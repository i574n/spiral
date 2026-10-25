#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn lcg_0(mut v0: u64, mut v1: u64, mut v2: i32, mut v3: u64) -> u64 {
    loop {
        let v4: bool = v2 == 0i32;
        if v4 {
            return v3;
        } else {
            let v5: i32 = v2.wrapping_sub(1i32);
            let v6: u64 = v3.wrapping_mul(v0);
            let v7: u64 = v6.wrapping_add(v1);
            (v0, v1, v2, v3) = (v0, v1, v5, v7);
            continue;
        }
    }
}
fn spiral_main() -> i32 {
    let v0: u64 = 42u64;
    let v1: u64 = 6364136223846793005u64;
    let v2: u64 = 1442695040888963407u64;
    let v3: i32 = 1000i32;
    let v4: u64 = lcg_0(v1, v2, v3, v0);
    print!("lcg {}\n", v4);
    let v5: i64 = 9223372036854775807i64;
    let v6: i64 = -9223372036854775807i64;
    let v7: u64 = 18446744073709551615u64;
    let v8: i64 = v6.wrapping_sub(1i64);
    let v9: u64 = v7.wrapping_add(2u64);
    print!("max {} min {} wrap {}\n", v5, v8, v9);
    let v10: i64 = -9007199254740993i64;
    let v11: i64 = 7i64;
    let v12: i64 = v10.wrapping_div(v11);
    let v13: i64 = v10.wrapping_rem(v11);
    print!("div {} mod {}\n", v12, v13);
    let v14: i64 = v10.wrapping_shr((3i32) as u32);
    let v15: u64 = v4.wrapping_shr((60i32) as u32);
    print!("shl {} shr {} ushr {}\n", 4611686018427387904i64, v14, v15);
    let v16: u64 = v4 & 18446744069414584320u64;
    let v17: i64 = v10 | 255i64;
    let v18: u64 = v4 ^ v1;
    print!("and {} or {} xor {}\n", v16, v17, v18);
    let v19: f64 = 1E+18f64;
    let v20: i64 = (v19 as i64);
    let v21: u32 = (v4 as u32);
    let v22: f64 = (v10 as f64);
    let v23: bool = v22 < 0.0f64;
    let v24: i32 = if v23 {
        1i32
    } else {
        0i32
    };
    print!("conv {} {} {}\n", v20, v21, v24);
    let v25: bool = v4 > v1;
    if v25 {
        1i32
    } else {
        0i32
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
