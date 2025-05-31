using AnalisisSistemasAPI.Models.DataBase;
using AnalisisSistemasAPI.Models.RolModels;

namespace AnalisisSistemasAPI.Interfaces
{
    public interface IRolRepository
    {
        List<Rol> GetRoles();
        Rol GetRol(int id);
        void Insert(Rol rol);
        void Update(Rol rol);
        void Delete(int id);
        List<RolAccessModel> GetAccess(int id);
        List<RolModuleAccessModel> GetModuleAccess(int id);
        void UpdateModuleAccess(List<RolModuleAccessModel> model, int id);
    }
}
