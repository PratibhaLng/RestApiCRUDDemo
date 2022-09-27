using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUDDemo.EmployeeData;
using System.Threading.Tasks;
using System;
using RestApiCRUDDemo.Models;

namespace RestApiCRUDDemo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {


        private readonly ICategoryRepository _ccategory;

        public CategoryController(ICategoryRepository ccategory)
        {
            _ccategory = ccategory;


        }
        

        
        [HttpGet]
        [Route("api/[controller]")]

     
        public IActionResult GetAllCategory()
        {
            try
            {

                return Ok(_ccategory.GetAllCategory());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retreiving Data from Database");

            }


        }
        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult AddCategory(Category category)
        {
            _ccategory.AddCategory(category);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Host + HttpContext.Request.Path + "/" + category.Id, category);




        }



    


    [HttpGet("{id:int}")]
        public IActionResult GetCategory(int id)
        {
            try
            {
                var resultId = _ccategory.GetCategory(id);
                if (resultId == null)
                {
                    return NotFound();
                }
                return Ok(resultId);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retreiving Data from Database");

            }

        }

        [HttpDelete]
        [Route("delete/Id")]
        public IActionResult DeleteCategory(int Id)
            

        {
            var removeCategory = _ccategory.GetCategory(Id);
            if (removeCategory == null)
            {



                return NotFound($"Category With Id:{Id}  was not found");
            }

            {

                _ccategory.DeleteCategory(Id);
                return Ok(removeCategory);

            }
        }


        


        [HttpPut]
        [Route("Edit/Id")]
        public IActionResult EditCategory( Category category)

        {
            //var existingCategory = _ccategory.GetCategory(id);
           // if (existingCategory != null)
             //   category.Id = existingCategory.Id;
            _ccategory.EditCategory(category);
            return Ok(category);
        }


        //public IActionResult Index()
        //{
        //     return View();
        // }
    }
}
