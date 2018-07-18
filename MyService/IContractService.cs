using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    public interface IContractService
    {
        IQueryable<Contract> GetContracts();
        Contract GetContract(long id);
        void InsertContract(Contract entity);
        void UpdateContract(Contract entity);
        void DeleteContract(Contract entity);
    }
}
