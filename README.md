# 🚀 CryptoQuotes API 🌐  

The **CryptoQuote** API provides users with real-time cryptocurrency quotes and conversion rates. It supports fetching exchange rates for multiple cryptocurrencies and their respective values. You can query this API by providing a cryptocurrency code (like BTC) and receive the latest exchange rate information from two sources: **CoinMarketCap** and **ExchangeRates** API. It is built with modern development practices and follows **Clean Architecture** to ensure scalability, maintainability, and separation of concerns.

---

## 🔑 Key Technologies, Architecture & Patterns  

- 🛠 **.NET 8**  
- 🏗 **Clean Architecture**  
- ⚙️ **CQRS (Command Query Responsibility Segregation)**  
- 📦 **MediatR**  
- ✅ **Fluent Validation**  
- 🎯 **Result Pattern**  
- 💡 **Dependency Injection (DI)**  
- 📜 **Swagger/OpenAPI**  
- 🧪 **xUnit**
- 🤖 **NSubstitute**
- 🎯 **FluentAssertions**

---

## 🌟 Features  

- Fetch real-time cryptocurrency quotes for a given code (e.g., **BTC**, **ETH**).  
- Supports two major data sources:  
  - 🔗 **CoinMarketCap API** for cryptocurrency quotes.  
  - 💰 **ExchangeRates API** for currency conversion rates.  
- Delivers up-to-date exchange rate data for various cryptocurrencies.  

---

## 🛠 Project Setup and Installation  

### 1️⃣ Clone the Repository  
```bash  
git clone https://github.com/imaanmzr/CryptoQuotes.git  
cd CryptoQuotes
```
2️⃣ Install Dependencies
Run the following command to restore dependencies:
```
dotnet restore
```
3️⃣ Set Environment Variables

The project relies on two external services for cryptocurrency and exchange rates. You will need to set the following **API keys** as environment variables on your local machine or server.

Required Variables:

🔑 CoinMarketCap API Key

🔑 ExchangeRates API Key

4️⃣ Setting Environment Variables for Development

Set your API keys in the launchSettings.json file for local development. Example:

```json
"COINMARKETCAP_API_KEY": "your-actual-api-key-here",  
"EXCHANGERATES_API_KEY": "your-actual-api-key-here"
```
5️⃣ Running the Project
Once the environment variables are set, you can run the project locally using the following command:
```
dotnet run
```

📡 Accessing the API

🎯 API Endpoint: /quotes
Method: GET
Example: Fetch the quotes in these currencies ("EUR", "BRL", "GBP", "AUD") for BTC
```
GET https://localhost:5001/quotes?cryptocurrencyCode=BTC
```
