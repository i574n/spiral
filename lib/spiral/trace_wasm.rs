pub mod Trace {
    use super::*;
    use fable_library_rust::DateTime_::DateTime;
    use fable_library_rust::List_::empty;
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
    use fable_library_rust::Native_::on_startup;
    use fable_library_rust::NativeArray_::new_array;
    use fable_library_rust::Option_::defaultValue;
    use fable_library_rust::Option_::map;
    use fable_library_rust::Seq_::ofList;
    use fable_library_rust::String_::append;
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
        US4_6(Trace::US3),
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
    #[derive(Clone, Debug)]
    pub enum US6 {
        US6_0(
            LrcPtr<Trace::Mut0>,
            LrcPtr<Trace::Mut1>,
            LrcPtr<Trace::Mut2>,
            LrcPtr<Trace::Mut3>,
            LrcPtr<Trace::Mut4>,
            Option<i64>,
        ),
        US6_1,
    }
    impl core::fmt::Display for US6 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    pub fn method3(v0: string) -> string {
        v0
    }
    pub fn method4() -> string {
        string("")
    }
    pub fn closure1(unitVar: (), v0: string) -> Trace::US5 {
        Trace::US5::US5_0(v0)
    }
    pub fn method5() -> Func1<string, Trace::US5> {
        Func1::new(move |v: string| Trace::closure1((), v))
    }
    pub fn method2(v0: string) -> string {
        panic!(
            "{}",
            sprintf!(
                "env.get_environment_variable / target: {} / var: {}",
                Trace::US4::US4_4(Trace::US3::US3_1),
                v0
            ),
        )
    }
    pub fn method1() -> (Trace::US1, Trace::US2) {
        let v1: string = Trace::method2(string("TRACE_LEVEL"));
        let v6: string = toLower(string("Critical"));
        let v13: string = toLower(string("Warning"));
        let v20: string = toLower(string("Info"));
        let v27: string = toLower(string("Debug"));
        let v34: string = toLower(string("Verbose"));
        let v41: Trace::US1 = if string("Verbose") == (v1.clone()) {
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
                    let v48: Trace::US1 = if string("Debug") == (v1.clone()) {
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
                            let v55: Trace::US1 = if string("Info") == (v1.clone()) {
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
                                    let v62: Trace::US1 = if string("Warning") == (v1.clone()) {
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
                                                if string("Critical") == (v1.clone()) {
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
                                                        if (v34.clone()) == (v1.clone()) {
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
                                                                == (v1.clone())
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
                                                                        == (v1.clone())
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
                                                                                    (v1.clone())
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
                                                                                            (v1.clone())
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
                Trace::US2::US2_0({
                    let _arg: DateTime = DateTime::now();
                    _arg.ticks()
                })
            },
        )
    }
    pub fn closure2(unitVar: (), v0: string) {
        ();
    }
    pub fn method0(
        v0: Trace::US0,
    ) -> (
        LrcPtr<Trace::Mut0>,
        LrcPtr<Trace::Mut1>,
        LrcPtr<Trace::Mut2>,
        LrcPtr<Trace::Mut3>,
        LrcPtr<Trace::Mut4>,
        Option<i64>,
    ) {
        let _run_target_args__v3: (Trace::US1, Trace::US2) = (Trace::US1::US1_1, Trace::US2::US2_1);
        let v185: Trace::US2 = _run_target_args__v3.1.clone();
        let v184: Trace::US1 = _run_target_args__v3.0.clone();
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
                l0: MutCell::new(match &v184 {
                    Trace::US1::US1_0(v184_0_0) => match &v184 {
                        Trace::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    _ => v0.clone(),
                }),
            }),
            match &v185 {
                Trace::US2::US2_0(v185_0_0) => Some(match &v185 {
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
    pub fn closure7(unitVar: (), v0: i64) -> Trace::US2 {
        Trace::US2::US2_0(v0)
    }
    pub fn method7() -> Func1<i64, Trace::US2> {
        Func1::new(move |v: i64| Trace::closure7((), v))
    }
    pub fn method8() -> string {
        string("hh:mm:ss")
    }
    pub fn method9() -> string {
        string("HH:mm:ss")
    }
    pub fn method6(
        v0: LrcPtr<Trace::Mut0>,
        v1: LrcPtr<Trace::Mut1>,
        v2: LrcPtr<Trace::Mut2>,
        v3: LrcPtr<Trace::Mut3>,
        v4: LrcPtr<Trace::Mut4>,
        v5: Option<i64>,
    ) -> string {
        let v451: Trace::US2 = defaultValue(Trace::US2::US2_1, map(Trace::method7(), v5));
        let v605: DateTime = match &v451 {
            Trace::US2::US2_0(v451_0_0) => {
                let v534: TimeSpan = TimeSpan::new_ticks(
                    ({
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    }) - (match &v451 {
                        Trace::US2::US2_0(x) => x.clone(),
                        _ => unreachable!(),
                    }),
                );
                DateTime::new_ymdhms_milli(
                    1_i32,
                    1_i32,
                    1_i32,
                    v534.hours(),
                    v534.minutes(),
                    v534.seconds(),
                    v534.milliseconds(),
                )
            }
            _ => DateTime::now(),
        };
        let v606: string = Trace::method8();
        let provider: string = if (v606.clone()) == string("") {
            string("M-d-y hh:mm:ss tt")
        } else {
            v606
        };
        v605.toString(provider)
    }
    pub fn method12() -> string {
        string("")
    }
    pub fn closure8(v0: LrcPtr<Trace::Mut3>, v1: string, unitVar: ()) {
        let v4: string = append((v0.l0.get().clone()), (v1));
        v0.l0.set(v4);
        ()
    }
    pub fn method11(v0: char) -> string {
        let v2: LrcPtr<Trace::Mut3> = LrcPtr::new(Trace::Mut3 {
            l0: MutCell::new(Trace::method12()),
        });
        let v17: () = {
            Trace::closure8(v2.clone(), sprintf!("{}", v0), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method13() -> string {
        string("\u{001b}[0m")
    }
    pub fn method10(v0: Trace::US0) -> string {
        let v5: Trace::US5 = if if let Trace::US0::US0_0 = &v0 {
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
                let v12: Trace::US5 = if if let Trace::US0::US0_1 = &v0 {
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
                        let v19: Trace::US5 = if if let Trace::US0::US0_2 = &v0 {
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
                                let v26: Trace::US5 = if if let Trace::US0::US0_3 = &v0 {
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
                                        let v33: Trace::US5 = if if let Trace::US0::US0_4 = &v0 {
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
        let v57: string = Trace::method11(getCharAt(
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
        let v173: &str = match &v0 {
            Trace::US0::US0_1 => inline_colorization::color_bright_blue,
            Trace::US0::US0_2 => inline_colorization::color_bright_green,
            Trace::US0::US0_0 => inline_colorization::color_bright_black,
            Trace::US0::US0_3 => inline_colorization::color_yellow,
            _ => inline_colorization::color_bright_red,
        };
        let v182: &str = &*v57;
        let v211: &str = inline_colorization::color_reset;
        let v213: std::string::String = format!("{}{}{}", v173, v182, v211);
        fable_library_rust::String_::fromString(v213)
    }
    pub fn method15(v0: string) -> string {
        let v2: LrcPtr<Trace::Mut3> = LrcPtr::new(Trace::Mut3 {
            l0: MutCell::new(Trace::method12()),
        });
        let v14_1: () = {
            Trace::closure8(v2.clone(), v0, ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method16(v0: string) -> string {
        trimEndChars(
            trimStartChars(v0, toArray(empty::<char>())),
            toArray(ofArray(new_array(&[' ', '/']))),
        )
    }
    pub fn method14(
        v0: LrcPtr<Trace::Mut0>,
        v1: LrcPtr<Trace::Mut1>,
        v2: LrcPtr<Trace::Mut2>,
        v3: LrcPtr<Trace::Mut3>,
        v4: LrcPtr<Trace::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
        v9: string,
    ) -> string {
        let v10: string = Trace::method15(v9);
        Trace::method16(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    (v8),
                )),
                string(" / "),
            )),
            (v10),
        ))
    }
    pub fn closure9(v0: LrcPtr<Trace::Mut0>, unitVar: ()) {
        let v2: i64 = (v0.l0.get().clone()) + 1_i64;
        v0.l0.set(v2);
        ()
    }
    pub fn closure11(v0: string, unitVar: ()) {
        printfn!("{0}", v0);
    }
    pub fn closure10(unitVar: (), v0: string) {
        let v4: () = {
            Trace::closure11(v0, ());
            ()
        };
        ()
    }
    pub fn closure6(v0: Trace::US0, v1: Func0<string>, v2: Func0<string>, unitVar: ()) {
        fn v18() {
            Trace::closure0((), ());
        }
        let v19: () = {
            v18();
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
        let v60: Trace::US0 = (patternInput.4.clone()).l0.get().clone();
        let v306: Trace::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            (find(
                v0.clone(),
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Trace::US0::US0_0, 0_i32)),
                    LrcPtr::new((Trace::US0::US0_1, 1_i32)),
                    LrcPtr::new((Trace::US0::US0_2, 2_i32)),
                    LrcPtr::new((Trace::US0::US0_3, 3_i32)),
                    LrcPtr::new((Trace::US0::US0_4, 4_i32)),
                ])))),
            )) >= (find(
                v60,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Trace::US0::US0_0, 0_i32)),
                    LrcPtr::new((Trace::US0::US0_1, 1_i32)),
                    LrcPtr::new((Trace::US0::US0_2, 2_i32)),
                    LrcPtr::new((Trace::US0::US0_3, 3_i32)),
                    LrcPtr::new((Trace::US0::US0_4, 4_i32)),
                ])))),
            ))
        }) == false
        {
            Trace::US6::US6_1
        } else {
            let v84: () = {
                v18();
                ()
            };
            let patternInput_1: (
                LrcPtr<Trace::Mut0>,
                LrcPtr<Trace::Mut1>,
                LrcPtr<Trace::Mut2>,
                LrcPtr<Trace::Mut3>,
                LrcPtr<Trace::Mut4>,
                Option<i64>,
            ) = Trace::TraceState::trace_state().get().clone().unwrap();
            let v112: Option<i64> = patternInput_1.5.clone();
            let v111: LrcPtr<Trace::Mut4> = patternInput_1.4.clone();
            let v110: LrcPtr<Trace::Mut3> = patternInput_1.3.clone();
            let v109: LrcPtr<Trace::Mut2> = patternInput_1.2.clone();
            let v108: LrcPtr<Trace::Mut1> = patternInput_1.1.clone();
            let v107: LrcPtr<Trace::Mut0> = patternInput_1.0.clone();
            let v125: string = Trace::method6(
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                v111.clone(),
                v112.clone(),
            );
            let v126: string = Trace::method10(v0);
            let v127: string = v1();
            let v132: string = if (v127.clone()) == string("") {
                string("")
            } else {
                Trace::method14(v107, v108, v109, v110, v111, v112, v125, v126, v127, v2())
            };
            let v148: () = {
                v18();
                ()
            };
            let patternInput_2: (
                LrcPtr<Trace::Mut0>,
                LrcPtr<Trace::Mut1>,
                LrcPtr<Trace::Mut2>,
                LrcPtr<Trace::Mut3>,
                LrcPtr<Trace::Mut4>,
                Option<i64>,
            ) = Trace::TraceState::trace_state().get().clone().unwrap();
            let v172: LrcPtr<Trace::Mut1> = patternInput_2.1.clone();
            let v171: LrcPtr<Trace::Mut0> = patternInput_2.0.clone();
            let v193: () = {
                Trace::closure9(v171.clone(), ());
                ()
            };
            println!("{}", v132.clone());
            (v172.l0.get().clone())(v132);
            Trace::US6::US6_0(
                v171,
                v172,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn closure5(v0: Trace::US0, v1: Func0<string>, v2: Func0<string>) {
        let v322: () = {
            Trace::closure6(v0, v1, v2, ());
            ()
        };
        ()
    }
    pub fn closure4(v0: Trace::US0, v1: Func0<string>) -> Func1<Func0<string>, ()> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            move |v: Func0<string>| Trace::closure5(v0.clone(), v1.clone(), v)
        })
    }
    pub fn closure3(unitVar: (), v0: Trace::US0) -> Func1<Func0<string>, Func1<Func0<string>, ()>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: Func0<string>| Trace::closure4(v0.clone(), v)
        })
    }
    pub fn v14() -> () {
        static v14: OnceInit<()> = OnceInit::new();
        v14.get_or_init(|| ()).clone()
    }
    pub fn v15() -> Func0<()> {
        static v15: OnceInit<Func0<()>> = OnceInit::new();
        v15.get_or_init(|| Func0::new(move || Trace::closure0((), ())))
            .clone()
    }
    pub fn v16() -> () {
        static v16: OnceInit<()> = OnceInit::new();
        v16.get_or_init(|| {
            (Trace::v15())();
            Trace::v14()
        })
        .clone()
    }
    pub fn v31() -> Func1<Trace::US0, Func1<Func0<string>, Func1<Func0<string>, ()>>> {
        static v31: OnceInit<Func1<Trace::US0, Func1<Func0<string>, Func1<Func0<string>, ()>>>> =
            OnceInit::new();
        v31.get_or_init(|| Func1::new(move |v: Trace::US0| Trace::closure3((), v)))
            .clone()
    }
    pub fn trace(x: Trace::US0) -> Func1<Func0<string>, Func1<Func0<string>, ()>> {
        (Trace::v31())(x)
    }
    on_startup!(());
}
