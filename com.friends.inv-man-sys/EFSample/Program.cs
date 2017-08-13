using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFSample.DAL;
using EFSample.DBContext;
using EFSample.Models;

namespace EFSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Institution institution = new Institution(){Name = "BITM", Location = "Dhaka"};

            //var trainee = new Trainee() { Name = "kamal", Address = "Dhaka", Institution = institution, EnrollDate = new DateTime(2017,2,12),SEID = "001"};



            //TraineeGateway traineeGateway = new TraineeGateway();

           //bool isSaved =  traineeGateway.Add(trainee);

            //int id = 1;

            //var trainee = traineeGateway.GetById(id);

           // if (trainee!=null)
           // {
           //     trainee.Address = "Sylhet";
           // }

           //bool isUpdated = traineeGateway.Update(trainee);

           //if (isSaved)
           //{
           //    Console.WriteLine("Successful!");
           //}

            TraineeGateway gateway = new TraineeGateway();
            var trainee = gateway.GetById(2);

            Console.WriteLine(" Trainee: "+trainee.Name+ " Institution: "+trainee.Institution.Name);


            Console.ReadKey();
        }
    }
}
