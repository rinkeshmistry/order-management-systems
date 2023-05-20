using Microsoft.EntityFrameworkCore;
using OrderManagementApi.Entities.Modules.Customer;
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
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [NotMapped]
        [JsonIgnore]
        public string OrderId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string OrderStatus { get; set; }

        [Required]
        public int ShippingId { get; set; }

        #region Child Table Relations
        public ICollection<OrderProduct> OrderProducts { get; set; }
        #endregion


        #region Computed Column
        [JsonIgnore]
        [Column("OrderId")]
        public string GenerateOrderId
        {
            get => $"OMS-{Id}";
            set => OrderId = value;
        }
        #endregion

        #region Foregin Key Configuration
        [ForeignKey("CustomerId")]
        [JsonIgnore]
        public Customer.Customer Customer { get; set; }

        #endregion
    }
}
