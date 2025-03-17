//// A module that contains types and functions to work with Semantic Versioning.
////
//// Semantic Versioning (see [https://semver.org/](https://semver.org/)) is a specification that
//// proposes a simple set of rules and requirements that dictate how version numbers are assigned
//// and incremented.
////
//// > **NOTE:**
//// > This module follows the [Semantic Versioning specification 2.0](https://semver.org/spec/v2.0.0.html).
////
//// ## Import
////
//// To import the types and functions of this module, add the following import statement in your
//// _gleam_ files:
////
//// ```gleam
//// import stoiridh/version
//// ```
////
//// ## Example
////
//// This brief example gives an overview on how to use this module:
////
//// ```gleam
//// import gleam/io
//// import gleam/result
//// import stoiridh/version
////
//// pub fn main() {
////   use v1 <- result.map(
////     version.new(5, 12, 4)
////     |> version.with_prerelease("alpha.20")
////     |> version.with_build_metadata("49ae79"),
////   )
////
////   use v2 <- result.map(
////     version.new(8, 0, 0)
////     |> version.with_build_metadata("dev"),
////   )
////
////   v1
////   |> version.to_string
////   |> io.println
////
////   v2
////   |> version.to_string
////   |> io.println
////
////   v1
////   |> version.compare(v2)
////   |> io.debug
//// }
//// ```
////
//// ```text
//// 5.12.4-alpha.20+49ae79
//// 8.0.0+dev
//// Lt
//// ```

import gleam/bool
import gleam/dict.{type Dict}
import gleam/int
import gleam/list
import gleam/option.{type Option, None, Some}
import gleam/order
import gleam/result
import gleam/string

import stoiridh/internal/int as sint

/// A type that holds errors when interacting with Semantic Versioning.
pub type VersionError {
  /// The version isn’t valid.
  ///
  /// An invalid version may be the result of an empty string or the failure of parsing a character
  /// as a digit for any `major`, `minor`, or `patch` version numbers.
  InvalidVersion

  /// The major version number isn’t valid.
  ///
  /// This error raises when the [parse](#parse) function failed to parse the major version number.
  InvalidMajorVersion

  /// The minor version number isn’t valid.
  ///
  /// This error raises when the [parse](#parse) function failed to parse the minor version number.
  InvalidMinorVersion

  /// The patch version number isn’t valid.
  ///
  /// This error raises when the [parse](#parse) function failed to parse the patch version number.
  InvalidPatchVersion

  /// The pre-release version isn’t valid.
  ///
  /// A valid pre-release version is a series of dot separated identifiers. Identifiers must
  /// comprise only ASCII alphanumerics and hyphens [A-Za-z0-9-]. Identifiers MUST NOT be empty.
  /// Numeric identifiers MUST NOT include leading zeroes.
  InvalidPrerelease

  /// The build metadata isn’t valid.
  ///
  /// A valid build metadata is a series of dot separated identifiers. Identifiers must
  /// comprise only ASCII alphanumerics and hyphens [A-Za-z0-9-]. Identifiers MUST NOT be empty.
  InvalidBuildMetadata

  /// Constructs a negative value error.
  ///
  /// This error is emitted when the version contains any negative value.
  NegativeValue(String)
}

/// A `Version` type.
///
/// The `Version` type holds the values for constructing a semantic version.
pub opaque type Version {
  Version(
    major: Int,
    minor: Int,
    patch: Int,
    prerelease: Option(String),
    build_metadata: Option(String),
  )
}

/// A `Parser` type.
///
/// The `Parser` type holds the graphemes as `input` and `version_parts` will help to reconstruct
/// a [`Version`](#Version).
type Parser {
  Parser(input: List(String), version_parts: Dict(String, String))
}

/// Creates a new semantic version.
///
/// Any negative values on `major`, `minor`, or `patch` will result as an error.
pub fn new(major: Int, minor: Int, patch: Int) -> Result(Version, VersionError) {
  use major <- result.try(
    major
    |> sint.is_positive
    |> result.map_error(fn(error) { NegativeValue(error) }),
  )

  use minor <- result.try(
    minor
    |> sint.is_positive
    |> result.map_error(fn(error) { NegativeValue(error) }),
  )

  use patch <- result.try(
    patch
    |> sint.is_positive
    |> result.map_error(fn(error) { NegativeValue(error) }),
  )

  Ok(Version(major, minor, patch, None, None))
}

