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
        use fable_library_rust::List_::empty;
        use fable_library_rust::List_::ofArray;
        use fable_library_rust::List_::singleton;
        use fable_library_rust::List_::toArray;
        use fable_library_rust::Map_::find;
        use fable_library_rust::Map_::ofSeq;
        use fable_library_rust::Native_::Any;
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
        use fable_library_rust::String_::printfn;
        use fable_library_rust::String_::sprintf;
        use fable_library_rust::String_::string;
        use fable_library_rust::String_::toLower;
        use fable_library_rust::String_::toString;
        use fable_library_rust::String_::trimEndChars;
        use fable_library_rust::String_::trimStartChars;
        use fable_library_rust::System::Collections::Generic::IEnumerable_1;
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
            US0_0(std::string::String),
            US0_1,
        }
        impl core::fmt::Display for US0 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US3 {
            US3_0,
            US3_1,
            US3_2,
            US3_3,
            US3_4,
        }
        impl core::fmt::Display for US3 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US2 {
            US2_0(Spiral_wasm::US3),
            US2_1,
        }
        impl core::fmt::Display for US2 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US1 {
            US1_0(Spiral_wasm::US2),
            US1_1,
        }
        impl core::fmt::Display for US1 {
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
            pub l0: MutCell<Spiral_wasm::US3>,
        }
        impl core::fmt::Display for Mut4 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US4 {
            US4_0(i64),
            US4_1,
        }
        impl core::fmt::Display for US4 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US5 {
            US5_0,
            US5_1,
            US5_2,
        }
        impl core::fmt::Display for US5 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US6 {
            US6_0(Spiral_wasm::US5),
            US6_1(Spiral_wasm::US5),
            US6_2(Spiral_wasm::US5),
            US6_3(Spiral_wasm::US5),
            US6_4(Spiral_wasm::US5),
            US6_5(Spiral_wasm::US5),
            US6_6(Spiral_wasm::US5),
        }
        impl core::fmt::Display for US6 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US7 {
            US7_0(string),
            US7_1,
        }
        impl core::fmt::Display for US7 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US8 {
            US8_0(
                LrcPtr<Spiral_wasm::Mut0>,
                LrcPtr<Spiral_wasm::Mut1>,
                LrcPtr<Spiral_wasm::Mut2>,
                LrcPtr<Spiral_wasm::Mut3>,
                LrcPtr<Spiral_wasm::Mut4>,
                Option<i64>,
            ),
            US8_1,
        }
        impl core::fmt::Display for US8 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US9 {
            US9_0(u8, Spiral_wasm::US7),
            US9_1(u8, Spiral_wasm::US7),
        }
        impl core::fmt::Display for US9 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US10 {
            US10_0(Spiral_wasm::US7),
            US10_1(std::string::String),
        }
        impl core::fmt::Display for US10 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US11 {
            US11_0(u8),
            US11_1(std::string::String),
        }
        impl core::fmt::Display for US11 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        pub fn method0() -> clap::Command {
            let v1: string = string("r#\"command\"#");
            let v2: &'static str = r#"command"#;
            let v4: clap::Command = clap::Command::new(v2);
            let v6: clap::Command = clap::Command::args_override_self(v4, true);
            let v8: usize = 0_i32 as usize;
            let v12: usize = 1_i32 as usize;
            let v28: clap::builder::ValueRange = if (v12) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v8..)
            } else {
                let v26: string = string("clap::builder::ValueRange::new($0..=$1)");
                clap::builder::ValueRange::new(v8..=v12)
            };
            let v30: string = string("r#\"exception\"#");
            let v31: &'static str = r#"exception"#;
            let v33: clap::Arg = clap::Arg::new(v31);
            let v35: clap::Arg = v33.short('e');
            let v36: string = string("r#\"exception\"#");
            let v37: &'static str = r#"exception"#;
            let v39: clap::Arg = v35.long(v37);
            let v41: clap::Arg = v39.num_args(v28);
            let v43: clap::Arg = v41.require_equals(true);
            let v45: string = string("r#\"\"#");
            let v46: &str = r#""#;
            let v48: clap::Arg = v43.default_missing_value(v46);
            let v50: clap::Command = clap::Command::arg(v6, v48);
            let v52: string = string("r#\"trace_level\"#");
            let v53: &'static str = r#"trace_level"#;
            let v55: clap::Arg = clap::Arg::new(v53);
            let v57: clap::Arg = v55.short('t');
            let v58: string = string("r#\"trace_level\"#");
            let v59: &'static str = r#"trace_level"#;
            let v61: clap::Arg = v57.long(v59);
            let v66: string = toLower(string("Critical"));
            let v73: string = toLower(string("Warning"));
            let v80: string = toLower(string("Info"));
            let v87: string = toLower(string("Debug"));
            let v122: Array<string> = toArray(ofArray(new_array(&[
                toLower(string("Verbose")),
                v87,
                v80,
                v73,
                v66,
            ])));
            let v126: Vec<string> = v122.to_vec();
            let v128: bool = true;
            let _vec_map: Vec<_> = v126
                .into_iter()
                .map(|x| {
                    //;
                    let v130: string = x;
                    let v137: &str = &*v130;
                    let v173: std::string::String = String::from(v137);
                    let v204: Box<std::string::String> = Box::new(v173);
                    let v206: &'static mut std::string::String = Box::leak(v204);
                    let v208: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v206);
                    let v210: bool = true;
                    v208
                })
                .collect::<Vec<_>>();
            let v212: Vec<clap::builder::PossibleValue> = _vec_map;
            let v214: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v212),
            );
            let v216: clap::Arg = v61.value_parser(v214);
            let v218: clap::Command = clap::Command::arg(v50, v216);
            let v220: string = string("r#\"wasm\"#");
            let v221: &'static str = r#"wasm"#;
            let v223: clap::Arg = clap::Arg::new(v221);
            let v225: clap::Arg = v223.short('w');
            let v226: string = string("r#\"wasm\"#");
            let v227: &'static str = r#"wasm"#;
            let v229: clap::Arg = v225.long(v227);
            let v231: clap::Arg = v229.required(true);
            clap::Command::arg(v218, v231)
        }
        pub fn method1() -> string {
            string("trace_level")
        }
        pub fn closure1(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US0 {
            Spiral_wasm::US0::US0_0(v0_1)
        }
        pub fn method2() -> Func1<std::string::String, Spiral_wasm::US0> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure1((), v))
        }
        pub fn method6(v0_1: string) -> string {
            v0_1
        }
        pub fn method7() -> string {
            string("")
        }
        pub fn closure3(unitVar: (), v0_1: string) -> Spiral_wasm::US7 {
            Spiral_wasm::US7::US7_0(v0_1)
        }
        pub fn method8() -> Func1<string, Spiral_wasm::US7> {
            Func1::new(move |v: string| Spiral_wasm::closure3((), v))
        }
        pub fn method5(v0_1: string) -> string {
            let v3: string = Spiral_wasm::method6(v0_1);
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
            let v16: string = Spiral_wasm::method7();
            v15.unwrap_or(v16)
        }
        pub fn method4() -> (Spiral_wasm::US2, Spiral_wasm::US4) {
            let v1: string = Spiral_wasm::method5(string("TRACE_LEVEL"));
            let v6: string = toLower(string("Critical"));
            let v13: string = toLower(string("Warning"));
            let v20: string = toLower(string("Info"));
            let v27: string = toLower(string("Debug"));
            let v34: string = toLower(string("Verbose"));
            let v41: Spiral_wasm::US2 = if string("Verbose") == (v1.clone()) {
                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_0)
            } else {
                Spiral_wasm::US2::US2_1
            };
            (
                match &v41 {
                    Spiral_wasm::US2::US2_0(v41_0_0) => Spiral_wasm::US2::US2_0(
                        match &v41 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    _ => {
                        let v48: Spiral_wasm::US2 = if string("Debug") == (v1.clone()) {
                            Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_1)
                        } else {
                            Spiral_wasm::US2::US2_1
                        };
                        match &v48 {
                            Spiral_wasm::US2::US2_0(v48_0_0) => Spiral_wasm::US2::US2_0(
                                match &v48 {
                                    Spiral_wasm::US2::US2_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => {
                                let v55: Spiral_wasm::US2 = if string("Info") == (v1.clone()) {
                                    Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                } else {
                                    Spiral_wasm::US2::US2_1
                                };
                                match &v55 {
                                    Spiral_wasm::US2::US2_0(v55_0_0) => Spiral_wasm::US2::US2_0(
                                        match &v55 {
                                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => {
                                        let v62: Spiral_wasm::US2 =
                                            if string("Warning") == (v1.clone()) {
                                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                            } else {
                                                Spiral_wasm::US2::US2_1
                                            };
                                        match &v62 {
                                            Spiral_wasm::US2::US2_0(v62_0_0) => {
                                                Spiral_wasm::US2::US2_0(
                                                    match &v62 {
                                                        Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                )
                                            }
                                            _ => {
                                                let v69: Spiral_wasm::US2 = if string("Critical")
                                                    == (v1.clone())
                                                {
                                                    Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_4)
                                                } else {
                                                    Spiral_wasm::US2::US2_1
                                                };
                                                match &v69 {
                                                    Spiral_wasm::US2::US2_0(v69_0_0) => {
                                                        Spiral_wasm::US2::US2_0(
                                                            match &v69 {
                                                                Spiral_wasm::US2::US2_0(x) => {
                                                                    x.clone()
                                                                }
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => {
                                                        let v76: Spiral_wasm::US2 =
                                                            if (v34.clone()) == (v1.clone()) {
                                                                Spiral_wasm::US2::US2_0(
                                                                    Spiral_wasm::US3::US3_0,
                                                                )
                                                            } else {
                                                                Spiral_wasm::US2::US2_1
                                                            };
                                                        match &v76 {
                                                            Spiral_wasm::US2::US2_0(v76_0_0) => {
                                                                Spiral_wasm::US2::US2_0(
                                                                    match &v76 {
                                                                        Spiral_wasm::US2::US2_0(
                                                                            x,
                                                                        ) => x.clone(),
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                )
                                                            }
                                                            _ => {
                                                                let v83: Spiral_wasm::US2 = if (v27
                                                                    .clone())
                                                                    == (v1.clone())
                                                                {
                                                                    Spiral_wasm::US2::US2_0(
                                                                        Spiral_wasm::US3::US3_1,
                                                                    )
                                                                } else {
                                                                    Spiral_wasm::US2::US2_1
                                                                };
                                                                match &v83 {
                                                                 Spiral_wasm::US2::US2_0(v83_0_0)
                                                                 =>
                                                                 Spiral_wasm::US2::US2_0(match &v83
                                                                                             {
                                                                                             Spiral_wasm::US2::US2_0(x)
                                                                                             =>
                                                                                             x.clone(),
                                                                                             _
                                                                                             =>
                                                                                             unreachable!(),
                                                                                         }.clone()),
                                                                 _ => {
                                                                     let v90:
                                                                             Spiral_wasm::US2 =
                                                                         if (v20.clone())
                                                                                ==
                                                                                (v1.clone())
                                                                            {
                                                                             Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                                                         } else {
                                                                             Spiral_wasm::US2::US2_1
                                                                         };
                                                                     match &v90
                                                                         {
                                                                         Spiral_wasm::US2::US2_0(v90_0_0)
                                                                         =>
                                                                         Spiral_wasm::US2::US2_0(match &v90
                                                                                                     {
                                                                                                     Spiral_wasm::US2::US2_0(x)
                                                                                                     =>
                                                                                                     x.clone(),
                                                                                                     _
                                                                                                     =>
                                                                                                     unreachable!(),
                                                                                                 }.clone()),
                                                                         _ =>
                                                                         {
                                                                             let v97:
                                                                                     Spiral_wasm::US2 =
                                                                                 if (v13.clone())
                                                                                        ==
                                                                                        (v1.clone())
                                                                                    {
                                                                                     Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                                                                 } else {
                                                                                     Spiral_wasm::US2::US2_1
                                                                                 };
                                                                             match &v97
                                                                                 {
                                                                                 Spiral_wasm::US2::US2_0(v97_0_0)
                                                                                 =>
                                                                                 Spiral_wasm::US2::US2_0(match &v97
                                                                                                             {
                                                                                                             Spiral_wasm::US2::US2_0(x)
                                                                                                             =>
                                                                                                             x.clone(),
                                                                                                             _
                                                                                                             =>
                                                                                                             unreachable!(),
                                                                                                         }.clone()),
                                                                                 _
                                                                                 =>
                                                                                 {
                                                                                     let v104:
                                                                                             Spiral_wasm::US2 =
                                                                                         if (v6.clone())
                                                                                                ==
                                                                                                (v1.clone())
                                                                                            {
                                                                                             Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_4)
                                                                                         } else {
                                                                                             Spiral_wasm::US2::US2_1
                                                                                         };
                                                                                     match &v104
                                                                                         {
                                                                                         Spiral_wasm::US2::US2_0(v104_0_0)
                                                                                         =>
                                                                                         Spiral_wasm::US2::US2_0(match &v104
                                                                                                                     {
                                                                                                                     Spiral_wasm::US2::US2_0(x)
                                                                                                                     =>
                                                                                                                     x.clone(),
                                                                                                                     _
                                                                                                                     =>
                                                                                                                     unreachable!(),
                                                                                                                 }.clone()),
                                                                                         _
                                                                                         =>
                                                                                         Spiral_wasm::US2::US2_1,
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
                    Spiral_wasm::US4::US4_1
                } else {
                    Spiral_wasm::US4::US4_0({
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    })
                },
            )
        }
        pub fn closure4(unitVar: (), v0_1: string) {
            ();
        }
        pub fn method3(
            v0_1: Spiral_wasm::US3,
        ) -> (
            LrcPtr<Spiral_wasm::Mut0>,
            LrcPtr<Spiral_wasm::Mut1>,
            LrcPtr<Spiral_wasm::Mut2>,
            LrcPtr<Spiral_wasm::Mut3>,
            LrcPtr<Spiral_wasm::Mut4>,
            Option<i64>,
        ) {
            let patternInput: (Spiral_wasm::US2, Spiral_wasm::US4) = Spiral_wasm::method4();
            let _run_target_args__v3: (Spiral_wasm::US2, Spiral_wasm::US4) =
                (patternInput.0.clone(), patternInput.1.clone());
            let v185: Spiral_wasm::US4 = _run_target_args__v3.1.clone();
            let v184: Spiral_wasm::US2 = _run_target_args__v3.0.clone();
            (
                LrcPtr::new(Spiral_wasm::Mut0 {
                    l0: MutCell::new(1_i64),
                }),
                LrcPtr::new(Spiral_wasm::Mut1 {
                    l0: MutCell::new(Func1::new(move |v: string| Spiral_wasm::closure4((), v))),
                }),
                LrcPtr::new(Spiral_wasm::Mut2 {
                    l0: MutCell::new(true),
                }),
                LrcPtr::new(Spiral_wasm::Mut3 {
                    l0: MutCell::new(string("")),
                }),
                LrcPtr::new(Spiral_wasm::Mut4 {
                    l0: MutCell::new(match &v184 {
                        Spiral_wasm::US2::US2_0(v184_0_0) => match &v184 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => v0_1.clone(),
                    }),
                }),
                match &v185 {
                    Spiral_wasm::US4::US4_0(v185_0_0) => Some(match &v185 {
                        Spiral_wasm::US4::US4_0(x) => x.clone(),
                        _ => unreachable!(),
                    }),
                    _ => None::<i64>,
                },
            )
        }
        pub fn closure2(v0_1: Spiral_wasm::US3, unitVar: ()) {
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
        pub fn closure6(unitVar: (), unitVar_1: ()) {
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
                ) = Spiral_wasm::method3(Spiral_wasm::US3::US3_0);
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
        pub fn closure7(unitVar: (), v0_1: i64) -> Spiral_wasm::US4 {
            Spiral_wasm::US4::US4_0(v0_1)
        }
        pub fn method10() -> Func1<i64, Spiral_wasm::US4> {
            Func1::new(move |v: i64| Spiral_wasm::closure7((), v))
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
            let v241: Spiral_wasm::US4 =
                defaultValue(Spiral_wasm::US4::US4_1, map(Spiral_wasm::method10(), v5));
            let v395: DateTime = match &v241 {
                Spiral_wasm::US4::US4_0(v241_0_0) => {
                    let v324: TimeSpan = TimeSpan::new_ticks(
                        ({
                            let _arg: DateTime = DateTime::now();
                            _arg.ticks()
                        }) - (match &v241 {
                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                            _ => unreachable!(),
                        }),
                    );
                    DateTime::new_ymdhms_milli(
                        1_i32,
                        1_i32,
                        1_i32,
                        v324.hours(),
                        v324.minutes(),
                        v324.seconds(),
                        v324.milliseconds(),
                    )
                }
                _ => DateTime::now(),
            };
            let v396: string = Spiral_wasm::method11();
            let provider: string = if (v396.clone()) == string("") {
                string("M-d-y hh:mm:ss tt")
            } else {
                v396
            };
            v395.toString(provider)
        }
        pub fn method15() -> string {
            string("")
        }
        pub fn closure8(v0_1: LrcPtr<Spiral_wasm::Mut3>, v1: string, unitVar: ()) {
            let v4: string = append((v0_1.l0.get().clone()), (v1));
            v0_1.l0.set(v4);
            ()
        }
        pub fn method14(v0_1: char) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v17: () = {
                Spiral_wasm::closure8(v2.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method13() -> string {
            let v3: &str = inline_colorization::color_bright_black;
            let v10: std::string::String = String::from(v3);
            let v139: string = append(
                (fable_library_rust::String_::fromString(v10)),
                (Spiral_wasm::method14(getCharAt(toLower(string("Verbose")), 0_i32))),
            );
            let v145: &str = inline_colorization::color_reset;
            let v152: std::string::String = String::from(v145);
            append((v139), (fable_library_rust::String_::fromString(v152)))
        }
        pub fn method17(v0_1: Array<string>) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v16: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v35: () = {
                Spiral_wasm::closure8(v2.clone(), string("args"), ());
                ()
            };
            let v54: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v76: () = {
                Spiral_wasm::closure8(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v95: () = {
                Spiral_wasm::closure8(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method18(v0_1: string) -> string {
            trimEndChars(
                trimStartChars(v0_1, toArray(empty::<char>())),
                toArray(ofArray(new_array(&[' ', '/']))),
            )
        }
        pub fn method16(
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
            let v9: string = Spiral_wasm::method17(v8);
            Spiral_wasm::method18(append(
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
        pub fn closure9(v0_1: LrcPtr<Spiral_wasm::Mut0>, unitVar: ()) {
            let v2: i64 = (v0_1.l0.get().clone()) + 1_i64;
            v0_1.l0.set(v2);
            ()
        }
        pub fn closure11(v0_1: string, unitVar: ()) {
            printfn!("{0}", v0_1);
        }
        pub fn closure10(unitVar: (), v0_1: string) {
            let v4: () = {
                Spiral_wasm::closure11(v0_1, ());
                ()
            };
            ()
        }
        pub fn closure5(v0_1: Array<string>, unitVar: ()) {
            fn v16() {
                Spiral_wasm::closure6((), ());
            }
            let v17: () = {
                v16();
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
            let v58: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v298: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v58,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v81: () = {
                    v16();
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
                let v109: Option<i64> = patternInput_1.5.clone();
                let v108: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v107: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v106: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v105: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v104: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v124: string = Spiral_wasm::method16(
                    v104.clone(),
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    Spiral_wasm::method9(v104, v105, v106, v107, v108, v109),
                    Spiral_wasm::method13(),
                    v0_1,
                );
                let v140: () = {
                    v16();
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
                let v164: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v163: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v185: () = {
                    Spiral_wasm::closure9(v163.clone(), ());
                    ()
                };
                println!("{}", v124.clone());
                (v164.l0.get().clone())(v124);
                Spiral_wasm::US8::US8_0(
                    v163,
                    v164,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn method19() -> string {
            string("exception")
        }
        pub fn closure12(unitVar: (), v0_1: std::string::String) -> string {
            trimEndChars(
                trimStartChars(
                    fable_library_rust::String_::fromString(v0_1),
                    toArray(singleton('\\')),
                ),
                toArray(singleton('\\')),
            )
        }
        pub fn method20() -> Func1<std::string::String, string> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure12((), v))
        }
        pub fn method22() -> string {
            string("wasm")
        }
        pub fn method24(v0_1: string) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v16: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v35: () = {
                Spiral_wasm::closure8(v2.clone(), string("wasm_path"), ());
                ()
            };
            let v54: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v71: () = {
                Spiral_wasm::closure8(v2.clone(), v0_1, ());
                ()
            };
            let v90: () = {
                Spiral_wasm::closure8(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method23(
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
            let v9: string = Spiral_wasm::method24(v8);
            Spiral_wasm::method18(append(
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
        pub fn closure13(v0_1: string, unitVar: ()) {
            fn v16() {
                Spiral_wasm::closure6((), ());
            }
            let v17: () = {
                v16();
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
            let v58: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v298: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v58,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v81: () = {
                    v16();
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
                let v109: Option<i64> = patternInput_1.5.clone();
                let v108: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v107: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v106: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v105: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v104: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v124: string = Spiral_wasm::method23(
                    v104.clone(),
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    Spiral_wasm::method9(v104, v105, v106, v107, v108, v109),
                    Spiral_wasm::method13(),
                    v0_1,
                );
                let v140: () = {
                    v16();
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
                let v164: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v163: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v185: () = {
                    Spiral_wasm::closure9(v163.clone(), ());
                    ()
                };
                println!("{}", v124.clone());
                (v164.l0.get().clone())(v124);
                Spiral_wasm::US8::US8_0(
                    v163,
                    v164,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn method28(
            v0_1: u8,
            v1: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v2: near_workspaces::Contract,
        ) -> string {
            let v4: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v18: () = {
                Spiral_wasm::closure8(v4.clone(), string("{ "), ());
                ()
            };
            let v37: () = {
                Spiral_wasm::closure8(v4.clone(), string("retry"), ());
                ()
            };
            let v56: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v76: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v95: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v114: () = {
                Spiral_wasm::closure8(v4.clone(), string("worker"), ());
                ()
            };
            let v131: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v143: std::string::String = format!("{:#?}", v1);
            let v190: () = {
                Spiral_wasm::closure8(
                    v4.clone(),
                    fable_library_rust::String_::fromString(v143),
                    (),
                );
                ()
            };
            let v207: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v226: () = {
                Spiral_wasm::closure8(v4.clone(), string("contract"), ());
                ()
            };
            let v243: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v255: std::string::String = format!("{:#?}", v2);
            let v302: () = {
                Spiral_wasm::closure8(
                    v4.clone(),
                    fable_library_rust::String_::fromString(v255),
                    (),
                );
                ()
            };
            let v321: () = {
                Spiral_wasm::closure8(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
        }
        pub fn method27(
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
            let v11: string = Spiral_wasm::method28(v8, v9, v10);
            Spiral_wasm::method18(append(
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
        pub fn closure14(
            v0_1: u8,
            v1: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v2: near_workspaces::Contract,
            unitVar: (),
        ) {
            fn v18() {
                Spiral_wasm::closure6((), ());
            }
            let v19: () = {
                v18();
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
            let v60: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v300: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v60,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v83: () = {
                    v18();
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
                let v111: Option<i64> = patternInput_1.5.clone();
                let v110: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v109: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v108: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v107: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v106: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v126: string = Spiral_wasm::method27(
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    v110.clone(),
                    v111.clone(),
                    Spiral_wasm::method9(v106, v107, v108, v109, v110, v111),
                    Spiral_wasm::method13(),
                    v0_1,
                    v1,
                    v2,
                );
                let v142: () = {
                    v18();
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
                let v166: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v165: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v187: () = {
                    Spiral_wasm::closure9(v165.clone(), ());
                    ()
                };
                println!("{}", v126.clone());
                (v166.l0.get().clone())(v126);
                Spiral_wasm::US8::US8_0(
                    v165,
                    v166,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn method30(v0_1: u8, v1: near_workspaces::result::ExecutionFinalResult) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v17: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v36: () = {
                Spiral_wasm::closure8(v3.clone(), string("retry"), ());
                ()
            };
            let v55: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v75: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v94: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v113: () = {
                Spiral_wasm::closure8(v3.clone(), string("result"), ());
                ()
            };
            let v130: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v142: std::string::String = format!("{:#?}", v1);
            let v189: () = {
                Spiral_wasm::closure8(
                    v3.clone(),
                    fable_library_rust::String_::fromString(v142),
                    (),
                );
                ()
            };
            let v208: () = {
                Spiral_wasm::closure8(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method29(
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
            let v10: string = Spiral_wasm::method30(v8, v9);
            Spiral_wasm::method18(append(
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
        pub fn closure15(v0_1: u8, v1: near_workspaces::result::ExecutionFinalResult, unitVar: ()) {
            fn v17() {
                Spiral_wasm::closure6((), ());
            }
            let v18: () = {
                v17();
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
            let v59: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v299: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v59,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v82: () = {
                    v17();
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
                let v110: Option<i64> = patternInput_1.5.clone();
                let v109: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v108: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v107: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v106: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v105: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v125: string = Spiral_wasm::method29(
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    v110.clone(),
                    Spiral_wasm::method9(v105, v106, v107, v108, v109, v110),
                    Spiral_wasm::method13(),
                    v0_1,
                    v1,
                );
                let v141: () = {
                    v17();
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
                let v165: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v164: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v186: () = {
                    Spiral_wasm::closure9(v164.clone(), ());
                    ()
                };
                println!("{}", v125.clone());
                (v165.l0.get().clone())(v125);
                Spiral_wasm::US8::US8_0(
                    v164,
                    v165,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn closure17(v0_1: std::string::String, unitVar: ()) {
            printfn!("{0}", v0_1);
        }
        pub fn closure16(unitVar: (), v0_1: std::string::String) {
            let v4: () = {
                Spiral_wasm::closure17(v0_1, ());
                ()
            };
            ()
        }
        pub fn closure18(unitVar: (), unitVar_1: ()) {
            fn v15() {
                Spiral_wasm::closure6((), ());
            }
            let v16: () = {
                v15();
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
            let v57: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v239: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                2_i32
                    >= (find(
                        v57,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v80: () = {
                    v15();
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
                let v104: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v103: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v125: () = {
                    Spiral_wasm::closure9(v103.clone(), ());
                    ()
                };
                println!("{}", string(" "));
                (v104.l0.get().clone())(string(" "));
                Spiral_wasm::US8::US8_0(
                    v103,
                    v104,
                    patternInput_1.2.clone(),
                    patternInput_1.3.clone(),
                    patternInput_1.4.clone(),
                    patternInput_1.5.clone(),
                )
            };
            ()
        }
        pub fn method31() -> string {
            let v3: &str = inline_colorization::color_bright_green;
            let v10: std::string::String = String::from(v3);
            let v139: string = append(
                (fable_library_rust::String_::fromString(v10)),
                (Spiral_wasm::method14(getCharAt(toLower(string("Info")), 0_i32))),
            );
            let v145: &str = inline_colorization::color_reset;
            let v152: std::string::String = String::from(v145);
            append((v139), (fable_library_rust::String_::fromString(v152)))
        }
        pub fn method33(v0_1: u8, v1: f64, v2: u64) -> string {
            let v4: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v18: () = {
                Spiral_wasm::closure8(v4.clone(), string("{ "), ());
                ()
            };
            let v37: () = {
                Spiral_wasm::closure8(v4.clone(), string("retry"), ());
                ()
            };
            let v56: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v76: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v95: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v114: () = {
                Spiral_wasm::closure8(v4.clone(), string("total_gas_burnt_usd"), ());
                ()
            };
            let v131: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v151: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{:+.6}", v1), ());
                ()
            };
            let v168: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v187: () = {
                Spiral_wasm::closure8(v4.clone(), string("total_gas_burnt"), ());
                ()
            };
            let v204: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v224: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v2), ());
                ()
            };
            let v243: () = {
                Spiral_wasm::closure8(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
        }
        pub fn method32(
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
            let v11: string = Spiral_wasm::method33(v8, v9, v10);
            Spiral_wasm::method18(append(
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
        pub fn closure19(v0_1: u8, v1: u64, v2: f64, unitVar: ()) {
            fn v18() {
                Spiral_wasm::closure6((), ());
            }
            let v19: () = {
                v18();
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
            let v60: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v300: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                2_i32
                    >= (find(
                        v60,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v83: () = {
                    v18();
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
                let v111: Option<i64> = patternInput_1.5.clone();
                let v110: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v109: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v108: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v107: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v106: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v126: string = Spiral_wasm::method32(
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    v110.clone(),
                    v111.clone(),
                    Spiral_wasm::method9(v106, v107, v108, v109, v110, v111),
                    Spiral_wasm::method31(),
                    v0_1,
                    v2,
                    v1,
                );
                let v142: () = {
                    v18();
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
                let v166: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v165: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v187: () = {
                    Spiral_wasm::closure9(v165.clone(), ());
                    ()
                };
                println!("{}", v126.clone());
                (v166.l0.get().clone())(v126);
                Spiral_wasm::US8::US8_0(
                    v165,
                    v166,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn method35(v0_1: bool, v1: f64, v2: f64, v3: u64, v4: u128) -> string {
            let v6: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v20: () = {
                Spiral_wasm::closure8(v6.clone(), string("{ "), ());
                ()
            };
            let v39: () = {
                Spiral_wasm::closure8(v6.clone(), string("is_success"), ());
                ()
            };
            let v58: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v78: () = {
                Spiral_wasm::closure8(
                    v6.clone(),
                    if v0_1 {
                        string("true")
                    } else {
                        string("false")
                    },
                    (),
                );
                ()
            };
            let v97: () = {
                Spiral_wasm::closure8(v6.clone(), string("; "), ());
                ()
            };
            let v116: () = {
                Spiral_wasm::closure8(v6.clone(), string("gas_burnt_usd"), ());
                ()
            };
            let v133: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v153: () = {
                Spiral_wasm::closure8(v6.clone(), sprintf!("{:+.6}", v1), ());
                ()
            };
            let v170: () = {
                Spiral_wasm::closure8(v6.clone(), string("; "), ());
                ()
            };
            let v189: () = {
                Spiral_wasm::closure8(v6.clone(), string("tokens_burnt_usd"), ());
                ()
            };
            let v206: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v226: () = {
                Spiral_wasm::closure8(v6.clone(), sprintf!("{:+.6}", v2), ());
                ()
            };
            let v243: () = {
                Spiral_wasm::closure8(v6.clone(), string("; "), ());
                ()
            };
            let v262: () = {
                Spiral_wasm::closure8(v6.clone(), string("gas_burnt"), ());
                ()
            };
            let v279: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v299: () = {
                Spiral_wasm::closure8(v6.clone(), sprintf!("{}", v3), ());
                ()
            };
            let v316: () = {
                Spiral_wasm::closure8(v6.clone(), string("; "), ());
                ()
            };
            let v335: () = {
                Spiral_wasm::closure8(v6.clone(), string("tokens_burnt"), ());
                ()
            };
            let v352: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v364: std::string::String = format!("{:#?}", v4);
            let v411: () = {
                Spiral_wasm::closure8(
                    v6.clone(),
                    fable_library_rust::String_::fromString(v364),
                    (),
                );
                ()
            };
            let v430: () = {
                Spiral_wasm::closure8(v6.clone(), string(" }"), ());
                ()
            };
            v6.l0.get().clone()
        }
        pub fn method34(
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
            let v13: string = Spiral_wasm::method35(v8, v9, v10, v11, v12);
            Spiral_wasm::method18(append(
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
        pub fn closure21(v0_1: bool, v1: u64, v2: f64, v3: u128, v4: f64, unitVar: ()) {
            fn v20() {
                Spiral_wasm::closure6((), ());
            }
            let v21: () = {
                v20();
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
            let v62: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v302: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                2_i32
                    >= (find(
                        v62,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v85: () = {
                    v20();
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
                let v113: Option<i64> = patternInput_1.5.clone();
                let v112: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v111: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v110: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v109: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v108: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v128: string = Spiral_wasm::method34(
                    v108.clone(),
                    v109.clone(),
                    v110.clone(),
                    v111.clone(),
                    v112.clone(),
                    v113.clone(),
                    Spiral_wasm::method9(v108, v109, v110, v111, v112, v113),
                    Spiral_wasm::method31(),
                    v0_1,
                    v2,
                    v4,
                    v1,
                    v3,
                );
                let v144: () = {
                    v20();
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
                let v168: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v167: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v189: () = {
                    Spiral_wasm::closure9(v167.clone(), ());
                    ()
                };
                println!("{}", v128.clone());
                (v168.l0.get().clone())(v128);
                Spiral_wasm::US8::US8_0(
                    v167,
                    v168,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn closure20(unitVar: (), v0_1: near_workspaces::result::ExecutionOutcome) {
            let v2: bool = v0_1.clone().is_success();
            let v4: near_workspaces::types::Gas = v0_1.clone().gas_burnt;
            let v6: u64 = v4.as_gas();
            let v13: f64 = ((v6 as f64) / 10000000000000000.0_f64) * 6.68_f64;
            let v15: near_workspaces::types::NearToken = v0_1.tokens_burnt;
            let v17: u128 = v15.as_yoctonear();
            let v335: () = {
                Spiral_wasm::closure21(
                    v2,
                    v6,
                    v13,
                    v17.clone(),
                    ((v17 as f64) / 1E+24_f64) * 6.68_f64,
                    (),
                );
                ()
            };
            ()
        }
        pub fn method37(
            v0_1: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
        ) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v16: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v35: () = {
                Spiral_wasm::closure8(v2.clone(), string("result2"), ());
                ()
            };
            let v54: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v66: std::string::String = format!("{:#?}", v0_1);
            let v113: () = {
                Spiral_wasm::closure8(v2.clone(), fable_library_rust::String_::fromString(v66), ());
                ()
            };
            let v132: () = {
                Spiral_wasm::closure8(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method36(
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
            let v9: string = Spiral_wasm::method37(v8);
            Spiral_wasm::method18(append(
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
        pub fn closure22(
            v0_1: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
            unitVar: (),
        ) {
            fn v16() {
                Spiral_wasm::closure6((), ());
            }
            let v17: () = {
                v16();
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
            let v58: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v298: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v58,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v81: () = {
                    v16();
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
                let v109: Option<i64> = patternInput_1.5.clone();
                let v108: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v107: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v106: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v105: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v104: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v124: string = Spiral_wasm::method36(
                    v104.clone(),
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    Spiral_wasm::method9(v104, v105, v106, v107, v108, v109),
                    Spiral_wasm::method13(),
                    v0_1,
                );
                let v140: () = {
                    v16();
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
                let v164: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v163: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v185: () = {
                    Spiral_wasm::closure9(v163.clone(), ());
                    ()
                };
                println!("{}", v124.clone());
                (v164.l0.get().clone())(v124);
                Spiral_wasm::US8::US8_0(
                    v163,
                    v164,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn method38(
            v0_1: near_workspaces::result::ExecutionFinalResult,
        ) -> near_workspaces::result::ExecutionFinalResult {
            v0_1
        }
        pub fn method40(v0_1: i32, v1: Vec<&near_workspaces::result::ExecutionOutcome>) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v17: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v36: () = {
                Spiral_wasm::closure8(v3.clone(), string("receipt_failures_len"), ());
                ()
            };
            let v55: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v75: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v94: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v113: () = {
                Spiral_wasm::closure8(v3.clone(), string("receipt_failures"), ());
                ()
            };
            let v130: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v142: std::string::String = format!("{:#?}", v1);
            let v189: () = {
                Spiral_wasm::closure8(
                    v3.clone(),
                    fable_library_rust::String_::fromString(v142),
                    (),
                );
                ()
            };
            let v208: () = {
                Spiral_wasm::closure8(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method39(
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
            let v10: string = Spiral_wasm::method40(v8, v9);
            Spiral_wasm::method18(append(
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
        pub fn closure23(
            v0_1: Vec<&near_workspaces::result::ExecutionOutcome>,
            v1: i32,
            unitVar: (),
        ) {
            fn v17() {
                Spiral_wasm::closure6((), ());
            }
            let v18: () = {
                v17();
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
            let v59: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v299: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v59,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v82: () = {
                    v17();
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
                let v110: Option<i64> = patternInput_1.5.clone();
                let v109: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v108: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v107: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v106: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v105: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v125: string = Spiral_wasm::method39(
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    v110.clone(),
                    Spiral_wasm::method9(v105, v106, v107, v108, v109, v110),
                    Spiral_wasm::method13(),
                    v1,
                    v0_1,
                );
                let v141: () = {
                    v17();
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
                let v165: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v164: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v186: () = {
                    Spiral_wasm::closure9(v164.clone(), ());
                    ()
                };
                println!("{}", v125.clone());
                (v165.l0.get().clone())(v125);
                Spiral_wasm::US8::US8_0(
                    v164,
                    v165,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn method41(
            v0_1: near_workspaces::result::ExecutionFinalResult,
        ) -> near_workspaces::result::ExecutionFinalResult {
            v0_1
        }
        pub fn method43(v0_1: i32, v1: Vec<near_workspaces::result::ExecutionOutcome>) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v17: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v36: () = {
                Spiral_wasm::closure8(v3.clone(), string("receipt_outcomes_len"), ());
                ()
            };
            let v55: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v75: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v94: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v113: () = {
                Spiral_wasm::closure8(v3.clone(), string("receipt_outcomes"), ());
                ()
            };
            let v130: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v142: std::string::String = format!("{:#?}", v1);
            let v189: () = {
                Spiral_wasm::closure8(
                    v3.clone(),
                    fable_library_rust::String_::fromString(v142),
                    (),
                );
                ()
            };
            let v208: () = {
                Spiral_wasm::closure8(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method42(
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
            let v10: string = Spiral_wasm::method43(v8, v9);
            Spiral_wasm::method18(append(
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
        pub fn closure24(
            v0_1: Vec<near_workspaces::result::ExecutionOutcome>,
            v1: i32,
            unitVar: (),
        ) {
            fn v17() {
                Spiral_wasm::closure6((), ());
            }
            let v18: () = {
                v17();
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
            let v59: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v299: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v59,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v82: () = {
                    v17();
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
                let v110: Option<i64> = patternInput_1.5.clone();
                let v109: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v108: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v107: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v106: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v105: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v125: string = Spiral_wasm::method42(
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    v110.clone(),
                    Spiral_wasm::method9(v105, v106, v107, v108, v109, v110),
                    Spiral_wasm::method13(),
                    v1,
                    v0_1,
                );
                let v141: () = {
                    v17();
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
                let v165: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v164: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v186: () = {
                    Spiral_wasm::closure9(v164.clone(), ());
                    ()
                };
                println!("{}", v125.clone());
                (v165.l0.get().clone())(v125);
                Spiral_wasm::US8::US8_0(
                    v164,
                    v165,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn method45(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v16: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v35: () = {
                Spiral_wasm::closure8(v2.clone(), string("json"), ());
                ()
            };
            let v54: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v66: std::string::String = format!("{:#?}", v0_1);
            let v113: () = {
                Spiral_wasm::closure8(v2.clone(), fable_library_rust::String_::fromString(v66), ());
                ()
            };
            let v132: () = {
                Spiral_wasm::closure8(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
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
            v8: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v9: string = Spiral_wasm::method45(v8);
            Spiral_wasm::method18(append(
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
        pub fn closure25(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            fn v16() {
                Spiral_wasm::closure6((), ());
            }
            let v17: () = {
                v16();
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
            let v58: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v298: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v58,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v81: () = {
                    v16();
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
                let v109: Option<i64> = patternInput_1.5.clone();
                let v108: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v107: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v106: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v105: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v104: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v124: string = Spiral_wasm::method44(
                    v104.clone(),
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    Spiral_wasm::method9(v104, v105, v106, v107, v108, v109),
                    Spiral_wasm::method13(),
                    v0_1,
                );
                let v140: () = {
                    v16();
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
                let v164: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v163: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v185: () = {
                    Spiral_wasm::closure9(v163.clone(), ());
                    ()
                };
                println!("{}", v124.clone());
                (v164.l0.get().clone())(v124);
                Spiral_wasm::US8::US8_0(
                    v163,
                    v164,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn method47(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v16: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v35: () = {
                Spiral_wasm::closure8(v2.clone(), string("borsh"), ());
                ()
            };
            let v54: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v66: std::string::String = format!("{:#?}", v0_1);
            let v113: () = {
                Spiral_wasm::closure8(v2.clone(), fable_library_rust::String_::fromString(v66), ());
                ()
            };
            let v132: () = {
                Spiral_wasm::closure8(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
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
            v8: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v9: string = Spiral_wasm::method47(v8);
            Spiral_wasm::method18(append(
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
        pub fn closure26(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            fn v16() {
                Spiral_wasm::closure6((), ());
            }
            let v17: () = {
                v16();
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
            let v58: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v298: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v58,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v81: () = {
                    v16();
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
                let v109: Option<i64> = patternInput_1.5.clone();
                let v108: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v107: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v106: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v105: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v104: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v124: string = Spiral_wasm::method46(
                    v104.clone(),
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    Spiral_wasm::method9(v104, v105, v106, v107, v108, v109),
                    Spiral_wasm::method13(),
                    v0_1,
                );
                let v140: () = {
                    v16();
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
                let v164: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v163: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v185: () = {
                    Spiral_wasm::closure9(v163.clone(), ());
                    ()
                };
                println!("{}", v124.clone());
                (v164.l0.get().clone())(v124);
                Spiral_wasm::US8::US8_0(
                    v163,
                    v164,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn method48(
            v0_1: i32,
            v1: u8,
            v2: Vec<&near_workspaces::result::ExecutionOutcome>,
        ) -> string {
            let v4: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v18: () = {
                Spiral_wasm::closure8(v4.clone(), string("{ "), ());
                ()
            };
            let v37: () = {
                Spiral_wasm::closure8(v4.clone(), string("receipt_outcomes_len"), ());
                ()
            };
            let v56: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v76: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v95: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v114: () = {
                Spiral_wasm::closure8(v4.clone(), string("retry"), ());
                ()
            };
            let v131: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v151: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v1), ());
                ()
            };
            let v168: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v187: () = {
                Spiral_wasm::closure8(v4.clone(), string("receipt_failures"), ());
                ()
            };
            let v204: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v216: std::string::String = format!("{:#?}", v2);
            let v263: () = {
                Spiral_wasm::closure8(
                    v4.clone(),
                    fable_library_rust::String_::fromString(v216),
                    (),
                );
                ()
            };
            let v282: () = {
                Spiral_wasm::closure8(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
        }
        pub fn method26(
            v0_1: Vec<u8>,
            v1: u8,
        ) -> std::pin::Pin<
            Box<dyn std::future::Future<Output = Result<Spiral_wasm::US7, anyhow::Error>>>,
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
                    let v333: () = {
                        Spiral_wasm::closure14(v1, v11, v19.clone(), ());
                        ()
                    };
                    let v650: near_workspaces::operations::CallTransaction =
                        v19.call(&*string("state_main"));
                    let v652: near_workspaces::types::Gas =
                        near_workspaces::types::Gas::from_tgas(300);
                    let v654: near_workspaces::operations::CallTransaction = v650.gas(v652);
                    let v656: std::pin::Pin<
                        Box<
                            dyn std::future::Future<
                                    Output = Result<
                                        near_workspaces::result::ExecutionFinalResult,
                                        near_workspaces::error::Error,
                                    >,
                                >,
                        >,
                    > = Box::pin(v654.transact());
                    let v658: Result<
                        near_workspaces::result::ExecutionFinalResult,
                        near_workspaces::error::Error,
                    > = v656.await;
                    let v660: near_workspaces::result::ExecutionFinalResult = v658?;
                    let v974: () = {
                        Spiral_wasm::closure15(v1, v660.clone(), ());
                        ()
                    };
                    let v1290: Vec<&str> = v660.logs();
                    let v1292: bool = true;
                    let _vec_map: Vec<_> = v1290
                        .into_iter()
                        .map(|x| {
                            //;
                            let v1294: &str = x;
                            let v1301: std::string::String = String::from(v1294);
                            let v1332: bool = true;
                            v1301
                        })
                        .collect::<Vec<_>>();
                    let v1334: Vec<std::string::String> = _vec_map;
                    let v1337: bool = true;
                    v1334.iter().for_each(|x| {
                        Func1::new(move |v: std::string::String| Spiral_wasm::closure16((), v))(
                            x.clone(),
                        );
                    }); //;
                    let v1594: () = {
                        Spiral_wasm::closure18((), ());
                        ()
                    };
                    let v1852: near_workspaces::types::Gas = v660.clone().total_gas_burnt;
                    let v1854: u64 = v1852.as_gas();
                    let v2175: () = {
                        Spiral_wasm::closure19(
                            v1,
                            v1854,
                            ((v1854 as f64) / 10000000000000000.0_f64) * 6.68_f64,
                            (),
                        );
                        ()
                    };
                    let v2491: near_workspaces::result::ExecutionFinalResult = v660.clone();
                    let v2493: Vec<&near_workspaces::result::ExecutionOutcome> = v2491.outcomes();
                    let v2495 = v2493.into_iter();
                    let v2497 = v2495.cloned();
                    let v2500: bool = true;
                    v2497.for_each(|x| {
                        Func1::new(move |v_1: near_workspaces::result::ExecutionOutcome| {
                            Spiral_wasm::closure20((), v_1)
                        })(x)
                    });
                    let v2816: () = {
                        Spiral_wasm::closure22(v660.clone().into_result(), ());
                        ()
                    };
                    let v3131: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method38(v660.clone());
                    let v3133: Vec<&near_workspaces::result::ExecutionOutcome> =
                        v3131.receipt_failures();
                    let v3141: i32 = v3133.clone().len() as i32;
                    let v3462: () = {
                        Spiral_wasm::closure23(v3133.clone(), v3141, ());
                        ()
                    };
                    let v3777: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method41(v660.clone());
                    let v3779: &[near_workspaces::result::ExecutionOutcome] =
                        v3777.receipt_outcomes();
                    let v3781: Vec<near_workspaces::result::ExecutionOutcome> = v3779.into();
                    let v3789: i32 = v3781.clone().len() as i32;
                    let v4110: () = {
                        Spiral_wasm::closure24(v3781, v3789, ());
                        ()
                    };
                    let v4740: () = {
                        Spiral_wasm::closure25(v660.clone().json(), ());
                        ()
                    };
                    let v5370: () = {
                        Spiral_wasm::closure26(v660.borsh(), ());
                        ()
                    };
                    let v5685: string = Spiral_wasm::method48(v3789, v1, v3133);
                    let v5720: Result<Spiral_wasm::US7, anyhow::Error> = if (v3141) > 0_i32 {
                        Ok::<Spiral_wasm::US7, anyhow::Error>(Spiral_wasm::US7::US7_0(
                            v5685.clone(),
                        ))
                    } else {
                        if (v3789) > 1_i32 {
                            Ok::<Spiral_wasm::US7, anyhow::Error>(Spiral_wasm::US7::US7_1)
                        } else {
                            let v5703: anyhow::Error = anyhow::anyhow!(v5685);
                            Err(v5703)
                        }
                    };
                    let v5723: string = string("}");
                    let v5728: bool = true;
                    let _fix_closure_v5725 = v5720;
                    let v5734: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v5725 "), (v5723))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v5735: bool = true;
                    _fix_closure_v5725
                },
            ); // rust.fix_closure';
            let v5737 = __future_init;
            v5737
        }
        pub fn closure27(unitVar: (), v0_1: anyhow::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method49() -> Func1<anyhow::Error, std::string::String> {
            Func1::new(move |v: anyhow::Error| Spiral_wasm::closure27((), v))
        }
        pub fn closure28(unitVar: (), v0_1: Spiral_wasm::US7) -> Spiral_wasm::US10 {
            Spiral_wasm::US10::US10_0(v0_1)
        }
        pub fn method50() -> Func1<Spiral_wasm::US7, Spiral_wasm::US10> {
            Func1::new(move |v: Spiral_wasm::US7| Spiral_wasm::closure28((), v))
        }
        pub fn closure29(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US10 {
            Spiral_wasm::US10::US10_1(v0_1)
        }
        pub fn method51() -> Func1<std::string::String, Spiral_wasm::US10> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure29((), v))
        }
        pub fn method52() -> string {
            let v3: &str = inline_colorization::color_yellow;
            let v10: std::string::String = String::from(v3);
            let v139: string = append(
                (fable_library_rust::String_::fromString(v10)),
                (Spiral_wasm::method14(getCharAt(toLower(string("Warning")), 0_i32))),
            );
            let v145: &str = inline_colorization::color_reset;
            let v152: std::string::String = String::from(v145);
            append((v139), (fable_library_rust::String_::fromString(v152)))
        }
        pub fn method54(v0_1: u8, v1: std::string::String) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v17: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v36: () = {
                Spiral_wasm::closure8(v3.clone(), string("retry"), ());
                ()
            };
            let v55: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v75: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v94: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v113: () = {
                Spiral_wasm::closure8(v3.clone(), string("error"), ());
                ()
            };
            let v130: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v142: std::string::String = format!("{:#?}", v1);
            let v189: () = {
                Spiral_wasm::closure8(
                    v3.clone(),
                    fable_library_rust::String_::fromString(v142),
                    (),
                );
                ()
            };
            let v208: () = {
                Spiral_wasm::closure8(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method53(
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
            let v10: string = Spiral_wasm::method54(v8, v9);
            Spiral_wasm::method18(append(
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
        pub fn closure30(v0_1: u8, v1: std::string::String, unitVar: ()) {
            fn v17() {
                Spiral_wasm::closure6((), ());
            }
            let v18: () = {
                v17();
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
            let v59: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v299: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                3_i32
                    >= (find(
                        v59,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v82: () = {
                    v17();
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
                let v110: Option<i64> = patternInput_1.5.clone();
                let v109: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v108: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v107: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v106: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v105: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v125: string = Spiral_wasm::method53(
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    v110.clone(),
                    Spiral_wasm::method9(v105, v106, v107, v108, v109, v110),
                    Spiral_wasm::method52(),
                    v0_1,
                    v1,
                );
                let v141: () = {
                    v17();
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
                let v165: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v164: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v186: () = {
                    Spiral_wasm::closure9(v164.clone(), ());
                    ()
                };
                println!("{}", v125.clone());
                (v165.l0.get().clone())(v125);
                Spiral_wasm::US8::US8_0(
                    v164,
                    v165,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn closure31(unitVar: (), unitVar_1: ()) {
            fn v15() {
                Spiral_wasm::closure6((), ());
            }
            let v16: () = {
                v15();
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
            let v57: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v237: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                3_i32
                    >= (find(
                        v57,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v80: () = {
                    v15();
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
                let v104: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v103: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v125: () = {
                    Spiral_wasm::closure9(v103.clone(), ());
                    ()
                };
                println!("{}", string("\n"));
                (v104.l0.get().clone())(string("\n"));
                Spiral_wasm::US8::US8_0(
                    v103,
                    v104,
                    patternInput_1.2.clone(),
                    patternInput_1.3.clone(),
                    patternInput_1.4.clone(),
                    patternInput_1.5.clone(),
                )
            };
            ()
        }
        pub fn closure32(v0_1: u8, v1: std::string::String, unitVar: ()) {
            fn v17() {
                Spiral_wasm::closure6((), ());
            }
            let v18: () = {
                v17();
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
            let v59: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v299: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                3_i32
                    >= (find(
                        v59,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v82: () = {
                    v17();
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
                let v110: Option<i64> = patternInput_1.5.clone();
                let v109: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v108: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v107: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v106: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v105: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v125: string = Spiral_wasm::method53(
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    v110.clone(),
                    Spiral_wasm::method9(v105, v106, v107, v108, v109, v110),
                    Spiral_wasm::method52(),
                    v0_1,
                    v1,
                );
                let v141: () = {
                    v17();
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
                let v165: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v164: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v186: () = {
                    Spiral_wasm::closure9(v164.clone(), ());
                    ()
                };
                println!("{}", v125.clone());
                (v165.l0.get().clone())(v125);
                Spiral_wasm::US8::US8_0(
                    v164,
                    v165,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn closure33(unitVar: (), unitVar_1: ()) {
            fn v15() {
                Spiral_wasm::closure6((), ());
            }
            let v16: () = {
                v15();
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
            let v57: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v237: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                3_i32
                    >= (find(
                        v57,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v80: () = {
                    v15();
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
                let v104: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v103: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v125: () = {
                    Spiral_wasm::closure9(v103.clone(), ());
                    ()
                };
                println!("{}", string("\n"));
                (v104.l0.get().clone())(string("\n"));
                Spiral_wasm::US8::US8_0(
                    v103,
                    v104,
                    patternInput_1.2.clone(),
                    patternInput_1.3.clone(),
                    patternInput_1.4.clone(),
                    patternInput_1.5.clone(),
                )
            };
            ()
        }
        pub fn method55() -> string {
            let v3: &str = inline_colorization::color_bright_red;
            let v10: std::string::String = String::from(v3);
            let v139: string = append(
                (fable_library_rust::String_::fromString(v10)),
                (Spiral_wasm::method14(getCharAt(toLower(string("Critical")), 0_i32))),
            );
            let v145: &str = inline_colorization::color_reset;
            let v152: std::string::String = String::from(v145);
            append((v139), (fable_library_rust::String_::fromString(v152)))
        }
        pub fn method57(v0_1: u8, v1: string) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v17: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v36: () = {
                Spiral_wasm::closure8(v3.clone(), string("retry"), ());
                ()
            };
            let v55: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v75: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v94: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v113: () = {
                Spiral_wasm::closure8(v3.clone(), string("error"), ());
                ()
            };
            let v130: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v147: () = {
                Spiral_wasm::closure8(v3.clone(), v1, ());
                ()
            };
            let v166: () = {
                Spiral_wasm::closure8(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method56(
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
            let v10: string = Spiral_wasm::method57(v8, v9);
            Spiral_wasm::method18(append(
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
        pub fn closure34(v0_1: u8, v1: string, unitVar: ()) {
            fn v17() {
                Spiral_wasm::closure6((), ());
            }
            let v18: () = {
                v17();
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
            let v59: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v299: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                4_i32
                    >= (find(
                        v59,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v82: () = {
                    v17();
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
                let v110: Option<i64> = patternInput_1.5.clone();
                let v109: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v108: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v107: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v106: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v105: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v125: string = Spiral_wasm::method56(
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    v110.clone(),
                    Spiral_wasm::method9(v105, v106, v107, v108, v109, v110),
                    Spiral_wasm::method55(),
                    v0_1,
                    v1,
                );
                let v141: () = {
                    v17();
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
                let v165: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v164: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v186: () = {
                    Spiral_wasm::closure9(v164.clone(), ());
                    ()
                };
                println!("{}", v125.clone());
                (v165.l0.get().clone())(v125);
                Spiral_wasm::US8::US8_0(
                    v164,
                    v165,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn method25(
            v0_1: Vec<u8>,
            v1: u8,
        ) -> std::pin::Pin<Box<dyn std::future::Future<Output = Spiral_wasm::US9>>> {
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
                                    Output = Result<Spiral_wasm::US7, anyhow::Error>,
                                >,
                        >,
                    > = Spiral_wasm::method26(v0_1.clone(), v1);
                    let v10: Result<Spiral_wasm::US7, anyhow::Error> = v8.await;
                    let v11 = Spiral_wasm::method49();
                    let v24: Result<Spiral_wasm::US7, std::string::String> =
                        v10.map_err(|x| v11(x));
                    let v27 = Spiral_wasm::method50();
                    let v28 = Spiral_wasm::method51();
                    let v30: Spiral_wasm::US10 = match &v24 {
                        Err(v24_1_0) => v28(v24_1_0.clone()),
                        Ok(v24_0_0) => v27(v24_0_0.clone()),
                    };
                    let v3037: Spiral_wasm::US9 = match &v30 {
                        Spiral_wasm::US10::US10_0(v30_0_0) => {
                            let v33: Spiral_wasm::US7 = v30_0_0.clone();
                            match &v33 {
                                Spiral_wasm::US7::US7_0(v33_0_0) => {
                                    let v64: string = match &v33 {
                                        Spiral_wasm::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone();
                                    let v378: () = {
                                        Spiral_wasm::closure34(v1, v64.clone(), ());
                                        ()
                                    };
                                    let v694: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v696: bool = */
                                        async move {
                                            /*;
                                            let v698: bool = */
                                            ();
                                            let v701: string = string("}");
                                            let v707: bool = true;
                                            let _fix_closure_v704 =
                                                (v1, Spiral_wasm::US7::US7_0(v64));
                                            let v713: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v704 "),
                                                            (v701),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v714: bool = true;
                                            _fix_closure_v704
                                        },
                                    ); // rust.fix_closure';
                                    let v716 = __future_init;
                                    let v718: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<Output = (u8, Spiral_wasm::US7)>,
                                        >,
                                    > = v716;
                                    let patternInput_2: (u8, Spiral_wasm::US7) = v718.await;
                                    Spiral_wasm::US9::US9_1(
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone(),
                                    )
                                }
                                _ => {
                                    let v35: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v37: bool = */
                                        async move {
                                            /*;
                                            let v39: bool = */
                                            ();
                                            let v42: string = string("}");
                                            let v48: bool = true;
                                            let _fix_closure_v45 = (v1, Spiral_wasm::US7::US7_1);
                                            let v54: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v45 "),
                                                            (v42),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v55: bool = true;
                                            _fix_closure_v45
                                        },
                                    ); // rust.fix_closure';
                                    let v57 = __future_init;
                                    let v59: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<Output = (u8, Spiral_wasm::US7)>,
                                        >,
                                    > = v57;
                                    let patternInput_1: (u8, Spiral_wasm::US7) = v59.await;
                                    Spiral_wasm::US9::US9_0(
                                        patternInput_1.0.clone(),
                                        patternInput_1.1.clone(),
                                    )
                                }
                            }
                        }
                        Spiral_wasm::US10::US10_1(v30_1_0) => {
                            let v725: std::string::String = v30_1_0.clone();
                            if (v1) >= 15_u8 {
                                let v1040: () = {
                                    Spiral_wasm::closure30(v1, v725.clone(), ());
                                    ()
                                };
                                let v1609: () = {
                                    Spiral_wasm::closure31((), ());
                                    ()
                                };
                                let v1865: bool = true;
                                let __future_init = Box::pin(
                                    /*;
                                    let v1867: bool = */
                                    async move {
                                        /*;
                                        let v1869: bool = */
                                        ();
                                        let v1872: string = string("}");
                                        let v1878: bool = true;
                                        let _fix_closure_v1875 = (v1, Spiral_wasm::US7::US7_1);
                                        let v1884: string = append(
                                            (append(
                                                (append(
                                                    (append(
                                                        string("true; _fix_closure_v1875 "),
                                                        (v1872),
                                                    )),
                                                    string("); "),
                                                )),
                                                string(""),
                                            )),
                                            string(" // rust.fix_closure\'"),
                                        );
                                        let v1885: bool = true;
                                        _fix_closure_v1875
                                    },
                                ); // rust.fix_closure';
                                let v1887 = __future_init;
                                let v1889: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = (u8, Spiral_wasm::US7)>>,
                                > = v1887;
                                let patternInput: (u8, Spiral_wasm::US7) = v1889.await;
                                Spiral_wasm::US9::US9_0(
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                )
                            } else {
                                let v2207: () = {
                                    Spiral_wasm::closure32(v1, v725, ());
                                    ()
                                };
                                let v2776: () = {
                                    Spiral_wasm::closure33((), ());
                                    ()
                                };
                                let v3032: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = Spiral_wasm::US9>>,
                                > = Spiral_wasm::method25(v0_1.clone(), (v1) + 1_u8);
                                v3032.await
                            }
                        }
                    };
                    let v3040: string = string("}");
                    let v3045: bool = true;
                    let _fix_closure_v3042 = v3037;
                    let v3051: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v3042 "), (v3040))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v3052: bool = true;
                    _fix_closure_v3042
                },
            ); // rust.fix_closure';
            let v3054 = __future_init;
            v3054
        }
        pub fn method59(v0_1: Spiral_wasm::US9) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v16: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v35: () = {
                Spiral_wasm::closure8(v2.clone(), string("retries"), ());
                ()
            };
            let v54: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v75: () = {
                Spiral_wasm::closure8(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v94: () = {
                Spiral_wasm::closure8(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method58(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: Spiral_wasm::US9,
        ) -> string {
            let v9: string = Spiral_wasm::method59(v8);
            Spiral_wasm::method18(append(
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
        pub fn closure35(v0_1: Spiral_wasm::US9, unitVar: ()) {
            fn v16() {
                Spiral_wasm::closure6((), ());
            }
            let v17: () = {
                v16();
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
            let v58: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v298: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v58,
                        ofSeq(ofList(ofArray(new_array(&[
                            LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                            LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                        ])))),
                    ))
            }) == false
            {
                Spiral_wasm::US8::US8_1
            } else {
                let v81: () = {
                    v16();
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
                let v109: Option<i64> = patternInput_1.5.clone();
                let v108: LrcPtr<Spiral_wasm::Mut4> = patternInput_1.4.clone();
                let v107: LrcPtr<Spiral_wasm::Mut3> = patternInput_1.3.clone();
                let v106: LrcPtr<Spiral_wasm::Mut2> = patternInput_1.2.clone();
                let v105: LrcPtr<Spiral_wasm::Mut1> = patternInput_1.1.clone();
                let v104: LrcPtr<Spiral_wasm::Mut0> = patternInput_1.0.clone();
                let v124: string = Spiral_wasm::method58(
                    v104.clone(),
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    Spiral_wasm::method9(v104, v105, v106, v107, v108, v109),
                    Spiral_wasm::method13(),
                    v0_1,
                );
                let v140: () = {
                    v16();
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
                let v164: LrcPtr<Spiral_wasm::Mut1> = patternInput_2.1.clone();
                let v163: LrcPtr<Spiral_wasm::Mut0> = patternInput_2.0.clone();
                let v185: () = {
                    Spiral_wasm::closure9(v163.clone(), ());
                    ()
                };
                println!("{}", v124.clone());
                (v164.l0.get().clone())(v124);
                Spiral_wasm::US8::US8_0(
                    v163,
                    v164,
                    patternInput_2.2.clone(),
                    patternInput_2.3.clone(),
                    patternInput_2.4.clone(),
                    patternInput_2.5.clone(),
                )
            };
            ()
        }
        pub fn method60(v0_1: Spiral_wasm::US9, v1: Spiral_wasm::US7) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v17: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v36: () = {
                Spiral_wasm::closure8(v3.clone(), string("retries"), ());
                ()
            };
            let v55: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v76: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v95: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v114: () = {
                Spiral_wasm::closure8(v3.clone(), string("error"), ());
                ()
            };
            let v131: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v152: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{:?}", v1), ());
                ()
            };
            let v171: () = {
                Spiral_wasm::closure8(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method21(
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
                    let v7: string = Spiral_wasm::method22();
                    let v14: &str = &*v7;
                    let v45: Option<std::string::String> =
                        clap::ArgMatches::get_one(&v0_1, v14).cloned();
                    let v70: Spiral_wasm::US0 =
                        defaultValue(Spiral_wasm::US0::US0_1, map(Spiral_wasm::method2(), v45));
                    let v77: std::string::String = match &v70 {
                        Spiral_wasm::US0::US0_0(v70_0_0) => match &v70 {
                            Spiral_wasm::US0::US0_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v79: string = fable_library_rust::String_::fromString(v77);
                    let v393: () = {
                        Spiral_wasm::closure13(v79.clone(), ());
                        ()
                    };
                    let v709: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v79);
                    let v713: std::pin::Pin<
                        Box<dyn std::future::Future<Output = Spiral_wasm::US9>>,
                    > = Spiral_wasm::method25(v709?, 1_u8);
                    let v715: Spiral_wasm::US9 = v713.await;
                    let v1029: () = {
                        Spiral_wasm::closure35(v715.clone(), ());
                        ()
                    };
                    let v1371: Result<u8, anyhow::Error> = match &v715 {
                        Spiral_wasm::US9::US9_0(v715_0_0, v715_0_1) => {
                            Ok::<u8, anyhow::Error>(v715_0_0.clone())
                        }
                        Spiral_wasm::US9::US9_1(v715_1_0, v715_1_1) => {
                            let v1352: string =
                                Spiral_wasm::method60(v715.clone(), v715_1_1.clone());
                            let v1354: anyhow::Error = anyhow::anyhow!(v1352);
                            Err(v1354)
                        }
                    };
                    let v1374: string = string("}");
                    let v1379: bool = true;
                    let _fix_closure_v1376 = v1371;
                    let v1385: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v1376 "), (v1374))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v1386: bool = true;
                    _fix_closure_v1376
                },
            ); // rust.fix_closure';
            let v1388 = __future_init;
            v1388
        }
        pub fn closure36(unitVar: (), v0_1: u8) -> Spiral_wasm::US11 {
            Spiral_wasm::US11::US11_0(v0_1)
        }
        pub fn method61() -> Func1<u8, Spiral_wasm::US11> {
            Func1::new(move |v: u8| Spiral_wasm::closure36((), v))
        }
        pub fn closure37(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US11 {
            Spiral_wasm::US11::US11_1(v0_1)
        }
        pub fn method62() -> Func1<std::string::String, Spiral_wasm::US11> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure37((), v))
        }
        pub fn closure0(unitVar: (), v0_1: Array<string>) -> i32 {
            let v1: clap::Command = Spiral_wasm::method0();
            let v3: clap::ArgMatches = clap::Command::get_matches(v1);
            let v4: string = Spiral_wasm::method1();
            let v11: &str = &*v4;
            let v42: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v11).cloned();
            let v67: Spiral_wasm::US0 =
                defaultValue(Spiral_wasm::US0::US0_1, map(Spiral_wasm::method2(), v42));
            let v203: Spiral_wasm::US1 = match &v67 {
                Spiral_wasm::US0::US0_0(v67_0_0) => {
                    let v73: string = fable_library_rust::String_::fromString(
                        match &v67 {
                            Spiral_wasm::US0::US0_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    );
                    let v78: string = toLower(string("Critical"));
                    let v85: string = toLower(string("Warning"));
                    let v92: string = toLower(string("Info"));
                    let v99: string = toLower(string("Debug"));
                    let v106: string = toLower(string("Verbose"));
                    let v113: Spiral_wasm::US2 = if string("Verbose") == (v73.clone()) {
                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_0)
                    } else {
                        Spiral_wasm::US2::US2_1
                    };
                    Spiral_wasm::US1::US1_0(match &v113 {
                        Spiral_wasm::US2::US2_0(v113_0_0) => Spiral_wasm::US2::US2_0(
                            match &v113 {
                                Spiral_wasm::US2::US2_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v120: Spiral_wasm::US2 = if string("Debug") == (v73.clone()) {
                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_1)
                            } else {
                                Spiral_wasm::US2::US2_1
                            };
                            match &v120 {
                                Spiral_wasm::US2::US2_0(v120_0_0) => Spiral_wasm::US2::US2_0(
                                    match &v120 {
                                        Spiral_wasm::US2::US2_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v127: Spiral_wasm::US2 = if string("Info") == (v73.clone())
                                    {
                                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                    } else {
                                        Spiral_wasm::US2::US2_1
                                    };
                                    match &v127 {
                                        Spiral_wasm::US2::US2_0(v127_0_0) => {
                                            Spiral_wasm::US2::US2_0(
                                                match &v127 {
                                                    Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            )
                                        }
                                        _ => {
                                            let v134: Spiral_wasm::US2 =
                                                if string("Warning") == (v73.clone()) {
                                                    Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                                } else {
                                                    Spiral_wasm::US2::US2_1
                                                };
                                            match &v134 {
                                                Spiral_wasm::US2::US2_0(v134_0_0) => {
                                                    Spiral_wasm::US2::US2_0(
                                                        match &v134 {
                                                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => {
                                                    let v141: Spiral_wasm::US2 =
                                                        if string("Critical") == (v73.clone()) {
                                                            Spiral_wasm::US2::US2_0(
                                                                Spiral_wasm::US3::US3_4,
                                                            )
                                                        } else {
                                                            Spiral_wasm::US2::US2_1
                                                        };
                                                    match &v141 {
                                                        Spiral_wasm::US2::US2_0(v141_0_0) => {
                                                            Spiral_wasm::US2::US2_0(
                                                                match &v141 {
                                                                    Spiral_wasm::US2::US2_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            let v148: Spiral_wasm::US2 = if (v106
                                                                .clone())
                                                                == (v73.clone())
                                                            {
                                                                Spiral_wasm::US2::US2_0(
                                                                    Spiral_wasm::US3::US3_0,
                                                                )
                                                            } else {
                                                                Spiral_wasm::US2::US2_1
                                                            };
                                                            match &v148 {
                                                                Spiral_wasm::US2::US2_0(
                                                                    v148_0_0,
                                                                ) => Spiral_wasm::US2::US2_0(
                                                                    match &v148 {
                                                                        Spiral_wasm::US2::US2_0(
                                                                            x,
                                                                        ) => x.clone(),
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                ),
                                                                _ => {
                                                                    let v155: Spiral_wasm::US2 =
                                                                        if (v99.clone())
                                                                            == (v73.clone())
                                                                        {
                                                                            Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_1)
                                                                        } else {
                                                                            Spiral_wasm::US2::US2_1
                                                                        };
                                                                    match &v155
                                                                                                    {
                                                                                                    Spiral_wasm::US2::US2_0(v155_0_0)
                                                                                                    =>
                                                                                                    Spiral_wasm::US2::US2_0(match &v155
                                                                                                                                {
                                                                                                                                Spiral_wasm::US2::US2_0(x)
                                                                                                                                =>
                                                                                                                                x.clone(),
                                                                                                                                _
                                                                                                                                =>
                                                                                                                                unreachable!(),
                                                                                                                            }.clone()),
                                                                                                    _
                                                                                                    =>
                                                                                                    {
                                                                                                        let v162:
                                                                                                                Spiral_wasm::US2 =
                                                                                                            if (v92.clone())
                                                                                                                   ==
                                                                                                                   (v73.clone())
                                                                                                               {
                                                                                                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                                                                                            } else {
                                                                                                                Spiral_wasm::US2::US2_1
                                                                                                            };
                                                                                                        match &v162
                                                                                                            {
                                                                                                            Spiral_wasm::US2::US2_0(v162_0_0)
                                                                                                            =>
                                                                                                            Spiral_wasm::US2::US2_0(match &v162
                                                                                                                                        {
                                                                                                                                        Spiral_wasm::US2::US2_0(x)
                                                                                                                                        =>
                                                                                                                                        x.clone(),
                                                                                                                                        _
                                                                                                                                        =>
                                                                                                                                        unreachable!(),
                                                                                                                                    }.clone()),
                                                                                                            _
                                                                                                            =>
                                                                                                            {
                                                                                                                let v169:
                                                                                                                        Spiral_wasm::US2 =
                                                                                                                    if (v85.clone())
                                                                                                                           ==
                                                                                                                           (v73.clone())
                                                                                                                       {
                                                                                                                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                                                                                                    } else {
                                                                                                                        Spiral_wasm::US2::US2_1
                                                                                                                    };
                                                                                                                match &v169
                                                                                                                    {
                                                                                                                    Spiral_wasm::US2::US2_0(v169_0_0)
                                                                                                                    =>
                                                                                                                    Spiral_wasm::US2::US2_0(match &v169
                                                                                                                                                {
                                                                                                                                                Spiral_wasm::US2::US2_0(x)
                                                                                                                                                =>
                                                                                                                                                x.clone(),
                                                                                                                                                _
                                                                                                                                                =>
                                                                                                                                                unreachable!(),
                                                                                                                                            }.clone()),
                                                                                                                    _
                                                                                                                    =>
                                                                                                                    {
                                                                                                                        let v176:
                                                                                                                                Spiral_wasm::US2 =
                                                                                                                            if (v78.clone())
                                                                                                                                   ==
                                                                                                                                   (v73.clone())
                                                                                                                               {
                                                                                                                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_4)
                                                                                                                            } else {
                                                                                                                                Spiral_wasm::US2::US2_1
                                                                                                                            };
                                                                                                                        match &v176
                                                                                                                            {
                                                                                                                            Spiral_wasm::US2::US2_0(v176_0_0)
                                                                                                                            =>
                                                                                                                            Spiral_wasm::US2::US2_0(match &v176
                                                                                                                                                        {
                                                                                                                                                        Spiral_wasm::US2::US2_0(x)
                                                                                                                                                        =>
                                                                                                                                                        x.clone(),
                                                                                                                                                        _
                                                                                                                                                        =>
                                                                                                                                                        unreachable!(),
                                                                                                                                                    }.clone()),
                                                                                                                            _
                                                                                                                            =>
                                                                                                                            Spiral_wasm::US2::US2_1,
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
                _ => Spiral_wasm::US1::US1_1,
            };
            let v210: Spiral_wasm::US2 = if let Spiral_wasm::US1::US1_0(v203_0_0) = &v203 {
                let v204: Spiral_wasm::US2 = v203_0_0.clone();
                if let Spiral_wasm::US2::US2_0(v204_0_0) = &v204 {
                    Spiral_wasm::US2::US2_0(v204_0_0.clone())
                } else {
                    Spiral_wasm::US2::US2_1
                }
            } else {
                Spiral_wasm::US2::US2_1
            };
            let v229: () = {
                Spiral_wasm::closure2(
                    match &v210 {
                        Spiral_wasm::US2::US2_0(v210_0_0) => match &v210 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => Spiral_wasm::US3::US3_0,
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
            let v580: () = {
                Spiral_wasm::closure5(v0_1, ());
                ()
            };
            let v895: string = Spiral_wasm::method19();
            let v902: &str = &*v895;
            let v933: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v902).cloned();
            let v937: Option<string> = map(Spiral_wasm::method20(), v933);
            let v1074: Spiral_wasm::US7 =
                defaultValue(Spiral_wasm::US7::US7_1, map(Spiral_wasm::method8(), v937));
            let v1078: std::pin::Pin<
                Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>,
            > = Spiral_wasm::method21(v3);
            let v1080 = tokio::runtime::Builder::new_multi_thread()
                .enable_all()
                .build()
                .unwrap();
            let v1082: Result<u8, anyhow::Error> = v1080.handle().block_on(v1078);
            let v1083 = Spiral_wasm::method49();
            let v1096: Result<u8, std::string::String> = v1082.map_err(|x| v1083(x));
            let v1099 = Spiral_wasm::method61();
            let v1100 = Spiral_wasm::method62();
            let v1102: Spiral_wasm::US11 = match &v1096 {
                Err(v1096_1_0) => v1100(v1096_1_0.clone()),
                Ok(v1096_0_0) => v1099(v1096_0_0.clone()),
            };
            match &v1102 {
                Spiral_wasm::US11::US11_0(v1102_0_0) => {
                    if let Spiral_wasm::US7::US7_0(v1074_0_0) = &v1074 {
                        let v1107: string = sprintf!(
                            "spiral_wasm.main / retries: {} / exception: \'{}\'",
                            v1102_0_0.clone(),
                            v1074_0_0.clone()
                        );
                        let v1111: Result<(), string> = Err(v1107);
                        v1111.unwrap();
                        ()
                    }
                }
                Spiral_wasm::US11::US11_1(v1102_1_0) => {
                    let v1127: std::string::String = v1102_1_0.clone();
                    if let Spiral_wasm::US7::US7_0(v1074_0_0) = &v1074 {
                        let v1128: string = v1074_0_0.clone();
                        if string("") == (v1128.clone()) {
                            ()
                        } else {
                            if contains(
                                fable_library_rust::String_::fromString(v1127.clone()),
                                v1128.clone(),
                            ) {
                                ()
                            } else {
                                let v1136: string = sprintf!(
                                    "spiral_wasm.main / exception: \'{}\' / error: {}",
                                    v1128,
                                    v1127
                                );
                                let v1140: Result<(), string> = Err(v1136);
                                v1140.unwrap();
                                ()
                            }
                        }
                    } else {
                        let v1159: u8 = v1096.clone().unwrap();
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
