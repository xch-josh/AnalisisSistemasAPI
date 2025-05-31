namespace AnalisisSistemasAPI.Models.UserModels
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool State { get; set; }

        public int RolId { get; set; }
    }
}
