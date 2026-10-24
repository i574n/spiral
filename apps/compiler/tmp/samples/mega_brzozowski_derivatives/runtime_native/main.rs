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
    UH0_InputEmpty,
    UH0_InputCons(US0, Rc<UH0>),
}
#[derive(Clone)]
enum US1 {
    US1_TriA,
    US1_TriB,
    US1_TriC,
}
#[derive(Clone)]
enum UH1 {
    UH1_InputEmpty,
    UH1_InputCons(US1, Rc<UH1>),
}
#[derive(Clone)]
enum UH2 {
    UH2_RegexEmpty,
    UH2_RegexEpsilon,
    UH2_RegexChar(US0),
    UH2_RegexAlt(Rc<UH2>, Rc<UH2>),
    UH2_RegexCat(Rc<UH2>, Rc<UH2>),
    UH2_RegexStar(Rc<UH2>),
}
#[derive(Clone)]
enum US2 {
    US2_SymbolLess,
    US2_SymbolSame,
    US2_SymbolGreater,
}
#[derive(Clone)]
enum US3 {
    US3_Nullable,
    US3_NonNullable,
}
#[derive(Clone)]
enum UH3 {
    UH3_RegexEmpty,
    UH3_RegexEpsilon,
    UH3_RegexChar(US1),
    UH3_RegexAlt(Rc<UH3>, Rc<UH3>),
    UH3_RegexCat(Rc<UH3>, Rc<UH3>),
    UH3_RegexStar(Rc<UH3>),
}
#[derive(Clone)]
enum US4 {
    US4_BitMatcherRaw(Rc<UH2>, Rc<UH0>),
}
#[derive(Clone)]
enum US5 {
    US5_BitMatcherDecided(Rc<UH2>, Rc<UH0>, bool),
}
#[path = "main_part1.rs"] mod part1;
pub(crate) use part1::*;
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
