﻿using UC1Api.Dto;

namespace UC1Api.Bl.Interfaces
{
	public interface ICountriesBl
	{
		List<Country> FilterByName(List<Country> countries, string searchName);
	}
}
