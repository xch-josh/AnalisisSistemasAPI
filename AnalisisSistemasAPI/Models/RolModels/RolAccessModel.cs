namespace AnalisisSistemasAPI.Models.RolModels
{
    public class RolAccessModel
    {
        public int ModuleID { get; set; }
        public string? ModuleName { get; set; }
        public string? Link { get; set; }
        public string? Icon { get; set; }
        public int? Father { get; set; }
    }
}
