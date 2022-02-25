using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using System.Diagnostics;
using API.Data.DTOs;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class ClientsController : BaseApiController
    {
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
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
        public async Task<ActionResult> DeleteClient(int id)
        {
            var client = await _unitOfWork.ClientRepository.GetClientByIdAsync(id);
            _unitOfWork.ClientRepository.DeleteClient(client);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Cannot delete client");
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => x.Value);
                return BadRequest(errors);
            }

            client.CityOfResidence = client.CityOfResidence != null ? await _unitOfWork.CityRepository.GetCityById(client.CityOfResidence.Id) : null;
            client.LivingCity = client.LivingCity != null ? await _unitOfWork.CityRepository.GetCityById(client.LivingCity.Id) : null;
            client.FamilyPosition = client.FamilyPosition != null ? await _unitOfWork.FamilyPositionRepository.GetFamilyPositionById(client.FamilyPosition.Id) : null;
            client.Citizen = client.Citizen != null ? await _unitOfWork.CountryRepository.GetCountryById(client.Citizen.Id) : null;
            client.Invalidity = client.Invalidity != null ? await _unitOfWork.InvalidityRepository.GetInvalidityById(client.Invalidity.Id) : null;
            
            var createdClient = await _unitOfWork.ClientRepository.CreateClient(client);
            
            if (await _unitOfWork.Complete())
            {
                return CreatedAtRoute("GetClients", createdClient);
            }

            return BadRequest("Cannot create client");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateClient(Client updatedClient)
        {
            _unitOfWork.ClientRepository.Update(updatedClient);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Error while updating client");
        }
        #endregion
    }
}
