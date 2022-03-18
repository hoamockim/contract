using Contract.Model;
using Microsoft.AspNetCore.Mvc;

namespace Contract.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class ContractController: ControllerBase {
        private readonly ILogger<ContractController> _logger;
        public ContractController(ILogger<ContractController> logger)
        {
            this._logger = logger;
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