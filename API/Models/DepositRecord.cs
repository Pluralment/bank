using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class DepositRecord
    {
        public int DepositContractId { get; set; }
        public DepositContract DepositContract { get; set; }
        
        public int RecordId { get; set; }
        public AccountingRecord Record { get; set; }
    }
}
