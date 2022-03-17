
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities;

namespace Contract.Model {
    [Table("ContractDetail")]
    public class ContractDetail: Entity
    {
        [Key]
        public int id {get;set;}
        public ContractDetail(){}

        public string CustomerCode {get;set;}
    }
}
