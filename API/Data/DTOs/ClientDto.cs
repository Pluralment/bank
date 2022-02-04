using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string FatherName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool Gender { get; set; }

        public string PassportSerial { get; set; }

        public string PassportNumber { get; set; }

        public string IssuedBy { get; set; }

        public DateTime IssuedDate { get; set; }

        public string IdentifyNumber { get; set; }

        public string CityOfResidence { get; set; }

        public string AddressOfResidence { get; set; }

        public string HomePhone { get; set; }

        public string CellPhone { get; set; }

        public string Email { get; set; }

        public string PlaceOfWork { get; set; }
       
        public string Position { get; set; }
        
        public string LivingCity { get; set; }

        public string LivingAddress { get; set; }
 
        public string FamilyPosition { get; set; }

        public string Citizen { get; set; }

        public string Invalidity { get; set; }

        public bool Retired { get; set; }

        public decimal MonthlyIncome { get; set; }
        
        public bool Military { get; set; }
    }
}