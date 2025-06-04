using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;
using Microsoft.EntityFrameworkCore;

namespace AnalisisSistemasAPI.Repositories
{
    public class ProductRepository : IProductsRepository
    {
        MiAlmacencitoDbContext db;

        public ProductRepository(MiAlmacencitoDbContext db)
        {
            this.db = db;
        }

        public void DeleteProduct(int id)
        {
            var product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }        public Product? GetProduct(int id)
        {
            // Incluimos datos relacionados usando Include y marcamos el método como que puede retornar null
            var product = db.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Measure)
                .FirstOrDefault(p => p.ProductId == id);

            return product;
        }

        public List<Product> GetProducts()
        {
            // Incluimos datos relacionados usando Include
            var products = db.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Measure)
                .ToList();

            return products;
        }        public void InsertProduct(Product product)
        {
            // Para evitar problemas con las propiedades de navegación
            var newProduct = new Product
            {
                CodeBar = product.CodeBar,
                Name = product.Name,
                PurchasePrice = product.PurchasePrice,
                GainPercentage = product.GainPercentage,
                UnitPrice = product.UnitPrice,
                Description = product.Description,
                State = product.State,
                MeasureId = product.MeasureId,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId
            };
            
            db.Products.Add(newProduct);
            db.SaveChanges();
        }        public void UpdateProduct(Product product)
        {
            // Busca el producto existente para mantener las relaciones
            var existingProduct = db.Products.Find(product.ProductId);
            
            if (existingProduct != null)
            {
                // Actualiza solo las propiedades escalares, mantiene las relaciones
                existingProduct.CodeBar = product.CodeBar;
                existingProduct.Name = product.Name;
                existingProduct.PurchasePrice = product.PurchasePrice;
                existingProduct.GainPercentage = product.GainPercentage;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.Description = product.Description;
                existingProduct.State = product.State;
                existingProduct.MeasureId = product.MeasureId;
                existingProduct.BrandId = product.BrandId;
                existingProduct.CategoryId = product.CategoryId;
                
                db.SaveChanges();
            }
        }
    }
}
