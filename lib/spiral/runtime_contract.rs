pub mod Runtime {
    use super::*;
    type Async<T> = T;
    type DateTime = ();
    use fable_library_rust::List_::cons;
    use fable_library_rust::List_::empty;
    use fable_library_rust::List_::ofArray;
    use fable_library_rust::List_::toArray;
    use fable_library_rust::List_::List;
    use fable_library_rust::Map_::find;
    use fable_library_rust::Map_::ofSeq;
    use fable_library_rust::NativeArray_::new_array;
    use fable_library_rust::NativeArray_::new_empty;
    use fable_library_rust::NativeArray_::Array;
    use fable_library_rust::Native_::getNull;
    use fable_library_rust::Native_::on_startup;
    use fable_library_rust::Native_::unbox;
    use fable_library_rust::Native_::Any;
    use fable_library_rust::Native_::Arc;
    use fable_library_rust::Native_::Func0;
    use fable_library_rust::Native_::Func1;
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
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub struct Mut5 {
        pub l0: MutCell<i32>,
    }
    impl core::fmt::Display for Mut5 {
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
        let v6: string = toLower(string("Critical"));
        let v13: string = toLower(string("Warning"));
        let v20_1: string = toLower(string("Info"));
        let v27: string = toLower(string("Debug"));
        let v34: string = toLower(string("Verbose"));
        let v41: Runtime::US1 = if string("Verbose") == (v1_1.clone()) {
            Runtime::US1::US1_0(Runtime::US0::US0_0)
        } else {
            Runtime::US1::US1_1
        };
        (
            match &v41 {
                Runtime::US1::US1_0(v41_0_0) => Runtime::US1::US1_0(
                    match &v41 {
                        Runtime::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                ),
                _ => {
                    let v48: Runtime::US1 = if string("Debug") == (v1_1.clone()) {
                        Runtime::US1::US1_0(Runtime::US0::US0_1)
                    } else {
                        Runtime::US1::US1_1
                    };
                    match &v48 {
                        Runtime::US1::US1_0(v48_0_0) => Runtime::US1::US1_0(
                            match &v48 {
                                Runtime::US1::US1_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v55: Runtime::US1 = if string("Info") == (v1_1.clone()) {
                                Runtime::US1::US1_0(Runtime::US0::US0_2)
                            } else {
                                Runtime::US1::US1_1
                            };
                            match &v55 {
                                Runtime::US1::US1_0(v55_0_0) => Runtime::US1::US1_0(
                                    match &v55 {
                                        Runtime::US1::US1_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v62: Runtime::US1 = if string("Warning") == (v1_1.clone()) {
                                        Runtime::US1::US1_0(Runtime::US0::US0_3)
                                    } else {
                                        Runtime::US1::US1_1
                                    };
                                    match &v62 {
                                        Runtime::US1::US1_0(v62_0_0) => Runtime::US1::US1_0(
                                            match &v62 {
                                                Runtime::US1::US1_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        ),
                                        _ => {
                                            let v69: Runtime::US1 =
                                                if string("Critical") == (v1_1.clone()) {
                                                    Runtime::US1::US1_0(Runtime::US0::US0_4)
                                                } else {
                                                    Runtime::US1::US1_1
                                                };
                                            match &v69 {
                                                Runtime::US1::US1_0(v69_0_0) => {
                                                    Runtime::US1::US1_0(
                                                        match &v69 {
                                                            Runtime::US1::US1_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => {
                                                    let v76: Runtime::US1 =
                                                        if (v34.clone()) == (v1_1.clone()) {
                                                            Runtime::US1::US1_0(Runtime::US0::US0_0)
                                                        } else {
                                                            Runtime::US1::US1_1
                                                        };
                                                    match &v76 {
                                                        Runtime::US1::US1_0(v76_0_0) => {
                                                            Runtime::US1::US1_0(
                                                                match &v76 {
                                                                    Runtime::US1::US1_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            let v83: Runtime::US1 = if (v27.clone())
                                                                == (v1_1.clone())
                                                            {
                                                                Runtime::US1::US1_0(
                                                                    Runtime::US0::US0_1,
                                                                )
                                                            } else {
                                                                Runtime::US1::US1_1
                                                            };
                                                            match &v83 {
                                                                Runtime::US1::US1_0(v83_0_0) => {
                                                                    Runtime::US1::US1_0(
                                                                        match &v83 {
                                                                            Runtime::US1::US1_0(
                                                                                x,
                                                                            ) => x.clone(),
                                                                            _ => unreachable!(),
                                                                        }
                                                                        .clone(),
                                                                    )
                                                                }
                                                                _ => {
                                                                    let v90: Runtime::US1 =
                                                                        if (v20_1.clone())
                                                                            == (v1_1.clone())
                                                                        {
                                                                            Runtime::US1::US1_0(
                                                                                Runtime::US0::US0_2,
                                                                            )
                                                                        } else {
                                                                            Runtime::US1::US1_1
                                                                        };
                                                                    match &v90 {
                                                                     Runtime::US1::US1_0(v90_0_0)
                                                                     =>
                                                                     Runtime::US1::US1_0(match &v90
                                                                                             {
                                                                                             Runtime::US1::US1_0(x)
                                                                                             =>
                                                                                             x.clone(),
                                                                                             _
                                                                                             =>
                                                                                             unreachable!(),
                                                                                         }.clone()),
                                                                     _ => {
                                                                         let v97:
                                                                                 Runtime::US1 =
                                                                             if (v13.clone())
                                                                                    ==
                                                                                    (v1_1.clone())
                                                                                {
                                                                                 Runtime::US1::US1_0(Runtime::US0::US0_3)
                                                                             } else {
                                                                                 Runtime::US1::US1_1
                                                                             };
                                                                         match &v97
                                                                             {
                                                                             Runtime::US1::US1_0(v97_0_0)
                                                                             =>
                                                                             Runtime::US1::US1_0(match &v97
                                                                                                     {
                                                                                                     Runtime::US1::US1_0(x)
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
                                                                                         Runtime::US1 =
                                                                                     if (v6.clone())
                                                                                            ==
                                                                                            (v1_1.clone())
                                                                                        {
                                                                                         Runtime::US1::US1_0(Runtime::US0::US0_4)
                                                                                     } else {
                                                                                         Runtime::US1::US1_1
                                                                                     };
                                                                                 match &v104
                                                                                     {
                                                                                     Runtime::US1::US1_0(v104_0_0)
                                                                                     =>
                                                                                     Runtime::US1::US1_0(match &v104
                                                                                                             {
                                                                                                             Runtime::US1::US1_0(x)
                                                                                                             =>
                                                                                                             x.clone(),
                                                                                                             _
                                                                                                             =>
                                                                                                             unreachable!(),
                                                                                                         }.clone()),
                                                                                     _
                                                                                     =>
                                                                                     Runtime::US1::US1_1,
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
            if (Runtime::method2(string("AUTOMATION"))) != string("True") {
                Runtime::US2::US2_1
            } else {
                let v143: DateTime = unbox::<DateTime>(fable_library_rust::Native_::getZero());
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
        let v509: u64 = near_sdk::env::block_timestamp();
        let v534: Runtime::US2 = defaultValue(Runtime::US2::US2_1, map(Runtime::method9(), v5));
        let v547: u64 = (match &v534 {
            Runtime::US2::US2_0(v534_0_0) => {
                (v509)
                    - (match &v534 {
                        Runtime::US2::US2_0(x) => x.clone(),
                        _ => unreachable!(),
                    } as u64)
            }
            _ => v509,
        }) / 1000000000_u64;
        let v548: u64 = (v547) % 60_u64;
        let v550: u64 = ((v547) / 60_u64) % 60_u64;
        let v552: u64 = ((v547) / 3600_u64) % 24_u64;
        let v554: std::string::String = format!("{:02}:{:02}:{:02}", v552, v550, v548);
        fable_library_rust::String_::fromString(v554)
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
        let v8: string = Runtime::method13(getCharAt(toLower(string("Warning")), 0_i32));
        let v97: &str = inline_colorization::color_yellow;
        let v108: &str = &*v8;
        let v132: &str = inline_colorization::color_reset;
        let v134: std::string::String = format!("{}{}{}", v97, v108, v132);
        fable_library_rust::String_::fromString(v134)
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
    pub fn method27(v0_1: i64, v1_1: string, v2_1: i64) -> LrcPtr<Runtime::UH0> {
        if (v2_1) < (v0_1) {
            LrcPtr::new(Runtime::UH0::UH0_1(
                getCharAt(v1_1.clone(), v2_1 as i32),
                Runtime::method27(v0_1, v1_1, (v2_1) + 1_i64),
            ))
        } else {
            LrcPtr::new(Runtime::UH0::UH0_0)
        }
    }
    pub fn method28(
        v0_1: LrcPtr<Runtime::UH0>,
        v1_1: LrcPtr<StringBuilder>,
        v2_1: i32,
        v3: i32,
    ) -> (LrcPtr<StringBuilder>, i32, i32) {
        let v0_1: MutCell<LrcPtr<Runtime::UH0>> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
        let v2_1: MutCell<i32> = MutCell::new(v2_1);
        let v3: MutCell<i32> = MutCell::new(v3);
        '_method28: loop {
            break '_method28 (match v0_1.get().clone().as_ref() {
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
                        continue '_method28;
                    }
                }
            });
        }
    }
    pub fn closure15(v0_1: i32, v1_1: i32, v2_1: string) -> string {
        if (v1_1) >= (v0_1) {
            v2_1.clone()
        } else {
            (Runtime::method29(v0_1, (v1_1) + 1_i32))(append((v2_1), string(" ")))
        }
    }
    pub fn method29(v0_1: i32, v1_1: i32) -> Func1<string, string> {
        Func1::new({
            let v0_1 = v0_1.clone();
            let v1_1 = v1_1.clone();
            move |v: string| Runtime::closure15(v0_1, v1_1, v)
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
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                    Runtime::method27(length(v51.clone()) as i64, v51, 0_i64),
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
            } else {
                let v66: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                (if -2_i32 == (v66) {
                                    (length(v0_1)) + 1_i32
                                } else {
                                    (v66) + 1_i32
                                }) - 1_i32
                            )
                        )
                    ),
                    string("\n"),
                    append(
                        ((Runtime::method29((v3) - 1_i32, 0_i32))(string(""))),
                        string("^"),
                    ),
                    string("\n"),
                ])))
            }
        }
    }
    pub fn closure16(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US7 {
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
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                    Runtime::method27(length(v51.clone()) as i64, v51, 0_i64),
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
            } else {
                let v66: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                (if -2_i32 == (v66) {
                                    (length(v0_1)) + 1_i32
                                } else {
                                    (v66) + 1_i32
                                }) - 1_i32
                            )
                        )
                    ),
                    string("\n"),
                    append(
                        ((Runtime::method29((v3) - 1_i32, 0_i32))(string(""))),
                        string("^"),
                    ),
                    string("\n"),
                ])))
            }
        }
    }
    pub fn method30(
        v0_1: string,
        v1_1: LrcPtr<StringBuilder>,
        v2_1: LrcPtr<Runtime::UH1>,
    ) -> Runtime::US7 {
        let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
        let v2_1: MutCell<LrcPtr<Runtime::UH1>> = MutCell::new(v2_1.clone());
        '_method30: loop {
            break '_method30 (match v2_1.get().clone().as_ref() {
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
                            continue '_method30;
                        }
                    }
                }
            });
        }
    }
    pub fn method31(v0_1: char, v1_1: i64) -> bool {
        let v0_1: MutCell<char> = MutCell::new(v0_1);
        let v1_1: MutCell<i64> = MutCell::new(v1_1);
        '_method31: loop {
            break '_method31 (if (v1_1.get().clone()) >= 2_i64 {
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
                    continue '_method31;
                }
            });
        }
    }
    pub fn method32(
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
        '_method32: loop {
            break '_method32 ({
                let v98: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\"', '\'']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v25: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method31(v25, 0_i64)) == false {
                        let v62: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v68: string = ofChar(v25);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                            Runtime::method27(length(v68.clone()) as i64, v68, 0_i64),
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
                    } else {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                            v25,
                            toArray(ofArray(new_array(&['\"', '\'']))),
                            (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    }
                };
                let v110: Runtime::US7 = match &v98 {
                    Runtime::US7::US7_0(v98_0_0, v98_0_1, v98_0_2, v98_0_3, v98_0_4) => {
                        let v99: char = v98_0_0.clone();
                        Runtime::US7::US7_0(
                            if '\\' == (v99) { '/' } else { v99 },
                            v98_0_1.clone(),
                            v98_0_2.clone(),
                            v98_0_3.clone(),
                            v98_0_4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v98_1_0) => Runtime::US7::US7_1(v98_1_0.clone()),
                };
                match &v110 {
                    Runtime::US7::US7_0(v110_0_0, v110_0_1, v110_0_2, v110_0_3, v110_0_4) => {
                        let v0_1_temp: string =
                            append((v0_1.get().clone()), (ofChar(v110_0_0.clone())));
                        let v1_1_temp: string = v110_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v110_0_2.clone();
                        let v3_temp: i32 = v110_0_3.clone();
                        let v4_temp: i32 = v110_0_4.clone();
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        v2_1.set(v2_1_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method32;
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
    pub fn method33(
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
        '_method33: loop {
            break '_method33 (match v4.get().clone().as_ref() {
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
                            continue '_method33;
                        }
                    }
                }
            });
        }
    }
    pub fn method34(v0_1: char, v1_1: i64) -> bool {
        let v0_1: MutCell<char> = MutCell::new(v0_1);
        let v1_1: MutCell<i64> = MutCell::new(v1_1);
        '_method34: loop {
            break '_method34 (if (v1_1.get().clone()) >= 3_i64 {
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
                    continue '_method34;
                }
            });
        }
    }
    pub fn method35(
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
        '_method35: loop {
            break '_method35 ({
                let v106: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                        toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                    if (Runtime::method34(v29, 0_i64)) == false {
                        let v66: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v72: string = ofChar(v29);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                            Runtime::method27(length(v72.clone()) as i64, v72, 0_i64),
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
                    } else {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                            v29,
                            toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                            (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    }
                };
                let v118: Runtime::US7 = match &v106 {
                    Runtime::US7::US7_0(v106_0_0, v106_0_1, v106_0_2, v106_0_3, v106_0_4) => {
                        let v107: char = v106_0_0.clone();
                        Runtime::US7::US7_0(
                            if '\\' == (v107) { '/' } else { v107 },
                            v106_0_1.clone(),
                            v106_0_2.clone(),
                            v106_0_3.clone(),
                            v106_0_4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v106_1_0) => Runtime::US7::US7_1(v106_1_0.clone()),
                };
                match &v118 {
                    Runtime::US7::US7_0(v118_0_0, v118_0_1, v118_0_2, v118_0_3, v118_0_4) => {
                        let v0_1_temp: string =
                            append((v0_1.get().clone()), (ofChar(v118_0_0.clone())));
                        let v1_1_temp: string = v118_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v118_0_2.clone();
                        let v3_temp: i32 = v118_0_3.clone();
                        let v4_temp: i32 = v118_0_4.clone();
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        v2_1.set(v2_1_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method35;
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
    pub fn method36(v0_1: string, v1_1: i32) -> i32 {
        let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
        let v1_1: MutCell<i32> = MutCell::new(v1_1);
        '_method36: loop {
            break '_method36 (if (v1_1.get().clone()) >= (length(v0_1.get().clone())) {
                v1_1.get().clone()
            } else {
                if ' ' == (getCharAt(v0_1.get().clone(), v1_1.get().clone())) {
                    let v0_1_temp: string = v0_1.get().clone();
                    let v1_1_temp: i32 = (v1_1.get().clone()) + 1_i32;
                    v0_1.set(v0_1_temp);
                    v1_1.set(v1_1_temp);
                    continue '_method36;
                } else {
                    v1_1.get().clone()
                }
            });
        }
    }
    pub fn method37(
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
        '_method37: loop {
            break '_method37 ({
                let v66: Runtime::US7 = if string("") == (v1_1.get().clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.any_char / unexpected end of input / s: {:?}",
                        (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                    ))
                } else {
                    let v16: char = getCharAt(v1_1.get().clone(), 0_i32);
                    let v50: string = getSlice(
                        v1_1.get().clone(),
                        Some(1_i32),
                        Some((length(v1_1.get().clone())) - 1_i32),
                    );
                    let v56: string = ofChar(v16);
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                        Runtime::method27(length(v56.clone()) as i64, v56, 0_i64),
                        v2_1.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    );
                    Runtime::US7::US7_0(
                        v16,
                        v50,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                };
                match &v66 {
                    Runtime::US7::US7_0(v66_0_0, v66_0_1, v66_0_2, v66_0_3, v66_0_4) => {
                        let v0_1_temp: string =
                            append((v0_1.get().clone()), (ofChar(v66_0_0.clone())));
                        let v1_1_temp: string = v66_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v66_0_2.clone();
                        let v3_temp: i32 = v66_0_3.clone();
                        let v4_temp: i32 = v66_0_4.clone();
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        v2_1.set(v2_1_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method37;
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
            let v10: string = defaultValue(
                string(""),
                match &_v0.get().clone() {
                    None => panic!("{}", string("optionm\'.of_obj / _v0=None"),),
                    Some(_v0_0_0) => _v0_0_0.clone(),
                },
            );
            let v16: LrcPtr<StringBuilder> = StringBuilder::_ctor__Z721C83C5(Runtime::method26());
            fn v19_1(arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US7 {
                Runtime::closure14((), arg10_0040)
            }
            fn v20_1(arg10_0040_1: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US7 {
                Runtime::closure16((), arg10_0040_1)
            }
            let v24: Runtime::US7 = Runtime::method30(
                v10.clone(),
                v16.clone(),
                LrcPtr::new(Runtime::UH1::UH1_1(
                    Func1::from(v19_1),
                    LrcPtr::new(Runtime::UH1::UH1_1(
                        Func1::from(v20_1),
                        LrcPtr::new(Runtime::UH1::UH1_0),
                    )),
                )),
            );
            let v197: Runtime::US8 = match &v24 {
                Runtime::US7::US7_0(v24_0_0, v24_0_1, v24_0_2, v24_0_3, v24_0_4) => {
                    let v29: i32 = v24_0_4.clone();
                    let v28: i32 = v24_0_3.clone();
                    let v27: LrcPtr<StringBuilder> = v24_0_2.clone();
                    let v26: string = v24_0_1.clone();
                    let v123: Runtime::US7 = if string("") == (v26.clone()) {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'']))),
                            (v27.clone(), v28, v29)
                        ))
                    } else {
                        let v50: char = getCharAt(v26.clone(), 0_i32);
                        if (Runtime::method31(v50, 0_i64)) == false {
                            let v87: string = getSlice(
                                v26.clone(),
                                Some(1_i32),
                                Some((length(v26.clone())) - 1_i32),
                            );
                            let v93: string = ofChar(v50);
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                                Runtime::method27(length(v93.clone()) as i64, v93, 0_i64),
                                v27.clone(),
                                v28,
                                v29,
                            );
                            Runtime::US7::US7_0(
                                v50,
                                v87,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        } else {
                            Runtime::US7::US7_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v50,
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                (v27.clone(), v28, v29)
                            ))
                        }
                    };
                    let v135: Runtime::US7 = match &v123 {
                        Runtime::US7::US7_0(v123_0_0, v123_0_1, v123_0_2, v123_0_3, v123_0_4) => {
                            let v124: char = v123_0_0.clone();
                            Runtime::US7::US7_0(
                                if '\\' == (v124) { '/' } else { v124 },
                                v123_0_1.clone(),
                                v123_0_2.clone(),
                                v123_0_3.clone(),
                                v123_0_4.clone(),
                            )
                        }
                        Runtime::US7::US7_1(v123_1_0) => Runtime::US7::US7_1(v123_1_0.clone()),
                    };
                    let v155: Runtime::US8 = match &v135 {
                        Runtime::US7::US7_0(v135_0_0, v135_0_1, v135_0_2, v135_0_3, v135_0_4) => {
                            let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method32(
                                    ofChar(v135_0_0.clone()),
                                    v135_0_1.clone(),
                                    v135_0_2.clone(),
                                    v135_0_3.clone(),
                                    v135_0_4.clone(),
                                );
                            Runtime::US8::US8_0(
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                                patternInput_1.3.clone(),
                                patternInput_1.4.clone(),
                            )
                        }
                        Runtime::US7::US7_1(v135_1_0) => Runtime::US8::US8_1(v135_1_0.clone()),
                    };
                    let v165: Runtime::US8 = match &v155 {
                        Runtime::US8::US8_0(v155_0_0, v155_0_1, v155_0_2, v155_0_3, v155_0_4) => {
                            Runtime::US8::US8_0(
                                v155_0_0.clone(),
                                v155_0_1.clone(),
                                v155_0_2.clone(),
                                v155_0_3.clone(),
                                v155_0_4.clone(),
                            )
                        }
                        _ => Runtime::US8::US8_0(string(""), v26.clone(), v27.clone(), v28, v29),
                    };
                    match &v165 {
                        Runtime::US8::US8_0(v165_0_0, v165_0_1, v165_0_2, v165_0_3, v165_0_4) => {
                            let v170: i32 = v165_0_4.clone();
                            let v169: i32 = v165_0_3.clone();
                            let v168: LrcPtr<StringBuilder> = v165_0_2.clone();
                            let v167: string = v165_0_1.clone();
                            let v174: Runtime::US7 = Runtime::method33(
                                v167.clone(),
                                v168.clone(),
                                v169,
                                v170,
                                LrcPtr::new(Runtime::UH1::UH1_1(
                                    Func1::from(v19_1),
                                    LrcPtr::new(Runtime::UH1::UH1_1(
                                        Func1::from(v20_1),
                                        LrcPtr::new(Runtime::UH1::UH1_0),
                                    )),
                                )),
                            );
                            match &v174 {
                                    Runtime::US7::US7_0(v174_0_0, v174_0_1,
                                                        v174_0_2, v174_0_3,
                                                        v174_0_4) =>
                                    Runtime::US8::US8_0(v165_0_0.clone(),
                                                        v174_0_1.clone(),
                                                        v174_0_2.clone(),
                                                        v174_0_3.clone(),
                                                        v174_0_4.clone()),
                                    Runtime::US7::US7_1(v174_1_0) =>
                                    Runtime::US8::US8_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                 v174_1_0.clone(),
                                                                 (v10.clone(),
                                                                  v16.clone(),
                                                                  1_i32,
                                                                  1_i32),
                                                                 (v26.clone(),
                                                                  v27.clone(),
                                                                  v28, v29),
                                                                 (v167.clone(),
                                                                  v168.clone(),
                                                                  v169,
                                                                  v170))),
                                }
                        }
                        _ => Runtime::US8::US8_1(string("parsing.between / expected content")),
                    }
                }
                Runtime::US7::US7_1(v24_1_0) => Runtime::US8::US8_1(v24_1_0.clone()),
            };
            let v416: Runtime::US8 = match &v197 {
                Runtime::US8::US8_0(v197_0_0, v197_0_1, v197_0_2, v197_0_3, v197_0_4) => {
                    v197.clone()
                }
                _ => {
                    let v307: Runtime::US7 = if string("") == (v10.clone()) {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                            (v16.clone(), 1_i32, 1_i32)
                        ))
                    } else {
                        let v228: char = getCharAt(v10.clone(), 0_i32);
                        if (Runtime::method34(v228, 0_i64)) == false {
                            let v265: string = getSlice(
                                v10.clone(),
                                Some(1_i32),
                                Some((length(v10.clone())) - 1_i32),
                            );
                            let v271: string = ofChar(v228);
                            let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method28(
                                    Runtime::method27(length(v271.clone()) as i64, v271, 0_i64),
                                    v16.clone(),
                                    1_i32,
                                    1_i32,
                                );
                            Runtime::US7::US7_0(
                                v228,
                                v265,
                                patternInput_2.0.clone(),
                                patternInput_2.1.clone(),
                                patternInput_2.2.clone(),
                            )
                        } else {
                            Runtime::US7::US7_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v228,
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                (v16.clone(), 1_i32, 1_i32)
                            ))
                        }
                    };
                    let v319: Runtime::US7 = match &v307 {
                        Runtime::US7::US7_0(v307_0_0, v307_0_1, v307_0_2, v307_0_3, v307_0_4) => {
                            let v308: char = v307_0_0.clone();
                            Runtime::US7::US7_0(
                                if '\\' == (v308) { '/' } else { v308 },
                                v307_0_1.clone(),
                                v307_0_2.clone(),
                                v307_0_3.clone(),
                                v307_0_4.clone(),
                            )
                        }
                        Runtime::US7::US7_1(v307_1_0) => Runtime::US7::US7_1(v307_1_0.clone()),
                    };
                    let v339: Runtime::US8 = match &v319 {
                        Runtime::US7::US7_0(v319_0_0, v319_0_1, v319_0_2, v319_0_3, v319_0_4) => {
                            let patternInput_3: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method35(
                                    ofChar(v319_0_0.clone()),
                                    v319_0_1.clone(),
                                    v319_0_2.clone(),
                                    v319_0_3.clone(),
                                    v319_0_4.clone(),
                                );
                            Runtime::US8::US8_0(
                                patternInput_3.0.clone(),
                                patternInput_3.1.clone(),
                                patternInput_3.2.clone(),
                                patternInput_3.3.clone(),
                                patternInput_3.4.clone(),
                            )
                        }
                        Runtime::US7::US7_1(v319_1_0) => Runtime::US8::US8_1(v319_1_0.clone()),
                    };
                    match &v339 {
                        Runtime::US8::US8_0(v339_0_0, v339_0_1, v339_0_2, v339_0_3, v339_0_4) => {
                            v339.clone()
                        }
                        _ => {
                            let v354: Runtime::US10 = if (length(v10.clone())) == 0_i32 {
                                Runtime::US10::US10_0(v10.clone(), v16.clone(), 1_i32, 1_i32)
                            } else {
                                Runtime::US10::US10_1(sprintf!(
                                    "parsing.eof / expected end of input / input: {:?}",
                                    v10.clone()
                                ))
                            };
                            let v363: Runtime::US8 = match &v354 {
                                Runtime::US10::US10_0(v354_0_0, v354_0_1, v354_0_2, v354_0_3) => {
                                    Runtime::US8::US8_0(
                                        string(""),
                                        v354_0_0.clone(),
                                        v354_0_1.clone(),
                                        v354_0_2.clone(),
                                        v354_0_3.clone(),
                                    )
                                }
                                Runtime::US10::US10_1(v354_1_0) => {
                                    Runtime::US8::US8_1(v354_1_0.clone())
                                }
                            };
                            match &v363 {
                                Runtime::US8::US8_0(
                                    v363_0_0,
                                    v363_0_1,
                                    v363_0_2,
                                    v363_0_3,
                                    v363_0_4,
                                ) => {
                                    let v365: string = v363_0_1.clone();
                                    Runtime::US8::US8_0(
                                        v363_0_0.clone(),
                                        getSlice(
                                            v365.clone(),
                                            Some(Runtime::method36(v365.clone(), 0_i32)),
                                            Some((length(v365)) - 1_i32),
                                        ),
                                        v363_0_2.clone(),
                                        v363_0_3.clone(),
                                        v363_0_4.clone(),
                                    )
                                }
                                Runtime::US8::US8_1(v363_1_0) => {
                                    Runtime::US8::US8_1(v363_1_0.clone())
                                }
                            }
                        }
                    }
                }
            };
            let v671: Runtime::US11 = match &v416 {
                Runtime::US8::US8_0(v416_0_0, v416_0_1, v416_0_2, v416_0_3, v416_0_4) => {
                    let v421: i32 = v416_0_4.clone();
                    let v420: i32 = v416_0_3.clone();
                    let v419: LrcPtr<StringBuilder> = v416_0_2.clone();
                    let v418: string = v416_0_1.clone();
                    let v542: Runtime::US7 = if string("") == (v418.clone()) {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                            ' ',
                            (v419.clone(), v420, v421)
                        ))
                    } else {
                        let v428: char = getCharAt(v418.clone(), 0_i32);
                        if (v428) == ' ' {
                            let v463: string = getSlice(
                                v418.clone(),
                                Some(1_i32),
                                Some((length(v418.clone())) - 1_i32),
                            );
                            let v469: string = ofChar(v428);
                            let patternInput_4: (LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method28(
                                    Runtime::method27(length(v469.clone()) as i64, v469, 0_i64),
                                    v419.clone(),
                                    v420,
                                    v421,
                                );
                            Runtime::US7::US7_0(
                                v428,
                                v463,
                                patternInput_4.0.clone(),
                                patternInput_4.1.clone(),
                                patternInput_4.2.clone(),
                            )
                        } else {
                            let v484: i32 = (indexOf(v418.clone(), string("\n"))) - 1_i32;
                            Runtime::US7::US7_1(concat(new_array(&[
                                sprintf!(
                                    "parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                    ' ',
                                    v420,
                                    v421,
                                    v419.clone(),
                                    getSlice(
                                        v418.clone(),
                                        Some(0_i32),
                                        Some(
                                            (if -2_i32 == (v484) {
                                                (length(v418.clone())) + 1_i32
                                            } else {
                                                (v484) + 1_i32
                                            }) - 1_i32
                                        )
                                    )
                                ),
                                string("\n"),
                                append(
                                    ((Runtime::method29((v421) - 1_i32, 0_i32))(string(""))),
                                    string("^"),
                                ),
                                string("\n"),
                            ])))
                        }
                    };
                    let v554: Runtime::US12 = match &v542 {
                        Runtime::US7::US7_0(v542_0_0, v542_0_1, v542_0_2, v542_0_3, v542_0_4) => {
                            Runtime::US12::US12_0(
                                Runtime::US9::US9_0(v542_0_0.clone()),
                                v542_0_1.clone(),
                                v542_0_2.clone(),
                                v542_0_3.clone(),
                                v542_0_4.clone(),
                            )
                        }
                        _ => Runtime::US12::US12_0(
                            Runtime::US9::US9_1,
                            v418.clone(),
                            v419.clone(),
                            v420,
                            v421,
                        ),
                    };
                    let v645: Runtime::US8 = match &v554 {
                        Runtime::US12::US12_0(v554_0_0, v554_0_1, v554_0_2, v554_0_3, v554_0_4) => {
                            let v559: i32 = v554_0_4.clone();
                            let v558: i32 = v554_0_3.clone();
                            let v557: LrcPtr<StringBuilder> = v554_0_2.clone();
                            let v556: string = v554_0_1.clone();
                            let v621: Runtime::US7 = if string("") == (v556.clone()) {
                                Runtime::US7::US7_1(sprintf!(
                                    "parsing.any_char / unexpected end of input / s: {:?}",
                                    (v557.clone(), v558, v559)
                                ))
                            } else {
                                let v571: char = getCharAt(v556.clone(), 0_i32);
                                let v605: string = getSlice(
                                    v556.clone(),
                                    Some(1_i32),
                                    Some((length(v556)) - 1_i32),
                                );
                                let v611: string = ofChar(v571);
                                let patternInput_5: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method28(
                                        Runtime::method27(length(v611.clone()) as i64, v611, 0_i64),
                                        v557,
                                        v558,
                                        v559,
                                    );
                                Runtime::US7::US7_0(
                                    v571,
                                    v605,
                                    patternInput_5.0.clone(),
                                    patternInput_5.1.clone(),
                                    patternInput_5.2.clone(),
                                )
                            };
                            match &v621 {
                                Runtime::US7::US7_0(
                                    v621_0_0,
                                    v621_0_1,
                                    v621_0_2,
                                    v621_0_3,
                                    v621_0_4,
                                ) => {
                                    let patternInput_6: (
                                        string,
                                        string,
                                        LrcPtr<StringBuilder>,
                                        i32,
                                        i32,
                                    ) = Runtime::method37(
                                        ofChar(v621_0_0.clone()),
                                        v621_0_1.clone(),
                                        v621_0_2.clone(),
                                        v621_0_3.clone(),
                                        v621_0_4.clone(),
                                    );
                                    Runtime::US8::US8_0(
                                        patternInput_6.0.clone(),
                                        patternInput_6.1.clone(),
                                        patternInput_6.2.clone(),
                                        patternInput_6.3.clone(),
                                        patternInput_6.4.clone(),
                                    )
                                }
                                Runtime::US7::US7_1(v621_1_0) => {
                                    Runtime::US8::US8_1(v621_1_0.clone())
                                }
                            }
                        }
                        Runtime::US12::US12_1(v554_1_0) => Runtime::US8::US8_1(v554_1_0.clone()),
                    };
                    let v657: Runtime::US13 = match &v645 {
                        Runtime::US8::US8_0(v645_0_0, v645_0_1, v645_0_2, v645_0_3, v645_0_4) => {
                            Runtime::US13::US13_0(
                                Runtime::US5::US5_0(v645_0_0.clone()),
                                v645_0_1.clone(),
                                v645_0_2.clone(),
                                v645_0_3.clone(),
                                v645_0_4.clone(),
                            )
                        }
                        _ => Runtime::US13::US13_0(
                            Runtime::US5::US5_1,
                            v418.clone(),
                            v419.clone(),
                            v420,
                            v421,
                        ),
                    };
                    match &v657 {
                        Runtime::US13::US13_0(v657_0_0, v657_0_1, v657_0_2, v657_0_3, v657_0_4) => {
                            Runtime::US11::US11_0(
                                v416_0_0.clone(),
                                v657_0_0.clone(),
                                v657_0_1.clone(),
                                v657_0_2.clone(),
                                v657_0_3.clone(),
                                v657_0_4.clone(),
                            )
                        }
                        Runtime::US13::US13_1(v657_1_0) => Runtime::US11::US11_1(v657_1_0.clone()),
                    }
                }
                Runtime::US8::US8_1(v416_1_0) => Runtime::US11::US11_1(v416_1_0.clone()),
            };
            match &v671 {
                Runtime::US11::US11_0(
                    v671_0_0,
                    v671_0_1,
                    v671_0_2,
                    v671_0_3,
                    v671_0_4,
                    v671_0_5,
                ) => Runtime::US6::US6_0(v671_0_0.clone(), v671_0_1.clone()),
                Runtime::US11::US11_1(v671_1_0) => Runtime::US6::US6_1(v671_1_0.clone()),
            }
        }
    }
    pub fn method38() -> string {
        let v8: string = Runtime::method13(getCharAt(toLower(string("Debug")), 0_i32));
        let v97: &str = inline_colorization::color_bright_blue;
        let v108: &str = &*v8;
        let v132: &str = inline_colorization::color_reset;
        let v134: std::string::String = format!("{}{}{}", v97, v108, v132);
        fable_library_rust::String_::fromString(v134)
    }
    pub fn method40(
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
        let v19_1: () = {
            Runtime::closure7(v10.clone(), string("{ "), ());
            ()
        };
        let v30: () = {
            Runtime::closure7(v10.clone(), string("file_name"), ());
            ()
        };
        let v41: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v50: () = {
            Runtime::closure7(v10.clone(), v0_1, ());
            ()
        };
        let v61: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v72: () = {
            Runtime::closure7(v10.clone(), string("arguments"), ());
            ()
        };
        let v81: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v94: () = {
            Runtime::closure7(v10.clone(), sprintf!("{:?}", v1_1), ());
            ()
        };
        let v103: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v114: () = {
            Runtime::closure7(v10.clone(), string("options"), ());
            ()
        };
        let v123: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v132: () = {
            Runtime::closure7(v10.clone(), string("{ "), ());
            ()
        };
        let v143: () = {
            Runtime::closure7(v10.clone(), string("command"), ());
            ()
        };
        let v152: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v161: () = {
            Runtime::closure7(v10.clone(), v2_1, ());
            ()
        };
        let v170: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v181: () = {
            Runtime::closure7(v10.clone(), string("cancellation_token"), ());
            ()
        };
        let v190: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v207: std::string::String = format!("{:#?}", v3);
        let v238: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v207),
                (),
            );
            ()
        };
        let v247: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v258: () = {
            Runtime::closure7(v10.clone(), string("environment_variables"), ());
            ()
        };
        let v267: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v280: () = {
            Runtime::closure7(v10.clone(), sprintf!("{:?}", v4), ());
            ()
        };
        let v289: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v300: () = {
            Runtime::closure7(v10.clone(), string("on_line"), ());
            ()
        };
        let v309: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v326: std::string::String = format!("{:#?}", v5);
        let v357: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v326),
                (),
            );
            ()
        };
        let v366: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v377: () = {
            Runtime::closure7(v10.clone(), string("stdin"), ());
            ()
        };
        let v386: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v403: std::string::String = format!("{:#?}", v6);
        let v434: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v403),
                (),
            );
            ()
        };
        let v443: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v454: () = {
            Runtime::closure7(v10.clone(), string("trace"), ());
            ()
        };
        let v463: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v475: () = {
            Runtime::closure7(
                v10.clone(),
                if v7 { string("true") } else { string("false") },
                (),
            );
            ()
        };
        let v484: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v495: () = {
            Runtime::closure7(v10.clone(), string("working_directory"), ());
            ()
        };
        let v504: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v521: std::string::String = format!("{:#?}", v8);
        let v552: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v521),
                (),
            );
            ()
        };
        let v563: () = {
            Runtime::closure7(v10.clone(), string(" }"), ());
            ()
        };
        let v572: () = {
            Runtime::closure7(v10.clone(), string(" }"), ());
            ()
        };
        v10.l0.get().clone()
    }
    pub fn method39(
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
        let v17_1: string = Runtime::method40(v8, v9, v10, v11, v12, v13, v14, v15, v16);
        Runtime::method18(sprintf!(
            "{} {} #{} {} / {}",
            v6,
            v7,
            v0_1.l0.get().clone(),
            string("runtime.execute_with_options_async"),
            v17_1
        ))
    }
    pub fn closure17(
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
            Runtime::method19(Runtime::method39(
                v34.clone(),
                v35.clone(),
                v36.clone(),
                v37.clone(),
                v38.clone(),
                v39.clone(),
                Runtime::method8(v34, v35, v36, v37, v38, v39),
                Runtime::method38(),
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
    pub fn method41(
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
    pub fn method42(v0_1: i32, v1_1: LrcPtr<Runtime::Mut5>) -> bool {
        (v1_1.l0.get().clone()) < (v0_1)
    }
    pub fn method45(v0_1: bool) -> string {
        unbox::<string>(fable_library_rust::Native_::getZero())
    }
    pub fn closure19(
        unitVar: (),
        v0_1: Func1<(i32, string, bool), Arc<Async<()>>>,
    ) -> Runtime::US14 {
        Runtime::US14::US14_0(v0_1)
    }
    pub fn method46() -> Func1<Func1<(i32, string, bool), Arc<Async<()>>>, Runtime::US14> {
        Func1::new(move |v: Func1<(i32, string, bool), Arc<Async<()>>>| Runtime::closure19((), v))
    }
    pub fn method47(v0_1: bool) -> i32 {
        unbox::<i32>(fable_library_rust::Native_::getZero())
    }
    pub fn method48() -> string {
        let v8: string = Runtime::method13(getCharAt(toLower(string("Verbose")), 0_i32));
        let v97: &str = inline_colorization::color_bright_black;
        let v108: &str = &*v8;
        let v132: &str = inline_colorization::color_reset;
        let v134: std::string::String = format!("{}{}{}", v97, v108, v132);
        fable_library_rust::String_::fromString(v134)
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
    pub fn closure20(v0_1: string, unitVar: ()) {
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
    pub fn closure18(
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
    pub fn closure21(unitVar: (), v0_1: CancellationToken) -> Runtime::US15 {
        Runtime::US15::US15_0(v0_1)
    }
    pub fn method50() -> Func1<CancellationToken, Runtime::US15> {
        Func1::new(move |v: CancellationToken| Runtime::closure21((), v))
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
    pub fn closure22(v0_1: bool, unitVar: ()) {
        if (Runtime::method52(v0_1)) == false {
            Runtime::method53(v0_1);
        };
    }
    pub fn method56(v0_1: LrcPtr<TaskCanceledException>) -> string {
        let v2_1: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method14()),
        });
        let v11: () = {
            Runtime::closure7(v2_1.clone(), string("{ "), ());
            ()
        };
        let v22: () = {
            Runtime::closure7(v2_1.clone(), string("ex"), ());
            ()
        };
        let v33: () = {
            Runtime::closure7(v2_1.clone(), string(" = "), ());
            ()
        };
        let v50: std::string::String = format!("{:#?}", v0_1);
        let v81: () = {
            Runtime::closure7(
                v2_1.clone(),
                fable_library_rust::String_::fromString(v50),
                (),
            );
            ()
        };
        let v92: () = {
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
    pub fn closure23(v0_1: LrcPtr<TaskCanceledException>, unitVar: ()) {
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
        let v19_1: () = {
            Runtime::closure7(v10.clone(), string("{ "), ());
            ()
        };
        let v30: () = {
            Runtime::closure7(v10.clone(), string("exit_code"), ());
            ()
        };
        let v41: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v50: () = {
            Runtime::closure7(v10.clone(), sprintf!("{}", v0_1), ());
            ()
        };
        let v61: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v72: () = {
            Runtime::closure7(v10.clone(), string("output_length"), ());
            ()
        };
        let v81: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v90: () = {
            Runtime::closure7(v10.clone(), sprintf!("{}", v1_1), ());
            ()
        };
        let v99: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v110: () = {
            Runtime::closure7(v10.clone(), string("options"), ());
            ()
        };
        let v119: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v128: () = {
            Runtime::closure7(v10.clone(), string("{ "), ());
            ()
        };
        let v139: () = {
            Runtime::closure7(v10.clone(), string("command"), ());
            ()
        };
        let v148: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v157: () = {
            Runtime::closure7(v10.clone(), v2_1, ());
            ()
        };
        let v166: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v177: () = {
            Runtime::closure7(v10.clone(), string("cancellation_token"), ());
            ()
        };
        let v186: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v203: std::string::String = format!("{:#?}", v3);
        let v234: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v203),
                (),
            );
            ()
        };
        let v243: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v254: () = {
            Runtime::closure7(v10.clone(), string("environment_variables"), ());
            ()
        };
        let v263: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v276: () = {
            Runtime::closure7(v10.clone(), sprintf!("{:?}", v4), ());
            ()
        };
        let v285: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v296: () = {
            Runtime::closure7(v10.clone(), string("on_line"), ());
            ()
        };
        let v305: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v322: std::string::String = format!("{:#?}", v5);
        let v353: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v322),
                (),
            );
            ()
        };
        let v362: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v373: () = {
            Runtime::closure7(v10.clone(), string("stdin"), ());
            ()
        };
        let v382: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v399: std::string::String = format!("{:#?}", v6);
        let v430: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v399),
                (),
            );
            ()
        };
        let v439: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v450: () = {
            Runtime::closure7(v10.clone(), string("trace"), ());
            ()
        };
        let v459: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v471: () = {
            Runtime::closure7(
                v10.clone(),
                if v7 { string("true") } else { string("false") },
                (),
            );
            ()
        };
        let v480: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v491: () = {
            Runtime::closure7(v10.clone(), string("working_directory"), ());
            ()
        };
        let v500: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v517: std::string::String = format!("{:#?}", v8);
        let v548: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v517),
                (),
            );
            ()
        };
        let v559: () = {
            Runtime::closure7(v10.clone(), string(" }"), ());
            ()
        };
        let v568: () = {
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
    pub fn closure24(
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
                Runtime::method38(),
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
    pub fn closure25(
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
    pub fn closure26(
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
        let v20_1: LrcPtr<Runtime::Heap0> = v0_1(LrcPtr::new(Runtime::Heap0 {
            l0: string(""),
            l1: None::<CancellationToken>,
            l2: new_empty::<(string, string)>(),
            l3: None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
            l4: None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            l5: true,
            l6: None::<string>,
        }));
        (
            v20_1.l0.clone(),
            v20_1.l1.clone(),
            v20_1.l2.clone(),
            v20_1.l3.clone(),
            v20_1.l4.clone(),
            v20_1.l5,
            v20_1.l6.clone(),
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
                let v114: Runtime::US7 = if string("") == (v1_1.get().clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                            Runtime::method27(length(v76.clone()) as i64, v76, 0_i64),
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
                    } else {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                            v33,
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    }
                };
                match &v114 {
                    Runtime::US7::US7_0(v114_0_0, v114_0_1, v114_0_2, v114_0_3, v114_0_4) => {
                        let v0_1_temp: string =
                            append((v0_1.get().clone()), (ofChar(v114_0_0.clone())));
                        let v1_1_temp: string = v114_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v114_0_2.clone();
                        let v3_temp: i32 = v114_0_3.clone();
                        let v4_temp: i32 = v114_0_4.clone();
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
    pub fn closure28(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US8 {
        let v3: i32 = _arg.3.clone();
        let v2_1: i32 = _arg.2.clone();
        let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
        let v0_1: string = _arg.0.clone();
        let v125: Runtime::US7 = if string("") == (v0_1.clone()) {
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
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                    Runtime::method27(length(v51.clone()) as i64, v51, 0_i64),
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
            } else {
                let v66: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                (if -2_i32 == (v66) {
                                    (length(v0_1)) + 1_i32
                                } else {
                                    (v66) + 1_i32
                                }) - 1_i32
                            )
                        )
                    ),
                    string("\n"),
                    append(
                        ((Runtime::method29((v3) - 1_i32, 0_i32))(string(""))),
                        string("^"),
                    ),
                    string("\n"),
                ])))
            }
        };
        let v196: Runtime::US7 = match &v125 {
            Runtime::US7::US7_0(v125_0_0, v125_0_1, v125_0_2, v125_0_3, v125_0_4) => {
                let v130: i32 = v125_0_4.clone();
                let v129: i32 = v125_0_3.clone();
                let v128: LrcPtr<StringBuilder> = v125_0_2.clone();
                let v127: string = v125_0_1.clone();
                if string("") == (v127.clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.any_char / unexpected end of input / s: {:?}",
                        (v128.clone(), v129, v130)
                    ))
                } else {
                    let v142: char = getCharAt(v127.clone(), 0_i32);
                    let v176: string =
                        getSlice(v127.clone(), Some(1_i32), Some((length(v127)) - 1_i32));
                    let v182: string = ofChar(v142);
                    let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                        Runtime::method27(length(v182.clone()) as i64, v182, 0_i64),
                        v128,
                        v129,
                        v130,
                    );
                    Runtime::US7::US7_0(
                        v142,
                        v176,
                        patternInput_1.0.clone(),
                        patternInput_1.1.clone(),
                        patternInput_1.2.clone(),
                    )
                }
            }
            Runtime::US7::US7_1(v125_1_0) => Runtime::US7::US7_1(v125_1_0.clone()),
        };
        match &v196 {
            Runtime::US7::US7_0(v196_0_0, v196_0_1, v196_0_2, v196_0_3, v196_0_4) => {
                Runtime::US8::US8_0(
                    append((ofChar('\\')), (ofChar(v196_0_0.clone()))),
                    v196_0_1.clone(),
                    v196_0_2.clone(),
                    v196_0_3.clone(),
                    v196_0_4.clone(),
                )
            }
            Runtime::US7::US7_1(v196_1_0) => Runtime::US8::US8_1(v196_1_0.clone()),
        }
    }
    pub fn closure29(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US8 {
        let v3: i32 = _arg.3.clone();
        let v2_1: i32 = _arg.2.clone();
        let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
        let v0_1: string = _arg.0.clone();
        let v125: Runtime::US7 = if string("") == (v0_1.clone()) {
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
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                    Runtime::method27(length(v51.clone()) as i64, v51, 0_i64),
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
            } else {
                let v66: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                (if -2_i32 == (v66) {
                                    (length(v0_1)) + 1_i32
                                } else {
                                    (v66) + 1_i32
                                }) - 1_i32
                            )
                        )
                    ),
                    string("\n"),
                    append(
                        ((Runtime::method29((v3) - 1_i32, 0_i32))(string(""))),
                        string("^"),
                    ),
                    string("\n"),
                ])))
            }
        };
        let v196: Runtime::US7 = match &v125 {
            Runtime::US7::US7_0(v125_0_0, v125_0_1, v125_0_2, v125_0_3, v125_0_4) => {
                let v130: i32 = v125_0_4.clone();
                let v129: i32 = v125_0_3.clone();
                let v128: LrcPtr<StringBuilder> = v125_0_2.clone();
                let v127: string = v125_0_1.clone();
                if string("") == (v127.clone()) {
                    Runtime::US7::US7_1(sprintf!(
                        "parsing.any_char / unexpected end of input / s: {:?}",
                        (v128.clone(), v129, v130)
                    ))
                } else {
                    let v142: char = getCharAt(v127.clone(), 0_i32);
                    let v176: string =
                        getSlice(v127.clone(), Some(1_i32), Some((length(v127)) - 1_i32));
                    let v182: string = ofChar(v142);
                    let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                        Runtime::method27(length(v182.clone()) as i64, v182, 0_i64),
                        v128,
                        v129,
                        v130,
                    );
                    Runtime::US7::US7_0(
                        v142,
                        v176,
                        patternInput_1.0.clone(),
                        patternInput_1.1.clone(),
                        patternInput_1.2.clone(),
                    )
                }
            }
            Runtime::US7::US7_1(v125_1_0) => Runtime::US7::US7_1(v125_1_0.clone()),
        };
        match &v196 {
            Runtime::US7::US7_0(v196_0_0, v196_0_1, v196_0_2, v196_0_3, v196_0_4) => {
                Runtime::US8::US8_0(
                    append((ofChar('`')), (ofChar(v196_0_0.clone()))),
                    v196_0_1.clone(),
                    v196_0_2.clone(),
                    v196_0_3.clone(),
                    v196_0_4.clone(),
                )
            }
            Runtime::US7::US7_1(v196_1_0) => Runtime::US8::US8_1(v196_1_0.clone()),
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
                let v106: Runtime::US7 = if string("") == (v1_1.get().clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                            Runtime::method27(length(v72.clone()) as i64, v72, 0_i64),
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
                    } else {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                            v29,
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    }
                };
                let v121: Runtime::US8 = match &v106 {
                    Runtime::US7::US7_0(v106_0_0, v106_0_1, v106_0_2, v106_0_3, v106_0_4) => {
                        Runtime::US8::US8_0(
                            ofChar(v106_0_0.clone()),
                            v106_0_1.clone(),
                            v106_0_2.clone(),
                            v106_0_3.clone(),
                            v106_0_4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v106_1_0) => Runtime::US8::US8_1(v106_1_0.clone()),
                };
                let v135: Runtime::US8 = match &v121 {
                    Runtime::US8::US8_0(v121_0_0, v121_0_1, v121_0_2, v121_0_3, v121_0_4) => {
                        v121.clone()
                    }
                    _ => Runtime::method66(
                        v1_1.get().clone(),
                        v2_1.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                        LrcPtr::new(Runtime::UH3::UH3_1(
                            Func1::new(
                                move |arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)| {
                                    Runtime::closure28((), arg10_0040)
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
                                        Runtime::closure29((), arg10_0040_1)
                                    },
                                ),
                                LrcPtr::new(Runtime::UH3::UH3_0),
                            )),
                        )),
                    ),
                };
                match &v135 {
                    Runtime::US8::US8_0(v135_0_0, v135_0_1, v135_0_2, v135_0_3, v135_0_4) => {
                        let v0_1_temp: LrcPtr<Runtime::UH2> =
                            LrcPtr::new(Runtime::UH2::UH2_1(v135_0_0.clone(), v0_1.get().clone()));
                        let v1_1_temp: string = v135_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v135_0_2.clone();
                        let v3_temp: i32 = v135_0_3.clone();
                        let v4_temp: i32 = v135_0_4.clone();
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
                let v106: Runtime::US7 = if string("") == (v1_1.get().clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                            Runtime::method27(length(v72.clone()) as i64, v72, 0_i64),
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
                    } else {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                            v29,
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    }
                };
                let v121: Runtime::US8 = match &v106 {
                    Runtime::US7::US7_0(v106_0_0, v106_0_1, v106_0_2, v106_0_3, v106_0_4) => {
                        Runtime::US8::US8_0(
                            ofChar(v106_0_0.clone()),
                            v106_0_1.clone(),
                            v106_0_2.clone(),
                            v106_0_3.clone(),
                            v106_0_4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v106_1_0) => Runtime::US8::US8_1(v106_1_0.clone()),
                };
                match &v121 {
                    Runtime::US8::US8_0(v121_0_0, v121_0_1, v121_0_2, v121_0_3, v121_0_4) => {
                        let v0_1_temp: LrcPtr<Runtime::UH2> =
                            LrcPtr::new(Runtime::UH2::UH2_1(v121_0_0.clone(), v0_1.get().clone()));
                        let v1_1_temp: string = v121_0_1.clone();
                        let v2_1_temp: LrcPtr<StringBuilder> = v121_0_2.clone();
                        let v3_temp: i32 = v121_0_3.clone();
                        let v4_temp: i32 = v121_0_4.clone();
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
                let v114: Runtime::US7 = if v5 {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method28(
                            Runtime::method27(length(v76.clone()) as i64, v76, 0_i64),
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
                    } else {
                        Runtime::US7::US7_1(sprintf!(
                            "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                            v33,
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    }
                };
                let v134: Runtime::US8 = match &v114 {
                    Runtime::US7::US7_0(v114_0_0, v114_0_1, v114_0_2, v114_0_3, v114_0_4) => {
                        let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                            Runtime::method63(
                                ofChar(v114_0_0.clone()),
                                v114_0_1.clone(),
                                v114_0_2.clone(),
                                v114_0_3.clone(),
                                v114_0_4.clone(),
                            );
                        Runtime::US8::US8_0(
                            patternInput_1.0.clone(),
                            patternInput_1.1.clone(),
                            patternInput_1.2.clone(),
                            patternInput_1.3.clone(),
                            patternInput_1.4.clone(),
                        )
                    }
                    Runtime::US7::US7_1(v114_1_0) => Runtime::US8::US8_1(v114_1_0.clone()),
                };
                let v522: Runtime::US8 = match &v134 {
                    Runtime::US8::US8_0(v134_0_0, v134_0_1, v134_0_2, v134_0_3, v134_0_4) => {
                        v134.clone()
                    }
                    _ => {
                        let v261: Runtime::US7 = if v5 {
                            Runtime::US7::US7_1(sprintf!(
                                "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                '\"',
                                (v2_1.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        } else {
                            let v146: char = getCharAt(v1_1.get().clone(), 0_i32);
                            if (v146) == '\"' {
                                let v181: string = getSlice(
                                    v1_1.get().clone(),
                                    Some(1_i32),
                                    Some((length(v1_1.get().clone())) - 1_i32),
                                );
                                let v187: string = ofChar(v146);
                                let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method28(
                                        Runtime::method27(length(v187.clone()) as i64, v187, 0_i64),
                                        v2_1.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Runtime::US7::US7_0(
                                    v146,
                                    v181,
                                    patternInput_2.0.clone(),
                                    patternInput_2.1.clone(),
                                    patternInput_2.2.clone(),
                                )
                            } else {
                                let v202: i32 = (indexOf(v1_1.get().clone(), string("\n"))) - 1_i32;
                                Runtime::US7::US7_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                                 '\"',
                                                                                                 v3.get().clone(),
                                                                                                 v4.get().clone(),
                                                                                                 v2_1.get().clone(),
                                                                                                 getSlice(v1_1.get().clone(),
                                                                                                          Some(0_i32),
                                                                                                          Some((if -2_i32
                                                                                                                       ==
                                                                                                                       (v202)
                                                                                                                   {
                                                                                                                    (length(v1_1.get().clone()))
                                                                                                                        +
                                                                                                                        1_i32
                                                                                                                } else {
                                                                                                                    (v202)
                                                                                                                        +
                                                                                                                        1_i32
                                                                                                                })
                                                                                                                   -
                                                                                                                   1_i32))),
                                                                                        string("\n"),
                                                                                        append(((Runtime::method29((v4.get().clone())
                                                                                                                       -
                                                                                                                       1_i32,
                                                                                                                   0_i32))(string(""))),
                                                                                               string("^")),
                                                                                        string("\n")])))
                            }
                        };
                        let v451: Runtime::US8 = match &v261 {
                            Runtime::US7::US7_0(
                                v261_0_0,
                                v261_0_1,
                                v261_0_2,
                                v261_0_3,
                                v261_0_4,
                            ) => {
                                let v266: i32 = v261_0_4.clone();
                                let v265: i32 = v261_0_3.clone();
                                let v264: LrcPtr<StringBuilder> = v261_0_2.clone();
                                let v263: string = v261_0_1.clone();
                                let v268: Runtime::US17 = Runtime::method64(
                                    LrcPtr::new(Runtime::UH2::UH2_0),
                                    v263.clone(),
                                    v264.clone(),
                                    v265,
                                    v266,
                                );
                                let v301: Runtime::US8 = match &v268 {
                                    Runtime::US17::US17_0(
                                        v268_0_0,
                                        v268_0_1,
                                        v268_0_2,
                                        v268_0_3,
                                        v268_0_4,
                                    ) => {
                                        let v275: List<string> =
                                            Runtime::method68(v268_0_0.clone(), empty::<string>());
                                        Runtime::US8::US8_0(
                                            join(
                                                string(""),
                                                toArray_1(delay(Func0::new({
                                                    let v275 = v275.clone();
                                                    move || ofList(v275.clone()).clone()
                                                }))),
                                            ),
                                            v268_0_1.clone(),
                                            v268_0_2.clone(),
                                            v268_0_3.clone(),
                                            v268_0_4.clone(),
                                        )
                                    }
                                    Runtime::US17::US17_1(v268_1_0) => {
                                        Runtime::US8::US8_1(v268_1_0.clone())
                                    }
                                };
                                match &v301 {
                                    Runtime::US8::US8_0(
                                        v301_0_0,
                                        v301_0_1,
                                        v301_0_2,
                                        v301_0_3,
                                        v301_0_4,
                                    ) => {
                                        let v306: i32 = v301_0_4.clone();
                                        let v305: i32 = v301_0_3.clone();
                                        let v304: LrcPtr<StringBuilder> = v301_0_2.clone();
                                        let v303: string = v301_0_1.clone();
                                        let v428: Runtime::US7 = if string("") == (v303.clone()) {
                                            Runtime::US7::US7_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                                                                              '\"',
                                                                                              (v304.clone(),
                                                                                               v305,
                                                                                               v306)))
                                        } else {
                                            let v313: char = getCharAt(v303.clone(), 0_i32);
                                            if (v313) == '\"' {
                                                let v348: string = getSlice(
                                                    v303.clone(),
                                                    Some(1_i32),
                                                    Some((length(v303.clone())) - 1_i32),
                                                );
                                                let v354: string = ofChar(v313);
                                                let patternInput_3: (
                                                    LrcPtr<StringBuilder>,
                                                    i32,
                                                    i32,
                                                ) = Runtime::method28(
                                                    Runtime::method27(
                                                        length(v354.clone()) as i64,
                                                        v354,
                                                        0_i64,
                                                    ),
                                                    v304.clone(),
                                                    v305,
                                                    v306,
                                                );
                                                Runtime::US7::US7_0(
                                                    v313,
                                                    v348,
                                                    patternInput_3.0.clone(),
                                                    patternInput_3.1.clone(),
                                                    patternInput_3.2.clone(),
                                                )
                                            } else {
                                                let v369: i32 =
                                                    (indexOf(v303.clone(), string("\n"))) - 1_i32;
                                                Runtime::US7::US7_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                                                     '\"',
                                                                                                                     v305,
                                                                                                                     v306,
                                                                                                                     v304.clone(),
                                                                                                                     getSlice(v303.clone(),
                                                                                                                              Some(0_i32),
                                                                                                                              Some((if -2_i32
                                                                                                                                           ==
                                                                                                                                           (v369)
                                                                                                                                       {
                                                                                                                                        (length(v303.clone()))
                                                                                                                                            +
                                                                                                                                            1_i32
                                                                                                                                    } else {
                                                                                                                                        (v369)
                                                                                                                                            +
                                                                                                                                            1_i32
                                                                                                                                    })
                                                                                                                                       -
                                                                                                                                       1_i32))),
                                                                                                            string("\n"),
                                                                                                            append(((Runtime::method29((v306)
                                                                                                                                           -
                                                                                                                                           1_i32,
                                                                                                                                       0_i32))(string(""))),
                                                                                                                   string("^")),
                                                                                                            string("\n")])))
                                            }
                                        };
                                        match &v428 {
                                                             Runtime::US7::US7_0(v428_0_0,
                                                                                 v428_0_1,
                                                                                 v428_0_2,
                                                                                 v428_0_3,
                                                                                 v428_0_4)
                                                             =>
                                                             Runtime::US8::US8_0(v301_0_0.clone(),
                                                                                 v428_0_1.clone(),
                                                                                 v428_0_2.clone(),
                                                                                 v428_0_3.clone(),
                                                                                 v428_0_4.clone()),
                                                             Runtime::US7::US7_1(v428_1_0)
                                                             =>
                                                             Runtime::US8::US8_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                                          v428_1_0.clone(),
                                                                                          (v1_1.get().clone(),
                                                                                           v2_1.get().clone(),
                                                                                           v3.get().clone(),
                                                                                           v4.get().clone()),
                                                                                          (v263.clone(),
                                                                                           v264.clone(),
                                                                                           v265,
                                                                                           v266),
                                                                                          (v303.clone(),
                                                                                           v304.clone(),
                                                                                           v305,
                                                                                           v306))),
                                                         }
                                    }
                                    _ => Runtime::US8::US8_1(string(
                                        "parsing.between / expected content",
                                    )),
                                }
                            }
                            Runtime::US7::US7_1(v261_1_0) => Runtime::US8::US8_1(v261_1_0.clone()),
                        };
                        match &v451 {
                            Runtime::US8::US8_0(
                                v451_0_0,
                                v451_0_1,
                                v451_0_2,
                                v451_0_3,
                                v451_0_4,
                            ) => v451.clone(),
                            _ => {
                                let v463: Runtime::US8 = Runtime::method66(
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
                                                Runtime::closure28((), arg10_0040)
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
                                                    Runtime::closure29((), arg10_0040_1)
                                                },
                                            ),
                                            LrcPtr::new(Runtime::UH3::UH3_0),
                                        )),
                                    )),
                                );
                                let v474: Runtime::US8 = match &v463 {
                                    Runtime::US8::US8_0(
                                        v463_0_0,
                                        v463_0_1,
                                        v463_0_2,
                                        v463_0_3,
                                        v463_0_4,
                                    ) => Runtime::US8::US8_0(
                                        string(""),
                                        v463_0_1.clone(),
                                        v463_0_2.clone(),
                                        v463_0_3.clone(),
                                        v463_0_4.clone(),
                                    ),
                                    Runtime::US8::US8_1(v463_1_0) => {
                                        Runtime::US8::US8_1(v463_1_0.clone())
                                    }
                                };
                                let v485: Runtime::US17 = match &v474 {
                                    Runtime::US8::US8_0(
                                        v474_0_0,
                                        v474_0_1,
                                        v474_0_2,
                                        v474_0_3,
                                        v474_0_4,
                                    ) => Runtime::method69(
                                        LrcPtr::new(Runtime::UH2::UH2_0),
                                        v474_0_1.clone(),
                                        v474_0_2.clone(),
                                        v474_0_3.clone(),
                                        v474_0_4.clone(),
                                    ),
                                    Runtime::US8::US8_1(v474_1_0) => {
                                        Runtime::US17::US17_1(v474_1_0.clone())
                                    }
                                };
                                match &v485 {
                                    Runtime::US17::US17_0(
                                        v485_0_0,
                                        v485_0_1,
                                        v485_0_2,
                                        v485_0_3,
                                        v485_0_4,
                                    ) => {
                                        let v492: List<string> =
                                            Runtime::method68(v485_0_0.clone(), empty::<string>());
                                        Runtime::US8::US8_0(
                                            join(
                                                string(""),
                                                toArray_1(delay(Func0::new({
                                                    let v492 = v492.clone();
                                                    move || ofList(v492.clone()).clone()
                                                }))),
                                            ),
                                            v485_0_1.clone(),
                                            v485_0_2.clone(),
                                            v485_0_3.clone(),
                                            v485_0_4.clone(),
                                        )
                                    }
                                    Runtime::US17::US17_1(v485_1_0) => {
                                        Runtime::US8::US8_1(v485_1_0.clone())
                                    }
                                }
                            }
                        }
                    }
                };
                match &v522 {
                    Runtime::US8::US8_0(v522_0_0, v522_0_1, v522_0_2, v522_0_3, v522_0_4) => {
                        let v527: i32 = v522_0_4.clone();
                        let v526: i32 = v522_0_3.clone();
                        let v525: LrcPtr<StringBuilder> = v522_0_2.clone();
                        let v524: string = v522_0_1.clone();
                        let v523: string = v522_0_0.clone();
                        let v529: i32 = Runtime::method36(v524.clone(), 0_i32);
                        let v571: Runtime::US10 = if 0_i32 == (v529) {
                            Runtime::US10::US10_1(string(
                                "parsing.spaces1 / expected at least one space",
                            ))
                        } else {
                            Runtime::US10::US10_0(
                                getSlice(
                                    v524.clone(),
                                    Some(v529),
                                    Some((length(v524.clone())) - 1_i32),
                                ),
                                v525.clone(),
                                v526,
                                v527,
                            )
                        };
                        match &v571 {
                            Runtime::US10::US10_0(v571_0_0, v571_0_1, v571_0_2, v571_0_3) => {
                                let v0_1_temp: LrcPtr<Runtime::UH2> = LrcPtr::new(
                                    Runtime::UH2::UH2_1(v523.clone(), v0_1.get().clone()),
                                );
                                let v1_1_temp: string = v571_0_0.clone();
                                let v2_1_temp: LrcPtr<StringBuilder> = v571_0_1.clone();
                                let v3_temp: i32 = v571_0_2.clone();
                                let v4_temp: i32 = v571_0_3.clone();
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
                                        v523.clone(),
                                        LrcPtr::new(Runtime::UH2::UH2_0),
                                    )),
                                ),
                                v524.clone(),
                                v525.clone(),
                                v526,
                                v527,
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
            let v22: Runtime::US17 = Runtime::method61(
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
            match &v22 {
                Runtime::US17::US17_0(v22_0_0, v22_0_1, v22_0_2, v22_0_3, v22_0_4) => {
                    Runtime::US16::US16_0(toArray(Runtime::method68(
                        v22_0_0.clone(),
                        empty::<string>(),
                    )))
                }
                Runtime::US17::US17_1(v22_1_0) => Runtime::US16::US16_1(v22_1_0.clone()),
            }
        }
    }
    pub fn closure27(unitVar: (), v0_1: string) -> Result<Array<string>, string> {
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
                )| Runtime::closure25((), arg10_0040),
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
                    Runtime::closure26((), v)
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
        v21.get_or_init(|| Func1::new(move |v: string| Runtime::closure27((), v)))
            .clone()
    }
    pub fn split_args(x: string) -> Result<Array<string>, string> {
        (Runtime::v21())(x)
    }
    on_startup!(());
}
