using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Invalidity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name should is required")]
        [MaxLength(80, ErrorMessage = "Length of Name should be less than 80")]
        public string Name { get; set; }
    }
}
