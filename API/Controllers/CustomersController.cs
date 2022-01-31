using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("Customers")]
    public class CustomersController : ControllerBase
    {
        DataContext _appContext;
        public CustomersController(DataContext appContext)
        {
            _appContext = appContext;
        }

        #region Customer related methods
        [HttpGet]
        [Route("")]
        [Route("CustomersList")]
        public IActionResult CustomerList()
        {
            return new JsonResult(_appContext.Clients) 
            { 
                StatusCode = 200 
            };
        }

        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int id)
        {
            return new JsonResult(_appContext.Clients.FirstOrDefault(x => x.Id == id))
            {
                StatusCode = 200
            };
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var client = _appContext.Clients.FirstOrDefault(x => x.Id == id);
                if (client != null)
                {
                    _appContext.Clients.Remove(client);
                    _appContext.SaveChanges();
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500); 
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer()
        {
            try
            {
                using (var reader = new StreamReader(Request.Body))
                {
                    var client = JsonConvert.DeserializeObject<Client>(await reader.ReadToEndAsync());
                    _appContext.Add(client);
                    _appContext.SaveChanges();
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            try
            {
                var oldClient = _appContext.Clients.FirstOrDefault(x => x.Id == id);
                using (var reader = new StreamReader(Request.Body))
                {
                    var client = JsonConvert.DeserializeObject<Client>(await reader.ReadToEndAsync());
                    _appContext.Entry(oldClient).CurrentValues.SetValues(client);
                    _appContext.SaveChanges();
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        #endregion
    }
}
