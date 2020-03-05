using Blazor.Teleport;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extends the <see cref="IServiceCollection"/> with a method to help adding the teleporter.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the teleporter service to the <see cref="IServiceCollection"/>.
        /// </summary>
        public static IServiceCollection AddTeleporter(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<ITeleporter, Teleporter>();
        }
    }
}
