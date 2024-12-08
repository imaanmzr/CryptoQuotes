using FluentAssertions;
using NSubstitute;
using Services.CryptoQuotes.Application.Contracts;
using Services.CryptoQuotes.Application.CryptoQuotes.GetCryptoQuotes;
using Services.CryptoQuotes.Domain;

namespace CryptoQuotes.Application.UnitTests;
public class GetCryptoQuotesTests
{
	private static readonly GetCryptoQuotesQuery Query = new("BTC");

	private readonly GetCryptoQuotesQueryHandler _handler;

	private readonly ICryptoQuoteService _quoteServiceMock;

	public GetCryptoQuotesTests()
	{
		_quoteServiceMock = Substitute.For<ICryptoQuoteService>();

		_handler = new GetCryptoQuotesQueryHandler(_quoteServiceMock);
	}

	[Fact]
	public async Task Handle_Should_ReturnFailure_WhenQuoteServiceReturnsFailure()
	{
		//Arrange
		var failureResult = Result.Failure<CryptoQuoteResponse>(Error.Failure("Failed.To.Get.Quotes", "Failed to get quotes."));

		_quoteServiceMock.GetQuoteAsync(Query.CryptocurrencyCode, Arg.Any<CancellationToken>())
			.Returns(failureResult);

		//Act
		Result<CryptoQuoteResponse> result = await _handler.Handle(Query, default);

		//Assert
		result.Error.Should().Be(Error.Failure("Failed.To.Get.Quotes", "Failed to get quotes."));
	}

	[Fact]
	public async Task Handle_Should_ReturnSuccess_WhenQuoteServiceReturnsSuccess()
	{
		//Arrange
		var successResult = Result.Success(CryptoQuoteResponseData.QuoteResponse);

		_quoteServiceMock.GetQuoteAsync(Query.CryptocurrencyCode, Arg.Any<CancellationToken>())
			.Returns(successResult);

		// Act
		Result<CryptoQuoteResponse> result = await _handler.Handle(Query, default);

		// Assert
		result.IsSuccess.Should().BeTrue();
		result.Should().NotBeNull();
		result.Value.Should().NotBeNull();
		result.Value.Status.Should().BeEquivalentTo(CryptoQuoteResponseData.QuoteResponse.Status);
		result.Value.Data.Should().BeEquivalentTo(CryptoQuoteResponseData.QuoteResponse.Data);
	}
}