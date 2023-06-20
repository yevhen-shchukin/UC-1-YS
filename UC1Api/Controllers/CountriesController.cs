using Microsoft.AspNetCore.Mvc;
using UC1Api.Bl.Interfaces;
using UC1Api.Dto;

namespace UC1Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
	private readonly HttpClient _httpClient;
	private readonly string? _apiUrl;
	private readonly ICountriesBl _countriesBl;

	public CountriesController(
		IHttpClientFactory httpClientFactory,
		IConfiguration configuration,
		ICountriesBl countriesBl)
	{
		if (httpClientFactory == null) throw new ArgumentNullException(nameof(httpClientFactory));
		if (configuration == null) throw new ArgumentNullException(nameof(configuration));

		_httpClient = httpClientFactory.CreateClient();
		_apiUrl = configuration.GetSection("ApiSettings:CountriesUrl").Value;

		_countriesBl = countriesBl ?? throw new ArgumentNullException(nameof(countriesBl));
	}

	[HttpGet]
	public async Task<IActionResult> Get(
		string? nameFilter,
		int? populationMaxFilter,
		string? sortByNameAscendOrDescend,
		int? maxCount)
	{
		var response = await _httpClient.GetAsync(_apiUrl);

		if (response.IsSuccessStatusCode)
		{
			var countries = await response.Content.ReadAsAsync<List<Country>>();

			if (nameFilter != null)
			{
				countries = _countriesBl.FilterByName(countries, nameFilter);
			}

			if (populationMaxFilter != null && populationMaxFilter > 0)
			{
				countries = _countriesBl.FilterByPopulation(countries, (int)populationMaxFilter);
			}

			if (Enum.TryParse(sortByNameAscendOrDescend, true, out SortAscDesc ad))
			{
				countries = _countriesBl.SortByName(countries, ad);
			}

			if (maxCount != null && maxCount > 0)
			{
				countries = _countriesBl.GetRecordsNumber(countries, (int)maxCount);
			}

			return Ok(countries);
		}
		else
		{
			return StatusCode((int)response.StatusCode);
		}
	}
}

