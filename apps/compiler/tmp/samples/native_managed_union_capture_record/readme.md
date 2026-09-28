# Managed union captured by a reusable closure

This source-real authority captures `Empty | Item (string * array i32)` inside a returned closure. The program exercises both tags, invokes the `Item` closure twice and returns 42 in C, Rust and Delphi.

Rust derives `Clone` for the closure environment and clones the captured residual union before each invocation. Delphi relies on its managed record fields. The portable classifier accepts the capture only when the C residual proves both constructor ownership transfer and explicit closure decref lifecycle.

The focused gate also projects Rust and Delphi packages and keeps two exact negative fixtures: one removes the capture decref and the other removes constructor ownership transfer. This authority does not claim arbitrary nested managed unions, interprocedural aliasing or general closure-environment relocation.
