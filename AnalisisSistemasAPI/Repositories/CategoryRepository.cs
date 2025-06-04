using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;

namespace AnalisisSistemasAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        MiAlmacencitoDbContext db;

        public CategoryRepository(MiAlmacencitoDbContext db)
        {
            this.db = db;
        }

        public List<Category> GetCategories()
        {
            var lst = db.Categories.ToList();
            return lst;
        }

        public Category GetCategory(int id)
        {
            var category = db.Categories.Find(id);
            return category;
        }

        public void Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void Update(Category category)
        {
            db.Categories.Update(category);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
        }
    }
}
