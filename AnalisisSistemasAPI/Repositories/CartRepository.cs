using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.CartModels;
using AnalisisSistemasAPI.Models.DataBase;
using Microsoft.EntityFrameworkCore;

namespace AnalisisSistemasAPI.Repositories
{
    public class CartRepository : ICartRepository
    {
        MiAlmacencitoDbContext db;

        public CartRepository(MiAlmacencitoDbContext db)
        {
            this.db = db;
        }

        public List<CartViewModel> GetCartItems()
        {
            var cartItems = new List<CartViewModel>();

            cartItems = (from x in db.Carts
                         join y in db.Products on x.ProductId equals y.ProductId
                         select new CartViewModel
                         {
                             CartId = x.CartId,
                             Quantity = x.Quantity,
                             ProductName = y.Name,
                             CodeBar = y.CodeBar,
                             UnitPrice = y.UnitPrice,
                             Discount = x.Discount,
                             SalePrice = x.SalePrice,
                             Subtotal = x.Subtotal
                         }).ToList();

            return cartItems;
        }

        public Cart GetCartItem(int id)
        {
            var cartItem = db.Carts.Include(c => c.Product)
                             .FirstOrDefault(c => c.CartId == id);
            return cartItem;
        }

        public void Insert(CartModel model)
        {
            // Verificar si el producto ya existe en el carrito
            var existingItem = db.Carts.FirstOrDefault(c => c.ProductId == model.ProductId);
            
            if (existingItem != null)
            {
                // Actualizar cantidad
                existingItem.Quantity += model.Quantity;
                db.SaveChanges();
            }
            else
            {
                // Agregar nuevo ítem
                var cartItem = new Cart();

                cartItem.Quantity = model.Quantity;
                cartItem.PurchasePrice = model.PurchasePrice;
                cartItem.UnitPrice = model.UnitPrice;
                cartItem.Discount = model.Discount;
                cartItem.SalePrice = model.SalePrice;
                cartItem.Subtotal = model.Subtotal;
                cartItem.ProductId = model.ProductId;
                cartItem.UserId = model.UserId;
                cartItem.BranchId = model.BranchId;

                db.Carts.Add(cartItem);
                db.SaveChanges();
            }
        }

        public void Update(CartModel model)
        {
            var cartItem = db.Carts.Find(model.CartId);
            db.Carts.Update(cartItem);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var cartItem = db.Carts.Find(id);
            
            if (cartItem != null)
            {
                db.Carts.Remove(cartItem);
                db.SaveChanges();
            }
        }

        public void ClearCart()
        {
            var cartItems = db.Carts.ToList();
            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();
        }
    }
}
