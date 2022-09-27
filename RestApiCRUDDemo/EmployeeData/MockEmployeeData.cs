using RestApiCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiCRUDDemo.EmployeeData
{
    public class MockEmployeeData : IEmployeeData

    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
            Id=Guid.NewGuid(),
            Name="Employee One"

            },



            new Employee()
            {
            Id=Guid.NewGuid(),
            Name="Employee One"

            }


        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;  
            return existingEmployee;
        }

        public List<Employee> GetEmployee()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id==id);
        }
    }
}
