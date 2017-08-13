using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFSample.DBContext;
using EFSample.Models;

namespace EFSample.DAL
{
    public class InstitutionGateway
    {
        public Institution GetById(int id)
        {
            TrainingDBContext db = new TrainingDBContext();
            var institution = db.Institutions.Include(c=>c.Trainees).FirstOrDefault(c => c.Id == id);
            return institution;
        }

        public Institution GetWithExistingTraineeById(int id)
        {
            TrainingDBContext db=new TrainingDBContext();
            var institution = db.Institutions.FirstOrDefault(c => c.Id == id);

            db.Entry(institution)
                .Collection(c => c.Trainees)
                .Query()
                .Where(c => c.IsDeleted == false)
                .Load();

            return institution;
        }

        public List<Institution> GetAll()
        {
            TrainingDBContext db = new TrainingDBContext();
            return db.Institutions.ToList();
        }
    }

    
}
