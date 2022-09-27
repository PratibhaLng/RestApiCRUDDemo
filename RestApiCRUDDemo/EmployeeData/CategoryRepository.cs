using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUDDemo.EmployeeData
{
    public class CategoryRepository : ICategoryRepository
    {

        private EmployeeContext _employeeContext;
        public CategoryRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public  Category AddCategory(Category category)
        {
          //  category.Id = Id;
            _employeeContext.Categories.Add(category);
             _employeeContext.SaveChanges();
            return category;
        }

       
        public void  DeleteCategory(int Id)
        {



            var result =  _employeeContext.Categories.Where(a => a.Id == Id).FirstOrDefault();
            if (result != null)
            {

                _employeeContext.Categories.Remove(result);
                _employeeContext.SaveChanges();
                

            }

        }
        

        public Category EditCategory(Category category)
        {
            var existingEmployee = _employeeContext.Categories.Find(category.Id);
            if (existingEmployee != null)
            {

                _employeeContext.Categories.Update(category);
                _employeeContext.SaveChanges();
            }
            return category;
        }
        
        public  List<Category> GetAllCategory()
        {
            return _employeeContext.Categories.ToList();
        }

        public Category GetCategory(int Id)
        {
            return  _employeeContext.Categories.FirstOrDefault(a => a.Id == Id);
        }
    }
}