/// Creates a new semantic version from a `String` representation.
///
/// # Add or Override Pre-release and Build Metadata Labels.
///
/// You can also use [with_prerelease](#with_prerelease) and [with_build_metadata](
/// #with_build_metadata) after parsing a version successfully to whether add or override the
/// pre-release and build metadata labels, respectively.
///
/// ## Example
///
/// ```gleam
/// use v <- result.map(
///   version.parse("1.0.0-alpha.1")
///   |> version.with_prerelease("beta.2")
///   |> version.with_build_metadata("dev")
/// )
///
/// v
/// |> version.to_string
/// |> io.println
/// ```
///
/// ```text
/// 1.0.0-beta.2+dev
/// ```
pub fn parse(from input: String) -> Result(Version, VersionError) {
  let graphemes =
    input
    |> string.to_graphemes

  use <- bool.guard(list.is_empty(graphemes), Error(InvalidVersion))

  graphemes
  |> parse_version_numbers
  |> result.then(parse_prerelease)
  |> result.then(parse_build_metadata)
  |> result.then(transform_to_version)
}

/// Parses the Version Numbers.
fn parse_version_numbers(
  from input: List(String),
) -> Result(Parser, VersionError) {
  do_parse_version_numbers(input, "", [])
}

/// Parses recursively each grapheme for reconstructing the `major`, `minor`, and `patch` version
/// numbers, respectively.
///
/// The condition for returning a new [Parser](#Parser) is there are no graphemes left or the next
/// one matches either a `-` for a pre-release or a `+` for build metadata. In either of this
/// condition, the function verifies that the reconstruction of the `major`, `minor`, and `patch`
/// version number is valid.
fn do_parse_version_numbers(
  input: List(String),
  buffer: String,
  version_parts: List(Int),
) -> Result(Parser, VersionError) {
  case input {
    [elem] -> {
      let version_number = buffer <> elem

      use <- bool.guard(
        string.starts_with(version_number, "00"),
        Error(InvalidVersion),
      )

      case int.parse(version_number) {
        Ok(version_part) ->
          do_parse_version_numbers(
            [],
            "",
            version_parts
              |> list.append([version_part]),
          )
        Error(_) -> Error(InvalidVersion)
      }
    }
    [elem, delimiter, ..remaining_graphemes]
      if delimiter == "-" || delimiter == "+"
    -> {
      case int.parse(buffer <> elem) {
        Ok(version_part) -> {
          let version_parts =
            version_parts
            |> list.append([version_part])

          version_parts
          |> check_version_parts
          |> result.map(fn(version_parts) {
            let #(major, minor, patch) = version_parts

            Parser(
              [delimiter, ..remaining_graphemes],
              dict.new()
                |> dict.insert("major", int.to_string(major))
                |> dict.insert("minor", int.to_string(minor))
                |> dict.insert("patch", int.to_string(patch)),
            )
          })
        }
        Error(_) -> Error(InvalidVersion)
      }
    }
    [elem, ".", ..remaining_graphemes] -> {
      let version_number = buffer <> elem

      use <- bool.guard(
        string.starts_with(version_number, "00"),
        Error(InvalidVersion),
      )

      case int.parse(version_number) {
        Ok(version_part) -> {
          do_parse_version_numbers(
            remaining_graphemes,
            "",
            version_parts
              |> list.append([version_part]),
          )
        }
        Error(_) -> Error(InvalidVersion)
      }
    }
    [".", ..remaining_graphemes] ->
      do_parse_version_numbers(remaining_graphemes, buffer, version_parts)
    [elem, ..remaining_graphemes] -> {
      case int.parse(elem) {
        Ok(_) ->
          do_parse_version_numbers(
            remaining_graphemes,
            buffer <> elem,
            version_parts,
          )
        Error(_) -> Error(InvalidVersion)
      }
    }
    [] -> {
      version_parts
      |> check_version_parts
      |> result.map(fn(version_parts) {
        let #(major, minor, patch) = version_parts

        Parser(
          [],
          dict.new()
            |> dict.insert("major", int.to_string(major))
            |> dict.insert("minor", int.to_string(minor))
            |> dict.insert("patch", int.to_string(patch)),
        )
      })
    }
  }
}

