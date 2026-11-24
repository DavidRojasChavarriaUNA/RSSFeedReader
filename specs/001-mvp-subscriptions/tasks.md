# Tasks: MVP Subscription Management

**Input**: Design documents from `/specs/001-mvp-subscriptions/`

**Prerequisites**: plan.md, spec.md, research.md, data-model.md,
contracts/subscriptions-openapi.yaml, quickstart.md

**Tests**: Tests are not explicitly requested by the specification, so test tasks are
omitted. Implementation will include validation at each checkpoint.

**Organization**: Tasks are grouped by user story to keep the MVP increments
independently implementable and testable.

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Create the ASP.NET Core API and Blazor WebAssembly projects.

- [ ] T001 Create the solution and required project directories in repository root
- [ ] T002 [P] Create the ASP.NET Core Web API project at
  `backend/RSSFeedReader.Api/RSSFeedReader.Api.csproj`
- [ ] T003 [P] Create the Blazor WebAssembly project at
  `frontend/RSSFeedReader.UI/RSSFeedReader.UI.csproj`
- [ ] T004 Remove Blazor template demo pages and links from
  `frontend/RSSFeedReader.UI/Pages/` and
  `frontend/RSSFeedReader.UI/Layout/NavMenu.razor`
- [ ] T005 Configure API launch settings for `http://localhost:5151` in
  `backend/RSSFeedReader.Api/Properties/launchSettings.json`
- [ ] T006 Configure frontend launch settings for `http://localhost:5213` in
  `frontend/RSSFeedReader.UI/Properties/launchSettings.json`
- [ ] T007 Configure the frontend API base URL in
  `frontend/RSSFeedReader.UI/wwwroot/appsettings.json`

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Establish shared backend/frontend infrastructure required by both stories.

**CRITICAL**: No user story work can begin until this phase is complete.

- [ ] T008 Add the typed subscription API contract types in
  `backend/RSSFeedReader.Api/Models/SubscriptionModels.cs`
- [ ] T009 Implement session-local subscription storage for the API in
  `backend/RSSFeedReader.Api/Services/SubscriptionStore.cs`
- [ ] T010 Configure API routing, CORS for `http://localhost:5213`, and application
  services in `backend/RSSFeedReader.Api/Program.cs`
- [ ] T011 Configure the frontend HTTP client and application services in
  `frontend/RSSFeedReader.UI/Program.cs`
- [ ] T012 Add the frontend subscription request and response types in
  `frontend/RSSFeedReader.UI/Models/SubscriptionModels.cs`
- [ ] T013 Implement the frontend API service in
  `frontend/RSSFeedReader.UI/Services/SubscriptionApiService.cs`
- [ ] T014 Add an application route with exactly one root subscription page in
  `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`

**Checkpoint**: Foundation ready; user story implementation can proceed.

---

## Phase 3: User Story 1 - Add a Feed Subscription (Priority: P1) MVP

**Goal**: Allow a local user to enter a non-empty feed URL and add it to the
session-local list.

**Independent Test**: With an empty list, enter a URL and submit it; verify the API
returns success and the list contains the new entry.

### Implementation for User Story 1

- [ ] T015 [US1] Implement `POST /subscriptions` according to
  `contracts/subscriptions-openapi.yaml` in
  `backend/RSSFeedReader.Api/Program.cs`, applying the required trimmed,
  non-empty `Subscription.url` rule from `data-model.md`
- [ ] T016 [US1] Add an empty or whitespace-only submission check to
  `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [ ] T017 [US1] Add the URL entry field and add action to
  `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [ ] T018 [US1] Call the subscription add API from
  `frontend/RSSFeedReader.UI/Services/SubscriptionApiService.cs`
- [ ] T019 [US1] Refresh the displayed list immediately after a successful add in
  `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [ ] T020 [US1] Display a clear validation message for rejected empty submissions in
  `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`

**Checkpoint**: User Story 1 can add a URL and update the list independently.

---

## Phase 4: User Story 2 - View Subscriptions (Priority: P1)

**Goal**: Show all subscriptions added during the active API process and an explicit
empty state before any entries exist.

**Independent Test**: Add one or more subscriptions, navigate or refresh within the
running session, and verify every entry remains visible.

### Implementation for User Story 2

- [ ] T021 [US2] Implement `GET /subscriptions` according to
  `contracts/subscriptions-openapi.yaml` in
  `backend/RSSFeedReader.Api/Program.cs`
- [ ] T022 [P] [US2] Implement the frontend list-loading operation in
  `frontend/RSSFeedReader.UI/Services/SubscriptionApiService.cs`
- [ ] T023 [P] [US2] Render the subscription list in
  `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [ ] T024 [US2] Render an explicit empty state when no subscriptions exist in
  `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [ ] T025 [US2] Load existing subscriptions when the page initializes or revisits in
  `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [ ] T026 [US2] Display API failure feedback without exposing internal details in
  `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`

