using AnalisisSistemasAPI.Models.CartModels;
using AnalisisSistemasAPI.Models.DataBase;

namespace AnalisisSistemasAPI.Interfaces
{
    public interface ICartRepository
    {
        List<CartViewModel> GetCartItems();
        Cart GetCartItem(int id);
        void Insert(CartModel cartItem);
        void Update(CartModel cartItem);
        void Delete(int id);
        void ClearCart();
    }
}
