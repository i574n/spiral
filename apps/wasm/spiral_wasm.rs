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
            let v90: Array<string> = toArray(ofArray(new_array(&[
                string("Verbose"),
                string("Debug"),
                string("Info"),
                string("Warning"),
                string("Critical"),
            ])));
            let v94: Vec<string> = v90.to_vec();
            let v96: bool = true;
            let _vec_map: Vec<_> = v94
                .into_iter()
                .map(|x| {
                    //;
                    let v98: string = x;
                    let v105: &str = &*v98;
                    let v138: std::string::String = String::from(v105);
                    let v166: Box<std::string::String> = Box::new(v138);
                    let v168: &'static mut std::string::String = Box::leak(v166);
                    let v170: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v168);
                    let v172: bool = true;
                    v170
                })
                .collect::<Vec<_>>();
            let v174: Vec<clap::builder::PossibleValue> = _vec_map;
            let v176: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v174),
            );
            let v178: clap::Arg = v61.value_parser(v176);
            let v180: clap::Command = clap::Command::arg(v50, v178);
            let v182: string = string("r#\"wasm\"#");
            let v183: &'static str = r#"wasm"#;
            let v185: clap::Arg = clap::Arg::new(v183);
            let v187: clap::Arg = v185.short('w');
            let v188: string = string("r#\"wasm\"#");
            let v189: &'static str = r#"wasm"#;
            let v191: clap::Arg = v187.long(v189);
            let v193: clap::Arg = v191.required(true);
            clap::Command::arg(v180, v193)
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
            let v6: Spiral_wasm::US2 = if string("Verbose") == (v1.clone()) {
                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_0)
            } else {
                Spiral_wasm::US2::US2_1
            };
            (
                match &v6 {
                    Spiral_wasm::US2::US2_0(v6_0_0) => Spiral_wasm::US2::US2_0(
                        match &v6 {
                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    _ => {
                        let v13: Spiral_wasm::US2 = if string("Debug") == (v1.clone()) {
                            Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_1)
                        } else {
                            Spiral_wasm::US2::US2_1
                        };
                        match &v13 {
                            Spiral_wasm::US2::US2_0(v13_0_0) => Spiral_wasm::US2::US2_0(
                                match &v13 {
                                    Spiral_wasm::US2::US2_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => {
                                let v20: Spiral_wasm::US2 = if string("Info") == (v1.clone()) {
                                    Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                } else {
                                    Spiral_wasm::US2::US2_1
                                };
                                match &v20 {
                                    Spiral_wasm::US2::US2_0(v20_0_0) => Spiral_wasm::US2::US2_0(
                                        match &v20 {
                                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => {
                                        let v27: Spiral_wasm::US2 =
                                            if string("Warning") == (v1.clone()) {
                                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                            } else {
                                                Spiral_wasm::US2::US2_1
                                            };
                                        match &v27 {
                                            Spiral_wasm::US2::US2_0(v27_0_0) => {
                                                Spiral_wasm::US2::US2_0(
                                                    match &v27 {
                                                        Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                )
                                            }
                                            _ => {
                                                let v34: Spiral_wasm::US2 = if string("Critical")
                                                    == (v1.clone())
                                                {
                                                    Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_4)
                                                } else {
                                                    Spiral_wasm::US2::US2_1
                                                };
                                                match &v34 {
                                                    Spiral_wasm::US2::US2_0(v34_0_0) => {
                                                        Spiral_wasm::US2::US2_0(
                                                            match &v34 {
                                                                Spiral_wasm::US2::US2_0(x) => {
                                                                    x.clone()
                                                                }
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => Spiral_wasm::US2::US2_1,
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
            let v182: Spiral_wasm::US4 =
                defaultValue(Spiral_wasm::US4::US4_1, map(Spiral_wasm::method11(), v5));
            let v300: DateTime = match &v182 {
                Spiral_wasm::US4::US4_0(v182_0_0) => {
                    let v252: TimeSpan = TimeSpan::new_ticks(
                        ({
                            let _arg: DateTime = DateTime::now();
                            _arg.ticks()
                        }) - (match &v182 {
                            Spiral_wasm::US4::US4_0(x) => x.clone(),
                            _ => unreachable!(),
                        }),
                    );
                    DateTime::new_ymdhms_milli(
                        1_i32,
                        1_i32,
                        1_i32,
                        v252.hours(),
                        v252.minutes(),
                        v252.seconds(),
                        v252.milliseconds(),
                    )
                }
                _ => DateTime::now(),
            };
            let v302: string = Spiral_wasm::method12();
            let provider: string = if (v302.clone()) == string("") {
                string("M-d-y hh:mm:ss tt")
            } else {
                v302
            };
            v300.toString(provider)
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
                    let v567: Result<Spiral_wasm::US7, anyhow::Error> = if (v314) > 0_i32 {
                        Ok::<Spiral_wasm::US7, anyhow::Error>(Spiral_wasm::US7::US7_0(v542.clone()))
                    } else {
                        if (v383) > 1_i32 {
                            Ok::<Spiral_wasm::US7, anyhow::Error>(Spiral_wasm::US7::US7_1)
                        } else {
                            let v550: anyhow::Error = anyhow::anyhow!(v542);
                            Err(v550)
                        }
                    };
                    let v570: string = string("}");
                    let v575: bool = true;
                    let _fix_closure_v572 = v567;
                    let v582: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v572 "), (v570))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v583: bool = true;
                    _fix_closure_v572
                },
            ); // rust.fix_closure';
            let v585 = __future_init;
            v585
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
                    let v29: Spiral_wasm::US9 = match &v24 {
                        Err(v24_1_0) => v28(v24_1_0.clone()),
                        Ok(v24_0_0) => v27(v24_0_0.clone()),
                    };
                    let v292: Spiral_wasm::US8 = match &v29 {
                        Spiral_wasm::US9::US9_0(v29_0_0) => {
                            let v30: Spiral_wasm::US7 = v29_0_0.clone();
                            match &v30 {
                                Spiral_wasm::US7::US7_0(v30_0_0) => {
                                    let v62: string = match &v30 {
                                        Spiral_wasm::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone();
                                    let v65: () = {
                                        Spiral_wasm::closure34(v1, v62.clone(), ());
                                        ()
                                    };
                                    let v113: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v115: bool = */
                                        async move {
                                            /*;
                                            let v117: bool = */
                                            ();
                                            let v120: string = string("}");
                                            let v126: bool = true;
                                            let _fix_closure_v123 =
                                                (v1, Spiral_wasm::US7::US7_0(v62));
                                            let v133: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v123 "),
                                                            (v120),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v134: bool = true;
                                            _fix_closure_v123
                                        },
                                    ); // rust.fix_closure';
                                    let v136 = __future_init;
                                    let v138: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<
                                                Output = (u8, Spiral_wasm::US7),
                                            >,
                                        >,
                                    > = v136;
                                    let patternInput_2: (u8, Spiral_wasm::US7) = v138.await;
                                    Spiral_wasm::US8::US8_1(
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone(),
                                    )
                                }
                                _ => {
                                    let v32: bool = true;
                                    let __future_init = Box::pin(
                                        /*;
                                        let v34: bool = */
                                        async move {
                                            /*;
                                            let v36: bool = */
                                            ();
                                            let v39: string = string("}");
                                            let v45: bool = true;
                                            let _fix_closure_v42 = (v1, Spiral_wasm::US7::US7_1);
                                            let v52: string = append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("true; _fix_closure_v42 "),
                                                            (v39),
                                                        )),
                                                        string("); "),
                                                    )),
                                                    string(""),
                                                )),
                                                string(" // rust.fix_closure\'"),
                                            );
                                            let v53: bool = true;
                                            _fix_closure_v42
                                        },
                                    ); // rust.fix_closure';
                                    let v55 = __future_init;
                                    let v57: std::pin::Pin<
                                        Box<
                                            dyn std::future::Future<
                                                Output = (u8, Spiral_wasm::US7),
                                            >,
                                        >,
                                    > = v55;
                                    let patternInput_1: (u8, Spiral_wasm::US7) = v57.await;
                                    Spiral_wasm::US8::US8_0(
                                        patternInput_1.0.clone(),
                                        patternInput_1.1.clone(),
                                    )
                                }
                            }
                        }
                        Spiral_wasm::US9::US9_1(v29_1_0) => {
                            let v145: std::string::String = v29_1_0.clone();
                            if (v1) >= 15_u8 {
                                let v149: () = {
                                    Spiral_wasm::closure30(v1, v145.clone(), ());
                                    ()
                                };
                                let v198: () = {
                                    Spiral_wasm::closure31((), ());
                                    ()
                                };
                                let v202: bool = true;
                                let __future_init = Box::pin(
                                    /*;
                                    let v204: bool = */
                                    async move {
                                        /*;
                                        let v206: bool = */
                                        ();
                                        let v209: string = string("}");
                                        let v215: bool = true;
                                        let _fix_closure_v212 = (v1, Spiral_wasm::US7::US7_1);
                                        let v222: string = append(
                                            (append(
                                                (append(
                                                    (append(
                                                        string("true; _fix_closure_v212 "),
                                                        (v209),
                                                    )),
                                                    string("); "),
                                                )),
                                                string(""),
                                            )),
                                            string(" // rust.fix_closure\'"),
                                        );
                                        let v223: bool = true;
                                        _fix_closure_v212
                                    },
                                ); // rust.fix_closure';
                                let v225 = __future_init;
                                let v227: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = (u8, Spiral_wasm::US7)>>,
                                > = v225;
                                let patternInput: (u8, Spiral_wasm::US7) = v227.await;
                                Spiral_wasm::US8::US8_0(
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                )
                            } else {
                                let v234: () = {
                                    Spiral_wasm::closure32(v1, v145, ());
                                    ()
                                };
                                let v283: () = {
                                    Spiral_wasm::closure33((), ());
                                    ()
                                };
                                let v287: std::pin::Pin<
                                    Box<dyn std::future::Future<Output = Spiral_wasm::US8>>,
                                > = Spiral_wasm::method28(v0_1.clone(), (v1) + 1_u8);
                                v287.await
                            }
                        }
                    };
                    let v295: string = string("}");
                    let v300: bool = true;
                    let _fix_closure_v297 = v292;
                    let v307: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v297 "), (v295))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v308: bool = true;
                    _fix_closure_v297
                },
            ); // rust.fix_closure';
            let v310 = __future_init;
            v310
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
                    let v59: Spiral_wasm::US0 =
                        defaultValue(Spiral_wasm::US0::US0_1, map(Spiral_wasm::method2(), v42));
                    let v66: std::string::String = match &v59 {
                        Spiral_wasm::US0::US0_0(v59_0_0) => match &v59 {
                            Spiral_wasm::US0::US0_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => panic!("{}", string("Option does not have a value."),),
                    };
                    let v68: string = fable_library_rust::String_::fromString(v66);
                    let v71: () = {
                        Spiral_wasm::closure13(v68.clone(), ());
                        ()
                    };
                    let v119: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v68);
                    let v123: std::pin::Pin<
                        Box<dyn std::future::Future<Output = Spiral_wasm::US8>>,
                    > = Spiral_wasm::method28(v119?, 1_u8);
                    let v125: Spiral_wasm::US8 = v123.await;
                    let v128: () = {
                        Spiral_wasm::closure35(v125.clone(), ());
                        ()
                    };
                    let v199: Result<u8, anyhow::Error> = match &v125 {
                        Spiral_wasm::US8::US8_0(v125_0_0, v125_0_1) => {
                            Ok::<u8, anyhow::Error>(v125_0_0.clone())
                        }
                        Spiral_wasm::US8::US8_1(v125_1_0, v125_1_1) => {
                            let v180: string =
                                Spiral_wasm::method65(v125.clone(), v125_1_1.clone());
                            let v182: anyhow::Error = anyhow::anyhow!(v180);
                            Err(v182)
                        }
                    };
                    let v202: string = string("}");
                    let v207: bool = true;
                    let _fix_closure_v204 = v199;
                    let v214: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v204 "), (v202))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v215: bool = true;
                    _fix_closure_v204
                },
            ); // rust.fix_closure';
            let v217 = __future_init;
            v217
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
            let v56: Spiral_wasm::US0 =
                defaultValue(Spiral_wasm::US0::US0_1, map(Spiral_wasm::method2(), v39));
            let v112: Spiral_wasm::US1 = match &v56 {
                Spiral_wasm::US0::US0_0(v56_0_0) => {
                    let v62: string = fable_library_rust::String_::fromString(
                        match &v56 {
                            Spiral_wasm::US0::US0_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    );
                    let v67: Spiral_wasm::US2 = if string("Verbose") == (v62.clone()) {
                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_0)
                    } else {
                        Spiral_wasm::US2::US2_1
                    };
                    Spiral_wasm::US1::US1_0(match &v67 {
                        Spiral_wasm::US2::US2_0(v67_0_0) => Spiral_wasm::US2::US2_0(
                            match &v67 {
                                Spiral_wasm::US2::US2_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v74: Spiral_wasm::US2 = if string("Debug") == (v62.clone()) {
                                Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_1)
                            } else {
                                Spiral_wasm::US2::US2_1
                            };
                            match &v74 {
                                Spiral_wasm::US2::US2_0(v74_0_0) => Spiral_wasm::US2::US2_0(
                                    match &v74 {
                                        Spiral_wasm::US2::US2_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v81: Spiral_wasm::US2 = if string("Info") == (v62.clone()) {
                                        Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_2)
                                    } else {
                                        Spiral_wasm::US2::US2_1
                                    };
                                    match &v81 {
                                        Spiral_wasm::US2::US2_0(v81_0_0) => {
                                            Spiral_wasm::US2::US2_0(
                                                match &v81 {
                                                    Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            )
                                        }
                                        _ => {
                                            let v88: Spiral_wasm::US2 =
                                                if string("Warning") == (v62.clone()) {
                                                    Spiral_wasm::US2::US2_0(Spiral_wasm::US3::US3_3)
                                                } else {
                                                    Spiral_wasm::US2::US2_1
                                                };
                                            match &v88 {
                                                Spiral_wasm::US2::US2_0(v88_0_0) => {
                                                    Spiral_wasm::US2::US2_0(
                                                        match &v88 {
                                                            Spiral_wasm::US2::US2_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => {
                                                    let v95: Spiral_wasm::US2 =
                                                        if string("Critical") == (v62.clone()) {
                                                            Spiral_wasm::US2::US2_0(
                                                                Spiral_wasm::US3::US3_4,
                                                            )
                                                        } else {
                                                            Spiral_wasm::US2::US2_1
                                                        };
                                                    match &v95 {
                                                        Spiral_wasm::US2::US2_0(v95_0_0) => {
                                                            Spiral_wasm::US2::US2_0(
                                                                match &v95 {
                                                                    Spiral_wasm::US2::US2_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => Spiral_wasm::US2::US2_1,
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
            let v119: Spiral_wasm::US2 = if let Spiral_wasm::US1::US1_0(v112_0_0) = &v112 {
                let v113: Spiral_wasm::US2 = v112_0_0.clone();
                if let Spiral_wasm::US2::US2_0(v113_0_0) = &v113 {
                    Spiral_wasm::US2::US2_0(v113_0_0.clone())
                } else {
                    Spiral_wasm::US2::US2_1
                }
            } else {
                Spiral_wasm::US2::US2_1
            };
            let v126: () = {
                Spiral_wasm::closure2(
                    match &v119 {
                        Spiral_wasm::US2::US2_0(v119_0_0) => match &v119 {
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
            let v165: () = {
                Spiral_wasm::closure5(v0_1, ());
                ()
            };
            let v212: string = Spiral_wasm::method22();
            let v219: &str = &*v212;
            let v247: Option<std::string::String> =
                clap::ArgMatches::get_one(&v3.clone(), v219).cloned();
            let v250: Option<string> = map(Spiral_wasm::method23(), v247);
            let v359: Spiral_wasm::US7 =
                defaultValue(Spiral_wasm::US7::US7_1, map(Spiral_wasm::method8(), v250));
            let v363: std::pin::Pin<
                Box<dyn std::future::Future<Output = Result<u8, anyhow::Error>>>,
            > = Spiral_wasm::method24(v3);
            let v365 = tokio::runtime::Builder::new_multi_thread()
                .enable_all()
                .build()
                .unwrap();
            let v367: Result<u8, anyhow::Error> = v365.handle().block_on(v363);
            let v368 = Spiral_wasm::method53();
            let v381: Result<u8, std::string::String> = v367.map_err(|x| v368(x));
            let v384 = Spiral_wasm::method66();
            let v385 = Spiral_wasm::method67();
            let v386: Spiral_wasm::US10 = match &v381 {
                Err(v381_1_0) => v385(v381_1_0.clone()),
                Ok(v381_0_0) => v384(v381_0_0.clone()),
            };
            match &v386 {
                Spiral_wasm::US10::US10_0(v386_0_0) => {
                    if let Spiral_wasm::US7::US7_0(v359_0_0) = &v359 {
                        let v389: string = sprintf!(
                            "spiral_wasm.main / retries: {} / exception: \'{}\'",
                            v386_0_0.clone(),
                            v359_0_0.clone()
                        );
                        let v393: Result<(), string> = Err(v389);
                        v393.unwrap();
                        ()
                    }
                }
                Spiral_wasm::US10::US10_1(v386_1_0) => {
                    let v409: std::string::String = v386_1_0.clone();
                    if let Spiral_wasm::US7::US7_0(v359_0_0) = &v359 {
                        let v410: string = v359_0_0.clone();
                        if string("") == (v410.clone()) {
                            ()
                        } else {
                            if contains(
                                fable_library_rust::String_::fromString(v409.clone()),
                                v410.clone(),
                            ) {
                                ()
                            } else {
                                let v418: string = sprintf!(
                                    "spiral_wasm.main / exception: \'{}\' / error: {}",
                                    v410,
                                    v409
                                );
                                let v422: Result<(), string> = Err(v418);
                                v422.unwrap();
                                ()
                            }
                        }
                    } else {
                        let v441: u8 = v381.clone().unwrap();
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
