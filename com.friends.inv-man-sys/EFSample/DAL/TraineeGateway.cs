using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFSample.DBContext;
using EFSample.Models;
using EFSample.Models.ViewModels;

namespace EFSample.DAL
{
    public class TraineeGateway
    {
        public bool Add(Trainee trainee)
        {
            TrainingDBContext db = new TrainingDBContext();
            db.Trainee.Add(trainee);

            int rowAffeted = db.SaveChanges();

            return rowAffeted>0;
        }

        public List<Trainee> Search(TraineeSearchCriteria criteria)
        {
            TrainingDBContext db = new TrainingDBContext();
            var traineeList = db.Trainee.AsQueryable();

            if (criteria == null)
            {
                return traineeList.ToList();
            }

            if (!String.IsNullOrEmpty(criteria.Name))
            {
                traineeList = traineeList.Where(c => c.Name.StartsWith(criteria.Name));

            }

            if (!String.IsNullOrEmpty(criteria.SEID))
            {
                traineeList = traineeList.Where(c => c.SEID == criteria.SEID);
            }

            if (criteria.EnrollFrom!=null)
            {
                traineeList = traineeList.Where(c => c.EnrollDate >= criteria.EnrollFrom);
            }

            if (criteria.EnrollTo != null)
            {
                traineeList = traineeList.Where(c => c.EnrollDate <= criteria.EnrollTo);
            }

            return traineeList.ToList();
        }

        public Trainee GetById(int id)
        {
            TrainingDBContext db = new TrainingDBContext();
            return db.Trainee.AsNoTracking().Include(c=>c.Institution).FirstOrDefault(c => c.Id == id);
        }

        public bool Update(Trainee trainee)
        {
            TrainingDBContext db = new TrainingDBContext();

            db.Trainee.Attach(trainee);
            db.Entry(trainee).State =  EntityState.Modified;

            int rowAffected = db.SaveChanges();

            return rowAffected > 0;

        }

        public List<Trainee> GetAll()
        {
            TrainingDBContext db = new TrainingDBContext();

            return db.Trainee.Include(t => t.Institution).ToList();
        }

        public bool Delete(Trainee trainee)
        {
            TrainingDBContext db = new TrainingDBContext();

            db.Trainee.Attach(trainee);
            db.Entry(trainee).State = EntityState.Deleted;

            int rowAffected = db.SaveChanges();
            return rowAffected > 0;
        }
    }
}
