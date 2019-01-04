using Microsoft.Extensions.DependencyInjection;
using TwitterSentiment;
using TwitterSentiment.OAuth;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddTwitterSentiment(this IServiceCollection services)
        {
            services.AddTransient<OAuthMessageHandler>();

            services.AddHttpClient<TwitterClient>()
                    .AddHttpMessageHandler<OAuthMessageHandler>();

            services.AddHttpClient<TextAnalyticsClient>();
        
            return services;
        }
    }
}