using System;
namespace DCE.Models
{
    public class Order
    {
        public String? OrderId { get; set; }
        public String ProductId { get; set; }
        public int OrderStatus { get; set; }
        public int OrderType { get; set; }
        public String OrderBy { get; set; }
        public DateTime OrderedOn { get; set; }
        public DateTime ShippedOn { get; set; }
        public Boolean IsActive { get; set; }
    }
}

