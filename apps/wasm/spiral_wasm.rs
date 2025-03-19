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
        use fable_library_rust::NativeArray_::new_array;
        use fable_library_rust::NativeArray_::Array;
        use fable_library_rust::Native_::Any;
        use fable_library_rust::Native_::Func1;
        use fable_library_rust::Native_::LrcPtr;
        use fable_library_rust::Native_::MutCell;
        use fable_library_rust::Native_::OnceInit;
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
            let v6: string = Spiral_wasm::method6(v0_1);
            let v8: Result<std::string::String, std::env::VarError> = std::env::var(&*v6);
            let v10: bool = true;
            let _result_map_ = v8.map(|x| {
                //;
                let v12: std::string::String = x;
                let v14: string = fable_library_rust::String_::fromString(v12);
                let v16: bool = true;
                v14
            });
            let v18: Result<string, std::env::VarError> = _result_map_;
            let v19: string = Spiral_wasm::method7();
            v18.unwrap_or(v19)
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
            let v3: () = {
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
            let v42: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
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
                    v42,
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
            let v198: Spiral_wasm::US4 =
                defaultValue(Spiral_wasm::US4::US4_1, map(Spiral_wasm::method11(), v5));
            let v316: DateTime = match &v198 {
                Spiral_wasm::US4::US4_0(v198_0_0) => {
                    let v268: TimeSpan = TimeSpan::new_ticks(
                        ({
                            let _arg: DateTime = DateTime::now();
                            _arg.ticks()
                        }) - (match &v198 {
                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                            _ => unreachable!(),
                        }),
                    );
                    DateTime::new_ymdhms_milli(
                        1_i32,
                        1_i32,
                        1_i32,
                        v268.hours(),
                        v268.minutes(),
                        v268.seconds(),
                        v268.milliseconds(),
                    )
                }
                _ => DateTime::now(),
            };
            let v318: string = Spiral_wasm::method12();
            let provider: string = if (v318.clone()) == string("") {
                string("M-d-y hh:mm:ss tt")
            } else {
                v318
            };
            v316.toString(provider)
        }
        pub fn method16() -> string {
            string("")
        }
        pub fn closure8(v0_1: LrcPtr<Spiral_wasm::Mut3>, v1: string, unitVar: ()) {
            let v3: string = append((v0_1.l0.get().clone()), (v1));
            v0_1.l0.set(v3);
            ()
        }
        pub fn method15(v0_1: char) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v9: () = {
                Spiral_wasm::closure8(v2.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method17() -> string {
            string("\u{001b}[0m")
        }
        pub fn method14() -> string {
            let v8: string = Spiral_wasm::method15(getCharAt(toLower(string("Verbose")), 0_i32));
            let v15: &str = inline_colorization::color_bright_black;
            let v22: &str = &*v8;
            let v50: &str = inline_colorization::color_reset;
            let v52: std::string::String = format!("{}{}{}", v15, v22, v50);
            fable_library_rust::String_::fromString(v52)
        }
        pub fn method19(v0_1: Array<string>) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v11: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral_wasm::closure8(v2.clone(), string("args"), ());
                ()
            };
            let v33: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v46: () = {
                Spiral_wasm::closure8(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v57: () = {
                Spiral_wasm::closure8(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method20(v0_1: string) -> string {
            trimEndChars(
                trimStartChars(v0_1, toArray(empty::<char>())),
                toArray(ofArray(new_array(&[' ', '/']))),
            )
        }
        pub fn method18(
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
            let v9: string = Spiral_wasm::method19(v8);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral_wasm.main"),
                v9
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
            let v3: () = {
                Spiral_wasm::closure11(v0_1, ());
                ()
            };
            ()
        }
        pub fn method21(v0_1: string) {
            let v3: () = {
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
            let v44: () = {
                Spiral_wasm::closure9(patternInput.0.clone(), ());
                ()
            };
            println!("{}", v0_1.clone());
            ((patternInput.1.clone()).l0.get().clone())(v0_1)
        }
        pub fn closure5(v0_1: Array<string>, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v5: () = {
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
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method18(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral_wasm::method10(v26, v27, v28, v29, v30, v31),
                    Spiral_wasm::method14(),
                    v0_1,
                ))
            };
        }
        pub fn method22() -> string {
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
        pub fn method23() -> Func1<std::string::String, string> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure12((), v))
        }
        pub fn method25() -> string {
            string("wasm")
        }
        pub fn method27(v0_1: string) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v11: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral_wasm::closure8(v2.clone(), string("wasm_path"), ());
                ()
            };
            let v33: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v42: () = {
                Spiral_wasm::closure8(v2.clone(), v0_1, ());
                ()
            };
            let v53: () = {
                Spiral_wasm::closure8(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method26(
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
            let v9: string = Spiral_wasm::method27(v8);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral_wasm.run"),
                v9
            ))
        }
        pub fn closure13(v0_1: string, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v5: () = {
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
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method26(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral_wasm::method10(v26, v27, v28, v29, v30, v31),
                    Spiral_wasm::method14(),
                    v0_1,
                ))
            };
        }
        pub fn method31(
            v0_1: u8,
            v1: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v2: near_workspaces::Contract,
        ) -> string {
            let v4: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v13: () = {
                Spiral_wasm::closure8(v4.clone(), string("{ "), ());
                ()
            };
            let v24: () = {
                Spiral_wasm::closure8(v4.clone(), string("retry"), ());
                ()
            };
            let v35: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v44: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v55: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v66: () = {
                Spiral_wasm::closure8(v4.clone(), string("worker"), ());
                ()
            };
            let v75: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v84: std::string::String = format!("{:#?}", v1);
            let v123: () = {
                Spiral_wasm::closure8(v4.clone(), fable_library_rust::String_::fromString(v84), ());
                ()
            };
            let v132: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v143: () = {
                Spiral_wasm::closure8(v4.clone(), string("contract"), ());
                ()
            };
            let v152: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v161: std::string::String = format!("{:#?}", v2);
            let v200: () = {
                Spiral_wasm::closure8(
                    v4.clone(),
                    fable_library_rust::String_::fromString(v161),
                    (),
                );
                ()
            };
            let v211: () = {
                Spiral_wasm::closure8(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
        }
        pub fn method30(
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
            let v11: string = Spiral_wasm::method31(v8, v9, v10);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral_wasm.run"),
                v11
            ))
        }
        pub fn closure14(
            v0_1: u8,
            v1: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v2: near_workspaces::Contract,
            unitVar: (),
        ) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v7: () = {
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
                let v33: Option<i64> = patternInput.5.clone();
                let v32: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v31: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v30: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v29: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v28: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method30(
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    Spiral_wasm::method10(v28, v29, v30, v31, v32, v33),
                    Spiral_wasm::method14(),
                    v0_1,
                    v1,
                    v2,
                ))
            };
        }
        pub fn method33(v0_1: u8, v1: near_workspaces::result::ExecutionFinalResult) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v12: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral_wasm::closure8(v3.clone(), string("retry"), ());
                ()
            };
            let v34: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v54: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral_wasm::closure8(v3.clone(), string("result"), ());
                ()
            };
            let v74: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v83: std::string::String = format!("{:#?}", v1);
            let v122: () = {
                Spiral_wasm::closure8(v3.clone(), fable_library_rust::String_::fromString(v83), ());
                ()
            };
            let v133: () = {
                Spiral_wasm::closure8(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
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
            v9: near_workspaces::result::ExecutionFinalResult,
        ) -> string {
            let v10: string = Spiral_wasm::method33(v8, v9);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral_wasm.run"),
                v10
            ))
        }
        pub fn closure15(v0_1: u8, v1: near_workspaces::result::ExecutionFinalResult, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v6: () = {
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
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method32(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral_wasm::method10(v27, v28, v29, v30, v31, v32),
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
            let v3: () = {
                Spiral_wasm::closure17(v0_1, ());
                ()
            };
            ()
        }
        pub fn method34() {
            let v2: () = {
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
            let v43: () = {
                Spiral_wasm::closure9(patternInput.0.clone(), ());
                ()
            };
            println!("{}", string(" "));
            ((patternInput.1.clone()).l0.get().clone())(string(" "))
        }
        pub fn closure18(unitVar: (), unitVar_1: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_2) {
                Spiral_wasm::method34();
            };
        }
        pub fn method35() -> string {
            let v8: string = Spiral_wasm::method15(getCharAt(toLower(string("Info")), 0_i32));
            let v15: &str = inline_colorization::color_bright_green;
            let v22: &str = &*v8;
            let v50: &str = inline_colorization::color_reset;
            let v52: std::string::String = format!("{}{}{}", v15, v22, v50);
            fable_library_rust::String_::fromString(v52)
        }
        pub fn method37(v0_1: u8, v1: f64, v2: u64) -> string {
            let v4: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v13: () = {
                Spiral_wasm::closure8(v4.clone(), string("{ "), ());
                ()
            };
            let v24: () = {
                Spiral_wasm::closure8(v4.clone(), string("retry"), ());
                ()
            };
            let v35: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v44: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v55: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v66: () = {
                Spiral_wasm::closure8(v4.clone(), string("total_gas_burnt_usd"), ());
                ()
            };
            let v75: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v84: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{:+.6}", v1), ());
                ()
            };
            let v93: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v104: () = {
                Spiral_wasm::closure8(v4.clone(), string("total_gas_burnt"), ());
                ()
            };
            let v113: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v122: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v2), ());
                ()
            };
            let v133: () = {
                Spiral_wasm::closure8(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
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
            v8: u8,
            v9: f64,
            v10: u64,
        ) -> string {
            let v11: string = Spiral_wasm::method37(v8, v9, v10);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("near_workspaces.print_usd"),
                v11
            ))
        }
        pub fn closure19(v0_1: u8, v1: u64, v2: f64, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_2) {
                let v7: () = {
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
                let v33: Option<i64> = patternInput.5.clone();
                let v32: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v31: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v30: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v29: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v28: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method36(
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    Spiral_wasm::method10(v28, v29, v30, v31, v32, v33),
                    Spiral_wasm::method35(),
                    v0_1,
                    v2,
                    v1,
                ))
            };
        }
        pub fn method39(v0_1: bool, v1: f64, v2: f64, v3: u64, v4: u128) -> string {
            let v6: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v15: () = {
                Spiral_wasm::closure8(v6.clone(), string("{ "), ());
                ()
            };
            let v26: () = {
                Spiral_wasm::closure8(v6.clone(), string("is_success"), ());
                ()
            };
            let v37: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v49: () = {
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
            let v60: () = {
                Spiral_wasm::closure8(v6.clone(), string("; "), ());
                ()
            };
            let v71: () = {
                Spiral_wasm::closure8(v6.clone(), string("gas_burnt_usd"), ());
                ()
            };
            let v80: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v89: () = {
                Spiral_wasm::closure8(v6.clone(), sprintf!("{:+.6}", v1), ());
                ()
            };
            let v98: () = {
                Spiral_wasm::closure8(v6.clone(), string("; "), ());
                ()
            };
            let v109: () = {
                Spiral_wasm::closure8(v6.clone(), string("tokens_burnt_usd"), ());
                ()
            };
            let v118: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v127: () = {
                Spiral_wasm::closure8(v6.clone(), sprintf!("{:+.6}", v2), ());
                ()
            };
            let v136: () = {
                Spiral_wasm::closure8(v6.clone(), string("; "), ());
                ()
            };
            let v147: () = {
                Spiral_wasm::closure8(v6.clone(), string("gas_burnt"), ());
                ()
            };
            let v156: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v165: () = {
                Spiral_wasm::closure8(v6.clone(), sprintf!("{}", v3), ());
                ()
            };
            let v174: () = {
                Spiral_wasm::closure8(v6.clone(), string("; "), ());
                ()
            };
            let v185: () = {
                Spiral_wasm::closure8(v6.clone(), string("tokens_burnt"), ());
                ()
            };
            let v194: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v203: std::string::String = format!("{:#?}", v4);
            let v242: () = {
                Spiral_wasm::closure8(
                    v6.clone(),
                    fable_library_rust::String_::fromString(v203),
                    (),
                );
                ()
            };
            let v253: () = {
                Spiral_wasm::closure8(v6.clone(), string(" }"), ());
                ()
            };
            v6.l0.get().clone()
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
            v8: bool,
            v9: f64,
            v10: f64,
            v11: u64,
            v12: u128,
        ) -> string {
            let v13: string = Spiral_wasm::method39(v8, v9, v10, v11, v12);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("near_workspaces.print_usd / outcome"),
                v13
            ))
        }
        pub fn closure21(v0_1: bool, v1: u64, v2: f64, v3: u128, v4: f64, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_2) {
                let v9: () = {
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
                let v35: Option<i64> = patternInput.5.clone();
                let v34: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v33: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v32: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v31: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v30: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method38(
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    v35.clone(),
                    Spiral_wasm::method10(v30, v31, v32, v33, v34, v35),
                    Spiral_wasm::method35(),
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
            let v24: () = {
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
        pub fn method41(
            v0_1: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
        ) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v11: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral_wasm::closure8(v2.clone(), string("result2"), ());
                ()
            };
            let v33: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v42: std::string::String = format!("{:#?}", v0_1);
            let v81: () = {
                Spiral_wasm::closure8(v2.clone(), fable_library_rust::String_::fromString(v42), ());
                ()
            };
            let v92: () = {
                Spiral_wasm::closure8(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
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
            v8: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
        ) -> string {
            let v9: string = Spiral_wasm::method41(v8);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral_wasm.run"),
                v9
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
                let v5: () = {
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
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method40(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral_wasm::method10(v26, v27, v28, v29, v30, v31),
                    Spiral_wasm::method14(),
                    v0_1,
                ))
            };
        }
        pub fn method42(
            v0_1: near_workspaces::result::ExecutionFinalResult,
        ) -> near_workspaces::result::ExecutionFinalResult {
            v0_1
        }
        pub fn method44(v0_1: i32, v1: Vec<&near_workspaces::result::ExecutionOutcome>) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v12: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral_wasm::closure8(v3.clone(), string("receipt_failures_len"), ());
                ()
            };
            let v34: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v54: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral_wasm::closure8(v3.clone(), string("receipt_failures"), ());
                ()
            };
            let v74: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v83: std::string::String = format!("{:#?}", v1);
            let v122: () = {
                Spiral_wasm::closure8(v3.clone(), fable_library_rust::String_::fromString(v83), ());
                ()
            };
            let v133: () = {
                Spiral_wasm::closure8(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method43(
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
            let v10: string = Spiral_wasm::method44(v8, v9);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral_wasm.run"),
                v10
            ))
        }
        pub fn closure23(
            v0_1: Vec<&near_workspaces::result::ExecutionOutcome>,
            v1: i32,
            unitVar: (),
        ) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v6: () = {
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
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method43(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral_wasm::method10(v27, v28, v29, v30, v31, v32),
                    Spiral_wasm::method14(),
                    v1,
                    v0_1,
                ))
            };
        }
        pub fn method45(
            v0_1: near_workspaces::result::ExecutionFinalResult,
        ) -> near_workspaces::result::ExecutionFinalResult {
            v0_1
        }
        pub fn method47(v0_1: i32, v1: Vec<near_workspaces::result::ExecutionOutcome>) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v12: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral_wasm::closure8(v3.clone(), string("receipt_outcomes_len"), ());
                ()
            };
            let v34: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v54: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral_wasm::closure8(v3.clone(), string("receipt_outcomes"), ());
                ()
            };
            let v74: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v83: std::string::String = format!("{:#?}", v1);
            let v122: () = {
                Spiral_wasm::closure8(v3.clone(), fable_library_rust::String_::fromString(v83), ());
                ()
            };
            let v133: () = {
                Spiral_wasm::closure8(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
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
            v8: i32,
            v9: Vec<near_workspaces::result::ExecutionOutcome>,
        ) -> string {
            let v10: string = Spiral_wasm::method47(v8, v9);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral_wasm.run"),
                v10
            ))
        }
        pub fn closure24(
            v0_1: Vec<near_workspaces::result::ExecutionOutcome>,
            v1: i32,
            unitVar: (),
        ) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v6: () = {
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
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method46(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral_wasm::method10(v27, v28, v29, v30, v31, v32),
                    Spiral_wasm::method14(),
                    v1,
                    v0_1,
                ))
            };
        }
        pub fn method49(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v11: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral_wasm::closure8(v2.clone(), string("json"), ());
                ()
            };
            let v33: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v42: std::string::String = format!("{:#?}", v0_1);
            let v81: () = {
                Spiral_wasm::closure8(v2.clone(), fable_library_rust::String_::fromString(v42), ());
                ()
            };
            let v92: () = {
                Spiral_wasm::closure8(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
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
            v8: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v9: string = Spiral_wasm::method49(v8);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral_wasm.run"),
                v9
            ))
        }
        pub fn closure25(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v5: () = {
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
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method48(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral_wasm::method10(v26, v27, v28, v29, v30, v31),
                    Spiral_wasm::method14(),
                    v0_1,
                ))
            };
        }
        pub fn method51(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v11: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral_wasm::closure8(v2.clone(), string("borsh"), ());
                ()
            };
            let v33: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v42: std::string::String = format!("{:#?}", v0_1);
            let v81: () = {
                Spiral_wasm::closure8(v2.clone(), fable_library_rust::String_::fromString(v42), ());
                ()
            };
            let v92: () = {
                Spiral_wasm::closure8(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
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
            v8: Result<std::string::String, near_workspaces::error::Error>,
        ) -> string {
            let v9: string = Spiral_wasm::method51(v8);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral_wasm.run"),
                v9
            ))
        }
        pub fn closure26(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v5: () = {
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
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method50(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral_wasm::method10(v26, v27, v28, v29, v30, v31),
                    Spiral_wasm::method14(),
                    v0_1,
                ))
            };
        }
        pub fn method52(
            v0_1: i32,
            v1: u8,
            v2: Vec<&near_workspaces::result::ExecutionOutcome>,
        ) -> string {
            let v4: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v13: () = {
                Spiral_wasm::closure8(v4.clone(), string("{ "), ());
                ()
            };
            let v24: () = {
                Spiral_wasm::closure8(v4.clone(), string("receipt_outcomes_len"), ());
                ()
            };
            let v35: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v44: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v55: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v66: () = {
                Spiral_wasm::closure8(v4.clone(), string("retry"), ());
                ()
            };
            let v75: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v84: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v1), ());
                ()
            };
            let v93: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v104: () = {
                Spiral_wasm::closure8(v4.clone(), string("receipt_failures"), ());
                ()
            };
            let v113: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v122: std::string::String = format!("{:#?}", v2);
            let v161: () = {
                Spiral_wasm::closure8(
                    v4.clone(),
                    fable_library_rust::String_::fromString(v122),
                    (),
                );
                ()
            };
            let v172: () = {
                Spiral_wasm::closure8(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
        }
        pub fn method29(
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
                    let v22: () = {
                        Spiral_wasm::closure14(v1, v11, v19.clone(), ());
                        ()
                    };
                    let v71: near_workspaces::operations::CallTransaction =
                        v19.call(&*string("state_main"));
                    let v73: near_workspaces::types::Gas =
                        near_workspaces::types::Gas::from_tgas(300);
                    let v75: near_workspaces::operations::CallTransaction = v71.gas(v73);
                    let v77: std::pin::Pin<
                        Box<
                            dyn std::future::Future<
                                Output = Result<
                                    near_workspaces::result::ExecutionFinalResult,
                                    near_workspaces::error::Error,
                                >,
                            >,
                        >,
                    > = Box::pin(v75.transact());
                    let v79: Result<
                        near_workspaces::result::ExecutionFinalResult,
                        near_workspaces::error::Error,
                    > = v77.await;
                    let v81: near_workspaces::result::ExecutionFinalResult = v79?;
                    let v84: () = {
                        Spiral_wasm::closure15(v1, v81.clone(), ());
                        ()
                    };
                    let v132: Vec<&str> = v81.logs();
                    let v134: bool = true;
                    let _vec_map: Vec<_> = v132
                        .into_iter()
                        .map(|x| {
                            //;
                            let v136: &str = x;
                            let v143: std::string::String = String::from(v136);
                            let v171: bool = true;
                            v143
                        })
                        .collect::<Vec<_>>();
                    let v173: Vec<std::string::String> = _vec_map;
                    let v176: bool = true;
                    v173.iter().for_each(|x| {
                        Func1::new(move |v: std::string::String| Spiral_wasm::closure16((), v))(
                            x.clone(),
                        );
                    }); //;
                    let v179: () = {
                        Spiral_wasm::closure18((), ());
                        ()
                    };
                    let v183: near_workspaces::types::Gas = v81.clone().total_gas_burnt;
                    let v185: u64 = v183.as_gas();
                    let v195: () = {
                        Spiral_wasm::closure19(
                            v1,
                            v185,
                            ((v185 as f64) / 10000000000000000.0_f64) * 6.68_f64,
                            (),
                        );
                        ()
                    };
                    let v243: near_workspaces::result::ExecutionFinalResult = v81.clone();
                    let v245: Vec<&near_workspaces::result::ExecutionOutcome> = v243.outcomes();
                    let v247 = v245.into_iter();
                    let v249 = v247.cloned();
                    let v252: bool = true;
                    v249.for_each(|x| {
                        Func1::new(move |v_1: near_workspaces::result::ExecutionOutcome| {
                            Spiral_wasm::closure20((), v_1)
                        })(x)
                    });
                    let v257: () = {
                        Spiral_wasm::closure22(v81.clone().into_result(), ());
                        ()
                    };
                    let v304: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method42(v81.clone());
                    let v306: Vec<&near_workspaces::result::ExecutionOutcome> =
                        v304.receipt_failures();
                    let v314: i32 = v306.clone().len() as i32;
                    let v324: () = {
                        Spiral_wasm::closure23(v306.clone(), v314, ());
                        ()
                    };
                    let v371: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method45(v81.clone());
                    let v373: &[near_workspaces::result::ExecutionOutcome] =
                        v371.receipt_outcomes();
                    let v375: Vec<near_workspaces::result::ExecutionOutcome> = v373.into();
                    let v383: i32 = v375.clone().len() as i32;
                    let v393: () = {
                        Spiral_wasm::closure24(v375, v383, ());
                        ()
                    };
                    let v444: () = {
                        Spiral_wasm::closure25(v81.clone().json(), ());
                        ()
                    };
                    let v495: () = {
                        Spiral_wasm::closure26(v81.borsh(), ());
                        ()
                    };
                    let v542: string = Spiral_wasm::method52(v383, v1, v306);
                    let v577: Result<Spiral_wasm::US7, anyhow::Error> = if (v314) > 0_i32 {
                        Ok::<Spiral_wasm::US7, anyhow::Error>(Spiral_wasm::US7::US7_0(v542.clone()))
                    } else {
                        if (v383) > 1_i32 {
                            Ok::<Spiral_wasm::US7, anyhow::Error>(Spiral_wasm::US7::US7_1)
                        } else {
                            let v560: anyhow::Error = anyhow::anyhow!(v542);
                            Err(v560)
                        }
                    };
                    let v580: string = string("}");
                    let v585: bool = true;
                    let _fix_closure_v582 = v577;
                    let v592: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v582 "), (v580))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v593: bool = true;
                    _fix_closure_v582
                },
            ); // rust.fix_closure';
            let v595 = __future_init;
            v595
        }
        pub fn closure27(unitVar: (), v0_1: anyhow::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method53() -> Func1<anyhow::Error, std::string::String> {
            Func1::new(move |v: anyhow::Error| Spiral_wasm::closure27((), v))
        }
        pub fn closure28(unitVar: (), v0_1: Spiral_wasm::US7) -> Spiral_wasm::US9 {
            Spiral_wasm::US9::US9_0(v0_1)
        }
        pub fn method54() -> Func1<Spiral_wasm::US7, Spiral_wasm::US9> {
            Func1::new(move |v: Spiral_wasm::US7| Spiral_wasm::closure28((), v))
        }
        pub fn closure29(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US9 {
            Spiral_wasm::US9::US9_1(v0_1)
        }
        pub fn method55() -> Func1<std::string::String, Spiral_wasm::US9> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure29((), v))
        }
        pub fn method56() -> string {
            let v8: string = Spiral_wasm::method15(getCharAt(toLower(string("Warning")), 0_i32));
            let v15: &str = inline_colorization::color_yellow;
            let v22: &str = &*v8;
            let v50: &str = inline_colorization::color_reset;
            let v52: std::string::String = format!("{}{}{}", v15, v22, v50);
            fable_library_rust::String_::fromString(v52)
        }
        pub fn method58(v0_1: u8, v1: std::string::String) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v12: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral_wasm::closure8(v3.clone(), string("retry"), ());
                ()
            };
            let v34: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v54: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral_wasm::closure8(v3.clone(), string("error"), ());
                ()
            };
            let v74: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v83: std::string::String = format!("{:#?}", v1);
            let v122: () = {
                Spiral_wasm::closure8(v3.clone(), fable_library_rust::String_::fromString(v83), ());
                ()
            };
            let v133: () = {
                Spiral_wasm::closure8(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method57(
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
            let v10: string = Spiral_wasm::method58(v8, v9);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral_wasm.run / Error error"),
                v10
            ))
        }
        pub fn closure30(v0_1: u8, v1: std::string::String, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_3) {
                let v6: () = {
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
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method57(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral_wasm::method10(v27, v28, v29, v30, v31, v32),
                    Spiral_wasm::method56(),
                    v0_1,
                    v1,
                ))
            };
        }
        pub fn method59() {
            let v2: () = {
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
            let v43: () = {
                Spiral_wasm::closure9(patternInput.0.clone(), ());
                ()
            };
            println!("{}", string("\n"));
            ((patternInput.1.clone()).l0.get().clone())(string("\n"))
        }
        pub fn closure31(unitVar: (), unitVar_1: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_3) {
                Spiral_wasm::method59();
            };
        }
        pub fn closure32(v0_1: u8, v1: std::string::String, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_3) {
                let v6: () = {
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
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method57(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral_wasm::method10(v27, v28, v29, v30, v31, v32),
                    Spiral_wasm::method56(),
                    v0_1,
                    v1,
                ))
            };
        }
        pub fn closure33(unitVar: (), unitVar_1: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_3) {
                Spiral_wasm::method59();
            };
        }
        pub fn method60() -> string {
            let v8: string = Spiral_wasm::method15(getCharAt(toLower(string("Critical")), 0_i32));
            let v15: &str = inline_colorization::color_bright_red;
            let v22: &str = &*v8;
            let v50: &str = inline_colorization::color_reset;
            let v52: std::string::String = format!("{}{}{}", v15, v22, v50);
            fable_library_rust::String_::fromString(v52)
        }
        pub fn method62(v0_1: u8, v1: string) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v12: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral_wasm::closure8(v3.clone(), string("retry"), ());
                ()
            };
            let v34: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v54: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral_wasm::closure8(v3.clone(), string("error"), ());
                ()
            };
            let v74: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral_wasm::closure8(v3.clone(), v1, ());
                ()
            };
            let v94: () = {
                Spiral_wasm::closure8(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
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
            v8: u8,
            v9: string,
        ) -> string {
            let v10: string = Spiral_wasm::method62(v8, v9);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral_wasm.run / Ok (Some error)"),
                v10
            ))
        }
        pub fn closure34(v0_1: u8, v1: string, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_4) {
                let v6: () = {
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
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method61(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral_wasm::method10(v27, v28, v29, v30, v31, v32),
                    Spiral_wasm::method60(),
                    v0_1,
                    v1,
                ))
            };
        }
        pub fn method28(
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
                    > = Spiral_wasm::method29(v0_1.clone(), v1);
                    let v10: Result<Spiral_wasm::US7, anyhow::Error> = v8.await;
                    let v11 = Spiral_wasm::method53();
                    let v24: Result<Spiral_wasm::US7, std::string::String> =
                        v10.map_err(|x| v11(x));
                    let v27 = Spiral_wasm::method54();
                    let v28 = Spiral_wasm::method55();
                    let v30: Spiral_wasm::US9 = match &v24 {
                        Err(v24_1_0) => v28(v24_1_0.clone()),
                        Ok(v24_0_0) => v27(v24_0_0.clone()),
                    };
                    let v295: Spiral_wasm::US8 = match &v30 {
                        Spiral_wasm::US9::US9_0(v30_0_0) => {
                            let v33: Spiral_wasm::US7 = v30_0_0.clone();
                            match &v33 {
                                Spiral_wasm::US7::US7_0(v33_0_0) => {
                                    let v65: string = match &v33 {
                                        Spiral_wasm::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone();
                                    let v68: () = {
                                        Spiral_wasm::closure34(v1, v65.clone(), ());
                                        ()
                                    };
                                    let v116: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v118: bool = */
                                        async move {
                                            /*;
                                            let v120: bool = */
                                            ();
                                            let v123: string = string("}");
                                            let v129: bool = true;
                                            let _fix_closure_v126 =
                                                (v1, Spiral_wasm::US7::US7_0(v65));
                                            let v136: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v126 "),
                                                            (v123),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v137: bool = true;
                                            _fix_closure_v126
                                        },
                                    ); // rust.fix_closure';
                                    let v139 = __future_init;
                                    let v141: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<
                                                Output = (u8, Spiral_wasm::US7),
                                            >,
                                        >,
                                    > = v139;
                                    let patternInput_2: (u8, Spiral_wasm::US7) = v141.await;
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
                                            dyn std::future::Future<
                                                Output = (u8, Spiral_wasm::US7),
                                            >,
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
                            let v148: std::string::String = v30_1_0.clone();
                            if (v1) >= 15_u8 {
                                let v152: () = {
                                    Spiral_wasm::closure30(v1, v148.clone(), ());
                                    ()
                                };
                                let v201: () = {
                                    Spiral_wasm::closure31((), ());
                                    ()
                                };
                                let v205: bool = true;
                                let __future_init = Box::pin(
                                    /*;
                                    let v207: bool = */
                                    async move {
                                        /*;
                                        let v209: bool = */
                                        ();
                                        let v212: string = string("}");
                                        let v218: bool = true;
                                        let _fix_closure_v215 = (v1, Spiral_wasm::US7::US7_1);
                                        let v225: string = append(
                                            (append(
                                                (append(
                                                    (append(
                                                        string("true; _fix_closure_v215 "),
                                                        (v212),
                                                    )),
                                                    string("); "),
                                                )),
                                                string(""),
                                            )),
                                            string(" // rust.fix_closure\'"),
                                        );
                                        let v226: bool = true;
                                        _fix_closure_v215
                                    },
                                ); // rust.fix_closure';
                                let v228 = __future_init;
                                let v230: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = (u8, Spiral_wasm::US7)>>,
                                > = v228;
                                let patternInput: (u8, Spiral_wasm::US7) = v230.await;
                                Spiral_wasm::US8::US8_0(
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                )
                            } else {
                                let v237: () = {
                                    Spiral_wasm::closure32(v1, v148, ());
                                    ()
                                };
                                let v286: () = {
                                    Spiral_wasm::closure33((), ());
                                    ()
                                };
                                let v290: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = Spiral_wasm::US8>>,
                                > = Spiral_wasm::method28(v0_1.clone(), (v1) + 1_u8);
                                v290.await
                            }
                        }
                    };
                    let v298: string = string("}");
                    let v303: bool = true;
                    let _fix_closure_v300 = v295;
                    let v310: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v300 "), (v298))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v311: bool = true;
                    _fix_closure_v300
                },
            ); // rust.fix_closure';
            let v313 = __future_init;
            v313
        }
        pub fn method64(v0_1: Spiral_wasm::US8) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v11: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral_wasm::closure8(v2.clone(), string("retries"), ());
                ()
            };
            let v33: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v46: () = {
                Spiral_wasm::closure8(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v57: () = {
                Spiral_wasm::closure8(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
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
            v8: Spiral_wasm::US8,
        ) -> string {
            let v9: string = Spiral_wasm::method64(v8);
            Spiral_wasm::method20(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral_wasm.run"),
                v9
            ))
        }
        pub fn closure35(v0_1: Spiral_wasm::US8, unitVar: ()) {
            if Spiral_wasm::method9(Spiral_wasm::US3::US3_0) {
                let v5: () = {
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
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral_wasm::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral_wasm::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral_wasm::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral_wasm::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral_wasm::Mut0> = patternInput.0.clone();
                Spiral_wasm::method21(Spiral_wasm::method63(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral_wasm::method10(v26, v27, v28, v29, v30, v31),
                    Spiral_wasm::method14(),
                    v0_1,
                ))
            };
        }
        pub fn method65(v0_1: Spiral_wasm::US8, v1: Spiral_wasm::US7) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v12: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral_wasm::closure8(v3.clone(), string("retries"), ());
                ()
            };
            let v34: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v47: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v58: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v69: () = {
                Spiral_wasm::closure8(v3.clone(), string("error"), ());
                ()
            };
            let v78: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v91: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{:?}", v1), ());
                ()
            };
            let v102: () = {
                Spiral_wasm::closure8(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method24(
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
                    let v7: string = Spiral_wasm::method25();
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
                    let v79: () = {
                        Spiral_wasm::closure13(v76.clone(), ());
                        ()
                    };
                    let v127: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v76);
                    let v131: std::pin::Pin<
                        Box<dyn std::future::Future<Output = Spiral_wasm::US8>>,
                    > = Spiral_wasm::method28(v127?, 1_u8);
                    let v133: Spiral_wasm::US8 = v131.await;
                    let v136: () = {
                        Spiral_wasm::closure35(v133.clone(), ());
                        ()
                    };
                    let v210: Result<u8, anyhow::Error> = match &v133 {
                        Spiral_wasm::US8::US8_0(v133_0_0, v133_0_1) => {
                            Ok::<u8, anyhow::Error>(v133_0_0.clone())
                        }
                        Spiral_wasm::US8::US8_1(v133_1_0, v133_1_1) => {
                            let v191: string =
                                Spiral_wasm::method65(v133.clone(), v133_1_1.clone());
                            let v193: anyhow::Error = anyhow::anyhow!(v191);
                            Err(v193)
                        }
                    };
                    let v213: string = string("}");
                    let v218: bool = true;
                    let _fix_closure_v215 = v210;
                    let v225: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v215 "), (v213))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v226: bool = true;
                    _fix_closure_v215
                },
            ); // rust.fix_closure';
            let v228 = __future_init;
            v228
        }
        pub fn closure36(unitVar: (), v0_1: u8) -> Spiral_wasm::US10 {
            Spiral_wasm::US10::US10_0(v0_1)
        }
        pub fn method66() -> Func1<u8, Spiral_wasm::US10> {
            Func1::new(move |v: u8| Spiral_wasm::closure36((), v))
        }
        pub fn closure37(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US10 {
            Spiral_wasm::US10::US10_1(v0_1)
        }
        pub fn method67() -> Func1<std::string::String, Spiral_wasm::US10> {
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
            let v214: () = {
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
            let v253: () = {
                Spiral_wasm::closure5(v0_1, ());
                ()
            };
            let v300: string = Spiral_wasm::method22();
            let v307: &str = &*v300;
            let v335: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v307).cloned();
            let v339: Option<string> = map(Spiral_wasm::method23(), v335);
            let v468: Spiral_wasm::US7 =
                defaultValue(Spiral_wasm::US7::US7_1, map(Spiral_wasm::method8(), v339));
            let v472: std::pin::Pin<
                Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>,
            > = Spiral_wasm::method24(v3);
            let v474 = tokio::runtime::Builder::new_multi_thread()
                .enable_all()
                .build()
                .unwrap();
            let v476: Result<u8, anyhow::Error> = v474.handle().block_on(v472);
            let v477 = Spiral_wasm::method53();
            let v490: Result<u8, std::string::String> = v476.map_err(|x| v477(x));
            let v493 = Spiral_wasm::method66();
            let v494 = Spiral_wasm::method67();
            let v496: Spiral_wasm::US10 = match &v490 {
                Err(v490_1_0) => v494(v490_1_0.clone()),
                Ok(v490_0_0) => v493(v490_0_0.clone()),
            };
            match &v496 {
                Spiral_wasm::US10::US10_0(v496_0_0) => {
                    if let Spiral_wasm::US7::US7_0(v468_0_0) = &v468 {
                        let v501: string = sprintf!(
                            "spiral_wasm.main / retries: {} / exception: \'{}\'",
                            v496_0_0.clone(),
                            v468_0_0.clone()
                        );
                        let v505: Result<(), string> = Err(v501);
                        v505.unwrap();
                        ()
                    }
                }
                Spiral_wasm::US10::US10_1(v496_1_0) => {
                    let v521: std::string::String = v496_1_0.clone();
                    if let Spiral_wasm::US7::US7_0(v468_0_0) = &v468 {
                        let v522: string = v468_0_0.clone();
                        if string("") == (v522.clone()) {
                            ()
                        } else {
                            if contains(
                                fable_library_rust::String_::fromString(v521.clone()),
                                v522.clone(),
                            ) {
                                ()
                            } else {
                                let v530: string = sprintf!(
                                    "spiral_wasm.main / exception: \'{}\' / error: {}",
                                    v522,
                                    v521
                                );
                                let v534: Result<(), string> = Err(v530);
                                v534.unwrap();
                                ()
                            }
                        }
                    } else {
                        let v553: u8 = v490.clone().unwrap();
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
