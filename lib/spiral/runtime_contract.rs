pub mod Runtime {
    use super::*;
    type Async<T> = T;
    type DateTime = ();
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
        panic!(
            "{}",
            sprintf!(
                "env.get_environment_variable / target: {} / var: {}",
                Runtime::US4::US4_4(Runtime::US3::US3_2),
                v0
            ),
        )
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
                let v147: DateTime = unbox::<DateTime>(fable_library_rust::Native_::getZero());
                Runtime::US2::US2_0(unbox::<i64>(fable_library_rust::Native_::getZero()))
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
        let v94: string = string("option_env!(\"AUTOMATION\").unwrap_or(\"\")");
        let v95: &str = option_env!("AUTOMATION").unwrap_or("");
        let v106: std::string::String = String::from(v95);
        let _run_target_args__v3: (Runtime::US1, Runtime::US2) = (
            Runtime::US1::US1_1,
            if (fable_library_rust::String_::fromString(v106)) != string("True") {
                Runtime::US2::US2_1
            } else {
                Runtime::US2::US2_0(near_sdk::env::block_timestamp() as i64)
            },
        );
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
        let v569: u64 = near_sdk::env::block_timestamp();
        let v594: Runtime::US2 = defaultValue(Runtime::US2::US2_1, map(Runtime::method8(), v5));
        let v607: u64 = (match &v594 {
            Runtime::US2::US2_0(v594_0_0) => {
                (v569)
                    - (match &v594 {
                        Runtime::US2::US2_0(x) => x.clone(),
                        _ => unreachable!(),
                    } as u64)
            }
            _ => v569,
        }) / 1000000000_u64;
        let v608: u64 = (v607) % 60_u64;
        let v610: u64 = ((v607) / 60_u64) % 60_u64;
        let v612: u64 = ((v607) / 3600_u64) % 24_u64;
        let v614: std::string::String = format!("{:02}:{:02}:{:02}", v612, v610, v608);
        fable_library_rust::String_::fromString(v614)
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
        let v115: &str = inline_colorization::color_yellow;
        let v126: &str = &*v8;
        let v153: &str = inline_colorization::color_reset;
        let v155: std::string::String = format!("{}{}{}", v115, v126, v153);
        fable_library_rust::String_::fromString(v155)
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
            let v165: LrcPtr<Runtime::Mut3> = patternInput_2.3.clone();
            let v163: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v162: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v184: () = {
                Runtime::closure8(v162.clone(), ());
                ()
            };
            let v207: string = if (v165.l0.get().clone()) == string("") {
                v123.clone()
            } else {
                if (v123.clone()) == string("") {
                    v165.l0.get().clone()
                } else {
                    append(
                        (append((v165.l0.get().clone()), string("\n"))),
                        (v123.clone()),
                    )
                }
            };
            let v218: &str = &*v207.clone();
            let v245 = v218.chars();
            let v247 = v245;
            let v249: Vec<char> = v247.collect::<Vec<_>>();
            let v251: Vec<Vec<char>> = v249
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v253: bool = true;
            let _vec_map: Vec<_> = v251
                .into_iter()
                .map(|x| {
                    //;
                    let v255: Vec<char> = x;
                    let v257: std::string::String = String::from_iter(v255);
                    let v259: bool = true;
                    v257
                })
                .collect::<Vec<_>>();
            let v261: Vec<std::string::String> = _vec_map;
            if if (v123.clone()) != string("") {
                (v261.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v165.l0.set(v207);
                ()
            } else {
                v165.l0.set(string(""));
                {
                    let v286: bool = true;
                    v261.into_iter().for_each(|x| {
                        //;
                        let v288: std::string::String = x;
                        let v290: bool = true;
                        near_sdk::log!("{}", v288);
                        let v292: bool = true;
                        let v294: bool = true;
                    }); //;
                    ()
                }
            }
            (v163.l0.get().clone())(v123);
            Runtime::US6::US6_0(
                v162,
                v163,
                patternInput_2.2.clone(),
                v165,
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
            let v165: LrcPtr<Runtime::Mut3> = patternInput_2.3.clone();
            let v163: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v162: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v184: () = {
                Runtime::closure8(v162.clone(), ());
                ()
            };
            let v207: string = if (v165.l0.get().clone()) == string("") {
                v123.clone()
            } else {
                if (v123.clone()) == string("") {
                    v165.l0.get().clone()
                } else {
                    append(
                        (append((v165.l0.get().clone()), string("\n"))),
                        (v123.clone()),
                    )
                }
            };
            let v218: &str = &*v207.clone();
            let v245 = v218.chars();
            let v247 = v245;
            let v249: Vec<char> = v247.collect::<Vec<_>>();
            let v251: Vec<Vec<char>> = v249
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v253: bool = true;
            let _vec_map: Vec<_> = v251
                .into_iter()
                .map(|x| {
                    //;
                    let v255: Vec<char> = x;
                    let v257: std::string::String = String::from_iter(v255);
                    let v259: bool = true;
                    v257
                })
                .collect::<Vec<_>>();
            let v261: Vec<std::string::String> = _vec_map;
            if if (v123.clone()) != string("") {
                (v261.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v165.l0.set(v207);
                ()
            } else {
                v165.l0.set(string(""));
                {
                    let v286: bool = true;
                    v261.into_iter().for_each(|x| {
                        //;
                        let v288: std::string::String = x;
                        let v290: bool = true;
                        near_sdk::log!("{}", v288);
                        let v292: bool = true;
                        let v294: bool = true;
                    }); //;
                    ()
                }
            }
            (v163.l0.get().clone())(v123);
            Runtime::US6::US6_0(
                v162,
                v163,
                patternInput_2.2.clone(),
                v165,
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
            let v165: LrcPtr<Runtime::Mut3> = patternInput_2.3.clone();
            let v163: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v162: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v184: () = {
                Runtime::closure8(v162.clone(), ());
                ()
            };
            let v207: string = if (v165.l0.get().clone()) == string("") {
                v123.clone()
            } else {
                if (v123.clone()) == string("") {
                    v165.l0.get().clone()
                } else {
                    append(
                        (append((v165.l0.get().clone()), string("\n"))),
                        (v123.clone()),
                    )
                }
            };
            let v218: &str = &*v207.clone();
            let v245 = v218.chars();
            let v247 = v245;
            let v249: Vec<char> = v247.collect::<Vec<_>>();
            let v251: Vec<Vec<char>> = v249
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v253: bool = true;
            let _vec_map: Vec<_> = v251
                .into_iter()
                .map(|x| {
                    //;
                    let v255: Vec<char> = x;
                    let v257: std::string::String = String::from_iter(v255);
                    let v259: bool = true;
                    v257
                })
                .collect::<Vec<_>>();
            let v261: Vec<std::string::String> = _vec_map;
            if if (v123.clone()) != string("") {
                (v261.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v165.l0.set(v207);
                ()
            } else {
                v165.l0.set(string(""));
                {
                    let v286: bool = true;
                    v261.into_iter().for_each(|x| {
                        //;
                        let v288: std::string::String = x;
                        let v290: bool = true;
                        near_sdk::log!("{}", v288);
                        let v292: bool = true;
                        let v294: bool = true;
                    }); //;
                    ()
                }
            }
            (v163.l0.get().clone())(v123);
            Runtime::US6::US6_0(
                v162,
                v163,
                patternInput_2.2.clone(),
                v165,
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
        let v152: std::string::String = format!("{:#?}", v1);
        let v191: () = {
            Runtime::closure7(
                v5.clone(),
                fable_library_rust::String_::fromString(v152),
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
                let v51: string =
                    getSlice(v0.clone(), Some(1_i32), Some((length(v0.clone())) - 1_i32));
                let v57: string = ofChar(v14_1);
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                    Runtime::method26(length(v57.clone()) as i64, v57, 0_i64),
                    v1.clone(),
                    v2,
                    v3,
                );
                Runtime::US8::US8_0(
                    v14_1,
                    v51,
                    patternInput.0.clone(),
                    patternInput.1.clone(),
                    patternInput.2.clone(),
                )
            } else {
                let v74: i32 = (indexOf(v0.clone(), string("\n"))) - 1_i32;
                let v114: string = getSlice(
                    v0.clone(),
                    Some(0_i32),
                    Some(
                        (if -2_i32 == (v74) {
                            (length(v0)) + 1_i32
                        } else {
                            (v74) + 1_i32
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
                                (v114),
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
                let v51: string =
                    getSlice(v0.clone(), Some(1_i32), Some((length(v0.clone())) - 1_i32));
                let v57: string = ofChar(v14_1);
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                    Runtime::method26(length(v57.clone()) as i64, v57, 0_i64),
                    v1.clone(),
                    v2,
                    v3,
                );
                Runtime::US8::US8_0(
                    v14_1,
                    v51,
                    patternInput.0.clone(),
                    patternInput.1.clone(),
                    patternInput.2.clone(),
                )
            } else {
                let v74: i32 = (indexOf(v0.clone(), string("\n"))) - 1_i32;
                let v114: string = getSlice(
                    v0.clone(),
                    Some(0_i32),
                    Some(
                        (if -2_i32 == (v74) {
                            (length(v0)) + 1_i32
                        } else {
                            (v74) + 1_i32
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
                                (v114),
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
    pub fn method31(v0: Array<char>) -> string {
        let v2: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v18: () = {
            Runtime::closure7(v2.clone(), sprintf!("{:?}", v0), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method32(v0: string, v1: LrcPtr<StringBuilder>, v2: i32, v3: i32) -> string {
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
        let v74: () = {
            Runtime::closure7(v5.clone(), v0, ());
            ()
        };
        let v93: () = {
            Runtime::closure7(v5.clone(), string("; "), ());
            ()
        };
        let v112: () = {
            Runtime::closure7(v5.clone(), string("s"), ());
            ()
        };
        let v129: () = {
            Runtime::closure7(v5.clone(), string(" = "), ());
            ()
        };
        let v149: std::string::String = format!("{:#?}", v1);
        let v188: () = {
            Runtime::closure7(
                v5.clone(),
                fable_library_rust::String_::fromString(v149),
                (),
            );
            ()
        };
        let v207: () = {
            Runtime::closure7(v5.clone(), string(" }"), ());
            ()
        };
        v5.l0.get().clone()
    }
    pub fn method33(v0: char, v1: i64) -> bool {
        let v0: MutCell<char> = MutCell::new(v0);
        let v1: MutCell<i64> = MutCell::new(v1);
        '_method33: loop {
            break '_method33 (if (v1.get().clone()) >= 2_i64 {
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
                    continue '_method33;
                }
            });
        }
    }
    pub fn method34(v0: char, v1: string, v2: LrcPtr<StringBuilder>, v3: i32, v4: i32) -> string {
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
        let v150: () = {
            Runtime::closure7(v6.clone(), v1, ());
            ()
        };
        let v167: () = {
            Runtime::closure7(v6.clone(), string("; "), ());
            ()
        };
        let v186: () = {
            Runtime::closure7(v6.clone(), string("s"), ());
            ()
        };
        let v203: () = {
            Runtime::closure7(v6.clone(), string(" = "), ());
            ()
        };
        let v223: std::string::String = format!("{:#?}", v2);
        let v262: () = {
            Runtime::closure7(
                v6.clone(),
                fable_library_rust::String_::fromString(v223),
                (),
            );
            ()
        };
        let v281: () = {
            Runtime::closure7(v6.clone(), string(" }"), ());
            ()
        };
        v6.l0.get().clone()
    }
    pub fn method35(
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
        '_method35: loop {
            break '_method35 ({
                let v160: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method32(
                            Runtime::method31(toArray(ofArray(new_array(&['\"', '\''])))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v55: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method33(v55, 0_i64)) == false {
                        let v94: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v100: string = ofChar(v55);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                            Runtime::method26(length(v100.clone()) as i64, v100, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v55,
                            v94,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method34(
                                v55,
                                Runtime::method31(toArray(ofArray(new_array(&['\"', '\''])))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v172: Runtime::US8 = match &v160 {
                    Runtime::US8::US8_0(v160_0_0, v160_0_1, v160_0_2, v160_0_3, v160_0_4) => {
                        let v161: char = v160_0_0.clone();
                        Runtime::US8::US8_0(
                            if '\\' == (v161) { '/' } else { v161 },
                            v160_0_1.clone(),
                            v160_0_2.clone(),
                            v160_0_3.clone(),
                            v160_0_4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v160_1_0) => Runtime::US8::US8_1(v160_1_0.clone()),
                };
                match &v172 {
                    Runtime::US8::US8_0(v172_0_0, v172_0_1, v172_0_2, v172_0_3, v172_0_4) => {
                        let v0_temp: string =
                            append((v0.get().clone()), (ofChar(v172_0_0.clone())));
                        let v1_temp: string = v172_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v172_0_2.clone();
                        let v3_temp: i32 = v172_0_3.clone();
                        let v4_temp: i32 = v172_0_4.clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method35;
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
    pub fn method36(
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
        '_method36: loop {
            break '_method36 (match v4.get().clone().as_ref() {
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
                            continue '_method36;
                        }
                    }
                }
            });
        }
    }
    pub fn method37(
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
        let v194: std::string::String = format!("{:#?}", v2);
        let v233: () = {
            Runtime::closure7(
                v14_1.clone(),
                fable_library_rust::String_::fromString(v194),
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
        let v340: std::string::String = format!("{:#?}", v6);
        let v379: () = {
            Runtime::closure7(
                v14_1.clone(),
                fable_library_rust::String_::fromString(v340),
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
        let v486: std::string::String = format!("{:#?}", v10);
        let v525: () = {
            Runtime::closure7(
                v14_1.clone(),
                fable_library_rust::String_::fromString(v486),
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
    pub fn method38(v0: char, v1: i64) -> bool {
        let v0: MutCell<char> = MutCell::new(v0);
        let v1: MutCell<i64> = MutCell::new(v1);
        '_method38: loop {
            break '_method38 (if (v1.get().clone()) >= 3_i64 {
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
                    continue '_method38;
                }
            });
        }
    }
    pub fn method39(
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
        '_method39: loop {
            break '_method39 ({
                let v184: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method32(
                            Runtime::method31(toArray(ofArray(new_array(&['\"', '\'', ' '])))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v67: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method38(v67, 0_i64)) == false {
                        let v106: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v112: string = ofChar(v67);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                            Runtime::method26(length(v112.clone()) as i64, v112, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v67,
                            v106,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method34(
                                v67,
                                Runtime::method31(toArray(ofArray(new_array(&['\"', '\'', ' '])))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v196: Runtime::US8 = match &v184 {
                    Runtime::US8::US8_0(v184_0_0, v184_0_1, v184_0_2, v184_0_3, v184_0_4) => {
                        let v185: char = v184_0_0.clone();
                        Runtime::US8::US8_0(
                            if '\\' == (v185) { '/' } else { v185 },
                            v184_0_1.clone(),
                            v184_0_2.clone(),
                            v184_0_3.clone(),
                            v184_0_4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v184_1_0) => Runtime::US8::US8_1(v184_1_0.clone()),
                };
                match &v196 {
                    Runtime::US8::US8_0(v196_0_0, v196_0_1, v196_0_2, v196_0_3, v196_0_4) => {
                        let v0_temp: string =
                            append((v0.get().clone()), (ofChar(v196_0_0.clone())));
                        let v1_temp: string = v196_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v196_0_2.clone();
                        let v3_temp: i32 = v196_0_3.clone();
                        let v4_temp: i32 = v196_0_4.clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method39;
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
    pub fn method40(v0: string) -> string {
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
    pub fn method41(v0: string, v1: i32) -> i32 {
        let v0: MutCell<string> = MutCell::new(v0.clone());
        let v1: MutCell<i32> = MutCell::new(v1);
        '_method41: loop {
            break '_method41 (if (v1.get().clone()) >= (length(v0.get().clone())) {
                v1.get().clone()
            } else {
                if ' ' == (getCharAt(v0.get().clone(), v1.get().clone())) {
                    let v0_temp: string = v0.get().clone();
                    let v1_temp: i32 = (v1.get().clone()) + 1_i32;
                    v0.set(v0_temp);
                    v1.set(v1_temp);
                    continue '_method41;
                } else {
                    v1.get().clone()
                }
            });
        }
    }
    pub fn method42(v0: LrcPtr<StringBuilder>, v1: i32, v2: i32) -> string {
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
        let v76: std::string::String = format!("{:#?}", v0);
        let v115: () = {
            Runtime::closure7(v4.clone(), fable_library_rust::String_::fromString(v76), ());
            ()
        };
        let v134: () = {
            Runtime::closure7(v4.clone(), string(" }"), ());
            ()
        };
        v4.l0.get().clone()
    }
    pub fn method43(
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
        '_method43: loop {
            break '_method43 ({
                let v66: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.any_char / unexpected end of input / "),
                        (Runtime::method42(v2.get().clone(), v3.get().clone(), v4.get().clone())),
                    ))
                } else {
                    let v14_1: char = getCharAt(v1.get().clone(), 0_i32);
                    let v50: string = getSlice(
                        v1.get().clone(),
                        Some(1_i32),
                        Some((length(v1.get().clone())) - 1_i32),
                    );
                    let v56: string = ofChar(v14_1);
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                        Runtime::method26(length(v56.clone()) as i64, v56, 0_i64),
                        v2.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    );
                    Runtime::US8::US8_0(
                        v14_1,
                        v50,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                };
                match &v66 {
                    Runtime::US8::US8_0(v66_0_0, v66_0_1, v66_0_2, v66_0_3, v66_0_4) => {
                        let v0_temp: string = append((v0.get().clone()), (ofChar(v66_0_0.clone())));
                        let v1_temp: string = v66_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v66_0_2.clone();
                        let v3_temp: i32 = v66_0_3.clone();
                        let v4_temp: i32 = v66_0_4.clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method43;
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
            let v264: Runtime::US9 = match &v24 {
                Runtime::US8::US8_0(v24_0_0, v24_0_1, v24_0_2, v24_0_3, v24_0_4) => {
                    let v29: i32 = v24_0_4.clone();
                    let v28: i32 = v24_0_3.clone();
                    let v27: LrcPtr<StringBuilder> = v24_0_2.clone();
                    let v26: string = v24_0_1.clone();
                    let v185: Runtime::US8 = if string("") == (v26.clone()) {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected end of input / "),
                            (Runtime::method32(
                                Runtime::method31(toArray(ofArray(new_array(&['\"', '\''])))),
                                v27.clone(),
                                v28,
                                v29,
                            )),
                        ))
                    } else {
                        let v80: char = getCharAt(v26.clone(), 0_i32);
                        if (Runtime::method33(v80, 0_i64)) == false {
                            let v119: string = getSlice(
                                v26.clone(),
                                Some(1_i32),
                                Some((length(v26.clone())) - 1_i32),
                            );
                            let v125: string = ofChar(v80);
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                                Runtime::method26(length(v125.clone()) as i64, v125, 0_i64),
                                v27.clone(),
                                v28,
                                v29,
                            );
                            Runtime::US8::US8_0(
                                v80,
                                v119,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        } else {
                            Runtime::US8::US8_1(append(
                                string("parsing.none_of / unexpected char / "),
                                (Runtime::method34(
                                    v80,
                                    Runtime::method31(toArray(ofArray(new_array(&['\"', '\''])))),
                                    v27.clone(),
                                    v28,
                                    v29,
                                )),
                            ))
                        }
                    };
                    let v197: Runtime::US8 = match &v185 {
                        Runtime::US8::US8_0(v185_0_0, v185_0_1, v185_0_2, v185_0_3, v185_0_4) => {
                            let v186: char = v185_0_0.clone();
                            Runtime::US8::US8_0(
                                if '\\' == (v186) { '/' } else { v186 },
                                v185_0_1.clone(),
                                v185_0_2.clone(),
                                v185_0_3.clone(),
                                v185_0_4.clone(),
                            )
                        }
                        Runtime::US8::US8_1(v185_1_0) => Runtime::US8::US8_1(v185_1_0.clone()),
                    };
                    let v217: Runtime::US9 = match &v197 {
                        Runtime::US8::US8_0(v197_0_0, v197_0_1, v197_0_2, v197_0_3, v197_0_4) => {
                            let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method35(
                                    ofChar(v197_0_0.clone()),
                                    v197_0_1.clone(),
                                    v197_0_2.clone(),
                                    v197_0_3.clone(),
                                    v197_0_4.clone(),
                                );
                            Runtime::US9::US9_0(
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                                patternInput_1.3.clone(),
                                patternInput_1.4.clone(),
                            )
                        }
                        Runtime::US8::US8_1(v197_1_0) => Runtime::US9::US9_1(v197_1_0.clone()),
                    };
                    let v227: Runtime::US9 = match &v217 {
                        Runtime::US9::US9_0(v217_0_0, v217_0_1, v217_0_2, v217_0_3, v217_0_4) => {
                            Runtime::US9::US9_0(
                                v217_0_0.clone(),
                                v217_0_1.clone(),
                                v217_0_2.clone(),
                                v217_0_3.clone(),
                                v217_0_4.clone(),
                            )
                        }
                        _ => Runtime::US9::US9_0(string(""), v26.clone(), v27.clone(), v28, v29),
                    };
                    match &v227 {
                        Runtime::US9::US9_0(v227_0_0, v227_0_1, v227_0_2, v227_0_3, v227_0_4) => {
                            let v232: i32 = v227_0_4.clone();
                            let v231: i32 = v227_0_3.clone();
                            let v230: LrcPtr<StringBuilder> = v227_0_2.clone();
                            let v229: string = v227_0_1.clone();
                            let v236: Runtime::US8 = Runtime::method36(
                                v229.clone(),
                                v230.clone(),
                                v231,
                                v232,
                                LrcPtr::new(Runtime::UH1::UH1_1(
                                    Func1::from(v19),
                                    LrcPtr::new(Runtime::UH1::UH1_1(
                                        Func1::from(v20),
                                        LrcPtr::new(Runtime::UH1::UH1_0),
                                    )),
                                )),
                            );
                            match &v236 {
                                Runtime::US8::US8_0(
                                    v236_0_0,
                                    v236_0_1,
                                    v236_0_2,
                                    v236_0_3,
                                    v236_0_4,
                                ) => Runtime::US9::US9_0(
                                    v227_0_0.clone(),
                                    v236_0_1.clone(),
                                    v236_0_2.clone(),
                                    v236_0_3.clone(),
                                    v236_0_4.clone(),
                                ),
                                Runtime::US8::US8_1(v236_1_0) => Runtime::US9::US9_1(append(
                                    string("parsing.between / expected closing delimiter / "),
                                    (Runtime::method37(
                                        v236_1_0.clone(),
                                        v10.clone(),
                                        v16_1.clone(),
                                        1_i32,
                                        1_i32,
                                        v26.clone(),
                                        v27.clone(),
                                        v28,
                                        v29,
                                        v229.clone(),
                                        v230.clone(),
                                        v231,
                                        v232,
                                    )),
                                )),
                            }
                        }
                        _ => Runtime::US9::US9_1(string("parsing.between / expected content")),
                    }
                }
                Runtime::US8::US8_1(v24_1_0) => Runtime::US9::US9_1(v24_1_0.clone()),
            };
            let v570: Runtime::US9 = match &v264 {
                Runtime::US9::US9_0(v264_0_0, v264_0_1, v264_0_2, v264_0_3, v264_0_4) => {
                    v264.clone()
                }
                _ => {
                    let v456: Runtime::US8 = if string("") == (v10.clone()) {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected end of input / "),
                            (Runtime::method32(
                                Runtime::method31(toArray(ofArray(new_array(&['\"', '\'', ' '])))),
                                v16_1.clone(),
                                1_i32,
                                1_i32,
                            )),
                        ))
                    } else {
                        let v335: char = getCharAt(v10.clone(), 0_i32);
                        if (Runtime::method38(v335, 0_i64)) == false {
                            let v374: string = getSlice(
                                v10.clone(),
                                Some(1_i32),
                                Some((length(v10.clone())) - 1_i32),
                            );
                            let v380: string = ofChar(v335);
                            let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method27(
                                    Runtime::method26(length(v380.clone()) as i64, v380, 0_i64),
                                    v16_1.clone(),
                                    1_i32,
                                    1_i32,
                                );
                            Runtime::US8::US8_0(
                                v335,
                                v374,
                                patternInput_2.0.clone(),
                                patternInput_2.1.clone(),
                                patternInput_2.2.clone(),
                            )
                        } else {
                            Runtime::US8::US8_1(append(
                                string("parsing.none_of / unexpected char / "),
                                (Runtime::method34(
                                    v335,
                                    Runtime::method31(toArray(ofArray(new_array(&[
                                        '\"', '\'', ' ',
                                    ])))),
                                    v16_1.clone(),
                                    1_i32,
                                    1_i32,
                                )),
                            ))
                        }
                    };
                    let v468: Runtime::US8 = match &v456 {
                        Runtime::US8::US8_0(v456_0_0, v456_0_1, v456_0_2, v456_0_3, v456_0_4) => {
                            let v457: char = v456_0_0.clone();
                            Runtime::US8::US8_0(
                                if '\\' == (v457) { '/' } else { v457 },
                                v456_0_1.clone(),
                                v456_0_2.clone(),
                                v456_0_3.clone(),
                                v456_0_4.clone(),
                            )
                        }
                        Runtime::US8::US8_1(v456_1_0) => Runtime::US8::US8_1(v456_1_0.clone()),
                    };
                    let v488: Runtime::US9 = match &v468 {
                        Runtime::US8::US8_0(v468_0_0, v468_0_1, v468_0_2, v468_0_3, v468_0_4) => {
                            let patternInput_3: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method39(
                                    ofChar(v468_0_0.clone()),
                                    v468_0_1.clone(),
                                    v468_0_2.clone(),
                                    v468_0_3.clone(),
                                    v468_0_4.clone(),
                                );
                            Runtime::US9::US9_0(
                                patternInput_3.0.clone(),
                                patternInput_3.1.clone(),
                                patternInput_3.2.clone(),
                                patternInput_3.3.clone(),
                                patternInput_3.4.clone(),
                            )
                        }
                        Runtime::US8::US8_1(v468_1_0) => Runtime::US9::US9_1(v468_1_0.clone()),
                    };
                    match &v488 {
                        Runtime::US9::US9_0(v488_0_0, v488_0_1, v488_0_2, v488_0_3, v488_0_4) => {
                            v488.clone()
                        }
                        _ => {
                            let v506: Runtime::US11 = if (length(v10.clone())) == 0_i32 {
                                Runtime::US11::US11_0(v10.clone(), v16_1.clone(), 1_i32, 1_i32)
                            } else {
                                Runtime::US11::US11_1(append(
                                    string("parsing.eof / expected end of input / "),
                                    (Runtime::method40(v10.clone())),
                                ))
                            };
                            let v515: Runtime::US9 = match &v506 {
                                Runtime::US11::US11_0(v506_0_0, v506_0_1, v506_0_2, v506_0_3) => {
                                    Runtime::US9::US9_0(
                                        string(""),
                                        v506_0_0.clone(),
                                        v506_0_1.clone(),
                                        v506_0_2.clone(),
                                        v506_0_3.clone(),
                                    )
                                }
                                Runtime::US11::US11_1(v506_1_0) => {
                                    Runtime::US9::US9_1(v506_1_0.clone())
                                }
                            };
                            match &v515 {
                                Runtime::US9::US9_0(
                                    v515_0_0,
                                    v515_0_1,
                                    v515_0_2,
                                    v515_0_3,
                                    v515_0_4,
                                ) => {
                                    let v517: string = v515_0_1.clone();
                                    Runtime::US9::US9_0(
                                        v515_0_0.clone(),
                                        getSlice(
                                            v517.clone(),
                                            Some(Runtime::method41(v517.clone(), 0_i32)),
                                            Some((length(v517)) - 1_i32),
                                        ),
                                        v515_0_2.clone(),
                                        v515_0_3.clone(),
                                        v515_0_4.clone(),
                                    )
                                }
                                Runtime::US9::US9_1(v515_1_0) => {
                                    Runtime::US9::US9_1(v515_1_0.clone())
                                }
                            }
                        }
                    }
                }
            };
            let v868: Runtime::US12 = match &v570 {
                Runtime::US9::US9_0(v570_0_0, v570_0_1, v570_0_2, v570_0_3, v570_0_4) => {
                    let v575: i32 = v570_0_4.clone();
                    let v574: i32 = v570_0_3.clone();
                    let v573: LrcPtr<StringBuilder> = v570_0_2.clone();
                    let v572: string = v570_0_1.clone();
                    let v739: Runtime::US8 = if string("") == (v572.clone()) {
                        Runtime::US8::US8_1(append(
                            string("parsing.p_char / unexpected end of input / "),
                            (Runtime::method25(' ', v573.clone(), v574, v575)),
                        ))
                    } else {
                        let v586: char = getCharAt(v572.clone(), 0_i32);
                        if (v586) == ' ' {
                            let v623: string = getSlice(
                                v572.clone(),
                                Some(1_i32),
                                Some((length(v572.clone())) - 1_i32),
                            );
                            let v629: string = ofChar(v586);
                            let patternInput_4: (LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method27(
                                    Runtime::method26(length(v629.clone()) as i64, v629, 0_i64),
                                    v573.clone(),
                                    v574,
                                    v575,
                                );
                            Runtime::US8::US8_0(
                                v586,
                                v623,
                                patternInput_4.0.clone(),
                                patternInput_4.1.clone(),
                                patternInput_4.2.clone(),
                            )
                        } else {
                            let v646: i32 = (indexOf(v572.clone(), string("\n"))) - 1_i32;
                            let v686: string = getSlice(
                                v572.clone(),
                                Some(0_i32),
                                Some(
                                    (if -2_i32 == (v646) {
                                        (length(v572.clone())) + 1_i32
                                    } else {
                                        (v646) + 1_i32
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
                                                        (Runtime::method28(' ', v574, v575)),
                                                    )),
                                                    string("\n"),
                                                )),
                                                (toString(v573.clone())),
                                            )),
                                            (v686),
                                        )),
                                        string("\n"),
                                    )),
                                    (append(
                                        ((Runtime::method29((v575) - 1_i32, 0_i32))(string(""))),
                                        string("^"),
                                    )),
                                )),
                                string("\n"),
                            ))
                        }
                    };
                    let v751: Runtime::US13 = match &v739 {
                        Runtime::US8::US8_0(v739_0_0, v739_0_1, v739_0_2, v739_0_3, v739_0_4) => {
                            Runtime::US13::US13_0(
                                Runtime::US10::US10_0(v739_0_0.clone()),
                                v739_0_1.clone(),
                                v739_0_2.clone(),
                                v739_0_3.clone(),
                                v739_0_4.clone(),
                            )
                        }
                        _ => Runtime::US13::US13_0(
                            Runtime::US10::US10_1,
                            v572.clone(),
                            v573.clone(),
                            v574,
                            v575,
                        ),
                    };
                    let v842: Runtime::US9 = match &v751 {
                        Runtime::US13::US13_0(v751_0_0, v751_0_1, v751_0_2, v751_0_3, v751_0_4) => {
                            let v756: i32 = v751_0_4.clone();
                            let v755: i32 = v751_0_3.clone();
                            let v754: LrcPtr<StringBuilder> = v751_0_2.clone();
                            let v753: string = v751_0_1.clone();
                            let v818: Runtime::US8 = if string("") == (v753.clone()) {
                                Runtime::US8::US8_1(append(
                                    string("parsing.any_char / unexpected end of input / "),
                                    (Runtime::method42(v754.clone(), v755, v756)),
                                ))
                            } else {
                                let v766: char = getCharAt(v753.clone(), 0_i32);
                                let v802: string = getSlice(
                                    v753.clone(),
                                    Some(1_i32),
                                    Some((length(v753)) - 1_i32),
                                );
                                let v808: string = ofChar(v766);
                                let patternInput_5: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method27(
                                        Runtime::method26(length(v808.clone()) as i64, v808, 0_i64),
                                        v754,
                                        v755,
                                        v756,
                                    );
                                Runtime::US8::US8_0(
                                    v766,
                                    v802,
                                    patternInput_5.0.clone(),
                                    patternInput_5.1.clone(),
                                    patternInput_5.2.clone(),
                                )
                            };
                            match &v818 {
                                Runtime::US8::US8_0(
                                    v818_0_0,
                                    v818_0_1,
                                    v818_0_2,
                                    v818_0_3,
                                    v818_0_4,
                                ) => {
                                    let patternInput_6: (
                                        string,
                                        string,
                                        LrcPtr<StringBuilder>,
                                        i32,
                                        i32,
                                    ) = Runtime::method43(
                                        ofChar(v818_0_0.clone()),
                                        v818_0_1.clone(),
                                        v818_0_2.clone(),
                                        v818_0_3.clone(),
                                        v818_0_4.clone(),
                                    );
                                    Runtime::US9::US9_0(
                                        patternInput_6.0.clone(),
                                        patternInput_6.1.clone(),
                                        patternInput_6.2.clone(),
                                        patternInput_6.3.clone(),
                                        patternInput_6.4.clone(),
                                    )
                                }
                                Runtime::US8::US8_1(v818_1_0) => {
                                    Runtime::US9::US9_1(v818_1_0.clone())
                                }
                            }
                        }
                        Runtime::US13::US13_1(v751_1_0) => Runtime::US9::US9_1(v751_1_0.clone()),
                    };
                    let v854: Runtime::US14 = match &v842 {
                        Runtime::US9::US9_0(v842_0_0, v842_0_1, v842_0_2, v842_0_3, v842_0_4) => {
                            Runtime::US14::US14_0(
                                Runtime::US5::US5_0(v842_0_0.clone()),
                                v842_0_1.clone(),
                                v842_0_2.clone(),
                                v842_0_3.clone(),
                                v842_0_4.clone(),
                            )
                        }
                        _ => Runtime::US14::US14_0(
                            Runtime::US5::US5_1,
                            v572.clone(),
                            v573.clone(),
                            v574,
                            v575,
                        ),
                    };
                    match &v854 {
                        Runtime::US14::US14_0(v854_0_0, v854_0_1, v854_0_2, v854_0_3, v854_0_4) => {
                            Runtime::US12::US12_0(
                                v570_0_0.clone(),
                                v854_0_0.clone(),
                                v854_0_1.clone(),
                                v854_0_2.clone(),
                                v854_0_3.clone(),
                                v854_0_4.clone(),
                            )
                        }
                        Runtime::US14::US14_1(v854_1_0) => Runtime::US12::US12_1(v854_1_0.clone()),
                    }
                }
                Runtime::US9::US9_1(v570_1_0) => Runtime::US12::US12_1(v570_1_0.clone()),
            };
            match &v868 {
                Runtime::US12::US12_0(
                    v868_0_0,
                    v868_0_1,
                    v868_0_2,
                    v868_0_3,
                    v868_0_4,
                    v868_0_5,
                ) => Runtime::US7::US7_0(v868_0_0.clone(), v868_0_1.clone()),
                Runtime::US12::US12_1(v868_1_0) => Runtime::US7::US7_1(v868_1_0.clone()),
            }
        }
    }
    pub fn method44() -> string {
        let v8: string = Runtime::method12(getCharAt(toLower(string("Debug")), 0_i32));
        let v115: &str = inline_colorization::color_bright_blue;
        let v126: &str = &*v8;
        let v153: &str = inline_colorization::color_reset;
        let v155: std::string::String = format!("{}{}{}", v115, v126, v153);
        fable_library_rust::String_::fromString(v155)
    }
    pub fn method46(
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
        let v351: std::string::String = format!("{:#?}", v3);
        let v390: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v351),
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
        let v537: std::string::String = format!("{:#?}", v5);
        let v576: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v537),
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
        let v649: std::string::String = format!("{:#?}", v6);
        let v688: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v649),
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
        let v834: std::string::String = format!("{:#?}", v8);
        let v873: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v834),
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
    pub fn method45(
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
        let v17: string = Runtime::method46(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1);
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
            let v132: string = Runtime::method45(
                v112.clone(),
                v113.clone(),
                v114.clone(),
                v115.clone(),
                v116.clone(),
                v117.clone(),
                Runtime::method7(v112, v113, v114, v115, v116, v117),
                Runtime::method44(),
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
            let v174: LrcPtr<Runtime::Mut3> = patternInput_2.3.clone();
            let v172: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v171: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v193: () = {
                Runtime::closure8(v171.clone(), ());
                ()
            };
            let v216: string = if (v174.l0.get().clone()) == string("") {
                v132.clone()
            } else {
                if (v132.clone()) == string("") {
                    v174.l0.get().clone()
                } else {
                    append(
                        (append((v174.l0.get().clone()), string("\n"))),
                        (v132.clone()),
                    )
                }
            };
            let v227: &str = &*v216.clone();
            let v254 = v227.chars();
            let v256 = v254;
            let v258: Vec<char> = v256.collect::<Vec<_>>();
            let v260: Vec<Vec<char>> = v258
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v262: bool = true;
            let _vec_map: Vec<_> = v260
                .into_iter()
                .map(|x| {
                    //;
                    let v264: Vec<char> = x;
                    let v266: std::string::String = String::from_iter(v264);
                    let v268: bool = true;
                    v266
                })
                .collect::<Vec<_>>();
            let v270: Vec<std::string::String> = _vec_map;
            if if (v132.clone()) != string("") {
                (v270.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v174.l0.set(v216);
                ()
            } else {
                v174.l0.set(string(""));
                {
                    let v295: bool = true;
                    v270.into_iter().for_each(|x| {
                        //;
                        let v297: std::string::String = x;
                        let v299: bool = true;
                        near_sdk::log!("{}", v297);
                        let v301: bool = true;
                        let v303: bool = true;
                    }); //;
                    ()
                }
            }
            (v172.l0.get().clone())(v132);
            Runtime::US6::US6_0(
                v171,
                v172,
                patternInput_2.2.clone(),
                v174,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method47(
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
    pub fn method48(v0: i32, v1: LrcPtr<Runtime::Mut5>) -> bool {
        (v1.l0.get().clone()) < (v0)
    }
    pub fn method51(v0: bool) -> string {
        unbox::<string>(fable_library_rust::Native_::getZero())
    }
    pub fn closure19(unitVar: (), v0: Func1<(i32, string, bool), Arc<Async<()>>>) -> Runtime::US15 {
        Runtime::US15::US15_0(v0)
    }
    pub fn method52() -> Func1<Func1<(i32, string, bool), Arc<Async<()>>>, Runtime::US15> {
        Func1::new(move |v: Func1<(i32, string, bool), Arc<Async<()>>>| Runtime::closure19((), v))
    }
    pub fn method53(v0: bool) -> i32 {
        unbox::<i32>(fable_library_rust::Native_::getZero())
    }
    pub fn method54() -> string {
        let v8: string = Runtime::method12(getCharAt(toLower(string("Verbose")), 0_i32));
        let v115: &str = inline_colorization::color_bright_black;
        let v126: &str = &*v8;
        let v153: &str = inline_colorization::color_reset;
        let v155: std::string::String = format!("{}{}{}", v115, v126, v153);
        fable_library_rust::String_::fromString(v155)
    }
    pub fn method55(
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
                Runtime::method55(
                    v104.clone(),
                    v105.clone(),
                    v106.clone(),
                    v107.clone(),
                    v108.clone(),
                    v109.clone(),
                    Runtime::method7(v104, v105, v106, v107, v108, v109),
                    Runtime::method54(),
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
            let v169: LrcPtr<Runtime::Mut3> = patternInput_2.3.clone();
            let v167: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v166: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v188: () = {
                Runtime::closure8(v166.clone(), ());
                ()
            };
            let v211: string = if (v169.l0.get().clone()) == string("") {
                v127.clone()
            } else {
                if (v127.clone()) == string("") {
                    v169.l0.get().clone()
                } else {
                    append(
                        (append((v169.l0.get().clone()), string("\n"))),
                        (v127.clone()),
                    )
                }
            };
            let v222: &str = &*v211.clone();
            let v249 = v222.chars();
            let v251 = v249;
            let v253: Vec<char> = v251.collect::<Vec<_>>();
            let v255: Vec<Vec<char>> = v253
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v257: bool = true;
            let _vec_map: Vec<_> = v255
                .into_iter()
                .map(|x| {
                    //;
                    let v259: Vec<char> = x;
                    let v261: std::string::String = String::from_iter(v259);
                    let v263: bool = true;
                    v261
                })
                .collect::<Vec<_>>();
            let v265: Vec<std::string::String> = _vec_map;
            if if (v127.clone()) != string("") {
                (v265.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v169.l0.set(v211);
                ()
            } else {
                v169.l0.set(string(""));
                {
                    let v290: bool = true;
                    v265.into_iter().for_each(|x| {
                        //;
                        let v292: std::string::String = x;
                        let v294: bool = true;
                        near_sdk::log!("{}", v292);
                        let v296: bool = true;
                        let v298: bool = true;
                    }); //;
                    ()
                }
            }
            (v167.l0.get().clone())(v127);
            Runtime::US6::US6_0(
                v166,
                v167,
                patternInput_2.2.clone(),
                v169,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method50(
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
        Runtime::method50(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
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
        let v11: Arc<Async<()>> = Runtime::method49(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10);
        fable_library_rust::Native_::getZero::<()>();
        ()
    }
    pub fn closure21(unitVar: (), v0: CancellationToken) -> Runtime::US16 {
        Runtime::US16::US16_0(v0)
    }
    pub fn method56() -> Func1<CancellationToken, Runtime::US16> {
        Func1::new(move |v: CancellationToken| Runtime::closure21((), v))
    }
    pub fn method57(v0: CancellationToken) -> Arc<Async<CancellationToken>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method58(v0: bool) -> bool {
        unbox::<bool>(fable_library_rust::Native_::getZero())
    }
    pub fn method59(v0: bool) {
        ();
    }
    pub fn closure22(v0: bool, unitVar: ()) {
        if (Runtime::method58(v0)) == false {
            Runtime::method59(v0);
        };
    }
    pub fn method62(v0: LrcPtr<TaskCanceledException>) -> string {
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
        let v74: std::string::String = format!("{:#?}", v0);
        let v113: () = {
            Runtime::closure7(v2.clone(), fable_library_rust::String_::fromString(v74), ());
            ()
        };
        let v132: () = {
            Runtime::closure7(v2.clone(), string(" }"), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method61(
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
        let v9: string = Runtime::method62(v8);
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
            let v124: string = Runtime::method61(
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
            let v166: LrcPtr<Runtime::Mut3> = patternInput_2.3.clone();
            let v164: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v163: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v185: () = {
                Runtime::closure8(v163.clone(), ());
                ()
            };
            let v208: string = if (v166.l0.get().clone()) == string("") {
                v124.clone()
            } else {
                if (v124.clone()) == string("") {
                    v166.l0.get().clone()
                } else {
                    append(
                        (append((v166.l0.get().clone()), string("\n"))),
                        (v124.clone()),
                    )
                }
            };
            let v219: &str = &*v208.clone();
            let v246 = v219.chars();
            let v248 = v246;
            let v250: Vec<char> = v248.collect::<Vec<_>>();
            let v252: Vec<Vec<char>> = v250
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v254: bool = true;
            let _vec_map: Vec<_> = v252
                .into_iter()
                .map(|x| {
                    //;
                    let v256: Vec<char> = x;
                    let v258: std::string::String = String::from_iter(v256);
                    let v260: bool = true;
                    v258
                })
                .collect::<Vec<_>>();
            let v262: Vec<std::string::String> = _vec_map;
            if if (v124.clone()) != string("") {
                (v262.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v166.l0.set(v208);
                ()
            } else {
                v166.l0.set(string(""));
                {
                    let v287: bool = true;
                    v262.into_iter().for_each(|x| {
                        //;
                        let v289: std::string::String = x;
                        let v291: bool = true;
                        near_sdk::log!("{}", v289);
                        let v293: bool = true;
                        let v295: bool = true;
                    }); //;
                    ()
                }
            }
            (v164.l0.get().clone())(v124);
            Runtime::US6::US6_0(
                v163,
                v164,
                patternInput_2.2.clone(),
                v166,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method60(
        v0: bool,
        v1: LrcPtr<ConcurrentStack_1<string>>,
        v2: CancellationToken,
    ) -> Arc<Async<i32>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method63() -> string {
        string("\n")
    }
    pub fn method65(
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
        let v353: std::string::String = format!("{:#?}", v3);
        let v392: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v353),
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
        let v539: std::string::String = format!("{:#?}", v5);
        let v578: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v539),
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
        let v651: std::string::String = format!("{:#?}", v6);
        let v690: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v651),
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
        let v836: std::string::String = format!("{:#?}", v8);
        let v875: () = {
            Runtime::closure7(
                v10.clone(),
                fable_library_rust::String_::fromString(v836),
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
    pub fn method64(
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
        let v17: string = Runtime::method65(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1);
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
            let v133: string = Runtime::method64(
                v112.clone(),
                v113.clone(),
                v114.clone(),
                v115.clone(),
                v116.clone(),
                v117.clone(),
                Runtime::method7(v112, v113, v114, v115, v116, v117),
                Runtime::method44(),
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
            let v175: LrcPtr<Runtime::Mut3> = patternInput_2.3.clone();
            let v173: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v172: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v194: () = {
                Runtime::closure8(v172.clone(), ());
                ()
            };
            let v217: string = if (v175.l0.get().clone()) == string("") {
                v133.clone()
            } else {
                if (v133.clone()) == string("") {
                    v175.l0.get().clone()
                } else {
                    append(
                        (append((v175.l0.get().clone()), string("\n"))),
                        (v133.clone()),
                    )
                }
            };
            let v228: &str = &*v217.clone();
            let v255 = v228.chars();
            let v257 = v255;
            let v259: Vec<char> = v257.collect::<Vec<_>>();
            let v261: Vec<Vec<char>> = v259
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v263: bool = true;
            let _vec_map: Vec<_> = v261
                .into_iter()
                .map(|x| {
                    //;
                    let v265: Vec<char> = x;
                    let v267: std::string::String = String::from_iter(v265);
                    let v269: bool = true;
                    v267
                })
                .collect::<Vec<_>>();
            let v271: Vec<std::string::String> = _vec_map;
            if if (v133.clone()) != string("") {
                (v271.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v175.l0.set(v217);
                ()
            } else {
                v175.l0.set(string(""));
                {
                    let v296: bool = true;
                    v271.into_iter().for_each(|x| {
                        //;
                        let v298: std::string::String = x;
                        let v300: bool = true;
                        near_sdk::log!("{}", v298);
                        let v302: bool = true;
                        let v304: bool = true;
                    }); //;
                    ()
                }
            }
            (v173.l0.get().clone())(v133);
            Runtime::US6::US6_0(
                v172,
                v173,
                patternInput_2.2.clone(),
                v175,
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
    pub fn method68(v0: char, v1: i64) -> bool {
        let v0: MutCell<char> = MutCell::new(v0);
        let v1: MutCell<i64> = MutCell::new(v1);
        '_method68: loop {
            break '_method68 (if (v1.get().clone()) >= 4_i64 {
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
                    continue '_method68;
                }
            });
        }
    }
    pub fn method69(
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
        '_method69: loop {
            break '_method69 ({
                let v208: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method32(
                            Runtime::method31(toArray(ofArray(new_array(&['\\', '`', '\"', ' '])))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v79: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method68(v79, 0_i64)) == false {
                        let v118: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v124: string = ofChar(v79);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                            Runtime::method26(length(v124.clone()) as i64, v124, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v79,
                            v118,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method34(
                                v79,
                                Runtime::method31(toArray(ofArray(new_array(&[
                                    '\\', '`', '\"', ' ',
                                ])))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                match &v208 {
                    Runtime::US8::US8_0(v208_0_0, v208_0_1, v208_0_2, v208_0_3, v208_0_4) => {
                        let v0_temp: string =
                            append((v0.get().clone()), (ofChar(v208_0_0.clone())));
                        let v1_temp: string = v208_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v208_0_2.clone();
                        let v3_temp: i32 = v208_0_3.clone();
                        let v4_temp: i32 = v208_0_4.clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method69;
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
    pub fn method71(v0: char, v1: i64) -> bool {
        let v0: MutCell<char> = MutCell::new(v0);
        let v1: MutCell<i64> = MutCell::new(v1);
        '_method71: loop {
            break '_method71 (if (v1.get().clone()) >= 3_i64 {
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
                    continue '_method71;
                }
            });
        }
    }
    pub fn closure28(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US9 {
        let v3: i32 = _arg.3.clone();
        let v2: i32 = _arg.2.clone();
        let v1: LrcPtr<StringBuilder> = _arg.1.clone();
        let v0: string = _arg.0.clone();
        let v168: Runtime::US8 = if string("") == (v0.clone()) {
            Runtime::US8::US8_1(append(
                string("parsing.p_char / unexpected end of input / "),
                (Runtime::method25('\\', v1.clone(), v2, v3)),
            ))
        } else {
            let v14_1: char = getCharAt(v0.clone(), 0_i32);
            if (v14_1) == '\\' {
                let v51: string =
                    getSlice(v0.clone(), Some(1_i32), Some((length(v0.clone())) - 1_i32));
                let v57: string = ofChar(v14_1);
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                    Runtime::method26(length(v57.clone()) as i64, v57, 0_i64),
                    v1.clone(),
                    v2,
                    v3,
                );
                Runtime::US8::US8_0(
                    v14_1,
                    v51,
                    patternInput.0.clone(),
                    patternInput.1.clone(),
                    patternInput.2.clone(),
                )
            } else {
                let v74: i32 = (indexOf(v0.clone(), string("\n"))) - 1_i32;
                let v114: string = getSlice(
                    v0.clone(),
                    Some(0_i32),
                    Some(
                        (if -2_i32 == (v74) {
                            (length(v0)) + 1_i32
                        } else {
                            (v74) + 1_i32
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
                                (v114),
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
        let v239: Runtime::US8 = match &v168 {
            Runtime::US8::US8_0(v168_0_0, v168_0_1, v168_0_2, v168_0_3, v168_0_4) => {
                let v173: i32 = v168_0_4.clone();
                let v172: i32 = v168_0_3.clone();
                let v171: LrcPtr<StringBuilder> = v168_0_2.clone();
                let v170: string = v168_0_1.clone();
                if string("") == (v170.clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.any_char / unexpected end of input / "),
                        (Runtime::method42(v171.clone(), v172, v173)),
                    ))
                } else {
                    let v183: char = getCharAt(v170.clone(), 0_i32);
                    let v219: string =
                        getSlice(v170.clone(), Some(1_i32), Some((length(v170)) - 1_i32));
                    let v225: string = ofChar(v183);
                    let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                        Runtime::method26(length(v225.clone()) as i64, v225, 0_i64),
                        v171,
                        v172,
                        v173,
                    );
                    Runtime::US8::US8_0(
                        v183,
                        v219,
                        patternInput_1.0.clone(),
                        patternInput_1.1.clone(),
                        patternInput_1.2.clone(),
                    )
                }
            }
            Runtime::US8::US8_1(v168_1_0) => Runtime::US8::US8_1(v168_1_0.clone()),
        };
        match &v239 {
            Runtime::US8::US8_0(v239_0_0, v239_0_1, v239_0_2, v239_0_3, v239_0_4) => {
                Runtime::US9::US9_0(
                    append((ofChar('\\')), (ofChar(v239_0_0.clone()))),
                    v239_0_1.clone(),
                    v239_0_2.clone(),
                    v239_0_3.clone(),
                    v239_0_4.clone(),
                )
            }
            Runtime::US8::US8_1(v239_1_0) => Runtime::US9::US9_1(v239_1_0.clone()),
        }
    }
    pub fn closure29(unitVar: (), _arg: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US9 {
        let v3: i32 = _arg.3.clone();
        let v2: i32 = _arg.2.clone();
        let v1: LrcPtr<StringBuilder> = _arg.1.clone();
        let v0: string = _arg.0.clone();
        let v168: Runtime::US8 = if string("") == (v0.clone()) {
            Runtime::US8::US8_1(append(
                string("parsing.p_char / unexpected end of input / "),
                (Runtime::method25('`', v1.clone(), v2, v3)),
            ))
        } else {
            let v14_1: char = getCharAt(v0.clone(), 0_i32);
            if (v14_1) == '`' {
                let v51: string =
                    getSlice(v0.clone(), Some(1_i32), Some((length(v0.clone())) - 1_i32));
                let v57: string = ofChar(v14_1);
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                    Runtime::method26(length(v57.clone()) as i64, v57, 0_i64),
                    v1.clone(),
                    v2,
                    v3,
                );
                Runtime::US8::US8_0(
                    v14_1,
                    v51,
                    patternInput.0.clone(),
                    patternInput.1.clone(),
                    patternInput.2.clone(),
                )
            } else {
                let v74: i32 = (indexOf(v0.clone(), string("\n"))) - 1_i32;
                let v114: string = getSlice(
                    v0.clone(),
                    Some(0_i32),
                    Some(
                        (if -2_i32 == (v74) {
                            (length(v0)) + 1_i32
                        } else {
                            (v74) + 1_i32
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
                                (v114),
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
        let v239: Runtime::US8 = match &v168 {
            Runtime::US8::US8_0(v168_0_0, v168_0_1, v168_0_2, v168_0_3, v168_0_4) => {
                let v173: i32 = v168_0_4.clone();
                let v172: i32 = v168_0_3.clone();
                let v171: LrcPtr<StringBuilder> = v168_0_2.clone();
                let v170: string = v168_0_1.clone();
                if string("") == (v170.clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.any_char / unexpected end of input / "),
                        (Runtime::method42(v171.clone(), v172, v173)),
                    ))
                } else {
                    let v183: char = getCharAt(v170.clone(), 0_i32);
                    let v219: string =
                        getSlice(v170.clone(), Some(1_i32), Some((length(v170)) - 1_i32));
                    let v225: string = ofChar(v183);
                    let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                        Runtime::method26(length(v225.clone()) as i64, v225, 0_i64),
                        v171,
                        v172,
                        v173,
                    );
                    Runtime::US8::US8_0(
                        v183,
                        v219,
                        patternInput_1.0.clone(),
                        patternInput_1.1.clone(),
                        patternInput_1.2.clone(),
                    )
                }
            }
            Runtime::US8::US8_1(v168_1_0) => Runtime::US8::US8_1(v168_1_0.clone()),
        };
        match &v239 {
            Runtime::US8::US8_0(v239_0_0, v239_0_1, v239_0_2, v239_0_3, v239_0_4) => {
                Runtime::US9::US9_0(
                    append((ofChar('`')), (ofChar(v239_0_0.clone()))),
                    v239_0_1.clone(),
                    v239_0_2.clone(),
                    v239_0_3.clone(),
                    v239_0_4.clone(),
                )
            }
            Runtime::US8::US8_1(v239_1_0) => Runtime::US9::US9_1(v239_1_0.clone()),
        }
    }
    pub fn method72(
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
        '_method72: loop {
            break '_method72 (match v4.get().clone().as_ref() {
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
                            continue '_method72;
                        }
                    }
                }
            });
        }
    }
    pub fn method73(v0: LrcPtr<Runtime::UH2>, v1: LrcPtr<Runtime::UH2>) -> LrcPtr<Runtime::UH2> {
        let v0: MutCell<LrcPtr<Runtime::UH2>> = MutCell::new(v0.clone());
        let v1: MutCell<LrcPtr<Runtime::UH2>> = MutCell::new(v1.clone());
        '_method73: loop {
            break '_method73 (match v0.get().clone().as_ref() {
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
                    continue '_method73;
                }
            });
        }
    }
    pub fn method70(
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
        '_method70: loop {
            break '_method70 ({
                let v184: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method32(
                            Runtime::method31(toArray(ofArray(new_array(&['\\', '`', '\"'])))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v67: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method71(v67, 0_i64)) == false {
                        let v106: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v112: string = ofChar(v67);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                            Runtime::method26(length(v112.clone()) as i64, v112, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v67,
                            v106,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method34(
                                v67,
                                Runtime::method31(toArray(ofArray(new_array(&['\\', '`', '\"'])))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v199: Runtime::US9 = match &v184 {
                    Runtime::US8::US8_0(v184_0_0, v184_0_1, v184_0_2, v184_0_3, v184_0_4) => {
                        Runtime::US9::US9_0(
                            ofChar(v184_0_0.clone()),
                            v184_0_1.clone(),
                            v184_0_2.clone(),
                            v184_0_3.clone(),
                            v184_0_4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v184_1_0) => Runtime::US9::US9_1(v184_1_0.clone()),
                };
                let v213: Runtime::US9 = match &v199 {
                    Runtime::US9::US9_0(v199_0_0, v199_0_1, v199_0_2, v199_0_3, v199_0_4) => {
                        v199.clone()
                    }
                    _ => Runtime::method72(
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
                match &v213 {
                    Runtime::US9::US9_0(v213_0_0, v213_0_1, v213_0_2, v213_0_3, v213_0_4) => {
                        let v0_temp: LrcPtr<Runtime::UH2> =
                            LrcPtr::new(Runtime::UH2::UH2_1(v213_0_0.clone(), v0.get().clone()));
                        let v1_temp: string = v213_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v213_0_2.clone();
                        let v3_temp: i32 = v213_0_3.clone();
                        let v4_temp: i32 = v213_0_4.clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method70;
                    }
                    _ => Runtime::US18::US18_0(
                        Runtime::method73(v0.get().clone(), LrcPtr::new(Runtime::UH2::UH2_0)),
                        v1.get().clone(),
                        v2.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method74(v0: LrcPtr<Runtime::UH2>, v1: List<string>) -> List<string> {
        match v0.as_ref() {
            Runtime::UH2::UH2_0 => v1.clone(),
            Runtime::UH2::UH2_1(v0_1_0, v0_1_1) => cons(
                match v0.as_ref() {
                    Runtime::UH2::UH2_1(x, _) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                Runtime::method74(
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
    pub fn method75(
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
        '_method75: loop {
            break '_method75 ({
                let v184: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method32(
                            Runtime::method31(toArray(ofArray(new_array(&['\\', '`', '\"'])))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v67: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method71(v67, 0_i64)) == false {
                        let v106: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v112: string = ofChar(v67);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                            Runtime::method26(length(v112.clone()) as i64, v112, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v67,
                            v106,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method34(
                                v67,
                                Runtime::method31(toArray(ofArray(new_array(&['\\', '`', '\"'])))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v199: Runtime::US9 = match &v184 {
                    Runtime::US8::US8_0(v184_0_0, v184_0_1, v184_0_2, v184_0_3, v184_0_4) => {
                        Runtime::US9::US9_0(
                            ofChar(v184_0_0.clone()),
                            v184_0_1.clone(),
                            v184_0_2.clone(),
                            v184_0_3.clone(),
                            v184_0_4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v184_1_0) => Runtime::US9::US9_1(v184_1_0.clone()),
                };
                match &v199 {
                    Runtime::US9::US9_0(v199_0_0, v199_0_1, v199_0_2, v199_0_3, v199_0_4) => {
                        let v0_temp: LrcPtr<Runtime::UH2> =
                            LrcPtr::new(Runtime::UH2::UH2_1(v199_0_0.clone(), v0.get().clone()));
                        let v1_temp: string = v199_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v199_0_2.clone();
                        let v3_temp: i32 = v199_0_3.clone();
                        let v4_temp: i32 = v199_0_4.clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method75;
                    }
                    _ => Runtime::US18::US18_0(
                        Runtime::method73(v0.get().clone(), LrcPtr::new(Runtime::UH2::UH2_0)),
                        v1.get().clone(),
                        v2.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method67(
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
        '_method67: loop {
            break '_method67 ({
                let v5: bool = string("") == (v1.get().clone());
                let v208: Runtime::US8 = if v5 {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method32(
                            Runtime::method31(toArray(ofArray(new_array(&['\\', '`', '\"', ' '])))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v79: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method68(v79, 0_i64)) == false {
                        let v118: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v124: string = ofChar(v79);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method27(
                            Runtime::method26(length(v124.clone()) as i64, v124, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v79,
                            v118,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method34(
                                v79,
                                Runtime::method31(toArray(ofArray(new_array(&[
                                    '\\', '`', '\"', ' ',
                                ])))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v228: Runtime::US9 = match &v208 {
                    Runtime::US8::US8_0(v208_0_0, v208_0_1, v208_0_2, v208_0_3, v208_0_4) => {
                        let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                            Runtime::method69(
                                ofChar(v208_0_0.clone()),
                                v208_0_1.clone(),
                                v208_0_2.clone(),
                                v208_0_3.clone(),
                                v208_0_4.clone(),
                            );
                        Runtime::US9::US9_0(
                            patternInput_1.0.clone(),
                            patternInput_1.1.clone(),
                            patternInput_1.2.clone(),
                            patternInput_1.3.clone(),
                            patternInput_1.4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v208_1_0) => Runtime::US9::US9_1(v208_1_0.clone()),
                };
                let v705: Runtime::US9 = match &v228 {
                    Runtime::US9::US9_0(v228_0_0, v228_0_1, v228_0_2, v228_0_3, v228_0_4) => {
                        v228.clone()
                    }
                    _ => {
                        let v398: Runtime::US8 = if v5 {
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
                            let v244: char = getCharAt(v1.get().clone(), 0_i32);
                            if (v244) == '\"' {
                                let v281: string = getSlice(
                                    v1.get().clone(),
                                    Some(1_i32),
                                    Some((length(v1.get().clone())) - 1_i32),
                                );
                                let v287: string = ofChar(v244);
                                let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method27(
                                        Runtime::method26(length(v287.clone()) as i64, v287, 0_i64),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Runtime::US8::US8_0(
                                    v244,
                                    v281,
                                    patternInput_2.0.clone(),
                                    patternInput_2.1.clone(),
                                    patternInput_2.2.clone(),
                                )
                            } else {
                                let v304: i32 = (indexOf(v1.get().clone(), string("\n"))) - 1_i32;
                                let v344: string = getSlice(
                                    v1.get().clone(),
                                    Some(0_i32),
                                    Some(
                                        (if -2_i32 == (v304) {
                                            (length(v1.get().clone())) + 1_i32
                                        } else {
                                            (v304) + 1_i32
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
                                                (v344),
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
                        let v634: Runtime::US9 = match &v398 {
                            Runtime::US8::US8_0(
                                v398_0_0,
                                v398_0_1,
                                v398_0_2,
                                v398_0_3,
                                v398_0_4,
                            ) => {
                                let v403: i32 = v398_0_4.clone();
                                let v402: i32 = v398_0_3.clone();
                                let v401: LrcPtr<StringBuilder> = v398_0_2.clone();
                                let v400: string = v398_0_1.clone();
                                let v405: Runtime::US18 = Runtime::method70(
                                    LrcPtr::new(Runtime::UH2::UH2_0),
                                    v400.clone(),
                                    v401.clone(),
                                    v402,
                                    v403,
                                );
                                let v438: Runtime::US9 = match &v405 {
                                    Runtime::US18::US18_0(
                                        v405_0_0,
                                        v405_0_1,
                                        v405_0_2,
                                        v405_0_3,
                                        v405_0_4,
                                    ) => {
                                        let v412: List<string> =
                                            Runtime::method74(v405_0_0.clone(), empty::<string>());
                                        Runtime::US9::US9_0(
                                            join(
                                                string(""),
                                                toArray_1(delay(Func0::new({
                                                    let v412 = v412.clone();
                                                    move || ofList(v412.clone()).clone()
                                                }))),
                                            ),
                                            v405_0_1.clone(),
                                            v405_0_2.clone(),
                                            v405_0_3.clone(),
                                            v405_0_4.clone(),
                                        )
                                    }
                                    Runtime::US18::US18_1(v405_1_0) => {
                                        Runtime::US9::US9_1(v405_1_0.clone())
                                    }
                                };
                                match &v438 {
                                    Runtime::US9::US9_0(
                                        v438_0_0,
                                        v438_0_1,
                                        v438_0_2,
                                        v438_0_3,
                                        v438_0_4,
                                    ) => {
                                        let v443: i32 = v438_0_4.clone();
                                        let v442: i32 = v438_0_3.clone();
                                        let v441: LrcPtr<StringBuilder> = v438_0_2.clone();
                                        let v440: string = v438_0_1.clone();
                                        let v608: Runtime::US8 = if string("") == (v440.clone()) {
                                            Runtime::US8::US8_1(append(
                                                string(
                                                    "parsing.p_char / unexpected end of input / ",
                                                ),
                                                (Runtime::method25('\"', v441.clone(), v442, v443)),
                                            ))
                                        } else {
                                            let v454: char = getCharAt(v440.clone(), 0_i32);
                                            if (v454) == '\"' {
                                                let v491: string = getSlice(
                                                    v440.clone(),
                                                    Some(1_i32),
                                                    Some((length(v440.clone())) - 1_i32),
                                                );
                                                let v497: string = ofChar(v454);
                                                let patternInput_3: (
                                                    LrcPtr<StringBuilder>,
                                                    i32,
                                                    i32,
                                                ) = Runtime::method27(
                                                    Runtime::method26(
                                                        length(v497.clone()) as i64,
                                                        v497,
                                                        0_i64,
                                                    ),
                                                    v441.clone(),
                                                    v442,
                                                    v443,
                                                );
                                                Runtime::US8::US8_0(
                                                    v454,
                                                    v491,
                                                    patternInput_3.0.clone(),
                                                    patternInput_3.1.clone(),
                                                    patternInput_3.2.clone(),
                                                )
                                            } else {
                                                let v514: i32 =
                                                    (indexOf(v440.clone(), string("\n"))) - 1_i32;
                                                let v554: string = getSlice(
                                                    v440.clone(),
                                                    Some(0_i32),
                                                    Some(
                                                        (if -2_i32 == (v514) {
                                                            (length(v440.clone())) + 1_i32
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
                                                                            string(
                                                                                "parsing.p_char / ",
                                                                            ),
                                                                            (Runtime::method28(
                                                                                '\"', v442, v443,
                                                                            )),
                                                                        )),
                                                                        string("\n"),
                                                                    )),
                                                                    (toString(v441.clone())),
                                                                )),
                                                                (v554),
                                                            )),
                                                            string("\n"),
                                                        )),
                                                        (append(
                                                            ((Runtime::method29(
                                                                (v443) - 1_i32,
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
                                        match &v608 {
                                            Runtime::US8::US8_0(
                                                v608_0_0,
                                                v608_0_1,
                                                v608_0_2,
                                                v608_0_3,
                                                v608_0_4,
                                            ) => Runtime::US9::US9_0(
                                                v438_0_0.clone(),
                                                v608_0_1.clone(),
                                                v608_0_2.clone(),
                                                v608_0_3.clone(),
                                                v608_0_4.clone(),
                                            ),
                                            Runtime::US8::US8_1(v608_1_0) => {
                                                Runtime::US9::US9_1(append(
                                                    string(
                                                        "parsing.between / expected closing delimiter / ",
                                                    ),
                                                    (Runtime::method37(
                                                        v608_1_0.clone(),
                                                        v1.get().clone(),
                                                        v2.get().clone(),
                                                        v3.get().clone(),
                                                        v4.get().clone(),
                                                        v400.clone(),
                                                        v401.clone(),
                                                        v402,
                                                        v403,
                                                        v440.clone(),
                                                        v441.clone(),
                                                        v442,
                                                        v443,
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
                            Runtime::US8::US8_1(v398_1_0) => Runtime::US9::US9_1(v398_1_0.clone()),
                        };
                        match &v634 {
                            Runtime::US9::US9_0(
                                v634_0_0,
                                v634_0_1,
                                v634_0_2,
                                v634_0_3,
                                v634_0_4,
                            ) => v634.clone(),
                            _ => {
                                let v646: Runtime::US9 = Runtime::method72(
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
                                let v657: Runtime::US9 = match &v646 {
                                    Runtime::US9::US9_0(
                                        v646_0_0,
                                        v646_0_1,
                                        v646_0_2,
                                        v646_0_3,
                                        v646_0_4,
                                    ) => Runtime::US9::US9_0(
                                        string(""),
                                        v646_0_1.clone(),
                                        v646_0_2.clone(),
                                        v646_0_3.clone(),
                                        v646_0_4.clone(),
                                    ),
                                    Runtime::US9::US9_1(v646_1_0) => {
                                        Runtime::US9::US9_1(v646_1_0.clone())
                                    }
                                };
                                let v668: Runtime::US18 = match &v657 {
                                    Runtime::US9::US9_0(
                                        v657_0_0,
                                        v657_0_1,
                                        v657_0_2,
                                        v657_0_3,
                                        v657_0_4,
                                    ) => Runtime::method75(
                                        LrcPtr::new(Runtime::UH2::UH2_0),
                                        v657_0_1.clone(),
                                        v657_0_2.clone(),
                                        v657_0_3.clone(),
                                        v657_0_4.clone(),
                                    ),
                                    Runtime::US9::US9_1(v657_1_0) => {
                                        Runtime::US18::US18_1(v657_1_0.clone())
                                    }
                                };
                                match &v668 {
                                    Runtime::US18::US18_0(
                                        v668_0_0,
                                        v668_0_1,
                                        v668_0_2,
                                        v668_0_3,
                                        v668_0_4,
                                    ) => {
                                        let v675: List<string> =
                                            Runtime::method74(v668_0_0.clone(), empty::<string>());
                                        Runtime::US9::US9_0(
                                            join(
                                                string(""),
                                                toArray_1(delay(Func0::new({
                                                    let v675 = v675.clone();
                                                    move || ofList(v675.clone()).clone()
                                                }))),
                                            ),
                                            v668_0_1.clone(),
                                            v668_0_2.clone(),
                                            v668_0_3.clone(),
                                            v668_0_4.clone(),
                                        )
                                    }
                                    Runtime::US18::US18_1(v668_1_0) => {
                                        Runtime::US9::US9_1(v668_1_0.clone())
                                    }
                                }
                            }
                        }
                    }
                };
                match &v705 {
                    Runtime::US9::US9_0(v705_0_0, v705_0_1, v705_0_2, v705_0_3, v705_0_4) => {
                        let v710: i32 = v705_0_4.clone();
                        let v709: i32 = v705_0_3.clone();
                        let v708: LrcPtr<StringBuilder> = v705_0_2.clone();
                        let v707: string = v705_0_1.clone();
                        let v706: string = v705_0_0.clone();
                        let v712: i32 = Runtime::method41(v707.clone(), 0_i32);
                        let v756: Runtime::US11 = if 0_i32 == (v712) {
                            Runtime::US11::US11_1(string(
                                "parsing.spaces1 / expected at least one space",
                            ))
                        } else {
                            Runtime::US11::US11_0(
                                getSlice(
                                    v707.clone(),
                                    Some(v712),
                                    Some((length(v707.clone())) - 1_i32),
                                ),
                                v708.clone(),
                                v709,
                                v710,
                            )
                        };
                        match &v756 {
                            Runtime::US11::US11_0(v756_0_0, v756_0_1, v756_0_2, v756_0_3) => {
                                let v0_temp: LrcPtr<Runtime::UH2> = LrcPtr::new(
                                    Runtime::UH2::UH2_1(v706.clone(), v0.get().clone()),
                                );
                                let v1_temp: string = v756_0_0.clone();
                                let v2_temp: LrcPtr<StringBuilder> = v756_0_1.clone();
                                let v3_temp: i32 = v756_0_2.clone();
                                let v4_temp: i32 = v756_0_3.clone();
                                v0.set(v0_temp);
                                v1.set(v1_temp);
                                v2.set(v2_temp);
                                v3.set(v3_temp);
                                v4.set(v4_temp);
                                continue '_method67;
                            }
                            _ => Runtime::US18::US18_0(
                                Runtime::method73(
                                    v0.get().clone(),
                                    LrcPtr::new(Runtime::UH2::UH2_1(
                                        v706.clone(),
                                        LrcPtr::new(Runtime::UH2::UH2_0),
                                    )),
                                ),
                                v707.clone(),
                                v708.clone(),
                                v709,
                                v710,
                            ),
                        }
                    }
                    _ => Runtime::US18::US18_0(
                        Runtime::method73(v0.get().clone(), LrcPtr::new(Runtime::UH2::UH2_0)),
                        v1.get().clone(),
                        v2.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                    ),
                }
            });
        }
    }
    pub fn method66(v0: string) -> Runtime::US17 {
        let _v0: MutCell<Option<Option<string>>> = MutCell::new(None::<Option<string>>);
        _v0.set(Some(Some(v0)));
        {
            let v22: Runtime::US18 = Runtime::method67(
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
                    Runtime::US17::US17_0(toArray(Runtime::method74(
                        v22_0_0.clone(),
                        empty::<string>(),
                    )))
                }
                Runtime::US18::US18_1(v22_1_0) => Runtime::US17::US17_1(v22_1_0.clone()),
            }
        }
    }
    pub fn closure27(unitVar: (), v0: string) -> Result<Array<string>, string> {
        let v1: Runtime::US17 = Runtime::method66(v0);
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
