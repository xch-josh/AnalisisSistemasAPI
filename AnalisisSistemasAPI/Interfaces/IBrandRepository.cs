using AnalisisSistemasAPI.Models.DataBase;
namespace AnalisisSistemasAPI.Interfaces
{
    public interface IBrandRepository
    {
        List<Brand> GetBrands();
        Brand GetBrand(int id);
        void Insert(Brand brand);
        void Update(Brand brand);
        void Delete(int id);
    }
}
