## Context

The repository is a .NET 10 test project using xUnit and `Microsoft.Playwright.Xunit` 1.62.0. The target is a locally running web application at `http://localhost:5243`; the current change adds focused browser coverage rather than changing application behavior or introducing a new test framework.

## Goals / Non-Goals

**Goals:**

- Automate each dark-mode scenario in the capability spec as an independent browser test.
- Check observable theme state and representative readable content/controls in Chromium.
- Produce actionable Playwright failure artifacts when the configured test runner supports them.

**Non-Goals:**

- Performance, load, accessibility certification, or pixel-perfect visual regression testing.
- Testing system color-scheme negotiation, theme persistence across browser restarts, authentication, or backend data.
- Adding cross-browser coverage in this initial change.

## Framework & Tooling

Use the existing C#/.NET 10 xUnit project and `Microsoft.Playwright.Xunit` fixture/lifecycle. Prefer accessible roles, labels, and stable test identifiers for the theme control; use CSS selectors only when no stable user-facing locator exists. Run Chromium headlessly for the smoke suite, with the existing Playwright browser installation and test-runner conventions.

## Test Architecture

Keep tests isolated: each test starts from a fresh page, navigates to the base URL, and does not depend on another test's theme state. Use the existing Playwright xUnit fixture rather than creating a second browser-management abstraction. Tests may run in parallel because they mutate only per-page state; they must not share cookies, storage state, or a persistent context.

## Test Data Strategy

No seeded data, database state, or external service mocks are required. The test uses the application's default local page and records the URL as a configurable base URL if the existing project already supports configuration. A failed navigation or unavailable local server is an environment prerequisite failure and should remain distinguishable from a dark-mode assertion failure.

## CI/CD Integration

Run the focused test class after the local application is available, then include it in the normal `dotnet test` suite. Use the repository's existing result and failure-artifact settings; retain a screenshot, trace, or video for failures when already configured. Do not add a new pipeline in this change unless no existing test invocation can execute the suite against the local URL.

## Risks / Trade-offs

- [Risk] The local application may expose no stable accessible name or test identifier for the theme control -> Mitigation: inspect the rendered control during implementation and prefer its role/label; document any unavoidable stable fallback locator.
- [Risk] Theme colors may vary by page or component -> Mitigation: assert stable user-visible state and representative computed presentation rather than brittle full-page screenshots.
- [Risk] The application may not be running when tests execute -> Mitigation: document the prerequisite and make the test setup fail clearly at navigation instead of hiding the cause with retries.