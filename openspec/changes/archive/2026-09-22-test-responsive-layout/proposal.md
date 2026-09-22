## Why

The application currently has browser coverage for theme behavior but no automated protection for responsive layout. Changes to the Bootstrap navbar, viewport handling, or page content could introduce horizontal overflow, clipped controls, or unusable navigation on phones and tablets while still passing desktop-only checks.

## What Changes

- Add Playwright coverage for the main page at representative mobile, tablet, and desktop viewport sizes.
- Verify the responsive navigation remains usable, including mobile navigation expansion and desktop navigation visibility.
- Verify primary content remains visible, readable, and within the viewport without horizontal overflow at each viewport class.
- Reuse the existing .NET 10 xUnit and `Microsoft.Playwright.Xunit` project; no new framework or package is proposed.

## Application Under Test

- **Application:** TestDemo home page and responsive site navigation.
- **URL:** `http://localhost:5243/`.
- **Access:** The local application must be running and reachable before the Playwright tests start. The tested page does not require authentication or seeded data.
- **Viewport matrix:** Mobile portrait (`375x667`), tablet portrait (`768x1024`), desktop (`1280x800`), plus mobile landscape (`667x375`) as a boundary orientation check.

## Capabilities

### New Capabilities

- `responsive-layout`: Verify that the application's navigation and primary content adapt correctly across mobile, tablet, and desktop viewports.

### Modified Capabilities

- None.

## Impact

- **Test project:** `TestDemo.Tests.csproj` and a new responsive-layout Playwright test/support file as needed.
- **Browsers:** Chromium remains the initial browser target, with viewport emulation covering the requested device classes.
- **Environment:** Requires the local application at `http://localhost:5243/`; navigation failures should remain distinguishable from responsive assertion failures.
- **CI/data/dependencies:** No database, external service, or mutable test data is required. No package or pipeline change is planned unless the existing test execution setup cannot run the viewport matrix.