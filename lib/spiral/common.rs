pub mod Common {
    use super::*;
    use fable_library_rust::DateTime_::DateTime;
    use fable_library_rust::Exception_::try_catch;
    use fable_library_rust::FSharp::Control::LazyExtensions;
    use fable_library_rust::List_::empty;
    use fable_library_rust::List_::ofArray;
    use fable_library_rust::List_::toArray;
    use fable_library_rust::Map_::find;
    use fable_library_rust::Map_::ofSeq;
    use fable_library_rust::NativeArray_::new_array;
    use fable_library_rust::Native_::interface_cast;
    use fable_library_rust::Native_::on_startup;
    use fable_library_rust::Native_::refCell;
    use fable_library_rust::Native_::Any;
    use fable_library_rust::Native_::Func0;
    use fable_library_rust::Native_::Func1;
    use fable_library_rust::Native_::Lrc;
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
    use fable_library_rust::System::IDisposable;
    use fable_library_rust::System::Lazy_1;
    use fable_library_rust::TimeSpan_::TimeSpan;
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
    pub fn method3(v0_1: string) -> string {
        v0_1
    }
    pub fn method4() -> string {
        string("")
    }
    pub fn closure1(unitVar: (), v0_1: string) -> Common::US5 {
        Common::US5::US5_0(v0_1)
    }
    pub fn method5() -> Func1<string, Common::US5> {
        Func1::new(move |v: string| Common::closure1((), v))
    }
    pub fn method2(v0_1: string) -> string {
        let v6: string = Common::method3(v0_1);
        let v8: Result<std::string::String, std::env::VarError> = std::env::var(&*v6);
        let v10: bool = true;
        let _result_map_ = v8.map(|x| {
            //;
            let v12: std::string::String = x;
            let v14: string = fable_library_rust::String_::fromString(v12);
            let v16: bool = true;
            v14
        });
        let v18_1: Result<string, std::env::VarError> = _result_map_;
        let v19_1: string = Common::method4();
        v18_1.unwrap_or(v19_1)
    }
    pub fn method1() -> (Common::US1, Common::US2) {
        let v1_1: string = Common::method2(string("TRACE_LEVEL"));
        let v6: string = toLower(string("Critical"));
        let v13: string = toLower(string("Warning"));
        let v20: string = toLower(string("Info"));
        let v27: string = toLower(string("Debug"));
        let v34: string = toLower(string("Verbose"));
        let v41: Common::US1 = if string("Verbose") == (v1_1.clone()) {
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
                    let v48: Common::US1 = if string("Debug") == (v1_1.clone()) {
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
                            let v55: Common::US1 = if string("Info") == (v1_1.clone()) {
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
                                    let v62: Common::US1 = if string("Warning") == (v1_1.clone()) {
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
                                                if string("Critical") == (v1_1.clone()) {
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
                                                        if (v34.clone()) == (v1_1.clone()) {
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
                                                            let v83: Common::US1 = if (v27.clone())
                                                                == (v1_1.clone())
                                                            {
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
                                                                        == (v1_1.clone())
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
                                                                                    (v1_1.clone())
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
                                                                                            (v1_1.clone())
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
                Common::US2::US2_0({
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
        v0_1: Common::US0,
    ) -> (
        LrcPtr<Common::Mut0>,
        LrcPtr<Common::Mut1>,
        LrcPtr<Common::Mut2>,
        LrcPtr<Common::Mut3>,
        LrcPtr<Common::Mut4>,
        Option<i64>,
    ) {
        let patternInput: (Common::US1, Common::US2) = Common::method1();
        let _run_target_args__v3: (Common::US1, Common::US2) =
            (patternInput.0.clone(), patternInput.1.clone());
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
                    _ => v0_1.clone(),
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
    pub fn method6(v0_1: Func0<()>) -> Func0<()> {
        v0_1
    }
    pub fn method7(v0_1: Func0<()>) -> Func0<()> {
        v0_1
    }
    pub fn closure3(unitVar: (), v0_1: Func0<()>) -> LrcPtr<dyn IDisposable> {
        let v6 = Common::method6(v0_1);
        interface_cast!(
            Common::Disposable::_ctor__3A5B6456(Func0::new({
                let v6 = v6.clone();
                move || v6.clone()()
            })),
            Lrc<dyn IDisposable>,
        )
    }
    pub fn closure6(unitVar: (), v0_1: Common::US6) -> Common::US7 {
        Common::US7::US7_0(v0_1)
    }
    pub fn closure7(v0_1: i32, v1_1: Func0<()>, v2_1: i32, unitVar: ()) -> Common::US6 {
        if (v2_1) < (v0_1) {
            v1_1();
            Common::US6::US6_0
        } else {
            Common::US6::US6_1
        }
    }
    pub fn method9(v0_1: Common::US0) -> bool {
        let v3: () = {
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
        let v42: Common::US0 = (patternInput.4.clone()).l0.get().clone();
        if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            (find(
                v0_1,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Common::US0::US0_0, 0_i32)),
                    LrcPtr::new((Common::US0::US0_1, 1_i32)),
                    LrcPtr::new((Common::US0::US0_2, 2_i32)),
                    LrcPtr::new((Common::US0::US0_3, 3_i32)),
                    LrcPtr::new((Common::US0::US0_4, 4_i32)),
                ])))),
            )) >= (find(
                v42,
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
    pub fn closure10(unitVar: (), v0_1: i64) -> Common::US2 {
        Common::US2::US2_0(v0_1)
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
        v0_1: LrcPtr<Common::Mut0>,
        v1_1: LrcPtr<Common::Mut1>,
        v2_1: LrcPtr<Common::Mut2>,
        v3: LrcPtr<Common::Mut3>,
        v4: LrcPtr<Common::Mut4>,
        v5: Option<i64>,
    ) -> string {
        let v198: Common::US2 = defaultValue(Common::US2::US2_1, map(Common::method11(), v5));
        let v316: DateTime = match &v198 {
            Common::US2::US2_0(v198_0_0) => {
                let v268: TimeSpan = TimeSpan::new_ticks(
                    ({
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    }) - (match &v198 {
                        Common::US2::US2_0(x) => x.clone(),
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
        let v318: string = Common::method12();
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
    pub fn closure11(v0_1: LrcPtr<Common::Mut3>, v1_1: string, unitVar: ()) {
        let v3: string = append((v0_1.l0.get().clone()), (v1_1));
        v0_1.l0.set(v3);
        ()
    }
    pub fn method15(v0_1: char) -> string {
        let v2_1: LrcPtr<Common::Mut3> = LrcPtr::new(Common::Mut3 {
            l0: MutCell::new(Common::method16()),
        });
        let v9: () = {
            Common::closure11(v2_1.clone(), sprintf!("{}", v0_1), ());
            ()
        };
        v2_1.l0.get().clone()
    }
    pub fn method17() -> string {
        string("\u{001b}[0m")
    }
    pub fn method14() -> string {
        let v8: string = Common::method15(getCharAt(toLower(string("Warning")), 0_i32));
        let v15: &str = inline_colorization::color_yellow;
        let v22: &str = &*v8;
        let v50: &str = inline_colorization::color_reset;
        let v52: std::string::String = format!("{}{}{}", v15, v22, v50);
        fable_library_rust::String_::fromString(v52)
    }
    pub fn method19(v0_1: i32, v1_1: LrcPtr<Exception>) -> string {
        let v3: LrcPtr<Common::Mut3> = LrcPtr::new(Common::Mut3 {
            l0: MutCell::new(Common::method16()),
        });
        let v12: () = {
            Common::closure11(v3.clone(), string("{ "), ());
            ()
        };
        let v23: () = {
            Common::closure11(v3.clone(), string("retry"), ());
            ()
        };
        let v34: () = {
            Common::closure11(v3.clone(), string(" = "), ());
            ()
        };
        let v43: () = {
            Common::closure11(v3.clone(), sprintf!("{}", v0_1), ());
            ()
        };
        let v54: () = {
            Common::closure11(v3.clone(), string("; "), ());
            ()
        };
        let v65: () = {
            Common::closure11(v3.clone(), string("ex"), ());
            ()
        };
        let v74: () = {
            Common::closure11(v3.clone(), string(" = "), ());
            ()
        };
        let v83: std::string::String = format!("{:#?}", v1_1);
        let v122: () = {
            Common::closure11(v3.clone(), fable_library_rust::String_::fromString(v83), ());
            ()
        };
        let v133: () = {
            Common::closure11(v3.clone(), string(" }"), ());
            ()
        };
        v3.l0.get().clone()
    }
    pub fn method20(v0_1: string) -> string {
        trimEndChars(
            trimStartChars(v0_1, toArray(empty::<char>())),
            toArray(ofArray(new_array(&[' ', '/']))),
        )
    }
    pub fn method18(
        v0_1: LrcPtr<Common::Mut0>,
        v1_1: LrcPtr<Common::Mut1>,
        v2_1: LrcPtr<Common::Mut2>,
        v3: LrcPtr<Common::Mut3>,
        v4: LrcPtr<Common::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i32,
        v9: LrcPtr<Exception>,
    ) -> string {
        let v10: string = Common::method19(v8, v9);
        Common::method20(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            string("common.retry_fn"),
            v10
        ))
    }
    pub fn closure12(v0_1: LrcPtr<Common::Mut0>, unitVar: ()) {
        let v2_1: i64 = (v0_1.l0.get().clone()) + 1_i64;
        v0_1.l0.set(v2_1);
        ()
    }
    pub fn closure14(v0_1: string, unitVar: ()) {
        printfn!("{0}", v0_1);
    }
    pub fn closure13(unitVar: (), v0_1: string) {
        let v3: () = {
            Common::closure14(v0_1, ());
            ()
        };
        ()
    }
    pub fn method21(v0_1: string) {
        let v3: () = {
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
        let v44: () = {
            Common::closure12(patternInput.0.clone(), ());
            ()
        };
        println!("{}", v0_1.clone());
        ((patternInput.1.clone()).l0.get().clone())(v0_1)
    }
    pub fn closure9(v0_1: i32, v1_1: LrcPtr<Exception>, unitVar: ()) {
        if Common::method9(Common::US0::US0_3) {
            let v6: () = {
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
            let v32: Option<i64> = patternInput.5.clone();
            let v31: LrcPtr<Common::Mut4> = patternInput.4.clone();
            let v30: LrcPtr<Common::Mut3> = patternInput.3.clone();
            let v29: LrcPtr<Common::Mut2> = patternInput.2.clone();
            let v28: LrcPtr<Common::Mut1> = patternInput.1.clone();
            let v27: LrcPtr<Common::Mut0> = patternInput.0.clone();
            Common::method21(Common::method18(
                v27.clone(),
                v28.clone(),
                v29.clone(),
                v30.clone(),
                v31.clone(),
                v32.clone(),
                Common::method10(v27, v28, v29, v30, v31, v32),
                Common::method14(),
                v0_1,
                v1_1,
            ))
        };
    }
    pub fn closure8(v0_1: i32, v1_1: LrcPtr<Exception>) -> Common::US7 {
        let v4: () = {
            Common::closure9(v0_1, v1_1, ());
            ()
        };
        Common::US7::US7_1
    }
    pub fn method8(v0_1: i32, v1_1: Func0<()>, v2_1: i32) -> Common::US6 {
        let v0_1: MutCell<i32> = MutCell::new(v0_1);
        let v1_1 = MutCell::new(v1_1.clone());
        let v2_1: MutCell<i32> = MutCell::new(v2_1);
        '_method8: loop {
            break '_method8 ({
                let result: LrcPtr<MutCell<Common::US7>> = refCell(Common::US7::US7_1);
                try_catch(
                    || {
                        result.set(Common::closure6(
                            (),
                            Common::closure7(
                                v0_1.get().clone(),
                                v1_1.get().clone(),
                                v2_1.get().clone(),
                                (),
                            ),
                        ))
                    },
                    |ex: LrcPtr<Exception>| {
                        result.set(Common::closure8(v2_1.get().clone(), ex.clone()))
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
                            let v0_1_temp: i32 = v0_1.get().clone();
                            let v1_1_temp = v1_1.get().clone();
                            let v2_1_temp: i32 = (v2_1.get().clone()) + 1_i32;
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2_1.set(v2_1_temp);
                            continue '_method8;
                        }
                    }
                }
            });
        }
    }
    pub fn closure5(v0_1: i32, v1_1: Func0<()>) -> Option<()> {
        let v3: Common::US6 = Common::method8(v0_1, v1_1, 0_i32);
        match &v3 {
            Common::US6::US6_0 => Some(()),
            _ => None::<()>,
        }
    }
    pub fn closure4(unitVar: (), v0_1: i32) -> Func1<Func0<()>, Option<()>> {
        Func1::new({
            let v0_1 = v0_1.clone();
            move |v: Func0<()>| Common::closure5(v0_1, v)
        })
    }
    pub fn method22(v0_1: Func0<()>) -> Func0<()> {
        v0_1
    }
    pub fn closure16(v0_1: LrcPtr<Lazy_1<()>>, unitVar: ()) {
        v0_1.get_Value();
        ()
    }
    pub fn closure15(unitVar: (), v0_1: Func0<()>) -> Func0<()> {
        let v1_1 = Common::method22(v0_1);
        let v6: LrcPtr<Lazy_1<()>> = LazyExtensions::Create(Func0::new({
            let v1_1 = v1_1.clone();
            move || v1_1()
        }));
        Func0::new({
            let v6 = v6.clone();
            move || Common::closure16(v6.clone(), ())
        })
    }
    pub fn v0() -> () {
        static v0: OnceInit<()> = OnceInit::new();
        v0.get_or_init(|| ()).clone()
    }
    pub fn v1() -> Func0<()> {
        static v1: OnceInit<Func0<()>> = OnceInit::new();
        v1.get_or_init(|| Func0::new(move || Common::closure0((), ())))
            .clone()
    }
    pub fn v2() -> () {
        static v2: OnceInit<()> = OnceInit::new();
        v2.get_or_init(|| {
            (Common::v1())();
            Common::v0()
        })
        .clone()
    }
    pub fn v17() -> Func1<Func0<()>, LrcPtr<dyn IDisposable>> {
        static v17: OnceInit<Func1<Func0<()>, LrcPtr<dyn IDisposable>>> = OnceInit::new();
        v17.get_or_init(|| Func1::new(move |v: Func0<()>| Common::closure3((), v)))
            .clone()
    }
    pub fn new_disposable(x: Func0<()>) -> LrcPtr<dyn IDisposable> {
        (Common::v17())(x)
    }
    pub fn v18() -> Func1<i32, Func1<Func0<()>, Option<()>>> {
        static v18: OnceInit<Func1<i32, Func1<Func0<()>, Option<()>>>> = OnceInit::new();
        v18.get_or_init(|| Func1::new(move |v: i32| Common::closure4((), v)))
            .clone()
    }
    pub fn retry_fn(x: i32) -> Func1<Func0<()>, Option<()>> {
        (Common::v18())(x)
    }
    pub fn v19() -> Func1<Func0<()>, Func0<()>> {
        static v19: OnceInit<Func1<Func0<()>, Func0<()>>> = OnceInit::new();
        v19.get_or_init(|| Func1::new(move |v: Func0<()>| Common::closure15((), v)))
            .clone()
    }
    pub fn memoize(x: Func0<()>) -> Func0<()> {
        (Common::v19())(x)
    }
    on_startup!(());
}
