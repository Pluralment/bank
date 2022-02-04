using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InvaliditiesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvaliditiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invalidity>>> InvalidityList()
        {
            var invalidities = await _unitOfWork.InvalidityRepository.GetInvalidityTypes();
            return Ok(invalidities);
        }
    }
}