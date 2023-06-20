using FluentAssertions;
using NUnit.Framework;
using UC1Api.Bl;
using UC1Api.Dto;

namespace UC1Api.UnitTests
{
	[TestFixture]
	public class CountriesBlTests
	{
		private CountriesBl _countriesBl;
		private List<Country> _countries;

		[SetUp]
		public void Setup()
		{
			_countriesBl = new CountriesBl();
			_countries = new List<Country>
			{
				new Country { Name = new CountryName { Common = "United States" }, Population = 331002651 },
				new Country { Name = new CountryName { Common = "Canada" }, Population = 37742154 },
				new Country { Name = new CountryName { Common = "Australia" }, Population = 25499884 }
			};
		}

		[Test]
		public void FilterByName_ShouldReturnMatchingCountries()
		{
			// Arrange
			string searchName = "united";

			// Act
			var filteredCountries = _countriesBl.FilterByName(_countries, searchName);

			// Assert
			filteredCountries.Should().HaveCount(1);
			filteredCountries.Should().Contain(c => c.Name!.Common!.Equals("United States", StringComparison.InvariantCultureIgnoreCase));
		}

		[Test]
		public void FilterByPopulation_ShouldReturnCountriesWithLessPopulation()
		{
			// Arrange
			int population = 40; // In millions

			// Act
			var filteredCountries = _countriesBl.FilterByPopulation(_countries, population);

			// Assert
			filteredCountries.Should().HaveCount(2);
			filteredCountries.Should().Contain(c => c.Name!.Common!.Equals("Canada"));
			filteredCountries.Should().Contain(c => c.Name!.Common!.Equals("Australia"));
		}

		[Test]
		public void SortByName_ShouldReturnCountriesSortedByNameInAscendingOrder()
		{
			// Arrange
			var expectedOrder = new List<string> { "Australia", "Canada", "United States" };

			// Act
			var sortedCountries = _countriesBl.SortByName(_countries, SortAscDesc.Ascend);

			// Assert
			sortedCountries.Should().HaveCount(3);
			sortedCountries.Should().BeInAscendingOrder(c => c.Name!.Common!);
			//sortedCountries.Should().ContainInOrder(expectedOrder);
		}

		[Test]
		public void SortByName_ShouldReturnCountriesSortedByNameInDescendingOrder()
		{
			// Arrange
			var expectedOrder = new List<string> { "United States", "Canada", "Australia" };

			// Act
			var sortedCountries = _countriesBl.SortByName(_countries, SortAscDesc.Descend);

			// Assert
			sortedCountries.Should().HaveCount(3);
			sortedCountries.Should().BeInDescendingOrder(c => c.Name!.Common!);
			//sortedCountries.Should().ContainInOrder(expectedOrder);
		}

		[Test]
		public void GetRecordsNumber_ShouldReturnLimitedNumberOfCountries()
		{
			// Arrange
			int recordsNumber = 2;

			// Act
			var limitedCountries = _countriesBl.GetRecordsNumber(_countries, recordsNumber);

			// Assert
			limitedCountries.Should().HaveCount(2);
			limitedCountries.Should().Contain(c => c.Name!.Common!.Equals("United States"));
			limitedCountries.Should().Contain(c => c.Name!.Common!.Equals("Canada"));
		}
	}
}


