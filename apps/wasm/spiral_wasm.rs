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
        #[derive(Clone, Debug)]
        pub enum US12 {
            US12_0(
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ),
            US12_1,
        }
        impl core::fmt::Display for US12 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US13 {
            US13_0(char),
            US13_1,
        }
        impl core::fmt::Display for US13 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub struct Mut5 {
            pub l0: MutCell<i32>,
        }
        impl core::fmt::Display for Mut5 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US14 {
            US14_0(u8, Spiral_wasm::US10),
            US14_1(u8, Spiral_wasm::US10),
        }
        impl core::fmt::Display for US14 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US15 {
            US15_0(i32),
            US15_1(LrcPtr<Exception>),
        }
        impl core::fmt::Display for US15 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US16 {
            US16_0(i32),
            US16_1,
        }
        impl core::fmt::Display for US16 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US17 {
            US17_0(Spiral_wasm::US10),
            US17_1(std::string::String),
        }
        impl core::fmt::Display for US17 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US18 {
            US18_0(u8),
            US18_1(std::string::String),
        }
        impl core::fmt::Display for US18 {
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
            let v1: string = string("r#\"command\"#");
            let v2: &'static str = r#"command"#;
            let v4: clap::Command = clap::Command::new(v2);
            let v6: clap::Command = clap::Command::args_override_self(v4, true);
            let v20: Spiral_wasm::US0 = Spiral_wasm::method1();
            let v41: Spiral_wasm::US1 = match &v20 {
                Spiral_wasm::US0::US0_0(v20_0_0) => Spiral_wasm::US1::US1_0(v20_0_0.clone()),
                _ => Spiral_wasm::US1::US1_1,
            };
            let v88: usize = match &v41 {
                Spiral_wasm::US1::US1_0(v41_0_0) => match &v41 {
                    Spiral_wasm::US1::US1_0(x) => x.clone(),
                    _ => unreachable!(),
                },
                _ => panic!("{}", string("Option does not have a value."),),
            };
            let v102: Spiral_wasm::US0 = Spiral_wasm::method2();
            let v123: Spiral_wasm::US1 = match &v102 {
                Spiral_wasm::US0::US0_0(v102_0_0) => Spiral_wasm::US1::US1_0(v102_0_0.clone()),
                _ => Spiral_wasm::US1::US1_1,
            };
            let v170: usize = match &v123 {
                Spiral_wasm::US1::US1_0(v123_0_0) => match &v123 {
                    Spiral_wasm::US1::US1_0(x) => x.clone(),
                    _ => unreachable!(),
                },
                _ => panic!("{}", string("Option does not have a value."),),
            };
            let v184: Spiral_wasm::US0 = Spiral_wasm::method1();
            let v205: Spiral_wasm::US1 = match &v184 {
                Spiral_wasm::US0::US0_0(v184_0_0) => Spiral_wasm::US1::US1_0(v184_0_0.clone()),
                _ => Spiral_wasm::US1::US1_1,
            };
            let v272: clap::builder::ValueRange = if (v170)
                == (match &v205 {
                    Spiral_wasm::US1::US1_0(v205_0_0) => match &v205 {
                        Spiral_wasm::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    },
                    _ => panic!("{}", string("Option does not have a value."),),
                }) {
                clap::builder::ValueRange::new(v88..)
            } else {
                let v270: string = string("clap::builder::ValueRange::new($0..=$1)");
                clap::builder::ValueRange::new(v88..=v170)
            };
            let v274: string = string("r#\"exception\"#");
            let v275: &'static str = r#"exception"#;
            let v277: clap::Arg = clap::Arg::new(v275);
            let v279: clap::Arg = v277.short('e');
            let v280: string = string("r#\"exception\"#");
            let v281: &'static str = r#"exception"#;
            let v283: clap::Arg = v279.long(v281);
            let v285: clap::Arg = v283.num_args(v272);
            let v287: clap::Arg = v285.require_equals(true);
            let v289: string = string("r#\"\"#");
            let v290: &str = r#""#;
            let v292: clap::Arg = v287.default_missing_value(v290);
            let v294: clap::Command = clap::Command::arg(v6, v292);
            let v296: string = string("r#\"trace_level\"#");
            let v297: &'static str = r#"trace_level"#;
            let v299: clap::Arg = clap::Arg::new(v297);
            let v301: clap::Arg = v299.short('t');
            let v302: string = string("r#\"trace_level\"#");
            let v303: &'static str = r#"trace_level"#;
            let v305: clap::Arg = v301.long(v303);
            let v312: string = toLower(string("Critical"));
            let v330: string = toLower(string("Warning"));
            let v348: string = toLower(string("Info"));
            let v366: string = toLower(string("Debug"));
            let v486: Array<string> = toArray(ofArray(new_array(&[
                toLower(string("Verbose")),
                v366,
                v348,
                v330,
                v312,
            ])));
            let v499: Vec<string> = v486.to_vec();
            let v501: bool = true;
            let _vec_map: Vec<_> = v499
                .into_iter()
                .map(|x| {
                    //;
                    let v503: string = x;
                    let v688: &str = &*v503;
                    let v1333: std::string::String = String::from(v688);
                    let v1795: Box<std::string::String> = Box::new(v1333);
                    let v1797: &'static mut std::string::String = Box::leak(v1795);
                    let v1799: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v1797);
                    let v1801: bool = true;
                    v1799
                })
                .collect::<Vec<_>>();
            let v1803: Vec<clap::builder::PossibleValue> = _vec_map;
            let v1805: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v1803),
            );
            let v1807: clap::Arg = v305.value_parser(v1805);
            let v1809: clap::Command = clap::Command::arg(v294, v1807);
            let v1811: string = string("r#\"wasm\"#");
            let v1812: &'static str = r#"wasm"#;
            let v1814: clap::Arg = clap::Arg::new(v1812);
            let v1816: clap::Arg = v1814.short('w');
            let v1817: string = string("r#\"wasm\"#");
            let v1818: &'static str = r#"wasm"#;
            let v1820: clap::Arg = v1816.long(v1818);
            let v1822: clap::Arg = v1820.required(true);
            clap::Command::arg(v1809, v1822)
        }
        pub fn method3() -> string {
            string("trace_level")
        }
        pub fn closure6(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US2 {
            Spiral_wasm::US2::US2_0(v0_1)
        }
        pub fn method4() -> Func1<std::string::String, Spiral_wasm::US2> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure6((), v))
        }
        pub fn method8(v0_1: string) -> string {
            v0_1
        }
        pub fn method9() -> string {
            string("")
        }
        pub fn method12() -> string {
            string("")
        }
        pub fn method13(v0_1: LrcPtr<Spiral_wasm::Mut3>, v1: string) {
            let v5: string = append((v0_1.l0.get().clone()), (v1));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method11(v0_1: Spiral_wasm::US9) -> string {
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method13(v12.clone(), sprintf!("{:?}", v0_1));
            v12.l0.get().clone()
        }
        pub fn method14(v0_1: string) -> string {
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method13(v12.clone(), v0_1);
            v12.l0.get().clone()
        }
        pub fn method10(v0_1: string) -> string {
            panic!(
                "{}",
                append(
                    (append(
                        (append(
                            string("env.get_environment_variable / target: "),
                            (Spiral_wasm::method11(Spiral_wasm::US9::US9_5(
                                Spiral_wasm::US8::US8_0(Spiral_wasm::US7::US7_0)
                            )))
                        )),
                        string(" / var: ")
                    )),
                    (Spiral_wasm::method14(v0_1))
                ),
            )
        }
        pub fn method15(v0_1: string) -> string {
            panic!(
                "{}",
                append(
                    (append(
                        (append(
                            string("env.get_environment_variable / target: "),
                            (Spiral_wasm::method11(Spiral_wasm::US9::US9_5(
                                Spiral_wasm::US8::US8_0(Spiral_wasm::US7::US7_1)
                            )))
                        )),
                        string(" / var: ")
                    )),
                    (Spiral_wasm::method14(v0_1))
                ),
            )
        }
        pub fn closure8(unitVar: (), v0_1: string) -> Spiral_wasm::US10 {
            Spiral_wasm::US10::US10_0(v0_1)
        }
        pub fn method16() -> Func1<string, Spiral_wasm::US10> {
            Func1::new(move |v: string| Spiral_wasm::closure8((), v))
        }
        pub fn method7(v0_1: string) -> string {
            let v32: string = Spiral_wasm::method8(v0_1);
            let v34: Result<std::string::String, std::env::VarError> = std::env::var(&*v32);
            let v36: bool = true;
            let _result_map_ = v34.map(|x| {
                //;
                let v38: std::string::String = x;
                let v40: string = fable_library_rust::String_::fromString(v38);
                let v42: bool = true;
                v40
            });
            let v44: Result<string, std::env::VarError> = _result_map_;
            let v45: string = Spiral_wasm::method9();
            v44.unwrap_or(v45)
        }
        pub fn closure9(v0_1: i64, unitVar: ()) -> i64 {
            v0_1
        }
        pub fn closure10(unitVar: (), v0_1: i64) -> Spiral_wasm::US11 {
            Spiral_wasm::US11::US11_0(v0_1)
        }
        pub fn closure11(unitVar: (), v0_1: LrcPtr<Exception>) -> Spiral_wasm::US11 {
            Spiral_wasm::US11::US11_1(v0_1)
        }
        pub fn method17(v0_1: i64) -> Spiral_wasm::US11 {
            try_catch(
                || Spiral_wasm::closure10((), Spiral_wasm::closure9(v0_1, ())),
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
        pub fn method6() -> (Spiral_wasm::US4, Spiral_wasm::US6) {
            let v1: string = Spiral_wasm::method7(string("TRACE_LEVEL"));
            let v8: string = toLower(string("Critical"));
            let v26: string = toLower(string("Warning"));
            let v44: string = toLower(string("Info"));
            let v62: string = toLower(string("Debug"));
            let v80: string = toLower(string("Verbose"));
            let v96: Spiral_wasm::US4 = if string("Verbose") == (v1.clone()) {
                Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_0)
            } else {
                Spiral_wasm::US4::US4_1
            };
            (
                match &v96 {
                    Spiral_wasm::US4::US4_0(v96_0_0) => Spiral_wasm::US4::US4_0(
                        match &v96 {
                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    _ => {
                        let v103: Spiral_wasm::US4 = if string("Debug") == (v1.clone()) {
                            Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_1)
                        } else {
                            Spiral_wasm::US4::US4_1
                        };
                        match &v103 {
                            Spiral_wasm::US4::US4_0(v103_0_0) => Spiral_wasm::US4::US4_0(
                                match &v103 {
                                    Spiral_wasm::US4::US4_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => {
                                let v110: Spiral_wasm::US4 = if string("Info") == (v1.clone()) {
                                    Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_2)
                                } else {
                                    Spiral_wasm::US4::US4_1
                                };
                                match &v110 {
                                    Spiral_wasm::US4::US4_0(v110_0_0) => Spiral_wasm::US4::US4_0(
                                        match &v110 {
                                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => {
                                        let v117: Spiral_wasm::US4 =
                                            if string("Warning") == (v1.clone()) {
                                                Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_3)
                                            } else {
                                                Spiral_wasm::US4::US4_1
                                            };
                                        match &v117 {
                                            Spiral_wasm::US4::US4_0(v117_0_0) => {
                                                Spiral_wasm::US4::US4_0(
                                                    match &v117 {
                                                        Spiral_wasm::US4::US4_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                )
                                            }
                                            _ => {
                                                let v124: Spiral_wasm::US4 = if string("Critical")
                                                    == (v1.clone())
                                                {
                                                    Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_4)
                                                } else {
                                                    Spiral_wasm::US4::US4_1
                                                };
                                                match &v124 {
                                                    Spiral_wasm::US4::US4_0(v124_0_0) => {
                                                        Spiral_wasm::US4::US4_0(
                                                            match &v124 {
                                                                Spiral_wasm::US4::US4_0(x) => {
                                                                    x.clone()
                                                                }
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => {
                                                        let v131: Spiral_wasm::US4 =
                                                            if (v80.clone()) == (v1.clone()) {
                                                                Spiral_wasm::US4::US4_0(
                                                                    Spiral_wasm::US5::US5_0,
                                                                )
                                                            } else {
                                                                Spiral_wasm::US4::US4_1
                                                            };
                                                        match &v131 {
                                                            Spiral_wasm::US4::US4_0(v131_0_0) => {
                                                                Spiral_wasm::US4::US4_0(
                                                                    match &v131 {
                                                                        Spiral_wasm::US4::US4_0(
                                                                            x,
                                                                        ) => x.clone(),
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                )
                                                            }
                                                            _ => {
                                                                let v138: Spiral_wasm::US4 =
                                                                    if (v62.clone()) == (v1.clone())
                                                                    {
                                                                        Spiral_wasm::US4::US4_0(
                                                                            Spiral_wasm::US5::US5_1,
                                                                        )
                                                                    } else {
                                                                        Spiral_wasm::US4::US4_1
                                                                    };
                                                                match &v138 {
                                                                 Spiral_wasm::US4::US4_0(v138_0_0)
                                                                 =>
                                                                 Spiral_wasm::US4::US4_0(match &v138
                                                                                             {
                                                                                             Spiral_wasm::US4::US4_0(x)
                                                                                             =>
                                                                                             x.clone(),
                                                                                             _
                                                                                             =>
                                                                                             unreachable!(),
                                                                                         }.clone()),
                                                                 _ => {
                                                                     let v145:
                                                                             Spiral_wasm::US4 =
                                                                         if (v44.clone())
                                                                                ==
                                                                                (v1.clone())
                                                                            {
                                                                             Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_2)
                                                                         } else {
                                                                             Spiral_wasm::US4::US4_1
                                                                         };
                                                                     match &v145
                                                                         {
                                                                         Spiral_wasm::US4::US4_0(v145_0_0)
                                                                         =>
                                                                         Spiral_wasm::US4::US4_0(match &v145
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
                                                                             let v152:
                                                                                     Spiral_wasm::US4 =
                                                                                 if (v26.clone())
                                                                                        ==
                                                                                        (v1.clone())
                                                                                    {
                                                                                     Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_3)
                                                                                 } else {
                                                                                     Spiral_wasm::US4::US4_1
                                                                                 };
                                                                             match &v152
                                                                                 {
                                                                                 Spiral_wasm::US4::US4_0(v152_0_0)
                                                                                 =>
                                                                                 Spiral_wasm::US4::US4_0(match &v152
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
                                                                                     let v159:
                                                                                             Spiral_wasm::US4 =
                                                                                         if (v8.clone())
                                                                                                ==
                                                                                                (v1.clone())
                                                                                            {
                                                                                             Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_4)
                                                                                         } else {
                                                                                             Spiral_wasm::US4::US4_1
                                                                                         };
                                                                                     match &v159
                                                                                         {
                                                                                         Spiral_wasm::US4::US4_0(v159_0_0)
                                                                                         =>
                                                                                         Spiral_wasm::US4::US4_0(match &v159
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
                if (Spiral_wasm::method7(string("AUTOMATION"))) != string("True") {
                    Spiral_wasm::US6::US6_1
                } else {
                    let v463: Spiral_wasm::US11 = Spiral_wasm::method17({
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    });
                    let v484: Spiral_wasm::US6 = match &v463 {
                        Spiral_wasm::US11::US11_0(v463_0_0) => {
                            Spiral_wasm::US6::US6_0(v463_0_0.clone())
                        }
                        _ => Spiral_wasm::US6::US6_1,
                    };
                    Spiral_wasm::US6::US6_0(match &v484 {
                        Spiral_wasm::US6::US6_0(v484_0_0) => match &v484 {
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
        pub fn method5(
            v0_1: Spiral_wasm::US5,
        ) -> (
            LrcPtr<Spiral_wasm::Mut0>,
            LrcPtr<Spiral_wasm::Mut1>,
            LrcPtr<Spiral_wasm::Mut2>,
            LrcPtr<Spiral_wasm::Mut3>,
            LrcPtr<Spiral_wasm::Mut4>,
            Option<i64>,
        ) {
            let patternInput: (Spiral_wasm::US4, Spiral_wasm::US6) = Spiral_wasm::method6();
            let _run_target_args__v5: (Spiral_wasm::US4, Spiral_wasm::US6) =
                (patternInput.0.clone(), patternInput.1.clone());
            let v2180: Spiral_wasm::US6 = _run_target_args__v5.1.clone();
            let v2179: Spiral_wasm::US4 = _run_target_args__v5.0.clone();
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
                    l0: MutCell::new(match &v2179 {
                        Spiral_wasm::US4::US4_0(v2179_0_0) => match &v2179 {
                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => v0_1.clone(),
                    }),
                }),
                match &v2180 {
                    Spiral_wasm::US6::US6_0(v2180_0_0) => Some(match &v2180 {
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
                ) = Spiral_wasm::method5(v0_1);
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
                ) = Spiral_wasm::method5(Spiral_wasm::US5::US5_0);
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
        pub fn method19() -> Func1<i64, Spiral_wasm::US6> {
            Func1::new(move |v: i64| Spiral_wasm::closure15((), v))
        }
        pub fn method20() -> string {
            string("hh:mm:ss")
        }
        pub fn method21() -> string {
            string("HH:mm:ss")
        }
        pub fn method18(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
        ) -> string {
            let v1756: Spiral_wasm::US6 =
                defaultValue(Spiral_wasm::US6::US6_1, map(Spiral_wasm::method19(), v5));
            let v2414: DateTime = match &v1756 {
                Spiral_wasm::US6::US6_0(v1756_0_0) => {
                    let v2030: Spiral_wasm::US11 = Spiral_wasm::method17({
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    });
                    let v2051: Spiral_wasm::US6 = match &v2030 {
                        Spiral_wasm::US11::US11_0(v2030_0_0) => {
                            Spiral_wasm::US6::US6_0(v2030_0_0.clone())
                        }
                        _ => Spiral_wasm::US6::US6_1,
                    };
                    let v2196: TimeSpan = TimeSpan::new_ticks(
                        (match &v2051 {
                            Spiral_wasm::US6::US6_0(v2051_0_0) => match &v2051 {
                                Spiral_wasm::US6::US6_0(x) => x.clone(),
                                _ => unreachable!(),
                            },
                            _ => panic!("{}", string("Option does not have a value."),),
                        }) - (match &v1756 {
                            Spiral_wasm::US6::US6_0(x) => x.clone(),
                            _ => unreachable!(),
                        }),
                    );
                    DateTime::new_ymdhms_milli(
                        1_i32,
                        1_i32,
                        1_i32,
                        v2196.hours(),
                        v2196.minutes(),
                        v2196.seconds(),
                        v2196.milliseconds(),
                    )
                }
                _ => DateTime::now(),
            };
            let v2415: string = Spiral_wasm::method20();
            let provider: string = if (v2415.clone()) == string("") {
                string("M-d-y hh:mm:ss tt")
            } else {
                v2415
            };
            v2414.toString(provider)
        }
        pub fn method23(v0_1: char) -> string {
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method13(v12.clone(), sprintf!("{}", v0_1));
            v12.l0.get().clone()
        }
        pub fn method22() -> string {
            let v4: &str = inline_colorization::color_bright_black;
            let v189: std::string::String = String::from(v4);
            let v1978: string = append(
                (fable_library_rust::String_::fromString(v189)),
                (Spiral_wasm::method23(getCharAt(toLower(string("Verbose")), 0_i32))),
            );
            let v1994: &str = inline_colorization::color_reset;
            let v2179: std::string::String = String::from(v1994);
            append((v1978), (fable_library_rust::String_::fromString(v2179)))
        }
        pub fn method25(v0_1: i64) -> string {
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method13(v12.clone(), sprintf!("{}", v0_1));
            v12.l0.get().clone()
        }
        pub fn method27(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("{ "));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method28(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("args"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method29(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string(" = "));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method30(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string(" }"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method26(v0_1: Array<string>) -> string {
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v12.clone());
            Spiral_wasm::method28(v12.clone());
            Spiral_wasm::method29(v12.clone());
            Spiral_wasm::method13(v12.clone(), sprintf!("{:?}", v0_1));
            Spiral_wasm::method30(v12.clone());
            v12.l0.get().clone()
        }
        pub fn method33(v0_1: char, v1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1: MutCell<i64> = MutCell::new(v1);
            '_method33: loop {
                break '_method33 (if (v1.get().clone()) >= 4_i64 {
                    false
                } else {
                    let v19: Spiral_wasm::US13 = if (v1.get().clone()) == 0_i64 {
                        Spiral_wasm::US13::US13_0(' ')
                    } else {
                        let v5: i64 = (v1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral_wasm::US13::US13_0('\t')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            if (v8) == 0_i64 {
                                Spiral_wasm::US13::US13_0('\r')
                            } else {
                                let v11: i64 = (v8) - 1_i64;
                                if (v11) == 0_i64 {
                                    Spiral_wasm::US13::US13_0('\n')
                                } else {
                                    let v14: i64 = (v11) - 1_i64;
                                    Spiral_wasm::US13::US13_1
                                }
                            }
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v19 {
                            Spiral_wasm::US13::US13_0(v19_0_0) => match &v19 {
                                Spiral_wasm::US13::US13_0(x) => x.clone(),
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
                        continue '_method33;
                    }
                });
            }
        }
        pub fn method32(v0_1: string, v1: i32, v2: i32) -> i32 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1: MutCell<i32> = MutCell::new(v1);
            let v2: MutCell<i32> = MutCell::new(v2);
            '_method32: loop {
                break '_method32 (if (v2.get().clone()) >= (v1.get().clone()) {
                    v1.get().clone()
                } else {
                    if Spiral_wasm::method33(getCharAt(v0_1.get().clone(), v2.get().clone()), 0_i64)
                    {
                        let v0_1_temp: string = v0_1.get().clone();
                        let v1_temp: i32 = v1.get().clone();
                        let v2_temp: i32 = (v2.get().clone()) + 1_i32;
                        v0_1.set(v0_1_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        continue '_method32;
                    } else {
                        v2.get().clone()
                    }
                });
            }
        }
        pub fn method35(v0_1: char, v1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1: MutCell<i64> = MutCell::new(v1);
            '_method35: loop {
                break '_method35 (if (v1.get().clone()) >= 2_i64 {
                    false
                } else {
                    let v11: Spiral_wasm::US13 = if (v1.get().clone()) == 0_i64 {
                        Spiral_wasm::US13::US13_0(' ')
                    } else {
                        let v5: i64 = (v1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral_wasm::US13::US13_0('/')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            Spiral_wasm::US13::US13_1
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v11 {
                            Spiral_wasm::US13::US13_0(v11_0_0) => match &v11 {
                                Spiral_wasm::US13::US13_0(x) => x.clone(),
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
                        continue '_method35;
                    }
                });
            }
        }
        pub fn method34(v0_1: string, v1: i32) -> i32 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1: MutCell<i32> = MutCell::new(v1);
            '_method34: loop {
                break '_method34 (if (v1.get().clone()) <= 0_i32 {
                    0_i32
                } else {
                    let v3: i32 = (v1.get().clone()) - 1_i32;
                    if Spiral_wasm::method35(getCharAt(v0_1.get().clone(), v3), 0_i64) {
                        let v0_1_temp: string = v0_1.get().clone();
                        let v1_temp: i32 = v3;
                        v0_1.set(v0_1_temp);
                        v1.set(v1_temp);
                        continue '_method34;
                    } else {
                        v3
                    }
                });
            }
        }
        pub fn method31(v0_1: string) -> string {
            let v1: i32 = length(v0_1.clone());
            let v716: string = getSlice(
                v0_1.clone(),
                Some(Spiral_wasm::method32(v0_1, v1, 0_i32)),
                Some(v1),
            );
            getSlice(
                v716.clone(),
                Some(0_i32),
                Some(Spiral_wasm::method34(v716.clone(), length(v716))),
            )
        }
        pub fn method24(
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
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.main"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method26(v8)),
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
            let v33: () = {
                Spiral_wasm::closure18(v0_1, ());
                ()
            };
            ()
        }
        pub fn method36(v0_1: i32, v1: LrcPtr<Spiral_wasm::Mut5>) -> bool {
            (v1.l0.get().clone()) < (v0_1)
        }
        pub fn closure13(v0_1: Array<string>, unitVar: ()) {
            fn v62() {
                Spiral_wasm::closure14((), ());
            }
            let v63: () = {
                v62();
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
            let v159: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1234: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v159,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v228: () = {
                        v62();
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
                    let v282: Option<i64> = patternInput_1.5.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v278: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v277: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v326: string = Spiral_wasm::method24(
                        v277.clone(),
                        v278.clone(),
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        Spiral_wasm::method18(v277, v278, v279, v280, v281, v282),
                        Spiral_wasm::method22(),
                        v0_1,
                    );
                    let v388: () = {
                        v62();
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
                    let v438: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v437: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v490: () = {
                        Spiral_wasm::closure16(v437.clone(), ());
                        ()
                    };
                    println!("{}", v326.clone());
                    (v438.l0.get().clone())(v326);
                    Spiral_wasm::US12::US12_0(
                        v437,
                        v438,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn method37() -> string {
            string("exception")
        }
        pub fn method40(v0_1: char, v1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1: MutCell<i64> = MutCell::new(v1);
            '_method40: loop {
                break '_method40 (if (v1.get().clone()) >= 1_i64 {
                    false
                } else {
                    let v7: Spiral_wasm::US13 = if (v1.get().clone()) == 0_i64 {
                        Spiral_wasm::US13::US13_0('\\')
                    } else {
                        let v5: i64 = (v1.get().clone()) - 1_i64;
                        Spiral_wasm::US13::US13_1
                    };
                    if (v0_1.get().clone())
                        == (match &v7 {
                            Spiral_wasm::US13::US13_0(v7_0_0) => match &v7 {
                                Spiral_wasm::US13::US13_0(x) => x.clone(),
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
                        continue '_method40;
                    }
                });
            }
        }
        pub fn method39(v0_1: string, v1: i32, v2: i32) -> i32 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1: MutCell<i32> = MutCell::new(v1);
            let v2: MutCell<i32> = MutCell::new(v2);
            '_method39: loop {
                break '_method39 (if (v2.get().clone()) >= (v1.get().clone()) {
                    v1.get().clone()
                } else {
                    if Spiral_wasm::method40(getCharAt(v0_1.get().clone(), v2.get().clone()), 0_i64)
                    {
                        let v0_1_temp: string = v0_1.get().clone();
                        let v1_temp: i32 = v1.get().clone();
                        let v2_temp: i32 = (v2.get().clone()) + 1_i32;
                        v0_1.set(v0_1_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        continue '_method39;
                    } else {
                        v2.get().clone()
                    }
                });
            }
        }
        pub fn method41(v0_1: string, v1: i32) -> i32 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1: MutCell<i32> = MutCell::new(v1);
            '_method41: loop {
                break '_method41 (if (v1.get().clone()) <= 0_i32 {
                    0_i32
                } else {
                    let v3: i32 = (v1.get().clone()) - 1_i32;
                    if Spiral_wasm::method40(getCharAt(v0_1.get().clone(), v3), 0_i64) {
                        let v0_1_temp: string = v0_1.get().clone();
                        let v1_temp: i32 = v3;
                        v0_1.set(v0_1_temp);
                        v1.set(v1_temp);
                        continue '_method41;
                    } else {
                        v3
                    }
                });
            }
        }
        pub fn closure19(unitVar: (), v0_1: std::string::String) -> string {
            let v2: string = fable_library_rust::String_::fromString(v0_1);
            let v3: i32 = length(v2.clone());
            let v718: string = getSlice(
                v2.clone(),
                Some(Spiral_wasm::method39(v2, v3, 0_i32)),
                Some(v3),
            );
            getSlice(
                v718.clone(),
                Some(0_i32),
                Some(Spiral_wasm::method41(v718.clone(), length(v718))),
            )
        }
        pub fn method38() -> Func1<std::string::String, string> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure19((), v))
        }
        pub fn method43() -> string {
            string("wasm")
        }
        pub fn method46(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("wasm_path"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method45(v0_1: string) -> string {
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v12.clone());
            Spiral_wasm::method46(v12.clone());
            Spiral_wasm::method29(v12.clone());
            Spiral_wasm::method13(v12.clone(), v0_1);
            Spiral_wasm::method30(v12.clone());
            v12.l0.get().clone()
        }
        pub fn method44(
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
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method45(v8)),
            ))
        }
        pub fn closure20(v0_1: string, unitVar: ()) {
            fn v62() {
                Spiral_wasm::closure14((), ());
            }
            let v63: () = {
                v62();
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
            let v159: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1234: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v159,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v228: () = {
                        v62();
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
                    let v282: Option<i64> = patternInput_1.5.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v278: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v277: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v326: string = Spiral_wasm::method44(
                        v277.clone(),
                        v278.clone(),
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        Spiral_wasm::method18(v277, v278, v279, v280, v281, v282),
                        Spiral_wasm::method22(),
                        v0_1,
                    );
                    let v388: () = {
                        v62();
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
                    let v438: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v437: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v490: () = {
                        Spiral_wasm::closure16(v437.clone(), ());
                        ()
                    };
                    println!("{}", v326.clone());
                    (v438.l0.get().clone())(v326);
                    Spiral_wasm::US12::US12_0(
                        v437,
                        v438,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn method51(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("retry"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method52(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("; "));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method53(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("worker"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method54(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("contract"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method50(
            v0_1: u8,
            v1: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v2: near_workspaces::Contract,
        ) -> string {
            let v14: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v14.clone());
            Spiral_wasm::method51(v14.clone());
            Spiral_wasm::method29(v14.clone());
            Spiral_wasm::method13(v14.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method52(v14.clone());
            Spiral_wasm::method53(v14.clone());
            Spiral_wasm::method29(v14.clone());
            {
                let v946: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method13(v14.clone(), fable_library_rust::String_::fromString(v946));
                Spiral_wasm::method52(v14.clone());
                Spiral_wasm::method54(v14.clone());
                Spiral_wasm::method29(v14.clone());
                {
                    let v1554: std::string::String = format!("{:#?}", v2);
                    Spiral_wasm::method13(
                        v14.clone(),
                        fable_library_rust::String_::fromString(v1554),
                    );
                    Spiral_wasm::method30(v14.clone());
                    v14.l0.get().clone()
                }
            }
        }
        pub fn method49(
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
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method50(v8, v9, v10)),
            ))
        }
        pub fn closure21(
            v0_1: u8,
            v1: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v2: near_workspaces::Contract,
            unitVar: (),
        ) {
            fn v64() {
                Spiral_wasm::closure14((), ());
            }
            let v65: () = {
                v64();
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
            let v161: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1236: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v161,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v230: () = {
                        v64();
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
                    let v284: Option<i64> = patternInput_1.5.clone();
                    let v283: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v282: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v328: string = Spiral_wasm::method49(
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        v283.clone(),
                        v284.clone(),
                        Spiral_wasm::method18(v279, v280, v281, v282, v283, v284),
                        Spiral_wasm::method22(),
                        v0_1,
                        v1,
                        v2,
                    );
                    let v390: () = {
                        v64();
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
                    let v440: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v439: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v492: () = {
                        Spiral_wasm::closure16(v439.clone(), ());
                        ()
                    };
                    println!("{}", v328.clone());
                    (v440.l0.get().clone())(v328);
                    Spiral_wasm::US12::US12_0(
                        v439,
                        v440,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn method57(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("result"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method56(v0_1: u8, v1: near_workspaces::result::ExecutionFinalResult) -> string {
            let v13: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v13.clone());
            Spiral_wasm::method51(v13.clone());
            Spiral_wasm::method29(v13.clone());
            Spiral_wasm::method13(v13.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method52(v13.clone());
            Spiral_wasm::method57(v13.clone());
            Spiral_wasm::method29(v13.clone());
            {
                let v945: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method13(v13.clone(), fable_library_rust::String_::fromString(v945));
                Spiral_wasm::method30(v13.clone());
                v13.l0.get().clone()
            }
        }
        pub fn method55(
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
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method56(v8, v9)),
            ))
        }
        pub fn closure22(v0_1: u8, v1: near_workspaces::result::ExecutionFinalResult, unitVar: ()) {
            fn v63() {
                Spiral_wasm::closure14((), ());
            }
            let v64: () = {
                v63();
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
            let v160: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1235: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v160,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v229: () = {
                        v63();
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
                    let v283: Option<i64> = patternInput_1.5.clone();
                    let v282: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v278: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v327: string = Spiral_wasm::method55(
                        v278.clone(),
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        v283.clone(),
                        Spiral_wasm::method18(v278, v279, v280, v281, v282, v283),
                        Spiral_wasm::method22(),
                        v0_1,
                        v1,
                    );
                    let v389: () = {
                        v63();
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
                    let v439: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v438: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v491: () = {
                        Spiral_wasm::closure16(v438.clone(), ());
                        ()
                    };
                    println!("{}", v327.clone());
                    (v439.l0.get().clone())(v327);
                    Spiral_wasm::US12::US12_0(
                        v438,
                        v439,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn closure24(v0_1: std::string::String, unitVar: ()) {
            printfn!("{0}", v0_1);
        }
        pub fn closure23(unitVar: (), v0_1: std::string::String) {
            let v33: () = {
                Spiral_wasm::closure24(v0_1, ());
                ()
            };
            ()
        }
        pub fn closure25(unitVar: (), unitVar_1: ()) {
            fn v61() {
                Spiral_wasm::closure14((), ());
            }
            let v62: () = {
                v61();
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
            let v158: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1074: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    2_i32
                        >= (find(
                            v158,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v227: () = {
                        v61();
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
                    let v277: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v276: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v329: () = {
                        Spiral_wasm::closure16(v276.clone(), ());
                        ()
                    };
                    println!("{}", string(" "));
                    (v277.l0.get().clone())(string(" "));
                    Spiral_wasm::US12::US12_0(
                        v276,
                        v277,
                        patternInput_1.2.clone(),
                        patternInput_1.3.clone(),
                        patternInput_1.4.clone(),
                        patternInput_1.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn method58() -> string {
            let v4: &str = inline_colorization::color_bright_green;
            let v189: std::string::String = String::from(v4);
            let v1978: string = append(
                (fable_library_rust::String_::fromString(v189)),
                (Spiral_wasm::method23(getCharAt(toLower(string("Info")), 0_i32))),
            );
            let v1994: &str = inline_colorization::color_reset;
            let v2179: std::string::String = String::from(v1994);
            append((v1978), (fable_library_rust::String_::fromString(v2179)))
        }
        pub fn method61(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("total_gas_burnt_usd"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method62(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("total_gas_burnt"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method60(v0_1: u8, v1: f64, v2: u64) -> string {
            let v14: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v14.clone());
            Spiral_wasm::method51(v14.clone());
            Spiral_wasm::method29(v14.clone());
            Spiral_wasm::method13(v14.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method52(v14.clone());
            Spiral_wasm::method61(v14.clone());
            Spiral_wasm::method29(v14.clone());
            Spiral_wasm::method13(v14.clone(), sprintf!("{:+.6}", v1));
            Spiral_wasm::method52(v14.clone());
            Spiral_wasm::method62(v14.clone());
            Spiral_wasm::method29(v14.clone());
            Spiral_wasm::method13(v14.clone(), sprintf!("{}", v2));
            Spiral_wasm::method30(v14.clone());
            v14.l0.get().clone()
        }
        pub fn method59(
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
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("near_workspaces.print_usd"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method60(v8, v9, v10)),
            ))
        }
        pub fn closure26(v0_1: u8, v1: u64, v2: f64, unitVar: ()) {
            fn v64() {
                Spiral_wasm::closure14((), ());
            }
            let v65: () = {
                v64();
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
            let v161: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1236: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    2_i32
                        >= (find(
                            v161,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v230: () = {
                        v64();
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
                    let v284: Option<i64> = patternInput_1.5.clone();
                    let v283: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v282: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v328: string = Spiral_wasm::method59(
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        v283.clone(),
                        v284.clone(),
                        Spiral_wasm::method18(v279, v280, v281, v282, v283, v284),
                        Spiral_wasm::method58(),
                        v0_1,
                        v2,
                        v1,
                    );
                    let v390: () = {
                        v64();
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
                    let v440: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v439: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v492: () = {
                        Spiral_wasm::closure16(v439.clone(), ());
                        ()
                    };
                    println!("{}", v328.clone());
                    (v440.l0.get().clone())(v328);
                    Spiral_wasm::US12::US12_0(
                        v439,
                        v440,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn method65(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("is_success"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method66(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("gas_burnt_usd"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method67(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("tokens_burnt_usd"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method68(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("gas_burnt"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method69(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("tokens_burnt"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method64(v0_1: bool, v1: f64, v2: f64, v3: u64, v4: u128) -> string {
            let v16: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v16.clone());
            Spiral_wasm::method65(v16.clone());
            Spiral_wasm::method29(v16.clone());
            Spiral_wasm::method13(
                v16.clone(),
                if v0_1 {
                    string("true")
                } else {
                    string("false")
                },
            );
            Spiral_wasm::method52(v16.clone());
            Spiral_wasm::method66(v16.clone());
            Spiral_wasm::method29(v16.clone());
            Spiral_wasm::method13(v16.clone(), sprintf!("{:+.6}", v1));
            Spiral_wasm::method52(v16.clone());
            Spiral_wasm::method67(v16.clone());
            Spiral_wasm::method29(v16.clone());
            Spiral_wasm::method13(v16.clone(), sprintf!("{:+.6}", v2));
            Spiral_wasm::method52(v16.clone());
            Spiral_wasm::method68(v16.clone());
            Spiral_wasm::method29(v16.clone());
            Spiral_wasm::method13(v16.clone(), sprintf!("{}", v3));
            Spiral_wasm::method52(v16.clone());
            Spiral_wasm::method69(v16.clone());
            Spiral_wasm::method29(v16.clone());
            {
                let v2499: std::string::String = format!("{:#?}", v4);
                Spiral_wasm::method13(v16.clone(), fable_library_rust::String_::fromString(v2499));
                Spiral_wasm::method30(v16.clone());
                v16.l0.get().clone()
            }
        }
        pub fn method63(
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
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("near_workspaces.print_usd / outcome"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method64(v8, v9, v10, v11, v12)),
            ))
        }
        pub fn closure28(v0_1: bool, v1: u64, v2: f64, v3: u128, v4: f64, unitVar: ()) {
            fn v66() {
                Spiral_wasm::closure14((), ());
            }
            let v67: () = {
                v66();
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
            let v163: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1238: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    2_i32
                        >= (find(
                            v163,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v232: () = {
                        v66();
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
                    let v286: Option<i64> = patternInput_1.5.clone();
                    let v285: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v284: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v283: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v282: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v330: string = Spiral_wasm::method63(
                        v281.clone(),
                        v282.clone(),
                        v283.clone(),
                        v284.clone(),
                        v285.clone(),
                        v286.clone(),
                        Spiral_wasm::method18(v281, v282, v283, v284, v285, v286),
                        Spiral_wasm::method58(),
                        v0_1,
                        v2,
                        v4,
                        v1,
                        v3,
                    );
                    let v392: () = {
                        v66();
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
                    let v442: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v441: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v494: () = {
                        Spiral_wasm::closure16(v441.clone(), ());
                        ()
                    };
                    println!("{}", v330.clone());
                    (v442.l0.get().clone())(v330);
                    Spiral_wasm::US12::US12_0(
                        v441,
                        v442,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn closure27(unitVar: (), v0_1: near_workspaces::result::ExecutionOutcome) {
            let v2: bool = v0_1.clone().is_success();
            let v4: near_workspaces::types::Gas = v0_1.clone().gas_burnt;
            let v6: u64 = v4.as_gas();
            let v100: f64 = ((v6 as f64) / 10000000000000000.0_f64) * 6.68_f64;
            let v102: near_workspaces::types::NearToken = v0_1.tokens_burnt;
            let v104: u128 = v102.as_yoctonear();
            let v2676: () = {
                Spiral_wasm::closure28(
                    v2,
                    v6,
                    v100,
                    v104.clone(),
                    ((v104 as f64) / 1E+24_f64) * 6.68_f64,
                    (),
                );
                ()
            };
            ()
        }
        pub fn method72(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("result2"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method71(
            v0_1: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
        ) -> string {
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v12.clone());
            Spiral_wasm::method72(v12.clone());
            Spiral_wasm::method29(v12.clone());
            {
                let v418: std::string::String = format!("{:#?}", v0_1);
                Spiral_wasm::method13(v12.clone(), fable_library_rust::String_::fromString(v418));
                Spiral_wasm::method30(v12.clone());
                v12.l0.get().clone()
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
            v8: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
        ) -> string {
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method71(v8)),
            ))
        }
        pub fn closure29(
            v0_1: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
            unitVar: (),
        ) {
            fn v62() {
                Spiral_wasm::closure14((), ());
            }
            let v63: () = {
                v62();
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
            let v159: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1234: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v159,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v228: () = {
                        v62();
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
                    let v282: Option<i64> = patternInput_1.5.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v278: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v277: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v326: string = Spiral_wasm::method70(
                        v277.clone(),
                        v278.clone(),
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        Spiral_wasm::method18(v277, v278, v279, v280, v281, v282),
                        Spiral_wasm::method22(),
                        v0_1,
                    );
                    let v388: () = {
                        v62();
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
                    let v438: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v437: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v490: () = {
                        Spiral_wasm::closure16(v437.clone(), ());
                        ()
                    };
                    println!("{}", v326.clone());
                    (v438.l0.get().clone())(v326);
                    Spiral_wasm::US12::US12_0(
                        v437,
                        v438,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn method73(
            v0_1: near_workspaces::result::ExecutionFinalResult,
        ) -> near_workspaces::result::ExecutionFinalResult {
            v0_1
        }
        pub fn closure30(v0_1: usize, unitVar: ()) -> i32 {
            v0_1 as i32
        }
        pub fn closure31(unitVar: (), v0_1: i32) -> Spiral_wasm::US15 {
            Spiral_wasm::US15::US15_0(v0_1)
        }
        pub fn closure32(unitVar: (), v0_1: LrcPtr<Exception>) -> Spiral_wasm::US15 {
            Spiral_wasm::US15::US15_1(v0_1)
        }
        pub fn method74(v0_1: usize) -> Spiral_wasm::US15 {
            try_catch(
                || Spiral_wasm::closure31((), Spiral_wasm::closure30(v0_1, ())),
                |ex: LrcPtr<Exception>| {
                    Spiral_wasm::closure32(
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
        pub fn method77(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("receipt_failures_len"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method78(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("receipt_failures"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method76(v0_1: i32, v1: Vec<&near_workspaces::result::ExecutionOutcome>) -> string {
            let v13: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v13.clone());
            Spiral_wasm::method77(v13.clone());
            Spiral_wasm::method29(v13.clone());
            Spiral_wasm::method13(v13.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method52(v13.clone());
            Spiral_wasm::method78(v13.clone());
            Spiral_wasm::method29(v13.clone());
            {
                let v945: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method13(v13.clone(), fable_library_rust::String_::fromString(v945));
                Spiral_wasm::method30(v13.clone());
                v13.l0.get().clone()
            }
        }
        pub fn method75(
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
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method76(v8, v9)),
            ))
        }
        pub fn closure33(
            v0_1: Vec<&near_workspaces::result::ExecutionOutcome>,
            v1: i32,
            unitVar: (),
        ) {
            fn v63() {
                Spiral_wasm::closure14((), ());
            }
            let v64: () = {
                v63();
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
            let v160: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1235: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v160,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v229: () = {
                        v63();
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
                    let v283: Option<i64> = patternInput_1.5.clone();
                    let v282: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v278: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v327: string = Spiral_wasm::method75(
                        v278.clone(),
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        v283.clone(),
                        Spiral_wasm::method18(v278, v279, v280, v281, v282, v283),
                        Spiral_wasm::method22(),
                        v1,
                        v0_1,
                    );
                    let v389: () = {
                        v63();
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
                    let v439: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v438: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v491: () = {
                        Spiral_wasm::closure16(v438.clone(), ());
                        ()
                    };
                    println!("{}", v327.clone());
                    (v439.l0.get().clone())(v327);
                    Spiral_wasm::US12::US12_0(
                        v438,
                        v439,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn method79(
            v0_1: near_workspaces::result::ExecutionFinalResult,
        ) -> near_workspaces::result::ExecutionFinalResult {
            v0_1
        }
        pub fn method82(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("receipt_outcomes_len"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method83(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("receipt_outcomes"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method81(v0_1: i32, v1: Vec<near_workspaces::result::ExecutionOutcome>) -> string {
            let v13: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v13.clone());
            Spiral_wasm::method82(v13.clone());
            Spiral_wasm::method29(v13.clone());
            Spiral_wasm::method13(v13.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method52(v13.clone());
            Spiral_wasm::method83(v13.clone());
            Spiral_wasm::method29(v13.clone());
            {
                let v945: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method13(v13.clone(), fable_library_rust::String_::fromString(v945));
                Spiral_wasm::method30(v13.clone());
                v13.l0.get().clone()
            }
        }
        pub fn method80(
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
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method81(v8, v9)),
            ))
        }
        pub fn closure34(
            v0_1: Vec<near_workspaces::result::ExecutionOutcome>,
            v1: i32,
            unitVar: (),
        ) {
            fn v63() {
                Spiral_wasm::closure14((), ());
            }
            let v64: () = {
                v63();
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
            let v160: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1235: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v160,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v229: () = {
                        v63();
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
                    let v283: Option<i64> = patternInput_1.5.clone();
                    let v282: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v278: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v327: string = Spiral_wasm::method80(
                        v278.clone(),
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        v283.clone(),
                        Spiral_wasm::method18(v278, v279, v280, v281, v282, v283),
                        Spiral_wasm::method22(),
                        v1,
                        v0_1,
                    );
                    let v389: () = {
                        v63();
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
                    let v439: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v438: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v491: () = {
                        Spiral_wasm::closure16(v438.clone(), ());
                        ()
                    };
                    println!("{}", v327.clone());
                    (v439.l0.get().clone())(v327);
                    Spiral_wasm::US12::US12_0(
                        v438,
                        v439,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn method86(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("json"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method85(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v12.clone());
            Spiral_wasm::method86(v12.clone());
            Spiral_wasm::method29(v12.clone());
            {
                let v418: std::string::String = format!("{:#?}", v0_1);
                Spiral_wasm::method13(v12.clone(), fable_library_rust::String_::fromString(v418));
                Spiral_wasm::method30(v12.clone());
                v12.l0.get().clone()
            }
        }
        pub fn method84(
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
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method85(v8)),
            ))
        }
        pub fn closure35(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            fn v62() {
                Spiral_wasm::closure14((), ());
            }
            let v63: () = {
                v62();
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
            let v159: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1234: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v159,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v228: () = {
                        v62();
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
                    let v282: Option<i64> = patternInput_1.5.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v278: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v277: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v326: string = Spiral_wasm::method84(
                        v277.clone(),
                        v278.clone(),
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        Spiral_wasm::method18(v277, v278, v279, v280, v281, v282),
                        Spiral_wasm::method22(),
                        v0_1,
                    );
                    let v388: () = {
                        v62();
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
                    let v438: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v437: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v490: () = {
                        Spiral_wasm::closure16(v437.clone(), ());
                        ()
                    };
                    println!("{}", v326.clone());
                    (v438.l0.get().clone())(v326);
                    Spiral_wasm::US12::US12_0(
                        v437,
                        v438,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn method89(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("borsh"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method88(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v12.clone());
            Spiral_wasm::method89(v12.clone());
            Spiral_wasm::method29(v12.clone());
            {
                let v418: std::string::String = format!("{:#?}", v0_1);
                Spiral_wasm::method13(v12.clone(), fable_library_rust::String_::fromString(v418));
                Spiral_wasm::method30(v12.clone());
                v12.l0.get().clone()
            }
        }
        pub fn method87(
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
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method88(v8)),
            ))
        }
        pub fn closure36(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            fn v62() {
                Spiral_wasm::closure14((), ());
            }
            let v63: () = {
                v62();
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
            let v159: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1234: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v159,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v228: () = {
                        v62();
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
                    let v282: Option<i64> = patternInput_1.5.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v278: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v277: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v326: string = Spiral_wasm::method87(
                        v277.clone(),
                        v278.clone(),
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        Spiral_wasm::method18(v277, v278, v279, v280, v281, v282),
                        Spiral_wasm::method22(),
                        v0_1,
                    );
                    let v388: () = {
                        v62();
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
                    let v438: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v437: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v490: () = {
                        Spiral_wasm::closure16(v437.clone(), ());
                        ()
                    };
                    println!("{}", v326.clone());
                    (v438.l0.get().clone())(v326);
                    Spiral_wasm::US12::US12_0(
                        v437,
                        v438,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn method90(
            v0_1: i32,
            v1: u8,
            v2: Vec<&near_workspaces::result::ExecutionOutcome>,
        ) -> string {
            let v14: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v14.clone());
            Spiral_wasm::method82(v14.clone());
            Spiral_wasm::method29(v14.clone());
            Spiral_wasm::method13(v14.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method52(v14.clone());
            Spiral_wasm::method51(v14.clone());
            Spiral_wasm::method29(v14.clone());
            Spiral_wasm::method13(v14.clone(), sprintf!("{}", v1));
            Spiral_wasm::method52(v14.clone());
            Spiral_wasm::method78(v14.clone());
            Spiral_wasm::method29(v14.clone());
            {
                let v1472: std::string::String = format!("{:#?}", v2);
                Spiral_wasm::method13(v14.clone(), fable_library_rust::String_::fromString(v1472));
                Spiral_wasm::method30(v14.clone());
                v14.l0.get().clone()
            }
        }
        pub fn method48(
            v0_1: Vec<u8>,
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
                    > = Box::pin(v13.dev_deploy(&v0_1));
                    let v17: Result<near_workspaces::Contract, near_workspaces::error::Error> =
                        v15.await;
                    let v19: near_workspaces::Contract = v17?;
                    let v2587: () = {
                        Spiral_wasm::closure21(v1, v11, v19.clone(), ());
                        ()
                    };
                    let v3879: near_workspaces::operations::CallTransaction =
                        v19.call(&*string("state_main"));
                    let v3881: near_workspaces::types::Gas =
                        near_workspaces::types::Gas::from_tgas(300);
                    let v3883: near_workspaces::operations::CallTransaction = v3879.gas(v3881);
                    let v3885: std::pin::Pin<
                        Box<
                            dyn std::future::Future<
                                    Output = Result<
                                        near_workspaces::result::ExecutionFinalResult,
                                        near_workspaces::error::Error,
                                    >,
                                >,
                        >,
                    > = Box::pin(v3883.transact());
                    let v3887: Result<
                        near_workspaces::result::ExecutionFinalResult,
                        near_workspaces::error::Error,
                    > = v3885.await;
                    let v3889: near_workspaces::result::ExecutionFinalResult = v3887?;
                    let v6457: () = {
                        Spiral_wasm::closure22(v1, v3889.clone(), ());
                        ()
                    };
                    let v7748: Vec<&str> = v3889.logs();
                    let v7750: bool = true;
                    let _vec_map: Vec<_> = v7748
                        .into_iter()
                        .map(|x| {
                            //;
                            let v7752: &str = x;
                            let v7937: std::string::String = String::from(v7752);
                            let v8399: bool = true;
                            v7937
                        })
                        .collect::<Vec<_>>();
                    let v8401: Vec<std::string::String> = _vec_map;
                    let v8404: bool = true;
                    v8401.iter().for_each(|x| {
                        Func1::new(move |v: std::string::String| Spiral_wasm::closure23((), v))(
                            x.clone(),
                        );
                    }); //;
                    let v10655: () = {
                        Spiral_wasm::closure25((), ());
                        ()
                    };
                    let v11787: near_workspaces::types::Gas = v3889.clone().total_gas_burnt;
                    let v11789: u64 = v11787.as_gas();
                    let v14451: () = {
                        Spiral_wasm::closure26(
                            v1,
                            v11789,
                            ((v11789 as f64) / 10000000000000000.0_f64) * 6.68_f64,
                            (),
                        );
                        ()
                    };
                    let v15742: near_workspaces::result::ExecutionFinalResult = v3889.clone();
                    let v15744: Vec<&near_workspaces::result::ExecutionOutcome> = v15742.outcomes();
                    let v15746 = v15744.into_iter();
                    let v15748 = v15746.cloned();
                    let v15751: bool = true;
                    v15748.for_each(|x| {
                        Func1::new(move |v_1: near_workspaces::result::ExecutionOutcome| {
                            Spiral_wasm::closure27((), v_1)
                        })(x)
                    });
                    let v18321: () = {
                        Spiral_wasm::closure29(v3889.clone().into_result(), ());
                        ()
                    };
                    let v19611: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method73(v3889.clone());
                    let v19613: Vec<&near_workspaces::result::ExecutionOutcome> =
                        v19611.receipt_failures();
                    let v19804: Spiral_wasm::US15 = Spiral_wasm::method74(v19613.clone().len());
                    let v19825: Spiral_wasm::US16 = match &v19804 {
                        Spiral_wasm::US15::US15_0(v19804_0_0) => {
                            Spiral_wasm::US16::US16_0(v19804_0_0.clone())
                        }
                        _ => Spiral_wasm::US16::US16_1,
                    };
                    let v19872: i32 = match &v19825 {
                        Spiral_wasm::US16::US16_0(v19825_0_0) => match &v19825 {
                            Spiral_wasm::US16::US16_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v22537: () = {
                        Spiral_wasm::closure33(v19613.clone(), v19872, ());
                        ()
                    };
                    let v23827: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method79(v3889.clone());
                    let v23829: &[near_workspaces::result::ExecutionOutcome] =
                        v23827.receipt_outcomes();
                    let v23831: Vec<near_workspaces::result::ExecutionOutcome> = v23829.into();
                    let v24022: Spiral_wasm::US15 = Spiral_wasm::method74(v23831.clone().len());
                    let v24043: Spiral_wasm::US16 = match &v24022 {
                        Spiral_wasm::US15::US15_0(v24022_0_0) => {
                            Spiral_wasm::US16::US16_0(v24022_0_0.clone())
                        }
                        _ => Spiral_wasm::US16::US16_1,
                    };
                    let v24090: i32 = match &v24043 {
                        Spiral_wasm::US16::US16_0(v24043_0_0) => match &v24043 {
                            Spiral_wasm::US16::US16_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v26755: () = {
                        Spiral_wasm::closure34(v23831, v24090, ());
                        ()
                    };
                    let v30614: () = {
                        Spiral_wasm::closure35(v3889.clone().json(), ());
                        ()
                    };
                    let v34473: () = {
                        Spiral_wasm::closure36(v3889.borsh(), ());
                        ()
                    };
                    let v35763: string = Spiral_wasm::method90(v24090, v1, v19613);
                    let v35820: Result<Spiral_wasm::US10, anyhow::Error> = if (v19872) > 0_i32 {
                        Ok::<Spiral_wasm::US10, anyhow::Error>(Spiral_wasm::US10::US10_0(
                            v35763.clone(),
                        ))
                    } else {
                        if (v24090) > 1_i32 {
                            Ok::<Spiral_wasm::US10, anyhow::Error>(Spiral_wasm::US10::US10_1)
                        } else {
                            let v35803: anyhow::Error = anyhow::anyhow!(v35763);
                            Err(v35803)
                        }
                    };
                    let v35823: string = string("}");
                    let v35828: bool = true;
                    let _fix_closure_v35825 = v35820;
                    let v35834: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v35825 "), (v35823))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v35835: bool = true;
                    _fix_closure_v35825
                },
            ); // rust.fix_closure';
            let v35837 = __future_init;
            v35837
        }
        pub fn closure37(unitVar: (), v0_1: anyhow::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method91() -> Func1<anyhow::Error, std::string::String> {
            Func1::new(move |v: anyhow::Error| Spiral_wasm::closure37((), v))
        }
        pub fn closure38(unitVar: (), v0_1: Spiral_wasm::US10) -> Spiral_wasm::US17 {
            Spiral_wasm::US17::US17_0(v0_1)
        }
        pub fn method92() -> Func1<Spiral_wasm::US10, Spiral_wasm::US17> {
            Func1::new(move |v: Spiral_wasm::US10| Spiral_wasm::closure38((), v))
        }
        pub fn closure39(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US17 {
            Spiral_wasm::US17::US17_1(v0_1)
        }
        pub fn method93() -> Func1<std::string::String, Spiral_wasm::US17> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure39((), v))
        }
        pub fn method94() -> string {
            let v4: &str = inline_colorization::color_yellow;
            let v189: std::string::String = String::from(v4);
            let v1978: string = append(
                (fable_library_rust::String_::fromString(v189)),
                (Spiral_wasm::method23(getCharAt(toLower(string("Warning")), 0_i32))),
            );
            let v1994: &str = inline_colorization::color_reset;
            let v2179: std::string::String = String::from(v1994);
            append((v1978), (fable_library_rust::String_::fromString(v2179)))
        }
        pub fn method97(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("error"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method96(v0_1: u8, v1: std::string::String) -> string {
            let v13: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v13.clone());
            Spiral_wasm::method51(v13.clone());
            Spiral_wasm::method29(v13.clone());
            Spiral_wasm::method13(v13.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method52(v13.clone());
            Spiral_wasm::method97(v13.clone());
            Spiral_wasm::method29(v13.clone());
            {
                let v945: std::string::String = format!("{:#?}", v1);
                Spiral_wasm::method13(v13.clone(), fable_library_rust::String_::fromString(v945));
                Spiral_wasm::method30(v13.clone());
                v13.l0.get().clone()
            }
        }
        pub fn method95(
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
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run / Error error"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method96(v8, v9)),
            ))
        }
        pub fn closure40(v0_1: u8, v1: std::string::String, unitVar: ()) {
            fn v63() {
                Spiral_wasm::closure14((), ());
            }
            let v64: () = {
                v63();
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
            let v160: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1235: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    3_i32
                        >= (find(
                            v160,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v229: () = {
                        v63();
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
                    let v283: Option<i64> = patternInput_1.5.clone();
                    let v282: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v278: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v327: string = Spiral_wasm::method95(
                        v278.clone(),
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        v283.clone(),
                        Spiral_wasm::method18(v278, v279, v280, v281, v282, v283),
                        Spiral_wasm::method94(),
                        v0_1,
                        v1,
                    );
                    let v389: () = {
                        v63();
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
                    let v439: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v438: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v491: () = {
                        Spiral_wasm::closure16(v438.clone(), ());
                        ()
                    };
                    println!("{}", v327.clone());
                    (v439.l0.get().clone())(v327);
                    Spiral_wasm::US12::US12_0(
                        v438,
                        v439,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn closure41(unitVar: (), unitVar_1: ()) {
            fn v61() {
                Spiral_wasm::closure14((), ());
            }
            let v62: () = {
                v61();
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
            let v158: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1071: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    3_i32
                        >= (find(
                            v158,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v227: () = {
                        v61();
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
                    let v277: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v276: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v329: () = {
                        Spiral_wasm::closure16(v276.clone(), ());
                        ()
                    };
                    println!("{}", string("\n"));
                    (v277.l0.get().clone())(string("\n"));
                    Spiral_wasm::US12::US12_0(
                        v276,
                        v277,
                        patternInput_1.2.clone(),
                        patternInput_1.3.clone(),
                        patternInput_1.4.clone(),
                        patternInput_1.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn closure42(v0_1: u8, v1: std::string::String, unitVar: ()) {
            fn v63() {
                Spiral_wasm::closure14((), ());
            }
            let v64: () = {
                v63();
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
            let v160: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1235: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    3_i32
                        >= (find(
                            v160,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v229: () = {
                        v63();
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
                    let v283: Option<i64> = patternInput_1.5.clone();
                    let v282: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v278: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v327: string = Spiral_wasm::method95(
                        v278.clone(),
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        v283.clone(),
                        Spiral_wasm::method18(v278, v279, v280, v281, v282, v283),
                        Spiral_wasm::method94(),
                        v0_1,
                        v1,
                    );
                    let v389: () = {
                        v63();
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
                    let v439: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v438: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v491: () = {
                        Spiral_wasm::closure16(v438.clone(), ());
                        ()
                    };
                    println!("{}", v327.clone());
                    (v439.l0.get().clone())(v327);
                    Spiral_wasm::US12::US12_0(
                        v438,
                        v439,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn closure43(unitVar: (), unitVar_1: ()) {
            fn v61() {
                Spiral_wasm::closure14((), ());
            }
            let v62: () = {
                v61();
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
            let v158: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1071: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    3_i32
                        >= (find(
                            v158,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v227: () = {
                        v61();
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
                    let v277: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v276: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v329: () = {
                        Spiral_wasm::closure16(v276.clone(), ());
                        ()
                    };
                    println!("{}", string("\n"));
                    (v277.l0.get().clone())(string("\n"));
                    Spiral_wasm::US12::US12_0(
                        v276,
                        v277,
                        patternInput_1.2.clone(),
                        patternInput_1.3.clone(),
                        patternInput_1.4.clone(),
                        patternInput_1.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn method98() -> string {
            let v4: &str = inline_colorization::color_bright_red;
            let v189: std::string::String = String::from(v4);
            let v1978: string = append(
                (fable_library_rust::String_::fromString(v189)),
                (Spiral_wasm::method23(getCharAt(toLower(string("Critical")), 0_i32))),
            );
            let v1994: &str = inline_colorization::color_reset;
            let v2179: std::string::String = String::from(v1994);
            append((v1978), (fable_library_rust::String_::fromString(v2179)))
        }
        pub fn method100(v0_1: u8, v1: string) -> string {
            let v13: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v13.clone());
            Spiral_wasm::method51(v13.clone());
            Spiral_wasm::method29(v13.clone());
            Spiral_wasm::method13(v13.clone(), sprintf!("{}", v0_1));
            Spiral_wasm::method52(v13.clone());
            Spiral_wasm::method97(v13.clone());
            Spiral_wasm::method29(v13.clone());
            Spiral_wasm::method13(v13.clone(), v1);
            Spiral_wasm::method30(v13.clone());
            v13.l0.get().clone()
        }
        pub fn method99(
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
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run / Ok (Some error)"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method100(v8, v9)),
            ))
        }
        pub fn closure44(v0_1: u8, v1: string, unitVar: ()) {
            fn v63() {
                Spiral_wasm::closure14((), ());
            }
            let v64: () = {
                v63();
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
            let v160: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1235: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    4_i32
                        >= (find(
                            v160,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v229: () = {
                        v63();
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
                    let v283: Option<i64> = patternInput_1.5.clone();
                    let v282: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v278: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v327: string = Spiral_wasm::method99(
                        v278.clone(),
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        v283.clone(),
                        Spiral_wasm::method18(v278, v279, v280, v281, v282, v283),
                        Spiral_wasm::method98(),
                        v0_1,
                        v1,
                    );
                    let v389: () = {
                        v63();
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
                    let v439: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v438: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v491: () = {
                        Spiral_wasm::closure16(v438.clone(), ());
                        ()
                    };
                    println!("{}", v327.clone());
                    (v439.l0.get().clone())(v327);
                    Spiral_wasm::US12::US12_0(
                        v438,
                        v439,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn method47(
            v0_1: Vec<u8>,
            v1: u8,
        ) -> std::pin::Pin<Box<dyn std::future::Future<Output = Spiral_wasm::US14>>> {
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
                    > = Spiral_wasm::method48(v0_1.clone(), v1);
                    let v10: Result<Spiral_wasm::US10, anyhow::Error> = v8.await;
                    let v11 = Spiral_wasm::method91();
                    let v24: Result<Spiral_wasm::US10, std::string::String> =
                        v10.map_err(|x| v11(x));
                    let v27 = Spiral_wasm::method92();
                    let v28 = Spiral_wasm::method93();
                    let v31: Spiral_wasm::US17 = match &v24 {
                        Err(v24_1_0) => v28(v24_1_0.clone()),
                        Ok(v24_0_0) => v27(v24_0_0.clone()),
                    };
                    let v18460: Spiral_wasm::US14 = match &v31 {
                        Spiral_wasm::US17::US17_0(v31_0_0) => {
                            let v43: Spiral_wasm::US10 = v31_0_0.clone();
                            match &v43 {
                                Spiral_wasm::US10::US10_0(v43_0_0) => {
                                    let v74: string = match &v43 {
                                        Spiral_wasm::US10::US10_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone();
                                    let v2642: () = {
                                        Spiral_wasm::closure44(v1, v74.clone(), ());
                                        ()
                                    };
                                    let v3933: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v3935: bool = */
                                        async move {
                                            /*;
                                            let v3937: bool = */
                                            ();
                                            let v3940: string = string("}");
                                            let v3946: bool = true;
                                            let _fix_closure_v3943 =
                                                (v1, Spiral_wasm::US10::US10_0(v74));
                                            let v3952: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v3943 "),
                                                            (v3940),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v3953: bool = true;
                                            _fix_closure_v3943
                                        },
                                    ); // rust.fix_closure';
                                    let v3955 = __future_init;
                                    let v3957: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<
                                                    Output = (u8, Spiral_wasm::US10),
                                                >,
                                        >,
                                    > = v3955;
                                    let patternInput_2: (u8, Spiral_wasm::US10) = v3957.await;
                                    Spiral_wasm::US14::US14_1(
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone(),
                                    )
                                }
                                _ => {
                                    let v45: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v47: bool = */
                                        async move {
                                            /*;
                                            let v49: bool = */
                                            ();
                                            let v52: string = string("}");
                                            let v58: bool = true;
                                            let _fix_closure_v55 = (v1, Spiral_wasm::US10::US10_1);
                                            let v64: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v55 "),
                                                            (v52),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v65: bool = true;
                                            _fix_closure_v55
                                        },
                                    ); // rust.fix_closure';
                                    let v67 = __future_init;
                                    let v69: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<
                                                    Output = (u8, Spiral_wasm::US10),
                                                >,
                                        >,
                                    > = v67;
                                    let patternInput_1: (u8, Spiral_wasm::US10) = v69.await;
                                    Spiral_wasm::US14::US14_0(
                                        patternInput_1.0.clone(),
                                        patternInput_1.1.clone(),
                                    )
                                }
                            }
                        }
                        Spiral_wasm::US17::US17_1(v31_1_0) => {
                            let v3964: std::string::String = v31_1_0.clone();
                            if (v1) >= 15_u8 {
                                let v6533: () = {
                                    Spiral_wasm::closure40(v1, v3964.clone(), ());
                                    ()
                                };
                                let v10067: () = {
                                    Spiral_wasm::closure41((), ());
                                    ()
                                };
                                let v11196: bool = true;
                                let __future_init = Box::pin(
                                    /*;
                                    let v11198: bool = */
                                    async move {
                                        /*;
                                        let v11200: bool = */
                                        ();
                                        let v11203: string = string("}");
                                        let v11209: bool = true;
                                        let _fix_closure_v11206 = (v1, Spiral_wasm::US10::US10_1);
                                        let v11215: string = append(
                                            (append(
                                                (append(
                                                    (append(
                                                        string("true; _fix_closure_v11206 "),
                                                        (v11203),
                                                    )),
                                                    string("); "),
                                                )),
                                                string(""),
                                            )),
                                            string(" // rust.fix_closure\'"),
                                        );
                                        let v11216: bool = true;
                                        _fix_closure_v11206
                                    },
                                ); // rust.fix_closure';
                                let v11218 = __future_init;
                                let v11220: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = (u8, Spiral_wasm::US10)>>,
                                > = v11218;
                                let patternInput: (u8, Spiral_wasm::US10) = v11220.await;
                                Spiral_wasm::US14::US14_0(
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                )
                            } else {
                                let v13792: () = {
                                    Spiral_wasm::closure42(v1, v3964, ());
                                    ()
                                };
                                let v17326: () = {
                                    Spiral_wasm::closure43((), ());
                                    ()
                                };
                                let v18455: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = Spiral_wasm::US14>>,
                                > = Spiral_wasm::method47(v0_1.clone(), (v1) + 1_u8);
                                v18455.await
                            }
                        }
                    };
                    let v18463: string = string("}");
                    let v18468: bool = true;
                    let _fix_closure_v18465 = v18460;
                    let v18474: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v18465 "), (v18463))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v18475: bool = true;
                    _fix_closure_v18465
                },
            ); // rust.fix_closure';
            let v18477 = __future_init;
            v18477
        }
        pub fn method103(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v7: string = append((v0_1.l0.get().clone()), string("retries"));
            v0_1.l0.set(v7);
            ()
        }
        pub fn method102(v0_1: Spiral_wasm::US14) -> string {
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v12.clone());
            Spiral_wasm::method103(v12.clone());
            Spiral_wasm::method29(v12.clone());
            Spiral_wasm::method13(v12.clone(), sprintf!("{:?}", v0_1));
            Spiral_wasm::method30(v12.clone());
            v12.l0.get().clone()
        }
        pub fn method101(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: Spiral_wasm::US14,
        ) -> string {
            Spiral_wasm::method31(append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append((v6), string(" "))),
                                    (Spiral_wasm::method25(v0_1.l0.get().clone())),
                                )),
                                (v7),
                            )),
                            string(" "),
                        )),
                        string("spiral_wasm.run"),
                    )),
                    string(" / "),
                )),
                (Spiral_wasm::method102(v8)),
            ))
        }
        pub fn closure45(v0_1: Spiral_wasm::US14, unitVar: ()) {
            fn v62() {
                Spiral_wasm::closure14((), ());
            }
            let v63: () = {
                v62();
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
            let v159: Spiral_wasm::US5 = (patternInput.4.clone()).l0.get().clone();
            let v1234: Spiral_wasm::US12 =
                if (if ((patternInput.2.clone()).l0.get().clone()) == false {
                    false
                } else {
                    0_i32
                        >= (find(
                            v159,
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
                    Spiral_wasm::US12::US12_1
                } else {
                    let v228: () = {
                        v62();
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
                    let v282: Option<i64> = patternInput_1.5.clone();
                    let v281: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                    let v280: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                    let v279: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                    let v278: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                    let v277: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                    let v326: string = Spiral_wasm::method101(
                        v277.clone(),
                        v278.clone(),
                        v279.clone(),
                        v280.clone(),
                        v281.clone(),
                        v282.clone(),
                        Spiral_wasm::method18(v277, v278, v279, v280, v281, v282),
                        Spiral_wasm::method22(),
                        v0_1,
                    );
                    let v388: () = {
                        v62();
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
                    let v438: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                    let v437: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                    let v490: () = {
                        Spiral_wasm::closure16(v437.clone(), ());
                        ()
                    };
                    println!("{}", v326.clone());
                    (v438.l0.get().clone())(v326);
                    Spiral_wasm::US12::US12_0(
                        v437,
                        v438,
                        patternInput_2.2.clone(),
                        patternInput_2.3.clone(),
                        patternInput_2.4.clone(),
                        patternInput_2.5.clone(),
                    )
                };
            ();
            ()
        }
        pub fn method104(v0_1: Spiral_wasm::US14, v1: Spiral_wasm::US10) -> string {
            let v13: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method12()),
            });
            Spiral_wasm::method27(v13.clone());
            Spiral_wasm::method103(v13.clone());
            Spiral_wasm::method29(v13.clone());
            Spiral_wasm::method13(v13.clone(), sprintf!("{:?}", v0_1));
            Spiral_wasm::method52(v13.clone());
            Spiral_wasm::method97(v13.clone());
            Spiral_wasm::method29(v13.clone());
            Spiral_wasm::method13(v13.clone(), sprintf!("{:?}", v1));
            Spiral_wasm::method30(v13.clone());
            v13.l0.get().clone()
        }
        pub fn method42(
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
                    let v7: string = Spiral_wasm::method43();
                    let v192: &str = &*v7;
                    let v654: Option<std::string::String> =
                        clap::ArgMatches::get_one(&v0_1, v192).cloned();
                    let v780: Spiral_wasm::US2 =
                        defaultValue(Spiral_wasm::US2::US2_1, map(Spiral_wasm::method4(), v654));
                    let v796: std::string::String = match &v780 {
                        Spiral_wasm::US2::US2_0(v780_0_0) => match &v780 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v798: string = fable_library_rust::String_::fromString(v796);
                    let v3366: () = {
                        Spiral_wasm::closure20(v798.clone(), ());
                        ()
                    };
                    let v4657: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v798);
                    let v4661: std::pin::Pin<
                        Box<dyn std::future::Future<Output = Spiral_wasm::US14>>,
                    > = Spiral_wasm::method47(v4657?, 1_u8);
                    let v4663: Spiral_wasm::US14 = v4661.await;
                    let v7231: () = {
                        Spiral_wasm::closure45(v4663.clone(), ());
                        ()
                    };
                    let v8558: Result<u8, anyhow::Error> = match &v4663 {
                        Spiral_wasm::US14::US14_0(v4663_0_0, v4663_0_1) => {
                            Ok::<u8, anyhow::Error>(v4663_0_0.clone())
                        }
                        Spiral_wasm::US14::US14_1(v4663_1_0, v4663_1_1) => {
                            let v8539: string =
                                Spiral_wasm::method104(v4663.clone(), v4663_1_1.clone());
                            let v8541: anyhow::Error = anyhow::anyhow!(v8539);
                            Err(v8541)
                        }
                    };
                    let v8561: string = string("}");
                    let v8566: bool = true;
                    let _fix_closure_v8563 = v8558;
                    let v8572: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v8563 "), (v8561))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v8573: bool = true;
                    _fix_closure_v8563
                },
            ); // rust.fix_closure';
            let v8575 = __future_init;
            v8575
        }
        pub fn closure46(unitVar: (), v0_1: u8) -> Spiral_wasm::US18 {
            Spiral_wasm::US18::US18_0(v0_1)
        }
        pub fn method105() -> Func1<u8, Spiral_wasm::US18> {
            Func1::new(move |v: u8| Spiral_wasm::closure46((), v))
        }
        pub fn closure47(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US18 {
            Spiral_wasm::US18::US18_1(v0_1)
        }
        pub fn method106() -> Func1<std::string::String, Spiral_wasm::US18> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure47((), v))
        }
        pub fn closure0(unitVar: (), v0_1: Array<string>) -> i32 {
            let v1: clap::Command = Spiral_wasm::method0();
            let v3: clap::ArgMatches = clap::Command::get_matches(v1);
            let v4: string = Spiral_wasm::method3();
            let v189: &str = &*v4;
            let v651: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v189).cloned();
            let v777: Spiral_wasm::US2 =
                defaultValue(Spiral_wasm::US2::US2_1, map(Spiral_wasm::method4(), v651));
            let v977: Spiral_wasm::US3 = match &v777 {
                Spiral_wasm::US2::US2_0(v777_0_0) => {
                    let v792: string = fable_library_rust::String_::fromString(
                        match &v777 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    );
                    let v799: string = toLower(string("Critical"));
                    let v817: string = toLower(string("Warning"));
                    let v835: string = toLower(string("Info"));
                    let v853: string = toLower(string("Debug"));
                    let v871: string = toLower(string("Verbose"));
                    let v887: Spiral_wasm::US4 = if string("Verbose") == (v792.clone()) {
                        Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_0)
                    } else {
                        Spiral_wasm::US4::US4_1
                    };
                    Spiral_wasm::US3::US3_0(match &v887 {
                        Spiral_wasm::US4::US4_0(v887_0_0) => Spiral_wasm::US4::US4_0(
                            match &v887 {
                                Spiral_wasm::US4::US4_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v894: Spiral_wasm::US4 = if string("Debug") == (v792.clone()) {
                                Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_1)
                            } else {
                                Spiral_wasm::US4::US4_1
                            };
                            match &v894 {
                                Spiral_wasm::US4::US4_0(v894_0_0) => Spiral_wasm::US4::US4_0(
                                    match &v894 {
                                        Spiral_wasm::US4::US4_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v901: Spiral_wasm::US4 = if string("Info") == (v792.clone())
                                    {
                                        Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_2)
                                    } else {
                                        Spiral_wasm::US4::US4_1
                                    };
                                    match &v901 {
                                        Spiral_wasm::US4::US4_0(v901_0_0) => {
                                            Spiral_wasm::US4::US4_0(
                                                match &v901 {
                                                    Spiral_wasm::US4::US4_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            )
                                        }
                                        _ => {
                                            let v908: Spiral_wasm::US4 =
                                                if string("Warning") == (v792.clone()) {
                                                    Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_3)
                                                } else {
                                                    Spiral_wasm::US4::US4_1
                                                };
                                            match &v908 {
                                                Spiral_wasm::US4::US4_0(v908_0_0) => {
                                                    Spiral_wasm::US4::US4_0(
                                                        match &v908 {
                                                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => {
                                                    let v915: Spiral_wasm::US4 =
                                                        if string("Critical") == (v792.clone()) {
                                                            Spiral_wasm::US4::US4_0(
                                                                Spiral_wasm::US5::US5_4,
                                                            )
                                                        } else {
                                                            Spiral_wasm::US4::US4_1
                                                        };
                                                    match &v915 {
                                                        Spiral_wasm::US4::US4_0(v915_0_0) => {
                                                            Spiral_wasm::US4::US4_0(
                                                                match &v915 {
                                                                    Spiral_wasm::US4::US4_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            let v922: Spiral_wasm::US4 =
                                                                if (v871.clone()) == (v792.clone())
                                                                {
                                                                    Spiral_wasm::US4::US4_0(
                                                                        Spiral_wasm::US5::US5_0,
                                                                    )
                                                                } else {
                                                                    Spiral_wasm::US4::US4_1
                                                                };
                                                            match &v922 {
                                                                Spiral_wasm::US4::US4_0(
                                                                    v922_0_0,
                                                                ) => Spiral_wasm::US4::US4_0(
                                                                    match &v922 {
                                                                        Spiral_wasm::US4::US4_0(
                                                                            x,
                                                                        ) => x.clone(),
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                ),
                                                                _ => {
                                                                    let v929: Spiral_wasm::US4 =
                                                                        if (v853.clone())
                                                                            == (v792.clone())
                                                                        {
                                                                            Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_1)
                                                                        } else {
                                                                            Spiral_wasm::US4::US4_1
                                                                        };
                                                                    match &v929
                                                                                                    {
                                                                                                    Spiral_wasm::US4::US4_0(v929_0_0)
                                                                                                    =>
                                                                                                    Spiral_wasm::US4::US4_0(match &v929
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
                                                                                                        let v936:
                                                                                                                Spiral_wasm::US4 =
                                                                                                            if (v835.clone())
                                                                                                                   ==
                                                                                                                   (v792.clone())
                                                                                                               {
                                                                                                                Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_2)
                                                                                                            } else {
                                                                                                                Spiral_wasm::US4::US4_1
                                                                                                            };
                                                                                                        match &v936
                                                                                                            {
                                                                                                            Spiral_wasm::US4::US4_0(v936_0_0)
                                                                                                            =>
                                                                                                            Spiral_wasm::US4::US4_0(match &v936
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
                                                                                                                let v943:
                                                                                                                        Spiral_wasm::US4 =
                                                                                                                    if (v817.clone())
                                                                                                                           ==
                                                                                                                           (v792.clone())
                                                                                                                       {
                                                                                                                        Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_3)
                                                                                                                    } else {
                                                                                                                        Spiral_wasm::US4::US4_1
                                                                                                                    };
                                                                                                                match &v943
                                                                                                                    {
                                                                                                                    Spiral_wasm::US4::US4_0(v943_0_0)
                                                                                                                    =>
                                                                                                                    Spiral_wasm::US4::US4_0(match &v943
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
                                                                                                                        let v950:
                                                                                                                                Spiral_wasm::US4 =
                                                                                                                            if (v799.clone())
                                                                                                                                   ==
                                                                                                                                   (v792.clone())
                                                                                                                               {
                                                                                                                                Spiral_wasm::US4::US4_0(Spiral_wasm::US5::US5_4)
                                                                                                                            } else {
                                                                                                                                Spiral_wasm::US4::US4_1
                                                                                                                            };
                                                                                                                        match &v950
                                                                                                                            {
                                                                                                                            Spiral_wasm::US4::US4_0(v950_0_0)
                                                                                                                            =>
                                                                                                                            Spiral_wasm::US4::US4_0(match &v950
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
            let v984: Spiral_wasm::US4 = if let Spiral_wasm::US3::US3_0(v977_0_0) = &v977 {
                let v978: Spiral_wasm::US4 = v977_0_0.clone();
                if let Spiral_wasm::US4::US4_0(v978_0_0) = &v978 {
                    Spiral_wasm::US4::US4_0(v978_0_0.clone())
                } else {
                    Spiral_wasm::US4::US4_1
                }
            } else {
                Spiral_wasm::US4::US4_1
            };
            let v1047: () = {
                Spiral_wasm::closure7(
                    match &v984 {
                        Spiral_wasm::US4::US4_0(v984_0_0) => match &v984 {
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
            let v3707: () = {
                Spiral_wasm::closure13(v0_1, ());
                ()
            };
            let v4997: string = Spiral_wasm::method37();
            let v5182: &str = &*v4997;
            let v5644: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v5182).cloned();
            let v7162: Option<string> = map(Spiral_wasm::method38(), v5644);
            let v8800: Spiral_wasm::US10 = defaultValue(
                Spiral_wasm::US10::US10_1,
                map(Spiral_wasm::method16(), v7162),
            );
            let v8813: std::pin::Pin<
                Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>,
            > = Spiral_wasm::method42(v3);
            let v8815 = tokio::runtime::Builder::new_multi_thread()
                .enable_all()
                .build()
                .unwrap();
            let v8817: Result<u8, anyhow::Error> = v8815.handle().block_on(v8813);
            let v8818 = Spiral_wasm::method91();
            let v8831: Result<u8, std::string::String> = v8817.map_err(|x| v8818(x));
            let v8834 = Spiral_wasm::method105();
            let v8835 = Spiral_wasm::method106();
            let v8838: Spiral_wasm::US18 = match &v8831 {
                Err(v8831_1_0) => v8835(v8831_1_0.clone()),
                Ok(v8831_0_0) => v8834(v8831_0_0.clone()),
            };
            match &v8838 {
                Spiral_wasm::US18::US18_0(v8838_0_0) => {
                    if let Spiral_wasm::US10::US10_0(v8800_0_0) = &v8800 {
                        let v8852: string = sprintf!(
                            "spiral_wasm.main / retries: {} / exception: \'{}\'",
                            v8838_0_0.clone(),
                            v8800_0_0.clone()
                        );
                        let v8857: Result<(), string> = Err(v8852);
                        v8857.unwrap();
                        ()
                    }
                }
                Spiral_wasm::US18::US18_1(v8838_1_0) => {
                    let v8869: std::string::String = v8838_1_0.clone();
                    if let Spiral_wasm::US10::US10_0(v8800_0_0) = &v8800 {
                        let v8870: string = v8800_0_0.clone();
                        if string("") == (v8870.clone()) {
                            ()
                        } else {
                            if contains(
                                fable_library_rust::String_::fromString(v8869.clone()),
                                v8870.clone(),
                            ) {
                                ()
                            } else {
                                let v8888: string = sprintf!(
                                    "spiral_wasm.main / exception: \'{}\' / error: {}",
                                    v8870,
                                    v8869
                                );
                                let v8893: Result<(), string> = Err(v8888);
                                v8893.unwrap();
                                ()
                            }
                        }
                    } else {
                        let v8906: u8 = v8831.clone().unwrap();
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
