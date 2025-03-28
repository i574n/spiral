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
    use fable_library_rust::NativeArray_::new_array;
    use fable_library_rust::Native_::getNull;
    use fable_library_rust::Native_::on_startup;
    use fable_library_rust::Native_::Any;
    use fable_library_rust::Native_::Arc;
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
    use fable_library_rust::System::Exception;
    use fable_library_rust::TimeSpan_::TimeSpan;
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
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US6 {
        US6_0(bool),
        US6_1,
    }
    impl core::fmt::Display for US6 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US7 {
        US7_0(bool),
        US7_1(LrcPtr<Exception>),
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
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US9 {
        US9_0(i32),
        US9_1,
    }
    impl core::fmt::Display for US9 {
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
    pub fn closure1(unitVar: (), v0_1: string) -> Networking::US5 {
        Networking::US5::US5_0(v0_1)
    }
    pub fn method5() -> Func1<string, Networking::US5> {
        Func1::new(move |v: string| Networking::closure1((), v))
    }
    pub fn method2(v0_1: string) -> string {
        panic!(
            "{}",
            sprintf!(
                "env.get_environment_variable / target: {} / var: {}",
                Networking::US4::US4_3(Networking::US3::US3_1),
                v0_1
            ),
        )
    }
    pub fn method1() -> (Networking::US1, Networking::US2) {
        let v1_1: string = Networking::method2(string("TRACE_LEVEL"));
        let v6: string = toLower(string("Critical"));
        let v13: string = toLower(string("Warning"));
        let v20_1: string = toLower(string("Info"));
        let v27: string = toLower(string("Debug"));
        let v34: string = toLower(string("Verbose"));
        let v41: Networking::US1 = if string("Verbose") == (v1_1.clone()) {
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
                    let v48: Networking::US1 = if string("Debug") == (v1_1.clone()) {
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
                            let v55: Networking::US1 = if string("Info") == (v1_1.clone()) {
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
                                    let v62: Networking::US1 =
                                        if string("Warning") == (v1_1.clone()) {
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
                                                if string("Critical") == (v1_1.clone()) {
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
                                                        if (v34.clone()) == (v1_1.clone()) {
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
                                                            let v83: Networking::US1 = if (v27
                                                                .clone())
                                                                == (v1_1.clone())
                                                            {
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
                                                                     if (v20_1.clone())
                                                                            ==
                                                                            (v1_1.clone())
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
                                                                                    (v1_1.clone())
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
                                                                                            (v1_1.clone())
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
    pub fn closure2(unitVar: (), v0_1: string) {
        ();
    }
    pub fn method0(
        v0_1: Networking::US0,
    ) -> (
        LrcPtr<Networking::Mut0>,
        LrcPtr<Networking::Mut1>,
        LrcPtr<Networking::Mut2>,
        LrcPtr<Networking::Mut3>,
        LrcPtr<Networking::Mut4>,
        Option<i64>,
    ) {
        let _run_target_args__v3: (Networking::US1, Networking::US2) =
            (Networking::US1::US1_1, Networking::US2::US2_1);
        let v173: Networking::US2 = _run_target_args__v3.1.clone();
        let v172: Networking::US1 = _run_target_args__v3.0.clone();
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
                l0: MutCell::new(match &v172 {
                    Networking::US1::US1_0(v172_0_0) => match &v172 {
                        Networking::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    _ => v0_1.clone(),
                }),
            }),
            match &v173 {
                Networking::US2::US2_0(v173_0_0) => Some(match &v173 {
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
    pub fn method8(v0_1: Networking::US0) -> bool {
        let v3: () = {
            Networking::closure0((), ());
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
        let v42: Networking::US0 = (patternInput.4.clone()).l0.get().clone();
        if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            (find(
                v0_1,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Networking::US0::US0_0, 0_i32)),
                    LrcPtr::new((Networking::US0::US0_1, 1_i32)),
                    LrcPtr::new((Networking::US0::US0_2, 2_i32)),
                    LrcPtr::new((Networking::US0::US0_3, 3_i32)),
                    LrcPtr::new((Networking::US0::US0_4, 4_i32)),
                ])))),
            )) >= (find(
                v42,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Networking::US0::US0_0, 0_i32)),
                    LrcPtr::new((Networking::US0::US0_1, 1_i32)),
                    LrcPtr::new((Networking::US0::US0_2, 2_i32)),
                    LrcPtr::new((Networking::US0::US0_3, 3_i32)),
                    LrcPtr::new((Networking::US0::US0_4, 4_i32)),
                ])))),
            ))
        }
    }
    pub fn closure6(unitVar: (), v0_1: i64) -> Networking::US2 {
        Networking::US2::US2_0(v0_1)
    }
    pub fn method10() -> Func1<i64, Networking::US2> {
        Func1::new(move |v: i64| Networking::closure6((), v))
    }
    pub fn method11() -> string {
        string("hh:mm:ss")
    }
    pub fn method12() -> string {
        string("HH:mm:ss")
    }
    pub fn method9(
        v0_1: LrcPtr<Networking::Mut0>,
        v1_1: LrcPtr<Networking::Mut1>,
        v2_1: LrcPtr<Networking::Mut2>,
        v3: LrcPtr<Networking::Mut3>,
        v4: LrcPtr<Networking::Mut4>,
        v5: Option<i64>,
    ) -> string {
        let v347: Networking::US2 =
            defaultValue(Networking::US2::US2_1, map(Networking::method10(), v5));
        let v465: DateTime = match &v347 {
            Networking::US2::US2_0(v347_0_0) => {
                let v417: TimeSpan = TimeSpan::new_ticks(
                    ({
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    }) - (match &v347 {
                        Networking::US2::US2_0(x) => x.clone(),
                        _ => unreachable!(),
                    }),
                );
                DateTime::new_ymdhms_milli(
                    1_i32,
                    1_i32,
                    1_i32,
                    v417.hours(),
                    v417.minutes(),
                    v417.seconds(),
                    v417.milliseconds(),
                )
            }
            _ => DateTime::now(),
        };
        let v467: string = Networking::method11();
        let provider: string = if (v467.clone()) == string("") {
            string("M-d-y hh:mm:ss tt")
        } else {
            v467
        };
        v465.toString(provider)
    }
    pub fn method15() -> string {
        string("")
    }
    pub fn closure7(v0_1: LrcPtr<Networking::Mut3>, v1_1: string, unitVar: ()) {
        let v3: string = append((v0_1.l0.get().clone()), (v1_1));
        v0_1.l0.set(v3);
        ()
    }
    pub fn method14(v0_1: char) -> string {
        let v2_1: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method15()),
        });
        let v9: () = {
            Networking::closure7(v2_1.clone(), sprintf!("{}", v0_1), ());
            ()
        };
        v2_1.l0.get().clone()
    }
    pub fn method16() -> string {
        string("\u{001b}[0m")
    }
    pub fn method13() -> string {
        let v8: string = Networking::method14(getCharAt(toLower(string("Verbose")), 0_i32));
        let v56: &str = inline_colorization::color_bright_black;
        let v65: &str = &*v8;
        let v91: &str = inline_colorization::color_reset;
        let v93: std::string::String = format!("{}{}{}", v56, v65, v91);
        fable_library_rust::String_::fromString(v93)
    }
    pub fn method18(v0_1: i32, v1_1: string) -> string {
        let v3: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method15()),
        });
        let v12: () = {
            Networking::closure7(v3.clone(), string("{ "), ());
            ()
        };
        let v23: () = {
            Networking::closure7(v3.clone(), string("port"), ());
            ()
        };
        let v34: () = {
            Networking::closure7(v3.clone(), string(" = "), ());
            ()
        };
        let v43: () = {
            Networking::closure7(v3.clone(), sprintf!("{}", v0_1), ());
            ()
        };
        let v54: () = {
            Networking::closure7(v3.clone(), string("; "), ());
            ()
        };
        let v65: () = {
            Networking::closure7(v3.clone(), string("ex"), ());
            ()
        };
        let v74: () = {
            Networking::closure7(v3.clone(), string(" = "), ());
            ()
        };
        let v83: () = {
            Networking::closure7(v3.clone(), v1_1, ());
            ()
        };
        let v94: () = {
            Networking::closure7(v3.clone(), string(" }"), ());
            ()
        };
        v3.l0.get().clone()
    }
    pub fn method19(v0_1: string) -> string {
        trimEndChars(
            trimStartChars(v0_1, toArray(empty::<char>())),
            toArray(ofArray(new_array(&[' ', '/']))),
        )
    }
    pub fn method17(
        v0_1: LrcPtr<Networking::Mut0>,
        v1_1: LrcPtr<Networking::Mut1>,
        v2_1: LrcPtr<Networking::Mut2>,
        v3: LrcPtr<Networking::Mut3>,
        v4: LrcPtr<Networking::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i32,
        v9: string,
    ) -> string {
        let v10: string = Networking::method18(v8, v9);
        Networking::method19(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            string("networking.test_port_open"),
            v10
        ))
    }
    pub fn closure8(v0_1: LrcPtr<Networking::Mut0>, unitVar: ()) {
        let v2_1: i64 = (v0_1.l0.get().clone()) + 1_i64;
        v0_1.l0.set(v2_1);
        ()
    }
    pub fn closure10(v0_1: string, unitVar: ()) {
        printfn!("{0}", v0_1);
    }
    pub fn closure9(unitVar: (), v0_1: string) {
        let v3: () = {
            Networking::closure10(v0_1, ());
            ()
        };
        ()
    }
    pub fn method20(v0_1: string) {
        let v3: () = {
            Networking::closure0((), ());
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
        let v44: () = {
            Networking::closure8(patternInput.0.clone(), ());
            ()
        };
        println!("{}", v0_1.clone());
        ((patternInput.1.clone()).l0.get().clone())(v0_1)
    }
    pub fn closure5(v0_1: i32, v1_1: LrcPtr<Exception>, unitVar: ()) {
        if Networking::method8(Networking::US0::US0_0) {
            let v6: () = {
                Networking::closure0((), ());
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
            let v32: Option<i64> = patternInput.5.clone();
            let v31: LrcPtr<Networking::Mut4> = patternInput.4.clone();
            let v30: LrcPtr<Networking::Mut3> = patternInput.3.clone();
            let v29: LrcPtr<Networking::Mut2> = patternInput.2.clone();
            let v28: LrcPtr<Networking::Mut1> = patternInput.1.clone();
            let v27: LrcPtr<Networking::Mut0> = patternInput.0.clone();
            Networking::method20(Networking::method17(
                v27.clone(),
                v28.clone(),
                v29.clone(),
                v30.clone(),
                v31.clone(),
                v32.clone(),
                Networking::method9(v27, v28, v29, v30, v31, v32),
                Networking::method13(),
                v0_1,
                sprintf!("{:?}", v1_1),
            ))
        };
    }
    pub fn method7(v0_1: string, v1_1: i32) -> Arc<Async<bool>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method6(v0_1: string, v1_1: i32) -> Arc<Async<bool>> {
        Networking::method7(v0_1, v1_1)
    }
    pub fn closure4(v0_1: string, v1_1: i32) -> Arc<Async<bool>> {
        Networking::method6(v0_1, v1_1)
    }
    pub fn closure3(unitVar: (), v0_1: string) -> Func1<i32, Arc<Async<bool>>> {
        Func1::new({
            let v0_1 = v0_1.clone();
            move |v: i32| Networking::closure4(v0_1.clone(), v)
        })
    }
    pub fn closure14(unitVar: (), v0_1: bool) -> Networking::US7 {
        Networking::US7::US7_0(v0_1)
    }
    pub fn method26() -> Func1<bool, Networking::US7> {
        Func1::new(move |v: bool| Networking::closure14((), v))
    }
    pub fn closure15(unitVar: (), v0_1: LrcPtr<Exception>) -> Networking::US7 {
        Networking::US7::US7_1(v0_1)
    }
    pub fn method27() -> Func1<LrcPtr<Exception>, Networking::US7> {
        Func1::new(move |v: LrcPtr<Exception>| Networking::closure15((), v))
    }
    pub fn method25(
        v0_1: Arc<Async<LrcPtr<Choice_2<bool, LrcPtr<Exception>>>>>,
    ) -> Arc<Async<Networking::US7>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method28(v0_1: Arc<Async<Networking::US7>>) -> Arc<Async<Networking::US8>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method31(v0_1: i32) -> string {
        let v2_1: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method15()),
        });
        let v11: () = {
            Networking::closure7(v2_1.clone(), string("{ "), ());
            ()
        };
        let v22: () = {
            Networking::closure7(v2_1.clone(), string("timeout"), ());
            ()
        };
        let v33: () = {
            Networking::closure7(v2_1.clone(), string(" = "), ());
            ()
        };
        let v42: () = {
            Networking::closure7(v2_1.clone(), sprintf!("{}", v0_1), ());
            ()
        };
        let v53: () = {
            Networking::closure7(v2_1.clone(), string(" }"), ());
            ()
        };
        v2_1.l0.get().clone()
    }
    pub fn method30(
        v0_1: LrcPtr<Networking::Mut0>,
        v1_1: LrcPtr<Networking::Mut1>,
        v2_1: LrcPtr<Networking::Mut2>,
        v3: LrcPtr<Networking::Mut3>,
        v4: LrcPtr<Networking::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i32,
    ) -> string {
        let v9: string = Networking::method31(v8);
        Networking::method19(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            string("async.run_with_timeout_async"),
            v9
        ))
    }
    pub fn closure16(v0_1: i32, unitVar: ()) {
        if Networking::method8(Networking::US0::US0_0) {
            let v5: () = {
                Networking::closure0((), ());
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
            let v31: Option<i64> = patternInput.5.clone();
            let v30: LrcPtr<Networking::Mut4> = patternInput.4.clone();
            let v29: LrcPtr<Networking::Mut3> = patternInput.3.clone();
            let v28: LrcPtr<Networking::Mut2> = patternInput.2.clone();
            let v27: LrcPtr<Networking::Mut1> = patternInput.1.clone();
            let v26: LrcPtr<Networking::Mut0> = patternInput.0.clone();
            Networking::method20(Networking::method30(
                v26.clone(),
                v27.clone(),
                v28.clone(),
                v29.clone(),
                v30.clone(),
                v31.clone(),
                Networking::method9(v26, v27, v28, v29, v30, v31),
                Networking::method13(),
                v0_1,
            ))
        };
    }
    pub fn method32() -> string {
        let v8: string = Networking::method14(getCharAt(toLower(string("Critical")), 0_i32));
        let v56: &str = inline_colorization::color_bright_red;
        let v65: &str = &*v8;
        let v91: &str = inline_colorization::color_reset;
        let v93: std::string::String = format!("{}{}{}", v56, v65, v91);
        fable_library_rust::String_::fromString(v93)
    }
    pub fn method34(v0_1: i32, v1_1: string) -> string {
        let v3: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method15()),
        });
        let v12: () = {
            Networking::closure7(v3.clone(), string("{ "), ());
            ()
        };
        let v23: () = {
            Networking::closure7(v3.clone(), string("timeout"), ());
            ()
        };
        let v34: () = {
            Networking::closure7(v3.clone(), string(" = "), ());
            ()
        };
        let v43: () = {
            Networking::closure7(v3.clone(), sprintf!("{}", v0_1), ());
            ()
        };
        let v54: () = {
            Networking::closure7(v3.clone(), string("; "), ());
            ()
        };
        let v65: () = {
            Networking::closure7(v3.clone(), string("ex"), ());
            ()
        };
        let v74: () = {
            Networking::closure7(v3.clone(), string(" = "), ());
            ()
        };
        let v83: () = {
            Networking::closure7(v3.clone(), v1_1, ());
            ()
        };
        let v94: () = {
            Networking::closure7(v3.clone(), string(" }"), ());
            ()
        };
        v3.l0.get().clone()
    }
    pub fn method33(
        v0_1: LrcPtr<Networking::Mut0>,
        v1_1: LrcPtr<Networking::Mut1>,
        v2_1: LrcPtr<Networking::Mut2>,
        v3: LrcPtr<Networking::Mut3>,
        v4: LrcPtr<Networking::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i32,
        v9: string,
    ) -> string {
        let v10: string = Networking::method34(v8, v9);
        Networking::method19(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            string("async.run_with_timeout_async**"),
            v10
        ))
    }
    pub fn closure17(v0_1: i32, v1_1: LrcPtr<Exception>, unitVar: ()) {
        if Networking::method8(Networking::US0::US0_4) {
            let v6: () = {
                Networking::closure0((), ());
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
            let v32: Option<i64> = patternInput.5.clone();
            let v31: LrcPtr<Networking::Mut4> = patternInput.4.clone();
            let v30: LrcPtr<Networking::Mut3> = patternInput.3.clone();
            let v29: LrcPtr<Networking::Mut2> = patternInput.2.clone();
            let v28: LrcPtr<Networking::Mut1> = patternInput.1.clone();
            let v27: LrcPtr<Networking::Mut0> = patternInput.0.clone();
            Networking::method20(Networking::method33(
                v27.clone(),
                v28.clone(),
                v29.clone(),
                v30.clone(),
                v31.clone(),
                v32.clone(),
                Networking::method9(v27, v28, v29, v30, v31, v32),
                Networking::method32(),
                v0_1,
                sprintf!("{:?}", v1_1),
            ))
        };
    }
    pub fn method29(v0_1: i32, v1_1: Arc<Async<Networking::US8>>) -> Arc<Async<Networking::US6>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method24(v0_1: Arc<Async<bool>>, v1_1: i32) -> Arc<Async<Networking::US6>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method23(v0_1: i32, v1_1: Arc<Async<bool>>) -> Arc<Async<Networking::US6>> {
        Networking::method24(v1_1, v0_1)
    }
    pub fn method22(v0_1: i32, v1_1: string, v2_1: i32) -> Arc<Async<bool>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method21(v0_1: i32, v1_1: string, v2_1: i32) -> Arc<Async<bool>> {
        Networking::method22(v0_1, v1_1, v2_1)
    }
    pub fn closure13(v0_1: i32, v1_1: string, v2_1: i32) -> Arc<Async<bool>> {
        Networking::method21(v0_1, v1_1, v2_1)
    }
    pub fn closure12(v0_1: i32, v1_1: string) -> Func1<i32, Arc<Async<bool>>> {
        Func1::new({
            let v0_1 = v0_1.clone();
            let v1_1 = v1_1.clone();
            move |v: i32| Networking::closure13(v0_1, v1_1.clone(), v)
        })
    }
    pub fn closure11(unitVar: (), v0_1: i32) -> Func1<string, Func1<i32, Arc<Async<bool>>>> {
        Func1::new({
            let v0_1 = v0_1.clone();
            move |v: string| Networking::closure12(v0_1, v)
        })
    }
    pub fn closure22(unitVar: (), v0_1: i32) -> Networking::US9 {
        Networking::US9::US9_0(v0_1)
    }
    pub fn method38() -> Func1<i32, Networking::US9> {
        Func1::new(move |v: i32| Networking::closure22((), v))
    }
    pub fn method40(v0_1: i32, v1_1: i64, v2_1: Option<i32>, v3: bool) -> string {
        let v5: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method15()),
        });
        let v14: () = {
            Networking::closure7(v5.clone(), string("{ "), ());
            ()
        };
        let v25: () = {
            Networking::closure7(v5.clone(), string("port"), ());
            ()
        };
        let v36: () = {
            Networking::closure7(v5.clone(), string(" = "), ());
            ()
        };
        let v45: () = {
            Networking::closure7(v5.clone(), sprintf!("{}", v0_1), ());
            ()
        };
        let v56: () = {
            Networking::closure7(v5.clone(), string("; "), ());
            ()
        };
        let v67: () = {
            Networking::closure7(v5.clone(), string("retry"), ());
            ()
        };
        let v76: () = {
            Networking::closure7(v5.clone(), string(" = "), ());
            ()
        };
        let v85: () = {
            Networking::closure7(v5.clone(), sprintf!("{}", v1_1), ());
            ()
        };
        let v94: () = {
            Networking::closure7(v5.clone(), string("; "), ());
            ()
        };
        let v105: () = {
            Networking::closure7(v5.clone(), string("timeout"), ());
            ()
        };
        let v114: () = {
            Networking::closure7(v5.clone(), string(" = "), ());
            ()
        };
        let v127: std::string::String = format!("{:#?}", v2_1);
        let v162: () = {
            Networking::closure7(
                v5.clone(),
                fable_library_rust::String_::fromString(v127),
                (),
            );
            ()
        };
        let v171: () = {
            Networking::closure7(v5.clone(), string("; "), ());
            ()
        };
        let v182: () = {
            Networking::closure7(v5.clone(), string("status"), ());
            ()
        };
        let v191: () = {
            Networking::closure7(v5.clone(), string(" = "), ());
            ()
        };
        let v203: () = {
            Networking::closure7(
                v5.clone(),
                if v3 { string("true") } else { string("false") },
                (),
            );
            ()
        };
        let v214: () = {
            Networking::closure7(v5.clone(), string(" }"), ());
            ()
        };
        v5.l0.get().clone()
    }
    pub fn method39(
        v0_1: LrcPtr<Networking::Mut0>,
        v1_1: LrcPtr<Networking::Mut1>,
        v2_1: LrcPtr<Networking::Mut2>,
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
        Networking::method19(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            string("networking.wait_for_port_access"),
            v12
        ))
    }
    pub fn closure23(v0_1: Option<i32>, v1_1: bool, v2_1: i32, v3: i64, unitVar: ()) {
        if Networking::method8(Networking::US0::US0_0) {
            let v8: () = {
                Networking::closure0((), ());
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
            let v34: Option<i64> = patternInput.5.clone();
            let v33: LrcPtr<Networking::Mut4> = patternInput.4.clone();
            let v32: LrcPtr<Networking::Mut3> = patternInput.3.clone();
            let v31: LrcPtr<Networking::Mut2> = patternInput.2.clone();
            let v30: LrcPtr<Networking::Mut1> = patternInput.1.clone();
            let v29: LrcPtr<Networking::Mut0> = patternInput.0.clone();
            Networking::method20(Networking::method39(
                v29.clone(),
                v30.clone(),
                v31.clone(),
                v32.clone(),
                v33.clone(),
                v34.clone(),
                Networking::method9(v29, v30, v31, v32, v33, v34),
                Networking::method13(),
                v2_1,
                v3,
                v0_1,
                v1_1,
            ))
        };
    }
    pub fn method37(
        v0_1: Option<i32>,
        v1_1: bool,
        v2_1: string,
        v3: i32,
        v4: i64,
    ) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method36(
        v0_1: Option<i32>,
        v1_1: bool,
        v2_1: string,
        v3: i32,
        v4: i64,
    ) -> Arc<Async<i64>> {
        Networking::method37(v0_1, v1_1, v2_1, v3, v4)
    }
    pub fn method35(v0_1: Option<i32>, v1_1: bool, v2_1: string, v3: i32) -> Arc<Async<i64>> {
        Networking::method36(v0_1, v1_1, v2_1, v3, 1_i64)
    }
    pub fn closure21(v0_1: Option<i32>, v1_1: bool, v2_1: string, v3: i32) -> Arc<Async<i64>> {
        Networking::method35(v0_1, v1_1, v2_1, v3)
    }
    pub fn closure20(v0_1: Option<i32>, v1_1: bool, v2_1: string) -> Func1<i32, Arc<Async<i64>>> {
        Func1::new({
            let v0_1 = v0_1.clone();
            let v1_1 = v1_1.clone();
            let v2_1 = v2_1.clone();
            move |v: i32| Networking::closure21(v0_1.clone(), v1_1, v2_1.clone(), v)
        })
    }
    pub fn closure19(v0_1: Option<i32>, v1_1: bool) -> Func1<string, Func1<i32, Arc<Async<i64>>>> {
        Func1::new({
            let v0_1 = v0_1.clone();
            let v1_1 = v1_1.clone();
            move |v: string| Networking::closure20(v0_1.clone(), v1_1, v)
        })
    }
    pub fn closure18(
        unitVar: (),
        v0_1: Option<i32>,
    ) -> Func1<bool, Func1<string, Func1<i32, Arc<Async<i64>>>>> {
        Func1::new({
            let v0_1 = v0_1.clone();
            move |v: bool| Networking::closure19(v0_1.clone(), v)
        })
    }
    pub fn method43(v0_1: Option<i32>, v1_1: string, v2_1: i32) -> Arc<Async<i32>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method42(v0_1: Option<i32>, v1_1: string, v2_1: i32) -> Arc<Async<i32>> {
        Networking::method43(v0_1, v1_1, v2_1)
    }
    pub fn method41(v0_1: Option<i32>, v1_1: string, v2_1: i32) -> Arc<Async<i32>> {
        Networking::method42(v0_1, v1_1, v2_1)
    }
    pub fn closure26(v0_1: Option<i32>, v1_1: string, v2_1: i32) -> Arc<Async<i32>> {
        Networking::method41(v0_1, v1_1, v2_1)
    }
    pub fn closure25(v0_1: Option<i32>, v1_1: string) -> Func1<i32, Arc<Async<i32>>> {
        Func1::new({
            let v0_1 = v0_1.clone();
            let v1_1 = v1_1.clone();
            move |v: i32| Networking::closure26(v0_1.clone(), v1_1.clone(), v)
        })
    }
    pub fn closure24(unitVar: (), v0_1: Option<i32>) -> Func1<string, Func1<i32, Arc<Async<i32>>>> {
        Func1::new({
            let v0_1 = v0_1.clone();
            move |v: string| Networking::closure25(v0_1.clone(), v)
        })
    }
    pub fn v0() -> () {
        static v0: OnceInit<()> = OnceInit::new();
        v0.get_or_init(|| ()).clone()
    }
    pub fn v1() -> Func0<()> {
        static v1: OnceInit<Func0<()>> = OnceInit::new();
        v1.get_or_init(|| Func0::new(move || Networking::closure0((), ())))
            .clone()
    }
    pub fn v2() -> () {
        static v2: OnceInit<()> = OnceInit::new();
        v2.get_or_init(|| {
            (Networking::v1())();
            Networking::v0()
        })
        .clone()
    }
    pub fn v17() -> Func1<string, Func1<i32, Arc<Async<bool>>>> {
        static v17: OnceInit<Func1<string, Func1<i32, Arc<Async<bool>>>>> = OnceInit::new();
        v17.get_or_init(|| Func1::new(move |v: string| Networking::closure3((), v)))
            .clone()
    }
    pub fn test_port_open(x: string) -> Func1<i32, Arc<Async<bool>>> {
        (Networking::v17())(x)
    }
    pub fn v18() -> Func1<i32, Func1<string, Func1<i32, Arc<Async<bool>>>>> {
        static v18: OnceInit<Func1<i32, Func1<string, Func1<i32, Arc<Async<bool>>>>>> =
            OnceInit::new();
        v18.get_or_init(|| Func1::new(move |v: i32| Networking::closure11((), v)))
            .clone()
    }
    pub fn test_port_open_timeout(x: i32) -> Func1<string, Func1<i32, Arc<Async<bool>>>> {
        (Networking::v18())(x)
    }
    pub fn v19() -> Func1<Option<i32>, Func1<bool, Func1<string, Func1<i32, Arc<Async<i64>>>>>> {
        static v19: OnceInit<
            Func1<Option<i32>, Func1<bool, Func1<string, Func1<i32, Arc<Async<i64>>>>>>,
        > = OnceInit::new();
        v19.get_or_init(|| Func1::new(move |v: Option<i32>| Networking::closure18((), v)))
            .clone()
    }
    pub fn wait_for_port_access(
        x: Option<i32>,
    ) -> Func1<bool, Func1<string, Func1<i32, Arc<Async<i64>>>>> {
        (Networking::v19())(x)
    }
    pub fn v20() -> Func1<Option<i32>, Func1<string, Func1<i32, Arc<Async<i32>>>>> {
        static v20: OnceInit<Func1<Option<i32>, Func1<string, Func1<i32, Arc<Async<i32>>>>>> =
            OnceInit::new();
        v20.get_or_init(|| Func1::new(move |v: Option<i32>| Networking::closure24((), v)))
            .clone()
    }
    pub fn get_available_port(x: Option<i32>) -> Func1<string, Func1<i32, Arc<Async<i32>>>> {
        (Networking::v20())(x)
    }
    on_startup!(());
}
