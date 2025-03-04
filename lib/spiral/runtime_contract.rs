pub mod Runtime {
    use super::*;
    type Async<T> = T;
    type DateTime = ();
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
        panic!(
            "{}",
            sprintf!(
                "env.get_environment_variable / target: {} / var: {}",
                Runtime::US4::US4_3(Runtime::US3::US3_2),
                v0_1
            ),
        )
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
                let v63: DateTime = unbox::<DateTime>(fable_library_rust::Native_::getZero());
                Runtime::US2::US2_0(unbox::<i64>(fable_library_rust::Native_::getZero()))
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
        let v88: string = string("option_env!(\"AUTOMATION\").unwrap_or(\"\")");
        let v89: &str = option_env!("AUTOMATION").unwrap_or("");
        let v100: std::string::String = String::from(v89);
        let _run_target_args__v3: (Runtime::US1, Runtime::US2) = (
            Runtime::US1::US1_1,
            if (fable_library_rust::String_::fromString(v100)) != string("True") {
                Runtime::US2::US2_1
            } else {
                Runtime::US2::US2_0(near_sdk::env::block_timestamp() as i64)
            },
        );
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
        let v485: u64 = near_sdk::env::block_timestamp();
        let v502: Runtime::US2 = defaultValue(Runtime::US2::US2_1, map(Runtime::method9(), v5));
        let v515: u64 = (match &v502 {
            Runtime::US2::US2_0(v502_0_0) => {
                (v485)
                    - (match &v502 {
                        Runtime::US2::US2_0(x) => x.clone(),
                        _ => unreachable!(),
                    } as u64)
            }
            _ => v485,
        }) / 1000000000_u64;
        let v516: u64 = (v515) % 60_u64;
        let v518: u64 = ((v515) / 60_u64) % 60_u64;
        let v520: u64 = ((v515) / 3600_u64) % 24_u64;
        let v522: std::string::String = format!("{:02}:{:02}:{:02}", v520, v518, v516);
        fable_library_rust::String_::fromString(v522)
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
        let v96: &str = inline_colorization::color_yellow;
        let v107: &str = &*v7;
        let v131: &str = inline_colorization::color_reset;
        let v133: std::string::String = format!("{}{}{}", v96, v107, v131);
        fable_library_rust::String_::fromString(v133)
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
        let v27: LrcPtr<Runtime::Mut3> = patternInput.3.clone();
        let v44: () = {
            Runtime::closure8(patternInput.0.clone(), ());
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
                let v45: string = getSlice(
                    v0_1.clone(),
                    Some(1_i32),
                    Some((length(v0_1.clone())) - 1_i32),
                );
                let v51: string = ofChar(v10);
                let v54: i32 = length(v51.clone());
                let v55: Array<char> = new_init(&'\u{0000}', v54);
                let v56: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                    l0: MutCell::new(0_i32),
                });
                while Runtime::method27(v54, v56.clone()) {
                    let v58: i32 = v56.l0.get().clone();
                    let v59: char = getCharAt(v51.clone(), v58);
                    v55.get_mut()[v58 as usize] = v59;
                    {
                        let v60: i32 = (v58) + 1_i32;
                        v56.l0.set(v60);
                        ()
                    }
                }
                {
                    let v62: List<char> = ofArray(v55.clone());
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                        foldBack(
                            Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                (Runtime::method28())(b0)(b1)
                            }),
                            v62,
                            LrcPtr::new(Runtime::UH0::UH0_0),
                        ),
                        v1_1.clone(),
                        v2_1,
                        v3,
                    );
                    Runtime::US7::US7_0(
                        v10,
                        v45,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                }
            } else {
                let v105: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                (if -2_i32 == (v105) {
                                    (length(v0_1)) + 1_i32
                                } else {
                                    (v105) + 1_i32
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
                let v45: string = getSlice(
                    v0_1.clone(),
                    Some(1_i32),
                    Some((length(v0_1.clone())) - 1_i32),
                );
                let v51: string = ofChar(v10);
                let v54: i32 = length(v51.clone());
                let v55: Array<char> = new_init(&'\u{0000}', v54);
                let v56: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                    l0: MutCell::new(0_i32),
                });
                while Runtime::method27(v54, v56.clone()) {
                    let v58: i32 = v56.l0.get().clone();
                    let v59: char = getCharAt(v51.clone(), v58);
                    v55.get_mut()[v58 as usize] = v59;
                    {
                        let v60: i32 = (v58) + 1_i32;
                        v56.l0.set(v60);
                        ()
                    }
                }
                {
                    let v62: List<char> = ofArray(v55.clone());
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                        foldBack(
                            Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                (Runtime::method28())(b0)(b1)
                            }),
                            v62,
                            LrcPtr::new(Runtime::UH0::UH0_0),
                        ),
                        v1_1.clone(),
                        v2_1,
                        v3,
                    );
                    Runtime::US7::US7_0(
                        v10,
                        v45,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                }
            } else {
                let v105: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                (if -2_i32 == (v105) {
                                    (length(v0_1)) + 1_i32
                                } else {
                                    (v105) + 1_i32
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
                let v137: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\"', '\'']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v25: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method32(v25, 0_i64)) == false {
                        let v62: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v68: string = ofChar(v25);
                        let v71: i32 = length(v68.clone());
                        let v72: Array<char> = new_init(&'\u{0000}', v71);
                        let v73: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Runtime::method27(v71, v73.clone()) {
                            let v75: i32 = v73.l0.get().clone();
                            let v76: char = getCharAt(v68.clone(), v75);
                            v72.get_mut()[v75 as usize] = v76;
                            {
                                let v77: i32 = (v75) + 1_i32;
                                v73.l0.set(v77);
                                ()
                            }
                        }
                        {
                            let v79: List<char> = ofArray(v72.clone());
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                        (Runtime::method28())(b0)(b1)
                                    }),
                                    v79,
                                    LrcPtr::new(Runtime::UH0::UH0_0),
                                ),
                                v2_1.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Runtime::US7::US7_0(
                                v25,
                                v62,
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
                let v149: Runtime::US7 = match &v137 {
                    Runtime::US7::US7_0(v137_0_0, v137_0_1, v137_0_2, v137_0_3, v137_0_4) => {
                        let v138: char = v137_0_0.clone();
                        Runtime::US7::US7_0(
                            if '\\' == (v138) { '/' } else { v138 },
                            v137_0_1.clone(),
                            v137_0_2.clone(),
                            v137_0_3.clone(),
                            v137_0_4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v137_1_0) => Runtime::US7::US7_1(v137_1_0.clone()),
                };
                match &v149 {
                    Runtime::US7::US7_0(v149_0_0, v149_0_1, v149_0_2, v149_0_3, v149_0_4) => {
                        let v0_1_temp: string =
                            append((v0_1.get().clone()), (ofChar(v149_0_0.clone())));
                        let v1_1_temp: string = v149_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v149_0_2.clone();
                        let v3_temp: i32 = v149_0_3.clone();
                        let v4_temp: i32 = v149_0_4.clone();
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
                let v145: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method35(v29, 0_i64)) == false {
                        let v66: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v72: string = ofChar(v29);
                        let v75: i32 = length(v72.clone());
                        let v76: Array<char> = new_init(&'\u{0000}', v75);
                        let v77: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Runtime::method27(v75, v77.clone()) {
                            let v79: i32 = v77.l0.get().clone();
                            let v80: char = getCharAt(v72.clone(), v79);
                            v76.get_mut()[v79 as usize] = v80;
                            {
                                let v81: i32 = (v79) + 1_i32;
                                v77.l0.set(v81);
                                ()
                            }
                        }
                        {
                            let v83: List<char> = ofArray(v76.clone());
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                        (Runtime::method28())(b0)(b1)
                                    }),
                                    v83,
                                    LrcPtr::new(Runtime::UH0::UH0_0),
                                ),
                                v2_1.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Runtime::US7::US7_0(
                                v29,
                                v66,
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
                let v157: Runtime::US7 = match &v145 {
                    Runtime::US7::US7_0(v145_0_0, v145_0_1, v145_0_2, v145_0_3, v145_0_4) => {
                        let v146: char = v145_0_0.clone();
                        Runtime::US7::US7_0(
                            if '\\' == (v146) { '/' } else { v146 },
                            v145_0_1.clone(),
                            v145_0_2.clone(),
                            v145_0_3.clone(),
                            v145_0_4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v145_1_0) => Runtime::US7::US7_1(v145_1_0.clone()),
                };
                match &v157 {
                    Runtime::US7::US7_0(v157_0_0, v157_0_1, v157_0_2, v157_0_3, v157_0_4) => {
                        let v0_1_temp: string =
                            append((v0_1.get().clone()), (ofChar(v157_0_0.clone())));
                        let v1_1_temp: string = v157_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v157_0_2.clone();
                        let v3_temp: i32 = v157_0_3.clone();
                        let v4_temp: i32 = v157_0_4.clone();
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
                let v100: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.any_char / unexpected end of input / s: {:?}",
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v11: char = getCharAt(v1_1.get().clone(), 0_i32);
                    let v45: string = getSlice(
                        v1_1.get().clone(),
                        Some(1_i32),
                        Some((length(v1_1.get().clone())) - 1_i32),
                    );
                    let v51: string = ofChar(v11);
                    let v54: i32 = length(v51.clone());
                    let v55: Array<char> = new_init(&'\u{0000}', v54);
                    let v56: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Runtime::method27(v54, v56.clone()) {
                        let v58: i32 = v56.l0.get().clone();
                        let v59: char = getCharAt(v51.clone(), v58);
                        v55.get_mut()[v58 as usize] = v59;
                        {
                            let v60: i32 = (v58) + 1_i32;
                            v56.l0.set(v60);
                            ()
                        }
                    }
                    {
                        let v62: List<char> = ofArray(v55.clone());
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                    (Runtime::method28())(b0)(b1)
                                }),
                                v62,
                                LrcPtr::new(Runtime::UH0::UH0_0),
                            ),
                            v2_1.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US7::US7_0(
                            v11,
                            v45,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                };
                match &v100 {
                    Runtime::US7::US7_0(v100_0_0, v100_0_1, v100_0_2, v100_0_3, v100_0_4) => {
                        let v0_1_temp: string =
                            append((v0_1.get().clone()), (ofChar(v100_0_0.clone())));
                        let v1_1_temp: string = v100_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v100_0_2.clone();
                        let v3_temp: i32 = v100_0_3.clone();
                        let v4_temp: i32 = v100_0_4.clone();
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
            let v235: Runtime::US8 = match &v23 {
                Runtime::US7::US7_0(v23_0_0, v23_0_1, v23_0_2, v23_0_3, v23_0_4) => {
                    let v28: i32 = v23_0_4.clone();
                    let v27: i32 = v23_0_3.clone();
                    let v26: LrcPtr<StringBuilder> = v23_0_2.clone();
                    let v25: string = v23_0_1.clone();
                    let v161: Runtime::US7 = if string("") == (v25.clone()) {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'']))),
                            (v26.clone(), v27, v28)
                        ))
                    } else {
                        let v49: char = getCharAt(v25.clone(), 0_i32);
                        if (Runtime::method32(v49, 0_i64)) == false {
                            let v86: string = getSlice(
                                v25.clone(),
                                Some(1_i32),
                                Some((length(v25.clone())) - 1_i32),
                            );
                            let v92: string = ofChar(v49);
                            let v95: i32 = length(v92.clone());
                            let v96: Array<char> = new_init(&'\u{0000}', v95);
                            let v97: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Runtime::method27(v95, v97.clone()) {
                                let v99: i32 = v97.l0.get().clone();
                                let v100: char = getCharAt(v92.clone(), v99);
                                v96.get_mut()[v99 as usize] = v100;
                                {
                                    let v101: i32 = (v99) + 1_i32;
                                    v97.l0.set(v101);
                                    ()
                                }
                            }
                            {
                                let v103: List<char> = ofArray(v96.clone());
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method29(
                                        foldBack(
                                            Func2::new(
                                                move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                                    (Runtime::method28())(b0)(b1)
                                                },
                                            ),
                                            v103,
                                            LrcPtr::new(Runtime::UH0::UH0_0),
                                        ),
                                        v26.clone(),
                                        v27,
                                        v28,
                                    );
                                Runtime::US7::US7_0(
                                    v49,
                                    v86,
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
                    let v173: Runtime::US7 = match &v161 {
                        Runtime::US7::US7_0(v161_0_0, v161_0_1, v161_0_2, v161_0_3, v161_0_4) => {
                            let v162: char = v161_0_0.clone();
                            Runtime::US7::US7_0(
                                if '\\' == (v162) { '/' } else { v162 },
                                v161_0_1.clone(),
                                v161_0_2.clone(),
                                v161_0_3.clone(),
                                v161_0_4.clone(),
                            )
                        }
                        Runtime::US7::US7_1(v161_1_0) => Runtime::US7::US7_1(v161_1_0.clone()),
                    };
                    let v193: Runtime::US8 = match &v173 {
                        Runtime::US7::US7_0(v173_0_0, v173_0_1, v173_0_2, v173_0_3, v173_0_4) => {
                            let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method33(
                                    ofChar(v173_0_0.clone()),
                                    v173_0_1.clone(),
                                    v173_0_2.clone(),
                                    v173_0_3.clone(),
                                    v173_0_4.clone(),
                                );
                            Runtime::US8::US8_0(
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                                patternInput_1.3.clone(),
                                patternInput_1.4.clone(),
                            )
                        }
                        Runtime::US7::US7_1(v173_1_0) => Runtime::US8::US8_1(v173_1_0.clone()),
                    };
                    let v203: Runtime::US8 = match &v193 {
                        Runtime::US8::US8_0(v193_0_0, v193_0_1, v193_0_2, v193_0_3, v193_0_4) => {
                            Runtime::US8::US8_0(
                                v193_0_0.clone(),
                                v193_0_1.clone(),
                                v193_0_2.clone(),
                                v193_0_3.clone(),
                                v193_0_4.clone(),
                            )
                        }
                        _ => Runtime::US8::US8_0(string(""), v25.clone(), v26.clone(), v27, v28),
                    };
                    match &v203 {
                        Runtime::US8::US8_0(v203_0_0, v203_0_1, v203_0_2, v203_0_3, v203_0_4) => {
                            let v208: i32 = v203_0_4.clone();
                            let v207: i32 = v203_0_3.clone();
                            let v206: LrcPtr<StringBuilder> = v203_0_2.clone();
                            let v205: string = v203_0_1.clone();
                            let v212: Runtime::US7 = Runtime::method34(
                                v205.clone(),
                                v206.clone(),
                                v207,
                                v208,
                                LrcPtr::new(Runtime::UH1::UH1_1(
                                    Func1::from(v18_1),
                                    LrcPtr::new(Runtime::UH1::UH1_1(
                                        Func1::from(v19_1),
                                        LrcPtr::new(Runtime::UH1::UH1_0),
                                    )),
                                )),
                            );
                            match &v212 {
                                    Runtime::US7::US7_0(v212_0_0, v212_0_1,
                                                        v212_0_2, v212_0_3,
                                                        v212_0_4) =>
                                    Runtime::US8::US8_0(v203_0_0.clone(),
                                                        v212_0_1.clone(),
                                                        v212_0_2.clone(),
                                                        v212_0_3.clone(),
                                                        v212_0_4.clone()),
                                    Runtime::US7::US7_1(v212_1_0) =>
                                    Runtime::US8::US8_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                 v212_1_0.clone(),
                                                                 (v9.clone(),
                                                                  v15.clone(),
                                                                  1_i32,
                                                                  1_i32),
                                                                 (v25.clone(),
                                                                  v26.clone(),
                                                                  v27, v28),
                                                                 (v205.clone(),
                                                                  v206.clone(),
                                                                  v207,
                                                                  v208))),
                                }
                        }
                        _ => Runtime::US8::US8_1(string("parsing.between / expected content")),
                    }
                }
                Runtime::US7::US7_1(v23_1_0) => Runtime::US8::US8_1(v23_1_0.clone()),
            };
            let v493: Runtime::US8 = match &v235 {
                Runtime::US8::US8_0(v235_0_0, v235_0_1, v235_0_2, v235_0_3, v235_0_4) => {
                    v235.clone()
                }
                _ => {
                    let v384: Runtime::US7 = if string("") == (v9.clone()) {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                            (v15.clone(), 1_i32, 1_i32)
                        ))
                    } else {
                        let v266: char = getCharAt(v9.clone(), 0_i32);
                        if (Runtime::method35(v266, 0_i64)) == false {
                            let v303: string = getSlice(
                                v9.clone(),
                                Some(1_i32),
                                Some((length(v9.clone())) - 1_i32),
                            );
                            let v309: string = ofChar(v266);
                            let v312: i32 = length(v309.clone());
                            let v313: Array<char> = new_init(&'\u{0000}', v312);
                            let v314: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Runtime::method27(v312, v314.clone()) {
                                let v316: i32 = v314.l0.get().clone();
                                let v317: char = getCharAt(v309.clone(), v316);
                                v313.get_mut()[v316 as usize] = v317;
                                {
                                    let v318: i32 = (v316) + 1_i32;
                                    v314.l0.set(v318);
                                    ()
                                }
                            }
                            {
                                let v320: List<char> = ofArray(v313.clone());
                                let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method29(
                                        foldBack(
                                            Func2::new(
                                                move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                                    (Runtime::method28())(b0)(b1)
                                                },
                                            ),
                                            v320,
                                            LrcPtr::new(Runtime::UH0::UH0_0),
                                        ),
                                        v15.clone(),
                                        1_i32,
                                        1_i32,
                                    );
                                Runtime::US7::US7_0(
                                    v266,
                                    v303,
                                    patternInput_2.0.clone(),
                                    patternInput_2.1.clone(),
                                    patternInput_2.2.clone(),
                                )
                            }
                        } else {
                            Runtime::US7::US7_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v266,
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                (v15.clone(), 1_i32, 1_i32)
                            ))
                        }
                    };
                    let v396: Runtime::US7 = match &v384 {
                        Runtime::US7::US7_0(v384_0_0, v384_0_1, v384_0_2, v384_0_3, v384_0_4) => {
                            let v385: char = v384_0_0.clone();
                            Runtime::US7::US7_0(
                                if '\\' == (v385) { '/' } else { v385 },
                                v384_0_1.clone(),
                                v384_0_2.clone(),
                                v384_0_3.clone(),
                                v384_0_4.clone(),
                            )
                        }
                        Runtime::US7::US7_1(v384_1_0) => Runtime::US7::US7_1(v384_1_0.clone()),
                    };
                    let v416: Runtime::US8 = match &v396 {
                        Runtime::US7::US7_0(v396_0_0, v396_0_1, v396_0_2, v396_0_3, v396_0_4) => {
                            let patternInput_3: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method36(
                                    ofChar(v396_0_0.clone()),
                                    v396_0_1.clone(),
                                    v396_0_2.clone(),
                                    v396_0_3.clone(),
                                    v396_0_4.clone(),
                                );
                            Runtime::US8::US8_0(
                                patternInput_3.0.clone(),
                                patternInput_3.1.clone(),
                                patternInput_3.2.clone(),
                                patternInput_3.3.clone(),
                                patternInput_3.4.clone(),
                            )
                        }
                        Runtime::US7::US7_1(v396_1_0) => Runtime::US8::US8_1(v396_1_0.clone()),
                    };
                    match &v416 {
                        Runtime::US8::US8_0(v416_0_0, v416_0_1, v416_0_2, v416_0_3, v416_0_4) => {
                            v416.clone()
                        }
                        _ => {
                            let v431: Runtime::US10 = if (length(v9.clone())) == 0_i32 {
                                Runtime::US10::US10_0(v9.clone(), v15.clone(), 1_i32, 1_i32)
                            } else {
                                Runtime::US10::US10_1(sprintf!(
                                    "parsing.eof / expected end of input / input: {:?}",
                                    v9.clone()
                                ))
                            };
                            let v440: Runtime::US8 = match &v431 {
                                Runtime::US10::US10_0(v431_0_0, v431_0_1, v431_0_2, v431_0_3) => {
                                    Runtime::US8::US8_0(
                                        string(""),
                                        v431_0_0.clone(),
                                        v431_0_1.clone(),
                                        v431_0_2.clone(),
                                        v431_0_3.clone(),
                                    )
                                }
                                Runtime::US10::US10_1(v431_1_0) => {
                                    Runtime::US8::US8_1(v431_1_0.clone())
                                }
                            };
                            match &v440 {
                                Runtime::US8::US8_0(
                                    v440_0_0,
                                    v440_0_1,
                                    v440_0_2,
                                    v440_0_3,
                                    v440_0_4,
                                ) => {
                                    let v442: string = v440_0_1.clone();
                                    Runtime::US8::US8_0(
                                        v440_0_0.clone(),
                                        getSlice(
                                            v442.clone(),
                                            Some(Runtime::method37(v442.clone(), 0_i32)),
                                            Some((length(v442)) - 1_i32),
                                        ),
                                        v440_0_2.clone(),
                                        v440_0_3.clone(),
                                        v440_0_4.clone(),
                                    )
                                }
                                Runtime::US8::US8_1(v440_1_0) => {
                                    Runtime::US8::US8_1(v440_1_0.clone())
                                }
                            }
                        }
                    }
                }
            };
            let v821: Runtime::US11 = match &v493 {
                Runtime::US8::US8_0(v493_0_0, v493_0_1, v493_0_2, v493_0_3, v493_0_4) => {
                    let v498: i32 = v493_0_4.clone();
                    let v497: i32 = v493_0_3.clone();
                    let v496: LrcPtr<StringBuilder> = v493_0_2.clone();
                    let v495: string = v493_0_1.clone();
                    let v658: Runtime::US7 = if string("") == (v495.clone()) {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                            ' ',
                            (v496.clone(), v497, v498)
                        ))
                    } else {
                        let v505: char = getCharAt(v495.clone(), 0_i32);
                        if (v505) == ' ' {
                            let v540: string = getSlice(
                                v495.clone(),
                                Some(1_i32),
                                Some((length(v495.clone())) - 1_i32),
                            );
                            let v546: string = ofChar(v505);
                            let v549: i32 = length(v546.clone());
                            let v550: Array<char> = new_init(&'\u{0000}', v549);
                            let v551: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Runtime::method27(v549, v551.clone()) {
                                let v553: i32 = v551.l0.get().clone();
                                let v554: char = getCharAt(v546.clone(), v553);
                                v550.get_mut()[v553 as usize] = v554;
                                {
                                    let v555: i32 = (v553) + 1_i32;
                                    v551.l0.set(v555);
                                    ()
                                }
                            }
                            {
                                let v557: List<char> = ofArray(v550.clone());
                                let patternInput_4: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method29(
                                        foldBack(
                                            Func2::new(
                                                move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                                    (Runtime::method28())(b0)(b1)
                                                },
                                            ),
                                            v557,
                                            LrcPtr::new(Runtime::UH0::UH0_0),
                                        ),
                                        v496.clone(),
                                        v497,
                                        v498,
                                    );
                                Runtime::US7::US7_0(
                                    v505,
                                    v540,
                                    patternInput_4.0.clone(),
                                    patternInput_4.1.clone(),
                                    patternInput_4.2.clone(),
                                )
                            }
                        } else {
                            let v600: i32 = (indexOf(v495.clone(), string("\n"))) - 1_i32;
                            Runtime::US7::US7_1(concat(new_array(&[
                                sprintf!(
                                    "parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                    ' ',
                                    v497,
                                    v498,
                                    v496.clone(),
                                    getSlice(
                                        v495.clone(),
                                        Some(0_i32),
                                        Some(
                                            (if -2_i32 == (v600) {
                                                (length(v495.clone())) + 1_i32
                                            } else {
                                                (v600) + 1_i32
                                            }) - 1_i32
                                        )
                                    )
                                ),
                                string("\n"),
                                append(
                                    ((Runtime::method30((v498) - 1_i32, 0_i32))(string(""))),
                                    string("^"),
                                ),
                                string("\n"),
                            ])))
                        }
                    };
                    let v670: Runtime::US12 = match &v658 {
                        Runtime::US7::US7_0(v658_0_0, v658_0_1, v658_0_2, v658_0_3, v658_0_4) => {
                            Runtime::US12::US12_0(
                                Runtime::US9::US9_0(v658_0_0.clone()),
                                v658_0_1.clone(),
                                v658_0_2.clone(),
                                v658_0_3.clone(),
                                v658_0_4.clone(),
                            )
                        }
                        _ => Runtime::US12::US12_0(
                            Runtime::US9::US9_1,
                            v495.clone(),
                            v496.clone(),
                            v497,
                            v498,
                        ),
                    };
                    let v795: Runtime::US8 = match &v670 {
                        Runtime::US12::US12_0(v670_0_0, v670_0_1, v670_0_2, v670_0_3, v670_0_4) => {
                            let v675: i32 = v670_0_4.clone();
                            let v674: i32 = v670_0_3.clone();
                            let v673: LrcPtr<StringBuilder> = v670_0_2.clone();
                            let v672: string = v670_0_1.clone();
                            let v771: Runtime::US7 = if string("") == (v672.clone()) {
                                Runtime::US7::US7_1(sprintf!(
                                    "parsing.any_char / unexpected end of input / s: {:?}",
                                    (v673.clone(), v674, v675)
                                ))
                            } else {
                                let v682: char = getCharAt(v672.clone(), 0_i32);
                                let v716: string = getSlice(
                                    v672.clone(),
                                    Some(1_i32),
                                    Some((length(v672)) - 1_i32),
                                );
                                let v722: string = ofChar(v682);
                                let v725: i32 = length(v722.clone());
                                let v726: Array<char> = new_init(&'\u{0000}', v725);
                                let v727: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Runtime::method27(v725, v727.clone()) {
                                    let v729: i32 = v727.l0.get().clone();
                                    let v730: char = getCharAt(v722.clone(), v729);
                                    v726.get_mut()[v729 as usize] = v730;
                                    {
                                        let v731: i32 = (v729) + 1_i32;
                                        v727.l0.set(v731);
                                        ()
                                    }
                                }
                                {
                                    let v733: List<char> = ofArray(v726.clone());
                                    let patternInput_5: (LrcPtr<StringBuilder>, i32, i32) =
                                        Runtime::method29(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                                        (Runtime::method28())(b0)(b1)
                                                    },
                                                ),
                                                v733,
                                                LrcPtr::new(Runtime::UH0::UH0_0),
                                            ),
                                            v673,
                                            v674,
                                            v675,
                                        );
                                    Runtime::US7::US7_0(
                                        v682,
                                        v716,
                                        patternInput_5.0.clone(),
                                        patternInput_5.1.clone(),
                                        patternInput_5.2.clone(),
                                    )
                                }
                            };
                            match &v771 {
                                Runtime::US7::US7_0(
                                    v771_0_0,
                                    v771_0_1,
                                    v771_0_2,
                                    v771_0_3,
                                    v771_0_4,
                                ) => {
                                    let patternInput_6: (
                                        string,
                                        string,
                                        LrcPtr<StringBuilder>,
                                        i32,
                                        i32,
                                    ) = Runtime::method38(
                                        ofChar(v771_0_0.clone()),
                                        v771_0_1.clone(),
                                        v771_0_2.clone(),
                                        v771_0_3.clone(),
                                        v771_0_4.clone(),
                                    );
                                    Runtime::US8::US8_0(
                                        patternInput_6.0.clone(),
                                        patternInput_6.1.clone(),
                                        patternInput_6.2.clone(),
                                        patternInput_6.3.clone(),
                                        patternInput_6.4.clone(),
                                    )
                                }
                                Runtime::US7::US7_1(v771_1_0) => {
                                    Runtime::US8::US8_1(v771_1_0.clone())
                                }
                            }
                        }
                        Runtime::US12::US12_1(v670_1_0) => Runtime::US8::US8_1(v670_1_0.clone()),
                    };
                    let v807: Runtime::US13 = match &v795 {
                        Runtime::US8::US8_0(v795_0_0, v795_0_1, v795_0_2, v795_0_3, v795_0_4) => {
                            Runtime::US13::US13_0(
                                Runtime::US5::US5_0(v795_0_0.clone()),
                                v795_0_1.clone(),
                                v795_0_2.clone(),
                                v795_0_3.clone(),
                                v795_0_4.clone(),
                            )
                        }
                        _ => Runtime::US13::US13_0(
                            Runtime::US5::US5_1,
                            v495.clone(),
                            v496.clone(),
                            v497,
                            v498,
                        ),
                    };
                    match &v807 {
                        Runtime::US13::US13_0(v807_0_0, v807_0_1, v807_0_2, v807_0_3, v807_0_4) => {
                            Runtime::US11::US11_0(
                                v493_0_0.clone(),
                                v807_0_0.clone(),
                                v807_0_1.clone(),
                                v807_0_2.clone(),
                                v807_0_3.clone(),
                                v807_0_4.clone(),
                            )
                        }
                        Runtime::US13::US13_1(v807_1_0) => Runtime::US11::US11_1(v807_1_0.clone()),
                    }
                }
                Runtime::US8::US8_1(v493_1_0) => Runtime::US11::US11_1(v493_1_0.clone()),
            };
            match &v821 {
                Runtime::US11::US11_0(
                    v821_0_0,
                    v821_0_1,
                    v821_0_2,
                    v821_0_3,
                    v821_0_4,
                    v821_0_5,
                ) => Runtime::US6::US6_0(v821_0_0.clone(), v821_0_1.clone()),
                Runtime::US11::US11_1(v821_1_0) => Runtime::US6::US6_1(v821_1_0.clone()),
            }
        }
    }
    pub fn method39() -> string {
        let v7: string = Runtime::method13(getCharAt(toLower(string("Debug")), 0_i32));
        let v96: &str = inline_colorization::color_bright_blue;
        let v107: &str = &*v7;
        let v131: &str = inline_colorization::color_reset;
        let v133: std::string::String = format!("{}{}{}", v96, v107, v131);
        fable_library_rust::String_::fromString(v133)
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
        let v199: std::string::String = format!("{:#?}", v3);
        let v230: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v199),
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
        let v316: std::string::String = format!("{:#?}", v5);
        let v347: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v316),
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
        let v392: std::string::String = format!("{:#?}", v6);
        let v423: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v392),
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
        let v508: std::string::String = format!("{:#?}", v8);
        let v539: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v508),
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
        let v96: &str = inline_colorization::color_bright_black;
        let v107: &str = &*v7;
        let v131: &str = inline_colorization::color_reset;
        let v133: std::string::String = format!("{}{}{}", v96, v107, v131);
        fable_library_rust::String_::fromString(v133)
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
        let v47: std::string::String = format!("{:#?}", v0_1);
        let v78: () = {
            Runtime::closure7(
                v2_1.clone(),
                fable_library_rust::String_::fromString(v47),
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
        let v195: std::string::String = format!("{:#?}", v3);
        let v226: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v195),
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
        let v312: std::string::String = format!("{:#?}", v5);
        let v343: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v312),
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
        let v388: std::string::String = format!("{:#?}", v6);
        let v419: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v388),
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
        let v504: std::string::String = format!("{:#?}", v8);
        let v535: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v504),
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
                let v153: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v33: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method62(v33, 0_i64)) == false {
                        let v70: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v76: string = ofChar(v33);
                        let v79: i32 = length(v76.clone());
                        let v80: Array<char> = new_init(&'\u{0000}', v79);
                        let v81: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Runtime::method27(v79, v81.clone()) {
                            let v83: i32 = v81.l0.get().clone();
                            let v84: char = getCharAt(v76.clone(), v83);
                            v80.get_mut()[v83 as usize] = v84;
                            {
                                let v85: i32 = (v83) + 1_i32;
                                v81.l0.set(v85);
                                ()
                            }
                        }
                        {
                            let v87: List<char> = ofArray(v80.clone());
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                        (Runtime::method28())(b0)(b1)
                                    }),
                                    v87,
                                    LrcPtr::new(Runtime::UH0::UH0_0),
                                ),
                                v2_1.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Runtime::US7::US7_0(
                                v33,
                                v70,
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
                match &v153 {
                    Runtime::US7::US7_0(v153_0_0, v153_0_1, v153_0_2, v153_0_3, v153_0_4) => {
                        let v0_1_temp: string =
                            append((v0_1.get().clone()), (ofChar(v153_0_0.clone())));
                        let v1_1_temp: string = v153_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v153_0_2.clone();
                        let v3_temp: i32 = v153_0_3.clone();
                        let v4_temp: i32 = v153_0_4.clone();
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
        let v164: Runtime::US7 = if string("") == (v0_1.clone()) {
            Runtime::US7::US7_1(sprintf!(
                "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                '\\',
                (v1_1.clone(), v2_1, v3)
            ))
        } else {
            let v10: char = getCharAt(v0_1.clone(), 0_i32);
            if (v10) == '\\' {
                let v45: string = getSlice(
                    v0_1.clone(),
                    Some(1_i32),
                    Some((length(v0_1.clone())) - 1_i32),
                );
                let v51: string = ofChar(v10);
                let v54: i32 = length(v51.clone());
                let v55: Array<char> = new_init(&'\u{0000}', v54);
                let v56: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                    l0: MutCell::new(0_i32),
                });
                while Runtime::method27(v54, v56.clone()) {
                    let v58: i32 = v56.l0.get().clone();
                    let v59: char = getCharAt(v51.clone(), v58);
                    v55.get_mut()[v58 as usize] = v59;
                    {
                        let v60: i32 = (v58) + 1_i32;
                        v56.l0.set(v60);
                        ()
                    }
                }
                {
                    let v62: List<char> = ofArray(v55.clone());
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                        foldBack(
                            Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                (Runtime::method28())(b0)(b1)
                            }),
                            v62,
                            LrcPtr::new(Runtime::UH0::UH0_0),
                        ),
                        v1_1.clone(),
                        v2_1,
                        v3,
                    );
                    Runtime::US7::US7_0(
                        v10,
                        v45,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                }
            } else {
                let v105: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                (if -2_i32 == (v105) {
                                    (length(v0_1)) + 1_i32
                                } else {
                                    (v105) + 1_i32
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
        let v269: Runtime::US7 = match &v164 {
            Runtime::US7::US7_0(v164_0_0, v164_0_1, v164_0_2, v164_0_3, v164_0_4) => {
                let v169: i32 = v164_0_4.clone();
                let v168: i32 = v164_0_3.clone();
                let v167: LrcPtr<StringBuilder> = v164_0_2.clone();
                let v166: string = v164_0_1.clone();
                if string("") == (v166.clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.any_char / unexpected end of input / s: {:?}",
                        (v167.clone(), v168, v169)
                    ))
                } else {
                    let v176: char = getCharAt(v166.clone(), 0_i32);
                    let v210: string =
                        getSlice(v166.clone(), Some(1_i32), Some((length(v166)) - 1_i32));
                    let v216: string = ofChar(v176);
                    let v219: i32 = length(v216.clone());
                    let v220: Array<char> = new_init(&'\u{0000}', v219);
                    let v221: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Runtime::method27(v219, v221.clone()) {
                        let v223: i32 = v221.l0.get().clone();
                        let v224: char = getCharAt(v216.clone(), v223);
                        v220.get_mut()[v223 as usize] = v224;
                        {
                            let v225: i32 = (v223) + 1_i32;
                            v221.l0.set(v225);
                            ()
                        }
                    }
                    {
                        let v227: List<char> = ofArray(v220.clone());
                        let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                    (Runtime::method28())(b0)(b1)
                                }),
                                v227,
                                LrcPtr::new(Runtime::UH0::UH0_0),
                            ),
                            v167,
                            v168,
                            v169,
                        );
                        Runtime::US7::US7_0(
                            v176,
                            v210,
                            patternInput_1.0.clone(),
                            patternInput_1.1.clone(),
                            patternInput_1.2.clone(),
                        )
                    }
                }
            }
            Runtime::US7::US7_1(v164_1_0) => Runtime::US7::US7_1(v164_1_0.clone()),
        };
        match &v269 {
            Runtime::US7::US7_0(v269_0_0, v269_0_1, v269_0_2, v269_0_3, v269_0_4) => {
                Runtime::US8::US8_0(
                    append((ofChar('\\')), (ofChar(v269_0_0.clone()))),
                    v269_0_1.clone(),
                    v269_0_2.clone(),
                    v269_0_3.clone(),
                    v269_0_4.clone(),
                )
            }
            Runtime::US7::US7_1(v269_1_0) => Runtime::US8::US8_1(v269_1_0.clone()),
        }
    }
    pub fn closure31(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US8 {
        let v3: i32 = _arg.3.clone();
        let v2_1: i32 = _arg.2.clone();
        let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
        let v0_1: string = _arg.0.clone();
        let v164: Runtime::US7 = if string("") == (v0_1.clone()) {
            Runtime::US7::US7_1(sprintf!(
                "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                '`',
                (v1_1.clone(), v2_1, v3)
            ))
        } else {
            let v10: char = getCharAt(v0_1.clone(), 0_i32);
            if (v10) == '`' {
                let v45: string = getSlice(
                    v0_1.clone(),
                    Some(1_i32),
                    Some((length(v0_1.clone())) - 1_i32),
                );
                let v51: string = ofChar(v10);
                let v54: i32 = length(v51.clone());
                let v55: Array<char> = new_init(&'\u{0000}', v54);
                let v56: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                    l0: MutCell::new(0_i32),
                });
                while Runtime::method27(v54, v56.clone()) {
                    let v58: i32 = v56.l0.get().clone();
                    let v59: char = getCharAt(v51.clone(), v58);
                    v55.get_mut()[v58 as usize] = v59;
                    {
                        let v60: i32 = (v58) + 1_i32;
                        v56.l0.set(v60);
                        ()
                    }
                }
                {
                    let v62: List<char> = ofArray(v55.clone());
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                        foldBack(
                            Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                (Runtime::method28())(b0)(b1)
                            }),
                            v62,
                            LrcPtr::new(Runtime::UH0::UH0_0),
                        ),
                        v1_1.clone(),
                        v2_1,
                        v3,
                    );
                    Runtime::US7::US7_0(
                        v10,
                        v45,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                }
            } else {
                let v105: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                (if -2_i32 == (v105) {
                                    (length(v0_1)) + 1_i32
                                } else {
                                    (v105) + 1_i32
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
        let v269: Runtime::US7 = match &v164 {
            Runtime::US7::US7_0(v164_0_0, v164_0_1, v164_0_2, v164_0_3, v164_0_4) => {
                let v169: i32 = v164_0_4.clone();
                let v168: i32 = v164_0_3.clone();
                let v167: LrcPtr<StringBuilder> = v164_0_2.clone();
                let v166: string = v164_0_1.clone();
                if string("") == (v166.clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.any_char / unexpected end of input / s: {:?}",
                        (v167.clone(), v168, v169)
                    ))
                } else {
                    let v176: char = getCharAt(v166.clone(), 0_i32);
                    let v210: string =
                        getSlice(v166.clone(), Some(1_i32), Some((length(v166)) - 1_i32));
                    let v216: string = ofChar(v176);
                    let v219: i32 = length(v216.clone());
                    let v220: Array<char> = new_init(&'\u{0000}', v219);
                    let v221: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Runtime::method27(v219, v221.clone()) {
                        let v223: i32 = v221.l0.get().clone();
                        let v224: char = getCharAt(v216.clone(), v223);
                        v220.get_mut()[v223 as usize] = v224;
                        {
                            let v225: i32 = (v223) + 1_i32;
                            v221.l0.set(v225);
                            ()
                        }
                    }
                    {
                        let v227: List<char> = ofArray(v220.clone());
                        let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                    (Runtime::method28())(b0)(b1)
                                }),
                                v227,
                                LrcPtr::new(Runtime::UH0::UH0_0),
                            ),
                            v167,
                            v168,
                            v169,
                        );
                        Runtime::US7::US7_0(
                            v176,
                            v210,
                            patternInput_1.0.clone(),
                            patternInput_1.1.clone(),
                            patternInput_1.2.clone(),
                        )
                    }
                }
            }
            Runtime::US7::US7_1(v164_1_0) => Runtime::US7::US7_1(v164_1_0.clone()),
        };
        match &v269 {
            Runtime::US7::US7_0(v269_0_0, v269_0_1, v269_0_2, v269_0_3, v269_0_4) => {
                Runtime::US8::US8_0(
                    append((ofChar('`')), (ofChar(v269_0_0.clone()))),
                    v269_0_1.clone(),
                    v269_0_2.clone(),
                    v269_0_3.clone(),
                    v269_0_4.clone(),
                )
            }
            Runtime::US7::US7_1(v269_1_0) => Runtime::US8::US8_1(v269_1_0.clone()),
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
                let v145: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\\', '`', '\"']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method65(v29, 0_i64)) == false {
                        let v66: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v72: string = ofChar(v29);
                        let v75: i32 = length(v72.clone());
                        let v76: Array<char> = new_init(&'\u{0000}', v75);
                        let v77: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Runtime::method27(v75, v77.clone()) {
                            let v79: i32 = v77.l0.get().clone();
                            let v80: char = getCharAt(v72.clone(), v79);
                            v76.get_mut()[v79 as usize] = v80;
                            {
                                let v81: i32 = (v79) + 1_i32;
                                v77.l0.set(v81);
                                ()
                            }
                        }
                        {
                            let v83: List<char> = ofArray(v76.clone());
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                        (Runtime::method28())(b0)(b1)
                                    }),
                                    v83,
                                    LrcPtr::new(Runtime::UH0::UH0_0),
                                ),
                                v2_1.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Runtime::US7::US7_0(
                                v29,
                                v66,
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
                let v160: Runtime::US8 = match &v145 {
                    Runtime::US7::US7_0(v145_0_0, v145_0_1, v145_0_2, v145_0_3, v145_0_4) => {
                        Runtime::US8::US8_0(
                            ofChar(v145_0_0.clone()),
                            v145_0_1.clone(),
                            v145_0_2.clone(),
                            v145_0_3.clone(),
                            v145_0_4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v145_1_0) => Runtime::US8::US8_1(v145_1_0.clone()),
                };
                let v174: Runtime::US8 = match &v160 {
                    Runtime::US8::US8_0(v160_0_0, v160_0_1, v160_0_2, v160_0_3, v160_0_4) => {
                        v160.clone()
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
                match &v174 {
                    Runtime::US8::US8_0(v174_0_0, v174_0_1, v174_0_2, v174_0_3, v174_0_4) => {
                        let v0_1_temp: LrcPtr<Runtime::UH2> =
                            LrcPtr::new(Runtime::UH2::UH2_1(v174_0_0.clone(), v0_1.get().clone()));
                        let v1_1_temp: string = v174_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v174_0_2.clone();
                        let v3_temp: i32 = v174_0_3.clone();
                        let v4_temp: i32 = v174_0_4.clone();
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
                let v145: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\\', '`', '\"']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method65(v29, 0_i64)) == false {
                        let v66: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v72: string = ofChar(v29);
                        let v75: i32 = length(v72.clone());
                        let v76: Array<char> = new_init(&'\u{0000}', v75);
                        let v77: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Runtime::method27(v75, v77.clone()) {
                            let v79: i32 = v77.l0.get().clone();
                            let v80: char = getCharAt(v72.clone(), v79);
                            v76.get_mut()[v79 as usize] = v80;
                            {
                                let v81: i32 = (v79) + 1_i32;
                                v77.l0.set(v81);
                                ()
                            }
                        }
                        {
                            let v83: List<char> = ofArray(v76.clone());
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                        (Runtime::method28())(b0)(b1)
                                    }),
                                    v83,
                                    LrcPtr::new(Runtime::UH0::UH0_0),
                                ),
                                v2_1.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Runtime::US7::US7_0(
                                v29,
                                v66,
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
                let v160: Runtime::US8 = match &v145 {
                    Runtime::US7::US7_0(v145_0_0, v145_0_1, v145_0_2, v145_0_3, v145_0_4) => {
                        Runtime::US8::US8_0(
                            ofChar(v145_0_0.clone()),
                            v145_0_1.clone(),
                            v145_0_2.clone(),
                            v145_0_3.clone(),
                            v145_0_4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v145_1_0) => Runtime::US8::US8_1(v145_1_0.clone()),
                };
                match &v160 {
                    Runtime::US8::US8_0(v160_0_0, v160_0_1, v160_0_2, v160_0_3, v160_0_4) => {
                        let v0_1_temp: LrcPtr<Runtime::UH2> =
                            LrcPtr::new(Runtime::UH2::UH2_1(v160_0_0.clone(), v0_1.get().clone()));
                        let v1_1_temp: string = v160_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v160_0_2.clone();
                        let v3_temp: i32 = v160_0_3.clone();
                        let v4_temp: i32 = v160_0_4.clone();
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
                let v153: Runtime::US7 = if v5 {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v33: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method62(v33, 0_i64)) == false {
                        let v70: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v76: string = ofChar(v33);
                        let v79: i32 = length(v76.clone());
                        let v80: Array<char> = new_init(&'\u{0000}', v79);
                        let v81: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Runtime::method27(v79, v81.clone()) {
                            let v83: i32 = v81.l0.get().clone();
                            let v84: char = getCharAt(v76.clone(), v83);
                            v80.get_mut()[v83 as usize] = v84;
                            {
                                let v85: i32 = (v83) + 1_i32;
                                v81.l0.set(v85);
                                ()
                            }
                        }
                        {
                            let v87: List<char> = ofArray(v80.clone());
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method29(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                        (Runtime::method28())(b0)(b1)
                                    }),
                                    v87,
                                    LrcPtr::new(Runtime::UH0::UH0_0),
                                ),
                                v2_1.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Runtime::US7::US7_0(
                                v33,
                                v70,
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
                let v173: Runtime::US8 = match &v153 {
                    Runtime::US7::US7_0(v153_0_0, v153_0_1, v153_0_2, v153_0_3, v153_0_4) => {
                        let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                            Runtime::method63(
                                ofChar(v153_0_0.clone()),
                                v153_0_1.clone(),
                                v153_0_2.clone(),
                                v153_0_3.clone(),
                                v153_0_4.clone(),
                            );
                        Runtime::US8::US8_0(
                            patternInput_1.0.clone(),
                            patternInput_1.1.clone(),
                            patternInput_1.2.clone(),
                            patternInput_1.3.clone(),
                            patternInput_1.4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v153_1_0) => Runtime::US8::US8_1(v153_1_0.clone()),
                };
                let v635: Runtime::US8 = match &v173 {
                    Runtime::US8::US8_0(v173_0_0, v173_0_1, v173_0_2, v173_0_3, v173_0_4) => {
                        v173.clone()
                    }
                    _ => {
                        let v339: Runtime::US7 = if v5 {
                            Runtime::US7::US7_1(sprintf!(
                                "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                '\"',
                                (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        } else {
                            let v185: char = getCharAt(v1_1.get().clone(), 0_i32);
                            if (v185) == '\"' {
                                let v220: string = getSlice(
                                    v1_1.get().clone(),
                                    Some(1_i32),
                                    Some((length(v1_1.get().clone())) - 1_i32),
                                );
                                let v226: string = ofChar(v185);
                                let v229: i32 = length(v226.clone());
                                let v230: Array<char> = new_init(&'\u{0000}', v229);
                                let v231: LrcPtr<Runtime::Mut5> = LrcPtr::new(Runtime::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Runtime::method27(v229, v231.clone()) {
                                    let v233: i32 = v231.l0.get().clone();
                                    let v234: char = getCharAt(v226.clone(), v233);
                                    v230.get_mut()[v233 as usize] = v234;
                                    {
                                        let v235: i32 = (v233) + 1_i32;
                                        v231.l0.set(v235);
                                        ()
                                    }
                                }
                                {
                                    let v237: List<char> = ofArray(v230.clone());
                                    let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                        Runtime::method29(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Runtime::UH0>| {
                                                        (Runtime::method28())(b0)(b1)
                                                    },
                                                ),
                                                v237,
                                                LrcPtr::new(Runtime::UH0::UH0_0),
                                            ),
                                            v2_1.get().clone(),
                                            v3.get().clone(),
                                            v4.get().clone(),
                                        );
                                    Runtime::US7::US7_0(
                                        v185,
                                        v220,
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone(),
                                        patternInput_2.2.clone(),
                                    )
                                }
                            } else {
                                let v280: i32 = (indexOf(v1_1.get().clone(), string("\n"))) - 1_i32;
                                Runtime::US7::US7_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                                 '\"',
                                                                                                 v3.get().clone(),
                                                                                                 v4.get().clone(),
                                                                                                 v2_1.get().clone(),
                                                                                                 getSlice(v1_1.get().clone(),
                                                                                                          Some(0_i32),
                                                                                                          Some((if -2_i32
                                                                                                                       ==
                                                                                                                       (v280)
                                                                                                                   {
                                                                                                                    (length(v1_1.get().clone()))
                                                                                                                        +
                                                                                                                        1_i32
                                                                                                                } else {
                                                                                                                    (v280)
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
                        let v566: Runtime::US8 = match &v339 {
                            Runtime::US7::US7_0(
                                v339_0_0,
                                v339_0_1,
                                v339_0_2,
                                v339_0_3,
                                v339_0_4,
                            ) => {
                                let v344: i32 = v339_0_4.clone();
                                let v343: i32 = v339_0_3.clone();
                                let v342: LrcPtr<StringBuilder> = v339_0_2.clone();
                                let v341: string = v339_0_1.clone();
                                let v346: Runtime::US17 = Runtime::method64(
                                    LrcPtr::new(Runtime::UH2::UH2_0),
                                    v341.clone(),
                                    v342.clone(),
                                    v343,
                                    v344,
                                );
                                let v377: Runtime::US8 = match &v346 {
                                    Runtime::US17::US17_0(
                                        v346_0_0,
                                        v346_0_1,
                                        v346_0_2,
                                        v346_0_3,
                                        v346_0_4,
                                    ) => {
                                        let v353: List<string> =
                                            Runtime::method68(v346_0_0.clone(), empty::<string>());
                                        Runtime::US8::US8_0(
                                            join(
                                                string(""),
                                                toArray_1(delay(Func0::new({
                                                    let v353 = v353.clone();
                                                    move || ofList(v353.clone()).clone()
                                                }))),
                                            ),
                                            v346_0_1.clone(),
                                            v346_0_2.clone(),
                                            v346_0_3.clone(),
                                            v346_0_4.clone(),
                                        )
                                    }
                                    Runtime::US17::US17_1(v346_1_0) => {
                                        Runtime::US8::US8_1(v346_1_0.clone())
                                    }
                                };
                                match &v377 {
                                    Runtime::US8::US8_0(
                                        v377_0_0,
                                        v377_0_1,
                                        v377_0_2,
                                        v377_0_3,
                                        v377_0_4,
                                    ) => {
                                        let v382: i32 = v377_0_4.clone();
                                        let v381: i32 = v377_0_3.clone();
                                        let v380: LrcPtr<StringBuilder> = v377_0_2.clone();
                                        let v379: string = v377_0_1.clone();
                                        let v543: Runtime::US7 = if string("") == (v379.clone()) {
                                            Runtime::US7::US7_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                                                                              '\"',
                                                                                              (v380.clone(),
                                                                                               v381,
                                                                                               v382)))
                                        } else {
                                            let v389: char = getCharAt(v379.clone(), 0_i32);
                                            if (v389) == '\"' {
                                                let v424: string = getSlice(
                                                    v379.clone(),
                                                    Some(1_i32),
                                                    Some((length(v379.clone())) - 1_i32),
                                                );
                                                let v430: string = ofChar(v389);
                                                let v433: i32 = length(v430.clone());
                                                let v434: Array<char> = new_init(&'\u{0000}', v433);
                                                let v435: LrcPtr<Runtime::Mut5> =
                                                    LrcPtr::new(Runtime::Mut5 {
                                                        l0: MutCell::new(0_i32),
                                                    });
                                                while Runtime::method27(v433, v435.clone()) {
                                                    let v437: i32 = v435.l0.get().clone();
                                                    let v438: char = getCharAt(v430.clone(), v437);
                                                    v434.get_mut()[v437 as usize] = v438;
                                                    {
                                                        let v439: i32 = (v437) + 1_i32;
                                                        v435.l0.set(v439);
                                                        ()
                                                    }
                                                }
                                                {
                                                    let v441: List<char> = ofArray(v434.clone());
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
                                                                                                        v441,
                                                                                                        LrcPtr::new(Runtime::UH0::UH0_0)),
                                                                                               v380.clone(),
                                                                                               v381,
                                                                                               v382);
                                                    Runtime::US7::US7_0(
                                                        v389,
                                                        v424,
                                                        patternInput_3.0.clone(),
                                                        patternInput_3.1.clone(),
                                                        patternInput_3.2.clone(),
                                                    )
                                                }
                                            } else {
                                                let v484: i32 =
                                                    (indexOf(v379.clone(), string("\n"))) - 1_i32;
                                                Runtime::US7::US7_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                                                     '\"',
                                                                                                                     v381,
                                                                                                                     v382,
                                                                                                                     v380.clone(),
                                                                                                                     getSlice(v379.clone(),
                                                                                                                              Some(0_i32),
                                                                                                                              Some((if -2_i32
                                                                                                                                           ==
                                                                                                                                           (v484)
                                                                                                                                       {
                                                                                                                                        (length(v379.clone()))
                                                                                                                                            +
                                                                                                                                            1_i32
                                                                                                                                    } else {
                                                                                                                                        (v484)
                                                                                                                                            +
                                                                                                                                            1_i32
                                                                                                                                    })
                                                                                                                                       -
                                                                                                                                       1_i32))),
                                                                                                            string("\n"),
                                                                                                            append(((Runtime::method30((v382)
                                                                                                                                           -
                                                                                                                                           1_i32,
                                                                                                                                       0_i32))(string(""))),
                                                                                                                   string("^")),
                                                                                                            string("\n")])))
                                            }
                                        };
                                        match &v543 {
                                                             Runtime::US7::US7_0(v543_0_0,
                                                                                 v543_0_1,
                                                                                 v543_0_2,
                                                                                 v543_0_3,
                                                                                 v543_0_4)
                                                             =>
                                                             Runtime::US8::US8_0(v377_0_0.clone(),
                                                                                 v543_0_1.clone(),
                                                                                 v543_0_2.clone(),
                                                                                 v543_0_3.clone(),
                                                                                 v543_0_4.clone()),
                                                             Runtime::US7::US7_1(v543_1_0)
                                                             =>
                                                             Runtime::US8::US8_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                                          v543_1_0.clone(),
                                                                                          (v1_1.get().clone(),
                                                                                           v2_1.get().clone(),
                                                                                           v3.get().clone(),
                                                                                           v4.get().clone()),
                                                                                          (v341.clone(),
                                                                                           v342.clone(),
                                                                                           v343,
                                                                                           v344),
                                                                                          (v379.clone(),
                                                                                           v380.clone(),
                                                                                           v381,
                                                                                           v382))),
                                                         }
                                    }
                                    _ => Runtime::US8::US8_1(string(
                                        "parsing.between / expected content",
                                    )),
                                }
                            }
                            Runtime::US7::US7_1(v339_1_0) => Runtime::US8::US8_1(v339_1_0.clone()),
                        };
                        match &v566 {
                            Runtime::US8::US8_0(
                                v566_0_0,
                                v566_0_1,
                                v566_0_2,
                                v566_0_3,
                                v566_0_4,
                            ) => v566.clone(),
                            _ => {
                                let v578: Runtime::US8 = Runtime::method66(
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
                                let v589: Runtime::US8 = match &v578 {
                                    Runtime::US8::US8_0(
                                        v578_0_0,
                                        v578_0_1,
                                        v578_0_2,
                                        v578_0_3,
                                        v578_0_4,
                                    ) => Runtime::US8::US8_0(
                                        string(""),
                                        v578_0_1.clone(),
                                        v578_0_2.clone(),
                                        v578_0_3.clone(),
                                        v578_0_4.clone(),
                                    ),
                                    Runtime::US8::US8_1(v578_1_0) => {
                                        Runtime::US8::US8_1(v578_1_0.clone())
                                    }
                                };
                                let v600: Runtime::US17 = match &v589 {
                                    Runtime::US8::US8_0(
                                        v589_0_0,
                                        v589_0_1,
                                        v589_0_2,
                                        v589_0_3,
                                        v589_0_4,
                                    ) => Runtime::method69(
                                        LrcPtr::new(Runtime::UH2::UH2_0),
                                        v589_0_1.clone(),
                                        v589_0_2.clone(),
                                        v589_0_3.clone(),
                                        v589_0_4.clone(),
                                    ),
                                    Runtime::US8::US8_1(v589_1_0) => {
                                        Runtime::US17::US17_1(v589_1_0.clone())
                                    }
                                };
                                match &v600 {
                                    Runtime::US17::US17_0(
                                        v600_0_0,
                                        v600_0_1,
                                        v600_0_2,
                                        v600_0_3,
                                        v600_0_4,
                                    ) => {
                                        let v607: List<string> =
                                            Runtime::method68(v600_0_0.clone(), empty::<string>());
                                        Runtime::US8::US8_0(
                                            join(
                                                string(""),
                                                toArray_1(delay(Func0::new({
                                                    let v607 = v607.clone();
                                                    move || ofList(v607.clone()).clone()
                                                }))),
                                            ),
                                            v600_0_1.clone(),
                                            v600_0_2.clone(),
                                            v600_0_3.clone(),
                                            v600_0_4.clone(),
                                        )
                                    }
                                    Runtime::US17::US17_1(v600_1_0) => {
                                        Runtime::US8::US8_1(v600_1_0.clone())
                                    }
                                }
                            }
                        }
                    }
                };
                match &v635 {
                    Runtime::US8::US8_0(v635_0_0, v635_0_1, v635_0_2, v635_0_3, v635_0_4) => {
                        let v640: i32 = v635_0_4.clone();
                        let v639: i32 = v635_0_3.clone();
                        let v638: LrcPtr<StringBuilder> = v635_0_2.clone();
                        let v637: string = v635_0_1.clone();
                        let v636: string = v635_0_0.clone();
                        let v642: i32 = Runtime::method37(v637.clone(), 0_i32);
                        let v684: Runtime::US10 = if 0_i32 == (v642) {
                            Runtime::US10::US10_1(string(
                                "parsing.spaces1 / expected at least one space",
                            ))
                        } else {
                            Runtime::US10::US10_0(
                                getSlice(
                                    v637.clone(),
                                    Some(v642),
                                    Some((length(v637.clone())) - 1_i32),
                                ),
                                v638.clone(),
                                v639,
                                v640,
                            )
                        };
                        match &v684 {
                            Runtime::US10::US10_0(v684_0_0, v684_0_1, v684_0_2, v684_0_3) => {
                                let v0_1_temp: LrcPtr<Runtime::UH2> = LrcPtr::new(
                                    Runtime::UH2::UH2_1(v636.clone(), v0_1.get().clone()),
                                );
                                let v1_1_temp: string = v684_0_0.clone();
                                let v2_1_temp: LrcPtr<StringBuilder> = v684_0_1.clone();
                                let v3_temp: i32 = v684_0_2.clone();
                                let v4_temp: i32 = v684_0_3.clone();
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
                                        v636.clone(),
                                        LrcPtr::new(Runtime::UH2::UH2_0),
                                    )),
                                ),
                                v637.clone(),
                                v638.clone(),
                                v639,
                                v640,
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
