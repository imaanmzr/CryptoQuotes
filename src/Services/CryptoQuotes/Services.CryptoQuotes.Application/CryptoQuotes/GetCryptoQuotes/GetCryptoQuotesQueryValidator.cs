using FluentValidation;

namespace Services.CryptoQuotes.Application.CryptoQuotes.GetCryptoQuotes;
internal sealed class GetCryptoQuotesQueryValidator : AbstractValidator<GetCryptoQuotesQuery>
{
	public GetCryptoQuotesQueryValidator()
	{
		RuleFor(x => x.CryptocurrencyCode)
			.NotEmpty()
			.MaximumLength(9)
			.WithMessage("Cryptocurrency code must not exceed 9 characters.");
	}
}
