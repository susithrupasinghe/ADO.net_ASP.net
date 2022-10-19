using System;
namespace DCE.Models
{
    public class Product
    {
        public String? ProductId { get; set; }
        public String ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public String SupplierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public Boolean IsActive { get; set; }
    }
}

