# Rust static closure chains raise the recursion limit

A closure that captures nothing is a `thread_local!` static in the Rust output. A chain of them (closure k's body calls
closure k+1: a lazy stream of constants, like lib.dice's roller cycles) nests std's generic thread-local initializer
instances per link in rustc's monomorphization walk, which stops at the crate's `recursion_limit` (128 by default):
the dice contract's native wasm32 build failed with "reached the recursion limit while instantiating ...
closure43::CLOSURE::__init" on its 64-link chain until it added `#![recursion_limit = "512"]` itself. The backend now
emits the attribute when a program has more than 16 static closures (the smallest power of two from 256 that is at
least 4 per static closure + 64; never when a global already sets the limit): 80 here, so 512. The x86_64 build of this
program alone stays under the default limit; the attribute is what the larger dice program needs. C runs the same
program (its backend forward-declares the closure type a recursive union names, see native_closure_union_rec); both
exit with 40.
