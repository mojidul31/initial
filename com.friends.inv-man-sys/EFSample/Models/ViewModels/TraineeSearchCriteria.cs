using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EFSample.Models.ViewModels
{
    public class TraineeSearchCriteria
    {
        public string Name { get; set; }
        public string SEID { get; set; }
        public DateTime? EnrollFrom { get; set; }
        public DateTime? EnrollTo { get; set; }

    }
}
