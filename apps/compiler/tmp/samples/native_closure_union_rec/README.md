# Closures inside recursive unions (C forward declarations)

A recursive union whose case holds a closure that returns the union (`stream`: `Cons : u64 * (() -> stream)`) or takes it
(`visitor`: `Visit : i32 * (visitor -> i32)`), with a closure whose body calls the join point that creates it.
The C backend failed twice here: `unknown type name 'Fun0'` (a `Fun` struct prints its range and domain types first,
and the union struct among them names the `Fun` before its typedef), and `implicit declaration of function 'build0'`
(the closure's body calls `build` while `build`'s definition is still being printed, so it lands after the closure).
CodegenC now emits a forward `typedef` for a `Fun` named while its struct is printing, and a prototype for a function
called while its definition is printing (the same fix replaces the hand-written prototypes the scc shims carry).
All four backends exit with 70 (55 from the stream, 15 from the visitor).
