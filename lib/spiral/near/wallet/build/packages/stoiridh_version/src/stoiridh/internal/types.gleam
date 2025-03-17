/// The `ConstraintResult` type holds the result of version constraint parsing.
///
/// The `Strict` type means that the version constraint contains the `Major`, `Minor` and `Patch`
/// parts.
///
/// The `Partial` type means that the version constraint contains only either `Major` or `Major` and
/// `Minor` parts.
///
/// The `Wildcard` type means that the version constraint contains a wildcard in one of the `Major`,
/// `Minor`, and `Patch` parts.
///
/// The `Partial` and `Wildcard` types may seem similar, but they differ on how to correctly
/// interpret a version constraint.
pub type ConstraintResult {
  Partial(version_part: VersionPart)
  Strict
  Wildcard(version_part: VersionPart)
}

/// The `VersionPart` type contains the parts that compose a version number. Labels are not
/// represented here.
pub type VersionPart {
  Major
  Minor
  Patch
}
