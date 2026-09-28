#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_patterns, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn method0(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: bool = v0 < 0i32;
    if v2 {
        0i32
    } else {
        let mut v3: bool = 255i32 < v0;
        if v3 {
            0i32
        } else {
            let mut v4: bool = v1 < 0i32;
            if v4 {
                0i32
            } else {
                let mut v5: bool = 0i32 < v1;
                if v5 {
                    0i32
                } else {
                    1i32
                }
            }
        }
    }
}
fn method1(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: i32 = v0 ^ v1 ;
    v2
}
fn method2(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: i32 = if v1 == 0 { ((v0 as u32).wrapping_mul(435)) as i32 } else { v0 };
    v2
}
fn method3(mut v0: i32, mut v1: i32) -> i32 {
    let mut v2: i32 = (((((v0 as u32 as u64) * 435) + ((v1 as u32 as u64) * 256) + (((v1 as u32 as u64) * 435) >> 32)) & 0xffff_ffff) as u32) as i32;
    v2
}
fn closure0() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method0(v0, v1)
    })
}
fn closure1() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method1(v0, v1)
    })
}
fn closure2() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method2(v0, v1)
    })
}
fn closure3() -> Rc<dyn Fn(i32, i32) -> i32> {
    Rc::new(move |mut v0: i32, mut v1: i32| -> i32 {
        method3(v0, v1)
    })
}
pub fn eoie_state_receipt_byte_valid(v0: i32, v1: i32) -> i32 {
    closure0()(v0, v1)
}
pub fn eoie_state_receipt_mix_low(v0: i32, v1: i32) -> i32 {
    closure1()(v0, v1)
}
pub fn eoie_state_receipt_low_step(v0: i32, v1: i32) -> i32 {
    closure2()(v0, v1)
}
pub fn eoie_state_receipt_high_step(v0: i32, v1: i32) -> i32 {
    closure3()(v0, v1)
}
