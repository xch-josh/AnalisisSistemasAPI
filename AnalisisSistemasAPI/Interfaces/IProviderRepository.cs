using AnalisisSistemasAPI.Models.DataBase;
namespace AnalisisSistemasAPI.Interfaces
{
    public interface IProviderRepository
    {
        List<Provider> GetProviders();
        Provider GetProvider(int id);
        void Insert(Provider provider);
        void Update(Provider provider);
        void Delete(int id);
    }
}
