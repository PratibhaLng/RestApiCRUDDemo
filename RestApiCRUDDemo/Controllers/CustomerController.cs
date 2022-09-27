using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUDDemo.EmployeeData;
using RestApiCRUDDemo.Models;
using System;

namespace RestApiCRUDDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {


        


            private readonly ICustomerRepository _ccustomer;

            public CustomerController(ICustomerRepository ccustomer)
            {
                _ccustomer = ccustomer;


            }



            [HttpGet]
            [Route("api/[controller]")]


            public IActionResult GetAllCustomer()
            {
                try
                {

                    return Ok(_ccustomer.GetAllCustomer());
                }
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "Error in Retreiving Data from Database");

                }


            }
            [HttpPost]
            [Route("api/[controller]")]

            public IActionResult AddCustomer(Customer customer)
            {
                _ccustomer.AddCustomer(customer);
                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Host + HttpContext.Request.Path + "/" + customer.Id, customer);




            }






            [HttpGet("{id:int}")]
            public IActionResult GetCustomer(int id)
            {
                try
                {
                    var resultId = _ccustomer.GetCustomer(id);
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
            public IActionResult DeleteCustomer(int Id)


            {
                var removeCustomer = _ccustomer.GetCustomer(Id);
                if (removeCustomer == null)
                {



                    return NotFound($"Category With Id:{Id}  was not found");
                }

                {

                    _ccustomer.DeleteCustomer(Id);
                    return Ok(removeCustomer);

                }
            }





            [HttpPut]
            [Route("Edit/Id")]
            public IActionResult EditCustomer(int id, Customer customer)

            {
               // var existingCustomer = _ccustomer.GetCustomer(id);
               // if (existingCustomer != null)
                 //   customer.Id = existingCustomer.Id;
                _ccustomer.EditCustomer(customer);
                return Ok(customer);
            }




            //public IActionResult Index()
            // {
            //     return View();
            // }
        }
    }
