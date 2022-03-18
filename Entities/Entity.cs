using System.Linq.Expressions;

namespace Entities {
    public abstract class Entity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public IList<Expression> expressions {get;set;}
    }
}
