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
mod module_e3e534c3 {
    pub mod Spiral_wasm {
        use super::*;
        use fable_library_rust::DateTime_::DateTime;
        use fable_library_rust::Exception_::try_catch;
        use fable_library_rust::List_::ofArray;
        use fable_library_rust::List_::toArray;
        use fable_library_rust::Map_::find;
        use fable_library_rust::Map_::ofSeq;
        use fable_library_rust::Native_::Any;
        use fable_library_rust::Native_::Func0;
        use fable_library_rust::Native_::Func1;
        use fable_library_rust::Native_::LrcPtr;
        use fable_library_rust::Native_::MutCell;
        use fable_library_rust::Native_::OnceInit;
        use fable_library_rust::NativeArray_::Array;
        use fable_library_rust::NativeArray_::new_array;
        use fable_library_rust::Option_::defaultValue;
        use fable_library_rust::Option_::map;
        use fable_library_rust::Seq_::ofList;
        use fable_library_rust::String_::append;
        use fable_library_rust::String_::contains;
        use fable_library_rust::String_::getCharAt;
        use fable_library_rust::String_::getSlice;
        use fable_library_rust::String_::length;
        use fable_library_rust::String_::printfn;
        use fable_library_rust::String_::sprintf;
        use fable_library_rust::String_::string;
        use fable_library_rust::String_::toLower;
        use fable_library_rust::String_::toString;
        use fable_library_rust::System::Collections::Generic::IEnumerable_1;
        use fable_library_rust::System::Exception;
        use fable_library_rust::TimeSpan_::TimeSpan;
        pub trait IOsEnviron: core::fmt::Debug + core::fmt::Display {
            fn environ(&self) -> LrcPtr<dyn Any>;
        }
        impl<V: IOsEnviron + core::fmt::Debug + core::fmt::Display> IOsEnviron for LrcPtr<V> {
            #[inline]
            fn environ(&self) -> LrcPtr<dyn Any> {
                (**self).environ()
            }
        }
        pub mod TraceState {
            use super::*;
            pub fn trace_state() -> LrcPtr<
                MutCell<
                    Option<(
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    )>,
                >,
            > {
                static trace_state: OnceInit<
                    LrcPtr<
                        MutCell<
                            Option<(
                                LrcPtr<Spiral_wasm::Mut0>,
                                LrcPtr<Spiral_wasm::Mut1>,
                                LrcPtr<Spiral_wasm::Mut2>,
                                LrcPtr<Spiral_wasm::Mut3>,
                                LrcPtr<Spiral_wasm::Mut4>,
                                Option<i64>,
                            )>,
                        >,
                    >,
                > = OnceInit::new();
                trace_state
                    .get_or_init(|| {
                        LrcPtr::new(MutCell::new(
                            None::<(
                                LrcPtr<Spiral_wasm::Mut0>,
                                LrcPtr<Spiral_wasm::Mut1>,
                                LrcPtr<Spiral_wasm::Mut2>,
                                LrcPtr<Spiral_wasm::Mut3>,
                                LrcPtr<Spiral_wasm::Mut4>,
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
            pub l0: MutCell<i64>,
        }
        impl core::fmt::Display for Mut0 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub struct Mut1 {
            pub l0: MutCell<Func1<string, ()>>,
        }
        impl core::fmt::Display for Mut1 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub struct Mut2 {
            pub l0: MutCell<bool>,
        }
        impl core::fmt::Display for Mut2 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub struct Mut3 {
            pub l0: MutCell<string>,
        }
        impl core::fmt::Display for Mut3 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub struct Mut4 {
            pub l0: MutCell<Spiral_wasm::US5>,
        }
        impl core::fmt::Display for Mut4 {
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
            US7_2,
        }
        impl core::fmt::Display for US7 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US8 {
            US8_0(Spiral_wasm::US7),
            US8_1(Spiral_wasm::US7),
            US8_2(Spiral_wasm::US7),
            US8_3(Spiral_wasm::US7),
            US8_4(Spiral_wasm::US7),
            US8_5(Spiral_wasm::US7),
            US8_6(Spiral_wasm::US7),
        }
        impl core::fmt::Display for US8 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US9 {
            US9_0(string),
            US9_1,
        }
        impl core::fmt::Display for US9 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US10 {
            US10_0(i64),
            US10_1(LrcPtr<Exception>),
        }
        impl core::fmt::Display for US10 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US11 {
            US11_0(
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ),
            US11_1,
        }
        impl core::fmt::Display for US11 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US12 {
            US12_0(char),
            US12_1,
        }
        impl core::fmt::Display for US12 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US13 {
            US13_0(i32),
            US13_1(LrcPtr<Exception>),
        }
        impl core::fmt::Display for US13 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US14 {
            US14_0(i32),
            US14_1,
        }
        impl core::fmt::Display for US14 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US15 {
            US15_0(u8, Spiral_wasm::US9),
            US15_1(u8, Spiral_wasm::US9),
        }
        impl core::fmt::Display for US15 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US16 {
            US16_0(Spiral_wasm::US9),
            US16_1(std::string::String),
        }
        impl core::fmt::Display for US16 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US17 {
            US17_0(u8),
            US17_1(std::string::String),
        }
        impl core::fmt::Display for US17 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        pub fn closure1(unitVar: (), unitVar_1: ()) -> usize {
            0_i32 as usize
        }
        pub fn closure2(unitVar: (), v0_1: usize) -> Spiral_wasm::US0 {
            Spiral_wasm::US0::US0_0(v0_1)
        }
        pub fn closure3(unitVar: (), v0_1: Func0<LrcPtr<Exception>>) -> LrcPtr<Exception> {
            v0_1()
        }
        pub fn closure4(unitVar: (), v0_1: LrcPtr<Exception>) -> Spiral_wasm::US0 {
            Spiral_wasm::US0::US0_1(v0_1)
        }
        pub fn closure5(unitVar: (), unitVar_1: ()) -> usize {
            1_i32 as usize
        }
        pub fn method0() -> clap::Command {
            let v1: string = string("r#\"command\"#");
            let v2: &'static str = r#"command"#;
            let v4: clap::Command = clap::Command::new(v2);
            let v6: clap::Command = clap::Command::args_override_self(v4, true);
            fn v13() -> usize {
                Spiral_wasm::closure1((), ())
            }
            fn v14(v: usize) -> Spiral_wasm::US0 {
                Spiral_wasm::closure2((), v)
            }
            fn v15(v_1: Func0<LrcPtr<Exception>>) -> LrcPtr<Exception> {
                Spiral_wasm::closure3((), v_1)
            }
            fn v16(v_2: LrcPtr<Exception>) -> Spiral_wasm::US0 {
                Spiral_wasm::closure4((), v_2)
            }
            let v17: Spiral_wasm::US0 = try_catch(
                || v14(v13()),
                |ex: LrcPtr<Exception>| {
                    v16(v15(Func0::new({
                        let ex = ex.clone();
                        move || ex.clone()
                    })))
                },
            );
            let v36: Spiral_wasm::US1 = match &v17 {
                Spiral_wasm::US0::US0_0(v17_0_0) => Spiral_wasm::US1::US1_0(v17_0_0.clone()),
                _ => Spiral_wasm::US1::US1_1,
            };
            let v74: usize = match &v36 {
                Spiral_wasm::US1::US1_0(v36_0_0) => match &v36 {
                    Spiral_wasm::US1::US1_0(x) => x.clone(),
                    _ => unreachable!(),
                },
                _ => panic!("{}", string("Option does not have a value."),),
            };
            let v82: Spiral_wasm::US0 = try_catch(
                || v14(Spiral_wasm::closure5((), ())),
                |ex_1: LrcPtr<Exception>| {
                    v16(v15(Func0::new({
                        let ex_1 = ex_1.clone();
                        move || ex_1.clone()
                    })))
                },
            );
            let v101: Spiral_wasm::US1 = match &v82 {
                Spiral_wasm::US0::US0_0(v82_0_0) => Spiral_wasm::US1::US1_0(v82_0_0.clone()),
                _ => Spiral_wasm::US1::US1_1,
            };
            let v139: usize = match &v101 {
                Spiral_wasm::US1::US1_0(v101_0_0) => match &v101 {
                    Spiral_wasm::US1::US1_0(x) => x.clone(),
                    _ => unreachable!(),
                },
                _ => panic!("{}", string("Option does not have a value."),),
            };
            let v146: Spiral_wasm::US0 = try_catch(
                || v14(v13()),
                |ex_2: LrcPtr<Exception>| {
                    v16(v15(Func0::new({
                        let ex_2 = ex_2.clone();
                        move || ex_2.clone()
                    })))
                },
            );
            let v165: Spiral_wasm::US1 = match &v146 {
                Spiral_wasm::US0::US0_0(v146_0_0) => Spiral_wasm::US1::US1_0(v146_0_0.clone()),
                _ => Spiral_wasm::US1::US1_1,
            };
            let v220: clap::builder::ValueRange = if (v139)
                == (match &v165 {
                    Spiral_wasm::US1::US1_0(v165_0_0) => match &v165 {
                        Spiral_wasm::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    },
                    _ => panic!("{}", string("Option does not have a value."),),
                }) {
                clap::builder::ValueRange::new(v74..)
            } else {
                let v218: string = string("clap::builder::ValueRange::new($0..=$1)");
                clap::builder::ValueRange::new(v74..=v139)
            };
            let v222: string = string("r#\"exception\"#");
            let v223: &'static str = r#"exception"#;
            let v225: clap::Arg = clap::Arg::new(v223);
            let v227: clap::Arg = v225.short('e');
            let v228: string = string("r#\"exception\"#");
            let v229: &'static str = r#"exception"#;
            let v231: clap::Arg = v227.long(v229);
            let v233: clap::Arg = v231.num_args(v220);
            let v235: clap::Arg = v233.require_equals(true);
            let v237: string = string("r#\"\"#");
            let v238: &str = r#""#;
            let v240: clap::Arg = v235.default_missing_value(v238);
            let v242: clap::Command = clap::Command::arg(v6, v240);
            let v244: string = string("r#\"trace_level\"#");
            let v245: &'static str = r#"trace_level"#;
            let v247: clap::Arg = clap::Arg::new(v245);
            let v249: clap::Arg = v247.short('t');
            let v250: string = string("r#\"trace_level\"#");
            let v251: &'static str = r#"trace_level"#;
            let v253: clap::Arg = v249.long(v251);
            let v258: string = toLower(string("Critical"));
            let v272: string = toLower(string("Warning"));
            let v286: string = toLower(string("Info"));
            let v300: string = toLower(string("Debug"));
            let v397: Array<string> = toArray(ofArray(new_array(&[
                toLower(string("Verbose")),
                v300,
                v286,
                v272,
                v258,
            ])));
            let v408: Vec<string> = v397.to_vec();
            let v410: bool = true;
            let _vec_map: Vec<_> = v408
                .into_iter()
                .map(|x| {
                    //;
                    let v412: string = x;
                    let v426: &str = &*v412;
                    let v511: std::string::String = String::from(v426);
                    let v584: Box<std::string::String> = Box::new(v511);
                    let v586: &'static mut std::string::String = Box::leak(v584);
                    let v588: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v586);
                    let v590: bool = true;
                    v588
                })
                .collect::<Vec<_>>();
            let v592: Vec<clap::builder::PossibleValue> = _vec_map;
            let v594: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v592),
            );
            let v596: clap::Arg = v253.value_parser(v594);
            let v598: clap::Command = clap::Command::arg(v242, v596);
            let v600: string = string("r#\"wasm\"#");
            let v601: &'static str = r#"wasm"#;
            let v603: clap::Arg = clap::Arg::new(v601);
            let v605: clap::Arg = v603.short('w');
            let v606: string = string("r#\"wasm\"#");
            let v607: &'static str = r#"wasm"#;
            let v609: clap::Arg = v605.long(v607);
            let v611: clap::Arg = v609.required(true);
            clap::Command::arg(v598, v611)
        }
        pub fn method1() -> string {
            string("trace_level")
        }
        pub fn closure6(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US2 {
            Spiral_wasm::US2::US2_0(v0_1)
        }
        pub fn method2() -> Func1<std::string::String, Spiral_wasm::US2> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure6((), v))
        }
        pub fn method6(v0_1: string) -> string {
            v0_1
        }
        pub fn method7() -> string {
            string("")
        }
        pub fn closure8(unitVar: (), v0_1: string) -> Spiral_wasm::US9 {
            Spiral_wasm::US9::US9_0(v0_1)
        }
        pub fn method8() -> Func1<string, Spiral_wasm::US9> {
            Func1::new(move |v: string| Spiral_wasm::closure8((), v))
        }
        pub fn method5(v0_1: string) -> string {
            let v21: string = Spiral_wasm::method6(v0_1);
            let v23: Result<std::string::String, std::env::VarError> = std::env::var(&*v21);
            let v25: bool = true;
            let _result_map_ = v23.map(|x| {
                //;
                let v27: std::string::String = x;
                let v29: string = fable_library_rust::String_::fromString(v27);
                let v31: bool = true;
                v29
            });
            let v33: Result<string, std::env::VarError> = _result_map_;
            let v34: string = Spiral_wasm::method7();
            v33.unwrap_or(v34)
        }
        pub fn closure9(v0_1: i64, unitVar: ()) -> i64 {
            v0_1
        }
        pub fn closure10(unitVar: (), v0_1: i64) -> Spiral_wasm::US10 {
            Spiral_wasm::US10::US10_0(v0_1)
        }
        pub fn closure11(unitVar: (), v0_1: LrcPtr<Exception>) -> Spiral_wasm::US10 {
            Spiral_wasm::US10::US10_1(v0_1)
        }
        pub fn method4() -> (Spiral_wasm::US4, Spiral_wasm::US6) {
            let v1: string = Spiral_wasm::method5(string("TRACE_LEVEL"));
            let v6: string = toLower(string("Critical"));
            let v20: string = toLower(string("Warning"));
            let v34: string = toLower(string("Info"));
            let v48: string = toLower(string("Debug"));
            let v62: string = toLower(string("Verbose"));
            let v76: Spiral_wasm::US4 = if string("Verbose") == (v1.clone()) {
                Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_0)
            } else {
                Spiral_wasm::US4::US4_1
            };
            (
                match &v76 {
                    Spiral_wasm::US4::US4_0(v76_0_0) => Spiral_wasm::US4::US4_0(
                        match &v76 {
                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    _ => {
                        let v83: Spiral_wasm::US4 = if string("Debug") == (v1.clone()) {
                            Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_1)
                        } else {
                            Spiral_wasm::US4::US4_1
                        };
                        match &v83 {
                            Spiral_wasm::US4::US4_0(v83_0_0) => Spiral_wasm::US4::US4_0(
                                match &v83 {
                                    Spiral_wasm::US4::US4_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => {
                                let v90: Spiral_wasm::US4 = if string("Info") == (v1.clone()) {
                                    Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_2)
                                } else {
                                    Spiral_wasm::US4::US4_1
                                };
                                match &v90 {
                                    Spiral_wasm::US4::US4_0(v90_0_0) => Spiral_wasm::US4::US4_0(
                                        match &v90 {
                                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => {
                                        let v97: Spiral_wasm::US4 =
                                            if string("Warning") == (v1.clone()) {
                                                Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_3)
                                            } else {
                                                Spiral_wasm::US4::US4_1
                                            };
                                        match &v97 {
                                            Spiral_wasm::US4::US4_0(v97_0_0) => {
                                                Spiral_wasm::US4::US4_0(
                                                    match &v97 {
                                                        Spiral_wasm::US4::US4_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                )
                                            }
                                            _ => {
                                                let v104: Spiral_wasm::US4 = if string("Critical")
                                                    == (v1.clone())
                                                {
                                                    Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_4)
                                                } else {
                                                    Spiral_wasm::US4::US4_1
                                                };
                                                match &v104 {
                                                    Spiral_wasm::US4::US4_0(v104_0_0) => {
                                                        Spiral_wasm::US4::US4_0(
                                                            match &v104 {
                                                                Spiral_wasm::US4::US4_0(x) => {
                                                                    x.clone()
                                                                }
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => {
                                                        let v111: Spiral_wasm::US4 =
                                                            if (v62.clone()) == (v1.clone()) {
                                                                Spiral_wasm::US4::US4_0(
                                                                    Spiral_wasm::US5::US5_0,
                                                                )
                                                            } else {
                                                                Spiral_wasm::US4::US4_1
                                                            };
                                                        match &v111 {
                                                            Spiral_wasm::US4::US4_0(v111_0_0) => {
                                                                Spiral_wasm::US4::US4_0(
                                                                    match &v111 {
                                                                        Spiral_wasm::US4::US4_0(
                                                                            x,
                                                                        ) => x.clone(),
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                )
                                                            }
                                                            _ => {
                                                                let v118: Spiral_wasm::US4 =
                                                                    if (v48.clone()) == (v1.clone())
                                                                    {
                                                                        Spiral_wasm::US4::US4_0(
                                                                            Spiral_wasm::US5::US5_1,
                                                                        )
                                                                    } else {
                                                                        Spiral_wasm::US4::US4_1
                                                                    };
                                                                match &v118 {
                                                                 Spiral_wasm::US4::US4_0(v118_0_0)
                                                                 =>
                                                                 Spiral_wasm::US4::US4_0(match &v118
                                                                                             {
                                                                                             Spiral_wasm::US4::US4_0(x)
                                                                                             =>
                                                                                             x.clone(),
                                                                                             _
                                                                                             =>
                                                                                             unreachable!(),
                                                                                         }.clone()),
                                                                 _ => {
                                                                     let v125:
                                                                             Spiral_wasm::US4 =
                                                                         if (v34.clone())
                                                                                ==
                                                                                (v1.clone())
                                                                            {
                                                                             Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_2)
                                                                         } else {
                                                                             Spiral_wasm::US4::US4_1
                                                                         };
                                                                     match &v125
                                                                         {
                                                                         Spiral_wasm::US4::US4_0(v125_0_0)
                                                                         =>
                                                                         Spiral_wasm::US4::US4_0(match &v125
                                                                                                     {
                                                                                                     Spiral_wasm::US4::US4_0(x)
                                                                                                     =>
                                                                                                     x.clone(),
                                                                                                     _
                                                                                                     =>
                                                                                                     unreachable!(),
                                                                                                 }.clone()),
                                                                         _ =>
                                                                         {
                                                                             let v132:
                                                                                     Spiral_wasm::US4 =
                                                                                 if (v20.clone())
                                                                                        ==
                                                                                        (v1.clone())
                                                                                    {
                                                                                     Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_3)
                                                                                 } else {
                                                                                     Spiral_wasm::US4::US4_1
                                                                                 };
                                                                             match &v132
                                                                                 {
                                                                                 Spiral_wasm::US4::US4_0(v132_0_0)
                                                                                 =>
                                                                                 Spiral_wasm::US4::US4_0(match &v132
                                                                                                             {
                                                                                                             Spiral_wasm::US4::US4_0(x)
                                                                                                             =>
                                                                                                             x.clone(),
                                                                                                             _
                                                                                                             =>
                                                                                                             unreachable!(),
                                                                                                         }.clone()),
                                                                                 _
                                                                                 =>
                                                                                 {
                                                                                     let v139:
                                                                                             Spiral_wasm::US4 =
                                                                                         if (v6.clone())
                                                                                                ==
                                                                                                (v1.clone())
                                                                                            {
                                                                                             Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_4)
                                                                                         } else {
                                                                                             Spiral_wasm::US4::US4_1
                                                                                         };
                                                                                     match &v139
                                                                                         {
                                                                                         Spiral_wasm::US4::US4_0(v139_0_0)
                                                                                         =>
                                                                                         Spiral_wasm::US4::US4_0(match &v139
                                                                                                                     {
                                                                                                                     Spiral_wasm::US4::US4_0(x)
                                                                                                                     =>
                                                                                                                     x.clone(),
                                                                                                                     _
                                                                                                                     =>
                                                                                                                     unreachable!(),
                                                                                                                 }.clone()),
                                                                                         _
                                                                                         =>
                                                                                         Spiral_wasm::US4::US4_1,
                                                                                     }
                                                                                 }
                                                                             }
                                                                         }
                                                                     }
                                                                 }
                                                             }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                if (Spiral_wasm::method5(string("AUTOMATION"))) != string("True") {
                    Spiral_wasm::US6::US6_1
                } else {
                    let v232: i64 = {
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    };
                    let v377: Spiral_wasm::US10 = try_catch(
                        || Spiral_wasm::closure10((), Spiral_wasm::closure9(v232, ())),
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
                    );
                    let v396: Spiral_wasm::US6 = match &v377 {
                        Spiral_wasm::US10::US10_0(v377_0_0) => {
                            Spiral_wasm::US6::US6_0(v377_0_0.clone())
                        }
                        _ => Spiral_wasm::US6::US6_1,
                    };
                    Spiral_wasm::US6::US6_0(match &v396 {
                        Spiral_wasm::US6::US6_0(v396_0_0) => match &v396 {
                            Spiral_wasm::US6::US6_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    })
                },
            )
        }
        pub fn closure12(unitVar: (), v0_1: string) {
            ();
        }
        pub fn method3(
            v0_1: Spiral_wasm::US5,
        ) -> (
            LrcPtr<Spiral_wasm::Mut0>,
            LrcPtr<Spiral_wasm::Mut1>,
            LrcPtr<Spiral_wasm::Mut2>,
            LrcPtr<Spiral_wasm::Mut3>,
            LrcPtr<Spiral_wasm::Mut4>,
            Option<i64>,
        ) {
            let patternInput: (Spiral_wasm::US4, Spiral_wasm::US6) = Spiral_wasm::method4();
            let _run_target_args__v3: (Spiral_wasm::US4, Spiral_wasm::US6) =
                (patternInput.0.clone(), patternInput.1.clone());
            let v395: Spiral_wasm::US6 = _run_target_args__v3.1.clone();
            let v394: Spiral_wasm::US4 = _run_target_args__v3.0.clone();
            (
                LrcPtr::new(Spiral_wasm::Mut0 {
                    l0: MutCell::new(1_i64),
                }),
                LrcPtr::new(Spiral_wasm::Mut1 {
                    l0: MutCell::new(Func1::new(move |v: string| Spiral_wasm::closure12((), v))),
                }),
                LrcPtr::new(Spiral_wasm::Mut2 {
                    l0: MutCell::new(true),
                }),
                LrcPtr::new(Spiral_wasm::Mut3 {
                    l0: MutCell::new(string("")),
                }),
                LrcPtr::new(Spiral_wasm::Mut4 {
                    l0: MutCell::new(match &v394 {
                        Spiral_wasm::US4::US4_0(v394_0_0) => match &v394 {
                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => v0_1.clone(),
                    }),
                }),
                match &v395 {
                    Spiral_wasm::US6::US6_0(v395_0_0) => Some(match &v395 {
                        Spiral_wasm::US6::US6_0(x) => x.clone(),
                        _ => unreachable!(),
                    }),
                    _ => None::<i64>,
                },
            )
        }
        pub fn closure7(v0_1: Spiral_wasm::US5, unitVar: ()) {
            if Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .is_none()
            {
                let patternInput: (
                    LrcPtr<Spiral_wasm::Mut0>,
                    LrcPtr<Spiral_wasm::Mut1>,
                    LrcPtr<Spiral_wasm::Mut2>,
                    LrcPtr<Spiral_wasm::Mut3>,
                    LrcPtr<Spiral_wasm::Mut4>,
                    Option<i64>,
                ) = Spiral_wasm::method3(v0_1);
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
        pub fn closure14(unitVar: (), unitVar_1: ()) {
            if Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .is_none()
            {
                let patternInput: (
                    LrcPtr<Spiral_wasm::Mut0>,
                    LrcPtr<Spiral_wasm::Mut1>,
                    LrcPtr<Spiral_wasm::Mut2>,
                    LrcPtr<Spiral_wasm::Mut3>,
                    LrcPtr<Spiral_wasm::Mut4>,
                    Option<i64>,
                ) = Spiral_wasm::method3(Spiral_wasm::US5::US5_0);
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
        pub fn closure15(unitVar: (), v0_1: i64) -> Spiral_wasm::US6 {
            Spiral_wasm::US6::US6_0(v0_1)
        }
        pub fn method10() -> Func1<i64, Spiral_wasm::US6> {
            Func1::new(move |v: i64| Spiral_wasm::closure15((), v))
        }
        pub fn method11() -> string {
            string("hh:mm:ss")
        }
        pub fn method12() -> string {
            string("HH:mm:ss")
        }
        pub fn method9(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
        ) -> string {
            let v657: Spiral_wasm::US6 =
                defaultValue(Spiral_wasm::US6::US6_1, map(Spiral_wasm::method10(), v5));
            let v1154: DateTime = match &v657 {
                Spiral_wasm::US6::US6_0(v657_0_0) => {
                    let v722: i64 = {
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    };
                    let v867: Spiral_wasm::US10 = try_catch(
                        || Spiral_wasm::closure10((), Spiral_wasm::closure9(v722, ())),
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
                    );
                    let v886: Spiral_wasm::US6 = match &v867 {
                        Spiral_wasm::US10::US10_0(v867_0_0) => {
                            Spiral_wasm::US6::US6_0(v867_0_0.clone())
                        }
                        _ => Spiral_wasm::US6::US6_1,
                    };
                    let v1000: TimeSpan = TimeSpan::new_ticks(
                        (match &v886 {
                            Spiral_wasm::US6::US6_0(v886_0_0) => match &v886 {
                                Spiral_wasm::US6::US6_0(x) => x.clone(),
                                _ => unreachable!(),
                            },
                            _ => panic!("{}", string("Option does not have a value."),),
                        }) - (match &v657 {
                            Spiral_wasm::US6::US6_0(x) => x.clone(),
                            _ => unreachable!(),
                        }),
                    );
                    DateTime::new_ymdhms_milli(
                        1_i32,
                        1_i32,
                        1_i32,
                        v1000.hours(),
                        v1000.minutes(),
                        v1000.seconds(),
                        v1000.milliseconds(),
                    )
                }
                _ => DateTime::now(),
            };
            let v1155: string = Spiral_wasm::method11();
            let provider: string = if (v1155.clone()) == string("") {
                string("M-d-y hh:mm:ss tt")
            } else {
                v1155
            };
            v1154.toString(provider)
        }
        pub fn method15() -> string {
            string("")
        }
        pub fn method16(v0_1: LrcPtr<Spiral_wasm::Mut3>, v1: string) {
            let v4: string = append((v0_1.l0.get().clone()), (v1));
            v0_1.l0.set(v4);
            ()
        }
        pub fn method14(v0_1: char) -> string {
            let v10: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method16(v10.clone(), sprintf!("{}", v0_1));
            v10.l0.get().clone()
        }
        pub fn method13() -> string {
            let v3: &str = inline_colorization::color_bright_black;
            let v17: std::string::String = String::from(v3);
            let v293: string = append(
                (fable_library_rust::String_::fromString(v17)),
                (Spiral_wasm::method14(getCharAt(toLower(string("Verbose")), 0_i32))),
            );
            let v306: &str = inline_colorization::color_reset;
            let v320: std::string::String = String::from(v306);
            append((v293), (fable_library_rust::String_::fromString(v320)))
        }
        pub fn method19(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("{ "));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method20(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("args"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method21(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string(" = "));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method22(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string(" }"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method18(v0_1: Array<string>) -> string {
            let v10: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v10.clone());
            Spiral_wasm::method20(v10.clone());
            Spiral_wasm::method21(v10.clone());
            Spiral_wasm::method16(v10.clone(), sprintf!("{:?}", v0_1));
            Spiral_wasm::method22(v10.clone());
            v10.l0.get().clone()
        }
        pub fn method25(v0_1: char, v1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1: MutCell<i64> = MutCell::new(v1);
            '_method25: loop {
                break '_method25 (if (v1.get().clone()) >= 4_i64 {
                    false
                } else {
                    let v19: Spiral_wasm::US12 = if (v1.get().clone()) == 0_i64 {
                        Spiral_wasm::US12::US12_0(' ')
                    } else {
                        let v5: i64 = (v1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral_wasm::US12::US12_0('\t')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            if (v8) == 0_i64 {
                                Spiral_wasm::US12::US12_0('\r')
                            } else {
                                let v11: i64 = (v8) - 1_i64;
                                if (v11) == 0_i64 {
                                    Spiral_wasm::US12::US12_0('\n')
                                } else {
                                    let v14: i64 = (v11) - 1_i64;
                                    Spiral_wasm::US12::US12_1
                                }
                            }
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v19 {
                            Spiral_wasm::US12::US12_0(v19_0_0) => match &v19 {
                                Spiral_wasm::US12::US12_0(x) => x.clone(),
                                _ => unreachable!(),
                            },
                            _ => panic!("{}", string("Option does not have a value."),),
                        })
                    {
                        true
                    } else {
                        let v0_1_temp: char = v0_1.get().clone();
                        let v1_temp: i64 = (v1.get().clone()) + 1_i64;
                        v0_1.set(v0_1_temp);
                        v1.set(v1_temp);
                        continue '_method25;
                    }
                });
            }
        }
        pub fn method24(v0_1: string, v1: i32, v2: i32) -> i32 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1: MutCell<i32> = MutCell::new(v1);
            let v2: MutCell<i32> = MutCell::new(v2);
            '_method24: loop {
                break '_method24 (if (v2.get().clone()) >= (v1.get().clone()) {
                    v1.get().clone()
                } else {
                    if Spiral_wasm::method25(getCharAt(v0_1.get().clone(), v2.get().clone()), 0_i64)
                    {
                        let v0_1_temp: string = v0_1.get().clone();
                        let v1_temp: i32 = v1.get().clone();
                        let v2_temp: i32 = (v2.get().clone()) + 1_i32;
                        v0_1.set(v0_1_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        continue '_method24;
                    } else {
                        v2.get().clone()
                    }
                });
            }
        }
        pub fn method27(v0_1: char, v1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1: MutCell<i64> = MutCell::new(v1);
            '_method27: loop {
                break '_method27 (if (v1.get().clone()) >= 2_i64 {
                    false
                } else {
                    let v11: Spiral_wasm::US12 = if (v1.get().clone()) == 0_i64 {
                        Spiral_wasm::US12::US12_0(' ')
                    } else {
                        let v5: i64 = (v1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral_wasm::US12::US12_0('/')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            Spiral_wasm::US12::US12_1
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v11 {
                            Spiral_wasm::US12::US12_0(v11_0_0) => match &v11 {
                                Spiral_wasm::US12::US12_0(x) => x.clone(),
                                _ => unreachable!(),
                            },
                            _ => panic!("{}", string("Option does not have a value."),),
                        })
                    {
                        true
                    } else {
                        let v0_1_temp: char = v0_1.get().clone();
                        let v1_temp: i64 = (v1.get().clone()) + 1_i64;
                        v0_1.set(v0_1_temp);
                        v1.set(v1_temp);
                        continue '_method27;
                    }
                });
            }
        }
        pub fn method26(v0_1: string, v1: i32) -> i32 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1: MutCell<i32> = MutCell::new(v1);
            '_method26: loop {
                break '_method26 (if (v1.get().clone()) <= 0_i32 {
                    0_i32
                } else {
                    let v3: i32 = (v1.get().clone()) - 1_i32;
                    if Spiral_wasm::method27(getCharAt(v0_1.get().clone(), v3), 0_i64) {
                        let v0_1_temp: string = v0_1.get().clone();
                        let v1_temp: i32 = v3;
                        v0_1.set(v0_1_temp);
                        v1.set(v1_temp);
                        continue '_method26;
                    } else {
                        v3
                    }
                });
            }
        }
        pub fn method23(v0_1: string) -> string {
            let v1: i32 = length(v0_1.clone());
            let v492: string = getSlice(
                v0_1.clone(),
                Some(Spiral_wasm::method24(v0_1, v1, 0_i32)),
                Some(v1),
            );
            getSlice(
                v492.clone(),
                Some(0_i32),
                Some(Spiral_wasm::method26(v492.clone(), length(v492))),
            )
        }
        pub fn method17(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: Array<string>,
        ) -> string {
            let v9: string = Spiral_wasm::method18(v8);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.main"),
                    )),
                    string(" / "),
                )),
                (v9),
            ))
        }
        pub fn closure16(v0_1: LrcPtr<Spiral_wasm::Mut0>, unitVar: ()) {
            let v2: i64 = (v0_1.l0.get().clone()) + 1_i64;
            v0_1.l0.set(v2);
            ()
        }
        pub fn closure18(v0_1: string, unitVar: ()) {
            printfn!("{0}", v0_1);
        }
        pub fn closure17(unitVar: (), v0_1: string) {
            let v22: () = {
                Spiral_wasm::closure18(v0_1, ());
                ()
            };
            ()
        }
        pub fn closure19(v0_1: usize, unitVar: ()) -> i32 {
            v0_1 as i32
        }
        pub fn closure20(unitVar: (), v0_1: i32) -> Spiral_wasm::US13 {
            Spiral_wasm::US13::US13_0(v0_1)
        }
        pub fn closure21(unitVar: (), v0_1: LrcPtr<Exception>) -> Spiral_wasm::US13 {
            Spiral_wasm::US13::US13_1(v0_1)
        }
        pub fn closure13(v0_1: Array<string>, unitVar: ()) {
            fn v31() {
                Spiral_wasm::closure14((), ());
            }
            let v32: () = {
                v31();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v110: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v741: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v110,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v148: () = {
                        v31();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v191: Option<i64> = patternInput_1.5.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v187: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v186: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v228: string = Spiral_wasm::method17(
                        v186.clone(),
                        v187.clone(),
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        Spiral_wasm::method9(v186, v187, v188, v189, v190, v191),
                        Spiral_wasm::method13(),
                        v0_1,
                    );
                    let v259: () = {
                        v31();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v298: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v297: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v341: () = {
                        Spiral_wasm::closure16(v297.clone(), ());
                        ()
                    };
                    println!("{}", v228.clone());
                    (v298.l0.get().clone())(v228);
                    Spiral_wasm::US11::US11_0(
                        v297,
                        v298,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method28() -> string {
            string("exception")
        }
        pub fn method31(v0_1: char, v1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1: MutCell<i64> = MutCell::new(v1);
            '_method31: loop {
                break '_method31 (if (v1.get().clone()) >= 1_i64 {
                    false
                } else {
                    let v7: Spiral_wasm::US12 = if (v1.get().clone()) == 0_i64 {
                        Spiral_wasm::US12::US12_0('\\')
                    } else {
                        let v5: i64 = (v1.get().clone()) - 1_i64;
                        Spiral_wasm::US12::US12_1
                    };
                    if (v0_1.get().clone())
                        == (match &v7 {
                            Spiral_wasm::US12::US12_0(v7_0_0) => match &v7 {
                                Spiral_wasm::US12::US12_0(x) => x.clone(),
                                _ => unreachable!(),
                            },
                            _ => panic!("{}", string("Option does not have a value."),),
                        })
                    {
                        true
                    } else {
                        let v0_1_temp: char = v0_1.get().clone();
                        let v1_temp: i64 = (v1.get().clone()) + 1_i64;
                        v0_1.set(v0_1_temp);
                        v1.set(v1_temp);
                        continue '_method31;
                    }
                });
            }
        }
        pub fn method30(v0_1: string, v1: i32, v2: i32) -> i32 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1: MutCell<i32> = MutCell::new(v1);
            let v2: MutCell<i32> = MutCell::new(v2);
            '_method30: loop {
                break '_method30 (if (v2.get().clone()) >= (v1.get().clone()) {
                    v1.get().clone()
                } else {
                    if Spiral_wasm::method31(getCharAt(v0_1.get().clone(), v2.get().clone()), 0_i64)
                    {
                        let v0_1_temp: string = v0_1.get().clone();
                        let v1_temp: i32 = v1.get().clone();
                        let v2_temp: i32 = (v2.get().clone()) + 1_i32;
                        v0_1.set(v0_1_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        continue '_method30;
                    } else {
                        v2.get().clone()
                    }
                });
            }
        }
        pub fn method32(v0_1: string, v1: i32) -> i32 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1: MutCell<i32> = MutCell::new(v1);
            '_method32: loop {
                break '_method32 (if (v1.get().clone()) <= 0_i32 {
                    0_i32
                } else {
                    let v3: i32 = (v1.get().clone()) - 1_i32;
                    if Spiral_wasm::method31(getCharAt(v0_1.get().clone(), v3), 0_i64) {
                        let v0_1_temp: string = v0_1.get().clone();
                        let v1_temp: i32 = v3;
                        v0_1.set(v0_1_temp);
                        v1.set(v1_temp);
                        continue '_method32;
                    } else {
                        v3
                    }
                });
            }
        }
        pub fn closure22(unitVar: (), v0_1: std::string::String) -> string {
            let v2: string = fable_library_rust::String_::fromString(v0_1);
            let v3: i32 = length(v2.clone());
            let v494: string = getSlice(
                v2.clone(),
                Some(Spiral_wasm::method30(v2, v3, 0_i32)),
                Some(v3),
            );
            getSlice(
                v494.clone(),
                Some(0_i32),
                Some(Spiral_wasm::method32(v494.clone(), length(v494))),
            )
        }
        pub fn method29() -> Func1<std::string::String, string> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure22((), v))
        }
        pub fn method34() -> string {
            string("wasm")
        }
        pub fn method37(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("wasm_path"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method36(v0_1: string) -> string {
            let v10: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v10.clone());
            Spiral_wasm::method37(v10.clone());
            Spiral_wasm::method21(v10.clone());
            Spiral_wasm::method16(v10.clone(), v0_1);
            Spiral_wasm::method22(v10.clone());
            v10.l0.get().clone()
        }
        pub fn method35(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: string,
        ) -> string {
            let v9: string = Spiral_wasm::method36(v8);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (v9),
            ))
        }
        pub fn closure23(v0_1: string, unitVar: ()) {
            fn v31() {
                Spiral_wasm::closure14((), ());
            }
            let v32: () = {
                v31();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v110: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v741: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v110,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v148: () = {
                        v31();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v191: Option<i64> = patternInput_1.5.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v187: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v186: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v228: string = Spiral_wasm::method35(
                        v186.clone(),
                        v187.clone(),
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        Spiral_wasm::method9(v186, v187, v188, v189, v190, v191),
                        Spiral_wasm::method13(),
                        v0_1,
                    );
                    let v259: () = {
                        v31();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v298: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v297: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v341: () = {
                        Spiral_wasm::closure16(v297.clone(), ());
                        ()
                    };
                    println!("{}", v228.clone());
                    (v298.l0.get().clone())(v228);
                    Spiral_wasm::US11::US11_0(
                        v297,
                        v298,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method42(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("retry"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method43(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("; "));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method44(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("worker"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method45(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("contract"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method41(
            v0_1: u8,
            v1: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v2: near_workspaces::Contract,
        ) -> string {
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v12.clone());
            Spiral_wasm::method42(v12.clone());
            Spiral_wasm::method21(v12.clone());
            Spiral_wasm::method16(v12.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method43(v12.clone());
            Spiral_wasm::method44(v12.clone());
            Spiral_wasm::method21(v12.clone());
            {
                let v346: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method16(v12.clone(), fable_library_rust::String_::fromString(v346));
                Spiral_wasm::method43(v12.clone());
                Spiral_wasm::method45(v12.clone());
                Spiral_wasm::method21(v12.clone());
                {
                    let v612: std::string::String = format!("{:#?}", v2);
                    Spiral_wasm::method16(
                        v12.clone(),
                        fable_library_rust::String_::fromString(v612),
                    );
                    Spiral_wasm::method22(v12.clone());
                    v12.l0.get().clone()
                }
            }
        }
        pub fn method40(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: u8,
            v9: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v10: near_workspaces::Contract,
        ) -> string {
            let v11: string = Spiral_wasm::method41(v8, v9, v10);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (v11),
            ))
        }
        pub fn closure24(
            v0_1: u8,
            v1: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v2: near_workspaces::Contract,
            unitVar: (),
        ) {
            fn v33() {
                Spiral_wasm::closure14((), ());
            }
            let v34: () = {
                v33();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v112: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v743: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v112,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v150: () = {
                        v33();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v193: Option<i64> = patternInput_1.5.clone();
                    let v192: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v191: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v230: string = Spiral_wasm::method40(
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        v192.clone(),
                        v193.clone(),
                        Spiral_wasm::method9(v188, v189, v190, v191, v192, v193),
                        Spiral_wasm::method13(),
                        v0_1,
                        v1,
                        v2,
                    );
                    let v261: () = {
                        v33();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v300: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v299: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v343: () = {
                        Spiral_wasm::closure16(v299.clone(), ());
                        ()
                    };
                    println!("{}", v230.clone());
                    (v300.l0.get().clone())(v230);
                    Spiral_wasm::US11::US11_0(
                        v299,
                        v300,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method48(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("result"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method47(v0_1: u8, v1: near_workspaces::result::ExecutionFinalResult) -> string {
            let v11: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v11.clone());
            Spiral_wasm::method42(v11.clone());
            Spiral_wasm::method21(v11.clone());
            Spiral_wasm::method16(v11.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method43(v11.clone());
            Spiral_wasm::method48(v11.clone());
            Spiral_wasm::method21(v11.clone());
            {
                let v345: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method16(v11.clone(), fable_library_rust::String_::fromString(v345));
                Spiral_wasm::method22(v11.clone());
                v11.l0.get().clone()
            }
        }
        pub fn method46(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: u8,
            v9: near_workspaces::result::ExecutionFinalResult,
        ) -> string {
            let v10: string = Spiral_wasm::method47(v8, v9);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (v10),
            ))
        }
        pub fn closure25(v0_1: u8, v1: near_workspaces::result::ExecutionFinalResult, unitVar: ()) {
            fn v32() {
                Spiral_wasm::closure14((), ());
            }
            let v33: () = {
                v32();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v111: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v742: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v111,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v149: () = {
                        v32();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v192: Option<i64> = patternInput_1.5.clone();
                    let v191: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v187: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v229: string = Spiral_wasm::method46(
                        v187.clone(),
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        v192.clone(),
                        Spiral_wasm::method9(v187, v188, v189, v190, v191, v192),
                        Spiral_wasm::method13(),
                        v0_1,
                        v1,
                    );
                    let v260: () = {
                        v32();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v299: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v298: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v342: () = {
                        Spiral_wasm::closure16(v298.clone(), ());
                        ()
                    };
                    println!("{}", v229.clone());
                    (v299.l0.get().clone())(v229);
                    Spiral_wasm::US11::US11_0(
                        v298,
                        v299,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn closure27(v0_1: std::string::String, unitVar: ()) {
            printfn!("{0}", v0_1);
        }
        pub fn closure26(unitVar: (), v0_1: std::string::String) {
            let v22: () = {
                Spiral_wasm::closure27(v0_1, ());
                ()
            };
            ()
        }
        pub fn closure28(unitVar: (), unitVar_1: ()) {
            fn v30() {
                Spiral_wasm::closure14((), ());
            }
            let v31: () = {
                v30();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v109: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v630: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    2_i32
                        >= (find(
                            v109,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v147: () = {
                        v30();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v186: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v185: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v229: () = {
                        Spiral_wasm::closure16(v185.clone(), ());
                        ()
                    };
                    println!("{}", string(" "));
                    (v186.l0.get().clone())(string(" "));
                    Spiral_wasm::US11::US11_0(
                        v185,
                        v186,
                        patternInput_1.2.clone(),
                        patternInput_1.3.clone(),
                        patternInput_1.4.clone(),
                        patternInput_1.5.clone(),
                    )
                };
            ()
        }
        pub fn method49() -> string {
            let v3: &str = inline_colorization::color_bright_green;
            let v17: std::string::String = String::from(v3);
            let v293: string = append(
                (fable_library_rust::String_::fromString(v17)),
                (Spiral_wasm::method14(getCharAt(toLower(string("Info")), 0_i32))),
            );
            let v306: &str = inline_colorization::color_reset;
            let v320: std::string::String = String::from(v306);
            append((v293), (fable_library_rust::String_::fromString(v320)))
        }
        pub fn method52(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("total_gas_burnt_usd"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method53(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("total_gas_burnt"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method51(v0_1: u8, v1: f64, v2: u64) -> string {
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v12.clone());
            Spiral_wasm::method42(v12.clone());
            Spiral_wasm::method21(v12.clone());
            Spiral_wasm::method16(v12.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method43(v12.clone());
            Spiral_wasm::method52(v12.clone());
            Spiral_wasm::method21(v12.clone());
            Spiral_wasm::method16(v12.clone(), sprintf!("{:+.6}", v1));
            Spiral_wasm::method43(v12.clone());
            Spiral_wasm::method53(v12.clone());
            Spiral_wasm::method21(v12.clone());
            Spiral_wasm::method16(v12.clone(), sprintf!("{}", v2));
            Spiral_wasm::method22(v12.clone());
            v12.l0.get().clone()
        }
        pub fn method50(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: u8,
            v9: f64,
            v10: u64,
        ) -> string {
            let v11: string = Spiral_wasm::method51(v8, v9, v10);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("near_workspaces.print_usd"),
                    )),
                    string(" / "),
                )),
                (v11),
            ))
        }
        pub fn closure29(v0_1: u8, v1: u64, v2: f64, unitVar: ()) {
            fn v33() {
                Spiral_wasm::closure14((), ());
            }
            let v34: () = {
                v33();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v112: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v743: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    2_i32
                        >= (find(
                            v112,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v150: () = {
                        v33();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v193: Option<i64> = patternInput_1.5.clone();
                    let v192: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v191: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v230: string = Spiral_wasm::method50(
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        v192.clone(),
                        v193.clone(),
                        Spiral_wasm::method9(v188, v189, v190, v191, v192, v193),
                        Spiral_wasm::method49(),
                        v0_1,
                        v2,
                        v1,
                    );
                    let v261: () = {
                        v33();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v300: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v299: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v343: () = {
                        Spiral_wasm::closure16(v299.clone(), ());
                        ()
                    };
                    println!("{}", v230.clone());
                    (v300.l0.get().clone())(v230);
                    Spiral_wasm::US11::US11_0(
                        v299,
                        v300,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method56(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("is_success"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method57(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("gas_burnt_usd"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method58(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("tokens_burnt_usd"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method59(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("gas_burnt"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method60(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("tokens_burnt"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method55(v0_1: bool, v1: f64, v2: f64, v3: u64, v4: u128) -> string {
            let v14: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v14.clone());
            Spiral_wasm::method56(v14.clone());
            Spiral_wasm::method21(v14.clone());
            Spiral_wasm::method16(
                v14.clone(),
                if v0_1 {
                    string("true")
                } else {
                    string("false")
                },
            );
            Spiral_wasm::method43(v14.clone());
            Spiral_wasm::method57(v14.clone());
            Spiral_wasm::method21(v14.clone());
            Spiral_wasm::method16(v14.clone(), sprintf!("{:+.6}", v1));
            Spiral_wasm::method43(v14.clone());
            Spiral_wasm::method58(v14.clone());
            Spiral_wasm::method21(v14.clone());
            Spiral_wasm::method16(v14.clone(), sprintf!("{:+.6}", v2));
            Spiral_wasm::method43(v14.clone());
            Spiral_wasm::method59(v14.clone());
            Spiral_wasm::method21(v14.clone());
            Spiral_wasm::method16(v14.clone(), sprintf!("{}", v3));
            Spiral_wasm::method43(v14.clone());
            Spiral_wasm::method60(v14.clone());
            Spiral_wasm::method21(v14.clone());
            {
                let v902: std::string::String = format!("{:#?}", v4);
                Spiral_wasm::method16(v14.clone(), fable_library_rust::String_::fromString(v902));
                Spiral_wasm::method22(v14.clone());
                v14.l0.get().clone()
            }
        }
        pub fn method54(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: bool,
            v9: f64,
            v10: f64,
            v11: u64,
            v12: u128,
        ) -> string {
            let v13: string = Spiral_wasm::method55(v8, v9, v10, v11, v12);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("near_workspaces.print_usd / outcome"),
                    )),
                    string(" / "),
                )),
                (v13),
            ))
        }
        pub fn closure31(v0_1: bool, v1: u64, v2: f64, v3: u128, v4: f64, unitVar: ()) {
            fn v35() {
                Spiral_wasm::closure14((), ());
            }
            let v36: () = {
                v35();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v114: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v745: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    2_i32
                        >= (find(
                            v114,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v152: () = {
                        v35();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v195: Option<i64> = patternInput_1.5.clone();
                    let v194: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v193: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v192: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v191: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v232: string = Spiral_wasm::method54(
                        v190.clone(),
                        v191.clone(),
                        v192.clone(),
                        v193.clone(),
                        v194.clone(),
                        v195.clone(),
                        Spiral_wasm::method9(v190, v191, v192, v193, v194, v195),
                        Spiral_wasm::method49(),
                        v0_1,
                        v2,
                        v4,
                        v1,
                        v3,
                    );
                    let v263: () = {
                        v35();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v302: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v301: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v345: () = {
                        Spiral_wasm::closure16(v301.clone(), ());
                        ()
                    };
                    println!("{}", v232.clone());
                    (v302.l0.get().clone())(v232);
                    Spiral_wasm::US11::US11_0(
                        v301,
                        v302,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn closure30(unitVar: (), v0_1: near_workspaces::result::ExecutionOutcome) {
            let v2: bool = v0_1.clone().is_success();
            let v4: near_workspaces::types::Gas = v0_1.clone().gas_burnt;
            let v6: u64 = v4.as_gas();
            let v20: f64 = ((v6 as f64) / 10000000000000000.0_f64) * 6.68_f64;
            let v22: near_workspaces::types::NearToken = v0_1.tokens_burnt;
            let v24: u128 = v22.as_yoctonear();
            let v808: () = {
                Spiral_wasm::closure31(
                    v2,
                    v6,
                    v20,
                    v24.clone(),
                    ((v24 as f64) / 1E+24_f64) * 6.68_f64,
                    (),
                );
                ()
            };
            ()
        }
        pub fn method63(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("result2"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method62(
            v0_1: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
        ) -> string {
            let v10: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v10.clone());
            Spiral_wasm::method63(v10.clone());
            Spiral_wasm::method21(v10.clone());
            {
                let v156: std::string::String = format!("{:#?}", v0_1);
                Spiral_wasm::method16(v10.clone(), fable_library_rust::String_::fromString(v156));
                Spiral_wasm::method22(v10.clone());
                v10.l0.get().clone()
            }
        }
        pub fn method61(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
        ) -> string {
            let v9: string = Spiral_wasm::method62(v8);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (v9),
            ))
        }
        pub fn closure32(
            v0_1: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
            unitVar: (),
        ) {
            fn v31() {
                Spiral_wasm::closure14((), ());
            }
            let v32: () = {
                v31();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v110: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v741: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v110,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v148: () = {
                        v31();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v191: Option<i64> = patternInput_1.5.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v187: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v186: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v228: string = Spiral_wasm::method61(
                        v186.clone(),
                        v187.clone(),
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        Spiral_wasm::method9(v186, v187, v188, v189, v190, v191),
                        Spiral_wasm::method13(),
                        v0_1,
                    );
                    let v259: () = {
                        v31();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v298: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v297: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v341: () = {
                        Spiral_wasm::closure16(v297.clone(), ());
                        ()
                    };
                    println!("{}", v228.clone());
                    (v298.l0.get().clone())(v228);
                    Spiral_wasm::US11::US11_0(
                        v297,
                        v298,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method64(
            v0_1: near_workspaces::result::ExecutionFinalResult,
        ) -> near_workspaces::result::ExecutionFinalResult {
            v0_1
        }
        pub fn method67(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("receipt_failures_len"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method68(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("receipt_failures"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method66(v0_1: i32, v1: Vec<&near_workspaces::result::ExecutionOutcome>) -> string {
            let v11: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v11.clone());
            Spiral_wasm::method67(v11.clone());
            Spiral_wasm::method21(v11.clone());
            Spiral_wasm::method16(v11.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method43(v11.clone());
            Spiral_wasm::method68(v11.clone());
            Spiral_wasm::method21(v11.clone());
            {
                let v345: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method16(v11.clone(), fable_library_rust::String_::fromString(v345));
                Spiral_wasm::method22(v11.clone());
                v11.l0.get().clone()
            }
        }
        pub fn method65(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: Vec<&near_workspaces::result::ExecutionOutcome>,
        ) -> string {
            let v10: string = Spiral_wasm::method66(v8, v9);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (v10),
            ))
        }
        pub fn closure33(
            v0_1: Vec<&near_workspaces::result::ExecutionOutcome>,
            v1: i32,
            unitVar: (),
        ) {
            fn v32() {
                Spiral_wasm::closure14((), ());
            }
            let v33: () = {
                v32();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v111: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v742: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v111,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v149: () = {
                        v32();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v192: Option<i64> = patternInput_1.5.clone();
                    let v191: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v187: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v229: string = Spiral_wasm::method65(
                        v187.clone(),
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        v192.clone(),
                        Spiral_wasm::method9(v187, v188, v189, v190, v191, v192),
                        Spiral_wasm::method13(),
                        v1,
                        v0_1,
                    );
                    let v260: () = {
                        v32();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v299: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v298: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v342: () = {
                        Spiral_wasm::closure16(v298.clone(), ());
                        ()
                    };
                    println!("{}", v229.clone());
                    (v299.l0.get().clone())(v229);
                    Spiral_wasm::US11::US11_0(
                        v298,
                        v299,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method69(
            v0_1: near_workspaces::result::ExecutionFinalResult,
        ) -> near_workspaces::result::ExecutionFinalResult {
            v0_1
        }
        pub fn method72(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("receipt_outcomes_len"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method73(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("receipt_outcomes"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method71(v0_1: i32, v1: Vec<near_workspaces::result::ExecutionOutcome>) -> string {
            let v11: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v11.clone());
            Spiral_wasm::method72(v11.clone());
            Spiral_wasm::method21(v11.clone());
            Spiral_wasm::method16(v11.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method43(v11.clone());
            Spiral_wasm::method73(v11.clone());
            Spiral_wasm::method21(v11.clone());
            {
                let v345: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method16(v11.clone(), fable_library_rust::String_::fromString(v345));
                Spiral_wasm::method22(v11.clone());
                v11.l0.get().clone()
            }
        }
        pub fn method70(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: Vec<near_workspaces::result::ExecutionOutcome>,
        ) -> string {
            let v10: string = Spiral_wasm::method71(v8, v9);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (v10),
            ))
        }
        pub fn closure34(
            v0_1: Vec<near_workspaces::result::ExecutionOutcome>,
            v1: i32,
            unitVar: (),
        ) {
            fn v32() {
                Spiral_wasm::closure14((), ());
            }
            let v33: () = {
                v32();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v111: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v742: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v111,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v149: () = {
                        v32();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v192: Option<i64> = patternInput_1.5.clone();
                    let v191: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v187: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v229: string = Spiral_wasm::method70(
                        v187.clone(),
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        v192.clone(),
                        Spiral_wasm::method9(v187, v188, v189, v190, v191, v192),
                        Spiral_wasm::method13(),
                        v1,
                        v0_1,
                    );
                    let v260: () = {
                        v32();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v299: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v298: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v342: () = {
                        Spiral_wasm::closure16(v298.clone(), ());
                        ()
                    };
                    println!("{}", v229.clone());
                    (v299.l0.get().clone())(v229);
                    Spiral_wasm::US11::US11_0(
                        v298,
                        v299,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method76(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("json"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method75(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v10: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v10.clone());
            Spiral_wasm::method76(v10.clone());
            Spiral_wasm::method21(v10.clone());
            {
                let v156: std::string::String = format!("{:#?}", v0_1);
                Spiral_wasm::method16(v10.clone(), fable_library_rust::String_::fromString(v156));
                Spiral_wasm::method22(v10.clone());
                v10.l0.get().clone()
            }
        }
        pub fn method74(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v9: string = Spiral_wasm::method75(v8);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (v9),
            ))
        }
        pub fn closure35(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            fn v31() {
                Spiral_wasm::closure14((), ());
            }
            let v32: () = {
                v31();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v110: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v741: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v110,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v148: () = {
                        v31();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v191: Option<i64> = patternInput_1.5.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v187: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v186: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v228: string = Spiral_wasm::method74(
                        v186.clone(),
                        v187.clone(),
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        Spiral_wasm::method9(v186, v187, v188, v189, v190, v191),
                        Spiral_wasm::method13(),
                        v0_1,
                    );
                    let v259: () = {
                        v31();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v298: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v297: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v341: () = {
                        Spiral_wasm::closure16(v297.clone(), ());
                        ()
                    };
                    println!("{}", v228.clone());
                    (v298.l0.get().clone())(v228);
                    Spiral_wasm::US11::US11_0(
                        v297,
                        v298,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method79(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("borsh"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method78(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v10: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v10.clone());
            Spiral_wasm::method79(v10.clone());
            Spiral_wasm::method21(v10.clone());
            {
                let v156: std::string::String = format!("{:#?}", v0_1);
                Spiral_wasm::method16(v10.clone(), fable_library_rust::String_::fromString(v156));
                Spiral_wasm::method22(v10.clone());
                v10.l0.get().clone()
            }
        }
        pub fn method77(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v9: string = Spiral_wasm::method78(v8);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (v9),
            ))
        }
        pub fn closure36(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            fn v31() {
                Spiral_wasm::closure14((), ());
            }
            let v32: () = {
                v31();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v110: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v741: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v110,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v148: () = {
                        v31();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v191: Option<i64> = patternInput_1.5.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v187: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v186: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v228: string = Spiral_wasm::method77(
                        v186.clone(),
                        v187.clone(),
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        Spiral_wasm::method9(v186, v187, v188, v189, v190, v191),
                        Spiral_wasm::method13(),
                        v0_1,
                    );
                    let v259: () = {
                        v31();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v298: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v297: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v341: () = {
                        Spiral_wasm::closure16(v297.clone(), ());
                        ()
                    };
                    println!("{}", v228.clone());
                    (v298.l0.get().clone())(v228);
                    Spiral_wasm::US11::US11_0(
                        v297,
                        v298,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method80(
            v0_1: i32,
            v1: u8,
            v2: Vec<&near_workspaces::result::ExecutionOutcome>,
        ) -> string {
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v12.clone());
            Spiral_wasm::method72(v12.clone());
            Spiral_wasm::method21(v12.clone());
            Spiral_wasm::method16(v12.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method43(v12.clone());
            Spiral_wasm::method42(v12.clone());
            Spiral_wasm::method21(v12.clone());
            Spiral_wasm::method16(v12.clone(), sprintf!("{}", v1));
            Spiral_wasm::method43(v12.clone());
            Spiral_wasm::method68(v12.clone());
            Spiral_wasm::method21(v12.clone());
            {
                let v534: std::string::String = format!("{:#?}", v2);
                Spiral_wasm::method16(v12.clone(), fable_library_rust::String_::fromString(v534));
                Spiral_wasm::method22(v12.clone());
                v12.l0.get().clone()
            }
        }
        pub fn method39(
            v0_1: Vec<u8>,
            v1: u8,
        ) -> std::pin::Pin<
            Box<dyn std::future::Future<Output = Result<Spiral_wasm::US9, anyhow::Error>>>,
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
                    > = Box::pin(v13.dev_deploy(&v0_1));
                    let v17: Result<near_workspaces::Contract, near_workspaces::error::Error> =
                        v15.await;
                    let v19: near_workspaces::Contract = v17?;
                    let v799: () = {
                        Spiral_wasm::closure24(v1, v11, v19.clone(), ());
                        ()
                    };
                    let v1586: near_workspaces::operations::CallTransaction =
                        v19.call(&*string("state_main"));
                    let v1588: near_workspaces::types::Gas =
                        near_workspaces::types::Gas::from_tgas(300);
                    let v1590: near_workspaces::operations::CallTransaction = v1586.gas(v1588);
                    let v1592: std::pin::Pin<
                        Box<
                            dyn std::future::Future<
                                    Output = Result<
                                        near_workspaces::result::ExecutionFinalResult,
                                        near_workspaces::error::Error,
                                    >,
                                >,
                        >,
                    > = Box::pin(v1590.transact());
                    let v1594: Result<
                        near_workspaces::result::ExecutionFinalResult,
                        near_workspaces::error::Error,
                    > = v1592.await;
                    let v1596: near_workspaces::result::ExecutionFinalResult = v1594?;
                    let v2376: () = {
                        Spiral_wasm::closure25(v1, v1596.clone(), ());
                        ()
                    };
                    let v3162: Vec<&str> = v1596.logs();
                    let v3164: bool = true;
                    let _vec_map: Vec<_> = v3162
                        .into_iter()
                        .map(|x| {
                            //;
                            let v3166: &str = x;
                            let v3180: std::string::String = String::from(v3166);
                            let v3253: bool = true;
                            v3180
                        })
                        .collect::<Vec<_>>();
                    let v3255: Vec<std::string::String> = _vec_map;
                    let v3258: bool = true;
                    v3255.iter().for_each(|x| {
                        Func1::new(move |v: std::string::String| Spiral_wasm::closure26((), v))(
                            x.clone(),
                        );
                    }); //;
                    let v3929: () = {
                        Spiral_wasm::closure28((), ());
                        ()
                    };
                    let v4605: near_workspaces::types::Gas = v1596.clone().total_gas_burnt;
                    let v4607: u64 = v4605.as_gas();
                    let v5401: () = {
                        Spiral_wasm::closure29(
                            v1,
                            v4607,
                            ((v4607 as f64) / 10000000000000000.0_f64) * 6.68_f64,
                            (),
                        );
                        ()
                    };
                    let v6187: near_workspaces::result::ExecutionFinalResult = v1596.clone();
                    let v6189: Vec<&near_workspaces::result::ExecutionOutcome> = v6187.outcomes();
                    let v6191 = v6189.into_iter();
                    let v6193 = v6191.cloned();
                    let v6196: bool = true;
                    v6193.for_each(|x| {
                        Func1::new(move |v_1: near_workspaces::result::ExecutionOutcome| {
                            Spiral_wasm::closure30((), v_1)
                        })(x)
                    });
                    let v6978: () = {
                        Spiral_wasm::closure32(v1596.clone().into_result(), ());
                        ()
                    };
                    let v7763: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method64(v1596.clone());
                    let v7765: Vec<&near_workspaces::result::ExecutionOutcome> =
                        v7763.receipt_failures();
                    let v7767: usize = v7765.clone().len();
                    fn v7856(v_2: i32) -> Spiral_wasm::US13 {
                        Spiral_wasm::closure20((), v_2)
                    }
                    fn v7857(v_3: Func0<LrcPtr<Exception>>) -> LrcPtr<Exception> {
                        Spiral_wasm::closure3((), v_3)
                    }
                    fn v7858(v_4: LrcPtr<Exception>) -> Spiral_wasm::US13 {
                        Spiral_wasm::closure21((), v_4)
                    }
                    let v7859: Spiral_wasm::US13 = try_catch(
                        || v7856(Spiral_wasm::closure19(v7767, ())),
                        |ex: LrcPtr<Exception>| {
                            v7858(v7857(Func0::new({
                                let ex = ex.clone();
                                move || ex.clone()
                            })))
                        },
                    );
                    let v7878: Spiral_wasm::US14 = match &v7859 {
                        Spiral_wasm::US13::US13_0(v7859_0_0) => {
                            Spiral_wasm::US14::US14_0(v7859_0_0.clone())
                        }
                        _ => Spiral_wasm::US14::US14_1,
                    };
                    let v7916: i32 = match &v7878 {
                        Spiral_wasm::US14::US14_0(v7878_0_0) => match &v7878 {
                            Spiral_wasm::US14::US14_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v8764: () = {
                        Spiral_wasm::closure33(v7765.clone(), v7916, ());
                        ()
                    };
                    let v9540: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method69(v1596.clone());
                    let v9542: &[near_workspaces::result::ExecutionOutcome] =
                        v9540.receipt_outcomes();
                    let v9544: Vec<near_workspaces::result::ExecutionOutcome> = v9542.into();
                    let v9546: usize = v9544.clone().len();
                    let v9629: Spiral_wasm::US13 = try_catch(
                        || v7856(Spiral_wasm::closure19(v9546, ())),
                        |ex_1: LrcPtr<Exception>| {
                            v7858(v7857(Func0::new({
                                let ex_1 = ex_1.clone();
                                move || ex_1.clone()
                            })))
                        },
                    );
                    let v9648: Spiral_wasm::US14 = match &v9629 {
                        Spiral_wasm::US13::US13_0(v9629_0_0) => {
                            Spiral_wasm::US14::US14_0(v9629_0_0.clone())
                        }
                        _ => Spiral_wasm::US14::US14_1,
                    };
                    let v9686: i32 = match &v9648 {
                        Spiral_wasm::US14::US14_0(v9648_0_0) => match &v9648 {
                            Spiral_wasm::US14::US14_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v10534: () = {
                        Spiral_wasm::closure34(v9544, v9686, ());
                        ()
                    };
                    let v12082: () = {
                        Spiral_wasm::closure35(v1596.clone().json(), ());
                        ()
                    };
                    let v13630: () = {
                        Spiral_wasm::closure36(v1596.borsh(), ());
                        ()
                    };
                    let v14406: string = Spiral_wasm::method80(v9686, v1, v7765);
                    let v14455: Result<Spiral_wasm::US9, anyhow::Error> = if (v7916) > 0_i32 {
                        Ok::<Spiral_wasm::US9, anyhow::Error>(Spiral_wasm::US9::US9_0(
                            v14406.clone(),
                        ))
                    } else {
                        if (v9686) > 1_i32 {
                            Ok::<Spiral_wasm::US9, anyhow::Error>(Spiral_wasm::US9::US9_1)
                        } else {
                            let v14438: anyhow::Error = anyhow::anyhow!(v14406);
                            Err(v14438)
                        }
                    };
                    let v14458: string = string("}");
                    let v14463: bool = true;
                    let _fix_closure_v14460 = v14455;
                    let v14469: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v14460 "), (v14458))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v14470: bool = true;
                    _fix_closure_v14460
                },
            ); // rust.fix_closure';
            let v14472 = __future_init;
            v14472
        }
        pub fn closure37(unitVar: (), v0_1: anyhow::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method81() -> Func1<anyhow::Error, std::string::String> {
            Func1::new(move |v: anyhow::Error| Spiral_wasm::closure37((), v))
        }
        pub fn closure38(unitVar: (), v0_1: Spiral_wasm::US9) -> Spiral_wasm::US16 {
            Spiral_wasm::US16::US16_0(v0_1)
        }
        pub fn method82() -> Func1<Spiral_wasm::US9, Spiral_wasm::US16> {
            Func1::new(move |v: Spiral_wasm::US9| Spiral_wasm::closure38((), v))
        }
        pub fn closure39(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US16 {
            Spiral_wasm::US16::US16_1(v0_1)
        }
        pub fn method83() -> Func1<std::string::String, Spiral_wasm::US16> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure39((), v))
        }
        pub fn method84() -> string {
            let v3: &str = inline_colorization::color_yellow;
            let v17: std::string::String = String::from(v3);
            let v293: string = append(
                (fable_library_rust::String_::fromString(v17)),
                (Spiral_wasm::method14(getCharAt(toLower(string("Warning")), 0_i32))),
            );
            let v306: &str = inline_colorization::color_reset;
            let v320: std::string::String = String::from(v306);
            append((v293), (fable_library_rust::String_::fromString(v320)))
        }
        pub fn method87(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("error"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method86(v0_1: u8, v1: std::string::String) -> string {
            let v11: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v11.clone());
            Spiral_wasm::method42(v11.clone());
            Spiral_wasm::method21(v11.clone());
            Spiral_wasm::method16(v11.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method43(v11.clone());
            Spiral_wasm::method87(v11.clone());
            Spiral_wasm::method21(v11.clone());
            {
                let v345: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method16(v11.clone(), fable_library_rust::String_::fromString(v345));
                Spiral_wasm::method22(v11.clone());
                v11.l0.get().clone()
            }
        }
        pub fn method85(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: u8,
            v9: std::string::String,
        ) -> string {
            let v10: string = Spiral_wasm::method86(v8, v9);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run / Error error"),
                    )),
                    string(" / "),
                )),
                (v10),
            ))
        }
        pub fn closure40(v0_1: u8, v1: std::string::String, unitVar: ()) {
            fn v32() {
                Spiral_wasm::closure14((), ());
            }
            let v33: () = {
                v32();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v111: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v742: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    3_i32
                        >= (find(
                            v111,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v149: () = {
                        v32();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v192: Option<i64> = patternInput_1.5.clone();
                    let v191: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v187: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v229: string = Spiral_wasm::method85(
                        v187.clone(),
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        v192.clone(),
                        Spiral_wasm::method9(v187, v188, v189, v190, v191, v192),
                        Spiral_wasm::method84(),
                        v0_1,
                        v1,
                    );
                    let v260: () = {
                        v32();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v299: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v298: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v342: () = {
                        Spiral_wasm::closure16(v298.clone(), ());
                        ()
                    };
                    println!("{}", v229.clone());
                    (v299.l0.get().clone())(v229);
                    Spiral_wasm::US11::US11_0(
                        v298,
                        v299,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn closure41(unitVar: (), unitVar_1: ()) {
            fn v30() {
                Spiral_wasm::closure14((), ());
            }
            let v31: () = {
                v30();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v109: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v628: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    3_i32
                        >= (find(
                            v109,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v147: () = {
                        v30();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v186: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v185: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v229: () = {
                        Spiral_wasm::closure16(v185.clone(), ());
                        ()
                    };
                    println!("{}", string("\n"));
                    (v186.l0.get().clone())(string("\n"));
                    Spiral_wasm::US11::US11_0(
                        v185,
                        v186,
                        patternInput_1.2.clone(),
                        patternInput_1.3.clone(),
                        patternInput_1.4.clone(),
                        patternInput_1.5.clone(),
                    )
                };
            ()
        }
        pub fn closure42(v0_1: u8, v1: std::string::String, unitVar: ()) {
            fn v32() {
                Spiral_wasm::closure14((), ());
            }
            let v33: () = {
                v32();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v111: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v742: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    3_i32
                        >= (find(
                            v111,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v149: () = {
                        v32();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v192: Option<i64> = patternInput_1.5.clone();
                    let v191: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v187: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v229: string = Spiral_wasm::method85(
                        v187.clone(),
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        v192.clone(),
                        Spiral_wasm::method9(v187, v188, v189, v190, v191, v192),
                        Spiral_wasm::method84(),
                        v0_1,
                        v1,
                    );
                    let v260: () = {
                        v32();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v299: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v298: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v342: () = {
                        Spiral_wasm::closure16(v298.clone(), ());
                        ()
                    };
                    println!("{}", v229.clone());
                    (v299.l0.get().clone())(v229);
                    Spiral_wasm::US11::US11_0(
                        v298,
                        v299,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn closure43(unitVar: (), unitVar_1: ()) {
            fn v30() {
                Spiral_wasm::closure14((), ());
            }
            let v31: () = {
                v30();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v109: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v628: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    3_i32
                        >= (find(
                            v109,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v147: () = {
                        v30();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v186: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v185: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v229: () = {
                        Spiral_wasm::closure16(v185.clone(), ());
                        ()
                    };
                    println!("{}", string("\n"));
                    (v186.l0.get().clone())(string("\n"));
                    Spiral_wasm::US11::US11_0(
                        v185,
                        v186,
                        patternInput_1.2.clone(),
                        patternInput_1.3.clone(),
                        patternInput_1.4.clone(),
                        patternInput_1.5.clone(),
                    )
                };
            ()
        }
        pub fn method88() -> string {
            let v3: &str = inline_colorization::color_bright_red;
            let v17: std::string::String = String::from(v3);
            let v293: string = append(
                (fable_library_rust::String_::fromString(v17)),
                (Spiral_wasm::method14(getCharAt(toLower(string("Critical")), 0_i32))),
            );
            let v306: &str = inline_colorization::color_reset;
            let v320: std::string::String = String::from(v306);
            append((v293), (fable_library_rust::String_::fromString(v320)))
        }
        pub fn method90(v0_1: u8, v1: string) -> string {
            let v11: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v11.clone());
            Spiral_wasm::method42(v11.clone());
            Spiral_wasm::method21(v11.clone());
            Spiral_wasm::method16(v11.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method43(v11.clone());
            Spiral_wasm::method87(v11.clone());
            Spiral_wasm::method21(v11.clone());
            Spiral_wasm::method16(v11.clone(), v1);
            Spiral_wasm::method22(v11.clone());
            v11.l0.get().clone()
        }
        pub fn method89(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: u8,
            v9: string,
        ) -> string {
            let v10: string = Spiral_wasm::method90(v8, v9);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run / Ok (Some error)"),
                    )),
                    string(" / "),
                )),
                (v10),
            ))
        }
        pub fn closure44(v0_1: u8, v1: string, unitVar: ()) {
            fn v32() {
                Spiral_wasm::closure14((), ());
            }
            let v33: () = {
                v32();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v111: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v742: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    4_i32
                        >= (find(
                            v111,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v149: () = {
                        v32();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v192: Option<i64> = patternInput_1.5.clone();
                    let v191: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v187: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v229: string = Spiral_wasm::method89(
                        v187.clone(),
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        v192.clone(),
                        Spiral_wasm::method9(v187, v188, v189, v190, v191, v192),
                        Spiral_wasm::method88(),
                        v0_1,
                        v1,
                    );
                    let v260: () = {
                        v32();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v299: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v298: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v342: () = {
                        Spiral_wasm::closure16(v298.clone(), ());
                        ()
                    };
                    println!("{}", v229.clone());
                    (v299.l0.get().clone())(v229);
                    Spiral_wasm::US11::US11_0(
                        v298,
                        v299,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method38(
            v0_1: Vec<u8>,
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
                                    Output = Result<Spiral_wasm::US9, anyhow::Error>,
                                >,
                        >,
                    > = Spiral_wasm::method39(v0_1.clone(), v1);
                    let v10: Result<Spiral_wasm::US9, anyhow::Error> = v8.await;
                    let v11 = Spiral_wasm::method81();
                    let v24: Result<Spiral_wasm::US9, std::string::String> =
                        v10.map_err(|x| v11(x));
                    let v27 = Spiral_wasm::method82();
                    let v28 = Spiral_wasm::method83();
                    let v30: Spiral_wasm::US16 = match &v24 {
                        Err(v24_1_0) => v28(v24_1_0.clone()),
                        Ok(v24_0_0) => v27(v24_0_0.clone()),
                    };
                    let v7522: Spiral_wasm::US15 = match &v30 {
                        Spiral_wasm::US16::US16_0(v30_0_0) => {
                            let v46: Spiral_wasm::US9 = v30_0_0.clone();
                            match &v46 {
                                Spiral_wasm::US9::US9_0(v46_0_0) => {
                                    let v77: string = match &v46 {
                                        Spiral_wasm::US9::US9_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone();
                                    let v857: () = {
                                        Spiral_wasm::closure44(v1, v77.clone(), ());
                                        ()
                                    };
                                    let v1643: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v1645: bool = */
                                        async move {
                                            /*;
                                            let v1647: bool = */
                                            ();
                                            let v1650: string = string("}");
                                            let v1656: bool = true;
                                            let _fix_closure_v1653 =
                                                (v1, Spiral_wasm::US9::US9_0(v77));
                                            let v1662: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v1653 "),
                                                            (v1650),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v1663: bool = true;
                                            _fix_closure_v1653
                                        },
                                    ); // rust.fix_closure';
                                    let v1665 = __future_init;
                                    let v1667: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<Output = (u8, Spiral_wasm::US9)>,
                                        >,
                                    > = v1665;
                                    let patternInput_2: (u8, Spiral_wasm::US9) = v1667.await;
                                    Spiral_wasm::US15::US15_1(
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone(),
                                    )
                                }
                                _ => {
                                    let v48: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v50: bool = */
                                        async move {
                                            /*;
                                            let v52: bool = */
                                            ();
                                            let v55: string = string("}");
                                            let v61: bool = true;
                                            let _fix_closure_v58 = (v1, Spiral_wasm::US9::US9_1);
                                            let v67: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v58 "),
                                                            (v55),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v68: bool = true;
                                            _fix_closure_v58
                                        },
                                    ); // rust.fix_closure';
                                    let v70 = __future_init;
                                    let v72: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<Output = (u8, Spiral_wasm::US9)>,
                                        >,
                                    > = v70;
                                    let patternInput_1: (u8, Spiral_wasm::US9) = v72.await;
                                    Spiral_wasm::US15::US15_0(
                                        patternInput_1.0.clone(),
                                        patternInput_1.1.clone(),
                                    )
                                }
                            }
                        }
                        Spiral_wasm::US16::US16_1(v30_1_0) => {
                            let v1674: std::string::String = v30_1_0.clone();
                            if (v1) >= 15_u8 {
                                let v2455: () = {
                                    Spiral_wasm::closure40(v1, v1674.clone(), ());
                                    ()
                                };
                                let v3908: () = {
                                    Spiral_wasm::closure41((), ());
                                    ()
                                };
                                let v4582: bool = true;
                                let __future_init = Box::pin(
                                    /*;
                                    let v4584: bool = */
                                    async move {
                                        /*;
                                        let v4586: bool = */
                                        ();
                                        let v4589: string = string("}");
                                        let v4595: bool = true;
                                        let _fix_closure_v4592 = (v1, Spiral_wasm::US9::US9_1);
                                        let v4601: string = append(
                                            (append(
                                                (append(
                                                    (append(
                                                        string("true; _fix_closure_v4592 "),
                                                        (v4589),
                                                    )),
                                                    string("); "),
                                                )),
                                                string(""),
                                            )),
                                            string(" // rust.fix_closure\'"),
                                        );
                                        let v4602: bool = true;
                                        _fix_closure_v4592
                                    },
                                ); // rust.fix_closure';
                                let v4604 = __future_init;
                                let v4606: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = (u8, Spiral_wasm::US9)>>,
                                > = v4604;
                                let patternInput: (u8, Spiral_wasm::US9) = v4606.await;
                                Spiral_wasm::US15::US15_0(
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                )
                            } else {
                                let v5390: () = {
                                    Spiral_wasm::closure42(v1, v1674, ());
                                    ()
                                };
                                let v6843: () = {
                                    Spiral_wasm::closure43((), ());
                                    ()
                                };
                                let v7517: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = Spiral_wasm::US15>>,
                                > = Spiral_wasm::method38(v0_1.clone(), (v1) + 1_u8);
                                v7517.await
                            }
                        }
                    };
                    let v7525: string = string("}");
                    let v7530: bool = true;
                    let _fix_closure_v7527 = v7522;
                    let v7536: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v7527 "), (v7525))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v7537: bool = true;
                    _fix_closure_v7527
                },
            ); // rust.fix_closure';
            let v7539 = __future_init;
            v7539
        }
        pub fn method93(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("retries"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method92(v0_1: Spiral_wasm::US15) -> string {
            let v10: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v10.clone());
            Spiral_wasm::method93(v10.clone());
            Spiral_wasm::method21(v10.clone());
            Spiral_wasm::method16(v10.clone(), sprintf!("{:?}", v0_1));
            Spiral_wasm::method22(v10.clone());
            v10.l0.get().clone()
        }
        pub fn method91(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: Spiral_wasm::US15,
        ) -> string {
            let v9: string = Spiral_wasm::method92(v8);
            Spiral_wasm::method23(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                                (toString(v0_1.l0.get().clone())),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (v9),
            ))
        }
        pub fn closure45(v0_1: Spiral_wasm::US15, unitVar: ()) {
            fn v31() {
                Spiral_wasm::closure14((), ());
            }
            let v32: () = {
                v31();
                ()
            };
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v110: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v741: Spiral_wasm::US11 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v110,
                            ofSeq(ofList(ofArray(new_array(&[
                                LrcPtr::new((Spiral_wasm::US5::US5_0, 0_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_1, 1_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_2, 2_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_3, 3_i32)),
                                LrcPtr::new((Spiral_wasm::US5::US5_4, 4_i32)),
                            ])))),
                        ))
                }) == false
                {
                    Spiral_wasm::US11::US11_1
                } else {
                    let v148: () = {
                        v31();
                        ()
                    };
                    let patternInput_1: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v191: Option<i64> = patternInput_1.5.clone();
                    let v190: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v189: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v188: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v187: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v186: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v228: string = Spiral_wasm::method91(
                        v186.clone(),
                        v187.clone(),
                        v188.clone(),
                        v189.clone(),
                        v190.clone(),
                        v191.clone(),
                        Spiral_wasm::method9(v186, v187, v188, v189, v190, v191),
                        Spiral_wasm::method13(),
                        v0_1,
                    );
                    let v259: () = {
                        v31();
                        ()
                    };
                    let patternInput_2: (
                        LrcPtr<Spiral_wasm::Mut0>,
                        LrcPtr<Spiral_wasm::Mut1>,
                        LrcPtr<Spiral_wasm::Mut2>,
                        LrcPtr<Spiral_wasm::Mut3>,
                        LrcPtr<Spiral_wasm::Mut4>,
                        Option<i64>,
                    ) = Spiral_wasm::TraceState::trace_state()
                        .get()
                        .clone()
                        .unwrap();
                    let v298: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v297: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v341: () = {
                        Spiral_wasm::closure16(v297.clone(), ());
                        ()
                    };
                    println!("{}", v228.clone());
                    (v298.l0.get().clone())(v228);
                    Spiral_wasm::US11::US11_0(
                        v297,
                        v298,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ()
        }
        pub fn method94(v0_1: Spiral_wasm::US15, v1: Spiral_wasm::US9) -> string {
            let v11: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            Spiral_wasm::method19(v11.clone());
            Spiral_wasm::method93(v11.clone());
            Spiral_wasm::method21(v11.clone());
            Spiral_wasm::method16(v11.clone(), sprintf!("{:?}", v0_1));
            Spiral_wasm::method43(v11.clone());
            Spiral_wasm::method87(v11.clone());
            Spiral_wasm::method21(v11.clone());
            Spiral_wasm::method16(v11.clone(), sprintf!("{:?}", v1));
            Spiral_wasm::method22(v11.clone());
            v11.l0.get().clone()
        }
        pub fn method33(
            v0_1: clap::ArgMatches,
        ) -> std::pin::Pin<Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>>
        {
            let v2: bool = true;
            let __future_init = Box::pin(
                /*;
                let v4: bool = */
                async move {
                    /*;
                    let v6: bool = */
                    ();
                    let v7: string = Spiral_wasm::method34();
                    let v21: &str = &*v7;
                    let v94: Option<std::string::String> =
                        clap::ArgMatches::get_one(&v0_1, v21).cloned();
                    let v156: Spiral_wasm::US2 =
                        defaultValue(Spiral_wasm::US2::US2_1, map(Spiral_wasm::method2(), v94));
                    let v170: std::string::String = match &v156 {
                        Spiral_wasm::US2::US2_0(v156_0_0) => match &v156 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v172: string = fable_library_rust::String_::fromString(v170);
                    let v952: () = {
                        Spiral_wasm::closure23(v172.clone(), ());
                        ()
                    };
                    let v1738: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v172);
                    let v1742: std::pin::Pin<
                        Box<dyn std::future::Future<Output = Spiral_wasm::US15>>,
                    > = Spiral_wasm::method38(v1738?, 1_u8);
                    let v1744: Spiral_wasm::US15 = v1742.await;
                    let v2524: () = {
                        Spiral_wasm::closure45(v1744.clone(), ());
                        ()
                    };
                    let v3343: Result<u8, anyhow::Error> = match &v1744 {
                        Spiral_wasm::US15::US15_0(v1744_0_0, v1744_0_1) => {
                            Ok::<u8, anyhow::Error>(v1744_0_0.clone())
                        }
                        Spiral_wasm::US15::US15_1(v1744_1_0, v1744_1_1) => {
                            let v3324: string =
                                Spiral_wasm::method94(v1744.clone(), v1744_1_1.clone());
                            let v3326: anyhow::Error = anyhow::anyhow!(v3324);
                            Err(v3326)
                        }
                    };
                    let v3346: string = string("}");
                    let v3351: bool = true;
                    let _fix_closure_v3348 = v3343;
                    let v3357: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v3348 "), (v3346))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v3358: bool = true;
                    _fix_closure_v3348
                },
            ); // rust.fix_closure';
            let v3360 = __future_init;
            v3360
        }
        pub fn closure46(unitVar: (), v0_1: u8) -> Spiral_wasm::US17 {
            Spiral_wasm::US17::US17_0(v0_1)
        }
        pub fn method95() -> Func1<u8, Spiral_wasm::US17> {
            Func1::new(move |v: u8| Spiral_wasm::closure46((), v))
        }
        pub fn closure47(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US17 {
            Spiral_wasm::US17::US17_1(v0_1)
        }
        pub fn method96() -> Func1<std::string::String, Spiral_wasm::US17> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure47((), v))
        }
        pub fn closure0(unitVar: (), v0_1: Array<string>) -> i32 {
            let v1: clap::Command = Spiral_wasm::method0();
            let v3: clap::ArgMatches = clap::Command::get_matches(v1);
            let v4: string = Spiral_wasm::method1();
            let v18: &str = &*v4;
            let v91: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v18).cloned();
            let v153: Spiral_wasm::US2 =
                defaultValue(Spiral_wasm::US2::US2_1, map(Spiral_wasm::method2(), v91));
            let v331: Spiral_wasm::US3 = match &v153 {
                Spiral_wasm::US2::US2_0(v153_0_0) => {
                    let v166: string = fable_library_rust::String_::fromString(
                        match &v153 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    );
                    let v171: string = toLower(string("Critical"));
                    let v185: string = toLower(string("Warning"));
                    let v199: string = toLower(string("Info"));
                    let v213: string = toLower(string("Debug"));
                    let v227: string = toLower(string("Verbose"));
                    let v241: Spiral_wasm::US4 = if string("Verbose") == (v166.clone()) {
                        Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_0)
                    } else {
                        Spiral_wasm::US4::US4_1
                    };
                    Spiral_wasm::US3::US3_0(match &v241 {
                        Spiral_wasm::US4::US4_0(v241_0_0) => Spiral_wasm::US4::US4_0(
                            match &v241 {
                                Spiral_wasm::US4::US4_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v248: Spiral_wasm::US4 = if string("Debug") == (v166.clone()) {
                                Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_1)
                            } else {
                                Spiral_wasm::US4::US4_1
                            };
                            match &v248 {
                                Spiral_wasm::US4::US4_0(v248_0_0) => Spiral_wasm::US4::US4_0(
                                    match &v248 {
                                        Spiral_wasm::US4::US4_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v255: Spiral_wasm::US4 = if string("Info") == (v166.clone())
                                    {
                                        Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_2)
                                    } else {
                                        Spiral_wasm::US4::US4_1
                                    };
                                    match &v255 {
                                        Spiral_wasm::US4::US4_0(v255_0_0) => {
                                            Spiral_wasm::US4::US4_0(
                                                match &v255 {
                                                    Spiral_wasm::US4::US4_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            )
                                        }
                                        _ => {
                                            let v262: Spiral_wasm::US4 =
                                                if string("Warning") == (v166.clone()) {
                                                    Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_3)
                                                } else {
                                                    Spiral_wasm::US4::US4_1
                                                };
                                            match &v262 {
                                                Spiral_wasm::US4::US4_0(v262_0_0) => {
                                                    Spiral_wasm::US4::US4_0(
                                                        match &v262 {
                                                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => {
                                                    let v269: Spiral_wasm::US4 =
                                                        if string("Critical") == (v166.clone()) {
                                                            Spiral_wasm::US4::US4_0(
                                                                Spiral_wasm::US5::US5_4,
                                                            )
                                                        } else {
                                                            Spiral_wasm::US4::US4_1
                                                        };
                                                    match &v269 {
                                                        Spiral_wasm::US4::US4_0(v269_0_0) => {
                                                            Spiral_wasm::US4::US4_0(
                                                                match &v269 {
                                                                    Spiral_wasm::US4::US4_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            let v276: Spiral_wasm::US4 =
                                                                if (v227.clone()) == (v166.clone())
                                                                {
                                                                    Spiral_wasm::US4::US4_0(
                                                                        Spiral_wasm::US5::US5_0,
                                                                    )
                                                                } else {
                                                                    Spiral_wasm::US4::US4_1
                                                                };
                                                            match &v276 {
                                                                Spiral_wasm::US4::US4_0(
                                                                    v276_0_0,
                                                                ) => Spiral_wasm::US4::US4_0(
                                                                    match &v276 {
                                                                        Spiral_wasm::US4::US4_0(
                                                                            x,
                                                                        ) => x.clone(),
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                ),
                                                                _ => {
                                                                    let v283: Spiral_wasm::US4 =
                                                                        if (v213.clone())
                                                                            == (v166.clone())
                                                                        {
                                                                            Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_1)
                                                                        } else {
                                                                            Spiral_wasm::US4::US4_1
                                                                        };
                                                                    match &v283
                                                                                                    {
                                                                                                    Spiral_wasm::US4::US4_0(v283_0_0)
                                                                                                    =>
                                                                                                    Spiral_wasm::US4::US4_0(match &v283
                                                                                                                                {
                                                                                                                                Spiral_wasm::US4::US4_0(x)
                                                                                                                                =>
                                                                                                                                x.clone(),
                                                                                                                                _
                                                                                                                                =>
                                                                                                                                unreachable!(),
                                                                                                                            }.clone()),
                                                                                                    _
                                                                                                    =>
                                                                                                    {
                                                                                                        let v290:
                                                                                                                Spiral_wasm::US4 =
                                                                                                            if (v199.clone())
                                                                                                                   ==
                                                                                                                   (v166.clone())
                                                                                                               {
                                                                                                                Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_2)
                                                                                                            } else {
                                                                                                                Spiral_wasm::US4::US4_1
                                                                                                            };
                                                                                                        match &v290
                                                                                                            {
                                                                                                            Spiral_wasm::US4::US4_0(v290_0_0)
                                                                                                            =>
                                                                                                            Spiral_wasm::US4::US4_0(match &v290
                                                                                                                                        {
                                                                                                                                        Spiral_wasm::US4::US4_0(x)
                                                                                                                                        =>
                                                                                                                                        x.clone(),
                                                                                                                                        _
                                                                                                                                        =>
                                                                                                                                        unreachable!(),
                                                                                                                                    }.clone()),
                                                                                                            _
                                                                                                            =>
                                                                                                            {
                                                                                                                let v297:
                                                                                                                        Spiral_wasm::US4 =
                                                                                                                    if (v185.clone())
                                                                                                                           ==
                                                                                                                           (v166.clone())
                                                                                                                       {
                                                                                                                        Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_3)
                                                                                                                    } else {
                                                                                                                        Spiral_wasm::US4::US4_1
                                                                                                                    };
                                                                                                                match &v297
                                                                                                                    {
                                                                                                                    Spiral_wasm::US4::US4_0(v297_0_0)
                                                                                                                    =>
                                                                                                                    Spiral_wasm::US4::US4_0(match &v297
                                                                                                                                                {
                                                                                                                                                Spiral_wasm::US4::US4_0(x)
                                                                                                                                                =>
                                                                                                                                                x.clone(),
                                                                                                                                                _
                                                                                                                                                =>
                                                                                                                                                unreachable!(),
                                                                                                                                            }.clone()),
                                                                                                                    _
                                                                                                                    =>
                                                                                                                    {
                                                                                                                        let v304:
                                                                                                                                Spiral_wasm::US4 =
                                                                                                                            if (v171.clone())
                                                                                                                                   ==
                                                                                                                                   (v166.clone())
                                                                                                                               {
                                                                                                                                Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_4)
                                                                                                                            } else {
                                                                                                                                Spiral_wasm::US4::US4_1
                                                                                                                            };
                                                                                                                        match &v304
                                                                                                                            {
                                                                                                                            Spiral_wasm::US4::US4_0(v304_0_0)
                                                                                                                            =>
                                                                                                                            Spiral_wasm::US4::US4_0(match &v304
                                                                                                                                                        {
                                                                                                                                                        Spiral_wasm::US4::US4_0(x)
                                                                                                                                                        =>
                                                                                                                                                        x.clone(),
                                                                                                                                                        _
                                                                                                                                                        =>
                                                                                                                                                        unreachable!(),
                                                                                                                                                    }.clone()),
                                                                                                                            _
                                                                                                                            =>
                                                                                                                            Spiral_wasm::US4::US4_1,
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    })
                }
                _ => Spiral_wasm::US3::US3_1,
            };
            let v338: Spiral_wasm::US4 = if let Spiral_wasm::US3::US3_0(v331_0_0) = &v331 {
                let v332: Spiral_wasm::US4 = v331_0_0.clone();
                if let Spiral_wasm::US4::US4_0(v332_0_0) = &v332 {
                    Spiral_wasm::US4::US4_0(v332_0_0.clone())
                } else {
                    Spiral_wasm::US4::US4_1
                }
            } else {
                Spiral_wasm::US4::US4_1
            };
            let v372: () = {
                Spiral_wasm::closure7(
                    match &v338 {
                        Spiral_wasm::US4::US4_0(v338_0_0) => match &v338 {
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
            let patternInput: (
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ) = Spiral_wasm::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v1226: () = {
                Spiral_wasm::closure13(v0_1, ());
                ()
            };
            let v2011: string = Spiral_wasm::method28();
            let v2025: &str = &*v2011;
            let v2098: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v2025).cloned();
            let v2111: Option<string> = map(Spiral_wasm::method29(), v2098);
            let v3222: Spiral_wasm::US9 =
                defaultValue(Spiral_wasm::US9::US9_1, map(Spiral_wasm::method8(), v2111));
            let v3233: std::pin::Pin<
                Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>,
            > = Spiral_wasm::method33(v3);
            let v3235 = tokio::runtime::Builder::new_multi_thread()
                .enable_all()
                .build()
                .unwrap();
            let v3237: Result<u8, anyhow::Error> = v3235.handle().block_on(v3233);
            let v3238 = Spiral_wasm::method81();
            let v3251: Result<u8, std::string::String> = v3237.map_err(|x| v3238(x));
            let v3254 = Spiral_wasm::method95();
            let v3255 = Spiral_wasm::method96();
            let v3257: Spiral_wasm::US17 = match &v3251 {
                Err(v3251_1_0) => v3255(v3251_1_0.clone()),
                Ok(v3251_0_0) => v3254(v3251_0_0.clone()),
            };
            match &v3257 {
                Spiral_wasm::US17::US17_0(v3257_0_0) => {
                    if let Spiral_wasm::US9::US9_0(v3222_0_0) = &v3222 {
                        let v3275: string = sprintf!(
                            "spiral_wasm.main / retries: {} / exception: \'{}\'",
                            v3257_0_0.clone(),
                            v3222_0_0.clone()
                        );
                        let v3279: Result<(), string> = Err(v3275);
                        v3279.unwrap();
                        ()
                    }
                }
                Spiral_wasm::US17::US17_1(v3257_1_0) => {
                    let v3295: std::string::String = v3257_1_0.clone();
                    if let Spiral_wasm::US9::US9_0(v3222_0_0) = &v3222 {
                        let v3296: string = v3222_0_0.clone();
                        if string("") == (v3296.clone()) {
                            ()
                        } else {
                            if contains(
                                fable_library_rust::String_::fromString(v3295.clone()),
                                v3296.clone(),
                            ) {
                                ()
                            } else {
                                let v3311: string = sprintf!(
                                    "spiral_wasm.main / exception: \'{}\' / error: {}",
                                    v3296,
                                    v3295
                                );
                                let v3315: Result<(), string> = Err(v3311);
                                v3315.unwrap();
                                ()
                            }
                        }
                    } else {
                        let v3334: u8 = v3251.clone().unwrap();
                        ()
                    }
                }
            }
            0_i32
        }
        pub fn v0() -> Func1<Array<string>, i32> {
            static v0: OnceInit<Func1<Array<string>, i32>> = OnceInit::new();
            v0.get_or_init(|| Func1::new(move |v: Array<string>| Spiral_wasm::closure0((), v)))
                .clone()
        }
        pub fn main(args: Array<string>) -> i32 {
            (Spiral_wasm::v0())(args)
        }
    }
}
pub use module_e3e534c3::*;
#[path = "../../lib/spiral/async_.rs"]
mod module_763b9e6c;
pub use module_763b9e6c::*;
#[path = "../../lib/spiral/common.rs"]
mod module_18f1c018;
pub use module_18f1c018::*;
#[path = "../../lib/spiral/crypto.rs"]
mod module_c0301e36;
pub use module_c0301e36::*;
#[path = "../../lib/spiral/date_time.rs"]
mod module_e5abed0b;
pub use module_e5abed0b::*;
#[path = "../../lib/spiral/file_system.rs"]
mod module_336d1dc9;
pub use module_336d1dc9::*;
#[path = "../../lib/spiral/lib.rs"]
mod module_12dde172;
pub use module_12dde172::*;
#[path = "../../lib/spiral/networking.rs"]
mod module_7e35832b;
pub use module_7e35832b::*;
#[path = "../../lib/spiral/platform.rs"]
mod module_afd02cca;
pub use module_afd02cca::*;
#[path = "../../lib/spiral/runtime.rs"]
mod module_a3c64389;
pub use module_a3c64389::*;
#[path = "../../lib/spiral/sm.rs"]
mod module_8f227ecb;
pub use module_8f227ecb::*;
#[path = "../../lib/spiral/threading.rs"]
mod module_e08c16fb;
pub use module_e08c16fb::*;
#[path = "../../lib/spiral/trace.rs"]
mod module_702ddcb4;
pub use module_702ddcb4::*;
#[path = "../../deps/polyglot/lib/fsharp/Common.rs"]
mod module_eb7e4788;
pub use module_eb7e4788::*;
pub mod Polyglot {
    pub use crate::module_eb7e4788::Polyglot::*;
}
pub fn main() {
    let args = std::env::args().skip(1).map(fromString).collect();
    Spiral_wasm::main(array_from(args));
}
