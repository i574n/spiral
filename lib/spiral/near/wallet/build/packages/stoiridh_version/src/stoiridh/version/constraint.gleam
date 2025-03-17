//// A module that contains types and functions to work with version constraints.
////
//// ## Import
////
//// To import the types and functions of this module, add the following import statement in your
//// _gleam_ files:
////
//// ```gleam
//// import stoiridh/version/constraint
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
//// import stoiridh/version/constraint
////
//// pub fn main() {
////   use v1 <- result.map(
////     version.new(5, 12, 4)
////     |> version.with_prerelease("alpha.20")
////     |> version.with_build_metadata("49ae79"),
////   )
////
////   use vc <- result.map(
////     constraint.new("^5")
////   )
////
////   v1
////   |> version.to_string
////   |> io.println
////
////   vc
////   |> constraint.check(v1)
////   |> io.debug
//// }
//// ```
////
//// ```text
//// 5.12.4-alpha.20+49ae79
//// True
//// ```

import gleam/bool
import gleam/int
import gleam/io
import gleam/list
import gleam/order
import gleam/result
import gleam/string

import stoiridh/internal/cursor.{type Cursor, Cursor}
import stoiridh/internal/types.{
  type ConstraintResult, Major, Minor, Partial, Patch, Strict, Wildcard,
}
import stoiridh/version.{type Version, type VersionError}

