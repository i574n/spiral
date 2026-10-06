#![allow(dead_code)]
#![allow(non_camel_case_types)]
#![allow(non_snake_case)]
#![allow(non_upper_case_globals)]
#![allow(unreachable_code)]
#![allow(unused_attributes)]
#![allow(unused_imports)]
#![allow(unused_macros)]
#![allow(unused_parens)]
#![allow(unused_variables)]
#![allow(unused_assignments)]
use fable_library_rust::NativeArray_::array_from;
use fable_library_rust::String_::fromString;
mod module_fb49c4a9 {
    pub mod Spiral_wasm {
        use super::*;
        use fable_library_rust::DateTime_::DateTime;
        use fable_library_rust::Exception_::try_catch;
        use fable_library_rust::List_::ofArray;
        use fable_library_rust::List_::toArray;
        use fable_library_rust::Native_::Func0;
        use fable_library_rust::Native_::Func1;
        use fable_library_rust::Native_::LrcPtr;
        use fable_library_rust::Native_::MutCell;
        use fable_library_rust::Native_::OnceInit;
        use fable_library_rust::NativeArray_::Array;
        use fable_library_rust::NativeArray_::get_Count;
        use fable_library_rust::NativeArray_::new_array;
        use fable_library_rust::Option_::defaultValue;
        use fable_library_rust::Option_::map;
        use fable_library_rust::String_::append;
        use fable_library_rust::String_::contains;
        use fable_library_rust::String_::getCharAt;
        use fable_library_rust::String_::getSlice;
        use fable_library_rust::String_::length;
        use fable_library_rust::String_::printfn;
        use fable_library_rust::String_::sprintf;
        use fable_library_rust::String_::string;
        use fable_library_rust::String_::toLower;
        use fable_library_rust::System::Exception;
        use fable_library_rust::TimeSpan_::TimeSpan;
        pub mod TraceState {
            use super::*;
            pub fn trace_state() -> LrcPtr<
                MutCell<
                    Option<(
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    )>,
                >,
            > {
                static trace_state: OnceInit<
                    LrcPtr<
                        MutCell<
                            Option<(
                                LrcPtr<Spiral_wasm::Mut1>,
                                LrcPtr<Spiral_wasm::Mut2>,
                                LrcPtr<Spiral_wasm::Mut3>,
                                LrcPtr<Spiral_wasm::Mut4>,
                                LrcPtr<Spiral_wasm::Mut5>,
                                Option<i64>,
                            )>,
                        >,
                    >,
                > = OnceInit::new();
                trace_state
                    .get_or_init(|| {
                        LrcPtr::new(MutCell::new(
                            None::<(
                                LrcPtr<Spiral_wasm::Mut1>,
                                LrcPtr<Spiral_wasm::Mut2>,
                                LrcPtr<Spiral_wasm::Mut3>,
                                LrcPtr<Spiral_wasm::Mut4>,
                                LrcPtr<Spiral_wasm::Mut5>,
                                Option<i64>,
                            )>,
                        ))
                    })
                    .clone()
            }
        }
        #[derive(Clone, Debug)]
        pub enum US0 {
            US0_0(usize),
            US0_1(LrcPtr<Exception>),
        }
        impl core::fmt::Display for US0 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US1 {
            US1_0(usize),
            US1_1,
        }
        impl core::fmt::Display for US1 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US2 {
            US2_0(std::string::String),
            US2_1,
        }
        impl core::fmt::Display for US2 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US5 {
            US5_0,
            US5_1,
            US5_2,
            US5_3,
            US5_4,
        }
        impl core::fmt::Display for US5 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US4 {
            US4_0(Spiral_wasm::US5),
            US4_1,
        }
        impl core::fmt::Display for US4 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US3 {
            US3_0(Spiral_wasm::US4),
            US3_1,
        }
        impl core::fmt::Display for US3 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub struct Mut0 {
            pub l0: MutCell<i32>,
            pub l1: MutCell<Spiral_wasm::US4>,
        }
        impl core::fmt::Display for Mut0 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub struct Mut1 {
            pub l0: MutCell<i64>,
        }
        impl core::fmt::Display for Mut1 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub struct Mut2 {
            pub l0: MutCell<Func1<string, ()>>,
        }
        impl core::fmt::Display for Mut2 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub struct Mut3 {
            pub l0: MutCell<bool>,
        }
        impl core::fmt::Display for Mut3 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub struct Mut4 {
            pub l0: MutCell<string>,
        }
        impl core::fmt::Display for Mut4 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub struct Mut5 {
            pub l0: MutCell<Spiral_wasm::US5>,
        }
        impl core::fmt::Display for Mut5 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US6 {
            US6_0(i64),
            US6_1,
        }
        impl core::fmt::Display for US6 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US7 {
            US7_0,
            US7_1,
        }
        impl core::fmt::Display for US7 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US8 {
            US8_0(Spiral_wasm::US7),
            US8_1,
        }
        impl core::fmt::Display for US8 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US9 {
            US9_0,
            US9_1,
            US9_2,
            US9_3,
            US9_4,
            US9_5(Spiral_wasm::US8),
            US9_6,
            US9_7,
        }
        impl core::fmt::Display for US9 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US10 {
            US10_0(string),
            US10_1,
        }
        impl core::fmt::Display for US10 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US11 {
            US11_0(i64),
            US11_1(LrcPtr<Exception>),
        }
        impl core::fmt::Display for US11 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US12 {
            US12_0(i64),
            US12_1,
        }
        impl core::fmt::Display for US12 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US13 {
            US13_0(i64),
            US13_1(LrcPtr<Exception>),
        }
        impl core::fmt::Display for US13 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US14 {
            US14_0(
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ),
            US14_1,
        }
        impl core::fmt::Display for US14 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub struct Mut6 {
            pub l0: MutCell<i32>,
        }
        impl core::fmt::Display for Mut6 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US15 {
            US15_0(u8, Spiral_wasm::US10),
            US15_1(u8, Spiral_wasm::US10),
        }
        impl core::fmt::Display for US15 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US16 {
            US16_0(i32),
            US16_1(LrcPtr<Exception>),
        }
        impl core::fmt::Display for US16 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US17 {
            US17_0(i32),
            US17_1,
        }
        impl core::fmt::Display for US17 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US18 {
            US18_0(Spiral_wasm::US10),
            US18_1(std::string::String),
        }
        impl core::fmt::Display for US18 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US19 {
            US19_0(u8),
            US19_1(std::string::String),
        }
        impl core::fmt::Display for US19 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        pub fn closure1(unitVar: (), unitVar_1: ()) -> usize {
            0_i32 as usize
        }
        pub fn closure2(unitVar: (), v0: usize) -> Spiral_wasm::US0 {
            Spiral_wasm::US0::US0_0(v0)
        }
        pub fn closure3(unitVar: (), v0: Func0<LrcPtr<Exception>>) -> LrcPtr<Exception> {
            v0()
        }
        pub fn closure4(unitVar: (), v0: LrcPtr<Exception>) -> Spiral_wasm::US0 {
            Spiral_wasm::US0::US0_1(v0)
        }
        pub fn method1() -> Spiral_wasm::US0 {
            try_catch(
                || Spiral_wasm::closure2((), Spiral_wasm::closure1((), ())),
                |ex: LrcPtr<Exception>| {
                    Spiral_wasm::closure4(
                        (),
                        Spiral_wasm::closure3(
                            (),
                            Func0::new({
                                let ex = ex.clone();
                                move || ex.clone()
                            }),
                        ),
                    )
                },
            )
        }
        pub fn closure5(unitVar: (), unitVar_1: ()) -> usize {
            1_i32 as usize
        }
        pub fn method2() -> Spiral_wasm::US0 {
            try_catch(
                || Spiral_wasm::closure2((), Spiral_wasm::closure5((), ())),
                |ex: LrcPtr<Exception>| {
                    Spiral_wasm::closure4(
                        (),
                        Spiral_wasm::closure3(
                            (),
                            Func0::new({
                                let ex = ex.clone();
                                move || ex.clone()
                            }),
                        ),
                    )
                },
            )
        }
        pub fn method0() -> clap::Command {
            let v21: string = string("r#\"command\"#");
            let v22: &'static str = r#"command"#;
            let v57: clap::Command = clap::Command::new(v22);
            let v59: clap::Command = clap::Command::args_override_self(v57, true);
            let v76: Spiral_wasm::US0 = Spiral_wasm::method1();
            let v122: Spiral_wasm::US1 = match &v76 {
                Spiral_wasm::US0::US0_0(v76_0_0) => Spiral_wasm::US1::US1_0(v76_0_0.clone()),
                _ => Spiral_wasm::US1::US1_1,
            };
            let v179: usize = match &v122 {
                Spiral_wasm::US1::US1_0(v122_0_0) => match &v122 {
                    Spiral_wasm::US1::US1_0(x) => x.clone(),
                    _ => unreachable!(),
                },
                _ => panic!("{}", string("Option does not have a value."),),
            };
            let v189: Spiral_wasm::US0 = Spiral_wasm::method2();
            let v206: Spiral_wasm::US1 = match &v189 {
                Spiral_wasm::US0::US0_0(v189_0_0) => Spiral_wasm::US1::US1_0(v189_0_0.clone()),
                _ => Spiral_wasm::US1::US1_1,
            };
            let v241: usize = match &v206 {
                Spiral_wasm::US1::US1_0(v206_0_0) => match &v206 {
                    Spiral_wasm::US1::US1_0(x) => x.clone(),
                    _ => unreachable!(),
                },
                _ => panic!("{}", string("Option does not have a value."),),
            };
            let v242: Spiral_wasm::US0 = Spiral_wasm::method1();
            let v248: Spiral_wasm::US1 = match &v242 {
                Spiral_wasm::US0::US0_0(v242_0_0) => Spiral_wasm::US1::US1_0(v242_0_0.clone()),
                _ => Spiral_wasm::US1::US1_1,
            };
            let v280: clap::builder::ValueRange = if (v241)
                == (match &v248 {
                    Spiral_wasm::US1::US1_0(v248_0_0) => match &v248 {
                        Spiral_wasm::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    },
                    _ => panic!("{}", string("Option does not have a value."),),
                }) {
                clap::builder::ValueRange::new(v179..)
            } else {
                let v278: string = string("clap::builder::ValueRange::new($0..=$1)");
                clap::builder::ValueRange::new(v179..=v241)
            };
            let v285: string = string("r#\"exception\"#");
            let v286: &'static str = r#"exception"#;
            let v296: clap::Arg = clap::Arg::new(v286);
            let v298: clap::Arg = v296.short('e' as char);
            let v299: string = string("r#\"exception\"#");
            let v300: &'static str = r#"exception"#;
            let v302: clap::Arg = v298.long(v300);
            let v304: clap::Arg = v302.num_args(v280);
            let v306: clap::Arg = v304.require_equals(true);
            let v328: string = string("r#\"\"#");
            let v329: &str = r#""#;
            let v368: clap::Arg = v306.default_missing_value(v329);
            let v380: clap::Command = clap::Command::arg(v59, v368);
            let v385: string = string("r#\"trace_level\"#");
            let v386: &'static str = r#"trace_level"#;
            let v396: clap::Arg = clap::Arg::new(v386);
            let v398: clap::Arg = v396.short('t' as char);
            let v399: string = string("r#\"trace_level\"#");
            let v400: &'static str = r#"trace_level"#;
            let v402: clap::Arg = v398.long(v400);
            let v409: string = toLower(string("Critical"));
            let v435: string = toLower(string("Warning"));
            let v449: string = toLower(string("Info"));
            let v463: string = toLower(string("Debug"));
            let v624: Array<string> = toArray(ofArray(new_array(&[
                toLower(string("Verbose")),
                v463,
                v449,
                v435,
                v409,
            ])));
            let v662: Vec<string> = v624.to_vec();
            let v673: bool = true;
            let _vec_map: Vec<_> = v662
                .into_iter()
                .map(|x| {
                    //;
                    let v675: string = x;
                    let v916: &str = &*v675;
                    let v1083: std::string::String = String::from(v916);
                    let v1100: Box<std::string::String> = Box::new(v1083);
                    let v1102: &'static mut std::string::String = Box::leak(v1100);
                    let v1104: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v1102);
                    let v1106: bool = true;
                    v1104
                })
                .collect::<Vec<_>>();
            let v1108: Vec<clap::builder::PossibleValue> = _vec_map;
            let v1110: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v1108),
            );
            let v1112: clap::Arg = v402.value_parser(v1110);
            let v1114: clap::Command = clap::Command::arg(v380, v1112);
            let v1119: string = string("r#\"wasm\"#");
            let v1120: &'static str = r#"wasm"#;
            let v1130: clap::Arg = clap::Arg::new(v1120);
            let v1132: clap::Arg = v1130.short('w' as char);
            let v1133: string = string("r#\"wasm\"#");
            let v1134: &'static str = r#"wasm"#;
            let v1136: clap::Arg = v1132.long(v1134);
            let v1138: clap::Arg = v1136.required(true);
            clap::Command::arg(v1114, v1138)
        }
        pub fn method3() -> string {
            string("trace_level")
        }
        pub fn closure6(unitVar: (), v0: std::string::String) -> Spiral_wasm::US2 {
            Spiral_wasm::US2::US2_0(v0)
        }
        pub fn method4() -> Func1<std::string::String, Spiral_wasm::US2> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure6((), v))
        }
        pub fn method5(v0: i32, v1: LrcPtr<Spiral_wasm::Mut0>) -> bool {
            (v1.l0.get().clone()) < (v0)
        }
        pub fn method9(v0: string) -> string {
            v0
        }
        pub fn method10() -> string {
            string("")
        }
        pub fn method13() -> string {
            string("")
        }
        pub fn method14(v0: LrcPtr<Spiral_wasm::Mut4>, v1: string) {
            let v3: string = append((v0.l0.get().clone()), (v1));
            v0.l0.set(v3);
            ()
        }
        pub fn method12(v0: Spiral_wasm::US9) -> string {
            let v6_1: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method14(v6_1.clone(), sprintf!("{:?}", v0));
            v6_1.l0.get().clone()
        }
        pub fn method15(v0: string) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method14(v2.clone(), v0);
            v2.l0.get().clone()
        }
        pub fn method11(v0: string) -> string {
            panic!(
                "{}",
                append(
                    (append(
                        (append(
                            string("env.get_environment_variable / target: "),
                            (Spiral_wasm::method12(Spiral_wasm::US9::US9_5(
                                Spiral_wasm::US8::US8_0(Spiral_wasm::US7::US7_0)
                            )))
                        )),
                        string(" / var: ")
                    )),
                    (Spiral_wasm::method15(v0))
                ),
            )
        }
        pub fn method16(v0: string) -> string {
            panic!(
                "{}",
                append(
                    (append(
                        (append(
                            string("env.get_environment_variable / target: "),
                            (Spiral_wasm::method12(Spiral_wasm::US9::US9_5(
                                Spiral_wasm::US8::US8_0(Spiral_wasm::US7::US7_1)
                            )))
                        )),
                        string(" / var: ")
                    )),
                    (Spiral_wasm::method15(v0))
                ),
            )
        }
        pub fn closure8(unitVar: (), v0: string) -> Spiral_wasm::US10 {
            Spiral_wasm::US10::US10_0(v0)
        }
        pub fn method17() -> Func1<string, Spiral_wasm::US10> {
            Func1::new(move |v: string| Spiral_wasm::closure8((), v))
        }
        pub fn method8(v0: string) -> string {
            let v3: string = Spiral_wasm::method9(v0);
            let v5: Result<std::string::String, std::env::VarError> = std::env::var(&*v3);
            let v7: bool = true;
            let _result_map_ = v5.map(|x| {
                //;
                let v9: std::string::String = x;
                let v11: string = fable_library_rust::String_::fromString(v9);
                let v13: bool = true;
                v11
            });
            let v15: Result<string, std::env::VarError> = _result_map_;
            let v16: string = Spiral_wasm::method10();
            v15.unwrap_or(v16)
        }
        pub fn closure9(v0: f64, unitVar: ()) -> i64 {
            v0 as i64
        }
        pub fn closure10(unitVar: (), v0: i64) -> Spiral_wasm::US11 {
            Spiral_wasm::US11::US11_0(v0)
        }
        pub fn closure11(unitVar: (), v0: LrcPtr<Exception>) -> Spiral_wasm::US11 {
            Spiral_wasm::US11::US11_1(v0)
        }
        pub fn method18(v0: f64) -> Spiral_wasm::US11 {
            try_catch(
                || Spiral_wasm::closure10((), Spiral_wasm::closure9(v0, ())),
                |ex: LrcPtr<Exception>| {
                    Spiral_wasm::closure11(
                        (),
                        Spiral_wasm::closure3(
                            (),
                            Func0::new({
                                let ex = ex.clone();
                                move || ex.clone()
                            }),
                        ),
                    )
                },
            )
        }
        pub fn closure12(v0: i64, unitVar: ()) -> i64 {
            v0
        }
        pub fn closure13(unitVar: (), v0: i64) -> Spiral_wasm::US13 {
            Spiral_wasm::US13::US13_0(v0)
        }
        pub fn closure14(unitVar: (), v0: LrcPtr<Exception>) -> Spiral_wasm::US13 {
            Spiral_wasm::US13::US13_1(v0)
        }
        pub fn method19(v0: i64) -> Spiral_wasm::US13 {
            try_catch(
                || Spiral_wasm::closure13((), Spiral_wasm::closure12(v0, ())),
                |ex: LrcPtr<Exception>| {
                    Spiral_wasm::closure14(
                        (),
                        Spiral_wasm::closure3(
                            (),
                            Func0::new({
                                let ex = ex.clone();
                                move || ex.clone()
                            }),
                        ),
                    )
                },
            )
        }
        pub fn method7() -> (Spiral_wasm::US4, Spiral_wasm::US6) {
            let v1: string = Spiral_wasm::method8(string("TRACE_LEVEL"));
            let v4: string = toLower(string("Critical"));
            let v7: string = toLower(string("Warning"));
            let v10: string = toLower(string("Info"));
            let v13: string = toLower(string("Debug"));
            let v125: Array<(string, Spiral_wasm::US5)> = toArray(ofArray(new_array(&[
                (string("Verbose"), Spiral_wasm::US5::US5_0),
                (string("Debug"), Spiral_wasm::US5::US5_1),
                (string("Info"), Spiral_wasm::US5::US5_2),
                (string("Warning"), Spiral_wasm::US5::US5_3),
                (string("Critical"), Spiral_wasm::US5::US5_4),
                (toLower(string("Verbose")), Spiral_wasm::US5::US5_0),
                (v13, Spiral_wasm::US5::US5_1),
                (v10, Spiral_wasm::US5::US5_2),
                (v7, Spiral_wasm::US5::US5_3),
                (v4, Spiral_wasm::US5::US5_4),
            ])));
            let v126: i32 = get_Count(v125.clone());
            let v128: LrcPtr<Spiral_wasm::Mut0> = LrcPtr::new(Spiral_wasm::Mut0 {
                l0: MutCell::new(0_i32),
                l1: MutCell::new(Spiral_wasm::US4::US4_1),
            });
            while Spiral_wasm::method5(v126, v128.clone()) {
                let v130: i32 = v128.l0.get().clone();
                let v133: i32 = ((v130.wrapping_neg()) + (v126)) - 1_i32;
                let v134: Spiral_wasm::US4 = v128.l1.get().clone();
                let patternInput: (string, Spiral_wasm::US5) = v125[v133].clone();
                let v143: Spiral_wasm::US4 = match &v134 {
                    Spiral_wasm::US4::US4_0(v134_0_0) => v134.clone(),
                    _ => {
                        if (patternInput.0.clone()) == (v1.clone()) {
                            Spiral_wasm::US4::US4_0(patternInput.1.clone())
                        } else {
                            Spiral_wasm::US4::US4_1
                        }
                    }
                };
                let v144: i32 = (v130) + 1_i32;
                v128.l0.set(v144);
                v128.l1.set(v143);
                ()
            }
            (
                v128.l1.get().clone(),
                if (Spiral_wasm::method8(string("AUTOMATION"))) != string("True") {
                    Spiral_wasm::US6::US6_1
                } else {
                    let v180: Spiral_wasm::US11 = Spiral_wasm::method18(
                        10000000.0_f64
                            * ((({
                                let _arg: TimeSpan = (DateTime::now()) - (DateTime::minValue());
                                _arg.ticks()
                            }) / 10000000_i64) as f64),
                    );
                    let v186: Spiral_wasm::US12 = match &v180 {
                        Spiral_wasm::US11::US11_0(v180_0_0) => {
                            Spiral_wasm::US12::US12_0(v180_0_0.clone())
                        }
                        _ => Spiral_wasm::US12::US12_1,
                    };
                    let v191: Spiral_wasm::US13 = Spiral_wasm::method19(match &v186 {
                        Spiral_wasm::US12::US12_0(v186_0_0) => match &v186 {
                            Spiral_wasm::US12::US12_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    });
                    let v197: Spiral_wasm::US6 = match &v191 {
                        Spiral_wasm::US13::US13_0(v191_0_0) => {
                            Spiral_wasm::US6::US6_0(v191_0_0.clone())
                        }
                        _ => Spiral_wasm::US6::US6_1,
                    };
                    Spiral_wasm::US6::US6_0(match &v197 {
                        Spiral_wasm::US6::US6_0(v197_0_0) => match &v197 {
                            Spiral_wasm::US6::US6_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    })
                },
            )
        }
        pub fn closure15(unitVar: (), v0: string) {
            ();
        }
        pub fn method6(
            v0: Spiral_wasm::US5,
        ) -> (
            LrcPtr<Spiral_wasm::Mut1>,
            LrcPtr<Spiral_wasm::Mut2>,
            LrcPtr<Spiral_wasm::Mut3>,
            LrcPtr<Spiral_wasm::Mut4>,
            LrcPtr<Spiral_wasm::Mut5>,
            Option<i64>,
        ) {
            let _run_target_args__v1: (Spiral_wasm::US4, Spiral_wasm::US6) =
                (Spiral_wasm::US4::US4_1, Spiral_wasm::US6::US6_1);
            let v68: Spiral_wasm::US6 = _run_target_args__v1.1.clone();
            let v67: Spiral_wasm::US4 = _run_target_args__v1.0.clone();
            (
                LrcPtr::new(Spiral_wasm::Mut1 {
                    l0: MutCell::new(1_i64),
                }),
                LrcPtr::new(Spiral_wasm::Mut2 {
                    l0: MutCell::new(Func1::new(move |v: string| Spiral_wasm::closure15((), v))),
                }),
                LrcPtr::new(Spiral_wasm::Mut3 {
                    l0: MutCell::new(true),
                }),
                LrcPtr::new(Spiral_wasm::Mut4 {
                    l0: MutCell::new(string("")),
                }),
                LrcPtr::new(Spiral_wasm::Mut5 {
                    l0: MutCell::new(match &v67 {
                        Spiral_wasm::US4::US4_0(v67_0_0) => match &v67 {
                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => v0.clone(),
                    }),
                }),
                match &v68 {
                    Spiral_wasm::US6::US6_0(v68_0_0) => Some(match &v68 {
                        Spiral_wasm::US6::US6_0(x) => x.clone(),
                        _ => unreachable!(),
                    }),
                    _ => None::<i64>,
                },
            )
        }
        pub fn closure7(v0: Spiral_wasm::US5, unitVar: ()) {
            if Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .is_none()
            {
                let patternInput: (
                    LrcPtr<Spiral_wasm::Mut1>,
                    LrcPtr<Spiral_wasm::Mut2>,
                    LrcPtr<Spiral_wasm::Mut3>,
                    LrcPtr<Spiral_wasm::Mut4>,
                    LrcPtr<Spiral_wasm::Mut5>,
                    Option<i64>,
                ) = Spiral_wasm::method6(v0);
                Spiral_wasm::TraceState::trace_state().set(Some((
                    patternInput.0.clone(),
                    patternInput.1.clone(),
                    patternInput.2.clone(),
                    patternInput.3.clone(),
                    patternInput.4.clone(),
                    patternInput.5.clone(),
                )));
                ()
            };
        }
        pub fn closure17(unitVar: (), unitVar_1: ()) {
            if Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .is_none()
            {
                let patternInput: (
                    LrcPtr<Spiral_wasm::Mut1>,
                    LrcPtr<Spiral_wasm::Mut2>,
                    LrcPtr<Spiral_wasm::Mut3>,
                    LrcPtr<Spiral_wasm::Mut4>,
                    LrcPtr<Spiral_wasm::Mut5>,
                    Option<i64>,
                ) = Spiral_wasm::method6(Spiral_wasm::US5::US5_0);
                Spiral_wasm::TraceState::trace_state().set(Some((
                    patternInput.0.clone(),
                    patternInput.1.clone(),
                    patternInput.2.clone(),
                    patternInput.3.clone(),
                    patternInput.4.clone(),
                    patternInput.5.clone(),
                )));
                ()
            };
        }
        pub fn closure18(unitVar: (), v0: i64) -> Spiral_wasm::US6 {
            Spiral_wasm::US6::US6_0(v0)
        }
        pub fn method21() -> Func1<i64, Spiral_wasm::US6> {
            Func1::new(move |v: i64| Spiral_wasm::closure18((), v))
        }
        pub fn method22() -> string {
            string("hh:mm:ss")
        }
        pub fn method23() -> string {
            string("HH:mm:ss")
        }
        pub fn method20(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
        ) -> string {
            let v10: Spiral_wasm::US6 =
                defaultValue(Spiral_wasm::US6::US6_1, map(Spiral_wasm::method21(), v5));
            let v82: DateTime = match &v10 {
                Spiral_wasm::US6::US6_0(v10_0_0) => {
                    let v41: Spiral_wasm::US11 = Spiral_wasm::method18(
                        10000000.0_f64
                            * ((({
                                let _arg: TimeSpan = (DateTime::now()) - (DateTime::minValue());
                                _arg.ticks()
                            }) / 10000000_i64) as f64),
                    );
                    let v47: Spiral_wasm::US12 = match &v41 {
                        Spiral_wasm::US11::US11_0(v41_0_0) => {
                            Spiral_wasm::US12::US12_0(v41_0_0.clone())
                        }
                        _ => Spiral_wasm::US12::US12_1,
                    };
                    let v52: Spiral_wasm::US13 = Spiral_wasm::method19(match &v47 {
                        Spiral_wasm::US12::US12_0(v47_0_0) => match &v47 {
                            Spiral_wasm::US12::US12_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    });
                    let v58: Spiral_wasm::US6 = match &v52 {
                        Spiral_wasm::US13::US13_0(v52_0_0) => {
                            Spiral_wasm::US6::US6_0(v52_0_0.clone())
                        }
                        _ => Spiral_wasm::US6::US6_1,
                    };
                    let v64: TimeSpan = TimeSpan::new_ticks(
                        (match &v58 {
                            Spiral_wasm::US6::US6_0(v58_0_0) => match &v58 {
                                Spiral_wasm::US6::US6_0(x) => x.clone(),
                                _ => unreachable!(),
                            },
                            _ => panic!("{}", string("Option does not have a value."),),
                        }) - (match &v10 {
                            Spiral_wasm::US6::US6_0(x) => x.clone(),
                            _ => unreachable!(),
                        }),
                    );
                    DateTime::new_ymdhms_milli(
                        1_i32,
                        1_i32,
                        1_i32,
                        v64.hours(),
                        v64.minutes(),
                        v64.seconds(),
                        v64.milliseconds(),
                    )
                }
                _ => DateTime::now(),
            };
            let v83: string = Spiral_wasm::method22();
            let provider: string = if (v83.clone()) == string("") {
                string("M-d-y hh:mm:ss tt")
            } else {
                v83
            };
            v82.toString(provider)
        }
        pub fn method25(v0: char) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method14(v2.clone(), sprintf!("{}", v0));
            v2.l0.get().clone()
        }
        pub fn method24() -> string {
            let v2: &str = inline_colorization::color_bright_black;
            let v5: std::string::String = String::from(v2);
            let v51: string = append(
                (fable_library_rust::String_::fromString(v5)),
                (Spiral_wasm::method25(getCharAt(toLower(string("Verbose")), 0_i32))),
            );
            let v54: &str = inline_colorization::color_reset;
            let v57: std::string::String = String::from(v54);
            append((v51), (fable_library_rust::String_::fromString(v57)))
        }
        pub fn method27(v0: i64) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method14(v2.clone(), sprintf!("{}", v0));
            v2.l0.get().clone()
        }
        pub fn method29(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("{ "));
            v0.l0.set(v3);
            ()
        }
        pub fn method30(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("args"));
            v0.l0.set(v3);
            ()
        }
        pub fn method31(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string(" = "));
            v0.l0.set(v3);
            ()
        }
        pub fn method32(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string(" }"));
            v0.l0.set(v3);
            ()
        }
        pub fn method28(v0: Array<string>) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v2.clone());
            Spiral_wasm::method30(v2.clone());
            Spiral_wasm::method31(v2.clone());
            Spiral_wasm::method14(v2.clone(), sprintf!("{:?}", v0));
            Spiral_wasm::method32(v2.clone());
            v2.l0.get().clone()
        }
        pub fn method34(v0: string, v1: i32, v2: i32) -> i32 {
            let v0: MutCell<string> = MutCell::new(v0.clone());
            let v1: MutCell<i32> = MutCell::new(v1);
            let v2: MutCell<i32> = MutCell::new(v2);
            '_method34: loop {
                break '_method34 (if (v2.get().clone()) >= (v1.get().clone()) {
                    v1.get().clone()
                } else {
                    let v4: char = getCharAt(v0.get().clone(), v2.get().clone());
                    if if (v4) == ' ' {
                        true
                    } else {
                        if (v4) == '\t' {
                            true
                        } else {
                            if (v4) == '\r' { true } else { (v4) == '\n' }
                        }
                    } {
                        let v0_temp: string = v0.get().clone();
                        let v1_temp: i32 = v1.get().clone();
                        let v2_temp: i32 = (v2.get().clone()) + 1_i32;
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        continue '_method34;
                    } else {
                        v2.get().clone()
                    }
                });
            }
        }
        pub fn method35(v0: string, v1: i32) -> i32 {
            let v0: MutCell<string> = MutCell::new(v0.clone());
            let v1: MutCell<i32> = MutCell::new(v1);
            '_method35: loop {
                break '_method35 (if (v1.get().clone()) <= 0_i32 {
                    -1_i32
                } else {
                    let v3: i32 = (v1.get().clone()) - 1_i32;
                    let v4: char = getCharAt(v0.get().clone(), v3);
                    if if (v4) == ' ' { true } else { (v4) == '/' } {
                        let v0_temp: string = v0.get().clone();
                        let v1_temp: i32 = v3;
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        continue '_method35;
                    } else {
                        v3
                    }
                });
            }
        }
        pub fn method33(v0: string) -> string {
            let v1: i32 = length(v0.clone());
            let v5: string = getSlice(
                v0.clone(),
                Some(Spiral_wasm::method34(v0, v1, 0_i32)),
                Some((v1) - 1_i32),
            );
            getSlice(
                v5.clone(),
                Some(0_i32),
                Some(Spiral_wasm::method35(v5.clone(), length(v5))),
            )
        }
        pub fn method26(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: Array<string>,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.main"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method28(v8)),
            ))
        }
        pub fn closure19(v0: LrcPtr<Spiral_wasm::Mut1>, unitVar: ()) {
            let v2: i64 = (v0.l0.get().clone()) + 1_i64;
            v0.l0.set(v2);
            ()
        }
        pub fn closure21(v0: string, unitVar: ()) {
            printfn!("{0}", v0);
        }
        pub fn closure20(unitVar: (), v0: string) {
            let v3: () = {
                Spiral_wasm::closure21(v0, ());
                ()
            };
            ()
        }
        pub fn method36(v0: i32, v1: LrcPtr<Spiral_wasm::Mut6>) -> bool {
            (v1.l0.get().clone()) < (v0)
        }
        pub fn closure16(v0: Array<string>, unitVar: ()) {
            fn v2() {
                Spiral_wasm::closure17((), ());
            }
            let v3: () = {
                v2();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v10: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v15: i32 = match &v10 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v102: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    10_i32 >= (v15)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v23: () = {
                        v2();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v29: Option<i64> = patternInput_1.5.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v25: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v24: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v32: string = Spiral_wasm::method26(
                        v24.clone(),
                        v25.clone(),
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        Spiral_wasm::method20(v24, v25, v26, v27, v28, v29),
                        Spiral_wasm::method24(),
                        v0,
                    );
                    let v34: () = {
                        v2();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v36: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v35: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v43: () = {
                        Spiral_wasm::closure19(v35.clone(), ());
                        ()
                    };
                    println!("{}", v32.clone());
                    (v36.l0.get().clone())(v32);
                    Spiral_wasm::US14::US14_0(
                        v35,
                        v36,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method37() -> string {
            string("exception")
        }
        pub fn method39(v0: string, v1: i32, v2: i32) -> i32 {
            let v0: MutCell<string> = MutCell::new(v0.clone());
            let v1: MutCell<i32> = MutCell::new(v1);
            let v2: MutCell<i32> = MutCell::new(v2);
            '_method39: loop {
                break '_method39 (if (v2.get().clone()) >= (v1.get().clone()) {
                    v1.get().clone()
                } else {
                    if (getCharAt(v0.get().clone(), v2.get().clone())) == '\\' {
                        let v0_temp: string = v0.get().clone();
                        let v1_temp: i32 = v1.get().clone();
                        let v2_temp: i32 = (v2.get().clone()) + 1_i32;
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        continue '_method39;
                    } else {
                        v2.get().clone()
                    }
                });
            }
        }
        pub fn method40(v0: string, v1: i32) -> i32 {
            let v0: MutCell<string> = MutCell::new(v0.clone());
            let v1: MutCell<i32> = MutCell::new(v1);
            '_method40: loop {
                break '_method40 (if (v1.get().clone()) <= 0_i32 {
                    -1_i32
                } else {
                    let v3: i32 = (v1.get().clone()) - 1_i32;
                    if (getCharAt(v0.get().clone(), v3)) == '\\' {
                        let v0_temp: string = v0.get().clone();
                        let v1_temp: i32 = v3;
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        continue '_method40;
                    } else {
                        v3
                    }
                });
            }
        }
        pub fn closure22(unitVar: (), v0: std::string::String) -> string {
            let v2: string = fable_library_rust::String_::fromString(v0);
            let v3: i32 = length(v2.clone());
            let v7: string = getSlice(
                v2.clone(),
                Some(Spiral_wasm::method39(v2, v3, 0_i32)),
                Some((v3) - 1_i32),
            );
            getSlice(
                v7.clone(),
                Some(0_i32),
                Some(Spiral_wasm::method40(v7.clone(), length(v7))),
            )
        }
        pub fn method38() -> Func1<std::string::String, string> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure22((), v))
        }
        pub fn method42() -> string {
            string("wasm")
        }
        pub fn method45(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("wasm_path"));
            v0.l0.set(v3);
            ()
        }
        pub fn method44(v0: string) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v2.clone());
            Spiral_wasm::method45(v2.clone());
            Spiral_wasm::method31(v2.clone());
            Spiral_wasm::method14(v2.clone(), v0);
            Spiral_wasm::method32(v2.clone());
            v2.l0.get().clone()
        }
        pub fn method43(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: string,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method44(v8)),
            ))
        }
        pub fn closure23(v0: string, unitVar: ()) {
            fn v2() {
                Spiral_wasm::closure17((), ());
            }
            let v3: () = {
                v2();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v10: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v15: i32 = match &v10 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v102: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    10_i32 >= (v15)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v23: () = {
                        v2();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v29: Option<i64> = patternInput_1.5.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v25: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v24: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v32: string = Spiral_wasm::method43(
                        v24.clone(),
                        v25.clone(),
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        Spiral_wasm::method20(v24, v25, v26, v27, v28, v29),
                        Spiral_wasm::method24(),
                        v0,
                    );
                    let v34: () = {
                        v2();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v36: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v35: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v43: () = {
                        Spiral_wasm::closure19(v35.clone(), ());
                        ()
                    };
                    println!("{}", v32.clone());
                    (v36.l0.get().clone())(v32);
                    Spiral_wasm::US14::US14_0(
                        v35,
                        v36,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method50(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("retry"));
            v0.l0.set(v3);
            ()
        }
        pub fn method51(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("; "));
            v0.l0.set(v3);
            ()
        }
        pub fn method52(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("worker"));
            v0.l0.set(v3);
            ()
        }
        pub fn method53(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("contract"));
            v0.l0.set(v3);
            ()
        }
        pub fn method49(
            v0: u8,
            v1: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v2: near_workspaces::Contract,
        ) -> string {
            let v4: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v4.clone());
            Spiral_wasm::method50(v4.clone());
            Spiral_wasm::method31(v4.clone());
            Spiral_wasm::method14(v4.clone(), sprintf!("{}", v0));
            Spiral_wasm::method51(v4.clone());
            Spiral_wasm::method52(v4.clone());
            Spiral_wasm::method31(v4.clone());
            {
                let v8: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method14(v4.clone(), fable_library_rust::String_::fromString(v8));
                Spiral_wasm::method51(v4.clone());
                Spiral_wasm::method53(v4.clone());
                Spiral_wasm::method31(v4.clone());
                {
                    let v24: std::string::String = format!("{:#?}", v2);
                    Spiral_wasm::method14(v4.clone(), fable_library_rust::String_::fromString(v24));
                    Spiral_wasm::method32(v4.clone());
                    v4.l0.get().clone()
                }
            }
        }
        pub fn method48(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: u8,
            v9: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v10: near_workspaces::Contract,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method49(v8, v9, v10)),
            ))
        }
        pub fn closure24(
            v0: u8,
            v1: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v2: near_workspaces::Contract,
            unitVar: (),
        ) {
            fn v4() {
                Spiral_wasm::closure17((), ());
            }
            let v5: () = {
                v4();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v12: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v17: i32 = match &v12 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v104: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    10_i32 >= (v17)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v25: () = {
                        v4();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v31: Option<i64> = patternInput_1.5.clone();
                    let v30: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v29: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v34: string = Spiral_wasm::method48(
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        v30.clone(),
                        v31.clone(),
                        Spiral_wasm::method20(v26, v27, v28, v29, v30, v31),
                        Spiral_wasm::method24(),
                        v0,
                        v1,
                        v2,
                    );
                    let v36: () = {
                        v4();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v38: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v37: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v45: () = {
                        Spiral_wasm::closure19(v37.clone(), ());
                        ()
                    };
                    println!("{}", v34.clone());
                    (v38.l0.get().clone())(v34);
                    Spiral_wasm::US14::US14_0(
                        v37,
                        v38,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method56(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("result"));
            v0.l0.set(v3);
            ()
        }
        pub fn method55(v0: u8, v1: near_workspaces::result::ExecutionFinalResult) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v3.clone());
            Spiral_wasm::method50(v3.clone());
            Spiral_wasm::method31(v3.clone());
            Spiral_wasm::method14(v3.clone(), sprintf!("{}", v0));
            Spiral_wasm::method51(v3.clone());
            Spiral_wasm::method56(v3.clone());
            Spiral_wasm::method31(v3.clone());
            {
                let v7: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method14(v3.clone(), fable_library_rust::String_::fromString(v7));
                Spiral_wasm::method32(v3.clone());
                v3.l0.get().clone()
            }
        }
        pub fn method54(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: u8,
            v9: near_workspaces::result::ExecutionFinalResult,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method55(v8, v9)),
            ))
        }
        pub fn closure25(v0: u8, v1: near_workspaces::result::ExecutionFinalResult, unitVar: ()) {
            fn v3() {
                Spiral_wasm::closure17((), ());
            }
            let v4: () = {
                v3();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v11: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v16: i32 = match &v11 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v103: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    10_i32 >= (v16)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v24: () = {
                        v3();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v30: Option<i64> = patternInput_1.5.clone();
                    let v29: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v25: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v33: string = Spiral_wasm::method54(
                        v25.clone(),
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        v30.clone(),
                        Spiral_wasm::method20(v25, v26, v27, v28, v29, v30),
                        Spiral_wasm::method24(),
                        v0,
                        v1,
                    );
                    let v35: () = {
                        v3();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v37: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v36: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v44: () = {
                        Spiral_wasm::closure19(v36.clone(), ());
                        ()
                    };
                    println!("{}", v33.clone());
                    (v37.l0.get().clone())(v33);
                    Spiral_wasm::US14::US14_0(
                        v36,
                        v37,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn closure27(v0: std::string::String, unitVar: ()) {
            printfn!("{0}", v0);
        }
        pub fn closure26(unitVar: (), v0: std::string::String) {
            let v5: () = {
                Spiral_wasm::closure27(v0, ());
                ()
            };
            ()
        }
        pub fn closure28(unitVar: (), unitVar_1: ()) {
            fn v1() {
                Spiral_wasm::closure17((), ());
            }
            let v2: () = {
                v1();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v9: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v14: i32 = match &v9 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v91: Spiral_wasm::US14 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                30_i32 >= (v14)
            }) == false
            {
                Spiral_wasm::US14::US14_1
            } else {
                let v22: () = {
                    v1();
                    ()
                };
                let patternInput_1: (
                    LrcPtr<Spiral_wasm::Mut1>,
                    LrcPtr<Spiral_wasm::Mut2>,
                    LrcPtr<Spiral_wasm::Mut3>,
                    LrcPtr<Spiral_wasm::Mut4>,
                    LrcPtr<Spiral_wasm::Mut5>,
                    Option<i64>,
                ) = Spiral_wasm::TraceState::trace_state()
                    .get()
                    .clone()
                    .unwrap();
                let v24: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                let v23: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                let v31: () = {
                    Spiral_wasm::closure19(v23.clone(), ());
                    ()
                };
                println!("{}", string(" "));
                (v24.l0.get().clone())(string(" "));
                Spiral_wasm::US14::US14_0(
                    v23,
                    v24,
                    patternInput_1.2.clone(),
                    patternInput_1.3.clone(),
                    patternInput_1.4.clone(),
                    patternInput_1.5.clone(),
                )
            };
            ()
        }
        pub fn method57() -> string {
            let v2: &str = inline_colorization::color_bright_green;
            let v5: std::string::String = String::from(v2);
            let v51: string = append(
                (fable_library_rust::String_::fromString(v5)),
                (Spiral_wasm::method25(getCharAt(toLower(string("Info")), 0_i32))),
            );
            let v54: &str = inline_colorization::color_reset;
            let v57: std::string::String = String::from(v54);
            append((v51), (fable_library_rust::String_::fromString(v57)))
        }
        pub fn method60(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("total_gas_burnt_usd"));
            v0.l0.set(v3);
            ()
        }
        pub fn method61(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("total_gas_burnt"));
            v0.l0.set(v3);
            ()
        }
        pub fn method59(v0: u8, v1: f64, v2: u64) -> string {
            let v4: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v4.clone());
            Spiral_wasm::method50(v4.clone());
            Spiral_wasm::method31(v4.clone());
            Spiral_wasm::method14(v4.clone(), sprintf!("{}", v0));
            Spiral_wasm::method51(v4.clone());
            Spiral_wasm::method60(v4.clone());
            Spiral_wasm::method31(v4.clone());
            Spiral_wasm::method14(v4.clone(), sprintf!("{:+.6}", v1));
            Spiral_wasm::method51(v4.clone());
            Spiral_wasm::method61(v4.clone());
            Spiral_wasm::method31(v4.clone());
            Spiral_wasm::method14(v4.clone(), sprintf!("{}", v2));
            Spiral_wasm::method32(v4.clone());
            v4.l0.get().clone()
        }
        pub fn method58(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: u8,
            v9: f64,
            v10: u64,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("near_workspaces.print_usd"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method59(v8, v9, v10)),
            ))
        }
        pub fn closure29(v0: u8, v1: u64, v2: f64, unitVar: ()) {
            fn v4() {
                Spiral_wasm::closure17((), ());
            }
            let v5: () = {
                v4();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v12: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v17: i32 = match &v12 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v104: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    30_i32 >= (v17)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v25: () = {
                        v4();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v31: Option<i64> = patternInput_1.5.clone();
                    let v30: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v29: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v34: string = Spiral_wasm::method58(
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        v30.clone(),
                        v31.clone(),
                        Spiral_wasm::method20(v26, v27, v28, v29, v30, v31),
                        Spiral_wasm::method57(),
                        v0,
                        v2,
                        v1,
                    );
                    let v36: () = {
                        v4();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v38: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v37: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v45: () = {
                        Spiral_wasm::closure19(v37.clone(), ());
                        ()
                    };
                    println!("{}", v34.clone());
                    (v38.l0.get().clone())(v34);
                    Spiral_wasm::US14::US14_0(
                        v37,
                        v38,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method64(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("is_success"));
            v0.l0.set(v3);
            ()
        }
        pub fn method65(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("gas_burnt_usd"));
            v0.l0.set(v3);
            ()
        }
        pub fn method66(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("tokens_burnt_usd"));
            v0.l0.set(v3);
            ()
        }
        pub fn method67(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("gas_burnt"));
            v0.l0.set(v3);
            ()
        }
        pub fn method68(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("tokens_burnt"));
            v0.l0.set(v3);
            ()
        }
        pub fn method63(v0: bool, v1: f64, v2: f64, v3: u64, v4: u128) -> string {
            let v6_1: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v6_1.clone());
            Spiral_wasm::method64(v6_1.clone());
            Spiral_wasm::method31(v6_1.clone());
            Spiral_wasm::method14(
                v6_1.clone(),
                if v0 { string("true") } else { string("false") },
            );
            Spiral_wasm::method51(v6_1.clone());
            Spiral_wasm::method65(v6_1.clone());
            Spiral_wasm::method31(v6_1.clone());
            Spiral_wasm::method14(v6_1.clone(), sprintf!("{:+.6}", v1));
            Spiral_wasm::method51(v6_1.clone());
            Spiral_wasm::method66(v6_1.clone());
            Spiral_wasm::method31(v6_1.clone());
            Spiral_wasm::method14(v6_1.clone(), sprintf!("{:+.6}", v2));
            Spiral_wasm::method51(v6_1.clone());
            Spiral_wasm::method67(v6_1.clone());
            Spiral_wasm::method31(v6_1.clone());
            Spiral_wasm::method14(v6_1.clone(), sprintf!("{}", v3));
            Spiral_wasm::method51(v6_1.clone());
            Spiral_wasm::method68(v6_1.clone());
            Spiral_wasm::method31(v6_1.clone());
            {
                let v15: std::string::String = format!("{:#?}", v4);
                Spiral_wasm::method14(v6_1.clone(), fable_library_rust::String_::fromString(v15));
                Spiral_wasm::method32(v6_1.clone());
                v6_1.l0.get().clone()
            }
        }
        pub fn method62(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: bool,
            v9: f64,
            v10: f64,
            v11: u64,
            v12: u128,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("near_workspaces.print_usd / outcome"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method63(v8, v9, v10, v11, v12)),
            ))
        }
        pub fn closure31(v0: bool, v1: u64, v2: f64, v3: u128, v4: f64, unitVar: ()) {
            fn v6_1() {
                Spiral_wasm::closure17((), ());
            }
            let v7: () = {
                v6_1();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v14: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v19: i32 = match &v14 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v106: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    30_i32 >= (v19)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v27: () = {
                        v6_1();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v33: Option<i64> = patternInput_1.5.clone();
                    let v32: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v31: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v30: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v29: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v36: string = Spiral_wasm::method62(
                        v28.clone(),
                        v29.clone(),
                        v30.clone(),
                        v31.clone(),
                        v32.clone(),
                        v33.clone(),
                        Spiral_wasm::method20(v28, v29, v30, v31, v32, v33),
                        Spiral_wasm::method57(),
                        v0,
                        v2,
                        v4,
                        v1,
                        v3,
                    );
                    let v38: () = {
                        v6_1();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v40: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v39: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v47: () = {
                        Spiral_wasm::closure19(v39.clone(), ());
                        ()
                    };
                    println!("{}", v36.clone());
                    (v40.l0.get().clone())(v36);
                    Spiral_wasm::US14::US14_0(
                        v39,
                        v40,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn closure30(unitVar: (), v0: near_workspaces::result::ExecutionOutcome) {
            let v2: bool = v0.clone().is_success();
            let v4: near_workspaces::types::Gas = v0.clone().gas_burnt;
            let v6_1: u64 = v4.as_gas();
            let v10: f64 = ((v6_1 as f64) / 10000000000000000.0_f64) * 6.68_f64;
            let v12: near_workspaces::types::NearToken = v0.tokens_burnt;
            let v14: u128 = v12.as_yoctonear();
            let v120: () = {
                Spiral_wasm::closure31(
                    v2,
                    v6_1,
                    v10,
                    v14.clone(),
                    ((v14 as f64) / 1E+24_f64) * 6.68_f64,
                    (),
                );
                ()
            };
            ()
        }
        pub fn method71(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("result2"));
            v0.l0.set(v3);
            ()
        }
        pub fn method70(
            v0: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
        ) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v2.clone());
            Spiral_wasm::method71(v2.clone());
            Spiral_wasm::method31(v2.clone());
            {
                let v5: std::string::String = format!("{:#?}", v0);
                Spiral_wasm::method14(v2.clone(), fable_library_rust::String_::fromString(v5));
                Spiral_wasm::method32(v2.clone());
                v2.l0.get().clone()
            }
        }
        pub fn method69(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method70(v8)),
            ))
        }
        pub fn closure32(
            v0: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
            unitVar: (),
        ) {
            fn v2() {
                Spiral_wasm::closure17((), ());
            }
            let v3: () = {
                v2();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v10: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v15: i32 = match &v10 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v102: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    10_i32 >= (v15)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v23: () = {
                        v2();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v29: Option<i64> = patternInput_1.5.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v25: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v24: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v32: string = Spiral_wasm::method69(
                        v24.clone(),
                        v25.clone(),
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        Spiral_wasm::method20(v24, v25, v26, v27, v28, v29),
                        Spiral_wasm::method24(),
                        v0,
                    );
                    let v34: () = {
                        v2();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v36: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v35: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v43: () = {
                        Spiral_wasm::closure19(v35.clone(), ());
                        ()
                    };
                    println!("{}", v32.clone());
                    (v36.l0.get().clone())(v32);
                    Spiral_wasm::US14::US14_0(
                        v35,
                        v36,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method72(
            v0: near_workspaces::result::ExecutionFinalResult,
        ) -> near_workspaces::result::ExecutionFinalResult {
            v0
        }
        pub fn closure33(v0: usize, unitVar: ()) -> i32 {
            v0 as i32
        }
        pub fn closure34(unitVar: (), v0: i32) -> Spiral_wasm::US16 {
            Spiral_wasm::US16::US16_0(v0)
        }
        pub fn closure35(unitVar: (), v0: LrcPtr<Exception>) -> Spiral_wasm::US16 {
            Spiral_wasm::US16::US16_1(v0)
        }
        pub fn method73(v0: usize) -> Spiral_wasm::US16 {
            try_catch(
                || Spiral_wasm::closure34((), Spiral_wasm::closure33(v0, ())),
                |ex: LrcPtr<Exception>| {
                    Spiral_wasm::closure35(
                        (),
                        Spiral_wasm::closure3(
                            (),
                            Func0::new({
                                let ex = ex.clone();
                                move || ex.clone()
                            }),
                        ),
                    )
                },
            )
        }
        pub fn method76(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("receipt_failures_len"));
            v0.l0.set(v3);
            ()
        }
        pub fn method77(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("receipt_failures"));
            v0.l0.set(v3);
            ()
        }
        pub fn method75(v0: i32, v1: Vec<&near_workspaces::result::ExecutionOutcome>) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v3.clone());
            Spiral_wasm::method76(v3.clone());
            Spiral_wasm::method31(v3.clone());
            Spiral_wasm::method14(v3.clone(), sprintf!("{}", v0));
            Spiral_wasm::method51(v3.clone());
            Spiral_wasm::method77(v3.clone());
            Spiral_wasm::method31(v3.clone());
            {
                let v7: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method14(v3.clone(), fable_library_rust::String_::fromString(v7));
                Spiral_wasm::method32(v3.clone());
                v3.l0.get().clone()
            }
        }
        pub fn method74(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: i32,
            v9: Vec<&near_workspaces::result::ExecutionOutcome>,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method75(v8, v9)),
            ))
        }
        pub fn closure36(
            v0: Vec<&near_workspaces::result::ExecutionOutcome>,
            v1: i32,
            unitVar: (),
        ) {
            fn v3() {
                Spiral_wasm::closure17((), ());
            }
            let v4: () = {
                v3();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v11: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v16: i32 = match &v11 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v103: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    10_i32 >= (v16)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v24: () = {
                        v3();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v30: Option<i64> = patternInput_1.5.clone();
                    let v29: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v25: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v33: string = Spiral_wasm::method74(
                        v25.clone(),
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        v30.clone(),
                        Spiral_wasm::method20(v25, v26, v27, v28, v29, v30),
                        Spiral_wasm::method24(),
                        v1,
                        v0,
                    );
                    let v35: () = {
                        v3();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v37: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v36: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v44: () = {
                        Spiral_wasm::closure19(v36.clone(), ());
                        ()
                    };
                    println!("{}", v33.clone());
                    (v37.l0.get().clone())(v33);
                    Spiral_wasm::US14::US14_0(
                        v36,
                        v37,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method78(
            v0: near_workspaces::result::ExecutionFinalResult,
        ) -> near_workspaces::result::ExecutionFinalResult {
            v0
        }
        pub fn method81(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("receipt_outcomes_len"));
            v0.l0.set(v3);
            ()
        }
        pub fn method82(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("receipt_outcomes"));
            v0.l0.set(v3);
            ()
        }
        pub fn method80(v0: i32, v1: Vec<near_workspaces::result::ExecutionOutcome>) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v3.clone());
            Spiral_wasm::method81(v3.clone());
            Spiral_wasm::method31(v3.clone());
            Spiral_wasm::method14(v3.clone(), sprintf!("{}", v0));
            Spiral_wasm::method51(v3.clone());
            Spiral_wasm::method82(v3.clone());
            Spiral_wasm::method31(v3.clone());
            {
                let v7: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method14(v3.clone(), fable_library_rust::String_::fromString(v7));
                Spiral_wasm::method32(v3.clone());
                v3.l0.get().clone()
            }
        }
        pub fn method79(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: i32,
            v9: Vec<near_workspaces::result::ExecutionOutcome>,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method80(v8, v9)),
            ))
        }
        pub fn closure37(v0: Vec<near_workspaces::result::ExecutionOutcome>, v1: i32, unitVar: ()) {
            fn v3() {
                Spiral_wasm::closure17((), ());
            }
            let v4: () = {
                v3();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v11: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v16: i32 = match &v11 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v103: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    10_i32 >= (v16)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v24: () = {
                        v3();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v30: Option<i64> = patternInput_1.5.clone();
                    let v29: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v25: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v33: string = Spiral_wasm::method79(
                        v25.clone(),
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        v30.clone(),
                        Spiral_wasm::method20(v25, v26, v27, v28, v29, v30),
                        Spiral_wasm::method24(),
                        v1,
                        v0,
                    );
                    let v35: () = {
                        v3();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v37: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v36: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v44: () = {
                        Spiral_wasm::closure19(v36.clone(), ());
                        ()
                    };
                    println!("{}", v33.clone());
                    (v37.l0.get().clone())(v33);
                    Spiral_wasm::US14::US14_0(
                        v36,
                        v37,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method85(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("json"));
            v0.l0.set(v3);
            ()
        }
        pub fn method84(v0: Result<std::string::String, near_workspaces::error::Error>) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v2.clone());
            Spiral_wasm::method85(v2.clone());
            Spiral_wasm::method31(v2.clone());
            {
                let v5: std::string::String = format!("{:#?}", v0);
                Spiral_wasm::method14(v2.clone(), fable_library_rust::String_::fromString(v5));
                Spiral_wasm::method32(v2.clone());
                v2.l0.get().clone()
            }
        }
        pub fn method83(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method84(v8)),
            ))
        }
        pub fn closure38(
            v0: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            fn v2() {
                Spiral_wasm::closure17((), ());
            }
            let v3: () = {
                v2();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v10: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v15: i32 = match &v10 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v102: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    10_i32 >= (v15)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v23: () = {
                        v2();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v29: Option<i64> = patternInput_1.5.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v25: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v24: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v32: string = Spiral_wasm::method83(
                        v24.clone(),
                        v25.clone(),
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        Spiral_wasm::method20(v24, v25, v26, v27, v28, v29),
                        Spiral_wasm::method24(),
                        v0,
                    );
                    let v34: () = {
                        v2();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v36: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v35: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v43: () = {
                        Spiral_wasm::closure19(v35.clone(), ());
                        ()
                    };
                    println!("{}", v32.clone());
                    (v36.l0.get().clone())(v32);
                    Spiral_wasm::US14::US14_0(
                        v35,
                        v36,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method88(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("borsh"));
            v0.l0.set(v3);
            ()
        }
        pub fn method87(v0: Result<std::string::String, near_workspaces::error::Error>) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v2.clone());
            Spiral_wasm::method88(v2.clone());
            Spiral_wasm::method31(v2.clone());
            {
                let v5: std::string::String = format!("{:#?}", v0);
                Spiral_wasm::method14(v2.clone(), fable_library_rust::String_::fromString(v5));
                Spiral_wasm::method32(v2.clone());
                v2.l0.get().clone()
            }
        }
        pub fn method86(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method87(v8)),
            ))
        }
        pub fn closure39(
            v0: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            fn v2() {
                Spiral_wasm::closure17((), ());
            }
            let v3: () = {
                v2();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v10: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v15: i32 = match &v10 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v102: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    10_i32 >= (v15)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v23: () = {
                        v2();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v29: Option<i64> = patternInput_1.5.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v25: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v24: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v32: string = Spiral_wasm::method86(
                        v24.clone(),
                        v25.clone(),
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        Spiral_wasm::method20(v24, v25, v26, v27, v28, v29),
                        Spiral_wasm::method24(),
                        v0,
                    );
                    let v34: () = {
                        v2();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v36: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v35: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v43: () = {
                        Spiral_wasm::closure19(v35.clone(), ());
                        ()
                    };
                    println!("{}", v32.clone());
                    (v36.l0.get().clone())(v32);
                    Spiral_wasm::US14::US14_0(
                        v35,
                        v36,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method89(
            v0: i32,
            v1: u8,
            v2: Vec<&near_workspaces::result::ExecutionOutcome>,
        ) -> string {
            let v4: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v4.clone());
            Spiral_wasm::method81(v4.clone());
            Spiral_wasm::method31(v4.clone());
            Spiral_wasm::method14(v4.clone(), sprintf!("{}", v0));
            Spiral_wasm::method51(v4.clone());
            Spiral_wasm::method50(v4.clone());
            Spiral_wasm::method31(v4.clone());
            Spiral_wasm::method14(v4.clone(), sprintf!("{}", v1));
            Spiral_wasm::method51(v4.clone());
            Spiral_wasm::method77(v4.clone());
            Spiral_wasm::method31(v4.clone());
            {
                let v9: std::string::String = format!("{:#?}", v2);
                Spiral_wasm::method14(v4.clone(), fable_library_rust::String_::fromString(v9));
                Spiral_wasm::method32(v4.clone());
                v4.l0.get().clone()
            }
        }
        pub fn method47(
            v0: Vec<u8>,
            v1: u8,
        ) -> std::pin::Pin<
            Box<dyn std::future::Future<Output = Result<Spiral_wasm::US10, anyhow::Error>>>,
        > {
            let v3: bool = true;
            let __future_init = Box::pin(
                /*;
                let v5: bool = */
                async move {
                    /*;
                    let v7: bool = */
                    ();
                    let v9: Result<
                        near_workspaces::Worker<near_workspaces::network::Sandbox>,
                        near_workspaces::error::Error,
                    > = near_workspaces::sandbox().await;
                    let v11: near_workspaces::Worker<near_workspaces::network::Sandbox> = v9?;
                    let v13: near_workspaces::Worker<near_workspaces::network::Sandbox> =
                        v11.clone();
                    let v15: std::pin::Pin<
                        Box<
                            dyn std::future::Future<
                                    Output = Result<
                                        near_workspaces::Contract,
                                        near_workspaces::error::Error,
                                    >,
                                >,
                        >,
                    > = Box::pin(v13.dev_deploy(&v0));
                    let v17: Result<near_workspaces::Contract, near_workspaces::error::Error> =
                        v15.await;
                    let v19: near_workspaces::Contract = v17?;
                    let v121: () = {
                        Spiral_wasm::closure24(v1, v11, v19.clone(), ());
                        ()
                    };
                    let v278: near_workspaces::operations::CallTransaction =
                        v19.call(&*string("state_main"));
                    let v284: near_workspaces::types::Gas =
                        near_workspaces::types::Gas::from_tgas(300);
                    let v296: near_workspaces::operations::CallTransaction = v278.gas(v284);
                    let v298: std::pin::Pin<
                        Box<
                            dyn std::future::Future<
                                    Output = Result<
                                        near_workspaces::result::ExecutionFinalResult,
                                        near_workspaces::error::Error,
                                    >,
                                >,
                        >,
                    > = Box::pin(v296.transact());
                    let v300: Result<
                        near_workspaces::result::ExecutionFinalResult,
                        near_workspaces::error::Error,
                    > = v298.await;
                    let v302: near_workspaces::result::ExecutionFinalResult = v300?;
                    let v404: () = {
                        Spiral_wasm::closure25(v1, v302.clone(), ());
                        ()
                    };
                    let v560: Vec<&str> = v302.logs();
                    let v562: bool = true;
                    let _vec_map: Vec<_> = v560
                        .into_iter()
                        .map(|x| {
                            //;
                            let v564: &str = x;
                            let v567: std::string::String = String::from(v564);
                            let v576: bool = true;
                            v567
                        })
                        .collect::<Vec<_>>();
                    let v578: Vec<std::string::String> = _vec_map;
                    let v581: bool = true;
                    v578.iter().for_each(|x| {
                        Func1::new(move |v: std::string::String| Spiral_wasm::closure26((), v))(
                            x.clone(),
                        );
                    }); //;
                    let v664: () = {
                        Spiral_wasm::closure28((), ());
                        ()
                    };
                    let v792: near_workspaces::types::Gas = v302.clone().total_gas_burnt;
                    let v794: u64 = v792.as_gas();
                    let v966: () = {
                        Spiral_wasm::closure29(
                            v1,
                            v794,
                            ((v794 as f64) / 10000000000000000.0_f64) * 6.68_f64,
                            (),
                        );
                        ()
                    };
                    let v1122: near_workspaces::result::ExecutionFinalResult = v302.clone();
                    let v1124: Vec<&near_workspaces::result::ExecutionOutcome> = v1122.outcomes();
                    let v1126 = v1124.into_iter();
                    let v1128 = v1126.cloned();
                    let v1131: bool = true;
                    v1128.for_each(|x| {
                        Func1::new(move |v_1: near_workspaces::result::ExecutionOutcome| {
                            Spiral_wasm::closure30((), v_1)
                        })(x)
                    });
                    let v1235: () = {
                        Spiral_wasm::closure32(v302.clone().into_result(), ());
                        ()
                    };
                    let v1390: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method72(v302.clone());
                    let v1392: Vec<&near_workspaces::result::ExecutionOutcome> =
                        v1390.receipt_failures();
                    let v1540: Spiral_wasm::US16 = Spiral_wasm::method73(v1392.clone().len());
                    let v1546: Spiral_wasm::US17 = match &v1540 {
                        Spiral_wasm::US16::US16_0(v1540_0_0) => {
                            Spiral_wasm::US17::US17_0(v1540_0_0.clone())
                        }
                        _ => Spiral_wasm::US17::US17_1,
                    };
                    let v1550: i32 = match &v1546 {
                        Spiral_wasm::US17::US17_0(v1546_0_0) => match &v1546 {
                            Spiral_wasm::US17::US17_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v1673: () = {
                        Spiral_wasm::closure36(v1392.clone(), v1550, ());
                        ()
                    };
                    let v1828: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method78(v302.clone());
                    let v1830: &[near_workspaces::result::ExecutionOutcome] =
                        v1828.receipt_outcomes();
                    let v1832: Vec<near_workspaces::result::ExecutionOutcome> = v1830.into();
                    let v1848: Spiral_wasm::US16 = Spiral_wasm::method73(v1832.clone().len());
                    let v1854: Spiral_wasm::US17 = match &v1848 {
                        Spiral_wasm::US16::US16_0(v1848_0_0) => {
                            Spiral_wasm::US17::US17_0(v1848_0_0.clone())
                        }
                        _ => Spiral_wasm::US17::US17_1,
                    };
                    let v1858: i32 = match &v1854 {
                        Spiral_wasm::US17::US17_0(v1854_0_0) => match &v1854 {
                            Spiral_wasm::US17::US17_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v1960: () = {
                        Spiral_wasm::closure37(v1832, v1858, ());
                        ()
                    };
                    let v2220: () = {
                        Spiral_wasm::closure38(v302.clone().json(), ());
                        ()
                    };
                    let v2478: () = {
                        Spiral_wasm::closure39(v302.borsh(), ());
                        ()
                    };
                    let v2633: string = Spiral_wasm::method89(v1858, v1, v1392);
                    let v2723: Result<Spiral_wasm::US10, anyhow::Error> = if (v1550) > 0_i32 {
                        Ok::<Spiral_wasm::US10, anyhow::Error>(Spiral_wasm::US10::US10_0(
                            v2633.clone(),
                        ))
                    } else {
                        if (v1858) > 1_i32 {
                            Ok::<Spiral_wasm::US10, anyhow::Error>(Spiral_wasm::US10::US10_1)
                        } else {
                            let v2693: anyhow::Error = anyhow::anyhow!(v2633);
                            Err(v2693)
                        }
                    };
                    let v2750: string = string("}");
                    let v2755: bool = true;
                    let _fix_closure_v2752 = v2723;
                    let v2761: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v2752 "), (v2750))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v2762: bool = true;
                    _fix_closure_v2752
                },
            ); // rust.fix_closure';
            let v2785 = __future_init;
            v2785
        }
        pub fn closure40(unitVar: (), v0: anyhow::Error) -> std::string::String {
            format!("{}", v0)
        }
        pub fn method90() -> Func1<anyhow::Error, std::string::String> {
            Func1::new(move |v: anyhow::Error| Spiral_wasm::closure40((), v))
        }
        pub fn closure41(unitVar: (), v0: Spiral_wasm::US10) -> Spiral_wasm::US18 {
            Spiral_wasm::US18::US18_0(v0)
        }
        pub fn method91() -> Func1<Spiral_wasm::US10, Spiral_wasm::US18> {
            Func1::new(move |v: Spiral_wasm::US10| Spiral_wasm::closure41((), v))
        }
        pub fn closure42(unitVar: (), v0: std::string::String) -> Spiral_wasm::US18 {
            Spiral_wasm::US18::US18_1(v0)
        }
        pub fn method92() -> Func1<std::string::String, Spiral_wasm::US18> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure42((), v))
        }
        pub fn method93() -> string {
            let v2: &str = inline_colorization::color_yellow;
            let v5: std::string::String = String::from(v2);
            let v51: string = append(
                (fable_library_rust::String_::fromString(v5)),
                (Spiral_wasm::method25(getCharAt(toLower(string("Warning")), 0_i32))),
            );
            let v54: &str = inline_colorization::color_reset;
            let v57: std::string::String = String::from(v54);
            append((v51), (fable_library_rust::String_::fromString(v57)))
        }
        pub fn method96(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("error"));
            v0.l0.set(v3);
            ()
        }
        pub fn method95(v0: u8, v1: std::string::String) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v3.clone());
            Spiral_wasm::method50(v3.clone());
            Spiral_wasm::method31(v3.clone());
            Spiral_wasm::method14(v3.clone(), sprintf!("{}", v0));
            Spiral_wasm::method51(v3.clone());
            Spiral_wasm::method96(v3.clone());
            Spiral_wasm::method31(v3.clone());
            {
                let v7: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method14(v3.clone(), fable_library_rust::String_::fromString(v7));
                Spiral_wasm::method32(v3.clone());
                v3.l0.get().clone()
            }
        }
        pub fn method94(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: u8,
            v9: std::string::String,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run / Error error"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method95(v8, v9)),
            ))
        }
        pub fn closure43(v0: u8, v1: std::string::String, unitVar: ()) {
            fn v3() {
                Spiral_wasm::closure17((), ());
            }
            let v4: () = {
                v3();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v11: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v16: i32 = match &v11 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v103: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    40_i32 >= (v16)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v24: () = {
                        v3();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v30: Option<i64> = patternInput_1.5.clone();
                    let v29: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v25: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v33: string = Spiral_wasm::method94(
                        v25.clone(),
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        v30.clone(),
                        Spiral_wasm::method20(v25, v26, v27, v28, v29, v30),
                        Spiral_wasm::method93(),
                        v0,
                        v1,
                    );
                    let v35: () = {
                        v3();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v37: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v36: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v44: () = {
                        Spiral_wasm::closure19(v36.clone(), ());
                        ()
                    };
                    println!("{}", v33.clone());
                    (v37.l0.get().clone())(v33);
                    Spiral_wasm::US14::US14_0(
                        v36,
                        v37,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn closure44(unitVar: (), unitVar_1: ()) {
            fn v1() {
                Spiral_wasm::closure17((), ());
            }
            let v2: () = {
                v1();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v9: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v14: i32 = match &v9 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v90: Spiral_wasm::US14 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                40_i32 >= (v14)
            }) == false
            {
                Spiral_wasm::US14::US14_1
            } else {
                let v22: () = {
                    v1();
                    ()
                };
                let patternInput_1: (
                    LrcPtr<Spiral_wasm::Mut1>,
                    LrcPtr<Spiral_wasm::Mut2>,
                    LrcPtr<Spiral_wasm::Mut3>,
                    LrcPtr<Spiral_wasm::Mut4>,
                    LrcPtr<Spiral_wasm::Mut5>,
                    Option<i64>,
                ) = Spiral_wasm::TraceState::trace_state()
                    .get()
                    .clone()
                    .unwrap();
                let v24: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                let v23: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                let v31: () = {
                    Spiral_wasm::closure19(v23.clone(), ());
                    ()
                };
                println!("{}", string("\n"));
                (v24.l0.get().clone())(string("\n"));
                Spiral_wasm::US14::US14_0(
                    v23,
                    v24,
                    patternInput_1.2.clone(),
                    patternInput_1.3.clone(),
                    patternInput_1.4.clone(),
                    patternInput_1.5.clone(),
                )
            };
            ()
        }
        pub fn closure45(v0: u8, v1: std::string::String, unitVar: ()) {
            fn v3() {
                Spiral_wasm::closure17((), ());
            }
            let v4: () = {
                v3();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v11: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v16: i32 = match &v11 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v103: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    40_i32 >= (v16)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v24: () = {
                        v3();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v30: Option<i64> = patternInput_1.5.clone();
                    let v29: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v25: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v33: string = Spiral_wasm::method94(
                        v25.clone(),
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        v30.clone(),
                        Spiral_wasm::method20(v25, v26, v27, v28, v29, v30),
                        Spiral_wasm::method93(),
                        v0,
                        v1,
                    );
                    let v35: () = {
                        v3();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v37: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v36: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v44: () = {
                        Spiral_wasm::closure19(v36.clone(), ());
                        ()
                    };
                    println!("{}", v33.clone());
                    (v37.l0.get().clone())(v33);
                    Spiral_wasm::US14::US14_0(
                        v36,
                        v37,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn closure46(unitVar: (), unitVar_1: ()) {
            fn v1() {
                Spiral_wasm::closure17((), ());
            }
            let v2: () = {
                v1();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v9: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v14: i32 = match &v9 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v90: Spiral_wasm::US14 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                40_i32 >= (v14)
            }) == false
            {
                Spiral_wasm::US14::US14_1
            } else {
                let v22: () = {
                    v1();
                    ()
                };
                let patternInput_1: (
                    LrcPtr<Spiral_wasm::Mut1>,
                    LrcPtr<Spiral_wasm::Mut2>,
                    LrcPtr<Spiral_wasm::Mut3>,
                    LrcPtr<Spiral_wasm::Mut4>,
                    LrcPtr<Spiral_wasm::Mut5>,
                    Option<i64>,
                ) = Spiral_wasm::TraceState::trace_state()
                    .get()
                    .clone()
                    .unwrap();
                let v24: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                let v23: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                let v31: () = {
                    Spiral_wasm::closure19(v23.clone(), ());
                    ()
                };
                println!("{}", string("\n"));
                (v24.l0.get().clone())(string("\n"));
                Spiral_wasm::US14::US14_0(
                    v23,
                    v24,
                    patternInput_1.2.clone(),
                    patternInput_1.3.clone(),
                    patternInput_1.4.clone(),
                    patternInput_1.5.clone(),
                )
            };
            ()
        }
        pub fn method97() -> string {
            let v2: &str = inline_colorization::color_bright_red;
            let v5: std::string::String = String::from(v2);
            let v51: string = append(
                (fable_library_rust::String_::fromString(v5)),
                (Spiral_wasm::method25(getCharAt(toLower(string("Critical")), 0_i32))),
            );
            let v54: &str = inline_colorization::color_reset;
            let v57: std::string::String = String::from(v54);
            append((v51), (fable_library_rust::String_::fromString(v57)))
        }
        pub fn method99(v0: u8, v1: string) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v3.clone());
            Spiral_wasm::method50(v3.clone());
            Spiral_wasm::method31(v3.clone());
            Spiral_wasm::method14(v3.clone(), sprintf!("{}", v0));
            Spiral_wasm::method51(v3.clone());
            Spiral_wasm::method96(v3.clone());
            Spiral_wasm::method31(v3.clone());
            Spiral_wasm::method14(v3.clone(), v1);
            Spiral_wasm::method32(v3.clone());
            v3.l0.get().clone()
        }
        pub fn method98(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: u8,
            v9: string,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run / Ok (Some error)"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method99(v8, v9)),
            ))
        }
        pub fn closure47(v0: u8, v1: string, unitVar: ()) {
            fn v3() {
                Spiral_wasm::closure17((), ());
            }
            let v4: () = {
                v3();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v11: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v16: i32 = match &v11 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v103: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    50_i32 >= (v16)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v24: () = {
                        v3();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v30: Option<i64> = patternInput_1.5.clone();
                    let v29: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v25: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v33: string = Spiral_wasm::method98(
                        v25.clone(),
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        v30.clone(),
                        Spiral_wasm::method20(v25, v26, v27, v28, v29, v30),
                        Spiral_wasm::method97(),
                        v0,
                        v1,
                    );
                    let v35: () = {
                        v3();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v37: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v36: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v44: () = {
                        Spiral_wasm::closure19(v36.clone(), ());
                        ()
                    };
                    println!("{}", v33.clone());
                    (v37.l0.get().clone())(v33);
                    Spiral_wasm::US14::US14_0(
                        v36,
                        v37,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method46(
            v0: Vec<u8>,
            v1: u8,
        ) -> std::pin::Pin<Box<dyn std::future::Future<Output = Spiral_wasm::US15>>> {
            let v3: bool = true;
            let __future_init = Box::pin(
                /*;
                let v5: bool = */
                async move {
                    /*;
                    let v7: bool = */
                    ();
                    let v8: std::pin::Pin<
                        Box<
                            dyn std::future::Future<
                                    Output = Result<Spiral_wasm::US10, anyhow::Error>,
                                >,
                        >,
                    > = Spiral_wasm::method47(v0.clone(), v1);
                    let v10: Result<Spiral_wasm::US10, anyhow::Error> = v8.await;
                    let v11 = Spiral_wasm::method90();
                    let v23: Result<Spiral_wasm::US10, std::string::String> =
                        v10.map_err(|x| v11(x));
                    let v30 = Spiral_wasm::method91();
                    let v31 = Spiral_wasm::method92();
                    let v34: Spiral_wasm::US18 = match &v23 {
                        Err(v23_1_0) => v31(v23_1_0.clone()),
                        Ok(v23_0_0) => v30(v23_0_0.clone()),
                    };
                    let v1434: Spiral_wasm::US15 = match &v34 {
                        Spiral_wasm::US18::US18_0(v34_0_0) => {
                            let v64: Spiral_wasm::US10 = v34_0_0.clone();
                            match &v64 {
                                Spiral_wasm::US10::US10_0(v64_0_0) => {
                                    let v137: string = match &v64 {
                                        Spiral_wasm::US10::US10_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone();
                                    let v239: () = {
                                        Spiral_wasm::closure47(v1, v137.clone(), ());
                                        ()
                                    };
                                    let v395: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v397: bool = */
                                        async move {
                                            /*;
                                            let v399: bool = */
                                            ();
                                            let v418: string = string("}");
                                            let v424: bool = true;
                                            let _fix_closure_v421 =
                                                (v1, Spiral_wasm::US10::US10_0(v137));
                                            let v430: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v421 "),
                                                            (v418),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v431: bool = true;
                                            _fix_closure_v421
                                        },
                                    ); // rust.fix_closure';
                                    let v459 = __future_init;
                                    let v461: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<
                                                    Output = (u8, Spiral_wasm::US10),
                                                >,
                                        >,
                                    > = v459;
                                    let patternInput_2: (u8, Spiral_wasm::US10) = v461.await;
                                    Spiral_wasm::US15::US15_1(
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone(),
                                    )
                                }
                                _ => {
                                    let v66: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v68: bool = */
                                        async move {
                                            /*;
                                            let v70: bool = */
                                            ();
                                            let v89: string = string("}");
                                            let v95: bool = true;
                                            let _fix_closure_v92 = (v1, Spiral_wasm::US10::US10_1);
                                            let v101: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v92 "),
                                                            (v89),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v102: bool = true;
                                            _fix_closure_v92
                                        },
                                    ); // rust.fix_closure';
                                    let v130 = __future_init;
                                    let v132: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<
                                                    Output = (u8, Spiral_wasm::US10),
                                                >,
                                        >,
                                    > = v130;
                                    let patternInput_1: (u8, Spiral_wasm::US10) = v132.await;
                                    Spiral_wasm::US15::US15_0(
                                        patternInput_1.0.clone(),
                                        patternInput_1.1.clone(),
                                    )
                                }
                            }
                        }
                        Spiral_wasm::US18::US18_1(v34_1_0) => {
                            let v468: std::string::String = v34_1_0.clone();
                            if (v1) >= 15_u8 {
                                let v571: () = {
                                    Spiral_wasm::closure43(v1, v468.clone(), ());
                                    ()
                                };
                                let v808: () = {
                                    Spiral_wasm::closure44((), ());
                                    ()
                                };
                                let v935: bool = true;
                                let __future_init = Box::pin(
                                    /*;
                                    let v937: bool = */
                                    async move {
                                        /*;
                                        let v939: bool = */
                                        ();
                                        let v942: string = string("}");
                                        let v948: bool = true;
                                        let _fix_closure_v945 = (v1, Spiral_wasm::US10::US10_1);
                                        let v954: string = append(
                                            (append(
                                                (append(
                                                    (append(
                                                        string("true; _fix_closure_v945 "),
                                                        (v942),
                                                    )),
                                                    string("); "),
                                                )),
                                                string(""),
                                            )),
                                            string(" // rust.fix_closure\'"),
                                        );
                                        let v955: bool = true;
                                        _fix_closure_v945
                                    },
                                ); // rust.fix_closure';
                                let v957 = __future_init;
                                let v959: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = (u8, Spiral_wasm::US10)>>,
                                > = v957;
                                let patternInput: (u8, Spiral_wasm::US10) = v959.await;
                                Spiral_wasm::US15::US15_0(
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                )
                            } else {
                                let v1065: () = {
                                    Spiral_wasm::closure45(v1, v468, ());
                                    ()
                                };
                                let v1302: () = {
                                    Spiral_wasm::closure46((), ());
                                    ()
                                };
                                let v1429: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = Spiral_wasm::US15>>,
                                > = Spiral_wasm::method46(v0.clone(), (v1) + 1_u8);
                                v1429.await
                            }
                        }
                    };
                    let v1451: string = string("}");
                    let v1456: bool = true;
                    let _fix_closure_v1453 = v1434;
                    let v1462: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v1453 "), (v1451))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v1463: bool = true;
                    _fix_closure_v1453
                },
            ); // rust.fix_closure';
            let v1486 = __future_init;
            v1486
        }
        pub fn method102(v0: LrcPtr<Spiral_wasm::Mut4>) {
            let v3: string = append((v0.l0.get().clone()), string("retries"));
            v0.l0.set(v3);
            ()
        }
        pub fn method101(v0: Spiral_wasm::US15) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v2.clone());
            Spiral_wasm::method102(v2.clone());
            Spiral_wasm::method31(v2.clone());
            Spiral_wasm::method14(v2.clone(), sprintf!("{:?}", v0));
            Spiral_wasm::method32(v2.clone());
            v2.l0.get().clone()
        }
        pub fn method100(
            v0: LrcPtr<Spiral_wasm::Mut1>,
            v1: LrcPtr<Spiral_wasm::Mut2>,
            v2: LrcPtr<Spiral_wasm::Mut3>,
            v3: LrcPtr<Spiral_wasm::Mut4>,
            v4: LrcPtr<Spiral_wasm::Mut5>,
            v5: Option<i64>,
            v6_1: string,
            v7: string,
            v8: Spiral_wasm::US15,
        ) -> string {
            Spiral_wasm::method33(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6_1), string(" "))),
                                    (Spiral_wasm::method27(v0.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method101(v8)),
            ))
        }
        pub fn closure48(v0: Spiral_wasm::US15, unitVar: ()) {
            fn v2() {
                Spiral_wasm::closure17((), ());
            }
            let v3: () = {
                v2();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v10: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v15: i32 = match &v10 {
                Spiral_wasm::US5::US5_1 => 20_i32,
                Spiral_wasm::US5::US5_2 => 30_i32,
                Spiral_wasm::US5::US5_0 => 10_i32,
                Spiral_wasm::US5::US5_3 => 40_i32,
                _ => 50_i32,
            };
            let v102: Spiral_wasm::US14 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    10_i32 >= (v15)
                }) == false
                {
                    Spiral_wasm::US14::US14_1
                } else {
                    let v23: () = {
                        v2();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v29: Option<i64> = patternInput_1.5.clone();
                    let v28: LrcPtr<Spiral_wasm::Mut5> = patternInput_1.4.clone();
                    let v27: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.3.clone();
                    let v26: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.2.clone();
                    let v25: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.1.clone();
                    let v24: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.0.clone();
                    let v32: string = Spiral_wasm::method100(
                        v24.clone(),
                        v25.clone(),
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        Spiral_wasm::method20(v24, v25, v26, v27, v28, v29),
                        Spiral_wasm::method24(),
                        v0,
                    );
                    let v34: () = {
                        v2();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        LrcPtr<Spiral_wasm::Mut5>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v36: LrcPtr<Spiral_wasm::Mut2> = patternInput_2.1.clone();
                    let v35: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.0.clone();
                    let v43: () = {
                        Spiral_wasm::closure19(v35.clone(), ());
                        ()
                    };
                    println!("{}", v32.clone());
                    (v36.l0.get().clone())(v32);
                    Spiral_wasm::US14::US14_0(
                        v35,
                        v36,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method103(v0: Spiral_wasm::US15, v1: Spiral_wasm::US10) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut4> = LrcPtr::new(Spiral_wasm::Mut4 {
                l0: MutCell::new(Spiral_wasm::method13()),
            });
            Spiral_wasm::method29(v3.clone());
            Spiral_wasm::method102(v3.clone());
            Spiral_wasm::method31(v3.clone());
            Spiral_wasm::method14(v3.clone(), sprintf!("{:?}", v0));
            Spiral_wasm::method51(v3.clone());
            Spiral_wasm::method96(v3.clone());
            Spiral_wasm::method31(v3.clone());
            Spiral_wasm::method14(v3.clone(), sprintf!("{:?}", v1));
            Spiral_wasm::method32(v3.clone());
            v3.l0.get().clone()
        }
        pub fn method41(
            v0: clap::ArgMatches,
        ) -> std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>>
        {
            let v2: bool = true;
            let __future_init = Box::pin(
                /*;
                let v4: bool = */
                async move {
                    /*;
                    let v6_1: bool = */
                    ();
                    let v7: string = Spiral_wasm::method42();
                    let v10: &str = &*v7;
                    let v19: Option<std::string::String> =
                        clap::ArgMatches::get_one(&v0, v10).cloned();
                    let v23: Spiral_wasm::US2 =
                        defaultValue(Spiral_wasm::US2::US2_1, map(Spiral_wasm::method4(), v19));
                    let v27: std::string::String = match &v23 {
                        Spiral_wasm::US2::US2_0(v23_0_0) => match &v23 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v29: string = fable_library_rust::String_::fromString(v27);
                    let v131: () = {
                        Spiral_wasm::closure23(v29.clone(), ());
                        ()
                    };
                    let v287: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v29);
                    let v291: std::pin::Pin<
                        Box<dyn std::future::Future<Output = Spiral_wasm::US15>>,
                    > = Spiral_wasm::method46(v287?, 1_u8);
                    let v293: Spiral_wasm::US15 = v291.await;
                    let v395: () = {
                        Spiral_wasm::closure48(v293.clone(), ());
                        ()
                    };
                    let v608: Result<u8, anyhow::Error> = match &v293 {
                        Spiral_wasm::US15::US15_0(v293_0_0, v293_0_1) => {
                            Ok::<u8, anyhow::Error>(v293_0_0.clone())
                        }
                        Spiral_wasm::US15::US15_1(v293_1_0, v293_1_1) => {
                            let v586: string =
                                Spiral_wasm::method103(v293.clone(), v293_1_1.clone());
                            let v588: anyhow::Error = anyhow::anyhow!(v586);
                            Err(v588)
                        }
                    };
                    let v625: string = string("}");
                    let v630: bool = true;
                    let _fix_closure_v627 = v608;
                    let v636: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v627 "), (v625))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v637: bool = true;
                    _fix_closure_v627
                },
            ); // rust.fix_closure';
            let v660 = __future_init;
            v660
        }
        pub fn closure49(unitVar: (), v0: u8) -> Spiral_wasm::US19 {
            Spiral_wasm::US19::US19_0(v0)
        }
        pub fn method104() -> Func1<u8, Spiral_wasm::US19> {
            Func1::new(move |v: u8| Spiral_wasm::closure49((), v))
        }
        pub fn closure50(unitVar: (), v0: std::string::String) -> Spiral_wasm::US19 {
            Spiral_wasm::US19::US19_1(v0)
        }
        pub fn method105() -> Func1<std::string::String, Spiral_wasm::US19> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure50((), v))
        }
        pub fn closure0(unitVar: (), v0: Array<string>) -> i32 {
            let v1: clap::Command = Spiral_wasm::method0();
            let v3: clap::ArgMatches = clap::Command::get_matches(v1);
            let v4: string = Spiral_wasm::method3();
            let v7: &str = &*v4;
            let v16: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v7).cloned();
            let v107: Spiral_wasm::US2 =
                defaultValue(Spiral_wasm::US2::US2_1, map(Spiral_wasm::method4(), v16));
            let v698: Spiral_wasm::US3 = match &v107 {
                Spiral_wasm::US2::US2_0(v107_0_0) => {
                    let v124: string = fable_library_rust::String_::fromString(
                        match &v107 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    );
                    let v137: string = toLower(string("Critical"));
                    let v140: string = toLower(string("Warning"));
                    let v143: string = toLower(string("Info"));
                    let v146: string = toLower(string("Debug"));
                    let v633: Array<(string, Spiral_wasm::US5)> = toArray(ofArray(new_array(&[
                        (string("Verbose"), Spiral_wasm::US5::US5_0),
                        (string("Debug"), Spiral_wasm::US5::US5_1),
                        (string("Info"), Spiral_wasm::US5::US5_2),
                        (string("Warning"), Spiral_wasm::US5::US5_3),
                        (string("Critical"), Spiral_wasm::US5::US5_4),
                        (toLower(string("Verbose")), Spiral_wasm::US5::US5_0),
                        (v146, Spiral_wasm::US5::US5_1),
                        (v143, Spiral_wasm::US5::US5_2),
                        (v140, Spiral_wasm::US5::US5_3),
                        (v137, Spiral_wasm::US5::US5_4),
                    ])));
                    let v666: i32 = get_Count(v633.clone());
                    let v668: LrcPtr<Spiral_wasm::Mut0> = LrcPtr::new(Spiral_wasm::Mut0 {
                        l0: MutCell::new(0_i32),
                        l1: MutCell::new(Spiral_wasm::US4::US4_1),
                    });
                    while Spiral_wasm::method5(v666, v668.clone()) {
                        let v670: i32 = v668.l0.get().clone();
                        let v673: i32 = ((v670.wrapping_neg()) + (v666)) - 1_i32;
                        let v674: Spiral_wasm::US4 = v668.l1.get().clone();
                        let patternInput: (string, Spiral_wasm::US5) = v633[v673].clone();
                        let v692: Spiral_wasm::US4 = match &v674 {
                            Spiral_wasm::US4::US4_0(v674_0_0) => v674.clone(),
                            _ => {
                                if (patternInput.0.clone()) == (v124.clone()) {
                                    Spiral_wasm::US4::US4_0(patternInput.1.clone())
                                } else {
                                    Spiral_wasm::US4::US4_1
                                }
                            }
                        };
                        let v693: i32 = (v670) + 1_i32;
                        v668.l0.set(v693);
                        v668.l1.set(v692);
                        ()
                    }
                    Spiral_wasm::US3::US3_0(v668.l1.get().clone())
                }
                _ => Spiral_wasm::US3::US3_1,
            };
            let v705: Spiral_wasm::US4 = if let Spiral_wasm::US3::US3_0(v698_0_0) = &v698 {
                let v699: Spiral_wasm::US4 = v698_0_0.clone();
                if let Spiral_wasm::US4::US4_0(v699_0_0) = &v699 {
                    Spiral_wasm::US4::US4_0(v699_0_0.clone())
                } else {
                    Spiral_wasm::US4::US4_1
                }
            } else {
                Spiral_wasm::US4::US4_1
            };
            let v756: () = {
                Spiral_wasm::closure7(
                    match &v705 {
                        Spiral_wasm::US4::US4_0(v705_0_0) => match &v705 {
                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => Spiral_wasm::US5::US5_0,
                    },
                    (),
                );
                ()
            };
            let patternInput_1: (
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                LrcPtr<Spiral_wasm::Mut5>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v1261: () = {
                Spiral_wasm::closure16(v0, ());
                ()
            };
            let v1416: string = Spiral_wasm::method37();
            let v1419: &str = &*v1416;
            let v1428: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v1419).cloned();
            let v1448: Option<string> = map(Spiral_wasm::method38(), v1428);
            let v1492: Spiral_wasm::US10 = defaultValue(
                Spiral_wasm::US10::US10_1,
                map(Spiral_wasm::method17(), v1448),
            );
            let v1493: std::pin::Pin<
                Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>,
            > = Spiral_wasm::method41(v3);
            let v1495 = tokio::runtime::Builder::new_multi_thread()
                .enable_all()
                .build()
                .unwrap();
            let v1497: Result<u8, anyhow::Error> = v1495.handle().block_on(v1493);
            let v1498 = Spiral_wasm::method90();
            let v1510: Result<u8, std::string::String> = v1497.map_err(|x| v1498(x));
            let v1519 = Spiral_wasm::method104();
            let v1520 = Spiral_wasm::method105();
            let v1523: Spiral_wasm::US19 = match &v1510 {
                Err(v1510_1_0) => v1520(v1510_1_0.clone()),
                Ok(v1510_0_0) => v1519(v1510_0_0.clone()),
            };
            match &v1523 {
                Spiral_wasm::US19::US19_0(v1523_0_0) => {
                    if let Spiral_wasm::US10::US10_0(v1492_0_0) = &v1492 {
                        let v1555: string = sprintf!(
                            "spiral_wasm.main / retries: {} / exception: \'{}\'",
                            v1523_0_0.clone(),
                            v1492_0_0.clone()
                        );
                        let v1560: Result<(), string> = Err(v1555);
                        v1560.unwrap();
                        ()
                    }
                }
                Spiral_wasm::US19::US19_1(v1523_1_0) => {
                    let v1575: std::string::String = v1523_1_0.clone();
                    if let Spiral_wasm::US10::US10_0(v1492_0_0) = &v1492 {
                        let v1576: string = v1492_0_0.clone();
                        if string("") == (v1576.clone()) {
                            ()
                        } else {
                            if contains(
                                fable_library_rust::String_::fromString(v1575.clone()),
                                v1576.clone(),
                            ) {
                                ()
                            } else {
                                let v1590: string = sprintf!(
                                    "spiral_wasm.main / exception: \'{}\' / error: {}",
                                    v1576,
                                    v1575
                                );
                                let v1593: Result<(), string> = Err(v1590);
                                v1593.unwrap();
                                ()
                            }
                        }
                    } else {
                        let v1603: u8 = v1510.clone().unwrap();
                        ()
                    }
                }
            }
            0_i32
        }
        pub fn v6() -> Func1<Array<string>, i32> {
            static v6: OnceInit<Func1<Array<string>, i32>> = OnceInit::new();
            v6.get_or_init(|| Func1::new(move |v: Array<string>| Spiral_wasm::closure0((), v)))
                .clone()
        }
        pub fn main(args: Array<string>) -> i32 {
            (Spiral_wasm::v6())(args)
        }
    }
}
pub use module_fb49c4a9::*;
#[path = "../../lib/spiral/async_.rs"]
mod module_2335f2f5;
pub use module_2335f2f5::*;
#[path = "../../lib/spiral/common.rs"]
mod module_652e6d81;
pub use module_652e6d81::*;
#[path = "../../lib/spiral/crypto.rs"]
mod module_dd5f95ef;
pub use module_dd5f95ef::*;
#[path = "../../lib/spiral/date_time.rs"]
mod module_ca5e6cb2;
pub use module_ca5e6cb2::*;
#[path = "../../lib/spiral/file_system.rs"]
mod module_5ab1faf0;
pub use module_5ab1faf0::*;
#[path = "../../lib/spiral/lib.rs"]
mod module_b386774b;
pub use module_b386774b::*;
#[path = "../../lib/spiral/networking.rs"]
mod module_ce497f72;
pub use module_ce497f72::*;
#[path = "../../lib/spiral/platform.rs"]
mod module_9a61edd3;
pub use module_9a61edd3::*;
#[path = "../../lib/spiral/runtime.rs"]
mod module_502d7e30;
pub use module_502d7e30::*;
#[path = "../../lib/spiral/sm.rs"]
mod module_34f67952;
pub use module_34f67952::*;
#[path = "../../lib/spiral/threading.rs"]
mod module_11c0c5c2;
pub use module_11c0c5c2::*;
#[path = "../../lib/spiral/trace.rs"]
mod module_28ecba0d;
pub use module_28ecba0d::*;
#[path = "../../deps/polyglot/lib/fsharp/Common.rs"]
mod module_ad43931;
pub use module_ad43931::*;
pub mod Polyglot {
    pub use crate::module_ad43931::Polyglot::*;
}
pub fn main() {
    let args = std::env::args().skip(1).map(fromString).collect();
    Spiral_wasm::main(array_from(args));
}
