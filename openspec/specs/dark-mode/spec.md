# dark-mode Specification

## Purpose

This capability defines the user-visible dark-mode behavior that the browser test suite must protect at the local application URL, including theme activation, readable content, and a return to the default presentation.

## Requirements

### Requirement: Users can activate a readable dark theme

The application SHALL provide an accessible dark-mode control and SHALL apply a visually distinct dark theme without making primary content or interactive controls unreadable.

#### Scenario: Dark mode is enabled

- **WHEN** a user opens `http://localhost:5243` and activates the dark-mode control
- **THEN** the page presents the dark theme and the control exposes its active state

#### Scenario: Dark theme content remains usable

- **WHEN** dark mode is active
- **THEN** the page's primary text and visible interactive controls remain readable and visually distinguishable from the dark background

### Requirement: Users can return to the default theme

The application SHALL allow a user to deactivate dark mode and SHALL restore the default light presentation without losing the page's primary content or controls.

#### Scenario: Dark mode is disabled

- **WHEN** a user with dark mode active activates the theme control again
- **THEN** the page returns to the default light theme and the control exposes its inactive state

#### Scenario: Default theme is unchanged before activation

- **WHEN** a user opens the application without activating dark mode
- **THEN** the page displays the default light presentation and its primary content and controls are available