using AnalisisSistemasAPI.Models.DataBase;

namespace AnalisisSistemasAPI.Interfaces
{
    public interface IPermissionRepository
    {
        List<Permission> GetPermissions();
        Permission GetPermission(int id);
        void Insert(Permission permission);
        void Update(Permission permission);
        void Delete(int id);
    }
}
