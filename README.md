# Tech Challenge - Customer Bets Api

## Blueprint

	Blue print for API can be found in Blueprint.md located adjust to this file

## Testing API

	Postman scripts are included at https://github.com/harshane/techchallenge_api/tree/master/Tools
	Also separate Web application is built to test the Race endpoint at https://github.com/harshane/techchallenge_harshal_testApiWebPage

## Development

	To Run this application locally, 
	
	1. Build the solution locally using Visual Studio 2017
    2. In case of build errors due to nuget packages - Restore the nuget packages using command "dotnet restore" Reference https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-restore
	3. Press F5 and then access below URls
	
		http://localhost:3095/customer	- a list of customers
		http://localhost:3095/bets/customer - total amount bet per customer
		http://localhost:3095/bets/customer/1 - all bets placed for a customer
		http://localhost:3095/bets/customer/total - total amount bet for all customers
		http://localhost:3095/bets/customer/total/1 - total  bet amount placed for a customer
		http://localhost:3095/races - a list of today's race and horses associated with each race


## Tools/Nuget packages used for development
	
	Visual Studio 2017 - For main development
	AutoMapper	- To map entities to Dto
	NLog	- To Log (only basic logging is done, it can be extended further)
	Newtonsoft.Json  (to Serialize/Deserialize Json)
	
## Technologies used
	Asp.Net Core
