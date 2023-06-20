using UC1Api.Bl.Interfaces;
using UC1Api.Dto;

namespace UC1Api.Bl;

public class CountriesBl : ICountriesBl
{
	public List<Country> FilterByName(List<Country> countries, string searchName)
	{
		return
			countries
				.FindAll(country => country.Name?.Common?.Contains(searchName, StringComparison.InvariantCultureIgnoreCase) == true);
	}

	public List<Country> FilterByPopulation(List<Country> countries, int population)
	{
		return
			countries
				.FindAll(country => country.Population < population * 1000000);
	}
}