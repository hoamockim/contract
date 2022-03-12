
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities;

namespace Contract.Model {
    
    [Table("Template")]
    public class Template: Entity
    {
        [Key]
        public int id {get;set;}
        public Template()
        {
        }

    }
}
