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
        use fable_library_rust::List_::ofArray;
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
        use fable_library_rust::String_::getSlice;
        use fable_library_rust::String_::length;
        use fable_library_rust::String_::printfn;
        use fable_library_rust::String_::sprintf;
        use fable_library_rust::String_::string;
        use fable_library_rust::String_::toLower;
        use fable_library_rust::String_::toString;
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
            US9_0(char),
            US9_1,
        }
        impl core::fmt::Display for US9 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US10 {
            US10_0(u8, Spiral_wasm::US7),
            US10_1(u8, Spiral_wasm::US7),
        }
        impl core::fmt::Display for US10 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US11 {
            US11_0(Spiral_wasm::US7),
            US11_1(std::string::String),
        }
        impl core::fmt::Display for US11 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US12 {
            US12_0(u8),
            US12_1(std::string::String),
        }
        impl core::fmt::Display for US12 {
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
            let v19: usize = 1_i32 as usize;
            let v56: clap::builder::ValueRange = if (v19) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v8..)
            } else {
                let v54: string = string("clap::builder::ValueRange::new($0..=$1)");
                clap::builder::ValueRange::new(v8..=v19)
            };
            let v58: string = string("r#\"exception\"#");
            let v59: &'static str = r#"exception"#;
            let v61: clap::Arg = clap::Arg::new(v59);
            let v63: clap::Arg = v61.short('e');
            let v64: string = string("r#\"exception\"#");
            let v65: &'static str = r#"exception"#;
            let v67: clap::Arg = v63.long(v65);
            let v69: clap::Arg = v67.num_args(v56);
            let v71: clap::Arg = v69.require_equals(true);
            let v73: string = string("r#\"\"#");
            let v74: &str = r#""#;
            let v76: clap::Arg = v71.default_missing_value(v74);
            let v78: clap::Command = clap::Command::arg(v6, v76);
            let v80: string = string("r#\"trace_level\"#");
            let v81: &'static str = r#"trace_level"#;
            let v83: clap::Arg = clap::Arg::new(v81);
            let v85: clap::Arg = v83.short('t');
            let v86: string = string("r#\"trace_level\"#");
            let v87: &'static str = r#"trace_level"#;
            let v89: clap::Arg = v85.long(v87);
            let v94: string = toLower(string("Critical"));
            let v108: string = toLower(string("Warning"));
            let v122: string = toLower(string("Info"));
            let v136: string = toLower(string("Debug"));
            let v233: Array<string> = toArray(ofArray(new_array(&[
                toLower(string("Verbose")),
                v136,
                v122,
                v108,
                v94,
            ])));
            let v244: Vec<string> = v233.to_vec();
            let v246: bool = true;
            let _vec_map: Vec<_> = v244
                .into_iter()
                .map(|x| {
                    //;
                    let v248: string = x;
                    let v262: &str = &*v248;
                    let v347: std::string::String = String::from(v262);
                    let v420: Box<std::string::String> = Box::new(v347);
                    let v422: &'static mut std::string::String = Box::leak(v420);
                    let v424: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v422);
                    let v426: bool = true;
                    v424
                })
                .collect::<Vec<_>>();
            let v428: Vec<clap::builder::PossibleValue> = _vec_map;
            let v430: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v428),
            );
            let v432: clap::Arg = v89.value_parser(v430);
            let v434: clap::Command = clap::Command::arg(v78, v432);
            let v436: string = string("r#\"wasm\"#");
            let v437: &'static str = r#"wasm"#;
            let v439: clap::Arg = clap::Arg::new(v437);
            let v441: clap::Arg = v439.short('w');
            let v442: string = string("r#\"wasm\"#");
            let v443: &'static str = r#"wasm"#;
            let v445: clap::Arg = v441.long(v443);
            let v447: clap::Arg = v445.required(true);
            clap::Command::arg(v434, v447)
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
        pub fn method4() -> (Spiral_wasm::US2, Spiral_wasm::US4) {
            let v1: string = Spiral_wasm::method5(string("TRACE_LEVEL"));
            let v6: string = toLower(string("Critical"));
            let v20: string = toLower(string("Warning"));
            let v34: string = toLower(string("Info"));
            let v48: string = toLower(string("Debug"));
            let v62: string = toLower(string("Verbose"));
            let v76: Spiral_wasm::US2 = if string("Verbose") == (v1.clone()) {
                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_0)
            } else {
                Spiral_wasm::US2::US2_1
            };
            (
                match &v76 {
                    Spiral_wasm::US2::US2_0(v76_0_0) => Spiral_wasm::US2::US2_0(
                        match &v76 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    _ => {
                        let v83: Spiral_wasm::US2 = if string("Debug") == (v1.clone()) {
                            Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_1)
                        } else {
                            Spiral_wasm::US2::US2_1
                        };
                        match &v83 {
                            Spiral_wasm::US2::US2_0(v83_0_0) => Spiral_wasm::US2::US2_0(
                                match &v83 {
                                    Spiral_wasm::US2::US2_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => {
                                let v90: Spiral_wasm::US2 = if string("Info") == (v1.clone()) {
                                    Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                } else {
                                    Spiral_wasm::US2::US2_1
                                };
                                match &v90 {
                                    Spiral_wasm::US2::US2_0(v90_0_0) => Spiral_wasm::US2::US2_0(
                                        match &v90 {
                                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => {
                                        let v97: Spiral_wasm::US2 =
                                            if string("Warning") == (v1.clone()) {
                                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                            } else {
                                                Spiral_wasm::US2::US2_1
                                            };
                                        match &v97 {
                                            Spiral_wasm::US2::US2_0(v97_0_0) => {
                                                Spiral_wasm::US2::US2_0(
                                                    match &v97 {
                                                        Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                )
                                            }
                                            _ => {
                                                let v104: Spiral_wasm::US2 = if string("Critical")
                                                    == (v1.clone())
                                                {
                                                    Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_4)
                                                } else {
                                                    Spiral_wasm::US2::US2_1
                                                };
                                                match &v104 {
                                                    Spiral_wasm::US2::US2_0(v104_0_0) => {
                                                        Spiral_wasm::US2::US2_0(
                                                            match &v104 {
                                                                Spiral_wasm::US2::US2_0(x) => {
                                                                    x.clone()
                                                                }
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => {
                                                        let v111: Spiral_wasm::US2 =
                                                            if (v62.clone()) == (v1.clone()) {
                                                                Spiral_wasm::US2::US2_0(
                                                                    Spiral_wasm::US3::US3_0,
                                                                )
                                                            } else {
                                                                Spiral_wasm::US2::US2_1
                                                            };
                                                        match &v111 {
                                                            Spiral_wasm::US2::US2_0(v111_0_0) => {
                                                                Spiral_wasm::US2::US2_0(
                                                                    match &v111 {
                                                                        Spiral_wasm::US2::US2_0(
                                                                            x,
                                                                        ) => x.clone(),
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                )
                                                            }
                                                            _ => {
                                                                let v118: Spiral_wasm::US2 =
                                                                    if (v48.clone()) == (v1.clone())
                                                                    {
                                                                        Spiral_wasm::US2::US2_0(
                                                                            Spiral_wasm::US3::US3_1,
                                                                        )
                                                                    } else {
                                                                        Spiral_wasm::US2::US2_1
                                                                    };
                                                                match &v118 {
                                                                 Spiral_wasm::US2::US2_0(v118_0_0)
                                                                 =>
                                                                 Spiral_wasm::US2::US2_0(match &v118
                                                                                             {
                                                                                             Spiral_wasm::US2::US2_0(x)
                                                                                             =>
                                                                                             x.clone(),
                                                                                             _
                                                                                             =>
                                                                                             unreachable!(),
                                                                                         }.clone()),
                                                                 _ => {
                                                                     let v125:
                                                                             Spiral_wasm::US2 =
                                                                         if (v34.clone())
                                                                                ==
                                                                                (v1.clone())
                                                                            {
                                                                             Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                                                         } else {
                                                                             Spiral_wasm::US2::US2_1
                                                                         };
                                                                     match &v125
                                                                         {
                                                                         Spiral_wasm::US2::US2_0(v125_0_0)
                                                                         =>
                                                                         Spiral_wasm::US2::US2_0(match &v125
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
                                                                             let v132:
                                                                                     Spiral_wasm::US2 =
                                                                                 if (v20.clone())
                                                                                        ==
                                                                                        (v1.clone())
                                                                                    {
                                                                                     Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                                                                 } else {
                                                                                     Spiral_wasm::US2::US2_1
                                                                                 };
                                                                             match &v132
                                                                                 {
                                                                                 Spiral_wasm::US2::US2_0(v132_0_0)
                                                                                 =>
                                                                                 Spiral_wasm::US2::US2_0(match &v132
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
                                                                                     let v139:
                                                                                             Spiral_wasm::US2 =
                                                                                         if (v6.clone())
                                                                                                ==
                                                                                                (v1.clone())
                                                                                            {
                                                                                             Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_4)
                                                                                         } else {
                                                                                             Spiral_wasm::US2::US2_1
                                                                                         };
                                                                                     match &v139
                                                                                         {
                                                                                         Spiral_wasm::US2::US2_0(v139_0_0)
                                                                                         =>
                                                                                         Spiral_wasm::US2::US2_0(match &v139
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
            let v395: Spiral_wasm::US4 = _run_target_args__v3.1.clone();
            let v394: Spiral_wasm::US2 = _run_target_args__v3.0.clone();
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
                    l0: MutCell::new(match &v394 {
                        Spiral_wasm::US2::US2_0(v394_0_0) => match &v394 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => v0_1.clone(),
                    }),
                }),
                match &v395 {
                    Spiral_wasm::US4::US4_0(v395_0_0) => Some(match &v395 {
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
            let v495: Spiral_wasm::US4 =
                defaultValue(Spiral_wasm::US4::US4_1, map(Spiral_wasm::method10(), v5));
            let v831: DateTime = match &v495 {
                Spiral_wasm::US4::US4_0(v495_0_0) => {
                    let v668: TimeSpan = TimeSpan::new_ticks(
                        ({
                            let _arg: DateTime = DateTime::now();
                            _arg.ticks()
                        }) - (match &v495 {
                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                            _ => unreachable!(),
                        }),
                    );
                    DateTime::new_ymdhms_milli(
                        1_i32,
                        1_i32,
                        1_i32,
                        v668.hours(),
                        v668.minutes(),
                        v668.seconds(),
                        v668.milliseconds(),
                    )
                }
                _ => DateTime::now(),
            };
            let v832: string = Spiral_wasm::method11();
            let provider: string = if (v832.clone()) == string("") {
                string("M-d-y hh:mm:ss tt")
            } else {
                v832
            };
            v831.toString(provider)
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
                    let v19: Spiral_wasm::US9 = if (v1.get().clone()) == 0_i64 {
                        Spiral_wasm::US9::US9_0(' ')
                    } else {
                        let v5: i64 = (v1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral_wasm::US9::US9_0('\t')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            if (v8) == 0_i64 {
                                Spiral_wasm::US9::US9_0('\r')
                            } else {
                                let v11: i64 = (v8) - 1_i64;
                                if (v11) == 0_i64 {
                                    Spiral_wasm::US9::US9_0('\n')
                                } else {
                                    let v14: i64 = (v11) - 1_i64;
                                    Spiral_wasm::US9::US9_1
                                }
                            }
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v19 {
                            Spiral_wasm::US9::US9_0(v19_0_0) => match &v19 {
                                Spiral_wasm::US9::US9_0(x) => x.clone(),
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
                    let v11: Spiral_wasm::US9 = if (v1.get().clone()) == 0_i64 {
                        Spiral_wasm::US9::US9_0(' ')
                    } else {
                        let v5: i64 = (v1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral_wasm::US9::US9_0('/')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            Spiral_wasm::US9::US9_1
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v11 {
                            Spiral_wasm::US9::US9_0(v11_0_0) => match &v11 {
                                Spiral_wasm::US9::US9_0(x) => x.clone(),
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
            let v537: string = getSlice(
                v0_1.clone(),
                Some(Spiral_wasm::method24(v0_1, v1, 0_i32)),
                Some(v1),
            );
            getSlice(
                v537.clone(),
                Some(0_i32),
                Some(Spiral_wasm::method26(v537.clone(), length(v537))),
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
        pub fn closure8(v0_1: LrcPtr<Spiral_wasm::Mut0>, unitVar: ()) {
            let v2: i64 = (v0_1.l0.get().clone()) + 1_i64;
            v0_1.l0.set(v2);
            ()
        }
        pub fn closure10(v0_1: string, unitVar: ()) {
            printfn!("{0}", v0_1);
        }
        pub fn closure9(unitVar: (), v0_1: string) {
            let v22: () = {
                Spiral_wasm::closure10(v0_1, ());
                ()
            };
            ()
        }
        pub fn closure5(v0_1: Array<string>, unitVar: ()) {
            fn v31() {
                Spiral_wasm::closure6((), ());
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
            let v110: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v556: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v110,
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
                    Spiral_wasm::closure8(v297.clone(), ());
                    ()
                };
                println!("{}", v228.clone());
                (v298.l0.get().clone())(v228);
                Spiral_wasm::US8::US8_0(
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
                    let v7: Spiral_wasm::US9 = if (v1.get().clone()) == 0_i64 {
                        Spiral_wasm::US9::US9_0('\\')
                    } else {
                        let v5: i64 = (v1.get().clone()) - 1_i64;
                        Spiral_wasm::US9::US9_1
                    };
                    if (v0_1.get().clone())
                        == (match &v7 {
                            Spiral_wasm::US9::US9_0(v7_0_0) => match &v7 {
                                Spiral_wasm::US9::US9_0(x) => x.clone(),
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
        pub fn closure11(unitVar: (), v0_1: std::string::String) -> string {
            let v2: string = fable_library_rust::String_::fromString(v0_1);
            let v3: i32 = length(v2.clone());
            let v539: string = getSlice(
                v2.clone(),
                Some(Spiral_wasm::method30(v2, v3, 0_i32)),
                Some(v3),
            );
            getSlice(
                v539.clone(),
                Some(0_i32),
                Some(Spiral_wasm::method32(v539.clone(), length(v539))),
            )
        }
        pub fn method29() -> Func1<std::string::String, string> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure11((), v))
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
        pub fn closure12(v0_1: string, unitVar: ()) {
            fn v31() {
                Spiral_wasm::closure6((), ());
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
            let v110: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v556: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v110,
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
                    Spiral_wasm::closure8(v297.clone(), ());
                    ()
                };
                println!("{}", v228.clone());
                (v298.l0.get().clone())(v228);
                Spiral_wasm::US8::US8_0(
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
        pub fn closure13(
            v0_1: u8,
            v1: near_workspaces::Worker<near_workspaces::network::Sandbox>,
            v2: near_workspaces::Contract,
            unitVar: (),
        ) {
            fn v33() {
                Spiral_wasm::closure6((), ());
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
            let v112: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v558: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v112,
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
                    Spiral_wasm::closure8(v299.clone(), ());
                    ()
                };
                println!("{}", v230.clone());
                (v300.l0.get().clone())(v230);
                Spiral_wasm::US8::US8_0(
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
        pub fn closure14(v0_1: u8, v1: near_workspaces::result::ExecutionFinalResult, unitVar: ()) {
            fn v32() {
                Spiral_wasm::closure6((), ());
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
            let v111: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v557: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v111,
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
                    Spiral_wasm::closure8(v298.clone(), ());
                    ()
                };
                println!("{}", v229.clone());
                (v299.l0.get().clone())(v229);
                Spiral_wasm::US8::US8_0(
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
        pub fn closure16(v0_1: std::string::String, unitVar: ()) {
            printfn!("{0}", v0_1);
        }
        pub fn closure15(unitVar: (), v0_1: std::string::String) {
            let v22: () = {
                Spiral_wasm::closure16(v0_1, ());
                ()
            };
            ()
        }
        pub fn closure17(unitVar: (), unitVar_1: ()) {
            fn v30() {
                Spiral_wasm::closure6((), ());
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
            let v109: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v445: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                2_i32
                    >= (find(
                        v109,
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
                    Spiral_wasm::closure8(v185.clone(), ());
                    ()
                };
                println!("{}", string(" "));
                (v186.l0.get().clone())(string(" "));
                Spiral_wasm::US8::US8_0(
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
        pub fn closure18(v0_1: u8, v1: u64, v2: f64, unitVar: ()) {
            fn v33() {
                Spiral_wasm::closure6((), ());
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
            let v112: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v558: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                2_i32
                    >= (find(
                        v112,
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
                    Spiral_wasm::closure8(v299.clone(), ());
                    ()
                };
                println!("{}", v230.clone());
                (v300.l0.get().clone())(v230);
                Spiral_wasm::US8::US8_0(
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
        pub fn closure20(v0_1: bool, v1: u64, v2: f64, v3: u128, v4: f64, unitVar: ()) {
            fn v35() {
                Spiral_wasm::closure6((), ());
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
            let v114: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v560: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                2_i32
                    >= (find(
                        v114,
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
                    Spiral_wasm::closure8(v301.clone(), ());
                    ()
                };
                println!("{}", v232.clone());
                (v302.l0.get().clone())(v232);
                Spiral_wasm::US8::US8_0(
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
        pub fn closure19(unitVar: (), v0_1: near_workspaces::result::ExecutionOutcome) {
            let v2: bool = v0_1.clone().is_success();
            let v4: near_workspaces::types::Gas = v0_1.clone().gas_burnt;
            let v6: u64 = v4.as_gas();
            let v20: f64 = ((v6 as f64) / 10000000000000000.0_f64) * 6.68_f64;
            let v22: near_workspaces::types::NearToken = v0_1.tokens_burnt;
            let v24: u128 = v22.as_yoctonear();
            let v623: () = {
                Spiral_wasm::closure20(
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
        pub fn closure21(
            v0_1: Result<
                near_workspaces::result::ExecutionSuccess,
                near_workspaces::result::ExecutionFailure,
            >,
            unitVar: (),
        ) {
            fn v31() {
                Spiral_wasm::closure6((), ());
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
            let v110: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v556: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v110,
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
                    Spiral_wasm::closure8(v297.clone(), ());
                    ()
                };
                println!("{}", v228.clone());
                (v298.l0.get().clone())(v228);
                Spiral_wasm::US8::US8_0(
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
        pub fn closure22(
            v0_1: Vec<&near_workspaces::result::ExecutionOutcome>,
            v1: i32,
            unitVar: (),
        ) {
            fn v32() {
                Spiral_wasm::closure6((), ());
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
            let v111: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v557: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v111,
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
                    Spiral_wasm::closure8(v298.clone(), ());
                    ()
                };
                println!("{}", v229.clone());
                (v299.l0.get().clone())(v229);
                Spiral_wasm::US8::US8_0(
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
        pub fn closure23(
            v0_1: Vec<near_workspaces::result::ExecutionOutcome>,
            v1: i32,
            unitVar: (),
        ) {
            fn v32() {
                Spiral_wasm::closure6((), ());
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
            let v111: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v557: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v111,
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
                    Spiral_wasm::closure8(v298.clone(), ());
                    ()
                };
                println!("{}", v229.clone());
                (v299.l0.get().clone())(v229);
                Spiral_wasm::US8::US8_0(
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
        pub fn closure24(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            fn v31() {
                Spiral_wasm::closure6((), ());
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
            let v110: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v556: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v110,
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
                    Spiral_wasm::closure8(v297.clone(), ());
                    ()
                };
                println!("{}", v228.clone());
                (v298.l0.get().clone())(v228);
                Spiral_wasm::US8::US8_0(
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
        pub fn closure25(
            v0_1: Result<std::string::String, near_workspaces::error::Error>,
            unitVar: (),
        ) {
            fn v31() {
                Spiral_wasm::closure6((), ());
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
            let v110: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v556: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v110,
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
                    Spiral_wasm::closure8(v297.clone(), ());
                    ()
                };
                println!("{}", v228.clone());
                (v298.l0.get().clone())(v228);
                Spiral_wasm::US8::US8_0(
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
                    let v614: () = {
                        Spiral_wasm::closure13(v1, v11, v19.clone(), ());
                        ()
                    };
                    let v1216: near_workspaces::operations::CallTransaction =
                        v19.call(&*string("state_main"));
                    let v1218: near_workspaces::types::Gas =
                        near_workspaces::types::Gas::from_tgas(300);
                    let v1220: near_workspaces::operations::CallTransaction = v1216.gas(v1218);
                    let v1222: std::pin::Pin<
                        Box<
                            dyn std::future::Future<
                                    Output = Result<
                                        near_workspaces::result::ExecutionFinalResult,
                                        near_workspaces::error::Error,
                                    >,
                                >,
                        >,
                    > = Box::pin(v1220.transact());
                    let v1224: Result<
                        near_workspaces::result::ExecutionFinalResult,
                        near_workspaces::error::Error,
                    > = v1222.await;
                    let v1226: near_workspaces::result::ExecutionFinalResult = v1224?;
                    let v1821: () = {
                        Spiral_wasm::closure14(v1, v1226.clone(), ());
                        ()
                    };
                    let v2422: Vec<&str> = v1226.logs();
                    let v2424: bool = true;
                    let _vec_map: Vec<_> = v2422
                        .into_iter()
                        .map(|x| {
                            //;
                            let v2426: &str = x;
                            let v2440: std::string::String = String::from(v2426);
                            let v2513: bool = true;
                            v2440
                        })
                        .collect::<Vec<_>>();
                    let v2515: Vec<std::string::String> = _vec_map;
                    let v2518: bool = true;
                    v2515.iter().for_each(|x| {
                        Func1::new(move |v: std::string::String| Spiral_wasm::closure15((), v))(
                            x.clone(),
                        );
                    }); //;
                    let v3004: () = {
                        Spiral_wasm::closure17((), ());
                        ()
                    };
                    let v3495: near_workspaces::types::Gas = v1226.clone().total_gas_burnt;
                    let v3497: u64 = v3495.as_gas();
                    let v4106: () = {
                        Spiral_wasm::closure18(
                            v1,
                            v3497,
                            ((v3497 as f64) / 10000000000000000.0_f64) * 6.68_f64,
                            (),
                        );
                        ()
                    };
                    let v4707: near_workspaces::result::ExecutionFinalResult = v1226.clone();
                    let v4709: Vec<&near_workspaces::result::ExecutionOutcome> = v4707.outcomes();
                    let v4711 = v4709.into_iter();
                    let v4713 = v4711.cloned();
                    let v4716: bool = true;
                    v4713.for_each(|x| {
                        Func1::new(move |v_1: near_workspaces::result::ExecutionOutcome| {
                            Spiral_wasm::closure19((), v_1)
                        })(x)
                    });
                    let v5313: () = {
                        Spiral_wasm::closure21(v1226.clone().into_result(), ());
                        ()
                    };
                    let v5913: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method64(v1226.clone());
                    let v5915: Vec<&near_workspaces::result::ExecutionOutcome> =
                        v5913.receipt_failures();
                    let v5930: i32 = v5915.clone().len() as i32;
                    let v6553: () = {
                        Spiral_wasm::closure22(v5915.clone(), v5930, ());
                        ()
                    };
                    let v7153: near_workspaces::result::ExecutionFinalResult =
                        Spiral_wasm::method69(v1226.clone());
                    let v7155: &[near_workspaces::result::ExecutionOutcome] =
                        v7153.receipt_outcomes();
                    let v7157: Vec<near_workspaces::result::ExecutionOutcome> = v7155.into();
                    let v7172: i32 = v7157.clone().len() as i32;
                    let v7795: () = {
                        Spiral_wasm::closure23(v7157, v7172, ());
                        ()
                    };
                    let v8991: () = {
                        Spiral_wasm::closure24(v1226.clone().json(), ());
                        ()
                    };
                    let v10187: () = {
                        Spiral_wasm::closure25(v1226.borsh(), ());
                        ()
                    };
                    let v10787: string = Spiral_wasm::method80(v7172, v1, v5915);
                    let v10836: Result<Spiral_wasm::US7, anyhow::Error> = if (v5930) > 0_i32 {
                        Ok::<Spiral_wasm::US7, anyhow::Error>(Spiral_wasm::US7::US7_0(
                            v10787.clone(),
                        ))
                    } else {
                        if (v7172) > 1_i32 {
                            Ok::<Spiral_wasm::US7, anyhow::Error>(Spiral_wasm::US7::US7_1)
                        } else {
                            let v10819: anyhow::Error = anyhow::anyhow!(v10787);
                            Err(v10819)
                        }
                    };
                    let v10839: string = string("}");
                    let v10844: bool = true;
                    let _fix_closure_v10841 = v10836;
                    let v10850: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v10841 "), (v10839))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v10851: bool = true;
                    _fix_closure_v10841
                },
            ); // rust.fix_closure';
            let v10853 = __future_init;
            v10853
        }
        pub fn closure26(unitVar: (), v0_1: anyhow::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method81() -> Func1<anyhow::Error, std::string::String> {
            Func1::new(move |v: anyhow::Error| Spiral_wasm::closure26((), v))
        }
        pub fn closure27(unitVar: (), v0_1: Spiral_wasm::US7) -> Spiral_wasm::US11 {
            Spiral_wasm::US11::US11_0(v0_1)
        }
        pub fn method82() -> Func1<Spiral_wasm::US7, Spiral_wasm::US11> {
            Func1::new(move |v: Spiral_wasm::US7| Spiral_wasm::closure27((), v))
        }
        pub fn closure28(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US11 {
            Spiral_wasm::US11::US11_1(v0_1)
        }
        pub fn method83() -> Func1<std::string::String, Spiral_wasm::US11> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure28((), v))
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
        pub fn closure29(v0_1: u8, v1: std::string::String, unitVar: ()) {
            fn v32() {
                Spiral_wasm::closure6((), ());
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
            let v111: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v557: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                3_i32
                    >= (find(
                        v111,
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
                    Spiral_wasm::closure8(v298.clone(), ());
                    ()
                };
                println!("{}", v229.clone());
                (v299.l0.get().clone())(v229);
                Spiral_wasm::US8::US8_0(
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
        pub fn closure30(unitVar: (), unitVar_1: ()) {
            fn v30() {
                Spiral_wasm::closure6((), ());
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
            let v109: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v443: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                3_i32
                    >= (find(
                        v109,
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
                    Spiral_wasm::closure8(v185.clone(), ());
                    ()
                };
                println!("{}", string("\n"));
                (v186.l0.get().clone())(string("\n"));
                Spiral_wasm::US8::US8_0(
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
        pub fn closure31(v0_1: u8, v1: std::string::String, unitVar: ()) {
            fn v32() {
                Spiral_wasm::closure6((), ());
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
            let v111: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v557: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                3_i32
                    >= (find(
                        v111,
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
                    Spiral_wasm::closure8(v298.clone(), ());
                    ()
                };
                println!("{}", v229.clone());
                (v299.l0.get().clone())(v229);
                Spiral_wasm::US8::US8_0(
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
        pub fn closure32(unitVar: (), unitVar_1: ()) {
            fn v30() {
                Spiral_wasm::closure6((), ());
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
            let v109: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v443: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                3_i32
                    >= (find(
                        v109,
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
                    Spiral_wasm::closure8(v185.clone(), ());
                    ()
                };
                println!("{}", string("\n"));
                (v186.l0.get().clone())(string("\n"));
                Spiral_wasm::US8::US8_0(
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
        pub fn closure33(v0_1: u8, v1: string, unitVar: ()) {
            fn v32() {
                Spiral_wasm::closure6((), ());
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
            let v111: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v557: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                4_i32
                    >= (find(
                        v111,
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
                    Spiral_wasm::closure8(v298.clone(), ());
                    ()
                };
                println!("{}", v229.clone());
                (v299.l0.get().clone())(v229);
                Spiral_wasm::US8::US8_0(
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
        ) -> std::pin::Pin<Box<dyn std::future::Future<Output = Spiral_wasm::US10>>> {
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
                    > = Spiral_wasm::method39(v0_1.clone(), v1);
                    let v10: Result<Spiral_wasm::US7, anyhow::Error> = v8.await;
                    let v11 = Spiral_wasm::method81();
                    let v24: Result<Spiral_wasm::US7, std::string::String> =
                        v10.map_err(|x| v11(x));
                    let v27 = Spiral_wasm::method82();
                    let v28 = Spiral_wasm::method83();
                    let v30: Spiral_wasm::US11 = match &v24 {
                        Err(v24_1_0) => v28(v24_1_0.clone()),
                        Ok(v24_0_0) => v27(v24_0_0.clone()),
                    };
                    let v5672: Spiral_wasm::US10 = match &v30 {
                        Spiral_wasm::US11::US11_0(v30_0_0) => {
                            let v46: Spiral_wasm::US7 = v30_0_0.clone();
                            match &v46 {
                                Spiral_wasm::US7::US7_0(v46_0_0) => {
                                    let v77: string = match &v46 {
                                        Spiral_wasm::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone();
                                    let v672: () = {
                                        Spiral_wasm::closure33(v1, v77.clone(), ());
                                        ()
                                    };
                                    let v1273: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v1275: bool = */
                                        async move {
                                            /*;
                                            let v1277: bool = */
                                            ();
                                            let v1280: string = string("}");
                                            let v1286: bool = true;
                                            let _fix_closure_v1283 =
                                                (v1, Spiral_wasm::US7::US7_0(v77));
                                            let v1292: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v1283 "),
                                                            (v1280),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v1293: bool = true;
                                            _fix_closure_v1283
                                        },
                                    ); // rust.fix_closure';
                                    let v1295 = __future_init;
                                    let v1297: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<Output = (u8, Spiral_wasm::US7)>,
                                        >,
                                    > = v1295;
                                    let patternInput_2: (u8, Spiral_wasm::US7) = v1297.await;
                                    Spiral_wasm::US10::US10_1(
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
                                            let _fix_closure_v58 = (v1, Spiral_wasm::US7::US7_1);
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
                                            dyn std::future::Future<Output = (u8, Spiral_wasm::US7)>,
                                        >,
                                    > = v70;
                                    let patternInput_1: (u8, Spiral_wasm::US7) = v72.await;
                                    Spiral_wasm::US10::US10_0(
                                        patternInput_1.0.clone(),
                                        patternInput_1.1.clone(),
                                    )
                                }
                            }
                        }
                        Spiral_wasm::US11::US11_1(v30_1_0) => {
                            let v1304: std::string::String = v30_1_0.clone();
                            if (v1) >= 15_u8 {
                                let v1900: () = {
                                    Spiral_wasm::closure29(v1, v1304.clone(), ());
                                    ()
                                };
                                let v2983: () = {
                                    Spiral_wasm::closure30((), ());
                                    ()
                                };
                                let v3472: bool = true;
                                let __future_init = Box::pin(
                                    /*;
                                    let v3474: bool = */
                                    async move {
                                        /*;
                                        let v3476: bool = */
                                        ();
                                        let v3479: string = string("}");
                                        let v3485: bool = true;
                                        let _fix_closure_v3482 = (v1, Spiral_wasm::US7::US7_1);
                                        let v3491: string = append(
                                            (append(
                                                (append(
                                                    (append(
                                                        string("true; _fix_closure_v3482 "),
                                                        (v3479),
                                                    )),
                                                    string("); "),
                                                )),
                                                string(""),
                                            )),
                                            string(" // rust.fix_closure\'"),
                                        );
                                        let v3492: bool = true;
                                        _fix_closure_v3482
                                    },
                                ); // rust.fix_closure';
                                let v3494 = __future_init;
                                let v3496: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = (u8, Spiral_wasm::US7)>>,
                                > = v3494;
                                let patternInput: (u8, Spiral_wasm::US7) = v3496.await;
                                Spiral_wasm::US10::US10_0(
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                )
                            } else {
                                let v4095: () = {
                                    Spiral_wasm::closure31(v1, v1304, ());
                                    ()
                                };
                                let v5178: () = {
                                    Spiral_wasm::closure32((), ());
                                    ()
                                };
                                let v5667: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = Spiral_wasm::US10>>,
                                > = Spiral_wasm::method38(v0_1.clone(), (v1) + 1_u8);
                                v5667.await
                            }
                        }
                    };
                    let v5675: string = string("}");
                    let v5680: bool = true;
                    let _fix_closure_v5677 = v5672;
                    let v5686: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v5677 "), (v5675))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v5687: bool = true;
                    _fix_closure_v5677
                },
            ); // rust.fix_closure';
            let v5689 = __future_init;
            v5689
        }
        pub fn method93(v0_1: LrcPtr<Spiral_wasm::Mut3>) {
            let v5: string = append((v0_1.l0.get().clone()), string("retries"));
            v0_1.l0.set(v5);
            ()
        }
        pub fn method92(v0_1: Spiral_wasm::US10) -> string {
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
            v8: Spiral_wasm::US10,
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
        pub fn closure34(v0_1: Spiral_wasm::US10, unitVar: ()) {
            fn v31() {
                Spiral_wasm::closure6((), ());
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
            let v110: Spiral_wasm::US3 = (patternInput.4.clone()).l0.get().clone();
            let v556: Spiral_wasm::US8 = if (if ((patternInput.2.clone()).l0.get().clone()) == false
            {
                false
            } else {
                0_i32
                    >= (find(
                        v110,
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
                    Spiral_wasm::closure8(v297.clone(), ());
                    ()
                };
                println!("{}", v228.clone());
                (v298.l0.get().clone())(v228);
                Spiral_wasm::US8::US8_0(
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
        pub fn method94(v0_1: Spiral_wasm::US10, v1: Spiral_wasm::US7) -> string {
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
                    let v156: Spiral_wasm::US0 =
                        defaultValue(Spiral_wasm::US0::US0_1, map(Spiral_wasm::method2(), v94));
                    let v170: std::string::String = match &v156 {
                        Spiral_wasm::US0::US0_0(v156_0_0) => match &v156 {
                            Spiral_wasm::US0::US0_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v172: string = fable_library_rust::String_::fromString(v170);
                    let v767: () = {
                        Spiral_wasm::closure12(v172.clone(), ());
                        ()
                    };
                    let v1368: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v172);
                    let v1372: std::pin::Pin<
                        Box<dyn std::future::Future<Output = Spiral_wasm::US10>>,
                    > = Spiral_wasm::method38(v1368?, 1_u8);
                    let v1374: Spiral_wasm::US10 = v1372.await;
                    let v1969: () = {
                        Spiral_wasm::closure34(v1374.clone(), ());
                        ()
                    };
                    let v2603: Result<u8, anyhow::Error> = match &v1374 {
                        Spiral_wasm::US10::US10_0(v1374_0_0, v1374_0_1) => {
                            Ok::<u8, anyhow::Error>(v1374_0_0.clone())
                        }
                        Spiral_wasm::US10::US10_1(v1374_1_0, v1374_1_1) => {
                            let v2584: string =
                                Spiral_wasm::method94(v1374.clone(), v1374_1_1.clone());
                            let v2586: anyhow::Error = anyhow::anyhow!(v2584);
                            Err(v2586)
                        }
                    };
                    let v2606: string = string("}");
                    let v2611: bool = true;
                    let _fix_closure_v2608 = v2603;
                    let v2617: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v2608 "), (v2606))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v2618: bool = true;
                    _fix_closure_v2608
                },
            ); // rust.fix_closure';
            let v2620 = __future_init;
            v2620
        }
        pub fn closure35(unitVar: (), v0_1: u8) -> Spiral_wasm::US12 {
            Spiral_wasm::US12::US12_0(v0_1)
        }
        pub fn method95() -> Func1<u8, Spiral_wasm::US12> {
            Func1::new(move |v: u8| Spiral_wasm::closure35((), v))
        }
        pub fn closure36(unitVar: (), v0_1: std::string::String) -> Spiral_wasm::US12 {
            Spiral_wasm::US12::US12_1(v0_1)
        }
        pub fn method96() -> Func1<std::string::String, Spiral_wasm::US12> {
            Func1::new(move |v: std::string::String| Spiral_wasm::closure36((), v))
        }
        pub fn closure0(unitVar: (), v0_1: Array<string>) -> i32 {
            let v1: clap::Command = Spiral_wasm::method0();
            let v3: clap::ArgMatches = clap::Command::get_matches(v1);
            let v4: string = Spiral_wasm::method1();
            let v18: &str = &*v4;
            let v91: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v18).cloned();
            let v153: Spiral_wasm::US0 =
                defaultValue(Spiral_wasm::US0::US0_1, map(Spiral_wasm::method2(), v91));
            let v331: Spiral_wasm::US1 = match &v153 {
                Spiral_wasm::US0::US0_0(v153_0_0) => {
                    let v166: string = fable_library_rust::String_::fromString(
                        match &v153 {
                            Spiral_wasm::US0::US0_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    );
                    let v171: string = toLower(string("Critical"));
                    let v185: string = toLower(string("Warning"));
                    let v199: string = toLower(string("Info"));
                    let v213: string = toLower(string("Debug"));
                    let v227: string = toLower(string("Verbose"));
                    let v241: Spiral_wasm::US2 = if string("Verbose") == (v166.clone()) {
                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_0)
                    } else {
                        Spiral_wasm::US2::US2_1
                    };
                    Spiral_wasm::US1::US1_0(match &v241 {
                        Spiral_wasm::US2::US2_0(v241_0_0) => Spiral_wasm::US2::US2_0(
                            match &v241 {
                                Spiral_wasm::US2::US2_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v248: Spiral_wasm::US2 = if string("Debug") == (v166.clone()) {
                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_1)
                            } else {
                                Spiral_wasm::US2::US2_1
                            };
                            match &v248 {
                                Spiral_wasm::US2::US2_0(v248_0_0) => Spiral_wasm::US2::US2_0(
                                    match &v248 {
                                        Spiral_wasm::US2::US2_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v255: Spiral_wasm::US2 = if string("Info") == (v166.clone())
                                    {
                                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                    } else {
                                        Spiral_wasm::US2::US2_1
                                    };
                                    match &v255 {
                                        Spiral_wasm::US2::US2_0(v255_0_0) => {
                                            Spiral_wasm::US2::US2_0(
                                                match &v255 {
                                                    Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            )
                                        }
                                        _ => {
                                            let v262: Spiral_wasm::US2 =
                                                if string("Warning") == (v166.clone()) {
                                                    Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                                } else {
                                                    Spiral_wasm::US2::US2_1
                                                };
                                            match &v262 {
                                                Spiral_wasm::US2::US2_0(v262_0_0) => {
                                                    Spiral_wasm::US2::US2_0(
                                                        match &v262 {
                                                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => {
                                                    let v269: Spiral_wasm::US2 =
                                                        if string("Critical") == (v166.clone()) {
                                                            Spiral_wasm::US2::US2_0(
                                                                Spiral_wasm::US3::US3_4,
                                                            )
                                                        } else {
                                                            Spiral_wasm::US2::US2_1
                                                        };
                                                    match &v269 {
                                                        Spiral_wasm::US2::US2_0(v269_0_0) => {
                                                            Spiral_wasm::US2::US2_0(
                                                                match &v269 {
                                                                    Spiral_wasm::US2::US2_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            let v276: Spiral_wasm::US2 =
                                                                if (v227.clone()) == (v166.clone())
                                                                {
                                                                    Spiral_wasm::US2::US2_0(
                                                                        Spiral_wasm::US3::US3_0,
                                                                    )
                                                                } else {
                                                                    Spiral_wasm::US2::US2_1
                                                                };
                                                            match &v276 {
                                                                Spiral_wasm::US2::US2_0(
                                                                    v276_0_0,
                                                                ) => Spiral_wasm::US2::US2_0(
                                                                    match &v276 {
                                                                        Spiral_wasm::US2::US2_0(
                                                                            x,
                                                                        ) => x.clone(),
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                ),
                                                                _ => {
                                                                    let v283: Spiral_wasm::US2 =
                                                                        if (v213.clone())
                                                                            == (v166.clone())
                                                                        {
                                                                            Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_1)
                                                                        } else {
                                                                            Spiral_wasm::US2::US2_1
                                                                        };
                                                                    match &v283
                                                                                                    {
                                                                                                    Spiral_wasm::US2::US2_0(v283_0_0)
                                                                                                    =>
                                                                                                    Spiral_wasm::US2::US2_0(match &v283
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
                                                                                                        let v290:
                                                                                                                Spiral_wasm::US2 =
                                                                                                            if (v199.clone())
                                                                                                                   ==
                                                                                                                   (v166.clone())
                                                                                                               {
                                                                                                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                                                                                            } else {
                                                                                                                Spiral_wasm::US2::US2_1
                                                                                                            };
                                                                                                        match &v290
                                                                                                            {
                                                                                                            Spiral_wasm::US2::US2_0(v290_0_0)
                                                                                                            =>
                                                                                                            Spiral_wasm::US2::US2_0(match &v290
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
                                                                                                                let v297:
                                                                                                                        Spiral_wasm::US2 =
                                                                                                                    if (v185.clone())
                                                                                                                           ==
                                                                                                                           (v166.clone())
                                                                                                                       {
                                                                                                                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                                                                                                    } else {
                                                                                                                        Spiral_wasm::US2::US2_1
                                                                                                                    };
                                                                                                                match &v297
                                                                                                                    {
                                                                                                                    Spiral_wasm::US2::US2_0(v297_0_0)
                                                                                                                    =>
                                                                                                                    Spiral_wasm::US2::US2_0(match &v297
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
                                                                                                                        let v304:
                                                                                                                                Spiral_wasm::US2 =
                                                                                                                            if (v171.clone())
                                                                                                                                   ==
                                                                                                                                   (v166.clone())
                                                                                                                               {
                                                                                                                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_4)
                                                                                                                            } else {
                                                                                                                                Spiral_wasm::US2::US2_1
                                                                                                                            };
                                                                                                                        match &v304
                                                                                                                            {
                                                                                                                            Spiral_wasm::US2::US2_0(v304_0_0)
                                                                                                                            =>
                                                                                                                            Spiral_wasm::US2::US2_0(match &v304
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
            let v338: Spiral_wasm::US2 = if let Spiral_wasm::US1::US1_0(v331_0_0) = &v331 {
                let v332: Spiral_wasm::US2 = v331_0_0.clone();
                if let Spiral_wasm::US2::US2_0(v332_0_0) = &v332 {
                    Spiral_wasm::US2::US2_0(v332_0_0.clone())
                } else {
                    Spiral_wasm::US2::US2_1
                }
            } else {
                Spiral_wasm::US2::US2_1
            };
            let v372: () = {
                Spiral_wasm::closure2(
                    match &v338 {
                        Spiral_wasm::US2::US2_0(v338_0_0) => match &v338 {
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
            let v1041: () = {
                Spiral_wasm::closure5(v0_1, ());
                ()
            };
            let v1641: string = Spiral_wasm::method28();
            let v1655: &str = &*v1641;
            let v1728: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v1655).cloned();
            let v1741: Option<string> = map(Spiral_wasm::method29(), v1728);
            let v2942: Spiral_wasm::US7 =
                defaultValue(Spiral_wasm::US7::US7_1, map(Spiral_wasm::method8(), v1741));
            let v2953: std::pin::Pin<
                Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>,
            > = Spiral_wasm::method33(v3);
            let v2955 = tokio::runtime::Builder::new_multi_thread()
                .enable_all()
                .build()
                .unwrap();
            let v2957: Result<u8, anyhow::Error> = v2955.handle().block_on(v2953);
            let v2958 = Spiral_wasm::method81();
            let v2971: Result<u8, std::string::String> = v2957.map_err(|x| v2958(x));
            let v2974 = Spiral_wasm::method95();
            let v2975 = Spiral_wasm::method96();
            let v2977: Spiral_wasm::US12 = match &v2971 {
                Err(v2971_1_0) => v2975(v2971_1_0.clone()),
                Ok(v2971_0_0) => v2974(v2971_0_0.clone()),
            };
            match &v2977 {
                Spiral_wasm::US12::US12_0(v2977_0_0) => {
                    if let Spiral_wasm::US7::US7_0(v2942_0_0) = &v2942 {
                        let v2995: string = sprintf!(
                            "spiral_wasm.main / retries: {} / exception: \'{}\'",
                            v2977_0_0.clone(),
                            v2942_0_0.clone()
                        );
                        let v2999: Result<(), string> = Err(v2995);
                        v2999.unwrap();
                        ()
                    }
                }
                Spiral_wasm::US12::US12_1(v2977_1_0) => {
                    let v3015: std::string::String = v2977_1_0.clone();
                    if let Spiral_wasm::US7::US7_0(v2942_0_0) = &v2942 {
                        let v3016: string = v2942_0_0.clone();
                        if string("") == (v3016.clone()) {
                            ()
                        } else {
                            if contains(
                                fable_library_rust::String_::fromString(v3015.clone()),
                                v3016.clone(),
                            ) {
                                ()
                            } else {
                                let v3031: string = sprintf!(
                                    "spiral_wasm.main / exception: \'{}\' / error: {}",
                                    v3016,
                                    v3015
                                );
                                let v3035: Result<(), string> = Err(v3031);
                                v3035.unwrap();
                                ()
                            }
                        }
                    } else {
                        let v3054: u8 = v2971.clone().unwrap();
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
