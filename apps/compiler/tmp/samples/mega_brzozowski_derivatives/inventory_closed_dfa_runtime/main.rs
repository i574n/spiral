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
    UH0_SymbolListNil,
    UH0_SymbolListCons(US0, Rc<UH0>),
}
#[derive(Clone)]
enum UH2 {
    UH2_InputEmpty,
    UH2_InputCons(US0, Rc<UH2>),
}
#[derive(Clone)]
enum UH1 {
    UH1_InputListNil,
    UH1_InputListCons(Rc<UH2>, Rc<UH1>),
}
#[derive(Clone)]
enum US1 {
    US1_TriA,
    US1_TriB,
    US1_TriC,
}
#[derive(Clone)]
enum UH3 {
    UH3_SymbolListNil,
    UH3_SymbolListCons(US1, Rc<UH3>),
}
#[derive(Clone)]
enum UH5 {
    UH5_InputEmpty,
    UH5_InputCons(US1, Rc<UH5>),
}
#[derive(Clone)]
enum UH4 {
    UH4_InputListNil,
    UH4_InputListCons(Rc<UH5>, Rc<UH4>),
}
#[derive(Clone)]
enum US2 {
    US2_ModelA,
    US2_ModelB,
    US2_ModelC,
}
#[derive(Clone)]
enum UH6 {
    UH6_InputEmpty,
    UH6_InputCons(US2, Rc<UH6>),
}
#[derive(Clone)]
enum UH7 {
    UH7_RegexEmpty,
    UH7_RegexEpsilon,
    UH7_RegexChar(US0),
    UH7_RegexAlt(Rc<UH7>, Rc<UH7>),
    UH7_RegexCat(Rc<UH7>, Rc<UH7>),
    UH7_RegexStar(Rc<UH7>),
}
#[derive(Clone)]
enum US3 {
    US3_InventoryDfaAccepted,
    US3_InventoryDfaRejected,
    US3_InventoryDfaInputOutsideInventory,
}
#[derive(Clone)]
enum US4 {
    US4_SymbolLess,
    US4_SymbolSame,
    US4_SymbolGreater,
}
#[derive(Clone)]
enum US5 {
    US5_Nullable,
    US5_NonNullable,
}
#[derive(Clone)]
enum UH8 {
    UH8_RegexEmpty,
    UH8_RegexEpsilon,
    UH8_RegexChar(US1),
    UH8_RegexAlt(Rc<UH8>, Rc<UH8>),
    UH8_RegexCat(Rc<UH8>, Rc<UH8>),
    UH8_RegexStar(Rc<UH8>),
}
#[path = "main_part1.rs"] mod part1;
pub(crate) use part1::*;
fn main() { #[cfg(target_arch = "wasm32")] { spiral_main(); return; }
    let main = std::thread::Builder::new().stack_size(1 << 30).spawn(spiral_main).unwrap();
    std::process::exit(match main.join() { Ok(code) => code, Err(_) => 1 });
}
