using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface ICreditTypeRepository
    {
        Task<IEnumerable<CreditType>> GetCreditTypes();
    }
}