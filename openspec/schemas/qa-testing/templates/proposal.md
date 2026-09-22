## Why

<!-- Explain the motivation for this test automation effort. What's untested/under-tested today? Why now? -->

## What Changes

<!-- Describe what test automation will change. Be specific about new suites, page objects, fixtures, or CI pipelines. Mark **BREAKING** if replacing an existing framework/suite. -->

## Application Under Test

<!-- Feature/area being tested, URLs/endpoints, and how to reach a test environment (staging URL, local docker-compose, etc.) -->

## Capabilities

### New Capabilities
<!-- Flows getting test coverage for the first time. Use kebab-case for path segments
     you introduce (e.g., checkout-flow or api/orders) that follow the project's
     existing spec organization. Each creates specs/<capability-path>/spec.md. -->
- `<capability-path>`: <brief description of the flow/feature being covered>

### Modified Capabilities
<!-- Existing test-covered flows whose expected scenarios are changing (not just
     test code refactoring). Each needs a delta spec file. Use the exact existing
     path under openspec/specs/. Leave empty if no scenario changes. A change with
     no capabilities at all (pure test-infra change) must set `skip_specs: true`
     in its .openspec.yaml - openspec validate rejects a zero-delta change without
     that marker. Do not invent a scenario just to satisfy validation. -->
- `<existing-capability-path>`: <what scenario/behavior is changing>

## Impact

<!-- Affected test projects, CI pipelines, environments, test data, dependencies (NuGet packages, browser drivers) -->
