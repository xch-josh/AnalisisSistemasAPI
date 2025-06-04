using AnalisisSistemasAPI.Models.DataBase;

namespace AnalisisSistemasAPI.Interfaces
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
        Product? GetProduct(int id);

        void UpdateProduct(Product product);
        void DeleteProduct(int  id);
        void InsertProduct(Product product);
    }
}
