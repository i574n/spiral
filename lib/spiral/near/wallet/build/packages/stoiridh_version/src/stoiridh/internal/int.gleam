//// An internal module to validate integers.

import gleam/int

/// Checks if `value` is greater than or equal to zero.
///
/// If `True`, then the function returns the value unchanged. Otherwise, the function returns an
/// error with a message.
///
/// # Example
///
/// ```gleam
/// let value = -1
///
/// value
/// |> int.is_positive
/// ```
pub fn is_positive(from value: Int) -> Result(Int, String) {
  case value {
    value if value >= 0 -> Ok(value)
    _ -> Error(int.to_string(value) <> " is not a positive integer.")
  }
}