/// Checks for the presence of all version parts.
fn check_version_parts(
  version_parts: List(Int),
) -> Result(#(Int, Int, Int), VersionError) {
  case version_parts {
    [major, minor, patch] -> Ok(#(major, minor, patch))
    [_major, _minor] -> Error(InvalidPatchVersion)
    [_major] -> Error(InvalidMinorVersion)
    [] -> Error(InvalidMajorVersion)
    [_major, _minor, _patch, ..] -> Error(InvalidVersion)
  }
}

/// Parses the pre-release label.
fn parse_prerelease(with parser: Parser) -> Result(Parser, VersionError) {
  case list.first(parser.input) {
    Ok("-") -> {
      case list.rest(parser.input) {
        Ok(input) -> do_parse_prerelease(parser, input, "")
        Error(_) -> Error(InvalidPrerelease)
      }
    }
    _ -> Ok(parser)
  }
}

/// Parses recursively each grapheme for reconstructing the pre-release label.
///
/// The condition for returning a new [Parser](#Parser) is there are no graphemes left or the next
/// one matches a `+` for build metadata. In either of this condition, the function verifies rules
/// on each dot separated identifiers to validate the reconstruction of the pre-release label.
fn do_parse_prerelease(
  parser: Parser,
  input: List(String),
  buffer: String,
) -> Result(Parser, VersionError) {
  case input {
    ["+", ..remaining_graphemes] -> {
      use prerelease <- result.try(
        buffer
        |> string.split(on: ".")
        |> validate_identifiers(predicate: fn(i) {
          !{ string.is_empty(i) || has_leading_zeros(i) }
          && is_valid_identifier(i)
        })
        |> result.replace_error(InvalidPrerelease),
      )

      case prerelease {
        Some(p) ->
          Ok(Parser(
            ["+", ..remaining_graphemes],
            parser.version_parts
              |> dict.insert("prerelease", p),
          ))
        None -> Error(InvalidPrerelease)
      }
    }
    [elem, ..remaining_graphemes] ->
      do_parse_prerelease(parser, remaining_graphemes, buffer <> elem)
    [] -> {
      use prerelease <- result.try(
        buffer
        |> string.split(on: ".")
        |> validate_identifiers(predicate: fn(i) {
          !{ string.is_empty(i) || has_leading_zeros(i) }
          && is_valid_identifier(i)
        })
        |> result.replace_error(InvalidPrerelease),
      )

      case prerelease {
        Some(p) ->
          Ok(Parser(
            [],
            parser.version_parts
              |> dict.insert("prerelease", p),
          ))
        None -> Error(InvalidPrerelease)
      }
    }
  }
}

/// Parses each grapheme for reconstructing the build metadata label.
///
/// As it is the last section, the function only verifies rules on each dot separated identifiers to
/// validate the reconstruction of the build metadata label.
///
/// If everything is OK, the function returns a dictionary that contains all version parts for
/// reconstructing a [`Version`](#Version) record.
fn parse_build_metadata(
  with parser: Parser,
) -> Result(Dict(String, String), VersionError) {
  case list.first(parser.input) {
    Ok("+") -> {
      case list.rest(parser.input) {
        Ok(input) -> {
          use build_metadata <- result.try(
            input
            |> string.join(with: "")
            |> string.split(on: ".")
            |> validate_identifiers(predicate: fn(i) {
              !string.is_empty(i) && is_valid_identifier(i)
            })
            |> result.replace_error(InvalidBuildMetadata),
          )

          case build_metadata {
            Some(bm) ->
              Ok(
                parser.version_parts
                |> dict.insert("build_metadata", bm),
              )
            None -> Error(InvalidBuildMetadata)
          }
        }
        Error(_) -> Error(InvalidBuildMetadata)
      }
    }
    _ -> Ok(parser.version_parts)
  }
}

/// Transforms version parts into a [`Version`](#Version) record.
fn transform_to_version(
  from input: Dict(String, String),
) -> Result(Version, VersionError) {
  use major <- result.try(
    input
    |> dict.get("major")
    |> result.map_error(fn(_) { InvalidMajorVersion })
    |> result.then(fn(major) {
      case int.parse(major) {
        Ok(major) -> Ok(major)
        Error(_) -> Error(InvalidMajorVersion)
      }
    }),
  )

  use minor <- result.try(
    input
    |> dict.get("minor")
    |> result.map_error(fn(_) { InvalidMinorVersion })
    |> result.then(fn(minor) {
      case int.parse(minor) {
        Ok(minor) -> Ok(minor)
        Error(_) -> Error(InvalidMinorVersion)
      }
    }),
  )

  use patch <- result.try(
    input
    |> dict.get("patch")
    |> result.map_error(fn(_) { InvalidPatchVersion })
    |> result.then(fn(patch) {
      case int.parse(patch) {
        Ok(patch) -> Ok(patch)
        Error(_) -> Error(InvalidPatchVersion)
      }
    }),
  )

  let prerelease =
    input
    |> dict.get("prerelease")
    |> option.from_result

  let build_metadata =
    input
    |> dict.get("build_metadata")
    |> option.from_result

  Ok(Version(major, minor, patch, prerelease, build_metadata))
}

/// Appends a pre-release to version.
///
/// A pre-release version indicates that the version is unstable and might not satisfy the intended
/// compatibility requirements as denoted by its associated normal version. Examples: `1.0.0-alpha`,
/// `1.0.0-alpha.1`, `1.0.0-0.3.7`, `1.0.0-x.7.z.92`, `1.0.0-x-y-z.--`.
///
/// # Error
///
/// If `prerelease` is not valid, then the [`InvalidPrerelease`](#VersionError) error will return.
///
/// # Example
///
/// ```gleam
/// use v <- result.map(
///   version.new(1, 0, 18)
///   |> version.with_prerelease("alpha.1"),
/// )
/// ```
pub fn with_prerelease(
  version: Result(Version, VersionError),
  prerelease: String,
) -> Result(Version, VersionError) {
  use prerelease <- result.try(
    prerelease
    |> string.split(on: ".")
    |> validate_identifiers(predicate: fn(i) {
      !{ string.is_empty(i) || has_leading_zeros(i) } && is_valid_identifier(i)
    }),
  )

  version
  |> result.map(with: fn(v) { Version(..v, prerelease: prerelease) })
}

/// Appends a build metadata to version.
///
/// Build metadata are additional information that are ignored during version precedence. Examples:
/// `1.0.0+a10234ff`, `1.0.0+a10234ff.001`, `1.0.0-alpha.1+bc632df`.
///
/// # Error
///
/// If `build_metadata` is not valid, the [`InvalidBuildMetadata`](#VersionError) error will return.
///
/// # Example
///
/// ```gleam
/// use v <- result.map(
///   version.new(1, 0, 18)
///   |> version.with_build_metadata("ae93d74"),
/// )
/// ```
pub fn with_build_metadata(
  version: Result(Version, VersionError),
  build_metadata: String,
) -> Result(Version, VersionError) {
  use build_metadata <- result.try(
    build_metadata
    |> string.split(on: ".")
    |> validate_identifiers(predicate: fn(i) {
      !string.is_empty(i) && is_valid_identifier(i)
    })
    |> result.replace_error(InvalidBuildMetadata),
  )

  version
  |> result.map(with: fn(v) { Version(..v, build_metadata: build_metadata) })
}

/// Validates identifiers.
///
/// This function verifies that all `identifiers` match the `predicate`. If `True`, then the
/// identifiers will join as a unique string separated by dots. Otherwise, a `InvalidPrerelease`
/// returns.
///
/// # Note
///
/// If the error is not what you want, you can remap with `result.replace_error`.
fn validate_identifiers(
  validate identifiers: List(String),
  predicate predicate: fn(String) -> Bool,
) -> Result(Option(String), VersionError) {
  case
    identifiers
    |> list.all(predicate)
  {
    True -> Ok(Some(string.join(identifiers, with: ".")))
    False -> Error(InvalidPrerelease)
  }
}

/// For an identifier to be valid, the specification says it must comprise only ASCII alphanumerics
/// and hyphens [A-Za-z0-9-].
///
/// +-----------+------------+
/// |        45 | '-'        |
/// +-----------+------------+
/// | 48 to  57 | '0' to '9' |
/// +-----------+------------+
/// | 65 to  90 | 'A' to 'Z' |
/// +-----------+------------+
/// | 97 to 122 | 'a' to 'z' |
/// +-----------+------------+
fn is_valid_identifier(with identifier: String) -> Bool {
  identifier
  |> string.to_graphemes
  |> list.all(fn(c) {
    let c = {
      let assert [char, ..] = string.to_utf_codepoints(c)

      char
      |> string.utf_codepoint_to_int
    }

    c == 45
    || { c >= 48 && c <= 57 }
    || { c >= 65 && c <= 90 }
    || { c >= 97 && c <= 122 }
  })
}

/// Checks if the identifier has leading zeros.
fn has_leading_zeros(with identifier: String) -> Bool {
  identifier
  |> string.starts_with("00")
}

/// Returns the major version.
///
/// # Example
///
/// ```gleam
/// use v <- result.map(version.new(1, 0, 18))
///
/// v
/// |> version.major
/// ```
///
/// ```text
/// 1
/// ```
pub fn major(version: Version) -> Int {
  version.major
}

/// Returns the minor version.
///
/// # Example
///
/// ```gleam
/// use v <- result.map(version.new(1, 0, 18))
///
/// v
/// |> version.minor
/// ```
///
/// ```text
/// 0
/// ```
pub fn minor(version: Version) -> Int {
  version.minor
}

/// Returns the patch version.
///
/// # Example
///
/// ```gleam
/// use v <- result.map(version.new(1, 0, 18))
///
/// v
/// |> version.patch
/// ```
///
/// ```text
/// 18
/// ```
pub fn patch(version: Version) -> Int {
  version.patch
}

/// Returns the pre-release version.
///
/// # Example
///
/// ```gleam
/// use v <- result.map(
///   version.new(1, 0, 18)
///   |> version.with_prerelease("alpha.1"),
/// )
///
/// v
/// |> version.prerelease
/// ```
///
/// ```gleam
/// Some("alpha.1")
/// ```
pub fn prerelease(version: Version) -> Option(String) {
  version.prerelease
}

/// Returns the build metadata of the version.
///
/// # Example
///
/// ```gleam
/// use v <- result.map(
///   version.new(1, 0, 18)
///   |> version.with_build_metadata("ae93d74"),
/// )
///
/// v
/// |> version.build_metadata
/// ```
///
/// ```gleam
/// Some("ae93d74")
/// ```
pub fn build_metadata(version: Version) -> Option(String) {
  version.build_metadata
}

/// Converts a `Version` to a `String`.
///
/// # Example
///
/// ```gleam
/// use v <- result.map(
///   version.new(1, 0, 18)
///   |> version.with_prerelease("beta.8")
///   |> version.with_build_metadata("dff999"),
/// )
///
/// v
/// |> version.to_string
/// |> io.println
/// ```
///
/// ```text
/// 1.0.1-beta.8+dff999
/// ```
pub fn to_string(version: Version) -> String {
  let v =
    int.to_string(version.major)
    <> "."
    <> int.to_string(version.minor)
    <> "."
    <> int.to_string(version.patch)

  let p =
    version
    |> prerelease
    |> option.then(fn(p) { Some(string.concat(["-", p])) })
    |> option.unwrap(or: "")

  let b =
    version
    |> build_metadata
    |> option.then(fn(b) { Some(string.concat(["+", b])) })
    |> option.unwrap(or: "")

  string.concat([v, p, b])
}

/// Compares two versions.
///
/// The comparison of two versions `a` and `b` is carried out in two logical steps.
///
/// The first step consists of comparing numerically the fields `major`, `minor`, and `patch` to
/// find a difference. If the comparison results in equality, then we will proceed to the second
/// step if and only if there is a presence of a pre-release label in either one or both versions.
///
/// The second step consists of comparing each dot separated identifier of the pre-release label
/// from both versions `a` and `b` until a difference is found. If a version has'nt a pre-release
/// label, then it will have a higher precedence than the other.
///
/// Example: `1.2.3-alpha.1` < `1.2.3`.
///
/// # Example
///
/// ```gleam
/// use v1 <- result.map(version.new(1, 15, 0))
/// use v2 <- result.map(version.new(0, 30, 5))
///
/// v1
/// |> version.compare(v2)
/// ```
///
/// ```gleam
/// order.Gt
/// ```
///
/// # Precedence
///
/// Precedence for two pre-release versions with the same `major`, `minor` and `patch` field
/// consists of comparing each dot separated identifier from left to right until a difference is
/// found.
///
/// - Identifiers consisting of only digits are compared numerically.
/// - Identifiers with letters or hyphens are compared lexically in ASCII sort order.
/// - Numeric identifiers always have a lower precedence than non-numeric identifiers.
/// - A larget set of identifiers will always have a higher precedence than a smaller set if and
///   only if all of the preceding identifiers are equal.
///
/// If there is no precedence and both versions are exactly the same, then the function will return
/// `order.Eq`.
///
/// ```gleam
/// use v <- result.map(
///   version.new(1, 0, 0)
///   |> version.with_prerelease("alpha.1.beta.2.gamma.3.---"),
/// )
///
/// v
/// |> version.compare(v)
/// ```
///
/// ```gleam
/// order.Eq
/// ```
///
/// ## Precedence and Build Metadata
///
/// According to the specification, the `build-metadata` label is ignored during the comparison.
///
/// ```gleam
/// use v1 <- result.map(
///   version.new(1, 15, 0)
///   |> version.with_prerelease("alpha.1")
///   |> version.with_build_metadata("aef1678"),
/// )
///
/// use v2 <- result.map(
///   version.new(1, 15, 0)
///   |> version.with_prerelease("alpha.1"),
/// )
///
/// v1
/// |> version.compare(v2)
/// |> should.equal(order.Eq)
/// ```
///
/// ```gleam
/// order.Eq
/// ```
pub fn compare(a: Version, b: Version) -> order.Order {
  case equal_to(a, b) {
    True -> compare_prerelease(a, b)
    False ->
      case less(a, b) {
        True -> order.Lt
        False -> order.Gt
      }
  }
}

/// Determines the equality of two versions.
///
/// This function will compare numerically two versions by verifying equality only for the `major`,
/// `minor`, and `patch` fields.
fn equal_to(a: Version, b: Version) -> Bool {
  a.major == b.major && a.minor == b.minor && a.patch == b.patch
}

/// Determines the precedence of two versions.
///
/// This function will compare numerically two versions by verifying the precedence only for the `major`,
/// `minor`, and `patch` fields.
fn less(a: Version, b: Version) -> Bool {
  a.major < b.major
  || { a.major == b.major && a.minor < b.minor }
  || { a.major == b.major && a.minor == b.minor && a.patch < b.patch }
}

/// Compares the pre-release label identifiers of two versions.
fn compare_prerelease(a: Version, b: Version) -> order.Order {
  case option.is_some(a.prerelease), option.is_some(b.prerelease) {
    False, False -> order.Eq
    False, True -> order.Gt
    True, False -> order.Lt
    True, True -> {
      let a_prerelease =
        a.prerelease
        |> option.unwrap(or: "")
        |> string.split(on: ".")

      let b_prerelease =
        b.prerelease
        |> option.unwrap(or: "")
        |> string.split(on: ".")

      do_compare_prerelease(a_prerelease, b_prerelease)
    }
  }
}

/// Compares recursively each identifier of two pre-release versions.
fn do_compare_prerelease(a: List(String), b: List(String)) -> order.Order {
  case a, b {
    [a], [b] -> compare_identifiers(a, b)
    [a, ..arest], [b, ..brest] -> {
      case compare_identifiers(a, b) {
        order.Eq -> do_compare_prerelease(arest, brest)
        order.Gt -> order.Gt
        order.Lt -> order.Lt
      }
    }
    [_], [] | [_, ..], [] -> order.Gt
    [], [_] | [], [_, ..] -> order.Lt
    // We should never reach this state as the patterns above shall catch all the possibilities.
    [], [] -> order.Eq
  }
}

/// Compares two identifiers `a` and `b` and returns the order as a result.
///
/// - If both identifiers are only digits, then they are compared numerically.
/// - If either `a` or `b` is numeric, then it will have a lower precedence.
/// - If both identifiers are non-digits, then they are compared lexically in ASCII sort order.
fn compare_identifiers(a: String, b: String) -> order.Order {
  let left = int.parse(a)
  let right = int.parse(b)

  case left, right {
    Ok(l), Ok(r) -> int.compare(l, r)
    Ok(_), Error(_) -> order.Lt
    Error(_), Ok(_) -> order.Gt
    Error(_), Error(_) -> string.compare(a, b)
  }
}
