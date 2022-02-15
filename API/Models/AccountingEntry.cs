﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class AccountingEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
        
        public AccountingRecord From { get; set; }        
        public AccountingRecord To { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}