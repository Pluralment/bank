using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CitiesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CitiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> CitiesList()
        {
            var cities = await _unitOfWork.CityRepository.GetCities();
            return Ok(cities);
        }

        [HttpPost]
        public async Task<ActionResult<City>> CreateCity(City city)
        {
            var createdCity = await _unitOfWork.CityRepository.CreateCity(city);

            if (await _unitOfWork.Complete())
            {
                return Ok(createdCity);
            }

            return BadRequest("Error while creating city");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCity(int id)
        {
            var city = await _unitOfWork.CityRepository.GetCity(id);
            _unitOfWork.CityRepository.DeleteCity(city);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Cannot delete client");
        }

        [HttpPut()]
        public async Task<ActionResult> UpdateCity(City city)
        {
            _unitOfWork.CityRepository.Update(city);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Cannot delete client");
        }
    }
}