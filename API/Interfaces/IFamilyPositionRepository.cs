using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IFamilyPositionRepository
    {
        Task<IEnumerable<FamilyPosition>> GetFamilyPositions();

        Task<FamilyPosition> GetFamilyPositionByName(string name);
    }
}