/// A version `Constraint` type.
///
/// The version `Constraint` type holds all version constraints that will next apply during a
/// [check](#check) on a version number to verify if it satisfies the version constraint.
pub opaque type Constraint {
  Constraint(constraints: List(#(Operator, Version)))
}

pub type ConstraintError {
  /// The given version constraint does not respect the constraint definition.
  InvalidConstraint
}

/// An `Operator` internal type.
///
/// The following operators allow associating version numbers as a version constraint.
type Operator {
  /// The `=` operator.
  Equal

  /// The `<` operator.
  LessThan

  /// The `<=` operator.
  LessThanOrEqualTo

  /// The `>` operator.
  GreaterThan

  /// The `>=` operator.
  GreaterThanOrEqualTo

  /// The `^` operator.
  Caret

  /// The `~` operator.
  Tilde
}

/// Creates a new version constraint.
///
/// A version constraint contains one or more conditions to check the acceptability of a version.
///
/// # Operators
///
/// When you create a new version constraint, you should specify an operator that will determine,
/// during a [check](#check), if a version satisfies the version constraint. If omitted, the version
/// number within the version constraint will implicitly consider as the `=` operator.
///
/// In the table below, the accepted operators that supports the function:
///
/// | Operator | Description                                                                                                         |
/// | -------- | ------------------------------------------------------------------------------------------------------------------- |
/// | `=`      | The *equal* operator will check if a version matches exactly the version constraint.                                |
/// | `<`      | The *less than* operator will check if a version is less than the version constraint.                               |
/// | `<=`     | The *less than or equal to* operator will check if a version is less than or equal to the version constraint.       |
/// | `>`      | The *greater than* operator will check if a version is greater than the version constraint.                         |
/// | `>=`     | The *greater than or equal to* operator will check if a version is greater than or equal to the version constraint. |
/// | `^`      | The *caret* operator will check for compatible updates to a specified version.                                      |
/// | `~`      | The *tilde* operator will check for patch updates to a specified version.                                           |
///
/// ## The `=` operator
///
/// As you may expect, the *equal* operator should strictly check the equivalence of a version
/// compared to a version constraint. But it did not. Indeed, when a version constraint is partial
/// or have a wildcard, some logical rules are applied to make sure you match a range of potential
/// versions:
///
/// | Version Constraint | Equivalent To    | Rule                 |
/// | ------------------ | ---------------- | -------------------- |
/// | `=1` or `=1.x`     | `>=1.0.0 <2.0.0` | `>=I.0.0 <(I+1).0.0` |
/// | `=1.1` or `=1.1.x` | `>=1.1.0 <1.2.0` | `>=I.J.0 <I.(J+1).0` |
/// | `=1.1.1`           | `=1.1.1`         | `=I.J.K`             |
///
/// ### Special Case: Wildcard in Major Version Number Constraint
///
/// Putting a wildcard in a major version number part is prohibited whatever the operators. However,
/// this function only accepts a wildcard for the `=` operator as it make sense to want the latest
/// version available for a package, as an example, whatever the reason behind.
///
/// | Version Constraint | Equivalent To |
/// | ------------------ | ------------- |
/// | `*`                | `>=0.0.0`     |
/// | `=*`               | `>=0.0.0`     |
///
/// ## The `^` operator 
///
/// The *caret* operator allows finding compatible updates to a specified version:
///
/// | Version Constraint | Equivalent To    | Rule                 |
/// | ------------------ | ---------------- | -------------------- |
/// | `^0` or `^0.x`     | `>=0.0.0 <1.0.0` | `>=I.0.0 <(I+1).0.0` |
/// | `^1` or `^1.x`     | `>=1.0.0 <2.0.0` | `>=I.0.0 <(I+1).0.0` |
/// | `^0.5` or `^0.5.x` | `>=0.5.0 <0.6.0` | `>=0.J.0 <0.(J+1).0` |
/// | `^1.1` or `^1.1.x` | `>=1.1.0 <2.0.0` | `>=I.J.0 <(I+1).0.0` |
/// | `^0.0.7`           | `=0.0.7`         | `=0.0.K`             |
/// | `^1.1.0`           | `>=1.1.0 <2.0.0` | `>=I.J.0 <(I+1).0.0` |
///
/// ## The `~` operator
///
/// The *tilde* operator allows finding patch updates to a specified version:
///
/// | Version Constraint | Equivalent To    | Rule                 |
/// | ------------------ | ---------------- | -------------------- |
/// | `~0` or `~0.x`     | `>=0.0.0 <1.0.0` | `>=0.0.0 <(I+1).0.0` |
/// | `~1` or `~1.x`     | `>=1.0.0 <2.0.0` | `>=I.0.0 <(I+1).0.0` |
/// | `~0.5` or `~0.5.x` | `>=0.5.0 <0.6.0` | `>=0.J.0 <0.(J+1).0` |
/// | `~1.1` or `~1.1.x` | `>=1.1.0 <1.2.0` | `>=I.J.0 <I.(J+1).0` |
/// | `~0.0.7`           | `>=0.0.7 <0.1.0` | `>=0.0.K <0.(J+1).0` |
/// | `~1.1.0`           | `>=1.1.0 <1.2.0` | `>=I.J.0 <I.(J+1).0` |
///
/// # Wildcard and Partial Version Number within Version Constraints
///
/// Unlike `version.new`, a version constraint may contain wildcards or be partial.
///
/// ## Wildcard
///
/// This function supports three kinds of wildcards: `*`, `x`, and `X`. A wildcard allows you to not
/// specify the part of a version number.
///
/// However, keep in mind it is strictly prohibited from putting a wildcard into a major version
/// part. Except if and only if the definition of the version constraint is `"*"` or `"=*"`.
///
/// # Example
///
/// ```gleam
/// import gleam/io
/// import gleam/result
///
/// import stoiridh/version
/// import stoiridh/version/constraint
///
/// pub fn main() {
///   use vc <- result.map(constraint.new("=1.*"))
///   use v1 <- result.map(version.parse("1.4.0"))
///   use v2 <- result.map(version.parse("2.0.0"))
///
///   vc
///   |> constraint.check(v1)
///   |> io.debug
///
///   vc
///   |> constraint.check(v2)
///   |> io.debug
/// }
/// ```
///
/// ```text
/// True
/// False
/// ```
pub fn new(constraints: String) -> Result(Constraint, ConstraintError) {
  parse_constraints(constraints)
}

/// Checks the acceptability of a version against this version constraint.
///
/// # Example
///
/// ```gleam
/// import gleam/io
/// import gleam/result
///
/// import stoiridh/version
/// import stoiridh/version/constraint
///
/// pub fn main() {
///   use vc <- result.map(constraint.new("=1.0.0"))
///   use v1 <- result.map(version.parse("1.4.0"))
///   use v2 <- result.map(version.parse("2.0.0"))
///
///   vc
///   |> constraint.check(v1)
///   |> io.debug
///
///   vc
///   |> constraint.check(v2)
///   |> io.debug
/// }
/// ```
///
/// ```text
/// False
/// False
/// ```
pub fn check(this constraint: Constraint, with_this version: Version) -> Bool {
  constraint.constraints
  |> list.all(satisfying: fn(c) -> Bool {
    case c {
      #(Caret, v) -> {
        io.println_error(
          "^"
          <> version.to_string(v)
          <> " was not interpreted correctly. Please, open an issue at"
          <> " https://gitlab.com/stoiridh-project/stoiridh-version/-/issues"
          <> " with a reproductible example.",
        )
        False
      }
      #(Tilde, v) -> {
        io.println_error(
          "~"
          <> version.to_string(v)
          <> " was not interpreted correctly. Please, open an issue at"
          <> " https://gitlab.com/stoiridh-project/stoiridh-version/-/issues"
          <> " with a reproductible example.",
        )
        False
      }
      #(Equal, v) -> version.compare(version, v) == order.Eq
      #(LessThan, v) -> version.compare(version, v) == order.Lt
      #(LessThanOrEqualTo, v) -> {
        case version.compare(version, v) {
          order.Lt | order.Eq -> True
          order.Gt -> False
        }
      }
      #(GreaterThan, v) -> version.compare(version, v) == order.Gt
      #(GreaterThanOrEqualTo, v) -> {
        case version.compare(version, v) {
          order.Gt | order.Eq -> True
          order.Lt -> False
        }
      }
    }
  })
}

