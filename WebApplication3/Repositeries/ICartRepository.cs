using WebApplication3.Models;

namespace WebApplication3.Repositeries
{
    public interface ICartRepository
    {
        Cart Get(int id);
        //Cart Create(int id);
        bool Exist(int id);
    }
}
