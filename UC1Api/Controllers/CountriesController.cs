using Microsoft.AspNetCore.Mvc;
using UC1Api.Dto;

namespace UC1Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
	private readonly HttpClient _httpClient;
	private readonly string? _apiUrl;

	public CountriesController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
	{
		if (httpClientFactory == null) throw new ArgumentNullException(nameof(httpClientFactory));
		if (configuration == null) throw new ArgumentNullException(nameof(configuration));

		_httpClient = httpClientFactory.CreateClient();
		_apiUrl = configuration.GetSection("ApiSettings:CountriesUrl").Value;
	}

	[HttpGet]
	public async Task<IActionResult> Get(string? p1, int? p2, string? p3)
	{
		var response = await _httpClient.GetAsync(_apiUrl);

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

