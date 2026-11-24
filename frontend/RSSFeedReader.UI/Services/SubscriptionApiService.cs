using System.Net.Http.Json;
using RSSFeedReader.UI.Models;

namespace RSSFeedReader.UI;

public sealed class SubscriptionApiService(HttpClient httpClient)
{
    public async Task<IReadOnlyList<Subscription>> GetSubscriptionsAsync()
    {
        var subscriptions = await httpClient.GetFromJsonAsync<List<Subscription>>("subscriptions");
        return subscriptions ?? [];
    }

    public async Task AddSubscriptionAsync(string url)
    {
        var response = await httpClient.PostAsJsonAsync(
            "subscriptions",
            new AddSubscriptionRequest { Url = url });

        if (!response.IsSuccessStatusCode)
        {
            var message = await response.Content.ReadAsStringAsync();
            throw new InvalidOperationException(
                string.IsNullOrWhiteSpace(message) ? "Could not add the subscription." : message);
        }
    }
}
