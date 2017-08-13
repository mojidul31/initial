using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SEID { get; set; }
        public DateTime EnrollDate { get; set; }
        public string Address { get; set; }
        public int InstitutionId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Institution Institution { get; set; }
    }
}
