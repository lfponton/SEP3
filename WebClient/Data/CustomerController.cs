using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Data
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase {
        private ICustomerDAO customerDao;

        public CustomerController(ICustomerDAO customerrDao) {
            this.customerDao = customerrDao;
        }

        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomerAsync([FromQuery] string? email, [FromQuery] string? password) {
            try {
                if (email == null || password == null) return BadRequest("Please enter email and password");

                Customer customer = await customerDao.GetCustomerAsync(email, password);
                return Ok(customer);
            }
            catch (NullReferenceException e) {
                return NotFound(e.Message);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomerAsync([FromBody] Customer customer) {
            try
            {
                Customer newCustomer = await customerDao.AddCustomerAsync(customer);
                return Created($"/{newCustomer.Email}", newCustomer);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("{email}")]
        public async Task<ActionResult<Customer>> UpdateCustomerAsync([FromRoute] string email, [FromBody] Customer customer) {
            try
            {

                
               // Customer u = await  customerDao.updateCustomerAsync(email,customer);
              //  return Ok(u);
            }
            catch (NullReferenceException e) {
                return NotFound(e.Message);
            }
            catch (Exception e) {
                return StatusCode(500, e.Message);
            }

            return null;
        }
    }

}