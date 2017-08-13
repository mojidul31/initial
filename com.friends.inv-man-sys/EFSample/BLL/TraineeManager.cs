using System.Collections.Generic;
using EFSample.DAL;
using EFSample.Models;

namespace EFSample.Core.BLL
{
    public class TraineeManager
    {
        TraineeGateway _traineeGateway = new TraineeGateway();
        public List<Trainee> GetAll()
        {
            return  _traineeGateway.GetAll();
           
        }

        public Trainee GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return _traineeGateway.GetById((int)id);
        }

        public bool Add(Trainee trainee)
        {
            return _traineeGateway.Add(trainee);
        }

        public bool Update(Trainee trainee)
        {
            return _traineeGateway.Update(trainee);
        }

        public bool Delete(Trainee trainee)
        {
            return _traineeGateway.Delete(trainee);
        }
    }
}