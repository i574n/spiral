pub mod Trace {
    use super::*;
    type DateTime = ();
    use fable_library_rust::List_::empty;
    use fable_library_rust::List_::ofArray;
    use fable_library_rust::List_::toArray;
    use fable_library_rust::Map_::find;
    use fable_library_rust::Map_::ofSeq;
    use fable_library_rust::NativeArray_::new_array;
    use fable_library_rust::Native_::getNull;
    use fable_library_rust::Native_::on_startup;
    use fable_library_rust::Native_::unbox;
    use fable_library_rust::Native_::Any;
    use fable_library_rust::Native_::Func0;
    use fable_library_rust::Native_::Func1;
    use fable_library_rust::Native_::LrcPtr;
    use fable_library_rust::Native_::MutCell;
    use fable_library_rust::Native_::OnceInit;
    use fable_library_rust::Option_::defaultValue;
    use fable_library_rust::Option_::map;
    use fable_library_rust::Seq_::ofList;
    use fable_library_rust::String_::append;
    use fable_library_rust::String_::getCharAt;
    use fable_library_rust::String_::printfn;
    use fable_library_rust::String_::sprintf;
    use fable_library_rust::String_::string;
    use fable_library_rust::String_::toLower;
    use fable_library_rust::String_::trimEndChars;
    use fable_library_rust::String_::trimStartChars;
    use fable_library_rust::System::Collections::Generic::IEnumerable_1;
    pub mod TraceState {
        use super::*;
        pub fn trace_state() -> LrcPtr<
            MutCell<
                Option<(
                    LrcPtr<Trace::Mut0>,
                    LrcPtr<Trace::Mut1>,
                    LrcPtr<Trace::Mut2>,
                    LrcPtr<Trace::Mut3>,
                    LrcPtr<Trace::Mut4>,
                    Option<i64>,
                )>,
            >,
        > {
            static trace_state: OnceInit<
                LrcPtr<
                    MutCell<
                        Option<(
                            LrcPtr<Trace::Mut0>,
                            LrcPtr<Trace::Mut1>,
                            LrcPtr<Trace::Mut2>,
                            LrcPtr<Trace::Mut3>,
                            LrcPtr<Trace::Mut4>,
                            Option<i64>,
                        )>,
                    >,
                >,
            > = OnceInit::new();
            trace_state
                .get_or_init(|| {
                    LrcPtr::new(MutCell::new(
                        None::<(
                            LrcPtr<Trace::Mut0>,
                            LrcPtr<Trace::Mut1>,
                            LrcPtr<Trace::Mut2>,
                            LrcPtr<Trace::Mut3>,
                            LrcPtr<Trace::Mut4>,
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
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US0 {
        US0_0,
        US0_1,
        US0_2,
        US0_3,
        US0_4,
    }
    impl core::fmt::Display for US0 {
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
        pub l0: MutCell<Trace::US0>,
    }
    impl core::fmt::Display for Mut4 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US1 {
        US1_0(Trace::US0),
        US1_1,
    }
    impl core::fmt::Display for US1 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US2 {
        US2_0(i64),
        US2_1,
    }
    impl core::fmt::Display for US2 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US3 {
        US3_0,
        US3_1,
        US3_2,
    }
    impl core::fmt::Display for US3 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US4 {
        US4_0(Trace::US3),
        US4_1(Trace::US3),
        US4_2(Trace::US3),
        US4_3(Trace::US3),
        US4_4(Trace::US3),
        US4_5(Trace::US3),
    }
    impl core::fmt::Display for US4 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US5 {
        US5_0(string),
        US5_1,
    }
    impl core::fmt::Display for US5 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    pub fn method3(v0_1: string) -> string {
        v0_1
    }
    pub fn method4() -> string {
        string("")
    }
    pub fn closure1(unitVar: (), v0_1: string) -> Trace::US5 {
        Trace::US5::US5_0(v0_1)
    }
    pub fn method5() -> Func1<string, Trace::US5> {
        Func1::new(move |v: string| Trace::closure1((), v))
    }
    pub fn method2(v0_1: string) -> string {
        panic!(
            "{}",
            sprintf!(
                "env.get_environment_variable / target: {} / var: {}",
                Trace::US4::US4_3(Trace::US3::US3_2),
                v0_1
            ),
        )
    }
    pub fn method1() -> (Trace::US1, Trace::US2) {
        let v1_1: string = Trace::method2(string("TRACE_LEVEL"));
        let v6: string = toLower(string("Critical"));
        let v13: string = toLower(string("Warning"));
        let v20: string = toLower(string("Info"));
        let v27: string = toLower(string("Debug"));
        let v34: string = toLower(string("Verbose"));
        let v41: Trace::US1 = if string("Verbose") == (v1_1.clone()) {
            Trace::US1::US1_0(Trace::US0::US0_0)
        } else {
            Trace::US1::US1_1
        };
        (
            match &v41 {
                Trace::US1::US1_0(v41_0_0) => Trace::US1::US1_0(
                    match &v41 {
                        Trace::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                ),
                _ => {
                    let v48: Trace::US1 = if string("Debug") == (v1_1.clone()) {
                        Trace::US1::US1_0(Trace::US0::US0_1)
                    } else {
                        Trace::US1::US1_1
                    };
                    match &v48 {
                        Trace::US1::US1_0(v48_0_0) => Trace::US1::US1_0(
                            match &v48 {
                                Trace::US1::US1_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v55: Trace::US1 = if string("Info") == (v1_1.clone()) {
                                Trace::US1::US1_0(Trace::US0::US0_2)
                            } else {
                                Trace::US1::US1_1
                            };
                            match &v55 {
                                Trace::US1::US1_0(v55_0_0) => Trace::US1::US1_0(
                                    match &v55 {
                                        Trace::US1::US1_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v62: Trace::US1 = if string("Warning") == (v1_1.clone()) {
                                        Trace::US1::US1_0(Trace::US0::US0_3)
                                    } else {
                                        Trace::US1::US1_1
                                    };
                                    match &v62 {
                                        Trace::US1::US1_0(v62_0_0) => Trace::US1::US1_0(
                                            match &v62 {
                                                Trace::US1::US1_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        ),
                                        _ => {
                                            let v69: Trace::US1 =
                                                if string("Critical") == (v1_1.clone()) {
                                                    Trace::US1::US1_0(Trace::US0::US0_4)
                                                } else {
                                                    Trace::US1::US1_1
                                                };
                                            match &v69 {
                                                Trace::US1::US1_0(v69_0_0) => Trace::US1::US1_0(
                                                    match &v69 {
                                                        Trace::US1::US1_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                ),
                                                _ => {
                                                    let v76: Trace::US1 =
                                                        if (v34.clone()) == (v1_1.clone()) {
                                                            Trace::US1::US1_0(Trace::US0::US0_0)
                                                        } else {
                                                            Trace::US1::US1_1
                                                        };
                                                    match &v76 {
                                                        Trace::US1::US1_0(v76_0_0) => {
                                                            Trace::US1::US1_0(
                                                                match &v76 {
                                                                    Trace::US1::US1_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            let v83: Trace::US1 = if (v27.clone())
                                                                == (v1_1.clone())
                                                            {
                                                                Trace::US1::US1_0(Trace::US0::US0_1)
                                                            } else {
                                                                Trace::US1::US1_1
                                                            };
                                                            match &v83 {
                                                                Trace::US1::US1_0(v83_0_0) => {
                                                                    Trace::US1::US1_0(
                                                                        match &v83 {
                                                                            Trace::US1::US1_0(
                                                                                x,
                                                                            ) => x.clone(),
                                                                            _ => unreachable!(),
                                                                        }
                                                                        .clone(),
                                                                    )
                                                                }
                                                                _ => {
                                                                    let v90: Trace::US1 = if (v20
                                                                        .clone())
                                                                        == (v1_1.clone())
                                                                    {
                                                                        Trace::US1::US1_0(
                                                                            Trace::US0::US0_2,
                                                                        )
                                                                    } else {
                                                                        Trace::US1::US1_1
                                                                    };
                                                                    match &v90 {
                                                                     Trace::US1::US1_0(v90_0_0)
                                                                     =>
                                                                     Trace::US1::US1_0(match &v90
                                                                                           {
                                                                                           Trace::US1::US1_0(x)
                                                                                           =>
                                                                                           x.clone(),
                                                                                           _
                                                                                           =>
                                                                                           unreachable!(),
                                                                                       }.clone()),
                                                                     _ => {
                                                                         let v97:
                                                                                 Trace::US1 =
                                                                             if (v13.clone())
                                                                                    ==
                                                                                    (v1_1.clone())
                                                                                {
                                                                                 Trace::US1::US1_0(Trace::US0::US0_3)
                                                                             } else {
                                                                                 Trace::US1::US1_1
                                                                             };
                                                                         match &v97
                                                                             {
                                                                             Trace::US1::US1_0(v97_0_0)
                                                                             =>
                                                                             Trace::US1::US1_0(match &v97
                                                                                                   {
                                                                                                   Trace::US1::US1_0(x)
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
                                                                                         Trace::US1 =
                                                                                     if (v6.clone())
                                                                                            ==
                                                                                            (v1_1.clone())
                                                                                        {
                                                                                         Trace::US1::US1_0(Trace::US0::US0_4)
                                                                                     } else {
                                                                                         Trace::US1::US1_1
                                                                                     };
                                                                                 match &v104
                                                                                     {
                                                                                     Trace::US1::US1_0(v104_0_0)
                                                                                     =>
                                                                                     Trace::US1::US1_0(match &v104
                                                                                                           {
                                                                                                           Trace::US1::US1_0(x)
                                                                                                           =>
                                                                                                           x.clone(),
                                                                                                           _
                                                                                                           =>
                                                                                                           unreachable!(),
                                                                                                       }.clone()),
                                                                                     _
                                                                                     =>
                                                                                     Trace::US1::US1_1,
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
            if (Trace::method2(string("AUTOMATION"))) != string("True") {
                Trace::US2::US2_1
            } else {
                let v143: DateTime = unbox::<DateTime>(fable_library_rust::Native_::getZero());
                Trace::US2::US2_0(unbox::<i64>(fable_library_rust::Native_::getZero()))
            },
        )
    }
    pub fn closure2(unitVar: (), v0_1: string) {
        ();
    }
    pub fn method0(
        v0_1: Trace::US0,
    ) -> (
        LrcPtr<Trace::Mut0>,
        LrcPtr<Trace::Mut1>,
        LrcPtr<Trace::Mut2>,
        LrcPtr<Trace::Mut3>,
        LrcPtr<Trace::Mut4>,
        Option<i64>,
    ) {
        let v88: string = string("option_env!(\"AUTOMATION\").unwrap_or(\"\")");
        let v89: &str = option_env!("AUTOMATION").unwrap_or("");
        let v100: std::string::String = String::from(v89);
        let _run_target_args__v3: (Trace::US1, Trace::US2) = (
            Trace::US1::US1_1,
            if (fable_library_rust::String_::fromString(v100)) != string("True") {
                Trace::US2::US2_1
            } else {
                Trace::US2::US2_0(near_sdk::env::block_timestamp() as i64)
            },
        );
        let v173: Trace::US2 = _run_target_args__v3.1.clone();
        let v172: Trace::US1 = _run_target_args__v3.0.clone();
        (
            LrcPtr::new(Trace::Mut0 {
                l0: MutCell::new(1_i64),
            }),
            LrcPtr::new(Trace::Mut1 {
                l0: MutCell::new(Func1::new(move |v: string| Trace::closure2((), v))),
            }),
            LrcPtr::new(Trace::Mut2 {
                l0: MutCell::new(true),
            }),
            LrcPtr::new(Trace::Mut3 {
                l0: MutCell::new(string("")),
            }),
            LrcPtr::new(Trace::Mut4 {
                l0: MutCell::new(match &v172 {
                    Trace::US1::US1_0(v172_0_0) => match &v172 {
                        Trace::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    _ => v0_1.clone(),
                }),
            }),
            match &v173 {
                Trace::US2::US2_0(v173_0_0) => Some(match &v173 {
                    Trace::US2::US2_0(x) => x.clone(),
                    _ => unreachable!(),
                }),
                _ => None::<i64>,
            },
        )
    }
    pub fn closure0(unitVar: (), unitVar_1: ()) {
        if Trace::TraceState::trace_state().get().clone().is_none() {
            let patternInput: (
                LrcPtr<Trace::Mut0>,
                LrcPtr<Trace::Mut1>,
                LrcPtr<Trace::Mut2>,
                LrcPtr<Trace::Mut3>,
                LrcPtr<Trace::Mut4>,
                Option<i64>,
            ) = Trace::method0(Trace::US0::US0_0);
            Trace::TraceState::trace_state().set(Some((
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
    pub fn method6(v0_1: Trace::US0) -> bool {
        let v3: () = {
            Trace::closure0((), ());
            ()
        };
        let patternInput: (
            LrcPtr<Trace::Mut0>,
            LrcPtr<Trace::Mut1>,
            LrcPtr<Trace::Mut2>,
            LrcPtr<Trace::Mut3>,
            LrcPtr<Trace::Mut4>,
            Option<i64>,
        ) = Trace::TraceState::trace_state().get().clone().unwrap();
        let v42: Trace::US0 = (patternInput.4.clone()).l0.get().clone();
        if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            (find(
                v0_1,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Trace::US0::US0_0, 0_i32)),
                    LrcPtr::new((Trace::US0::US0_1, 1_i32)),
                    LrcPtr::new((Trace::US0::US0_2, 2_i32)),
                    LrcPtr::new((Trace::US0::US0_3, 3_i32)),
                    LrcPtr::new((Trace::US0::US0_4, 4_i32)),
                ])))),
            )) >= (find(
                v42,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Trace::US0::US0_0, 0_i32)),
                    LrcPtr::new((Trace::US0::US0_1, 1_i32)),
                    LrcPtr::new((Trace::US0::US0_2, 2_i32)),
                    LrcPtr::new((Trace::US0::US0_3, 3_i32)),
                    LrcPtr::new((Trace::US0::US0_4, 4_i32)),
                ])))),
            ))
        }
    }
    pub fn closure7(unitVar: (), v0_1: i64) -> Trace::US2 {
        Trace::US2::US2_0(v0_1)
    }
    pub fn method8() -> Func1<i64, Trace::US2> {
        Func1::new(move |v: i64| Trace::closure7((), v))
    }
    pub fn method9() -> string {
        string("hh:mm:ss")
    }
    pub fn method10() -> string {
        string("HH:mm:ss")
    }
    pub fn method7(
        v0_1: LrcPtr<Trace::Mut0>,
        v1_1: LrcPtr<Trace::Mut1>,
        v2_1: LrcPtr<Trace::Mut2>,
        v3: LrcPtr<Trace::Mut3>,
        v4: LrcPtr<Trace::Mut4>,
        v5: Option<i64>,
    ) -> string {
        let v491: u64 = near_sdk::env::block_timestamp();
        let v510: Trace::US2 = defaultValue(Trace::US2::US2_1, map(Trace::method8(), v5));
        let v523: u64 = (match &v510 {
            Trace::US2::US2_0(v510_0_0) => {
                (v491)
                    - (match &v510 {
                        Trace::US2::US2_0(x) => x.clone(),
                        _ => unreachable!(),
                    } as u64)
            }
            _ => v491,
        }) / 1000000000_u64;
        let v524: u64 = (v523) % 60_u64;
        let v526: u64 = ((v523) / 60_u64) % 60_u64;
        let v528: u64 = ((v523) / 3600_u64) % 24_u64;
        let v530: std::string::String = format!("{:02}:{:02}:{:02}", v528, v526, v524);
        fable_library_rust::String_::fromString(v530)
    }
    pub fn method13() -> string {
        string("")
    }
    pub fn closure8(v0_1: LrcPtr<Trace::Mut3>, v1_1: string, unitVar: ()) {
        let v3: string = append((v0_1.l0.get().clone()), (v1_1));
        v0_1.l0.set(v3);
        ()
    }
    pub fn method12(v0_1: char) -> string {
        let v2_1: LrcPtr<Trace::Mut3> = LrcPtr::new(Trace::Mut3 {
            l0: MutCell::new(Trace::method13()),
        });
        let v9: () = {
            Trace::closure8(v2_1.clone(), sprintf!("{}", v0_1), ());
            ()
        };
        v2_1.l0.get().clone()
    }
    pub fn method14() -> string {
        string("\u{001b}[0m")
    }
    pub fn method11(v0_1: Trace::US0) -> string {
        let v5: Trace::US5 = if if let Trace::US0::US0_0 = &v0_1 {
            true
        } else {
            false
        } {
            Trace::US5::US5_0(string("Verbose"))
        } else {
            Trace::US5::US5_1
        };
        let v46: Trace::US5 = match &v5 {
            Trace::US5::US5_0(v5_0_0) => Trace::US5::US5_0(
                match &v5 {
                    Trace::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
            ),
            _ => {
                let v12: Trace::US5 = if if let Trace::US0::US0_1 = &v0_1 {
                    true
                } else {
                    false
                } {
                    Trace::US5::US5_0(string("Debug"))
                } else {
                    Trace::US5::US5_1
                };
                match &v12 {
                    Trace::US5::US5_0(v12_0_0) => Trace::US5::US5_0(
                        match &v12 {
                            Trace::US5::US5_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    _ => {
                        let v19: Trace::US5 = if if let Trace::US0::US0_2 = &v0_1 {
                            true
                        } else {
                            false
                        } {
                            Trace::US5::US5_0(string("Info"))
                        } else {
                            Trace::US5::US5_1
                        };
                        match &v19 {
                            Trace::US5::US5_0(v19_0_0) => Trace::US5::US5_0(
                                match &v19 {
                                    Trace::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => {
                                let v26: Trace::US5 = if if let Trace::US0::US0_3 = &v0_1 {
                                    true
                                } else {
                                    false
                                } {
                                    Trace::US5::US5_0(string("Warning"))
                                } else {
                                    Trace::US5::US5_1
                                };
                                match &v26 {
                                    Trace::US5::US5_0(v26_0_0) => Trace::US5::US5_0(
                                        match &v26 {
                                            Trace::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => {
                                        let v33: Trace::US5 = if if let Trace::US0::US0_4 = &v0_1 {
                                            true
                                        } else {
                                            false
                                        } {
                                            Trace::US5::US5_0(string("Critical"))
                                        } else {
                                            Trace::US5::US5_1
                                        };
                                        match &v33 {
                                            Trace::US5::US5_0(v33_0_0) => Trace::US5::US5_0(
                                                match &v33 {
                                                    Trace::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            ),
                                            _ => Trace::US5::US5_1,
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        };
        let v57: string = Trace::method12(getCharAt(
            toLower(match &v46 {
                Trace::US5::US5_0(v46_0_0) => match &v46 {
                    Trace::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                _ => panic!("{}", string("Option does not have a value."),),
            }),
            0_i32,
        ));
        let v194: &str = match &v0_1 {
            Trace::US0::US0_1 => inline_colorization::color_bright_blue,
            Trace::US0::US0_2 => inline_colorization::color_bright_green,
            Trace::US0::US0_0 => inline_colorization::color_bright_black,
            Trace::US0::US0_3 => inline_colorization::color_yellow,
            _ => inline_colorization::color_bright_red,
        };
        let v205: &str = &*v57;
        let v229: &str = inline_colorization::color_reset;
        let v231: std::string::String = format!("{}{}{}", v194, v205, v229);
        fable_library_rust::String_::fromString(v231)
    }
    pub fn method16(v0_1: string) -> string {
        let v2_1: LrcPtr<Trace::Mut3> = LrcPtr::new(Trace::Mut3 {
            l0: MutCell::new(Trace::method13()),
        });
        let v9: () = {
            Trace::closure8(v2_1.clone(), v0_1, ());
            ()
        };
        v2_1.l0.get().clone()
    }
    pub fn method17(v0_1: string) -> string {
        trimEndChars(
            trimStartChars(v0_1, toArray(empty::<char>())),
            toArray(ofArray(new_array(&[' ', '/']))),
        )
    }
    pub fn method15(
        v0_1: LrcPtr<Trace::Mut0>,
        v1_1: LrcPtr<Trace::Mut1>,
        v2_1: LrcPtr<Trace::Mut2>,
        v3: LrcPtr<Trace::Mut3>,
        v4: LrcPtr<Trace::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
        v9: string,
    ) -> string {
        let v10: string = Trace::method16(v9);
        Trace::method17(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            v8,
            v10
        ))
    }
    pub fn closure9(v0_1: LrcPtr<Trace::Mut0>, unitVar: ()) {
        let v2_1: i64 = (v0_1.l0.get().clone()) + 1_i64;
        v0_1.l0.set(v2_1);
        ()
    }
    pub fn closure11(v0_1: string, unitVar: ()) {
        printfn!("{0}", v0_1);
    }
    pub fn closure10(unitVar: (), v0_1: string) {
        let v3: () = {
            Trace::closure11(v0_1, ());
            ()
        };
        ()
    }
    pub fn method18(v0_1: string) {
        let v3: () = {
            Trace::closure0((), ());
            ()
        };
        let patternInput: (
            LrcPtr<Trace::Mut0>,
            LrcPtr<Trace::Mut1>,
            LrcPtr<Trace::Mut2>,
            LrcPtr<Trace::Mut3>,
            LrcPtr<Trace::Mut4>,
            Option<i64>,
        ) = Trace::TraceState::trace_state().get().clone().unwrap();
        let v27: LrcPtr<Trace::Mut3> = patternInput.3.clone();
        let v44: () = {
            Trace::closure9(patternInput.0.clone(), ());
            ()
        };
        let v60: string = if (v27.l0.get().clone()) == string("") {
            v0_1.clone()
        } else {
            if (v0_1.clone()) == string("") {
                v27.l0.get().clone()
            } else {
                append(
                    (append((v27.l0.get().clone()), string("\n"))),
                    (v0_1.clone()),
                )
            }
        };
        let v71: &str = &*v60.clone();
        let v95 = v71.chars();
        let v97 = v95;
        let v99: Vec<char> = v97.collect::<Vec<_>>();
        let v101: Vec<Vec<char>> = v99
            .chunks(15000)
            .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
            .collect::<Vec<_>>();
        let v103: bool = true;
        let _vec_map: Vec<_> = v101
            .into_iter()
            .map(|x| {
                //;
                let v105: Vec<char> = x;
                let v107: std::string::String = String::from_iter(v105);
                let v109: bool = true;
                v107
            })
            .collect::<Vec<_>>();
        let v111: Vec<std::string::String> = _vec_map;
        if if (v0_1.clone()) != string("") {
            (v111.clone().len() as i32) <= 1_i32
        } else {
            false
        } {
            v27.l0.set(v60);
            ()
        } else {
            v27.l0.set(string(""));
            {
                let v136: bool = true;
                v111.into_iter().for_each(|x| {
                    //;
                    let v138: std::string::String = x;
                    let v140: bool = true;
                    near_sdk::log!("{}", v138);
                    let v142: bool = true;
                    let v144: bool = true;
                }); //;
                ()
            }
        }
        ((patternInput.1.clone()).l0.get().clone())(v0_1)
    }
    pub fn closure6(v0_1: Trace::US0, v1_1: Func0<string>, v2_1: Func0<string>, unitVar: ()) {
        if Trace::method6(v0_1.clone()) {
            let v6: () = {
                Trace::closure0((), ());
                ()
            };
            let patternInput: (
                LrcPtr<Trace::Mut0>,
                LrcPtr<Trace::Mut1>,
                LrcPtr<Trace::Mut2>,
                LrcPtr<Trace::Mut3>,
                LrcPtr<Trace::Mut4>,
                Option<i64>,
            ) = Trace::TraceState::trace_state().get().clone().unwrap();
            let v32: Option<i64> = patternInput.5.clone();
            let v31: LrcPtr<Trace::Mut4> = patternInput.4.clone();
            let v30: LrcPtr<Trace::Mut3> = patternInput.3.clone();
            let v29: LrcPtr<Trace::Mut2> = patternInput.2.clone();
            let v28: LrcPtr<Trace::Mut1> = patternInput.1.clone();
            let v27: LrcPtr<Trace::Mut0> = patternInput.0.clone();
            let v45: string = Trace::method7(
                v27.clone(),
                v28.clone(),
                v29.clone(),
                v30.clone(),
                v31.clone(),
                v32.clone(),
            );
            let v46: string = Trace::method11(v0_1);
            let v47: string = v1_1();
            Trace::method18(if (v47.clone()) == string("") {
                string("")
            } else {
                Trace::method15(v27, v28, v29, v30, v31, v32, v45, v46, v47, v2_1())
            })
        };
    }
    pub fn closure5(v0_1: Trace::US0, v1_1: Func0<string>, v2_1: Func0<string>) {
        let v5: () = {
            Trace::closure6(v0_1, v1_1, v2_1, ());
            ()
        };
        ()
    }
    pub fn closure4(v0_1: Trace::US0, v1_1: Func0<string>) -> Func1<Func0<string>, ()> {
        Func1::new({
            let v0_1 = v0_1.clone();
            let v1_1 = v1_1.clone();
            move |v: Func0<string>| Trace::closure5(v0_1.clone(), v1_1.clone(), v)
        })
    }
    pub fn closure3(
        unitVar: (),
        v0_1: Trace::US0,
    ) -> Func1<Func0<string>, Func1<Func0<string>, ()>> {
        Func1::new({
            let v0_1 = v0_1.clone();
            move |v: Func0<string>| Trace::closure4(v0_1.clone(), v)
        })
    }
    pub fn v0() -> () {
        static v0: OnceInit<()> = OnceInit::new();
        v0.get_or_init(|| ()).clone()
    }
    pub fn v1() -> Func0<()> {
        static v1: OnceInit<Func0<()>> = OnceInit::new();
        v1.get_or_init(|| Func0::new(move || Trace::closure0((), ())))
            .clone()
    }
    pub fn v2() -> () {
        static v2: OnceInit<()> = OnceInit::new();
        v2.get_or_init(|| {
            (Trace::v1())();
            Trace::v0()
        })
        .clone()
    }
    pub fn v17() -> Func1<Trace::US0, Func1<Func0<string>, Func1<Func0<string>, ()>>> {
        static v17: OnceInit<Func1<Trace::US0, Func1<Func0<string>, Func1<Func0<string>, ()>>>> =
            OnceInit::new();
        v17.get_or_init(|| Func1::new(move |v: Trace::US0| Trace::closure3((), v)))
            .clone()
    }
    pub fn trace(x: Trace::US0) -> Func1<Func0<string>, Func1<Func0<string>, ()>> {
        (Trace::v17())(x)
    }
    on_startup!(());
}
