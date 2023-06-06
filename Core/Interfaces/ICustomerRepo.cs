using Core.Entities;

namespace Core.Interfaces
{
    public interface ICustomerRepo:IGenericRepo<Customer>
    {
        Task<Customer> GetCustomerByIdAsync(int id);
    }
}
