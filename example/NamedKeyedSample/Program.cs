// See https://aka.ms/new-console-template for more information

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;

using NamedKeyedSample;

using System.Diagnostics;

// Create service collection Microsoft.Extensions.DependencyInjection
var serviceCollection = new ServiceCollection();

// Create specification using autofac
var autoFacBuilder = new ContainerBuilder();

// Link autofac to service collection
autoFacBuilder.Populate(serviceCollection);

var key = Guid.NewGuid();
var keyMessage = "Test for access service by key";

autoFacBuilder.RegisterType<ServiceImplementation>()
              .WithMetadata("message", keyMessage)
              .Keyed<IService>(key)
              .As<IService>();

var name = Guid.NewGuid().ToString();
var nameMessage = "Test for access service by name";

autoFacBuilder.RegisterType<ServiceImplementation>()
              .WithMetadata("message", nameMessage)
              .Named<IService>(name)
              .As<IService>();

IServiceProvider provider = new AutofacServiceProviderExtended(autoFacBuilder.Build());

var namedServiceByType = (IService)provider.GetRequiredServiceNamed(typeof(IService), name);
var namedServiceByGeneric = provider.GetRequiredServiceNamed<IService>(name);

var keyedServiceByType = (IService)provider.GetRequiredServiceKeyed(typeof(IService), key);
var keyedServiceByGeneric = provider.GetRequiredServiceKeyed<IService>(key);

Debug.Assert(namedServiceByType != null && namedServiceByType.GetSampleText() == nameMessage);
Debug.Assert(namedServiceByGeneric != null && namedServiceByType.GetSampleText() == nameMessage);

Debug.Assert(keyedServiceByType != null && keyedServiceByType.GetSampleText() == keyMessage);
Debug.Assert(keyedServiceByGeneric != null && keyedServiceByGeneric.GetSampleText() == keyMessage);
