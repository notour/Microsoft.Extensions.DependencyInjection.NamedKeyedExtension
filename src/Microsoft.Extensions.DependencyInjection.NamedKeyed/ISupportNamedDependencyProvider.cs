namespace Microsoft.Extensions.DependencyInjection
{
    using System;

    /// <summary>
    /// Service provider that support service resolution by name
    /// </summary>
    /// <seealso cref="IServiceProvider" />
    public interface ISupportNamedDependencyProvider : IServiceProvider
    {
        /// <summary>
        ///     Gets the service object of the specified type register with name.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service object to get..</param>
        /// <param name="name"> An name specify at the service registry.</param>
        /// <returns>
        ///     A service object of type serviceType. -or- null if there is no service object of type serviceType.
        /// </returns>
        object? GetServiceNamed(Type serviceType, string name);

        /// <summary>
        ///     Gets the service object of the specified type register with name.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Raised when the requested service is not founded.</exception>
        /// <param name="serviceType">An object that specifies the type of service object to get..</param>
        /// <param name="name"> An name specify at the service registry.</param>
        /// <returns>
        ///     A service object of type serviceType. -or- null if there is no service object of type serviceType.
        /// </returns>
        object GetRequiredServiceNamed(Type serviceType, string name);
    }
}
