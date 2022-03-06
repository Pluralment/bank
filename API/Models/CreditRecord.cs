using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CreditRecord
    {
        public int CreditContractId { get; set; }
        public CreditContract CreditContract { get; set; }

        public int RecordId { get; set; }
        public AccountingRecord Record { get; set; }
    }
}
