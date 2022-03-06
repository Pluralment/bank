using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ICreditRepository
    {
        Task<CreditContract> CreateCredit(CreditContract credit);

        Task<CreditContract> CloseCredit(CreditContract credit);

        Task<CreditContract> GetCreditById(int id);

        Task<CreditType> GetCreditTypeById(int id);

        Task<IEnumerable<CreditContract>> GetCreditList();

        Task<IEnumerable<CreditContract>> GetCreditsByClientId(int id);
    }
}
