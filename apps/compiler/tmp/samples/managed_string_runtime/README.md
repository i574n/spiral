# Managed string runtime

Exercises the C string runtime through repeated consumers of one string value. The Spiral optimizer may common-subexpression-eliminate the duplicate length read; the portable Rust and Delphi lowerings must still remove the C refcount helper surface and return zero natively.

Current boundary: string length and literal bridging are positive. Indexing, slicing, concatenation, heap-owned mutation and explicit shared ownership remain open.
