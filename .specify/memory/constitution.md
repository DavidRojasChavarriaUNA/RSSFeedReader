<!--
Sync Impact Report:
- Version change: 0.0.0 -> 1.0.0
- Modified principles: none (initial constitutional document)
- Added sections: Core Principles, Security and Quality Constraints,
  Development Workflow, Governance
- Removed sections: none
- Follow-up TODOs:
  - TODO(RATIFICATION_DATE): Confirm the original project adoption date.
-->

# RSS Feed Reader Constitution

## Core Principles

### I. MVP Scope and Incremental Delivery

Implementation MUST remain within the active release scope and MUST NOT introduce
post-MVP behavior as part of MVP work. The MVP MUST support adding a feed URL and
displaying the in-memory subscription list. Extended-MVP work MUST be added only
through a separate specification and must introduce feed fetching, parsing, refresh,
and basic failure reporting before persistence or background automation.

**Rationale:** A tightly bounded MVP prevents speculative complexity and preserves a
fast, verifiable delivery path.

### II. Security by Design

Application code MUST minimize exposed attack surface and MUST validate and safely
handle untrusted values at trust boundaries. User-provided URLs and later fetched
feed content MUST be treated as untrusted: validate configuration and URL inputs,
enforce HTTP timeouts and redirect controls, prevent unsafe server-side requests,
and never evaluate or render feed content as executable HTML. Secrets MUST come from
configuration or secret stores, never source-controlled files. CORS MUST allow only
the configured frontend origins, and sensitive runtime errors MUST not expose
credentials or internal implementation details.

**Rationale:** Feed URLs and remote content become security-sensitive inputs once
network operations are enabled; controls must be established with the first
implementation rather than retrofitted.

### III. Maintainable Separation of Responsibilities

The ASP.NET Core Web API and Blazor WebAssembly frontend MUST maintain a clear
boundary: the API owns data operations and future feed/network operations, while the
UI owns presentation and user interaction. Code MUST be organized for replaceable
implementations, dependency injection, and testable domain operations. Public
interfaces MUST be documented, and configuration values such as API origins and ports
MUST come from configuration rather than hard-coded values.

**Rationale:** Explicit boundaries make cross-platform, incremental persistence,
polling, and feed enhancements possible without rewriting the MVP.

### IV. Test-First Quality Gates (NON-NEGOTIABLE)

Behavioral changes MUST be covered by focused tests before implementation is
considered complete. Tests MUST verify subscription add/list behavior for the MVP,
API contracts, frontend routing, configuration alignment, and failure paths for
Extended-MVP network operations. A clean build and relevant test suite MUST pass
before merge, and routing or startup failures MUST be corrected before feature work
continutes.

**Rationale:** Small automated checks catch contract drift and cross-project failures
early, when fixes remain inexpensive.

### V. Code Quality and Operational Reliability

Production code MUST use typed models, explicit error handling, meaningful logging,
and consistent C# conventions rather than duplicated or speculative abstractions.
Code reviews MUST verify readability, resource disposal, cancellation, and
configuration correctness. HTTP operations MUST use bounded timeouts and structured
diagnostics, and UI state changes MUST be deterministic and reflect backend outcomes.
Complexity MUST be justified in the implementation plan or review.

**Rationale:** Simple, observable, consistently reviewed code remains maintainable
as persistence, polling, and richer feed features are introduced.

## Security and Quality Constraints

- The MVP MUST use in-memory subscriptions and MUST NOT require a database or
  background service.
- The backend and frontend MUST use coordinated, configurable localhost ports.
  Default development endpoints are the backend at `http://localhost:5151/api/` and
  the frontend at `http://localhost:5213`.
- The frontend MUST remove Blazor template demo pages and route links, verify unique
  routes with only one page at `/`, and confirm a clean build before feature
  implementation.
- RSS/Atom support added after MVP MUST use `System.ServiceModel.Syndication`, manual
  refresh, title and link display, and basic failure handling. HTML from feeds MUST
  be rendered only as sanitized, non-executable content.
- Persistence additions MUST use the documented EF Core and SQLite direction unless a
  reviewed implementation explicitly replaces that choice.
- Dependencies MUST be limited to those required for the active scope and reviewed
  for licensing and security before adoption.

## Development Workflow

- Every feature MUST begin with a specification that identifies scope, acceptance
  criteria, security concerns, and explicit exclusions.
- Implementation MUST follow a dependency-ordered plan and tasks with verification
  steps. Changes MUST be small enough to review and revert independently.
- Before merge, contributors MUST run the relevant clean build, test suite, and
  route/configuration verification. Failures MUST be fixed rather than suppressed.
- Pull requests MUST document externally visible behavior changes and confirm
  compliance with this constitution; unresolved deviations MUST include a migration
  or remediation plan.

## Governance

This constitution supersedes local conventions that conflict with its principles.
Amendments MUST identify the affected principles or sections, document the
rationale, update the constitution version, and preserve applicable requirements
from prior versions. A principle removal or incompatible governance change requires
a MAJOR version. A new or materially expanded principle or section requires a MINOR
version. Clarifications and non-semantic refinements require a PATCH version.

Compliance reviews MUST occur during specification, implementation review, test
review, and final merge. Any justified exception MUST be documented in the relevant
plan or pull request with scope, impact, expiry or resolution, and verification
criteria. The ratification date remains `TODO(RATIFICATION_DATE): Confirm the original
project adoption date` until project stakeholders provide it.

**Version**: 1.0.0 | **Ratified**: TODO(RATIFICATION_DATE): Confirm the original project adoption date | **Last Amended**: 2026-11-24
