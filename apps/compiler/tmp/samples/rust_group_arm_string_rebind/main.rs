#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn string_slice(value: &str, from: i64, to: i64) -> Rc<str> {
    let bytes = value.as_bytes();
    let length = bytes.len() as i64;
    if from < 0 || from > length || to < from - 1 || to >= length { std::process::abort(); }
    if to < from { return { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) }; }
    if (bytes[from as usize] & 0xC0) == 0x80 || (to + 1 < length && (bytes[(to + 1) as usize] & 0xC0) == 0x80) { std::process::exit(3); }
    let slice = &bytes[from as usize..(to + 1) as usize];
    match std::str::from_utf8(slice) { Ok(text) => Rc::<str>::from(text), Err(error) => Rc::<str>::from(std::str::from_utf8(&slice[..error.valid_up_to()]).unwrap_or("")) }
}
#[derive(Clone)]
enum US0 {
    US0_Hit(i32),
    US0_Miss,
}
#[derive(Clone)]
enum US1 {
    US1_Good(i32),
    US1_Bad(Rc<str>),
}
#[derive(Clone)]
enum UH0 {
    UH0_End,
    UH0_Word(Rc<str>, Rc<UH0>),
}
fn closure1(mut v0: i32) -> Rc<dyn Fn(Rc<str>) -> US0> {
    Rc::new(move |mut v1: Rc<str>| -> US0 {
        let v2: bool = &*v1 == "frames";
        if v2 {
            let v3: i32 = v0.wrapping_add(1i32);
            US0::US0_Hit(v3)
        } else {
            US0::US0_Miss
        }
    })
}
fn closure0() -> Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> US0>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> US0>> = Rc::new(move |mut v0: i32| -> Rc<dyn Fn(Rc<str>) -> US0> {
        closure1(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn closure4(mut v0: i32, mut v1: Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1> {
    Rc::new(move |mut v2: Rc<str>| -> US1 {
        let v3: bool = &*v1 == "spi";
        if v3 {
            let v4: i32 = v0.wrapping_add(10i32);
            US1::US1_Good(v4)
        } else {
            let v6: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("executor is fake, got "); } LIT.with(|lit| lit.clone()) }, v2));
            US1::US1_Bad(v6)
        }
    })
}
fn closure3(mut v0: i32) -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>> {
    Rc::new(move |mut v1: Rc<str>| -> Rc<dyn Fn(Rc<str>) -> US1> {
        closure4(v0, v1)
    })
}
fn closure2() -> Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>>> {
    thread_local!{ static CLOSURE: Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>>> = Rc::new(move |mut v0: i32| -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>> {
        closure3(v0)
    }); } CLOSURE.with(|closure| closure.clone())
}
fn starts_4(mut v0: Rc<str>, mut v1: Rc<str>) -> bool {
    let v2: i32 = (v1.clone().len() as i32);
    let v3: bool = 1i32 < v2;
    if v3 {
        let v4: Rc<str> = string_slice(&v1, 0i32 as i64, 1i32 as i64);
        let mut v5: bool = &*v4 == &*v0;
        v5
    } else {
        false
    }
}
enum Group0 {
    M0(Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> US0>>, Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>>>, i32, Rc<UH0>),
    M1(Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> US0>>, Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>>>, i32, Rc<str>, Rc<UH0>),
    M2(Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> US0>>, Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>>>, i32, Rc<str>, Rc<UH0>),
    M3(Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> US0>>, Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>>>, US1, Rc<UH0>),
}
fn group_0(mut st: Group0) -> US1 {
    loop {
        match st {
            Group0::M0(mut v0, mut v1, mut v2, mut v3) => {
                match Rc::unwrap_or_clone(v3) {
                    UH0::UH0_End => {
                        return US1::US1_Good(v2);
                    }
                    UH0::UH0_Word(v5, v6) => {
                        let mut v5: Rc<str> = v5;
                        let v6: Rc<UH0> = v6;
                        let mut v7: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("--"); } LIT.with(|lit| lit.clone()) };
                        let v8: bool = starts_4(v7, v5.clone());
                        let v13: Rc<str> = if v8 {
                            let v9: i32 = (v5.clone().len() as i32);
                            let v10: i32 = v9.wrapping_sub(1i32);
                            let v11: Rc<str> = string_slice(&v5.clone(), 2i32 as i64, v10 as i64);
                            v11
                        } else {
                            let v12: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            v12
                        };
                        let v14: bool = &*v13 == "";
                        if v14 {
                            let mut v15: Rc<str> = Rc::<str>::from(format!("{}{}", { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("unexpected "); } LIT.with(|lit| lit.clone()) }, v5));
                            return US1::US1_Bad(v15);
                        } else {
                            st = Group0::M1(v0, v1, v2, v5, v6);
                            continue;
                        }
                    }
                }
            }
            Group0::M1(mut v0, mut v1, mut v2, mut v3, mut v4) => {
                let mut v5: Rc<dyn Fn(Rc<str>) -> US0> = v0(v2);
                let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("--"); } LIT.with(|lit| lit.clone()) };
                let mut v7: bool = starts_4(v6, v3.clone());
                let v12: Rc<str> = if v7 {
                    let v8: i32 = (v3.clone().len() as i32);
                    let v9: i32 = v8.wrapping_sub(1i32);
                    let v10: Rc<str> = string_slice(&v3.clone(), 2i32 as i64, v9 as i64);
                    v10
                } else {
                    let v11: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                    v11
                };
                let v13: US0 = v5(v12);
                match v13 {
                    US0::US0_Hit(v14) => {
                        let v14: i32 = v14;
                        st = Group0::M0(v0, v1, v2, v4);
                        continue;
                    }
                    US0::US0_Miss => {
                        st = Group0::M2(v0, v1, v2, v3, v4);
                        continue;
                    }
                }
            }
            Group0::M2(mut v0, mut v1, mut v2, mut v3, mut v4) => {
                match Rc::unwrap_or_clone(v4) {
                    UH0::UH0_End => {
                        let v18: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("--"); } LIT.with(|lit| lit.clone()) };
                        let v19: bool = starts_4(v18, v3.clone());
                        let v24: Rc<str> = if v19 {
                            let v20: i32 = (v3.clone().len() as i32);
                            let v21: i32 = v20.wrapping_sub(1i32);
                            let v22: Rc<str> = string_slice(&v3, 2i32 as i64, v21 as i64);
                            v22
                        } else {
                            let v23: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            v23
                        };
                        let v25: Rc<str> = Rc::<str>::from(format!("{}{}", v24, { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(" needs a value"); } LIT.with(|lit| lit.clone()) }));
                        return US1::US1_Bad(v25);
                    }
                    UH0::UH0_Word(v5, v6) => {
                        let mut v5: Rc<str> = v5;
                        let v6: Rc<UH0> = v6;
                        let mut v7: Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>> = v1(v2);
                        let v8: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("--"); } LIT.with(|lit| lit.clone()) };
                        let v9: bool = starts_4(v8, v3.clone());
                        let v14: Rc<str> = if v9 {
                            let v10: i32 = (v3.clone().len() as i32);
                            let v11: i32 = v10.wrapping_sub(1i32);
                            let v12: Rc<str> = string_slice(&v3, 2i32 as i64, v11 as i64);
                            v12
                        } else {
                            let v13: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from(""); } LIT.with(|lit| lit.clone()) };
                            v13
                        };
                        let mut v15: Rc<dyn Fn(Rc<str>) -> US1> = v7(v14);
                        let v16: US1 = v15(v5);
                        st = Group0::M3(v0, v1, v16, v6);
                        continue;
                    }
                }
            }
            Group0::M3(mut v0, mut v1, mut v2, mut v3) => {
                match v2 {
                    US1::US1_Bad(v6) => {
                        let v6: Rc<str> = v6;
                        return US1::US1_Bad(v6);
                    }
                    US1::US1_Good(v4) => {
                        let v4: i32 = v4;
                        st = Group0::M0(v0, v1, v4, v3);
                        continue;
                    }
                }
            }
        }
    }
}
fn continued_3(mut v0: Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> US0>>, mut v1: Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>>>, mut v2: US1, mut v3: Rc<UH0>) -> US1 {
    group_0(Group0::M3(v0, v1, v2, v3))
}
fn valued_then_2(mut v0: Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> US0>>, mut v1: Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>>>, mut v2: i32, mut v3: Rc<str>, mut v4: Rc<UH0>) -> US1 {
    group_0(Group0::M2(v0, v1, v2, v3, v4))
}
fn arg_parsed_1(mut v0: Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> US0>>, mut v1: Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>>>, mut v2: i32, mut v3: Rc<str>, mut v4: Rc<UH0>) -> US1 {
    group_0(Group0::M1(v0, v1, v2, v3, v4))
}
fn flags_parsed_0(mut v0: Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> US0>>, mut v1: Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>>>, mut v2: i32, mut v3: Rc<UH0>) -> US1 {
    group_0(Group0::M0(v0, v1, v2, v3))
}
fn spiral_main() -> i32 {
    let mut v0: Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> US0>> = closure0();
    let mut v1: Rc<dyn Fn(i32) -> Rc<dyn Fn(Rc<str>) -> Rc<dyn Fn(Rc<str>) -> US1>>> = closure2();
    let v2: i32 = 0i32;
    let v3: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("--spi"); } LIT.with(|lit| lit.clone()) };
    let v4: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("a.spi"); } LIT.with(|lit| lit.clone()) };
    let mut v5: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("--executor"); } LIT.with(|lit| lit.clone()) };
    let v6: Rc<str> = { thread_local!{ static LIT: Rc<str> = Rc::<str>::from("gpu"); } LIT.with(|lit| lit.clone()) };
    let mut v7: Rc<UH0> = { thread_local!{ static CASE: Rc<UH0> = Rc::new(UH0::UH0_End); } CASE.with(|case| case.clone()) };
    let v8: Rc<UH0> = Rc::new(UH0::UH0_Word(v6, v7));
    let v9: Rc<UH0> = Rc::new(UH0::UH0_Word(v5, v8));
    let v10: Rc<UH0> = Rc::new(UH0::UH0_Word(v4, v9));
    let v11: Rc<UH0> = Rc::new(UH0::UH0_Word(v3, v10));
    let v12: US1 = flags_parsed_0(v0, v1, v2, v11);
    match v12 {
        US1::US1_Bad(v13) => {
            let v13: Rc<str> = v13;
            let v14: i32 = (v13.len() as i32);
            let mut v15: bool = v14 == 25i32;
            if v15 {
                0i32
            } else {
                1i32
            }
        }
        US1::US1_Good(v17) => {
            let v17: i32 = v17;
            2i32
        }
    }
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
