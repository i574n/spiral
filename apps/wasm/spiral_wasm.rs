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
            let v65: string = toLower(string("Critical"));
            let v71: string = toLower(string("Warning"));
            let v77: string = toLower(string("Info"));
            let v83: string = toLower(string("Debug"));
            let v115: Array<string> = toArray(ofArray(new_array(&[
                toLower(string("Verbose")),
                v83,
                v77,
                v71,
                v65,
            ])));
            let v119: Vec<string> = v115.to_vec();
            let v121: bool = true;
            let _vec_map: Vec<_> = v119
                .into_iter()
                .map(|x| {
                    //;
                    let v123: string = x;
                    let v130: &str = &*v123;
                    let v163: std::string::String = String::from(v130);
                    let v191: Box<std::string::String> = Box::new(v163);
                    let v193: &'static mut std::string::String = Box::leak(v191);
                    let v195: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v193);
                    let v197: bool = true;
                    v195
                })
                .collect::<Vec<_>>();
            let v199: Vec<clap::builder::PossibleValue> = _vec_map;
            let v201: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v199),
            );
            let v203: clap::Arg = v61.value_parser(v201);
            let v205: clap::Command = clap::Command::arg(v50, v203);
            let v207: string = string("r#\"wasm\"#");
            let v208: &'static str = r#"wasm"#;
            let v210: clap::Arg = clap::Arg::new(v208);
            let v212: clap::Arg = v210.short('w');
            let v213: string = string("r#\"wasm\"#");
            let v214: &'static str = r#"wasm"#;
            let v216: clap::Arg = v212.long(v214);
            let v218: clap::Arg = v216.required(true);
            clap::Command::arg(v205, v218)
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
            let v5: string = toLower(string("Critical"));
            let v11: string = toLower(string("Warning"));
            let v17: string = toLower(string("Info"));
            let v23: string = toLower(string("Debug"));
            let v29: string = toLower(string("Verbose"));
            let v36: Spiral_wasm::US2 = if string("Verbose") == (v1.clone()) {
                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_0)
            } else {
                Spiral_wasm::US2::US2_1
            };
            (
                match &v36 {
                    Spiral_wasm::US2::US2_0(v36_0_0) => Spiral_wasm::US2::US2_0(
                        match &v36 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    _ => {
                        let v43: Spiral_wasm::US2 = if string("Debug") == (v1.clone()) {
                            Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_1)
                        } else {
                            Spiral_wasm::US2::US2_1
                        };
                        match &v43 {
                            Spiral_wasm::US2::US2_0(v43_0_0) => Spiral_wasm::US2::US2_0(
                                match &v43 {
                                    Spiral_wasm::US2::US2_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => {
                                let v50: Spiral_wasm::US2 = if string("Info") == (v1.clone()) {
                                    Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                } else {
                                    Spiral_wasm::US2::US2_1
                                };
                                match &v50 {
                                    Spiral_wasm::US2::US2_0(v50_0_0) => Spiral_wasm::US2::US2_0(
                                        match &v50 {
                                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => {
                                        let v57: Spiral_wasm::US2 =
                                            if string("Warning") == (v1.clone()) {
                                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                            } else {
                                                Spiral_wasm::US2::US2_1
                                            };
                                        match &v57 {
                                            Spiral_wasm::US2::US2_0(v57_0_0) => {
                                                Spiral_wasm::US2::US2_0(
                                                    match &v57 {
                                                        Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                )
                                            }
                                            _ => {
                                                let v64: Spiral_wasm::US2 = if string("Critical")
                                                    == (v1.clone())
                                                {
                                                    Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_4)
                                                } else {
                                                    Spiral_wasm::US2::US2_1
                                                };
                                                match &v64 {
                                                    Spiral_wasm::US2::US2_0(v64_0_0) => {
                                                        Spiral_wasm::US2::US2_0(
                                                            match &v64 {
                                                                Spiral_wasm::US2::US2_0(x) => {
                                                                    x.clone()
                                                                }
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => {
                                                        let v71: Spiral_wasm::US2 =
                                                            if (v29.clone()) == (v1.clone()) {
                                                                Spiral_wasm::US2::US2_0(
                                                                    Spiral_wasm::US3::US3_0,
                                                                )
                                                            } else {
                                                                Spiral_wasm::US2::US2_1
                                                            };
                                                        match &v71 {
                                                            Spiral_wasm::US2::US2_0(v71_0_0) => {
                                                                Spiral_wasm::US2::US2_0(
                                                                    match &v71 {
                                                                        Spiral_wasm::US2::US2_0(
                                                                            x,
                                                                        ) => x.clone(),
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                )
                                                            }
                                                            _ => {
                                                                let v78: Spiral_wasm::US2 = if (v23
                                                                    .clone())
                                                                    == (v1.clone())
                                                                {
                                                                    Spiral_wasm::US2::US2_0(
                                                                        Spiral_wasm::US3::US3_1,
                                                                    )
                                                                } else {
                                                                    Spiral_wasm::US2::US2_1
                                                                };
                                                                match &v78 {
                                                                 Spiral_wasm::US2::US2_0(v78_0_0)
                                                                 =>
                                                                 Spiral_wasm::US2::US2_0(match &v78
                                                                                             {
                                                                                             Spiral_wasm::US2::US2_0(x)
                                                                                             =>
                                                                                             x.clone(),
                                                                                             _
                                                                                             =>
                                                                                             unreachable!(),
                                                                                         }.clone()),
                                                                 _ => {
                                                                     let v85:
                                                                             Spiral_wasm::US2 =
                                                                         if (v17.clone())
                                                                                ==
                                                                                (v1.clone())
                                                                            {
                                                                             Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                                                         } else {
                                                                             Spiral_wasm::US2::US2_1
                                                                         };
                                                                     match &v85
                                                                         {
                                                                         Spiral_wasm::US2::US2_0(v85_0_0)
                                                                         =>
                                                                         Spiral_wasm::US2::US2_0(match &v85
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
                                                                             let v92:
                                                                                     Spiral_wasm::US2 =
                                                                                 if (v11.clone())
                                                                                        ==
                                                                                        (v1.clone())
                                                                                    {
                                                                                     Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                                                                 } else {
                                                                                     Spiral_wasm::US2::US2_1
                                                                                 };
                                                                             match &v92
                                                                                 {
                                                                                 Spiral_wasm::US2::US2_0(v92_0_0)
                                                                                 =>
                                                                                 Spiral_wasm::US2::US2_0(match &v92
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
                                                                                     let v99:
                                                                                             Spiral_wasm::US2 =
                                                                                         if (v5.clone())
                                                                                                ==
                                                                                                (v1.clone())
                                                                                            {
                                                                                             Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_4)
                                                                                         } else {
                                                                                             Spiral_wasm::US2::US2_1
                                                                                         };
                                                                                     match &v99
                                                                                         {
                                                                                         Spiral_wasm::US2::US2_0(v99_0_0)
                                                                                         =>
                                                                                         Spiral_wasm::US2::US2_0(match &v99
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
            let v186: Spiral_wasm::US4 =
                defaultValue(Spiral_wasm::US4::US4_1, map(Spiral_wasm::method11(), v5));
            let v304: DateTime = match &v186 {
                Spiral_wasm::US4::US4_0(v186_0_0) => {
                    let v256: TimeSpan = TimeSpan::new_ticks(
                        ({
                            let _arg: DateTime = DateTime::now();
                            _arg.ticks()
                        }) - (match &v186 {
                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                            _ => unreachable!(),
                        }),
                    );
                    DateTime::new_ymdhms_milli(
                        1_i32,
                        1_i32,
                        1_i32,
                        v256.hours(),
                        v256.minutes(),
                        v256.seconds(),
                        v256.milliseconds(),
                    )
                }
                _ => DateTime::now(),
            };
            let v306: string = Spiral_wasm::method12();
            let provider: string = if (v306.clone()) == string("") {
                string("M-d-y hh:mm:ss tt")
            } else {
                v306
            };
            v304.toString(provider)
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
            let v7: string = Spiral_wasm::method15(getCharAt(toLower(string("Verbose")), 0_i32));
            let v14: &str = inline_colorization::color_bright_black;
            let v21: &str = &*v7;
            let v49: &str = inline_colorization::color_reset;
            let v51: std::string::String = format!("{}{}{}", v14, v21, v49);
            fable_library_rust::String_::fromString(v51)
        }
        pub fn method19(v0_1: Array<string>) -> string {
            let v2: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v10: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral_wasm::closure8(v2.clone(), string("args"), ());
                ()
            };
            let v30: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral_wasm::closure8(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v53: () = {
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
            let v10: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral_wasm::closure8(v2.clone(), string("wasm_path"), ());
                ()
            };
            let v30: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v39: () = {
                Spiral_wasm::closure8(v2.clone(), v0_1, ());
                ()
            };
            let v49: () = {
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
            let v12: () = {
                Spiral_wasm::closure8(v4.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral_wasm::closure8(v4.clone(), string("retry"), ());
                ()
            };
            let v32: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v41: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v51: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v61: () = {
                Spiral_wasm::closure8(v4.clone(), string("worker"), ());
                ()
            };
            let v70: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v79: std::string::String = format!("{:#?}", v1);
            let v118: () = {
                Spiral_wasm::closure8(v4.clone(), fable_library_rust::String_::fromString(v79), ());
                ()
            };
            let v127: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v137: () = {
                Spiral_wasm::closure8(v4.clone(), string("contract"), ());
                ()
            };
            let v146: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v155: std::string::String = format!("{:#?}", v2);
            let v194: () = {
                Spiral_wasm::closure8(
                    v4.clone(),
                    fable_library_rust::String_::fromString(v155),
                    (),
                );
                ()
            };
            let v204: () = {
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
            let v11: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral_wasm::closure8(v3.clone(), string("retry"), ());
                ()
            };
            let v31: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v50: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral_wasm::closure8(v3.clone(), string("result"), ());
                ()
            };
            let v69: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v78: std::string::String = format!("{:#?}", v1);
            let v117: () = {
                Spiral_wasm::closure8(v3.clone(), fable_library_rust::String_::fromString(v78), ());
                ()
            };
            let v127: () = {
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
            let v7: string = Spiral_wasm::method15(getCharAt(toLower(string("Info")), 0_i32));
            let v14: &str = inline_colorization::color_bright_green;
            let v21: &str = &*v7;
            let v49: &str = inline_colorization::color_reset;
            let v51: std::string::String = format!("{}{}{}", v14, v21, v49);
            fable_library_rust::String_::fromString(v51)
        }
        pub fn method37(v0_1: u8, v1: f64, v2: u64) -> string {
            let v4: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v12: () = {
                Spiral_wasm::closure8(v4.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral_wasm::closure8(v4.clone(), string("retry"), ());
                ()
            };
            let v32: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v41: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v51: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v61: () = {
                Spiral_wasm::closure8(v4.clone(), string("total_gas_burnt_usd"), ());
                ()
            };
            let v70: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v79: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{:+.6}", v1), ());
                ()
            };
            let v88: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v98: () = {
                Spiral_wasm::closure8(v4.clone(), string("total_gas_burnt"), ());
                ()
            };
            let v107: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v116: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v2), ());
                ()
            };
            let v126: () = {
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
            let v14: () = {
                Spiral_wasm::closure8(v6.clone(), string("{ "), ());
                ()
            };
            let v24: () = {
                Spiral_wasm::closure8(v6.clone(), string("is_success"), ());
                ()
            };
            let v34: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v46: () = {
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
            let v56: () = {
                Spiral_wasm::closure8(v6.clone(), string("; "), ());
                ()
            };
            let v66: () = {
                Spiral_wasm::closure8(v6.clone(), string("gas_burnt_usd"), ());
                ()
            };
            let v75: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v84: () = {
                Spiral_wasm::closure8(v6.clone(), sprintf!("{:+.6}", v1), ());
                ()
            };
            let v93: () = {
                Spiral_wasm::closure8(v6.clone(), string("; "), ());
                ()
            };
            let v103: () = {
                Spiral_wasm::closure8(v6.clone(), string("tokens_burnt_usd"), ());
                ()
            };
            let v112: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v121: () = {
                Spiral_wasm::closure8(v6.clone(), sprintf!("{:+.6}", v2), ());
                ()
            };
            let v130: () = {
                Spiral_wasm::closure8(v6.clone(), string("; "), ());
                ()
            };
            let v140: () = {
                Spiral_wasm::closure8(v6.clone(), string("gas_burnt"), ());
                ()
            };
            let v149: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v158: () = {
                Spiral_wasm::closure8(v6.clone(), sprintf!("{}", v3), ());
                ()
            };
            let v167: () = {
                Spiral_wasm::closure8(v6.clone(), string("; "), ());
                ()
            };
            let v177: () = {
                Spiral_wasm::closure8(v6.clone(), string("tokens_burnt"), ());
                ()
            };
            let v186: () = {
                Spiral_wasm::closure8(v6.clone(), string(" = "), ());
                ()
            };
            let v195: std::string::String = format!("{:#?}", v4);
            let v234: () = {
                Spiral_wasm::closure8(
                    v6.clone(),
                    fable_library_rust::String_::fromString(v195),
                    (),
                );
                ()
            };
            let v244: () = {
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
            let v10: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral_wasm::closure8(v2.clone(), string("result2"), ());
                ()
            };
            let v30: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v39: std::string::String = format!("{:#?}", v0_1);
            let v78: () = {
                Spiral_wasm::closure8(v2.clone(), fable_library_rust::String_::fromString(v39), ());
                ()
            };
            let v88: () = {
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
            let v11: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral_wasm::closure8(v3.clone(), string("receipt_failures_len"), ());
                ()
            };
            let v31: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v50: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral_wasm::closure8(v3.clone(), string("receipt_failures"), ());
                ()
            };
            let v69: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v78: std::string::String = format!("{:#?}", v1);
            let v117: () = {
                Spiral_wasm::closure8(v3.clone(), fable_library_rust::String_::fromString(v78), ());
                ()
            };
            let v127: () = {
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
            let v11: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral_wasm::closure8(v3.clone(), string("receipt_outcomes_len"), ());
                ()
            };
            let v31: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v50: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral_wasm::closure8(v3.clone(), string("receipt_outcomes"), ());
                ()
            };
            let v69: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v78: std::string::String = format!("{:#?}", v1);
            let v117: () = {
                Spiral_wasm::closure8(v3.clone(), fable_library_rust::String_::fromString(v78), ());
                ()
            };
            let v127: () = {
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
            let v10: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral_wasm::closure8(v2.clone(), string("json"), ());
                ()
            };
            let v30: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v39: std::string::String = format!("{:#?}", v0_1);
            let v78: () = {
                Spiral_wasm::closure8(v2.clone(), fable_library_rust::String_::fromString(v39), ());
                ()
            };
            let v88: () = {
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
            let v10: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral_wasm::closure8(v2.clone(), string("borsh"), ());
                ()
            };
            let v30: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v39: std::string::String = format!("{:#?}", v0_1);
            let v78: () = {
                Spiral_wasm::closure8(v2.clone(), fable_library_rust::String_::fromString(v39), ());
                ()
            };
            let v88: () = {
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
            let v12: () = {
                Spiral_wasm::closure8(v4.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral_wasm::closure8(v4.clone(), string("receipt_outcomes_len"), ());
                ()
            };
            let v32: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v41: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v51: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v61: () = {
                Spiral_wasm::closure8(v4.clone(), string("retry"), ());
                ()
            };
            let v70: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v79: () = {
                Spiral_wasm::closure8(v4.clone(), sprintf!("{}", v1), ());
                ()
            };
            let v88: () = {
                Spiral_wasm::closure8(v4.clone(), string("; "), ());
                ()
            };
            let v98: () = {
                Spiral_wasm::closure8(v4.clone(), string("receipt_failures"), ());
                ()
            };
            let v107: () = {
                Spiral_wasm::closure8(v4.clone(), string(" = "), ());
                ()
            };
            let v116: std::string::String = format!("{:#?}", v2);
            let v155: () = {
                Spiral_wasm::closure8(
                    v4.clone(),
                    fable_library_rust::String_::fromString(v116),
                    (),
                );
                ()
            };
            let v165: () = {
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
            let v7: string = Spiral_wasm::method15(getCharAt(toLower(string("Warning")), 0_i32));
            let v14: &str = inline_colorization::color_yellow;
            let v21: &str = &*v7;
            let v49: &str = inline_colorization::color_reset;
            let v51: std::string::String = format!("{}{}{}", v14, v21, v49);
            fable_library_rust::String_::fromString(v51)
        }
        pub fn method58(v0_1: u8, v1: std::string::String) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v11: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral_wasm::closure8(v3.clone(), string("retry"), ());
                ()
            };
            let v31: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v50: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral_wasm::closure8(v3.clone(), string("error"), ());
                ()
            };
            let v69: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v78: std::string::String = format!("{:#?}", v1);
            let v117: () = {
                Spiral_wasm::closure8(v3.clone(), fable_library_rust::String_::fromString(v78), ());
                ()
            };
            let v127: () = {
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
            let v7: string = Spiral_wasm::method15(getCharAt(toLower(string("Critical")), 0_i32));
            let v14: &str = inline_colorization::color_bright_red;
            let v21: &str = &*v7;
            let v49: &str = inline_colorization::color_reset;
            let v51: std::string::String = format!("{}{}{}", v14, v21, v49);
            fable_library_rust::String_::fromString(v51)
        }
        pub fn method62(v0_1: u8, v1: string) -> string {
            let v3: LrcPtr<Spiral_wasm::Mut3> = LrcPtr::new(Spiral_wasm::Mut3 {
                l0: MutCell::new(Spiral_wasm::method16()),
            });
            let v11: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral_wasm::closure8(v3.clone(), string("retry"), ());
                ()
            };
            let v31: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v50: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral_wasm::closure8(v3.clone(), string("error"), ());
                ()
            };
            let v69: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v78: () = {
                Spiral_wasm::closure8(v3.clone(), v1, ());
                ()
            };
            let v88: () = {
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
            let v10: () = {
                Spiral_wasm::closure8(v2.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral_wasm::closure8(v2.clone(), string("retries"), ());
                ()
            };
            let v30: () = {
                Spiral_wasm::closure8(v2.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral_wasm::closure8(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v53: () = {
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
            let v11: () = {
                Spiral_wasm::closure8(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral_wasm::closure8(v3.clone(), string("retries"), ());
                ()
            };
            let v31: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v44: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v54: () = {
                Spiral_wasm::closure8(v3.clone(), string("; "), ());
                ()
            };
            let v64: () = {
                Spiral_wasm::closure8(v3.clone(), string("error"), ());
                ()
            };
            let v73: () = {
                Spiral_wasm::closure8(v3.clone(), string(" = "), ());
                ()
            };
            let v86: () = {
                Spiral_wasm::closure8(v3.clone(), sprintf!("{:?}", v1), ());
                ()
            };
            let v96: () = {
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
                    let v61: Spiral_wasm::US0 =
                        defaultValue(Spiral_wasm::US0::US0_1, map(Spiral_wasm::method2(), v42));
                    let v68: std::string::String = match &v61 {
                        Spiral_wasm::US0::US0_0(v61_0_0) => match &v61 {
                            Spiral_wasm::US0::US0_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v70: string = fable_library_rust::String_::fromString(v68);
                    let v73: () = {
                        Spiral_wasm::closure13(v70.clone(), ());
                        ()
                    };
                    let v121: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v70);
                    let v125: std::pin::Pin<
                        Box<dyn std::future::Future<Output = Spiral_wasm::US8>>,
                    > = Spiral_wasm::method28(v121?, 1_u8);
                    let v127: Spiral_wasm::US8 = v125.await;
                    let v130: () = {
                        Spiral_wasm::closure35(v127.clone(), ());
                        ()
                    };
                    let v204: Result<u8, anyhow::Error> = match &v127 {
                        Spiral_wasm::US8::US8_0(v127_0_0, v127_0_1) => {
                            Ok::<u8, anyhow::Error>(v127_0_0.clone())
                        }
                        Spiral_wasm::US8::US8_1(v127_1_0, v127_1_1) => {
                            let v185: string =
                                Spiral_wasm::method65(v127.clone(), v127_1_1.clone());
                            let v187: anyhow::Error = anyhow::anyhow!(v185);
                            Err(v187)
                        }
                    };
                    let v207: string = string("}");
                    let v212: bool = true;
                    let _fix_closure_v209 = v204;
                    let v219: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v209 "), (v207))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v220: bool = true;
                    _fix_closure_v209
                },
            ); // rust.fix_closure';
            let v222 = __future_init;
            v222
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
            let v58: Spiral_wasm::US0 =
                defaultValue(Spiral_wasm::US0::US0_1, map(Spiral_wasm::method2(), v39));
            let v189: Spiral_wasm::US1 = match &v58 {
                Spiral_wasm::US0::US0_0(v58_0_0) => {
                    let v64: string = fable_library_rust::String_::fromString(
                        match &v58 {
                            Spiral_wasm::US0::US0_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    );
                    let v68: string = toLower(string("Critical"));
                    let v74: string = toLower(string("Warning"));
                    let v80: string = toLower(string("Info"));
                    let v86: string = toLower(string("Debug"));
                    let v92: string = toLower(string("Verbose"));
                    let v99: Spiral_wasm::US2 = if string("Verbose") == (v64.clone()) {
                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_0)
                    } else {
                        Spiral_wasm::US2::US2_1
                    };
                    Spiral_wasm::US1::US1_0(match &v99 {
                        Spiral_wasm::US2::US2_0(v99_0_0) => Spiral_wasm::US2::US2_0(
                            match &v99 {
                                Spiral_wasm::US2::US2_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v106: Spiral_wasm::US2 = if string("Debug") == (v64.clone()) {
                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_1)
                            } else {
                                Spiral_wasm::US2::US2_1
                            };
                            match &v106 {
                                Spiral_wasm::US2::US2_0(v106_0_0) => Spiral_wasm::US2::US2_0(
                                    match &v106 {
                                        Spiral_wasm::US2::US2_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v113: Spiral_wasm::US2 = if string("Info") == (v64.clone())
                                    {
                                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                    } else {
                                        Spiral_wasm::US2::US2_1
                                    };
                                    match &v113 {
                                        Spiral_wasm::US2::US2_0(v113_0_0) => {
                                            Spiral_wasm::US2::US2_0(
                                                match &v113 {
                                                    Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            )
                                        }
                                        _ => {
                                            let v120: Spiral_wasm::US2 =
                                                if string("Warning") == (v64.clone()) {
                                                    Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                                } else {
                                                    Spiral_wasm::US2::US2_1
                                                };
                                            match &v120 {
                                                Spiral_wasm::US2::US2_0(v120_0_0) => {
                                                    Spiral_wasm::US2::US2_0(
                                                        match &v120 {
                                                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => {
                                                    let v127: Spiral_wasm::US2 =
                                                        if string("Critical") == (v64.clone()) {
                                                            Spiral_wasm::US2::US2_0(
                                                                Spiral_wasm::US3::US3_4,
                                                            )
                                                        } else {
                                                            Spiral_wasm::US2::US2_1
                                                        };
                                                    match &v127 {
                                                        Spiral_wasm::US2::US2_0(v127_0_0) => {
                                                            Spiral_wasm::US2::US2_0(
                                                                match &v127 {
                                                                    Spiral_wasm::US2::US2_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            let v134: Spiral_wasm::US2 =
                                                                if (v92.clone()) == (v64.clone()) {
                                                                    Spiral_wasm::US2::US2_0(
                                                                        Spiral_wasm::US3::US3_0,
                                                                    )
                                                                } else {
                                                                    Spiral_wasm::US2::US2_1
                                                                };
                                                            match &v134 {
                                                                Spiral_wasm::US2::US2_0(
                                                                    v134_0_0,
                                                                ) => Spiral_wasm::US2::US2_0(
                                                                    match &v134 {
                                                                        Spiral_wasm::US2::US2_0(
                                                                            x,
                                                                        ) => x.clone(),
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                ),
                                                                _ => {
                                                                    let v141: Spiral_wasm::US2 =
                                                                        if (v86.clone())
                                                                            == (v64.clone())
                                                                        {
                                                                            Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_1)
                                                                        } else {
                                                                            Spiral_wasm::US2::US2_1
                                                                        };
                                                                    match &v141
                                                                                                    {
                                                                                                    Spiral_wasm::US2::US2_0(v141_0_0)
                                                                                                    =>
                                                                                                    Spiral_wasm::US2::US2_0(match &v141
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
                                                                                                        let v148:
                                                                                                                Spiral_wasm::US2 =
                                                                                                            if (v80.clone())
                                                                                                                   ==
                                                                                                                   (v64.clone())
                                                                                                               {
                                                                                                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                                                                                            } else {
                                                                                                                Spiral_wasm::US2::US2_1
                                                                                                            };
                                                                                                        match &v148
                                                                                                            {
                                                                                                            Spiral_wasm::US2::US2_0(v148_0_0)
                                                                                                            =>
                                                                                                            Spiral_wasm::US2::US2_0(match &v148
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
                                                                                                                let v155:
                                                                                                                        Spiral_wasm::US2 =
                                                                                                                    if (v74.clone())
                                                                                                                           ==
                                                                                                                           (v64.clone())
                                                                                                                       {
                                                                                                                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
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
                                                                                                                            if (v68.clone())
                                                                                                                                   ==
                                                                                                                                   (v64.clone())
                                                                                                                               {
                                                                                                                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_4)
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
            let v196: Spiral_wasm::US2 = if let Spiral_wasm::US1::US1_0(v189_0_0) = &v189 {
                let v190: Spiral_wasm::US2 = v189_0_0.clone();
                if let Spiral_wasm::US2::US2_0(v190_0_0) = &v190 {
                    Spiral_wasm::US2::US2_0(v190_0_0.clone())
                } else {
                    Spiral_wasm::US2::US2_1
                }
            } else {
                Spiral_wasm::US2::US2_1
            };
            let v203: () = {
                Spiral_wasm::closure2(
                    match &v196 {
                        Spiral_wasm::US2::US2_0(v196_0_0) => match &v196 {
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
            let v242: () = {
                Spiral_wasm::closure5(v0_1, ());
                ()
            };
            let v289: string = Spiral_wasm::method22();
            let v296: &str = &*v289;
            let v324: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v296).cloned();
            let v328: Option<string> = map(Spiral_wasm::method23(), v324);
            let v441: Spiral_wasm::US7 =
                defaultValue(Spiral_wasm::US7::US7_1, map(Spiral_wasm::method8(), v328));
            let v445: std::pin::Pin<
                Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>,
            > = Spiral_wasm::method24(v3);
            let v447 = tokio::runtime::Builder::new_multi_thread()
                .enable_all()
                .build()
                .unwrap();
            let v449: Result<u8, anyhow::Error> = v447.handle().block_on(v445);
            let v450 = Spiral_wasm::method53();
            let v463: Result<u8, std::string::String> = v449.map_err(|x| v450(x));
            let v466 = Spiral_wasm::method66();
            let v467 = Spiral_wasm::method67();
            let v469: Spiral_wasm::US10 = match &v463 {
                Err(v463_1_0) => v467(v463_1_0.clone()),
                Ok(v463_0_0) => v466(v463_0_0.clone()),
            };
            match &v469 {
                Spiral_wasm::US10::US10_0(v469_0_0) => {
                    if let Spiral_wasm::US7::US7_0(v441_0_0) = &v441 {
                        let v474: string = sprintf!(
                            "spiral_wasm.main / retries: {} / exception: \'{}\'",
                            v469_0_0.clone(),
                            v441_0_0.clone()
                        );
                        let v478: Result<(), string> = Err(v474);
                        v478.unwrap();
                        ()
                    }
                }
                Spiral_wasm::US10::US10_1(v469_1_0) => {
                    let v494: std::string::String = v469_1_0.clone();
                    if let Spiral_wasm::US7::US7_0(v441_0_0) = &v441 {
                        let v495: string = v441_0_0.clone();
                        if string("") == (v495.clone()) {
                            ()
                        } else {
                            if contains(
                                fable_library_rust::String_::fromString(v494.clone()),
                                v495.clone(),
                            ) {
                                ()
                            } else {
                                let v503: string = sprintf!(
                                    "spiral_wasm.main / exception: \'{}\' / error: {}",
                                    v495,
                                    v494
                                );
                                let v507: Result<(), string> = Err(v503);
                                v507.unwrap();
                                ()
                            }
                        }
                    } else {
                        let v526: u8 = v463.clone().unwrap();
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
