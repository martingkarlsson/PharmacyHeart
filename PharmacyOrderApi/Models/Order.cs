using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace PharmacyOrderApi.Models
{
    public class Order
    {
        public Order()
        {
            Created = DateTime.Now;
        }

        [Key]
        public int OrderId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public Status Status { get; set; }
        public decimal TotalCost { get; set; }

    }

    public enum Status
    {
        Pending,
        Shipped,
        Delivered,
        Canceled,
        Declined,
    }
}
