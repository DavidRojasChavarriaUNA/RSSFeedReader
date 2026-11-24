# MVP Quickstart

## Prerequisites

- A supported .NET SDK
- Two terminal windows
- A browser

## Start the API

From the repository root:

```powershell
dotnet run --project backend/RSSFeedReader.Api
```

Verify the API listens on `http://localhost:5151` according to its launch settings.

## Start the frontend

In a second terminal:

```powershell
dotnet run --project frontend/RSSFeedReader.UI
```

Open `http://localhost:5213` or the frontend URL reported by the run command.

## Validate the MVP

1. Open the subscription page.
2. Confirm an explicit empty state is shown when no subscriptions exist.
3. Enter `https://example.com/feed.xml` and submit.
4. Confirm the URL appears in the list immediately.
5. Enter a second URL and confirm both entries remain visible.
6. Submit only whitespace and confirm no entry is added and an instruction appears.
7. Stop and restart the API, then confirm the in-memory list is empty again.

## Validation checks

- The frontend API base URL points to `http://localhost:5151/api/`.
- Backend CORS allows `http://localhost:5213`.
- The browser console has no route or API connection errors.
- The subscription API contract matches
  [subscriptions-openapi.yaml](contracts/subscriptions-openapi.yaml).
- No feed fetching or item display occurs during this workflow.
