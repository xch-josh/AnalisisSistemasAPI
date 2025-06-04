using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;
using AnalisisSistemasAPI.Models.RolModels;
using AnalisisSistemasAPI.Models.UserModels;
using System.Linq;

namespace AnalisisSistemasAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        MiAlmacencitoDbContext db;

        public UserRepository(MiAlmacencitoDbContext db)
        {
            this.db = db;
        }

        public SessionModel BeginSession(string username, string password)
        {
            var user = new SessionModel();

            user = (from x in db.Users
                    join y in db.Rols on x.RolId equals y.RolId
                    where x.UserName == username && x.Password == password
                    select new SessionModel
                    {
                        UserId = x.UserId,
                        Name = x.Name,
                        Username = x.UserName,
                        RolID = x.RolId,
                        Rol = y.Name
                    }).FirstOrDefault();

            return user;
        }

        public void Delete(int id)
        {
            var user = db.Users.Find(id);

            db.Users.Remove(user);
            db.SaveChanges();
        }

        public User GetUser(int id)
        {
            var user = db.Users.Find(id);

            return user;
        }

        public List<UserViewModel> GetUsers()
        {
            var users = (from x in db.Users
                         join y in db.Rols on x.RolId equals y.RolId
                         select new UserViewModel
                         {
                             userId = x.UserId,
                             name = x.Name,
                             userName = x.UserName,
                             state = x.State,
                             rol = y.Name
                         }).ToList();

            return users;
        }

        public void Insert(UserModel model)
        {
            var user = new User();

            user.Name = model.Name;
            user.UserName = model.UserName;
            user.RolId = model.RolId;
            user.State = model.State;
            user.Password = model.Password;

            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Update(UserModel model)
        {
            var user = db.Users.Find(model.UserId);

            user.Name = model.Name;
            user.UserName = model.UserName;
            user.RolId = model.RolId;
            user.State = model.State;
            user.Password = model.Password;

            db.Users.Update(user);
            db.SaveChanges();
        }

        public List<UserBranchModel> GetAccess(int id)
        {
            var access = new List<UserBranchModel>();

            access = (from x in db.UserBranches
                      join z in db.Branches on x.BranchId equals z.BranchId
                      where x.UserId == id
                      select new UserBranchModel
                      {
                          BranchID = z.BranchId,
                          BranchName = z.Name
                      }).ToList();

            return access;
        }

        public List<UserBranchAccessModel> GetBranchAccess(int id)
        {
            var result = (from b in db.Branches
                          from ub in db.UserBranches
                              .Where(r => r.BranchId == b.BranchId && r.UserId == id)
                              .DefaultIfEmpty()
                          select new UserBranchAccessModel
                          {
                              BranchID = b.BranchId,
                              BranchName = b.Name,
                              EnableAccess = ub != null
                          }).ToList();
            return result;
        }

        public void UpdateBranchAccess(List<UserBranchAccessModel> model, int id)
        {
            var currentAccessList = db.UserBranches.Where(x => x.UserId == id).ToList();
            var branchesWithAccess = model.Where(m => m.EnableAccess).Select(m => m.BranchID).ToList();
            var currentBranchesWithAccess = currentAccessList.Select(ca => ca.BranchId).ToList();
            var accessesToAdd = branchesWithAccess
                .Where(branchId => !currentBranchesWithAccess.Contains(branchId))
                .Select(branchId => new UserBranch
                {
                    BranchId = branchId,
                    UserId = id
                })
                .ToList();

            var branchesWithoutAccess = model.Where(m => !m.EnableAccess).Select(m => m.BranchID).ToList();
            var accessesToRemove = currentAccessList
                .Where(ca => branchesWithoutAccess.Contains(ca.BranchId))
                .ToList();


            if (accessesToAdd.Any())
            {
                db.UserBranches.AddRange(accessesToAdd);
            }

            if (accessesToRemove.Any())
            {
                db.UserBranches.RemoveRange(accessesToRemove);
            }


            db.SaveChanges();
        }
    }
}
