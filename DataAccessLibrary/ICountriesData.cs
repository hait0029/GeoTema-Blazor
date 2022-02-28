using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public interface ICountriesData
    {
        Task<List<CountryModel>> GetCountries();
        Task InsertCountry(CountryModel country);
    }
}