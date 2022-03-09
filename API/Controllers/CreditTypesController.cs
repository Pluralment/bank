using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CreditTypesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreditTypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditType>>> GetCreditTypes() 
        {
            return Ok(await _unitOfWork.CreditTypeRepository.GetCreditTypes());
        }
    }
}