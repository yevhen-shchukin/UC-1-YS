# UC-1-YS Applications description

.NET Web API application that provides access to countries' information. It offers a simple and efficient solution for retrieving data about various countries worldwide. The application focuses on a single endpoint that allows users to fetch comprehensive details about countries based on their specific needs. By leveraging this endpoint, users can apply filters such as name, population, and sorting order to obtain a tailored list of countries. 

# How to run the app locally
To run the app on a local environment you need to open the solution with VisualStudio, build, and run the application. No special setup is required.

# GET /Countries endpoint

Endpoint: GET /Countries

## Request Parameters
The endpoint accepts the following query parameters:
- nameFilter (optional): A string used to filter countries by name.
- populationMaxFilter (optional): An integer used to filter countries by maximum population.
- sortByNameAscendOrDescend (optional): A string indicating the sorting order of the countries by name. Possible values are "ascend" and "descend".
- maxCount (optional): An integer specifying the maximum number of countries to return.

## Response
The endpoint returns an HTTP response with the following possible status codes:

200 OK: The request was successful, and the response body contains a list of countries based on the applied filters and sorting parameters.
Other status codes: The request encountered an error. The status code corresponds to the error that occurred.
If the request is successful, the response body will contain a JSON array of country objects. Each country object has the following properties:
- name: The name of the country.
- population: The population of the country.

## Examples
Requests:
```
GET /api/endpoint?nameFilter=United&populationMaxFilter=100000000&sortByNameAscendOrDescend=ascend&maxCount=10
GET /api/endpoint?nameFilter=United
GET /api/endpoint?populationMaxFilter=100000000
GET /api/endpoint?sortByNameAscendOrDescend=descend
GET /api/endpoint?maxCount=10
GET /api/endpoint?nameFilter=United&populationMaxFilter=100000000
GET /api/endpoint?nameFilter=United&populationMaxFilter=100000000&sortByNameAscendOrDescend=ascend
GET /api/endpoint?nameFilter=United&populationMaxFilter=100000000&maxCount=10
GET /api/endpoint?populationMaxFilter=100000000&sortByNameAscendOrDescend=ascend&maxCount=10
GET /api/endpoint?sortByNameAscendOrDescend=ascend&maxCount=10
```

Response:
```
HTTP/1.1 200 OK
Content-Type: application/json

[
  {
    "name": "United States",
    "population": 331002651
  },
  {
    "name": "United Kingdom",
    "population": 67886011
  },
  {
    "name": "United Arab Emirates",
    "population": 9890400
  },
  ...
]

```
