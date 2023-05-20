using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OrderManagementApi.Entities.Modules.Customer
{
    public class CustomerContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string BranchName { get; set; }

        [Required]
        public string BranchAddress { get; set; }

        [Required]
        public string BranchCity { get; set; }

        [Required]
        public string BranchState { get; set; }

        [Required]
        public string BranchCountry { get; set; }

        [Required]
        public int CustomerId { get; set; }



        #region Foreign Key Relation
        [ForeignKey("CustomerId")]
        [JsonIgnore]
        public Customer Customer { get; set; }
        #endregion



    }
}
