namespace Microsoft.Extensions.DependencyInjection
{
    using System;

    /// <summary>
    /// Service provider that support service resolution by key
    /// </summary>
    /// <seealso cref="IServiceProvider" />
    public interface ISupportKeyedDependencyProvider : IServiceProvider
    {
        /// <summary>
        ///     Gets the service object of the specified type register with specific key.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service object to get..</param>
        /// <param name="key"> An object , used as key, specify at the service registry.</param>
        /// <returns>
        ///     A service object of type serviceType. -or- null if there is no service object of type serviceType.
        /// </returns>
        object? GetServiceKeyed(Type serviceType, object key);

        /// <summary>
        ///     Gets the service object of the specified type register with specific key.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Raised when the requested service is not founded.</exception>
        /// <param name="serviceType">An object that specifies the type of service object to get..</param>
        /// <param name="key"> An object , used as key, specify at the service registry.</param>
        /// <returns>
        ///     A service object of type serviceType. -or- null if there is no service object of type serviceType.
        /// </returns>
        object GetRequiredServiceKeyed(Type serviceType, object key);
    }
}
