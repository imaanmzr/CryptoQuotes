namespace Services.CryptoQuotes.Domain.ValueObjects;

public sealed record Quote
{
	public decimal? Price { get; init; }

	public Quote(decimal? price)
	{
		if (price is null)
		{
			Result.Failure<Quote>(Error.NullValue);
		}

		Price = price;
	}
}