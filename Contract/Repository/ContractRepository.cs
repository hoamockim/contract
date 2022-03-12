using Contract.Model;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace Contract.Repository {
    public class ContractRepository : GenericRepository<ContractDetail>
    {
        public ContractRepository(DataContext dataContext) : base(dataContext)
        {
            
        }
    }
}