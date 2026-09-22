## Purpose

This capability defines the user-visible responsive behavior that the browser test suite must protect so the application's navigation and primary content remain usable across phone, tablet, and desktop viewport sizes.

## ADDED Requirements

### Requirement: The main page fits each supported viewport

The application SHALL keep its primary content within the viewport at mobile, tablet, and desktop sizes without requiring horizontal scrolling, clipping essential content, or obscuring the main heading.

#### Scenario: Mobile portrait layout fits the viewport

- **WHEN** a user opens the home page at a 375 by 667 pixel viewport
- **THEN** the primary content is visible, readable, and does not extend beyond the viewport's horizontal bounds

#### Scenario: Tablet portrait layout fits the viewport

- **WHEN** a user opens the home page at a 768 by 1024 pixel viewport
- **THEN** the primary content is visible, readable, and does not extend beyond the viewport's horizontal bounds

#### Scenario: Desktop layout fits the viewport

- **WHEN** a user opens the home page at a 1280 by 800 pixel viewport
- **THEN** the primary content and full navigation are visible, readable, and do not extend beyond the viewport's horizontal bounds

#### Scenario: Mobile landscape layout fits the viewport

- **WHEN** a user opens the home page at a 667 by 375 pixel viewport
- **THEN** the primary content remains visible and usable without horizontal scrolling or vertical clipping of the main heading

### Requirement: Navigation adapts to viewport size

The application SHALL present navigation controls appropriate to the available viewport and SHALL allow users to reach the primary navigation links on both collapsed and expanded layouts.

#### Scenario: Mobile navigation can be opened

- **WHEN** a user opens the home page at a mobile viewport and activates the navigation menu control
- **THEN** the navigation menu opens without covering the primary interaction needed to select a navigation link, and the Home and Privacy links are available

#### Scenario: Desktop navigation is available without expansion

- **WHEN** a user opens the home page at a desktop viewport
- **THEN** the Home, Privacy, and theme navigation controls are available without requiring the mobile menu to be opened