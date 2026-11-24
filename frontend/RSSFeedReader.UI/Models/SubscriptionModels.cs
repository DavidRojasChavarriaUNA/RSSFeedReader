namespace RSSFeedReader.UI.Models;

public sealed class AddSubscriptionRequest
{
    public string Url { get; set; } = string.Empty;
}

public sealed class Subscription
{
    public string Url { get; set; } = string.Empty;
}
