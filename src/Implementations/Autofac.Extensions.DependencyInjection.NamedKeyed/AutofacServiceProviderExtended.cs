namespace Autofac.Extensions.DependencyInjection
{
    using Autofac;
    using Autofac.Core;

    using Microsoft.Extensions.DependencyInjection;

    using System;

    /// <summary>
    /// Extend Autofac implementation of <see cref="IServiceProvider"/> with <see cref="ISupportKeyedDependencyProvider"/> and <see cref="ISupportNamedDependencyProvider"/>
    /// </summary>
    /// <seealso cref="AutofacServiceProvider" />
    /// <seealso cref="ISupportKeyedDependencyProvider" />
    /// <seealso cref="ISupportNamedDependencyProvider" />
    public class AutofacServiceProviderExtended : AutofacServiceProvider, ISupportKeyedDependencyProvider, ISupportNamedDependencyProvider
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacServiceProviderExtended"/> class.
        /// </summary>
        /// <param name="lifetimeScope">The lifetime scope from which services will be resolved.</param>
        public AutofacServiceProviderExtended(ILifetimeScope lifetimeScope)
            : base(lifetimeScope)
        {
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public object GetRequiredServiceKeyed(Type serviceType, object key)
        {
            return base.LifetimeScope.ResolveKeyed(key, serviceType);
        }

        /// <inheritdoc/>
        public object GetRequiredServiceNamed(Type serviceType, string name)
        {
            return base.LifetimeScope.ResolveNamed(name, serviceType);
        }

        /// <inheritdoc/>
        public object? GetServiceKeyed(Type serviceType, object key)
        {
            return base.LifetimeScope.ResolveOptionalService(new KeyedService(key, serviceType));
        }

        /// <inheritdoc/>
        public object? GetServiceNamed(Type serviceType, string name)
        {
            if (base.LifetimeScope.TryResolveNamed(name, serviceType, out var service))
            {
                return service;
            }

            return default;
        }

        #endregion
    }
}
