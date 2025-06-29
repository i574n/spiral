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
        pub l7: bool,
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
        let v638: u64 = near_sdk::env::block_timestamp();
        let v663: Runtime::US2 = defaultValue(Runtime::US2::US2_1, map(Runtime::method8(), v5));
        let v676: u64 = (match &v663 {
            Runtime::US2::US2_0(v663_0_0) => {
                (v638)
                    - (match &v663 {
                        Runtime::US2::US2_0(x) => x.clone(),
                        _ => unreachable!(),
                    } as u64)
            }
            _ => v638,
        }) / 1000000000_u64;
        let v677: u64 = (v676) % 60_u64;
        let v679: u64 = ((v676) / 60_u64) % 60_u64;
        let v681: u64 = ((v676) / 3600_u64) % 24_u64;
        let v683: std::string::String = format!("{:02}:{:02}:{:02}", v681, v679, v677);
        fable_library_rust::String_::fromString(v683)
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
    pub fn method11() -> string {
        let v83: &str = inline_colorization::color_yellow;
        let v94: std::string::String = String::from(v83);
        let v139: string = append(
            (fable_library_rust::String_::fromString(v94)),
            (Runtime::method12(getCharAt(toLower(string("Warning")), 0_i32))),
        );
        let v225: &str = inline_colorization::color_reset;
        let v236: std::string::String = String::from(v225);
        append((v139), (fable_library_rust::String_::fromString(v236)))
    }
    pub fn method15() -> string {
        let v1: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        v1.l0.get().clone()
    }
    pub fn method16(v0: string) -> string {
        trimEndChars(
            trimStartChars(v0, toArray(empty::<char>())),
            toArray(ofArray(new_array(&[' ', '/']))),
        )
    }
    pub fn method14(
        v0: LrcPtr<Runtime::Mut0>,
        v1: LrcPtr<Runtime::Mut1>,
        v2: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
    ) -> string {
        let v8: string = Runtime::method15();
        Runtime::method16(append(
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
            let v123: string = Runtime::method14(
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
    pub fn method17(
        v0: LrcPtr<Runtime::Mut0>,
        v1: LrcPtr<Runtime::Mut1>,
        v2: LrcPtr<Runtime::Mut2>,
        v3: LrcPtr<Runtime::Mut3>,
        v4: LrcPtr<Runtime::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
    ) -> string {
        let v8: string = Runtime::method15();
        Runtime::method16(append(
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
            let v123: string = Runtime::method17(
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
        let v8: string = Runtime::method15();
        Runtime::method16(append(
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
    pub fn closure4(unitVar: (), unitVar_1: ()) {
        ();
    }
    pub fn method6() {
        ();
    }
    pub fn closure3(unitVar: (), unitVar_1: ()) {
        Runtime::method6();
    }
    pub fn method23() -> string {
        string("")
    }
    pub fn method24(v0: char, v1: LrcPtr<StringBuilder>, v2: i32, v3: i32) -> string {
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
    pub fn method25(v0: i64, v1: string, v2: i64) -> LrcPtr<Runtime::UH0> {
        if (v2) < (v0) {
            LrcPtr::new(Runtime::UH0::UH0_1(
                getCharAt(v1.clone(), v2 as i32),
                Runtime::method25(v0, v1, (v2) + 1_i64),
            ))
        } else {
            LrcPtr::new(Runtime::UH0::UH0_0)
        }
    }
    pub fn method26(
        v0: LrcPtr<Runtime::UH0>,
        v1: LrcPtr<StringBuilder>,
        v2: i32,
        v3: i32,
    ) -> (LrcPtr<StringBuilder>, i32, i32) {
        let v0: MutCell<LrcPtr<Runtime::UH0>> = MutCell::new(v0.clone());
        let v1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1.clone());
        let v2: MutCell<i32> = MutCell::new(v2);
        let v3: MutCell<i32> = MutCell::new(v3);
        '_method26: loop {
            break '_method26 (match v0.get().clone().as_ref() {
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
                        continue '_method26;
                    }
                }
            });
        }
    }
    pub fn method27(v0: char, v1: i32, v2: i32) -> string {
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
            (Runtime::method28(v0, (v1) + 1_i32))(append((v2), string(" ")))
        }
    }
    pub fn method28(v0: i32, v1: i32) -> Func1<string, string> {
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
                (Runtime::method24('\"', v1.clone(), v2, v3)),
            ))
        } else {
            let v14_1: char = getCharAt(v0.clone(), 0_i32);
            if (v14_1) == '\"' {
                let v51: string =
                    getSlice(v0.clone(), Some(1_i32), Some((length(v0.clone())) - 1_i32));
                let v57: string = ofChar(v14_1);
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                    Runtime::method25(length(v57.clone()) as i64, v57, 0_i64),
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
                                            (Runtime::method27('\"', v2, v3)),
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
                            ((Runtime::method28((v3) - 1_i32, 0_i32))(string(""))),
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
                (Runtime::method24('\'', v1.clone(), v2, v3)),
            ))
        } else {
            let v14_1: char = getCharAt(v0.clone(), 0_i32);
            if (v14_1) == '\'' {
                let v51: string =
                    getSlice(v0.clone(), Some(1_i32), Some((length(v0.clone())) - 1_i32));
                let v57: string = ofChar(v14_1);
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                    Runtime::method25(length(v57.clone()) as i64, v57, 0_i64),
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
                                            (Runtime::method27('\'', v2, v3)),
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
                            ((Runtime::method28((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        )),
                    )),
                    string("\n"),
                ))
            }
        }
    }
    pub fn method29(
        v0: string,
        v1: LrcPtr<StringBuilder>,
        v2: LrcPtr<Runtime::UH1>,
    ) -> Runtime::US8 {
        let v0: MutCell<string> = MutCell::new(v0.clone());
        let v1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1.clone());
        let v2: MutCell<LrcPtr<Runtime::UH1>> = MutCell::new(v2.clone());
        '_method29: loop {
            break '_method29 (match v2.get().clone().as_ref() {
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
                            continue '_method29;
                        }
                    }
                }
            });
        }
    }
    pub fn method30(v0: Array<char>) -> string {
        let v2: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v19: () = {
            Runtime::closure7(v2.clone(), sprintf!("{:?}", v0), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method31(v0: string, v1: LrcPtr<StringBuilder>, v2: i32, v3: i32) -> string {
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
    pub fn method33(v0: char, v1: string, v2: LrcPtr<StringBuilder>, v3: i32, v4: i32) -> string {
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
                let v176: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method31(
                            Runtime::method30(toArray(ofArray(new_array(&['\"', '\''])))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v63: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method32(v63, 0_i64)) == false {
                        let v102: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v108: string = ofChar(v63);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                            Runtime::method25(length(v108.clone()) as i64, v108, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v63,
                            v102,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method33(
                                v63,
                                Runtime::method30(toArray(ofArray(new_array(&['\"', '\''])))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v188: Runtime::US8 = match &v176 {
                    Runtime::US8::US8_0(v176_0_0, v176_0_1, v176_0_2, v176_0_3, v176_0_4) => {
                        let v177: char = v176_0_0.clone();
                        Runtime::US8::US8_0(
                            if '\\' == (v177) { '/' } else { v177 },
                            v176_0_1.clone(),
                            v176_0_2.clone(),
                            v176_0_3.clone(),
                            v176_0_4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v176_1_0) => Runtime::US8::US8_1(v176_1_0.clone()),
                };
                match &v188 {
                    Runtime::US8::US8_0(v188_0_0, v188_0_1, v188_0_2, v188_0_3, v188_0_4) => {
                        let v0_temp: string =
                            append((v0.get().clone()), (ofChar(v188_0_0.clone())));
                        let v1_temp: string = v188_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v188_0_2.clone();
                        let v3_temp: i32 = v188_0_3.clone();
                        let v4_temp: i32 = v188_0_4.clone();
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
                let v200: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method31(
                            Runtime::method30(toArray(ofArray(new_array(&['\"', '\'', ' '])))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v75: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method37(v75, 0_i64)) == false {
                        let v114: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v120: string = ofChar(v75);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                            Runtime::method25(length(v120.clone()) as i64, v120, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v75,
                            v114,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method33(
                                v75,
                                Runtime::method30(toArray(ofArray(new_array(&['\"', '\'', ' '])))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v212: Runtime::US8 = match &v200 {
                    Runtime::US8::US8_0(v200_0_0, v200_0_1, v200_0_2, v200_0_3, v200_0_4) => {
                        let v201: char = v200_0_0.clone();
                        Runtime::US8::US8_0(
                            if '\\' == (v201) { '/' } else { v201 },
                            v200_0_1.clone(),
                            v200_0_2.clone(),
                            v200_0_3.clone(),
                            v200_0_4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v200_1_0) => Runtime::US8::US8_1(v200_1_0.clone()),
                };
                match &v212 {
                    Runtime::US8::US8_0(v212_0_0, v212_0_1, v212_0_2, v212_0_3, v212_0_4) => {
                        let v0_temp: string =
                            append((v0.get().clone()), (ofChar(v212_0_0.clone())));
                        let v1_temp: string = v212_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v212_0_2.clone();
                        let v3_temp: i32 = v212_0_3.clone();
                        let v4_temp: i32 = v212_0_4.clone();
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
                let v66: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.any_char / unexpected end of input / "),
                        (Runtime::method41(v2.get().clone(), v3.get().clone(), v4.get().clone())),
                    ))
                } else {
                    let v14_1: char = getCharAt(v1.get().clone(), 0_i32);
                    let v50: string = getSlice(
                        v1.get().clone(),
                        Some(1_i32),
                        Some((length(v1.get().clone())) - 1_i32),
                    );
                    let v56: string = ofChar(v14_1);
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                        Runtime::method25(length(v56.clone()) as i64, v56, 0_i64),
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
    pub fn method22(v0: string) -> Runtime::US7 {
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
            let v16_1: LrcPtr<StringBuilder> = StringBuilder::_ctor__Z721C83C5(Runtime::method23());
            fn v19(arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US8 {
                Runtime::closure14((), arg10_0040)
            }
            fn v20(arg10_0040_1: (string, LrcPtr<StringBuilder>, i32, i32)) -> Runtime::US8 {
                Runtime::closure16((), arg10_0040_1)
            }
            let v24: Runtime::US8 = Runtime::method29(
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
            let v280: Runtime::US9 = match &v24 {
                Runtime::US8::US8_0(v24_0_0, v24_0_1, v24_0_2, v24_0_3, v24_0_4) => {
                    let v29: i32 = v24_0_4.clone();
                    let v28: i32 = v24_0_3.clone();
                    let v27: LrcPtr<StringBuilder> = v24_0_2.clone();
                    let v26: string = v24_0_1.clone();
                    let v201: Runtime::US8 = if string("") == (v26.clone()) {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected end of input / "),
                            (Runtime::method31(
                                Runtime::method30(toArray(ofArray(new_array(&['\"', '\''])))),
                                v27.clone(),
                                v28,
                                v29,
                            )),
                        ))
                    } else {
                        let v88: char = getCharAt(v26.clone(), 0_i32);
                        if (Runtime::method32(v88, 0_i64)) == false {
                            let v127: string = getSlice(
                                v26.clone(),
                                Some(1_i32),
                                Some((length(v26.clone())) - 1_i32),
                            );
                            let v133: string = ofChar(v88);
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                                Runtime::method25(length(v133.clone()) as i64, v133, 0_i64),
                                v27.clone(),
                                v28,
                                v29,
                            );
                            Runtime::US8::US8_0(
                                v88,
                                v127,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        } else {
                            Runtime::US8::US8_1(append(
                                string("parsing.none_of / unexpected char / "),
                                (Runtime::method33(
                                    v88,
                                    Runtime::method30(toArray(ofArray(new_array(&['\"', '\''])))),
                                    v27.clone(),
                                    v28,
                                    v29,
                                )),
                            ))
                        }
                    };
                    let v213: Runtime::US8 = match &v201 {
                        Runtime::US8::US8_0(v201_0_0, v201_0_1, v201_0_2, v201_0_3, v201_0_4) => {
                            let v202: char = v201_0_0.clone();
                            Runtime::US8::US8_0(
                                if '\\' == (v202) { '/' } else { v202 },
                                v201_0_1.clone(),
                                v201_0_2.clone(),
                                v201_0_3.clone(),
                                v201_0_4.clone(),
                            )
                        }
                        Runtime::US8::US8_1(v201_1_0) => Runtime::US8::US8_1(v201_1_0.clone()),
                    };
                    let v233: Runtime::US9 = match &v213 {
                        Runtime::US8::US8_0(v213_0_0, v213_0_1, v213_0_2, v213_0_3, v213_0_4) => {
                            let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method34(
                                    ofChar(v213_0_0.clone()),
                                    v213_0_1.clone(),
                                    v213_0_2.clone(),
                                    v213_0_3.clone(),
                                    v213_0_4.clone(),
                                );
                            Runtime::US9::US9_0(
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                                patternInput_1.3.clone(),
                                patternInput_1.4.clone(),
                            )
                        }
                        Runtime::US8::US8_1(v213_1_0) => Runtime::US9::US9_1(v213_1_0.clone()),
                    };
                    let v243: Runtime::US9 = match &v233 {
                        Runtime::US9::US9_0(v233_0_0, v233_0_1, v233_0_2, v233_0_3, v233_0_4) => {
                            Runtime::US9::US9_0(
                                v233_0_0.clone(),
                                v233_0_1.clone(),
                                v233_0_2.clone(),
                                v233_0_3.clone(),
                                v233_0_4.clone(),
                            )
                        }
                        _ => Runtime::US9::US9_0(string(""), v26.clone(), v27.clone(), v28, v29),
                    };
                    match &v243 {
                        Runtime::US9::US9_0(v243_0_0, v243_0_1, v243_0_2, v243_0_3, v243_0_4) => {
                            let v248: i32 = v243_0_4.clone();
                            let v247: i32 = v243_0_3.clone();
                            let v246: LrcPtr<StringBuilder> = v243_0_2.clone();
                            let v245: string = v243_0_1.clone();
                            let v252: Runtime::US8 = Runtime::method35(
                                v245.clone(),
                                v246.clone(),
                                v247,
                                v248,
                                LrcPtr::new(Runtime::UH1::UH1_1(
                                    Func1::from(v19),
                                    LrcPtr::new(Runtime::UH1::UH1_1(
                                        Func1::from(v20),
                                        LrcPtr::new(Runtime::UH1::UH1_0),
                                    )),
                                )),
                            );
                            match &v252 {
                                Runtime::US8::US8_0(
                                    v252_0_0,
                                    v252_0_1,
                                    v252_0_2,
                                    v252_0_3,
                                    v252_0_4,
                                ) => Runtime::US9::US9_0(
                                    v243_0_0.clone(),
                                    v252_0_1.clone(),
                                    v252_0_2.clone(),
                                    v252_0_3.clone(),
                                    v252_0_4.clone(),
                                ),
                                Runtime::US8::US8_1(v252_1_0) => Runtime::US9::US9_1(append(
                                    string("parsing.between / expected closing delimiter / "),
                                    (Runtime::method36(
                                        v252_1_0.clone(),
                                        v10.clone(),
                                        v16_1.clone(),
                                        1_i32,
                                        1_i32,
                                        v26.clone(),
                                        v27.clone(),
                                        v28,
                                        v29,
                                        v245.clone(),
                                        v246.clone(),
                                        v247,
                                        v248,
                                    )),
                                )),
                            }
                        }
                        _ => Runtime::US9::US9_1(string("parsing.between / expected content")),
                    }
                }
                Runtime::US8::US8_1(v24_1_0) => Runtime::US9::US9_1(v24_1_0.clone()),
            };
            let v602: Runtime::US9 = match &v280 {
                Runtime::US9::US9_0(v280_0_0, v280_0_1, v280_0_2, v280_0_3, v280_0_4) => {
                    v280.clone()
                }
                _ => {
                    let v488: Runtime::US8 = if string("") == (v10.clone()) {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected end of input / "),
                            (Runtime::method31(
                                Runtime::method30(toArray(ofArray(new_array(&['\"', '\'', ' '])))),
                                v16_1.clone(),
                                1_i32,
                                1_i32,
                            )),
                        ))
                    } else {
                        let v359: char = getCharAt(v10.clone(), 0_i32);
                        if (Runtime::method37(v359, 0_i64)) == false {
                            let v398: string = getSlice(
                                v10.clone(),
                                Some(1_i32),
                                Some((length(v10.clone())) - 1_i32),
                            );
                            let v404: string = ofChar(v359);
                            let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method26(
                                    Runtime::method25(length(v404.clone()) as i64, v404, 0_i64),
                                    v16_1.clone(),
                                    1_i32,
                                    1_i32,
                                );
                            Runtime::US8::US8_0(
                                v359,
                                v398,
                                patternInput_2.0.clone(),
                                patternInput_2.1.clone(),
                                patternInput_2.2.clone(),
                            )
                        } else {
                            Runtime::US8::US8_1(append(
                                string("parsing.none_of / unexpected char / "),
                                (Runtime::method33(
                                    v359,
                                    Runtime::method30(toArray(ofArray(new_array(&[
                                        '\"', '\'', ' ',
                                    ])))),
                                    v16_1.clone(),
                                    1_i32,
                                    1_i32,
                                )),
                            ))
                        }
                    };
                    let v500: Runtime::US8 = match &v488 {
                        Runtime::US8::US8_0(v488_0_0, v488_0_1, v488_0_2, v488_0_3, v488_0_4) => {
                            let v489: char = v488_0_0.clone();
                            Runtime::US8::US8_0(
                                if '\\' == (v489) { '/' } else { v489 },
                                v488_0_1.clone(),
                                v488_0_2.clone(),
                                v488_0_3.clone(),
                                v488_0_4.clone(),
                            )
                        }
                        Runtime::US8::US8_1(v488_1_0) => Runtime::US8::US8_1(v488_1_0.clone()),
                    };
                    let v520: Runtime::US9 = match &v500 {
                        Runtime::US8::US8_0(v500_0_0, v500_0_1, v500_0_2, v500_0_3, v500_0_4) => {
                            let patternInput_3: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method38(
                                    ofChar(v500_0_0.clone()),
                                    v500_0_1.clone(),
                                    v500_0_2.clone(),
                                    v500_0_3.clone(),
                                    v500_0_4.clone(),
                                );
                            Runtime::US9::US9_0(
                                patternInput_3.0.clone(),
                                patternInput_3.1.clone(),
                                patternInput_3.2.clone(),
                                patternInput_3.3.clone(),
                                patternInput_3.4.clone(),
                            )
                        }
                        Runtime::US8::US8_1(v500_1_0) => Runtime::US9::US9_1(v500_1_0.clone()),
                    };
                    match &v520 {
                        Runtime::US9::US9_0(v520_0_0, v520_0_1, v520_0_2, v520_0_3, v520_0_4) => {
                            v520.clone()
                        }
                        _ => {
                            let v538: Runtime::US11 = if (length(v10.clone())) == 0_i32 {
                                Runtime::US11::US11_0(v10.clone(), v16_1.clone(), 1_i32, 1_i32)
                            } else {
                                Runtime::US11::US11_1(append(
                                    string("parsing.eof / expected end of input / "),
                                    (Runtime::method39(v10.clone())),
                                ))
                            };
                            let v547: Runtime::US9 = match &v538 {
                                Runtime::US11::US11_0(v538_0_0, v538_0_1, v538_0_2, v538_0_3) => {
                                    Runtime::US9::US9_0(
                                        string(""),
                                        v538_0_0.clone(),
                                        v538_0_1.clone(),
                                        v538_0_2.clone(),
                                        v538_0_3.clone(),
                                    )
                                }
                                Runtime::US11::US11_1(v538_1_0) => {
                                    Runtime::US9::US9_1(v538_1_0.clone())
                                }
                            };
                            match &v547 {
                                Runtime::US9::US9_0(
                                    v547_0_0,
                                    v547_0_1,
                                    v547_0_2,
                                    v547_0_3,
                                    v547_0_4,
                                ) => {
                                    let v549: string = v547_0_1.clone();
                                    Runtime::US9::US9_0(
                                        v547_0_0.clone(),
                                        getSlice(
                                            v549.clone(),
                                            Some(Runtime::method40(v549.clone(), 0_i32)),
                                            Some((length(v549)) - 1_i32),
                                        ),
                                        v547_0_2.clone(),
                                        v547_0_3.clone(),
                                        v547_0_4.clone(),
                                    )
                                }
                                Runtime::US9::US9_1(v547_1_0) => {
                                    Runtime::US9::US9_1(v547_1_0.clone())
                                }
                            }
                        }
                    }
                }
            };
            let v900: Runtime::US12 = match &v602 {
                Runtime::US9::US9_0(v602_0_0, v602_0_1, v602_0_2, v602_0_3, v602_0_4) => {
                    let v607: i32 = v602_0_4.clone();
                    let v606: i32 = v602_0_3.clone();
                    let v605: LrcPtr<StringBuilder> = v602_0_2.clone();
                    let v604: string = v602_0_1.clone();
                    let v771: Runtime::US8 = if string("") == (v604.clone()) {
                        Runtime::US8::US8_1(append(
                            string("parsing.p_char / unexpected end of input / "),
                            (Runtime::method24(' ', v605.clone(), v606, v607)),
                        ))
                    } else {
                        let v618: char = getCharAt(v604.clone(), 0_i32);
                        if (v618) == ' ' {
                            let v655: string = getSlice(
                                v604.clone(),
                                Some(1_i32),
                                Some((length(v604.clone())) - 1_i32),
                            );
                            let v661: string = ofChar(v618);
                            let patternInput_4: (LrcPtr<StringBuilder>, i32, i32) =
                                Runtime::method26(
                                    Runtime::method25(length(v661.clone()) as i64, v661, 0_i64),
                                    v605.clone(),
                                    v606,
                                    v607,
                                );
                            Runtime::US8::US8_0(
                                v618,
                                v655,
                                patternInput_4.0.clone(),
                                patternInput_4.1.clone(),
                                patternInput_4.2.clone(),
                            )
                        } else {
                            let v678: i32 = (indexOf(v604.clone(), string("\n"))) - 1_i32;
                            let v718: string = getSlice(
                                v604.clone(),
                                Some(0_i32),
                                Some(
                                    (if -2_i32 == (v678) {
                                        (length(v604.clone())) + 1_i32
                                    } else {
                                        (v678) + 1_i32
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
                                                        (Runtime::method27(' ', v606, v607)),
                                                    )),
                                                    string("\n"),
                                                )),
                                                (toString(v605.clone())),
                                            )),
                                            (v718),
                                        )),
                                        string("\n"),
                                    )),
                                    (append(
                                        ((Runtime::method28((v607) - 1_i32, 0_i32))(string(""))),
                                        string("^"),
                                    )),
                                )),
                                string("\n"),
                            ))
                        }
                    };
                    let v783: Runtime::US13 = match &v771 {
                        Runtime::US8::US8_0(v771_0_0, v771_0_1, v771_0_2, v771_0_3, v771_0_4) => {
                            Runtime::US13::US13_0(
                                Runtime::US10::US10_0(v771_0_0.clone()),
                                v771_0_1.clone(),
                                v771_0_2.clone(),
                                v771_0_3.clone(),
                                v771_0_4.clone(),
                            )
                        }
                        _ => Runtime::US13::US13_0(
                            Runtime::US10::US10_1,
                            v604.clone(),
                            v605.clone(),
                            v606,
                            v607,
                        ),
                    };
                    let v874: Runtime::US9 = match &v783 {
                        Runtime::US13::US13_0(v783_0_0, v783_0_1, v783_0_2, v783_0_3, v783_0_4) => {
                            let v788: i32 = v783_0_4.clone();
                            let v787: i32 = v783_0_3.clone();
                            let v786: LrcPtr<StringBuilder> = v783_0_2.clone();
                            let v785: string = v783_0_1.clone();
                            let v850: Runtime::US8 = if string("") == (v785.clone()) {
                                Runtime::US8::US8_1(append(
                                    string("parsing.any_char / unexpected end of input / "),
                                    (Runtime::method41(v786.clone(), v787, v788)),
                                ))
                            } else {
                                let v798: char = getCharAt(v785.clone(), 0_i32);
                                let v834: string = getSlice(
                                    v785.clone(),
                                    Some(1_i32),
                                    Some((length(v785)) - 1_i32),
                                );
                                let v840: string = ofChar(v798);
                                let patternInput_5: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method26(
                                        Runtime::method25(length(v840.clone()) as i64, v840, 0_i64),
                                        v786,
                                        v787,
                                        v788,
                                    );
                                Runtime::US8::US8_0(
                                    v798,
                                    v834,
                                    patternInput_5.0.clone(),
                                    patternInput_5.1.clone(),
                                    patternInput_5.2.clone(),
                                )
                            };
                            match &v850 {
                                Runtime::US8::US8_0(
                                    v850_0_0,
                                    v850_0_1,
                                    v850_0_2,
                                    v850_0_3,
                                    v850_0_4,
                                ) => {
                                    let patternInput_6: (
                                        string,
                                        string,
                                        LrcPtr<StringBuilder>,
                                        i32,
                                        i32,
                                    ) = Runtime::method42(
                                        ofChar(v850_0_0.clone()),
                                        v850_0_1.clone(),
                                        v850_0_2.clone(),
                                        v850_0_3.clone(),
                                        v850_0_4.clone(),
                                    );
                                    Runtime::US9::US9_0(
                                        patternInput_6.0.clone(),
                                        patternInput_6.1.clone(),
                                        patternInput_6.2.clone(),
                                        patternInput_6.3.clone(),
                                        patternInput_6.4.clone(),
                                    )
                                }
                                Runtime::US8::US8_1(v850_1_0) => {
                                    Runtime::US9::US9_1(v850_1_0.clone())
                                }
                            }
                        }
                        Runtime::US13::US13_1(v783_1_0) => Runtime::US9::US9_1(v783_1_0.clone()),
                    };
                    let v886: Runtime::US14 = match &v874 {
                        Runtime::US9::US9_0(v874_0_0, v874_0_1, v874_0_2, v874_0_3, v874_0_4) => {
                            Runtime::US14::US14_0(
                                Runtime::US5::US5_0(v874_0_0.clone()),
                                v874_0_1.clone(),
                                v874_0_2.clone(),
                                v874_0_3.clone(),
                                v874_0_4.clone(),
                            )
                        }
                        _ => Runtime::US14::US14_0(
                            Runtime::US5::US5_1,
                            v604.clone(),
                            v605.clone(),
                            v606,
                            v607,
                        ),
                    };
                    match &v886 {
                        Runtime::US14::US14_0(v886_0_0, v886_0_1, v886_0_2, v886_0_3, v886_0_4) => {
                            Runtime::US12::US12_0(
                                v602_0_0.clone(),
                                v886_0_0.clone(),
                                v886_0_1.clone(),
                                v886_0_2.clone(),
                                v886_0_3.clone(),
                                v886_0_4.clone(),
                            )
                        }
                        Runtime::US14::US14_1(v886_1_0) => Runtime::US12::US12_1(v886_1_0.clone()),
                    }
                }
                Runtime::US9::US9_1(v602_1_0) => Runtime::US12::US12_1(v602_1_0.clone()),
            };
            match &v900 {
                Runtime::US12::US12_0(
                    v900_0_0,
                    v900_0_1,
                    v900_0_2,
                    v900_0_3,
                    v900_0_4,
                    v900_0_5,
                ) => Runtime::US7::US7_0(v900_0_0.clone(), v900_0_1.clone()),
                Runtime::US12::US12_1(v900_1_0) => Runtime::US7::US7_1(v900_1_0.clone()),
            }
        }
    }
    pub fn method43() -> string {
        let v83: &str = inline_colorization::color_bright_blue;
        let v94: std::string::String = String::from(v83);
        let v139: string = append(
            (fable_library_rust::String_::fromString(v94)),
            (Runtime::method12(getCharAt(toLower(string("Debug")), 0_i32))),
        );
        let v225: &str = inline_colorization::color_reset;
        let v236: std::string::String = String::from(v225);
        append((v139), (fable_library_rust::String_::fromString(v236)))
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
        v9: bool,
    ) -> string {
        let v11: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v25: () = {
            Runtime::closure7(v11.clone(), string("{ "), ());
            ()
        };
        let v44: () = {
            Runtime::closure7(v11.clone(), string("file_name"), ());
            ()
        };
        let v63: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v80: () = {
            Runtime::closure7(v11.clone(), v0, ());
            ()
        };
        let v99: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v118: () = {
            Runtime::closure7(v11.clone(), string("arguments"), ());
            ()
        };
        let v135: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v156: () = {
            Runtime::closure7(v11.clone(), sprintf!("{:?}", v1), ());
            ()
        };
        let v173: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v192: () = {
            Runtime::closure7(v11.clone(), string("options"), ());
            ()
        };
        let v209: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v226: () = {
            Runtime::closure7(v11.clone(), string("{ "), ());
            ()
        };
        let v245: () = {
            Runtime::closure7(v11.clone(), string("command"), ());
            ()
        };
        let v262: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v279: () = {
            Runtime::closure7(v11.clone(), v2, ());
            ()
        };
        let v296: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v315: () = {
            Runtime::closure7(v11.clone(), string("cancellation_token"), ());
            ()
        };
        let v332: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v352: std::string::String = format!("{:#?}", v3);
        let v391: () = {
            Runtime::closure7(
                v11.clone(),
                fable_library_rust::String_::fromString(v352),
                (),
            );
            ()
        };
        let v408: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v427: () = {
            Runtime::closure7(v11.clone(), string("environment_variables"), ());
            ()
        };
        let v444: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v466: () = {
            Runtime::closure7(v11.clone(), sprintf!("{:?}", v4), ());
            ()
        };
        let v483: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v502: () = {
            Runtime::closure7(v11.clone(), string("on_line"), ());
            ()
        };
        let v519: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v539: std::string::String = format!("{:#?}", v5);
        let v578: () = {
            Runtime::closure7(
                v11.clone(),
                fable_library_rust::String_::fromString(v539),
                (),
            );
            ()
        };
        let v595: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v614: () = {
            Runtime::closure7(v11.clone(), string("stdin"), ());
            ()
        };
        let v631: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v651: std::string::String = format!("{:#?}", v6);
        let v690: () = {
            Runtime::closure7(
                v11.clone(),
                fable_library_rust::String_::fromString(v651),
                (),
            );
            ()
        };
        let v707: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v726: () = {
            Runtime::closure7(v11.clone(), string("trace"), ());
            ()
        };
        let v743: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v763: () = {
            Runtime::closure7(
                v11.clone(),
                if v7 { string("true") } else { string("false") },
                (),
            );
            ()
        };
        let v780: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v799: () = {
            Runtime::closure7(v11.clone(), string("working_directory"), ());
            ()
        };
        let v816: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v836: std::string::String = format!("{:#?}", v8);
        let v875: () = {
            Runtime::closure7(
                v11.clone(),
                fable_library_rust::String_::fromString(v836),
                (),
            );
            ()
        };
        let v892: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v911: () = {
            Runtime::closure7(v11.clone(), string("stderr"), ());
            ()
        };
        let v928: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v948: () = {
            Runtime::closure7(
                v11.clone(),
                if v9 { string("true") } else { string("false") },
                (),
            );
            ()
        };
        let v967: () = {
            Runtime::closure7(v11.clone(), string(" }"), ());
            ()
        };
        let v984: () = {
            Runtime::closure7(v11.clone(), string(" }"), ());
            ()
        };
        v11.l0.get().clone()
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
        v17: bool,
    ) -> string {
        let v18: string = Runtime::method45(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1, v17);
        Runtime::method16(append(
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
            (v18),
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
        v7: bool,
        v8: Runtime::US5,
        v9: string,
        unitVar: (),
    ) {
        fn v25() {
            Runtime::closure0((), ());
        }
        let v26: () = {
            v25();
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
        let v67: Runtime::US0 = (patternInput.4.clone()).l0.get().clone();
        let v307: Runtime::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            1_i32
                >= (find(
                    v67,
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
            let v90: () = {
                v25();
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
            let v118: Option<i64> = patternInput_1.5.clone();
            let v117: LrcPtr<Runtime::Mut4> = patternInput_1.4.clone();
            let v116: LrcPtr<Runtime::Mut3> = patternInput_1.3.clone();
            let v115: LrcPtr<Runtime::Mut2> = patternInput_1.2.clone();
            let v114: LrcPtr<Runtime::Mut1> = patternInput_1.1.clone();
            let v113: LrcPtr<Runtime::Mut0> = patternInput_1.0.clone();
            let v133: string = Runtime::method44(
                v113.clone(),
                v114.clone(),
                v115.clone(),
                v116.clone(),
                v117.clone(),
                v118.clone(),
                Runtime::method7(v113, v114, v115, v116, v117, v118),
                Runtime::method43(),
                v9,
                v8,
                v0,
                v1,
                v2,
                v3,
                v4,
                v5,
                v6,
                v7,
            );
            let v149: () = {
                v25();
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
    pub fn method46(
        v0: string,
        v1: Option<CancellationToken>,
        v2: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
        v7: bool,
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
        let v83: &str = inline_colorization::color_bright_black;
        let v94: std::string::String = String::from(v83);
        let v139: string = append(
            (fable_library_rust::String_::fromString(v94)),
            (Runtime::method12(getCharAt(toLower(string("Verbose")), 0_i32))),
        );
        let v225: &str = inline_colorization::color_reset;
        let v236: std::string::String = String::from(v225);
        append((v139), (fable_library_rust::String_::fromString(v236)))
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
        let v9: string = Runtime::method15();
        Runtime::method16(append(
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
    pub fn method49(
        v0: string,
        v1: Option<CancellationToken>,
        v2: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
        v7: bool,
        v8: bool,
        v9: LrcPtr<ConcurrentStack_1<string>>,
        v10: bool,
        v11: bool,
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
        v8: bool,
        v9: LrcPtr<ConcurrentStack_1<string>>,
        v10: bool,
        v11: bool,
    ) -> Arc<Async<()>> {
        Runtime::method49(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11)
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
        v8: bool,
        v9: LrcPtr<ConcurrentStack_1<string>>,
        v10: bool,
        v11: bool,
    ) {
        let v12: Arc<Async<()>> =
            Runtime::method48(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11);
        fable_library_rust::Native_::getZero::<()>();
        ()
    }
    pub fn closure21(unitVar: (), v0: CancellationToken) -> Runtime::US16 {
        Runtime::US16::US16_0(v0)
    }
    pub fn method55() -> Func1<CancellationToken, Runtime::US16> {
        Func1::new(move |v: CancellationToken| Runtime::closure21((), v))
    }
    pub fn method57(v0: CancellationToken) -> Arc<Async<CancellationToken>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method56(v0: CancellationToken) -> Arc<Async<CancellationToken>> {
        Runtime::method57(v0)
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
        Runtime::method16(append(
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
        v9: bool,
    ) -> string {
        let v11: LrcPtr<Runtime::Mut3> = LrcPtr::new(Runtime::Mut3 {
            l0: MutCell::new(Runtime::method13()),
        });
        let v25: () = {
            Runtime::closure7(v11.clone(), string("{ "), ());
            ()
        };
        let v44: () = {
            Runtime::closure7(v11.clone(), string("exit_code"), ());
            ()
        };
        let v63: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v83: () = {
            Runtime::closure7(v11.clone(), sprintf!("{}", v0), ());
            ()
        };
        let v102: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v121: () = {
            Runtime::closure7(v11.clone(), string("output_length"), ());
            ()
        };
        let v138: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v158: () = {
            Runtime::closure7(v11.clone(), sprintf!("{}", v1), ());
            ()
        };
        let v175: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v194: () = {
            Runtime::closure7(v11.clone(), string("options"), ());
            ()
        };
        let v211: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v228: () = {
            Runtime::closure7(v11.clone(), string("{ "), ());
            ()
        };
        let v247: () = {
            Runtime::closure7(v11.clone(), string("command"), ());
            ()
        };
        let v264: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v281: () = {
            Runtime::closure7(v11.clone(), v2, ());
            ()
        };
        let v298: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v317: () = {
            Runtime::closure7(v11.clone(), string("cancellation_token"), ());
            ()
        };
        let v334: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v354: std::string::String = format!("{:#?}", v3);
        let v393: () = {
            Runtime::closure7(
                v11.clone(),
                fable_library_rust::String_::fromString(v354),
                (),
            );
            ()
        };
        let v410: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v429: () = {
            Runtime::closure7(v11.clone(), string("environment_variables"), ());
            ()
        };
        let v446: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v468: () = {
            Runtime::closure7(v11.clone(), sprintf!("{:?}", v4), ());
            ()
        };
        let v485: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v504: () = {
            Runtime::closure7(v11.clone(), string("on_line"), ());
            ()
        };
        let v521: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v541: std::string::String = format!("{:#?}", v5);
        let v580: () = {
            Runtime::closure7(
                v11.clone(),
                fable_library_rust::String_::fromString(v541),
                (),
            );
            ()
        };
        let v597: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v616: () = {
            Runtime::closure7(v11.clone(), string("stdin"), ());
            ()
        };
        let v633: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v653: std::string::String = format!("{:#?}", v6);
        let v692: () = {
            Runtime::closure7(
                v11.clone(),
                fable_library_rust::String_::fromString(v653),
                (),
            );
            ()
        };
        let v709: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v728: () = {
            Runtime::closure7(v11.clone(), string("trace"), ());
            ()
        };
        let v745: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v765: () = {
            Runtime::closure7(
                v11.clone(),
                if v7 { string("true") } else { string("false") },
                (),
            );
            ()
        };
        let v782: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v801: () = {
            Runtime::closure7(v11.clone(), string("working_directory"), ());
            ()
        };
        let v818: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v838: std::string::String = format!("{:#?}", v8);
        let v877: () = {
            Runtime::closure7(
                v11.clone(),
                fable_library_rust::String_::fromString(v838),
                (),
            );
            ()
        };
        let v894: () = {
            Runtime::closure7(v11.clone(), string("; "), ());
            ()
        };
        let v913: () = {
            Runtime::closure7(v11.clone(), string("stderr"), ());
            ()
        };
        let v930: () = {
            Runtime::closure7(v11.clone(), string(" = "), ());
            ()
        };
        let v950: () = {
            Runtime::closure7(
                v11.clone(),
                if v9 { string("true") } else { string("false") },
                (),
            );
            ()
        };
        let v969: () = {
            Runtime::closure7(v11.clone(), string(" }"), ());
            ()
        };
        let v986: () = {
            Runtime::closure7(v11.clone(), string(" }"), ());
            ()
        };
        v11.l0.get().clone()
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
        v17: bool,
    ) -> string {
        let v18: string = Runtime::method65(v8, v9, v10, v11, v12, v13, v14_1, v15_1, v16_1, v17);
        Runtime::method16(append(
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
            (v18),
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
        v7: bool,
        v8: i32,
        v9: string,
        unitVar: (),
    ) {
        fn v25() {
            Runtime::closure0((), ());
        }
        let v26: () = {
            v25();
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
        let v67: Runtime::US0 = (patternInput.4.clone()).l0.get().clone();
        let v308: Runtime::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            1_i32
                >= (find(
                    v67,
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
            let v90: () = {
                v25();
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
            let v118: Option<i64> = patternInput_1.5.clone();
            let v117: LrcPtr<Runtime::Mut4> = patternInput_1.4.clone();
            let v116: LrcPtr<Runtime::Mut3> = patternInput_1.3.clone();
            let v115: LrcPtr<Runtime::Mut2> = patternInput_1.2.clone();
            let v114: LrcPtr<Runtime::Mut1> = patternInput_1.1.clone();
            let v113: LrcPtr<Runtime::Mut0> = patternInput_1.0.clone();
            let v134: string = Runtime::method64(
                v113.clone(),
                v114.clone(),
                v115.clone(),
                v116.clone(),
                v117.clone(),
                v118.clone(),
                Runtime::method7(v113, v114, v115, v116, v117, v118),
                Runtime::method43(),
                v8,
                length(v9),
                v0,
                v1,
                v2,
                v3,
                v4,
                v5,
                v6,
                v7,
            );
            let v150: () = {
                v25();
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
            let v176: LrcPtr<Runtime::Mut3> = patternInput_2.3.clone();
            let v174: LrcPtr<Runtime::Mut1> = patternInput_2.1.clone();
            let v173: LrcPtr<Runtime::Mut0> = patternInput_2.0.clone();
            let v195: () = {
                Runtime::closure8(v173.clone(), ());
                ()
            };
            let v218: string = if (v176.l0.get().clone()) == string("") {
                v134.clone()
            } else {
                if (v134.clone()) == string("") {
                    v176.l0.get().clone()
                } else {
                    append(
                        (append((v176.l0.get().clone()), string("\n"))),
                        (v134.clone()),
                    )
                }
            };
            let v229: &str = &*v218.clone();
            let v256 = v229.chars();
            let v258 = v256;
            let v260: Vec<char> = v258.collect::<Vec<_>>();
            let v262: Vec<Vec<char>> = v260
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v264: bool = true;
            let _vec_map: Vec<_> = v262
                .into_iter()
                .map(|x| {
                    //;
                    let v266: Vec<char> = x;
                    let v268: std::string::String = String::from_iter(v266);
                    let v270: bool = true;
                    v268
                })
                .collect::<Vec<_>>();
            let v272: Vec<std::string::String> = _vec_map;
            if if (v134.clone()) != string("") {
                (v272.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v176.l0.set(v218);
                ()
            } else {
                v176.l0.set(string(""));
                {
                    let v297: bool = true;
                    v272.into_iter().for_each(|x| {
                        //;
                        let v299: std::string::String = x;
                        let v301: bool = true;
                        near_sdk::log!("{}", v299);
                        let v303: bool = true;
                        let v305: bool = true;
                    }); //;
                    ()
                }
            }
            (v174.l0.get().clone())(v134);
            Runtime::US6::US6_0(
                v173,
                v174,
                patternInput_2.2.clone(),
                v176,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method21(
        v0: string,
        v1: Option<CancellationToken>,
        v2: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
        v7: bool,
    ) -> Arc<Async<(i32, string)>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method20(
        v0: string,
        v1: Option<CancellationToken>,
        v2: Array<(string, string)>,
        v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
        v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
        v5: bool,
        v6: Option<string>,
        v7: bool,
    ) -> Arc<Async<(i32, string)>> {
        Runtime::method21(v0, v1, v2, v3, v4, v5, v6, v7)
    }
    pub fn method19(v0: string) -> Arc<Async<(i32, string)>> {
        Runtime::method20(
            v0,
            None::<CancellationToken>,
            new_empty::<(string, string)>(),
            None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
            None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            true,
            None::<string>,
            true,
        )
    }
    pub fn closure13(unitVar: (), v0: string) -> Arc<Async<(i32, string)>> {
        Runtime::method19(v0)
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
            bool,
        ),
    ) -> Arc<Async<(i32, string)>> {
        Runtime::method20(
            _arg.0.clone(),
            _arg.1.clone(),
            _arg.2.clone(),
            _arg.3.clone(),
            _arg.4.clone(),
            _arg.5.clone(),
            _arg.6.clone(),
            _arg.7.clone(),
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
        bool,
    ) {
        let v20: LrcPtr<Runtime::Heap0> = v0(LrcPtr::new(Runtime::Heap0 {
            l0: string(""),
            l1: None::<CancellationToken>,
            l2: new_empty::<(string, string)>(),
            l3: None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
            l4: None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            l5: true,
            l6: None::<string>,
            l7: true,
        }));
        (
            v20.l0.clone(),
            v20.l1.clone(),
            v20.l2.clone(),
            v20.l3.clone(),
            v20.l4.clone(),
            v20.l5,
            v20.l6.clone(),
            v20.l7,
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
                let v224: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method31(
                            Runtime::method30(toArray(ofArray(new_array(&['\\', '`', '\"', ' '])))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v87: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method68(v87, 0_i64)) == false {
                        let v126: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v132: string = ofChar(v87);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                            Runtime::method25(length(v132.clone()) as i64, v132, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v87,
                            v126,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method33(
                                v87,
                                Runtime::method30(toArray(ofArray(new_array(&[
                                    '\\', '`', '\"', ' ',
                                ])))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                match &v224 {
                    Runtime::US8::US8_0(v224_0_0, v224_0_1, v224_0_2, v224_0_3, v224_0_4) => {
                        let v0_temp: string =
                            append((v0.get().clone()), (ofChar(v224_0_0.clone())));
                        let v1_temp: string = v224_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v224_0_2.clone();
                        let v3_temp: i32 = v224_0_3.clone();
                        let v4_temp: i32 = v224_0_4.clone();
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
                (Runtime::method24('\\', v1.clone(), v2, v3)),
            ))
        } else {
            let v14_1: char = getCharAt(v0.clone(), 0_i32);
            if (v14_1) == '\\' {
                let v51: string =
                    getSlice(v0.clone(), Some(1_i32), Some((length(v0.clone())) - 1_i32));
                let v57: string = ofChar(v14_1);
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                    Runtime::method25(length(v57.clone()) as i64, v57, 0_i64),
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
                                            (Runtime::method27('\\', v2, v3)),
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
                            ((Runtime::method28((v3) - 1_i32, 0_i32))(string(""))),
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
                        (Runtime::method41(v171.clone(), v172, v173)),
                    ))
                } else {
                    let v183: char = getCharAt(v170.clone(), 0_i32);
                    let v219: string =
                        getSlice(v170.clone(), Some(1_i32), Some((length(v170)) - 1_i32));
                    let v225: string = ofChar(v183);
                    let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                        Runtime::method25(length(v225.clone()) as i64, v225, 0_i64),
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
                (Runtime::method24('`', v1.clone(), v2, v3)),
            ))
        } else {
            let v14_1: char = getCharAt(v0.clone(), 0_i32);
            if (v14_1) == '`' {
                let v51: string =
                    getSlice(v0.clone(), Some(1_i32), Some((length(v0.clone())) - 1_i32));
                let v57: string = ofChar(v14_1);
                let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                    Runtime::method25(length(v57.clone()) as i64, v57, 0_i64),
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
                                            (Runtime::method27('`', v2, v3)),
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
                            ((Runtime::method28((v3) - 1_i32, 0_i32))(string(""))),
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
                        (Runtime::method41(v171.clone(), v172, v173)),
                    ))
                } else {
                    let v183: char = getCharAt(v170.clone(), 0_i32);
                    let v219: string =
                        getSlice(v170.clone(), Some(1_i32), Some((length(v170)) - 1_i32));
                    let v225: string = ofChar(v183);
                    let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                        Runtime::method25(length(v225.clone()) as i64, v225, 0_i64),
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
                let v200: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method31(
                            Runtime::method30(toArray(ofArray(new_array(&['\\', '`', '\"'])))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v75: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method71(v75, 0_i64)) == false {
                        let v114: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v120: string = ofChar(v75);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                            Runtime::method25(length(v120.clone()) as i64, v120, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v75,
                            v114,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method33(
                                v75,
                                Runtime::method30(toArray(ofArray(new_array(&['\\', '`', '\"'])))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v215: Runtime::US9 = match &v200 {
                    Runtime::US8::US8_0(v200_0_0, v200_0_1, v200_0_2, v200_0_3, v200_0_4) => {
                        Runtime::US9::US9_0(
                            ofChar(v200_0_0.clone()),
                            v200_0_1.clone(),
                            v200_0_2.clone(),
                            v200_0_3.clone(),
                            v200_0_4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v200_1_0) => Runtime::US9::US9_1(v200_1_0.clone()),
                };
                let v229: Runtime::US9 = match &v215 {
                    Runtime::US9::US9_0(v215_0_0, v215_0_1, v215_0_2, v215_0_3, v215_0_4) => {
                        v215.clone()
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
                match &v229 {
                    Runtime::US9::US9_0(v229_0_0, v229_0_1, v229_0_2, v229_0_3, v229_0_4) => {
                        let v0_temp: LrcPtr<Runtime::UH2> =
                            LrcPtr::new(Runtime::UH2::UH2_1(v229_0_0.clone(), v0.get().clone()));
                        let v1_temp: string = v229_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v229_0_2.clone();
                        let v3_temp: i32 = v229_0_3.clone();
                        let v4_temp: i32 = v229_0_4.clone();
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
                let v200: Runtime::US8 = if string("") == (v1.get().clone()) {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method31(
                            Runtime::method30(toArray(ofArray(new_array(&['\\', '`', '\"'])))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v75: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method71(v75, 0_i64)) == false {
                        let v114: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v120: string = ofChar(v75);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                            Runtime::method25(length(v120.clone()) as i64, v120, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v75,
                            v114,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method33(
                                v75,
                                Runtime::method30(toArray(ofArray(new_array(&['\\', '`', '\"'])))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v215: Runtime::US9 = match &v200 {
                    Runtime::US8::US8_0(v200_0_0, v200_0_1, v200_0_2, v200_0_3, v200_0_4) => {
                        Runtime::US9::US9_0(
                            ofChar(v200_0_0.clone()),
                            v200_0_1.clone(),
                            v200_0_2.clone(),
                            v200_0_3.clone(),
                            v200_0_4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v200_1_0) => Runtime::US9::US9_1(v200_1_0.clone()),
                };
                match &v215 {
                    Runtime::US9::US9_0(v215_0_0, v215_0_1, v215_0_2, v215_0_3, v215_0_4) => {
                        let v0_temp: LrcPtr<Runtime::UH2> =
                            LrcPtr::new(Runtime::UH2::UH2_1(v215_0_0.clone(), v0.get().clone()));
                        let v1_temp: string = v215_0_1.clone();
                        let v2_temp: LrcPtr<StringBuilder> = v215_0_2.clone();
                        let v3_temp: i32 = v215_0_3.clone();
                        let v4_temp: i32 = v215_0_4.clone();
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
                let v224: Runtime::US8 = if v5 {
                    Runtime::US8::US8_1(append(
                        string("parsing.none_of / unexpected end of input / "),
                        (Runtime::method31(
                            Runtime::method30(toArray(ofArray(new_array(&['\\', '`', '\"', ' '])))),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        )),
                    ))
                } else {
                    let v87: char = getCharAt(v1.get().clone(), 0_i32);
                    if (Runtime::method68(v87, 0_i64)) == false {
                        let v126: string = getSlice(
                            v1.get().clone(),
                            Some(1_i32),
                            Some((length(v1.get().clone())) - 1_i32),
                        );
                        let v132: string = ofChar(v87);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Runtime::method26(
                            Runtime::method25(length(v132.clone()) as i64, v132, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Runtime::US8::US8_0(
                            v87,
                            v126,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    } else {
                        Runtime::US8::US8_1(append(
                            string("parsing.none_of / unexpected char / "),
                            (Runtime::method33(
                                v87,
                                Runtime::method30(toArray(ofArray(new_array(&[
                                    '\\', '`', '\"', ' ',
                                ])))),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            )),
                        ))
                    }
                };
                let v244: Runtime::US9 = match &v224 {
                    Runtime::US8::US8_0(v224_0_0, v224_0_1, v224_0_2, v224_0_3, v224_0_4) => {
                        let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                            Runtime::method69(
                                ofChar(v224_0_0.clone()),
                                v224_0_1.clone(),
                                v224_0_2.clone(),
                                v224_0_3.clone(),
                                v224_0_4.clone(),
                            );
                        Runtime::US9::US9_0(
                            patternInput_1.0.clone(),
                            patternInput_1.1.clone(),
                            patternInput_1.2.clone(),
                            patternInput_1.3.clone(),
                            patternInput_1.4.clone(),
                        )
                    }
                    Runtime::US8::US8_1(v224_1_0) => Runtime::US9::US9_1(v224_1_0.clone()),
                };
                let v721: Runtime::US9 = match &v244 {
                    Runtime::US9::US9_0(v244_0_0, v244_0_1, v244_0_2, v244_0_3, v244_0_4) => {
                        v244.clone()
                    }
                    _ => {
                        let v414: Runtime::US8 = if v5 {
                            Runtime::US8::US8_1(append(
                                string("parsing.p_char / unexpected end of input / "),
                                (Runtime::method24(
                                    '\"',
                                    v2.get().clone(),
                                    v3.get().clone(),
                                    v4.get().clone(),
                                )),
                            ))
                        } else {
                            let v260: char = getCharAt(v1.get().clone(), 0_i32);
                            if (v260) == '\"' {
                                let v297: string = getSlice(
                                    v1.get().clone(),
                                    Some(1_i32),
                                    Some((length(v1.get().clone())) - 1_i32),
                                );
                                let v303: string = ofChar(v260);
                                let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                    Runtime::method26(
                                        Runtime::method25(length(v303.clone()) as i64, v303, 0_i64),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Runtime::US8::US8_0(
                                    v260,
                                    v297,
                                    patternInput_2.0.clone(),
                                    patternInput_2.1.clone(),
                                    patternInput_2.2.clone(),
                                )
                            } else {
                                let v320: i32 = (indexOf(v1.get().clone(), string("\n"))) - 1_i32;
                                let v360: string = getSlice(
                                    v1.get().clone(),
                                    Some(0_i32),
                                    Some(
                                        (if -2_i32 == (v320) {
                                            (length(v1.get().clone())) + 1_i32
                                        } else {
                                            (v320) + 1_i32
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
                                                            (Runtime::method27(
                                                                '\"',
                                                                v3.get().clone(),
                                                                v4.get().clone(),
                                                            )),
                                                        )),
                                                        string("\n"),
                                                    )),
                                                    (toString(v2.get().clone())),
                                                )),
                                                (v360),
                                            )),
                                            string("\n"),
                                        )),
                                        (append(
                                            ((Runtime::method28(
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
                        let v650: Runtime::US9 = match &v414 {
                            Runtime::US8::US8_0(
                                v414_0_0,
                                v414_0_1,
                                v414_0_2,
                                v414_0_3,
                                v414_0_4,
                            ) => {
                                let v419: i32 = v414_0_4.clone();
                                let v418: i32 = v414_0_3.clone();
                                let v417: LrcPtr<StringBuilder> = v414_0_2.clone();
                                let v416: string = v414_0_1.clone();
                                let v421: Runtime::US18 = Runtime::method70(
                                    LrcPtr::new(Runtime::UH2::UH2_0),
                                    v416.clone(),
                                    v417.clone(),
                                    v418,
                                    v419,
                                );
                                let v454: Runtime::US9 = match &v421 {
                                    Runtime::US18::US18_0(
                                        v421_0_0,
                                        v421_0_1,
                                        v421_0_2,
                                        v421_0_3,
                                        v421_0_4,
                                    ) => {
                                        let v428: List<string> =
                                            Runtime::method74(v421_0_0.clone(), empty::<string>());
                                        Runtime::US9::US9_0(
                                            join(
                                                string(""),
                                                toArray_1(delay(Func0::new({
                                                    let v428 = v428.clone();
                                                    move || ofList(v428.clone()).clone()
                                                }))),
                                            ),
                                            v421_0_1.clone(),
                                            v421_0_2.clone(),
                                            v421_0_3.clone(),
                                            v421_0_4.clone(),
                                        )
                                    }
                                    Runtime::US18::US18_1(v421_1_0) => {
                                        Runtime::US9::US9_1(v421_1_0.clone())
                                    }
                                };
                                match &v454 {
                                    Runtime::US9::US9_0(
                                        v454_0_0,
                                        v454_0_1,
                                        v454_0_2,
                                        v454_0_3,
                                        v454_0_4,
                                    ) => {
                                        let v459: i32 = v454_0_4.clone();
                                        let v458: i32 = v454_0_3.clone();
                                        let v457: LrcPtr<StringBuilder> = v454_0_2.clone();
                                        let v456: string = v454_0_1.clone();
                                        let v624: Runtime::US8 = if string("") == (v456.clone()) {
                                            Runtime::US8::US8_1(append(
                                                string(
                                                    "parsing.p_char / unexpected end of input / ",
                                                ),
                                                (Runtime::method24('\"', v457.clone(), v458, v459)),
                                            ))
                                        } else {
                                            let v470: char = getCharAt(v456.clone(), 0_i32);
                                            if (v470) == '\"' {
                                                let v507: string = getSlice(
                                                    v456.clone(),
                                                    Some(1_i32),
                                                    Some((length(v456.clone())) - 1_i32),
                                                );
                                                let v513: string = ofChar(v470);
                                                let patternInput_3: (
                                                    LrcPtr<StringBuilder>,
                                                    i32,
                                                    i32,
                                                ) = Runtime::method26(
                                                    Runtime::method25(
                                                        length(v513.clone()) as i64,
                                                        v513,
                                                        0_i64,
                                                    ),
                                                    v457.clone(),
                                                    v458,
                                                    v459,
                                                );
                                                Runtime::US8::US8_0(
                                                    v470,
                                                    v507,
                                                    patternInput_3.0.clone(),
                                                    patternInput_3.1.clone(),
                                                    patternInput_3.2.clone(),
                                                )
                                            } else {
                                                let v530: i32 =
                                                    (indexOf(v456.clone(), string("\n"))) - 1_i32;
                                                let v570: string = getSlice(
                                                    v456.clone(),
                                                    Some(0_i32),
                                                    Some(
                                                        (if -2_i32 == (v530) {
                                                            (length(v456.clone())) + 1_i32
                                                        } else {
                                                            (v530) + 1_i32
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
                                                                            (Runtime::method27(
                                                                                '\"', v458, v459,
                                                                            )),
                                                                        )),
                                                                        string("\n"),
                                                                    )),
                                                                    (toString(v457.clone())),
                                                                )),
                                                                (v570),
                                                            )),
                                                            string("\n"),
                                                        )),
                                                        (append(
                                                            ((Runtime::method28(
                                                                (v459) - 1_i32,
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
                                        match &v624 {
                                            Runtime::US8::US8_0(
                                                v624_0_0,
                                                v624_0_1,
                                                v624_0_2,
                                                v624_0_3,
                                                v624_0_4,
                                            ) => Runtime::US9::US9_0(
                                                v454_0_0.clone(),
                                                v624_0_1.clone(),
                                                v624_0_2.clone(),
                                                v624_0_3.clone(),
                                                v624_0_4.clone(),
                                            ),
                                            Runtime::US8::US8_1(v624_1_0) => {
                                                Runtime::US9::US9_1(append(
                                                    string(
                                                        "parsing.between / expected closing delimiter / ",
                                                    ),
                                                    (Runtime::method36(
                                                        v624_1_0.clone(),
                                                        v1.get().clone(),
                                                        v2.get().clone(),
                                                        v3.get().clone(),
                                                        v4.get().clone(),
                                                        v416.clone(),
                                                        v417.clone(),
                                                        v418,
                                                        v419,
                                                        v456.clone(),
                                                        v457.clone(),
                                                        v458,
                                                        v459,
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
                            Runtime::US8::US8_1(v414_1_0) => Runtime::US9::US9_1(v414_1_0.clone()),
                        };
                        match &v650 {
                            Runtime::US9::US9_0(
                                v650_0_0,
                                v650_0_1,
                                v650_0_2,
                                v650_0_3,
                                v650_0_4,
                            ) => v650.clone(),
                            _ => {
                                let v662: Runtime::US9 = Runtime::method72(
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
                                let v673: Runtime::US9 = match &v662 {
                                    Runtime::US9::US9_0(
                                        v662_0_0,
                                        v662_0_1,
                                        v662_0_2,
                                        v662_0_3,
                                        v662_0_4,
                                    ) => Runtime::US9::US9_0(
                                        string(""),
                                        v662_0_1.clone(),
                                        v662_0_2.clone(),
                                        v662_0_3.clone(),
                                        v662_0_4.clone(),
                                    ),
                                    Runtime::US9::US9_1(v662_1_0) => {
                                        Runtime::US9::US9_1(v662_1_0.clone())
                                    }
                                };
                                let v684: Runtime::US18 = match &v673 {
                                    Runtime::US9::US9_0(
                                        v673_0_0,
                                        v673_0_1,
                                        v673_0_2,
                                        v673_0_3,
                                        v673_0_4,
                                    ) => Runtime::method75(
                                        LrcPtr::new(Runtime::UH2::UH2_0),
                                        v673_0_1.clone(),
                                        v673_0_2.clone(),
                                        v673_0_3.clone(),
                                        v673_0_4.clone(),
                                    ),
                                    Runtime::US9::US9_1(v673_1_0) => {
                                        Runtime::US18::US18_1(v673_1_0.clone())
                                    }
                                };
                                match &v684 {
                                    Runtime::US18::US18_0(
                                        v684_0_0,
                                        v684_0_1,
                                        v684_0_2,
                                        v684_0_3,
                                        v684_0_4,
                                    ) => {
                                        let v691: List<string> =
                                            Runtime::method74(v684_0_0.clone(), empty::<string>());
                                        Runtime::US9::US9_0(
                                            join(
                                                string(""),
                                                toArray_1(delay(Func0::new({
                                                    let v691 = v691.clone();
                                                    move || ofList(v691.clone()).clone()
                                                }))),
                                            ),
                                            v684_0_1.clone(),
                                            v684_0_2.clone(),
                                            v684_0_3.clone(),
                                            v684_0_4.clone(),
                                        )
                                    }
                                    Runtime::US18::US18_1(v684_1_0) => {
                                        Runtime::US9::US9_1(v684_1_0.clone())
                                    }
                                }
                            }
                        }
                    }
                };
                match &v721 {
                    Runtime::US9::US9_0(v721_0_0, v721_0_1, v721_0_2, v721_0_3, v721_0_4) => {
                        let v726: i32 = v721_0_4.clone();
                        let v725: i32 = v721_0_3.clone();
                        let v724: LrcPtr<StringBuilder> = v721_0_2.clone();
                        let v723: string = v721_0_1.clone();
                        let v722: string = v721_0_0.clone();
                        let v728: i32 = Runtime::method40(v723.clone(), 0_i32);
                        let v772: Runtime::US11 = if 0_i32 == (v728) {
                            Runtime::US11::US11_1(string(
                                "parsing.spaces1 / expected at least one space",
                            ))
                        } else {
                            Runtime::US11::US11_0(
                                getSlice(
                                    v723.clone(),
                                    Some(v728),
                                    Some((length(v723.clone())) - 1_i32),
                                ),
                                v724.clone(),
                                v725,
                                v726,
                            )
                        };
                        match &v772 {
                            Runtime::US11::US11_0(v772_0_0, v772_0_1, v772_0_2, v772_0_3) => {
                                let v0_temp: LrcPtr<Runtime::UH2> = LrcPtr::new(
                                    Runtime::UH2::UH2_1(v722.clone(), v0.get().clone()),
                                );
                                let v1_temp: string = v772_0_0.clone();
                                let v2_temp: LrcPtr<StringBuilder> = v772_0_1.clone();
                                let v3_temp: i32 = v772_0_2.clone();
                                let v4_temp: i32 = v772_0_3.clone();
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
                                        v722.clone(),
                                        LrcPtr::new(Runtime::UH2::UH2_0),
                                    )),
                                ),
                                v723.clone(),
                                v724.clone(),
                                v725,
                                v726,
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
                StringBuilder::_ctor__Z721C83C5(Runtime::method23()),
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
            bool,
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
                    bool,
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
                    bool,
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
            bool,
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
            bool,
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
                    bool,
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
        bool,
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
