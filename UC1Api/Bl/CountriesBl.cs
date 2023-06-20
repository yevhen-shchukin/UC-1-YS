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

	public List<Country> SortByName(List<Country> countries, SortAscDesc ascentOrDescend)
	{
		if (ascentOrDescend == SortAscDesc.Ascend)
		{
			countries = countries.OrderBy(q => q.Name?.Common).ToList();
		}
		else if (ascentOrDescend == SortAscDesc.Descend)
		{
			countries = countries.OrderByDescending(q => q.Name?.Common).ToList();
		}

		return countries;
	}

	public List<Country> GetRecordsNumber(List<Country> countries, int recordsNumber)
	{
		return countries.Take(recordsNumber).ToList();
	}
}