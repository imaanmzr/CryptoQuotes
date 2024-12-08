using MediatR;
using Services.CryptoQuotes.Application.Contracts;
using Services.CryptoQuotes.Domain;

namespace Services.CryptoQuotes.Application.CryptoQuotes.GetCryptoQuotes;

internal sealed class GetCryptoQuotesQueryHandler(
	ICryptoQuoteService quoteService
	) : IRequestHandler<GetCryptoQuotesQuery, Result<CryptoQuoteResponse>>
{
	public async Task<Result<CryptoQuoteResponse>> Handle(GetCryptoQuotesQuery request, CancellationToken cancellationToken)
    {
		Result<CryptoQuoteResponse> quoteResult = await quoteService.GetQuoteAsync(request.CryptocurrencyCode, cancellationToken);

		if (quoteResult.IsFailure)
		{
			return Result.Failure<CryptoQuoteResponse>(quoteResult.Error);
		}

		//Map the Dto to the domain entity
		CryptoQuote quote = CryptoQuoteMapper.Map(quoteResult.Value);

		//TODO: use the data that is mapped to the domain entity for validation, persisting in the database or raise domain events!

		return quoteResult;
    }
}
