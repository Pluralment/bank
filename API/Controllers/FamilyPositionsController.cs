using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FamilyPositionsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FamilyPositionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyPosition>>> FamilyPositionList()
        {
            var positions = await _unitOfWork.FamilyPositionRepository.GetFamilyPositions();
            return Ok(positions);
        }
    }
}