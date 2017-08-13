# Tech Challenge – Customer Bets Api

## Blueprint

	Blue print for API can be found in Blueprint.md located 

## Development

	To Run this application locally, 
	
	1. Rebuild the solution locally
    2. In case of build errors due to nuget packages - Restore the nuget packages using "dotnet.exe restore" 
	3. Press F5 and then access below URls
	
		http://localhost:3095/customer	- a list of customers
		http://localhost:3095/bets/customer - total amount bet per customer
		http://localhost:3095/bets/customer/1 - all bets placed for a customer
		http://localhost:3095/bets/customer/total - total amount bet for all customers
		http://localhost:3095/bets/customer/total/1 - total  bet amount placed for a customer
		http://localhost:3095/races - a list of today's race and horses associated with each race