pub mod Common {
    use super::*;
    type DateTime = ();
    use fable_library_rust::Exception_::try_catch;
    use fable_library_rust::FSharp::Control::LazyExtensions;
    use fable_library_rust::List_::empty;
    use fable_library_rust::List_::ofArray;
    use fable_library_rust::List_::toArray;
    use fable_library_rust::Map_::find;
    use fable_library_rust::Map_::ofSeq;
    use fable_library_rust::Native_::Any;
    use fable_library_rust::Native_::Func0;
    use fable_library_rust::Native_::Func1;
    use fable_library_rust::Native_::Lrc;
    use fable_library_rust::Native_::LrcPtr;
    use fable_library_rust::Native_::MutCell;
    use fable_library_rust::Native_::OnceInit;
    use fable_library_rust::Native_::interface_cast;
    use fable_library_rust::Native_::null;
    use fable_library_rust::Native_::on_startup;
    use fable_library_rust::Native_::refCell;
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
    use fable_library_rust::System::IDisposable;
    use fable_library_rust::System::Lazy_1;
    pub mod TraceState {
        use super::*;
        pub fn trace_state() -> LrcPtr<
            MutCell<
                Option<(
                    LrcPtr<Common::Mut0>,
                    LrcPtr<Common::Mut1>,
                    LrcPtr<Common::Mut2>,
                    LrcPtr<Common::Mut3>,
                    LrcPtr<Common::Mut4>,
                    Option<i64>,
                )>,
            >,
        > {
            static trace_state: OnceInit<
                LrcPtr<
                    MutCell<
                        Option<(
                            LrcPtr<Common::Mut0>,
                            LrcPtr<Common::Mut1>,
                            LrcPtr<Common::Mut2>,
                            LrcPtr<Common::Mut3>,
                            LrcPtr<Common::Mut4>,
                            Option<i64>,
                        )>,
                    >,
                >,
            > = OnceInit::new();
            trace_state
                .get_or_init(|| {
                    LrcPtr::new(MutCell::new(
                        None::<(
                            LrcPtr<Common::Mut0>,
                            LrcPtr<Common::Mut1>,
                            LrcPtr<Common::Mut2>,
                            LrcPtr<Common::Mut3>,
                            LrcPtr<Common::Mut4>,
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
    pub struct Disposable {
        f: Func0<()>,
    }
    impl Disposable {
        pub fn _ctor__3A5B6456(f: Func0<()>) -> LrcPtr<Common::Disposable> {
            let f_1;
            ();
            f_1 = f;
            ();
            LrcPtr::new(Common::Disposable { f: f_1 })
        }
    }
    impl core::fmt::Display for Disposable {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    impl IDisposable for Disposable {
        fn Dispose(&self) {
            (self.f)();
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
        pub l0: MutCell<Common::US0>,
    }
    impl core::fmt::Display for Mut4 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US1 {
        US1_0(Common::US0),
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
        US4_0(Common::US3),
        US4_1(Common::US3),
        US4_2(Common::US3),
        US4_3(Common::US3),
        US4_4(Common::US3),
        US4_5(Common::US3),
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
        US6_0,
        US6_1,
    }
    impl core::fmt::Display for US6 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US7 {
        US7_0(Common::US6),
        US7_1,
    }
    impl core::fmt::Display for US7 {
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
    pub fn closure1(unitVar: (), v0: string) -> Common::US5 {
        Common::US5::US5_0(v0)
    }
    pub fn method5() -> Func1<string, Common::US5> {
        Func1::new(move |v: string| Common::closure1((), v))
    }
    pub fn method2(v0: string) -> string {
        panic!(
            "{}",
            sprintf!(
                "env.get_environment_variable / target: {} / var: {}",
                Common::US4::US4_3(Common::US3::US3_2),
                v0
            ),
        )
    }
    pub fn method1() -> (Common::US1, Common::US2) {
        let v1: string = Common::method2(string("TRACE_LEVEL"));
        let v6: string = toLower(string("Critical"));
        let v13: string = toLower(string("Warning"));
        let v20: string = toLower(string("Info"));
        let v27: string = toLower(string("Debug"));
        let v34: string = toLower(string("Verbose"));
        let v41: Common::US1 = if string("Verbose") == (v1.clone()) {
            Common::US1::US1_0(Common::US0::US0_0)
        } else {
            Common::US1::US1_1
        };
        (
            match &v41 {
                Common::US1::US1_0(v41_0_0) => Common::US1::US1_0(
                    match &v41 {
                        Common::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                ),
                _ => {
                    let v48: Common::US1 = if string("Debug") == (v1.clone()) {
                        Common::US1::US1_0(Common::US0::US0_1)
                    } else {
                        Common::US1::US1_1
                    };
                    match &v48 {
                        Common::US1::US1_0(v48_0_0) => Common::US1::US1_0(
                            match &v48 {
                                Common::US1::US1_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v55: Common::US1 = if string("Info") == (v1.clone()) {
                                Common::US1::US1_0(Common::US0::US0_2)
                            } else {
                                Common::US1::US1_1
                            };
                            match &v55 {
                                Common::US1::US1_0(v55_0_0) => Common::US1::US1_0(
                                    match &v55 {
                                        Common::US1::US1_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v62: Common::US1 = if string("Warning") == (v1.clone()) {
                                        Common::US1::US1_0(Common::US0::US0_3)
                                    } else {
                                        Common::US1::US1_1
                                    };
                                    match &v62 {
                                        Common::US1::US1_0(v62_0_0) => Common::US1::US1_0(
                                            match &v62 {
                                                Common::US1::US1_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        ),
                                        _ => {
                                            let v69: Common::US1 =
                                                if string("Critical") == (v1.clone()) {
                                                    Common::US1::US1_0(Common::US0::US0_4)
                                                } else {
                                                    Common::US1::US1_1
                                                };
                                            match &v69 {
                                                Common::US1::US1_0(v69_0_0) => Common::US1::US1_0(
                                                    match &v69 {
                                                        Common::US1::US1_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                ),
                                                _ => {
                                                    let v76: Common::US1 =
                                                        if (v34.clone()) == (v1.clone()) {
                                                            Common::US1::US1_0(Common::US0::US0_0)
                                                        } else {
                                                            Common::US1::US1_1
                                                        };
                                                    match &v76 {
                                                        Common::US1::US1_0(v76_0_0) => {
                                                            Common::US1::US1_0(
                                                                match &v76 {
                                                                    Common::US1::US1_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            let v83: Common::US1 =
                                                                if (v27.clone()) == (v1.clone()) {
                                                                    Common::US1::US1_0(
                                                                        Common::US0::US0_1,
                                                                    )
                                                                } else {
                                                                    Common::US1::US1_1
                                                                };
                                                            match &v83 {
                                                                Common::US1::US1_0(v83_0_0) => {
                                                                    Common::US1::US1_0(
                                                                        match &v83 {
                                                                            Common::US1::US1_0(
                                                                                x,
                                                                            ) => x.clone(),
                                                                            _ => unreachable!(),
                                                                        }
                                                                        .clone(),
                                                                    )
                                                                }
                                                                _ => {
                                                                    let v90: Common::US1 = if (v20
                                                                        .clone())
                                                                        == (v1.clone())
                                                                    {
                                                                        Common::US1::US1_0(
                                                                            Common::US0::US0_2,
                                                                        )
                                                                    } else {
                                                                        Common::US1::US1_1
                                                                    };
                                                                    match &v90 {
                                                                     Common::US1::US1_0(v90_0_0)
                                                                     =>
                                                                     Common::US1::US1_0(match &v90
                                                                                            {
                                                                                            Common::US1::US1_0(x)
                                                                                            =>
                                                                                            x.clone(),
                                                                                            _
                                                                                            =>
                                                                                            unreachable!(),
                                                                                        }.clone()),
                                                                     _ => {
                                                                         let v97:
                                                                                 Common::US1 =
                                                                             if (v13.clone())
                                                                                    ==
                                                                                    (v1.clone())
                                                                                {
                                                                                 Common::US1::US1_0(Common::US0::US0_3)
                                                                             } else {
                                                                                 Common::US1::US1_1
                                                                             };
                                                                         match &v97
                                                                             {
                                                                             Common::US1::US1_0(v97_0_0)
                                                                             =>
                                                                             Common::US1::US1_0(match &v97
                                                                                                    {
                                                                                                    Common::US1::US1_0(x)
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
                                                                                         Common::US1 =
                                                                                     if (v6.clone())
                                                                                            ==
                                                                                            (v1.clone())
                                                                                        {
                                                                                         Common::US1::US1_0(Common::US0::US0_4)
                                                                                     } else {
                                                                                         Common::US1::US1_1
                                                                                     };
                                                                                 match &v104
                                                                                     {
                                                                                     Common::US1::US1_0(v104_0_0)
                                                                                     =>
                                                                                     Common::US1::US1_0(match &v104
                                                                                                            {
                                                                                                            Common::US1::US1_0(x)
                                                                                                            =>
                                                                                                            x.clone(),
                                                                                                            _
                                                                                                            =>
                                                                                                            unreachable!(),
                                                                                                        }.clone()),
                                                                                     _
                                                                                     =>
                                                                                     Common::US1::US1_1,
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
            if (Common::method2(string("AUTOMATION"))) != string("True") {
                Common::US2::US2_1
            } else {
                let v147: DateTime = unbox::<DateTime>(fable_library_rust::Native_::getZero());
                Common::US2::US2_0(unbox::<i64>(fable_library_rust::Native_::getZero()))
            },
        )
    }
    pub fn closure2(unitVar: (), v0: string) {
        ();
    }
    pub fn method0(
        v0: Common::US0,
    ) -> (
        LrcPtr<Common::Mut0>,
        LrcPtr<Common::Mut1>,
        LrcPtr<Common::Mut2>,
        LrcPtr<Common::Mut3>,
        LrcPtr<Common::Mut4>,
        Option<i64>,
    ) {
        let v88: string = string("option_env!(\"AUTOMATION\").unwrap_or(\"\")");
        let v89: &str = option_env!("AUTOMATION").unwrap_or("");
        let v100: std::string::String = String::from(v89);
        let _run_target_args__v3: (Common::US1, Common::US2) = (
            Common::US1::US1_1,
            if (fable_library_rust::String_::fromString(v100)) != string("True") {
                Common::US2::US2_1
            } else {
                Common::US2::US2_0(near_sdk::env::block_timestamp() as i64)
            },
        );
        let v173: Common::US2 = _run_target_args__v3.1.clone();
        let v172: Common::US1 = _run_target_args__v3.0.clone();
        (
            LrcPtr::new(Common::Mut0 {
                l0: MutCell::new(1_i64),
            }),
            LrcPtr::new(Common::Mut1 {
                l0: MutCell::new(Func1::new(move |v: string| Common::closure2((), v))),
            }),
            LrcPtr::new(Common::Mut2 {
                l0: MutCell::new(true),
            }),
            LrcPtr::new(Common::Mut3 {
                l0: MutCell::new(string("")),
            }),
            LrcPtr::new(Common::Mut4 {
                l0: MutCell::new(match &v172 {
                    Common::US1::US1_0(v172_0_0) => match &v172 {
                        Common::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    _ => v0.clone(),
                }),
            }),
            match &v173 {
                Common::US2::US2_0(v173_0_0) => Some(match &v173 {
                    Common::US2::US2_0(x) => x.clone(),
                    _ => unreachable!(),
                }),
                _ => None::<i64>,
            },
        )
    }
    pub fn closure0(unitVar: (), unitVar_1: ()) {
        if Common::TraceState::trace_state().get().clone().is_none() {
            let patternInput: (
                LrcPtr<Common::Mut0>,
                LrcPtr<Common::Mut1>,
                LrcPtr<Common::Mut2>,
                LrcPtr<Common::Mut3>,
                LrcPtr<Common::Mut4>,
                Option<i64>,
            ) = Common::method0(Common::US0::US0_0);
            Common::TraceState::trace_state().set(Some((
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
    pub fn method6(v0: Func0<()>) -> Func0<()> {
        v0
    }
    pub fn method7(v0: Func0<()>) -> Func0<()> {
        v0
    }
    pub fn closure3(unitVar: (), v0: Func0<()>) -> LrcPtr<dyn IDisposable> {
        let v10 = Common::method6(v0);
        interface_cast!(
            Common::Disposable::_ctor__3A5B6456(Func0::new({
                let v10 = v10.clone();
                move || v10.clone()()
            })),
            Lrc<dyn IDisposable>,
        )
    }
    pub fn closure6(unitVar: (), v0: Common::US6) -> Common::US7 {
        Common::US7::US7_0(v0)
    }
    pub fn closure7(v0: i32, v1: Func0<()>, v2: i32, unitVar: ()) -> Common::US6 {
        if (v2) < (v0) {
            v1();
            Common::US6::US6_0
        } else {
            Common::US6::US6_1
        }
    }
    pub fn method9(v0: Common::US0) -> bool {
        let v17: () = {
            Common::closure0((), ());
            ()
        };
        let patternInput: (
            LrcPtr<Common::Mut0>,
            LrcPtr<Common::Mut1>,
            LrcPtr<Common::Mut2>,
            LrcPtr<Common::Mut3>,
            LrcPtr<Common::Mut4>,
            Option<i64>,
        ) = Common::TraceState::trace_state().get().clone().unwrap();
        let v56: Common::US0 = (patternInput.4.clone()).l0.get().clone();
        if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            (find(
                v0,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Common::US0::US0_0, 0_i32)),
                    LrcPtr::new((Common::US0::US0_1, 1_i32)),
                    LrcPtr::new((Common::US0::US0_2, 2_i32)),
                    LrcPtr::new((Common::US0::US0_3, 3_i32)),
                    LrcPtr::new((Common::US0::US0_4, 4_i32)),
                ])))),
            )) >= (find(
                v56,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Common::US0::US0_0, 0_i32)),
                    LrcPtr::new((Common::US0::US0_1, 1_i32)),
                    LrcPtr::new((Common::US0::US0_2, 2_i32)),
                    LrcPtr::new((Common::US0::US0_3, 3_i32)),
                    LrcPtr::new((Common::US0::US0_4, 4_i32)),
                ])))),
            ))
        }
    }
    pub fn closure10(unitVar: (), v0: i64) -> Common::US2 {
        Common::US2::US2_0(v0)
    }
    pub fn method11() -> Func1<i64, Common::US2> {
        Func1::new(move |v: i64| Common::closure10((), v))
    }
    pub fn method12() -> string {
        string("hh:mm:ss")
    }
    pub fn method13() -> string {
        string("HH:mm:ss")
    }
    pub fn method10(
        v0: LrcPtr<Common::Mut0>,
        v1: LrcPtr<Common::Mut1>,
        v2: LrcPtr<Common::Mut2>,
        v3: LrcPtr<Common::Mut3>,
        v4: LrcPtr<Common::Mut4>,
        v5: Option<i64>,
    ) -> string {
        let v551: u64 = near_sdk::env::block_timestamp();
        let v576: Common::US2 = defaultValue(Common::US2::US2_1, map(Common::method11(), v5));
        let v589: u64 = (match &v576 {
            Common::US2::US2_0(v576_0_0) => {
                (v551)
                    - (match &v576 {
                        Common::US2::US2_0(x) => x.clone(),
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
    pub fn method15() -> string {
        string("")
    }
    pub fn closure11(v0: LrcPtr<Common::Mut3>, v1: string, unitVar: ()) {
        let v4: string = append((v0.l0.get().clone()), (v1));
        v0.l0.set(v4);
        ()
    }
    pub fn method16() -> string {
        string("\u{001b}[0m")
    }
    pub fn method14() -> string {
        let v7: char = getCharAt(toLower(string("Warning")), 0_i32);
        let v9: LrcPtr<Common::Mut3> = LrcPtr::new(Common::Mut3 {
            l0: MutCell::new(Common::method15()),
        });
        let v24: () = {
            Common::closure11(v9.clone(), sprintf!("{}", v7), ());
            ()
        };
        let v30: string = v9.l0.get().clone();
        let v131: &str = inline_colorization::color_yellow;
        let v142: &str = &*v30;
        let v166: &str = inline_colorization::color_reset;
        let v168: std::string::String = format!("{}{}{}", v131, v142, v166);
        fable_library_rust::String_::fromString(v168)
    }
    pub fn method18(v0: string) -> string {
        trimEndChars(
            trimStartChars(v0, toArray(empty::<char>())),
            toArray(ofArray(new_array(&[' ', '/']))),
        )
    }
    pub fn method17(
        v0: LrcPtr<Common::Mut0>,
        v1: LrcPtr<Common::Mut1>,
        v2: LrcPtr<Common::Mut2>,
        v3: LrcPtr<Common::Mut3>,
        v4: LrcPtr<Common::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i32,
        v9: LrcPtr<Exception>,
    ) -> string {
        let v11: LrcPtr<Common::Mut3> = LrcPtr::new(Common::Mut3 {
            l0: MutCell::new(Common::method15()),
        });
        let v25: () = {
            Common::closure11(v11.clone(), string("{ "), ());
            ()
        };
        let v44: () = {
            Common::closure11(v11.clone(), string("retry"), ());
            ()
        };
        let v63: () = {
            Common::closure11(v11.clone(), string(" = "), ());
            ()
        };
        let v83: () = {
            Common::closure11(v11.clone(), sprintf!("{}", v8), ());
            ()
        };
        let v102: () = {
            Common::closure11(v11.clone(), string("; "), ());
            ()
        };
        let v121: () = {
            Common::closure11(v11.clone(), string("ex"), ());
            ()
        };
        let v138: () = {
            Common::closure11(v11.clone(), string(" = "), ());
            ()
        };
        let v158: std::string::String = format!("{:#?}", v9);
        let v194: () = {
            Common::closure11(
                v11.clone(),
                fable_library_rust::String_::fromString(v158),
                (),
            );
            ()
        };
        let v213: () = {
            Common::closure11(v11.clone(), string(" }"), ());
            ()
        };
        let v219: string = v11.l0.get().clone();
        Common::method18(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("common.retry_fn"),
                )),
                string(" / "),
            )),
            (v219),
        ))
    }
    pub fn closure12(v0: LrcPtr<Common::Mut0>, unitVar: ()) {
        let v2: i64 = (v0.l0.get().clone()) + 1_i64;
        v0.l0.set(v2);
        ()
    }
    pub fn closure14(v0: string, unitVar: ()) {
        printfn!("{0}", v0);
    }
    pub fn closure13(unitVar: (), v0: string) {
        let v4: () = {
            Common::closure14(v0, ());
            ()
        };
        ()
    }
    pub fn method19(v0: string) {
        let v17: () = {
            Common::closure0((), ());
            ()
        };
        let patternInput: (
            LrcPtr<Common::Mut0>,
            LrcPtr<Common::Mut1>,
            LrcPtr<Common::Mut2>,
            LrcPtr<Common::Mut3>,
            LrcPtr<Common::Mut4>,
            Option<i64>,
        ) = Common::TraceState::trace_state().get().clone().unwrap();
        let v41: LrcPtr<Common::Mut3> = patternInput.3.clone();
        let v60: () = {
            Common::closure12(patternInput.0.clone(), ());
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
    pub fn closure9(v0: i32, v1: LrcPtr<Exception>, unitVar: ()) {
        if Common::method9(Common::US0::US0_3) {
            let v20: () = {
                Common::closure0((), ());
                ()
            };
            let patternInput: (
                LrcPtr<Common::Mut0>,
                LrcPtr<Common::Mut1>,
                LrcPtr<Common::Mut2>,
                LrcPtr<Common::Mut3>,
                LrcPtr<Common::Mut4>,
                Option<i64>,
            ) = Common::TraceState::trace_state().get().clone().unwrap();
            let v46: Option<i64> = patternInput.5.clone();
            let v45: LrcPtr<Common::Mut4> = patternInput.4.clone();
            let v44: LrcPtr<Common::Mut3> = patternInput.3.clone();
            let v43: LrcPtr<Common::Mut2> = patternInput.2.clone();
            let v42: LrcPtr<Common::Mut1> = patternInput.1.clone();
            let v41: LrcPtr<Common::Mut0> = patternInput.0.clone();
            Common::method19(Common::method17(
                v41.clone(),
                v42.clone(),
                v43.clone(),
                v44.clone(),
                v45.clone(),
                v46.clone(),
                Common::method10(v41, v42, v43, v44, v45, v46),
                Common::method14(),
                v0,
                v1,
            ))
        };
    }
    pub fn closure8(v0: i32, v1: LrcPtr<Exception>) -> Common::US7 {
        let v64: () = {
            Common::closure9(v0, v1, ());
            ()
        };
        Common::US7::US7_1
    }
    pub fn method8(v0: i32, v1: Func0<()>, v2: i32) -> Common::US6 {
        let v0: MutCell<i32> = MutCell::new(v0);
        let v1 = MutCell::new(v1.clone());
        let v2: MutCell<i32> = MutCell::new(v2);
        '_method8: loop {
            break '_method8 ({
                let result: LrcPtr<MutCell<Common::US7>> = refCell(Common::US7::US7_1);
                try_catch(
                    || {
                        result.set(Common::closure6(
                            (),
                            Common::closure7(
                                v0.get().clone(),
                                v1.get().clone(),
                                v2.get().clone(),
                                (),
                            ),
                        ))
                    },
                    |ex: LrcPtr<Exception>| {
                        result.set(Common::closure8(v2.get().clone(), ex.clone()))
                    },
                );
                {
                    let v8: Common::US7 = result.get().clone();
                    match &v8 {
                        Common::US7::US7_0(v8_0_0) => match &v8 {
                            Common::US7::US7_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => {
                            let v0_temp: i32 = v0.get().clone();
                            let v1_temp = v1.get().clone();
                            let v2_temp: i32 = (v2.get().clone()) + 1_i32;
                            v0.set(v0_temp);
                            v1.set(v1_temp);
                            v2.set(v2_temp);
                            continue '_method8;
                        }
                    }
                }
            });
        }
    }
    pub fn closure5(v0: i32, v1: Func0<()>) -> Option<()> {
        let v3: Common::US6 = Common::method8(v0, v1, 0_i32);
        match &v3 {
            Common::US6::US6_0 => Some(()),
            _ => None::<()>,
        }
    }
    pub fn closure4(unitVar: (), v0: i32) -> Func1<Func0<()>, Option<()>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: Func0<()>| Common::closure5(v0, v)
        })
    }
    pub fn method20(v0: Func0<()>) -> Func0<()> {
        v0
    }
    pub fn closure16(v0: LrcPtr<Lazy_1<()>>, unitVar: ()) {
        v0.get_Value();
        ()
    }
    pub fn closure15(unitVar: (), v0: Func0<()>) -> Func0<()> {
        let v1 = Common::method20(v0);
        let v6: LrcPtr<Lazy_1<()>> = LazyExtensions::Create(Func0::new({
            let v1 = v1.clone();
            move || v1()
        }));
        Func0::new({
            let v6 = v6.clone();
            move || Common::closure16(v6.clone(), ())
        })
    }
    pub fn v14() -> () {
        static v14: OnceInit<()> = OnceInit::new();
        v14.get_or_init(|| ()).clone()
    }
    pub fn v15() -> Func0<()> {
        static v15: OnceInit<Func0<()>> = OnceInit::new();
        v15.get_or_init(|| Func0::new(move || Common::closure0((), ())))
            .clone()
    }
    pub fn v16() -> () {
        static v16: OnceInit<()> = OnceInit::new();
        v16.get_or_init(|| {
            (Common::v15())();
            Common::v14()
        })
        .clone()
    }
    pub fn v31() -> Func1<Func0<()>, LrcPtr<dyn IDisposable>> {
        static v31: OnceInit<Func1<Func0<()>, LrcPtr<dyn IDisposable>>> = OnceInit::new();
        v31.get_or_init(|| Func1::new(move |v: Func0<()>| Common::closure3((), v)))
            .clone()
    }
    pub fn new_disposable(x: Func0<()>) -> LrcPtr<dyn IDisposable> {
        (Common::v31())(x)
    }
    pub fn v32() -> Func1<i32, Func1<Func0<()>, Option<()>>> {
        static v32: OnceInit<Func1<i32, Func1<Func0<()>, Option<()>>>> = OnceInit::new();
        v32.get_or_init(|| Func1::new(move |v: i32| Common::closure4((), v)))
            .clone()
    }
    pub fn retry_fn(x: i32) -> Func1<Func0<()>, Option<()>> {
        (Common::v32())(x)
    }
    pub fn v33() -> Func1<Func0<()>, Func0<()>> {
        static v33: OnceInit<Func1<Func0<()>, Func0<()>>> = OnceInit::new();
        v33.get_or_init(|| Func1::new(move |v: Func0<()>| Common::closure15((), v)))
            .clone()
    }
    pub fn memoize(x: Func0<()>) -> Func0<()> {
        (Common::v33())(x)
    }
    on_startup!(());
}
