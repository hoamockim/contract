using Contract.Model;
using Contract.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Contract.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class ContractController: ControllerBase {
        private readonly ILogger<ContractController> _logger;
        private readonly ContractRepository _contractRepository;
        public ContractController(ILogger<ContractController> logger, ContractRepository contractRepository)
        {
            this._logger = logger;
            _contractRepository = contractRepository;
        }

        [HttpGet(Name = "GetContractDetail")]
        public ContractDetail Get() 
        {
            return new ContractDetail();
        }

        [HttpGet(Name = "GetTemplate")]
        public Template GetTempate() 
        {
            return new Template();
        }
    }
}