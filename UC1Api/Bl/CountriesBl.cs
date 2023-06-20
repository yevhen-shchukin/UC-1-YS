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

	public List<Country> SortByName(List<Country> countries, string ascentOrDescend)
	{
		if (ascentOrDescend.Equals("ascend", StringComparison.OrdinalIgnoreCase))
		{
			countries = countries.OrderBy(q => q.Name?.Common).ToList();
		}
		else if (ascentOrDescend.Equals("descend", StringComparison.OrdinalIgnoreCase))
		{
			countries = countries.OrderByDescending(q => q.Name?.Common).ToList();
		}
		else
		{
			throw new ArgumentException("Invalid sort order. Please specify 'ascend' or 'descend'.");
		}

		return countries;
	}

}