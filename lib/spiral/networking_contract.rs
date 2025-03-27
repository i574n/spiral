pub mod Networking {
    use super::*;
    type Async<T> = T;
    use fable_library_rust::Choice_::Choice_2;
    type DateTime = ();
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
    use fable_library_rust::Native_::null;
    use fable_library_rust::Native_::on_startup;
    use fable_library_rust::Native_::unbox;
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
    use fable_library_rust::System::Exception;
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
        panic!(
            "{}",
            sprintf!(
                "env.get_environment_variable / target: {} / var: {}",
                Networking::US4::US4_3(Networking::US3::US3_2),
                v0
            ),
        )
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
                let v147: DateTime = unbox::<DateTime>(fable_library_rust::Native_::getZero());
                Networking::US2::US2_0(unbox::<i64>(fable_library_rust::Native_::getZero()))
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
        let v88: string = string("option_env!(\"AUTOMATION\").unwrap_or(\"\")");
        let v89: &str = option_env!("AUTOMATION").unwrap_or("");
        let v100: std::string::String = String::from(v89);
        let _run_target_args__v3: (Networking::US1, Networking::US2) = (
            Networking::US1::US1_1,
            if (fable_library_rust::String_::fromString(v100)) != string("True") {
                Networking::US2::US2_1
            } else {
                Networking::US2::US2_0(near_sdk::env::block_timestamp() as i64)
            },
        );
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
                    _ => v0.clone(),
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
    pub fn method8(v0: Networking::US0) -> bool {
        let v17: () = {
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
        let v56: Networking::US0 = (patternInput.4.clone()).l0.get().clone();
        if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            (find(
                v0,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Networking::US0::US0_0, 0_i32)),
                    LrcPtr::new((Networking::US0::US0_1, 1_i32)),
                    LrcPtr::new((Networking::US0::US0_2, 2_i32)),
                    LrcPtr::new((Networking::US0::US0_3, 3_i32)),
                    LrcPtr::new((Networking::US0::US0_4, 4_i32)),
                ])))),
            )) >= (find(
                v56,
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
    pub fn closure6(unitVar: (), v0: i64) -> Networking::US2 {
        Networking::US2::US2_0(v0)
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
        v0: LrcPtr<Networking::Mut0>,
        v1: LrcPtr<Networking::Mut1>,
        v2: LrcPtr<Networking::Mut2>,
        v3: LrcPtr<Networking::Mut3>,
        v4: LrcPtr<Networking::Mut4>,
        v5: Option<i64>,
    ) -> string {
        let v551: u64 = near_sdk::env::block_timestamp();
        let v576: Networking::US2 =
            defaultValue(Networking::US2::US2_1, map(Networking::method10(), v5));
        let v589: u64 = (match &v576 {
            Networking::US2::US2_0(v576_0_0) => {
                (v551)
                    - (match &v576 {
                        Networking::US2::US2_0(x) => x.clone(),
                        _ => unreachable!(),
                    } as u64)
            }
            _ => v551,
        }) / 1000000000_u64;
        let v590: u64 = (v589) % 60_u64;
        let v592: u64 = ((v589) / 60_u64) % 60_u64;
        let v594: u64 = ((v589) / 3600_u64) % 24_u64;
        let v596: std::string::String = format!("{:02}:{:02}:{:02}", v594, v592, v590);
        fable_library_rust::String_::fromString(v596)
    }
    pub fn method14() -> string {
        string("")
    }
    pub fn closure7(v0: LrcPtr<Networking::Mut3>, v1: string, unitVar: ()) {
        let v4: string = append((v0.l0.get().clone()), (v1));
        v0.l0.set(v4);
        ()
    }
    pub fn method15() -> string {
        string("\u{001b}[0m")
    }
    pub fn method13() -> string {
        let v7: char = getCharAt(toLower(string("Verbose")), 0_i32);
        let v9: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method14()),
        });
        let v24: () = {
            Networking::closure7(v9.clone(), sprintf!("{}", v7), ());
            ()
        };
        let v30: string = v9.l0.get().clone();
        let v131: &str = inline_colorization::color_bright_black;
        let v142: &str = &*v30;
        let v166: &str = inline_colorization::color_reset;
        let v168: std::string::String = format!("{}{}{}", v131, v142, v166);
        fable_library_rust::String_::fromString(v168)
    }
    pub fn method17(v0: string) -> string {
        trimEndChars(
            trimStartChars(v0, toArray(empty::<char>())),
            toArray(ofArray(new_array(&[' ', '/']))),
        )
    }
    pub fn method16(
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
        let v11: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method14()),
        });
        let v25: () = {
            Networking::closure7(v11.clone(), string("{ "), ());
            ()
        };
        let v44: () = {
            Networking::closure7(v11.clone(), string("port"), ());
            ()
        };
        let v63: () = {
            Networking::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v83: () = {
            Networking::closure7(v11.clone(), sprintf!("{}", v8), ());
            ()
        };
        let v102: () = {
            Networking::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v121: () = {
            Networking::closure7(v11.clone(), string("ex"), ());
            ()
        };
        let v138: () = {
            Networking::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v155: () = {
            Networking::closure7(v11.clone(), v9, ());
            ()
        };
        let v174: () = {
            Networking::closure7(v11.clone(), string(" }"), ());
            ()
        };
        let v180: string = v11.l0.get().clone();
        Networking::method17(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("networking.test_port_open"),
                )),
                string(" / "),
            )),
            (v180),
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
    pub fn method18(v0: string) {
        let v17: () = {
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
        let v41: LrcPtr<Networking::Mut3> = patternInput.3.clone();
        let v60: () = {
            Networking::closure8(patternInput.0.clone(), ());
            ()
        };
        let v83: string = if (v41.l0.get().clone()) == string("") {
            v0.clone()
        } else {
            if (v0.clone()) == string("") {
                v41.l0.get().clone()
            } else {
                append((append((v41.l0.get().clone()), string("\n"))), (v0.clone()))
            }
        };
        let v94: &str = &*v83.clone();
        let v118 = v94.chars();
        let v120 = v118;
        let v122: Vec<char> = v120.collect::<Vec<_>>();
        let v124: Vec<Vec<char>> = v122
            .chunks(15000)
            .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
            .collect::<Vec<_>>();
        let v126: bool = true;
        let _vec_map: Vec<_> = v124
            .into_iter()
            .map(|x| {
                //;
                let v128: Vec<char> = x;
                let v130: std::string::String = String::from_iter(v128);
                let v132: bool = true;
                v130
            })
            .collect::<Vec<_>>();
        let v134: Vec<std::string::String> = _vec_map;
        if if (v0.clone()) != string("") {
            (v134.clone().len() as i32) <= 1_i32
        } else {
            false
        } {
            v41.l0.set(v83);
            ()
        } else {
            v41.l0.set(string(""));
            {
                let v159: bool = true;
                v134.into_iter().for_each(|x| {
                    //;
                    let v161: std::string::String = x;
                    let v163: bool = true;
                    near_sdk::log!("{}", v161);
                    let v165: bool = true;
                    let v167: bool = true;
                }); //;
                ()
            }
        }
        ((patternInput.1.clone()).l0.get().clone())(v0)
    }
    pub fn closure5(v0: i32, v1: LrcPtr<Exception>, unitVar: ()) {
        if Networking::method8(Networking::US0::US0_0) {
            let v20: () = {
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
            let v46: Option<i64> = patternInput.5.clone();
            let v45: LrcPtr<Networking::Mut4> = patternInput.4.clone();
            let v44: LrcPtr<Networking::Mut3> = patternInput.3.clone();
            let v43: LrcPtr<Networking::Mut2> = patternInput.2.clone();
            let v42: LrcPtr<Networking::Mut1> = patternInput.1.clone();
            let v41: LrcPtr<Networking::Mut0> = patternInput.0.clone();
            Networking::method18(Networking::method16(
                v41.clone(),
                v42.clone(),
                v43.clone(),
                v44.clone(),
                v45.clone(),
                v46.clone(),
                Networking::method9(v41, v42, v43, v44, v45, v46),
                Networking::method13(),
                v0,
                sprintf!("{:?}", v1),
            ))
        };
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
    pub fn closure14(unitVar: (), v0: bool) -> Networking::US7 {
        Networking::US7::US7_0(v0)
    }
    pub fn method24() -> Func1<bool, Networking::US7> {
        Func1::new(move |v: bool| Networking::closure14((), v))
    }
    pub fn closure15(unitVar: (), v0: LrcPtr<Exception>) -> Networking::US7 {
        Networking::US7::US7_1(v0)
    }
    pub fn method25() -> Func1<LrcPtr<Exception>, Networking::US7> {
        Func1::new(move |v: LrcPtr<Exception>| Networking::closure15((), v))
    }
    pub fn method23(
        v0: Arc<Async<LrcPtr<Choice_2<bool, LrcPtr<Exception>>>>>,
    ) -> Arc<Async<Networking::US7>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method26(v0: Arc<Async<Networking::US7>>) -> Arc<Async<Networking::US8>> {
        fable_library_rust::Native_::getZero()
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
        let v10: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method14()),
        });
        let v24: () = {
            Networking::closure7(v10.clone(), string("{ "), ());
            ()
        };
        let v43: () = {
            Networking::closure7(v10.clone(), string("timeout"), ());
            ()
        };
        let v62: () = {
            Networking::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v82: () = {
            Networking::closure7(v10.clone(), sprintf!("{}", v8), ());
            ()
        };
        let v101: () = {
            Networking::closure7(v10.clone(), string(" }"), ());
            ()
        };
        let v107: string = v10.l0.get().clone();
        Networking::method17(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("async.run_with_timeout_async"),
                )),
                string(" / "),
            )),
            (v107),
        ))
    }
    pub fn closure16(v0: i32, unitVar: ()) {
        if Networking::method8(Networking::US0::US0_0) {
            let v19: () = {
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
            let v45: Option<i64> = patternInput.5.clone();
            let v44: LrcPtr<Networking::Mut4> = patternInput.4.clone();
            let v43: LrcPtr<Networking::Mut3> = patternInput.3.clone();
            let v42: LrcPtr<Networking::Mut2> = patternInput.2.clone();
            let v41: LrcPtr<Networking::Mut1> = patternInput.1.clone();
            let v40: LrcPtr<Networking::Mut0> = patternInput.0.clone();
            Networking::method18(Networking::method28(
                v40.clone(),
                v41.clone(),
                v42.clone(),
                v43.clone(),
                v44.clone(),
                v45.clone(),
                Networking::method9(v40, v41, v42, v43, v44, v45),
                Networking::method13(),
                v0,
            ))
        };
    }
    pub fn method29() -> string {
        let v7: char = getCharAt(toLower(string("Critical")), 0_i32);
        let v9: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method14()),
        });
        let v24: () = {
            Networking::closure7(v9.clone(), sprintf!("{}", v7), ());
            ()
        };
        let v30: string = v9.l0.get().clone();
        let v131: &str = inline_colorization::color_bright_red;
        let v142: &str = &*v30;
        let v166: &str = inline_colorization::color_reset;
        let v168: std::string::String = format!("{}{}{}", v131, v142, v166);
        fable_library_rust::String_::fromString(v168)
    }
    pub fn method30(
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
        let v11: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method14()),
        });
        let v25: () = {
            Networking::closure7(v11.clone(), string("{ "), ());
            ()
        };
        let v44: () = {
            Networking::closure7(v11.clone(), string("timeout"), ());
            ()
        };
        let v63: () = {
            Networking::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v83: () = {
            Networking::closure7(v11.clone(), sprintf!("{}", v8), ());
            ()
        };
        let v102: () = {
            Networking::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v121: () = {
            Networking::closure7(v11.clone(), string("ex"), ());
            ()
        };
        let v138: () = {
            Networking::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v155: () = {
            Networking::closure7(v11.clone(), v9, ());
            ()
        };
        let v174: () = {
            Networking::closure7(v11.clone(), string(" }"), ());
            ()
        };
        let v180: string = v11.l0.get().clone();
        Networking::method17(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("async.run_with_timeout_async**"),
                )),
                string(" / "),
            )),
            (v180),
        ))
    }
    pub fn closure17(v0: i32, v1: LrcPtr<Exception>, unitVar: ()) {
        if Networking::method8(Networking::US0::US0_4) {
            let v20: () = {
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
            let v46: Option<i64> = patternInput.5.clone();
            let v45: LrcPtr<Networking::Mut4> = patternInput.4.clone();
            let v44: LrcPtr<Networking::Mut3> = patternInput.3.clone();
            let v43: LrcPtr<Networking::Mut2> = patternInput.2.clone();
            let v42: LrcPtr<Networking::Mut1> = patternInput.1.clone();
            let v41: LrcPtr<Networking::Mut0> = patternInput.0.clone();
            Networking::method18(Networking::method30(
                v41.clone(),
                v42.clone(),
                v43.clone(),
                v44.clone(),
                v45.clone(),
                v46.clone(),
                Networking::method9(v41, v42, v43, v44, v45, v46),
                Networking::method29(),
                v0,
                sprintf!("{:?}", v1),
            ))
        };
    }
    pub fn method27(v0: i32, v1: Arc<Async<Networking::US8>>) -> Arc<Async<Networking::US6>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method22(v0: Arc<Async<bool>>, v1: i32) -> Arc<Async<Networking::US6>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method21(v0: i32, v1: Arc<Async<bool>>) -> Arc<Async<Networking::US6>> {
        Networking::method22(v1, v0)
    }
    pub fn method20(v0: i32, v1: string, v2: i32) -> Arc<Async<bool>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method19(v0: i32, v1: string, v2: i32) -> Arc<Async<bool>> {
        Networking::method20(v0, v1, v2)
    }
    pub fn closure13(v0: i32, v1: string, v2: i32) -> Arc<Async<bool>> {
        Networking::method19(v0, v1, v2)
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
    pub fn closure22(unitVar: (), v0: i32) -> Networking::US9 {
        Networking::US9::US9_0(v0)
    }
    pub fn method34() -> Func1<i32, Networking::US9> {
        Func1::new(move |v: i32| Networking::closure22((), v))
    }
    pub fn method35(
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
        let v13: LrcPtr<Networking::Mut3> = LrcPtr::new(Networking::Mut3 {
            l0: MutCell::new(Networking::method14()),
        });
        let v27: () = {
            Networking::closure7(v13.clone(), string("{ "), ());
            ()
        };
        let v46: () = {
            Networking::closure7(v13.clone(), string("port"), ());
            ()
        };
        let v65: () = {
            Networking::closure7(v13.clone(), string(" = "), ());
            ()
        };
        let v85: () = {
            Networking::closure7(v13.clone(), sprintf!("{}", v8), ());
            ()
        };
        let v104: () = {
            Networking::closure7(v13.clone(), string("; "), ());
            ()
        };
        let v123: () = {
            Networking::closure7(v13.clone(), string("retry"), ());
            ()
        };
        let v140: () = {
            Networking::closure7(v13.clone(), string(" = "), ());
            ()
        };
        let v160: () = {
            Networking::closure7(v13.clone(), sprintf!("{}", v9), ());
            ()
        };
        let v177: () = {
            Networking::closure7(v13.clone(), string("; "), ());
            ()
        };
        let v196: () = {
            Networking::closure7(v13.clone(), string("timeout"), ());
            ()
        };
        let v213: () = {
            Networking::closure7(v13.clone(), string(" = "), ());
            ()
        };
        let v233: std::string::String = format!("{:#?}", v10);
        let v269: () = {
            Networking::closure7(
                v13.clone(),
                fable_library_rust::String_::fromString(v233),
                (),
            );
            ()
        };
        let v286: () = {
            Networking::closure7(v13.clone(), string("; "), ());
            ()
        };
        let v305: () = {
            Networking::closure7(v13.clone(), string("status"), ());
            ()
        };
        let v322: () = {
            Networking::closure7(v13.clone(), string(" = "), ());
            ()
        };
        let v342: () = {
            Networking::closure7(
                v13.clone(),
                if v11 { string("true") } else { string("false") },
                (),
            );
            ()
        };
        let v361: () = {
            Networking::closure7(v13.clone(), string(" }"), ());
            ()
        };
        let v367: string = v13.l0.get().clone();
        Networking::method17(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("networking.wait_for_port_access"),
                )),
                string(" / "),
            )),
            (v367),
        ))
    }
    pub fn closure23(v0: Option<i32>, v1: bool, v2: i32, v3: i64, unitVar: ()) {
        if Networking::method8(Networking::US0::US0_0) {
            let v22: () = {
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
            let v48: Option<i64> = patternInput.5.clone();
            let v47: LrcPtr<Networking::Mut4> = patternInput.4.clone();
            let v46: LrcPtr<Networking::Mut3> = patternInput.3.clone();
            let v45: LrcPtr<Networking::Mut2> = patternInput.2.clone();
            let v44: LrcPtr<Networking::Mut1> = patternInput.1.clone();
            let v43: LrcPtr<Networking::Mut0> = patternInput.0.clone();
            Networking::method18(Networking::method35(
                v43.clone(),
                v44.clone(),
                v45.clone(),
                v46.clone(),
                v47.clone(),
                v48.clone(),
                Networking::method9(v43, v44, v45, v46, v47, v48),
                Networking::method13(),
                v2,
                v3,
                v0,
                v1,
            ))
        };
    }
    pub fn method33(v0: Option<i32>, v1: bool, v2: string, v3: i32, v4: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method32(v0: Option<i32>, v1: bool, v2: string, v3: i32, v4: i64) -> Arc<Async<i64>> {
        Networking::method33(v0, v1, v2, v3, v4)
    }
    pub fn method31(v0: Option<i32>, v1: bool, v2: string, v3: i32) -> Arc<Async<i64>> {
        Networking::method32(v0, v1, v2, v3, 1_i64)
    }
    pub fn closure21(v0: Option<i32>, v1: bool, v2: string, v3: i32) -> Arc<Async<i64>> {
        Networking::method31(v0, v1, v2, v3)
    }
    pub fn closure20(v0: Option<i32>, v1: bool, v2: string) -> Func1<i32, Arc<Async<i64>>> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            let v2 = v2.clone();
            move |v: i32| Networking::closure21(v0.clone(), v1, v2.clone(), v)
        })
    }
    pub fn closure19(v0: Option<i32>, v1: bool) -> Func1<string, Func1<i32, Arc<Async<i64>>>> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            move |v: string| Networking::closure20(v0.clone(), v1, v)
        })
    }
    pub fn closure18(
        unitVar: (),
        v0: Option<i32>,
    ) -> Func1<bool, Func1<string, Func1<i32, Arc<Async<i64>>>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: bool| Networking::closure19(v0.clone(), v)
        })
    }
    pub fn method38(v0: Option<i32>, v1: string, v2: i32) -> Arc<Async<i32>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method37(v0: Option<i32>, v1: string, v2: i32) -> Arc<Async<i32>> {
        Networking::method38(v0, v1, v2)
    }
    pub fn method36(v0: Option<i32>, v1: string, v2: i32) -> Arc<Async<i32>> {
        Networking::method37(v0, v1, v2)
    }
    pub fn closure26(v0: Option<i32>, v1: string, v2: i32) -> Arc<Async<i32>> {
        Networking::method36(v0, v1, v2)
    }
    pub fn closure25(v0: Option<i32>, v1: string) -> Func1<i32, Arc<Async<i32>>> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            move |v: i32| Networking::closure26(v0.clone(), v1.clone(), v)
        })
    }
    pub fn closure24(unitVar: (), v0: Option<i32>) -> Func1<string, Func1<i32, Arc<Async<i32>>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| Networking::closure25(v0.clone(), v)
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
        v33.get_or_init(|| Func1::new(move |v: Option<i32>| Networking::closure18((), v)))
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
        v34.get_or_init(|| Func1::new(move |v: Option<i32>| Networking::closure24((), v)))
            .clone()
    }
    pub fn get_available_port(x: Option<i32>) -> Func1<string, Func1<i32, Arc<Async<i32>>>> {
        (Networking::v34())(x)
    }
    on_startup!(());
}
