using AnalisisSistemasAPI.Models.DataBase;
using AnalisisSistemasAPI.Models.UserModels;

namespace AnalisisSistemasAPI.Interfaces
{
    public interface IUserRepository
    {
        List<UserViewModel> GetUsers();
        User GetUser(int id);
        void Insert(UserModel model);
        void Update(UserModel model);
        void Delete(int id);
        SessionModel BeginSession(string username, string password);
        List<UserBranchModel> GetAccess(int id);
        List<UserBranchAccessModel> GetBranchAccess(int id);
        void UpdateBranchAccess(List<UserBranchAccessModel> model, int id);
    }
}
