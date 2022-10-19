using System;
namespace DCE.Models.RequestDto
{
    public class UpdateCustomerDto
    {
        public String? username { get; set; }
        public String? email { get; set; }
        public String? firstName { get; set; }
        public String? lastName { get; set; }
    }
}

