# Native closure nested branch

This fixture proves that the portable lowering can merge runtime branches between closures with identical non-recursive capture layouts when each closure method contains nested `if/else` control flow.

Each closure captures two values: one managed string and one scalar bias. The selected closure receives `37`; the true branch computes `length("abc") + 2 + 37 = 42`. C, Rust and Delphi must compile and terminate with exit code 42. Rust is compiled with `-D warnings`.

`invalid.c` preserves the nested bodies and capture layout but changes the second callable parameter from `int32_t` to `int64_t`. The lowering must reject the family before emitting a destination because shared closure implementations require one compatible callable signature.

This authority proves balanced nested-method extraction and multiple identical captures. It does not claim arbitrary statement IR, loops inside closures, exception unwinding, heterogeneous environments or recursive shared captures.
