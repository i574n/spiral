pub mod Networking {
    use super::*;
    use fable_library_rust::Async_::Async;
    use fable_library_rust::Choice_::Choice_2;
    use fable_library_rust::DateTime_::DateTime;
    use fable_library_rust::List_::empty;
    use fable_library_rust::List_::ofArray;
    use fable_library_rust::List_::toArray;
    use fable_library_rust::Map_::find;
    use fable_library_rust::Map_::ofSeq;
    use fable_library_rust::Native_::Any;
    use fable_library_rust::Native_::Arc;
    use fable_library_rust::Native_::Func0;
    use fable_library_rust::Native_::Func1;
    use fable_library_rust::Native_::LrcPtr;
    use fable_library_rust::Native_::MutCell;
    use fable_library_rust::Native_::OnceInit;
    use fable_library_rust::Native_::getNull;
    use fable_library_rust::Native_::on_startup;
    use fable_library_rust::Native_::unbox;
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
                    LrcPtr<Networking::Mut0>,
                    LrcPtr<Networking::Mut1>,
                    LrcPtr<Networking::Mut2>,
                    LrcPtr<Networking::Mut3>,
                    LrcPtr<Networking::Mut4>,
                    Option<i64>,
                )>,
            >,
        > {
            static trace_state: OnceInit<
                LrcPtr<
                    MutCell<
                        Option<(
                            LrcPtr<Networking::Mut0>,
                            LrcPtr<Networking::Mut1>,
                            LrcPtr<Networking::Mut2>,
                            LrcPtr<Networking::Mut3>,
                            LrcPtr<Networking::Mut4>,
                            Option<i64>,
                        )>,
                    >,
                >,
            > = OnceInit::new();
            trace_state
                .get_or_init(|| {
                    LrcPtr::new(MutCell::new(
                        None::<(
                            LrcPtr<Networking::Mut0>,
                            LrcPtr<Networking::Mut1>,
                            LrcPtr<Networking::Mut2>,
                            LrcPtr<Networking::Mut3>,
                            LrcPtr<Networking::Mut4>,
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
        pub l0: MutCell<Networking::US0>,
    }
    impl core::fmt::Display for Mut4 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US1 {
        US1_0(Networking::US0),
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
        US4_0(Networking::US3),
        US4_1(Networking::US3),
        US4_2(Networking::US3),
        US4_3(Networking::US3),
        US4_4(Networking::US3),
        US4_5(Networking::US3),
        US4_6(Networking::US3),
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
            LrcPtr<Networking::Mut0>,
            LrcPtr<Networking::Mut1>,
            LrcPtr<Networking::Mut2>,
            LrcPtr<Networking::Mut3>,
            LrcPtr<Networking::Mut4>,
            Option<i64>,
        ),
        US6_1,
    }
    impl core::fmt::Display for US6 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US7 {
        US7_0(bool),
        US7_1,
    }
    impl core::fmt::Display for US7 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US8 {
        US8_0(bool),
        US8_1(LrcPtr<Exception>),
    }
    impl core::fmt::Display for US8 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US9 {
        US9_0(bool),
        US9_1(LrcPtr<Exception>),
    }
    impl core::fmt::Display for US9 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US10 {
        US10_0(i32),
        US10_1,
    }
    impl core::fmt::Display for US10 {
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
    pub fn closure1(unitVar: (), v0: string) -> Networking::US5 {
        Networking::US5::US5_0(v0)
    }
    pub fn method5() -> Func1<string, Networking::US5> {
        Func1::new(move |v: string| Networking::closure1((), v))
    }
    pub fn method2(v0: string) -> string {
        let v3: string = Networking::method3(v0);
        let v5: Result<std::string::String, std::env::VarError> = std::env::var(&*v3);
        let v7: bool = true;
        let _result_map_ = v5.map(|x| {
            //;
            let v9: std::string::String = x;
            let v11: string = fable_library_rust::String_::fromString(v9);
            let v13: bool = true;
            v11
        });
        let v15_1: Result<string, std::env::VarError> = _result_map_;
        let v16_1: string = Networking::method4();
        v15_1.unwrap_or(v16_1)
    }
    pub fn method1() -> (Networking::US1, Networking::US2) {
        let v1: string = Networking::method2(string("TRACE_LEVEL"));
        let v6: string = toLower(string("Critical"));
        let v13: string = toLower(string("Warning"));
        let v20: string = toLower(string("Info"));
        let v27: string = toLower(string("Debug"));
        let v34_1: string = toLower(string("Verbose"));
        let v41: Networking::US1 = if string("Verbose") == (v1.clone()) {
            Networking::US1::US1_0(Networking::US0::US0_0)
        } else {
            Networking::US1::US1_1
        };
        (
            match &v41 {
                Networking::US1::US1_0(v41_0_0) => Networking::US1::US1_0(
                    match &v41 {
                        Networking::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                ),
                _ => {
                    let v48: Networking::US1 = if string("Debug") == (v1.clone()) {
                        Networking::US1::US1_0(Networking::US0::US0_1)
                    } else {
                        Networking::US1::US1_1
                    };
                    match &v48 {
                        Networking::US1::US1_0(v48_0_0) => Networking::US1::US1_0(
                            match &v48 {
                                Networking::US1::US1_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v55: Networking::US1 = if string("Info") == (v1.clone()) {
                                Networking::US1::US1_0(Networking::US0::US0_2)
                            } else {
                                Networking::US1::US1_1
                            };
                            match &v55 {
                                Networking::US1::US1_0(v55_0_0) => Networking::US1::US1_0(
                                    match &v55 {
                                        Networking::US1::US1_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v62: Networking::US1 = if string("Warning") == (v1.clone())
                                    {
                                        Networking::US1::US1_0(Networking::US0::US0_3)
                                    } else {
                                        Networking::US1::US1_1
                                    };
                                    match &v62 {
                                        Networking::US1::US1_0(v62_0_0) => Networking::US1::US1_0(
                                            match &v62 {
                                                Networking::US1::US1_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        ),
                                        _ => {
                                            let v69: Networking::US1 =
                                                if string("Critical") == (v1.clone()) {
                                                    Networking::US1::US1_0(Networking::US0::US0_4)
                                                } else {
                                                    Networking::US1::US1_1
                                                };
                                            match &v69 {
                                                Networking::US1::US1_0(v69_0_0) => {
                                                    Networking::US1::US1_0(
                                                        match &v69 {
                                                            Networking::US1::US1_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => {
                                                    let v76: Networking::US1 =
                                                        if (v34_1.clone()) == (v1.clone()) {
                                                            Networking::US1::US1_0(
                                                                Networking::US0::US0_0,
                                                            )
                                                        } else {
                                                            Networking::US1::US1_1
                                                        };
                                                    match &v76 {
                                                        Networking::US1::US1_0(v76_0_0) => {
                                                            Networking::US1::US1_0(
                                                                match &v76 {
                                                                    Networking::US1::US1_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            let v83: Networking::US1 =
                                                                if (v27.clone()) == (v1.clone()) {
                                                                    Networking::US1::US1_0(
                                                                        Networking::US0::US0_1,
                                                                    )
                                                                } else {
                                                                    Networking::US1::US1_1
                                                                };
                                                            match &v83 {
                                                             Networking::US1::US1_0(v83_0_0)
                                                             =>
                                                             Networking::US1::US1_0(match &v83
                                                                                        {
                                                                                        Networking::US1::US1_0(x)
                                                                                        =>
                                                                                        x.clone(),
                                                                                        _
                                                                                        =>
                                                                                        unreachable!(),
                                                                                    }.clone()),
                                                             _ => {
                                                                 let v90:
                                                                         Networking::US1 =
                                                                     if (v20.clone())
                                                                            ==
                                                                            (v1.clone())
                                                                        {
                                                                         Networking::US1::US1_0(Networking::US0::US0_2)
                                                                     } else {
                                                                         Networking::US1::US1_1
                                                                     };
                                                                 match &v90 {
                                                                     Networking::US1::US1_0(v90_0_0)
                                                                     =>
                                                                     Networking::US1::US1_0(match &v90
                                                                                                {
                                                                                                Networking::US1::US1_0(x)
                                                                                                =>
                                                                                                x.clone(),
                                                                                                _
                                                                                                =>
                                                                                                unreachable!(),
                                                                                            }.clone()),
                                                                     _ => {
                                                                         let v97:
                                                                                 Networking::US1 =
                                                                             if (v13.clone())
                                                                                    ==
                                                                                    (v1.clone())
                                                                                {
                                                                                 Networking::US1::US1_0(Networking::US0::US0_3)
                                                                             } else {
                                                                                 Networking::US1::US1_1
                                                                             };
                                                                         match &v97
                                                                             {
                                                                             Networking::US1::US1_0(v97_0_0)
                                                                             =>
                                                                             Networking::US1::US1_0(match &v97
                                                                                                        {
                                                                                                        Networking::US1::US1_0(x)
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
                                                                                         Networking::US1 =
                                                                                     if (v6.clone())
                                                                                            ==
                                                                                            (v1.clone())
                                                                                        {
                                                                                         Networking::US1::US1_0(Networking::US0::US0_4)
                                                                                     } else {
                                                                                         Networking::US1::US1_1
                                                                                     };
                                                                                 match &v104
                                                                                     {
                                                                                     Networking::US1::US1_0(v104_0_0)
                                                                                     =>
                                                                                     Networking::US1::US1_0(match &v104
                                                                                                                {
                                                                                                                Networking::US1::US1_0(x)
                                                                                                                =>
                                                                                                                x.clone(),
                                                                                                                _
                                                                                                                =>
                                                                                                                unreachable!(),
                                                                                                            }.clone()),
                                                                                     _
                                                                                     =>
                                                                                     Networking::US1::US1_1,
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
            if (Networking::method2(string("AUTOMATION"))) != string("True") {
                Networking::US2::US2_1
            } else {
                Networking::US2::US2_0({
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
        v0: Networking::US0,
    ) -> (
        LrcPtr<Networking::Mut0>,
        LrcPtr<Networking::Mut1>,
        LrcPtr<Networking::Mut2>,
        LrcPtr<Networking::Mut3>,
        LrcPtr<Networking::Mut4>,
        Option<i64>,
    ) {
        let patternInput: (Networking::US1, Networking::US2) = Networking::method1();
        let _run_target_args__v3: (Networking::US1, Networking::US2) =
            (patternInput.0.clone(), patternInput.1.clone());
        let v185: Networking::US2 = _run_target_args__v3.1.clone();
        let v184: Networking::US1 = _run_target_args__v3.0.clone();
        (
            LrcPtr::new(Networking::Mut0 {
                l0: MutCell::new(1_i64),
            }),
            LrcPtr::new(Networking::Mut1 {
                l0: MutCell::new(Func1::new(move |v: string| Networking::closure2((), v))),
            }),
            LrcPtr::new(Networking::Mut2 {
                l0: MutCell::new(true),
            }),
            LrcPtr::new(Networking::Mut3 {
                l0: MutCell::new(string("")),
            }),
            LrcPtr::new(Networking::Mut4 {
                l0: MutCell::new(match &v184 {
                    Networking::US1::US1_0(v184_0_0) => match &v184 {
                        Networking::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    _ => v0.clone(),
                }),
            }),
            match &v185 {
                Networking::US2::US2_0(v185_0_0) => Some(match &v185 {
                    Networking::US2::US2_0(x) => x.clone(),
                    _ => unreachable!(),
                }),
                _ => None::<i64>,
            },
        )
    }
    pub fn closure0(unitVar: (), unitVar_1: ()) {
        if Networking::TraceState::trace_state()
            .get()
            .clone()
            .is_none()
        {
            let patternInput: (
                LrcPtr<Networking::Mut0>,
                LrcPtr<Networking::Mut1>,
                LrcPtr<Networking::Mut2>,
                LrcPtr<Networking::Mut3>,
                LrcPtr<Networking::Mut4>,
                Option<i64>,
            ) = Networking::method0(Networking::US0::US0_0);
            Networking::TraceState::trace_state().set(Some((
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
    pub fn closure6(unitVar: (), v0: i64) -> Networking::US2 {
        Networking::US2::US2_0(v0)
    }
    pub fn method9() -> Func1<i64, Networking::US2> {
        Func1::new(move |v: i64| Networking::closure6((), v))
    }
    pub fn method10() -> string {
        string("hh:mm:ss")
    }
    pub fn method11() -> string {
        string("HH:mm:ss")
    }
    pub fn method8(
        v0: LrcPtr<Networking::Mut0>,
        v1: LrcPtr<Networking::Mut1>,
        v2: LrcPtr<Networking::Mut2>,
        v3: LrcPtr<Networking::Mut3>,
        v4: LrcPtr<Networking::Mut4>,
        v5: Option<i64>,
    ) -> string {
        let v241: Networking::US2 =
            defaultValue(Networking::US2::US2_1, map(Networking::method9(), v5));
        let v395: DateTime = match &v241 {
            Networking::US2::US2_0(v241_0_0) => {
                let v324: TimeSpan = TimeSpan::new_ticks(
                    ({
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    }) - (match &v241 {
                        Networking::US2::US2_0(x) => x.clone(),
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
        let v396: string = Networking::method10();
        let provider: string = if (v396.clone()) == string("") {
            string("M-d-y hh:mm:ss tt")
        } else {
            v396
        };
        v395.toString(provider)
    }
    pub fn method14() -> string {
        string("")
    }
    pub fn closure7(v0: LrcPtr<Networking::Mut3>, v1: string, unitVar: ()) {
        let v4: string = append(v0.l0.get().clone(), v1);
        v0.l0.set(v4);
        ()
    }
    pub fn method13(v0: char) -> string {
        let v2: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method14()),
        });
        let v17: () = {
            Networking::closure7(v2.clone(), sprintf!("{}", v0), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method12() -> string {
        let v3: &str = inline_colorization::color_bright_black;
        let v10: std::string::String = String::from(v3);
        let v139: string = append(
            fable_library_rust::String_::fromString(v10),
            Networking::method13(getCharAt(toLower(string("Verbose")), 0_i32)),
        );
        let v145: &str = inline_colorization::color_reset;
        let v152: std::string::String = String::from(v145);
        append(v139, fable_library_rust::String_::fromString(v152))
    }
    pub fn method16(v0: i32, v1: string) -> string {
        let v3: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method14()),
        });
        let v17: () = {
            Networking::closure7(v3.clone(), string("{ "), ());
            ()
        };
        let v36: () = {
            Networking::closure7(v3.clone(), string("port"), ());
            ()
        };
        let v55: () = {
            Networking::closure7(v3.clone(), string(" = "), ());
            ()
        };
        let v75: () = {
            Networking::closure7(v3.clone(), sprintf!("{}", v0), ());
            ()
        };
        let v94: () = {
            Networking::closure7(v3.clone(), string("; "), ());
            ()
        };
        let v113: () = {
            Networking::closure7(v3.clone(), string("ex"), ());
            ()
        };
        let v130: () = {
            Networking::closure7(v3.clone(), string(" = "), ());
            ()
        };
        let v147: () = {
            Networking::closure7(v3.clone(), v1, ());
            ()
        };
        let v166: () = {
            Networking::closure7(v3.clone(), string(" }"), ());
            ()
        };
        v3.l0.get().clone()
    }
    pub fn method17(v0: string) -> string {
        trimEndChars(
            trimStartChars(v0, toArray(empty::<char>())),
            toArray(ofArray(new_array(&[' ', '/']))),
        )
    }
    pub fn method15(
        v0: LrcPtr<Networking::Mut0>,
        v1: LrcPtr<Networking::Mut1>,
        v2: LrcPtr<Networking::Mut2>,
        v3: LrcPtr<Networking::Mut3>,
        v4: LrcPtr<Networking::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i32,
        v9: string,
    ) -> string {
        let v10: string = Networking::method16(v8, v9);
        Networking::method17(append(
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("networking.test_port_open"),
                ),
                string(" / "),
            ),
            v10,
        ))
    }
    pub fn closure8(v0: LrcPtr<Networking::Mut0>, unitVar: ()) {
        let v2: i64 = (v0.l0.get().clone()) + 1_i64;
        v0.l0.set(v2);
        ()
    }
    pub fn closure10(v0: string, unitVar: ()) {
        printfn!("{0}", v0);
    }
    pub fn closure9(unitVar: (), v0: string) {
        let v4: () = {
            Networking::closure10(v0, ());
            ()
        };
        ()
    }
    pub fn closure5(v0: i32, v1: LrcPtr<Exception>, unitVar: ()) {
        fn v17() {
            Networking::closure0((), ());
        }
        let v18: () = {
            v17();
            ()
        };
        let patternInput: (
            LrcPtr<Networking::Mut0>,
            LrcPtr<Networking::Mut1>,
            LrcPtr<Networking::Mut2>,
            LrcPtr<Networking::Mut3>,
            LrcPtr<Networking::Mut4>,
            Option<i64>,
        ) = Networking::TraceState::trace_state().get().clone().unwrap();
        let v59: Networking::US0 = (patternInput.4.clone()).l0.get().clone();
        let v338: Networking::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            0_i32
                >= (find(
                    v59,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Networking::US0::US0_0, 0_i32)),
                        LrcPtr::new((Networking::US0::US0_1, 1_i32)),
                        LrcPtr::new((Networking::US0::US0_2, 2_i32)),
                        LrcPtr::new((Networking::US0::US0_3, 3_i32)),
                        LrcPtr::new((Networking::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            Networking::US6::US6_1
        } else {
            let v82: () = {
                v17();
                ()
            };
            let patternInput_1: (
                LrcPtr<Networking::Mut0>,
                LrcPtr<Networking::Mut1>,
                LrcPtr<Networking::Mut2>,
                LrcPtr<Networking::Mut3>,
                LrcPtr<Networking::Mut4>,
                Option<i64>,
            ) = Networking::TraceState::trace_state().get().clone().unwrap();
            let v110: Option<i64> = patternInput_1.5.clone();
            let v109: LrcPtr<Networking::Mut4> = patternInput_1.4.clone();
            let v108: LrcPtr<Networking::Mut3> = patternInput_1.3.clone();
            let v107: LrcPtr<Networking::Mut2> = patternInput_1.2.clone();
            let v106: LrcPtr<Networking::Mut1> = patternInput_1.1.clone();
            let v105: LrcPtr<Networking::Mut0> = patternInput_1.0.clone();
            let v164: string = Networking::method15(
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                Networking::method8(v105, v106, v107, v108, v109, v110),
                Networking::method12(),
                v0,
                sprintf!("{:?}", v1),
            );
            let v180: () = {
                v17();
                ()
            };
            let patternInput_2: (
                LrcPtr<Networking::Mut0>,
                LrcPtr<Networking::Mut1>,
                LrcPtr<Networking::Mut2>,
                LrcPtr<Networking::Mut3>,
                LrcPtr<Networking::Mut4>,
                Option<i64>,
            ) = Networking::TraceState::trace_state().get().clone().unwrap();
            let v204: LrcPtr<Networking::Mut1> = patternInput_2.1.clone();
            let v203: LrcPtr<Networking::Mut0> = patternInput_2.0.clone();
            let v225: () = {
                Networking::closure8(v203.clone(), ());
                ()
            };
            println!("{}", v164.clone());
            (v204.l0.get().clone())(v164);
            Networking::US6::US6_0(
                v203,
                v204,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method7(v0: string, v1: i32) -> Arc<Async<bool>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method6(v0: string, v1: i32) -> Arc<Async<bool>> {
        Networking::method7(v0, v1)
    }
    pub fn closure4(v0: string, v1: i32) -> Arc<Async<bool>> {
        Networking::method6(v0, v1)
    }
    pub fn closure3(unitVar: (), v0: string) -> Func1<i32, Arc<Async<bool>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: i32| Networking::closure4(v0.clone(), v)
        })
    }
    pub fn closure15(unitVar: (), v0: bool) -> Networking::US8 {
        Networking::US8::US8_0(v0)
    }
    pub fn method22() -> Func1<bool, Networking::US8> {
        Func1::new(move |v: bool| Networking::closure15((), v))
    }
    pub fn closure16(unitVar: (), v0: LrcPtr<Exception>) -> Networking::US8 {
        Networking::US8::US8_1(v0)
    }
    pub fn method23() -> Func1<LrcPtr<Exception>, Networking::US8> {
        Func1::new(move |v: LrcPtr<Exception>| Networking::closure16((), v))
    }
    pub fn closure14(
        unitVar: (),
        v0: LrcPtr<Choice_2<bool, LrcPtr<Exception>>>,
    ) -> Networking::US8 {
        unbox::<Networking::US8>(fable_library_rust::Native_::getZero())
    }
    pub fn method25(
        v0: Func1<LrcPtr<Choice_2<bool, LrcPtr<Exception>>>, Networking::US8>,
        v1: Arc<Async<LrcPtr<Choice_2<bool, LrcPtr<Exception>>>>>,
    ) -> Arc<Async<Networking::US8>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method24(
        v0: Func1<LrcPtr<Choice_2<bool, LrcPtr<Exception>>>, Networking::US8>,
        v1: Arc<Async<LrcPtr<Choice_2<bool, LrcPtr<Exception>>>>>,
    ) -> Arc<Async<Networking::US8>> {
        Networking::method25(v0, v1)
    }
    pub fn closure17(unitVar: (), v0: Networking::US8) -> Networking::US9 {
        match &v0 {
            Networking::US8::US8_1(v0_1_0) => Networking::US9::US9_1(v0_1_0.clone()),
            Networking::US8::US8_0(v0_0_0) => Networking::US9::US9_0(v0_0_0.clone()),
        }
    }
    pub fn method27(
        v0: Func1<Networking::US8, Networking::US9>,
        v1: Arc<Async<Networking::US8>>,
    ) -> Arc<Async<Networking::US9>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method26(
        v0: Func1<Networking::US8, Networking::US9>,
        v1: Arc<Async<Networking::US8>>,
    ) -> Arc<Async<Networking::US9>> {
        Networking::method27(v0, v1)
    }
    pub fn method29(v0: i32) -> string {
        let v2: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method14()),
        });
        let v16_1: () = {
            Networking::closure7(v2.clone(), string("{ "), ());
            ()
        };
        let v35: () = {
            Networking::closure7(v2.clone(), string("timeout"), ());
            ()
        };
        let v54: () = {
            Networking::closure7(v2.clone(), string(" = "), ());
            ()
        };
        let v74: () = {
            Networking::closure7(v2.clone(), sprintf!("{}", v0), ());
            ()
        };
        let v93: () = {
            Networking::closure7(v2.clone(), string(" }"), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method28(
        v0: LrcPtr<Networking::Mut0>,
        v1: LrcPtr<Networking::Mut1>,
        v2: LrcPtr<Networking::Mut2>,
        v3: LrcPtr<Networking::Mut3>,
        v4: LrcPtr<Networking::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i32,
    ) -> string {
        let v9: string = Networking::method29(v8);
        Networking::method17(append(
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("async.run_with_timeout_async"),
                ),
                string(" / "),
            ),
            v9,
        ))
    }
    pub fn closure19(v0: i32, unitVar: ()) {
        fn v16_1() {
            Networking::closure0((), ());
        }
        let v17: () = {
            v16_1();
            ()
        };
        let patternInput: (
            LrcPtr<Networking::Mut0>,
            LrcPtr<Networking::Mut1>,
            LrcPtr<Networking::Mut2>,
            LrcPtr<Networking::Mut3>,
            LrcPtr<Networking::Mut4>,
            Option<i64>,
        ) = Networking::TraceState::trace_state().get().clone().unwrap();
        let v58: Networking::US0 = (patternInput.4.clone()).l0.get().clone();
        let v298: Networking::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            0_i32
                >= (find(
                    v58,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Networking::US0::US0_0, 0_i32)),
                        LrcPtr::new((Networking::US0::US0_1, 1_i32)),
                        LrcPtr::new((Networking::US0::US0_2, 2_i32)),
                        LrcPtr::new((Networking::US0::US0_3, 3_i32)),
                        LrcPtr::new((Networking::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            Networking::US6::US6_1
        } else {
            let v81: () = {
                v16_1();
                ()
            };
            let patternInput_1: (
                LrcPtr<Networking::Mut0>,
                LrcPtr<Networking::Mut1>,
                LrcPtr<Networking::Mut2>,
                LrcPtr<Networking::Mut3>,
                LrcPtr<Networking::Mut4>,
                Option<i64>,
            ) = Networking::TraceState::trace_state().get().clone().unwrap();
            let v109: Option<i64> = patternInput_1.5.clone();
            let v108: LrcPtr<Networking::Mut4> = patternInput_1.4.clone();
            let v107: LrcPtr<Networking::Mut3> = patternInput_1.3.clone();
            let v106: LrcPtr<Networking::Mut2> = patternInput_1.2.clone();
            let v105: LrcPtr<Networking::Mut1> = patternInput_1.1.clone();
            let v104: LrcPtr<Networking::Mut0> = patternInput_1.0.clone();
            let v124: string = Networking::method28(
                v104.clone(),
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                Networking::method8(v104, v105, v106, v107, v108, v109),
                Networking::method12(),
                v0,
            );
            let v140: () = {
                v16_1();
                ()
            };
            let patternInput_2: (
                LrcPtr<Networking::Mut0>,
                LrcPtr<Networking::Mut1>,
                LrcPtr<Networking::Mut2>,
                LrcPtr<Networking::Mut3>,
                LrcPtr<Networking::Mut4>,
                Option<i64>,
            ) = Networking::TraceState::trace_state().get().clone().unwrap();
            let v164: LrcPtr<Networking::Mut1> = patternInput_2.1.clone();
            let v163: LrcPtr<Networking::Mut0> = patternInput_2.0.clone();
            let v185: () = {
                Networking::closure8(v163.clone(), ());
                ()
            };
            println!("{}", v124.clone());
            (v164.l0.get().clone())(v124);
            Networking::US6::US6_0(
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
    pub fn method30() -> string {
        let v3: &str = inline_colorization::color_bright_red;
        let v10: std::string::String = String::from(v3);
        let v139: string = append(
            fable_library_rust::String_::fromString(v10),
            Networking::method13(getCharAt(toLower(string("Critical")), 0_i32)),
        );
        let v145: &str = inline_colorization::color_reset;
        let v152: std::string::String = String::from(v145);
        append(v139, fable_library_rust::String_::fromString(v152))
    }
    pub fn method32(v0: i32, v1: string) -> string {
        let v3: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method14()),
        });
        let v17: () = {
            Networking::closure7(v3.clone(), string("{ "), ());
            ()
        };
        let v36: () = {
            Networking::closure7(v3.clone(), string("timeout"), ());
            ()
        };
        let v55: () = {
            Networking::closure7(v3.clone(), string(" = "), ());
            ()
        };
        let v75: () = {
            Networking::closure7(v3.clone(), sprintf!("{}", v0), ());
            ()
        };
        let v94: () = {
            Networking::closure7(v3.clone(), string("; "), ());
            ()
        };
        let v113: () = {
            Networking::closure7(v3.clone(), string("ex"), ());
            ()
        };
        let v130: () = {
            Networking::closure7(v3.clone(), string(" = "), ());
            ()
        };
        let v147: () = {
            Networking::closure7(v3.clone(), v1, ());
            ()
        };
        let v166: () = {
            Networking::closure7(v3.clone(), string(" }"), ());
            ()
        };
        v3.l0.get().clone()
    }
    pub fn method31(
        v0: LrcPtr<Networking::Mut0>,
        v1: LrcPtr<Networking::Mut1>,
        v2: LrcPtr<Networking::Mut2>,
        v3: LrcPtr<Networking::Mut3>,
        v4: LrcPtr<Networking::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i32,
        v9: string,
    ) -> string {
        let v10: string = Networking::method32(v8, v9);
        Networking::method17(append(
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("async.run_with_timeout_async**"),
                ),
                string(" / "),
            ),
            v10,
        ))
    }
    pub fn closure20(v0: i32, v1: LrcPtr<Exception>, unitVar: ()) {
        fn v17() {
            Networking::closure0((), ());
        }
        let v18: () = {
            v17();
            ()
        };
        let patternInput: (
            LrcPtr<Networking::Mut0>,
            LrcPtr<Networking::Mut1>,
            LrcPtr<Networking::Mut2>,
            LrcPtr<Networking::Mut3>,
            LrcPtr<Networking::Mut4>,
            Option<i64>,
        ) = Networking::TraceState::trace_state().get().clone().unwrap();
        let v59: Networking::US0 = (patternInput.4.clone()).l0.get().clone();
        let v338: Networking::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            4_i32
                >= (find(
                    v59,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Networking::US0::US0_0, 0_i32)),
                        LrcPtr::new((Networking::US0::US0_1, 1_i32)),
                        LrcPtr::new((Networking::US0::US0_2, 2_i32)),
                        LrcPtr::new((Networking::US0::US0_3, 3_i32)),
                        LrcPtr::new((Networking::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            Networking::US6::US6_1
        } else {
            let v82: () = {
                v17();
                ()
            };
            let patternInput_1: (
                LrcPtr<Networking::Mut0>,
                LrcPtr<Networking::Mut1>,
                LrcPtr<Networking::Mut2>,
                LrcPtr<Networking::Mut3>,
                LrcPtr<Networking::Mut4>,
                Option<i64>,
            ) = Networking::TraceState::trace_state().get().clone().unwrap();
            let v110: Option<i64> = patternInput_1.5.clone();
            let v109: LrcPtr<Networking::Mut4> = patternInput_1.4.clone();
            let v108: LrcPtr<Networking::Mut3> = patternInput_1.3.clone();
            let v107: LrcPtr<Networking::Mut2> = patternInput_1.2.clone();
            let v106: LrcPtr<Networking::Mut1> = patternInput_1.1.clone();
            let v105: LrcPtr<Networking::Mut0> = patternInput_1.0.clone();
            let v164: string = Networking::method31(
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                Networking::method8(v105, v106, v107, v108, v109, v110),
                Networking::method30(),
                v0,
                sprintf!("{:?}", v1),
            );
            let v180: () = {
                v17();
                ()
            };
            let patternInput_2: (
                LrcPtr<Networking::Mut0>,
                LrcPtr<Networking::Mut1>,
                LrcPtr<Networking::Mut2>,
                LrcPtr<Networking::Mut3>,
                LrcPtr<Networking::Mut4>,
                Option<i64>,
            ) = Networking::TraceState::trace_state().get().clone().unwrap();
            let v204: LrcPtr<Networking::Mut1> = patternInput_2.1.clone();
            let v203: LrcPtr<Networking::Mut0> = patternInput_2.0.clone();
            let v225: () = {
                Networking::closure8(v203.clone(), ());
                ()
            };
            println!("{}", v164.clone());
            (v204.l0.get().clone())(v164);
            Networking::US6::US6_0(
                v203,
                v204,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn closure18(v0: i32, v1: Networking::US9) -> Networking::US7 {
        match &v1 {
            Networking::US9::US9_0(v1_0_0) => Networking::US7::US7_0(v1_0_0.clone()),
            Networking::US9::US9_1(v1_1_0) => {
                let v4 = v1_1_0.clone();
                if contains(
                    sprintf!("{:?}", v4.clone()),
                    string("System.TimeoutException"),
                ) {
                    let v328: () = {
                        Networking::closure19(v0, ());
                        ()
                    };
                    Networking::US7::US7_1
                } else {
                    let v996: () = {
                        Networking::closure20(v0, v4, ());
                        ()
                    };
                    Networking::US7::US7_1
                }
            }
        }
    }
    pub fn method34(
        v0: Func1<Networking::US9, Networking::US7>,
        v1: Arc<Async<Networking::US9>>,
    ) -> Arc<Async<Networking::US7>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method33(
        v0: Func1<Networking::US9, Networking::US7>,
        v1: Arc<Async<Networking::US9>>,
    ) -> Arc<Async<Networking::US7>> {
        Networking::method34(v0, v1)
    }
    pub fn method21(v0: Arc<Async<bool>>, v1: i32) -> Arc<Async<Networking::US7>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method20(v0: i32, v1: Arc<Async<bool>>) -> Arc<Async<Networking::US7>> {
        Networking::method21(v1, v0)
    }
    pub fn method19(v0: i32, v1: string, v2: i32) -> Arc<Async<bool>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method18(v0: i32, v1: string, v2: i32) -> Arc<Async<bool>> {
        Networking::method19(v0, v1, v2)
    }
    pub fn closure13(v0: i32, v1: string, v2: i32) -> Arc<Async<bool>> {
        Networking::method18(v0, v1, v2)
    }
    pub fn closure12(v0: i32, v1: string) -> Func1<i32, Arc<Async<bool>>> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            move |v: i32| Networking::closure13(v0, v1.clone(), v)
        })
    }
    pub fn closure11(unitVar: (), v0: i32) -> Func1<string, Func1<i32, Arc<Async<bool>>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| Networking::closure12(v0, v)
        })
    }
    pub fn closure25(unitVar: (), v0: i32) -> Networking::US10 {
        Networking::US10::US10_0(v0)
    }
    pub fn method38() -> Func1<i32, Networking::US10> {
        Func1::new(move |v: i32| Networking::closure25((), v))
    }
    pub fn method40(v0: i32, v1: i64, v2: Option<i32>, v3: bool) -> string {
        let v5: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method14()),
        });
        let v19: () = {
            Networking::closure7(v5.clone(), string("{ "), ());
            ()
        };
        let v38: () = {
            Networking::closure7(v5.clone(), string("port"), ());
            ()
        };
        let v57: () = {
            Networking::closure7(v5.clone(), string(" = "), ());
            ()
        };
        let v77: () = {
            Networking::closure7(v5.clone(), sprintf!("{}", v0), ());
            ()
        };
        let v96: () = {
            Networking::closure7(v5.clone(), string("; "), ());
            ()
        };
        let v115: () = {
            Networking::closure7(v5.clone(), string("retry"), ());
            ()
        };
        let v132: () = {
            Networking::closure7(v5.clone(), string(" = "), ());
            ()
        };
        let v152: () = {
            Networking::closure7(v5.clone(), sprintf!("{}", v1), ());
            ()
        };
        let v169: () = {
            Networking::closure7(v5.clone(), string("; "), ());
            ()
        };
        let v188: () = {
            Networking::closure7(v5.clone(), string("timeout"), ());
            ()
        };
        let v205: () = {
            Networking::closure7(v5.clone(), string(" = "), ());
            ()
        };
        let v217: std::string::String = format!("{:#?}", v2);
        let v264: () = {
            Networking::closure7(
                v5.clone(),
                fable_library_rust::String_::fromString(v217),
                (),
            );
            ()
        };
        let v281: () = {
            Networking::closure7(v5.clone(), string("; "), ());
            ()
        };
        let v300: () = {
            Networking::closure7(v5.clone(), string("status"), ());
            ()
        };
        let v317: () = {
            Networking::closure7(v5.clone(), string(" = "), ());
            ()
        };
        let v337: () = {
            Networking::closure7(
                v5.clone(),
                if v3 { string("true") } else { string("false") },
                (),
            );
            ()
        };
        let v356: () = {
            Networking::closure7(v5.clone(), string(" }"), ());
            ()
        };
        v5.l0.get().clone()
    }
    pub fn method39(
        v0: LrcPtr<Networking::Mut0>,
        v1: LrcPtr<Networking::Mut1>,
        v2: LrcPtr<Networking::Mut2>,
        v3: LrcPtr<Networking::Mut3>,
        v4: LrcPtr<Networking::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i32,
        v9: i64,
        v10: Option<i32>,
        v11: bool,
    ) -> string {
        let v12: string = Networking::method40(v8, v9, v10, v11);
        Networking::method17(append(
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("networking.wait_for_port_access"),
                ),
                string(" / "),
            ),
            v12,
        ))
    }
    pub fn closure26(v0: Option<i32>, v1: bool, v2: i32, v3: i64, unitVar: ()) {
        fn v19() {
            Networking::closure0((), ());
        }
        let v20: () = {
            v19();
            ()
        };
        let patternInput: (
            LrcPtr<Networking::Mut0>,
            LrcPtr<Networking::Mut1>,
            LrcPtr<Networking::Mut2>,
            LrcPtr<Networking::Mut3>,
            LrcPtr<Networking::Mut4>,
            Option<i64>,
        ) = Networking::TraceState::trace_state().get().clone().unwrap();
        let v61: Networking::US0 = (patternInput.4.clone()).l0.get().clone();
        let v301: Networking::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            0_i32
                >= (find(
                    v61,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Networking::US0::US0_0, 0_i32)),
                        LrcPtr::new((Networking::US0::US0_1, 1_i32)),
                        LrcPtr::new((Networking::US0::US0_2, 2_i32)),
                        LrcPtr::new((Networking::US0::US0_3, 3_i32)),
                        LrcPtr::new((Networking::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            Networking::US6::US6_1
        } else {
            let v84: () = {
                v19();
                ()
            };
            let patternInput_1: (
                LrcPtr<Networking::Mut0>,
                LrcPtr<Networking::Mut1>,
                LrcPtr<Networking::Mut2>,
                LrcPtr<Networking::Mut3>,
                LrcPtr<Networking::Mut4>,
                Option<i64>,
            ) = Networking::TraceState::trace_state().get().clone().unwrap();
            let v112: Option<i64> = patternInput_1.5.clone();
            let v111: LrcPtr<Networking::Mut4> = patternInput_1.4.clone();
            let v110: LrcPtr<Networking::Mut3> = patternInput_1.3.clone();
            let v109: LrcPtr<Networking::Mut2> = patternInput_1.2.clone();
            let v108: LrcPtr<Networking::Mut1> = patternInput_1.1.clone();
            let v107: LrcPtr<Networking::Mut0> = patternInput_1.0.clone();
            let v127: string = Networking::method39(
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                v111.clone(),
                v112.clone(),
                Networking::method8(v107, v108, v109, v110, v111, v112),
                Networking::method12(),
                v2,
                v3,
                v0,
                v1,
            );
            let v143: () = {
                v19();
                ()
            };
            let patternInput_2: (
                LrcPtr<Networking::Mut0>,
                LrcPtr<Networking::Mut1>,
                LrcPtr<Networking::Mut2>,
                LrcPtr<Networking::Mut3>,
                LrcPtr<Networking::Mut4>,
                Option<i64>,
            ) = Networking::TraceState::trace_state().get().clone().unwrap();
            let v167: LrcPtr<Networking::Mut1> = patternInput_2.1.clone();
            let v166: LrcPtr<Networking::Mut0> = patternInput_2.0.clone();
            let v188: () = {
                Networking::closure8(v166.clone(), ());
                ()
            };
            println!("{}", v127.clone());
            (v167.l0.get().clone())(v127);
            Networking::US6::US6_0(
                v166,
                v167,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method37(v0: Option<i32>, v1: bool, v2: string, v3: i32, v4: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method36(v0: Option<i32>, v1: bool, v2: string, v3: i32, v4: i64) -> Arc<Async<i64>> {
        Networking::method37(v0, v1, v2, v3, v4)
    }
    pub fn method35(v0: Option<i32>, v1: bool, v2: string, v3: i32) -> Arc<Async<i64>> {
        Networking::method36(v0, v1, v2, v3, 1_i64)
    }
    pub fn closure24(v0: Option<i32>, v1: bool, v2: string, v3: i32) -> Arc<Async<i64>> {
        Networking::method35(v0, v1, v2, v3)
    }
    pub fn closure23(v0: Option<i32>, v1: bool, v2: string) -> Func1<i32, Arc<Async<i64>>> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            let v2 = v2.clone();
            move |v: i32| Networking::closure24(v0.clone(), v1, v2.clone(), v)
        })
    }
    pub fn closure22(v0: Option<i32>, v1: bool) -> Func1<string, Func1<i32, Arc<Async<i64>>>> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            move |v: string| Networking::closure23(v0.clone(), v1, v)
        })
    }
    pub fn closure21(
        unitVar: (),
        v0: Option<i32>,
    ) -> Func1<bool, Func1<string, Func1<i32, Arc<Async<i64>>>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: bool| Networking::closure22(v0.clone(), v)
        })
    }
    pub fn method43(v0: Option<i32>, v1: string, v2: i32) -> Arc<Async<i32>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method42(v0: Option<i32>, v1: string, v2: i32) -> Arc<Async<i32>> {
        Networking::method43(v0, v1, v2)
    }
    pub fn method41(v0: Option<i32>, v1: string, v2: i32) -> Arc<Async<i32>> {
        Networking::method42(v0, v1, v2)
    }
    pub fn closure29(v0: Option<i32>, v1: string, v2: i32) -> Arc<Async<i32>> {
        Networking::method41(v0, v1, v2)
    }
    pub fn closure28(v0: Option<i32>, v1: string) -> Func1<i32, Arc<Async<i32>>> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            move |v: i32| Networking::closure29(v0.clone(), v1.clone(), v)
        })
    }
    pub fn closure27(unitVar: (), v0: Option<i32>) -> Func1<string, Func1<i32, Arc<Async<i32>>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| Networking::closure28(v0.clone(), v)
        })
    }
    pub fn v14() -> () {
        static v14: OnceInit<()> = OnceInit::new();
        v14.get_or_init(|| ()).clone()
    }
    pub fn v15() -> Func0<()> {
        static v15: OnceInit<Func0<()>> = OnceInit::new();
        v15.get_or_init(|| Func0::new(move || Networking::closure0((), ())))
            .clone()
    }
    pub fn v16() -> () {
        static v16: OnceInit<()> = OnceInit::new();
        v16.get_or_init(|| {
            (Networking::v15())();
            Networking::v14()
        })
        .clone()
    }
    pub fn v31() -> Func1<string, Func1<i32, Arc<Async<bool>>>> {
        static v31: OnceInit<Func1<string, Func1<i32, Arc<Async<bool>>>>> = OnceInit::new();
        v31.get_or_init(|| Func1::new(move |v: string| Networking::closure3((), v)))
            .clone()
    }
    pub fn test_port_open(x: string) -> Func1<i32, Arc<Async<bool>>> {
        (Networking::v31())(x)
    }
    pub fn v32() -> Func1<i32, Func1<string, Func1<i32, Arc<Async<bool>>>>> {
        static v32: OnceInit<Func1<i32, Func1<string, Func1<i32, Arc<Async<bool>>>>>> =
            OnceInit::new();
        v32.get_or_init(|| Func1::new(move |v: i32| Networking::closure11((), v)))
            .clone()
    }
    pub fn test_port_open_timeout(x: i32) -> Func1<string, Func1<i32, Arc<Async<bool>>>> {
        (Networking::v32())(x)
    }
    pub fn v33() -> Func1<Option<i32>, Func1<bool, Func1<string, Func1<i32, Arc<Async<i64>>>>>> {
        static v33: OnceInit<
            Func1<Option<i32>, Func1<bool, Func1<string, Func1<i32, Arc<Async<i64>>>>>>,
        > = OnceInit::new();
        v33.get_or_init(|| Func1::new(move |v: Option<i32>| Networking::closure21((), v)))
            .clone()
    }
    pub fn wait_for_port_access(
        x: Option<i32>,
    ) -> Func1<bool, Func1<string, Func1<i32, Arc<Async<i64>>>>> {
        (Networking::v33())(x)
    }
    pub fn v34() -> Func1<Option<i32>, Func1<string, Func1<i32, Arc<Async<i32>>>>> {
        static v34: OnceInit<Func1<Option<i32>, Func1<string, Func1<i32, Arc<Async<i32>>>>>> =
            OnceInit::new();
        v34.get_or_init(|| Func1::new(move |v: Option<i32>| Networking::closure27((), v)))
            .clone()
    }
    pub fn get_available_port(x: Option<i32>) -> Func1<string, Func1<i32, Arc<Async<i32>>>> {
        (Networking::v34())(x)
    }
    on_startup!(());
}
