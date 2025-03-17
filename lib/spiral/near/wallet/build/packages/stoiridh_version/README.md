<p align="center">
  <br>
  <img alt="Stòiridh’s Version Logo" src="https://gitlab.com/stoiridh-project/stoiridh-version/-/raw/master/assets/logo.svg?ref_type=heads" width="150">
  <br>
</p>

# Stòiridh’s Version

[![Package Version](https://img.shields.io/hexpm/v/stoiridh_version)](https://hex.pm/packages/stoiridh_version)
[![Hex Docs](https://img.shields.io/badge/hex-docs-ffaff3)](https://hexdocs.pm/stoiridh_version/)
[![pipeline status](https://gitlab.com/stoiridh-project/stoiridh-version/badges/master/pipeline.svg)](https://gitlab.com/stoiridh-project/stoiridh-version/-/commits/master)

Stòiridh Version is a tiny library that implements the [Semantic Versioning Specification 2.0.0](https://semver.org/).

The library supports version constraints which are a crucial aspect of modern software development, especially in
environments that rely heavily on third-party libraries and packages. They offer a balance between allowing
flexibility in updates and ensuring stability and compatibility, thus playing a significant role in the overall
reliability and maintainability of software projects.

## Installation

In your [Gleam](https://gleam.run/) project, you can add it by typing the following command in your terminal.

```sh
gleam add stoiridh_version
```

### Usage

```gleam
import gleam/io
import gleam/result
import stoiridh/version
import stoiridh/version/constraint

pub fn main() {
  use v1 <- result.map(
    version.new(5, 12, 4)
    |> version.with_prerelease("alpha.20")
    |> version.with_build_metadata("49ae79"),
  )

  use v2 <- result.map(
    version.parse("8.0.0")
    |> version.with_build_metadata("dev"),
  )

  use vc <- result.map(
    constraint.new("^5.1")
  )

  v1
  |> version.to_string
  |> io.println

  v2
  |> version.to_string
  |> io.println

  v1
  |> version.compare(v2)
  |> io.debug

  vc
  |> constraint.check(v1)
  |> io.debug

  vc
  |> constraint.check(v2)
  |> io.debug
}
```

**Output:**

```text
5.12.4-alpha.20+49ae79
8.0.0+dev
Lt
True
False
```

Further documentation can be found at <https://hexdocs.pm/stoiridh_version>.

## Development

```sh
gleam test  # Run the tests
gleam shell # Run an Erlang shell
```

## Sponsorship

If you’d like to support my work, you can consider <script src="https://liberapay.com/viprip/widgets/button.js"></script><noscript><a href="https://liberapay.com/viprip/donate"><img alt="Donate using Liberapay" src="https://liberapay.com/assets/widgets/donate.svg"></a></noscript>. These donations will help me to continue my work on what I believe and share more projects.

## Author

This library and the logo is a creation of [William McKIE](https://gitlab.com/viprip).

## Licence

Copyright © 2024 [William McKIE](https://gitlab.com/viprip).

This project is licenced under the [Apache License 2.0](https://choosealicense.com/licenses/apache-2.0/).
