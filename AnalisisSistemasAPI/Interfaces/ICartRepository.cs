using AnalisisSistemasAPI.Models.DataBase;

namespace AnalisisSistemasAPI.Interfaces
{
    public interface ICartRepository
    {
        List<Cart> GetCartItems();
        Cart GetCartItem(int id);
        void Insert(Cart cartItem);
        void Update(Cart cartItem);
        void Delete(int id);
        void ClearCart();
    }
}
