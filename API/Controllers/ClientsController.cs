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
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _unitOfWork.ClientRepository.GetClientByIdAsync(id);
            _unitOfWork.ClientRepository.DeleteClient(client);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Cannot delete client");
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClient(ClientDto clientDto)
        {
            Client client = _mapper.Map<ClientDto, Client>(clientDto);

            client.CityOfResidence = await _unitOfWork.CityRepository.GetCityByName(client.CityOfResidence.Name);
            client.LivingCity = await _unitOfWork.CityRepository.GetCityByName(client.LivingCity.Name);
            client.FamilyPosition = await _unitOfWork.FamilyPositionRepository.GetFamilyPositionByName(client.FamilyPosition.Name);
            client.Citizen = await _unitOfWork.CountryRepository.GetCountryByName(client.Citizen.Name);
            client.Invalidity = await _unitOfWork.InvalidityRepository.GetInvalidityByName(client.Invalidity.Name);

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
    }
}
