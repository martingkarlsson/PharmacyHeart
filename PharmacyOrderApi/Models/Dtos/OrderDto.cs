namespace PharmacyOrderApi.Models.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Created { get; set; }
        public Status Status { get; set; }
        public decimal TotalCost { get; set; }
    }
}
