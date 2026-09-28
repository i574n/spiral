# Managed package-owned type

This fixture proves that one package can own a managed record while another package consumes it through a public signature. `Tuple0` contains an owned string and an `i32`. Rust exposes only the sidecar-declared type fields and restores the standard `Rc` import in the moved consumer module; Delphi uses its ordinary managed string record semantics. The invalid project attempts to relocate the managed type to the consumer and must fail before output is committed.
