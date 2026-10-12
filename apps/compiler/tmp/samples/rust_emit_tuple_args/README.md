# Rust emit-expression tuple arguments

`rust.emit_expr`'s argument tuple gives one `$k` per element. An element that is itself a tuple is one argument,
written as a Rust tuple: leading (`((a, b), c)`: `$0` is `(v0, v1)`), trailing (`(c, (a, b))`: the text names `$0`
and `$1` only, so `$1` is the rest of the spine, `(v0, v1)`), and whole (`(a, b)` with only `$0` named). Before,
the tuple was flattened and `$0` spliced its first field only. C computes the same value without macros; both exit
with 82.
