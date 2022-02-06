using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name should is required")]
        [MaxLength(80, ErrorMessage = "Length of Name should be less than 80")]
        public string Name { get; set; }
    }
}
