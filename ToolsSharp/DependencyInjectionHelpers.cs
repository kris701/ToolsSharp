using Microsoft.Extensions.DependencyInjection;

namespace ToolsSharp
{
	/// <summary>
	/// Helper methods for Dependency Injections
	/// </summary>
	public static class DependencyInjectionHelpers
	{
		/// <summary>
		/// Adds an instance AND its interface as a singleton
		/// </summary>
		/// <typeparam name="TInterface"></typeparam>
		/// <typeparam name="TInstance"></typeparam>
		/// <param name="services"></param>
		public static void AddInstanceAndInfterfaceSingleton<TInterface, TInstance>(this IServiceCollection services)
			where TInstance : class, TInterface
			where TInterface : class
		{
			services.AddSingleton<TInstance>();
			services.AddSingleton<TInterface>(sp =>
			{
				var existing = sp.GetRequiredService<TInstance>();
				return existing;
			});
		}
	}
}
