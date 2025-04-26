using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;

namespace AnalisisSistemasAPI.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        MiAlmacencitoDbContext db;

        public BranchRepository(MiAlmacencitoDbContext db)
        {
            this.db = db;
        }

        public List<Branch> GetBranches()
        {
            var lst = db.Branches.ToList();

            return lst;
        }

        public Branch GetBranch(int id)
        {
            var branch = db.Branches.Find(id);

            return branch;
        }

        public void Insert(Branch branch)
        {
            db.Branches.Add(branch);
            db.SaveChanges();
        }

        public void Update(Branch branch)
        {
            db.Branches.Update(branch);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var branch = db.Branches.Find(id);

            db.Branches.Remove(branch);
            db.SaveChanges();
        }
    }
}
