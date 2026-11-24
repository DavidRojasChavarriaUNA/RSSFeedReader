using RSSFeedReader.Api.Models;
using RSSFeedReader.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SubscriptionStore>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.WithOrigins("http://localhost:5213")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors();

app.MapGet("/api/subscriptions", (SubscriptionStore store)
    => Results.Ok(store.GetAll()));

app.MapPost("/api/subscriptions", (AddSubscriptionRequest request, SubscriptionStore store) =>
{
    var url = request.Url?.Trim();
    if (string.IsNullOrWhiteSpace(url))
    {
        return Results.BadRequest("Enter a feed URL.");
    }

    return Results.Created("/api/subscriptions", store.Add(url));
});

app.Run();
