#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn closure0(mut v0: Vec<i32>) -> Rc<dyn Fn() -> i32> {
    Rc::new(move || -> i32 {
        let mut v1: i32 = v0.clone().into_iter().count() as i32;
        v1
    })
}
fn method0(mut v0: i32, mut v1: i32, mut v2: Vec<i32>) -> i32 {
    loop {
        let mut v3: bool = v0 < 3i32;
        if v3 {
            let mut v4: i32 = v0 + 1i32;
            let mut v5: i32 = v2.clone().into_iter().count() as i32;
            let mut v6: i32 = v1 + v5;
            (v0, v1, v2) = (v4, v6, v2.clone());
            continue;
        } else {
            return v1;
        }
    }
}
fn spiral_main() -> i32 {
    let mut v0: i32 = 3i32;
    let mut v1: Vec<i32> = vec![1i32, 2, v0];
    let mut v2: i32 = v1.clone().into_iter().sum::<i32>();
    let mut v3: Option<Vec<i32>> = Some(vec![v0]);
    let mut v4: i32 = match v3.clone() { Some(x) => x.len() as i32, None => 0 };
    let mut v5: i32 = v3.map(|x| x[0]).unwrap_or(0);
    let mut v6: i32 = std::convert::identity(v1.clone()).len() as i32;
    let mut v8: i32 = v1.clone().into_iter().count() as i32;
    let mut v9: Vec<i32> = Vec::new();
    v9.push(4);
    let mut v10: i32 = v9.len() as i32;
    let mut v11: Rc<dyn Fn() -> i32> = closure0(v1.clone());
    let mut v12: i32 = v11();
    let mut v13: i32 = v11();
    let mut v14: i32 = v12 + v13;
    let mut v15: i32 = 0i32;
    let mut v16: i32 = 0i32;
    let mut v17: i32 = method0(v15, v16, v1.clone());
    let mut v18: i32 = v2 + v4;
    let mut v19: i32 = v18 + v5;
    let mut v20: i32 = v19 + v6;
    let mut v21: i32 = v20 + v8;
    let mut v22: i32 = v21 + v10;
    let mut v23: i32 = v22 + v14;
    let mut v24: i32 = v23 + v17;
    let mut v25: i32 = v1.len() as i32;
    let mut v26: i32 = v24 + v25;
    v26
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
