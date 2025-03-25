#![cfg_attr(feature = "no_std", no_std)]
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
#![allow(unused_unsafe)]
use fable_library_rust::NativeArray_::array_from;
use fable_library_rust::String_::fromString;
mod module_e3e534c3 {
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
        pub trait IOsEnviron: core::fmt::Debug + core::fmt::Display {
            fn environ(&self) -> LrcPtr<dyn Any>;
        }
        impl<V: IOsEnviron + core::fmt::Debug + core::fmt::Display> IOsEnviron for LrcPtr<V> {
            #[inline]
            fn environ(&self) -> LrcPtr<dyn Any> {
                (**self).environ()
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
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US8 {
            US8_0(u8, Spiral_wasm::US7),
            US8_1(u8, Spiral_wasm::US7),
        }
        impl core::fmt::Display for US8 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US9 {
            US9_0(Spiral_wasm::US7),
            US9_1(std::string::String),
        }
        impl core::fmt::Display for US9 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US10 {
            US10_0(u8),
            US10_1(std::string::String),
        }
        impl core::fmt::Display for US10 {
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
            let v120: Array<string> = toArray(ofArray(new_array(&[
                toLower(string("Verbose")),
                v87,
                v80,
                v73,
                v66,
            ])));
            let v124: Vec<string> = v120.to_vec();
            let v126: bool = true;
            let _vec_map: Vec<_> = v124
                .into_iter()
                .map(|x| {
                    //;
                    let v128: string = x;
                    let v135: &str = &*v128;
                    let v168: std::string::String = String::from(v135);
                    let v196: Box<std::string::String> = Box::new(v168);
                    let v198: &'static mut std::string::String = Box::leak(v196);
                    let v200: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v198);
                    let v202: bool = true;
                    v200
                })
                .collect::<Vec<_>>();
            let v204: Vec<clap::builder::PossibleValue> = _vec_map;
            let v206: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v204),
            );
            let v208: clap::Arg = v61.value_parser(v206);
            let v210: clap::Command = clap::Command::arg(v50, v208);
            let v212: string = string("r#\"wasm\"#");
            let v213: &'static str = r#"wasm"#;
            let v215: clap::Arg = clap::Arg::new(v213);
            let v217: clap::Arg = v215.short('w');
            let v218: string = string("r#\"wasm\"#");
            let v219: &'static str = r#"wasm"#;
            let v221: clap::Arg = v217.long(v219);
            let v223: clap::Arg = v221.required(true);
            clap::Command::arg(v210, v223)
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
            let v173: Spiral_wasm::US4 = _run_target_args__v3.1.clone();
            let v172: Spiral_wasm::US2 = _run_target_args__v3.0.clone();
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
                    l0: MutCell::new(match &v172 {
                        Spiral_wasm::US2::US2_0(v172_0_0) => match &v172 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => v0_1.clone(),
                    }),
                }),
                match &v173 {
                    Spiral_wasm::US4::US4_0(v173_0_0) => Some(match &v173 {
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
        pub fn method9(v0_1: Spiral_wasm::US3) -> bool {
            let v17: () = {
                Spiral_wasm::closure6((), ());
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
            let v56: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            if ((patternInput.2.clone()).l0.get().clone()) == false {
                false
            } else {
                (find(
                    v0_1,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                        LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                        LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                        LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                        LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                    ])))),
                )) >= (find(
                    v56,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Spiral_wasm::US3::US3_0, 0_i32)),
                        LrcPtr::new((Spiral_wasm::US3::US3_1, 1_i32)),
                        LrcPtr::new((Spiral_wasm::US3::US3_2, 2_i32)),
                        LrcPtr::new((Spiral_wasm::US3::US3_3, 3_i32)),
                        LrcPtr::new((Spiral_wasm::US3::US3_4, 4_i32)),
                    ])))),
                ))
            }
        }
        pub fn closure7(unitVar: (), v0_1: i64) -> Spiral_wasm::US4 {
            Spiral_wasm::US4::US4_0(v0_1)
        }
        pub fn method11() -> Func1<i64, Spiral_wasm::US4> {
            Func1::new(move |v: i64| Spiral_wasm::closure7((), v))
        }
        pub fn method12() -> string {
            string("hh:mm:ss")
        }
        pub fn method13() -> string {
            string("HH:mm:ss")
        }
        pub fn method10(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
        ) -> string {
            let v212: Spiral_wasm::US4 =
                defaultValue(Spiral_wasm::US4::US4_1, map(Spiral_wasm::method11(), v5));
            let v344: DateTime = match &v212 {
                Spiral_wasm::US4::US4_0(v212_0_0) => {
                    let v292: TimeSpan = TimeSpan::new_ticks(
                        ({
                            let _arg: DateTime = DateTime::now();
                            _arg.ticks()
                        }) - (match &v212 {
                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                            _ => unreachable!(),
                        }),
                    );
                    DateTime::new_ymdhms_milli(
                        1_i32,
                        1_i32,
                        1_i32,
                        v292.hours(),
                        v292.minutes(),
                        v292.seconds(),
                        v292.milliseconds(),
                    )
                }
                _ => DateTime::now(),
            };
            let v346: string = Spiral_wasm::method12();
            let provider: string = if (v346.clone()) == string("") {
                string("M-d-y hh:mm:ss tt")
            } else {
                v346
            };
            v344.toString(provider)
        }
        pub fn method15() -> string {
            string("")
        }
        pub fn closure8(v0_1: LrcPtr<Spiral_wasm::Mut3>, v1: string, unitVar: ()) {
            let v4: string = append((v0_1.l0.get().clone()), (v1));
            v0_1.l0.set(v4);
            ()
        }
        pub fn method16() -> string {
            string("\u{001b}[0m")
        }
        pub fn method14() -> string {
            let v7: char = getCharAt(toLower(string("Verbose")), 0_i32);
            let v9: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v24: () = {
                Spiral_wasm::closure8(v9.clone(), sprintf!("{}", v7), ());
                ()
            };
            let v30: string = v9.l0.get().clone();
            let v49: &str = inline_colorization::color_bright_black;
            let v56: &str = &*v30;
            let v84: &str = inline_colorization::color_reset;
            let v86: std::string::String = format!("{}{}{}", v49, v56, v84);
            fable_library_rust::String_::fromString(v86)
        }
        pub fn method18(v0_1: string) -> string {
            trimEndChars(
                trimStartChars(v0_1, toArray(empty::<char>())),
                toArray(ofArray(new_array(&[' ', '/']))),
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
            let v10: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v24: () = {
                Spiral_wasm::closure8(v10.clone(), string("{ "), ());
                ()
            };
            let v43: () = {
                Spiral_wasm::closure8(v10.clone(), string("args"), ());
                ()
            };
            let v62: () = {
                Spiral_wasm::closure8(v10.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral_wasm::closure8(v10.clone(), sprintf!("{:?}", v8), ());
                ()
            };
            let v102: () = {
                Spiral_wasm::closure8(v10.clone(), string(" }"), ());
                ()
            };
            let v108: string = v10.l0.get().clone();
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
                (v108),
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
        pub fn method19(v0_1: string) {
            let v17: () = {
                Spiral_wasm::closure6((), ());
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
            let v60: () = {
                Spiral_wasm::closure9(patternInput.0.clone(), ());
                ()
            };
            println!("{}", v0_1.clone());
            ((patternInput.1.clone()).l0.get().clone())(v0_1)
        }
        pub fn closure5(v0_1: Array<string>, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v19: () = {
                    Spiral_wasm::closure6((), ());
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
                let v45: Option<i64> = patternInput.5.clone();
                let v44: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v43: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v42: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v41: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v40: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method17(
                    v40.clone(),
                    v41.clone(),
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    Spiral_wasm::method10(v40, v41, v42, v43, v44, v45),
                    Spiral_wasm::method14(),
                    v0_1,
                ))
            };
        }
        pub fn method20() -> string {
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
        pub fn method21() -> Func1<std::string::String, string> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure12((), v))
        }
        pub fn method23() -> string {
            string("wasm")
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
            v8: string,
        ) -> string {
            let v10: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v24: () = {
                Spiral_wasm::closure8(v10.clone(), string("{ "), ());
                ()
            };
            let v43: () = {
                Spiral_wasm::closure8(v10.clone(), string("wasm_path"), ());
                ()
            };
            let v62: () = {
                Spiral_wasm::closure8(v10.clone(), string(" = "), ());
                ()
            };
            let v79: () = {
                Spiral_wasm::closure8(v10.clone(), v8, ());
                ()
            };
            let v98: () = {
                Spiral_wasm::closure8(v10.clone(), string(" }"), ());
                ()
            };
            let v104: string = v10.l0.get().clone();
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
                (v104),
            ))
        }
        pub fn closure13(v0_1: string, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v19: () = {
                    Spiral_wasm::closure6((), ());
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
                let v45: Option<i64> = patternInput.5.clone();
                let v44: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v43: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v42: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v41: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v40: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method24(
                    v40.clone(),
                    v41.clone(),
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    Spiral_wasm::method10(v40, v41, v42, v43, v44, v45),
                    Spiral_wasm::method14(),
                    v0_1,
                ))
            };
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
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v26: () = {
                Spiral_wasm::closure8(v12.clone(), string("{ "), ());
                ()
            };
            let v45: () = {
                Spiral_wasm::closure8(v12.clone(), string("retry"), ());
                ()
            };
            let v64: () = {
                Spiral_wasm::closure8(v12.clone(), string(" = "), ());
                ()
            };
            let v84: () = {
                Spiral_wasm::closure8(v12.clone(), sprintf!("{}", v8), ());
                ()
            };
            let v103: () = {
                Spiral_wasm::closure8(v12.clone(), string("; "), ());
                ()
            };
            let v122: () = {
                Spiral_wasm::closure8(v12.clone(), string("worker"), ());
                ()
            };
            let v139: () = {
                Spiral_wasm::closure8(v12.clone(), string(" = "), ());
                ()
            };
            let v151: std::string::String = format!("{:#?}", v9);
            let v195: () = {
                Spiral_wasm::closure8(
                    v12.clone(),
                    fable_library_rust::String_::fromString(v151),
                    (),
                );
                ()
            };
            let v212: () = {
                Spiral_wasm::closure8(v12.clone(), string("; "), ());
                ()
            };
            let v231: () = {
                Spiral_wasm::closure8(v12.clone(), string("contract"), ());
                ()
            };
            let v248: () = {
                Spiral_wasm::closure8(v12.clone(), string(" = "), ());
                ()
            };
            let v260: std::string::String = format!("{:#?}", v10);
            let v304: () = {
                Spiral_wasm::closure8(
                    v12.clone(),
                    fable_library_rust::String_::fromString(v260),
                    (),
                );
                ()
            };
            let v323: () = {
                Spiral_wasm::closure8(v12.clone(), string(" }"), ());
                ()
            };
            let v329: string = v12.l0.get().clone();
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
                (v329),
            ))
        }
        pub fn closure14(
            v0_1: u8,
            v1: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v2: near_workspaces::Contract,
            unitVar: (),
        ) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v21: () = {
                    Spiral_wasm::closure6((), ());
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
                let v47: Option<i64> = patternInput.5.clone();
                let v46: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v45: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v44: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v43: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v42: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method27(
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    v46.clone(),
                    v47.clone(),
                    Spiral_wasm::method10(v42, v43, v44, v45, v46, v47),
                    Spiral_wasm::method14(),
                    v0_1,
                    v1,
                    v2,
                ))
            };
        }
        pub fn method28(
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
            let v11: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v25: () = {
                Spiral_wasm::closure8(v11.clone(), string("{ "), ());
                ()
            };
            let v44: () = {
                Spiral_wasm::closure8(v11.clone(), string("retry"), ());
                ()
            };
            let v63: () = {
                Spiral_wasm::closure8(v11.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral_wasm::closure8(v11.clone(), sprintf!("{}", v8), ());
                ()
            };
            let v102: () = {
                Spiral_wasm::closure8(v11.clone(), string("; "), ());
                ()
            };
            let v121: () = {
                Spiral_wasm::closure8(v11.clone(), string("result"), ());
                ()
            };
            let v138: () = {
                Spiral_wasm::closure8(v11.clone(), string(" = "), ());
                ()
            };
            let v150: std::string::String = format!("{:#?}", v9);
            let v194: () = {
                Spiral_wasm::closure8(
                    v11.clone(),
                    fable_library_rust::String_::fromString(v150),
                    (),
                );
                ()
            };
            let v213: () = {
                Spiral_wasm::closure8(v11.clone(), string(" }"), ());
                ()
            };
            let v219: string = v11.l0.get().clone();
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
                (v219),
            ))
        }
        pub fn closure15(v0_1: u8, v1: near_workspaces::result::ExecutionFinalResult, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v20: () = {
                    Spiral_wasm::closure6((), ());
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
                let v46: Option<i64> = patternInput.5.clone();
                let v45: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v44: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v43: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v42: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v41: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method28(
                    v41.clone(),
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    v46.clone(),
                    Spiral_wasm::method10(v41, v42, v43, v44, v45, v46),
                    Spiral_wasm::method14(),
                    v0_1,
                    v1,
                ))
            };
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
        pub fn method29() {
            let v16: () = {
                Spiral_wasm::closure6((), ());
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
            let v59: () = {
                Spiral_wasm::closure9(patternInput.0.clone(), ());
                ()
            };
            println!("{}", string(" "));
            ((patternInput.1.clone()).l0.get().clone())(string(" "))
        }
        pub fn closure18(unitVar: (), unitVar_1: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_2) {
                Spiral_wasm::method29();
            };
        }
        pub fn method30() -> string {
            let v7: char = getCharAt(toLower(string("Info")), 0_i32);
            let v9: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v24: () = {
                Spiral_wasm::closure8(v9.clone(), sprintf!("{}", v7), ());
                ()
            };
            let v30: string = v9.l0.get().clone();
            let v49: &str = inline_colorization::color_bright_green;
            let v56: &str = &*v30;
            let v84: &str = inline_colorization::color_reset;
            let v86: std::string::String = format!("{}{}{}", v49, v56, v84);
            fable_library_rust::String_::fromString(v86)
        }
        pub fn method31(
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
            let v12: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v26: () = {
                Spiral_wasm::closure8(v12.clone(), string("{ "), ());
                ()
            };
            let v45: () = {
                Spiral_wasm::closure8(v12.clone(), string("retry"), ());
                ()
            };
            let v64: () = {
                Spiral_wasm::closure8(v12.clone(), string(" = "), ());
                ()
            };
            let v84: () = {
                Spiral_wasm::closure8(v12.clone(), sprintf!("{}", v8), ());
                ()
            };
            let v103: () = {
                Spiral_wasm::closure8(v12.clone(), string("; "), ());
                ()
            };
            let v122: () = {
                Spiral_wasm::closure8(v12.clone(), string("total_gas_burnt_usd"), ());
                ()
            };
            let v139: () = {
                Spiral_wasm::closure8(v12.clone(), string(" = "), ());
                ()
            };
            let v159: () = {
                Spiral_wasm::closure8(v12.clone(), sprintf!("{:+.6}", v9), ());
                ()
            };
            let v176: () = {
                Spiral_wasm::closure8(v12.clone(), string("; "), ());
                ()
            };
            let v195: () = {
                Spiral_wasm::closure8(v12.clone(), string("total_gas_burnt"), ());
                ()
            };
            let v212: () = {
                Spiral_wasm::closure8(v12.clone(), string(" = "), ());
                ()
            };
            let v232: () = {
                Spiral_wasm::closure8(v12.clone(), sprintf!("{}", v10), ());
                ()
            };
            let v251: () = {
                Spiral_wasm::closure8(v12.clone(), string(" }"), ());
                ()
            };
            let v257: string = v12.l0.get().clone();
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
                (v257),
            ))
        }
        pub fn closure19(v0_1: u8, v1: u64, v2: f64, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_2) {
                let v21: () = {
                    Spiral_wasm::closure6((), ());
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
                let v47: Option<i64> = patternInput.5.clone();
                let v46: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v45: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v44: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v43: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v42: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method31(
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    v46.clone(),
                    v47.clone(),
                    Spiral_wasm::method10(v42, v43, v44, v45, v46, v47),
                    Spiral_wasm::method30(),
                    v0_1,
                    v2,
                    v1,
                ))
            };
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
            v8: bool,
            v9: f64,
            v10: f64,
            v11: u64,
            v12: u128,
        ) -> string {
            let v14: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v28: () = {
                Spiral_wasm::closure8(v14.clone(), string("{ "), ());
                ()
            };
            let v47: () = {
                Spiral_wasm::closure8(v14.clone(), string("is_success"), ());
                ()
            };
            let v66: () = {
                Spiral_wasm::closure8(v14.clone(), string(" = "), ());
                ()
            };
            let v86: () = {
                Spiral_wasm::closure8(
                    v14.clone(),
                    if v8 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v105: () = {
                Spiral_wasm::closure8(v14.clone(), string("; "), ());
                ()
            };
            let v124: () = {
                Spiral_wasm::closure8(v14.clone(), string("gas_burnt_usd"), ());
                ()
            };
            let v141: () = {
                Spiral_wasm::closure8(v14.clone(), string(" = "), ());
                ()
            };
            let v161: () = {
                Spiral_wasm::closure8(v14.clone(), sprintf!("{:+.6}", v9), ());
                ()
            };
            let v178: () = {
                Spiral_wasm::closure8(v14.clone(), string("; "), ());
                ()
            };
            let v197: () = {
                Spiral_wasm::closure8(v14.clone(), string("tokens_burnt_usd"), ());
                ()
            };
            let v214: () = {
                Spiral_wasm::closure8(v14.clone(), string(" = "), ());
                ()
            };
            let v234: () = {
                Spiral_wasm::closure8(v14.clone(), sprintf!("{:+.6}", v10), ());
                ()
            };
            let v251: () = {
                Spiral_wasm::closure8(v14.clone(), string("; "), ());
                ()
            };
            let v270: () = {
                Spiral_wasm::closure8(v14.clone(), string("gas_burnt"), ());
                ()
            };
            let v287: () = {
                Spiral_wasm::closure8(v14.clone(), string(" = "), ());
                ()
            };
            let v307: () = {
                Spiral_wasm::closure8(v14.clone(), sprintf!("{}", v11), ());
                ()
            };
            let v324: () = {
                Spiral_wasm::closure8(v14.clone(), string("; "), ());
                ()
            };
            let v343: () = {
                Spiral_wasm::closure8(v14.clone(), string("tokens_burnt"), ());
                ()
            };
            let v360: () = {
                Spiral_wasm::closure8(v14.clone(), string(" = "), ());
                ()
            };
            let v372: std::string::String = format!("{:#?}", v12);
            let v416: () = {
                Spiral_wasm::closure8(
                    v14.clone(),
                    fable_library_rust::String_::fromString(v372),
                    (),
                );
                ()
            };
            let v435: () = {
                Spiral_wasm::closure8(v14.clone(), string(" }"), ());
                ()
            };
            let v441: string = v14.l0.get().clone();
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
                (v441),
            ))
        }
        pub fn closure21(v0_1: bool, v1: u64, v2: f64, v3: u128, v4: f64, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_2) {
                let v23: () = {
                    Spiral_wasm::closure6((), ());
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
                let v49: Option<i64> = patternInput.5.clone();
                let v48: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v47: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v46: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v45: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v44: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method32(
                    v44.clone(),
                    v45.clone(),
                    v46.clone(),
                    v47.clone(),
                    v48.clone(),
                    v49.clone(),
                    Spiral_wasm::method10(v44, v45, v46, v47, v48, v49),
                    Spiral_wasm::method30(),
                    v0_1,
                    v2,
                    v4,
                    v1,
                    v3,
                ))
            };
        }
        pub fn closure20(unitVar: (), v0_1: near_workspaces::result::ExecutionOutcome) {
            let v2: bool = v0_1.clone().is_success();
            let v4: near_workspaces::types::Gas = v0_1.clone().gas_burnt;
            let v6: u64 = v4.as_gas();
            let v13: f64 = ((v6 as f64) / 10000000000000000.0_f64) * 6.68_f64;
            let v15: near_workspaces::types::NearToken = v0_1.tokens_burnt;
            let v17: u128 = v15.as_yoctonear();
            let v84: () = {
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
        pub fn method33(
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
            let v10: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v24: () = {
                Spiral_wasm::closure8(v10.clone(), string("{ "), ());
                ()
            };
            let v43: () = {
                Spiral_wasm::closure8(v10.clone(), string("result2"), ());
                ()
            };
            let v62: () = {
                Spiral_wasm::closure8(v10.clone(), string(" = "), ());
                ()
            };
            let v74: std::string::String = format!("{:#?}", v8);
            let v118: () = {
                Spiral_wasm::closure8(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v74),
                    (),
                );
                ()
            };
            let v137: () = {
                Spiral_wasm::closure8(v10.clone(), string(" }"), ());
                ()
            };
            let v143: string = v10.l0.get().clone();
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
                (v143),
            ))
        }
        pub fn closure22(
            v0_1: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
            unitVar: (),
        ) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v19: () = {
                    Spiral_wasm::closure6((), ());
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
                let v45: Option<i64> = patternInput.5.clone();
                let v44: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v43: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v42: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v41: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v40: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method33(
                    v40.clone(),
                    v41.clone(),
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    Spiral_wasm::method10(v40, v41, v42, v43, v44, v45),
                    Spiral_wasm::method14(),
                    v0_1,
                ))
            };
        }
        pub fn method34(
            v0_1: near_workspaces::result::ExecutionFinalResult,
        ) -> near_workspaces::result::ExecutionFinalResult {
            v0_1
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
            v8: i32,
            v9: Vec<&near_workspaces::result::ExecutionOutcome>,
        ) -> string {
            let v11: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v25: () = {
                Spiral_wasm::closure8(v11.clone(), string("{ "), ());
                ()
            };
            let v44: () = {
                Spiral_wasm::closure8(v11.clone(), string("receipt_failures_len"), ());
                ()
            };
            let v63: () = {
                Spiral_wasm::closure8(v11.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral_wasm::closure8(v11.clone(), sprintf!("{}", v8), ());
                ()
            };
            let v102: () = {
                Spiral_wasm::closure8(v11.clone(), string("; "), ());
                ()
            };
            let v121: () = {
                Spiral_wasm::closure8(v11.clone(), string("receipt_failures"), ());
                ()
            };
            let v138: () = {
                Spiral_wasm::closure8(v11.clone(), string(" = "), ());
                ()
            };
            let v150: std::string::String = format!("{:#?}", v9);
            let v194: () = {
                Spiral_wasm::closure8(
                    v11.clone(),
                    fable_library_rust::String_::fromString(v150),
                    (),
                );
                ()
            };
            let v213: () = {
                Spiral_wasm::closure8(v11.clone(), string(" }"), ());
                ()
            };
            let v219: string = v11.l0.get().clone();
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
                (v219),
            ))
        }
        pub fn closure23(
            v0_1: Vec<&near_workspaces::result::ExecutionOutcome>,
            v1: i32,
            unitVar: (),
        ) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v20: () = {
                    Spiral_wasm::closure6((), ());
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
                let v46: Option<i64> = patternInput.5.clone();
                let v45: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v44: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v43: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v42: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v41: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method35(
                    v41.clone(),
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    v46.clone(),
                    Spiral_wasm::method10(v41, v42, v43, v44, v45, v46),
                    Spiral_wasm::method14(),
                    v1,
                    v0_1,
                ))
            };
        }
        pub fn method36(
            v0_1: near_workspaces::result::ExecutionFinalResult,
        ) -> near_workspaces::result::ExecutionFinalResult {
            v0_1
        }
        pub fn method37(
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
            let v11: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v25: () = {
                Spiral_wasm::closure8(v11.clone(), string("{ "), ());
                ()
            };
            let v44: () = {
                Spiral_wasm::closure8(v11.clone(), string("receipt_outcomes_len"), ());
                ()
            };
            let v63: () = {
                Spiral_wasm::closure8(v11.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral_wasm::closure8(v11.clone(), sprintf!("{}", v8), ());
                ()
            };
            let v102: () = {
                Spiral_wasm::closure8(v11.clone(), string("; "), ());
                ()
            };
            let v121: () = {
                Spiral_wasm::closure8(v11.clone(), string("receipt_outcomes"), ());
                ()
            };
            let v138: () = {
                Spiral_wasm::closure8(v11.clone(), string(" = "), ());
                ()
            };
            let v150: std::string::String = format!("{:#?}", v9);
            let v194: () = {
                Spiral_wasm::closure8(
                    v11.clone(),
                    fable_library_rust::String_::fromString(v150),
                    (),
                );
                ()
            };
            let v213: () = {
                Spiral_wasm::closure8(v11.clone(), string(" }"), ());
                ()
            };
            let v219: string = v11.l0.get().clone();
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
                (v219),
            ))
        }
        pub fn closure24(
            v0_1: Vec<near_workspaces::result::ExecutionOutcome>,
            v1: i32,
            unitVar: (),
        ) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v20: () = {
                    Spiral_wasm::closure6((), ());
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
                let v46: Option<i64> = patternInput.5.clone();
                let v45: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v44: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v43: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v42: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v41: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method37(
                    v41.clone(),
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    v46.clone(),
                    Spiral_wasm::method10(v41, v42, v43, v44, v45, v46),
                    Spiral_wasm::method14(),
                    v1,
                    v0_1,
                ))
            };
        }
        pub fn method38(
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
            let v10: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v24: () = {
                Spiral_wasm::closure8(v10.clone(), string("{ "), ());
                ()
            };
            let v43: () = {
                Spiral_wasm::closure8(v10.clone(), string("json"), ());
                ()
            };
            let v62: () = {
                Spiral_wasm::closure8(v10.clone(), string(" = "), ());
                ()
            };
            let v74: std::string::String = format!("{:#?}", v8);
            let v118: () = {
                Spiral_wasm::closure8(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v74),
                    (),
                );
                ()
            };
            let v137: () = {
                Spiral_wasm::closure8(v10.clone(), string(" }"), ());
                ()
            };
            let v143: string = v10.l0.get().clone();
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
                (v143),
            ))
        }
        pub fn closure25(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v19: () = {
                    Spiral_wasm::closure6((), ());
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
                let v45: Option<i64> = patternInput.5.clone();
                let v44: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v43: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v42: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v41: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v40: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method38(
                    v40.clone(),
                    v41.clone(),
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    Spiral_wasm::method10(v40, v41, v42, v43, v44, v45),
                    Spiral_wasm::method14(),
                    v0_1,
                ))
            };
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
            v8: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v10: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v24: () = {
                Spiral_wasm::closure8(v10.clone(), string("{ "), ());
                ()
            };
            let v43: () = {
                Spiral_wasm::closure8(v10.clone(), string("borsh"), ());
                ()
            };
            let v62: () = {
                Spiral_wasm::closure8(v10.clone(), string(" = "), ());
                ()
            };
            let v74: std::string::String = format!("{:#?}", v8);
            let v118: () = {
                Spiral_wasm::closure8(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v74),
                    (),
                );
                ()
            };
            let v137: () = {
                Spiral_wasm::closure8(v10.clone(), string(" }"), ());
                ()
            };
            let v143: string = v10.l0.get().clone();
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
                (v143),
            ))
        }
        pub fn closure26(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v19: () = {
                    Spiral_wasm::closure6((), ());
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
                let v45: Option<i64> = patternInput.5.clone();
                let v44: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v43: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v42: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v41: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v40: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method39(
                    v40.clone(),
                    v41.clone(),
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    Spiral_wasm::method10(v40, v41, v42, v43, v44, v45),
                    Spiral_wasm::method14(),
                    v0_1,
                ))
            };
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
                    let v82: () = {
                        Spiral_wasm::closure14(v1, v11, v19.clone(), ());
                        ()
                    };
                    let v145: near_workspaces::operations::CallTransaction =
                        v19.call(&*string("state_main"));
                    let v147: near_workspaces::types::Gas =
                        near_workspaces::types::Gas::from_tgas(300);
                    let v149: near_workspaces::operations::CallTransaction = v145.gas(v147);
                    let v151: std::pin::Pin<
                        Box<
                            dyn std::future::Future<
                                    Output = Result<
                                        near_workspaces::result::ExecutionFinalResult,
                                        near_workspaces::error::Error,
                                    >,
                                >,
                        >,
                    > = Box::pin(v149.transact());
                    let v153: Result<
                        near_workspaces::result::ExecutionFinalResult,
                        near_workspaces::error::Error,
                    > = v151.await;
                    let v155: near_workspaces::result::ExecutionFinalResult = v153?;
                    let v218: () = {
                        Spiral_wasm::closure15(v1, v155.clone(), ());
                        ()
                    };
                    let v280: Vec<&str> = v155.logs();
                    let v282: bool = true;
                    let _vec_map: Vec<_> = v280
                        .into_iter()
                        .map(|x| {
                            //;
                            let v284: &str = x;
                            let v291: std::string::String = String::from(v284);
                            let v319: bool = true;
                            v291
                        })
                        .collect::<Vec<_>>();
                    let v321: Vec<std::string::String> = _vec_map;
                    let v324: bool = true;
                    v321.iter().for_each(|x| {
                        Func1::new(move |v: std::string::String| Spiral_wasm::closure16((), v))(
                            x.clone(),
                        );
                    }); //;
                    let v329: () = {
                        Spiral_wasm::closure18((), ());
                        ()
                    };
                    let v333: near_workspaces::types::Gas = v155.clone().total_gas_burnt;
                    let v335: u64 = v333.as_gas();
                    let v405: () = {
                        Spiral_wasm::closure19(
                            v1,
                            v335,
                            ((v335 as f64) / 10000000000000000.0_f64) * 6.68_f64,
                            (),
                        );
                        ()
                    };
                    let v467: near_workspaces::result::ExecutionFinalResult = v155.clone();
                    let v469: Vec<&near_workspaces::result::ExecutionOutcome> = v467.outcomes();
                    let v471 = v469.into_iter();
                    let v473 = v471.cloned();
                    let v476: bool = true;
                    v473.for_each(|x| {
                        Func1::new(move |v_1: near_workspaces::result::ExecutionOutcome| {
                            Spiral_wasm::closure20((), v_1)
                        })(x)
                    });
                    let v541: () = {
                        Spiral_wasm::closure22(v155.clone().into_result(), ());
                        ()
                    };
                    let v602: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method34(v155.clone());
                    let v604: Vec<&near_workspaces::result::ExecutionOutcome> =
                        v602.receipt_failures();
                    let v612: i32 = v604.clone().len() as i32;
                    let v682: () = {
                        Spiral_wasm::closure23(v604.clone(), v612, ());
                        ()
                    };
                    let v743: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method36(v155.clone());
                    let v745: &[near_workspaces::result::ExecutionOutcome] =
                        v743.receipt_outcomes();
                    let v747: Vec<near_workspaces::result::ExecutionOutcome> = v745.into();
                    let v755: i32 = v747.clone().len() as i32;
                    let v825: () = {
                        Spiral_wasm::closure24(v747, v755, ());
                        ()
                    };
                    let v950: () = {
                        Spiral_wasm::closure25(v155.clone().json(), ());
                        ()
                    };
                    let v1075: () = {
                        Spiral_wasm::closure26(v155.borsh(), ());
                        ()
                    };
                    let v1137: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                        l0: MutCell::new(Spiral_wasm::method15()),
                    });
                    let v1151: () = {
                        Spiral_wasm::closure8(v1137.clone(), string("{ "), ());
                        ()
                    };
                    let v1170: () = {
                        Spiral_wasm::closure8(v1137.clone(), string("receipt_outcomes_len"), ());
                        ()
                    };
                    let v1189: () = {
                        Spiral_wasm::closure8(v1137.clone(), string(" = "), ());
                        ()
                    };
                    let v1209: () = {
                        Spiral_wasm::closure8(v1137.clone(), sprintf!("{}", v755), ());
                        ()
                    };
                    let v1228: () = {
                        Spiral_wasm::closure8(v1137.clone(), string("; "), ());
                        ()
                    };
                    let v1247: () = {
                        Spiral_wasm::closure8(v1137.clone(), string("retry"), ());
                        ()
                    };
                    let v1264: () = {
                        Spiral_wasm::closure8(v1137.clone(), string(" = "), ());
                        ()
                    };
                    let v1284: () = {
                        Spiral_wasm::closure8(v1137.clone(), sprintf!("{}", v1), ());
                        ()
                    };
                    let v1301: () = {
                        Spiral_wasm::closure8(v1137.clone(), string("; "), ());
                        ()
                    };
                    let v1320: () = {
                        Spiral_wasm::closure8(v1137.clone(), string("receipt_failures"), ());
                        ()
                    };
                    let v1337: () = {
                        Spiral_wasm::closure8(v1137.clone(), string(" = "), ());
                        ()
                    };
                    let v1349: std::string::String = format!("{:#?}", v604);
                    let v1393: () = {
                        Spiral_wasm::closure8(
                            v1137.clone(),
                            fable_library_rust::String_::fromString(v1349),
                            (),
                        );
                        ()
                    };
                    let v1412: () = {
                        Spiral_wasm::closure8(v1137.clone(), string(" }"), ());
                        ()
                    };
                    let v1418: string = v1137.l0.get().clone();
                    let v1453: Result<Spiral_wasm::US7, anyhow::Error> = if (v612) > 0_i32 {
                        Ok::<Spiral_wasm::US7, anyhow::Error>(Spiral_wasm::US7::US7_0(
                            v1418.clone(),
                        ))
                    } else {
                        if (v755) > 1_i32 {
                            Ok::<Spiral_wasm::US7, anyhow::Error>(Spiral_wasm::US7::US7_1)
                        } else {
                            let v1436: anyhow::Error = anyhow::anyhow!(v1418);
                            Err(v1436)
                        }
                    };
                    let v1456: string = string("}");
                    let v1461: bool = true;
                    let _fix_closure_v1458 = v1453;
                    let v1468: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v1458 "), (v1456))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v1469: bool = true;
                    _fix_closure_v1458
                },
            ); // rust.fix_closure';
            let v1471 = __future_init;
            v1471
        }
        pub fn closure27(unitVar: (), v0_1: anyhow::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method40() -> Func1<anyhow::Error, std::string::String> {
            Func1::new(move |v: anyhow::Error| Spiral_wasm::closure27((), v))
        }
        pub fn closure28(unitVar: (), v0_1: Spiral_wasm::US7) -> Spiral_wasm::US9 {
            Spiral_wasm::US9::US9_0(v0_1)
        }
        pub fn method41() -> Func1<Spiral_wasm::US7, Spiral_wasm::US9> {
            Func1::new(move |v: Spiral_wasm::US7| Spiral_wasm::closure28((), v))
        }
        pub fn closure29(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US9 {
            Spiral_wasm::US9::US9_1(v0_1)
        }
        pub fn method42() -> Func1<std::string::String, Spiral_wasm::US9> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure29((), v))
        }
        pub fn method43() -> string {
            let v7: char = getCharAt(toLower(string("Warning")), 0_i32);
            let v9: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v24: () = {
                Spiral_wasm::closure8(v9.clone(), sprintf!("{}", v7), ());
                ()
            };
            let v30: string = v9.l0.get().clone();
            let v49: &str = inline_colorization::color_yellow;
            let v56: &str = &*v30;
            let v84: &str = inline_colorization::color_reset;
            let v86: std::string::String = format!("{}{}{}", v49, v56, v84);
            fable_library_rust::String_::fromString(v86)
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
            v8: u8,
            v9: std::string::String,
        ) -> string {
            let v11: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v25: () = {
                Spiral_wasm::closure8(v11.clone(), string("{ "), ());
                ()
            };
            let v44: () = {
                Spiral_wasm::closure8(v11.clone(), string("retry"), ());
                ()
            };
            let v63: () = {
                Spiral_wasm::closure8(v11.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral_wasm::closure8(v11.clone(), sprintf!("{}", v8), ());
                ()
            };
            let v102: () = {
                Spiral_wasm::closure8(v11.clone(), string("; "), ());
                ()
            };
            let v121: () = {
                Spiral_wasm::closure8(v11.clone(), string("error"), ());
                ()
            };
            let v138: () = {
                Spiral_wasm::closure8(v11.clone(), string(" = "), ());
                ()
            };
            let v150: std::string::String = format!("{:#?}", v9);
            let v194: () = {
                Spiral_wasm::closure8(
                    v11.clone(),
                    fable_library_rust::String_::fromString(v150),
                    (),
                );
                ()
            };
            let v213: () = {
                Spiral_wasm::closure8(v11.clone(), string(" }"), ());
                ()
            };
            let v219: string = v11.l0.get().clone();
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
                (v219),
            ))
        }
        pub fn closure30(v0_1: u8, v1: std::string::String, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_3) {
                let v20: () = {
                    Spiral_wasm::closure6((), ());
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
                let v46: Option<i64> = patternInput.5.clone();
                let v45: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v44: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v43: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v42: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v41: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method44(
                    v41.clone(),
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    v46.clone(),
                    Spiral_wasm::method10(v41, v42, v43, v44, v45, v46),
                    Spiral_wasm::method43(),
                    v0_1,
                    v1,
                ))
            };
        }
        pub fn method45() {
            let v16: () = {
                Spiral_wasm::closure6((), ());
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
            let v59: () = {
                Spiral_wasm::closure9(patternInput.0.clone(), ());
                ()
            };
            println!("{}", string("\n"));
            ((patternInput.1.clone()).l0.get().clone())(string("\n"))
        }
        pub fn closure31(unitVar: (), unitVar_1: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_3) {
                Spiral_wasm::method45();
            };
        }
        pub fn closure32(v0_1: u8, v1: std::string::String, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_3) {
                let v20: () = {
                    Spiral_wasm::closure6((), ());
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
                let v46: Option<i64> = patternInput.5.clone();
                let v45: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v44: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v43: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v42: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v41: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method44(
                    v41.clone(),
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    v46.clone(),
                    Spiral_wasm::method10(v41, v42, v43, v44, v45, v46),
                    Spiral_wasm::method43(),
                    v0_1,
                    v1,
                ))
            };
        }
        pub fn closure33(unitVar: (), unitVar_1: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_3) {
                Spiral_wasm::method45();
            };
        }
        pub fn method46() -> string {
            let v7: char = getCharAt(toLower(string("Critical")), 0_i32);
            let v9: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v24: () = {
                Spiral_wasm::closure8(v9.clone(), sprintf!("{}", v7), ());
                ()
            };
            let v30: string = v9.l0.get().clone();
            let v49: &str = inline_colorization::color_bright_red;
            let v56: &str = &*v30;
            let v84: &str = inline_colorization::color_reset;
            let v86: std::string::String = format!("{}{}{}", v49, v56, v84);
            fable_library_rust::String_::fromString(v86)
        }
        pub fn method47(
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
            let v11: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v25: () = {
                Spiral_wasm::closure8(v11.clone(), string("{ "), ());
                ()
            };
            let v44: () = {
                Spiral_wasm::closure8(v11.clone(), string("retry"), ());
                ()
            };
            let v63: () = {
                Spiral_wasm::closure8(v11.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral_wasm::closure8(v11.clone(), sprintf!("{}", v8), ());
                ()
            };
            let v102: () = {
                Spiral_wasm::closure8(v11.clone(), string("; "), ());
                ()
            };
            let v121: () = {
                Spiral_wasm::closure8(v11.clone(), string("error"), ());
                ()
            };
            let v138: () = {
                Spiral_wasm::closure8(v11.clone(), string(" = "), ());
                ()
            };
            let v155: () = {
                Spiral_wasm::closure8(v11.clone(), v9, ());
                ()
            };
            let v174: () = {
                Spiral_wasm::closure8(v11.clone(), string(" }"), ());
                ()
            };
            let v180: string = v11.l0.get().clone();
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
                (v180),
            ))
        }
        pub fn closure34(v0_1: u8, v1: string, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_4) {
                let v20: () = {
                    Spiral_wasm::closure6((), ());
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
                let v46: Option<i64> = patternInput.5.clone();
                let v45: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v44: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v43: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v42: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v41: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method47(
                    v41.clone(),
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    v46.clone(),
                    Spiral_wasm::method10(v41, v42, v43, v44, v45, v46),
                    Spiral_wasm::method46(),
                    v0_1,
                    v1,
                ))
            };
        }
        pub fn method25(
            v0_1: Vec<u8>,
            v1: u8,
        ) -> std::pin::Pin<Box<dyn std::future::Future<Output = Spiral_wasm::US8>>> {
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
                    let v11 = Spiral_wasm::method40();
                    let v24: Result<Spiral_wasm::US7, std::string::String> =
                        v10.map_err(|x| v11(x));
                    let v27 = Spiral_wasm::method41();
                    let v28 = Spiral_wasm::method42();
                    let v30: Spiral_wasm::US9 = match &v24 {
                        Err(v24_1_0) => v28(v24_1_0.clone()),
                        Ok(v24_0_0) => v27(v24_0_0.clone()),
                    };
                    let v521: Spiral_wasm::US8 = match &v30 {
                        Spiral_wasm::US9::US9_0(v30_0_0) => {
                            let v33: Spiral_wasm::US7 = v30_0_0.clone();
                            match &v33 {
                                Spiral_wasm::US7::US7_0(v33_0_0) => {
                                    let v65: string = match &v33 {
                                        Spiral_wasm::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone();
                                    let v128: () = {
                                        Spiral_wasm::closure34(v1, v65.clone(), ());
                                        ()
                                    };
                                    let v190: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v192: bool = */
                                        async move {
                                            /*;
                                            let v194: bool = */
                                            ();
                                            let v197: string = string("}");
                                            let v203: bool = true;
                                            let _fix_closure_v200 =
                                                (v1, Spiral_wasm::US7::US7_0(v65));
                                            let v210: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v200 "),
                                                            (v197),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v211: bool = true;
                                            _fix_closure_v200
                                        },
                                    ); // rust.fix_closure';
                                    let v213 = __future_init;
                                    let v215: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<Output = (u8, Spiral_wasm::US7)>,
                                        >,
                                    > = v213;
                                    let patternInput_2: (u8, Spiral_wasm::US7) = v215.await;
                                    Spiral_wasm::US8::US8_1(
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
                                            let v55: string = append(
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
                                            let v56: bool = true;
                                            _fix_closure_v45
                                        },
                                    ); // rust.fix_closure';
                                    let v58 = __future_init;
                                    let v60: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<Output = (u8, Spiral_wasm::US7)>,
                                        >,
                                    > = v58;
                                    let patternInput_1: (u8, Spiral_wasm::US7) = v60.await;
                                    Spiral_wasm::US8::US8_0(
                                        patternInput_1.0.clone(),
                                        patternInput_1.1.clone(),
                                    )
                                }
                            }
                        }
                        Spiral_wasm::US9::US9_1(v30_1_0) => {
                            let v222: std::string::String = v30_1_0.clone();
                            if (v1) >= 15_u8 {
                                let v286: () = {
                                    Spiral_wasm::closure30(v1, v222.clone(), ());
                                    ()
                                };
                                let v351: () = {
                                    Spiral_wasm::closure31((), ());
                                    ()
                                };
                                let v355: bool = true;
                                let __future_init = Box::pin(
                                    /*;
                                    let v357: bool = */
                                    async move {
                                        /*;
                                        let v359: bool = */
                                        ();
                                        let v362: string = string("}");
                                        let v368: bool = true;
                                        let _fix_closure_v365 = (v1, Spiral_wasm::US7::US7_1);
                                        let v375: string = append(
                                            (append(
                                                (append(
                                                    (append(
                                                        string("true; _fix_closure_v365 "),
                                                        (v362),
                                                    )),
                                                    string("); "),
                                                )),
                                                string(""),
                                            )),
                                            string(" // rust.fix_closure\'"),
                                        );
                                        let v376: bool = true;
                                        _fix_closure_v365
                                    },
                                ); // rust.fix_closure';
                                let v378 = __future_init;
                                let v380: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = (u8, Spiral_wasm::US7)>>,
                                > = v378;
                                let patternInput: (u8, Spiral_wasm::US7) = v380.await;
                                Spiral_wasm::US8::US8_0(
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                )
                            } else {
                                let v447: () = {
                                    Spiral_wasm::closure32(v1, v222, ());
                                    ()
                                };
                                let v512: () = {
                                    Spiral_wasm::closure33((), ());
                                    ()
                                };
                                let v516: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = Spiral_wasm::US8>>,
                                > = Spiral_wasm::method25(v0_1.clone(), (v1) + 1_u8);
                                v516.await
                            }
                        }
                    };
                    let v524: string = string("}");
                    let v529: bool = true;
                    let _fix_closure_v526 = v521;
                    let v536: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v526 "), (v524))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v537: bool = true;
                    _fix_closure_v526
                },
            ); // rust.fix_closure';
            let v539 = __future_init;
            v539
        }
        pub fn method48(
            v0_1: LrcPtr<Spiral_wasm::Mut0>,
            v1: LrcPtr<Spiral_wasm::Mut1>,
            v2: LrcPtr<Spiral_wasm::Mut2>,
            v3: LrcPtr<Spiral_wasm::Mut3>,
            v4: LrcPtr<Spiral_wasm::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: Spiral_wasm::US8,
        ) -> string {
            let v10: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method15()),
            });
            let v24: () = {
                Spiral_wasm::closure8(v10.clone(), string("{ "), ());
                ()
            };
            let v43: () = {
                Spiral_wasm::closure8(v10.clone(), string("retries"), ());
                ()
            };
            let v62: () = {
                Spiral_wasm::closure8(v10.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral_wasm::closure8(v10.clone(), sprintf!("{:?}", v8), ());
                ()
            };
            let v102: () = {
                Spiral_wasm::closure8(v10.clone(), string(" }"), ());
                ()
            };
            let v108: string = v10.l0.get().clone();
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
                (v108),
            ))
        }
        pub fn closure35(v0_1: Spiral_wasm::US8, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v19: () = {
                    Spiral_wasm::closure6((), ());
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
                let v45: Option<i64> = patternInput.5.clone();
                let v44: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v43: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v42: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v41: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v40: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method19(Spiral_wasm::method48(
                    v40.clone(),
                    v41.clone(),
                    v42.clone(),
                    v43.clone(),
                    v44.clone(),
                    v45.clone(),
                    Spiral_wasm::method10(v40, v41, v42, v43, v44, v45),
                    Spiral_wasm::method14(),
                    v0_1,
                ))
            };
        }
        pub fn method22(
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
                    let v7: string = Spiral_wasm::method23();
                    let v14: &str = &*v7;
                    let v42: Option<std::string::String> =
                        clap::ArgMatches::get_one(&v0_1, v14).cloned();
                    let v67: Spiral_wasm::US0 =
                        defaultValue(Spiral_wasm::US0::US0_1, map(Spiral_wasm::method2(), v42));
                    let v74: std::string::String = match &v67 {
                        Spiral_wasm::US0::US0_0(v67_0_0) => match &v67 {
                            Spiral_wasm::US0::US0_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v76: string = fable_library_rust::String_::fromString(v74);
                    let v139: () = {
                        Spiral_wasm::closure13(v76.clone(), ());
                        ()
                    };
                    let v201: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v76);
                    let v205: std::pin::Pin<
                        Box<dyn std::future::Future<Output = Spiral_wasm::US8>>,
                    > = Spiral_wasm::method25(v201?, 1_u8);
                    let v207: Spiral_wasm::US8 = v205.await;
                    let v270: () = {
                        Spiral_wasm::closure35(v207.clone(), ());
                        ()
                    };
                    let v533: Result<u8, anyhow::Error> = match &v207 {
                        Spiral_wasm::US8::US8_0(v207_0_0, v207_0_1) => {
                            Ok::<u8, anyhow::Error>(v207_0_0.clone())
                        }
                        Spiral_wasm::US8::US8_1(v207_1_0, v207_1_1) => {
                            let v340: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                                l0: MutCell::new(Spiral_wasm::method15()),
                            });
                            let v354: () = {
                                Spiral_wasm::closure8(v340.clone(), string("{ "), ());
                                ()
                            };
                            let v373: () = {
                                Spiral_wasm::closure8(v340.clone(), string("retries"), ());
                                ()
                            };
                            let v392: () = {
                                Spiral_wasm::closure8(v340.clone(), string(" = "), ());
                                ()
                            };
                            let v413: () = {
                                Spiral_wasm::closure8(
                                    v340.clone(),
                                    sprintf!("{:?}", v207.clone()),
                                    (),
                                );
                                ()
                            };
                            let v432: () = {
                                Spiral_wasm::closure8(v340.clone(), string("; "), ());
                                ()
                            };
                            let v451: () = {
                                Spiral_wasm::closure8(v340.clone(), string("error"), ());
                                ()
                            };
                            let v468: () = {
                                Spiral_wasm::closure8(v340.clone(), string(" = "), ());
                                ()
                            };
                            let v489: () = {
                                Spiral_wasm::closure8(
                                    v340.clone(),
                                    sprintf!("{:?}", v207_1_1.clone()),
                                    (),
                                );
                                ()
                            };
                            let v508: () = {
                                Spiral_wasm::closure8(v340.clone(), string(" }"), ());
                                ()
                            };
                            let v514: string = v340.l0.get().clone();
                            let v516: anyhow::Error = anyhow::anyhow!(v514);
                            Err(v516)
                        }
                    };
                    let v536: string = string("}");
                    let v541: bool = true;
                    let _fix_closure_v538 = v533;
                    let v548: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v538 "), (v536))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v549: bool = true;
                    _fix_closure_v538
                },
            ); // rust.fix_closure';
            let v551 = __future_init;
            v551
        }
        pub fn closure36(unitVar: (), v0_1: u8) -> Spiral_wasm::US10 {
            Spiral_wasm::US10::US10_0(v0_1)
        }
        pub fn method49() -> Func1<u8, Spiral_wasm::US10> {
            Func1::new(move |v: u8| Spiral_wasm::closure36((), v))
        }
        pub fn closure37(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US10 {
            Spiral_wasm::US10::US10_1(v0_1)
        }
        pub fn method50() -> Func1<std::string::String, Spiral_wasm::US10> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure37((), v))
        }
        pub fn closure0(unitVar: (), v0_1: Array<string>) -> i32 {
            let v1: clap::Command = Spiral_wasm::method0();
            let v3: clap::ArgMatches = clap::Command::get_matches(v1);
            let v4: string = Spiral_wasm::method1();
            let v11: &str = &*v4;
            let v39: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v11).cloned();
            let v64: Spiral_wasm::US0 =
                defaultValue(Spiral_wasm::US0::US0_1, map(Spiral_wasm::method2(), v39));
            let v200: Spiral_wasm::US1 = match &v64 {
                Spiral_wasm::US0::US0_0(v64_0_0) => {
                    let v70: string = fable_library_rust::String_::fromString(
                        match &v64 {
                            Spiral_wasm::US0::US0_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    );
                    let v75: string = toLower(string("Critical"));
                    let v82: string = toLower(string("Warning"));
                    let v89: string = toLower(string("Info"));
                    let v96: string = toLower(string("Debug"));
                    let v103: string = toLower(string("Verbose"));
                    let v110: Spiral_wasm::US2 = if string("Verbose") == (v70.clone()) {
                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_0)
                    } else {
                        Spiral_wasm::US2::US2_1
                    };
                    Spiral_wasm::US1::US1_0(match &v110 {
                        Spiral_wasm::US2::US2_0(v110_0_0) => Spiral_wasm::US2::US2_0(
                            match &v110 {
                                Spiral_wasm::US2::US2_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v117: Spiral_wasm::US2 = if string("Debug") == (v70.clone()) {
                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_1)
                            } else {
                                Spiral_wasm::US2::US2_1
                            };
                            match &v117 {
                                Spiral_wasm::US2::US2_0(v117_0_0) => Spiral_wasm::US2::US2_0(
                                    match &v117 {
                                        Spiral_wasm::US2::US2_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v124: Spiral_wasm::US2 = if string("Info") == (v70.clone())
                                    {
                                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                    } else {
                                        Spiral_wasm::US2::US2_1
                                    };
                                    match &v124 {
                                        Spiral_wasm::US2::US2_0(v124_0_0) => {
                                            Spiral_wasm::US2::US2_0(
                                                match &v124 {
                                                    Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            )
                                        }
                                        _ => {
                                            let v131: Spiral_wasm::US2 =
                                                if string("Warning") == (v70.clone()) {
                                                    Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                                } else {
                                                    Spiral_wasm::US2::US2_1
                                                };
                                            match &v131 {
                                                Spiral_wasm::US2::US2_0(v131_0_0) => {
                                                    Spiral_wasm::US2::US2_0(
                                                        match &v131 {
                                                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => {
                                                    let v138: Spiral_wasm::US2 =
                                                        if string("Critical") == (v70.clone()) {
                                                            Spiral_wasm::US2::US2_0(
                                                                Spiral_wasm::US3::US3_4,
                                                            )
                                                        } else {
                                                            Spiral_wasm::US2::US2_1
                                                        };
                                                    match &v138 {
                                                        Spiral_wasm::US2::US2_0(v138_0_0) => {
                                                            Spiral_wasm::US2::US2_0(
                                                                match &v138 {
                                                                    Spiral_wasm::US2::US2_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            let v145: Spiral_wasm::US2 = if (v103
                                                                .clone())
                                                                == (v70.clone())
                                                            {
                                                                Spiral_wasm::US2::US2_0(
                                                                    Spiral_wasm::US3::US3_0,
                                                                )
                                                            } else {
                                                                Spiral_wasm::US2::US2_1
                                                            };
                                                            match &v145 {
                                                                Spiral_wasm::US2::US2_0(
                                                                    v145_0_0,
                                                                ) => Spiral_wasm::US2::US2_0(
                                                                    match &v145 {
                                                                        Spiral_wasm::US2::US2_0(
                                                                            x,
                                                                        ) => x.clone(),
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                ),
                                                                _ => {
                                                                    let v152: Spiral_wasm::US2 =
                                                                        if (v96.clone())
                                                                            == (v70.clone())
                                                                        {
                                                                            Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_1)
                                                                        } else {
                                                                            Spiral_wasm::US2::US2_1
                                                                        };
                                                                    match &v152
                                                                                                    {
                                                                                                    Spiral_wasm::US2::US2_0(v152_0_0)
                                                                                                    =>
                                                                                                    Spiral_wasm::US2::US2_0(match &v152
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
                                                                                                        let v159:
                                                                                                                Spiral_wasm::US2 =
                                                                                                            if (v89.clone())
                                                                                                                   ==
                                                                                                                   (v70.clone())
                                                                                                               {
                                                                                                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                                                                                            } else {
                                                                                                                Spiral_wasm::US2::US2_1
                                                                                                            };
                                                                                                        match &v159
                                                                                                            {
                                                                                                            Spiral_wasm::US2::US2_0(v159_0_0)
                                                                                                            =>
                                                                                                            Spiral_wasm::US2::US2_0(match &v159
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
                                                                                                                let v166:
                                                                                                                        Spiral_wasm::US2 =
                                                                                                                    if (v82.clone())
                                                                                                                           ==
                                                                                                                           (v70.clone())
                                                                                                                       {
                                                                                                                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                                                                                                    } else {
                                                                                                                        Spiral_wasm::US2::US2_1
                                                                                                                    };
                                                                                                                match &v166
                                                                                                                    {
                                                                                                                    Spiral_wasm::US2::US2_0(v166_0_0)
                                                                                                                    =>
                                                                                                                    Spiral_wasm::US2::US2_0(match &v166
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
                                                                                                                        let v173:
                                                                                                                                Spiral_wasm::US2 =
                                                                                                                            if (v75.clone())
                                                                                                                                   ==
                                                                                                                                   (v70.clone())
                                                                                                                               {
                                                                                                                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_4)
                                                                                                                            } else {
                                                                                                                                Spiral_wasm::US2::US2_1
                                                                                                                            };
                                                                                                                        match &v173
                                                                                                                            {
                                                                                                                            Spiral_wasm::US2::US2_0(v173_0_0)
                                                                                                                            =>
                                                                                                                            Spiral_wasm::US2::US2_0(match &v173
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
            let v207: Spiral_wasm::US2 = if let Spiral_wasm::US1::US1_0(v200_0_0) = &v200 {
                let v201: Spiral_wasm::US2 = v200_0_0.clone();
                if let Spiral_wasm::US2::US2_0(v201_0_0) = &v201 {
                    Spiral_wasm::US2::US2_0(v201_0_0.clone())
                } else {
                    Spiral_wasm::US2::US2_1
                }
            } else {
                Spiral_wasm::US2::US2_1
            };
            let v226: () = {
                Spiral_wasm::closure2(
                    match &v207 {
                        Spiral_wasm::US2::US2_0(v207_0_0) => match &v207 {
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
            let v325: () = {
                Spiral_wasm::closure5(v0_1, ());
                ()
            };
            let v386: string = Spiral_wasm::method20();
            let v393: &str = &*v386;
            let v421: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v393).cloned();
            let v425: Option<string> = map(Spiral_wasm::method21(), v421);
            let v554: Spiral_wasm::US7 =
                defaultValue(Spiral_wasm::US7::US7_1, map(Spiral_wasm::method8(), v425));
            let v558: std::pin::Pin<
                Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>,
            > = Spiral_wasm::method22(v3);
            let v560 = tokio::runtime::Builder::new_multi_thread()
                .enable_all()
                .build()
                .unwrap();
            let v562: Result<u8, anyhow::Error> = v560.handle().block_on(v558);
            let v563 = Spiral_wasm::method40();
            let v576: Result<u8, std::string::String> = v562.map_err(|x| v563(x));
            let v579 = Spiral_wasm::method49();
            let v580 = Spiral_wasm::method50();
            let v582: Spiral_wasm::US10 = match &v576 {
                Err(v576_1_0) => v580(v576_1_0.clone()),
                Ok(v576_0_0) => v579(v576_0_0.clone()),
            };
            match &v582 {
                Spiral_wasm::US10::US10_0(v582_0_0) => {
                    if let Spiral_wasm::US7::US7_0(v554_0_0) = &v554 {
                        let v587: string = sprintf!(
                            "spiral_wasm.main / retries: {} / exception: \'{}\'",
                            v582_0_0.clone(),
                            v554_0_0.clone()
                        );
                        let v591: Result<(), string> = Err(v587);
                        v591.unwrap();
                        ()
                    }
                }
                Spiral_wasm::US10::US10_1(v582_1_0) => {
                    let v607: std::string::String = v582_1_0.clone();
                    if let Spiral_wasm::US7::US7_0(v554_0_0) = &v554 {
                        let v608: string = v554_0_0.clone();
                        if string("") == (v608.clone()) {
                            ()
                        } else {
                            if contains(
                                fable_library_rust::String_::fromString(v607.clone()),
                                v608.clone(),
                            ) {
                                ()
                            } else {
                                let v616: string = sprintf!(
                                    "spiral_wasm.main / exception: \'{}\' / error: {}",
                                    v608,
                                    v607
                                );
                                let v620: Result<(), string> = Err(v616);
                                v620.unwrap();
                                ()
                            }
                        }
                    } else {
                        let v639: u8 = v576.clone().unwrap();
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
#[cfg(not(feature = "no_std"))]
pub fn main() {
    let args = std::env::args().skip(1).map(fromString).collect();
    Spiral_wasm::main(array_from(args));
}
