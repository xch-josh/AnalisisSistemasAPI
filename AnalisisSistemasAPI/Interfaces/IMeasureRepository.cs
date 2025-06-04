using AnalisisSistemasAPI.Models.DataBase;

namespace AnalisisSistemasAPI.Interfaces
{
    public interface IMeasureRepository
    {
        List<Measure> GetMeasures();
        Measure GetMeasure(int id);
        void Insert(Measure measure);
        void Update(Measure measure);
        void Delete(int id);
    }
}
