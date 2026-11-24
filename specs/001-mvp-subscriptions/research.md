# Phase 0 Research

## Decision: Use ASP.NET Core Web API and Blazor WebAssembly

**Decision**: The MVP will use a separate ASP.NET Core Web API backend and Blazor
WebAssembly frontend.

**Rationale**: This matches the stakeholder technology stack, cross-platform goals,
separation of responsibilities, and future extension path.

**Alternatives considered**:

- Blazor-only application: rejected because the stakeholder architecture assigns API
  responsibilities to a backend and expects separate frontend/backend communication.
- Console or desktop application: rejected because the target is a browser UI.

## Decision: Use session-local in-memory storage

**Decision**: Store subscriptions in a backend process collection and return a copy
of the current list.

**Rationale**: It satisfies the MVP's add/list requirements with no persistence,
database setup, or network feed behavior.

**Alternatives considered**:

- Browser-only storage: rejected because the stakeholder responsibilities give the
  backend ownership of data operations.
- Database persistence: rejected as post-MVP scope.

## Decision: Treat URLs as text in the MVP

**Decision**: Reject empty or whitespace-only input, but do not fetch or validate
feed content.

**Rationale**: It directly implements the MVP's documented assumption that valid
URLs are supplied and avoids an unneeded HTTP client.

**Alternatives considered**:

- URL syntax validation: rejected because stakeholder documents permit accepting
  valid-looking URLs.
- RSS/Atom verification: rejected because feed fetching and parsing are excluded.

## Decision: Allow duplicate text submissions

**Decision**: The MVP may append identical URLs because duplicate prevention is not
a stated requirement.

**Rationale**: This is the smallest behavior consistent with a simple in-memory
subscription list.

**Alternatives considered**:

- Reject duplicates: deferred because it adds UX and identity policy beyond MVP scope.

## Decision: Configure localhost communication explicitly

**Decision**: Use configurable API and frontend endpoints: backend
`http://localhost:5151/api/` and frontend `http://localhost:5213` by default.

**Rationale**: Coordinated ports and CORS configuration avoid cross-project startup
failures and match stakeholder guidance.

**Alternatives considered**:

- Hard-coded URLs: rejected by the constitution and configuration risk.
- Relative browser URLs: deferred until deployment topology is specified.
