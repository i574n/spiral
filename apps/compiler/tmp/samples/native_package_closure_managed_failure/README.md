# Package-owned managed closure failure

This fixture proves that one String-capturing closure value can be owned by `types/callable`, constructed through `selector/select`, consumed by `consumer/use`, and released correctly when invocation fails.

The C residual deliberately places `PortableFail` immediately before a synthetic return inside each closure branch. Rust must emit `panic!` without an unreachable return. Delphi must emit `raise Exception.Create` and carry `SysUtils` into the package-owned type unit.

`failure_lifecycle.rs` keeps an external `Rc<str>` and proves the strong count returns from 2 to 1 after unwind. `failure_lifecycle.pas` checks the equivalent bounded FPC 3.2.2 AnsiString reference-count contract: the temporary call copy is released during exception unwinding, the owned record copy can be cleared, and the external string remains usable.

The FPC refcount probe belongs only to the native test harness. It is not compiler or runtime production code.
