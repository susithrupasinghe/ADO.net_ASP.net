using System;
namespace DCE.Models
{
    public class Supplier
    {
        public String? SupplierId { get; set; }
        public String SupplierName { get; set; }
        public DateTime CreatedOn { get; set; }
        public Boolean IsActive { get; set; }
    }
}

