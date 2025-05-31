using AnalisisSistemasAPI.Interfaces;
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

        public List<Cart> GetCartItems()
        {
            var cartItems = db.Carts.Include(c => c.Product)
                              .ThenInclude(p => p.Brand)
                              .Include(c => c.Product.Category)
                              .Include(c => c.Product.Measure)
                              .ToList();
            return cartItems;
        }

        public Cart GetCartItem(int id)
        {
            var cartItem = db.Carts.Include(c => c.Product)
                             .FirstOrDefault(c => c.CartId == id);
            return cartItem;
        }

        public void Insert(Cart cartItem)
        {
            // Verificar si el producto ya existe en el carrito
            var existingItem = db.Carts.FirstOrDefault(c => c.ProductId == cartItem.ProductId);
            
            if (existingItem != null)
            {
                // Actualizar cantidad
                existingItem.Quantity += cartItem.Quantity;
                db.SaveChanges();
            }
            else
            {
                // Agregar nuevo ítem
                db.Carts.Add(cartItem);
                db.SaveChanges();
            }
        }

        public void Update(Cart cartItem)
        {
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
