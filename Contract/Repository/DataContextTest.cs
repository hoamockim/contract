
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
            _dataContext = new DataContext(connection);
            _dataContext.RegisterModels = new List<Action<ModelBuilder>>();
            _dataContext.RegisterModels.Add(mc => mc.Entity<ContractDetail>().ToTable("Contract"));
            _dataContext.RegisterModels.Add(mc => mc.Entity<Template>().ToTable("Template"));
        }
   }
}