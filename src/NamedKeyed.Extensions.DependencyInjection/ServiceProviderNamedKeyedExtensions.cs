﻿namespace Microsoft.Extensions.DependencyInjection
{
    using NamedKeyed.Extensions.DependencyInjection;

    using System;

    /// <summary>
    /// Extensions method for <see cref="IServiceProvider"/> to provide access to <see cref="ISupportKeyedDependencyProvider"/> and <see cref="ISupportNamedDependencyProvider"/>
    /// </summary>
    public static class ServiceProviderNamedKeyedExtensions
    {
        #region Methods

        /// <inheritdoc cref="ISupportKeyedDependencyProvider.GetRequiredServiceKeyed(Type, object)" />
        /// <exception cref="NotSupportedException">Raised when <paramref name="service"/> doesn't implement <see cref="ISupportKeyedDependencyProvider"/></exception>
        public static object GetRequiredServiceKeyed(this IServiceProvider service, Type serviceType, object key)
        {
            if (service is ISupportKeyedDependencyProvider supportKeyedDependencyProvider)
                return supportKeyedDependencyProvider.GetRequiredServiceKeyed(serviceType, key);

            throw new NotSupportedException();
        }

        /// <inheritdoc cref="GetRequiredServiceKeyed(IServiceProvider, Type, object)" />
        public static TService GetRequiredServiceKeyed<TService>(this IServiceProvider service, object key)
        {
            return (TService)service.GetRequiredServiceKeyed(typeof(TService), key);
        }

        /// <inheritdoc cref="ISupportNamedDependencyProvider.GetRequiredServiceNamed(Type, string)"/>
        /// <exception cref="NotSupportedException">Raised when <paramref name="service"/> doesn't implement <see cref="ISupportNamedDependencyProvider"/></exception>
        public static object GetRequiredServiceNamed(this IServiceProvider service, Type serviceType, string name)
        {
            if (service is ISupportNamedDependencyProvider supportNamedDependencyProvider)
                return supportNamedDependencyProvider.GetRequiredServiceNamed(serviceType, name);

            throw new NotSupportedException();
        }

        /// <inheritdoc cref="GetRequiredServiceNamed(IServiceProvider, Type, string)" />
        public static TService GetRequiredServiceNamed<TService>(this IServiceProvider service, string name)
        {
            return (TService)service.GetRequiredServiceNamed(typeof(TService), name);
        }

        /// <inheritdoc cref="ISupportKeyedDependencyProvider.GetServiceKeyed(Type, object)" />
        /// <exception cref="NotSupportedException">Raised when <paramref name="service"/> doesn't implement <see cref="ISupportKeyedDependencyProvider"/></exception>
        public static object? GetServiceKeyed(this IServiceProvider service, Type serviceType, object key)
        {
            if (service is ISupportKeyedDependencyProvider supportKeyedDependencyProvider)
                return supportKeyedDependencyProvider.GetServiceKeyed(serviceType, key);

            throw new NotSupportedException();
        }

        /// <inheritdoc cref="GetServiceKeyed(IServiceProvider, Type, object)" />
        public static TService? GetServiceKeyed<TService>(this IServiceProvider service, object key)
            where TService : class
        {
            var serviceResult = service.GetServiceKeyed(typeof(TService), key);

            if (serviceResult is TService castService)
                return castService;

            return default;
        }

        /// <inheritdoc cref="ISupportNamedDependencyProvider.GetServiceNamed(Type, string)"/>
        /// <exception cref="NotSupportedException">Raised when <paramref name="service"/> doesn't implement <see cref="ISupportNamedDependencyProvider"/></exception>
        public static object? GetServiceNamed(this IServiceProvider service, Type serviceType, string name)
        {
            if (service is ISupportNamedDependencyProvider supportNamedDependencyProvider)
                return supportNamedDependencyProvider.GetServiceNamed(serviceType, name);

            throw new NotSupportedException();
        }

        /// <inheritdoc cref="GetServiceNamed(IServiceProvider, Type, string)" />
        public static TService? GetServiceNamed<TService>(this IServiceProvider service, string name)
            where TService : class
        {
            var serviceResult = service.GetServiceNamed(typeof(TService), name);
            if (serviceResult is TService castService)
                return castService;

            return default;
        }

        #endregion
    }
}
