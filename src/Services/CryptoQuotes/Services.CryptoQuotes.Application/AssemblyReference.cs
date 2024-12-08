using System.Reflection;

namespace Services.CryptoQuotes.Application;

public static class AssemblyReference
{
	public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
