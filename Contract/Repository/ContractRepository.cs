using Contract.Model;
using Entities;

namespace Contract.Repository {
    public class ContractRepository : GenericRepository<ContractDetail>
    {
        private readonly ILogger<ContractRepository> _logger;

        public ContractRepository(DataContext dataContext, ILogger<ContractRepository> logger) : base(dataContext)
        {
            this._logger = logger;
            var _contractDetail = new ContractDetail();
            _contractDetail.CreatedAt = DateTime.Now;
            dataContext.Attach(_contractDetail).PropertyToPatch(ct=> ct.CreatedAt).Patch();

        }
    }
}