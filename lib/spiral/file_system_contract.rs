pub mod File_system {
    use super::*;
    type Async<T> = T;
    use fable_library_rust::Choice_::Choice_2;
    type DateTime = ();
    type Guid = ();
    use fable_library_rust::List_::empty;
    use fable_library_rust::List_::ofArray;
    use fable_library_rust::List_::singleton;
    use fable_library_rust::List_::toArray;
    use fable_library_rust::Map_::find;
    use fable_library_rust::Map_::ofSeq;
    use fable_library_rust::Native_::Any;
    use fable_library_rust::Native_::Arc;
    use fable_library_rust::Native_::Func0;
    use fable_library_rust::Native_::Func1;
    use fable_library_rust::Native_::Func2;
    use fable_library_rust::Native_::Lrc;
    use fable_library_rust::Native_::LrcPtr;
    use fable_library_rust::Native_::MutCell;
    use fable_library_rust::Native_::OnceInit;
    use fable_library_rust::Native_::getNull;
    use fable_library_rust::Native_::interface_cast;
    use fable_library_rust::Native_::on_startup;
    use fable_library_rust::Native_::unbox;
    use fable_library_rust::NativeArray_::Array;
    use fable_library_rust::NativeArray_::new_array;
    use fable_library_rust::Option_::defaultValue;
    use fable_library_rust::Option_::map;
    use fable_library_rust::Seq_::ofList;
    use fable_library_rust::String_::append;
    use fable_library_rust::String_::concat;
    use fable_library_rust::String_::contains;
    use fable_library_rust::String_::getCharAt;
    use fable_library_rust::String_::getSlice;
    use fable_library_rust::String_::length;
    use fable_library_rust::String_::ofChar;
    use fable_library_rust::String_::printfn;
    use fable_library_rust::String_::replace;
    use fable_library_rust::String_::sprintf;
    use fable_library_rust::String_::string;
    use fable_library_rust::String_::toLower;
    use fable_library_rust::String_::toString;
    use fable_library_rust::String_::trimEndChars;
    use fable_library_rust::String_::trimStartChars;
    use fable_library_rust::System::Collections::Generic::IEnumerable_1;
    use fable_library_rust::System::Exception;
    use fable_library_rust::System::IDisposable;
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
                    LrcPtr<File_system::Mut0>,
                    LrcPtr<File_system::Mut1>,
                    LrcPtr<File_system::Mut2>,
                    LrcPtr<File_system::Mut3>,
                    LrcPtr<File_system::Mut4>,
                    Option<i64>,
                )>,
            >,
        > {
            static trace_state: OnceInit<
                LrcPtr<
                    MutCell<
                        Option<(
                            LrcPtr<File_system::Mut0>,
                            LrcPtr<File_system::Mut1>,
                            LrcPtr<File_system::Mut2>,
                            LrcPtr<File_system::Mut3>,
                            LrcPtr<File_system::Mut4>,
                            Option<i64>,
                        )>,
                    >,
                >,
            > = OnceInit::new();
            trace_state
                .get_or_init(|| {
                    LrcPtr::new(MutCell::new(
                        None::<(
                            LrcPtr<File_system::Mut0>,
                            LrcPtr<File_system::Mut1>,
                            LrcPtr<File_system::Mut2>,
                            LrcPtr<File_system::Mut3>,
                            LrcPtr<File_system::Mut4>,
                            Option<i64>,
                        )>,
                    ))
                })
                .clone()
        }
    }
    pub trait IFsExistsSync: core::fmt::Debug + core::fmt::Display {
        fn existsSync(&self, path: string) -> bool;
    }
    impl<V: IFsExistsSync + core::fmt::Debug + core::fmt::Display> IFsExistsSync for LrcPtr<V> {
        #[inline]
        fn existsSync(&self, path: string) -> bool {
            (**self).existsSync(path)
        }
    }
    pub trait IPathBasename: core::fmt::Debug + core::fmt::Display {
        fn basename(&self, path: string) -> string;
    }
    impl<V: IPathBasename + core::fmt::Debug + core::fmt::Display> IPathBasename for LrcPtr<V> {
        #[inline]
        fn basename(&self, path: string) -> string {
            (**self).basename(path)
        }
    }
    pub trait IPathJoin: core::fmt::Debug + core::fmt::Display {
        fn join(&self, paths: Array<string>) -> string;
    }
    impl<V: IPathJoin + core::fmt::Debug + core::fmt::Display> IPathJoin for LrcPtr<V> {
        #[inline]
        fn join(&self, paths: Array<string>) -> string {
            (**self).join(paths)
        }
    }
    #[derive(Clone, Debug)]
    pub struct Disposable {
        f: Func0<()>,
    }
    impl Disposable {
        pub fn _ctor__3A5B6456(f: Func0<()>) -> LrcPtr<File_system::Disposable> {
            let f_1;
            ();
            f_1 = f;
            ();
            LrcPtr::new(File_system::Disposable { f: f_1 })
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
    pub trait IPathDirname: core::fmt::Debug + core::fmt::Display {
        fn dirname(&self, path: string) -> string;
    }
    impl<V: IPathDirname + core::fmt::Debug + core::fmt::Display> IPathDirname for LrcPtr<V> {
        #[inline]
        fn dirname(&self, path: string) -> string {
            (**self).dirname(path)
        }
    }
    pub trait IFs: core::fmt::Debug + core::fmt::Display {
        fn realpathSync(&self, path: string) -> string;
    }
    impl<V: IFs + core::fmt::Debug + core::fmt::Display> IFs for LrcPtr<V> {
        #[inline]
        fn realpathSync(&self, path: string) -> string {
            (**self).realpathSync(path)
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
        pub l0: MutCell<File_system::US0>,
    }
    impl core::fmt::Display for Mut4 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US1 {
        US1_0(File_system::US0),
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
        US4_0(File_system::US3),
        US4_1(File_system::US3),
        US4_2(File_system::US3),
        US4_3(File_system::US3),
        US4_4(File_system::US3),
        US4_5(File_system::US3),
        US4_6(File_system::US3),
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
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
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
    pub enum US8 {
        US8_0,
        US8_1,
        US8_2,
    }
    impl core::fmt::Display for US8 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US9 {
        US9_0,
        US9_1,
        US9_2,
        US9_3,
        US9_4,
    }
    impl core::fmt::Display for US9 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US7 {
        US7_0(File_system::US8, File_system::US9),
        US7_1,
    }
    impl core::fmt::Display for US7 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US10 {
        US10_0,
        US10_1(string),
    }
    impl core::fmt::Display for US10 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US11 {
        US11_0(i64),
        US11_1(LrcPtr<Exception>),
    }
    impl core::fmt::Display for US11 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US12 {
        US12_0(i64),
        US12_1(LrcPtr<Exception>),
    }
    impl core::fmt::Display for US12 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US13 {
        US13_0(Option<()>),
        US13_1,
    }
    impl core::fmt::Display for US13 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US14 {
        US14_0,
        US14_1(std::string::String),
    }
    impl core::fmt::Display for US14 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US15 {
        US15_0(std::path::PathBuf),
        US15_1(string),
    }
    impl core::fmt::Display for US15 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US16 {
        US16_0(std::path::PathBuf),
        US16_1,
    }
    impl core::fmt::Display for US16 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub struct Mut5 {
        pub l0: MutCell<i32>,
        pub l1: MutCell<i32>,
        pub l2: MutCell<Array<string>>,
    }
    impl core::fmt::Display for Mut5 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub struct Mut6 {
        pub l0: MutCell<i32>,
    }
    impl core::fmt::Display for Mut6 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US17 {
        US17_0,
        US17_1,
    }
    impl core::fmt::Display for US17 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US18 {
        US18_0(string),
        US18_1(string),
    }
    impl core::fmt::Display for US18 {
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
    pub fn closure1(unitVar: (), v0: string) -> File_system::US5 {
        File_system::US5::US5_0(v0)
    }
    pub fn method5() -> Func1<string, File_system::US5> {
        Func1::new(move |v: string| File_system::closure1((), v))
    }
    pub fn method2(v0: string) -> string {
        panic!(
            "{}",
            sprintf!(
                "env.get_environment_variable / target: {} / var: {}",
                File_system::US4::US4_4(File_system::US3::US3_2),
                v0
            ),
        )
    }
    pub fn method1() -> (File_system::US1, File_system::US2) {
        let v1: string = File_system::method2(string("TRACE_LEVEL"));
        let v6: string = toLower(string("Critical"));
        let v13: string = toLower(string("Warning"));
        let v20: string = toLower(string("Info"));
        let v27: string = toLower(string("Debug"));
        let v34_1: string = toLower(string("Verbose"));
        let v41_1: File_system::US1 = if string("Verbose") == (v1.clone()) {
            File_system::US1::US1_0(File_system::US0::US0_0)
        } else {
            File_system::US1::US1_1
        };
        (
            match &v41_1 {
                File_system::US1::US1_0(v41_1_0_0) => File_system::US1::US1_0(
                    match &v41_1 {
                        File_system::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                ),
                _ => {
                    let v48_1: File_system::US1 = if string("Debug") == (v1.clone()) {
                        File_system::US1::US1_0(File_system::US0::US0_1)
                    } else {
                        File_system::US1::US1_1
                    };
                    match &v48_1 {
                        File_system::US1::US1_0(v48_1_0_0) => File_system::US1::US1_0(
                            match &v48_1 {
                                File_system::US1::US1_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v55: File_system::US1 = if string("Info") == (v1.clone()) {
                                File_system::US1::US1_0(File_system::US0::US0_2)
                            } else {
                                File_system::US1::US1_1
                            };
                            match &v55 {
                                File_system::US1::US1_0(v55_0_0) => File_system::US1::US1_0(
                                    match &v55 {
                                        File_system::US1::US1_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v62: File_system::US1 = if string("Warning") == (v1.clone())
                                    {
                                        File_system::US1::US1_0(File_system::US0::US0_3)
                                    } else {
                                        File_system::US1::US1_1
                                    };
                                    match &v62 {
                                        File_system::US1::US1_0(v62_0_0) => {
                                            File_system::US1::US1_0(
                                                match &v62 {
                                                    File_system::US1::US1_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            )
                                        }
                                        _ => {
                                            let v69: File_system::US1 =
                                                if string("Critical") == (v1.clone()) {
                                                    File_system::US1::US1_0(File_system::US0::US0_4)
                                                } else {
                                                    File_system::US1::US1_1
                                                };
                                            match &v69 {
                                                File_system::US1::US1_0(v69_0_0) => {
                                                    File_system::US1::US1_0(
                                                        match &v69 {
                                                            File_system::US1::US1_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => {
                                                    let v76: File_system::US1 =
                                                        if (v34_1.clone()) == (v1.clone()) {
                                                            File_system::US1::US1_0(
                                                                File_system::US0::US0_0,
                                                            )
                                                        } else {
                                                            File_system::US1::US1_1
                                                        };
                                                    match &v76 {
                                                        File_system::US1::US1_0(v76_0_0) => {
                                                            File_system::US1::US1_0(
                                                                match &v76 {
                                                                    File_system::US1::US1_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            let v83: File_system::US1 =
                                                                if (v27.clone()) == (v1.clone()) {
                                                                    File_system::US1::US1_0(
                                                                        File_system::US0::US0_1,
                                                                    )
                                                                } else {
                                                                    File_system::US1::US1_1
                                                                };
                                                            match &v83 {
                                                                File_system::US1::US1_0(
                                                                    v83_0_0,
                                                                ) => File_system::US1::US1_0(
                                                                    match &v83 {
                                                                        File_system::US1::US1_0(
                                                                            x,
                                                                        ) => x.clone(),
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                ),
                                                                _ => {
                                                                    let v90: File_system::US1 =
                                                                        if (v20.clone())
                                                                            == (v1.clone())
                                                                        {
                                                                            File_system::US1::US1_0(File_system::US0::US0_2)
                                                                        } else {
                                                                            File_system::US1::US1_1
                                                                        };
                                                                    match &v90 {
                                                                     File_system::US1::US1_0(v90_0_0)
                                                                     =>
                                                                     File_system::US1::US1_0(match &v90
                                                                                                 {
                                                                                                 File_system::US1::US1_0(x)
                                                                                                 =>
                                                                                                 x.clone(),
                                                                                                 _
                                                                                                 =>
                                                                                                 unreachable!(),
                                                                                             }.clone()),
                                                                     _ => {
                                                                         let v97:
                                                                                 File_system::US1 =
                                                                             if (v13.clone())
                                                                                    ==
                                                                                    (v1.clone())
                                                                                {
                                                                                 File_system::US1::US1_0(File_system::US0::US0_3)
                                                                             } else {
                                                                                 File_system::US1::US1_1
                                                                             };
                                                                         match &v97
                                                                             {
                                                                             File_system::US1::US1_0(v97_0_0)
                                                                             =>
                                                                             File_system::US1::US1_0(match &v97
                                                                                                         {
                                                                                                         File_system::US1::US1_0(x)
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
                                                                                         File_system::US1 =
                                                                                     if (v6.clone())
                                                                                            ==
                                                                                            (v1.clone())
                                                                                        {
                                                                                         File_system::US1::US1_0(File_system::US0::US0_4)
                                                                                     } else {
                                                                                         File_system::US1::US1_1
                                                                                     };
                                                                                 match &v104
                                                                                     {
                                                                                     File_system::US1::US1_0(v104_0_0)
                                                                                     =>
                                                                                     File_system::US1::US1_0(match &v104
                                                                                                                 {
                                                                                                                 File_system::US1::US1_0(x)
                                                                                                                 =>
                                                                                                                 x.clone(),
                                                                                                                 _
                                                                                                                 =>
                                                                                                                 unreachable!(),
                                                                                                             }.clone()),
                                                                                     _
                                                                                     =>
                                                                                     File_system::US1::US1_1,
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
            if (File_system::method2(string("AUTOMATION"))) != string("True") {
                File_system::US2::US2_1
            } else {
                let v147: DateTime = unbox::<DateTime>(fable_library_rust::Native_::getZero());
                File_system::US2::US2_0(unbox::<i64>(fable_library_rust::Native_::getZero()))
            },
        )
    }
    pub fn closure2(unitVar: (), v0: string) {
        ();
    }
    pub fn method0(
        v0: File_system::US0,
    ) -> (
        LrcPtr<File_system::Mut0>,
        LrcPtr<File_system::Mut1>,
        LrcPtr<File_system::Mut2>,
        LrcPtr<File_system::Mut3>,
        LrcPtr<File_system::Mut4>,
        Option<i64>,
    ) {
        let v94: string = string("option_env!(\"AUTOMATION\").unwrap_or(\"\")");
        let v95: &str = option_env!("AUTOMATION").unwrap_or("");
        let v106: std::string::String = String::from(v95);
        let _run_target_args__v3: (File_system::US1, File_system::US2) = (
            File_system::US1::US1_1,
            if (fable_library_rust::String_::fromString(v106)) != string("True") {
                File_system::US2::US2_1
            } else {
                File_system::US2::US2_0(near_sdk::env::block_timestamp() as i64)
            },
        );
        let v185: File_system::US2 = _run_target_args__v3.1.clone();
        let v184: File_system::US1 = _run_target_args__v3.0.clone();
        (
            LrcPtr::new(File_system::Mut0 {
                l0: MutCell::new(1_i64),
            }),
            LrcPtr::new(File_system::Mut1 {
                l0: MutCell::new(Func1::new(move |v: string| File_system::closure2((), v))),
            }),
            LrcPtr::new(File_system::Mut2 {
                l0: MutCell::new(true),
            }),
            LrcPtr::new(File_system::Mut3 {
                l0: MutCell::new(string("")),
            }),
            LrcPtr::new(File_system::Mut4 {
                l0: MutCell::new(match &v184 {
                    File_system::US1::US1_0(v184_0_0) => match &v184 {
                        File_system::US1::US1_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    _ => v0.clone(),
                }),
            }),
            match &v185 {
                File_system::US2::US2_0(v185_0_0) => Some(match &v185 {
                    File_system::US2::US2_0(x) => x.clone(),
                    _ => unreachable!(),
                }),
                _ => None::<i64>,
            },
        )
    }
    pub fn closure0(unitVar: (), unitVar_1: ()) {
        if File_system::TraceState::trace_state()
            .get()
            .clone()
            .is_none()
        {
            let patternInput: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::method0(File_system::US0::US0_0);
            File_system::TraceState::trace_state().set(Some((
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
    pub fn method10(v0: string) -> bool {
        unbox::<bool>(fable_library_rust::Native_::getZero())
    }
    pub fn method9(v0: bool, v1: string) {
        ();
    }
    pub fn closure5(unitVar: (), v0: i64) -> File_system::US2 {
        File_system::US2::US2_0(v0)
    }
    pub fn method12() -> Func1<i64, File_system::US2> {
        Func1::new(move |v: i64| File_system::closure5((), v))
    }
    pub fn method13() -> string {
        string("hh:mm:ss")
    }
    pub fn method14() -> string {
        string("HH:mm:ss")
    }
    pub fn method11(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
    ) -> string {
        let v638: u64 = near_sdk::env::block_timestamp();
        let v663: File_system::US2 =
            defaultValue(File_system::US2::US2_1, map(File_system::method12(), v5));
        let v676: u64 = (match &v663 {
            File_system::US2::US2_0(v663_0_0) => {
                (v638)
                    - (match &v663 {
                        File_system::US2::US2_0(x) => x.clone(),
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
    pub fn method17() -> string {
        string("")
    }
    pub fn closure6(v0: LrcPtr<File_system::Mut3>, v1: string, unitVar: ()) {
        let v4: string = append((v0.l0.get().clone()), (v1));
        v0.l0.set(v4);
        ()
    }
    pub fn method16(v0: char) -> string {
        let v2: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v17: () = {
            File_system::closure6(v2.clone(), sprintf!("{}", v0), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method15() -> string {
        let v83: &str = inline_colorization::color_bright_blue;
        let v94: std::string::String = String::from(v83);
        let v139: string = append(
            (fable_library_rust::String_::fromString(v94)),
            (File_system::method16(getCharAt(toLower(string("Debug")), 0_i32))),
        );
        let v225: &str = inline_colorization::color_reset;
        let v236: std::string::String = String::from(v225);
        append((v139), (fable_library_rust::String_::fromString(v236)))
    }
    pub fn method18(v0: string) -> string {
        unbox::<string>(fable_library_rust::Native_::getZero())
    }
    pub fn method20(v0: string, v1: string) -> string {
        let v3: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v17: () = {
            File_system::closure6(v3.clone(), string("{ "), ());
            ()
        };
        let v36_1: () = {
            File_system::closure6(v3.clone(), string("ex"), ());
            ()
        };
        let v55: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v72: () = {
            File_system::closure6(v3.clone(), v0, ());
            ()
        };
        let v91: () = {
            File_system::closure6(v3.clone(), string("; "), ());
            ()
        };
        let v110: () = {
            File_system::closure6(v3.clone(), string("path"), ());
            ()
        };
        let v127: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v144: () = {
            File_system::closure6(v3.clone(), v1, ());
            ()
        };
        let v163: () = {
            File_system::closure6(v3.clone(), string(" }"), ());
            ()
        };
        v3.l0.get().clone()
    }
    pub fn method21(v0: string) -> string {
        trimEndChars(
            trimStartChars(v0, toArray(empty::<char>())),
            toArray(ofArray(new_array(&[' ', '/']))),
        )
    }
    pub fn method19(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
        v9: string,
    ) -> string {
        let v10: string = File_system::method20(v8, v9);
        File_system::method21(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("file_system.delete_directory_async"),
                )),
                string(" / "),
            )),
            (v10),
        ))
    }
    pub fn closure7(v0: LrcPtr<File_system::Mut0>, unitVar: ()) {
        let v2: i64 = (v0.l0.get().clone()) + 1_i64;
        v0.l0.set(v2);
        ()
    }
    pub fn closure9(v0: string, unitVar: ()) {
        printfn!("{0}", v0);
    }
    pub fn closure8(unitVar: (), v0: string) {
        let v4: () = {
            File_system::closure9(v0, ());
            ()
        };
        ()
    }
    pub fn closure4(v0: string, v1: LrcPtr<Exception>, unitVar: ()) {
        fn v17() {
            File_system::closure0((), ());
        }
        let v18: () = {
            v17();
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v59: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        let v339: File_system::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            1_i32
                >= (find(
                    v59,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                        LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                        LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                        LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                        LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            File_system::US6::US6_1
        } else {
            let v82: () = {
                v17();
                ()
            };
            let patternInput_1: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v110: Option<i64> = patternInput_1.5.clone();
            let v109: LrcPtr<File_system::Mut4> = patternInput_1.4.clone();
            let v108: LrcPtr<File_system::Mut3> = patternInput_1.3.clone();
            let v107: LrcPtr<File_system::Mut2> = patternInput_1.2.clone();
            let v106: LrcPtr<File_system::Mut1> = patternInput_1.1.clone();
            let v105: LrcPtr<File_system::Mut0> = patternInput_1.0.clone();
            let v165: string = File_system::method19(
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                File_system::method11(v105, v106, v107, v108, v109, v110),
                File_system::method15(),
                sprintf!("{:?}", v1),
                File_system::method18(v0),
            );
            let v181: () = {
                v17();
                ()
            };
            let patternInput_2: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v207: LrcPtr<File_system::Mut3> = patternInput_2.3.clone();
            let v205: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v204: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v226: () = {
                File_system::closure7(v204.clone(), ());
                ()
            };
            let v249: string = if (v207.l0.get().clone()) == string("") {
                v165.clone()
            } else {
                if (v165.clone()) == string("") {
                    v207.l0.get().clone()
                } else {
                    append(
                        (append((v207.l0.get().clone()), string("\n"))),
                        (v165.clone()),
                    )
                }
            };
            let v260: &str = &*v249.clone();
            let v287 = v260.chars();
            let v289 = v287;
            let v291: Vec<char> = v289.collect::<Vec<_>>();
            let v293: Vec<Vec<char>> = v291
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v295: bool = true;
            let _vec_map: Vec<_> = v293
                .into_iter()
                .map(|x| {
                    //;
                    let v297: Vec<char> = x;
                    let v299: std::string::String = String::from_iter(v297);
                    let v301: bool = true;
                    v299
                })
                .collect::<Vec<_>>();
            let v303: Vec<std::string::String> = _vec_map;
            if if (v165.clone()) != string("") {
                (v303.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v207.l0.set(v249);
                ()
            } else {
                v207.l0.set(string(""));
                {
                    let v328: bool = true;
                    v303.into_iter().for_each(|x| {
                        //;
                        let v330: std::string::String = x;
                        let v332: bool = true;
                        near_sdk::log!("{}", v330);
                        let v334: bool = true;
                        let v336: bool = true;
                    }); //;
                    ()
                }
            }
            (v205.l0.get().clone())(v165);
            File_system::US6::US6_0(
                v204,
                v205,
                patternInput_2.2.clone(),
                v207,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method8(v0: string, v1: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method7(v0: string, v1: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method6(v0: string) -> Arc<Async<i64>> {
        File_system::method7(v0, 0_i64)
    }
    pub fn closure3(unitVar: (), v0: string) -> Arc<Async<i64>> {
        File_system::method6(v0)
    }
    pub fn method26(v0: string, v1: i64, v2: string) -> string {
        let v4: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v18: () = {
            File_system::closure6(v4.clone(), string("{ "), ());
            ()
        };
        let v37_1: () = {
            File_system::closure6(v4.clone(), string("path"), ());
            ()
        };
        let v56: () = {
            File_system::closure6(v4.clone(), string(" = "), ());
            ()
        };
        let v73: () = {
            File_system::closure6(v4.clone(), v0, ());
            ()
        };
        let v92: () = {
            File_system::closure6(v4.clone(), string("; "), ());
            ()
        };
        let v111: () = {
            File_system::closure6(v4.clone(), string("retry"), ());
            ()
        };
        let v128: () = {
            File_system::closure6(v4.clone(), string(" = "), ());
            ()
        };
        let v148: () = {
            File_system::closure6(v4.clone(), sprintf!("{}", v1), ());
            ()
        };
        let v165: () = {
            File_system::closure6(v4.clone(), string("; "), ());
            ()
        };
        let v184: () = {
            File_system::closure6(v4.clone(), string("ex"), ());
            ()
        };
        let v201: () = {
            File_system::closure6(v4.clone(), string(" = "), ());
            ()
        };
        let v218: () = {
            File_system::closure6(v4.clone(), v2, ());
            ()
        };
        let v237: () = {
            File_system::closure6(v4.clone(), string(" }"), ());
            ()
        };
        v4.l0.get().clone()
    }
    pub fn method25(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
        v9: i64,
        v10: string,
    ) -> string {
        let v11: string = File_system::method26(v8, v9, v10);
        File_system::method21(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("file_system.wait_for_file_access"),
                )),
                string(" / "),
            )),
            (v11),
        ))
    }
    pub fn closure12(v0: string, v1: i64, v2: LrcPtr<Exception>, unitVar: ()) {
        fn v18() {
            File_system::closure0((), ());
        }
        let v19: () = {
            v18();
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v60: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        let v340: File_system::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            1_i32
                >= (find(
                    v60,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                        LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                        LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                        LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                        LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            File_system::US6::US6_1
        } else {
            let v83: () = {
                v18();
                ()
            };
            let patternInput_1: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v111: Option<i64> = patternInput_1.5.clone();
            let v110: LrcPtr<File_system::Mut4> = patternInput_1.4.clone();
            let v109: LrcPtr<File_system::Mut3> = patternInput_1.3.clone();
            let v108: LrcPtr<File_system::Mut2> = patternInput_1.2.clone();
            let v107: LrcPtr<File_system::Mut1> = patternInput_1.1.clone();
            let v106: LrcPtr<File_system::Mut0> = patternInput_1.0.clone();
            let v166: string = File_system::method25(
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                v111.clone(),
                File_system::method11(v106, v107, v108, v109, v110, v111),
                File_system::method15(),
                File_system::method18(v0),
                v1,
                sprintf!("{:?}", v2),
            );
            let v182: () = {
                v18();
                ()
            };
            let patternInput_2: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v208: LrcPtr<File_system::Mut3> = patternInput_2.3.clone();
            let v206: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v205: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v227: () = {
                File_system::closure7(v205.clone(), ());
                ()
            };
            let v250: string = if (v208.l0.get().clone()) == string("") {
                v166.clone()
            } else {
                if (v166.clone()) == string("") {
                    v208.l0.get().clone()
                } else {
                    append(
                        (append((v208.l0.get().clone()), string("\n"))),
                        (v166.clone()),
                    )
                }
            };
            let v261: &str = &*v250.clone();
            let v288 = v261.chars();
            let v290 = v288;
            let v292: Vec<char> = v290.collect::<Vec<_>>();
            let v294: Vec<Vec<char>> = v292
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v296: bool = true;
            let _vec_map: Vec<_> = v294
                .into_iter()
                .map(|x| {
                    //;
                    let v298: Vec<char> = x;
                    let v300: std::string::String = String::from_iter(v298);
                    let v302: bool = true;
                    v300
                })
                .collect::<Vec<_>>();
            let v304: Vec<std::string::String> = _vec_map;
            if if (v166.clone()) != string("") {
                (v304.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v208.l0.set(v250);
                ()
            } else {
                v208.l0.set(string(""));
                {
                    let v329: bool = true;
                    v304.into_iter().for_each(|x| {
                        //;
                        let v331: std::string::String = x;
                        let v333: bool = true;
                        near_sdk::log!("{}", v331);
                        let v335: bool = true;
                        let v337: bool = true;
                    }); //;
                    ()
                }
            }
            (v206.l0.get().clone())(v166);
            File_system::US6::US6_0(
                v205,
                v206,
                patternInput_2.2.clone(),
                v208,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method24(
        v0: File_system::US7,
        v1: string,
        v2: i64,
        v3: File_system::US9,
        v4: File_system::US8,
    ) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method23(v0: File_system::US7, v1: string, v2: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method22(v0: File_system::US7, v1: string) -> Arc<Async<i64>> {
        File_system::method23(v0, v1, 0_i64)
    }
    pub fn closure11(v0: File_system::US7, v1: string) -> Arc<Async<i64>> {
        File_system::method22(v0, v1)
    }
    pub fn closure10(unitVar: (), v0: File_system::US7) -> Func1<string, Arc<Async<i64>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure11(v0.clone(), v)
        })
    }
    pub fn method27(v0: string) -> Arc<Async<i64>> {
        File_system::method22(
            File_system::US7::US7_0(File_system::US8::US8_0, File_system::US9::US9_1),
            v0,
        )
    }
    pub fn closure13(unitVar: (), v0: string) -> Arc<Async<i64>> {
        File_system::method27(v0)
    }
    pub fn method31() -> string {
        let v83: &str = inline_colorization::color_bright_black;
        let v94: std::string::String = String::from(v83);
        let v139: string = append(
            (fable_library_rust::String_::fromString(v94)),
            (File_system::method16(getCharAt(toLower(string("Verbose")), 0_i32))),
        );
        let v225: &str = inline_colorization::color_reset;
        let v236: std::string::String = String::from(v225);
        append((v139), (fable_library_rust::String_::fromString(v236)))
    }
    pub fn method33(v0: i64, v1: string, v2: LrcPtr<Exception>) -> string {
        let v4: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v18: () = {
            File_system::closure6(v4.clone(), string("{ "), ());
            ()
        };
        let v37_1: () = {
            File_system::closure6(v4.clone(), string("retry"), ());
            ()
        };
        let v56: () = {
            File_system::closure6(v4.clone(), string(" = "), ());
            ()
        };
        let v76: () = {
            File_system::closure6(v4.clone(), sprintf!("{}", v0), ());
            ()
        };
        let v95: () = {
            File_system::closure6(v4.clone(), string("; "), ());
            ()
        };
        let v114: () = {
            File_system::closure6(v4.clone(), string("path"), ());
            ()
        };
        let v131: () = {
            File_system::closure6(v4.clone(), string(" = "), ());
            ()
        };
        let v148: () = {
            File_system::closure6(v4.clone(), v1, ());
            ()
        };
        let v165: () = {
            File_system::closure6(v4.clone(), string("; "), ());
            ()
        };
        let v184: () = {
            File_system::closure6(v4.clone(), string("ex"), ());
            ()
        };
        let v201: () = {
            File_system::closure6(v4.clone(), string(" = "), ());
            ()
        };
        let v221: std::string::String = format!("{:#?}", v2);
        let v260: () = {
            File_system::closure6(
                v4.clone(),
                fable_library_rust::String_::fromString(v221),
                (),
            );
            ()
        };
        let v279: () = {
            File_system::closure6(v4.clone(), string(" }"), ());
            ()
        };
        v4.l0.get().clone()
    }
    pub fn method32(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i64,
        v9: string,
        v10: LrcPtr<Exception>,
    ) -> string {
        let v11: string = File_system::method33(v8, v9, v10);
        File_system::method21(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("file_system.read_all_text_async"),
                )),
                string(" / "),
            )),
            (v11),
        ))
    }
    pub fn closure15(v0: string, v1: i64, v2: LrcPtr<Exception>, unitVar: ()) {
        fn v18() {
            File_system::closure0((), ());
        }
        let v19: () = {
            v18();
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v60: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        let v300: File_system::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            0_i32
                >= (find(
                    v60,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                        LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                        LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                        LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                        LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            File_system::US6::US6_1
        } else {
            let v83: () = {
                v18();
                ()
            };
            let patternInput_1: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v111: Option<i64> = patternInput_1.5.clone();
            let v110: LrcPtr<File_system::Mut4> = patternInput_1.4.clone();
            let v109: LrcPtr<File_system::Mut3> = patternInput_1.3.clone();
            let v108: LrcPtr<File_system::Mut2> = patternInput_1.2.clone();
            let v107: LrcPtr<File_system::Mut1> = patternInput_1.1.clone();
            let v106: LrcPtr<File_system::Mut0> = patternInput_1.0.clone();
            let v126: string = File_system::method32(
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                v111.clone(),
                File_system::method11(v106, v107, v108, v109, v110, v111),
                File_system::method31(),
                v1,
                v0,
                v2,
            );
            let v142: () = {
                v18();
                ()
            };
            let patternInput_2: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v168: LrcPtr<File_system::Mut3> = patternInput_2.3.clone();
            let v166: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v165: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v187: () = {
                File_system::closure7(v165.clone(), ());
                ()
            };
            let v210: string = if (v168.l0.get().clone()) == string("") {
                v126.clone()
            } else {
                if (v126.clone()) == string("") {
                    v168.l0.get().clone()
                } else {
                    append(
                        (append((v168.l0.get().clone()), string("\n"))),
                        (v126.clone()),
                    )
                }
            };
            let v221: &str = &*v210.clone();
            let v248 = v221.chars();
            let v250 = v248;
            let v252: Vec<char> = v250.collect::<Vec<_>>();
            let v254: Vec<Vec<char>> = v252
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v256: bool = true;
            let _vec_map: Vec<_> = v254
                .into_iter()
                .map(|x| {
                    //;
                    let v258: Vec<char> = x;
                    let v260: std::string::String = String::from_iter(v258);
                    let v262: bool = true;
                    v260
                })
                .collect::<Vec<_>>();
            let v264: Vec<std::string::String> = _vec_map;
            if if (v126.clone()) != string("") {
                (v264.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v168.l0.set(v210);
                ()
            } else {
                v168.l0.set(string(""));
                {
                    let v289: bool = true;
                    v264.into_iter().for_each(|x| {
                        //;
                        let v291: std::string::String = x;
                        let v293: bool = true;
                        near_sdk::log!("{}", v291);
                        let v295: bool = true;
                        let v297: bool = true;
                    }); //;
                    ()
                }
            }
            (v166.l0.get().clone())(v126);
            File_system::US6::US6_0(
                v165,
                v166,
                patternInput_2.2.clone(),
                v168,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method30(v0: string, v1: i64) -> Arc<Async<string>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method29(v0: string, v1: i64) -> Arc<Async<string>> {
        File_system::method30(v0, v1)
    }
    pub fn method28(v0: string) -> Arc<Async<string>> {
        File_system::method29(v0, 0_i64)
    }
    pub fn closure14(unitVar: (), v0: string) -> Arc<Async<string>> {
        File_system::method28(v0)
    }
    pub fn method35(v0: string) -> bool {
        unbox::<bool>(fable_library_rust::Native_::getZero())
    }
    pub fn method36(v0: Vec<u8>) -> Vec<u8> {
        v0
    }
    pub fn method34(v0: string, v1: string) -> bool {
        unbox::<bool>(fable_library_rust::Native_::getZero())
    }
    pub fn closure17(v0: string, v1: string) -> bool {
        File_system::method34(v0, v1)
    }
    pub fn closure16(unitVar: (), v0: string) -> Func1<string, bool> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure17(v0.clone(), v)
        })
    }
    pub fn method37(v0: string, v1: string) -> Arc<Async<()>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn closure19(v0: string, v1: string) -> Arc<Async<()>> {
        File_system::method37(v0, v1)
    }
    pub fn closure18(unitVar: (), v0: string) -> Func1<string, Arc<Async<()>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure19(v0.clone(), v)
        })
    }
    pub fn method41(v0: string, v1: string) -> Arc<Async<bool>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method40(v0: string, v1: string) -> Arc<Async<bool>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method39(v0: string, v1: string) -> Arc<Async<()>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method38(v0: string, v1: string) -> Arc<Async<()>> {
        File_system::method39(v0, v1)
    }
    pub fn closure21(v0: string, v1: string) -> Arc<Async<()>> {
        File_system::method38(v0, v1)
    }
    pub fn closure20(unitVar: (), v0: string) -> Func1<string, Arc<Async<()>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure21(v0.clone(), v)
        })
    }
    pub fn method46(v0: std::io::Error) -> string {
        let v2: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v17: std::string::String = format!("{:#?}", v0);
        let v56: () = {
            File_system::closure6(v2.clone(), fable_library_rust::String_::fromString(v17), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn closure23(unitVar: (), v0: std::io::Error) -> string {
        File_system::method46(v0)
    }
    pub fn method45() -> Func1<std::io::Error, string> {
        Func1::new(move |v: std::io::Error| File_system::closure23((), v))
    }
    pub fn closure24(unitVar: (), unitVar_1: ()) -> File_system::US10 {
        File_system::US10::US10_0
    }
    pub fn method47() -> Func0<File_system::US10> {
        Func0::new(move || File_system::closure24((), ()))
    }
    pub fn closure25(unitVar: (), v0: string) -> File_system::US10 {
        File_system::US10::US10_1(v0)
    }
    pub fn method48() -> Func1<string, File_system::US10> {
        Func1::new(move |v: string| File_system::closure25((), v))
    }
    pub fn method49() -> string {
        let v83: &str = inline_colorization::color_bright_red;
        let v94: std::string::String = String::from(v83);
        let v139: string = append(
            (fable_library_rust::String_::fromString(v94)),
            (File_system::method16(getCharAt(toLower(string("Critical")), 0_i32))),
        );
        let v225: &str = inline_colorization::color_reset;
        let v236: std::string::String = String::from(v225);
        append((v139), (fable_library_rust::String_::fromString(v236)))
    }
    pub fn method51(v0: string) -> string {
        let v2: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v16_1: () = {
            File_system::closure6(v2.clone(), string("{ "), ());
            ()
        };
        let v35_1: () = {
            File_system::closure6(v2.clone(), string("error\'"), ());
            ()
        };
        let v54: () = {
            File_system::closure6(v2.clone(), string(" = "), ());
            ()
        };
        let v71: () = {
            File_system::closure6(v2.clone(), v0, ());
            ()
        };
        let v90: () = {
            File_system::closure6(v2.clone(), string(" }"), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method50(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
    ) -> string {
        let v9: string = File_system::method51(v8);
        File_system::method21(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("file_system.file_delete"),
                )),
                string(" / "),
            )),
            (v9),
        ))
    }
    pub fn closure26(v0: string, unitVar: ()) {
        fn v16_1() {
            File_system::closure0((), ());
        }
        let v17: () = {
            v16_1();
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v58: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        let v298: File_system::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            4_i32
                >= (find(
                    v58,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                        LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                        LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                        LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                        LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            File_system::US6::US6_1
        } else {
            let v81: () = {
                v16_1();
                ()
            };
            let patternInput_1: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v109: Option<i64> = patternInput_1.5.clone();
            let v108: LrcPtr<File_system::Mut4> = patternInput_1.4.clone();
            let v107: LrcPtr<File_system::Mut3> = patternInput_1.3.clone();
            let v106: LrcPtr<File_system::Mut2> = patternInput_1.2.clone();
            let v105: LrcPtr<File_system::Mut1> = patternInput_1.1.clone();
            let v104: LrcPtr<File_system::Mut0> = patternInput_1.0.clone();
            let v124: string = File_system::method50(
                v104.clone(),
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                File_system::method11(v104, v105, v106, v107, v108, v109),
                File_system::method49(),
                v0,
            );
            let v140: () = {
                v16_1();
                ()
            };
            let patternInput_2: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v166: LrcPtr<File_system::Mut3> = patternInput_2.3.clone();
            let v164: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v163: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v185: () = {
                File_system::closure7(v163.clone(), ());
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
            File_system::US6::US6_0(
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
    pub fn method52() -> string {
        let v83: &str = inline_colorization::color_yellow;
        let v94: std::string::String = String::from(v83);
        let v139: string = append(
            (fable_library_rust::String_::fromString(v94)),
            (File_system::method16(getCharAt(toLower(string("Warning")), 0_i32))),
        );
        let v225: &str = inline_colorization::color_reset;
        let v236: std::string::String = String::from(v225);
        append((v139), (fable_library_rust::String_::fromString(v236)))
    }
    pub fn method54(v0: string, v1: string) -> string {
        let v3: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v17: () = {
            File_system::closure6(v3.clone(), string("{ "), ());
            ()
        };
        let v36_1: () = {
            File_system::closure6(v3.clone(), string("path"), ());
            ()
        };
        let v55: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v72: () = {
            File_system::closure6(v3.clone(), v0, ());
            ()
        };
        let v91: () = {
            File_system::closure6(v3.clone(), string("; "), ());
            ()
        };
        let v110: () = {
            File_system::closure6(v3.clone(), string("ex"), ());
            ()
        };
        let v127: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v144: () = {
            File_system::closure6(v3.clone(), v1, ());
            ()
        };
        let v163: () = {
            File_system::closure6(v3.clone(), string(" }"), ());
            ()
        };
        v3.l0.get().clone()
    }
    pub fn method53(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
        v9: string,
    ) -> string {
        let v10: string = File_system::method54(v8, v9);
        File_system::method21(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("delete_file_async"),
                )),
                string(" / "),
            )),
            (v10),
        ))
    }
    pub fn closure27(v0: string, v1: LrcPtr<Exception>, unitVar: ()) {
        fn v17() {
            File_system::closure0((), ());
        }
        let v18: () = {
            v17();
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v59: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        let v339: File_system::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            3_i32
                >= (find(
                    v59,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                        LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                        LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                        LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                        LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            File_system::US6::US6_1
        } else {
            let v82: () = {
                v17();
                ()
            };
            let patternInput_1: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v110: Option<i64> = patternInput_1.5.clone();
            let v109: LrcPtr<File_system::Mut4> = patternInput_1.4.clone();
            let v108: LrcPtr<File_system::Mut3> = patternInput_1.3.clone();
            let v107: LrcPtr<File_system::Mut2> = patternInput_1.2.clone();
            let v106: LrcPtr<File_system::Mut1> = patternInput_1.1.clone();
            let v105: LrcPtr<File_system::Mut0> = patternInput_1.0.clone();
            let v165: string = File_system::method53(
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                File_system::method11(v105, v106, v107, v108, v109, v110),
                File_system::method52(),
                File_system::method18(v0),
                sprintf!("{:?}", v1),
            );
            let v181: () = {
                v17();
                ()
            };
            let patternInput_2: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v207: LrcPtr<File_system::Mut3> = patternInput_2.3.clone();
            let v205: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v204: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v226: () = {
                File_system::closure7(v204.clone(), ());
                ()
            };
            let v249: string = if (v207.l0.get().clone()) == string("") {
                v165.clone()
            } else {
                if (v165.clone()) == string("") {
                    v207.l0.get().clone()
                } else {
                    append(
                        (append((v207.l0.get().clone()), string("\n"))),
                        (v165.clone()),
                    )
                }
            };
            let v260: &str = &*v249.clone();
            let v287 = v260.chars();
            let v289 = v287;
            let v291: Vec<char> = v289.collect::<Vec<_>>();
            let v293: Vec<Vec<char>> = v291
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v295: bool = true;
            let _vec_map: Vec<_> = v293
                .into_iter()
                .map(|x| {
                    //;
                    let v297: Vec<char> = x;
                    let v299: std::string::String = String::from_iter(v297);
                    let v301: bool = true;
                    v299
                })
                .collect::<Vec<_>>();
            let v303: Vec<std::string::String> = _vec_map;
            if if (v165.clone()) != string("") {
                (v303.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v207.l0.set(v249);
                ()
            } else {
                v207.l0.set(string(""));
                {
                    let v328: bool = true;
                    v303.into_iter().for_each(|x| {
                        //;
                        let v330: std::string::String = x;
                        let v332: bool = true;
                        near_sdk::log!("{}", v330);
                        let v334: bool = true;
                        let v336: bool = true;
                    }); //;
                    ()
                }
            }
            (v205.l0.get().clone())(v165);
            File_system::US6::US6_0(
                v204,
                v205,
                patternInput_2.2.clone(),
                v207,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method44(v0: string, v1: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method43(v0: string, v1: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method42(v0: string) -> Arc<Async<i64>> {
        File_system::method43(v0, 0_i64)
    }
    pub fn closure22(unitVar: (), v0: string) -> Arc<Async<i64>> {
        File_system::method42(v0)
    }
    pub fn method58(v0: string, v1: string) {
        ();
    }
    pub fn method60(v0: string, v1: string, v2: string) -> string {
        let v4: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v18: () = {
            File_system::closure6(v4.clone(), string("{ "), ());
            ()
        };
        let v37_1: () = {
            File_system::closure6(v4.clone(), string("old_path"), ());
            ()
        };
        let v56: () = {
            File_system::closure6(v4.clone(), string(" = "), ());
            ()
        };
        let v73: () = {
            File_system::closure6(v4.clone(), v0, ());
            ()
        };
        let v92: () = {
            File_system::closure6(v4.clone(), string("; "), ());
            ()
        };
        let v111: () = {
            File_system::closure6(v4.clone(), string("new_path"), ());
            ()
        };
        let v128: () = {
            File_system::closure6(v4.clone(), string(" = "), ());
            ()
        };
        let v145: () = {
            File_system::closure6(v4.clone(), v1, ());
            ()
        };
        let v162: () = {
            File_system::closure6(v4.clone(), string("; "), ());
            ()
        };
        let v181: () = {
            File_system::closure6(v4.clone(), string("ex"), ());
            ()
        };
        let v198: () = {
            File_system::closure6(v4.clone(), string(" = "), ());
            ()
        };
        let v215: () = {
            File_system::closure6(v4.clone(), v2, ());
            ()
        };
        let v234: () = {
            File_system::closure6(v4.clone(), string(" }"), ());
            ()
        };
        v4.l0.get().clone()
    }
    pub fn method59(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
        v9: string,
        v10: string,
    ) -> string {
        let v11: string = File_system::method60(v8, v9, v10);
        File_system::method21(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("move_file_async"),
                )),
                string(" / "),
            )),
            (v11),
        ))
    }
    pub fn closure30(v0: string, v1: string, v2: LrcPtr<Exception>, unitVar: ()) {
        fn v18() {
            File_system::closure0((), ());
        }
        let v19: () = {
            v18();
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v60: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        let v341: File_system::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            3_i32
                >= (find(
                    v60,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                        LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                        LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                        LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                        LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            File_system::US6::US6_1
        } else {
            let v83: () = {
                v18();
                ()
            };
            let patternInput_1: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v111: Option<i64> = patternInput_1.5.clone();
            let v110: LrcPtr<File_system::Mut4> = patternInput_1.4.clone();
            let v109: LrcPtr<File_system::Mut3> = patternInput_1.3.clone();
            let v108: LrcPtr<File_system::Mut2> = patternInput_1.2.clone();
            let v107: LrcPtr<File_system::Mut1> = patternInput_1.1.clone();
            let v106: LrcPtr<File_system::Mut0> = patternInput_1.0.clone();
            let v167: string = File_system::method59(
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                v111.clone(),
                File_system::method11(v106, v107, v108, v109, v110, v111),
                File_system::method52(),
                File_system::method18(v1),
                File_system::method18(v0),
                sprintf!("{:?}", v2),
            );
            let v183: () = {
                v18();
                ()
            };
            let patternInput_2: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v209: LrcPtr<File_system::Mut3> = patternInput_2.3.clone();
            let v207: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v206: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v228: () = {
                File_system::closure7(v206.clone(), ());
                ()
            };
            let v251: string = if (v209.l0.get().clone()) == string("") {
                v167.clone()
            } else {
                if (v167.clone()) == string("") {
                    v209.l0.get().clone()
                } else {
                    append(
                        (append((v209.l0.get().clone()), string("\n"))),
                        (v167.clone()),
                    )
                }
            };
            let v262: &str = &*v251.clone();
            let v289 = v262.chars();
            let v291 = v289;
            let v293: Vec<char> = v291.collect::<Vec<_>>();
            let v295: Vec<Vec<char>> = v293
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v297: bool = true;
            let _vec_map: Vec<_> = v295
                .into_iter()
                .map(|x| {
                    //;
                    let v299: Vec<char> = x;
                    let v301: std::string::String = String::from_iter(v299);
                    let v303: bool = true;
                    v301
                })
                .collect::<Vec<_>>();
            let v305: Vec<std::string::String> = _vec_map;
            if if (v167.clone()) != string("") {
                (v305.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v209.l0.set(v251);
                ()
            } else {
                v209.l0.set(string(""));
                {
                    let v330: bool = true;
                    v305.into_iter().for_each(|x| {
                        //;
                        let v332: std::string::String = x;
                        let v334: bool = true;
                        near_sdk::log!("{}", v332);
                        let v336: bool = true;
                        let v338: bool = true;
                    }); //;
                    ()
                }
            }
            (v207.l0.get().clone())(v167);
            File_system::US6::US6_0(
                v206,
                v207,
                patternInput_2.2.clone(),
                v209,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method57(v0: string, v1: string, v2: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method56(v0: string, v1: string, v2: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method55(v0: string, v1: string) -> Arc<Async<i64>> {
        File_system::method56(v0, v1, 0_i64)
    }
    pub fn closure29(v0: string, v1: string) -> Arc<Async<i64>> {
        File_system::method55(v0, v1)
    }
    pub fn closure28(unitVar: (), v0: string) -> Func1<string, Arc<Async<i64>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure29(v0.clone(), v)
        })
    }
    pub fn closure33(unitVar: (), v0: i64) -> File_system::US11 {
        File_system::US11::US11_0(v0)
    }
    pub fn method66() -> Func1<i64, File_system::US11> {
        Func1::new(move |v: i64| File_system::closure33((), v))
    }
    pub fn closure34(unitVar: (), v0: LrcPtr<Exception>) -> File_system::US11 {
        File_system::US11::US11_1(v0)
    }
    pub fn method67() -> Func1<LrcPtr<Exception>, File_system::US11> {
        Func1::new(move |v: LrcPtr<Exception>| File_system::closure34((), v))
    }
    pub fn closure32(
        unitVar: (),
        v0: LrcPtr<Choice_2<i64, LrcPtr<Exception>>>,
    ) -> File_system::US11 {
        unbox::<File_system::US11>(fable_library_rust::Native_::getZero())
    }
    pub fn method69(
        v0: Func1<LrcPtr<Choice_2<i64, LrcPtr<Exception>>>, File_system::US11>,
        v1: Arc<Async<LrcPtr<Choice_2<i64, LrcPtr<Exception>>>>>,
    ) -> Arc<Async<File_system::US11>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method68(
        v0: Func1<LrcPtr<Choice_2<i64, LrcPtr<Exception>>>, File_system::US11>,
        v1: Arc<Async<LrcPtr<Choice_2<i64, LrcPtr<Exception>>>>>,
    ) -> Arc<Async<File_system::US11>> {
        File_system::method69(v0, v1)
    }
    pub fn closure35(unitVar: (), v0: File_system::US11) -> File_system::US12 {
        match &v0 {
            File_system::US11::US11_1(v0_1_0) => File_system::US12::US12_1(v0_1_0.clone()),
            File_system::US11::US11_0(v0_0_0) => File_system::US12::US12_0(v0_0_0.clone()),
        }
    }
    pub fn method71(
        v0: Func1<File_system::US11, File_system::US12>,
        v1: Arc<Async<File_system::US11>>,
    ) -> Arc<Async<File_system::US12>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method70(
        v0: Func1<File_system::US11, File_system::US12>,
        v1: Arc<Async<File_system::US11>>,
    ) -> Arc<Async<File_system::US12>> {
        File_system::method71(v0, v1)
    }
    pub fn method73(v0: i32) -> string {
        let v2: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v16_1: () = {
            File_system::closure6(v2.clone(), string("{ "), ());
            ()
        };
        let v35_1: () = {
            File_system::closure6(v2.clone(), string("timeout"), ());
            ()
        };
        let v54: () = {
            File_system::closure6(v2.clone(), string(" = "), ());
            ()
        };
        let v74: () = {
            File_system::closure6(v2.clone(), sprintf!("{}", v0), ());
            ()
        };
        let v93: () = {
            File_system::closure6(v2.clone(), string(" }"), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method72(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i32,
    ) -> string {
        let v9: string = File_system::method73(v8);
        File_system::method21(append(
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
            (v9),
        ))
    }
    pub fn closure37(v0: i32, unitVar: ()) {
        fn v16_1() {
            File_system::closure0((), ());
        }
        let v17: () = {
            v16_1();
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v58: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        let v298: File_system::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            0_i32
                >= (find(
                    v58,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                        LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                        LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                        LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                        LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            File_system::US6::US6_1
        } else {
            let v81: () = {
                v16_1();
                ()
            };
            let patternInput_1: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v109: Option<i64> = patternInput_1.5.clone();
            let v108: LrcPtr<File_system::Mut4> = patternInput_1.4.clone();
            let v107: LrcPtr<File_system::Mut3> = patternInput_1.3.clone();
            let v106: LrcPtr<File_system::Mut2> = patternInput_1.2.clone();
            let v105: LrcPtr<File_system::Mut1> = patternInput_1.1.clone();
            let v104: LrcPtr<File_system::Mut0> = patternInput_1.0.clone();
            let v124: string = File_system::method72(
                v104.clone(),
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                File_system::method11(v104, v105, v106, v107, v108, v109),
                File_system::method31(),
                v0,
            );
            let v140: () = {
                v16_1();
                ()
            };
            let patternInput_2: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v166: LrcPtr<File_system::Mut3> = patternInput_2.3.clone();
            let v164: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v163: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v185: () = {
                File_system::closure7(v163.clone(), ());
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
            File_system::US6::US6_0(
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
    pub fn method75(v0: i32, v1: string) -> string {
        let v3: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v17: () = {
            File_system::closure6(v3.clone(), string("{ "), ());
            ()
        };
        let v36_1: () = {
            File_system::closure6(v3.clone(), string("timeout"), ());
            ()
        };
        let v55: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v75: () = {
            File_system::closure6(v3.clone(), sprintf!("{}", v0), ());
            ()
        };
        let v94: () = {
            File_system::closure6(v3.clone(), string("; "), ());
            ()
        };
        let v113: () = {
            File_system::closure6(v3.clone(), string("ex"), ());
            ()
        };
        let v130: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v147: () = {
            File_system::closure6(v3.clone(), v1, ());
            ()
        };
        let v166: () = {
            File_system::closure6(v3.clone(), string(" }"), ());
            ()
        };
        v3.l0.get().clone()
    }
    pub fn method74(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i32,
        v9: string,
    ) -> string {
        let v10: string = File_system::method75(v8, v9);
        File_system::method21(append(
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
            (v10),
        ))
    }
    pub fn closure38(v0: i32, v1: LrcPtr<Exception>, unitVar: ()) {
        fn v17() {
            File_system::closure0((), ());
        }
        let v18: () = {
            v17();
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v59: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        let v338: File_system::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            4_i32
                >= (find(
                    v59,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                        LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                        LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                        LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                        LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            File_system::US6::US6_1
        } else {
            let v82: () = {
                v17();
                ()
            };
            let patternInput_1: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v110: Option<i64> = patternInput_1.5.clone();
            let v109: LrcPtr<File_system::Mut4> = patternInput_1.4.clone();
            let v108: LrcPtr<File_system::Mut3> = patternInput_1.3.clone();
            let v107: LrcPtr<File_system::Mut2> = patternInput_1.2.clone();
            let v106: LrcPtr<File_system::Mut1> = patternInput_1.1.clone();
            let v105: LrcPtr<File_system::Mut0> = patternInput_1.0.clone();
            let v164: string = File_system::method74(
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                File_system::method11(v105, v106, v107, v108, v109, v110),
                File_system::method49(),
                v0,
                sprintf!("{:?}", v1),
            );
            let v180: () = {
                v17();
                ()
            };
            let patternInput_2: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v206: LrcPtr<File_system::Mut3> = patternInput_2.3.clone();
            let v204: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v203: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v225: () = {
                File_system::closure7(v203.clone(), ());
                ()
            };
            let v248: string = if (v206.l0.get().clone()) == string("") {
                v164.clone()
            } else {
                if (v164.clone()) == string("") {
                    v206.l0.get().clone()
                } else {
                    append(
                        (append((v206.l0.get().clone()), string("\n"))),
                        (v164.clone()),
                    )
                }
            };
            let v259: &str = &*v248.clone();
            let v286 = v259.chars();
            let v288 = v286;
            let v290: Vec<char> = v288.collect::<Vec<_>>();
            let v292: Vec<Vec<char>> = v290
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v294: bool = true;
            let _vec_map: Vec<_> = v292
                .into_iter()
                .map(|x| {
                    //;
                    let v296: Vec<char> = x;
                    let v298: std::string::String = String::from_iter(v296);
                    let v300: bool = true;
                    v298
                })
                .collect::<Vec<_>>();
            let v302: Vec<std::string::String> = _vec_map;
            if if (v164.clone()) != string("") {
                (v302.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v206.l0.set(v248);
                ()
            } else {
                v206.l0.set(string(""));
                {
                    let v327: bool = true;
                    v302.into_iter().for_each(|x| {
                        //;
                        let v329: std::string::String = x;
                        let v331: bool = true;
                        near_sdk::log!("{}", v329);
                        let v333: bool = true;
                        let v335: bool = true;
                    }); //;
                    ()
                }
            }
            (v204.l0.get().clone())(v164);
            File_system::US6::US6_0(
                v203,
                v204,
                patternInput_2.2.clone(),
                v206,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn closure36(v0: i32, v1: File_system::US12) -> File_system::US2 {
        match &v1 {
            File_system::US12::US12_0(v1_0_0) => File_system::US2::US2_0(v1_0_0.clone()),
            File_system::US12::US12_1(v1_1_0) => {
                let v4 = v1_1_0.clone();
                if contains(
                    sprintf!("{:?}", v4.clone()),
                    string("System.TimeoutException"),
                ) {
                    let v328: () = {
                        File_system::closure37(v0, ());
                        ()
                    };
                    File_system::US2::US2_1
                } else {
                    let v996: () = {
                        File_system::closure38(v0, v4, ());
                        ()
                    };
                    File_system::US2::US2_1
                }
            }
        }
    }
    pub fn method77(
        v0: Func1<File_system::US12, File_system::US2>,
        v1: Arc<Async<File_system::US12>>,
    ) -> Arc<Async<File_system::US2>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method76(
        v0: Func1<File_system::US12, File_system::US2>,
        v1: Arc<Async<File_system::US12>>,
    ) -> Arc<Async<File_system::US2>> {
        File_system::method77(v0, v1)
    }
    pub fn method65(v0: Arc<Async<i64>>, v1: i32) -> Arc<Async<File_system::US2>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method64(v0: i32, v1: Arc<Async<i64>>) -> Arc<Async<File_system::US2>> {
        File_system::method65(v1, v0)
    }
    pub fn closure39(unitVar: (), v0: string) -> Option<string> {
        Some(v0)
    }
    pub fn method79(
        v0: Func1<string, Option<string>>,
        v1: Arc<Async<string>>,
    ) -> Arc<Async<Option<string>>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method78(
        v0: Func1<string, Option<string>>,
        v1: Arc<Async<string>>,
    ) -> Arc<Async<Option<string>>> {
        File_system::method79(v0, v1)
    }
    pub fn method81(v0: i64, v1: string) -> string {
        let v3: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v17: () = {
            File_system::closure6(v3.clone(), string("{ "), ());
            ()
        };
        let v36_1: () = {
            File_system::closure6(v3.clone(), string("retry"), ());
            ()
        };
        let v55: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v75: () = {
            File_system::closure6(v3.clone(), sprintf!("{}", v0), ());
            ()
        };
        let v94: () = {
            File_system::closure6(v3.clone(), string("; "), ());
            ()
        };
        let v113: () = {
            File_system::closure6(v3.clone(), string("ex"), ());
            ()
        };
        let v130: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v147: () = {
            File_system::closure6(v3.clone(), v1, ());
            ()
        };
        let v166: () = {
            File_system::closure6(v3.clone(), string(" }"), ());
            ()
        };
        v3.l0.get().clone()
    }
    pub fn method80(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: i64,
        v9: string,
    ) -> string {
        let v10: string = File_system::method81(v8, v9);
        File_system::method21(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("file_system.read_all_text_retry_async"),
                )),
                string(" / "),
            )),
            (v10),
        ))
    }
    pub fn closure40(v0: i64, v1: LrcPtr<Exception>, unitVar: ()) {
        fn v17() {
            File_system::closure0((), ());
        }
        let v18: () = {
            v17();
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v59: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        let v338: File_system::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            1_i32
                >= (find(
                    v59,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                        LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                        LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                        LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                        LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            File_system::US6::US6_1
        } else {
            let v82: () = {
                v17();
                ()
            };
            let patternInput_1: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v110: Option<i64> = patternInput_1.5.clone();
            let v109: LrcPtr<File_system::Mut4> = patternInput_1.4.clone();
            let v108: LrcPtr<File_system::Mut3> = patternInput_1.3.clone();
            let v107: LrcPtr<File_system::Mut2> = patternInput_1.2.clone();
            let v106: LrcPtr<File_system::Mut1> = patternInput_1.1.clone();
            let v105: LrcPtr<File_system::Mut0> = patternInput_1.0.clone();
            let v164: string = File_system::method80(
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                File_system::method11(v105, v106, v107, v108, v109, v110),
                File_system::method15(),
                v0,
                sprintf!("{:?}", v1),
            );
            let v180: () = {
                v17();
                ()
            };
            let patternInput_2: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v206: LrcPtr<File_system::Mut3> = patternInput_2.3.clone();
            let v204: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v203: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v225: () = {
                File_system::closure7(v203.clone(), ());
                ()
            };
            let v248: string = if (v206.l0.get().clone()) == string("") {
                v164.clone()
            } else {
                if (v164.clone()) == string("") {
                    v206.l0.get().clone()
                } else {
                    append(
                        (append((v206.l0.get().clone()), string("\n"))),
                        (v164.clone()),
                    )
                }
            };
            let v259: &str = &*v248.clone();
            let v286 = v259.chars();
            let v288 = v286;
            let v290: Vec<char> = v288.collect::<Vec<_>>();
            let v292: Vec<Vec<char>> = v290
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v294: bool = true;
            let _vec_map: Vec<_> = v292
                .into_iter()
                .map(|x| {
                    //;
                    let v296: Vec<char> = x;
                    let v298: std::string::String = String::from_iter(v296);
                    let v300: bool = true;
                    v298
                })
                .collect::<Vec<_>>();
            let v302: Vec<std::string::String> = _vec_map;
            if if (v164.clone()) != string("") {
                (v302.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v206.l0.set(v248);
                ()
            } else {
                v206.l0.set(string(""));
                {
                    let v327: bool = true;
                    v302.into_iter().for_each(|x| {
                        //;
                        let v329: std::string::String = x;
                        let v331: bool = true;
                        near_sdk::log!("{}", v329);
                        let v333: bool = true;
                        let v335: bool = true;
                    }); //;
                    ()
                }
            }
            (v204.l0.get().clone())(v164);
            File_system::US6::US6_0(
                v203,
                v204,
                patternInput_2.2.clone(),
                v206,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method63(v0: string, v1: i64) -> Arc<Async<Option<string>>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method62(v0: string, v1: i64) -> Arc<Async<Option<string>>> {
        File_system::method63(v0, v1)
    }
    pub fn method61(v0: string) -> Arc<Async<Option<string>>> {
        File_system::method62(v0, 0_i64)
    }
    pub fn closure31(unitVar: (), v0: string) -> Arc<Async<Option<string>>> {
        File_system::method61(v0)
    }
    pub fn closure42(unitVar: (), v0: Option<()>) -> File_system::US13 {
        File_system::US13::US13_0(v0)
    }
    pub fn method84() -> Func1<Option<()>, File_system::US13> {
        Func1::new(move |v: Option<()>| File_system::closure42((), v))
    }
    pub fn method85() -> string {
        string("hh:mm")
    }
    pub fn method86() -> string {
        string("yyyyMMdd-HHmm-ssff-ffff-f")
    }
    pub fn method87() -> string {
        string("hhmm")
    }
    pub fn method83(v0: Guid, v1: DateTime) -> Guid {
        unbox::<Guid>(fable_library_rust::Native_::getZero())
    }
    pub fn method89() -> string {
        unbox::<string>(fable_library_rust::Native_::getZero())
    }
    pub fn method90() -> string {
        string("!create_temp_path_")
    }
    pub fn method91(v0: string, v1: string) -> string {
        unbox::<string>(fable_library_rust::Native_::getZero())
    }
    pub fn method93() -> string {
        string("CARGO_PKG_NAME")
    }
    pub fn method92() -> string {
        File_system::method2(File_system::method93())
    }
    pub fn method88(v0: Guid) -> string {
        unbox::<string>(fable_library_rust::Native_::getZero())
    }
    pub fn method82() -> string {
        unbox::<string>(fable_library_rust::Native_::getZero())
    }
    pub fn closure41(unitVar: (), unitVar_1: ()) -> string {
        File_system::method82()
    }
    pub fn closure44(unitVar: (), v0: std::io::Error) -> std::string::String {
        format!("{}", v0)
    }
    pub fn method95() -> Func1<std::io::Error, std::string::String> {
        Func1::new(move |v: std::io::Error| File_system::closure44((), v))
    }
    pub fn closure45(unitVar: (), unitVar_1: ()) -> File_system::US14 {
        File_system::US14::US14_0
    }
    pub fn method96() -> Func0<File_system::US14> {
        Func0::new(move || File_system::closure45((), ()))
    }
    pub fn closure46(unitVar: (), v0: std::string::String) -> File_system::US14 {
        File_system::US14::US14_1(v0)
    }
    pub fn method97() -> Func1<std::string::String, File_system::US14> {
        Func1::new(move |v: std::string::String| File_system::closure46((), v))
    }
    pub fn method99(v0: string, v1: std::string::String) -> string {
        let v3: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v17: () = {
            File_system::closure6(v3.clone(), string("{ "), ());
            ()
        };
        let v36_1: () = {
            File_system::closure6(v3.clone(), string("dir"), ());
            ()
        };
        let v55: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v72: () = {
            File_system::closure6(v3.clone(), v0, ());
            ()
        };
        let v91: () = {
            File_system::closure6(v3.clone(), string("; "), ());
            ()
        };
        let v110: () = {
            File_system::closure6(v3.clone(), string("error"), ());
            ()
        };
        let v127: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v147: std::string::String = format!("{:#?}", v1);
        let v186: () = {
            File_system::closure6(
                v3.clone(),
                fable_library_rust::String_::fromString(v147),
                (),
            );
            ()
        };
        let v205: () = {
            File_system::closure6(v3.clone(), string(" }"), ());
            ()
        };
        v3.l0.get().clone()
    }
    pub fn method98(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
        v9: std::string::String,
    ) -> string {
        let v10: string = File_system::method99(v8, v9);
        File_system::method21(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("file_system.create_dir"),
                )),
                string(" / "),
            )),
            (v10),
        ))
    }
    pub fn closure47(v0: string, v1: std::string::String, unitVar: ()) {
        fn v17() {
            File_system::closure0((), ());
        }
        let v18: () = {
            v17();
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v59: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        let v299: File_system::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            4_i32
                >= (find(
                    v59,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                        LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                        LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                        LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                        LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            File_system::US6::US6_1
        } else {
            let v82: () = {
                v17();
                ()
            };
            let patternInput_1: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v110: Option<i64> = patternInput_1.5.clone();
            let v109: LrcPtr<File_system::Mut4> = patternInput_1.4.clone();
            let v108: LrcPtr<File_system::Mut3> = patternInput_1.3.clone();
            let v107: LrcPtr<File_system::Mut2> = patternInput_1.2.clone();
            let v106: LrcPtr<File_system::Mut1> = patternInput_1.1.clone();
            let v105: LrcPtr<File_system::Mut0> = patternInput_1.0.clone();
            let v125: string = File_system::method98(
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                File_system::method11(v105, v106, v107, v108, v109, v110),
                File_system::method49(),
                v0,
                v1,
            );
            let v141: () = {
                v17();
                ()
            };
            let patternInput_2: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v167: LrcPtr<File_system::Mut3> = patternInput_2.3.clone();
            let v165: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v164: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v186: () = {
                File_system::closure7(v164.clone(), ());
                ()
            };
            let v209: string = if (v167.l0.get().clone()) == string("") {
                v125.clone()
            } else {
                if (v125.clone()) == string("") {
                    v167.l0.get().clone()
                } else {
                    append(
                        (append((v167.l0.get().clone()), string("\n"))),
                        (v125.clone()),
                    )
                }
            };
            let v220: &str = &*v209.clone();
            let v247 = v220.chars();
            let v249 = v247;
            let v251: Vec<char> = v249.collect::<Vec<_>>();
            let v253: Vec<Vec<char>> = v251
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v255: bool = true;
            let _vec_map: Vec<_> = v253
                .into_iter()
                .map(|x| {
                    //;
                    let v257: Vec<char> = x;
                    let v259: std::string::String = String::from_iter(v257);
                    let v261: bool = true;
                    v259
                })
                .collect::<Vec<_>>();
            let v263: Vec<std::string::String> = _vec_map;
            if if (v125.clone()) != string("") {
                (v263.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v167.l0.set(v209);
                ()
            } else {
                v167.l0.set(string(""));
                {
                    let v288: bool = true;
                    v263.into_iter().for_each(|x| {
                        //;
                        let v290: std::string::String = x;
                        let v292: bool = true;
                        near_sdk::log!("{}", v290);
                        let v294: bool = true;
                        let v296: bool = true;
                    }); //;
                    ()
                }
            }
            (v165.l0.get().clone())(v125);
            File_system::US6::US6_0(
                v164,
                v165,
                patternInput_2.2.clone(),
                v167,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method101(v0: string) -> string {
        let v2: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v16_1: () = {
            File_system::closure6(v2.clone(), string("{ "), ());
            ()
        };
        let v35_1: () = {
            File_system::closure6(v2.clone(), string("dir"), ());
            ()
        };
        let v54: () = {
            File_system::closure6(v2.clone(), string(" = "), ());
            ()
        };
        let v71: () = {
            File_system::closure6(v2.clone(), v0, ());
            ()
        };
        let v90: () = {
            File_system::closure6(v2.clone(), string(" }"), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method100(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
    ) -> string {
        let v9: string = File_system::method101(v8);
        File_system::method21(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("file_system.create_dir"),
                )),
                string(" / "),
            )),
            (v9),
        ))
    }
    pub fn closure48(v0: string, unitVar: ()) {
        fn v16_1() {
            File_system::closure0((), ());
        }
        let v17: () = {
            v16_1();
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v58: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        let v298: File_system::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            0_i32
                >= (find(
                    v58,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                        LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                        LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                        LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                        LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            File_system::US6::US6_1
        } else {
            let v81: () = {
                v16_1();
                ()
            };
            let patternInput_1: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v109: Option<i64> = patternInput_1.5.clone();
            let v108: LrcPtr<File_system::Mut4> = patternInput_1.4.clone();
            let v107: LrcPtr<File_system::Mut3> = patternInput_1.3.clone();
            let v106: LrcPtr<File_system::Mut2> = patternInput_1.2.clone();
            let v105: LrcPtr<File_system::Mut1> = patternInput_1.1.clone();
            let v104: LrcPtr<File_system::Mut0> = patternInput_1.0.clone();
            let v124: string = File_system::method100(
                v104.clone(),
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                File_system::method11(v104, v105, v106, v107, v108, v109),
                File_system::method31(),
                v0,
            );
            let v140: () = {
                v16_1();
                ()
            };
            let patternInput_2: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v166: LrcPtr<File_system::Mut3> = patternInput_2.3.clone();
            let v164: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v163: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v185: () = {
                File_system::closure7(v163.clone(), ());
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
            File_system::US6::US6_0(
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
    pub fn closure49(v0: string, unitVar: ()) {
        File_system::method9(true, v0);
    }
    pub fn method102(v0: string) -> Func0<()> {
        Func0::new({
            let v0 = v0.clone();
            move || File_system::closure49(v0.clone(), ())
        })
    }
    pub fn method103(v0: string) -> Func0<()> {
        Func0::new({
            let v0 = v0.clone();
            move || File_system::closure49(v0.clone(), ())
        })
    }
    pub fn method104(v0: string) -> bool {
        unbox::<bool>(fable_library_rust::Native_::getZero())
    }
    pub fn method106(v0: string, v1: string) -> string {
        let v3: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v17: () = {
            File_system::closure6(v3.clone(), string("{ "), ());
            ()
        };
        let v36_1: () = {
            File_system::closure6(v3.clone(), string("dir"), ());
            ()
        };
        let v55: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v72: () = {
            File_system::closure6(v3.clone(), v0, ());
            ()
        };
        let v91: () = {
            File_system::closure6(v3.clone(), string("; "), ());
            ()
        };
        let v110: () = {
            File_system::closure6(v3.clone(), string("result"), ());
            ()
        };
        let v127: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v144: () = {
            File_system::closure6(v3.clone(), v1, ());
            ()
        };
        let v163: () = {
            File_system::closure6(v3.clone(), string(" }"), ());
            ()
        };
        v3.l0.get().clone()
    }
    pub fn method105(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
        v9: string,
    ) -> string {
        let v10: string = File_system::method106(v8, v9);
        File_system::method21(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("file_system.create_dir"),
                )),
                string(" / "),
            )),
            (v10),
        ))
    }
    pub fn closure50(v0: string, v1: string, unitVar: ()) {
        fn v17() {
            File_system::closure0((), ());
        }
        let v18: () = {
            v17();
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v59: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        let v299: File_system::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            1_i32
                >= (find(
                    v59,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                        LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                        LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                        LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                        LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            File_system::US6::US6_1
        } else {
            let v82: () = {
                v17();
                ()
            };
            let patternInput_1: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v110: Option<i64> = patternInput_1.5.clone();
            let v109: LrcPtr<File_system::Mut4> = patternInput_1.4.clone();
            let v108: LrcPtr<File_system::Mut3> = patternInput_1.3.clone();
            let v107: LrcPtr<File_system::Mut2> = patternInput_1.2.clone();
            let v106: LrcPtr<File_system::Mut1> = patternInput_1.1.clone();
            let v105: LrcPtr<File_system::Mut0> = patternInput_1.0.clone();
            let v125: string = File_system::method105(
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                File_system::method11(v105, v106, v107, v108, v109, v110),
                File_system::method15(),
                v0,
                v1,
            );
            let v141: () = {
                v17();
                ()
            };
            let patternInput_2: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v167: LrcPtr<File_system::Mut3> = patternInput_2.3.clone();
            let v165: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v164: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v186: () = {
                File_system::closure7(v164.clone(), ());
                ()
            };
            let v209: string = if (v167.l0.get().clone()) == string("") {
                v125.clone()
            } else {
                if (v125.clone()) == string("") {
                    v167.l0.get().clone()
                } else {
                    append(
                        (append((v167.l0.get().clone()), string("\n"))),
                        (v125.clone()),
                    )
                }
            };
            let v220: &str = &*v209.clone();
            let v247 = v220.chars();
            let v249 = v247;
            let v251: Vec<char> = v249.collect::<Vec<_>>();
            let v253: Vec<Vec<char>> = v251
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v255: bool = true;
            let _vec_map: Vec<_> = v253
                .into_iter()
                .map(|x| {
                    //;
                    let v257: Vec<char> = x;
                    let v259: std::string::String = String::from_iter(v257);
                    let v261: bool = true;
                    v259
                })
                .collect::<Vec<_>>();
            let v263: Vec<std::string::String> = _vec_map;
            if if (v125.clone()) != string("") {
                (v263.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v167.l0.set(v209);
                ()
            } else {
                v167.l0.set(string(""));
                {
                    let v288: bool = true;
                    v263.into_iter().for_each(|x| {
                        //;
                        let v290: std::string::String = x;
                        let v292: bool = true;
                        near_sdk::log!("{}", v290);
                        let v294: bool = true;
                        let v296: bool = true;
                    }); //;
                    ()
                }
            }
            (v165.l0.get().clone())(v125);
            File_system::US6::US6_0(
                v164,
                v165,
                patternInput_2.2.clone(),
                v167,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn closure51(v0: string, unitVar: ()) {
        let v1: Arc<Async<i64>> = File_system::method6(v0);
        let v16_1: Arc<Async<()>> = fable_library_rust::Native_::getZero();
        fable_library_rust::Native_::getZero::<()>();
        ()
    }
    pub fn method107(v0: string) -> Func0<()> {
        Func0::new({
            let v0 = v0.clone();
            move || File_system::closure51(v0.clone(), ())
        })
    }
    pub fn method108(v0: string) -> Func0<()> {
        Func0::new({
            let v0 = v0.clone();
            move || File_system::closure51(v0.clone(), ())
        })
    }
    pub fn method94(v0: string) -> LrcPtr<dyn IDisposable> {
        interface_cast!(
            fable_library_rust::Native_::getZero::<std::sync::Arc<dyn IDisposable>>(),
            Lrc<dyn IDisposable>,
        )
    }
    pub fn closure43(unitVar: (), unitVar_1: ()) -> (string, LrcPtr<dyn IDisposable>) {
        let v0: string = File_system::method82();
        (v0.clone(), File_system::method94(v0))
    }
    pub fn closure53(v0: i32, v1: string, v2: i32, v3: string) -> string {
        if (v2) >= (v0) {
            v3.clone()
        } else {
            (File_system::method110(v0, v1.clone(), (v2) + 1_i32))(append((v3), (v1)))
        }
    }
    pub fn method110(v0: i32, v1: string, v2: i32) -> Func1<string, string> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            let v2 = v2.clone();
            move |v: string| File_system::closure53(v0, v1.clone(), v2, v)
        })
    }
    pub fn method109(v0: string) -> Guid {
        let v3: string = ofChar('0');
        let v13: string = append(
            ((File_system::method110(32_i32 - (length(v0.clone())), v3, 0_i32))(string(""))),
            (v0),
        );
        unbox::<Guid>(fable_library_rust::Native_::getZero())
    }
    pub fn closure52(unitVar: (), v0: string) -> (string, LrcPtr<dyn IDisposable>) {
        let v2: string = File_system::method88(File_system::method109(v0));
        (v2.clone(), File_system::method94(v2))
    }
    pub fn closure54(unitVar: (), unitVar_1: ()) -> string {
        string("c:\\home\\git\\polyglot\\deps\\spiral\\lib\\spiral")
    }
    pub fn closure56(unitVar: (), v0: std::path::PathBuf) -> File_system::US15 {
        File_system::US15::US15_0(v0)
    }
    pub fn method114() -> Func1<std::path::PathBuf, File_system::US15> {
        Func1::new(move |v: std::path::PathBuf| File_system::closure56((), v))
    }
    pub fn closure57(unitVar: (), v0: string) -> File_system::US15 {
        File_system::US15::US15_1(v0)
    }
    pub fn method115() -> Func1<string, File_system::US15> {
        Func1::new(move |v: string| File_system::closure57((), v))
    }
    pub fn method118(v0: string) -> Option<string> {
        None::<string>
    }
    pub fn method119(v0: string) -> string {
        let v2: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v14_1: () = {
            File_system::closure6(v2.clone(), v0, ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method117(
        v0: string,
        v1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
        v2: u8,
        v3: string,
        v4: string,
    ) -> Result<std::path::PathBuf, std::io::Error> {
        let v5: string = File_system::method18(v4.clone());
        let v6: Option<string> = File_system::method118(v4.clone());
        let v31_1: File_system::US5 =
            defaultValue(File_system::US5::US5_1, map(File_system::method5(), v6));
        let v35_1: string = File_system::method119(v3);
        if (v2) >= 11_u8 {
            let v39_1: string = append(
                string("file_system.read_link / "),
                sprintf!(
                    "path: {} / n: {} / path\': {} / name: {}",
                    v0.clone(),
                    v2,
                    v4.clone(),
                    v5.clone()
                ),
            );
            let v50_1: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v39_1);
            Err(v50_1)
        } else {
            if let File_system::US5::US5_0(v31_1_0_0) = &v31_1 {
                if (v4.clone()) != string("") {
                    let v100: Result<std::path::PathBuf, std::io::Error> =
                        v1((v2) + 1_u8, v31_1_0_0.clone());
                    let v101 = File_system::method45();
                    let v114: Result<std::path::PathBuf, string> = v100.map_err(|x| v101(x));
                    let v117 = File_system::method114();
                    let v118 = File_system::method115();
                    let v120: File_system::US15 = match &v114 {
                        Err(v114_1_0) => v118(v114_1_0.clone()),
                        Ok(v114_0_0) => v117(v114_0_0.clone()),
                    };
                    match &v120 {
                        File_system::US15::US15_0(v120_0_0) => {
                            let v164: string = File_system::method91(
                                toString(v120_0_0.clone().display()),
                                v5.clone(),
                            );
                            let v175: &str = &*v164;
                            let v211: std::string::String = String::from(v175);
                            let v247: std::path::PathBuf = std::path::PathBuf::from(v211);
                            Ok(v247)
                        }
                        File_system::US15::US15_1(v120_1_0) => {
                            let v291: string = append(
                                string("file_system.read_link / "),
                                sprintf!(
                                    "error\': {} / error: {} / name: {}",
                                    v120_1_0.clone(),
                                    v35_1.clone(),
                                    v5.clone()
                                ),
                            );
                            let v302: std::io::Error =
                                std::io::Error::new(std::io::ErrorKind::Other, &*v291);
                            Err(v302)
                        }
                    }
                } else {
                    let v347: string = append(
                        string(
                            "file_system.read_link / run / The file or directory is not a reparse point. / ",
                        ),
                        sprintf!(
                            "path: {} / error: {} / path\': {} / name: {}",
                            v0.clone(),
                            v35_1.clone(),
                            v4.clone(),
                            v5.clone()
                        ),
                    );
                    let v358: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v347);
                    Err(v358)
                }
            } else {
                let v402: string = append(
                    string(
                        "file_system.read_link / run / The file or directory is not a reparse point. / ",
                    ),
                    sprintf!(
                        "path: {} / error: {} / path\': {} / name: {}",
                        v0,
                        v35_1.clone(),
                        v4,
                        v5.clone()
                    ),
                );
                let v413: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v402);
                Err(v413)
            }
        }
    }
    pub fn method116(v0: string, v1: u8, v2: string) -> Result<std::path::PathBuf, std::io::Error> {
        let v99: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v2.clone());
        let v100 = File_system::method45();
        let v113: Result<std::path::PathBuf, string> = v99.map_err(|x| v100(x));
        let v116 = File_system::method114();
        let v117 = File_system::method115();
        let v119: File_system::US15 = match &v113 {
            Err(v113_1_0) => v117(v113_1_0.clone()),
            Ok(v113_0_0) => v116(v113_0_0.clone()),
        };
        match &v119 {
            File_system::US15::US15_0(v119_0_0) => Ok(v119_0_0.clone()),
            File_system::US15::US15_1(v119_1_0) => File_system::method117(
                v0.clone(),
                Func2::new({
                    let v0 = v0.clone();
                    move |b0: u8, b1: string| {
                        (Func1::new({
                            let v0 = v0.clone();
                            move |v: u8| File_system::closure58(v0.clone(), v)
                        }))(b0)(b1)
                    }
                }),
                v1,
                v119_1_0.clone(),
                v2.clone(),
            ),
        }
    }
    pub fn closure59(v0: string, v1: u8, v2: string) -> Result<std::path::PathBuf, std::io::Error> {
        File_system::method116(v0, v1, v2)
    }
    pub fn closure58(
        v0: string,
        v1: u8,
    ) -> Func1<string, Result<std::path::PathBuf, std::io::Error>> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            move |v: string| File_system::closure59(v0.clone(), v1, v)
        })
    }
    pub fn method120(
        v0: string,
        v1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
        v2: u8,
        v3: string,
    ) -> Result<std::path::PathBuf, std::io::Error> {
        let v4: string = File_system::method18(v0.clone());
        let v5: Option<string> = File_system::method118(v0.clone());
        let v30: File_system::US5 =
            defaultValue(File_system::US5::US5_1, map(File_system::method5(), v5));
        let v34_1: string = File_system::method119(v3);
        if (v2) >= 11_u8 {
            let v38_1: string = append(
                string("file_system.read_link / "),
                sprintf!(
                    "path: {} / n: {} / path\': {} / name: {}",
                    v0.clone(),
                    v2,
                    v0.clone(),
                    v4.clone()
                ),
            );
            let v49_1: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v38_1);
            Err(v49_1)
        } else {
            if let File_system::US5::US5_0(v30_0_0) = &v30 {
                if (v0.clone()) != string("") {
                    let v99: Result<std::path::PathBuf, std::io::Error> =
                        v1((v2) + 1_u8, v30_0_0.clone());
                    let v100 = File_system::method45();
                    let v113: Result<std::path::PathBuf, string> = v99.map_err(|x| v100(x));
                    let v116 = File_system::method114();
                    let v117 = File_system::method115();
                    let v119: File_system::US15 = match &v113 {
                        Err(v113_1_0) => v117(v113_1_0.clone()),
                        Ok(v113_0_0) => v116(v113_0_0.clone()),
                    };
                    match &v119 {
                        File_system::US15::US15_0(v119_0_0) => {
                            let v163: string = File_system::method91(
                                toString(v119_0_0.clone().display()),
                                v4.clone(),
                            );
                            let v174: &str = &*v163;
                            let v210: std::string::String = String::from(v174);
                            let v246: std::path::PathBuf = std::path::PathBuf::from(v210);
                            Ok(v246)
                        }
                        File_system::US15::US15_1(v119_1_0) => {
                            let v290: string = append(
                                string("file_system.read_link / "),
                                sprintf!(
                                    "error\': {} / error: {} / name: {}",
                                    v119_1_0.clone(),
                                    v34_1.clone(),
                                    v4.clone()
                                ),
                            );
                            let v301: std::io::Error =
                                std::io::Error::new(std::io::ErrorKind::Other, &*v290);
                            Err(v301)
                        }
                    }
                } else {
                    let v346: string = append(
                        string(
                            "file_system.read_link / run / The file or directory is not a reparse point. / ",
                        ),
                        sprintf!(
                            "path: {} / error: {} / path\': {} / name: {}",
                            v0.clone(),
                            v34_1.clone(),
                            v0.clone(),
                            v4.clone()
                        ),
                    );
                    let v357: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v346);
                    Err(v357)
                }
            } else {
                let v401: string = append(
                    string(
                        "file_system.read_link / run / The file or directory is not a reparse point. / ",
                    ),
                    sprintf!(
                        "path: {} / error: {} / path\': {} / name: {}",
                        v0.clone(),
                        v34_1.clone(),
                        v0,
                        v4.clone()
                    ),
                );
                let v412: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v401);
                Err(v412)
            }
        }
    }
    pub fn method113(v0: string, v1: u8) -> Result<std::path::PathBuf, std::io::Error> {
        let v98: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v0.clone());
        let v99 = File_system::method45();
        let v112: Result<std::path::PathBuf, string> = v98.map_err(|x| v99(x));
        let v115 = File_system::method114();
        let v116 = File_system::method115();
        let v118: File_system::US15 = match &v112 {
            Err(v112_1_0) => v116(v112_1_0.clone()),
            Ok(v112_0_0) => v115(v112_0_0.clone()),
        };
        match &v118 {
            File_system::US15::US15_0(v118_0_0) => Ok(v118_0_0.clone()),
            File_system::US15::US15_1(v118_1_0) => File_system::method120(
                v0.clone(),
                Func2::new({
                    let v0 = v0.clone();
                    move |b0: u8, b1: string| {
                        (Func1::new({
                            let v0 = v0.clone();
                            move |v: u8| File_system::closure58(v0.clone(), v)
                        }))(b0)(b1)
                    }
                }),
                v1,
                v118_1_0.clone(),
            ),
        }
    }
    pub fn method122(v0: bool) -> i32 {
        unbox::<i32>(fable_library_rust::Native_::getZero())
    }
    pub fn method123() -> i32 {
        unbox::<i32>(fable_library_rust::Native_::getZero())
    }
    pub fn method124(v0: i32, v1: i32) -> bool {
        unbox::<bool>(fable_library_rust::Native_::getZero())
    }
    pub fn method126(
        v0: string,
        v1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
        v2: u8,
        v3: std::io::Error,
        v4: string,
    ) -> Result<std::path::PathBuf, std::io::Error> {
        let v5: string = File_system::method18(v4.clone());
        let v6: Option<string> = File_system::method118(v4.clone());
        let v31_1: File_system::US5 =
            defaultValue(File_system::US5::US5_1, map(File_system::method5(), v6));
        let v35_1: string = File_system::method46(v3);
        if (v2) >= 11_u8 {
            let v39_1: string = append(
                string("file_system.read_link / "),
                sprintf!(
                    "path: {} / n: {} / path\': {} / name: {}",
                    v0.clone(),
                    v2,
                    v4.clone(),
                    v5.clone()
                ),
            );
            let v50_1: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v39_1);
            Err(v50_1)
        } else {
            if let File_system::US5::US5_0(v31_1_0_0) = &v31_1 {
                if (v4.clone()) != string("") {
                    let v100: Result<std::path::PathBuf, std::io::Error> =
                        v1((v2) + 1_u8, v31_1_0_0.clone());
                    let v101 = File_system::method45();
                    let v114: Result<std::path::PathBuf, string> = v100.map_err(|x| v101(x));
                    let v117 = File_system::method114();
                    let v118 = File_system::method115();
                    let v120: File_system::US15 = match &v114 {
                        Err(v114_1_0) => v118(v114_1_0.clone()),
                        Ok(v114_0_0) => v117(v114_0_0.clone()),
                    };
                    match &v120 {
                        File_system::US15::US15_0(v120_0_0) => {
                            let v164: string = File_system::method91(
                                toString(v120_0_0.clone().display()),
                                v5.clone(),
                            );
                            let v175: &str = &*v164;
                            let v211: std::string::String = String::from(v175);
                            let v247: std::path::PathBuf = std::path::PathBuf::from(v211);
                            Ok(v247)
                        }
                        File_system::US15::US15_1(v120_1_0) => {
                            let v291: string = append(
                                string("file_system.read_link / "),
                                sprintf!(
                                    "error\': {} / error: {} / name: {}",
                                    v120_1_0.clone(),
                                    v35_1.clone(),
                                    v5.clone()
                                ),
                            );
                            let v302: std::io::Error =
                                std::io::Error::new(std::io::ErrorKind::Other, &*v291);
                            Err(v302)
                        }
                    }
                } else {
                    let v347: string = append(
                        string(
                            "file_system.read_link / run / The file or directory is not a reparse point. / ",
                        ),
                        sprintf!(
                            "path: {} / error: {} / path\': {} / name: {}",
                            v0.clone(),
                            v35_1.clone(),
                            v4.clone(),
                            v5.clone()
                        ),
                    );
                    let v358: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v347);
                    Err(v358)
                }
            } else {
                let v402: string = append(
                    string(
                        "file_system.read_link / run / The file or directory is not a reparse point. / ",
                    ),
                    sprintf!(
                        "path: {} / error: {} / path\': {} / name: {}",
                        v0,
                        v35_1.clone(),
                        v4,
                        v5.clone()
                    ),
                );
                let v413: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v402);
                Err(v413)
            }
        }
    }
    pub fn method125(v0: string, v1: u8, v2: string) -> Result<std::path::PathBuf, std::io::Error> {
        let v45_1: i32 =
            File_system::method122(unbox::<bool>(fable_library_rust::Native_::getZero()));
        let v47_1: bool = File_system::method124(File_system::method123(), v45_1);
        if v47_1 {
            let v62: bool = unbox::<bool>(fable_library_rust::Native_::getZero());
            let v131: std::path::PathBuf = fable_library_rust::Native_::getZero();
            Ok(v131)
        } else {
            let v153: string = append(
                string(
                    "file_system.read_link / Fsharp / The file or directory is not a reparse point. / ",
                ),
                sprintf!(
                    "path: {} / result: {} / path\': {} / n: {}",
                    v0.clone(),
                    v47_1,
                    v2.clone(),
                    v1
                ),
            );
            File_system::method126(
                v0.clone(),
                Func2::new({
                    let v0 = v0.clone();
                    move |b0: u8, b1: string| {
                        (Func1::new({
                            let v0 = v0.clone();
                            move |v: u8| File_system::closure60(v0.clone(), v)
                        }))(b0)(b1)
                    }
                }),
                v1,
                std::io::Error::new(std::io::ErrorKind::Other, &*v153),
                v2,
            )
        }
    }
    pub fn closure61(v0: string, v1: u8, v2: string) -> Result<std::path::PathBuf, std::io::Error> {
        File_system::method125(v0, v1, v2)
    }
    pub fn closure60(
        v0: string,
        v1: u8,
    ) -> Func1<string, Result<std::path::PathBuf, std::io::Error>> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            move |v: string| File_system::closure61(v0.clone(), v1, v)
        })
    }
    pub fn method127(
        v0: string,
        v1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
        v2: u8,
        v3: std::io::Error,
    ) -> Result<std::path::PathBuf, std::io::Error> {
        let v4: string = File_system::method18(v0.clone());
        let v5: Option<string> = File_system::method118(v0.clone());
        let v30: File_system::US5 =
            defaultValue(File_system::US5::US5_1, map(File_system::method5(), v5));
        let v34_1: string = File_system::method46(v3);
        if (v2) >= 11_u8 {
            let v38_1: string = append(
                string("file_system.read_link / "),
                sprintf!(
                    "path: {} / n: {} / path\': {} / name: {}",
                    v0.clone(),
                    v2,
                    v0.clone(),
                    v4.clone()
                ),
            );
            let v49_1: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v38_1);
            Err(v49_1)
        } else {
            if let File_system::US5::US5_0(v30_0_0) = &v30 {
                if (v0.clone()) != string("") {
                    let v99: Result<std::path::PathBuf, std::io::Error> =
                        v1((v2) + 1_u8, v30_0_0.clone());
                    let v100 = File_system::method45();
                    let v113: Result<std::path::PathBuf, string> = v99.map_err(|x| v100(x));
                    let v116 = File_system::method114();
                    let v117 = File_system::method115();
                    let v119: File_system::US15 = match &v113 {
                        Err(v113_1_0) => v117(v113_1_0.clone()),
                        Ok(v113_0_0) => v116(v113_0_0.clone()),
                    };
                    match &v119 {
                        File_system::US15::US15_0(v119_0_0) => {
                            let v163: string = File_system::method91(
                                toString(v119_0_0.clone().display()),
                                v4.clone(),
                            );
                            let v174: &str = &*v163;
                            let v210: std::string::String = String::from(v174);
                            let v246: std::path::PathBuf = std::path::PathBuf::from(v210);
                            Ok(v246)
                        }
                        File_system::US15::US15_1(v119_1_0) => {
                            let v290: string = append(
                                string("file_system.read_link / "),
                                sprintf!(
                                    "error\': {} / error: {} / name: {}",
                                    v119_1_0.clone(),
                                    v34_1.clone(),
                                    v4.clone()
                                ),
                            );
                            let v301: std::io::Error =
                                std::io::Error::new(std::io::ErrorKind::Other, &*v290);
                            Err(v301)
                        }
                    }
                } else {
                    let v346: string = append(
                        string(
                            "file_system.read_link / run / The file or directory is not a reparse point. / ",
                        ),
                        sprintf!(
                            "path: {} / error: {} / path\': {} / name: {}",
                            v0.clone(),
                            v34_1.clone(),
                            v0.clone(),
                            v4.clone()
                        ),
                    );
                    let v357: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v346);
                    Err(v357)
                }
            } else {
                let v401: string = append(
                    string(
                        "file_system.read_link / run / The file or directory is not a reparse point. / ",
                    ),
                    sprintf!(
                        "path: {} / error: {} / path\': {} / name: {}",
                        v0.clone(),
                        v34_1.clone(),
                        v0,
                        v4.clone()
                    ),
                );
                let v412: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v401);
                Err(v412)
            }
        }
    }
    pub fn method121(v0: string, v1: u8) -> Result<std::path::PathBuf, std::io::Error> {
        let v44_1: i32 =
            File_system::method122(unbox::<bool>(fable_library_rust::Native_::getZero()));
        let v46_1: bool = File_system::method124(File_system::method123(), v44_1);
        if v46_1 {
            let v61: bool = unbox::<bool>(fable_library_rust::Native_::getZero());
            let v130: std::path::PathBuf = fable_library_rust::Native_::getZero();
            Ok(v130)
        } else {
            let v152: string = append(
                string(
                    "file_system.read_link / Fsharp / The file or directory is not a reparse point. / ",
                ),
                sprintf!(
                    "path: {} / result: {} / path\': {} / n: {}",
                    v0.clone(),
                    v46_1,
                    v0.clone(),
                    v1
                ),
            );
            File_system::method127(
                v0.clone(),
                Func2::new({
                    let v0 = v0.clone();
                    move |b0: u8, b1: string| {
                        (Func1::new({
                            let v0 = v0.clone();
                            move |v: u8| File_system::closure60(v0.clone(), v)
                        }))(b0)(b1)
                    }
                }),
                v1,
                std::io::Error::new(std::io::ErrorKind::Other, &*v152),
            )
        }
    }
    pub fn method112(v0: string) -> Result<std::path::PathBuf, std::io::Error> {
        if File_system::method10(v0.clone()) {
            std::fs::read_link(&*v0.clone())
        } else {
            File_system::method113(v0, 0_u8)
        }
    }
    pub fn closure62(unitVar: (), v0: std::path::PathBuf) -> File_system::US16 {
        File_system::US16::US16_0(v0)
    }
    pub fn method128() -> Func1<std::path::PathBuf, File_system::US16> {
        Func1::new(move |v: std::path::PathBuf| File_system::closure62((), v))
    }
    pub fn method130(v0: string) -> string {
        v0
    }
    pub fn method131() -> string {
        string("")
    }
    pub fn method129(v0: string, v1: string, v2: string) -> string {
        File_system::method131()
    }
    pub fn method111(v0: string) -> string {
        if (v0.clone()) == string("") {
            string("")
        } else {
            let v3: Result<std::path::PathBuf, std::io::Error> = File_system::method112(v0.clone());
            let v11: Option<std::path::PathBuf> = v3.ok();
            let v43_1: File_system::US16 = defaultValue(
                File_system::US16::US16_1,
                map(File_system::method128(), v11),
            );
            let v89: string = match &v43_1 {
                File_system::US16::US16_0(v43_1_0_0) => toString(
                    match &v43_1 {
                        File_system::US16::US16_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone()
                    .display(),
                ),
                _ => v0.clone(),
            };
            let v94: string = File_system::method129(
                string("^\\\\\\\\\\?\\\\"),
                string(""),
                if (v89.clone()) == string("") {
                    v0.clone()
                } else {
                    v89
                },
            );
            if (length(v94.clone())) < 2_i32 {
                v0.clone()
            } else {
                replace(
                    concat(new_array(&[
                        toLower(ofChar(getCharAt(v94.clone(), 0_i32))),
                        getSlice(v94, Some(1_i32), None::<i32>),
                    ])),
                    string("\\"),
                    string("/"),
                )
            }
        }
    }
    pub fn closure55(unitVar: (), v0: string) -> string {
        File_system::method111(v0)
    }
    pub fn method133() -> string {
        unbox::<string>(fable_library_rust::Native_::getZero())
    }
    pub fn method134(v0: i32, v1: LrcPtr<File_system::Mut5>) -> bool {
        (v1.l0.get().clone()) < (v0)
    }
    pub fn method135(v0: i32, v1: LrcPtr<File_system::Mut6>) -> bool {
        (v1.l0.get().clone()) < (v0)
    }
    pub fn method136() -> char {
        std::path::MAIN_SEPARATOR
    }
    pub fn method137(v0: string) -> string {
        v0
    }
    pub fn method132(v0: string) -> string {
        unbox::<string>(fable_library_rust::Native_::getZero())
    }
    pub fn closure63(unitVar: (), v0: string) -> string {
        File_system::method132(v0)
    }
    pub fn method138(v0: string) -> string {
        File_system::method111(File_system::method132(v0))
    }
    pub fn closure64(unitVar: (), v0: string) -> string {
        File_system::method138(v0)
    }
    pub fn closure65(unitVar: (), v0: string) -> string {
        concat(new_array(&[
            string("file:///"),
            trimStartChars(v0, toArray(singleton('/'))),
        ]))
    }
    pub fn closure67(unitVar: (), v0: string) -> bool {
        File_system::method35(v0)
    }
    pub fn closure68(unitVar: (), v0: string) -> bool {
        File_system::method10(v0)
    }
    pub fn method142(
        v0: string,
        v1: string,
        v2: bool,
        v3: Func1<string, bool>,
        v4: string,
    ) -> File_system::US18 {
        let v0: MutCell<string> = MutCell::new(v0.clone());
        let v1: MutCell<string> = MutCell::new(v1.clone());
        let v2: MutCell<bool> = MutCell::new(v2);
        let v3 = MutCell::new(v3.clone());
        let v4: MutCell<string> = MutCell::new(v4.clone());
        '_method142: loop {
            break '_method142 (if v3(File_system::method91(v4.get().clone(), v0.get().clone())) {
                File_system::US18::US18_0(v4.get().clone())
            } else {
                let v8: Option<string> = File_system::method118(v4.get().clone());
                let v33_1: File_system::US5 =
                    defaultValue(File_system::US5::US5_1, map(File_system::method5(), v8));
                match &v33_1 {
                    File_system::US5::US5_0(v33_1_0_0) => {
                        let v0_temp: string = v0.get().clone();
                        let v1_temp: string = v1.get().clone();
                        let v2_temp: bool = v2.get().clone();
                        let v3_temp = v3.get().clone();
                        let v4_temp: string = match &v33_1 {
                            File_system::US5::US5_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone();
                        v0.set(v0_temp);
                        v1.set(v1_temp);
                        v2.set(v2_temp);
                        v3.set(v3_temp);
                        v4.set(v4_temp);
                        continue '_method142;
                    }
                    _ => File_system::US18::US18_1(append(
                        (concat(new_array(&[
                            string("file_system.find_parent / No parent for "),
                            if v2.get().clone() {
                                string("file")
                            } else {
                                string("dir")
                            },
                        ]))),
                        sprintf!(
                            " \'{}\' at \'{}\' (until \'{}\')",
                            v0.get().clone(),
                            v1.get().clone(),
                            v4.get().clone()
                        ),
                    )),
                }
            });
        }
    }
    pub fn method141(
        v0: string,
        v1: string,
        v2: bool,
        v3: Func1<string, bool>,
    ) -> File_system::US18 {
        if v3(File_system::method91(v1.clone(), v0.clone())) {
            File_system::US18::US18_0(v1.clone())
        } else {
            let v7: Option<string> = File_system::method118(v1.clone());
            let v32_1: File_system::US5 =
                defaultValue(File_system::US5::US5_1, map(File_system::method5(), v7));
            match &v32_1 {
                File_system::US5::US5_0(v32_1_0_0) => File_system::method142(
                    v0.clone(),
                    v1.clone(),
                    v2,
                    v3.clone(),
                    match &v32_1 {
                        File_system::US5::US5_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                ),
                _ => File_system::US18::US18_1(append(
                    (concat(new_array(&[
                        string("file_system.find_parent / No parent for "),
                        if v2 { string("file") } else { string("dir") },
                    ]))),
                    sprintf!(
                        " \'{}\' at \'{}\' (until \'{}\')",
                        v0.clone(),
                        v1.clone(),
                        v1.clone()
                    ),
                )),
            }
        }
    }
    pub fn method140(v0: File_system::US17, v1: string, v2: string) -> File_system::US18 {
        let v3: bool = if let File_system::US17::US17_0 = &v0 {
            true
        } else {
            false
        };
        File_system::method141(
            v1,
            v2,
            v3,
            if v3 {
                Func1::new(move |v: string| File_system::closure67((), v))
            } else {
                Func1::new(move |v_1: string| File_system::closure68((), v_1))
            },
        )
    }
    pub fn method144(v0: string, v1: string) -> string {
        let v3: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v17: () = {
            File_system::closure6(v3.clone(), string("{ "), ());
            ()
        };
        let v36_1: () = {
            File_system::closure6(v3.clone(), string("dir"), ());
            ()
        };
        let v55: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v72: () = {
            File_system::closure6(v3.clone(), v0, ());
            ()
        };
        let v91: () = {
            File_system::closure6(v3.clone(), string("; "), ());
            ()
        };
        let v110: () = {
            File_system::closure6(v3.clone(), string("error"), ());
            ()
        };
        let v127: () = {
            File_system::closure6(v3.clone(), string(" = "), ());
            ()
        };
        let v144: () = {
            File_system::closure6(v3.clone(), v1, ());
            ()
        };
        let v163: () = {
            File_system::closure6(v3.clone(), string(" }"), ());
            ()
        };
        v3.l0.get().clone()
    }
    pub fn method143(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
        v6: string,
        v7: string,
        v8: string,
        v9: string,
    ) -> string {
        let v10: string = File_system::method144(v8, v9);
        File_system::method21(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append((append((append((v6), string(" "))), (v7))), string(" #"))),
                            (toString(v0.l0.get().clone())),
                        )),
                        string(" "),
                    )),
                    string("file_system.get_workspace_root"),
                )),
                string(" / "),
            )),
            (v10),
        ))
    }
    pub fn closure69(v0: string, v1: string, unitVar: ()) {
        fn v17() {
            File_system::closure0((), ());
        }
        let v18: () = {
            v17();
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v59: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        let v299: File_system::US6 = if (if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            3_i32
                >= (find(
                    v59,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                        LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                        LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                        LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                        LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                    ])))),
                ))
        }) == false
        {
            File_system::US6::US6_1
        } else {
            let v82: () = {
                v17();
                ()
            };
            let patternInput_1: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v110: Option<i64> = patternInput_1.5.clone();
            let v109: LrcPtr<File_system::Mut4> = patternInput_1.4.clone();
            let v108: LrcPtr<File_system::Mut3> = patternInput_1.3.clone();
            let v107: LrcPtr<File_system::Mut2> = patternInput_1.2.clone();
            let v106: LrcPtr<File_system::Mut1> = patternInput_1.1.clone();
            let v105: LrcPtr<File_system::Mut0> = patternInput_1.0.clone();
            let v125: string = File_system::method143(
                v105.clone(),
                v106.clone(),
                v107.clone(),
                v108.clone(),
                v109.clone(),
                v110.clone(),
                File_system::method11(v105, v106, v107, v108, v109, v110),
                File_system::method52(),
                v0,
                v1,
            );
            let v141: () = {
                v17();
                ()
            };
            let patternInput_2: (
                LrcPtr<File_system::Mut0>,
                LrcPtr<File_system::Mut1>,
                LrcPtr<File_system::Mut2>,
                LrcPtr<File_system::Mut3>,
                LrcPtr<File_system::Mut4>,
                Option<i64>,
            ) = File_system::TraceState::trace_state()
                .get()
                .clone()
                .unwrap();
            let v167: LrcPtr<File_system::Mut3> = patternInput_2.3.clone();
            let v165: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v164: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v186: () = {
                File_system::closure7(v164.clone(), ());
                ()
            };
            let v209: string = if (v167.l0.get().clone()) == string("") {
                v125.clone()
            } else {
                if (v125.clone()) == string("") {
                    v167.l0.get().clone()
                } else {
                    append(
                        (append((v167.l0.get().clone()), string("\n"))),
                        (v125.clone()),
                    )
                }
            };
            let v220: &str = &*v209.clone();
            let v247 = v220.chars();
            let v249 = v247;
            let v251: Vec<char> = v249.collect::<Vec<_>>();
            let v253: Vec<Vec<char>> = v251
                .chunks(15000)
                .map(|x| x.into_iter().map(|x| x.clone()).collect::<Vec<_>>())
                .collect::<Vec<_>>();
            let v255: bool = true;
            let _vec_map: Vec<_> = v253
                .into_iter()
                .map(|x| {
                    //;
                    let v257: Vec<char> = x;
                    let v259: std::string::String = String::from_iter(v257);
                    let v261: bool = true;
                    v259
                })
                .collect::<Vec<_>>();
            let v263: Vec<std::string::String> = _vec_map;
            if if (v125.clone()) != string("") {
                (v263.clone().len() as i32) <= 1_i32
            } else {
                false
            } {
                v167.l0.set(v209);
                ()
            } else {
                v167.l0.set(string(""));
                {
                    let v288: bool = true;
                    v263.into_iter().for_each(|x| {
                        //;
                        let v290: std::string::String = x;
                        let v292: bool = true;
                        near_sdk::log!("{}", v290);
                        let v294: bool = true;
                        let v296: bool = true;
                    }); //;
                    ()
                }
            }
            (v165.l0.get().clone())(v125);
            File_system::US6::US6_0(
                v164,
                v165,
                patternInput_2.2.clone(),
                v167,
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn method139(v0: string) -> File_system::US5 {
        let v5: File_system::US18 = File_system::method140(
            File_system::US17::US17_1,
            File_system::method91(string("spiral"), string("workspace")),
            v0.clone(),
        );
        match &v5 {
            File_system::US18::US18_0(v5_0_0) => {
                File_system::US5::US5_0(File_system::method111(v5_0_0.clone()))
            }
            File_system::US18::US18_1(v5_1_0) => {
                let v323: () = {
                    File_system::closure69(v0.clone(), v5_1_0.clone(), ());
                    ()
                };
                File_system::US5::US5_1
            }
        }
    }
    pub fn closure66(unitVar: (), unitVar_1: ()) -> string {
        let v1: File_system::US5 = File_system::method139(File_system::method133());
        let v7: File_system::US5 = match &v1 {
            File_system::US5::US5_0(v1_0_0) => File_system::US5::US5_0(
                match &v1 {
                    File_system::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
            ),
            _ => {
                File_system::method139(string("c:\\home\\git\\polyglot\\deps\\spiral\\lib\\spiral"))
            }
        };
        let v13: File_system::US5 = match &v7 {
            File_system::US5::US5_0(v7_0_0) => File_system::US5::US5_0(
                match &v7 {
                    File_system::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
            ),
            _ => File_system::method139(string("/workspaces")),
        };
        let v17: string = match &v13 {
            File_system::US5::US5_0(v13_0_0) => match &v13 {
                File_system::US5::US5_0(x) => x.clone(),
                _ => unreachable!(),
            }
            .clone(),
            _ => panic!("{}", string("Option does not have a value."),),
        };
        File_system::method91(
            if string("deps") == (File_system::method18(v17.clone())) {
                let v25: File_system::US5 =
                    File_system::method139(File_system::method118(v17.clone()).clone().unwrap());
                match &v25 {
                    File_system::US5::US5_0(v25_0_0) => match &v25 {
                        File_system::US5::US5_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    _ => panic!("{}", string("Option does not have a value."),),
                }
            } else {
                v17
            },
            string("polyglot"),
        )
    }
    pub fn closure71(v0: LrcPtr<Exception>, unitVar: ()) -> LrcPtr<Exception> {
        v0
    }
    pub fn method145(v0: string) {
        ();
    }
    pub fn closure70(unitVar: (), v0: string) {
        File_system::method145(v0);
    }
    pub fn closure72(unitVar: (), v0: bool) {
        let v17: () = {
            File_system::closure0((), ());
            ()
        };
        let patternInput: (
            LrcPtr<File_system::Mut0>,
            LrcPtr<File_system::Mut1>,
            LrcPtr<File_system::Mut2>,
            LrcPtr<File_system::Mut3>,
            LrcPtr<File_system::Mut4>,
            Option<i64>,
        ) = File_system::TraceState::trace_state()
            .get()
            .clone()
            .unwrap();
        let v60 = if v0 {
            Func1::new(move |v: string| File_system::closure70((), v))
        } else {
            Func1::new(move |v_1: string| File_system::closure2((), v_1))
        };
        (patternInput.1.clone()).l0.set(v60);
        ()
    }
    pub fn method146(v0: string, v1: string) {
        if (File_system::method10(v0.clone())) == false {
            let v4: LrcPtr<dyn IDisposable> = File_system::method94(v0);
            ()
        }
        {
            let v9: string = defaultValue(string(""), File_system::method118(v1.clone()));
            if (File_system::method10(v9.clone())) == false {
                let v14_1: LrcPtr<dyn IDisposable> = File_system::method94(v9);
                ()
            }
            if if File_system::method10(v1.clone()) {
                let v16_1: Result<std::path::PathBuf, std::io::Error> =
                    File_system::method112(v1.clone());
                v16_1.is_err()
            } else {
                false
            } {
                File_system::method9(true, v1.clone());
            }
            if (File_system::method10(v1)) == false {
                ();
            }
        }
    }
    pub fn closure74(v0: string, v1: string) {
        File_system::method146(v0, v1);
    }
    pub fn closure73(unitVar: (), v0: string) -> Func1<string, ()> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure74(v0.clone(), v)
        })
    }
    pub fn closure76(v0: string, v1: string) -> string {
        File_system::method91(v0, v1)
    }
    pub fn closure75(unitVar: (), v0: string) -> Func1<string, string> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure76(v0.clone(), v)
        })
    }
    pub fn v14() -> () {
        static v14: OnceInit<()> = OnceInit::new();
        v14.get_or_init(|| ()).clone()
    }
    pub fn v15() -> Func0<()> {
        static v15: OnceInit<Func0<()>> = OnceInit::new();
        v15.get_or_init(|| Func0::new(move || File_system::closure0((), ())))
            .clone()
    }
    pub fn v16() -> () {
        static v16: OnceInit<()> = OnceInit::new();
        v16.get_or_init(|| {
            (File_system::v15())();
            File_system::v14()
        })
        .clone()
    }
    pub fn v31() -> Func1<string, Arc<Async<i64>>> {
        static v31: OnceInit<Func1<string, Arc<Async<i64>>>> = OnceInit::new();
        v31.get_or_init(|| Func1::new(move |v: string| File_system::closure3((), v)))
            .clone()
    }
    pub fn delete_directory_async(x: string) -> Arc<Async<i64>> {
        (File_system::v31())(x)
    }
    pub fn v32() -> Func1<File_system::US7, Func1<string, Arc<Async<i64>>>> {
        static v32: OnceInit<Func1<File_system::US7, Func1<string, Arc<Async<i64>>>>> =
            OnceInit::new();
        v32.get_or_init(|| Func1::new(move |v: File_system::US7| File_system::closure10((), v)))
            .clone()
    }
    pub fn wait_for_file_access(x: File_system::US7) -> Func1<string, Arc<Async<i64>>> {
        (File_system::v32())(x)
    }
    pub fn v33() -> Func1<string, Arc<Async<i64>>> {
        static v33: OnceInit<Func1<string, Arc<Async<i64>>>> = OnceInit::new();
        v33.get_or_init(|| Func1::new(move |v: string| File_system::closure13((), v)))
            .clone()
    }
    pub fn wait_for_file_access_read(x: string) -> Arc<Async<i64>> {
        (File_system::v33())(x)
    }
    pub fn v34() -> Func1<string, Arc<Async<string>>> {
        static v34: OnceInit<Func1<string, Arc<Async<string>>>> = OnceInit::new();
        v34.get_or_init(|| Func1::new(move |v: string| File_system::closure14((), v)))
            .clone()
    }
    pub fn read_all_text_async(x: string) -> Arc<Async<string>> {
        (File_system::v34())(x)
    }
    pub fn v35() -> Func1<string, Func1<string, bool>> {
        static v35: OnceInit<Func1<string, Func1<string, bool>>> = OnceInit::new();
        v35.get_or_init(|| Func1::new(move |v: string| File_system::closure16((), v)))
            .clone()
    }
    pub fn file_exists_content(x: string) -> Func1<string, bool> {
        (File_system::v35())(x)
    }
    pub fn v36() -> Func1<string, Func1<string, Arc<Async<()>>>> {
        static v36: OnceInit<Func1<string, Func1<string, Arc<Async<()>>>>> = OnceInit::new();
        v36.get_or_init(|| Func1::new(move |v: string| File_system::closure18((), v)))
            .clone()
    }
    pub fn write_all_text_async(x: string) -> Func1<string, Arc<Async<()>>> {
        (File_system::v36())(x)
    }
    pub fn v37() -> Func1<string, Func1<string, Arc<Async<()>>>> {
        static v37: OnceInit<Func1<string, Func1<string, Arc<Async<()>>>>> = OnceInit::new();
        v37.get_or_init(|| Func1::new(move |v: string| File_system::closure20((), v)))
            .clone()
    }
    pub fn write_all_text_exists(x: string) -> Func1<string, Arc<Async<()>>> {
        (File_system::v37())(x)
    }
    pub fn v38() -> Func1<string, Arc<Async<i64>>> {
        static v38: OnceInit<Func1<string, Arc<Async<i64>>>> = OnceInit::new();
        v38.get_or_init(|| Func1::new(move |v: string| File_system::closure22((), v)))
            .clone()
    }
    pub fn delete_file_async(x: string) -> Arc<Async<i64>> {
        (File_system::v38())(x)
    }
    pub fn v39() -> Func1<string, Func1<string, Arc<Async<i64>>>> {
        static v39: OnceInit<Func1<string, Func1<string, Arc<Async<i64>>>>> = OnceInit::new();
        v39.get_or_init(|| Func1::new(move |v: string| File_system::closure28((), v)))
            .clone()
    }
    pub fn move_file_async(x: string) -> Func1<string, Arc<Async<i64>>> {
        (File_system::v39())(x)
    }
    pub fn v40() -> Func1<string, Arc<Async<Option<string>>>> {
        static v40: OnceInit<Func1<string, Arc<Async<Option<string>>>>> = OnceInit::new();
        v40.get_or_init(|| Func1::new(move |v: string| File_system::closure31((), v)))
            .clone()
    }
    pub fn read_all_text_retry_async(x: string) -> Arc<Async<Option<string>>> {
        (File_system::v40())(x)
    }
    pub fn v41() -> Func0<string> {
        static v41: OnceInit<Func0<string>> = OnceInit::new();
        v41.get_or_init(|| Func0::new(move || File_system::closure41((), ())))
            .clone()
    }
    pub fn create_temp_path() -> string {
        (File_system::v41())()
    }
    pub fn v42() -> Func0<(string, LrcPtr<dyn IDisposable>)> {
        static v42: OnceInit<Func0<(string, LrcPtr<dyn IDisposable>)>> = OnceInit::new();
        v42.get_or_init(|| Func0::new(move || File_system::closure43((), ())))
            .clone()
    }
    pub fn create_temp_dir() -> (string, LrcPtr<dyn IDisposable>) {
        (File_system::v42())()
    }
    pub fn v43() -> Func1<string, (string, LrcPtr<dyn IDisposable>)> {
        static v43: OnceInit<Func1<string, (string, LrcPtr<dyn IDisposable>)>> = OnceInit::new();
        v43.get_or_init(|| Func1::new(move |v: string| File_system::closure52((), v)))
            .clone()
    }
    pub fn create_temp_dir_(x: string) -> (string, LrcPtr<dyn IDisposable>) {
        (File_system::v43())(x)
    }
    pub fn v44() -> Func0<string> {
        static v44: OnceInit<Func0<string>> = OnceInit::new();
        v44.get_or_init(|| Func0::new(move || File_system::closure54((), ())))
            .clone()
    }
    pub fn get_source_directory() -> string {
        (File_system::v44())()
    }
    pub fn v45() -> Func1<string, string> {
        static v45: OnceInit<Func1<string, string>> = OnceInit::new();
        v45.get_or_init(|| Func1::new(move |v: string| File_system::closure55((), v)))
            .clone()
    }
    pub fn normalize_path(x: string) -> string {
        (File_system::v45())(x)
    }
    pub fn v46() -> Func1<string, string> {
        static v46: OnceInit<Func1<string, string>> = OnceInit::new();
        v46.get_or_init(|| Func1::new(move |v: string| File_system::closure63((), v)))
            .clone()
    }
    pub fn get_full_path(x: string) -> string {
        (File_system::v46())(x)
    }
    pub fn v47() -> Func1<string, string> {
        static v47: OnceInit<Func1<string, string>> = OnceInit::new();
        v47.get_or_init(|| Func1::new(move |v: string| File_system::closure64((), v)))
            .clone()
    }
    pub fn standardize_path(x: string) -> string {
        (File_system::v47())(x)
    }
    pub fn v48() -> Func1<string, string> {
        static v48: OnceInit<Func1<string, string>> = OnceInit::new();
        v48.get_or_init(|| Func1::new(move |v: string| File_system::closure65((), v)))
            .clone()
    }
    pub fn new_file_uri(x: string) -> string {
        (File_system::v48())(x)
    }
    pub fn v49() -> Func0<string> {
        static v49: OnceInit<Func0<string>> = OnceInit::new();
        v49.get_or_init(|| Func0::new(move || File_system::closure66((), ())))
            .clone()
    }
    pub fn get_workspace_root() -> string {
        (File_system::v49())()
    }
    pub fn v50() -> Func1<string, ()> {
        static v50: OnceInit<Func1<string, ()>> = OnceInit::new();
        v50.get_or_init(|| Func1::new(move |v: string| File_system::closure70((), v)))
            .clone()
    }
    pub fn trace_file(x: string) {
        (File_system::v50())(x);
    }
    pub fn v51() -> Func1<bool, ()> {
        static v51: OnceInit<Func1<bool, ()>> = OnceInit::new();
        v51.get_or_init(|| Func1::new(move |v: bool| File_system::closure72((), v)))
            .clone()
    }
    pub fn init_trace_file(x: bool) {
        (File_system::v51())(x);
    }
    pub fn v52() -> Func1<string, Func1<string, ()>> {
        static v52: OnceInit<Func1<string, Func1<string, ()>>> = OnceInit::new();
        v52.get_or_init(|| Func1::new(move |v: string| File_system::closure73((), v)))
            .clone()
    }
    pub fn link_directory(x: string) -> Func1<string, ()> {
        (File_system::v52())(x)
    }
    pub fn v53() -> Func1<string, Func1<string, string>> {
        static v53: OnceInit<Func1<string, Func1<string, string>>> = OnceInit::new();
        v53.get_or_init(|| Func1::new(move |v: string| File_system::closure75((), v)))
            .clone()
    }
    pub fn op_LessDivideGreater(x: string) -> Func1<string, string> {
        (File_system::v53())(x)
    }
    on_startup!(());
}
