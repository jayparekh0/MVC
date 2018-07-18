using CommonService;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    public class ContractService:IContractService
    {
        private IRepository<Contract> _contractRepository;
        //private IRepository<UserProfile> userProfileRepository;

        public ContractService(IRepository<Contract> contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public IQueryable<Data.Contract> GetContracts()
        {
            return _contractRepository.Table;
        }

        public Data.Contract GetContract(long id)
        {
            return _contractRepository.GetById(id);
        }

        public void InsertContract(Data.Contract entity)
        {
            _contractRepository.Insert(entity);
        }

        public void UpdateContract(Data.Contract entity)
        {
            _contractRepository.Update(entity);
        }

        public void DeleteContract(Data.Contract entity)
        {
            _contractRepository.Delete(entity);
        }
    }
}
