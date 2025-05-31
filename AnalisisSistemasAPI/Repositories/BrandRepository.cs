using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;

namespace AnalisisSistemasAPI.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        MiAlmacencitoDbContext db;

        public BrandRepository(MiAlmacencitoDbContext db)
        {
            this.db = db;
        }

        public List<Brand> GetBrands()
        {
            var lst = db.Brands.ToList();
            return lst;
        }

        public Brand GetBrand(int id)
        {
            var brand = db.Brands.Find(id);
            return brand;
        }

        public void Insert(Brand brand)
        {
            db.Brands.Add(brand);
            db.SaveChanges();
        }

        public void Update(Brand brand)
        {
            db.Brands.Update(brand);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
            db.SaveChanges();
        }
    }
}
