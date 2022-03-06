using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CreditController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreditController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditContract>>> GetCreditList()
        {
            var result = await _unitOfWork.CreditRepository.GetCreditList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CreditContract>> CreateCredit(CreditContract credit)
        {
            credit.Client = await _unitOfWork.ClientRepository.GetClientByIdAsync(credit.Client.Id);
            credit.Currency = await _unitOfWork.DepositRepository.GetCurrencyById(credit.Currency.Id);
            credit.CreditType = await _unitOfWork.CreditRepository.GetCreditTypeById(credit.CreditType.Id);

            var createdCredit = await _unitOfWork.CreditRepository.CreateCredit(credit);

            if (await _unitOfWork.Complete())
            {
                createdCredit.CreditRecords = new List<CreditRecord>();
                return Ok(createdCredit);
            }

            return BadRequest("Error while creating credit");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> CloseCredit(int id)
        {
            var credit = await _unitOfWork.CreditRepository.GetCreditById(id);
            await _unitOfWork.CreditRepository.CloseCredit(credit);

            if (await _unitOfWork.Complete())
            {
                return Ok();
            }

            return BadRequest("Something went wrong");
        }

        [HttpGet("GetCreditsByClientId/{id}")]
        public async Task<ActionResult<IEnumerable<CreditContract>>> GetCreditsByClientId(int id)
        {
            var result = await _unitOfWork.CreditRepository.GetCreditsByClientId(id);
            return Ok(result);
        }


    }
}
