## Context

The repository contains a .NET 10 xUnit project using `Microsoft.Playwright.Xunit` 1.62.0. The application is a local ASP.NET Core page using Bootstrap responsive navigation, and the requested coverage spans viewport behavior rather than backend data or authenticated workflows.

## Goals / Non-Goals

**Goals:**

- Classify the responsive suite as end-to-end regression coverage with a smoke subset for the primary page.
- Exercise Chromium at mobile portrait, mobile landscape, tablet portrait, and desktop viewports.
- Verify content bounds, heading visibility, navigation availability, and mobile menu expansion using stable user-facing assertions.

**Non-Goals:**

- Performance, load, network-condition, or device-hardware testing.
- Pixel-perfect visual regression, accessibility certification, or testing every Bootstrap breakpoint.
- Additional browser engines or real-device farms in this initial change.

## Framework & Tooling

Use the existing C#/.NET 10 xUnit project and `Microsoft.Playwright.Xunit` lifecycle. Run Chromium headlessly with explicit viewport sizes. Prefer accessible roles, labels, and stable test identifiers for navigation controls; use a narrowly scoped structural locator only when the responsive container has no accessible contract. Use Playwright auto-waiting and explicit assertions rather than fixed delays.

## Test Architecture

Add a focused responsive-layout test class using the existing `PageTest` fixture. Keep each viewport scenario isolated with a fresh page/context and navigate to the base URL per test. Parameterize only the viewport matrix and shared assertions; keep mobile-menu interaction in its own scenario so failures identify whether layout or navigation behavior regressed. The tests may run in parallel because they use independent browser contexts and do not mutate shared application data.

## Test Data Strategy

No seeded data, database state, authentication, or external mocks are required. Each test uses the public home page at `http://localhost:5243/`. The application must be running before execution; navigation failures should remain distinguishable from responsive assertions. Clear or isolated browser storage per test so theme or menu state cannot leak between viewport cases.

## CI/CD Integration

Run the smoke subset on pull requests when the local application is available, then run the full responsive matrix in the normal browser regression stage. Execute the focused class before the full `dotnet test TestDemo.Tests.csproj` suite. Preserve existing Playwright screenshots, traces, or videos for failures when configured; do not add a new reporting system in this change. A merge gate should require the matrix to pass at all four viewports.

## Risks / Trade-offs

- [Risk] A CSS breakpoint change can alter whether the mobile menu control is exposed -> Mitigation: locate the control through its accessible label/role and assert behavior at the explicit mobile and desktop widths.
- [Risk] A broad page-wide overflow assertion can fail because of an unrelated browser scrollbar or third-party content -> Mitigation: compare document scroll width to viewport width and pair it with visible primary-content assertions.
- [Risk] Local server availability can make every viewport test fail -> Mitigation: document the prerequisite and report navigation failures separately from layout assertion failures.
- [Risk] System theme persistence can affect rendered colors or controls -> Mitigation: use fresh contexts and leave theme behavior outside this change's acceptance contract.