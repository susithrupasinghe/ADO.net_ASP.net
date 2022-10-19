using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DCE.Models;
using DCE.Models.RequestDto;
using DCE.Repositories;
using DCE.Repositories.Impl;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DCE.Controllers
{
    [Route("api/customer")]
    public class InventoryController : Controller
    {
        private static readonly ICustomerRepository customerRepository = new CustomerRepository();
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(ILogger<InventoryController> logger)
        {
            _logger = logger;
        }

        // POST: api/customer/create
        [HttpPost("create")]
        public IActionResult CreateCustomer([FromBody] CreateCustomerDto customer) {

            try
            {

                if (customerRepository.CreateCustomer(customer))
                {

                    _logger.LogInformation("CreateCustomer : User created {}", customer.ToString());
                    Response.StatusCode = StatusCodes.Status201Created;
                    return Json(
                        new GenericResponse
                        {
                            success = true,
                            message = "Customer created successfully",
                            payload = null

                        });
                }
                else {

                    _logger.LogError("CreateCustomer : User not created {}", customer.ToString());
                    Response.StatusCode = StatusCodes.Status404NotFound;
                    return Json(
                        new GenericResponse
                        {
                            success = false,
                            message = "Customer insertion failed",
                            payload = null
                        }
                        );
                }

              
            }
            catch (Exception ex) {

                _logger.LogError("CreateCustomer : Exception {}", ex);
                Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                return Json(
                    new GenericResponse
                    {
                        success = false,
                        message = "Customer insertion failed",
                        payload = null
                    }
                    );

            }

        }

        // GET: api/customer/all
        [HttpGet("all")]
        public IActionResult GetAllCustomers()
        {
            try
            {

                IEnumerable<Customer> customers = customerRepository.GetAllCustomers();
                Response.StatusCode = StatusCodes.Status200OK;
                return Json(
                    new GenericResponse
                    {
                        success = true,
                        message = "All customers retrived",
                        payload = customers

                    });
            }
            catch (Exception ex)
            {

                _logger.LogError("GetAllCustomers : Exception {}", ex);
                Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                return Json(
                    new GenericResponse
                    {
                        success = false,
                        message = "Customer retrival failed",
                        payload = null
                    }
                    );

            }
        }

        // PUT api/customer/{guid}
        [HttpPut("{guid}")]
        public IActionResult UpdateCustomer([FromBody] UpdateCustomerDto customer, String guid)
        {

            try
            {

                if (customerRepository.UpdateCustomer(customer, guid))
                {

                    _logger.LogInformation("UpdateCustomer : User created {}", customer.ToString());
                    Response.StatusCode = StatusCodes.Status201Created;
                    return Json(
                        new GenericResponse
                        {
                            success = true,
                            message = "Customer updated successfully",
                            payload = null

                        });
                }
                else
                {

                    _logger.LogError("UpdateCustomer : User not created {}", customer.ToString());
                    Response.StatusCode = StatusCodes.Status404NotFound;
                    return Json(
                        new GenericResponse
                        {
                            success = false,
                            message = "Customer update process failed",
                            payload = null
                        }
                        );
                }


            }
            catch (Exception ex)
            {

                _logger.LogError("UpdateCustomer : Exception {}", ex);
                Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                return Json(
                    new GenericResponse
                    {
                        success = false,
                        message = "Customer update process failed",
                        payload = null
                    }
                    );

            }

        }

        // DELETE api/customer/{guid}
        [HttpDelete("{guid}")]
        public IActionResult DeleteCustomer(String guid)
        {

            try
            {

                if (customerRepository.DeleteCustomer(guid))
                {

                    _logger.LogInformation("DeleteCustomer : User deleted {}", guid);
                    Response.StatusCode = StatusCodes.Status200OK;
                    return Json(
                        new GenericResponse
                        {
                            success = true,
                            message = "Customer deleted successfully",
                            payload = null

                        });
                }
                else
                {

                    _logger.LogError("DeleteCustomer : User not deleted {}", guid);
                    Response.StatusCode = StatusCodes.Status404NotFound;
                    return Json(
                        new GenericResponse
                        {
                            success = false,
                            message = "Customer deletetion failed",
                            payload = null
                        }
                        );
                }


            }
            catch (Exception ex)
            {

                _logger.LogError("DeleteCustomer : Exception {}", ex);
                Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                return Json(
                    new GenericResponse
                    {
                        success = false,
                        message = "Customer deletetion failed",
                        payload = null
                    }
                    );

            }
        }


        // GET api/customer/orders/active
        [HttpGet("orders/{guid}/active")]
        public IActionResult GetActiveOrdersByCustomer(String guid)
        {
            try
            {

                IEnumerable<Order> orders =  customerRepository.GetActiveOrders(guid);
                Response.StatusCode = StatusCodes.Status200OK;
                return Json(
                    new GenericResponse
                    {
                        success = true,
                        message = "Active orders retrival successfull",
                        payload = orders

                    });
            }
            catch (Exception ex)
            {

                _logger.LogError("DeleteCustomer : Exception {}", ex);
                Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                return Json(
                    new GenericResponse
                    {
                        success = false,
                        message = "Active orders retrival failed",
                        payload = null
                    }
                    );

            }
        }

    }
}

