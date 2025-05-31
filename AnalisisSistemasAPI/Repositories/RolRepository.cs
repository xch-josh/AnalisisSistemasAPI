using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;
using AnalisisSistemasAPI.Models.RolModels;

namespace AnalisisSistemasAPI.Repositories
{
    public class RolRepository : IRolRepository
    {
        MiAlmacencitoDbContext db;

        public RolRepository(MiAlmacencitoDbContext db)
        {
            this.db = db;
        }

        public void Delete(int id)
        {
            var rol = db.Rols.Find(id);

            db.Rols.Remove(rol);
            db.SaveChanges();
        }

        public Rol GetRol(int id)
        {
            var rol = db.Rols.Find(id);

            return rol;
        }

        public List<Rol> GetRoles()
        {
            var roles = db.Rols.ToList();

            return roles;
        }

        public void Insert(Rol rol)
        {
            db.Rols.Add(rol);
            db.SaveChanges();
        }

        public void Update(Rol rol)
        {
            db.Rols.Update(rol);
            db.SaveChanges();
        }

        public List<RolAccessModel> GetAccess(int id)
        {
            var access = new List<RolAccessModel>();

            access = (from x in db.RolAccesses
                          join z in db.Modules on x.ModuleId equals z.ModuleId
                          where x.RolId == id
                          select new RolAccessModel
                          {
                              ModuleID = z.ModuleId,
                              ModuleName = z.Name,
                              Link = z.Link,
                              Icon = z.Icon ?? string.Empty,
                              Father = z.Father,
                          }).ToList();

            return access;
        }

        public List<RolModuleAccessModel> GetModuleAccess(int id)
        {
            var result = (from m in db.Modules
                          from ra in db.RolAccesses
                              .Where(r => r.ModuleId == m.ModuleId && r.RolId == id)
                              .DefaultIfEmpty()
                          select new RolModuleAccessModel
                          {
                              ModuleID = m.ModuleId,
                              ModuleName = m.Name,
                              EnableAccess = ra != null,
                              Father = m.Father
                          }).ToList();
            return result;
        }

        public void UpdateModuleAccess(List<RolModuleAccessModel> model, int id)
        {
            var currentAccessList = db.RolAccesses.Where(x => x.RolId == id).ToList();
            var modulesWithAccess = model.Where(m => m.EnableAccess).Select(m => m.ModuleID).ToList();
            var currentModulesWithAccess = currentAccessList.Select(ca => ca.ModuleId).ToList();
            var accessesToAdd = modulesWithAccess
                .Where(moduleId => !currentModulesWithAccess.Contains(moduleId))
                .Select(moduleId => new RolAccess
                {
                    ModuleId = moduleId,
                    RolId = id
                })
                .ToList();

            var modulesWithoutAccess = model.Where(m => !m.EnableAccess).Select(m => m.ModuleID).ToList();
            var accessesToRemove = currentAccessList
                .Where(ca => modulesWithoutAccess.Contains(ca.ModuleId))
                .ToList();

            
            if (accessesToAdd.Any())
            {
                db.RolAccesses.AddRange(accessesToAdd);
            }

            if (accessesToRemove.Any())
            {
                db.RolAccesses.RemoveRange(accessesToRemove);
            }

            
            db.SaveChanges();
        }
    }
}
