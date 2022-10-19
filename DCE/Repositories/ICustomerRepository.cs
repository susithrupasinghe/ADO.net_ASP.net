using System;
using DCE.Models;
using DCE.Models.RequestDto;

namespace DCE.Repositories
{
    public interface ICustomerRepository
    {
        bool CreateCustomer(CreateCustomerDto customer);
        IEnumerable<Customer> GetAllCustomers();
        bool UpdateCustomer(UpdateCustomerDto customer, String userId);
        bool DeleteCustomer(String customerId);
        IEnumerable<Order> GetActiveOrders(String customerId);
    }
}

