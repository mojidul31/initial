using System.Collections.Generic;
using EFSample.DAL;
using EFSample.Models;

namespace EFSample.Core.BLL
{
    public class InstitutionManager
    {
        InstitutionGateway _gateway = new InstitutionGateway();
        public List<Institution> GetAll()
        {
            return _gateway.GetAll();
        }
    }
}