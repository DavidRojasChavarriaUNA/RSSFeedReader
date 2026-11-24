using RSSFeedReader.Api.Models;

namespace RSSFeedReader.Api.Services;

public sealed class SubscriptionStore
{
    private readonly List<Subscription> subscriptions = [];

    public IReadOnlyList<Subscription> GetAll() => subscriptions.ToArray();

    public Subscription Add(string url)
    {
        var subscription = new Subscription(url);
        subscriptions.Add(subscription);
        return subscription;
    }
}
