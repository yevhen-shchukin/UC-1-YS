using Microsoft.AspNetCore.Mvc;
using UC1Api.Dto;

namespace UC1Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
	private readonly HttpClient _httpClient;

	public CountriesController(IHttpClientFactory httpClientFactory)
	{
		_httpClient = httpClientFactory.CreateClient();
	}

	[HttpGet]
	public async Task<IActionResult> Get(string? p1, int? p2, string? p3)
	{
		var apiUrl = "https://restcountries.com/v3.1/all";

		var response = await _httpClient.GetAsync(apiUrl);

		if (response.IsSuccessStatusCode)
		{
			var content = await response.Content.ReadAsAsync<IEnumerable<Country>>();

			return Ok(content);
		}
		else
		{
			return StatusCode((int)response.StatusCode);
		}
	}
}

