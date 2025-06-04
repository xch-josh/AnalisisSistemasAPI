using AnalisisSistemasAPI.Models.DataBase;
namespace AnalisisSistemasAPI.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        Category GetCategory(int id);
        void Insert(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
