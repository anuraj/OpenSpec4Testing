## 1. Project Setup

- [x] 1.1 Confirm the local application starts and responds at `http://localhost:5243`, and verify the existing test project builds with `dotnet build TestDemo.Tests.csproj`
- [x] 1.2 Inspect the rendered theme control and identify an accessible role, label, or stable test identifier; verify the chosen locator resolves uniquely in Chromium

## 2. Page Objects / Fixtures

- [x] 2.1 Add only the minimal page helper or fixture setup needed to navigate to the local application and isolate page state, and verify it compiles in the existing xUnit Playwright lifecycle
- [x] 2.2 Configure failure diagnostics using the repository's existing Playwright settings, if available, and verify a failing browser test preserves the configured artifact

## 3. Test Cases

- [x] 3.1 Automate the "Dark mode is enabled" scenario and verify the focused test passes against `http://localhost:5243`
- [x] 3.2 Automate the "Dark theme content remains usable" scenario and verify readable primary content and interactive controls while dark mode is active
- [x] 3.3 Automate the "Dark mode is disabled" scenario and verify the default light theme and inactive control state are restored
- [x] 3.4 Automate the "Default theme is unchanged before activation" scenario and verify the initial light presentation and primary controls

## 4. CI Integration

- [x] 4.1 Run the focused dark-mode tests with the local application available and verify the test results are reported by the existing xUnit/.NET test runner
- [x] 4.2 Run `dotnet test TestDemo.Tests.csproj` and verify the full suite passes without cross-test theme-state leakage