/// Parses version constraints from a `String` representation.
///
/// # Warning
///
/// Currently, the function supports only `,` as a separator for multiple version constraints.
fn parse_constraints(constraint: String) -> Result(Constraint, ConstraintError) {
  case constraint {
    "=*" | "*" -> {
      use version <- result.try(
        version.new(0, 0, 0)
        |> result.map_error(fn(_) { InvalidConstraint }),
      )

      Ok(Constraint([#(GreaterThanOrEqualTo, version)]))
    }
    _ -> {
      let constraints = string.split(constraint, on: ",")

      case list.is_empty(constraints) {
        True -> do_parse_constraints([constraint])
        False -> do_parse_constraints(constraints)
      }
    }
  }
}

fn do_parse_constraints(
  constraints: List(String),
) -> Result(Constraint, ConstraintError) {
  use parsed_constraints <- result.try(
    constraints
    |> list.try_fold(from: Constraint([]), with: fn(cs, c) {
      use parsed_constraints <- result.try(parse_constraint(string.trim(c)))

      Ok(Constraint(list.append(cs.constraints, parsed_constraints)))
    }),
  )

  Ok(parsed_constraints)
}

/// Parses a version constraint.
fn parse_constraint(
  constraint: String,
) -> Result(List(#(Operator, Version)), ConstraintError) {
  case constraint {
    "^" <> c -> {
      use versions <- result.try(parse_caret_version_constraint(c))
      Ok(versions)
    }
    "~" <> c -> {
      use versions <- result.try(parse_tilde_version_constraint(c))
      Ok(versions)
    }
    "<=" <> c -> {
      use versions <- result.try(parse_version_constraint(LessThanOrEqualTo, c))
      Ok(versions)
    }
    "<" <> c -> {
      use versions <- result.try(parse_version_constraint(LessThan, c))
      Ok(versions)
    }
    ">=" <> c -> {
      use versions <- result.try(parse_version_constraint(
        GreaterThanOrEqualTo,
        c,
      ))
      Ok(versions)
    }
    ">" <> c -> {
      use versions <- result.try(parse_version_constraint(GreaterThan, c))
      Ok(versions)
    }
    "=" <> c | c -> {
      use versions <- result.try(parse_equality_version_constraint(c))
      Ok(versions)
    }
  }
}

/// Parses versions from a version constraint.
fn parse_version_constraint(
  for operator: Operator,
  version constraint: String,
) -> Result(List(#(Operator, Version)), ConstraintError) {
  use constraints <- result.try(
    constraint
    |> parse_loosely
    |> result.then(apply: fn(state) {
      let #(constraint_result, version) = state

      case constraint_result {
        Strict -> {
          Ok([#(operator, version)])
        }
        Wildcard(Major) -> {
          Error(InvalidConstraint)
        }
        Partial(Patch) | Wildcard(Patch) -> {
          case operator {
            LessThanOrEqualTo -> {
              use nmv <- result.try(
                next_minor_version(version)
                |> result.map_error(fn(_) { InvalidConstraint }),
              )
              Ok([#(LessThan, nmv)])
            }
            _ -> {
              Ok([#(operator, version)])
            }
          }
        }
        Partial(Minor) -> {
          case operator {
            GreaterThan -> {
              use nmv <- result.try(
                next_minor_version(version)
                |> result.map_error(fn(_) { InvalidConstraint }),
              )
              Ok([#(GreaterThanOrEqualTo, nmv)])
            }
            LessThanOrEqualTo -> {
              use nmv <- result.try(
                next_minor_version(version)
                |> result.map_error(fn(_) { InvalidConstraint }),
              )
              Ok([#(LessThan, nmv)])
            }
            _ -> Ok([#(operator, version)])
          }
        }
        Partial(Major) | Wildcard(Minor) -> {
          case operator {
            GreaterThan -> {
              use nmv <- result.try(
                next_major_version(version)
                |> result.map_error(fn(_) { InvalidConstraint }),
              )

              Ok([#(GreaterThanOrEqualTo, nmv)])
            }
            LessThanOrEqualTo -> {
              use nmv <- result.try(
                next_major_version(version)
                |> result.map_error(fn(_) { InvalidConstraint }),
              )

              Ok([#(LessThan, nmv)])
            }
            _ -> {
              Ok([#(operator, version)])
            }
          }
        }
      }
    }),
  )

  Ok(constraints)
}

/// Parses the equality version constraint and expand it if necessary.
///
/// The equality version constraint will expand only if the version number is partial or has a
/// wildcard.
///
/// | Version Constraint | Equivalent To  |
/// | ------------------ | -------------- |
/// | =1.2.0             | =1.2.0         |
/// | =1.2               | >=1.2.0 <1.3.0 |
/// | =1                 | >=1.0.0 <2.0.0 |
/// | =0                 | >=0.0.0 <1.0.0 |
/// | =*                 | >=0.0.0        |
fn parse_equality_version_constraint(
  version constraint: String,
) -> Result(List(#(Operator, Version)), ConstraintError) {
  use constraints <- result.try(
    constraint
    |> parse_loosely
    |> result.then(apply: fn(state) {
      let #(constraint_result, version) = state

      case constraint_result {
        Strict -> Ok([#(Equal, version)])
        Wildcard(Patch) | Partial(Patch) -> {
          use nmv <- result.try(
            next_minor_version(version)
            |> result.map_error(fn(_) { InvalidConstraint }),
          )

          Ok([#(GreaterThanOrEqualTo, version), #(LessThan, nmv)])
        }
        Wildcard(Minor) -> {
          use nmv <- result.try(
            next_major_version(version)
            |> result.map_error(fn(_) { InvalidConstraint }),
          )

          Ok([#(GreaterThanOrEqualTo, version), #(LessThan, nmv)])
        }
        Partial(Minor) -> {
          use nmv <- result.try(
            next_minor_version(version)
            |> result.map_error(fn(_) { InvalidConstraint }),
          )

          Ok([#(GreaterThanOrEqualTo, version), #(LessThan, nmv)])
        }
        Wildcard(Major) -> {
          case version.to_string(version) {
            "0.0.0" -> Ok([#(GreaterThanOrEqualTo, version)])
            _ -> {
              use nmv <- result.try(
                next_major_version(version)
                |> result.map_error(fn(_) { InvalidConstraint }),
              )

              Ok([#(GreaterThanOrEqualTo, version), #(LessThan, nmv)])
            }
          }
        }
        Partial(Major) -> {
          use nmv <- result.try(
            next_major_version(version)
            |> result.map_error(fn(_) { InvalidConstraint }),
          )

          Ok([#(GreaterThanOrEqualTo, version), #(LessThan, nmv)])
        }
      }
    }),
  )

  Ok(constraints)
}

/// Parses the caret version constraint.
///
///
/// | Version Constraint | Equivalent To     |
/// | ------------------ | ----------------- |
/// | ^0.0.5             | =0.0.5            |
/// | ^1.0.0             | >=1.0.0 <2.0.0    |
/// | ^0.4.2             | >=0.4.2 <0.5.0    |
/// | ^1.2               | >=1.2.0 <2.0.0    |
/// | ^1.2.*             | >=1.2.0 <2.0.0    |
/// | ^0                 | >=0.0.0 <1.0.0    |
/// | ^2.*               | >=2.0.0 <3.0.0    |
/// | ^*                 | InvalidConstraint |
fn parse_caret_version_constraint(
  version constraint: String,
) -> Result(List(#(Operator, Version)), ConstraintError) {
  use constraints <- result.try(
    constraint
    |> parse_loosely
    |> result.then(apply: fn(state) {
      let #(constraint_result, version) = state

      case constraint_result {
        Strict -> {
          let major = version |> version.major
          let minor = version |> version.minor

          case major, minor {
            0, 0 -> {
              Ok([#(Equal, version)])
            }
            0, _ -> {
              use nmv <- result.try(
                version
                |> next_minor_version
                |> result.map_error(fn(_) { InvalidConstraint }),
              )

              Ok([#(GreaterThanOrEqualTo, version), #(LessThan, nmv)])
            }
            _, _ -> {
              use nmv <- result.try(
                version
                |> next_major_version
                |> result.map_error(fn(_) { InvalidConstraint }),
              )

              Ok([#(GreaterThanOrEqualTo, version), #(LessThan, nmv)])
            }
          }
        }
        Partial(Minor) | Wildcard(Patch) -> {
          let major = version |> version.major

          use nmv <- result.try(case major {
            0 -> {
              use nmv <- result.map(
                version
                |> next_minor_version
                |> result.map_error(fn(_) { InvalidConstraint }),
              )
              nmv
            }
            _ -> {
              use nmv <- result.map(
                version
                |> next_major_version
                |> result.map_error(fn(_) { InvalidConstraint }),
              )
              nmv
            }
          })

          Ok([#(GreaterThanOrEqualTo, version), #(LessThan, nmv)])
        }
        Wildcard(Major) -> {
          Error(InvalidConstraint)
        }
        _ -> {
          use nmv <- result.try(
            version
            |> next_major_version
            |> result.map_error(fn(_) { InvalidConstraint }),
          )
          Ok([#(GreaterThanOrEqualTo, version), #(LessThan, nmv)])
        }
      }
    }),
  )

  Ok(constraints)
}

/// Parses the tilde version constraint.
///
/// | Version Constraint | Equivalent To     |
/// | ------------------ | ----------------- |
/// | ~0.0.5             | >=0.0.5 <0.1.0    |
/// | ~1.0.0             | >=1.0.0 <1.1.0    |
/// | ~0.4.2             | >=0.4.2 <0.5.0    |
/// | ~1.2               | >=1.2.0 <1.3.0    |
/// | ~1.2.*             | >=1.2.0 <1.3.0    |
/// | ~0                 | >=0.0.0 <1.0.0    |
/// | ~2.*               | >=2.0.0 <3.0.0    |
/// | ~*                 | InvalidConstraint |
fn parse_tilde_version_constraint(
  version constraint: String,
) -> Result(List(#(Operator, Version)), ConstraintError) {
  use constraints <- result.try(
    constraint
    |> parse_loosely
    |> result.then(apply: fn(state) {
      let #(constraint_result, version) = state

      case constraint_result {
        Strict | Partial(Minor) | Wildcard(Patch) -> {
          use nmv <- result.try(
            version
            |> next_minor_version
            |> result.map_error(fn(_) { InvalidConstraint }),
          )

          Ok([#(GreaterThanOrEqualTo, version), #(LessThan, nmv)])
        }
        Wildcard(Major) -> {
          Error(InvalidConstraint)
        }
        _ -> {
          use nmv <- result.try(
            version
            |> next_major_version
            |> result.map_error(fn(_) { InvalidConstraint }),
          )
          Ok([#(GreaterThanOrEqualTo, version), #(LessThan, nmv)])
        }
      }
    }),
  )

  Ok(constraints)
}

/// Restores maybe a partial version to a version that contains a `major`, `minor`, and `patch` part.
///
/// | Input | Output          |
/// | ----- | --------------- |
/// | 1     | 1.0.0           |
/// | 1.2   | 1.2.0           |
/// | 1.x   | 1.0.0           |
/// | 1.5.X | 1.5.0           |
/// | 1x    | InvalidVersion  |
/// | 1.**  | InvalidVersion  |
fn parse_loosely(
  constraint: String,
) -> Result(#(ConstraintResult, Version), ConstraintError) {
  constraint
  |> string.trim
  |> string.to_graphemes
  |> list.try_fold(
    from: #(cursor.new(), Strict, ""),
    with: fn(state, current_char) {
      let #(cursor, result, version) = state

      case current_char {
        "." -> {
          Ok(#(cursor.next(cursor), result, version <> "."))
        }
        "*" | "x" | "X" -> {
          use <- bool.guard(
            !{ string.is_empty(version) || string.ends_with(version, ".") },
            Error(InvalidConstraint),
          )

          let new_result = case cursor {
            Cursor(Major) -> Wildcard(Major)
            Cursor(Minor) -> Wildcard(Minor)
            Cursor(Patch) -> Wildcard(Patch)
          }

          Ok(#(cursor, new_result, version <> "0"))
        }
        c -> {
          case int.parse(c) {
            Ok(_) -> {
              Ok(#(cursor, result, version <> c))
            }
            Error(_) -> Error(InvalidConstraint)
          }
        }
      }
    },
  )
  |> result.then(transform_to_version_constraint)
}

/// Transforms a version constraint from its string representation to a Version type.
fn transform_to_version_constraint(
  state: #(Cursor, ConstraintResult, String),
) -> Result(#(ConstraintResult, Version), ConstraintError) {
  let #(cursor, result, version) = state

  case result {
    Strict -> {
      case cursor {
        Cursor(Major) -> {
          use version <- result.try(
            version.parse(version <> ".0.0")
            |> result.map_error(fn(_) { InvalidConstraint }),
          )

          Ok(#(Partial(Major), version))
        }
        Cursor(Minor) -> {
          use version <- result.try(
            version.parse(version <> ".0")
            |> result.map_error(fn(_) { InvalidConstraint }),
          )

          Ok(#(Partial(Minor), version))
        }
        Cursor(Patch) -> {
          use version <- result.try(
            version.parse(version)
            |> result.map_error(fn(_) { InvalidConstraint }),
          )

          Ok(#(Strict, version))
        }
      }
    }
    Wildcard(Patch) -> {
      use version <- result.try(
        version.parse(version)
        |> result.map_error(fn(_) { InvalidConstraint }),
      )

      Ok(#(Wildcard(Patch), version))
    }
    Wildcard(Minor) -> {
      use version <- result.try(
        version.parse(version <> ".0")
        |> result.map_error(fn(_) { InvalidConstraint }),
      )

      Ok(#(Wildcard(Minor), version))
    }
    Wildcard(Major) -> {
      use version <- result.try(
        version.parse(version <> ".0.0")
        |> result.map_error(fn(_) { InvalidConstraint }),
      )

      Ok(#(Wildcard(Major), version))
    }
    Partial(Patch) | Partial(Minor) | Partial(Major) -> {
      Error(InvalidConstraint)
    }
  }
}

/// Increments the next minor version.
fn next_minor_version(version: Version) -> Result(Version, VersionError) {
  version.new(version.major(version), version.minor(version) + 1, 0)
}

/// Increments the next major version.
fn next_major_version(version: Version) -> Result(Version, VersionError) {
  version.new(version.major(version) + 1, 0, 0)
}
