using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedCities(DataContext context)
        {
            if (await context.Cities.AnyAsync()) return;

            var citiesData = await System.IO.File.ReadAllTextAsync("Data/Seeds/CitiesSeedData.json");
            var cities = JsonSerializer.Deserialize<List<City>>(citiesData);
            if (cities == null) return;

            foreach (var city in cities)
            {
                await context.Cities.AddAsync(city);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedCountries(DataContext context)
        {
            if (await context.Countries.AnyAsync()) return;

            var countriesData = await System.IO.File.ReadAllTextAsync("Data/Seeds/CountriesSeedData.json");
            var countries = JsonSerializer.Deserialize<List<Country>>(countriesData);
            if (countries == null) return;

            foreach (var country in countries)
            {
                await context.Countries.AddAsync(country);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedFamilyPositions(DataContext context)
        {
            if (await context.FamilyPositions.AnyAsync()) return;

            var familyPositionsData = await System.IO.File.ReadAllTextAsync("Data/Seeds/FamilyPositionsSeedData.json");
            var familyPositions = JsonSerializer.Deserialize<List<FamilyPosition>>(familyPositionsData);
            if (familyPositions == null) return;

            foreach (var familyPosition in familyPositions)
            {
                await context.FamilyPositions.AddAsync(familyPosition);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedInvalidities(DataContext context)
        {
            if (await context.Invalidities.AnyAsync()) return;

            var invaliditiesData = await System.IO.File.ReadAllTextAsync("Data/Seeds/InvaliditiesSeedData.json");
            var invalidities = JsonSerializer.Deserialize<List<Invalidity>>(invaliditiesData);
            if (invalidities == null) return;

            foreach (var invalidity in invalidities)
            {
                await context.Invalidities.AddAsync(invalidity);
            }

            await context.SaveChangesAsync();
        }
    }
}