using Contract.Model;
using Entities;

namespace Contract.Repository {
    public class ContractRepository : GenericRepository<ContractDetail>
    {
        private readonly ILogger<ContractRepository> _logger;

        public ContractRepository(DataContext dataContext, ILogger<ContractRepository> logger) : base(dataContext)
        {
            this._logger = logger;
        }

        public void PatchContractInfo(ContractDetail contractDetail) {
            this.Patch(contractDetail, "Description", "Title");
        }
    }
}