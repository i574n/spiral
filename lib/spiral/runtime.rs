pub mod Runtime {
    use super::*;
    use fable_library_rust::Async_::Async;
    use fable_library_rust::DateTime_::DateTime;
    use fable_library_rust::List_::List;
    use fable_library_rust::List_::cons;
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
    use fable_library_rust::NativeArray_::Array;
    use fable_library_rust::NativeArray_::new_array;
    use fable_library_rust::NativeArray_::new_empty;
    use fable_library_rust::Option_::defaultValue;
    use fable_library_rust::Option_::map;
    use fable_library_rust::Seq_::delay;
    use fable_library_rust::Seq_::ofList;
    use fable_library_rust::Seq_::toArray as toArray_1;
    use fable_library_rust::String_::append;
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
    use fable_library_rust::String_::toString;
    use fable_library_rust::String_::trimEndChars;
    use fable_library_rust::String_::trimStartChars;
    use fable_library_rust::TimeSpan_::TimeSpan;
    type ConcurrentStack_1<T> = T;
    use fable_library_rust::System::Collections::Generic::IEnumerable_1;
    use fable_library_rust::System::Text::StringBuilder;
    use fable_library_rust::System::Threading::CancellationToken;
    type TaskCanceledException = ();
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
        US4_6(Runtime::US3),
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
            LrcPtr<Runtime::Mut0>,
            LrcPtr<Runtime::Mut1>,
            LrcPtr<Runtime::Mut2>,
            LrcPtr<Runtime::Mut3>,
            LrcPtr<Runtime::Mut4>,
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
        US7_0(string, Runtime::US5),
        US7_1(string),
    }
    impl core::fmt::Display for US7 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US8 {
        US8_0(char, string, LrcPtr<StringBuilder>, i32, i32),
        US8_1(string),
    }
    impl core::fmt::Display for US8 {
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
            Func1<(string, LrcPtr<StringBuilder>, i32, i32), Runtime::US8>,
            LrcPtr<Runtime::UH1>,
        ),
    }
    impl core::fmt::Display for UH1 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US9 {
        US9_0(string, string, LrcPtr<StringBuilder>, i32, i32),
        US9_1(string),
    }
    impl core::fmt::Display for US9 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US10 {
        US10_0(char),
        US10_1,
    }
    impl core::fmt::Display for US10 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US11 {
        US11_0(string, LrcPtr<StringBuilder>, i32, i32),
        US11_1(string),
    }
    impl core::fmt::Display for US11 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US12 {
        US12_0(
            string,
            Runtime::US5,
            string,
            LrcPtr<StringBuilder>,
            i32,
            i32,
        ),
        US12_1(string),
    }
    impl core::fmt::Display for US12 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US13 {
        US13_0(Runtime::US10, string, LrcPtr<StringBuilder>, i32, i32),
        US13_1(string),
    }
    impl core::fmt::Display for US13 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US14 {
        US14_0(Runtime::US5, string, LrcPtr<StringBuilder>, i32, i32),
        US14_1(string),
    }
    impl core::fmt::Display for US14 {
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
    pub enum US15 {
        US15_0(Func1<(i32, string, bool), Arc<Async<()>>>),
        US15_1,
    }
    impl core::fmt::Display for US15 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US16 {
        US16_0(CancellationToken),
        US16_1,
    }
    impl core::fmt::Display for US16 {
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
    pub enum US17 {
        US17_0(Array<string>),
        US17_1(string),
    }
    impl core::fmt::Display for US17 {
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
    pub enum US18 {
        US18_0(
            LrcPtr<Runtime::UH2>,
            string,
            LrcPtr<StringBuilder>,
            i32,
            i32,
        ),
        US18_1(string),
    }
    impl core::fmt::Display for US18 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum UH3 {
        UH3_0,
        UH3_1(
            Func1<(string, LrcPtr<StringBuilder>, i32, i32), Runtime::US9>,
            LrcPtr<Runtime::UH3>,
        ),
    }
    impl core::fmt::Display for UH3 {
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
    pub fn closure1(unitVar: (), v0: string) -> Runtime::US5 {
        Runtime::US5::US5_0(v0)
    }
    pub fn method5() -> Func1<string, Runtime::US5> {
        Func1::new(move |v: string| Runtime::closure1((), v))
    }
    pub fn method2(v0: string) -> string {
        let v3: string = Runtime::method3(v0);
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
        let v16_1: string = Runtime::method4();
        v15_1.unwrap_or(v16_1)
    }
    pub fn method1() -> (Runtime::US1, Runtime::US2) {
        let v1: string = Runtime::method2(string("TRACE_LEVEL"));
        let v6: string = toLower(string("Critical"));
        let v13: string = toLower(string("Warning"));
        let v20: string = toLower(string("Info"));
        let v27: string = toLower(string("Debug"));
        let v34_1: string = toLower(string("Verbose"));
        let v41: Runtime::US1 = if string("Verbose") == (v1.clone()) {
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
                    let v48: Runtime::US1 = if string("Debug") == (v1.clone()) {
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
                            let v55: Runtime::US1 = if string("Info") == (v1.clone()) {
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
                                    let v62: Runtime::US1 = if string("Warning") == (v1.clone()) {
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
                                                if string("Critical") == (v1.clone()) {
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
                                                        if (v34_1.clone()) == (v1.clone()) {
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
                                                            let v83: Runtime::US1 =
                                                                if (v27.clone()) == (v1.clone()) {
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
                                                                    let v90: Runtime::US1 = if (v20
                                                                        .clone())
                                                                        == (v1.clone())
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
                                                                                    (v1.clone())
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
                                                                                            (v1.clone())
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
                Runtime::US2::US2_0({
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
        v0: Runtime::US0,
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
        let v185: Runtime::US2 = _run_target_args__v3.1.clone();
        let v184: Runtime::US1 = _run_target_args__v3.0.clone();
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
                l0: MutCell::new(match &v184 {
                    Runtime::US1::US1_0(v184_0_0) => match &v184 {
                        Runtime::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    _ => v0.clone(),
                }),
            }),
            match &v185 {
                Runtime::US2::US2_0(v185_0_0) => Some(match &v185 {
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
    pub fn closure6(unitVar: (), v0: i64) -> Runtime::US2 {
        Runtime::US2::US2_0(v0)
    }
    pub fn method8() -> Func1<i64, Runtime::US2> {
        Func1::new(move |v: i64| Runtime::closure6((), v))
    }
    pub fn method9() -> string {
        string("hh:mm:ss")
    }
    pub fn method10() -> string {
        string("HH:mm:ss")
    }
    pub fn method7(
        v0: LrcPtr<Runtime::Mut0>,
        v1: LrcPtr<Runtime::Mut1>,
        v2: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
    ) -> string {
        let v220: Runtime::US2 = defaultValue(Runtime::US2::US2_1, map(Runtime::method8(), v5));
        let v360: DateTime = match &v220 {
            Runtime::US2::US2_0(v220_0_0) => {
                let v303: TimeSpan = TimeSpan::new_ticks(
                    ({
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    }) - (match &v220 {
                        Runtime::US2::US2_0(x) => x.clone(),
                        _ => unreachable!(),
                    }),
                );
                DateTime::new_ymdhms_milli(
                    1_i32,
                    1_i32,
                    1_i32,
                    v303.hours(),
                    v303.minutes(),
                    v303.seconds(),
                    v303.milliseconds(),
                )
            }
            _ => DateTime::now(),
        };
        let v361: string = Runtime::method9();
        let provider: string = if (v361.clone()) == string("") {
            string("M-d-y hh:mm:ss tt")
        } else {
            v361
        };
        v360.toString(provider)
    }
    pub fn method13() -> string {
        string("")
    }
    pub fn closure7(v0: LrcPtr<Runtime::Mut3>, v1: string, unitVar: ()) {
        let v4: string = append((v0.l0.get().clone()), (v1));
        v0.l0.set(v4);
        ()
    }
    pub fn method12(v0: char) -> string {
        let v2: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v17: () = {
            Runtime::closure7(v2.clone(), sprintf!("{}", v0), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method14() -> string {
        string("\u{001b}[0m")
    }
    pub fn method11() -> string {
        let v8: string = Runtime::method12(getCharAt(toLower(string("Warning")), 0_i32));
        let v27: &str = inline_colorization::color_yellow;
        let v34_1: &str = &*v8;
        let v65: &str = inline_colorization::color_reset;
        let v67: std::string::String = format!("{}{}{}", v27, v34_1, v65);
        fable_library_rust::String_::fromString(v67)
    }
    pub fn method16() -> string {
        let v1: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        v1.l0.get().clone()
    }
    pub fn method17(v0: string) -> string {
        trimEndChars(
            trimStartChars(v0, toArray(empty::<char>())),
            toArray(ofArray(new_array(&[' ', '/']))),
        )
    }
    pub fn method15(
        v0: LrcPtr<Runtime::Mut0>,
        v1: LrcPtr<Runtime::Mut1>,
        v2: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
    ) -> string {
        let v8: string = Runtime::method16();
        Runtime::method17(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("runtime.current_process_kill / exiting... 3"),
                )),
                string(" / "),
            )),
            (v8),
        ))
    }
    pub fn closure8(v0: LrcPtr<Runtime::Mut0>, unitVar: ()) {
        let v2: i64 = (v0.l0.get().clone()) + 1_i64;
        v0.l0.set(v2);
        ()
    }
    pub fn closure10(v0: string, unitVar: ()) {
        printfn!("{0}", v0);
    }
    pub fn closure9(unitVar: (), v0: string) {
        let v4: () = {
            Runtime::closure10(v0, ());
            ()
        };
        ()
    }
    pub fn closure5(unitVar: (), unitVar_1: ()) {
        fn v15_1() {
            Runtime::closure0((), ());
        }
        let v16_1: () = {
            v15_1();
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
        let v57: Runtime::US0 = (patternInput.4.clone()).l0.get().clone();
        let v297: Runtime::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            3_i32
                >= (find(
                    v57,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Runtime::US0::US0_0, 0_i32)),
                        LrcPtr::new((Runtime::US0::US0_1, 1_i32)),
                        LrcPtr::new((Runtime::US0::US0_2, 2_i32)),
                        LrcPtr::new((Runtime::US0::US0_3, 3_i32)),
                        LrcPtr::new((Runtime::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            Runtime::US6::US6_1
        } else {
            let v80: () = {
                v15_1();
                ()
            };
            let patternInput_1: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v108: Option<i64> = patternInput_1.5.clone();
            let v107: LrcPtr<Runtime::Mut4> = patternInput_1.4.clone();
            let v106: LrcPtr<Runtime::Mut3> = patternInput_1.3.clone();
            let v105: LrcPtr<Runtime::Mut2> = patternInput_1.2.clone();
            let v104: LrcPtr<Runtime::Mut1> = patternInput_1.1.clone();
            let v103: LrcPtr<Runtime::Mut0> = patternInput_1.0.clone();
            let v123: string = Runtime::method15(
                v103.clone(),
                v104.clone(),
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                Runtime::method7(v103, v104, v105, v106, v107, v108),
                Runtime::method11(),
            );
            let v139: () = {
                v15_1();
                ()
            };
            let patternInput_2: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v163: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v162: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v184: () = {
                Runtime::closure8(v162.clone(), ());
                ()
            };
            println!("{}", v123.clone());
            (v163.l0.get().clone())(v123);
            Runtime::US6::US6_0(
                v162,
                v163,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method18(
        v0: LrcPtr<Runtime::Mut0>,
        v1: LrcPtr<Runtime::Mut1>,
        v2: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
    ) -> string {
        let v8: string = Runtime::method16();
        Runtime::method17(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("runtime.current_process_kill / exiting... 2"),
                )),
                string(" / "),
            )),
            (v8),
        ))
    }
    pub fn closure11(unitVar: (), unitVar_1: ()) {
        fn v15_1() {
            Runtime::closure0((), ());
        }
        let v16_1: () = {
            v15_1();
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
        let v57: Runtime::US0 = (patternInput.4.clone()).l0.get().clone();
        let v297: Runtime::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            3_i32
                >= (find(
                    v57,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Runtime::US0::US0_0, 0_i32)),
                        LrcPtr::new((Runtime::US0::US0_1, 1_i32)),
                        LrcPtr::new((Runtime::US0::US0_2, 2_i32)),
                        LrcPtr::new((Runtime::US0::US0_3, 3_i32)),
                        LrcPtr::new((Runtime::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            Runtime::US6::US6_1
        } else {
            let v80: () = {
                v15_1();
                ()
            };
            let patternInput_1: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v108: Option<i64> = patternInput_1.5.clone();
            let v107: LrcPtr<Runtime::Mut4> = patternInput_1.4.clone();
            let v106: LrcPtr<Runtime::Mut3> = patternInput_1.3.clone();
            let v105: LrcPtr<Runtime::Mut2> = patternInput_1.2.clone();
            let v104: LrcPtr<Runtime::Mut1> = patternInput_1.1.clone();
            let v103: LrcPtr<Runtime::Mut0> = patternInput_1.0.clone();
            let v123: string = Runtime::method18(
                v103.clone(),
                v104.clone(),
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                Runtime::method7(v103, v104, v105, v106, v107, v108),
                Runtime::method11(),
            );
            let v139: () = {
                v15_1();
                ()
            };
            let patternInput_2: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v163: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v162: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v184: () = {
                Runtime::closure8(v162.clone(), ());
                ()
            };
            println!("{}", v123.clone());
            (v163.l0.get().clone())(v123);
            Runtime::US6::US6_0(
                v162,
                v163,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method19(
        v0: LrcPtr<Runtime::Mut0>,
        v1: LrcPtr<Runtime::Mut1>,
        v2: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
    ) -> string {
        let v8: string = Runtime::method16();
        Runtime::method17(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("runtime.current_process_kill / exiting... 1"),
                )),
                string(" / "),
            )),
            (v8),
        ))
    }
    pub fn closure12(unitVar: (), unitVar_1: ()) {
        fn v15_1() {
            Runtime::closure0((), ());
        }
        let v16_1: () = {
            v15_1();
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
        let v57: Runtime::US0 = (patternInput.4.clone()).l0.get().clone();
        let v297: Runtime::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            3_i32
                >= (find(
                    v57,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Runtime::US0::US0_0, 0_i32)),
                        LrcPtr::new((Runtime::US0::US0_1, 1_i32)),
                        LrcPtr::new((Runtime::US0::US0_2, 2_i32)),
                        LrcPtr::new((Runtime::US0::US0_3, 3_i32)),
                        LrcPtr::new((Runtime::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            Runtime::US6::US6_1
        } else {
            let v80: () = {
                v15_1();
                ()
            };
            let patternInput_1: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v108: Option<i64> = patternInput_1.5.clone();
            let v107: LrcPtr<Runtime::Mut4> = patternInput_1.4.clone();
            let v106: LrcPtr<Runtime::Mut3> = patternInput_1.3.clone();
            let v105: LrcPtr<Runtime::Mut2> = patternInput_1.2.clone();
            let v104: LrcPtr<Runtime::Mut1> = patternInput_1.1.clone();
            let v103: LrcPtr<Runtime::Mut0> = patternInput_1.0.clone();
            let v123: string = Runtime::method19(
                v103.clone(),
                v104.clone(),
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                Runtime::method7(v103, v104, v105, v106, v107, v108),
                Runtime::method11(),
            );
            let v139: () = {
                v15_1();
                ()
            };
            let patternInput_2: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v163: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v162: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v184: () = {
                Runtime::closure8(v162.clone(), ());
                ()
            };
            println!("{}", v123.clone());
            (v163.l0.get().clone())(v123);
            Runtime::US6::US6_0(
                v162,
                v163,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
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
    pub fn method24() -> string {
        string("")
    }
    pub fn method25(v0: char, v1: LrcPtr<StringBuilder>, v2: i32, v3: i32) -> string {
        let v5: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v19: () = {
            Runtime::closure7(v5.clone(), string("{ "), ());
            ()
        };
        let v38: () = {
            Runtime::closure7(v5.clone(), string("c"), ());
            ()
        };
        let v57: () = {
            Runtime::closure7(v5.clone(), string(" = "), ());
            ()
        };
        let v77: () = {
            Runtime::closure7(v5.clone(), sprintf!("{}", v0), ());
            ()
        };
        let v96: () = {
            Runtime::closure7(v5.clone(), string("; "), ());
            ()
        };
        let v115: () = {
            Runtime::closure7(v5.clone(), string("s"), ());
            ()
        };
        let v132: () = {
            Runtime::closure7(v5.clone(), string(" = "), ());
            ()
        };
        let v144: std::string::String = format!("{:#?}", v1);
        let v191: () = {
            Runtime::closure7(
                v5.clone(),
                fable_library_rust::String_::fromString(v144),
                (),
            );
            ()
        };
        let v210: () = {
            Runtime::closure7(v5.clone(), string(" }"), ());
            ()
        };
        v5.l0.get().clone()
    }
    pub fn method26(v0: i64, v1: string, v2: i64) -> LrcPtr<Runtime::UH0> {
        if (v2) < (v0) {
            LrcPtr::new(Runtime::UH0::UH0_1(
                getCharAt(v1.clone(), v2 as i32),
                Runtime::method26(v0, v1, (v2) + 1_i64),
            ))
        } else {
            LrcPtr::new(Runtime::UH0::UH0_0)
        }
    }
    pub fn method27(
        v0: LrcPtr<Runtime::UH0>,
        v1: LrcPtr<StringBuilder>,
        v2: i32,
        v3: i32,
    ) -> (LrcPtr<StringBuilder>, i32, i32) {
        let v0: MutCell<LrcPtr<Runtime::UH0>> = MutCell::new(v0.clone());
        let v1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1.clone());
        let v2: MutCell<i32> = MutCell::new(v2);
        let v3: MutCell<i32> = MutCell::new(v3);
        '_method27: loop {
            break '_method27 (match v0.get().clone().as_ref() {
                Runtime::UH0::UH0_0 => (v1.get().clone(), v2.get().clone(), v3.get().clone()),
                Runtime::UH0::UH0_1(v0_1_0, v0_1_1) => {
                    let v4: char = match v0.get().clone().as_ref() {
                        Runtime::UH0::UH0_1(x, _) => x.clone(),
                        _ => unreachable!(),
                    };
                    let v6: bool = '\n' == (v4);
                    let patternInput: (i32, i32) = if v6 {
                        ((v2.get().clone()) + 1_i32, 1_i32)
                    } else {
                        (v2.get().clone(), (v3.get().clone()) + 1_i32)
                    };
                    {
                        let v0_temp: LrcPtr<Runtime::UH0> = match v0.get().clone().as_ref() {
                            Runtime::UH0::UH0_1(_, x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone();
                        let v1_temp: LrcPtr<StringBuilder> = if v6 {
                            let v12: LrcPtr<StringBuilder> = v1.get().clone().Clear();
                            v1.get().clone()
                        } else {
                            let v23: LrcPtr<StringBuilder> = {
                                let value: string = ofChar(v4);
                                v1.get().clone().Append_Z721C83C5(value)
                            };
                            v1.get().clone()
                        };
                        let v2_temp: i32 = patternInput.0.clone();
                        let v3_temp: i32 = patternInput.1.clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        continue '_method27;
                    }
                }
            });
        }
    }
    pub fn method28(v0: char, v1: i32, v2: i32) -> string {
        let v4: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v18: () = {
            Runtime::closure7(v4.clone(), string("{ "), ());
            ()
        };
        let v37: () = {
            Runtime::closure7(v4.clone(), string("expected"), ());
            ()
        };
        let v56: () = {
            Runtime::closure7(v4.clone(), string(" = "), ());
            ()
        };
        let v76: () = {
            Runtime::closure7(v4.clone(), sprintf!("{}", v0), ());
            ()
        };
        let v95: () = {
            Runtime::closure7(v4.clone(), string("; "), ());
            ()
        };
        let v114: () = {
            Runtime::closure7(v4.clone(), string("line"), ());
            ()
        };
        let v131: () = {
            Runtime::closure7(v4.clone(), string(" = "), ());
            ()
        };
        let v151: () = {
            Runtime::closure7(v4.clone(), sprintf!("{}", v1), ());
            ()
        };
        let v168: () = {
            Runtime::closure7(v4.clone(), string("; "), ());
            ()
        };
        let v187: () = {
            Runtime::closure7(v4.clone(), string("col"), ());
            ()
        };
        let v204: () = {
            Runtime::closure7(v4.clone(), string(" = "), ());
            ()
        };
        let v224: () = {
            Runtime::closure7(v4.clone(), sprintf!("{}", v2), ());
            ()
        };
        let v243: () = {
            Runtime::closure7(v4.clone(), string(" }"), ());
            ()
        };
        v4.l0.get().clone()
    }
    pub fn closure15(v0: i32, v1: i32, v2: string) -> string {
        if (v1) >= (v0) {
            v2.clone()
        } else {
            (Runtime::method29(v0, (v1) + 1_i32))(append((v2), string(" ")))
        }
    }
    pub fn method29(v0: i32, v1: i32) -> Func1<string, string> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            move |v: string| Runtime::closure15(v0, v1, v)
        })
    }
    pub fn closure14(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US8 {
        let v3: i32 = _arg.3.clone();
        let v2: i32 = _arg.2.clone();
        let v1: LrcPtr<StringBuilder> = _arg.1.clone();
        let v0: string = _arg.0.clone();
        if string("") == (v0.clone()) {
            Runtime::US8::US8_1(append(
                string("parsing.p_char / unexpected end of input / "),
                (Runtime::method25('\"', v1.clone(), v2, v3)),
            ))
        } else {
            let v14_1: char = getCharAt(v0.clone(), 0_i32);
            if (v14_1) == '\"' {
                let v49: string =
                    getSlice(v0.clone(), Some(1_i32), Some((length(v0.clone())) - 1_i32));
                let v55: string = ofChar(v14_1);
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                    Runtime::method26(length(v55.clone()) as i64, v55, 0_i64),
                    v1.clone(),
                    v2,
                    v3,
                );
                Runtime::US8::US8_0(
                    v14_1,
                    v49,
                    patternInput.0.clone(),
                    patternInput.1.clone(),
                    patternInput.2.clone(),
                )
            } else {
                let v72: i32 = (indexOf(v0.clone(), string("\n"))) - 1_i32;
                let v110: string = getSlice(
                    v0.clone(),
                    Some(0_i32),
                    Some(
                        (if -2_i32 == (v72) {
                            (length(v0)) + 1_i32
                        } else {
                            (v72) + 1_i32
                        }) - 1_i32,
                    ),
                );
                Runtime::US8::US8_1(append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append(
                                        (append(
                                            string("parsing.p_char / "),
                                            (Runtime::method28('\"', v2, v3)),
                                        )),
                                        string("\n"),
                                    )),
                                    (toString(v1)),
                                )),
                                (v110),
                            )),
                            string("\n"),
                        )),
                        (append(
                            ((Runtime::method29((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        )),
                    )),
                    string("\n"),
                ))
            }
        }
    }
    pub fn closure16(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US8 {
        let v3: i32 = _arg.3.clone();
        let v2: i32 = _arg.2.clone();
        let v1: LrcPtr<StringBuilder> = _arg.1.clone();
        let v0: string = _arg.0.clone();
        if string("") == (v0.clone()) {
            Runtime::US8::US8_1(append(
                string("parsing.p_char / unexpected end of input / "),
                (Runtime::method25('\'', v1.clone(), v2, v3)),
            ))
        } else {
            let v14_1: char = getCharAt(v0.clone(), 0_i32);
            if (v14_1) == '\'' {
                let v49: string =
                    getSlice(v0.clone(), Some(1_i32), Some((length(v0.clone())) - 1_i32));
                let v55: string = ofChar(v14_1);
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                    Runtime::method26(length(v55.clone()) as i64, v55, 0_i64),
                    v1.clone(),
                    v2,
                    v3,
                );
                Runtime::US8::US8_0(
                    v14_1,
                    v49,
                    patternInput.0.clone(),
                    patternInput.1.clone(),
                    patternInput.2.clone(),
                )
            } else {
                let v72: i32 = (indexOf(v0.clone(), string("\n"))) - 1_i32;
                let v110: string = getSlice(
                    v0.clone(),
                    Some(0_i32),
                    Some(
                        (if -2_i32 == (v72) {
                            (length(v0)) + 1_i32
                        } else {
                            (v72) + 1_i32
                        }) - 1_i32,
                    ),
                );
                Runtime::US8::US8_1(append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append(
                                        (append(
                                            string("parsing.p_char / "),
                                            (Runtime::method28('\'', v2, v3)),
                                        )),
                                        string("\n"),
                                    )),
                                    (toString(v1)),
                                )),
                                (v110),
                            )),
                            string("\n"),
                        )),
                        (append(
                            ((Runtime::method29((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        )),
                    )),
                    string("\n"),
                ))
            }
        }
    }
    pub fn method30(
        v0: string,
        v1: LrcPtr<StringBuilder>,
        v2: LrcPtr<Runtime::UH1>,
    ) -> Runtime::US8 {
        let v0: MutCell<string> = MutCell::new(v0.clone());
        let v1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1.clone());
        let v2: MutCell<LrcPtr<Runtime::UH1>> = MutCell::new(v2.clone());
        '_method30: loop {
            break '_method30 (match v2.get().clone().as_ref() {
                Runtime::UH1::UH1_0 => {
                    Runtime::US8::US8_1(string("parsing.choice / no parsers succeeded"))
                }
                Runtime::UH1::UH1_1(v2_1_0, v2_1_1) => {
                    let v7: Runtime::US8 = (match v2.get().clone().as_ref() {
                        Runtime::UH1::UH1_1(x, _) => x.clone(),
                        _ => unreachable!(),
                    })((
                        v0.get().clone(),
                        v1.get().clone(),
                        1_i32,
                        1_i32,
                    ));
                    match &v7 {
                        Runtime::US8::US8_0(v7_0_0, v7_0_1, v7_0_2, v7_0_3, v7_0_4) => v7.clone(),
                        _ => {
                            let v0_temp: string = v0.get().clone();
                            let v1_temp: LrcPtr<StringBuilder> = v1.get().clone();
                            let v2_temp: LrcPtr<Runtime::UH1> = match v2.get().clone().as_ref() {
                                Runtime::UH1::UH1_1(_, x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone();
                            v0.set(v0_temp);
                            v1.set(v1_temp);
                            v2.set(v2_temp);
                            continue '_method30;
                        }
                    }
                }
            });
        }
    }
    pub fn method31(v0: Array<char>, v1: LrcPtr<StringBuilder>, v2: i32, v3: i32) -> string {
        let v5: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v19: () = {
            Runtime::closure7(v5.clone(), string("{ "), ());
            ()
        };
        let v38: () = {
            Runtime::closure7(v5.clone(), string("chars"), ());
            ()
        };
        let v57: () = {
            Runtime::closure7(v5.clone(), string(" = "), ());
            ()
        };
        let v78: () = {
            Runtime::closure7(v5.clone(), sprintf!("{:?}", v0), ());
            ()
        };
        let v97: () = {
            Runtime::closure7(v5.clone(), string("; "), ());
            ()
        };
        let v116: () = {
            Runtime::closure7(v5.clone(), string("s"), ());
            ()
        };
        let v133: () = {
            Runtime::closure7(v5.clone(), string(" = "), ());
            ()
        };
        let v145: std::string::String = format!("{:#?}", v1);
        let v192: () = {
            Runtime::closure7(
                v5.clone(),
                fable_library_rust::String_::fromString(v145),
                (),
            );
            ()
        };
        let v211: () = {
            Runtime::closure7(v5.clone(), string(" }"), ());
            ()
        };
        v5.l0.get().clone()
    }
    pub fn method32(v0: char, v1: i64) -> bool {
        let v0: MutCell<char> = MutCell::new(v0);
        let v1: MutCell<i64> = MutCell::new(v1);
        '_method32: loop {
            break '_method32 (if (v1.get().clone()) >= 2_i64 {
                false
            } else {
                let v11: Runtime::US10 = if (v1.get().clone()) == 0_i64 {
                    Runtime::US10::US10_0('\"')
                } else {
                    let v5: i64 = (v1.get().clone()) - 1_i64;
                    if (v5) == 0_i64 {
                        Runtime::US10::US10_0('\'')
                    } else {
                        let v8: i64 = (v5) - 1_i64;
                        Runtime::US10::US10_1
                    }
                };
                if (v0.get().clone())
                    == (match &v11 {
                        Runtime::US10::US10_0(v11_0_0) => match &v11 {
                            Runtime::US10::US10_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    })
                {
                    true
                } else {
                    let v0_temp: char = v0.get().clone();
                    let v1_temp: i64 = (v1.get().clone()) + 1_i64;
                    v0.set(v0_temp);
                    v1.set(v1_temp);
                    continue '_method32;
                }
            });
        }
    }
    pub fn method33(
        v0: char,
        v1: Array<char>,
        v2: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> string {
        let v6: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v20: () = {
            Runtime::closure7(v6.clone(), string("{ "), ());
            ()
        };
        let v39: () = {
            Runtime::closure7(v6.clone(), string("first_char"), ());
            ()
        };
        let v58: () = {
            Runtime::closure7(v6.clone(), string(" = "), ());
            ()
        };
        let v78: () = {
            Runtime::closure7(v6.clone(), sprintf!("{}", v0), ());
            ()
        };
        let v97: () = {
            Runtime::closure7(v6.clone(), string("; "), ());
            ()
        };
        let v116: () = {
            Runtime::closure7(v6.clone(), string("chars"), ());
            ()
        };
        let v133: () = {
            Runtime::closure7(v6.clone(), string(" = "), ());
            ()
        };
        let v154: () = {
            Runtime::closure7(v6.clone(), sprintf!("{:?}", v1), ());
            ()
        };
        let v171: () = {
            Runtime::closure7(v6.clone(), string("; "), ());
            ()
        };
        let v190: () = {
            Runtime::closure7(v6.clone(), string("s"), ());
            ()
        };
        let v207: () = {
            Runtime::closure7(v6.clone(), string(" = "), ());
            ()
        };
        let v219: std::string::String = format!("{:#?}", v2);
        let v266: () = {
            Runtime::closure7(
                v6.clone(),
                fable_library_rust::String_::fromString(v219),
                (),
            );
            ()
        };
        let v285: () = {
            Runtime::closure7(v6.clone(), string(" }"), ());
            ()
        };
        v6.l0.get().clone()
    }
    pub fn method34(
        v0: string,
        v1: string,
        v2: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> (string, string, LrcPtr<StringBuilder>, i32, i32) {
        let v0: MutCell<string> = MutCell::new(v0.clone());
        let v1: MutCell<string> = MutCell::new(v1.clone());
        let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method34: loop {
            break '_method34 ({
                let v104: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method31(
                            toArray(ofArray(new_array(&['\"', '\'']))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v28: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method32(v28, 0_i64)) == false {
                        let v65: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v71: string = ofChar(v28);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                            Runtime::method26(length(v71.clone()) as i64, v71, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v28,
                            v65,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method33(
                                v28,
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v116: Runtime::US8 = match &v104 {
                    Runtime::US8::US8_0(v104_0_0, v104_0_1, v104_0_2, v104_0_3, v104_0_4) => {
                        let v105: char = v104_0_0.clone();
                        Runtime::US8::US8_0(
                            if '\\' == (v105) { '/' } else { v105 },
                            v104_0_1.clone(),
                            v104_0_2.clone(),
                            v104_0_3.clone(),
                            v104_0_4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v104_1_0) => Runtime::US8::US8_1(v104_1_0.clone()),
                };
                match &v116 {
                    Runtime::US8::US8_0(v116_0_0, v116_0_1, v116_0_2, v116_0_3, v116_0_4) => {
                        let v0_temp: string =
                            append((v0.get().clone()), (ofChar(v116_0_0.clone())));
                        let v1_temp: string = v116_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v116_0_2.clone();
                        let v3_temp: i32 = v116_0_3.clone();
                        let v4_temp: i32 = v116_0_4.clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method34;
                    }
                    _ => (
                        v0.get().clone(),
                        v1.get().clone(),
                        v2.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method35(
        v0: string,
        v1: LrcPtr<StringBuilder>,
        v2: i32,
        v3: i32,
        v4: LrcPtr<Runtime::UH1>,
    ) -> Runtime::US8 {
        let v0: MutCell<string> = MutCell::new(v0.clone());
        let v1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1.clone());
        let v2: MutCell<i32> = MutCell::new(v2);
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<LrcPtr<Runtime::UH1>> = MutCell::new(v4.clone());
        '_method35: loop {
            break '_method35 (match v4.get().clone().as_ref() {
                Runtime::UH1::UH1_0 => {
                    Runtime::US8::US8_1(string("parsing.choice / no parsers succeeded"))
                }
                Runtime::UH1::UH1_1(v4_1_0, v4_1_1) => {
                    let v9: Runtime::US8 = (match v4.get().clone().as_ref() {
                        Runtime::UH1::UH1_1(x, _) => x.clone(),
                        _ => unreachable!(),
                    })((
                        v0.get().clone(),
                        v1.get().clone(),
                        v2.get().clone(),
                        v3.get().clone(),
                    ));
                    match &v9 {
                        Runtime::US8::US8_0(v9_0_0, v9_0_1, v9_0_2, v9_0_3, v9_0_4) => v9.clone(),
                        _ => {
                            let v0_temp: string = v0.get().clone();
                            let v1_temp: LrcPtr<StringBuilder> = v1.get().clone();
                            let v2_temp: i32 = v2.get().clone();
                            let v3_temp: i32 = v3.get().clone();
                            let v4_temp: LrcPtr<Runtime::UH1> = match v4.get().clone().as_ref() {
                                Runtime::UH1::UH1_1(_, x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone();
                            v0.set(v0_temp);
                            v1.set(v1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method35;
                        }
                    }
                }
            });
        }
    }
    pub fn method36(
        v0: string,
        v1: string,
        v2: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
        v5: string,
        v6: LrcPtr<StringBuilder>,
        v7: i32,
        v8: i32,
        v9: string,
        v10: LrcPtr<StringBuilder>,
        v11: i32,
        v12: i32,
    ) -> string {
        let v14_1: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v28: () = {
            Runtime::closure7(v14_1.clone(), string("{ "), ());
            ()
        };
        let v47: () = {
            Runtime::closure7(v14_1.clone(), string("e"), ());
            ()
        };
        let v66: () = {
            Runtime::closure7(v14_1.clone(), string(" = "), ());
            ()
        };
        let v83: () = {
            Runtime::closure7(v14_1.clone(), v0, ());
            ()
        };
        let v102: () = {
            Runtime::closure7(v14_1.clone(), string("; "), ());
            ()
        };
        let v121: () = {
            Runtime::closure7(v14_1.clone(), string("input"), ());
            ()
        };
        let v138: () = {
            Runtime::closure7(v14_1.clone(), string(" = "), ());
            ()
        };
        let v155: () = {
            Runtime::closure7(v14_1.clone(), v1, ());
            ()
        };
        let v174: () = {
            Runtime::closure7(v14_1.clone(), string(", "), ());
            ()
        };
        let v186: std::string::String = format!("{:#?}", v2);
        let v233: () = {
            Runtime::closure7(
                v14_1.clone(),
                fable_library_rust::String_::fromString(v186),
                (),
            );
            ()
        };
        let v250: () = {
            Runtime::closure7(v14_1.clone(), string("; "), ());
            ()
        };
        let v269: () = {
            Runtime::closure7(v14_1.clone(), string("rest1"), ());
            ()
        };
        let v286: () = {
            Runtime::closure7(v14_1.clone(), string(" = "), ());
            ()
        };
        let v303: () = {
            Runtime::closure7(v14_1.clone(), v5, ());
            ()
        };
        let v320: () = {
            Runtime::closure7(v14_1.clone(), string(", "), ());
            ()
        };
        let v332: std::string::String = format!("{:#?}", v6);
        let v379: () = {
            Runtime::closure7(
                v14_1.clone(),
                fable_library_rust::String_::fromString(v332),
                (),
            );
            ()
        };
        let v396: () = {
            Runtime::closure7(v14_1.clone(), string("; "), ());
            ()
        };
        let v415: () = {
            Runtime::closure7(v14_1.clone(), string("rest2"), ());
            ()
        };
        let v432: () = {
            Runtime::closure7(v14_1.clone(), string(" = "), ());
            ()
        };
        let v449: () = {
            Runtime::closure7(v14_1.clone(), v9, ());
            ()
        };
        let v466: () = {
            Runtime::closure7(v14_1.clone(), string(", "), ());
            ()
        };
        let v478: std::string::String = format!("{:#?}", v10);
        let v525: () = {
            Runtime::closure7(
                v14_1.clone(),
                fable_library_rust::String_::fromString(v478),
                (),
            );
            ()
        };
        let v544: () = {
            Runtime::closure7(v14_1.clone(), string(" }"), ());
            ()
        };
        v14_1.l0.get().clone()
    }
    pub fn method37(v0: char, v1: i64) -> bool {
        let v0: MutCell<char> = MutCell::new(v0);
        let v1: MutCell<i64> = MutCell::new(v1);
        '_method37: loop {
            break '_method37 (if (v1.get().clone()) >= 3_i64 {
                false
            } else {
                let v15_1: Runtime::US10 = if (v1.get().clone()) == 0_i64 {
                    Runtime::US10::US10_0('\"')
                } else {
                    let v5: i64 = (v1.get().clone()) - 1_i64;
                    if (v5) == 0_i64 {
                        Runtime::US10::US10_0('\'')
                    } else {
                        let v8: i64 = (v5) - 1_i64;
                        if (v8) == 0_i64 {
                            Runtime::US10::US10_0(' ')
                        } else {
                            let v11: i64 = (v8) - 1_i64;
                            Runtime::US10::US10_1
                        }
                    }
                };
                if (v0.get().clone())
                    == (match &v15_1 {
                        Runtime::US10::US10_0(v15_1_0_0) => match &v15_1 {
                            Runtime::US10::US10_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    })
                {
                    true
                } else {
                    let v0_temp: char = v0.get().clone();
                    let v1_temp: i64 = (v1.get().clone()) + 1_i64;
                    v0.set(v0_temp);
                    v1.set(v1_temp);
                    continue '_method37;
                }
            });
        }
    }
    pub fn method38(
        v0: string,
        v1: string,
        v2: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> (string, string, LrcPtr<StringBuilder>, i32, i32) {
        let v0: MutCell<string> = MutCell::new(v0.clone());
        let v1: MutCell<string> = MutCell::new(v1.clone());
        let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method38: loop {
            break '_method38 ({
                let v112: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method31(
                            toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v32_1: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method37(v32_1, 0_i64)) == false {
                        let v69: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v75: string = ofChar(v32_1);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                            Runtime::method26(length(v75.clone()) as i64, v75, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v32_1,
                            v69,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method33(
                                v32_1,
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v124: Runtime::US8 = match &v112 {
                    Runtime::US8::US8_0(v112_0_0, v112_0_1, v112_0_2, v112_0_3, v112_0_4) => {
                        let v113: char = v112_0_0.clone();
                        Runtime::US8::US8_0(
                            if '\\' == (v113) { '/' } else { v113 },
                            v112_0_1.clone(),
                            v112_0_2.clone(),
                            v112_0_3.clone(),
                            v112_0_4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v112_1_0) => Runtime::US8::US8_1(v112_1_0.clone()),
                };
                match &v124 {
                    Runtime::US8::US8_0(v124_0_0, v124_0_1, v124_0_2, v124_0_3, v124_0_4) => {
                        let v0_temp: string =
                            append((v0.get().clone()), (ofChar(v124_0_0.clone())));
                        let v1_temp: string = v124_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v124_0_2.clone();
                        let v3_temp: i32 = v124_0_3.clone();
                        let v4_temp: i32 = v124_0_4.clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method38;
                    }
                    _ => (
                        v0.get().clone(),
                        v1.get().clone(),
                        v2.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method39(v0: string) -> string {
        let v2: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v16_1: () = {
            Runtime::closure7(v2.clone(), string("{ "), ());
            ()
        };
        let v35_1: () = {
            Runtime::closure7(v2.clone(), string("input"), ());
            ()
        };
        let v54: () = {
            Runtime::closure7(v2.clone(), string(" = "), ());
            ()
        };
        let v71: () = {
            Runtime::closure7(v2.clone(), v0, ());
            ()
        };
        let v90: () = {
            Runtime::closure7(v2.clone(), string(" }"), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method40(v0: string, v1: i32) -> i32 {
        let v0: MutCell<string> = MutCell::new(v0.clone());
        let v1: MutCell<i32> = MutCell::new(v1);
        '_method40: loop {
            break '_method40 (if (v1.get().clone()) >= (length(v0.get().clone())) {
                v1.get().clone()
            } else {
                if ' ' == (getCharAt(v0.get().clone(), v1.get().clone())) {
                    let v0_temp: string = v0.get().clone();
                    let v1_temp: i32 = (v1.get().clone()) + 1_i32;
                    v0.set(v0_temp);
                    v1.set(v1_temp);
                    continue '_method40;
                } else {
                    v1.get().clone()
                }
            });
        }
    }
    pub fn method41(v0: LrcPtr<StringBuilder>, v1: i32, v2: i32) -> string {
        let v4: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v18: () = {
            Runtime::closure7(v4.clone(), string("{ "), ());
            ()
        };
        let v37: () = {
            Runtime::closure7(v4.clone(), string("s"), ());
            ()
        };
        let v56: () = {
            Runtime::closure7(v4.clone(), string(" = "), ());
            ()
        };
        let v68: std::string::String = format!("{:#?}", v0);
        let v115: () = {
            Runtime::closure7(v4.clone(), fable_library_rust::String_::fromString(v68), ());
            ()
        };
        let v134: () = {
            Runtime::closure7(v4.clone(), string(" }"), ());
            ()
        };
        v4.l0.get().clone()
    }
    pub fn method42(
        v0: string,
        v1: string,
        v2: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> (string, string, LrcPtr<StringBuilder>, i32, i32) {
        let v0: MutCell<string> = MutCell::new(v0.clone());
        let v1: MutCell<string> = MutCell::new(v1.clone());
        let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method42: loop {
            break '_method42 ({
                let v64: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.any_char / unexpected end of input / "),
                        (Runtime::method41(v2.get().clone(), v3.get().clone(), v4.get().clone())),
                    ))
                } else {
                    let v14_1: char = getCharAt(v1.get().clone(), 0_i32);
                    let v48: string = getSlice(
                        v1.get().clone(),
                        Some(1_i32),
                        Some((length(v1.get().clone())) - 1_i32),
                    );
                    let v54: string = ofChar(v14_1);
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                        Runtime::method26(length(v54.clone()) as i64, v54, 0_i64),
                        v2.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    );
                    Runtime::US8::US8_0(
                        v14_1,
                        v48,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                };
                match &v64 {
                    Runtime::US8::US8_0(v64_0_0, v64_0_1, v64_0_2, v64_0_3, v64_0_4) => {
                        let v0_temp: string = append((v0.get().clone()), (ofChar(v64_0_0.clone())));
                        let v1_temp: string = v64_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v64_0_2.clone();
                        let v3_temp: i32 = v64_0_3.clone();
                        let v4_temp: i32 = v64_0_4.clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method42;
                    }
                    _ => (
                        v0.get().clone(),
                        v1.get().clone(),
                        v2.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method23(v0: string) -> Runtime::US7 {
        let _v0: MutCell<Option<Option<string>>> = MutCell::new(None::<Option<string>>);
        _v0.set(Some(Some(v0)));
        {
            let v10: string = defaultValue(
                string(""),
                match &_v0.get().clone() {
                    None => panic!("{}", string("optionm\'.of_obj / _v0=None"),),
                    Some(_v0_0_0) => _v0_0_0.clone(),
                },
            );
            let v16_1: LrcPtr<StringBuilder> = StringBuilder::_ctor__Z721C83C5(Runtime::method24());
            fn v19(arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US8 {
                Runtime::closure14((), arg10_0040)
            }
            fn v20(arg10_0040_1: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US8 {
                Runtime::closure16((), arg10_0040_1)
            }
            let v24: Runtime::US8 = Runtime::method30(
                v10.clone(),
                v16_1.clone(),
                LrcPtr::new(Runtime::UH1::UH1_1(
                    Func1::from(v19),
                    LrcPtr::new(Runtime::UH1::UH1_1(
                        Func1::from(v20),
                        LrcPtr::new(Runtime::UH1::UH1_0),
                    )),
                )),
            );
            let v208: Runtime::US9 = match &v24 {
                Runtime::US8::US8_0(v24_0_0, v24_0_1, v24_0_2, v24_0_3, v24_0_4) => {
                    let v29: i32 = v24_0_4.clone();
                    let v28: i32 = v24_0_3.clone();
                    let v27: LrcPtr<StringBuilder> = v24_0_2.clone();
                    let v26: string = v24_0_1.clone();
                    let v129: Runtime::US8 = if string("") == (v26.clone()) {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected end of input / "),
                            (Runtime::method31(
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                v27.clone(),
                                v28,
                                v29,
                            )),
                        ))
                    } else {
                        let v53: char = getCharAt(v26.clone(), 0_i32);
                        if (Runtime::method32(v53, 0_i64)) == false {
                            let v90: string = getSlice(
                                v26.clone(),
                                Some(1_i32),
                                Some((length(v26.clone())) - 1_i32),
                            );
                            let v96: string = ofChar(v53);
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                                Runtime::method26(length(v96.clone()) as i64, v96, 0_i64),
                                v27.clone(),
                                v28,
                                v29,
                            );
                            Runtime::US8::US8_0(
                                v53,
                                v90,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        } else {
                            Runtime::US8::US8_1(append(
                                string("parsing.none_of / unexpected char / "),
                                (Runtime::method33(
                                    v53,
                                    toArray(ofArray(new_array(&['\"', '\'']))),
                                    v27.clone(),
                                    v28,
                                    v29,
                                )),
                            ))
                        }
                    };
                    let v141: Runtime::US8 = match &v129 {
                        Runtime::US8::US8_0(v129_0_0, v129_0_1, v129_0_2, v129_0_3, v129_0_4) => {
                            let v130: char = v129_0_0.clone();
                            Runtime::US8::US8_0(
                                if '\\' == (v130) { '/' } else { v130 },
                                v129_0_1.clone(),
                                v129_0_2.clone(),
                                v129_0_3.clone(),
                                v129_0_4.clone(),
                            )
                        }
                        Runtime::US8::US8_1(v129_1_0) => Runtime::US8::US8_1(v129_1_0.clone()),
                    };
                    let v161: Runtime::US9 = match &v141 {
                        Runtime::US8::US8_0(v141_0_0, v141_0_1, v141_0_2, v141_0_3, v141_0_4) => {
                            let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method34(
                                    ofChar(v141_0_0.clone()),
                                    v141_0_1.clone(),
                                    v141_0_2.clone(),
                                    v141_0_3.clone(),
                                    v141_0_4.clone(),
                                );
                            Runtime::US9::US9_0(
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                                patternInput_1.3.clone(),
                                patternInput_1.4.clone(),
                            )
                        }
                        Runtime::US8::US8_1(v141_1_0) => Runtime::US9::US9_1(v141_1_0.clone()),
                    };
                    let v171: Runtime::US9 = match &v161 {
                        Runtime::US9::US9_0(v161_0_0, v161_0_1, v161_0_2, v161_0_3, v161_0_4) => {
                            Runtime::US9::US9_0(
                                v161_0_0.clone(),
                                v161_0_1.clone(),
                                v161_0_2.clone(),
                                v161_0_3.clone(),
                                v161_0_4.clone(),
                            )
                        }
                        _ => Runtime::US9::US9_0(string(""), v26.clone(), v27.clone(), v28, v29),
                    };
                    match &v171 {
                        Runtime::US9::US9_0(v171_0_0, v171_0_1, v171_0_2, v171_0_3, v171_0_4) => {
                            let v176: i32 = v171_0_4.clone();
                            let v175: i32 = v171_0_3.clone();
                            let v174: LrcPtr<StringBuilder> = v171_0_2.clone();
                            let v173: string = v171_0_1.clone();
                            let v180: Runtime::US8 = Runtime::method35(
                                v173.clone(),
                                v174.clone(),
                                v175,
                                v176,
                                LrcPtr::new(Runtime::UH1::UH1_1(
                                    Func1::from(v19),
                                    LrcPtr::new(Runtime::UH1::UH1_1(
                                        Func1::from(v20),
                                        LrcPtr::new(Runtime::UH1::UH1_0),
                                    )),
                                )),
                            );
                            match &v180 {
                                Runtime::US8::US8_0(
                                    v180_0_0,
                                    v180_0_1,
                                    v180_0_2,
                                    v180_0_3,
                                    v180_0_4,
                                ) => Runtime::US9::US9_0(
                                    v171_0_0.clone(),
                                    v180_0_1.clone(),
                                    v180_0_2.clone(),
                                    v180_0_3.clone(),
                                    v180_0_4.clone(),
                                ),
                                Runtime::US8::US8_1(v180_1_0) => Runtime::US9::US9_1(append(
                                    string("parsing.between / expected closing delimiter / "),
                                    (Runtime::method36(
                                        v180_1_0.clone(),
                                        v10.clone(),
                                        v16_1.clone(),
                                        1_i32,
                                        1_i32,
                                        v26.clone(),
                                        v27.clone(),
                                        v28,
                                        v29,
                                        v173.clone(),
                                        v174.clone(),
                                        v175,
                                        v176,
                                    )),
                                )),
                            }
                        }
                        _ => Runtime::US9::US9_1(string("parsing.between / expected content")),
                    }
                }
                Runtime::US8::US8_1(v24_1_0) => Runtime::US9::US9_1(v24_1_0.clone()),
            };
            let v440: Runtime::US9 = match &v208 {
                Runtime::US9::US9_0(v208_0_0, v208_0_1, v208_0_2, v208_0_3, v208_0_4) => {
                    v208.clone()
                }
                _ => {
                    let v328: Runtime::US8 = if string("") == (v10.clone()) {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected end of input / "),
                            (Runtime::method31(
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                v16_1.clone(),
                                1_i32,
                                1_i32,
                            )),
                        ))
                    } else {
                        let v244: char = getCharAt(v10.clone(), 0_i32);
                        if (Runtime::method37(v244, 0_i64)) == false {
                            let v281: string = getSlice(
                                v10.clone(),
                                Some(1_i32),
                                Some((length(v10.clone())) - 1_i32),
                            );
                            let v287: string = ofChar(v244);
                            let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method27(
                                    Runtime::method26(length(v287.clone()) as i64, v287, 0_i64),
                                    v16_1.clone(),
                                    1_i32,
                                    1_i32,
                                );
                            Runtime::US8::US8_0(
                                v244,
                                v281,
                                patternInput_2.0.clone(),
                                patternInput_2.1.clone(),
                                patternInput_2.2.clone(),
                            )
                        } else {
                            Runtime::US8::US8_1(append(
                                string("parsing.none_of / unexpected char / "),
                                (Runtime::method33(
                                    v244,
                                    toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                    v16_1.clone(),
                                    1_i32,
                                    1_i32,
                                )),
                            ))
                        }
                    };
                    let v340: Runtime::US8 = match &v328 {
                        Runtime::US8::US8_0(v328_0_0, v328_0_1, v328_0_2, v328_0_3, v328_0_4) => {
                            let v329: char = v328_0_0.clone();
                            Runtime::US8::US8_0(
                                if '\\' == (v329) { '/' } else { v329 },
                                v328_0_1.clone(),
                                v328_0_2.clone(),
                                v328_0_3.clone(),
                                v328_0_4.clone(),
                            )
                        }
                        Runtime::US8::US8_1(v328_1_0) => Runtime::US8::US8_1(v328_1_0.clone()),
                    };
                    let v360: Runtime::US9 = match &v340 {
                        Runtime::US8::US8_0(v340_0_0, v340_0_1, v340_0_2, v340_0_3, v340_0_4) => {
                            let patternInput_3: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method38(
                                    ofChar(v340_0_0.clone()),
                                    v340_0_1.clone(),
                                    v340_0_2.clone(),
                                    v340_0_3.clone(),
                                    v340_0_4.clone(),
                                );
                            Runtime::US9::US9_0(
                                patternInput_3.0.clone(),
                                patternInput_3.1.clone(),
                                patternInput_3.2.clone(),
                                patternInput_3.3.clone(),
                                patternInput_3.4.clone(),
                            )
                        }
                        Runtime::US8::US8_1(v340_1_0) => Runtime::US9::US9_1(v340_1_0.clone()),
                    };
                    match &v360 {
                        Runtime::US9::US9_0(v360_0_0, v360_0_1, v360_0_2, v360_0_3, v360_0_4) => {
                            v360.clone()
                        }
                        _ => {
                            let v378: Runtime::US11 = if (length(v10.clone())) == 0_i32 {
                                Runtime::US11::US11_0(v10.clone(), v16_1.clone(), 1_i32, 1_i32)
                            } else {
                                Runtime::US11::US11_1(append(
                                    string("parsing.eof / expected end of input / "),
                                    (Runtime::method39(v10.clone())),
                                ))
                            };
                            let v387: Runtime::US9 = match &v378 {
                                Runtime::US11::US11_0(v378_0_0, v378_0_1, v378_0_2, v378_0_3) => {
                                    Runtime::US9::US9_0(
                                        string(""),
                                        v378_0_0.clone(),
                                        v378_0_1.clone(),
                                        v378_0_2.clone(),
                                        v378_0_3.clone(),
                                    )
                                }
                                Runtime::US11::US11_1(v378_1_0) => {
                                    Runtime::US9::US9_1(v378_1_0.clone())
                                }
                            };
                            match &v387 {
                                Runtime::US9::US9_0(
                                    v387_0_0,
                                    v387_0_1,
                                    v387_0_2,
                                    v387_0_3,
                                    v387_0_4,
                                ) => {
                                    let v389: string = v387_0_1.clone();
                                    Runtime::US9::US9_0(
                                        v387_0_0.clone(),
                                        getSlice(
                                            v389.clone(),
                                            Some(Runtime::method40(v389.clone(), 0_i32)),
                                            Some((length(v389)) - 1_i32),
                                        ),
                                        v387_0_2.clone(),
                                        v387_0_3.clone(),
                                        v387_0_4.clone(),
                                    )
                                }
                                Runtime::US9::US9_1(v387_1_0) => {
                                    Runtime::US9::US9_1(v387_1_0.clone())
                                }
                            }
                        }
                    }
                }
            };
            let v732: Runtime::US12 = match &v440 {
                Runtime::US9::US9_0(v440_0_0, v440_0_1, v440_0_2, v440_0_3, v440_0_4) => {
                    let v445: i32 = v440_0_4.clone();
                    let v444: i32 = v440_0_3.clone();
                    let v443: LrcPtr<StringBuilder> = v440_0_2.clone();
                    let v442: string = v440_0_1.clone();
                    let v605: Runtime::US8 = if string("") == (v442.clone()) {
                        Runtime::US8::US8_1(append(
                            string("parsing.p_char / unexpected end of input / "),
                            (Runtime::method25(' ', v443.clone(), v444, v445)),
                        ))
                    } else {
                        let v456: char = getCharAt(v442.clone(), 0_i32);
                        if (v456) == ' ' {
                            let v491: string = getSlice(
                                v442.clone(),
                                Some(1_i32),
                                Some((length(v442.clone())) - 1_i32),
                            );
                            let v497: string = ofChar(v456);
                            let patternInput_4: (LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method27(
                                    Runtime::method26(length(v497.clone()) as i64, v497, 0_i64),
                                    v443.clone(),
                                    v444,
                                    v445,
                                );
                            Runtime::US8::US8_0(
                                v456,
                                v491,
                                patternInput_4.0.clone(),
                                patternInput_4.1.clone(),
                                patternInput_4.2.clone(),
                            )
                        } else {
                            let v514: i32 = (indexOf(v442.clone(), string("\n"))) - 1_i32;
                            let v552: string = getSlice(
                                v442.clone(),
                                Some(0_i32),
                                Some(
                                    (if -2_i32 == (v514) {
                                        (length(v442.clone())) + 1_i32
                                    } else {
                                        (v514) + 1_i32
                                    }) - 1_i32,
                                ),
                            );
                            Runtime::US8::US8_1(append(
                                (append(
                                    (append(
                                        (append(
                                            (append(
                                                (append(
                                                    (append(
                                                        string("parsing.p_char / "),
                                                        (Runtime::method28(' ', v444, v445)),
                                                    )),
                                                    string("\n"),
                                                )),
                                                (toString(v443.clone())),
                                            )),
                                            (v552),
                                        )),
                                        string("\n"),
                                    )),
                                    (append(
                                        ((Runtime::method29((v445) - 1_i32, 0_i32))(string(""))),
                                        string("^"),
                                    )),
                                )),
                                string("\n"),
                            ))
                        }
                    };
                    let v617: Runtime::US13 = match &v605 {
                        Runtime::US8::US8_0(v605_0_0, v605_0_1, v605_0_2, v605_0_3, v605_0_4) => {
                            Runtime::US13::US13_0(
                                Runtime::US10::US10_0(v605_0_0.clone()),
                                v605_0_1.clone(),
                                v605_0_2.clone(),
                                v605_0_3.clone(),
                                v605_0_4.clone(),
                            )
                        }
                        _ => Runtime::US13::US13_0(
                            Runtime::US10::US10_1,
                            v442.clone(),
                            v443.clone(),
                            v444,
                            v445,
                        ),
                    };
                    let v706: Runtime::US9 = match &v617 {
                        Runtime::US13::US13_0(v617_0_0, v617_0_1, v617_0_2, v617_0_3, v617_0_4) => {
                            let v622: i32 = v617_0_4.clone();
                            let v621: i32 = v617_0_3.clone();
                            let v620: LrcPtr<StringBuilder> = v617_0_2.clone();
                            let v619: string = v617_0_1.clone();
                            let v682: Runtime::US8 = if string("") == (v619.clone()) {
                                Runtime::US8::US8_1(append(
                                    string("parsing.any_char / unexpected end of input / "),
                                    (Runtime::method41(v620.clone(), v621, v622)),
                                ))
                            } else {
                                let v632: char = getCharAt(v619.clone(), 0_i32);
                                let v666: string = getSlice(
                                    v619.clone(),
                                    Some(1_i32),
                                    Some((length(v619)) - 1_i32),
                                );
                                let v672: string = ofChar(v632);
                                let patternInput_5: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method27(
                                        Runtime::method26(length(v672.clone()) as i64, v672, 0_i64),
                                        v620,
                                        v621,
                                        v622,
                                    );
                                Runtime::US8::US8_0(
                                    v632,
                                    v666,
                                    patternInput_5.0.clone(),
                                    patternInput_5.1.clone(),
                                    patternInput_5.2.clone(),
                                )
                            };
                            match &v682 {
                                Runtime::US8::US8_0(
                                    v682_0_0,
                                    v682_0_1,
                                    v682_0_2,
                                    v682_0_3,
                                    v682_0_4,
                                ) => {
                                    let patternInput_6: (
                                        string,
                                        string,
                                        LrcPtr<StringBuilder>,
                                        i32,
                                        i32,
                                    ) = Runtime::method42(
                                        ofChar(v682_0_0.clone()),
                                        v682_0_1.clone(),
                                        v682_0_2.clone(),
                                        v682_0_3.clone(),
                                        v682_0_4.clone(),
                                    );
                                    Runtime::US9::US9_0(
                                        patternInput_6.0.clone(),
                                        patternInput_6.1.clone(),
                                        patternInput_6.2.clone(),
                                        patternInput_6.3.clone(),
                                        patternInput_6.4.clone(),
                                    )
                                }
                                Runtime::US8::US8_1(v682_1_0) => {
                                    Runtime::US9::US9_1(v682_1_0.clone())
                                }
                            }
                        }
                        Runtime::US13::US13_1(v617_1_0) => Runtime::US9::US9_1(v617_1_0.clone()),
                    };
                    let v718: Runtime::US14 = match &v706 {
                        Runtime::US9::US9_0(v706_0_0, v706_0_1, v706_0_2, v706_0_3, v706_0_4) => {
                            Runtime::US14::US14_0(
                                Runtime::US5::US5_0(v706_0_0.clone()),
                                v706_0_1.clone(),
                                v706_0_2.clone(),
                                v706_0_3.clone(),
                                v706_0_4.clone(),
                            )
                        }
                        _ => Runtime::US14::US14_0(
                            Runtime::US5::US5_1,
                            v442.clone(),
                            v443.clone(),
                            v444,
                            v445,
                        ),
                    };
                    match &v718 {
                        Runtime::US14::US14_0(v718_0_0, v718_0_1, v718_0_2, v718_0_3, v718_0_4) => {
                            Runtime::US12::US12_0(
                                v440_0_0.clone(),
                                v718_0_0.clone(),
                                v718_0_1.clone(),
                                v718_0_2.clone(),
                                v718_0_3.clone(),
                                v718_0_4.clone(),
                            )
                        }
                        Runtime::US14::US14_1(v718_1_0) => Runtime::US12::US12_1(v718_1_0.clone()),
                    }
                }
                Runtime::US9::US9_1(v440_1_0) => Runtime::US12::US12_1(v440_1_0.clone()),
            };
            match &v732 {
                Runtime::US12::US12_0(
                    v732_0_0,
                    v732_0_1,
                    v732_0_2,
                    v732_0_3,
                    v732_0_4,
                    v732_0_5,
                ) => Runtime::US7::US7_0(v732_0_0.clone(), v732_0_1.clone()),
                Runtime::US12::US12_1(v732_1_0) => Runtime::US7::US7_1(v732_1_0.clone()),
            }
        }
    }
    pub fn method43() -> string {
        let v8: string = Runtime::method12(getCharAt(toLower(string("Debug")), 0_i32));
        let v27: &str = inline_colorization::color_bright_blue;
        let v34_1: &str = &*v8;
        let v65: &str = inline_colorization::color_reset;
        let v67: std::string::String = format!("{}{}{}", v27, v34_1, v65);
        fable_library_rust::String_::fromString(v67)
    }
    pub fn method45(
        v0: string,
        v1: Runtime::US5,
        v2: string,
        v3: Option<CancellationToken>,
        v4: Array<(string, string)>,
        v5: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v6: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v7: bool,
        v8: Option<string>,
    ) -> string {
        let v10: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v24: () = {
            Runtime::closure7(v10.clone(), string("{ "), ());
            ()
        };
        let v43: () = {
            Runtime::closure7(v10.clone(), string("file_name"), ());
            ()
        };
        let v62: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v79: () = {
            Runtime::closure7(v10.clone(), v0, ());
            ()
        };
        let v98: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v117: () = {
            Runtime::closure7(v10.clone(), string("arguments"), ());
            ()
        };
        let v134: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v155: () = {
            Runtime::closure7(v10.clone(), sprintf!("{:?}", v1), ());
            ()
        };
        let v172: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v191: () = {
            Runtime::closure7(v10.clone(), string("options"), ());
            ()
        };
        let v208: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v225: () = {
            Runtime::closure7(v10.clone(), string("{ "), ());
            ()
        };
        let v244: () = {
            Runtime::closure7(v10.clone(), string("command"), ());
            ()
        };
        let v261: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v278: () = {
            Runtime::closure7(v10.clone(), v2, ());
            ()
        };
        let v295: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v314: () = {
            Runtime::closure7(v10.clone(), string("cancellation_token"), ());
            ()
        };
        let v331: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v343: std::string::String = format!("{:#?}", v3);
        let v390: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v343),
                (),
            );
            ()
        };
        let v407: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v426: () = {
            Runtime::closure7(v10.clone(), string("environment_variables"), ());
            ()
        };
        let v443: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v464: () = {
            Runtime::closure7(v10.clone(), sprintf!("{:?}", v4), ());
            ()
        };
        let v481: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v500: () = {
            Runtime::closure7(v10.clone(), string("on_line"), ());
            ()
        };
        let v517: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v529: std::string::String = format!("{:#?}", v5);
        let v576: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v529),
                (),
            );
            ()
        };
        let v593: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v612: () = {
            Runtime::closure7(v10.clone(), string("stdin"), ());
            ()
        };
        let v629: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v641: std::string::String = format!("{:#?}", v6);
        let v688: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v641),
                (),
            );
            ()
        };
        let v705: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v724: () = {
            Runtime::closure7(v10.clone(), string("trace"), ());
            ()
        };
        let v741: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v761: () = {
            Runtime::closure7(
                v10.clone(),
                if v7 { string("true") } else { string("false") },
                (),
            );
            ()
        };
        let v778: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v797: () = {
            Runtime::closure7(v10.clone(), string("working_directory"), ());
            ()
        };
        let v814: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v826: std::string::String = format!("{:#?}", v8);
        let v873: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v826),
                (),
            );
            ()
        };
        let v892: () = {
            Runtime::closure7(v10.clone(), string(" }"), ());
            ()
        };
        let v909: () = {
            Runtime::closure7(v10.clone(), string(" }"), ());
            ()
        };
        v10.l0.get().clone()
    }
    pub fn method44(
        v0: LrcPtr<Runtime::Mut0>,
        v1: LrcPtr<Runtime::Mut1>,
        v2: LrcPtr<Runtime::Mut2>,
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
        v14_1: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v15_1: bool,
        v16_1: Option<string>,
    ) -> string {
        let v17: string = Runtime::method45(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1);
        Runtime::method17(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("runtime.execute_with_options_async"),
                )),
                string(" / "),
            )),
            (v17),
        ))
    }
    pub fn closure17(
        v0: string,
        v1: Option<CancellationToken>,
        v2: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
        v7: Runtime::US5,
        v8: string,
        unitVar: (),
    ) {
        fn v24() {
            Runtime::closure0((), ());
        }
        let v25: () = {
            v24();
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
        let v66: Runtime::US0 = (patternInput.4.clone()).l0.get().clone();
        let v306: Runtime::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            1_i32
                >= (find(
                    v66,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Runtime::US0::US0_0, 0_i32)),
                        LrcPtr::new((Runtime::US0::US0_1, 1_i32)),
                        LrcPtr::new((Runtime::US0::US0_2, 2_i32)),
                        LrcPtr::new((Runtime::US0::US0_3, 3_i32)),
                        LrcPtr::new((Runtime::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            Runtime::US6::US6_1
        } else {
            let v89: () = {
                v24();
                ()
            };
            let patternInput_1: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v117: Option<i64> = patternInput_1.5.clone();
            let v116: LrcPtr<Runtime::Mut4> = patternInput_1.4.clone();
            let v115: LrcPtr<Runtime::Mut3> = patternInput_1.3.clone();
            let v114: LrcPtr<Runtime::Mut2> = patternInput_1.2.clone();
            let v113: LrcPtr<Runtime::Mut1> = patternInput_1.1.clone();
            let v112: LrcPtr<Runtime::Mut0> = patternInput_1.0.clone();
            let v132: string = Runtime::method44(
                v112.clone(),
                v113.clone(),
                v114.clone(),
                v115.clone(),
                v116.clone(),
                v117.clone(),
                Runtime::method7(v112, v113, v114, v115, v116, v117),
                Runtime::method43(),
                v8,
                v7,
                v0,
                v1,
                v2,
                v3,
                v4,
                v5,
                v6,
            );
            let v148: () = {
                v24();
                ()
            };
            let patternInput_2: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v172: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v171: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v193: () = {
                Runtime::closure8(v171.clone(), ());
                ()
            };
            println!("{}", v132.clone());
            (v172.l0.get().clone())(v132);
            Runtime::US6::US6_0(
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
    pub fn method46(
        v0: string,
        v1: Option<CancellationToken>,
        v2: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
    ) -> Array<(string, string)> {
        v2
    }
    pub fn method47(v0: i32, v1: LrcPtr<Runtime::Mut5>) -> bool {
        (v1.l0.get().clone()) < (v0)
    }
    pub fn method50(v0: bool) -> string {
        unbox::<string>(fable_library_rust::Native_::getZero())
    }
    pub fn closure19(unitVar: (), v0: Func1<(i32, string, bool), Arc<Async<()>>>) -> Runtime::US15 {
        Runtime::US15::US15_0(v0)
    }
    pub fn method51() -> Func1<Func1<(i32, string, bool), Arc<Async<()>>>, Runtime::US15> {
        Func1::new(move |v: Func1<(i32, string, bool), Arc<Async<()>>>| Runtime::closure19((), v))
    }
    pub fn method52(v0: bool) -> i32 {
        unbox::<i32>(fable_library_rust::Native_::getZero())
    }
    pub fn method53() -> string {
        let v8: string = Runtime::method12(getCharAt(toLower(string("Verbose")), 0_i32));
        let v27: &str = inline_colorization::color_bright_black;
        let v34_1: &str = &*v8;
        let v65: &str = inline_colorization::color_reset;
        let v67: std::string::String = format!("{}{}{}", v27, v34_1, v65);
        fable_library_rust::String_::fromString(v67)
    }
    pub fn method54(
        v0: LrcPtr<Runtime::Mut0>,
        v1: LrcPtr<Runtime::Mut1>,
        v2: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
    ) -> string {
        let v9: string = Runtime::method16();
        Runtime::method17(append(
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
            (v9),
        ))
    }
    pub fn closure20(v0: string, unitVar: ()) {
        fn v16_1() {
            Runtime::closure0((), ());
        }
        let v17: () = {
            v16_1();
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
        let v58: Runtime::US0 = (patternInput.4.clone()).l0.get().clone();
        let v301: Runtime::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            0_i32
                >= (find(
                    v58,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Runtime::US0::US0_0, 0_i32)),
                        LrcPtr::new((Runtime::US0::US0_1, 1_i32)),
                        LrcPtr::new((Runtime::US0::US0_2, 2_i32)),
                        LrcPtr::new((Runtime::US0::US0_3, 3_i32)),
                        LrcPtr::new((Runtime::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            Runtime::US6::US6_1
        } else {
            let v81: () = {
                v16_1();
                ()
            };
            let patternInput_1: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v109: Option<i64> = patternInput_1.5.clone();
            let v108: LrcPtr<Runtime::Mut4> = patternInput_1.4.clone();
            let v107: LrcPtr<Runtime::Mut3> = patternInput_1.3.clone();
            let v106: LrcPtr<Runtime::Mut2> = patternInput_1.2.clone();
            let v105: LrcPtr<Runtime::Mut1> = patternInput_1.1.clone();
            let v104: LrcPtr<Runtime::Mut0> = patternInput_1.0.clone();
            let v127: string = if (v0.clone()) == string("") {
                string("")
            } else {
                Runtime::method54(
                    v104.clone(),
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    Runtime::method7(v104, v105, v106, v107, v108, v109),
                    Runtime::method53(),
                    v0,
                )
            };
            let v143: () = {
                v16_1();
                ()
            };
            let patternInput_2: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v167: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v166: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v188: () = {
                Runtime::closure8(v166.clone(), ());
                ()
            };
            println!("{}", v127.clone());
            (v167.l0.get().clone())(v127);
            Runtime::US6::US6_0(
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
    pub fn method49(
        v0: string,
        v1: Option<CancellationToken>,
        v2: Array<(string, string)>,
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
    pub fn method48(
        v0: string,
        v1: Option<CancellationToken>,
        v2: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
        v7: bool,
        v8: LrcPtr<ConcurrentStack_1<string>>,
        v9: bool,
        v10: bool,
    ) -> Arc<Async<()>> {
        Runtime::method49(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
    }
    pub fn closure18(
        v0: string,
        v1: Option<CancellationToken>,
        v2: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
        v7: bool,
        v8: LrcPtr<ConcurrentStack_1<string>>,
        v9: bool,
        v10: bool,
    ) {
        let v11: Arc<Async<()>> = Runtime::method48(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10);
        fable_library_rust::Native_::getZero::<()>();
        ()
    }
    pub fn closure21(unitVar: (), v0: CancellationToken) -> Runtime::US16 {
        Runtime::US16::US16_0(v0)
    }
    pub fn method55() -> Func1<CancellationToken, Runtime::US16> {
        Func1::new(move |v: CancellationToken| Runtime::closure21((), v))
    }
    pub fn method56(v0: CancellationToken) -> Arc<Async<CancellationToken>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method57(v0: bool) -> bool {
        unbox::<bool>(fable_library_rust::Native_::getZero())
    }
    pub fn method58(v0: bool) {
        ();
    }
    pub fn closure22(v0: bool, unitVar: ()) {
        if (Runtime::method57(v0)) == false {
            Runtime::method58(v0);
        };
    }
    pub fn method61(v0: LrcPtr<TaskCanceledException>) -> string {
        let v2: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v16_1: () = {
            Runtime::closure7(v2.clone(), string("{ "), ());
            ()
        };
        let v35_1: () = {
            Runtime::closure7(v2.clone(), string("ex"), ());
            ()
        };
        let v54: () = {
            Runtime::closure7(v2.clone(), string(" = "), ());
            ()
        };
        let v66: std::string::String = format!("{:#?}", v0);
        let v113: () = {
            Runtime::closure7(v2.clone(), fable_library_rust::String_::fromString(v66), ());
            ()
        };
        let v132: () = {
            Runtime::closure7(v2.clone(), string(" }"), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method60(
        v0: LrcPtr<Runtime::Mut0>,
        v1: LrcPtr<Runtime::Mut1>,
        v2: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: LrcPtr<TaskCanceledException>,
    ) -> string {
        let v9: string = Runtime::method61(v8);
        Runtime::method17(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("runtime.execute_with_options_async / WaitForExitAsync"),
                )),
                string(" / "),
            )),
            (v9),
        ))
    }
    pub fn closure23(v0: LrcPtr<TaskCanceledException>, unitVar: ()) {
        fn v16_1() {
            Runtime::closure0((), ());
        }
        let v17: () = {
            v16_1();
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
        let v58: Runtime::US0 = (patternInput.4.clone()).l0.get().clone();
        let v298: Runtime::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            3_i32
                >= (find(
                    v58,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Runtime::US0::US0_0, 0_i32)),
                        LrcPtr::new((Runtime::US0::US0_1, 1_i32)),
                        LrcPtr::new((Runtime::US0::US0_2, 2_i32)),
                        LrcPtr::new((Runtime::US0::US0_3, 3_i32)),
                        LrcPtr::new((Runtime::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            Runtime::US6::US6_1
        } else {
            let v81: () = {
                v16_1();
                ()
            };
            let patternInput_1: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v109: Option<i64> = patternInput_1.5.clone();
            let v108: LrcPtr<Runtime::Mut4> = patternInput_1.4.clone();
            let v107: LrcPtr<Runtime::Mut3> = patternInput_1.3.clone();
            let v106: LrcPtr<Runtime::Mut2> = patternInput_1.2.clone();
            let v105: LrcPtr<Runtime::Mut1> = patternInput_1.1.clone();
            let v104: LrcPtr<Runtime::Mut0> = patternInput_1.0.clone();
            let v124: string = Runtime::method60(
                v104.clone(),
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                Runtime::method7(v104, v105, v106, v107, v108, v109),
                Runtime::method11(),
                v0,
            );
            let v140: () = {
                v16_1();
                ()
            };
            let patternInput_2: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v164: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v163: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v185: () = {
                Runtime::closure8(v163.clone(), ());
                ()
            };
            println!("{}", v124.clone());
            (v164.l0.get().clone())(v124);
            Runtime::US6::US6_0(
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
    pub fn method59(
        v0: bool,
        v1: LrcPtr<ConcurrentStack_1<string>>,
        v2: CancellationToken,
    ) -> Arc<Async<i32>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method62() -> string {
        string("\n")
    }
    pub fn method64(
        v0: i32,
        v1: i32,
        v2: string,
        v3: Option<CancellationToken>,
        v4: Array<(string, string)>,
        v5: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v6: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v7: bool,
        v8: Option<string>,
    ) -> string {
        let v10: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v24: () = {
            Runtime::closure7(v10.clone(), string("{ "), ());
            ()
        };
        let v43: () = {
            Runtime::closure7(v10.clone(), string("exit_code"), ());
            ()
        };
        let v62: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v82: () = {
            Runtime::closure7(v10.clone(), sprintf!("{}", v0), ());
            ()
        };
        let v101: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v120: () = {
            Runtime::closure7(v10.clone(), string("output_length"), ());
            ()
        };
        let v137: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v157: () = {
            Runtime::closure7(v10.clone(), sprintf!("{}", v1), ());
            ()
        };
        let v174: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v193: () = {
            Runtime::closure7(v10.clone(), string("options"), ());
            ()
        };
        let v210: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v227: () = {
            Runtime::closure7(v10.clone(), string("{ "), ());
            ()
        };
        let v246: () = {
            Runtime::closure7(v10.clone(), string("command"), ());
            ()
        };
        let v263: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v280: () = {
            Runtime::closure7(v10.clone(), v2, ());
            ()
        };
        let v297: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v316: () = {
            Runtime::closure7(v10.clone(), string("cancellation_token"), ());
            ()
        };
        let v333: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v345: std::string::String = format!("{:#?}", v3);
        let v392: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v345),
                (),
            );
            ()
        };
        let v409: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v428: () = {
            Runtime::closure7(v10.clone(), string("environment_variables"), ());
            ()
        };
        let v445: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v466: () = {
            Runtime::closure7(v10.clone(), sprintf!("{:?}", v4), ());
            ()
        };
        let v483: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v502: () = {
            Runtime::closure7(v10.clone(), string("on_line"), ());
            ()
        };
        let v519: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v531: std::string::String = format!("{:#?}", v5);
        let v578: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v531),
                (),
            );
            ()
        };
        let v595: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v614: () = {
            Runtime::closure7(v10.clone(), string("stdin"), ());
            ()
        };
        let v631: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v643: std::string::String = format!("{:#?}", v6);
        let v690: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v643),
                (),
            );
            ()
        };
        let v707: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v726: () = {
            Runtime::closure7(v10.clone(), string("trace"), ());
            ()
        };
        let v743: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v763: () = {
            Runtime::closure7(
                v10.clone(),
                if v7 { string("true") } else { string("false") },
                (),
            );
            ()
        };
        let v780: () = {
            Runtime::closure7(v10.clone(), string("; "), ());
            ()
        };
        let v799: () = {
            Runtime::closure7(v10.clone(), string("working_directory"), ());
            ()
        };
        let v816: () = {
            Runtime::closure7(v10.clone(), string(" = "), ());
            ()
        };
        let v828: std::string::String = format!("{:#?}", v8);
        let v875: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v828),
                (),
            );
            ()
        };
        let v894: () = {
            Runtime::closure7(v10.clone(), string(" }"), ());
            ()
        };
        let v911: () = {
            Runtime::closure7(v10.clone(), string(" }"), ());
            ()
        };
        v10.l0.get().clone()
    }
    pub fn method63(
        v0: LrcPtr<Runtime::Mut0>,
        v1: LrcPtr<Runtime::Mut1>,
        v2: LrcPtr<Runtime::Mut2>,
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
        v14_1: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v15_1: bool,
        v16_1: Option<string>,
    ) -> string {
        let v17: string = Runtime::method64(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1);
        Runtime::method17(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("runtime.execute_with_options_async"),
                )),
                string(" / "),
            )),
            (v17),
        ))
    }
    pub fn closure24(
        v0: string,
        v1: Option<CancellationToken>,
        v2: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
        v7: i32,
        v8: string,
        unitVar: (),
    ) {
        fn v24() {
            Runtime::closure0((), ());
        }
        let v25: () = {
            v24();
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
        let v66: Runtime::US0 = (patternInput.4.clone()).l0.get().clone();
        let v307: Runtime::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            1_i32
                >= (find(
                    v66,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Runtime::US0::US0_0, 0_i32)),
                        LrcPtr::new((Runtime::US0::US0_1, 1_i32)),
                        LrcPtr::new((Runtime::US0::US0_2, 2_i32)),
                        LrcPtr::new((Runtime::US0::US0_3, 3_i32)),
                        LrcPtr::new((Runtime::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            Runtime::US6::US6_1
        } else {
            let v89: () = {
                v24();
                ()
            };
            let patternInput_1: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v117: Option<i64> = patternInput_1.5.clone();
            let v116: LrcPtr<Runtime::Mut4> = patternInput_1.4.clone();
            let v115: LrcPtr<Runtime::Mut3> = patternInput_1.3.clone();
            let v114: LrcPtr<Runtime::Mut2> = patternInput_1.2.clone();
            let v113: LrcPtr<Runtime::Mut1> = patternInput_1.1.clone();
            let v112: LrcPtr<Runtime::Mut0> = patternInput_1.0.clone();
            let v133: string = Runtime::method63(
                v112.clone(),
                v113.clone(),
                v114.clone(),
                v115.clone(),
                v116.clone(),
                v117.clone(),
                Runtime::method7(v112, v113, v114, v115, v116, v117),
                Runtime::method43(),
                v7,
                length(v8),
                v0,
                v1,
                v2,
                v3,
                v4,
                v5,
                v6,
            );
            let v149: () = {
                v24();
                ()
            };
            let patternInput_2: (
                LrcPtr<Runtime::Mut0>,
                LrcPtr<Runtime::Mut1>,
                LrcPtr<Runtime::Mut2>,
                LrcPtr<Runtime::Mut3>,
                LrcPtr<Runtime::Mut4>,
                Option<i64>,
            ) = Runtime::TraceState::trace_state().get().clone().unwrap();
            let v173: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v172: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v194: () = {
                Runtime::closure8(v172.clone(), ());
                ()
            };
            println!("{}", v133.clone());
            (v173.l0.get().clone())(v133);
            Runtime::US6::US6_0(
                v172,
                v173,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method22(
        v0: string,
        v1: Option<CancellationToken>,
        v2: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
    ) -> Arc<Async<(i32, string)>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method21(
        v0: string,
        v1: Option<CancellationToken>,
        v2: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
    ) -> Arc<Async<(i32, string)>> {
        Runtime::method22(v0, v1, v2, v3, v4, v5, v6)
    }
    pub fn method20(v0: string) -> Arc<Async<(i32, string)>> {
        Runtime::method21(
            v0,
            None::<CancellationToken>,
            new_empty::<(string, string)>(),
            None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
            None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            true,
            None::<string>,
        )
    }
    pub fn closure13(unitVar: (), v0: string) -> Arc<Async<(i32, string)>> {
        Runtime::method20(v0)
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
        Runtime::method21(
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
        v0: Func1<LrcPtr<Runtime::Heap0>, LrcPtr<Runtime::Heap0>>,
    ) -> (
        string,
        Option<CancellationToken>,
        Array<(string, string)>,
        Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        bool,
        Option<string>,
    ) {
        let v20: LrcPtr<Runtime::Heap0> = v0(LrcPtr::new(Runtime::Heap0 {
            l0: string(""),
            l1: None::<CancellationToken>,
            l2: new_empty::<(string, string)>(),
            l3: None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
            l4: None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            l5: true,
            l6: None::<string>,
        }));
        (
            v20.l0.clone(),
            v20.l1.clone(),
            v20.l2.clone(),
            v20.l3.clone(),
            v20.l4.clone(),
            v20.l5,
            v20.l6.clone(),
        )
    }
    pub fn method67(v0: char, v1: i64) -> bool {
        let v0: MutCell<char> = MutCell::new(v0);
        let v1: MutCell<i64> = MutCell::new(v1);
        '_method67: loop {
            break '_method67 (if (v1.get().clone()) >= 4_i64 {
                false
            } else {
                let v19: Runtime::US10 = if (v1.get().clone()) == 0_i64 {
                    Runtime::US10::US10_0('\\')
                } else {
                    let v5: i64 = (v1.get().clone()) - 1_i64;
                    if (v5) == 0_i64 {
                        Runtime::US10::US10_0('`')
                    } else {
                        let v8: i64 = (v5) - 1_i64;
                        if (v8) == 0_i64 {
                            Runtime::US10::US10_0('\"')
                        } else {
                            let v11: i64 = (v8) - 1_i64;
                            if (v11) == 0_i64 {
                                Runtime::US10::US10_0(' ')
                            } else {
                                let v14_1: i64 = (v11) - 1_i64;
                                Runtime::US10::US10_1
                            }
                        }
                    }
                };
                if (v0.get().clone())
                    == (match &v19 {
                        Runtime::US10::US10_0(v19_0_0) => match &v19 {
                            Runtime::US10::US10_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    })
                {
                    true
                } else {
                    let v0_temp: char = v0.get().clone();
                    let v1_temp: i64 = (v1.get().clone()) + 1_i64;
                    v0.set(v0_temp);
                    v1.set(v1_temp);
                    continue '_method67;
                }
            });
        }
    }
    pub fn method68(
        v0: string,
        v1: string,
        v2: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> (string, string, LrcPtr<StringBuilder>, i32, i32) {
        let v0: MutCell<string> = MutCell::new(v0.clone());
        let v1: MutCell<string> = MutCell::new(v1.clone());
        let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method68: loop {
            break '_method68 ({
                let v120: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method31(
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v36: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method67(v36, 0_i64)) == false {
                        let v73: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v79: string = ofChar(v36);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                            Runtime::method26(length(v79.clone()) as i64, v79, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v36,
                            v73,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method33(
                                v36,
                                toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                match &v120 {
                    Runtime::US8::US8_0(v120_0_0, v120_0_1, v120_0_2, v120_0_3, v120_0_4) => {
                        let v0_temp: string =
                            append((v0.get().clone()), (ofChar(v120_0_0.clone())));
                        let v1_temp: string = v120_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v120_0_2.clone();
                        let v3_temp: i32 = v120_0_3.clone();
                        let v4_temp: i32 = v120_0_4.clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method68;
                    }
                    _ => (
                        v0.get().clone(),
                        v1.get().clone(),
                        v2.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method70(v0: char, v1: i64) -> bool {
        let v0: MutCell<char> = MutCell::new(v0);
        let v1: MutCell<i64> = MutCell::new(v1);
        '_method70: loop {
            break '_method70 (if (v1.get().clone()) >= 3_i64 {
                false
            } else {
                let v15_1: Runtime::US10 = if (v1.get().clone()) == 0_i64 {
                    Runtime::US10::US10_0('\\')
                } else {
                    let v5: i64 = (v1.get().clone()) - 1_i64;
                    if (v5) == 0_i64 {
                        Runtime::US10::US10_0('`')
                    } else {
                        let v8: i64 = (v5) - 1_i64;
                        if (v8) == 0_i64 {
                            Runtime::US10::US10_0('\"')
                        } else {
                            let v11: i64 = (v8) - 1_i64;
                            Runtime::US10::US10_1
                        }
                    }
                };
                if (v0.get().clone())
                    == (match &v15_1 {
                        Runtime::US10::US10_0(v15_1_0_0) => match &v15_1 {
                            Runtime::US10::US10_0(x) => x.clone(),
                            _ => unreachable!(),
                        },
                        _ => panic!("{}", string("Option does not have a value."),),
                    })
                {
                    true
                } else {
                    let v0_temp: char = v0.get().clone();
                    let v1_temp: i64 = (v1.get().clone()) + 1_i64;
                    v0.set(v0_temp);
                    v1.set(v1_temp);
                    continue '_method70;
                }
            });
        }
    }
    pub fn closure28(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US9 {
        let v3: i32 = _arg.3.clone();
        let v2: i32 = _arg.2.clone();
        let v1: LrcPtr<StringBuilder> = _arg.1.clone();
        let v0: string = _arg.0.clone();
        let v164: Runtime::US8 = if string("") == (v0.clone()) {
            Runtime::US8::US8_1(append(
                string("parsing.p_char / unexpected end of input / "),
                (Runtime::method25('\\', v1.clone(), v2, v3)),
            ))
        } else {
            let v14_1: char = getCharAt(v0.clone(), 0_i32);
            if (v14_1) == '\\' {
                let v49: string =
                    getSlice(v0.clone(), Some(1_i32), Some((length(v0.clone())) - 1_i32));
                let v55: string = ofChar(v14_1);
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                    Runtime::method26(length(v55.clone()) as i64, v55, 0_i64),
                    v1.clone(),
                    v2,
                    v3,
                );
                Runtime::US8::US8_0(
                    v14_1,
                    v49,
                    patternInput.0.clone(),
                    patternInput.1.clone(),
                    patternInput.2.clone(),
                )
            } else {
                let v72: i32 = (indexOf(v0.clone(), string("\n"))) - 1_i32;
                let v110: string = getSlice(
                    v0.clone(),
                    Some(0_i32),
                    Some(
                        (if -2_i32 == (v72) {
                            (length(v0)) + 1_i32
                        } else {
                            (v72) + 1_i32
                        }) - 1_i32,
                    ),
                );
                Runtime::US8::US8_1(append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append(
                                        (append(
                                            string("parsing.p_char / "),
                                            (Runtime::method28('\\', v2, v3)),
                                        )),
                                        string("\n"),
                                    )),
                                    (toString(v1)),
                                )),
                                (v110),
                            )),
                            string("\n"),
                        )),
                        (append(
                            ((Runtime::method29((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        )),
                    )),
                    string("\n"),
                ))
            }
        };
        let v233: Runtime::US8 = match &v164 {
            Runtime::US8::US8_0(v164_0_0, v164_0_1, v164_0_2, v164_0_3, v164_0_4) => {
                let v169: i32 = v164_0_4.clone();
                let v168: i32 = v164_0_3.clone();
                let v167: LrcPtr<StringBuilder> = v164_0_2.clone();
                let v166: string = v164_0_1.clone();
                if string("") == (v166.clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.any_char / unexpected end of input / "),
                        (Runtime::method41(v167.clone(), v168, v169)),
                    ))
                } else {
                    let v179: char = getCharAt(v166.clone(), 0_i32);
                    let v213: string =
                        getSlice(v166.clone(), Some(1_i32), Some((length(v166)) - 1_i32));
                    let v219: string = ofChar(v179);
                    let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                        Runtime::method26(length(v219.clone()) as i64, v219, 0_i64),
                        v167,
                        v168,
                        v169,
                    );
                    Runtime::US8::US8_0(
                        v179,
                        v213,
                        patternInput_1.0.clone(),
                        patternInput_1.1.clone(),
                        patternInput_1.2.clone(),
                    )
                }
            }
            Runtime::US8::US8_1(v164_1_0) => Runtime::US8::US8_1(v164_1_0.clone()),
        };
        match &v233 {
            Runtime::US8::US8_0(v233_0_0, v233_0_1, v233_0_2, v233_0_3, v233_0_4) => {
                Runtime::US9::US9_0(
                    append((ofChar('\\')), (ofChar(v233_0_0.clone()))),
                    v233_0_1.clone(),
                    v233_0_2.clone(),
                    v233_0_3.clone(),
                    v233_0_4.clone(),
                )
            }
            Runtime::US8::US8_1(v233_1_0) => Runtime::US9::US9_1(v233_1_0.clone()),
        }
    }
    pub fn closure29(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US9 {
        let v3: i32 = _arg.3.clone();
        let v2: i32 = _arg.2.clone();
        let v1: LrcPtr<StringBuilder> = _arg.1.clone();
        let v0: string = _arg.0.clone();
        let v164: Runtime::US8 = if string("") == (v0.clone()) {
            Runtime::US8::US8_1(append(
                string("parsing.p_char / unexpected end of input / "),
                (Runtime::method25('`', v1.clone(), v2, v3)),
            ))
        } else {
            let v14_1: char = getCharAt(v0.clone(), 0_i32);
            if (v14_1) == '`' {
                let v49: string =
                    getSlice(v0.clone(), Some(1_i32), Some((length(v0.clone())) - 1_i32));
                let v55: string = ofChar(v14_1);
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                    Runtime::method26(length(v55.clone()) as i64, v55, 0_i64),
                    v1.clone(),
                    v2,
                    v3,
                );
                Runtime::US8::US8_0(
                    v14_1,
                    v49,
                    patternInput.0.clone(),
                    patternInput.1.clone(),
                    patternInput.2.clone(),
                )
            } else {
                let v72: i32 = (indexOf(v0.clone(), string("\n"))) - 1_i32;
                let v110: string = getSlice(
                    v0.clone(),
                    Some(0_i32),
                    Some(
                        (if -2_i32 == (v72) {
                            (length(v0)) + 1_i32
                        } else {
                            (v72) + 1_i32
                        }) - 1_i32,
                    ),
                );
                Runtime::US8::US8_1(append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append(
                                        (append(
                                            string("parsing.p_char / "),
                                            (Runtime::method28('`', v2, v3)),
                                        )),
                                        string("\n"),
                                    )),
                                    (toString(v1)),
                                )),
                                (v110),
                            )),
                            string("\n"),
                        )),
                        (append(
                            ((Runtime::method29((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        )),
                    )),
                    string("\n"),
                ))
            }
        };
        let v233: Runtime::US8 = match &v164 {
            Runtime::US8::US8_0(v164_0_0, v164_0_1, v164_0_2, v164_0_3, v164_0_4) => {
                let v169: i32 = v164_0_4.clone();
                let v168: i32 = v164_0_3.clone();
                let v167: LrcPtr<StringBuilder> = v164_0_2.clone();
                let v166: string = v164_0_1.clone();
                if string("") == (v166.clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.any_char / unexpected end of input / "),
                        (Runtime::method41(v167.clone(), v168, v169)),
                    ))
                } else {
                    let v179: char = getCharAt(v166.clone(), 0_i32);
                    let v213: string =
                        getSlice(v166.clone(), Some(1_i32), Some((length(v166)) - 1_i32));
                    let v219: string = ofChar(v179);
                    let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                        Runtime::method26(length(v219.clone()) as i64, v219, 0_i64),
                        v167,
                        v168,
                        v169,
                    );
                    Runtime::US8::US8_0(
                        v179,
                        v213,
                        patternInput_1.0.clone(),
                        patternInput_1.1.clone(),
                        patternInput_1.2.clone(),
                    )
                }
            }
            Runtime::US8::US8_1(v164_1_0) => Runtime::US8::US8_1(v164_1_0.clone()),
        };
        match &v233 {
            Runtime::US8::US8_0(v233_0_0, v233_0_1, v233_0_2, v233_0_3, v233_0_4) => {
                Runtime::US9::US9_0(
                    append((ofChar('`')), (ofChar(v233_0_0.clone()))),
                    v233_0_1.clone(),
                    v233_0_2.clone(),
                    v233_0_3.clone(),
                    v233_0_4.clone(),
                )
            }
            Runtime::US8::US8_1(v233_1_0) => Runtime::US9::US9_1(v233_1_0.clone()),
        }
    }
    pub fn method71(
        v0: string,
        v1: LrcPtr<StringBuilder>,
        v2: i32,
        v3: i32,
        v4: LrcPtr<Runtime::UH3>,
    ) -> Runtime::US9 {
        let v0: MutCell<string> = MutCell::new(v0.clone());
        let v1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1.clone());
        let v2: MutCell<i32> = MutCell::new(v2);
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<LrcPtr<Runtime::UH3>> = MutCell::new(v4.clone());
        '_method71: loop {
            break '_method71 (match v4.get().clone().as_ref() {
                Runtime::UH3::UH3_0 => {
                    Runtime::US9::US9_1(string("parsing.choice / no parsers succeeded"))
                }
                Runtime::UH3::UH3_1(v4_1_0, v4_1_1) => {
                    let v9: Runtime::US9 = (match v4.get().clone().as_ref() {
                        Runtime::UH3::UH3_1(x, _) => x.clone(),
                        _ => unreachable!(),
                    })((
                        v0.get().clone(),
                        v1.get().clone(),
                        v2.get().clone(),
                        v3.get().clone(),
                    ));
                    match &v9 {
                        Runtime::US9::US9_0(v9_0_0, v9_0_1, v9_0_2, v9_0_3, v9_0_4) => v9.clone(),
                        _ => {
                            let v0_temp: string = v0.get().clone();
                            let v1_temp: LrcPtr<StringBuilder> = v1.get().clone();
                            let v2_temp: i32 = v2.get().clone();
                            let v3_temp: i32 = v3.get().clone();
                            let v4_temp: LrcPtr<Runtime::UH3> = match v4.get().clone().as_ref() {
                                Runtime::UH3::UH3_1(_, x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone();
                            v0.set(v0_temp);
                            v1.set(v1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method71;
                        }
                    }
                }
            });
        }
    }
    pub fn method72(v0: LrcPtr<Runtime::UH2>, v1: LrcPtr<Runtime::UH2>) -> LrcPtr<Runtime::UH2> {
        let v0: MutCell<LrcPtr<Runtime::UH2>> = MutCell::new(v0.clone());
        let v1: MutCell<LrcPtr<Runtime::UH2>> = MutCell::new(v1.clone());
        '_method72: loop {
            break '_method72 (match v0.get().clone().as_ref() {
                Runtime::UH2::UH2_0 => v1.get().clone(),
                Runtime::UH2::UH2_1(v0_1_0, v0_1_1) => {
                    let v0_temp: LrcPtr<Runtime::UH2> = match v0.get().clone().as_ref() {
                        Runtime::UH2::UH2_1(_, x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone();
                    let v1_temp: LrcPtr<Runtime::UH2> = LrcPtr::new(Runtime::UH2::UH2_1(
                        match v0.get().clone().as_ref() {
                            Runtime::UH2::UH2_1(x, _) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        v1.get().clone(),
                    ));
                    v0.set(v0_temp);
                    v1.set(v1_temp);
                    continue '_method72;
                }
            });
        }
    }
    pub fn method69(
        v0: LrcPtr<Runtime::UH2>,
        v1: string,
        v2: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> Runtime::US18 {
        let v0: MutCell<LrcPtr<Runtime::UH2>> = MutCell::new(v0.clone());
        let v1: MutCell<string> = MutCell::new(v1.clone());
        let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method69: loop {
            break '_method69 ({
                let v112: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method31(
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v32_1: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method70(v32_1, 0_i64)) == false {
                        let v69: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v75: string = ofChar(v32_1);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                            Runtime::method26(length(v75.clone()) as i64, v75, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v32_1,
                            v69,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method33(
                                v32_1,
                                toArray(ofArray(new_array(&['\\', '`', '\"']))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v127: Runtime::US9 = match &v112 {
                    Runtime::US8::US8_0(v112_0_0, v112_0_1, v112_0_2, v112_0_3, v112_0_4) => {
                        Runtime::US9::US9_0(
                            ofChar(v112_0_0.clone()),
                            v112_0_1.clone(),
                            v112_0_2.clone(),
                            v112_0_3.clone(),
                            v112_0_4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v112_1_0) => Runtime::US9::US9_1(v112_1_0.clone()),
                };
                let v141: Runtime::US9 = match &v127 {
                    Runtime::US9::US9_0(v127_0_0, v127_0_1, v127_0_2, v127_0_3, v127_0_4) => {
                        v127.clone()
                    }
                    _ => Runtime::method71(
                        v1.get().clone(),
                        v2.get().clone(),
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
                match &v141 {
                    Runtime::US9::US9_0(v141_0_0, v141_0_1, v141_0_2, v141_0_3, v141_0_4) => {
                        let v0_temp: LrcPtr<Runtime::UH2> =
                            LrcPtr::new(Runtime::UH2::UH2_1(v141_0_0.clone(), v0.get().clone()));
                        let v1_temp: string = v141_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v141_0_2.clone();
                        let v3_temp: i32 = v141_0_3.clone();
                        let v4_temp: i32 = v141_0_4.clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method69;
                    }
                    _ => Runtime::US18::US18_0(
                        Runtime::method72(v0.get().clone(), LrcPtr::new(Runtime::UH2::UH2_0)),
                        v1.get().clone(),
                        v2.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method73(v0: LrcPtr<Runtime::UH2>, v1: List<string>) -> List<string> {
        match v0.as_ref() {
            Runtime::UH2::UH2_0 => v1.clone(),
            Runtime::UH2::UH2_1(v0_1_0, v0_1_1) => cons(
                match v0.as_ref() {
                    Runtime::UH2::UH2_1(x, _) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                Runtime::method73(
                    match v0.as_ref() {
                        Runtime::UH2::UH2_1(_, x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    v1.clone(),
                ),
            ),
        }
    }
    pub fn method74(
        v0: LrcPtr<Runtime::UH2>,
        v1: string,
        v2: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> Runtime::US18 {
        let v0: MutCell<LrcPtr<Runtime::UH2>> = MutCell::new(v0.clone());
        let v1: MutCell<string> = MutCell::new(v1.clone());
        let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method74: loop {
            break '_method74 ({
                let v112: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method31(
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v32_1: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method70(v32_1, 0_i64)) == false {
                        let v69: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v75: string = ofChar(v32_1);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                            Runtime::method26(length(v75.clone()) as i64, v75, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v32_1,
                            v69,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method33(
                                v32_1,
                                toArray(ofArray(new_array(&['\\', '`', '\"']))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v127: Runtime::US9 = match &v112 {
                    Runtime::US8::US8_0(v112_0_0, v112_0_1, v112_0_2, v112_0_3, v112_0_4) => {
                        Runtime::US9::US9_0(
                            ofChar(v112_0_0.clone()),
                            v112_0_1.clone(),
                            v112_0_2.clone(),
                            v112_0_3.clone(),
                            v112_0_4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v112_1_0) => Runtime::US9::US9_1(v112_1_0.clone()),
                };
                match &v127 {
                    Runtime::US9::US9_0(v127_0_0, v127_0_1, v127_0_2, v127_0_3, v127_0_4) => {
                        let v0_temp: LrcPtr<Runtime::UH2> =
                            LrcPtr::new(Runtime::UH2::UH2_1(v127_0_0.clone(), v0.get().clone()));
                        let v1_temp: string = v127_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v127_0_2.clone();
                        let v3_temp: i32 = v127_0_3.clone();
                        let v4_temp: i32 = v127_0_4.clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method74;
                    }
                    _ => Runtime::US18::US18_0(
                        Runtime::method72(v0.get().clone(), LrcPtr::new(Runtime::UH2::UH2_0)),
                        v1.get().clone(),
                        v2.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method66(
        v0: LrcPtr<Runtime::UH2>,
        v1: string,
        v2: LrcPtr<StringBuilder>,
        v3: i32,
        v4: i32,
    ) -> Runtime::US18 {
        let v0: MutCell<LrcPtr<Runtime::UH2>> = MutCell::new(v0.clone());
        let v1: MutCell<string> = MutCell::new(v1.clone());
        let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
        let v3: MutCell<i32> = MutCell::new(v3);
        let v4: MutCell<i32> = MutCell::new(v4);
        '_method66: loop {
            break '_method66 ({
                let v5: bool = string("") == (v1.get().clone());
                let v120: Runtime::US8 = if v5 {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method31(
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v36: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method67(v36, 0_i64)) == false {
                        let v73: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v79: string = ofChar(v36);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                            Runtime::method26(length(v79.clone()) as i64, v79, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v36,
                            v73,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method33(
                                v36,
                                toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v140: Runtime::US9 = match &v120 {
                    Runtime::US8::US8_0(v120_0_0, v120_0_1, v120_0_2, v120_0_3, v120_0_4) => {
                        let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                            Runtime::method68(
                                ofChar(v120_0_0.clone()),
                                v120_0_1.clone(),
                                v120_0_2.clone(),
                                v120_0_3.clone(),
                                v120_0_4.clone(),
                            );
                        Runtime::US9::US9_0(
                            patternInput_1.0.clone(),
                            patternInput_1.1.clone(),
                            patternInput_1.2.clone(),
                            patternInput_1.3.clone(),
                            patternInput_1.4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v120_1_0) => Runtime::US9::US9_1(v120_1_0.clone()),
                };
                let v609: Runtime::US9 = match &v140 {
                    Runtime::US9::US9_0(v140_0_0, v140_0_1, v140_0_2, v140_0_3, v140_0_4) => {
                        v140.clone()
                    }
                    _ => {
                        let v306: Runtime::US8 = if v5 {
                            Runtime::US8::US8_1(append(
                                string("parsing.p_char / unexpected end of input / "),
                                (Runtime::method25(
                                    '\"',
                                    v2.get().clone(),
                                    v3.get().clone(),
                                    v4.get().clone(),
                                )),
                            ))
                        } else {
                            let v156: char = getCharAt(v1.get().clone(), 0_i32);
                            if (v156) == '\"' {
                                let v191: string = getSlice(
                                    v1.get().clone(),
                                    Some(1_i32),
                                    Some((length(v1.get().clone())) - 1_i32),
                                );
                                let v197: string = ofChar(v156);
                                let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method27(
                                        Runtime::method26(length(v197.clone()) as i64, v197, 0_i64),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Runtime::US8::US8_0(
                                    v156,
                                    v191,
                                    patternInput_2.0.clone(),
                                    patternInput_2.1.clone(),
                                    patternInput_2.2.clone(),
                                )
                            } else {
                                let v214: i32 = (indexOf(v1.get().clone(), string("\n"))) - 1_i32;
                                let v252: string = getSlice(
                                    v1.get().clone(),
                                    Some(0_i32),
                                    Some(
                                        (if -2_i32 == (v214) {
                                            (length(v1.get().clone())) + 1_i32
                                        } else {
                                            (v214) + 1_i32
                                        }) - 1_i32,
                                    ),
                                );
                                Runtime::US8::US8_1(append(
                                    (append(
                                        (append(
                                            (append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            string("parsing.p_char / "),
                                                            (Runtime::method28(
                                                                '\"',
                                                                v3.get().clone(),
                                                                v4.get().clone(),
                                                            )),
                                                        )),
                                                        string("\n"),
                                                    )),
                                                    (toString(v2.get().clone())),
                                                )),
                                                (v252),
                                            )),
                                            string("\n"),
                                        )),
                                        (append(
                                            ((Runtime::method29(
                                                (v4.get().clone()) - 1_i32,
                                                0_i32,
                                            ))(
                                                string("")
                                            )),
                                            string("^"),
                                        )),
                                    )),
                                    string("\n"),
                                ))
                            }
                        };
                        let v538: Runtime::US9 = match &v306 {
                            Runtime::US8::US8_0(
                                v306_0_0,
                                v306_0_1,
                                v306_0_2,
                                v306_0_3,
                                v306_0_4,
                            ) => {
                                let v311: i32 = v306_0_4.clone();
                                let v310: i32 = v306_0_3.clone();
                                let v309: LrcPtr<StringBuilder> = v306_0_2.clone();
                                let v308: string = v306_0_1.clone();
                                let v313: Runtime::US18 = Runtime::method69(
                                    LrcPtr::new(Runtime::UH2::UH2_0),
                                    v308.clone(),
                                    v309.clone(),
                                    v310,
                                    v311,
                                );
                                let v346: Runtime::US9 = match &v313 {
                                    Runtime::US18::US18_0(
                                        v313_0_0,
                                        v313_0_1,
                                        v313_0_2,
                                        v313_0_3,
                                        v313_0_4,
                                    ) => {
                                        let v320: List<string> =
                                            Runtime::method73(v313_0_0.clone(), empty::<string>());
                                        Runtime::US9::US9_0(
                                            join(
                                                string(""),
                                                toArray_1(delay(Func0::new({
                                                    let v320 = v320.clone();
                                                    move || ofList(v320.clone()).clone()
                                                }))),
                                            ),
                                            v313_0_1.clone(),
                                            v313_0_2.clone(),
                                            v313_0_3.clone(),
                                            v313_0_4.clone(),
                                        )
                                    }
                                    Runtime::US18::US18_1(v313_1_0) => {
                                        Runtime::US9::US9_1(v313_1_0.clone())
                                    }
                                };
                                match &v346 {
                                    Runtime::US9::US9_0(
                                        v346_0_0,
                                        v346_0_1,
                                        v346_0_2,
                                        v346_0_3,
                                        v346_0_4,
                                    ) => {
                                        let v351: i32 = v346_0_4.clone();
                                        let v350: i32 = v346_0_3.clone();
                                        let v349: LrcPtr<StringBuilder> = v346_0_2.clone();
                                        let v348: string = v346_0_1.clone();
                                        let v512: Runtime::US8 = if string("") == (v348.clone()) {
                                            Runtime::US8::US8_1(append(
                                                string(
                                                    "parsing.p_char / unexpected end of input / ",
                                                ),
                                                (Runtime::method25('\"', v349.clone(), v350, v351)),
                                            ))
                                        } else {
                                            let v362: char = getCharAt(v348.clone(), 0_i32);
                                            if (v362) == '\"' {
                                                let v397: string = getSlice(
                                                    v348.clone(),
                                                    Some(1_i32),
                                                    Some((length(v348.clone())) - 1_i32),
                                                );
                                                let v403: string = ofChar(v362);
                                                let patternInput_3: (
                                                    LrcPtr<StringBuilder>,
                                                    i32,
                                                    i32,
                                                ) = Runtime::method27(
                                                    Runtime::method26(
                                                        length(v403.clone()) as i64,
                                                        v403,
                                                        0_i64,
                                                    ),
                                                    v349.clone(),
                                                    v350,
                                                    v351,
                                                );
                                                Runtime::US8::US8_0(
                                                    v362,
                                                    v397,
                                                    patternInput_3.0.clone(),
                                                    patternInput_3.1.clone(),
                                                    patternInput_3.2.clone(),
                                                )
                                            } else {
                                                let v420: i32 =
                                                    (indexOf(v348.clone(), string("\n"))) - 1_i32;
                                                let v458: string = getSlice(
                                                    v348.clone(),
                                                    Some(0_i32),
                                                    Some(
                                                        (if -2_i32 == (v420) {
                                                            (length(v348.clone())) + 1_i32
                                                        } else {
                                                            (v420) + 1_i32
                                                        }) - 1_i32,
                                                    ),
                                                );
                                                Runtime::US8::US8_1(append(
                                                    (append(
                                                        (append(
                                                            (append(
                                                                (append(
                                                                    (append(
                                                                        (append(
                                                                            string(
                                                                                "parsing.p_char / ",
                                                                            ),
                                                                            (Runtime::method28(
                                                                                '\"', v350, v351,
                                                                            )),
                                                                        )),
                                                                        string("\n"),
                                                                    )),
                                                                    (toString(v349.clone())),
                                                                )),
                                                                (v458),
                                                            )),
                                                            string("\n"),
                                                        )),
                                                        (append(
                                                            ((Runtime::method29(
                                                                (v351) - 1_i32,
                                                                0_i32,
                                                            ))(
                                                                string("")
                                                            )),
                                                            string("^"),
                                                        )),
                                                    )),
                                                    string("\n"),
                                                ))
                                            }
                                        };
                                        match &v512 {
                                            Runtime::US8::US8_0(
                                                v512_0_0,
                                                v512_0_1,
                                                v512_0_2,
                                                v512_0_3,
                                                v512_0_4,
                                            ) => Runtime::US9::US9_0(
                                                v346_0_0.clone(),
                                                v512_0_1.clone(),
                                                v512_0_2.clone(),
                                                v512_0_3.clone(),
                                                v512_0_4.clone(),
                                            ),
                                            Runtime::US8::US8_1(v512_1_0) => {
                                                Runtime::US9::US9_1(append(
                                                    string(
                                                        "parsing.between / expected closing delimiter / ",
                                                    ),
                                                    (Runtime::method36(
                                                        v512_1_0.clone(),
                                                        v1.get().clone(),
                                                        v2.get().clone(),
                                                        v3.get().clone(),
                                                        v4.get().clone(),
                                                        v308.clone(),
                                                        v309.clone(),
                                                        v310,
                                                        v311,
                                                        v348.clone(),
                                                        v349.clone(),
                                                        v350,
                                                        v351,
                                                    )),
                                                ))
                                            }
                                        }
                                    }
                                    _ => Runtime::US9::US9_1(string(
                                        "parsing.between / expected content",
                                    )),
                                }
                            }
                            Runtime::US8::US8_1(v306_1_0) => Runtime::US9::US9_1(v306_1_0.clone()),
                        };
                        match &v538 {
                            Runtime::US9::US9_0(
                                v538_0_0,
                                v538_0_1,
                                v538_0_2,
                                v538_0_3,
                                v538_0_4,
                            ) => v538.clone(),
                            _ => {
                                let v550: Runtime::US9 = Runtime::method71(
                                    v1.get().clone(),
                                    v2.get().clone(),
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
                                let v561: Runtime::US9 = match &v550 {
                                    Runtime::US9::US9_0(
                                        v550_0_0,
                                        v550_0_1,
                                        v550_0_2,
                                        v550_0_3,
                                        v550_0_4,
                                    ) => Runtime::US9::US9_0(
                                        string(""),
                                        v550_0_1.clone(),
                                        v550_0_2.clone(),
                                        v550_0_3.clone(),
                                        v550_0_4.clone(),
                                    ),
                                    Runtime::US9::US9_1(v550_1_0) => {
                                        Runtime::US9::US9_1(v550_1_0.clone())
                                    }
                                };
                                let v572: Runtime::US18 = match &v561 {
                                    Runtime::US9::US9_0(
                                        v561_0_0,
                                        v561_0_1,
                                        v561_0_2,
                                        v561_0_3,
                                        v561_0_4,
                                    ) => Runtime::method74(
                                        LrcPtr::new(Runtime::UH2::UH2_0),
                                        v561_0_1.clone(),
                                        v561_0_2.clone(),
                                        v561_0_3.clone(),
                                        v561_0_4.clone(),
                                    ),
                                    Runtime::US9::US9_1(v561_1_0) => {
                                        Runtime::US18::US18_1(v561_1_0.clone())
                                    }
                                };
                                match &v572 {
                                    Runtime::US18::US18_0(
                                        v572_0_0,
                                        v572_0_1,
                                        v572_0_2,
                                        v572_0_3,
                                        v572_0_4,
                                    ) => {
                                        let v579: List<string> =
                                            Runtime::method73(v572_0_0.clone(), empty::<string>());
                                        Runtime::US9::US9_0(
                                            join(
                                                string(""),
                                                toArray_1(delay(Func0::new({
                                                    let v579 = v579.clone();
                                                    move || ofList(v579.clone()).clone()
                                                }))),
                                            ),
                                            v572_0_1.clone(),
                                            v572_0_2.clone(),
                                            v572_0_3.clone(),
                                            v572_0_4.clone(),
                                        )
                                    }
                                    Runtime::US18::US18_1(v572_1_0) => {
                                        Runtime::US9::US9_1(v572_1_0.clone())
                                    }
                                }
                            }
                        }
                    }
                };
                match &v609 {
                    Runtime::US9::US9_0(v609_0_0, v609_0_1, v609_0_2, v609_0_3, v609_0_4) => {
                        let v614: i32 = v609_0_4.clone();
                        let v613: i32 = v609_0_3.clone();
                        let v612: LrcPtr<StringBuilder> = v609_0_2.clone();
                        let v611: string = v609_0_1.clone();
                        let v610: string = v609_0_0.clone();
                        let v616: i32 = Runtime::method40(v611.clone(), 0_i32);
                        let v658: Runtime::US11 = if 0_i32 == (v616) {
                            Runtime::US11::US11_1(string(
                                "parsing.spaces1 / expected at least one space",
                            ))
                        } else {
                            Runtime::US11::US11_0(
                                getSlice(
                                    v611.clone(),
                                    Some(v616),
                                    Some((length(v611.clone())) - 1_i32),
                                ),
                                v612.clone(),
                                v613,
                                v614,
                            )
                        };
                        match &v658 {
                            Runtime::US11::US11_0(v658_0_0, v658_0_1, v658_0_2, v658_0_3) => {
                                let v0_temp: LrcPtr<Runtime::UH2> = LrcPtr::new(
                                    Runtime::UH2::UH2_1(v610.clone(), v0.get().clone()),
                                );
                                let v1_temp: string = v658_0_0.clone();
                                let v2_temp: LrcPtr<StringBuilder> = v658_0_1.clone();
                                let v3_temp: i32 = v658_0_2.clone();
                                let v4_temp: i32 = v658_0_3.clone();
                                v0.set(v0_temp);
                                v1.set(v1_temp);
                                v2.set(v2_temp);
                                v3.set(v3_temp);
                                v4.set(v4_temp);
                                continue '_method66;
                            }
                            _ => Runtime::US18::US18_0(
                                Runtime::method72(
                                    v0.get().clone(),
                                    LrcPtr::new(Runtime::UH2::UH2_1(
                                        v610.clone(),
                                        LrcPtr::new(Runtime::UH2::UH2_0),
                                    )),
                                ),
                                v611.clone(),
                                v612.clone(),
                                v613,
                                v614,
                            ),
                        }
                    }
                    _ => Runtime::US18::US18_0(
                        Runtime::method72(v0.get().clone(), LrcPtr::new(Runtime::UH2::UH2_0)),
                        v1.get().clone(),
                        v2.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method65(v0: string) -> Runtime::US17 {
        let _v0: MutCell<Option<Option<string>>> = MutCell::new(None::<Option<string>>);
        _v0.set(Some(Some(v0)));
        {
            let v22: Runtime::US18 = Runtime::method66(
                LrcPtr::new(Runtime::UH2::UH2_0),
                defaultValue(
                    string(""),
                    match &_v0.get().clone() {
                        None => panic!("{}", string("optionm\'.of_obj / _v0=None"),),
                        Some(_v0_0_0) => _v0_0_0.clone(),
                    },
                ),
                StringBuilder::_ctor__Z721C83C5(Runtime::method24()),
                1_i32,
                1_i32,
            );
            match &v22 {
                Runtime::US18::US18_0(v22_0_0, v22_0_1, v22_0_2, v22_0_3, v22_0_4) => {
                    Runtime::US17::US17_0(toArray(Runtime::method73(
                        v22_0_0.clone(),
                        empty::<string>(),
                    )))
                }
                Runtime::US18::US18_1(v22_1_0) => Runtime::US17::US17_1(v22_1_0.clone()),
            }
        }
    }
    pub fn closure27(unitVar: (), v0: string) -> Result<Array<string>, string> {
        let v1: Runtime::US17 = Runtime::method65(v0);
        match &v1 {
            Runtime::US17::US17_0(v1_0_0) => Ok::<Array<string>, string>(v1_0_0.clone()),
            Runtime::US17::US17_1(v1_1_0) => Err::<Array<string>, string>(v1_1_0.clone()),
        }
    }
    pub fn v14() -> () {
        static v14: OnceInit<()> = OnceInit::new();
        v14.get_or_init(|| ()).clone()
    }
    pub fn v15() -> Func0<()> {
        static v15: OnceInit<Func0<()>> = OnceInit::new();
        v15.get_or_init(|| Func0::new(move || Runtime::closure0((), ())))
            .clone()
    }
    pub fn v16() -> () {
        static v16: OnceInit<()> = OnceInit::new();
        v16.get_or_init(|| {
            (Runtime::v15())();
            Runtime::v14()
        })
        .clone()
    }
    pub fn v31() -> Func0<()> {
        static v31: OnceInit<Func0<()>> = OnceInit::new();
        v31.get_or_init(|| Func0::new(move || Runtime::closure3((), ())))
            .clone()
    }
    pub fn current_process_kill() {
        (Runtime::v31())();
    }
    pub fn v32() -> Func1<string, Arc<Async<(i32, string)>>> {
        static v32: OnceInit<Func1<string, Arc<Async<(i32, string)>>>> = OnceInit::new();
        v32.get_or_init(|| Func1::new(move |v: string| Runtime::closure13((), v)))
            .clone()
    }
    pub fn execute_async(x: string) -> Arc<Async<(i32, string)>> {
        (Runtime::v32())(x)
    }
    pub fn v33() -> Func1<
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
        static v33: OnceInit<
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
        v33.get_or_init(|| {
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
        (Runtime::v33())(x)
    }
    pub fn v34() -> Func1<
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
        static v34: OnceInit<
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
        v34.get_or_init(|| {
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
        (Runtime::v34())(x)
    }
    pub fn v35() -> Func1<string, Result<Array<string>, string>> {
        static v35: OnceInit<Func1<string, Result<Array<string>, string>>> = OnceInit::new();
        v35.get_or_init(|| Func1::new(move |v: string| Runtime::closure27((), v)))
            .clone()
    }
    pub fn split_args(x: string) -> Result<Array<string>, string> {
        (Runtime::v35())(x)
    }
    on_startup!(());
}
