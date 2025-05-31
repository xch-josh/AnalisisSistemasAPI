using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;

namespace AnalisisSistemasAPI.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        MiAlmacencitoDbContext db;

        public ProviderRepository(MiAlmacencitoDbContext db)
        {
            this.db = db;
        }

        public List<Provider> GetProviders()
        {
            var lst = db.Providers.ToList();
            return lst;
        }

        public Provider GetProvider(int id)
        {
            var provider = db.Providers.Find(id);
            return provider;
        }

        public void Insert(Provider provider)
        {
            db.Providers.Add(provider);
            db.SaveChanges();
        }

        public void Update(Provider provider)
        {
            db.Providers.Update(provider);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var provider = db.Providers.Find(id);
            db.Providers.Remove(provider);
            db.SaveChanges();
        }
    }
}
