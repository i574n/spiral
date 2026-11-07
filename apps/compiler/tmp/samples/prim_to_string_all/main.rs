#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
fn spiral_main() -> i32 {
    let v0: i8 = -128i8;
    let v1: i16 = -32768i16;
    let v2: i32 = -5i32;
    let v3: i64 = -1234567890123i64;
    let v4: u8 = 255u8;
    let v5: u16 = 65535u16;
    let v6: u32 = 4294967295u32;
    let v7: u64 = 18446744073709551615u64;
    let v8: bool = true;
    let v9: bool = false;
    let v10: u8 = b'a';
    let v11: Rc<str> = Rc::<str>::from((v0).to_string());
    let v12: bool = &*v11 == "-128";
    let v13: i32 = if v12 {
        0i32
    } else {
        1i32
    };
    let v14: Rc<str> = Rc::<str>::from((v1).to_string());
    let v15: bool = &*v14 == "-32768";
    let v16: i32 = if v15 {
        0i32
    } else {
        1i32
    };
    let v17: i32 = v13.wrapping_add(v16);
    let v18: Rc<str> = Rc::<str>::from((v2).to_string());
    let v19: bool = &*v18 == "-5";
    let v20: i32 = if v19 {
        0i32
    } else {
        1i32
    };
    let v21: i32 = v17.wrapping_add(v20);
    let v22: Rc<str> = Rc::<str>::from((v3).to_string());
    let v23: bool = &*v22 == "-1234567890123";
    let v24: i32 = if v23 {
        0i32
    } else {
        1i32
    };
    let v25: i32 = v21.wrapping_add(v24);
    let v26: Rc<str> = Rc::<str>::from((v4).to_string());
    let v27: bool = &*v26 == "255";
    let v28: i32 = if v27 {
        0i32
    } else {
        1i32
    };
    let v29: i32 = v25.wrapping_add(v28);
    let v30: Rc<str> = Rc::<str>::from((v5).to_string());
    let v31: bool = &*v30 == "65535";
    let v32: i32 = if v31 {
        0i32
    } else {
        1i32
    };
    let v33: i32 = v29.wrapping_add(v32);
    let v34: Rc<str> = Rc::<str>::from((v6).to_string());
    let v35: bool = &*v34 == "4294967295";
    let v36: i32 = if v35 {
        0i32
    } else {
        1i32
    };
    let v37: i32 = v33.wrapping_add(v36);
    let v38: Rc<str> = Rc::<str>::from((v7).to_string());
    let v39: bool = &*v38 == "18446744073709551615";
    let v40: i32 = if v39 {
        0i32
    } else {
        1i32
    };
    let v41: i32 = v37.wrapping_add(v40);
    let v42: Rc<str> = Rc::<str>::from((v8).to_string());
    let v43: bool = &*v42 == "true";
    let v44: i32 = if v43 {
        0i32
    } else {
        1i32
    };
    let v45: i32 = v41.wrapping_add(v44);
    let v46: Rc<str> = Rc::<str>::from((v9).to_string());
    let v47: bool = &*v46 == "false";
    let v48: i32 = if v47 {
        0i32
    } else {
        1i32
    };
    let v49: i32 = v45.wrapping_add(v48);
    let v50: Rc<str> = Rc::<str>::from(((v10) as char).to_string());
    let v51: bool = &*v50 == "a";
    let v52: i32 = if v51 {
        0i32
    } else {
        1i32
    };
    let v53: i32 = v49.wrapping_add(v52);
    let v54: Rc<str> = Rc::<str>::from((7u8).to_string());
    let v55: bool = &*v54 == "7";
    let v56: i32 = if v55 {
        0i32
    } else {
        1i32
    };
    let v57: i32 = v53.wrapping_add(v56);
    let v58: Rc<str> = Rc::<str>::from((false).to_string());
    let v59: bool = &*v58 == "false";
    let v60: i32 = if v59 {
        0i32
    } else {
        1i32
    };
    let v61: i32 = v57.wrapping_add(v60);
    let v62: Rc<str> = Rc::<str>::from(((b'z') as char).to_string());
    let v63: bool = &*v62 == "z";
    let v64: i32 = if v63 {
        0i32
    } else {
        1i32
    };
    let v65: i32 = v61.wrapping_add(v64);
    let v66: Rc<str> = Rc::<str>::from((-3i64).to_string());
    let v67: bool = &*v66 == "-3";
    let v68: i32 = if v67 {
        0i32
    } else {
        1i32
    };
    let v69: i32 = v65.wrapping_add(v68);
    v69
}
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
