using AnalisisSistemasAPI.Interfaces;
using AnalisisSistemasAPI.Models.DataBase;

namespace AnalisisSistemasAPI.Repositories
{
    public class MeasureRepository : IMeasureRepository
    {
        MiAlmacencitoDbContext db;

        public MeasureRepository(MiAlmacencitoDbContext db)
        {
            this.db = db;
        }

        public List<Measure> GetMeasures()
        {
            var lst = db.Measures.ToList();
            return lst;
        }

        public Measure GetMeasure(int id)
        {
            var measure = db.Measures.Find(id);
            return measure;
        }

        public void Insert(Measure measure)
        {
            db.Measures.Add(measure);
            db.SaveChanges();
        }

        public void Update(Measure measure)
        {
            db.Measures.Update(measure);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var measure = db.Measures.Find(id);
            if (measure != null)
            {
                db.Measures.Remove(measure);
                db.SaveChanges();
            }
        }
    }
}
