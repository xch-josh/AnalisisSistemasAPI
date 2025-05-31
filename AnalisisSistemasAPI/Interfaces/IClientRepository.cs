using AnalisisSistemasAPI.Models.DataBase;

namespace AnalisisSistemasAPI.Interfaces
{
    public interface IClientRepository
    {
        List<Client> GetClients();
        Client GetClient(int id);
        Client GetClientByDocument(string document);
        void Insert(Client client);
        void Update(Client client);
        void Delete(int id);
    }
}
