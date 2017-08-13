using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFSample.Models;

namespace EFSample.DBContext
{
    public class TrainingDBContext:DbContext
    {
        public TrainingDBContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Trainee> Trainee { get; set; } 
        public DbSet<Institution> Institutions { get; set; } 
    }
}
