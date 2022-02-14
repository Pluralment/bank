using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Plan Plan { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ContractNumber { get; set; }
    }
}
