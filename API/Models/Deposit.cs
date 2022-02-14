using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Deposit
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public Client Client { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime ContractExpiry { get; set; }

        // Отзывный или безотзывный
        [Required]
        public DepositType Type { get; set; }

        [Required]
        public string ContractNumber { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public double Sum { get; set; }

        [Required]
        public double Percentage { get; set; }
    }
}
