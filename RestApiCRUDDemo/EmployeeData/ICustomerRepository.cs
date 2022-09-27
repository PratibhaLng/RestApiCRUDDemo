using RestApiCRUDDemo.Models;
using System.Collections.Generic;

namespace RestApiCRUDDemo.EmployeeData
{
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomer();

        Customer GetCustomer(int Id);

        Customer AddCustomer(Customer customer);


        void DeleteCustomer(int Id);

        Customer EditCustomer(Customer customer);



    }
}
