using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using WebApplication3.Data;
using WebApplication3.Models;
using WebApplication3.ModelView;
using WebApplication3.Repositeries.IServices;
using WebApplication3.Repositeries.Services; // Assuming your UserService is in a Services folder

namespace WebApplication3.Controllers
{
    [Authorize]
    [Route("[controller]/{action}")]
    public class CartItemsController : Controller
    {
        private readonly ICartRepository _cartService;
        private readonly IUserService _userService;
        private readonly IProductService _product;
        private readonly IOrderService _orderService;
        public CartItemsController(ICartRepository cartService, IUserService userService , IProductService product , IOrderService order )
        {
            _cartService = cartService;
            _userService = userService;
            _product = product;
             _orderService = order;
 
        }

          

        // GET: CartItemsController
        public async Task<IActionResult> Index()
        {
            var currentUserId = await _userService.GetCurrentUserIdAsync();
            var cart = await _cartService.GetCartByUserIdAsync(currentUserId);

            if (cart == null)
            {
                return View(new CartViewModel()); // Return empty cart if no cart exists
            }

            var cartItems = await _cartService.GetCartItemsByUserIdAsync(currentUserId);

            var cartViewModel = new CartViewModel
            {
                CartItems = cartItems.ToList(),
            };

            return View(cartViewModel);
          
        }



        //[Route("{controller}/{action}")]
        public async Task<IActionResult> AddToCart( int productId, int quantity = 1)
        {
            var currentUserId = await _userService.GetCurrentUserIdAsync();
            
             await _cartService.AddItemToCartAsync(currentUserId, productId, quantity);

            
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> Checkout()
        {
            var currentUserId = await _userService.GetCurrentUserIdAsync();
            var cart = await _cartService.GetCartByUserIdAsync(currentUserId);

            if (cart == null || cart.CartItems.Count == 0)
            {
                return RedirectToAction("Index"); // Redirect to cart if empty
            }

            var order = await _orderService.CreateOrderAsync(currentUserId, cart.CartItems.ToList());
            TempData["message"] = "Order created successfully!";

            //var orderId = order.OrderId.ToString();

            return RedirectToAction("OrderConfirmation", new { orderId = order.OrderId.ToString() });


        }


        //[HttpGet("order-confirmation/{orderId}")]
        public async Task<IActionResult> OrderConfirmation([FromRoute] string orderId)
        {
            if (orderId ==null) // Validate order ID format
            {
                return BadRequest("Invalid order ID format."); // Handle invalid ID
              }

              var order = await _orderService.GetOrderById(orderId);
              var orderitems = await _orderService.GetOrderItemsByOrderId(orderId);

                 var vm = new OrderViewModel { Order = order, OrderItems = orderitems };

            if (order == null)
            {
                return NotFound(); // Handle order not found
            }
            return View(vm);

    }

    //[Route("{controller}/{action}/{productId}")]
    public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var currentUserId = await _userService.GetCurrentUserIdAsync();
            await _cartService.RemoveItemFromCartAsync(currentUserId, productId);

            return RedirectToAction("Index", "CartItems");
        }



    }
}