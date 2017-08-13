FORMAT: 1A

# CustomerBets

Customer Bets is a simple API allowing consumers to view sample customers and bets.

## Customer [/customers}]

A Customer object has the following attributes:

+ id - unique identifier for customer
+ name - name of the customer

+ Parameters
    + 

### View all customers [GET]

+ Response 200 (application/json)

        [
			{
				"id":1,
				"name":"Rob"
			},
			{
				"id":2,
				"name":"Lachlan"
			}
		]

## Customer Bets [/bets/customer]

A Customer Bet object has the following attributes:

+ customerId
+ stake - Total Bet Amount placed by customer

+ Parameters
    + 

### Total Bets Per Customer [GET]

Lists all customers with total amount of bets they placed.

+ Response 200 (application/json)

	[
		{
			"customerId":1,
			"stake":700.0
		},
		{	
			"customerId":2,
			"stake":750.0
		}
	]


##  Customer Bets [/bets/customer/{customer_id}]
A Customer Bet object has the following attributes:

+ customerId
+ stake - Bet Amount

+ Parameters
    + customerId: 1 (required, number) - ID of the Customer in form of an integer

### Total Bets placed for Customer [GET]

Lists all bets placed by the customer

+ Response 200 (application/json)

	[
		{
			"customerId":1,
			"stake":700.0
		},
		{	
			"customerId":1,
			"stake":750.0
		}
	]

##  Customer Bets [/bets/customer/total]

+ Parameters
    + 

###	Total amount bet  [GET]

Returns an integer with Sum of amount bet for all customers

+ Response 200 (application/json)

	700


##  Customer Bets [/bets/total/customer/{customerId}]

+ Parameters
    + customerId: 1 (required, number) - ID of the Customer in form of an integer

###	Total amount bet for customer [GET]

Returns an integer with Sum of all bets placed by customer

+ Response 200 (application/json)

	700