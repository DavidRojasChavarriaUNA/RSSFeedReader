namespace RSSFeedReader.Api.Models;

public sealed record AddSubscriptionRequest(string Url);

public sealed record Subscription(string Url);
