namespace AnalisisSistemasAPI.Models.RolModels
{
    public class RolModuleAccessModel
    {
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public bool EnableAccess { get; set; }
        public int? Father { get; set; }
    }
}
