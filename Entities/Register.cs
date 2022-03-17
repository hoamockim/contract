using Microsoft.EntityFrameworkCore;

namespace Entities { 
    public sealed class DomainRegister {
        internal List<Action<ModelBuilder>> RegisterModels { get; set; }
        internal  bool IsRegistered {get; set;}
        private DomainRegister(){
            RegisterModels = new List<Action<ModelBuilder>>();
        }

        private static readonly Lazy<DomainRegister> lazy = new Lazy<DomainRegister>(() => new DomainRegister());    
        public static DomainRegister Instance {
            get{
                return lazy.Value;
            }
        }

        public DomainRegister Register<T>(string name) where T: Entity {
            RegisterModels.Add(mc => mc.Entity<T>().ToTable(name));
            return Instance;
        }
    }
}