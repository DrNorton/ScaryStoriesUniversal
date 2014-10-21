
using System.Data.Entity;
using System.Web.Http;
using Autofac;
using Microsoft.WindowsAzure.Mobile.Service;
using ScaryStories.MobileService.Entity;

namespace ScaryStories.MobileService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options

            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options, (configuration, builder) => RegisterDependencies(builder)));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
             config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

        
        }

        private static void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterInstance<ScaryStoriesContext>(new ScaryStoriesContext());
        }
    }

}

