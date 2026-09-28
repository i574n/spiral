# Package-owned managed array closure failure

This fixture proves a single package-owned callable group containing `Array0`, its bounded runtime helpers and `ClosureValue0` across the graph `types/callable -> selector/select -> consumer/use -> root`.

The selected closure reads its captured array and exits through the shared `PortableFail` path. Rust catches the panic and verifies the external `Rc<RefCell<Vec<i32>>>` returns from strong count 2 to 1. Delphi catches the matching exception, clears the closure field and verifies the external dynamic array remains valid.

The fixture also protects two generic lowering boundaries: nested captured field reads must become `DynamicArrayGet` calls before simple variable replacement, and a Delphi type owner must not import `SysUtils` twice when array range helpers already placed it in the interface.

It does not claim heterogeneous closure environments, recursive shared callable groups, multi-owner type relocation or general control-flow analysis.
