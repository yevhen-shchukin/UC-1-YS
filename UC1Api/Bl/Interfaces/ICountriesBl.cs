using UC1Api.Dto;

namespace UC1Api.Bl.Interfaces
{
	public interface ICountriesBl
	{
		List<Country> FilterByName(List<Country> countries, string searchName);

		List<Country> FilterByPopulation(List<Country> countries, int population);

		List<Country> SortByName(List<Country> countries, string ascentOrDescend);
	}
}

