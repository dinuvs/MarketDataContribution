# MarketDataContribution
MarketDataContribution API

Database: Used EF code first migration
Change the connection string "MarketDataDBConnection" to point to the relevant database.
Use update-database command in package manager console to get the database tables created with market data type and fx currency pairs Seed Data

API's: 
API can be tested using the swagger Ui. 
To Create a Market Data , Please use the  Json request similar to the sample below:
MarketDataTypeId : 3 means FXQuote 
FxCurrencyPairId : 1 means EUR/USD 
(please refer migration scripts for full mapping)

Json Sample for Create:
{ FxCurrencyPairId:1, MarketDataTypeId:3, Bid:1.123, Ask:1.133, LastUpdatedBy:"System" }
 

Market Data List Api: 

Gets the list of all created Market Data.

Current Technical packages and tools used: 

Used Automapper to map classes like UI related and DB access.
Used Moq to mock classes for unit testing.
Swagger is integrated for API UI view.

Implementation Specifics: 

Seperated the Validation Service as a different project and created a mockclass which can be later replaced using the real implementation.
Error handling is done at the application level using .NET core middleware using the extensions(Refer Extension folder in main project)
Basic Ilogger has been used, Nlog can be implemented in Future for proper file logging or to add the logs to  splunk or any other cloud logging areas like amazon s3 etc.


Future changes or improvements: 

Include Api Gateway like Ocelot etc for better architecture
Create APis for creating MarketDataTypes and FXCurrencyPairs so that users can add data from the API's.
Login module to be added, etc ... Use .Net Identity for authentication and authorisation.
Expand the logging using packages like NLog etc 
Create a UI for better usage using ASP.NET MVC or Angular or ReactJS or even MS Blazor.
Implement OAUTH 2.0 protocol for client server interactions.
Include more unit tests to improve coverage.







