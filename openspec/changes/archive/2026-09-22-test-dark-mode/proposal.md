## Why

The local application at `http://localhost:5243` needs automated coverage for its dark-mode workflow. Without a browser-level check, regressions in theme activation, readable contrast, or returning to the default theme can reach users unnoticed.

## What Changes

- Add an isolated Playwright smoke/regression test for the dark-mode control and resulting page appearance.
- Verify the dark theme is observable on the page and that primary text and interactive controls remain usable.
- Verify the default light theme remains available after dark mode is toggled off.
- Reuse the existing .NET 10 xUnit and `Microsoft.Playwright.Xunit` test project; no new test framework or package is proposed.

## Application Under Test

- **Application:** Local web application dark-mode workflow.
- **URL:** `http://localhost:5243`.
- **Access:** The application must be running and reachable before the Playwright test starts. Authentication and test data are not assumed for this public/local workflow.

## Capabilities

### New Capabilities

- `dark-mode`: Verify activation, readable presentation, and deactivation of the application's dark theme.

### Modified Capabilities

- None.

## Impact

- **Test project:** `TestDemo.Tests.csproj` and a new dark-mode Playwright test/support file as needed.
- **Environment:** Requires the local application at `http://localhost:5243`; failures caused by an unavailable app should be reported as environment failures rather than assertion failures.
- **Browser coverage:** Chromium is the initial smoke target, using the browser lifecycle already provided by `Microsoft.Playwright.Xunit`.
- **CI/data/dependencies:** No database or mutable test data is required. No package or CI pipeline change is planned unless the existing test execution setup cannot launch the local application.