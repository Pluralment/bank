using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CountriesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CountriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> CountryList()
        {
            var countries = await _unitOfWork.CountryRepository.GetCountries();
            return Ok(countries);
        }
    }
}