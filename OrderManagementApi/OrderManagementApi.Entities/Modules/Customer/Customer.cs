using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderManagementApi.Entities.Modules.Customer
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string OrganizationName { get; set; }

        public string? WebSiteUrl { get; set; }

        #region Child Table Relations
        [JsonIgnore]
        public ICollection<CustomerContact> CustomerContacts { get; set; }

        [JsonIgnore]
        public ICollection<Order.Order> Orders { get; set; }

        #endregion
    }
}
