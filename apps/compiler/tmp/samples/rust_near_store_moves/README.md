# Rust NEAR store collections move

NEAR's persistent collections are handles on contract storage and don't implement Clone: `near_sdk::store::*`
(`Vector`, `LookupMap`, `IterableSet`, ...; either spelling, the Rust path or lib/spiral's Fable alias
`near_sdk_store_..`) and lib/spiral's native `near.vector` (`SpiralNearVec`, a plain `Vec` wrapper off wasm32). A
contract's state record holding one is returned from a join point and passed to another; both used to splice
`v1.clone()` (rustc E0599), so a contract's `new` had to hand its state back through a `&mut Option<State>` macro. They
now move. The program defines a local `near_sdk::store::LookupMap` stand-in so it builds without near-sdk. C computes
the same value without macros; both exit with 14.
