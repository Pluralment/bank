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
        public async Task<ActionResult<DepositContract>> CreateDeposit(DepositContract deposit)
        {
            deposit.Client = await _unitOfWork.ClientRepository.GetClientByIdAsync(deposit.Client.Id);
            deposit.Currency = await _unitOfWork.DepositRepository.GetCurrencyById(deposit.Currency.Id);
            deposit.DepositType = await _unitOfWork.DepositRepository.GetDepositTypeById(deposit.DepositType.Id);

            var createdDeposit = await _unitOfWork.DepositRepository.CreateDeposit(deposit);

            if (await _unitOfWork.Complete())
            {
                return Ok(createdDeposit);
            }

            return BadRequest("Error while creating deposit");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> CloseDeposit(int id)
        {
            var deposit = await _unitOfWork.DepositRepository.GetDepositById(id);
            await _unitOfWork.DepositRepository.CloseDeposit(deposit);

            if (await _unitOfWork.Complete())
            {
                return Ok();
            }

            return BadRequest("Something went wrong");
        }
    }
}
