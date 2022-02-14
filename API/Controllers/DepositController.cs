using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class DepositController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepositController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<Deposit>> CreateDeposit(Deposit deposit)
        {
            var createdDeposit = await _unitOfWork.DepositRepository.CreateDeposit(deposit);

            if (await _unitOfWork.Complete())
            {
                return Ok(createdDeposit);
            }

            return BadRequest("Error while creating deposit");
        }

    }
}
