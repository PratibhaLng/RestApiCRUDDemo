using RestApiCRUDDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestApiCRUDDemo.EmployeeData
{
    public class CustomerRepository : ICustomerRepository


    {

        private EmployeeContext _employeeContext;
        public CustomerRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public Customer AddCustomer(Customer customer)
        {
            _employeeContext.Customers.Add(customer);
            _employeeContext.SaveChanges();
            return customer;
        }

        public void DeleteCustomer(int Id)
        {

            var result = _employeeContext.Customers.Where(a => a.Id == Id).FirstOrDefault();
            if (result != null)
            {

                _employeeContext.Customers.Remove(result);
                _employeeContext.SaveChanges();


            }
        }

        public Customer EditCustomer(Customer customer)
        {

            //var existingEmployee = _employeeContext.Categories.Find(category.Id);
            // if (existingEmployee != null)
            //{

            _employeeContext.Customers.Update(customer);
            _employeeContext.SaveChanges();
            return null;
            //    }
            //return category;
        }
            public List<Customer> GetAllCustomer()
        {
            return _employeeContext.Customers.ToList();
        }

        public Customer GetCustomer(int Id)
        {
            return _employeeContext.Customers.FirstOrDefault(x => x.Id == Id);

        }


    }
}
