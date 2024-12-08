using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Services.CryptoQuotes.Application.CryptoQuotes.GetCryptoQuotes;
using Services.CryptoQuotes.Domain;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Services.CryptoQuotes.Presentation.CryptoQuotes;
public static class GetCryptoQuotes
{
	public static void MapEndpoint(IEndpointRouteBuilder app)
	{
		app.MapGet("/quotes", async (
        string cryptocurrencyCode,
			ISender sender,
			IValidator <GetCryptoQuotesQuery> validator) =>
		{
			var query = new GetCryptoQuotesQuery(cryptocurrencyCode);
			ValidationResult? validationResult = await validator.ValidateAsync(query);

			if (!validationResult.IsValid)
			{
				return Results.BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
			}

			try
			{
				Result<CryptoQuoteResponse> result = await sender.Send(query);

				if (result.IsFailure)
				{
					return Results.Problem(result.Error.Description);
				}

				return Results.Ok(result.Value);
			}
			catch (Exception ex)
			{
				return Results.Problem(ex.Message);
			}
		});
	}
}
