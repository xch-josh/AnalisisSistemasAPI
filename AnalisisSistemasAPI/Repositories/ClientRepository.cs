using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;

namespace AnalisisSistemasAPI.Repositories
{
    public class ClientRepository : IClientRepository
    {
        MiAlmacencitoDbContext db;

        public ClientRepository(MiAlmacencitoDbContext db)
        {
            this.db = db;
        }

        public List<Client> GetClients()
        {
            var clients = db.Clients.Where(c => c.State).ToList();
            return clients;
        }

        public Client GetClient(int id)
        {
            var client = db.Clients.Find(id);
            return client;
        }

    public Client GetClientByDocument(string document)
    {
        // Como no hay campo Dpi en Client, buscamos por nombre (ajustar según necesidades)
        var client = db.Clients.FirstOrDefault(c => c.Name.Contains(document));
        return client;
    }

        public void Insert(Client client)
        {
            client.State = true;
            db.Clients.Add(client);
            db.SaveChanges();
        }

        public void Update(Client client)
        {
            db.Clients.Update(client);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var client = db.Clients.Find(id);
            
            if (client != null)
            {
                client.State = false;  // Soft delete
                db.SaveChanges();
            }
        }
    }
}
