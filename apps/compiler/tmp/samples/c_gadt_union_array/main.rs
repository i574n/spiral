#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_Living(i32, i32),
}
impl Default for US0 {
    fn default() -> Self {
        US0::US0_Living(<i32>::default(), <i32>::default())
    }
}
fn spiral_main() -> i32 {
    let v0: i32 = 3i32;
    let v1: Rc<RefCell<Vec<US0>>> = Rc::new(RefCell::new(vec![<US0>::default(); v0 as usize]));
    0i32
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
