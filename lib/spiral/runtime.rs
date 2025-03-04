pub mod Runtime {
    use super::*;
    use fable_library_rust::Async_::Async;
    use fable_library_rust::DateTime_::DateTime;
    use fable_library_rust::List_::cons;
    use fable_library_rust::List_::empty;
    use fable_library_rust::List_::foldBack;
    use fable_library_rust::List_::ofArray;
    use fable_library_rust::List_::toArray;
    use fable_library_rust::List_::List;
    use fable_library_rust::Map_::find;
    use fable_library_rust::Map_::ofSeq;
    use fable_library_rust::NativeArray_::new_array;
    use fable_library_rust::NativeArray_::new_empty;
    use fable_library_rust::NativeArray_::new_init;
    use fable_library_rust::NativeArray_::Array;
    use fable_library_rust::Native_::getNull;
    use fable_library_rust::Native_::on_startup;
    use fable_library_rust::Native_::unbox;
    use fable_library_rust::Native_::Any;
    use fable_library_rust::Native_::Arc;
    use fable_library_rust::Native_::Func0;
    use fable_library_rust::Native_::Func1;
    use fable_library_rust::Native_::Func2;
    use fable_library_rust::Native_::LrcPtr;
    use fable_library_rust::Native_::MutCell;
    use fable_library_rust::Native_::OnceInit;
    use fable_library_rust::Option_::defaultValue;
    use fable_library_rust::Option_::map;
    use fable_library_rust::Seq_::delay;
    use fable_library_rust::Seq_::ofList;
    use fable_library_rust::Seq_::toArray as toArray_1;
    use fable_library_rust::String_::append;
    use fable_library_rust::String_::concat;
    use fable_library_rust::String_::getCharAt;
    use fable_library_rust::String_::getSlice;
    use fable_library_rust::String_::indexOf;
    use fable_library_rust::String_::join;
    use fable_library_rust::String_::length;
    use fable_library_rust::String_::ofChar;
    use fable_library_rust::String_::printfn;
    use fable_library_rust::String_::sprintf;
    use fable_library_rust::String_::string;
    use fable_library_rust::String_::toLower;
    use fable_library_rust::String_::trimEndChars;
    use fable_library_rust::String_::trimStartChars;
    use fable_library_rust::TimeSpan_::TimeSpan;
    type ConcurrentStack_1<T> = T;
    use fable_library_rust::System::Collections::Generic::IEnumerable_1;
    use fable_library_rust::System::Text::StringBuilder;
    use fable_library_rust::System::Threading::CancellationToken;
    type TaskCanceledException = ();
    pub mod TraceState {
        use super::*;
        pub fn trace_state() -> LrcPtr<
            MutCell<
                Option<(
                    LrcPtr<Runtime::Mut0>,
                    LrcPtr<Runtime::Mut1>,
                    LrcPtr<Runtime::Mut2>,
                    LrcPtr<Runtime::Mut3>,
                    LrcPtr<Runtime::Mut4>,
                    Option<i64>,
                )>,
            >,
        > {
            static trace_state: OnceInit<
                LrcPtr<
                    MutCell<
                        Option<(
                            LrcPtr<Runtime::Mut0>,
                            LrcPtr<Runtime::Mut1>,
                            LrcPtr<Runtime::Mut2>,
                            LrcPtr<Runtime::Mut3>,
                            LrcPtr<Runtime::Mut4>,
                            Option<i64>,
                        )>,
                    >,
                >,
            > = OnceInit::new();
            trace_state
                .get_or_init(|| {
                    LrcPtr::new(MutCell::new(
                        None::<(
                            LrcPtr<Runtime::Mut0>,
                            LrcPtr<Runtime::Mut1>,
                            LrcPtr<Runtime::Mut2>,
                            LrcPtr<Runtime::Mut3>,
                            LrcPtr<Runtime::Mut4>,
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
        pub l0: MutCell<Runtime::US0>,
    }
    impl core::fmt::Display for Mut4 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US1 {
        US1_0(Runtime::US0),
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
        US4_0(Runtime::US3),
        US4_1(Runtime::US3),
        US4_2(Runtime::US3),
        US4_3(Runtime::US3),
        US4_4(Runtime::US3),
        US4_5(Runtime::US3),
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
        US6_0(string, Runtime::US5),
        US6_1(string),
    }
    impl core::fmt::Display for US6 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US7 {
        US7_0(char, string, LrcPtr<StringBuilder>, i32, i32),
        US7_1(string),
    }
    impl core::fmt::Display for US7 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub struct Mut5 {
        pub l0: MutCell<i32>,
    }
    impl core::fmt::Display for Mut5 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum UH0 {
        UH0_0,
        UH0_1(char, LrcPtr<Runtime::UH0>),
    }
    impl core::fmt::Display for UH0 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum UH1 {
        UH1_0,
        UH1_1(
            Func1<(string, LrcPtr<StringBuilder>, i32, i32), Runtime::US7>,
            LrcPtr<Runtime::UH1>,
        ),
    }
    impl core::fmt::Display for UH1 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US8 {
        US8_0(string, string, LrcPtr<StringBuilder>, i32, i32),
        US8_1(string),
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
    #[derive(Clone, Debug)]
    pub enum US10 {
        US10_0(string, LrcPtr<StringBuilder>, i32, i32),
        US10_1(string),
    }
    impl core::fmt::Display for US10 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US11 {
        US11_0(
            string,
            Runtime::US5,
            string,
            LrcPtr<StringBuilder>,
            i32,
            i32,
        ),
        US11_1(string),
    }
    impl core::fmt::Display for US11 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US12 {
        US12_0(Runtime::US9, string, LrcPtr<StringBuilder>, i32, i32),
        US12_1(string),
    }
    impl core::fmt::Display for US12 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US13 {
        US13_0(Runtime::US5, string, LrcPtr<StringBuilder>, i32, i32),
        US13_1(string),
    }
    impl core::fmt::Display for US13 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US14 {
        US14_0(Func1<(i32, string, bool), Arc<Async<()>>>),
        US14_1,
    }
    impl core::fmt::Display for US14 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US15 {
        US15_0(CancellationToken),
        US15_1,
    }
    impl core::fmt::Display for US15 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub struct Heap0 {
        pub l0: string,
        pub l1: Option<CancellationToken>,
        pub l2: Array<(string, string)>,
        pub l3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        pub l4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        pub l5: bool,
        pub l6: Option<string>,
    }
    impl core::fmt::Display for Heap0 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US16 {
        US16_0(Array<string>),
        US16_1(string),
    }
    impl core::fmt::Display for US16 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum UH2 {
        UH2_0,
        UH2_1(string, LrcPtr<Runtime::UH2>),
    }
    impl core::fmt::Display for UH2 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US17 {
        US17_0(
            LrcPtr<Runtime::UH2>,
            string,
            LrcPtr<StringBuilder>,
            i32,
            i32,
        ),
        US17_1(string),
    }
    impl core::fmt::Display for US17 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum UH3 {
        UH3_0,
        UH3_1(
            Func1<(string, LrcPtr<StringBuilder>, i32, i32), Runtime::US8>,
            LrcPtr<Runtime::UH3>,
        ),
    }
    impl core::fmt::Display for UH3 {
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
    pub fn closure1(unitVar: (), v0_1: string) -> Runtime::US5 {
        Runtime::US5::US5_0(v0_1)
    }
    pub fn method5() -> Func1<string, Runtime::US5> {
        Func1::new(move |v: string| Runtime::closure1((), v))
    }
    pub fn method2(v0_1: string) -> string {
        let v6: string = Runtime::method3(v0_1);
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
        let v19_1: string = Runtime::method4();
        v18_1.unwrap_or(v19_1)
    }
    pub fn method1() -> (Runtime::US1, Runtime::US2) {
        let v1_1: string = Runtime::method2(string("TRACE_LEVEL"));
        let v6: Runtime::US1 = if string("Verbose") == (v1_1.clone()) {
            Runtime::US1::US1_0(Runtime::US0::US0_0)
        } else {
            Runtime::US1::US1_1
        };
        (
            match &v6 {
                Runtime::US1::US1_0(v6_0_0) => Runtime::US1::US1_0(
                    match &v6 {
                        Runtime::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                ),
                _ => {
                    let v13: Runtime::US1 = if string("Debug") == (v1_1.clone()) {
                        Runtime::US1::US1_0(Runtime::US0::US0_1)
                    } else {
                        Runtime::US1::US1_1
                    };
                    match &v13 {
                        Runtime::US1::US1_0(v13_0_0) => Runtime::US1::US1_0(
                            match &v13 {
                                Runtime::US1::US1_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v20_1: Runtime::US1 = if string("Info") == (v1_1.clone()) {
                                Runtime::US1::US1_0(Runtime::US0::US0_2)
                            } else {
                                Runtime::US1::US1_1
                            };
                            match &v20_1 {
                                Runtime::US1::US1_0(v20_1_0_0) => Runtime::US1::US1_0(
                                    match &v20_1 {
                                        Runtime::US1::US1_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v27: Runtime::US1 = if string("Warning") == (v1_1.clone()) {
                                        Runtime::US1::US1_0(Runtime::US0::US0_3)
                                    } else {
                                        Runtime::US1::US1_1
                                    };
                                    match &v27 {
                                        Runtime::US1::US1_0(v27_0_0) => Runtime::US1::US1_0(
                                            match &v27 {
                                                Runtime::US1::US1_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        ),
                                        _ => {
                                            let v34: Runtime::US1 =
                                                if string("Critical") == (v1_1.clone()) {
                                                    Runtime::US1::US1_0(Runtime::US0::US0_4)
                                                } else {
                                                    Runtime::US1::US1_1
                                                };
                                            match &v34 {
                                                Runtime::US1::US1_0(v34_0_0) => {
                                                    Runtime::US1::US1_0(
                                                        match &v34 {
                                                            Runtime::US1::US1_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => Runtime::US1::US1_1,
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            },
            if (Runtime::method2(string("AUTOMATION"))) != string("True") {
                Runtime::US2::US2_1
            } else {
                Runtime::US2::US2_0({
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
        v0_1: Runtime::US0,
    ) -> (
        LrcPtr<Runtime::Mut0>,
        LrcPtr<Runtime::Mut1>,
        LrcPtr<Runtime::Mut2>,
        LrcPtr<Runtime::Mut3>,
        LrcPtr<Runtime::Mut4>,
        Option<i64>,
    ) {
        let patternInput: (Runtime::US1, Runtime::US2) = Runtime::method1();
        let _run_target_args__v3: (Runtime::US1, Runtime::US2) =
            (patternInput.0.clone(), patternInput.1.clone());
        let v173: Runtime::US2 = _run_target_args__v3.1.clone();
        let v172: Runtime::US1 = _run_target_args__v3.0.clone();
        (
            LrcPtr::new(Runtime::Mut0 {
                l0: MutCell::new(1_i64),
            }),
            LrcPtr::new(Runtime::Mut1 {
                l0: MutCell::new(Func1::new(move |v: string| Runtime::closure2((), v))),
            }),
            LrcPtr::new(Runtime::Mut2 {
                l0: MutCell::new(true),
            }),
            LrcPtr::new(Runtime::Mut3 {
                l0: MutCell::new(string("")),
            }),
            LrcPtr::new(Runtime::Mut4 {
                l0: MutCell::new(match &v172 {
                    Runtime::US1::US1_0(v172_0_0) => match &v172 {
                        Runtime::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    _ => v0_1.clone(),
                }),
            }),
            match &v173 {
                Runtime::US2::US2_0(v173_0_0) => Some(match &v173 {
                    Runtime::US2::US2_0(x) => x.clone(),
                    _ => unreachable!(),
                }),
                _ => None::<i64>,
            },
        )
    }
    pub fn closure0(unitVar: (), unitVar_1: ()) {
        if Runtime::TraceState::trace_state().get().clone().is_none() {
            let patternInput: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::method0(Runtime::US0::US0_0);
            Runtime::TraceState::trace_state().set(Some((
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
    pub fn method7(v0_1: Runtime::US0) -> bool {
        let v3: () = {
            Runtime::closure0((), ());
            ()
        };
        let patternInput: (
            LrcPtr<Runtime::Mut0>,
            LrcPtr<Runtime::Mut1>,
            LrcPtr<Runtime::Mut2>,
            LrcPtr<Runtime::Mut3>,
            LrcPtr<Runtime::Mut4>,
            Option<i64>,
        ) = Runtime::TraceState::trace_state().get().clone().unwrap();
        let v42: Runtime::US0 = (patternInput.4.clone()).l0.get().clone();
        if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            (find(
                v0_1,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Runtime::US0::US0_0, 0_i32)),
                    LrcPtr::new((Runtime::US0::US0_1, 1_i32)),
                    LrcPtr::new((Runtime::US0::US0_2, 2_i32)),
                    LrcPtr::new((Runtime::US0::US0_3, 3_i32)),
                    LrcPtr::new((Runtime::US0::US0_4, 4_i32)),
                ])))),
            )) >= (find(
                v42,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((Runtime::US0::US0_0, 0_i32)),
                    LrcPtr::new((Runtime::US0::US0_1, 1_i32)),
                    LrcPtr::new((Runtime::US0::US0_2, 2_i32)),
                    LrcPtr::new((Runtime::US0::US0_3, 3_i32)),
                    LrcPtr::new((Runtime::US0::US0_4, 4_i32)),
                ])))),
            ))
        }
    }
    pub fn closure6(unitVar: (), v0_1: i64) -> Runtime::US2 {
        Runtime::US2::US2_0(v0_1)
    }
    pub fn method9() -> Func1<i64, Runtime::US2> {
        Func1::new(move |v: i64| Runtime::closure6((), v))
    }
    pub fn method10() -> string {
        string("hh:mm:ss")
    }
    pub fn method11() -> string {
        string("HH:mm:ss")
    }
    pub fn method8(
        v0_1: LrcPtr<Runtime::Mut0>,
        v1_1: LrcPtr<Runtime::Mut1>,
        v2_1: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
    ) -> string {
        let v182: Runtime::US2 = defaultValue(Runtime::US2::US2_1, map(Runtime::method9(), v5));
        let v300: DateTime = match &v182 {
            Runtime::US2::US2_0(v182_0_0) => {
                let v252: TimeSpan = TimeSpan::new_ticks(
                    ({
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    }) - (match &v182 {
                        Runtime::US2::US2_0(x) => x.clone(),
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
        let v302: string = Runtime::method10();
        let provider: string = if (v302.clone()) == string("") {
            string("M-d-y hh:mm:ss tt")
        } else {
            v302
        };
        v300.toString(provider)
    }
    pub fn method14() -> string {
        string("")
    }
    pub fn closure7(v0_1: LrcPtr<Runtime::Mut3>, v1_1: string, unitVar: ()) {
        let v3: string = append((v0_1.l0.get().clone()), (v1_1));
        v0_1.l0.set(v3);
        ()
    }
    pub fn method13(v0_1: char) -> string {
        let v2_1: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method14()),
        });
        let v9: () = {
            Runtime::closure7(v2_1.clone(), sprintf!("{}", v0_1), ());
            ()
        };
        v2_1.l0.get().clone()
    }
    pub fn method15() -> string {
        string("\u{001b}[0m")
    }
    pub fn method12() -> string {
        let v7: string = Runtime::method13(getCharAt(toLower(string("Warning")), 0_i32));
        let v14: &str = inline_colorization::color_yellow;
        let v21_1: &str = &*v7;
        let v49: &str = inline_colorization::color_reset;
        let v51: std::string::String = format!("{}{}{}", v14, v21_1, v49);
        fable_library_rust::String_::fromString(v51)
    }
    pub fn method17() -> string {
        let v1_1: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method14()),
        });
        v1_1.l0.get().clone()
    }
    pub fn method18(v0_1: string) -> string {
        trimEndChars(
            trimStartChars(v0_1, toArray(empty::<char>())),
            toArray(ofArray(new_array(&[' ', '/']))),
        )
    }
    pub fn method16(
        v0_1: LrcPtr<Runtime::Mut0>,
        v1_1: LrcPtr<Runtime::Mut1>,
        v2_1: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
    ) -> string {
        let v8: string = Runtime::method17();
        Runtime::method18(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            string("runtime.current_process_kill / exiting... 3"),
            v8
        ))
    }
    pub fn closure8(v0_1: LrcPtr<Runtime::Mut0>, unitVar: ()) {
        let v2_1: i64 = (v0_1.l0.get().clone()) + 1_i64;
        v0_1.l0.set(v2_1);
        ()
    }
    pub fn closure10(v0_1: string, unitVar: ()) {
        printfn!("{0}", v0_1);
    }
    pub fn closure9(unitVar: (), v0_1: string) {
        let v3: () = {
            Runtime::closure10(v0_1, ());
            ()
        };
        ()
    }
    pub fn method19(v0_1: string) {
        let v3: () = {
            Runtime::closure0((), ());
            ()
        };
        let patternInput: (
            LrcPtr<Runtime::Mut0>,
            LrcPtr<Runtime::Mut1>,
            LrcPtr<Runtime::Mut2>,
            LrcPtr<Runtime::Mut3>,
            LrcPtr<Runtime::Mut4>,
            Option<i64>,
        ) = Runtime::TraceState::trace_state().get().clone().unwrap();
        let v44: () = {
            Runtime::closure8(patternInput.0.clone(), ());
            ()
        };
        println!("{}", v0_1.clone());
        ((patternInput.1.clone()).l0.get().clone())(v0_1)
    }
    pub fn closure5(unitVar: (), unitVar_1: ()) {
        if Runtime::method7(Runtime::US0::US0_3) {
            let v4: () = {
                Runtime::closure0((), ());
                ()
            };
            let patternInput: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v30: Option<i64> = patternInput.5.clone();
            let v29: LrcPtr<Runtime::Mut4> = patternInput.4.clone();
            let v28: LrcPtr<Runtime::Mut3> = patternInput.3.clone();
            let v27: LrcPtr<Runtime::Mut2> = patternInput.2.clone();
            let v26: LrcPtr<Runtime::Mut1> = patternInput.1.clone();
            let v25: LrcPtr<Runtime::Mut0> = patternInput.0.clone();
            Runtime::method19(Runtime::method16(
                v25.clone(),
                v26.clone(),
                v27.clone(),
                v28.clone(),
                v29.clone(),
                v30.clone(),
                Runtime::method8(v25, v26, v27, v28, v29, v30),
                Runtime::method12(),
            ))
        };
    }
    pub fn method20(
        v0_1: LrcPtr<Runtime::Mut0>,
        v1_1: LrcPtr<Runtime::Mut1>,
        v2_1: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
    ) -> string {
        let v8: string = Runtime::method17();
        Runtime::method18(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            string("runtime.current_process_kill / exiting... 2"),
            v8
        ))
    }
    pub fn closure11(unitVar: (), unitVar_1: ()) {
        if Runtime::method7(Runtime::US0::US0_3) {
            let v4: () = {
                Runtime::closure0((), ());
                ()
            };
            let patternInput: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v30: Option<i64> = patternInput.5.clone();
            let v29: LrcPtr<Runtime::Mut4> = patternInput.4.clone();
            let v28: LrcPtr<Runtime::Mut3> = patternInput.3.clone();
            let v27: LrcPtr<Runtime::Mut2> = patternInput.2.clone();
            let v26: LrcPtr<Runtime::Mut1> = patternInput.1.clone();
            let v25: LrcPtr<Runtime::Mut0> = patternInput.0.clone();
            Runtime::method19(Runtime::method20(
                v25.clone(),
                v26.clone(),
                v27.clone(),
                v28.clone(),
                v29.clone(),
                v30.clone(),
                Runtime::method8(v25, v26, v27, v28, v29, v30),
                Runtime::method12(),
            ))
        };
    }
    pub fn method21(
        v0_1: LrcPtr<Runtime::Mut0>,
        v1_1: LrcPtr<Runtime::Mut1>,
        v2_1: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
    ) -> string {
        let v8: string = Runtime::method17();
        Runtime::method18(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            string("runtime.current_process_kill / exiting... 1"),
            v8
        ))
    }
    pub fn closure12(unitVar: (), unitVar_1: ()) {
        if Runtime::method7(Runtime::US0::US0_3) {
            let v4: () = {
                Runtime::closure0((), ());
                ()
            };
            let patternInput: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v30: Option<i64> = patternInput.5.clone();
            let v29: LrcPtr<Runtime::Mut4> = patternInput.4.clone();
            let v28: LrcPtr<Runtime::Mut3> = patternInput.3.clone();
            let v27: LrcPtr<Runtime::Mut2> = patternInput.2.clone();
            let v26: LrcPtr<Runtime::Mut1> = patternInput.1.clone();
            let v25: LrcPtr<Runtime::Mut0> = patternInput.0.clone();
            Runtime::method19(Runtime::method21(
                v25.clone(),
                v26.clone(),
                v27.clone(),
                v28.clone(),
                v29.clone(),
                v30.clone(),
                Runtime::method8(v25, v26, v27, v28, v29, v30),
                Runtime::method12(),
            ))
        };
    }
    pub fn closure4(unitVar: (), unitVar_1: ()) {
        ();
    }
    pub fn method6() {
        ();
    }
    pub fn closure3(unitVar: (), unitVar_1: ()) {
        Runtime::method6();
    }
    pub fn method26() -> string {
        string("")
    }
    pub fn method27(v0_1: i32, v1_1: LrcPtr<Runtime::Mut5>) -> bool {
        (v1_1.l0.get().clone()) < (v0_1)
    }
    pub fn closure16(v0_1: char, v1_1: LrcPtr<Runtime::UH0>) -> LrcPtr<Runtime::UH0> {
        LrcPtr::new(Runtime::UH0::UH0_1(v0_1, v1_1))
    }
    pub fn closure15(unitVar: (), v0_1: char) -> Func1<LrcPtr<Runtime::UH0>, LrcPtr<Runtime::UH0>> {
        Func1::new({
            let v0_1 = v0_1.clone();
            move |v: LrcPtr<Runtime::UH0>| Runtime::closure16(v0_1, v)
        })
    }
    pub fn method28() -> Func1<char, Func1<LrcPtr<Runtime::UH0>, LrcPtr<Runtime::UH0>>> {
        Func1::new(move |v: char| Runtime::closure15((), v))
    }
    pub fn method29(
        v0_1: LrcPtr<Runtime::UH0>,
        v1_1: LrcPtr<StringBuilder>,
        v2_1: i32,
        v3: i32,
    ) -> (LrcPtr<StringBuilder>, i32, i32) {
        let v0_1: MutCell<LrcPtr<Runtime::UH0>> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
        let v2_1: MutCell<i32> = MutCell::new(v2_1);
        let v3: MutCell<i32> = MutCell::new(v3);
        '_method29: loop {
            break '_method29 (match v0_1.get().clone().as_ref() {
                Runtime::UH0::UH0_0 => (v1_1.get().clone(), v2_1.get().clone(), v3.get().clone()),
                Runtime::UH0::UH0_1(v0_1_1_0, v0_1_1_1) => {
                    let v4: char = match v0_1.get().clone().as_ref() {
                        Runtime::UH0::UH0_1(x, _) => x.clone(),
                        _ => unreachable!(),
                    };
                    let v6: bool = '\n' == (v4);
                    let patternInput: (i32, i32) = if v6 {
                        ((v2_1.get().clone()) + 1_i32, 1_i32)
                    } else {
                        (v2_1.get().clone(), (v3.get().clone()) + 1_i32)
                    };
                    {
                        let v0_1_temp: LrcPtr<Runtime::UH0> = match v0_1.get().clone().as_ref() {
                            Runtime::UH0::UH0_1(_, x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone();
                        let v1_1_temp: LrcPtr<StringBuilder> = if v6 {
                            let v13: LrcPtr<StringBuilder> = v1_1.get().clone().Clear();
                            v1_1.get().clone()
                        } else {
                            let v24: LrcPtr<StringBuilder> = {
                                let value: string = ofChar(v4);
                                v1_1.get().clone().Append_Z721C83C5(value)
                            };
                            v1_1.get().clone()
                        };
                        let v2_1_temp: i32 = patternInput.0.clone();
                        let v3_temp: i32 = patternInput.1.clone();
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        v2_1.set(v2_1_temp);
                        v3.set(v3_temp);
                        continue '_method29;
                    }
                }
            });
        }
    }
    pub fn closure17(v0_1: i32, v1_1: i32, v2_1: string) -> string {
        if (v1_1) >= (v0_1) {
            v2_1.clone()
        } else {
            (Runtime::method30(v0_1, (v1_1) + 1_i32))(append((v2_1), string(" ")))
        }
    }
    pub fn method30(v0_1: i32, v1_1: i32) -> Func1<string, string> {
        Func1::new({
            let v0_1 = v0_1.clone();
            let v1_1 = v1_1.clone();
            move |v: string| Runtime::closure17(v0_1, v1_1, v)
        })
    }
    pub fn closure14(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US7 {
        let v3: i32 = _arg.3.clone();
        let v2_1: i32 = _arg.2.clone();
        let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
        let v0_1: string = _arg.0.clone();
        if string("") == (v0_1.clone()) {
            Runtime::US7::US7_1(sprintf!(
                "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                '\"',
                (v1_1.clone(), v2_1, v3)
            ))
        } else {
            let v10: char = getCharAt(v0_1.clone(), 0_i32);
            if (v10) == '\"' {
                let v39: string = getSlice(
                    v0_1.clone(),
                    Some(1_i32),
                    Some((length(v0_1.clone())) - 1_i32),
                );
                let v45: string = ofChar(v10);
                let v48: i32 = length(v45.clone());
                let v49: Array<char> = new_init(&'\u{0000}', v48);
                let v50: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                    l0: MutCell::new(0_i32),
                });
                while Runtime::method27(v48, v50.clone()) {
                    let v52: i32 = v50.l0.get().clone();
                    let v53: char = getCharAt(v45.clone(), v52);
                    v49.get_mut()[v52 as usize] = v53;
                    {
                        let v54: i32 = (v52) + 1_i32;
                        v50.l0.set(v54);
                        ()
                    }
                }
                {
                    let v56: List<char> = ofArray(v49.clone());
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                        foldBack(
                            Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                (Runtime::method28())(b0)(b1)
                            }),
                            v56,
                            LrcPtr::new(Runtime::UH0::UH0_0),
                        ),
                        v1_1.clone(),
                        v2_1,
                        v3,
                    );
                    Runtime::US7::US7_0(
                        v10,
                        v39,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                }
            } else {
                let v99: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
                Runtime::US7::US7_1(concat(new_array(&[
                    sprintf!(
                        "parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                        '\"',
                        v2_1,
                        v3,
                        v1_1,
                        getSlice(
                            v0_1.clone(),
                            Some(0_i32),
                            Some(
                                (if -2_i32 == (v99) {
                                    (length(v0_1)) + 1_i32
                                } else {
                                    (v99) + 1_i32
                                }) - 1_i32
                            )
                        )
                    ),
                    string("\n"),
                    append(
                        ((Runtime::method30((v3) - 1_i32, 0_i32))(string(""))),
                        string("^"),
                    ),
                    string("\n"),
                ])))
            }
        }
    }
    pub fn closure18(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US7 {
        let v3: i32 = _arg.3.clone();
        let v2_1: i32 = _arg.2.clone();
        let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
        let v0_1: string = _arg.0.clone();
        if string("") == (v0_1.clone()) {
            Runtime::US7::US7_1(sprintf!(
                "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                '\'',
                (v1_1.clone(), v2_1, v3)
            ))
        } else {
            let v10: char = getCharAt(v0_1.clone(), 0_i32);
            if (v10) == '\'' {
                let v39: string = getSlice(
                    v0_1.clone(),
                    Some(1_i32),
                    Some((length(v0_1.clone())) - 1_i32),
                );
                let v45: string = ofChar(v10);
                let v48: i32 = length(v45.clone());
                let v49: Array<char> = new_init(&'\u{0000}', v48);
                let v50: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                    l0: MutCell::new(0_i32),
                });
                while Runtime::method27(v48, v50.clone()) {
                    let v52: i32 = v50.l0.get().clone();
                    let v53: char = getCharAt(v45.clone(), v52);
                    v49.get_mut()[v52 as usize] = v53;
                    {
                        let v54: i32 = (v52) + 1_i32;
                        v50.l0.set(v54);
                        ()
                    }
                }
                {
                    let v56: List<char> = ofArray(v49.clone());
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                        foldBack(
                            Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                (Runtime::method28())(b0)(b1)
                            }),
                            v56,
                            LrcPtr::new(Runtime::UH0::UH0_0),
                        ),
                        v1_1.clone(),
                        v2_1,
                        v3,
                    );
                    Runtime::US7::US7_0(
                        v10,
                        v39,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                }
            } else {
                let v99: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
                Runtime::US7::US7_1(concat(new_array(&[
                    sprintf!(
                        "parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                        '\'',
                        v2_1,
                        v3,
                        v1_1,
                        getSlice(
                            v0_1.clone(),
                            Some(0_i32),
                            Some(
                                (if -2_i32 == (v99) {
                                    (length(v0_1)) + 1_i32
                                } else {
                                    (v99) + 1_i32
                                }) - 1_i32
                            )
                        )
                    ),
                    string("\n"),
                    append(
                        ((Runtime::method30((v3) - 1_i32, 0_i32))(string(""))),
                        string("^"),
                    ),
                    string("\n"),
                ])))
            }
        }
    }
    pub fn method31(
        v0_1: string,
        v1_1: LrcPtr<StringBuilder>,
        v2_1: LrcPtr<Runtime::UH1>,
    ) -> Runtime::US7 {
        let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
        let v2_1: MutCell<LrcPtr<Runtime::UH1>> = MutCell::new(v2_1.clone());
        '_method31: loop {
            break '_method31 (match v2_1.get().clone().as_ref() {
                Runtime::UH1::UH1_0 => {
                    Runtime::US7::US7_1(string("parsing.choice / no parsers succeeded"))
                }
                Runtime::UH1::UH1_1(v2_1_1_0, v2_1_1_1) => {
                    let v7: Runtime::US7 = (match v2_1.get().clone().as_ref() {
                        Runtime::UH1::UH1_1(x, _) => x.clone(),
                        _ => unreachable!(),
                    })((
                        v0_1.get().clone(),
                        v1_1.get().clone(),
                        1_i32,
                        1_i32,
                    ));
                    match &v7 {
                        Runtime::US7::US7_0(v7_0_0, v7_0_1, v7_0_2, v7_0_3, v7_0_4) => v7.clone(),
                        _ => {
                            let v0_1_temp: string = v0_1.get().clone();
                            let v1_1_temp: LrcPtr<StringBuilder> = v1_1.get().clone();
                            let v2_1_temp: LrcPtr<Runtime::UH1> = match v2_1.get().clone().as_ref()
                            {
                                Runtime::UH1::UH1_1(_, x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2_1.set(v2_1_temp);
                            continue '_method31;
                        }
                    }
                }
            });
        }
    }
    pub fn method32(v0_1: char, v1_1: i64) -> bool {
        let v0_1: MutCell<char> = MutCell::new(v0_1);
        let v1_1: MutCell<i64> = MutCell::new(v1_1);
        '_method32: loop {
            break '_method32 (if (v1_1.get().clone()) >= 2_i64 {
                false
            } else {
                let v11: Runtime::US9 = if (v1_1.get().clone()) == 0_i64 {
                    Runtime::US9::US9_0('\"')
                } else {
                    let v5: i64 = (v1_1.get().clone()) - 1_i64;
                    if (v5) == 0_i64 {
                        Runtime::US9::US9_0('\'')
                    } else {
                        let v8: i64 = (v5) - 1_i64;
                        Runtime::US9::US9_1
                    }
                };
                if (v0_1.get().clone())
                    == (match &v11 {
                        Runtime::US9::US9_0(v11_0_0) => match &v11 {
                            Runtime::US9::US9_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    })
                {
                    true
                } else {
                    let v0_1_temp: char = v0_1.get().clone();
                    let v1_1_temp: i64 = (v1_1.get().clone()) + 1_i64;
                    v0_1.set(v0_1_temp);
                    v1_1.set(v1_1_temp);
                    continue '_method32;
                }
            });
        }
    }
    pub fn method33(
        v0_1: string,
        v1_1: string,
        v2_1: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> (string, string, LrcPtr<StringBuilder>, i32, i32) {
        let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
        let v2_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2_1.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method33: loop {
            break '_method33 ({
                let v131: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\"', '\'']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v25: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method32(v25, 0_i64)) == false {
                        let v56: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v62: string = ofChar(v25);
                        let v65: i32 = length(v62.clone());
                        let v66: Array<char> = new_init(&'\u{0000}', v65);
                        let v67: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Runtime::method27(v65, v67.clone()) {
                            let v69: i32 = v67.l0.get().clone();
                            let v70: char = getCharAt(v62.clone(), v69);
                            v66.get_mut()[v69 as usize] = v70;
                            {
                                let v71: i32 = (v69) + 1_i32;
                                v67.l0.set(v71);
                                ()
                            }
                        }
                        {
                            let v73: List<char> = ofArray(v66.clone());
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                        (Runtime::method28())(b0)(b1)
                                    }),
                                    v73,
                                    LrcPtr::new(Runtime::UH0::UH0_0),
                                ),
                                v2_1.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Runtime::US7::US7_0(
                                v25,
                                v56,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        }
                    } else {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                            v25,
                            toArray(ofArray(new_array(&['\"', '\'']))),
                            (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    }
                };
                let v143: Runtime::US7 = match &v131 {
                    Runtime::US7::US7_0(v131_0_0, v131_0_1, v131_0_2, v131_0_3, v131_0_4) => {
                        let v132: char = v131_0_0.clone();
                        Runtime::US7::US7_0(
                            if '\\' == (v132) { '/' } else { v132 },
                            v131_0_1.clone(),
                            v131_0_2.clone(),
                            v131_0_3.clone(),
                            v131_0_4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v131_1_0) => Runtime::US7::US7_1(v131_1_0.clone()),
                };
                match &v143 {
                    Runtime::US7::US7_0(v143_0_0, v143_0_1, v143_0_2, v143_0_3, v143_0_4) => {
                        let v0_1_temp: string =
                            append((v0_1.get().clone()), (ofChar(v143_0_0.clone())));
                        let v1_1_temp: string = v143_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v143_0_2.clone();
                        let v3_temp: i32 = v143_0_3.clone();
                        let v4_temp: i32 = v143_0_4.clone();
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        v2_1.set(v2_1_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method33;
                    }
                    _ => (
                        v0_1.get().clone(),
                        v1_1.get().clone(),
                        v2_1.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method34(
        v0_1: string,
        v1_1: LrcPtr<StringBuilder>,
        v2_1: i32,
        v3: i32,
        v4: LrcPtr<Runtime::UH1>,
    ) -> Runtime::US7 {
        let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
        let v2_1: MutCell<i32> = MutCell::new(v2_1);
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<LrcPtr<Runtime::UH1>> = MutCell::new(v4.clone());
        '_method34: loop {
            break '_method34 (match v4.get().clone().as_ref() {
                Runtime::UH1::UH1_0 => {
                    Runtime::US7::US7_1(string("parsing.choice / no parsers succeeded"))
                }
                Runtime::UH1::UH1_1(v4_1_0, v4_1_1) => {
                    let v9: Runtime::US7 = (match v4.get().clone().as_ref() {
                        Runtime::UH1::UH1_1(x, _) => x.clone(),
                        _ => unreachable!(),
                    })((
                        v0_1.get().clone(),
                        v1_1.get().clone(),
                        v2_1.get().clone(),
                        v3.get().clone(),
                    ));
                    match &v9 {
                        Runtime::US7::US7_0(v9_0_0, v9_0_1, v9_0_2, v9_0_3, v9_0_4) => v9.clone(),
                        _ => {
                            let v0_1_temp: string = v0_1.get().clone();
                            let v1_1_temp: LrcPtr<StringBuilder> = v1_1.get().clone();
                            let v2_1_temp: i32 = v2_1.get().clone();
                            let v3_temp: i32 = v3.get().clone();
                            let v4_temp: LrcPtr<Runtime::UH1> = match v4.get().clone().as_ref() {
                                Runtime::UH1::UH1_1(_, x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2_1.set(v2_1_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method34;
                        }
                    }
                }
            });
        }
    }
    pub fn method35(v0_1: char, v1_1: i64) -> bool {
        let v0_1: MutCell<char> = MutCell::new(v0_1);
        let v1_1: MutCell<i64> = MutCell::new(v1_1);
        '_method35: loop {
            break '_method35 (if (v1_1.get().clone()) >= 3_i64 {
                false
            } else {
                let v15: Runtime::US9 = if (v1_1.get().clone()) == 0_i64 {
                    Runtime::US9::US9_0('\"')
                } else {
                    let v5: i64 = (v1_1.get().clone()) - 1_i64;
                    if (v5) == 0_i64 {
                        Runtime::US9::US9_0('\'')
                    } else {
                        let v8: i64 = (v5) - 1_i64;
                        if (v8) == 0_i64 {
                            Runtime::US9::US9_0(' ')
                        } else {
                            let v11: i64 = (v8) - 1_i64;
                            Runtime::US9::US9_1
                        }
                    }
                };
                if (v0_1.get().clone())
                    == (match &v15 {
                        Runtime::US9::US9_0(v15_0_0) => match &v15 {
                            Runtime::US9::US9_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    })
                {
                    true
                } else {
                    let v0_1_temp: char = v0_1.get().clone();
                    let v1_1_temp: i64 = (v1_1.get().clone()) + 1_i64;
                    v0_1.set(v0_1_temp);
                    v1_1.set(v1_1_temp);
                    continue '_method35;
                }
            });
        }
    }
    pub fn method36(
        v0_1: string,
        v1_1: string,
        v2_1: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> (string, string, LrcPtr<StringBuilder>, i32, i32) {
        let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
        let v2_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2_1.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method36: loop {
            break '_method36 ({
                let v139: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method35(v29, 0_i64)) == false {
                        let v60: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v66: string = ofChar(v29);
                        let v69: i32 = length(v66.clone());
                        let v70: Array<char> = new_init(&'\u{0000}', v69);
                        let v71: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Runtime::method27(v69, v71.clone()) {
                            let v73: i32 = v71.l0.get().clone();
                            let v74: char = getCharAt(v66.clone(), v73);
                            v70.get_mut()[v73 as usize] = v74;
                            {
                                let v75: i32 = (v73) + 1_i32;
                                v71.l0.set(v75);
                                ()
                            }
                        }
                        {
                            let v77: List<char> = ofArray(v70.clone());
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                        (Runtime::method28())(b0)(b1)
                                    }),
                                    v77,
                                    LrcPtr::new(Runtime::UH0::UH0_0),
                                ),
                                v2_1.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Runtime::US7::US7_0(
                                v29,
                                v60,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        }
                    } else {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                            v29,
                            toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                            (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    }
                };
                let v151: Runtime::US7 = match &v139 {
                    Runtime::US7::US7_0(v139_0_0, v139_0_1, v139_0_2, v139_0_3, v139_0_4) => {
                        let v140: char = v139_0_0.clone();
                        Runtime::US7::US7_0(
                            if '\\' == (v140) { '/' } else { v140 },
                            v139_0_1.clone(),
                            v139_0_2.clone(),
                            v139_0_3.clone(),
                            v139_0_4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v139_1_0) => Runtime::US7::US7_1(v139_1_0.clone()),
                };
                match &v151 {
                    Runtime::US7::US7_0(v151_0_0, v151_0_1, v151_0_2, v151_0_3, v151_0_4) => {
                        let v0_1_temp: string =
                            append((v0_1.get().clone()), (ofChar(v151_0_0.clone())));
                        let v1_1_temp: string = v151_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v151_0_2.clone();
                        let v3_temp: i32 = v151_0_3.clone();
                        let v4_temp: i32 = v151_0_4.clone();
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        v2_1.set(v2_1_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method36;
                    }
                    _ => (
                        v0_1.get().clone(),
                        v1_1.get().clone(),
                        v2_1.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method37(v0_1: string, v1_1: i32) -> i32 {
        let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<i32> = MutCell::new(v1_1);
        '_method37: loop {
            break '_method37 (if (v1_1.get().clone()) >= (length(v0_1.get().clone())) {
                v1_1.get().clone()
            } else {
                if ' ' == (getCharAt(v0_1.get().clone(), v1_1.get().clone())) {
                    let v0_1_temp: string = v0_1.get().clone();
                    let v1_1_temp: i32 = (v1_1.get().clone()) + 1_i32;
                    v0_1.set(v0_1_temp);
                    v1_1.set(v1_1_temp);
                    continue '_method37;
                } else {
                    v1_1.get().clone()
                }
            });
        }
    }
    pub fn method38(
        v0_1: string,
        v1_1: string,
        v2_1: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> (string, string, LrcPtr<StringBuilder>, i32, i32) {
        let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
        let v2_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2_1.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method38: loop {
            break '_method38 ({
                let v94: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.any_char / unexpected end of input / s: {:?}",
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v11: char = getCharAt(v1_1.get().clone(), 0_i32);
                    let v39: string = getSlice(
                        v1_1.get().clone(),
                        Some(1_i32),
                        Some((length(v1_1.get().clone())) - 1_i32),
                    );
                    let v45: string = ofChar(v11);
                    let v48: i32 = length(v45.clone());
                    let v49: Array<char> = new_init(&'\u{0000}', v48);
                    let v50: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Runtime::method27(v48, v50.clone()) {
                        let v52: i32 = v50.l0.get().clone();
                        let v53: char = getCharAt(v45.clone(), v52);
                        v49.get_mut()[v52 as usize] = v53;
                        {
                            let v54: i32 = (v52) + 1_i32;
                            v50.l0.set(v54);
                            ()
                        }
                    }
                    {
                        let v56: List<char> = ofArray(v49.clone());
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                    (Runtime::method28())(b0)(b1)
                                }),
                                v56,
                                LrcPtr::new(Runtime::UH0::UH0_0),
                            ),
                            v2_1.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US7::US7_0(
                            v11,
                            v39,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                };
                match &v94 {
                    Runtime::US7::US7_0(v94_0_0, v94_0_1, v94_0_2, v94_0_3, v94_0_4) => {
                        let v0_1_temp: string =
                            append((v0_1.get().clone()), (ofChar(v94_0_0.clone())));
                        let v1_1_temp: string = v94_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v94_0_2.clone();
                        let v3_temp: i32 = v94_0_3.clone();
                        let v4_temp: i32 = v94_0_4.clone();
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        v2_1.set(v2_1_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method38;
                    }
                    _ => (
                        v0_1.get().clone(),
                        v1_1.get().clone(),
                        v2_1.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method25(v0_1: string) -> Runtime::US6 {
        let _v0: MutCell<Option<Option<string>>> = MutCell::new(None::<Option<string>>);
        _v0.set(Some(Some(v0_1)));
        {
            let v9: string = defaultValue(
                string(""),
                match &_v0.get().clone() {
                    None => panic!("{}", string("optionm\'.of_obj / _v0=None"),),
                    Some(_v0_0_0) => _v0_0_0.clone(),
                },
            );
            let v15: LrcPtr<StringBuilder> = StringBuilder::_ctor__Z721C83C5(Runtime::method26());
            fn v18_1(arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US7 {
                Runtime::closure14((), arg10_0040)
            }
            fn v19_1(arg10_0040_1: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US7 {
                Runtime::closure18((), arg10_0040_1)
            }
            let v23: Runtime::US7 = Runtime::method31(
                v9.clone(),
                v15.clone(),
                LrcPtr::new(Runtime::UH1::UH1_1(
                    Func1::from(v18_1),
                    LrcPtr::new(Runtime::UH1::UH1_1(
                        Func1::from(v19_1),
                        LrcPtr::new(Runtime::UH1::UH1_0),
                    )),
                )),
            );
            let v229: Runtime::US8 = match &v23 {
                Runtime::US7::US7_0(v23_0_0, v23_0_1, v23_0_2, v23_0_3, v23_0_4) => {
                    let v28: i32 = v23_0_4.clone();
                    let v27: i32 = v23_0_3.clone();
                    let v26: LrcPtr<StringBuilder> = v23_0_2.clone();
                    let v25: string = v23_0_1.clone();
                    let v155: Runtime::US7 = if string("") == (v25.clone()) {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'']))),
                            (v26.clone(), v27, v28)
                        ))
                    } else {
                        let v49: char = getCharAt(v25.clone(), 0_i32);
                        if (Runtime::method32(v49, 0_i64)) == false {
                            let v80: string = getSlice(
                                v25.clone(),
                                Some(1_i32),
                                Some((length(v25.clone())) - 1_i32),
                            );
                            let v86: string = ofChar(v49);
                            let v89: i32 = length(v86.clone());
                            let v90: Array<char> = new_init(&'\u{0000}', v89);
                            let v91: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Runtime::method27(v89, v91.clone()) {
                                let v93: i32 = v91.l0.get().clone();
                                let v94: char = getCharAt(v86.clone(), v93);
                                v90.get_mut()[v93 as usize] = v94;
                                {
                                    let v95: i32 = (v93) + 1_i32;
                                    v91.l0.set(v95);
                                    ()
                                }
                            }
                            {
                                let v97: List<char> = ofArray(v90.clone());
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method29(
                                        foldBack(
                                            Func2::new(
                                                move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                                    (Runtime::method28())(b0)(b1)
                                                },
                                            ),
                                            v97,
                                            LrcPtr::new(Runtime::UH0::UH0_0),
                                        ),
                                        v26.clone(),
                                        v27,
                                        v28,
                                    );
                                Runtime::US7::US7_0(
                                    v49,
                                    v80,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Runtime::US7::US7_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v49,
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                (v26.clone(), v27, v28)
                            ))
                        }
                    };
                    let v167: Runtime::US7 = match &v155 {
                        Runtime::US7::US7_0(v155_0_0, v155_0_1, v155_0_2, v155_0_3, v155_0_4) => {
                            let v156: char = v155_0_0.clone();
                            Runtime::US7::US7_0(
                                if '\\' == (v156) { '/' } else { v156 },
                                v155_0_1.clone(),
                                v155_0_2.clone(),
                                v155_0_3.clone(),
                                v155_0_4.clone(),
                            )
                        }
                        Runtime::US7::US7_1(v155_1_0) => Runtime::US7::US7_1(v155_1_0.clone()),
                    };
                    let v187: Runtime::US8 = match &v167 {
                        Runtime::US7::US7_0(v167_0_0, v167_0_1, v167_0_2, v167_0_3, v167_0_4) => {
                            let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method33(
                                    ofChar(v167_0_0.clone()),
                                    v167_0_1.clone(),
                                    v167_0_2.clone(),
                                    v167_0_3.clone(),
                                    v167_0_4.clone(),
                                );
                            Runtime::US8::US8_0(
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                                patternInput_1.3.clone(),
                                patternInput_1.4.clone(),
                            )
                        }
                        Runtime::US7::US7_1(v167_1_0) => Runtime::US8::US8_1(v167_1_0.clone()),
                    };
                    let v197: Runtime::US8 = match &v187 {
                        Runtime::US8::US8_0(v187_0_0, v187_0_1, v187_0_2, v187_0_3, v187_0_4) => {
                            Runtime::US8::US8_0(
                                v187_0_0.clone(),
                                v187_0_1.clone(),
                                v187_0_2.clone(),
                                v187_0_3.clone(),
                                v187_0_4.clone(),
                            )
                        }
                        _ => Runtime::US8::US8_0(string(""), v25.clone(), v26.clone(), v27, v28),
                    };
                    match &v197 {
                        Runtime::US8::US8_0(v197_0_0, v197_0_1, v197_0_2, v197_0_3, v197_0_4) => {
                            let v202: i32 = v197_0_4.clone();
                            let v201: i32 = v197_0_3.clone();
                            let v200: LrcPtr<StringBuilder> = v197_0_2.clone();
                            let v199: string = v197_0_1.clone();
                            let v206: Runtime::US7 = Runtime::method34(
                                v199.clone(),
                                v200.clone(),
                                v201,
                                v202,
                                LrcPtr::new(Runtime::UH1::UH1_1(
                                    Func1::from(v18_1),
                                    LrcPtr::new(Runtime::UH1::UH1_1(
                                        Func1::from(v19_1),
                                        LrcPtr::new(Runtime::UH1::UH1_0),
                                    )),
                                )),
                            );
                            match &v206 {
                                    Runtime::US7::US7_0(v206_0_0, v206_0_1,
                                                        v206_0_2, v206_0_3,
                                                        v206_0_4) =>
                                    Runtime::US8::US8_0(v197_0_0.clone(),
                                                        v206_0_1.clone(),
                                                        v206_0_2.clone(),
                                                        v206_0_3.clone(),
                                                        v206_0_4.clone()),
                                    Runtime::US7::US7_1(v206_1_0) =>
                                    Runtime::US8::US8_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                 v206_1_0.clone(),
                                                                 (v9.clone(),
                                                                  v15.clone(),
                                                                  1_i32,
                                                                  1_i32),
                                                                 (v25.clone(),
                                                                  v26.clone(),
                                                                  v27, v28),
                                                                 (v199.clone(),
                                                                  v200.clone(),
                                                                  v201,
                                                                  v202))),
                                }
                        }
                        _ => Runtime::US8::US8_1(string("parsing.between / expected content")),
                    }
                }
                Runtime::US7::US7_1(v23_1_0) => Runtime::US8::US8_1(v23_1_0.clone()),
            };
            let v475: Runtime::US8 = match &v229 {
                Runtime::US8::US8_0(v229_0_0, v229_0_1, v229_0_2, v229_0_3, v229_0_4) => {
                    v229.clone()
                }
                _ => {
                    let v372: Runtime::US7 = if string("") == (v9.clone()) {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                            (v15.clone(), 1_i32, 1_i32)
                        ))
                    } else {
                        let v260: char = getCharAt(v9.clone(), 0_i32);
                        if (Runtime::method35(v260, 0_i64)) == false {
                            let v291: string = getSlice(
                                v9.clone(),
                                Some(1_i32),
                                Some((length(v9.clone())) - 1_i32),
                            );
                            let v297: string = ofChar(v260);
                            let v300: i32 = length(v297.clone());
                            let v301: Array<char> = new_init(&'\u{0000}', v300);
                            let v302: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Runtime::method27(v300, v302.clone()) {
                                let v304: i32 = v302.l0.get().clone();
                                let v305: char = getCharAt(v297.clone(), v304);
                                v301.get_mut()[v304 as usize] = v305;
                                {
                                    let v306: i32 = (v304) + 1_i32;
                                    v302.l0.set(v306);
                                    ()
                                }
                            }
                            {
                                let v308: List<char> = ofArray(v301.clone());
                                let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method29(
                                        foldBack(
                                            Func2::new(
                                                move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                                    (Runtime::method28())(b0)(b1)
                                                },
                                            ),
                                            v308,
                                            LrcPtr::new(Runtime::UH0::UH0_0),
                                        ),
                                        v15.clone(),
                                        1_i32,
                                        1_i32,
                                    );
                                Runtime::US7::US7_0(
                                    v260,
                                    v291,
                                    patternInput_2.0.clone(),
                                    patternInput_2.1.clone(),
                                    patternInput_2.2.clone(),
                                )
                            }
                        } else {
                            Runtime::US7::US7_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v260,
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                (v15.clone(), 1_i32, 1_i32)
                            ))
                        }
                    };
                    let v384: Runtime::US7 = match &v372 {
                        Runtime::US7::US7_0(v372_0_0, v372_0_1, v372_0_2, v372_0_3, v372_0_4) => {
                            let v373: char = v372_0_0.clone();
                            Runtime::US7::US7_0(
                                if '\\' == (v373) { '/' } else { v373 },
                                v372_0_1.clone(),
                                v372_0_2.clone(),
                                v372_0_3.clone(),
                                v372_0_4.clone(),
                            )
                        }
                        Runtime::US7::US7_1(v372_1_0) => Runtime::US7::US7_1(v372_1_0.clone()),
                    };
                    let v404: Runtime::US8 = match &v384 {
                        Runtime::US7::US7_0(v384_0_0, v384_0_1, v384_0_2, v384_0_3, v384_0_4) => {
                            let patternInput_3: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method36(
                                    ofChar(v384_0_0.clone()),
                                    v384_0_1.clone(),
                                    v384_0_2.clone(),
                                    v384_0_3.clone(),
                                    v384_0_4.clone(),
                                );
                            Runtime::US8::US8_0(
                                patternInput_3.0.clone(),
                                patternInput_3.1.clone(),
                                patternInput_3.2.clone(),
                                patternInput_3.3.clone(),
                                patternInput_3.4.clone(),
                            )
                        }
                        Runtime::US7::US7_1(v384_1_0) => Runtime::US8::US8_1(v384_1_0.clone()),
                    };
                    match &v404 {
                        Runtime::US8::US8_0(v404_0_0, v404_0_1, v404_0_2, v404_0_3, v404_0_4) => {
                            v404.clone()
                        }
                        _ => {
                            let v419: Runtime::US10 = if (length(v9.clone())) == 0_i32 {
                                Runtime::US10::US10_0(v9.clone(), v15.clone(), 1_i32, 1_i32)
                            } else {
                                Runtime::US10::US10_1(sprintf!(
                                    "parsing.eof / expected end of input / input: {:?}",
                                    v9.clone()
                                ))
                            };
                            let v428: Runtime::US8 = match &v419 {
                                Runtime::US10::US10_0(v419_0_0, v419_0_1, v419_0_2, v419_0_3) => {
                                    Runtime::US8::US8_0(
                                        string(""),
                                        v419_0_0.clone(),
                                        v419_0_1.clone(),
                                        v419_0_2.clone(),
                                        v419_0_3.clone(),
                                    )
                                }
                                Runtime::US10::US10_1(v419_1_0) => {
                                    Runtime::US8::US8_1(v419_1_0.clone())
                                }
                            };
                            match &v428 {
                                Runtime::US8::US8_0(
                                    v428_0_0,
                                    v428_0_1,
                                    v428_0_2,
                                    v428_0_3,
                                    v428_0_4,
                                ) => {
                                    let v430: string = v428_0_1.clone();
                                    Runtime::US8::US8_0(
                                        v428_0_0.clone(),
                                        getSlice(
                                            v430.clone(),
                                            Some(Runtime::method37(v430.clone(), 0_i32)),
                                            Some((length(v430)) - 1_i32),
                                        ),
                                        v428_0_2.clone(),
                                        v428_0_3.clone(),
                                        v428_0_4.clone(),
                                    )
                                }
                                Runtime::US8::US8_1(v428_1_0) => {
                                    Runtime::US8::US8_1(v428_1_0.clone())
                                }
                            }
                        }
                    }
                }
            };
            let v785: Runtime::US11 = match &v475 {
                Runtime::US8::US8_0(v475_0_0, v475_0_1, v475_0_2, v475_0_3, v475_0_4) => {
                    let v480: i32 = v475_0_4.clone();
                    let v479: i32 = v475_0_3.clone();
                    let v478: LrcPtr<StringBuilder> = v475_0_2.clone();
                    let v477: string = v475_0_1.clone();
                    let v628: Runtime::US7 = if string("") == (v477.clone()) {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                            ' ',
                            (v478.clone(), v479, v480)
                        ))
                    } else {
                        let v487: char = getCharAt(v477.clone(), 0_i32);
                        if (v487) == ' ' {
                            let v516: string = getSlice(
                                v477.clone(),
                                Some(1_i32),
                                Some((length(v477.clone())) - 1_i32),
                            );
                            let v522: string = ofChar(v487);
                            let v525: i32 = length(v522.clone());
                            let v526: Array<char> = new_init(&'\u{0000}', v525);
                            let v527: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Runtime::method27(v525, v527.clone()) {
                                let v529: i32 = v527.l0.get().clone();
                                let v530: char = getCharAt(v522.clone(), v529);
                                v526.get_mut()[v529 as usize] = v530;
                                {
                                    let v531: i32 = (v529) + 1_i32;
                                    v527.l0.set(v531);
                                    ()
                                }
                            }
                            {
                                let v533: List<char> = ofArray(v526.clone());
                                let patternInput_4: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method29(
                                        foldBack(
                                            Func2::new(
                                                move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                                    (Runtime::method28())(b0)(b1)
                                                },
                                            ),
                                            v533,
                                            LrcPtr::new(Runtime::UH0::UH0_0),
                                        ),
                                        v478.clone(),
                                        v479,
                                        v480,
                                    );
                                Runtime::US7::US7_0(
                                    v487,
                                    v516,
                                    patternInput_4.0.clone(),
                                    patternInput_4.1.clone(),
                                    patternInput_4.2.clone(),
                                )
                            }
                        } else {
                            let v576: i32 = (indexOf(v477.clone(), string("\n"))) - 1_i32;
                            Runtime::US7::US7_1(concat(new_array(&[
                                sprintf!(
                                    "parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                    ' ',
                                    v479,
                                    v480,
                                    v478.clone(),
                                    getSlice(
                                        v477.clone(),
                                        Some(0_i32),
                                        Some(
                                            (if -2_i32 == (v576) {
                                                (length(v477.clone())) + 1_i32
                                            } else {
                                                (v576) + 1_i32
                                            }) - 1_i32
                                        )
                                    )
                                ),
                                string("\n"),
                                append(
                                    ((Runtime::method30((v480) - 1_i32, 0_i32))(string(""))),
                                    string("^"),
                                ),
                                string("\n"),
                            ])))
                        }
                    };
                    let v640: Runtime::US12 = match &v628 {
                        Runtime::US7::US7_0(v628_0_0, v628_0_1, v628_0_2, v628_0_3, v628_0_4) => {
                            Runtime::US12::US12_0(
                                Runtime::US9::US9_0(v628_0_0.clone()),
                                v628_0_1.clone(),
                                v628_0_2.clone(),
                                v628_0_3.clone(),
                                v628_0_4.clone(),
                            )
                        }
                        _ => Runtime::US12::US12_0(
                            Runtime::US9::US9_1,
                            v477.clone(),
                            v478.clone(),
                            v479,
                            v480,
                        ),
                    };
                    let v759: Runtime::US8 = match &v640 {
                        Runtime::US12::US12_0(v640_0_0, v640_0_1, v640_0_2, v640_0_3, v640_0_4) => {
                            let v645: i32 = v640_0_4.clone();
                            let v644: i32 = v640_0_3.clone();
                            let v643: LrcPtr<StringBuilder> = v640_0_2.clone();
                            let v642: string = v640_0_1.clone();
                            let v735: Runtime::US7 = if string("") == (v642.clone()) {
                                Runtime::US7::US7_1(sprintf!(
                                    "parsing.any_char / unexpected end of input / s: {:?}",
                                    (v643.clone(), v644, v645)
                                ))
                            } else {
                                let v652: char = getCharAt(v642.clone(), 0_i32);
                                let v680: string = getSlice(
                                    v642.clone(),
                                    Some(1_i32),
                                    Some((length(v642)) - 1_i32),
                                );
                                let v686: string = ofChar(v652);
                                let v689: i32 = length(v686.clone());
                                let v690: Array<char> = new_init(&'\u{0000}', v689);
                                let v691: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Runtime::method27(v689, v691.clone()) {
                                    let v693: i32 = v691.l0.get().clone();
                                    let v694: char = getCharAt(v686.clone(), v693);
                                    v690.get_mut()[v693 as usize] = v694;
                                    {
                                        let v695: i32 = (v693) + 1_i32;
                                        v691.l0.set(v695);
                                        ()
                                    }
                                }
                                {
                                    let v697: List<char> = ofArray(v690.clone());
                                    let patternInput_5: (LrcPtr<StringBuilder>, i32, i32) =
                                        Runtime::method29(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                                        (Runtime::method28())(b0)(b1)
                                                    },
                                                ),
                                                v697,
                                                LrcPtr::new(Runtime::UH0::UH0_0),
                                            ),
                                            v643,
                                            v644,
                                            v645,
                                        );
                                    Runtime::US7::US7_0(
                                        v652,
                                        v680,
                                        patternInput_5.0.clone(),
                                        patternInput_5.1.clone(),
                                        patternInput_5.2.clone(),
                                    )
                                }
                            };
                            match &v735 {
                                Runtime::US7::US7_0(
                                    v735_0_0,
                                    v735_0_1,
                                    v735_0_2,
                                    v735_0_3,
                                    v735_0_4,
                                ) => {
                                    let patternInput_6: (
                                        string,
                                        string,
                                        LrcPtr<StringBuilder>,
                                        i32,
                                        i32,
                                    ) = Runtime::method38(
                                        ofChar(v735_0_0.clone()),
                                        v735_0_1.clone(),
                                        v735_0_2.clone(),
                                        v735_0_3.clone(),
                                        v735_0_4.clone(),
                                    );
                                    Runtime::US8::US8_0(
                                        patternInput_6.0.clone(),
                                        patternInput_6.1.clone(),
                                        patternInput_6.2.clone(),
                                        patternInput_6.3.clone(),
                                        patternInput_6.4.clone(),
                                    )
                                }
                                Runtime::US7::US7_1(v735_1_0) => {
                                    Runtime::US8::US8_1(v735_1_0.clone())
                                }
                            }
                        }
                        Runtime::US12::US12_1(v640_1_0) => Runtime::US8::US8_1(v640_1_0.clone()),
                    };
                    let v771: Runtime::US13 = match &v759 {
                        Runtime::US8::US8_0(v759_0_0, v759_0_1, v759_0_2, v759_0_3, v759_0_4) => {
                            Runtime::US13::US13_0(
                                Runtime::US5::US5_0(v759_0_0.clone()),
                                v759_0_1.clone(),
                                v759_0_2.clone(),
                                v759_0_3.clone(),
                                v759_0_4.clone(),
                            )
                        }
                        _ => Runtime::US13::US13_0(
                            Runtime::US5::US5_1,
                            v477.clone(),
                            v478.clone(),
                            v479,
                            v480,
                        ),
                    };
                    match &v771 {
                        Runtime::US13::US13_0(v771_0_0, v771_0_1, v771_0_2, v771_0_3, v771_0_4) => {
                            Runtime::US11::US11_0(
                                v475_0_0.clone(),
                                v771_0_0.clone(),
                                v771_0_1.clone(),
                                v771_0_2.clone(),
                                v771_0_3.clone(),
                                v771_0_4.clone(),
                            )
                        }
                        Runtime::US13::US13_1(v771_1_0) => Runtime::US11::US11_1(v771_1_0.clone()),
                    }
                }
                Runtime::US8::US8_1(v475_1_0) => Runtime::US11::US11_1(v475_1_0.clone()),
            };
            match &v785 {
                Runtime::US11::US11_0(
                    v785_0_0,
                    v785_0_1,
                    v785_0_2,
                    v785_0_3,
                    v785_0_4,
                    v785_0_5,
                ) => Runtime::US6::US6_0(v785_0_0.clone(), v785_0_1.clone()),
                Runtime::US11::US11_1(v785_1_0) => Runtime::US6::US6_1(v785_1_0.clone()),
            }
        }
    }
    pub fn method39() -> string {
        let v7: string = Runtime::method13(getCharAt(toLower(string("Debug")), 0_i32));
        let v14: &str = inline_colorization::color_bright_blue;
        let v21_1: &str = &*v7;
        let v49: &str = inline_colorization::color_reset;
        let v51: std::string::String = format!("{}{}{}", v14, v21_1, v49);
        fable_library_rust::String_::fromString(v51)
    }
    pub fn method41(
        v0_1: string,
        v1_1: Runtime::US5,
        v2_1: string,
        v3: Option<CancellationToken>,
        v4: Array<(string, string)>,
        v5: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v6: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v7: bool,
        v8: Option<string>,
    ) -> string {
        let v10: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method14()),
        });
        let v18_1: () = {
            Runtime::closure7(v10.clone(), string("{ "), ());
            ()
        };
        let v28: () = {
            Runtime::closure7(v10.clone(), string("file_name"), ());
            ()
        };
        let v38: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v47: () = {
            Runtime::closure7(v10.clone(), v0_1, ());
            ()
        };
        let v57: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v67: () = {
            Runtime::closure7(v10.clone(), string("arguments"), ());
            ()
        };
        let v76: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v89: () = {
            Runtime::closure7(v10.clone(), sprintf!("{:?}", v1_1), ());
            ()
        };
        let v98: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v108: () = {
            Runtime::closure7(v10.clone(), string("options"), ());
            ()
        };
        let v117: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v126: () = {
            Runtime::closure7(v10.clone(), string("{ "), ());
            ()
        };
        let v136: () = {
            Runtime::closure7(v10.clone(), string("command"), ());
            ()
        };
        let v145: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v154: () = {
            Runtime::closure7(v10.clone(), v2_1, ());
            ()
        };
        let v163: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v173: () = {
            Runtime::closure7(v10.clone(), string("cancellation_token"), ());
            ()
        };
        let v182: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v191: std::string::String = format!("{:#?}", v3);
        let v230: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v191),
                (),
            );
            ()
        };
        let v239: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v249: () = {
            Runtime::closure7(v10.clone(), string("environment_variables"), ());
            ()
        };
        let v258: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v271: () = {
            Runtime::closure7(v10.clone(), sprintf!("{:?}", v4), ());
            ()
        };
        let v280: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v290: () = {
            Runtime::closure7(v10.clone(), string("on_line"), ());
            ()
        };
        let v299: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v308: std::string::String = format!("{:#?}", v5);
        let v347: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v308),
                (),
            );
            ()
        };
        let v356: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v366: () = {
            Runtime::closure7(v10.clone(), string("stdin"), ());
            ()
        };
        let v375: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v384: std::string::String = format!("{:#?}", v6);
        let v423: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v384),
                (),
            );
            ()
        };
        let v432: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v442: () = {
            Runtime::closure7(v10.clone(), string("trace"), ());
            ()
        };
        let v451: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v463: () = {
            Runtime::closure7(
                v10.clone(),
                if v7 { string("true") } else { string("false") },
                (),
            );
            ()
        };
        let v472: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v482: () = {
            Runtime::closure7(v10.clone(), string("working_directory"), ());
            ()
        };
        let v491: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v500: std::string::String = format!("{:#?}", v8);
        let v539: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v500),
                (),
            );
            ()
        };
        let v549: () = {
            Runtime::closure7(v10.clone(), string(" }"), ());
            ()
        };
        let v558: () = {
            Runtime::closure7(v10.clone(), string(" }"), ());
            ()
        };
        v10.l0.get().clone()
    }
    pub fn method40(
        v0_1: LrcPtr<Runtime::Mut0>,
        v1_1: LrcPtr<Runtime::Mut1>,
        v2_1: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
        v9: Runtime::US5,
        v10: string,
        v11: Option<CancellationToken>,
        v12: Array<(string, string)>,
        v13: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v14: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v15: bool,
        v16: Option<string>,
    ) -> string {
        let v17_1: string = Runtime::method41(v8, v9, v10, v11, v12, v13, v14, v15, v16);
        Runtime::method18(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            string("runtime.execute_with_options_async"),
            v17_1
        ))
    }
    pub fn closure19(
        v0_1: string,
        v1_1: Option<CancellationToken>,
        v2_1: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
        v7: Runtime::US5,
        v8: string,
        unitVar: (),
    ) {
        if Runtime::method7(Runtime::US0::US0_1) {
            let v13: () = {
                Runtime::closure0((), ());
                ()
            };
            let patternInput: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v39: Option<i64> = patternInput.5.clone();
            let v38: LrcPtr<Runtime::Mut4> = patternInput.4.clone();
            let v37: LrcPtr<Runtime::Mut3> = patternInput.3.clone();
            let v36: LrcPtr<Runtime::Mut2> = patternInput.2.clone();
            let v35: LrcPtr<Runtime::Mut1> = patternInput.1.clone();
            let v34: LrcPtr<Runtime::Mut0> = patternInput.0.clone();
            Runtime::method19(Runtime::method40(
                v34.clone(),
                v35.clone(),
                v36.clone(),
                v37.clone(),
                v38.clone(),
                v39.clone(),
                Runtime::method8(v34, v35, v36, v37, v38, v39),
                Runtime::method39(),
                v8,
                v7,
                v0_1,
                v1_1,
                v2_1,
                v3,
                v4,
                v5,
                v6,
            ))
        };
    }
    pub fn method42(
        v0_1: string,
        v1_1: Option<CancellationToken>,
        v2_1: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
    ) -> Array<(string, string)> {
        v2_1
    }
    pub fn method45(v0_1: bool) -> string {
        unbox::<string>(fable_library_rust::Native_::getZero())
    }
    pub fn closure21(
        unitVar: (),
        v0_1: Func1<(i32, string, bool), Arc<Async<()>>>,
    ) -> Runtime::US14 {
        Runtime::US14::US14_0(v0_1)
    }
    pub fn method46() -> Func1<Func1<(i32, string, bool), Arc<Async<()>>>, Runtime::US14> {
        Func1::new(move |v: Func1<(i32, string, bool), Arc<Async<()>>>| Runtime::closure21((), v))
    }
    pub fn method47(v0_1: bool) -> i32 {
        unbox::<i32>(fable_library_rust::Native_::getZero())
    }
    pub fn method48() -> string {
        let v7: string = Runtime::method13(getCharAt(toLower(string("Verbose")), 0_i32));
        let v14: &str = inline_colorization::color_bright_black;
        let v21_1: &str = &*v7;
        let v49: &str = inline_colorization::color_reset;
        let v51: std::string::String = format!("{}{}{}", v14, v21_1, v49);
        fable_library_rust::String_::fromString(v51)
    }
    pub fn method49(
        v0_1: LrcPtr<Runtime::Mut0>,
        v1_1: LrcPtr<Runtime::Mut1>,
        v2_1: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
    ) -> string {
        let v9: string = Runtime::method17();
        Runtime::method18(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            v8,
            v9
        ))
    }
    pub fn closure22(v0_1: string, unitVar: ()) {
        if Runtime::method7(Runtime::US0::US0_0) {
            let v5: () = {
                Runtime::closure0((), ());
                ()
            };
            let patternInput: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v31: Option<i64> = patternInput.5.clone();
            let v30: LrcPtr<Runtime::Mut4> = patternInput.4.clone();
            let v29: LrcPtr<Runtime::Mut3> = patternInput.3.clone();
            let v28: LrcPtr<Runtime::Mut2> = patternInput.2.clone();
            let v27: LrcPtr<Runtime::Mut1> = patternInput.1.clone();
            let v26: LrcPtr<Runtime::Mut0> = patternInput.0.clone();
            Runtime::method19(if (v0_1.clone()) == string("") {
                string("")
            } else {
                Runtime::method49(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Runtime::method8(v26, v27, v28, v29, v30, v31),
                    Runtime::method48(),
                    v0_1,
                )
            })
        };
    }
    pub fn method44(
        v0_1: string,
        v1_1: Option<CancellationToken>,
        v2_1: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
        v7: bool,
        v8: LrcPtr<ConcurrentStack_1<string>>,
        v9: bool,
        v10: bool,
    ) -> Arc<Async<()>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method43(
        v0_1: string,
        v1_1: Option<CancellationToken>,
        v2_1: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
        v7: bool,
        v8: LrcPtr<ConcurrentStack_1<string>>,
        v9: bool,
        v10: bool,
    ) -> Arc<Async<()>> {
        Runtime::method44(v0_1, v1_1, v2_1, v3, v4, v5, v6, v7, v8, v9, v10)
    }
    pub fn closure20(
        v0_1: string,
        v1_1: Option<CancellationToken>,
        v2_1: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
        v7: bool,
        v8: LrcPtr<ConcurrentStack_1<string>>,
        v9: bool,
        v10: bool,
    ) {
        let v11: Arc<Async<()>> =
            Runtime::method43(v0_1, v1_1, v2_1, v3, v4, v5, v6, v7, v8, v9, v10);
        fable_library_rust::Native_::getZero::<()>();
        ()
    }
    pub fn closure23(unitVar: (), v0_1: CancellationToken) -> Runtime::US15 {
        Runtime::US15::US15_0(v0_1)
    }
    pub fn method50() -> Func1<CancellationToken, Runtime::US15> {
        Func1::new(move |v: CancellationToken| Runtime::closure23((), v))
    }
    pub fn method51(v0_1: CancellationToken) -> Arc<Async<CancellationToken>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method52(v0_1: bool) -> bool {
        unbox::<bool>(fable_library_rust::Native_::getZero())
    }
    pub fn method53(v0_1: bool) {
        ();
    }
    pub fn closure24(v0_1: bool, unitVar: ()) {
        if (Runtime::method52(v0_1)) == false {
            Runtime::method53(v0_1);
        };
    }
    pub fn method56(v0_1: LrcPtr<TaskCanceledException>) -> string {
        let v2_1: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method14()),
        });
        let v10: () = {
            Runtime::closure7(v2_1.clone(), string("{ "), ());
            ()
        };
        let v20_1: () = {
            Runtime::closure7(v2_1.clone(), string("ex"), ());
            ()
        };
        let v30: () = {
            Runtime::closure7(v2_1.clone(), string(" = "), ());
            ()
        };
        let v39: std::string::String = format!("{:#?}", v0_1);
        let v78: () = {
            Runtime::closure7(
                v2_1.clone(),
                fable_library_rust::String_::fromString(v39),
                (),
            );
            ()
        };
        let v88: () = {
            Runtime::closure7(v2_1.clone(), string(" }"), ());
            ()
        };
        v2_1.l0.get().clone()
    }
    pub fn method55(
        v0_1: LrcPtr<Runtime::Mut0>,
        v1_1: LrcPtr<Runtime::Mut1>,
        v2_1: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: LrcPtr<TaskCanceledException>,
    ) -> string {
        let v9: string = Runtime::method56(v8);
        Runtime::method18(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            string("runtime.execute_with_options_async / WaitForExitAsync"),
            v9
        ))
    }
    pub fn closure25(v0_1: LrcPtr<TaskCanceledException>, unitVar: ()) {
        if Runtime::method7(Runtime::US0::US0_3) {
            let v5: () = {
                Runtime::closure0((), ());
                ()
            };
            let patternInput: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v31: Option<i64> = patternInput.5.clone();
            let v30: LrcPtr<Runtime::Mut4> = patternInput.4.clone();
            let v29: LrcPtr<Runtime::Mut3> = patternInput.3.clone();
            let v28: LrcPtr<Runtime::Mut2> = patternInput.2.clone();
            let v27: LrcPtr<Runtime::Mut1> = patternInput.1.clone();
            let v26: LrcPtr<Runtime::Mut0> = patternInput.0.clone();
            Runtime::method19(Runtime::method55(
                v26.clone(),
                v27.clone(),
                v28.clone(),
                v29.clone(),
                v30.clone(),
                v31.clone(),
                Runtime::method8(v26, v27, v28, v29, v30, v31),
                Runtime::method12(),
                v0_1,
            ))
        };
    }
    pub fn method54(
        v0_1: bool,
        v1_1: LrcPtr<ConcurrentStack_1<string>>,
        v2_1: CancellationToken,
    ) -> Arc<Async<i32>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method57() -> string {
        string("\n")
    }
    pub fn method59(
        v0_1: i32,
        v1_1: i32,
        v2_1: string,
        v3: Option<CancellationToken>,
        v4: Array<(string, string)>,
        v5: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v6: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v7: bool,
        v8: Option<string>,
    ) -> string {
        let v10: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method14()),
        });
        let v18_1: () = {
            Runtime::closure7(v10.clone(), string("{ "), ());
            ()
        };
        let v28: () = {
            Runtime::closure7(v10.clone(), string("exit_code"), ());
            ()
        };
        let v38: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v47: () = {
            Runtime::closure7(v10.clone(), sprintf!("{}", v0_1), ());
            ()
        };
        let v57: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v67: () = {
            Runtime::closure7(v10.clone(), string("output_length"), ());
            ()
        };
        let v76: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v85: () = {
            Runtime::closure7(v10.clone(), sprintf!("{}", v1_1), ());
            ()
        };
        let v94: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v104: () = {
            Runtime::closure7(v10.clone(), string("options"), ());
            ()
        };
        let v113: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v122: () = {
            Runtime::closure7(v10.clone(), string("{ "), ());
            ()
        };
        let v132: () = {
            Runtime::closure7(v10.clone(), string("command"), ());
            ()
        };
        let v141: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v150: () = {
            Runtime::closure7(v10.clone(), v2_1, ());
            ()
        };
        let v159: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v169: () = {
            Runtime::closure7(v10.clone(), string("cancellation_token"), ());
            ()
        };
        let v178: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v187: std::string::String = format!("{:#?}", v3);
        let v226: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v187),
                (),
            );
            ()
        };
        let v235: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v245: () = {
            Runtime::closure7(v10.clone(), string("environment_variables"), ());
            ()
        };
        let v254: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v267: () = {
            Runtime::closure7(v10.clone(), sprintf!("{:?}", v4), ());
            ()
        };
        let v276: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v286: () = {
            Runtime::closure7(v10.clone(), string("on_line"), ());
            ()
        };
        let v295: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v304: std::string::String = format!("{:#?}", v5);
        let v343: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v304),
                (),
            );
            ()
        };
        let v352: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v362: () = {
            Runtime::closure7(v10.clone(), string("stdin"), ());
            ()
        };
        let v371: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v380: std::string::String = format!("{:#?}", v6);
        let v419: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v380),
                (),
            );
            ()
        };
        let v428: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v438: () = {
            Runtime::closure7(v10.clone(), string("trace"), ());
            ()
        };
        let v447: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v459: () = {
            Runtime::closure7(
                v10.clone(),
                if v7 { string("true") } else { string("false") },
                (),
            );
            ()
        };
        let v468: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v478: () = {
            Runtime::closure7(v10.clone(), string("working_directory"), ());
            ()
        };
        let v487: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v496: std::string::String = format!("{:#?}", v8);
        let v535: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v496),
                (),
            );
            ()
        };
        let v545: () = {
            Runtime::closure7(v10.clone(), string(" }"), ());
            ()
        };
        let v554: () = {
            Runtime::closure7(v10.clone(), string(" }"), ());
            ()
        };
        v10.l0.get().clone()
    }
    pub fn method58(
        v0_1: LrcPtr<Runtime::Mut0>,
        v1_1: LrcPtr<Runtime::Mut1>,
        v2_1: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i32,
        v9: i32,
        v10: string,
        v11: Option<CancellationToken>,
        v12: Array<(string, string)>,
        v13: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v14: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v15: bool,
        v16: Option<string>,
    ) -> string {
        let v17_1: string = Runtime::method59(v8, v9, v10, v11, v12, v13, v14, v15, v16);
        Runtime::method18(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            string("runtime.execute_with_options_async"),
            v17_1
        ))
    }
    pub fn closure26(
        v0_1: string,
        v1_1: Option<CancellationToken>,
        v2_1: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
        v7: i32,
        v8: string,
        unitVar: (),
    ) {
        if Runtime::method7(Runtime::US0::US0_1) {
            let v13: () = {
                Runtime::closure0((), ());
                ()
            };
            let patternInput: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v39: Option<i64> = patternInput.5.clone();
            let v38: LrcPtr<Runtime::Mut4> = patternInput.4.clone();
            let v37: LrcPtr<Runtime::Mut3> = patternInput.3.clone();
            let v36: LrcPtr<Runtime::Mut2> = patternInput.2.clone();
            let v35: LrcPtr<Runtime::Mut1> = patternInput.1.clone();
            let v34: LrcPtr<Runtime::Mut0> = patternInput.0.clone();
            Runtime::method19(Runtime::method58(
                v34.clone(),
                v35.clone(),
                v36.clone(),
                v37.clone(),
                v38.clone(),
                v39.clone(),
                Runtime::method8(v34, v35, v36, v37, v38, v39),
                Runtime::method39(),
                v7,
                length(v8),
                v0_1,
                v1_1,
                v2_1,
                v3,
                v4,
                v5,
                v6,
            ))
        };
    }
    pub fn method24(
        v0_1: string,
        v1_1: Option<CancellationToken>,
        v2_1: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
    ) -> Arc<Async<(i32, string)>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method23(
        v0_1: string,
        v1_1: Option<CancellationToken>,
        v2_1: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
    ) -> Arc<Async<(i32, string)>> {
        Runtime::method24(v0_1, v1_1, v2_1, v3, v4, v5, v6)
    }
    pub fn method22(v0_1: string) -> Arc<Async<(i32, string)>> {
        Runtime::method23(
            v0_1,
            None::<CancellationToken>,
            new_empty::<(string, string)>(),
            None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
            None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            true,
            None::<string>,
        )
    }
    pub fn closure13(unitVar: (), v0_1: string) -> Arc<Async<(i32, string)>> {
        Runtime::method22(v0_1)
    }
    pub fn closure27(
        unitVar: (),
        _arg: (
            string,
            Option<CancellationToken>,
            Array<(string, string)>,
            Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            bool,
            Option<string>,
        ),
    ) -> Arc<Async<(i32, string)>> {
        Runtime::method23(
            _arg.0.clone(),
            _arg.1.clone(),
            _arg.2.clone(),
            _arg.3.clone(),
            _arg.4.clone(),
            _arg.5.clone(),
            _arg.6.clone(),
        )
    }
    pub fn closure28(
        unitVar: (),
        v0_1: Func1<LrcPtr<Runtime::Heap0>, LrcPtr<Runtime::Heap0>>,
    ) -> (
        string,
        Option<CancellationToken>,
        Array<(string, string)>,
        Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        bool,
        Option<string>,
    ) {
        let v8: LrcPtr<Runtime::Heap0> = v0_1(LrcPtr::new(Runtime::Heap0 {
            l0: string(""),
            l1: None::<CancellationToken>,
            l2: new_empty::<(string, string)>(),
            l3: None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
            l4: None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            l5: true,
            l6: None::<string>,
        }));
        (
            v8.l0.clone(),
            v8.l1.clone(),
            v8.l2.clone(),
            v8.l3.clone(),
            v8.l4.clone(),
            v8.l5,
            v8.l6.clone(),
        )
    }
    pub fn method62(v0_1: char, v1_1: i64) -> bool {
        let v0_1: MutCell<char> = MutCell::new(v0_1);
        let v1_1: MutCell<i64> = MutCell::new(v1_1);
        '_method62: loop {
            break '_method62 (if (v1_1.get().clone()) >= 4_i64 {
                false
            } else {
                let v19_1: Runtime::US9 = if (v1_1.get().clone()) == 0_i64 {
                    Runtime::US9::US9_0('\\')
                } else {
                    let v5: i64 = (v1_1.get().clone()) - 1_i64;
                    if (v5) == 0_i64 {
                        Runtime::US9::US9_0('`')
                    } else {
                        let v8: i64 = (v5) - 1_i64;
                        if (v8) == 0_i64 {
                            Runtime::US9::US9_0('\"')
                        } else {
                            let v11: i64 = (v8) - 1_i64;
                            if (v11) == 0_i64 {
                                Runtime::US9::US9_0(' ')
                            } else {
                                let v14: i64 = (v11) - 1_i64;
                                Runtime::US9::US9_1
                            }
                        }
                    }
                };
                if (v0_1.get().clone())
                    == (match &v19_1 {
                        Runtime::US9::US9_0(v19_1_0_0) => match &v19_1 {
                            Runtime::US9::US9_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    })
                {
                    true
                } else {
                    let v0_1_temp: char = v0_1.get().clone();
                    let v1_1_temp: i64 = (v1_1.get().clone()) + 1_i64;
                    v0_1.set(v0_1_temp);
                    v1_1.set(v1_1_temp);
                    continue '_method62;
                }
            });
        }
    }
    pub fn method63(
        v0_1: string,
        v1_1: string,
        v2_1: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> (string, string, LrcPtr<StringBuilder>, i32, i32) {
        let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
        let v2_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2_1.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method63: loop {
            break '_method63 ({
                let v147: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v33: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method62(v33, 0_i64)) == false {
                        let v64: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v70: string = ofChar(v33);
                        let v73: i32 = length(v70.clone());
                        let v74: Array<char> = new_init(&'\u{0000}', v73);
                        let v75: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Runtime::method27(v73, v75.clone()) {
                            let v77: i32 = v75.l0.get().clone();
                            let v78: char = getCharAt(v70.clone(), v77);
                            v74.get_mut()[v77 as usize] = v78;
                            {
                                let v79: i32 = (v77) + 1_i32;
                                v75.l0.set(v79);
                                ()
                            }
                        }
                        {
                            let v81: List<char> = ofArray(v74.clone());
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                        (Runtime::method28())(b0)(b1)
                                    }),
                                    v81,
                                    LrcPtr::new(Runtime::UH0::UH0_0),
                                ),
                                v2_1.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Runtime::US7::US7_0(
                                v33,
                                v64,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        }
                    } else {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                            v33,
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    }
                };
                match &v147 {
                    Runtime::US7::US7_0(v147_0_0, v147_0_1, v147_0_2, v147_0_3, v147_0_4) => {
                        let v0_1_temp: string =
                            append((v0_1.get().clone()), (ofChar(v147_0_0.clone())));
                        let v1_1_temp: string = v147_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v147_0_2.clone();
                        let v3_temp: i32 = v147_0_3.clone();
                        let v4_temp: i32 = v147_0_4.clone();
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        v2_1.set(v2_1_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method63;
                    }
                    _ => (
                        v0_1.get().clone(),
                        v1_1.get().clone(),
                        v2_1.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method65(v0_1: char, v1_1: i64) -> bool {
        let v0_1: MutCell<char> = MutCell::new(v0_1);
        let v1_1: MutCell<i64> = MutCell::new(v1_1);
        '_method65: loop {
            break '_method65 (if (v1_1.get().clone()) >= 3_i64 {
                false
            } else {
                let v15: Runtime::US9 = if (v1_1.get().clone()) == 0_i64 {
                    Runtime::US9::US9_0('\\')
                } else {
                    let v5: i64 = (v1_1.get().clone()) - 1_i64;
                    if (v5) == 0_i64 {
                        Runtime::US9::US9_0('`')
                    } else {
                        let v8: i64 = (v5) - 1_i64;
                        if (v8) == 0_i64 {
                            Runtime::US9::US9_0('\"')
                        } else {
                            let v11: i64 = (v8) - 1_i64;
                            Runtime::US9::US9_1
                        }
                    }
                };
                if (v0_1.get().clone())
                    == (match &v15 {
                        Runtime::US9::US9_0(v15_0_0) => match &v15 {
                            Runtime::US9::US9_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    })
                {
                    true
                } else {
                    let v0_1_temp: char = v0_1.get().clone();
                    let v1_1_temp: i64 = (v1_1.get().clone()) + 1_i64;
                    v0_1.set(v0_1_temp);
                    v1_1.set(v1_1_temp);
                    continue '_method65;
                }
            });
        }
    }
    pub fn closure30(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US8 {
        let v3: i32 = _arg.3.clone();
        let v2_1: i32 = _arg.2.clone();
        let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
        let v0_1: string = _arg.0.clone();
        let v152: Runtime::US7 = if string("") == (v0_1.clone()) {
            Runtime::US7::US7_1(sprintf!(
                "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                '\\',
                (v1_1.clone(), v2_1, v3)
            ))
        } else {
            let v10: char = getCharAt(v0_1.clone(), 0_i32);
            if (v10) == '\\' {
                let v39: string = getSlice(
                    v0_1.clone(),
                    Some(1_i32),
                    Some((length(v0_1.clone())) - 1_i32),
                );
                let v45: string = ofChar(v10);
                let v48: i32 = length(v45.clone());
                let v49: Array<char> = new_init(&'\u{0000}', v48);
                let v50: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                    l0: MutCell::new(0_i32),
                });
                while Runtime::method27(v48, v50.clone()) {
                    let v52: i32 = v50.l0.get().clone();
                    let v53: char = getCharAt(v45.clone(), v52);
                    v49.get_mut()[v52 as usize] = v53;
                    {
                        let v54: i32 = (v52) + 1_i32;
                        v50.l0.set(v54);
                        ()
                    }
                }
                {
                    let v56: List<char> = ofArray(v49.clone());
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                        foldBack(
                            Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                (Runtime::method28())(b0)(b1)
                            }),
                            v56,
                            LrcPtr::new(Runtime::UH0::UH0_0),
                        ),
                        v1_1.clone(),
                        v2_1,
                        v3,
                    );
                    Runtime::US7::US7_0(
                        v10,
                        v39,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                }
            } else {
                let v99: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
                Runtime::US7::US7_1(concat(new_array(&[
                    sprintf!(
                        "parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                        '\\',
                        v2_1,
                        v3,
                        v1_1,
                        getSlice(
                            v0_1.clone(),
                            Some(0_i32),
                            Some(
                                (if -2_i32 == (v99) {
                                    (length(v0_1)) + 1_i32
                                } else {
                                    (v99) + 1_i32
                                }) - 1_i32
                            )
                        )
                    ),
                    string("\n"),
                    append(
                        ((Runtime::method30((v3) - 1_i32, 0_i32))(string(""))),
                        string("^"),
                    ),
                    string("\n"),
                ])))
            }
        };
        let v251: Runtime::US7 = match &v152 {
            Runtime::US7::US7_0(v152_0_0, v152_0_1, v152_0_2, v152_0_3, v152_0_4) => {
                let v157: i32 = v152_0_4.clone();
                let v156: i32 = v152_0_3.clone();
                let v155: LrcPtr<StringBuilder> = v152_0_2.clone();
                let v154: string = v152_0_1.clone();
                if string("") == (v154.clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.any_char / unexpected end of input / s: {:?}",
                        (v155.clone(), v156, v157)
                    ))
                } else {
                    let v164: char = getCharAt(v154.clone(), 0_i32);
                    let v192: string =
                        getSlice(v154.clone(), Some(1_i32), Some((length(v154)) - 1_i32));
                    let v198: string = ofChar(v164);
                    let v201: i32 = length(v198.clone());
                    let v202: Array<char> = new_init(&'\u{0000}', v201);
                    let v203: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Runtime::method27(v201, v203.clone()) {
                        let v205: i32 = v203.l0.get().clone();
                        let v206: char = getCharAt(v198.clone(), v205);
                        v202.get_mut()[v205 as usize] = v206;
                        {
                            let v207: i32 = (v205) + 1_i32;
                            v203.l0.set(v207);
                            ()
                        }
                    }
                    {
                        let v209: List<char> = ofArray(v202.clone());
                        let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                    (Runtime::method28())(b0)(b1)
                                }),
                                v209,
                                LrcPtr::new(Runtime::UH0::UH0_0),
                            ),
                            v155,
                            v156,
                            v157,
                        );
                        Runtime::US7::US7_0(
                            v164,
                            v192,
                            patternInput_1.0.clone(),
                            patternInput_1.1.clone(),
                            patternInput_1.2.clone(),
                        )
                    }
                }
            }
            Runtime::US7::US7_1(v152_1_0) => Runtime::US7::US7_1(v152_1_0.clone()),
        };
        match &v251 {
            Runtime::US7::US7_0(v251_0_0, v251_0_1, v251_0_2, v251_0_3, v251_0_4) => {
                Runtime::US8::US8_0(
                    append((ofChar('\\')), (ofChar(v251_0_0.clone()))),
                    v251_0_1.clone(),
                    v251_0_2.clone(),
                    v251_0_3.clone(),
                    v251_0_4.clone(),
                )
            }
            Runtime::US7::US7_1(v251_1_0) => Runtime::US8::US8_1(v251_1_0.clone()),
        }
    }
    pub fn closure31(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US8 {
        let v3: i32 = _arg.3.clone();
        let v2_1: i32 = _arg.2.clone();
        let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
        let v0_1: string = _arg.0.clone();
        let v152: Runtime::US7 = if string("") == (v0_1.clone()) {
            Runtime::US7::US7_1(sprintf!(
                "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                '`',
                (v1_1.clone(), v2_1, v3)
            ))
        } else {
            let v10: char = getCharAt(v0_1.clone(), 0_i32);
            if (v10) == '`' {
                let v39: string = getSlice(
                    v0_1.clone(),
                    Some(1_i32),
                    Some((length(v0_1.clone())) - 1_i32),
                );
                let v45: string = ofChar(v10);
                let v48: i32 = length(v45.clone());
                let v49: Array<char> = new_init(&'\u{0000}', v48);
                let v50: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                    l0: MutCell::new(0_i32),
                });
                while Runtime::method27(v48, v50.clone()) {
                    let v52: i32 = v50.l0.get().clone();
                    let v53: char = getCharAt(v45.clone(), v52);
                    v49.get_mut()[v52 as usize] = v53;
                    {
                        let v54: i32 = (v52) + 1_i32;
                        v50.l0.set(v54);
                        ()
                    }
                }
                {
                    let v56: List<char> = ofArray(v49.clone());
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                        foldBack(
                            Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                (Runtime::method28())(b0)(b1)
                            }),
                            v56,
                            LrcPtr::new(Runtime::UH0::UH0_0),
                        ),
                        v1_1.clone(),
                        v2_1,
                        v3,
                    );
                    Runtime::US7::US7_0(
                        v10,
                        v39,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                }
            } else {
                let v99: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
                Runtime::US7::US7_1(concat(new_array(&[
                    sprintf!(
                        "parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                        '`',
                        v2_1,
                        v3,
                        v1_1,
                        getSlice(
                            v0_1.clone(),
                            Some(0_i32),
                            Some(
                                (if -2_i32 == (v99) {
                                    (length(v0_1)) + 1_i32
                                } else {
                                    (v99) + 1_i32
                                }) - 1_i32
                            )
                        )
                    ),
                    string("\n"),
                    append(
                        ((Runtime::method30((v3) - 1_i32, 0_i32))(string(""))),
                        string("^"),
                    ),
                    string("\n"),
                ])))
            }
        };
        let v251: Runtime::US7 = match &v152 {
            Runtime::US7::US7_0(v152_0_0, v152_0_1, v152_0_2, v152_0_3, v152_0_4) => {
                let v157: i32 = v152_0_4.clone();
                let v156: i32 = v152_0_3.clone();
                let v155: LrcPtr<StringBuilder> = v152_0_2.clone();
                let v154: string = v152_0_1.clone();
                if string("") == (v154.clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.any_char / unexpected end of input / s: {:?}",
                        (v155.clone(), v156, v157)
                    ))
                } else {
                    let v164: char = getCharAt(v154.clone(), 0_i32);
                    let v192: string =
                        getSlice(v154.clone(), Some(1_i32), Some((length(v154)) - 1_i32));
                    let v198: string = ofChar(v164);
                    let v201: i32 = length(v198.clone());
                    let v202: Array<char> = new_init(&'\u{0000}', v201);
                    let v203: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Runtime::method27(v201, v203.clone()) {
                        let v205: i32 = v203.l0.get().clone();
                        let v206: char = getCharAt(v198.clone(), v205);
                        v202.get_mut()[v205 as usize] = v206;
                        {
                            let v207: i32 = (v205) + 1_i32;
                            v203.l0.set(v207);
                            ()
                        }
                    }
                    {
                        let v209: List<char> = ofArray(v202.clone());
                        let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                    (Runtime::method28())(b0)(b1)
                                }),
                                v209,
                                LrcPtr::new(Runtime::UH0::UH0_0),
                            ),
                            v155,
                            v156,
                            v157,
                        );
                        Runtime::US7::US7_0(
                            v164,
                            v192,
                            patternInput_1.0.clone(),
                            patternInput_1.1.clone(),
                            patternInput_1.2.clone(),
                        )
                    }
                }
            }
            Runtime::US7::US7_1(v152_1_0) => Runtime::US7::US7_1(v152_1_0.clone()),
        };
        match &v251 {
            Runtime::US7::US7_0(v251_0_0, v251_0_1, v251_0_2, v251_0_3, v251_0_4) => {
                Runtime::US8::US8_0(
                    append((ofChar('`')), (ofChar(v251_0_0.clone()))),
                    v251_0_1.clone(),
                    v251_0_2.clone(),
                    v251_0_3.clone(),
                    v251_0_4.clone(),
                )
            }
            Runtime::US7::US7_1(v251_1_0) => Runtime::US8::US8_1(v251_1_0.clone()),
        }
    }
    pub fn method66(
        v0_1: string,
        v1_1: LrcPtr<StringBuilder>,
        v2_1: i32,
        v3: i32,
        v4: LrcPtr<Runtime::UH3>,
    ) -> Runtime::US8 {
        let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
        let v2_1: MutCell<i32> = MutCell::new(v2_1);
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<LrcPtr<Runtime::UH3>> = MutCell::new(v4.clone());
        '_method66: loop {
            break '_method66 (match v4.get().clone().as_ref() {
                Runtime::UH3::UH3_0 => {
                    Runtime::US8::US8_1(string("parsing.choice / no parsers succeeded"))
                }
                Runtime::UH3::UH3_1(v4_1_0, v4_1_1) => {
                    let v9: Runtime::US8 = (match v4.get().clone().as_ref() {
                        Runtime::UH3::UH3_1(x, _) => x.clone(),
                        _ => unreachable!(),
                    })((
                        v0_1.get().clone(),
                        v1_1.get().clone(),
                        v2_1.get().clone(),
                        v3.get().clone(),
                    ));
                    match &v9 {
                        Runtime::US8::US8_0(v9_0_0, v9_0_1, v9_0_2, v9_0_3, v9_0_4) => v9.clone(),
                        _ => {
                            let v0_1_temp: string = v0_1.get().clone();
                            let v1_1_temp: LrcPtr<StringBuilder> = v1_1.get().clone();
                            let v2_1_temp: i32 = v2_1.get().clone();
                            let v3_temp: i32 = v3.get().clone();
                            let v4_temp: LrcPtr<Runtime::UH3> = match v4.get().clone().as_ref() {
                                Runtime::UH3::UH3_1(_, x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2_1.set(v2_1_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method66;
                        }
                    }
                }
            });
        }
    }
    pub fn method67(
        v0_1: LrcPtr<Runtime::UH2>,
        v1_1: LrcPtr<Runtime::UH2>,
    ) -> LrcPtr<Runtime::UH2> {
        let v0_1: MutCell<LrcPtr<Runtime::UH2>> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<LrcPtr<Runtime::UH2>> = MutCell::new(v1_1.clone());
        '_method67: loop {
            break '_method67 (match v0_1.get().clone().as_ref() {
                Runtime::UH2::UH2_0 => v1_1.get().clone(),
                Runtime::UH2::UH2_1(v0_1_1_0, v0_1_1_1) => {
                    let v0_1_temp: LrcPtr<Runtime::UH2> = match v0_1.get().clone().as_ref() {
                        Runtime::UH2::UH2_1(_, x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone();
                    let v1_1_temp: LrcPtr<Runtime::UH2> = LrcPtr::new(Runtime::UH2::UH2_1(
                        match v0_1.get().clone().as_ref() {
                            Runtime::UH2::UH2_1(x, _) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        v1_1.get().clone(),
                    ));
                    v0_1.set(v0_1_temp);
                    v1_1.set(v1_1_temp);
                    continue '_method67;
                }
            });
        }
    }
    pub fn method64(
        v0_1: LrcPtr<Runtime::UH2>,
        v1_1: string,
        v2_1: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> Runtime::US17 {
        let v0_1: MutCell<LrcPtr<Runtime::UH2>> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
        let v2_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2_1.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method64: loop {
            break '_method64 ({
                let v139: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\\', '`', '\"']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method65(v29, 0_i64)) == false {
                        let v60: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v66: string = ofChar(v29);
                        let v69: i32 = length(v66.clone());
                        let v70: Array<char> = new_init(&'\u{0000}', v69);
                        let v71: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Runtime::method27(v69, v71.clone()) {
                            let v73: i32 = v71.l0.get().clone();
                            let v74: char = getCharAt(v66.clone(), v73);
                            v70.get_mut()[v73 as usize] = v74;
                            {
                                let v75: i32 = (v73) + 1_i32;
                                v71.l0.set(v75);
                                ()
                            }
                        }
                        {
                            let v77: List<char> = ofArray(v70.clone());
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                        (Runtime::method28())(b0)(b1)
                                    }),
                                    v77,
                                    LrcPtr::new(Runtime::UH0::UH0_0),
                                ),
                                v2_1.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Runtime::US7::US7_0(
                                v29,
                                v60,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        }
                    } else {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                            v29,
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    }
                };
                let v154: Runtime::US8 = match &v139 {
                    Runtime::US7::US7_0(v139_0_0, v139_0_1, v139_0_2, v139_0_3, v139_0_4) => {
                        Runtime::US8::US8_0(
                            ofChar(v139_0_0.clone()),
                            v139_0_1.clone(),
                            v139_0_2.clone(),
                            v139_0_3.clone(),
                            v139_0_4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v139_1_0) => Runtime::US8::US8_1(v139_1_0.clone()),
                };
                let v168: Runtime::US8 = match &v154 {
                    Runtime::US8::US8_0(v154_0_0, v154_0_1, v154_0_2, v154_0_3, v154_0_4) => {
                        v154.clone()
                    }
                    _ => Runtime::method66(
                        v1_1.get().clone(),
                        v2_1.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                        LrcPtr::new(Runtime::UH3::UH3_1(
                            Func1::new(
                                move |arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)| {
                                    Runtime::closure30((), arg10_0040)
                                },
                            ),
                            LrcPtr::new(Runtime::UH3::UH3_1(
                                Func1::new(
                                    move |arg10_0040_1: (
                                        string,
                                        LrcPtr<StringBuilder>,
                                        i32,
                                        i32,
                                    )| {
                                        Runtime::closure31((), arg10_0040_1)
                                    },
                                ),
                                LrcPtr::new(Runtime::UH3::UH3_0),
                            )),
                        )),
                    ),
                };
                match &v168 {
                    Runtime::US8::US8_0(v168_0_0, v168_0_1, v168_0_2, v168_0_3, v168_0_4) => {
                        let v0_1_temp: LrcPtr<Runtime::UH2> =
                            LrcPtr::new(Runtime::UH2::UH2_1(v168_0_0.clone(), v0_1.get().clone()));
                        let v1_1_temp: string = v168_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v168_0_2.clone();
                        let v3_temp: i32 = v168_0_3.clone();
                        let v4_temp: i32 = v168_0_4.clone();
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        v2_1.set(v2_1_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method64;
                    }
                    _ => Runtime::US17::US17_0(
                        Runtime::method67(v0_1.get().clone(), LrcPtr::new(Runtime::UH2::UH2_0)),
                        v1_1.get().clone(),
                        v2_1.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method68(v0_1: LrcPtr<Runtime::UH2>, v1_1: List<string>) -> List<string> {
        match v0_1.as_ref() {
            Runtime::UH2::UH2_0 => v1_1.clone(),
            Runtime::UH2::UH2_1(v0_1_1_0, v0_1_1_1) => cons(
                match v0_1.as_ref() {
                    Runtime::UH2::UH2_1(x, _) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                Runtime::method68(
                    match v0_1.as_ref() {
                        Runtime::UH2::UH2_1(_, x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    v1_1.clone(),
                ),
            ),
        }
    }
    pub fn method69(
        v0_1: LrcPtr<Runtime::UH2>,
        v1_1: string,
        v2_1: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> Runtime::US17 {
        let v0_1: MutCell<LrcPtr<Runtime::UH2>> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
        let v2_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2_1.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method69: loop {
            break '_method69 ({
                let v139: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\\', '`', '\"']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method65(v29, 0_i64)) == false {
                        let v60: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v66: string = ofChar(v29);
                        let v69: i32 = length(v66.clone());
                        let v70: Array<char> = new_init(&'\u{0000}', v69);
                        let v71: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Runtime::method27(v69, v71.clone()) {
                            let v73: i32 = v71.l0.get().clone();
                            let v74: char = getCharAt(v66.clone(), v73);
                            v70.get_mut()[v73 as usize] = v74;
                            {
                                let v75: i32 = (v73) + 1_i32;
                                v71.l0.set(v75);
                                ()
                            }
                        }
                        {
                            let v77: List<char> = ofArray(v70.clone());
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                        (Runtime::method28())(b0)(b1)
                                    }),
                                    v77,
                                    LrcPtr::new(Runtime::UH0::UH0_0),
                                ),
                                v2_1.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Runtime::US7::US7_0(
                                v29,
                                v60,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        }
                    } else {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                            v29,
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    }
                };
                let v154: Runtime::US8 = match &v139 {
                    Runtime::US7::US7_0(v139_0_0, v139_0_1, v139_0_2, v139_0_3, v139_0_4) => {
                        Runtime::US8::US8_0(
                            ofChar(v139_0_0.clone()),
                            v139_0_1.clone(),
                            v139_0_2.clone(),
                            v139_0_3.clone(),
                            v139_0_4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v139_1_0) => Runtime::US8::US8_1(v139_1_0.clone()),
                };
                match &v154 {
                    Runtime::US8::US8_0(v154_0_0, v154_0_1, v154_0_2, v154_0_3, v154_0_4) => {
                        let v0_1_temp: LrcPtr<Runtime::UH2> =
                            LrcPtr::new(Runtime::UH2::UH2_1(v154_0_0.clone(), v0_1.get().clone()));
                        let v1_1_temp: string = v154_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v154_0_2.clone();
                        let v3_temp: i32 = v154_0_3.clone();
                        let v4_temp: i32 = v154_0_4.clone();
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        v2_1.set(v2_1_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method69;
                    }
                    _ => Runtime::US17::US17_0(
                        Runtime::method67(v0_1.get().clone(), LrcPtr::new(Runtime::UH2::UH2_0)),
                        v1_1.get().clone(),
                        v2_1.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method61(
        v0_1: LrcPtr<Runtime::UH2>,
        v1_1: string,
        v2_1: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> Runtime::US17 {
        let v0_1: MutCell<LrcPtr<Runtime::UH2>> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
        let v2_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2_1.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method61: loop {
            break '_method61 ({
                let v5: bool = string("") == (v1_1.get().clone());
                let v147: Runtime::US7 = if v5 {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v33: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method62(v33, 0_i64)) == false {
                        let v64: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v70: string = ofChar(v33);
                        let v73: i32 = length(v70.clone());
                        let v74: Array<char> = new_init(&'\u{0000}', v73);
                        let v75: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Runtime::method27(v73, v75.clone()) {
                            let v77: i32 = v75.l0.get().clone();
                            let v78: char = getCharAt(v70.clone(), v77);
                            v74.get_mut()[v77 as usize] = v78;
                            {
                                let v79: i32 = (v77) + 1_i32;
                                v75.l0.set(v79);
                                ()
                            }
                        }
                        {
                            let v81: List<char> = ofArray(v74.clone());
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                        (Runtime::method28())(b0)(b1)
                                    }),
                                    v81,
                                    LrcPtr::new(Runtime::UH0::UH0_0),
                                ),
                                v2_1.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Runtime::US7::US7_0(
                                v33,
                                v64,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        }
                    } else {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                            v33,
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    }
                };
                let v167: Runtime::US8 = match &v147 {
                    Runtime::US7::US7_0(v147_0_0, v147_0_1, v147_0_2, v147_0_3, v147_0_4) => {
                        let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                            Runtime::method63(
                                ofChar(v147_0_0.clone()),
                                v147_0_1.clone(),
                                v147_0_2.clone(),
                                v147_0_3.clone(),
                                v147_0_4.clone(),
                            );
                        Runtime::US8::US8_0(
                            patternInput_1.0.clone(),
                            patternInput_1.1.clone(),
                            patternInput_1.2.clone(),
                            patternInput_1.3.clone(),
                            patternInput_1.4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v147_1_0) => Runtime::US8::US8_1(v147_1_0.clone()),
                };
                let v605: Runtime::US8 = match &v167 {
                    Runtime::US8::US8_0(v167_0_0, v167_0_1, v167_0_2, v167_0_3, v167_0_4) => {
                        v167.clone()
                    }
                    _ => {
                        let v321: Runtime::US7 = if v5 {
                            Runtime::US7::US7_1(sprintf!(
                                "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                '\"',
                                (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        } else {
                            let v179: char = getCharAt(v1_1.get().clone(), 0_i32);
                            if (v179) == '\"' {
                                let v208: string = getSlice(
                                    v1_1.get().clone(),
                                    Some(1_i32),
                                    Some((length(v1_1.get().clone())) - 1_i32),
                                );
                                let v214: string = ofChar(v179);
                                let v217: i32 = length(v214.clone());
                                let v218: Array<char> = new_init(&'\u{0000}', v217);
                                let v219: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Runtime::method27(v217, v219.clone()) {
                                    let v221: i32 = v219.l0.get().clone();
                                    let v222: char = getCharAt(v214.clone(), v221);
                                    v218.get_mut()[v221 as usize] = v222;
                                    {
                                        let v223: i32 = (v221) + 1_i32;
                                        v219.l0.set(v223);
                                        ()
                                    }
                                }
                                {
                                    let v225: List<char> = ofArray(v218.clone());
                                    let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                        Runtime::method29(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                                        (Runtime::method28())(b0)(b1)
                                                    },
                                                ),
                                                v225,
                                                LrcPtr::new(Runtime::UH0::UH0_0),
                                            ),
                                            v2_1.get().clone(),
                                            v3.get().clone(),
                                            v4.get().clone(),
                                        );
                                    Runtime::US7::US7_0(
                                        v179,
                                        v208,
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone(),
                                        patternInput_2.2.clone(),
                                    )
                                }
                            } else {
                                let v268: i32 = (indexOf(v1_1.get().clone(), string("\n"))) - 1_i32;
                                Runtime::US7::US7_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                                 '\"',
                                                                                                 v3.get().clone(),
                                                                                                 v4.get().clone(),
                                                                                                 v2_1.get().clone(),
                                                                                                 getSlice(v1_1.get().clone(),
                                                                                                          Some(0_i32),
                                                                                                          Some((if -2_i32
                                                                                                                       ==
                                                                                                                       (v268)
                                                                                                                   {
                                                                                                                    (length(v1_1.get().clone()))
                                                                                                                        +
                                                                                                                        1_i32
                                                                                                                } else {
                                                                                                                    (v268)
                                                                                                                        +
                                                                                                                        1_i32
                                                                                                                })
                                                                                                                   -
                                                                                                                   1_i32))),
                                                                                        string("\n"),
                                                                                        append(((Runtime::method30((v4.get().clone())
                                                                                                                       -
                                                                                                                       1_i32,
                                                                                                                   0_i32))(string(""))),
                                                                                               string("^")),
                                                                                        string("\n")])))
                            }
                        };
                        let v536: Runtime::US8 = match &v321 {
                            Runtime::US7::US7_0(
                                v321_0_0,
                                v321_0_1,
                                v321_0_2,
                                v321_0_3,
                                v321_0_4,
                            ) => {
                                let v326: i32 = v321_0_4.clone();
                                let v325: i32 = v321_0_3.clone();
                                let v324: LrcPtr<StringBuilder> = v321_0_2.clone();
                                let v323: string = v321_0_1.clone();
                                let v328: Runtime::US17 = Runtime::method64(
                                    LrcPtr::new(Runtime::UH2::UH2_0),
                                    v323.clone(),
                                    v324.clone(),
                                    v325,
                                    v326,
                                );
                                let v359: Runtime::US8 = match &v328 {
                                    Runtime::US17::US17_0(
                                        v328_0_0,
                                        v328_0_1,
                                        v328_0_2,
                                        v328_0_3,
                                        v328_0_4,
                                    ) => {
                                        let v335: List<string> =
                                            Runtime::method68(v328_0_0.clone(), empty::<string>());
                                        Runtime::US8::US8_0(
                                            join(
                                                string(""),
                                                toArray_1(delay(Func0::new({
                                                    let v335 = v335.clone();
                                                    move || ofList(v335.clone()).clone()
                                                }))),
                                            ),
                                            v328_0_1.clone(),
                                            v328_0_2.clone(),
                                            v328_0_3.clone(),
                                            v328_0_4.clone(),
                                        )
                                    }
                                    Runtime::US17::US17_1(v328_1_0) => {
                                        Runtime::US8::US8_1(v328_1_0.clone())
                                    }
                                };
                                match &v359 {
                                    Runtime::US8::US8_0(
                                        v359_0_0,
                                        v359_0_1,
                                        v359_0_2,
                                        v359_0_3,
                                        v359_0_4,
                                    ) => {
                                        let v364: i32 = v359_0_4.clone();
                                        let v363: i32 = v359_0_3.clone();
                                        let v362: LrcPtr<StringBuilder> = v359_0_2.clone();
                                        let v361: string = v359_0_1.clone();
                                        let v513: Runtime::US7 = if string("") == (v361.clone()) {
                                            Runtime::US7::US7_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                                                                              '\"',
                                                                                              (v362.clone(),
                                                                                               v363,
                                                                                               v364)))
                                        } else {
                                            let v371: char = getCharAt(v361.clone(), 0_i32);
                                            if (v371) == '\"' {
                                                let v400: string = getSlice(
                                                    v361.clone(),
                                                    Some(1_i32),
                                                    Some((length(v361.clone())) - 1_i32),
                                                );
                                                let v406: string = ofChar(v371);
                                                let v409: i32 = length(v406.clone());
                                                let v410: Array<char> = new_init(&'\u{0000}', v409);
                                                let v411: LrcPtr<Runtime::Mut5> =
                                                    LrcPtr::new(Runtime::Mut5 {
                                                        l0: MutCell::new(0_i32),
                                                    });
                                                while Runtime::method27(v409, v411.clone()) {
                                                    let v413: i32 = v411.l0.get().clone();
                                                    let v414: char = getCharAt(v406.clone(), v413);
                                                    v410.get_mut()[v413 as usize] = v414;
                                                    {
                                                        let v415: i32 = (v413) + 1_i32;
                                                        v411.l0.set(v415);
                                                        ()
                                                    }
                                                }
                                                {
                                                    let v417: List<char> = ofArray(v410.clone());
                                                    let patternInput_3:
                                                                                 (LrcPtr<StringBuilder>,
                                                                                  i32,
                                                                                  i32) =
                                                                             Runtime::method29(foldBack(Func2::new(move
                                                                                                                       |b0:
                                                                                                                            char,
                                                                                                                        b1:
                                                                                                                            LrcPtr<Runtime::UH0>|
                                                                                                                       (Runtime::method28())(b0)(b1)),
                                                                                                        v417,
                                                                                                        LrcPtr::new(Runtime::UH0::UH0_0)),
                                                                                               v362.clone(),
                                                                                               v363,
                                                                                               v364);
                                                    Runtime::US7::US7_0(
                                                        v371,
                                                        v400,
                                                        patternInput_3.0.clone(),
                                                        patternInput_3.1.clone(),
                                                        patternInput_3.2.clone(),
                                                    )
                                                }
                                            } else {
                                                let v460: i32 =
                                                    (indexOf(v361.clone(), string("\n"))) - 1_i32;
                                                Runtime::US7::US7_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                                                     '\"',
                                                                                                                     v363,
                                                                                                                     v364,
                                                                                                                     v362.clone(),
                                                                                                                     getSlice(v361.clone(),
                                                                                                                              Some(0_i32),
                                                                                                                              Some((if -2_i32
                                                                                                                                           ==
                                                                                                                                           (v460)
                                                                                                                                       {
                                                                                                                                        (length(v361.clone()))
                                                                                                                                            +
                                                                                                                                            1_i32
                                                                                                                                    } else {
                                                                                                                                        (v460)
                                                                                                                                            +
                                                                                                                                            1_i32
                                                                                                                                    })
                                                                                                                                       -
                                                                                                                                       1_i32))),
                                                                                                            string("\n"),
                                                                                                            append(((Runtime::method30((v364)
                                                                                                                                           -
                                                                                                                                           1_i32,
                                                                                                                                       0_i32))(string(""))),
                                                                                                                   string("^")),
                                                                                                            string("\n")])))
                                            }
                                        };
                                        match &v513 {
                                                             Runtime::US7::US7_0(v513_0_0,
                                                                                 v513_0_1,
                                                                                 v513_0_2,
                                                                                 v513_0_3,
                                                                                 v513_0_4)
                                                             =>
                                                             Runtime::US8::US8_0(v359_0_0.clone(),
                                                                                 v513_0_1.clone(),
                                                                                 v513_0_2.clone(),
                                                                                 v513_0_3.clone(),
                                                                                 v513_0_4.clone()),
                                                             Runtime::US7::US7_1(v513_1_0)
                                                             =>
                                                             Runtime::US8::US8_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                                          v513_1_0.clone(),
                                                                                          (v1_1.get().clone(),
                                                                                           v2_1.get().clone(),
                                                                                           v3.get().clone(),
                                                                                           v4.get().clone()),
                                                                                          (v323.clone(),
                                                                                           v324.clone(),
                                                                                           v325,
                                                                                           v326),
                                                                                          (v361.clone(),
                                                                                           v362.clone(),
                                                                                           v363,
                                                                                           v364))),
                                                         }
                                    }
                                    _ => Runtime::US8::US8_1(string(
                                        "parsing.between / expected content",
                                    )),
                                }
                            }
                            Runtime::US7::US7_1(v321_1_0) => Runtime::US8::US8_1(v321_1_0.clone()),
                        };
                        match &v536 {
                            Runtime::US8::US8_0(
                                v536_0_0,
                                v536_0_1,
                                v536_0_2,
                                v536_0_3,
                                v536_0_4,
                            ) => v536.clone(),
                            _ => {
                                let v548: Runtime::US8 = Runtime::method66(
                                    v1_1.get().clone(),
                                    v2_1.get().clone(),
                                    v3.get().clone(),
                                    v4.get().clone(),
                                    LrcPtr::new(Runtime::UH3::UH3_1(
                                        Func1::new(
                                            move |arg10_0040: (
                                                string,
                                                LrcPtr<StringBuilder>,
                                                i32,
                                                i32,
                                            )| {
                                                Runtime::closure30((), arg10_0040)
                                            },
                                        ),
                                        LrcPtr::new(Runtime::UH3::UH3_1(
                                            Func1::new(
                                                move |arg10_0040_1: (
                                                    string,
                                                    LrcPtr<StringBuilder>,
                                                    i32,
                                                    i32,
                                                )| {
                                                    Runtime::closure31((), arg10_0040_1)
                                                },
                                            ),
                                            LrcPtr::new(Runtime::UH3::UH3_0),
                                        )),
                                    )),
                                );
                                let v559: Runtime::US8 = match &v548 {
                                    Runtime::US8::US8_0(
                                        v548_0_0,
                                        v548_0_1,
                                        v548_0_2,
                                        v548_0_3,
                                        v548_0_4,
                                    ) => Runtime::US8::US8_0(
                                        string(""),
                                        v548_0_1.clone(),
                                        v548_0_2.clone(),
                                        v548_0_3.clone(),
                                        v548_0_4.clone(),
                                    ),
                                    Runtime::US8::US8_1(v548_1_0) => {
                                        Runtime::US8::US8_1(v548_1_0.clone())
                                    }
                                };
                                let v570: Runtime::US17 = match &v559 {
                                    Runtime::US8::US8_0(
                                        v559_0_0,
                                        v559_0_1,
                                        v559_0_2,
                                        v559_0_3,
                                        v559_0_4,
                                    ) => Runtime::method69(
                                        LrcPtr::new(Runtime::UH2::UH2_0),
                                        v559_0_1.clone(),
                                        v559_0_2.clone(),
                                        v559_0_3.clone(),
                                        v559_0_4.clone(),
                                    ),
                                    Runtime::US8::US8_1(v559_1_0) => {
                                        Runtime::US17::US17_1(v559_1_0.clone())
                                    }
                                };
                                match &v570 {
                                    Runtime::US17::US17_0(
                                        v570_0_0,
                                        v570_0_1,
                                        v570_0_2,
                                        v570_0_3,
                                        v570_0_4,
                                    ) => {
                                        let v577: List<string> =
                                            Runtime::method68(v570_0_0.clone(), empty::<string>());
                                        Runtime::US8::US8_0(
                                            join(
                                                string(""),
                                                toArray_1(delay(Func0::new({
                                                    let v577 = v577.clone();
                                                    move || ofList(v577.clone()).clone()
                                                }))),
                                            ),
                                            v570_0_1.clone(),
                                            v570_0_2.clone(),
                                            v570_0_3.clone(),
                                            v570_0_4.clone(),
                                        )
                                    }
                                    Runtime::US17::US17_1(v570_1_0) => {
                                        Runtime::US8::US8_1(v570_1_0.clone())
                                    }
                                }
                            }
                        }
                    }
                };
                match &v605 {
                    Runtime::US8::US8_0(v605_0_0, v605_0_1, v605_0_2, v605_0_3, v605_0_4) => {
                        let v610: i32 = v605_0_4.clone();
                        let v609: i32 = v605_0_3.clone();
                        let v608: LrcPtr<StringBuilder> = v605_0_2.clone();
                        let v607: string = v605_0_1.clone();
                        let v606: string = v605_0_0.clone();
                        let v612: i32 = Runtime::method37(v607.clone(), 0_i32);
                        let v648: Runtime::US10 = if 0_i32 == (v612) {
                            Runtime::US10::US10_1(string(
                                "parsing.spaces1 / expected at least one space",
                            ))
                        } else {
                            Runtime::US10::US10_0(
                                getSlice(
                                    v607.clone(),
                                    Some(v612),
                                    Some((length(v607.clone())) - 1_i32),
                                ),
                                v608.clone(),
                                v609,
                                v610,
                            )
                        };
                        match &v648 {
                            Runtime::US10::US10_0(v648_0_0, v648_0_1, v648_0_2, v648_0_3) => {
                                let v0_1_temp: LrcPtr<Runtime::UH2> = LrcPtr::new(
                                    Runtime::UH2::UH2_1(v606.clone(), v0_1.get().clone()),
                                );
                                let v1_1_temp: string = v648_0_0.clone();
                                let v2_1_temp: LrcPtr<StringBuilder> = v648_0_1.clone();
                                let v3_temp: i32 = v648_0_2.clone();
                                let v4_temp: i32 = v648_0_3.clone();
                                v0_1.set(v0_1_temp);
                                v1_1.set(v1_1_temp);
                                v2_1.set(v2_1_temp);
                                v3.set(v3_temp);
                                v4.set(v4_temp);
                                continue '_method61;
                            }
                            _ => Runtime::US17::US17_0(
                                Runtime::method67(
                                    v0_1.get().clone(),
                                    LrcPtr::new(Runtime::UH2::UH2_1(
                                        v606.clone(),
                                        LrcPtr::new(Runtime::UH2::UH2_0),
                                    )),
                                ),
                                v607.clone(),
                                v608.clone(),
                                v609,
                                v610,
                            ),
                        }
                    }
                    _ => Runtime::US17::US17_0(
                        Runtime::method67(v0_1.get().clone(), LrcPtr::new(Runtime::UH2::UH2_0)),
                        v1_1.get().clone(),
                        v2_1.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method60(v0_1: string) -> Runtime::US16 {
        let _v0: MutCell<Option<Option<string>>> = MutCell::new(None::<Option<string>>);
        _v0.set(Some(Some(v0_1)));
        {
            let v21_1: Runtime::US17 = Runtime::method61(
                LrcPtr::new(Runtime::UH2::UH2_0),
                defaultValue(
                    string(""),
                    match &_v0.get().clone() {
                        None => panic!("{}", string("optionm\'.of_obj / _v0=None"),),
                        Some(_v0_0_0) => _v0_0_0.clone(),
                    },
                ),
                StringBuilder::_ctor__Z721C83C5(Runtime::method26()),
                1_i32,
                1_i32,
            );
            match &v21_1 {
                Runtime::US17::US17_0(v21_1_0_0, v21_1_0_1, v21_1_0_2, v21_1_0_3, v21_1_0_4) => {
                    Runtime::US16::US16_0(toArray(Runtime::method68(
                        v21_1_0_0.clone(),
                        empty::<string>(),
                    )))
                }
                Runtime::US17::US17_1(v21_1_1_0) => Runtime::US16::US16_1(v21_1_1_0.clone()),
            }
        }
    }
    pub fn closure29(unitVar: (), v0_1: string) -> Result<Array<string>, string> {
        let v1_1: Runtime::US16 = Runtime::method60(v0_1);
        match &v1_1 {
            Runtime::US16::US16_0(v1_1_0_0) => Ok::<Array<string>, string>(v1_1_0_0.clone()),
            Runtime::US16::US16_1(v1_1_1_0) => Err::<Array<string>, string>(v1_1_1_0.clone()),
        }
    }
    pub fn v0() -> () {
        static v0: OnceInit<()> = OnceInit::new();
        v0.get_or_init(|| ()).clone()
    }
    pub fn v1() -> Func0<()> {
        static v1: OnceInit<Func0<()>> = OnceInit::new();
        v1.get_or_init(|| Func0::new(move || Runtime::closure0((), ())))
            .clone()
    }
    pub fn v2() -> () {
        static v2: OnceInit<()> = OnceInit::new();
        v2.get_or_init(|| {
            (Runtime::v1())();
            Runtime::v0()
        })
        .clone()
    }
    pub fn v17() -> Func0<()> {
        static v17: OnceInit<Func0<()>> = OnceInit::new();
        v17.get_or_init(|| Func0::new(move || Runtime::closure3((), ())))
            .clone()
    }
    pub fn current_process_kill() {
        (Runtime::v17())();
    }
    pub fn v18() -> Func1<string, Arc<Async<(i32, string)>>> {
        static v18: OnceInit<Func1<string, Arc<Async<(i32, string)>>>> = OnceInit::new();
        v18.get_or_init(|| Func1::new(move |v: string| Runtime::closure13((), v)))
            .clone()
    }
    pub fn execute_async(x: string) -> Arc<Async<(i32, string)>> {
        (Runtime::v18())(x)
    }
    pub fn v19() -> Func1<
        (
            string,
            Option<CancellationToken>,
            Array<(string, string)>,
            Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            bool,
            Option<string>,
        ),
        Arc<Async<(i32, string)>>,
    > {
        static v19: OnceInit<
            Func1<
                (
                    string,
                    Option<CancellationToken>,
                    Array<(string, string)>,
                    Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
                    Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
                    bool,
                    Option<string>,
                ),
                Arc<Async<(i32, string)>>,
            >,
        > = OnceInit::new();
        v19.get_or_init(|| {
            Func1::new(
                move |arg10_0040: (
                    string,
                    Option<CancellationToken>,
                    Array<(string, string)>,
                    Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
                    Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
                    bool,
                    Option<string>,
                )| Runtime::closure27((), arg10_0040),
            )
        })
        .clone()
    }
    pub fn execute_with_options_async(
        x: (
            string,
            Option<CancellationToken>,
            Array<(string, string)>,
            Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            bool,
            Option<string>,
        ),
    ) -> Arc<Async<(i32, string)>> {
        (Runtime::v19())(x)
    }
    pub fn v20() -> Func1<
        Func1<LrcPtr<Runtime::Heap0>, LrcPtr<Runtime::Heap0>>,
        (
            string,
            Option<CancellationToken>,
            Array<(string, string)>,
            Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            bool,
            Option<string>,
        ),
    > {
        static v20: OnceInit<
            Func1<
                Func1<LrcPtr<Runtime::Heap0>, LrcPtr<Runtime::Heap0>>,
                (
                    string,
                    Option<CancellationToken>,
                    Array<(string, string)>,
                    Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
                    Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
                    bool,
                    Option<string>,
                ),
            >,
        > = OnceInit::new();
        v20.get_or_init(|| {
            Func1::new(
                move |v: Func1<LrcPtr<Runtime::Heap0>, LrcPtr<Runtime::Heap0>>| {
                    Runtime::closure28((), v)
                },
            )
        })
        .clone()
    }
    pub fn execution_options(
        x: Func1<LrcPtr<Runtime::Heap0>, LrcPtr<Runtime::Heap0>>,
    ) -> (
        string,
        Option<CancellationToken>,
        Array<(string, string)>,
        Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        bool,
        Option<string>,
    ) {
        (Runtime::v20())(x)
    }
    pub fn v21() -> Func1<string, Result<Array<string>, string>> {
        static v21: OnceInit<Func1<string, Result<Array<string>, string>>> = OnceInit::new();
        v21.get_or_init(|| Func1::new(move |v: string| Runtime::closure29((), v)))
            .clone()
    }
    pub fn split_args(x: string) -> Result<Array<string>, string> {
        (Runtime::v21())(x)
    }
    on_startup!(());
}
