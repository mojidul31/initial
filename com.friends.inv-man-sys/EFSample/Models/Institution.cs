using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample.Models
{
    public class Institution
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public List<Trainee> Trainees { get; set; }
    }
}
