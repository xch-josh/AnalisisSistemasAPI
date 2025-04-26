using AnalisisSistemasAPI.Models.DataBase;
namespace AnalisisSistemasAPI.Interfaces
{
    public interface IBranchRepository
    {
        List<Branch> GetBranches();
        Branch GetBranch(int id);
        void Insert(Branch branch);
        void Update(Branch branch);
        void Delete(int id);
    }
}
