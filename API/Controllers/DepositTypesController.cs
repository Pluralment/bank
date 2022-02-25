using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DepositTypesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public DepositTypesController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepositType>>> GetDepositTypes()
        {
            var depositTypes = await _unitOfWork.DepositTypeRepository.GetDepositTypes();
            return Ok(depositTypes);
        }
    }
}