**Checkpoint**: User Stories 1 and 2 work together while preserving session-local data.

---

## Phase 5: Polish & Cross-Cutting Concerns

**Purpose**: Complete MVP verification and remove demo or implementation artifacts.

- [ ] T027 [P] Verify only the subscription page uses the `/` route in
  `frontend/RSSFeedReader.UI/Pages/`
- [ ] T028 [P] Verify CORS, API base URL, and frontend/backend launch ports across
  `backend/RSSFeedReader.Api/Properties/launchSettings.json`,
  `frontend/RSSFeedReader.UI/Properties/launchSettings.json`, and
  `frontend/RSSFeedReader.UI/wwwroot/appsettings.json`
- [ ] T029 Run a clean backend build and startup check for
  `backend/RSSFeedReader.Api/RSSFeedReader.Api.csproj`
- [ ] T030 Run a clean frontend build and startup check for
  `frontend/RSSFeedReader.UI/RSSFeedReader.UI.csproj`
- [ ] T031 Run the add-and-view validation scenarios from
  `specs/001-mvp-subscriptions/quickstart.md`
- [ ] T032 Confirm the MVP contains no feed fetching, parsing, persistence, removal,
  authentication, or background refresh implementation

---

## Dependencies & Execution Order

### Phase Dependencies

- Setup (Phase 1) has no dependencies and can start immediately.
- Foundational (Phase 2) depends on Setup and blocks all user story work.
- User Story 1 (Phase 3) and User Story 2 (Phase 4) depend on Foundational.
- Polish (Phase 5) depends on both user stories being complete.

### User Story Dependencies

- **User Story 1 (P1)**: No dependency on User Story 2.
- **User Story 2 (P1)**: Independently testable after the shared foundation; it
  consumes the same subscription entity and API service as User Story 1.

### Parallel Opportunities

- T002 and T003 can run in parallel after the solution structure exists.
- T022 and T023 can run in parallel because they modify separate frontend files.
- Different story phases may proceed in parallel after Foundational completion if
  team capacity allows.
- T027 and T028 can run in parallel during polish.

---

## Parallel Example: User Story 1

```text
T016 - Add submission validation in Subscriptions.razor
T017 - Add URL entry and add action in Subscriptions.razor
T018 - Add add-request API call in SubscriptionApiService.cs
```

T016 and T017 touch the same file and must not run simultaneously. T018 can proceed
in parallel once its API contract and frontend model are available.

---

## Parallel Example: User Story 2

```text
T022 - Implement frontend list loading in SubscriptionApiService.cs
T023 - Render the subscription list in Subscriptions.razor
T024 - Render the empty state in Subscriptions.razor
```

T023 and T024 share one UI file and should be merged during implementation; T022 can
run independently in its service file.

---

## Implementation Strategy

### MVP First (User Story 1)

1. Complete Phase 1: Setup.
2. Complete Phase 2: Foundational.
3. Complete Phase 3: User Story 1.
4. STOP and validate add-subscription behavior independently.
5. Add User Story 2 so the MVP also displays and reloads the complete list.

### Incremental Delivery

1. Complete Setup and Foundational to establish a runnable API/UI foundation.
2. Implement and validate User Story 1.
3. Implement and validate User Story 2.
4. Run clean builds and quickstart validation in Polish.

### Parallel Team Strategy

1. One developer establishes the API foundation while another scaffolds the frontend.
2. After Foundational completion, one developer owns User Story 1 and another owns
   User Story 2.
3. Both stories merge only after independent checkpoints pass.

---

## Notes

- Tasks use strict checklist format with sequential IDs.
- [P] means a task uses independent files or a separate implementation stream.
- [US1] and [US2] labels apply only to user story phases.
- `Subscription.url` constrained by `data-model.md` is cited in T015 and therefore
  its required, trimmed, non-empty rule is explicitly resolved.
- Commit only after each task or a tested logical group.
