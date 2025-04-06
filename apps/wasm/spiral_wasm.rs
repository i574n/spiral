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
                    let v171: std::string::String = String::from(v135);
                    let v202: Box<std::string::String> = Box::new(v171);
                    let v204: &'static mut std::string::String = Box::leak(v202);
                    let v206: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v204);
                    let v208: bool = true;
                    v206
                })
                .collect::<Vec<_>>();
            let v210: Vec<clap::builder::PossibleValue> = _vec_map;
            let v212: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v210),
            );
            let v214: clap::Arg = v61.value_parser(v212);
            let v216: clap::Command = clap::Command::arg(v50, v214);
            let v218: string = string("r#\"wasm\"#");
            let v219: &'static str = r#"wasm"#;
            let v221: clap::Arg = clap::Arg::new(v219);
            let v223: clap::Arg = v221.short('w');
            let v224: string = string("r#\"wasm\"#");
            let v225: &'static str = r#"wasm"#;
            let v227: clap::Arg = v223.long(v225);
            let v229: clap::Arg = v227.required(true);
            clap::Command::arg(v216, v229)
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
            let v220: Spiral_wasm::US4 =
                defaultValue(Spiral_wasm::US4::US4_1, map(Spiral_wasm::method11(), v5));
            let v360: DateTime = match &v220 {
                Spiral_wasm::US4::US4_0(v220_0_0) => {
                    let v303: TimeSpan = TimeSpan::new_ticks(
                        ({
                            let _arg: DateTime = DateTime::now();
                            _arg.ticks()
                        }) - (match &v220 {
                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                            _ => unreachable!(),
                        }),
                    );
                    DateTime::new_ymdhms_milli(
                        1_i32,
                        1_i32,
                        1_i32,
                        v303.hours(),
                        v303.minutes(),
                        v303.seconds(),
                        v303.milliseconds(),
                    )
                }
                _ => DateTime::now(),
            };
            let v361: string = Spiral_wasm::method12();
            let provider: string = if (v361.clone()) == string("") {
                string("M-d-y hh:mm:ss tt")
            } else {
                v361
            };
            v360.toString(provider)
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
            let v87: &str = inline_colorization::color_reset;
            let v89: std::string::String = format!("{}{}{}", v49, v56, v87);
            fable_library_rust::String_::fromString(v89)
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
            let v198: () = {
                Spiral_wasm::closure8(
                    v12.clone(),
                    fable_library_rust::String_::fromString(v151),
                    (),
                );
                ()
            };
            let v215: () = {
                Spiral_wasm::closure8(v12.clone(), string("; "), ());
                ()
            };
            let v234: () = {
                Spiral_wasm::closure8(v12.clone(), string("contract"), ());
                ()
            };
            let v251: () = {
                Spiral_wasm::closure8(v12.clone(), string(" = "), ());
                ()
            };
            let v263: std::string::String = format!("{:#?}", v10);
            let v310: () = {
                Spiral_wasm::closure8(
                    v12.clone(),
                    fable_library_rust::String_::fromString(v263),
                    (),
                );
                ()
            };
            let v329: () = {
                Spiral_wasm::closure8(v12.clone(), string(" }"), ());
                ()
            };
            let v335: string = v12.l0.get().clone();
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
                (v335),
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
            let v197: () = {
                Spiral_wasm::closure8(
                    v11.clone(),
                    fable_library_rust::String_::fromString(v150),
                    (),
                );
                ()
            };
            let v216: () = {
                Spiral_wasm::closure8(v11.clone(), string(" }"), ());
                ()
            };
            let v222: string = v11.l0.get().clone();
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
                (v222),
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
            let v87: &str = inline_colorization::color_reset;
            let v89: std::string::String = format!("{}{}{}", v49, v56, v87);
            fable_library_rust::String_::fromString(v89)
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
            let v419: () = {
                Spiral_wasm::closure8(
                    v14.clone(),
                    fable_library_rust::String_::fromString(v372),
                    (),
                );
                ()
            };
            let v438: () = {
                Spiral_wasm::closure8(v14.clone(), string(" }"), ());
                ()
            };
            let v444: string = v14.l0.get().clone();
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
                (v444),
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
            let v121: () = {
                Spiral_wasm::closure8(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v74),
                    (),
                );
                ()
            };
            let v140: () = {
                Spiral_wasm::closure8(v10.clone(), string(" }"), ());
                ()
            };
            let v146: string = v10.l0.get().clone();
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
                (v146),
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
            let v197: () = {
                Spiral_wasm::closure8(
                    v11.clone(),
                    fable_library_rust::String_::fromString(v150),
                    (),
                );
                ()
            };
            let v216: () = {
                Spiral_wasm::closure8(v11.clone(), string(" }"), ());
                ()
            };
            let v222: string = v11.l0.get().clone();
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
                (v222),
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
            let v197: () = {
                Spiral_wasm::closure8(
                    v11.clone(),
                    fable_library_rust::String_::fromString(v150),
                    (),
                );
                ()
            };
            let v216: () = {
                Spiral_wasm::closure8(v11.clone(), string(" }"), ());
                ()
            };
            let v222: string = v11.l0.get().clone();
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
                (v222),
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
            let v121: () = {
                Spiral_wasm::closure8(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v74),
                    (),
                );
                ()
            };
            let v140: () = {
                Spiral_wasm::closure8(v10.clone(), string(" }"), ());
                ()
            };
            let v146: string = v10.l0.get().clone();
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
                (v146),
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
            let v121: () = {
                Spiral_wasm::closure8(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v74),
                    (),
                );
                ()
            };
            let v140: () = {
                Spiral_wasm::closure8(v10.clone(), string(" }"), ());
                ()
            };
            let v146: string = v10.l0.get().clone();
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
                (v146),
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
                            let v322: bool = true;
                            v291
                        })
                        .collect::<Vec<_>>();
                    let v324: Vec<std::string::String> = _vec_map;
                    let v327: bool = true;
                    v324.iter().for_each(|x| {
                        Func1::new(move |v: std::string::String| Spiral_wasm::closure16((), v))(
                            x.clone(),
                        );
                    }); //;
                    let v332: () = {
                        Spiral_wasm::closure18((), ());
                        ()
                    };
                    let v336: near_workspaces::types::Gas = v155.clone().total_gas_burnt;
                    let v338: u64 = v336.as_gas();
                    let v408: () = {
                        Spiral_wasm::closure19(
                            v1,
                            v338,
                            ((v338 as f64) / 10000000000000000.0_f64) * 6.68_f64,
                            (),
                        );
                        ()
                    };
                    let v470: near_workspaces::result::ExecutionFinalResult = v155.clone();
                    let v472: Vec<&near_workspaces::result::ExecutionOutcome> = v470.outcomes();
                    let v474 = v472.into_iter();
                    let v476 = v474.cloned();
                    let v479: bool = true;
                    v476.for_each(|x| {
                        Func1::new(move |v_1: near_workspaces::result::ExecutionOutcome| {
                            Spiral_wasm::closure20((), v_1)
                        })(x)
                    });
                    let v544: () = {
                        Spiral_wasm::closure22(v155.clone().into_result(), ());
                        ()
                    };
                    let v605: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method34(v155.clone());
                    let v607: Vec<&near_workspaces::result::ExecutionOutcome> =
                        v605.receipt_failures();
                    let v615: i32 = v607.clone().len() as i32;
                    let v685: () = {
                        Spiral_wasm::closure23(v607.clone(), v615, ());
                        ()
                    };
                    let v746: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method36(v155.clone());
                    let v748: &[near_workspaces::result::ExecutionOutcome] =
                        v746.receipt_outcomes();
                    let v750: Vec<near_workspaces::result::ExecutionOutcome> = v748.into();
                    let v758: i32 = v750.clone().len() as i32;
                    let v828: () = {
                        Spiral_wasm::closure24(v750, v758, ());
                        ()
                    };
                    let v953: () = {
                        Spiral_wasm::closure25(v155.clone().json(), ());
                        ()
                    };
                    let v1078: () = {
                        Spiral_wasm::closure26(v155.borsh(), ());
                        ()
                    };
                    let v1140: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                        l0: MutCell::new(Spiral_wasm::method15()),
                    });
                    let v1154: () = {
                        Spiral_wasm::closure8(v1140.clone(), string("{ "), ());
                        ()
                    };
                    let v1173: () = {
                        Spiral_wasm::closure8(v1140.clone(), string("receipt_outcomes_len"), ());
                        ()
                    };
                    let v1192: () = {
                        Spiral_wasm::closure8(v1140.clone(), string(" = "), ());
                        ()
                    };
                    let v1212: () = {
                        Spiral_wasm::closure8(v1140.clone(), sprintf!("{}", v758), ());
                        ()
                    };
                    let v1231: () = {
                        Spiral_wasm::closure8(v1140.clone(), string("; "), ());
                        ()
                    };
                    let v1250: () = {
                        Spiral_wasm::closure8(v1140.clone(), string("retry"), ());
                        ()
                    };
                    let v1267: () = {
                        Spiral_wasm::closure8(v1140.clone(), string(" = "), ());
                        ()
                    };
                    let v1287: () = {
                        Spiral_wasm::closure8(v1140.clone(), sprintf!("{}", v1), ());
                        ()
                    };
                    let v1304: () = {
                        Spiral_wasm::closure8(v1140.clone(), string("; "), ());
                        ()
                    };
                    let v1323: () = {
                        Spiral_wasm::closure8(v1140.clone(), string("receipt_failures"), ());
                        ()
                    };
                    let v1340: () = {
                        Spiral_wasm::closure8(v1140.clone(), string(" = "), ());
                        ()
                    };
                    let v1352: std::string::String = format!("{:#?}", v607);
                    let v1399: () = {
                        Spiral_wasm::closure8(
                            v1140.clone(),
                            fable_library_rust::String_::fromString(v1352),
                            (),
                        );
                        ()
                    };
                    let v1418: () = {
                        Spiral_wasm::closure8(v1140.clone(), string(" }"), ());
                        ()
                    };
                    let v1424: string = v1140.l0.get().clone();
                    let v1459: Result<Spiral_wasm::US7, anyhow::Error> = if (v615) > 0_i32 {
                        Ok::<Spiral_wasm::US7, anyhow::Error>(Spiral_wasm::US7::US7_0(
                            v1424.clone(),
                        ))
                    } else {
                        if (v758) > 1_i32 {
                            Ok::<Spiral_wasm::US7, anyhow::Error>(Spiral_wasm::US7::US7_1)
                        } else {
                            let v1442: anyhow::Error = anyhow::anyhow!(v1424);
                            Err(v1442)
                        }
                    };
                    let v1462: string = string("}");
                    let v1467: bool = true;
                    let _fix_closure_v1464 = v1459;
                    let v1473: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v1464 "), (v1462))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v1474: bool = true;
                    _fix_closure_v1464
                },
            ); // rust.fix_closure';
            let v1476 = __future_init;
            v1476
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
            let v87: &str = inline_colorization::color_reset;
            let v89: std::string::String = format!("{}{}{}", v49, v56, v87);
            fable_library_rust::String_::fromString(v89)
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
            let v197: () = {
                Spiral_wasm::closure8(
                    v11.clone(),
                    fable_library_rust::String_::fromString(v150),
                    (),
                );
                ()
            };
            let v216: () = {
                Spiral_wasm::closure8(v11.clone(), string(" }"), ());
                ()
            };
            let v222: string = v11.l0.get().clone();
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
                (v222),
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
            let v87: &str = inline_colorization::color_reset;
            let v89: std::string::String = format!("{}{}{}", v49, v56, v87);
            fable_library_rust::String_::fromString(v89)
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
                    let v518: Spiral_wasm::US8 = match &v30 {
                        Spiral_wasm::US9::US9_0(v30_0_0) => {
                            let v33: Spiral_wasm::US7 = v30_0_0.clone();
                            match &v33 {
                                Spiral_wasm::US7::US7_0(v33_0_0) => {
                                    let v64: string = match &v33 {
                                        Spiral_wasm::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone();
                                    let v127: () = {
                                        Spiral_wasm::closure34(v1, v64.clone(), ());
                                        ()
                                    };
                                    let v189: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v191: bool = */
                                        async move {
                                            /*;
                                            let v193: bool = */
                                            ();
                                            let v196: string = string("}");
                                            let v202: bool = true;
                                            let _fix_closure_v199 =
                                                (v1, Spiral_wasm::US7::US7_0(v64));
                                            let v208: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v199 "),
                                                            (v196),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v209: bool = true;
                                            _fix_closure_v199
                                        },
                                    ); // rust.fix_closure';
                                    let v211 = __future_init;
                                    let v213: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<Output = (u8, Spiral_wasm::US7)>,
                                        >,
                                    > = v211;
                                    let patternInput_2: (u8, Spiral_wasm::US7) = v213.await;
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
                                    Spiral_wasm::US8::US8_0(
                                        patternInput_1.0.clone(),
                                        patternInput_1.1.clone(),
                                    )
                                }
                            }
                        }
                        Spiral_wasm::US9::US9_1(v30_1_0) => {
                            let v220: std::string::String = v30_1_0.clone();
                            if (v1) >= 15_u8 {
                                let v284: () = {
                                    Spiral_wasm::closure30(v1, v220.clone(), ());
                                    ()
                                };
                                let v349: () = {
                                    Spiral_wasm::closure31((), ());
                                    ()
                                };
                                let v353: bool = true;
                                let __future_init = Box::pin(
                                    /*;
                                    let v355: bool = */
                                    async move {
                                        /*;
                                        let v357: bool = */
                                        ();
                                        let v360: string = string("}");
                                        let v366: bool = true;
                                        let _fix_closure_v363 = (v1, Spiral_wasm::US7::US7_1);
                                        let v372: string = append(
                                            (append(
                                                (append(
                                                    (append(
                                                        string("true; _fix_closure_v363 "),
                                                        (v360),
                                                    )),
                                                    string("); "),
                                                )),
                                                string(""),
                                            )),
                                            string(" // rust.fix_closure\'"),
                                        );
                                        let v373: bool = true;
                                        _fix_closure_v363
                                    },
                                ); // rust.fix_closure';
                                let v375 = __future_init;
                                let v377: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = (u8, Spiral_wasm::US7)>>,
                                > = v375;
                                let patternInput: (u8, Spiral_wasm::US7) = v377.await;
                                Spiral_wasm::US8::US8_0(
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                )
                            } else {
                                let v444: () = {
                                    Spiral_wasm::closure32(v1, v220, ());
                                    ()
                                };
                                let v509: () = {
                                    Spiral_wasm::closure33((), ());
                                    ()
                                };
                                let v513: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = Spiral_wasm::US8>>,
                                > = Spiral_wasm::method25(v0_1.clone(), (v1) + 1_u8);
                                v513.await
                            }
                        }
                    };
                    let v521: string = string("}");
                    let v526: bool = true;
                    let _fix_closure_v523 = v518;
                    let v532: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v523 "), (v521))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v533: bool = true;
                    _fix_closure_v523
                },
            ); // rust.fix_closure';
            let v535 = __future_init;
            v535
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
                    let v142: () = {
                        Spiral_wasm::closure13(v79.clone(), ());
                        ()
                    };
                    let v204: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v79);
                    let v208: std::pin::Pin<
                        Box<dyn std::future::Future<Output = Spiral_wasm::US8>>,
                    > = Spiral_wasm::method25(v204?, 1_u8);
                    let v210: Spiral_wasm::US8 = v208.await;
                    let v273: () = {
                        Spiral_wasm::closure35(v210.clone(), ());
                        ()
                    };
                    let v536: Result<u8, anyhow::Error> = match &v210 {
                        Spiral_wasm::US8::US8_0(v210_0_0, v210_0_1) => {
                            Ok::<u8, anyhow::Error>(v210_0_0.clone())
                        }
                        Spiral_wasm::US8::US8_1(v210_1_0, v210_1_1) => {
                            let v343: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                                l0: MutCell::new(Spiral_wasm::method15()),
                            });
                            let v357: () = {
                                Spiral_wasm::closure8(v343.clone(), string("{ "), ());
                                ()
                            };
                            let v376: () = {
                                Spiral_wasm::closure8(v343.clone(), string("retries"), ());
                                ()
                            };
                            let v395: () = {
                                Spiral_wasm::closure8(v343.clone(), string(" = "), ());
                                ()
                            };
                            let v416: () = {
                                Spiral_wasm::closure8(
                                    v343.clone(),
                                    sprintf!("{:?}", v210.clone()),
                                    (),
                                );
                                ()
                            };
                            let v435: () = {
                                Spiral_wasm::closure8(v343.clone(), string("; "), ());
                                ()
                            };
                            let v454: () = {
                                Spiral_wasm::closure8(v343.clone(), string("error"), ());
                                ()
                            };
                            let v471: () = {
                                Spiral_wasm::closure8(v343.clone(), string(" = "), ());
                                ()
                            };
                            let v492: () = {
                                Spiral_wasm::closure8(
                                    v343.clone(),
                                    sprintf!("{:?}", v210_1_1.clone()),
                                    (),
                                );
                                ()
                            };
                            let v511: () = {
                                Spiral_wasm::closure8(v343.clone(), string(" }"), ());
                                ()
                            };
                            let v517: string = v343.l0.get().clone();
                            let v519: anyhow::Error = anyhow::anyhow!(v517);
                            Err(v519)
                        }
                    };
                    let v539: string = string("}");
                    let v544: bool = true;
                    let _fix_closure_v541 = v536;
                    let v550: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v541 "), (v539))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v551: bool = true;
                    _fix_closure_v541
                },
            ); // rust.fix_closure';
            let v553 = __future_init;
            v553
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
            let v328: () = {
                Spiral_wasm::closure5(v0_1, ());
                ()
            };
            let v389: string = Spiral_wasm::method20();
            let v396: &str = &*v389;
            let v427: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v396).cloned();
            let v431: Option<string> = map(Spiral_wasm::method21(), v427);
            let v560: Spiral_wasm::US7 =
                defaultValue(Spiral_wasm::US7::US7_1, map(Spiral_wasm::method8(), v431));
            let v564: std::pin::Pin<
                Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>,
            > = Spiral_wasm::method22(v3);
            let v566 = tokio::runtime::Builder::new_multi_thread()
                .enable_all()
                .build()
                .unwrap();
            let v568: Result<u8, anyhow::Error> = v566.handle().block_on(v564);
            let v569 = Spiral_wasm::method40();
            let v582: Result<u8, std::string::String> = v568.map_err(|x| v569(x));
            let v585 = Spiral_wasm::method49();
            let v586 = Spiral_wasm::method50();
            let v588: Spiral_wasm::US10 = match &v582 {
                Err(v582_1_0) => v586(v582_1_0.clone()),
                Ok(v582_0_0) => v585(v582_0_0.clone()),
            };
            match &v588 {
                Spiral_wasm::US10::US10_0(v588_0_0) => {
                    if let Spiral_wasm::US7::US7_0(v560_0_0) = &v560 {
                        let v593: string = sprintf!(
                            "spiral_wasm.main / retries: {} / exception: \'{}\'",
                            v588_0_0.clone(),
                            v560_0_0.clone()
                        );
                        let v597: Result<(), string> = Err(v593);
                        v597.unwrap();
                        ()
                    }
                }
                Spiral_wasm::US10::US10_1(v588_1_0) => {
                    let v613: std::string::String = v588_1_0.clone();
                    if let Spiral_wasm::US7::US7_0(v560_0_0) = &v560 {
                        let v614: string = v560_0_0.clone();
                        if string("") == (v614.clone()) {
                            ()
                        } else {
                            if contains(
                                fable_library_rust::String_::fromString(v613.clone()),
                                v614.clone(),
                            ) {
                                ()
                            } else {
                                let v622: string = sprintf!(
                                    "spiral_wasm.main / exception: \'{}\' / error: {}",
                                    v614,
                                    v613
                                );
                                let v626: Result<(), string> = Err(v622);
                                v626.unwrap();
                                ()
                            }
                        }
                    } else {
                        let v645: u8 = v582.clone().unwrap();
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
