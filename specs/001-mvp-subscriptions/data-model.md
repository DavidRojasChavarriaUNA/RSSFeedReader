# Data Model

## Subscription

Represents one feed URL entered by a local user during the active API process.

| Field | Type | Required | Rules |
|-------|------|----------|-------|
| `url` | Text | Yes | Trimmed; not empty or whitespace-only |

### Validation

- Empty and whitespace-only values are rejected.
- Values are stored as text; no URL syntax or feed-content validation occurs.
- The same text value may appear more than once.
- Subscriptions exist only in memory and are lost when the API process stops.

### State

The collection begins empty. A valid non-empty add request appends a subscription.
A list request returns all existing subscriptions for the active process.

No state transitions beyond `empty -> contains subscriptions` and process restart
to `empty` are required.
