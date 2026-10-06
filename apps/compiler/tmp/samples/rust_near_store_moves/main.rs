#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
struct SpiralNearVec<T>(std::vec::Vec<T>);
mod near_sdk { pub mod store { pub struct LookupMap<K, V>(pub std::collections::BTreeMap<K, V>); } }
fn method0(mut v0: u32) -> (u32, SpiralNearVec<u8>, near_sdk::store::LookupMap<u32, u8>) {
    let mut v1: SpiralNearVec<u8> = SpiralNearVec(vec![1u8, 2, 3]);
    let mut v2: near_sdk::store::LookupMap<u32, u8> = near_sdk::store::LookupMap(std::collections::BTreeMap::from([(1u32, 4u8)]));
    (v0, v1, v2)
}
fn method1(mut v0: u32, mut v1: SpiralNearVec<u8>, mut v2: near_sdk::store::LookupMap<u32, u8>) -> i32 {
    let mut v3: i32 = (v0 as i32) + (v1.0.len() as i32) + (*v2.0.get(&1u32).unwrap() as i32);
    v3
}
fn spiral_main() -> i32 {
    let mut v0: u32 = 7u32;
    let (mut v1, mut v2, mut v3): (u32, SpiralNearVec<u8>, near_sdk::store::LookupMap<u32, u8>) = method0(v0);
    method1(v1, v2, v3)
}
#[cfg(not(target_arch = "wasm32"))]
fn main() {
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 101 });
}
#[cfg(target_arch = "wasm32")]
fn main() {
    spiral_main();
}
