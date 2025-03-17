//// An internal module that contains types and functions to keep track of version numbers position
//// during version constraints parsing.

import stoiridh/internal/types.{type VersionPart, Major, Minor, Patch}

/// A `Cursor` type to know the parser position.
pub type Cursor {
  Cursor(version_part: VersionPart)
}

/// Constructs a new cursor.
///
/// By default, the cursor is set to the `Major` position.
pub fn new() -> Cursor {
  Cursor(Major)
}

/// Increments the cursor to the next one until `Patch` is reached.
///
/// > Major -> Minor -> Patch
pub fn next(cursor: Cursor) -> Cursor {
  case cursor {
    Cursor(Major) -> Cursor(Minor)
    Cursor(Minor) -> Cursor(Patch)
    Cursor(Patch) -> Cursor(Patch)
  }
}
