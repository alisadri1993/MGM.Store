using Store.Business.Entities;

namespace Store.Business.Interfaces;
public interface ICustomerRepository
{
    Task<int> Save(Customer customer);
    Task<Customer> GetAll();
}
