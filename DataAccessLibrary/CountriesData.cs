using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class CountriesData : ICountriesData
    {
        //The readonly keyword bliver brugt til at lave erklæring med databasen men den skal erklære den construction og class
        private readonly ISqlDataAccess _db;

        public CountriesData (ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<List<CountryModel>> GetCountries()
        {
            string sql = "select * from dbo.Land";
            return _db.LoadData<CountryModel, dynamic>(sql, new { });
        }

        public Task InsertCountry(CountryModel country)
        {
            string sql = @"insert into dbo.Land (Land, VerdensDel1, VerdensDel2, Rang, FødselsRate)
                           values (@Land, @VerdensDel1, @VerdensDel2, @Rang, @FødselsRate);";
            return _db.SaveData(sql, country);
        }
    }
}
