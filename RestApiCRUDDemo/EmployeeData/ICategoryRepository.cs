using RestApiCRUDDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApiCRUDDemo.EmployeeData
{
    public interface ICategoryRepository
    {

        List<Category> GetAllCategory();
        
        Category GetCategory(int Id);

        Category AddCategory(Category category);
        

        void DeleteCategory(Category category);

        Category EditCategory(Category category);

    }
}
