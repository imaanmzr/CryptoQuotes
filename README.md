# CryptoQuotes API

The CryptoQuote API provides users with real-time cryptocurrency quotes and conversion rates. It supports fetching exchange rates for multiple cryptocurrencies and their respective values. You can query this API by providing a cryptocurrency code (like BTC) and receive the latest exchange rate information from two sources: CoinMarketCap and ExchangeRates API. It is built with modern development practices and follows a **Clean Architecture** to ensure scalability, maintainability, and separation of concerns.

### Key Technologies, Architecture & Patterns:

- **.NET 8**
- **Clean Architecture**
- **CQRS (Command Query Responsibility Segregation)**
- **MediatR**
- **Fluent Validation**
- **Result Pattern**
- **Dependency Injection (DI)**
- **Swagger/OpenAPI**
- **xunit**
- **NSubstitute**
- **FluentAssertions**
## Features

- Fetch cryptocurrency quotes for a given cryptocurrency code (e.g., BTC, ETH).
- Support for dynamic exchange rates from two major sources:
    - **CoinMarketCap API** for cryptocurrency data.
    - **ExchangeRates API** for currency conversion rates.
- API supports real-time data fetching for various cryptocurrencies.

## Project Setup and Installation

To set up the project on your local machine, follow these steps:

### 1. Clone the Repository

`git clone https://github.com/imaanmzr/CryptoQuotes.git cd CryptoQuotes`

### 2. Install Dependencies

Ensure you have the required dependencies installed using the .NET CLI:

`dotnet restore`
### 3. Set Environment Variables

The project relies on two external services for cryptocurrency and exchange rates. You will need to set the following **API keys** as environment variables on your local machine or server.
#### API Keys

- **CoinMarketCap API Key**
- **ExchangeRates API Key**

### 4. Setting Environment Variables in Development

You should set the environment variables (Your API keys from CoinMarketCap and  ExchangeRates ) in the launchSettings.json file.

        "COINMARKETCAP_API_KEY": "your-actual-api-key-here",
        "EXCHANGERATES_API_KEY": "your-actual-api-key-here"

### 6. Running the Project

Once the environment variables are set, you can run the project locally using the following command:

`dotnet run`

### 7. Accessing the API

Once the application is running, you can make API requests to fetch cryptocurrency quotes.

- **Endpoint:** `/quotes`
- **Method:** `GET`

### 8. Swagger Documentation (Optional)

If you are running the application in **development mode**, Swagger is enabled to explore the API:

- **URL:** `https://localhost:5001/swagger` (or your local server URL)
- This will allow you to view available endpoints and test them directly from the Swagger UI.
