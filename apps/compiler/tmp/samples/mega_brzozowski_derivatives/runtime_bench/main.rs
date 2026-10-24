#![allow(unused_mut, unused_variables, unused_imports, unused_parens, unused_braces, unused_assignments, dead_code, non_snake_case, non_camel_case_types, unreachable_code, while_true)]
use std::cell::RefCell;
use std::rc::Rc;
#[derive(Clone)]
enum US0 {
    US0_BitZero,
    US0_BitOne,
}
#[derive(Clone)]
enum UH0 {
    UH0_RegexEmpty,
    UH0_RegexEpsilon,
    UH0_RegexChar(US0),
    UH0_RegexAlt(Rc<UH0>, Rc<UH0>),
    UH0_RegexCat(Rc<UH0>, Rc<UH0>),
    UH0_RegexStar(Rc<UH0>),
}
#[derive(Clone)]
enum UH1 {
    UH1_InputEmpty,
    UH1_InputCons(US0, Rc<UH1>),
}
#[derive(Clone)]
enum US1 {
    US1_SymbolLess,
    US1_SymbolSame,
    US1_SymbolGreater,
}
#[derive(Clone)]
enum US2 {
    US2_Nullable,
    US2_NonNullable,
}
#[derive(Clone)]
enum UH2 {
    UH2_RegexListNil,
    UH2_RegexListCons(Rc<UH0>, Rc<UH2>),
}
#[path = "main_part1.rs"] mod part1;
pub(crate) use part1::*;
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
