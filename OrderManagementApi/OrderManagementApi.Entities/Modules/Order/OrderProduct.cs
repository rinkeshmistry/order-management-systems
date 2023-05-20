using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderManagementApi.Entities.Modules.Order
{
    public class OrderProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [JsonIgnore]
        public long OrderId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        #region Foreign Key Configuration
        [ForeignKey("OrderId")]
        [JsonIgnore]
        public Order Order { get; set; }

        #endregion

    }
}
