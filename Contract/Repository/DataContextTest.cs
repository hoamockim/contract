
using Contract.Model;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace Contract.Repository { 

   public class DataContextTest
    {
        DataContext _dataContext;
        public DataContextTest() => InitDataContext();

        public void InitDataContext()
        {
            const string connection = "";
            DomainRegister.Instance
            .Register<ContractDetail>("Contract")
            .Register<Template>("Template").Build();
            _dataContext = new DataContext(connection);
        }
   }
}