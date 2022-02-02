﻿using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;

namespace API.Controllers
{
    public class ClientController : BaseApiController
    {
        IUnitOfWork _unitOfWork;
        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Customer related methods
        [HttpGet("", Name = "GetClients")]
        public async Task<ActionResult<IEnumerable<Client>>> ClientList()
        {
            var clients = await _unitOfWork.ClientRepository.GetClientsAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Details(int id)
        {
            var client = await _unitOfWork.ClientRepository.GetClientByIdAsync(id);
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _unitOfWork.ClientRepository.GetClientByIdAsync(id);
            _unitOfWork.ClientRepository.DeleteClient(client);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Cannot delete client");
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            var createdClient = await _unitOfWork.ClientRepository.CreateClient(client);

            if (await _unitOfWork.Complete())
            {
                return CreatedAtRoute("GetClients", createdClient);
            }

            return BadRequest("Cannot create client");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateClient(Client client)
        {
            _unitOfWork.ClientRepository.Update(client);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Error while updating client");
        }
        #endregion


        /* DataContext _appContext;
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

        [HttpGet("Details")]
        public IActionResult Details(int id)
        {
            return new JsonResult(_appContext.Clients.FirstOrDefault(x => x.Id == id))
            {
                StatusCode = 200
            };
        }

        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var client = _appContext.Clients.FirstOrDefault(x => x.Id == id);
                if (client != null)
                {
                    _appContext.Clients.Remove(client);
                    _appContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer()
        {
            try
            {
                using (var reader = new StreamReader(Request.Body))
                {
                    var client = JsonConvert.DeserializeObject<Client>(await reader.ReadToEndAsync());
                    _appContext.Add(client);
                    _appContext.SaveChanges();
                    return Created("", client);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            try
            {
                var oldClient = _appContext.Clients.FirstOrDefault(x => x.Id == id);
                if (oldClient == null)
                {
                    return NotFound();
                }

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
                return BadRequest();
            }
        }
        #endregion

        #region Cities
        [HttpGet("CitiesList")]
        public IActionResult CitiesList()
        {
            return new JsonResult(_appContext.Cities)
            {
                StatusCode = 200
            };
        }

        [HttpPost("CreateCity")]
        public async Task<IActionResult> CreateCity()
        {
            try
            {
                using (var reader = new StreamReader(Request.Body))
                {
                    var city = JsonConvert.DeserializeObject<City>(await reader.ReadToEndAsync());
                    _appContext.Cities.Add(city);
                    _appContext.SaveChanges();
                    return Created("", city);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteCity")]
        public IActionResult DeleteCity(int id)
        {
            var city = _appContext.Cities.FirstOrDefault(x => x.Id == id);
            try
            {
                if (city != null)
                {
                    _appContext.Cities.Remove(city);
                    _appContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateCity")]
        public IActionResult UpdateCity(int id, string name)
        {
            var city = _appContext.Cities.FirstOrDefault(x => x.Id == id);
            try
            {
                if (city != null)
                {
                    city.Name = name;
                    _appContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion */
    }
}