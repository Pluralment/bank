using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CurrenciesController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CurrenciesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrencies()
        {
            var currencies = await _unitOfWork.CurrencyRepository.GetCurrencies();
            return Ok(currencies);
        }
    }
}