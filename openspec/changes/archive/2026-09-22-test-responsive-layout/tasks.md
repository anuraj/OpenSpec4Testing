## 1. Project Setup

- [x] 1.1 Confirm the local application responds at `http://localhost:5243/` and verify `dotnet build TestDemo.Tests.csproj` succeeds
- [x] 1.2 Confirm Chromium can launch with explicit `375x667`, `667x375`, `768x1024`, and `1280x800` viewports, and verify each context is created with isolated storage

## 2. Page Objects / Fixtures

- [x] 2.1 Add the minimal responsive test helper or fixture setup using the existing xUnit Playwright lifecycle, and verify it compiles without adding a second browser-management abstraction
- [x] 2.2 Inspect the rendered navigation controls at mobile and desktop widths, choose accessible roles/labels or stable identifiers, and verify each chosen locator resolves in Chromium
- [x] 2.3 Preserve the repository's existing failure diagnostics behavior, if configured, and verify a responsive test failure retains the configured screenshot, trace, or video artifact

## 3. Test Cases

- [x] 3.1 Automate the mobile portrait layout scenario at `375x667` and verify the heading, primary content, and horizontal bounds with the focused test run
- [x] 3.2 Automate the tablet portrait layout scenario at `768x1024` and verify the heading, primary content, and horizontal bounds with the focused test run
- [x] 3.3 Automate the desktop layout scenario at `1280x800` and verify primary content plus full navigation without horizontal overflow
- [x] 3.4 Automate the mobile landscape layout scenario at `667x375` and verify the heading remains visible without horizontal scrolling or vertical clipping
- [x] 3.5 Automate mobile navigation expansion and verify Home and Privacy remain available after opening the menu
- [x] 3.6 Automate desktop navigation availability and verify Home, Privacy, and theme controls are available without opening the mobile menu

## 4. CI Integration

- [x] 4.1 Run the focused responsive-layout tests with the local application available and verify xUnit reports all viewport and navigation cases
- [x] 4.2 Run `dotnet test TestDemo.Tests.csproj` and verify the full suite passes without responsive tests leaking viewport, storage, or menu state