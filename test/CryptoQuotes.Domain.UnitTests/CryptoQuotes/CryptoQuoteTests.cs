using FluentAssertions;
using Services.CryptoQuotes.Domain;

namespace CryptoQuotes.Domain.UnitTests.CryptoQuotes;
public class CryptoQuoteTests
{
	[Fact]
	public void Create_Should_SetPropertyValues()
	{
		//Act
		CryptoQuote cryptoQuote = CryptoQuote.Create(CryptoQuoteData.Status, CryptoQuoteData.Data).Value;

		//Assert
		cryptoQuote.Status.Should().Be(CryptoQuoteData.Status);
		cryptoQuote.Data.Should().BeEquivalentTo(CryptoQuoteData.Data);
	}
}