using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;

namespace AnalisisSistemasAPI.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        MiAlmacencitoDbContext db;

        public PermissionRepository(MiAlmacencitoDbContext db)
        {
            this.db = db;
        }


        public void Delete(int id)
        {
            var permission = db.Permissions.Find(id);

            db.Permissions.Remove(permission);
            db.SaveChanges();
        }

        public Permission GetPermission(int id)
        {
            var permission = db.Permissions.Find(id);

            return permission;
        }

        public List<Permission> GetPermissions()
        {
            var permissions = db.Permissions.ToList();

            return permissions;
        }

        public void Insert(Permission permission)
        {
            db.Permissions.Add(permission);
            db.SaveChanges();
        }

        public void Update(Permission permission)
        {
            db.Permissions.Update(permission);
            db.SaveChanges();
        }
    }
}
