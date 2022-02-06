using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface ICityRepository
    {
        Task<City> CreateCity(City city);

        Task<City> GetCityById(int id);
        
        Task<City> GetCityByName(string name);

        Task<IEnumerable<City>> GetCities();

        void Update(City city);

        void DeleteCity(City city);
    }
}