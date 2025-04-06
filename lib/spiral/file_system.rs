pub mod File_system {
    use super::*;
    use fable_library_rust::Async_::Async;
    use fable_library_rust::Choice_::Choice_2;
    use fable_library_rust::DateTime_::DateTime;
    use fable_library_rust::Guid_::Guid;
    use fable_library_rust::Guid_::new_guid;
    use fable_library_rust::Guid_::parse;
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
    use fable_library_rust::NativeArray_::get_Count;
    use fable_library_rust::NativeArray_::new_array;
    use fable_library_rust::NativeArray_::new_empty;
    use fable_library_rust::NativeArray_::new_init;
    use fable_library_rust::Option_::defaultValue;
    use fable_library_rust::Option_::map;
    use fable_library_rust::Range_::rangeNumeric;
    use fable_library_rust::Seq_::delay;
    use fable_library_rust::Seq_::map as map_1;
    use fable_library_rust::Seq_::ofList;
    use fable_library_rust::Seq_::toArray as toArray_1;
    use fable_library_rust::String_::append;
    use fable_library_rust::String_::concat;
    use fable_library_rust::String_::endsWith3;
    use fable_library_rust::String_::getCharAt;
    use fable_library_rust::String_::getSlice;
    use fable_library_rust::String_::join;
    use fable_library_rust::String_::length;
    use fable_library_rust::String_::ofChar;
    use fable_library_rust::String_::printfn;
    use fable_library_rust::String_::replace;
    use fable_library_rust::String_::split;
    use fable_library_rust::String_::sprintf;
    use fable_library_rust::String_::string;
    use fable_library_rust::String_::toLower;
    use fable_library_rust::String_::toString;
    use fable_library_rust::String_::trimEndChars;
    use fable_library_rust::String_::trimStartChars;
    use fable_library_rust::System::Collections::Generic::IEnumerable_1;
    use fable_library_rust::System::Exception;
    use fable_library_rust::System::IDisposable;
    use fable_library_rust::TimeSpan_::TimeSpan;
    type TimeZoneInfo = i64;
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
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US7 {
        US7_0,
        US7_1,
        US7_2,
    }
    impl core::fmt::Display for US7 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US8 {
        US8_0,
        US8_1,
        US8_2,
        US8_3,
        US8_4,
    }
    impl core::fmt::Display for US8 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US6 {
        US6_0(File_system::US7, File_system::US8),
        US6_1,
    }
    impl core::fmt::Display for US6 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US9 {
        US9_0,
        US9_1(string),
    }
    impl core::fmt::Display for US9 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US10 {
        US10_0(i64),
        US10_1(LrcPtr<Exception>),
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
        US12_0(chrono::DateTime<chrono::Utc>),
        US12_1,
    }
    impl core::fmt::Display for US12 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US13 {
        US13_0,
        US13_1(std::string::String),
    }
    impl core::fmt::Display for US13 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US14 {
        US14_0(std::path::PathBuf),
        US14_1(string),
    }
    impl core::fmt::Display for US14 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug)]
    pub enum US15 {
        US15_0(std::path::PathBuf),
        US15_1,
    }
    impl core::fmt::Display for US15 {
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
    pub enum US16 {
        US16_0,
        US16_1,
    }
    impl core::fmt::Display for US16 {
        fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
            write!(f, "{}", core::any::type_name::<Self>())
        }
    }
    #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
    pub enum US17 {
        US17_0(string),
        US17_1(string),
    }
    impl core::fmt::Display for US17 {
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
        let v3: string = File_system::method3(v0);
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
        let v16_1: string = File_system::method4();
        v15_1.unwrap_or(v16_1)
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
                File_system::US2::US2_0({
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
        v0: File_system::US0,
    ) -> (
        LrcPtr<File_system::Mut0>,
        LrcPtr<File_system::Mut1>,
        LrcPtr<File_system::Mut2>,
        LrcPtr<File_system::Mut3>,
        LrcPtr<File_system::Mut4>,
        Option<i64>,
    ) {
        let patternInput: (File_system::US1, File_system::US2) = File_system::method1();
        let _run_target_args__v3: (File_system::US1, File_system::US2) =
            (patternInput.0.clone(), patternInput.1.clone());
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
        let v12: &str = &*v0;
        let v48_1: std::string::String = String::from(v12);
        let v105: std::path::PathBuf = std::path::PathBuf::from(v48_1);
        if v105.clone().exists() {
            v105.is_dir()
        } else {
            false
        }
    }
    pub fn method9(v0: bool, v1: string) {
        if File_system::method10(v1.clone()) {
            if v0 {
                std::fs::remove_dir_all(&*v1.clone()).unwrap();
                ()
            } else {
                std::fs::remove_dir(&*v1).unwrap();
                ()
            };
        }
        ()
    }
    pub fn method11(v0: File_system::US0) -> bool {
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
        let v56: File_system::US0 = (patternInput.4.clone()).l0.get().clone();
        if ((patternInput.2.clone()).l0.get().clone()) == false {
            false
        } else {
            (find(
                v0,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                    LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                    LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                    LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                    LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                ])))),
            )) >= (find(
                v56,
                ofSeq(ofList(ofArray(new_array(&[
                    LrcPtr::new((File_system::US0::US0_0, 0_i32)),
                    LrcPtr::new((File_system::US0::US0_1, 1_i32)),
                    LrcPtr::new((File_system::US0::US0_2, 2_i32)),
                    LrcPtr::new((File_system::US0::US0_3, 3_i32)),
                    LrcPtr::new((File_system::US0::US0_4, 4_i32)),
                ])))),
            ))
        }
    }
    pub fn closure5(unitVar: (), v0: i64) -> File_system::US2 {
        File_system::US2::US2_0(v0)
    }
    pub fn method13() -> Func1<i64, File_system::US2> {
        Func1::new(move |v: i64| File_system::closure5((), v))
    }
    pub fn method14() -> string {
        string("hh:mm:ss")
    }
    pub fn method15() -> string {
        string("HH:mm:ss")
    }
    pub fn method12(
        v0: LrcPtr<File_system::Mut0>,
        v1: LrcPtr<File_system::Mut1>,
        v2: LrcPtr<File_system::Mut2>,
        v3: LrcPtr<File_system::Mut3>,
        v4: LrcPtr<File_system::Mut4>,
        v5: Option<i64>,
    ) -> string {
        let v220: File_system::US2 =
            defaultValue(File_system::US2::US2_1, map(File_system::method13(), v5));
        let v360: DateTime = match &v220 {
            File_system::US2::US2_0(v220_0_0) => {
                let v303: TimeSpan = TimeSpan::new_ticks(
                    ({
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    }) - (match &v220 {
                        File_system::US2::US2_0(x) => x.clone(),
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
        let v361: string = File_system::method14();
        let provider: string = if (v361.clone()) == string("") {
            string("M-d-y hh:mm:ss tt")
        } else {
            v361
        };
        v360.toString(provider)
    }
    pub fn method17() -> string {
        string("")
    }
    pub fn closure6(v0: LrcPtr<File_system::Mut3>, v1: string, unitVar: ()) {
        let v4: string = append((v0.l0.get().clone()), (v1));
        v0.l0.set(v4);
        ()
    }
    pub fn method18() -> string {
        string("\u{001b}[0m")
    }
    pub fn method16() -> string {
        let v7: char = getCharAt(toLower(string("Debug")), 0_i32);
        let v9: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v24: () = {
            File_system::closure6(v9.clone(), sprintf!("{}", v7), ());
            ()
        };
        let v30: string = v9.l0.get().clone();
        let v49_1: &str = inline_colorization::color_bright_blue;
        let v56: &str = &*v30;
        let v87: &str = inline_colorization::color_reset;
        let v89: std::string::String = format!("{}{}{}", v49_1, v56, v87);
        fable_library_rust::String_::fromString(v89)
    }
    pub fn method19(v0: string) -> string {
        let v12: &str = &*v0;
        let v48_1: std::string::String = String::from(v12);
        let v84: std::path::PathBuf = std::path::PathBuf::from(v48_1);
        let v115: Option<&std::ffi::OsStr> = v84.file_name();
        let v117: bool = true;
        let _optionm_map_ = v115.map(|x| {
            //;
            let v119: &std::ffi::OsStr = x;
            let v121: std::ffi::OsString = v119.to_os_string();
            let v123: Option<&str> = v121.to_str();
            let v125: &str = v123.unwrap();
            let v132: std::string::String = String::from(v125);
            let v163: string = fable_library_rust::String_::fromString(v132);
            let v165: bool = true;
            v163
        });
        let v167: Option<string> = _optionm_map_;
        let v192: File_system::US5 =
            defaultValue(File_system::US5::US5_1, map(File_system::method5(), v167));
        match &v192 {
            File_system::US5::US5_0(v192_0_0) => match &v192 {
                File_system::US5::US5_0(x) => x.clone(),
                _ => unreachable!(),
            }
            .clone(),
            _ => string(""),
        }
    }
    pub fn method21(v0: string) -> string {
        trimEndChars(
            trimStartChars(v0, toArray(empty::<char>())),
            toArray(ofArray(new_array(&[' ', '/']))),
        )
    }
    pub fn method20(
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
        let v11: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v25: () = {
            File_system::closure6(v11.clone(), string("{ "), ());
            ()
        };
        let v44_1: () = {
            File_system::closure6(v11.clone(), string("ex"), ());
            ()
        };
        let v63: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v80: () = {
            File_system::closure6(v11.clone(), v8, ());
            ()
        };
        let v99: () = {
            File_system::closure6(v11.clone(), string("; "), ());
            ()
        };
        let v118: () = {
            File_system::closure6(v11.clone(), string("path"), ());
            ()
        };
        let v135: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v152: () = {
            File_system::closure6(v11.clone(), v9, ());
            ()
        };
        let v171: () = {
            File_system::closure6(v11.clone(), string(" }"), ());
            ()
        };
        let v177: string = v11.l0.get().clone();
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
            (v177),
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
    pub fn method22(v0: string) {
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
        let v60: () = {
            File_system::closure7(patternInput.0.clone(), ());
            ()
        };
        println!("{}", v0.clone());
        ((patternInput.1.clone()).l0.get().clone())(v0)
    }
    pub fn closure4(v0: string, v1: LrcPtr<Exception>, unitVar: ()) {
        if File_system::method11(File_system::US0::US0_1) {
            let v20: () = {
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
            let v46_1: Option<i64> = patternInput.5.clone();
            let v45_1: LrcPtr<File_system::Mut4> = patternInput.4.clone();
            let v44_1: LrcPtr<File_system::Mut3> = patternInput.3.clone();
            let v43_1: LrcPtr<File_system::Mut2> = patternInput.2.clone();
            let v42_1: LrcPtr<File_system::Mut1> = patternInput.1.clone();
            let v41_1: LrcPtr<File_system::Mut0> = patternInput.0.clone();
            File_system::method22(File_system::method20(
                v41_1.clone(),
                v42_1.clone(),
                v43_1.clone(),
                v44_1.clone(),
                v45_1.clone(),
                v46_1.clone(),
                File_system::method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1),
                File_system::method16(),
                sprintf!("{:?}", v1),
                File_system::method19(v0),
            ))
        };
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
    pub fn method26(
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
        let v12: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v26: () = {
            File_system::closure6(v12.clone(), string("{ "), ());
            ()
        };
        let v45_1: () = {
            File_system::closure6(v12.clone(), string("path"), ());
            ()
        };
        let v64: () = {
            File_system::closure6(v12.clone(), string(" = "), ());
            ()
        };
        let v81: () = {
            File_system::closure6(v12.clone(), v8, ());
            ()
        };
        let v100: () = {
            File_system::closure6(v12.clone(), string("; "), ());
            ()
        };
        let v119: () = {
            File_system::closure6(v12.clone(), string("retry"), ());
            ()
        };
        let v136: () = {
            File_system::closure6(v12.clone(), string(" = "), ());
            ()
        };
        let v156: () = {
            File_system::closure6(v12.clone(), sprintf!("{}", v9), ());
            ()
        };
        let v173: () = {
            File_system::closure6(v12.clone(), string("; "), ());
            ()
        };
        let v192: () = {
            File_system::closure6(v12.clone(), string("ex"), ());
            ()
        };
        let v209: () = {
            File_system::closure6(v12.clone(), string(" = "), ());
            ()
        };
        let v226: () = {
            File_system::closure6(v12.clone(), v10, ());
            ()
        };
        let v245: () = {
            File_system::closure6(v12.clone(), string(" }"), ());
            ()
        };
        let v251: string = v12.l0.get().clone();
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
            (v251),
        ))
    }
    pub fn closure12(v0: string, v1: i64, v2: LrcPtr<Exception>, unitVar: ()) {
        if File_system::method11(File_system::US0::US0_1) {
            let v21: () = {
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
            let v47_1: Option<i64> = patternInput.5.clone();
            let v46_1: LrcPtr<File_system::Mut4> = patternInput.4.clone();
            let v45_1: LrcPtr<File_system::Mut3> = patternInput.3.clone();
            let v44_1: LrcPtr<File_system::Mut2> = patternInput.2.clone();
            let v43_1: LrcPtr<File_system::Mut1> = patternInput.1.clone();
            let v42_1: LrcPtr<File_system::Mut0> = patternInput.0.clone();
            File_system::method22(File_system::method26(
                v42_1.clone(),
                v43_1.clone(),
                v44_1.clone(),
                v45_1.clone(),
                v46_1.clone(),
                v47_1.clone(),
                File_system::method12(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1),
                File_system::method16(),
                File_system::method19(v0),
                v1,
                sprintf!("{:?}", v2),
            ))
        };
    }
    pub fn method25(
        v0: File_system::US6,
        v1: string,
        v2: i64,
        v3: File_system::US8,
        v4: File_system::US7,
    ) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method24(v0: File_system::US6, v1: string, v2: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method23(v0: File_system::US6, v1: string) -> Arc<Async<i64>> {
        File_system::method24(v0, v1, 0_i64)
    }
    pub fn closure11(v0: File_system::US6, v1: string) -> Arc<Async<i64>> {
        File_system::method23(v0, v1)
    }
    pub fn closure10(unitVar: (), v0: File_system::US6) -> Func1<string, Arc<Async<i64>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure11(v0.clone(), v)
        })
    }
    pub fn method27(v0: string) -> Arc<Async<i64>> {
        File_system::method23(
            File_system::US6::US6_0(File_system::US7::US7_0, File_system::US8::US8_1),
            v0,
        )
    }
    pub fn closure13(unitVar: (), v0: string) -> Arc<Async<i64>> {
        File_system::method27(v0)
    }
    pub fn method31() -> string {
        let v7: char = getCharAt(toLower(string("Verbose")), 0_i32);
        let v9: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v24: () = {
            File_system::closure6(v9.clone(), sprintf!("{}", v7), ());
            ()
        };
        let v30: string = v9.l0.get().clone();
        let v49_1: &str = inline_colorization::color_bright_black;
        let v56: &str = &*v30;
        let v87: &str = inline_colorization::color_reset;
        let v89: std::string::String = format!("{}{}{}", v49_1, v56, v87);
        fable_library_rust::String_::fromString(v89)
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
        let v12: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v26: () = {
            File_system::closure6(v12.clone(), string("{ "), ());
            ()
        };
        let v45_1: () = {
            File_system::closure6(v12.clone(), string("retry"), ());
            ()
        };
        let v64: () = {
            File_system::closure6(v12.clone(), string(" = "), ());
            ()
        };
        let v84: () = {
            File_system::closure6(v12.clone(), sprintf!("{}", v8), ());
            ()
        };
        let v103: () = {
            File_system::closure6(v12.clone(), string("; "), ());
            ()
        };
        let v122: () = {
            File_system::closure6(v12.clone(), string("path"), ());
            ()
        };
        let v139: () = {
            File_system::closure6(v12.clone(), string(" = "), ());
            ()
        };
        let v156: () = {
            File_system::closure6(v12.clone(), v9, ());
            ()
        };
        let v173: () = {
            File_system::closure6(v12.clone(), string("; "), ());
            ()
        };
        let v192: () = {
            File_system::closure6(v12.clone(), string("ex"), ());
            ()
        };
        let v209: () = {
            File_system::closure6(v12.clone(), string(" = "), ());
            ()
        };
        let v221: std::string::String = format!("{:#?}", v10);
        let v268: () = {
            File_system::closure6(
                v12.clone(),
                fable_library_rust::String_::fromString(v221),
                (),
            );
            ()
        };
        let v287: () = {
            File_system::closure6(v12.clone(), string(" }"), ());
            ()
        };
        let v293: string = v12.l0.get().clone();
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
            (v293),
        ))
    }
    pub fn closure15(v0: string, v1: i64, v2: LrcPtr<Exception>, unitVar: ()) {
        if File_system::method11(File_system::US0::US0_0) {
            let v21: () = {
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
            let v47_1: Option<i64> = patternInput.5.clone();
            let v46_1: LrcPtr<File_system::Mut4> = patternInput.4.clone();
            let v45_1: LrcPtr<File_system::Mut3> = patternInput.3.clone();
            let v44_1: LrcPtr<File_system::Mut2> = patternInput.2.clone();
            let v43_1: LrcPtr<File_system::Mut1> = patternInput.1.clone();
            let v42_1: LrcPtr<File_system::Mut0> = patternInput.0.clone();
            File_system::method22(File_system::method32(
                v42_1.clone(),
                v43_1.clone(),
                v44_1.clone(),
                v45_1.clone(),
                v46_1.clone(),
                v47_1.clone(),
                File_system::method12(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1),
                File_system::method31(),
                v1,
                v0,
                v2,
            ))
        };
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
    pub fn method34(v0: string) -> bool {
        let v12: &str = &*v0;
        let v48_1: std::string::String = String::from(v12);
        let v105: std::path::PathBuf = std::path::PathBuf::from(v48_1);
        if v105.clone().exists() {
            v105.is_file()
        } else {
            false
        }
    }
    pub fn method35(v0: Vec<u8>) -> Vec<u8> {
        v0
    }
    pub fn method33(v0: string, v1: string) -> bool {
        if (File_system::method34(v0.clone())) == false {
            false
        } else {
            let v20: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v0);
            let v68: Vec<u8> = File_system::method35(v20.unwrap());
            let v70: Result<std::string::String, std::string::FromUtf8Error> =
                std::string::String::from_utf8(v68);
            let v74: std::string::String = v70.unwrap();
            (v1) == (fable_library_rust::String_::fromString(v74))
        }
    }
    pub fn closure17(v0: string, v1: string) -> bool {
        File_system::method33(v0, v1)
    }
    pub fn closure16(unitVar: (), v0: string) -> Func1<string, bool> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure17(v0.clone(), v)
        })
    }
    pub fn method36(v0: string, v1: string) -> Arc<Async<()>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn closure19(v0: string, v1: string) -> Arc<Async<()>> {
        File_system::method36(v0, v1)
    }
    pub fn closure18(unitVar: (), v0: string) -> Func1<string, Arc<Async<()>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure19(v0.clone(), v)
        })
    }
    pub fn method40(v0: string, v1: string) -> Arc<Async<bool>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method39(v0: string, v1: string) -> Arc<Async<bool>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method38(v0: string, v1: string) -> Arc<Async<()>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method37(v0: string, v1: string) -> Arc<Async<()>> {
        File_system::method38(v0, v1)
    }
    pub fn closure21(v0: string, v1: string) -> Arc<Async<()>> {
        File_system::method37(v0, v1)
    }
    pub fn closure20(unitVar: (), v0: string) -> Func1<string, Arc<Async<()>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure21(v0.clone(), v)
        })
    }
    pub fn closure23(unitVar: (), v0: std::io::Error) -> string {
        let v2: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v9: std::string::String = format!("{:#?}", v0);
        let v56: () = {
            File_system::closure6(v2.clone(), fable_library_rust::String_::fromString(v9), ());
            ()
        };
        v2.l0.get().clone()
    }
    pub fn method44() -> Func1<std::io::Error, string> {
        Func1::new(move |v: std::io::Error| File_system::closure23((), v))
    }
    pub fn closure24(unitVar: (), unitVar_1: ()) -> File_system::US9 {
        File_system::US9::US9_0
    }
    pub fn method45() -> Func0<File_system::US9> {
        Func0::new(move || File_system::closure24((), ()))
    }
    pub fn closure25(unitVar: (), v0: string) -> File_system::US9 {
        File_system::US9::US9_1(v0)
    }
    pub fn method46() -> Func1<string, File_system::US9> {
        Func1::new(move |v: string| File_system::closure25((), v))
    }
    pub fn method47() -> string {
        let v7: char = getCharAt(toLower(string("Critical")), 0_i32);
        let v9: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v24: () = {
            File_system::closure6(v9.clone(), sprintf!("{}", v7), ());
            ()
        };
        let v30: string = v9.l0.get().clone();
        let v49_1: &str = inline_colorization::color_bright_red;
        let v56: &str = &*v30;
        let v87: &str = inline_colorization::color_reset;
        let v89: std::string::String = format!("{}{}{}", v49_1, v56, v87);
        fable_library_rust::String_::fromString(v89)
    }
    pub fn method48(
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
        let v10: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v24: () = {
            File_system::closure6(v10.clone(), string("{ "), ());
            ()
        };
        let v43_1: () = {
            File_system::closure6(v10.clone(), string("error\'"), ());
            ()
        };
        let v62: () = {
            File_system::closure6(v10.clone(), string(" = "), ());
            ()
        };
        let v79: () = {
            File_system::closure6(v10.clone(), v8, ());
            ()
        };
        let v98: () = {
            File_system::closure6(v10.clone(), string(" }"), ());
            ()
        };
        let v104: string = v10.l0.get().clone();
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
            (v104),
        ))
    }
    pub fn closure26(v0: string, unitVar: ()) {
        if File_system::method11(File_system::US0::US0_4) {
            let v19: () = {
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
            let v45_1: Option<i64> = patternInput.5.clone();
            let v44_1: LrcPtr<File_system::Mut4> = patternInput.4.clone();
            let v43_1: LrcPtr<File_system::Mut3> = patternInput.3.clone();
            let v42_1: LrcPtr<File_system::Mut2> = patternInput.2.clone();
            let v41_1: LrcPtr<File_system::Mut1> = patternInput.1.clone();
            let v40_1: LrcPtr<File_system::Mut0> = patternInput.0.clone();
            File_system::method22(File_system::method48(
                v40_1.clone(),
                v41_1.clone(),
                v42_1.clone(),
                v43_1.clone(),
                v44_1.clone(),
                v45_1.clone(),
                File_system::method12(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1),
                File_system::method47(),
                v0,
            ))
        };
    }
    pub fn method49() -> string {
        let v7: char = getCharAt(toLower(string("Warning")), 0_i32);
        let v9: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v24: () = {
            File_system::closure6(v9.clone(), sprintf!("{}", v7), ());
            ()
        };
        let v30: string = v9.l0.get().clone();
        let v49_1: &str = inline_colorization::color_yellow;
        let v56: &str = &*v30;
        let v87: &str = inline_colorization::color_reset;
        let v89: std::string::String = format!("{}{}{}", v49_1, v56, v87);
        fable_library_rust::String_::fromString(v89)
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
        v9: string,
    ) -> string {
        let v11: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v25: () = {
            File_system::closure6(v11.clone(), string("{ "), ());
            ()
        };
        let v44_1: () = {
            File_system::closure6(v11.clone(), string("path"), ());
            ()
        };
        let v63: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v80: () = {
            File_system::closure6(v11.clone(), v8, ());
            ()
        };
        let v99: () = {
            File_system::closure6(v11.clone(), string("; "), ());
            ()
        };
        let v118: () = {
            File_system::closure6(v11.clone(), string("ex"), ());
            ()
        };
        let v135: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v152: () = {
            File_system::closure6(v11.clone(), v9, ());
            ()
        };
        let v171: () = {
            File_system::closure6(v11.clone(), string(" }"), ());
            ()
        };
        let v177: string = v11.l0.get().clone();
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
            (v177),
        ))
    }
    pub fn closure27(v0: string, v1: LrcPtr<Exception>, unitVar: ()) {
        if File_system::method11(File_system::US0::US0_3) {
            let v20: () = {
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
            let v46_1: Option<i64> = patternInput.5.clone();
            let v45_1: LrcPtr<File_system::Mut4> = patternInput.4.clone();
            let v44_1: LrcPtr<File_system::Mut3> = patternInput.3.clone();
            let v43_1: LrcPtr<File_system::Mut2> = patternInput.2.clone();
            let v42_1: LrcPtr<File_system::Mut1> = patternInput.1.clone();
            let v41_1: LrcPtr<File_system::Mut0> = patternInput.0.clone();
            File_system::method22(File_system::method50(
                v41_1.clone(),
                v42_1.clone(),
                v43_1.clone(),
                v44_1.clone(),
                v45_1.clone(),
                v46_1.clone(),
                File_system::method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1),
                File_system::method49(),
                File_system::method19(v0),
                sprintf!("{:?}", v1),
            ))
        };
    }
    pub fn method43(v0: string, v1: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method42(v0: string, v1: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method41(v0: string) -> Arc<Async<i64>> {
        File_system::method42(v0, 0_i64)
    }
    pub fn closure22(unitVar: (), v0: string) -> Arc<Async<i64>> {
        File_system::method41(v0)
    }
    pub fn method54(v0: string, v1: string) {
        ();
    }
    pub fn method55(
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
        let v12: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v26: () = {
            File_system::closure6(v12.clone(), string("{ "), ());
            ()
        };
        let v45_1: () = {
            File_system::closure6(v12.clone(), string("old_path"), ());
            ()
        };
        let v64: () = {
            File_system::closure6(v12.clone(), string(" = "), ());
            ()
        };
        let v81: () = {
            File_system::closure6(v12.clone(), v8, ());
            ()
        };
        let v100: () = {
            File_system::closure6(v12.clone(), string("; "), ());
            ()
        };
        let v119: () = {
            File_system::closure6(v12.clone(), string("new_path"), ());
            ()
        };
        let v136: () = {
            File_system::closure6(v12.clone(), string(" = "), ());
            ()
        };
        let v153: () = {
            File_system::closure6(v12.clone(), v9, ());
            ()
        };
        let v170: () = {
            File_system::closure6(v12.clone(), string("; "), ());
            ()
        };
        let v189: () = {
            File_system::closure6(v12.clone(), string("ex"), ());
            ()
        };
        let v206: () = {
            File_system::closure6(v12.clone(), string(" = "), ());
            ()
        };
        let v223: () = {
            File_system::closure6(v12.clone(), v10, ());
            ()
        };
        let v242: () = {
            File_system::closure6(v12.clone(), string(" }"), ());
            ()
        };
        let v248: string = v12.l0.get().clone();
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
            (v248),
        ))
    }
    pub fn closure30(v0: string, v1: string, v2: LrcPtr<Exception>, unitVar: ()) {
        if File_system::method11(File_system::US0::US0_3) {
            let v21: () = {
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
            let v47_1: Option<i64> = patternInput.5.clone();
            let v46_1: LrcPtr<File_system::Mut4> = patternInput.4.clone();
            let v45_1: LrcPtr<File_system::Mut3> = patternInput.3.clone();
            let v44_1: LrcPtr<File_system::Mut2> = patternInput.2.clone();
            let v43_1: LrcPtr<File_system::Mut1> = patternInput.1.clone();
            let v42_1: LrcPtr<File_system::Mut0> = patternInput.0.clone();
            File_system::method22(File_system::method55(
                v42_1.clone(),
                v43_1.clone(),
                v44_1.clone(),
                v45_1.clone(),
                v46_1.clone(),
                v47_1.clone(),
                File_system::method12(v42_1, v43_1, v44_1, v45_1, v46_1, v47_1),
                File_system::method49(),
                File_system::method19(v1),
                File_system::method19(v0),
                sprintf!("{:?}", v2),
            ))
        };
    }
    pub fn method53(v0: string, v1: string, v2: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method52(v0: string, v1: string, v2: i64) -> Arc<Async<i64>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method51(v0: string, v1: string) -> Arc<Async<i64>> {
        File_system::method52(v0, v1, 0_i64)
    }
    pub fn closure29(v0: string, v1: string) -> Arc<Async<i64>> {
        File_system::method51(v0, v1)
    }
    pub fn closure28(unitVar: (), v0: string) -> Func1<string, Arc<Async<i64>>> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure29(v0.clone(), v)
        })
    }
    pub fn closure32(unitVar: (), v0: i64) -> File_system::US10 {
        File_system::US10::US10_0(v0)
    }
    pub fn method62() -> Func1<i64, File_system::US10> {
        Func1::new(move |v: i64| File_system::closure32((), v))
    }
    pub fn closure33(unitVar: (), v0: LrcPtr<Exception>) -> File_system::US10 {
        File_system::US10::US10_1(v0)
    }
    pub fn method63() -> Func1<LrcPtr<Exception>, File_system::US10> {
        Func1::new(move |v: LrcPtr<Exception>| File_system::closure33((), v))
    }
    pub fn method61(
        v0: Arc<Async<LrcPtr<Choice_2<i64, LrcPtr<Exception>>>>>,
    ) -> Arc<Async<File_system::US10>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method64(v0: Arc<Async<File_system::US10>>) -> Arc<Async<File_system::US11>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method66(
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
        let v10: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v24: () = {
            File_system::closure6(v10.clone(), string("{ "), ());
            ()
        };
        let v43_1: () = {
            File_system::closure6(v10.clone(), string("timeout"), ());
            ()
        };
        let v62: () = {
            File_system::closure6(v10.clone(), string(" = "), ());
            ()
        };
        let v82: () = {
            File_system::closure6(v10.clone(), sprintf!("{}", v8), ());
            ()
        };
        let v101: () = {
            File_system::closure6(v10.clone(), string(" }"), ());
            ()
        };
        let v107: string = v10.l0.get().clone();
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
            (v107),
        ))
    }
    pub fn closure34(v0: i32, unitVar: ()) {
        if File_system::method11(File_system::US0::US0_0) {
            let v19: () = {
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
            let v45_1: Option<i64> = patternInput.5.clone();
            let v44_1: LrcPtr<File_system::Mut4> = patternInput.4.clone();
            let v43_1: LrcPtr<File_system::Mut3> = patternInput.3.clone();
            let v42_1: LrcPtr<File_system::Mut2> = patternInput.2.clone();
            let v41_1: LrcPtr<File_system::Mut1> = patternInput.1.clone();
            let v40_1: LrcPtr<File_system::Mut0> = patternInput.0.clone();
            File_system::method22(File_system::method66(
                v40_1.clone(),
                v41_1.clone(),
                v42_1.clone(),
                v43_1.clone(),
                v44_1.clone(),
                v45_1.clone(),
                File_system::method12(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1),
                File_system::method31(),
                v0,
            ))
        };
    }
    pub fn method67(
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
        let v11: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v25: () = {
            File_system::closure6(v11.clone(), string("{ "), ());
            ()
        };
        let v44_1: () = {
            File_system::closure6(v11.clone(), string("timeout"), ());
            ()
        };
        let v63: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v83: () = {
            File_system::closure6(v11.clone(), sprintf!("{}", v8), ());
            ()
        };
        let v102: () = {
            File_system::closure6(v11.clone(), string("; "), ());
            ()
        };
        let v121: () = {
            File_system::closure6(v11.clone(), string("ex"), ());
            ()
        };
        let v138: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v155: () = {
            File_system::closure6(v11.clone(), v9, ());
            ()
        };
        let v174: () = {
            File_system::closure6(v11.clone(), string(" }"), ());
            ()
        };
        let v180: string = v11.l0.get().clone();
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
            (v180),
        ))
    }
    pub fn closure35(v0: i32, v1: LrcPtr<Exception>, unitVar: ()) {
        if File_system::method11(File_system::US0::US0_4) {
            let v20: () = {
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
            let v46_1: Option<i64> = patternInput.5.clone();
            let v45_1: LrcPtr<File_system::Mut4> = patternInput.4.clone();
            let v44_1: LrcPtr<File_system::Mut3> = patternInput.3.clone();
            let v43_1: LrcPtr<File_system::Mut2> = patternInput.2.clone();
            let v42_1: LrcPtr<File_system::Mut1> = patternInput.1.clone();
            let v41_1: LrcPtr<File_system::Mut0> = patternInput.0.clone();
            File_system::method22(File_system::method67(
                v41_1.clone(),
                v42_1.clone(),
                v43_1.clone(),
                v44_1.clone(),
                v45_1.clone(),
                v46_1.clone(),
                File_system::method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1),
                File_system::method47(),
                v0,
                sprintf!("{:?}", v1),
            ))
        };
    }
    pub fn method65(v0: i32, v1: Arc<Async<File_system::US11>>) -> Arc<Async<File_system::US2>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method60(v0: Arc<Async<i64>>, v1: i32) -> Arc<Async<File_system::US2>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method59(v0: i32, v1: Arc<Async<i64>>) -> Arc<Async<File_system::US2>> {
        File_system::method60(v1, v0)
    }
    pub fn method68(v0: Arc<Async<string>>) -> Arc<Async<Option<string>>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method69(
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
        let v11: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v25: () = {
            File_system::closure6(v11.clone(), string("{ "), ());
            ()
        };
        let v44_1: () = {
            File_system::closure6(v11.clone(), string("retry"), ());
            ()
        };
        let v63: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v83: () = {
            File_system::closure6(v11.clone(), sprintf!("{}", v8), ());
            ()
        };
        let v102: () = {
            File_system::closure6(v11.clone(), string("; "), ());
            ()
        };
        let v121: () = {
            File_system::closure6(v11.clone(), string("ex"), ());
            ()
        };
        let v138: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v155: () = {
            File_system::closure6(v11.clone(), v9, ());
            ()
        };
        let v174: () = {
            File_system::closure6(v11.clone(), string(" }"), ());
            ()
        };
        let v180: string = v11.l0.get().clone();
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
            (v180),
        ))
    }
    pub fn closure36(v0: i64, v1: LrcPtr<Exception>, unitVar: ()) {
        if File_system::method11(File_system::US0::US0_1) {
            let v20: () = {
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
            let v46_1: Option<i64> = patternInput.5.clone();
            let v45_1: LrcPtr<File_system::Mut4> = patternInput.4.clone();
            let v44_1: LrcPtr<File_system::Mut3> = patternInput.3.clone();
            let v43_1: LrcPtr<File_system::Mut2> = patternInput.2.clone();
            let v42_1: LrcPtr<File_system::Mut1> = patternInput.1.clone();
            let v41_1: LrcPtr<File_system::Mut0> = patternInput.0.clone();
            File_system::method22(File_system::method69(
                v41_1.clone(),
                v42_1.clone(),
                v43_1.clone(),
                v44_1.clone(),
                v45_1.clone(),
                v46_1.clone(),
                File_system::method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1),
                File_system::method16(),
                v0,
                sprintf!("{:?}", v1),
            ))
        };
    }
    pub fn method58(v0: string, v1: i64) -> Arc<Async<Option<string>>> {
        fable_library_rust::Native_::getZero()
    }
    pub fn method57(v0: string, v1: i64) -> Arc<Async<Option<string>>> {
        File_system::method58(v0, v1)
    }
    pub fn method56(v0: string) -> Arc<Async<Option<string>>> {
        File_system::method57(v0, 0_i64)
    }
    pub fn closure31(unitVar: (), v0: string) -> Arc<Async<Option<string>>> {
        File_system::method56(v0)
    }
    pub fn closure38(unitVar: (), v0: chrono::DateTime<chrono::Utc>) -> File_system::US12 {
        File_system::US12::US12_0(v0)
    }
    pub fn method72() -> Func1<chrono::DateTime<chrono::Utc>, File_system::US12> {
        Func1::new(move |v: chrono::DateTime<chrono::Utc>| File_system::closure38((), v))
    }
    pub fn method73() -> string {
        string("hh:mm")
    }
    pub fn method74() -> string {
        string("yyyyMMdd-HHmm-ssff-ffff-f")
    }
    pub fn method75() -> string {
        string("hhmm")
    }
    pub fn method71(v0: Guid, v1: DateTime) -> Guid {
        let v688: DateTime = {
            let _arg: DateTime = DateTime::unixEpoch();
            _arg.toUniversalTime()
        };
        let v698: DateTime = {
            let _arg_1: DateTime = DateTime::specifyKind(v1, 2_i32);
            _arg_1.toUniversalTime()
        };
        let v798: i64 = ((v698.ticks()) - (v688.ticks())) / 10_i64;
        let v800: Option<chrono::DateTime<chrono::Utc>> =
            chrono::DateTime::from_timestamp_micros(v798);
        let v825: File_system::US12 = defaultValue(
            File_system::US12::US12_1,
            map(File_system::method72(), v800),
        );
        let v845: File_system::US5 = match &v825 {
            File_system::US12::US12_0(v825_0_0) => {
                let v831: chrono::NaiveDateTime = match &v825 {
                    File_system::US12::US12_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone()
                .naive_utc();
                let v833: chrono::DateTime<chrono::Local> =
                    chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &v831);
                let v835: string = string("r#\"%Y%m%d-%H%M-%S%f\"#");
                let v836: &str = r#"%Y%m%d-%H%M-%S%f"#;
                let v838: std::string::String = v833.format(v836).to_string();
                let v840: string = fable_library_rust::String_::fromString(v838);
                File_system::US5::US5_0(sprintf!(
                    "{}-{}-{}",
                    getSlice(v840.clone(), Some(0_i32), Some(17_i32)),
                    getSlice(v840.clone(), Some(18_i32), Some(21_i32)),
                    getCharAt(v840, 22_i32)
                ))
            }
            _ => File_system::US5::US5_1,
        };
        let v849: string = match &v845 {
            File_system::US5::US5_0(v845_0_0) => match &v845 {
                File_system::US5::US5_0(x) => x.clone(),
                _ => unreachable!(),
            }
            .clone(),
            _ => string(""),
        };
        let v856: LrcPtr<TimeZoneInfo> = std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(
            chrono::Local::now().offset(),
        ) as i64);
        let v900: i64 = v698.ticks();
        let v936: string = string(
            "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))",
        );
        let v1087: TimeSpan = TimeSpan::new_ticks(chrono::FixedOffset::local_minus_utc(
            &chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(
                &chrono::DateTime::from_timestamp_nanos(v900),
            )),
        ) as i64);
        let v1108: u8 = if (v1087.hours()) > 0_i32 { 1_u8 } else { 0_u8 };
        let v1109: string = File_system::method73();
        let v1296: string = v1087.toString(v1109);
        let v1415: string = sprintf!(
            "{}{}{}",
            v1108,
            getSlice(v1296.clone(), Some(0_i32), Some(1_i32)),
            getSlice(v1296, Some(3_i32), Some(4_i32))
        );
        let v1418: string = toString(v0);
        parse(concat(new_array(&[
            v849.clone(),
            v1415.clone(),
            getSlice(
                v1418.clone(),
                Some((length(v849)) + (length(v1415))),
                Some((length(v1418)) - 1_i32),
            ),
        ])))
    }
    pub fn method77() -> string {
        let v6: std::path::PathBuf = std::env::temp_dir();
        let v13: std::path::Display = v6.display();
        let v49_1: std::string::String = format!("{}", v13);
        fable_library_rust::String_::fromString(v49_1)
    }
    pub fn method78() -> string {
        string("!create_temp_path_")
    }
    pub fn method79(v0: string, v1: string) -> string {
        let v13: &str = &*v0;
        let v49_1: std::string::String = String::from(v13);
        let v85: std::path::PathBuf = std::path::PathBuf::from(v49_1);
        let v121: &str = &*v1;
        let v157: std::string::String = String::from(v121);
        let v188: std::path::PathBuf = v85.join(v157);
        let v195: std::path::Display = v188.display();
        let v231: std::string::String = format!("{}", v195);
        fable_library_rust::String_::fromString(v231)
    }
    pub fn method81() -> string {
        string("CARGO_PKG_NAME")
    }
    pub fn method80() -> string {
        File_system::method2(File_system::method81())
    }
    pub fn method76(v0: Guid) -> string {
        File_system::method79(
            File_system::method79(
                File_system::method79(File_system::method77(), File_system::method78()),
                File_system::method80(),
            ),
            toString(v0),
        )
    }
    pub fn method70() -> string {
        let v37_1: DateTime = DateTime::now();
        File_system::method76(File_system::method71(new_guid(), v37_1))
    }
    pub fn closure37(unitVar: (), unitVar_1: ()) -> string {
        File_system::method70()
    }
    pub fn closure40(unitVar: (), v0: std::io::Error) -> std::string::String {
        format!("{}", v0)
    }
    pub fn method83() -> Func1<std::io::Error, std::string::String> {
        Func1::new(move |v: std::io::Error| File_system::closure40((), v))
    }
    pub fn closure41(unitVar: (), unitVar_1: ()) -> File_system::US13 {
        File_system::US13::US13_0
    }
    pub fn method84() -> Func0<File_system::US13> {
        Func0::new(move || File_system::closure41((), ()))
    }
    pub fn closure42(unitVar: (), v0: std::string::String) -> File_system::US13 {
        File_system::US13::US13_1(v0)
    }
    pub fn method85() -> Func1<std::string::String, File_system::US13> {
        Func1::new(move |v: std::string::String| File_system::closure42((), v))
    }
    pub fn method86(
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
        let v11: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v25: () = {
            File_system::closure6(v11.clone(), string("{ "), ());
            ()
        };
        let v44_1: () = {
            File_system::closure6(v11.clone(), string("dir"), ());
            ()
        };
        let v63: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v80: () = {
            File_system::closure6(v11.clone(), v8, ());
            ()
        };
        let v99: () = {
            File_system::closure6(v11.clone(), string("; "), ());
            ()
        };
        let v118: () = {
            File_system::closure6(v11.clone(), string("error"), ());
            ()
        };
        let v135: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v147: std::string::String = format!("{:#?}", v9);
        let v194: () = {
            File_system::closure6(
                v11.clone(),
                fable_library_rust::String_::fromString(v147),
                (),
            );
            ()
        };
        let v213: () = {
            File_system::closure6(v11.clone(), string(" }"), ());
            ()
        };
        let v219: string = v11.l0.get().clone();
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
            (v219),
        ))
    }
    pub fn closure43(v0: string, v1: std::string::String, unitVar: ()) {
        if File_system::method11(File_system::US0::US0_4) {
            let v20: () = {
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
            let v46_1: Option<i64> = patternInput.5.clone();
            let v45_1: LrcPtr<File_system::Mut4> = patternInput.4.clone();
            let v44_1: LrcPtr<File_system::Mut3> = patternInput.3.clone();
            let v43_1: LrcPtr<File_system::Mut2> = patternInput.2.clone();
            let v42_1: LrcPtr<File_system::Mut1> = patternInput.1.clone();
            let v41_1: LrcPtr<File_system::Mut0> = patternInput.0.clone();
            File_system::method22(File_system::method86(
                v41_1.clone(),
                v42_1.clone(),
                v43_1.clone(),
                v44_1.clone(),
                v45_1.clone(),
                v46_1.clone(),
                File_system::method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1),
                File_system::method47(),
                v0,
                v1,
            ))
        };
    }
    pub fn method87(
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
        let v10: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v24: () = {
            File_system::closure6(v10.clone(), string("{ "), ());
            ()
        };
        let v43_1: () = {
            File_system::closure6(v10.clone(), string("dir"), ());
            ()
        };
        let v62: () = {
            File_system::closure6(v10.clone(), string(" = "), ());
            ()
        };
        let v79: () = {
            File_system::closure6(v10.clone(), v8, ());
            ()
        };
        let v98: () = {
            File_system::closure6(v10.clone(), string(" }"), ());
            ()
        };
        let v104: string = v10.l0.get().clone();
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
            (v104),
        ))
    }
    pub fn closure44(v0: string, unitVar: ()) {
        if File_system::method11(File_system::US0::US0_0) {
            let v19: () = {
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
            let v45_1: Option<i64> = patternInput.5.clone();
            let v44_1: LrcPtr<File_system::Mut4> = patternInput.4.clone();
            let v43_1: LrcPtr<File_system::Mut3> = patternInput.3.clone();
            let v42_1: LrcPtr<File_system::Mut2> = patternInput.2.clone();
            let v41_1: LrcPtr<File_system::Mut1> = patternInput.1.clone();
            let v40_1: LrcPtr<File_system::Mut0> = patternInput.0.clone();
            File_system::method22(File_system::method87(
                v40_1.clone(),
                v41_1.clone(),
                v42_1.clone(),
                v43_1.clone(),
                v44_1.clone(),
                v45_1.clone(),
                File_system::method12(v40_1, v41_1, v42_1, v43_1, v44_1, v45_1),
                File_system::method31(),
                v0,
            ))
        };
    }
    pub fn closure45(v0: string, unitVar: ()) {
        File_system::method9(true, v0);
    }
    pub fn method88(v0: string) -> Func0<()> {
        Func0::new({
            let v0 = v0.clone();
            move || File_system::closure45(v0.clone(), ())
        })
    }
    pub fn method89(v0: string) -> Func0<()> {
        Func0::new({
            let v0 = v0.clone();
            move || File_system::closure45(v0.clone(), ())
        })
    }
    pub fn method90(v0: string) -> bool {
        unbox::<bool>(fable_library_rust::Native_::getZero())
    }
    pub fn method91(
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
        let v11: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v25: () = {
            File_system::closure6(v11.clone(), string("{ "), ());
            ()
        };
        let v44_1: () = {
            File_system::closure6(v11.clone(), string("dir"), ());
            ()
        };
        let v63: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v80: () = {
            File_system::closure6(v11.clone(), v8, ());
            ()
        };
        let v99: () = {
            File_system::closure6(v11.clone(), string("; "), ());
            ()
        };
        let v118: () = {
            File_system::closure6(v11.clone(), string("result"), ());
            ()
        };
        let v135: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v152: () = {
            File_system::closure6(v11.clone(), v9, ());
            ()
        };
        let v171: () = {
            File_system::closure6(v11.clone(), string(" }"), ());
            ()
        };
        let v177: string = v11.l0.get().clone();
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
            (v177),
        ))
    }
    pub fn closure46(v0: string, v1: string, unitVar: ()) {
        if File_system::method11(File_system::US0::US0_1) {
            let v20: () = {
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
            let v46_1: Option<i64> = patternInput.5.clone();
            let v45_1: LrcPtr<File_system::Mut4> = patternInput.4.clone();
            let v44_1: LrcPtr<File_system::Mut3> = patternInput.3.clone();
            let v43_1: LrcPtr<File_system::Mut2> = patternInput.2.clone();
            let v42_1: LrcPtr<File_system::Mut1> = patternInput.1.clone();
            let v41_1: LrcPtr<File_system::Mut0> = patternInput.0.clone();
            File_system::method22(File_system::method91(
                v41_1.clone(),
                v42_1.clone(),
                v43_1.clone(),
                v44_1.clone(),
                v45_1.clone(),
                v46_1.clone(),
                File_system::method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1),
                File_system::method16(),
                v0,
                v1,
            ))
        };
    }
    pub fn closure47(v0: string, unitVar: ()) {
        let v1: Arc<Async<i64>> = File_system::method6(v0);
        let v8: Arc<Async<()>> = fable_library_rust::Native_::getZero();
        fable_library_rust::Native_::getZero::<()>();
        ()
    }
    pub fn method92(v0: string) -> Func0<()> {
        Func0::new({
            let v0 = v0.clone();
            move || File_system::closure47(v0.clone(), ())
        })
    }
    pub fn method93(v0: string) -> Func0<()> {
        Func0::new({
            let v0 = v0.clone();
            move || File_system::closure47(v0.clone(), ())
        })
    }
    pub fn method82(v0: string) -> LrcPtr<dyn IDisposable> {
        let v239: Result<(), std::io::Error> = std::fs::create_dir_all(&*v0.clone());
        let v240 = File_system::method83();
        let v253: Result<(), std::string::String> = v239.map_err(|x| v240(x));
        let v256 = File_system::method84();
        let v257 = File_system::method85();
        let v259: File_system::US13 = match &v253 {
            Err(v253_1_0) => v257(v253_1_0.clone()),
            _ => v256(),
        };
        match &v259 {
            File_system::US13::US13_0 => {
                let v324: () = {
                    File_system::closure44(v0.clone(), ());
                    ()
                };
                ()
            }
            File_system::US13::US13_1(v259_1_0) => {
                let v448: () = {
                    File_system::closure43(
                        v0.clone(),
                        match &v259 {
                            File_system::US13::US13_1(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        (),
                    );
                    ()
                };
                ()
            }
        }
        {
            let v514 = File_system::method88(v0.clone());
            interface_cast!(
                File_system::Disposable::_ctor__3A5B6456(Func0::new({
                    let v514 = v514.clone();
                    move || v514.clone()()
                })),
                Lrc<dyn IDisposable>,
            )
        }
    }
    pub fn closure39(unitVar: (), unitVar_1: ()) -> (string, LrcPtr<dyn IDisposable>) {
        let v0: string = File_system::method70();
        (v0.clone(), File_system::method82(v0))
    }
    pub fn closure49(v0: i32, v1: string, v2: i32, v3: string) -> string {
        if (v2) >= (v0) {
            v3.clone()
        } else {
            (File_system::method95(v0, v1.clone(), (v2) + 1_i32))(append((v3), (v1)))
        }
    }
    pub fn method95(v0: i32, v1: string, v2: i32) -> Func1<string, string> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            let v2 = v2.clone();
            move |v: string| File_system::closure49(v0, v1.clone(), v2, v)
        })
    }
    pub fn method94(v0: string) -> Guid {
        let v3: string = ofChar('0');
        let v13: string = append(
            ((File_system::method95(32_i32 - (length(v0.clone())), v3, 0_i32))(string(""))),
            (v0),
        );
        parse(append(
            (append(
                (append(
                    (append(
                        (append(
                            (append(
                                (append(
                                    (append(
                                        (getSlice(v13.clone(), Some(0_i32), Some((8_i32) - 1_i32))),
                                        string("-"),
                                    )),
                                    (getSlice(v13.clone(), Some(8_i32), Some((12_i32) - 1_i32))),
                                )),
                                string("-"),
                            )),
                            (getSlice(v13.clone(), Some(12_i32), Some((16_i32) - 1_i32))),
                        )),
                        string("-"),
                    )),
                    (getSlice(v13.clone(), Some(16_i32), Some((20_i32) - 1_i32))),
                )),
                string("-"),
            )),
            (getSlice(v13, Some(20_i32), Some((32_i32) - 1_i32))),
        ))
    }
    pub fn closure48(unitVar: (), v0: string) -> (string, LrcPtr<dyn IDisposable>) {
        let v2: string = File_system::method76(File_system::method94(v0));
        (v2.clone(), File_system::method82(v2))
    }
    pub fn closure50(unitVar: (), unitVar_1: ()) -> string {
        string("/home/runner/work/spiral/polyglot/deps/spiral/lib/spiral")
    }
    pub fn closure52(unitVar: (), v0: std::path::PathBuf) -> File_system::US14 {
        File_system::US14::US14_0(v0)
    }
    pub fn method99() -> Func1<std::path::PathBuf, File_system::US14> {
        Func1::new(move |v: std::path::PathBuf| File_system::closure52((), v))
    }
    pub fn closure53(unitVar: (), v0: string) -> File_system::US14 {
        File_system::US14::US14_1(v0)
    }
    pub fn method100() -> Func1<string, File_system::US14> {
        Func1::new(move |v: string| File_system::closure53((), v))
    }
    pub fn method103(v0: string) -> Option<string> {
        let v12: &str = &*v0;
        let v48_1: std::string::String = String::from(v12);
        let v84: std::path::PathBuf = std::path::PathBuf::from(v48_1);
        let v115: Option<std::path::PathBuf> = v84.parent().map(std::path::PathBuf::from);
        let v117: bool = true;
        let _optionm_map_ = v115.map(|x| {
            //;
            let v119: std::path::PathBuf = x;
            let v126: std::path::Display = v119.display();
            let v162: std::string::String = format!("{}", v126);
            let v193: string = fable_library_rust::String_::fromString(v162);
            let v195: bool = true;
            v193
        });
        _optionm_map_
    }
    pub fn method102(
        v0: string,
        v1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
        v2: u8,
        v3: string,
        v4: string,
    ) -> Result<std::path::PathBuf, std::io::Error> {
        let v5: string = File_system::method19(v4.clone());
        let v6: Option<string> = File_system::method103(v4.clone());
        let v31_1: File_system::US5 =
            defaultValue(File_system::US5::US5_1, map(File_system::method5(), v6));
        let v36_1: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v48_1: () = {
            File_system::closure6(v36_1.clone(), v3, ());
            ()
        };
        let v54: string = v36_1.l0.get().clone();
        if (v2) >= 11_u8 {
            let v58: string = append(
                string("file_system.read_link / "),
                sprintf!(
                    "path: {} / n: {} / path\': {} / name: {}",
                    v0.clone(),
                    v2,
                    v4.clone(),
                    v5.clone()
                ),
            );
            let v65: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v58);
            Err(v65)
        } else {
            if let File_system::US5::US5_0(v31_1_0_0) = &v31_1 {
                if (v4.clone()) != string("") {
                    let v119: Result<std::path::PathBuf, std::io::Error> =
                        v1((v2) + 1_u8, v31_1_0_0.clone());
                    let v120 = File_system::method44();
                    let v133: Result<std::path::PathBuf, string> = v119.map_err(|x| v120(x));
                    let v136 = File_system::method99();
                    let v137 = File_system::method100();
                    let v139: File_system::US14 = match &v133 {
                        Err(v133_1_0) => v137(v133_1_0.clone()),
                        Ok(v133_0_0) => v136(v133_0_0.clone()),
                    };
                    match &v139 {
                        File_system::US14::US14_0(v139_0_0) => {
                            let v183: string = File_system::method79(
                                toString(v139_0_0.clone().display()),
                                v5.clone(),
                            );
                            let v190: &str = &*v183;
                            let v226: std::string::String = String::from(v190);
                            let v262: std::path::PathBuf = std::path::PathBuf::from(v226);
                            Ok(v262)
                        }
                        File_system::US14::US14_1(v139_1_0) => {
                            let v310: string = append(
                                string("file_system.read_link / "),
                                sprintf!(
                                    "error\': {} / error: {} / name: {}",
                                    v139_1_0.clone(),
                                    v54.clone(),
                                    v5.clone()
                                ),
                            );
                            let v317: std::io::Error =
                                std::io::Error::new(std::io::ErrorKind::Other, &*v310);
                            Err(v317)
                        }
                    }
                } else {
                    let v366: string = append(
                        string(
                            "file_system.read_link / run / The file or directory is not a reparse point. / ",
                        ),
                        sprintf!(
                            "path: {} / error: {} / path\': {} / name: {}",
                            v0.clone(),
                            v54.clone(),
                            v4.clone(),
                            v5.clone()
                        ),
                    );
                    let v373: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v366);
                    Err(v373)
                }
            } else {
                let v421: string = append(
                    string(
                        "file_system.read_link / run / The file or directory is not a reparse point. / ",
                    ),
                    sprintf!(
                        "path: {} / error: {} / path\': {} / name: {}",
                        v0,
                        v54.clone(),
                        v4,
                        v5.clone()
                    ),
                );
                let v428: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v421);
                Err(v428)
            }
        }
    }
    pub fn method101(v0: string, v1: u8, v2: string) -> Result<std::path::PathBuf, std::io::Error> {
        let v9: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v2.clone());
        let v10 = File_system::method44();
        let v23: Result<std::path::PathBuf, string> = v9.map_err(|x| v10(x));
        let v26 = File_system::method99();
        let v27 = File_system::method100();
        let v29: File_system::US14 = match &v23 {
            Err(v23_1_0) => v27(v23_1_0.clone()),
            Ok(v23_0_0) => v26(v23_0_0.clone()),
        };
        match &v29 {
            File_system::US14::US14_0(v29_0_0) => Ok(v29_0_0.clone()),
            File_system::US14::US14_1(v29_1_0) => File_system::method102(
                v0.clone(),
                Func2::new({
                    let v0 = v0.clone();
                    move |b0: u8, b1: string| {
                        (Func1::new({
                            let v0 = v0.clone();
                            move |v: u8| File_system::closure54(v0.clone(), v)
                        }))(b0)(b1)
                    }
                }),
                v1,
                v29_1_0.clone(),
                v2.clone(),
            ),
        }
    }
    pub fn closure55(v0: string, v1: u8, v2: string) -> Result<std::path::PathBuf, std::io::Error> {
        File_system::method101(v0, v1, v2)
    }
    pub fn closure54(
        v0: string,
        v1: u8,
    ) -> Func1<string, Result<std::path::PathBuf, std::io::Error>> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            move |v: string| File_system::closure55(v0.clone(), v1, v)
        })
    }
    pub fn method104(
        v0: string,
        v1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
        v2: u8,
        v3: string,
    ) -> Result<std::path::PathBuf, std::io::Error> {
        let v4: string = File_system::method19(v0.clone());
        let v5: Option<string> = File_system::method103(v0.clone());
        let v30: File_system::US5 =
            defaultValue(File_system::US5::US5_1, map(File_system::method5(), v5));
        let v35_1: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v47_1: () = {
            File_system::closure6(v35_1.clone(), v3, ());
            ()
        };
        let v53_1: string = v35_1.l0.get().clone();
        if (v2) >= 11_u8 {
            let v57: string = append(
                string("file_system.read_link / "),
                sprintf!(
                    "path: {} / n: {} / path\': {} / name: {}",
                    v0.clone(),
                    v2,
                    v0.clone(),
                    v4.clone()
                ),
            );
            let v64: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v57);
            Err(v64)
        } else {
            if let File_system::US5::US5_0(v30_0_0) = &v30 {
                if (v0.clone()) != string("") {
                    let v118: Result<std::path::PathBuf, std::io::Error> =
                        v1((v2) + 1_u8, v30_0_0.clone());
                    let v119 = File_system::method44();
                    let v132: Result<std::path::PathBuf, string> = v118.map_err(|x| v119(x));
                    let v135 = File_system::method99();
                    let v136 = File_system::method100();
                    let v138: File_system::US14 = match &v132 {
                        Err(v132_1_0) => v136(v132_1_0.clone()),
                        Ok(v132_0_0) => v135(v132_0_0.clone()),
                    };
                    match &v138 {
                        File_system::US14::US14_0(v138_0_0) => {
                            let v182: string = File_system::method79(
                                toString(v138_0_0.clone().display()),
                                v4.clone(),
                            );
                            let v189: &str = &*v182;
                            let v225: std::string::String = String::from(v189);
                            let v261: std::path::PathBuf = std::path::PathBuf::from(v225);
                            Ok(v261)
                        }
                        File_system::US14::US14_1(v138_1_0) => {
                            let v309: string = append(
                                string("file_system.read_link / "),
                                sprintf!(
                                    "error\': {} / error: {} / name: {}",
                                    v138_1_0.clone(),
                                    v53_1.clone(),
                                    v4.clone()
                                ),
                            );
                            let v316: std::io::Error =
                                std::io::Error::new(std::io::ErrorKind::Other, &*v309);
                            Err(v316)
                        }
                    }
                } else {
                    let v365: string = append(
                        string(
                            "file_system.read_link / run / The file or directory is not a reparse point. / ",
                        ),
                        sprintf!(
                            "path: {} / error: {} / path\': {} / name: {}",
                            v0.clone(),
                            v53_1.clone(),
                            v0.clone(),
                            v4.clone()
                        ),
                    );
                    let v372: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v365);
                    Err(v372)
                }
            } else {
                let v420: string = append(
                    string(
                        "file_system.read_link / run / The file or directory is not a reparse point. / ",
                    ),
                    sprintf!(
                        "path: {} / error: {} / path\': {} / name: {}",
                        v0.clone(),
                        v53_1.clone(),
                        v0,
                        v4.clone()
                    ),
                );
                let v427: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v420);
                Err(v427)
            }
        }
    }
    pub fn method98(v0: string, v1: u8) -> Result<std::path::PathBuf, std::io::Error> {
        let v8: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v0.clone());
        let v9 = File_system::method44();
        let v22: Result<std::path::PathBuf, string> = v8.map_err(|x| v9(x));
        let v25 = File_system::method99();
        let v26 = File_system::method100();
        let v28: File_system::US14 = match &v22 {
            Err(v22_1_0) => v26(v22_1_0.clone()),
            Ok(v22_0_0) => v25(v22_0_0.clone()),
        };
        match &v28 {
            File_system::US14::US14_0(v28_0_0) => Ok(v28_0_0.clone()),
            File_system::US14::US14_1(v28_1_0) => File_system::method104(
                v0.clone(),
                Func2::new({
                    let v0 = v0.clone();
                    move |b0: u8, b1: string| {
                        (Func1::new({
                            let v0 = v0.clone();
                            move |v: u8| File_system::closure54(v0.clone(), v)
                        }))(b0)(b1)
                    }
                }),
                v1,
                v28_1_0.clone(),
            ),
        }
    }
    pub fn method106(v0: bool) -> i32 {
        unbox::<i32>(fable_library_rust::Native_::getZero())
    }
    pub fn method107() -> i32 {
        unbox::<i32>(fable_library_rust::Native_::getZero())
    }
    pub fn method108(v0: i32, v1: i32) -> bool {
        unbox::<bool>(fable_library_rust::Native_::getZero())
    }
    pub fn method110(
        v0: string,
        v1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
        v2: u8,
        v3: std::io::Error,
        v4: string,
    ) -> Result<std::path::PathBuf, std::io::Error> {
        let v5: string = File_system::method19(v4.clone());
        let v6: Option<string> = File_system::method103(v4.clone());
        let v31_1: File_system::US5 =
            defaultValue(File_system::US5::US5_1, map(File_system::method5(), v6));
        let v36_1: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v43_1: std::string::String = format!("{:#?}", v3);
        let v90: () = {
            File_system::closure6(
                v36_1.clone(),
                fable_library_rust::String_::fromString(v43_1),
                (),
            );
            ()
        };
        let v96: string = v36_1.l0.get().clone();
        if (v2) >= 11_u8 {
            let v100: string = append(
                string("file_system.read_link / "),
                sprintf!(
                    "path: {} / n: {} / path\': {} / name: {}",
                    v0.clone(),
                    v2,
                    v4.clone(),
                    v5.clone()
                ),
            );
            let v107: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v100);
            Err(v107)
        } else {
            if let File_system::US5::US5_0(v31_1_0_0) = &v31_1 {
                if (v4.clone()) != string("") {
                    let v161: Result<std::path::PathBuf, std::io::Error> =
                        v1((v2) + 1_u8, v31_1_0_0.clone());
                    let v162 = File_system::method44();
                    let v175: Result<std::path::PathBuf, string> = v161.map_err(|x| v162(x));
                    let v178 = File_system::method99();
                    let v179 = File_system::method100();
                    let v181: File_system::US14 = match &v175 {
                        Err(v175_1_0) => v179(v175_1_0.clone()),
                        Ok(v175_0_0) => v178(v175_0_0.clone()),
                    };
                    match &v181 {
                        File_system::US14::US14_0(v181_0_0) => {
                            let v225: string = File_system::method79(
                                toString(v181_0_0.clone().display()),
                                v5.clone(),
                            );
                            let v232: &str = &*v225;
                            let v268: std::string::String = String::from(v232);
                            let v304: std::path::PathBuf = std::path::PathBuf::from(v268);
                            Ok(v304)
                        }
                        File_system::US14::US14_1(v181_1_0) => {
                            let v352: string = append(
                                string("file_system.read_link / "),
                                sprintf!(
                                    "error\': {} / error: {} / name: {}",
                                    v181_1_0.clone(),
                                    v96.clone(),
                                    v5.clone()
                                ),
                            );
                            let v359: std::io::Error =
                                std::io::Error::new(std::io::ErrorKind::Other, &*v352);
                            Err(v359)
                        }
                    }
                } else {
                    let v408: string = append(
                        string(
                            "file_system.read_link / run / The file or directory is not a reparse point. / ",
                        ),
                        sprintf!(
                            "path: {} / error: {} / path\': {} / name: {}",
                            v0.clone(),
                            v96.clone(),
                            v4.clone(),
                            v5.clone()
                        ),
                    );
                    let v415: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v408);
                    Err(v415)
                }
            } else {
                let v463: string = append(
                    string(
                        "file_system.read_link / run / The file or directory is not a reparse point. / ",
                    ),
                    sprintf!(
                        "path: {} / error: {} / path\': {} / name: {}",
                        v0,
                        v96.clone(),
                        v4,
                        v5.clone()
                    ),
                );
                let v470: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v463);
                Err(v470)
            }
        }
    }
    pub fn method109(v0: string, v1: u8, v2: string) -> Result<std::path::PathBuf, std::io::Error> {
        let v45_1: i32 =
            File_system::method106(unbox::<bool>(fable_library_rust::Native_::getZero()));
        let v47_1: bool = File_system::method108(File_system::method107(), v45_1);
        if v47_1 {
            let v54: bool = unbox::<bool>(fable_library_rust::Native_::getZero());
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
            File_system::method110(
                v0.clone(),
                Func2::new({
                    let v0 = v0.clone();
                    move |b0: u8, b1: string| {
                        (Func1::new({
                            let v0 = v0.clone();
                            move |v: u8| File_system::closure56(v0.clone(), v)
                        }))(b0)(b1)
                    }
                }),
                v1,
                std::io::Error::new(std::io::ErrorKind::Other, &*v153),
                v2,
            )
        }
    }
    pub fn closure57(v0: string, v1: u8, v2: string) -> Result<std::path::PathBuf, std::io::Error> {
        File_system::method109(v0, v1, v2)
    }
    pub fn closure56(
        v0: string,
        v1: u8,
    ) -> Func1<string, Result<std::path::PathBuf, std::io::Error>> {
        Func1::new({
            let v0 = v0.clone();
            let v1 = v1.clone();
            move |v: string| File_system::closure57(v0.clone(), v1, v)
        })
    }
    pub fn method111(
        v0: string,
        v1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
        v2: u8,
        v3: std::io::Error,
    ) -> Result<std::path::PathBuf, std::io::Error> {
        let v4: string = File_system::method19(v0.clone());
        let v5: Option<string> = File_system::method103(v0.clone());
        let v30: File_system::US5 =
            defaultValue(File_system::US5::US5_1, map(File_system::method5(), v5));
        let v35_1: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v42_1: std::string::String = format!("{:#?}", v3);
        let v89: () = {
            File_system::closure6(
                v35_1.clone(),
                fable_library_rust::String_::fromString(v42_1),
                (),
            );
            ()
        };
        let v95: string = v35_1.l0.get().clone();
        if (v2) >= 11_u8 {
            let v99: string = append(
                string("file_system.read_link / "),
                sprintf!(
                    "path: {} / n: {} / path\': {} / name: {}",
                    v0.clone(),
                    v2,
                    v0.clone(),
                    v4.clone()
                ),
            );
            let v106: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v99);
            Err(v106)
        } else {
            if let File_system::US5::US5_0(v30_0_0) = &v30 {
                if (v0.clone()) != string("") {
                    let v160: Result<std::path::PathBuf, std::io::Error> =
                        v1((v2) + 1_u8, v30_0_0.clone());
                    let v161 = File_system::method44();
                    let v174: Result<std::path::PathBuf, string> = v160.map_err(|x| v161(x));
                    let v177 = File_system::method99();
                    let v178 = File_system::method100();
                    let v180: File_system::US14 = match &v174 {
                        Err(v174_1_0) => v178(v174_1_0.clone()),
                        Ok(v174_0_0) => v177(v174_0_0.clone()),
                    };
                    match &v180 {
                        File_system::US14::US14_0(v180_0_0) => {
                            let v224: string = File_system::method79(
                                toString(v180_0_0.clone().display()),
                                v4.clone(),
                            );
                            let v231: &str = &*v224;
                            let v267: std::string::String = String::from(v231);
                            let v303: std::path::PathBuf = std::path::PathBuf::from(v267);
                            Ok(v303)
                        }
                        File_system::US14::US14_1(v180_1_0) => {
                            let v351: string = append(
                                string("file_system.read_link / "),
                                sprintf!(
                                    "error\': {} / error: {} / name: {}",
                                    v180_1_0.clone(),
                                    v95.clone(),
                                    v4.clone()
                                ),
                            );
                            let v358: std::io::Error =
                                std::io::Error::new(std::io::ErrorKind::Other, &*v351);
                            Err(v358)
                        }
                    }
                } else {
                    let v407: string = append(
                        string(
                            "file_system.read_link / run / The file or directory is not a reparse point. / ",
                        ),
                        sprintf!(
                            "path: {} / error: {} / path\': {} / name: {}",
                            v0.clone(),
                            v95.clone(),
                            v0.clone(),
                            v4.clone()
                        ),
                    );
                    let v414: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v407);
                    Err(v414)
                }
            } else {
                let v462: string = append(
                    string(
                        "file_system.read_link / run / The file or directory is not a reparse point. / ",
                    ),
                    sprintf!(
                        "path: {} / error: {} / path\': {} / name: {}",
                        v0.clone(),
                        v95.clone(),
                        v0,
                        v4.clone()
                    ),
                );
                let v469: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v462);
                Err(v469)
            }
        }
    }
    pub fn method105(v0: string, v1: u8) -> Result<std::path::PathBuf, std::io::Error> {
        let v44_1: i32 =
            File_system::method106(unbox::<bool>(fable_library_rust::Native_::getZero()));
        let v46_1: bool = File_system::method108(File_system::method107(), v44_1);
        if v46_1 {
            let v53_1: bool = unbox::<bool>(fable_library_rust::Native_::getZero());
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
            File_system::method111(
                v0.clone(),
                Func2::new({
                    let v0 = v0.clone();
                    move |b0: u8, b1: string| {
                        (Func1::new({
                            let v0 = v0.clone();
                            move |v: u8| File_system::closure56(v0.clone(), v)
                        }))(b0)(b1)
                    }
                }),
                v1,
                std::io::Error::new(std::io::ErrorKind::Other, &*v152),
            )
        }
    }
    pub fn method97(v0: string) -> Result<std::path::PathBuf, std::io::Error> {
        if File_system::method10(v0.clone()) {
            std::fs::read_link(&*v0.clone())
        } else {
            File_system::method98(v0, 0_u8)
        }
    }
    pub fn closure58(unitVar: (), v0: std::path::PathBuf) -> File_system::US15 {
        File_system::US15::US15_0(v0)
    }
    pub fn method112() -> Func1<std::path::PathBuf, File_system::US15> {
        Func1::new(move |v: std::path::PathBuf| File_system::closure58((), v))
    }
    pub fn method114(v0: string) -> string {
        v0
    }
    pub fn method115() -> string {
        string("")
    }
    pub fn method113(v0: string, v1: string, v2: string) -> string {
        let v6: Result<regex::Regex, regex::Error> = regex::Regex::new(&v0);
        let v10: regex::Regex = v6.unwrap();
        let v22: string = File_system::method114(v2);
        let v24: std::borrow::Cow<str> = v10.replace_all(&*v22, &*v1);
        let v26: std::string::String = String::from(v24);
        fable_library_rust::String_::fromString(v26)
    }
    pub fn method96(v0: string) -> string {
        if (v0.clone()) == string("") {
            string("")
        } else {
            let v3: Result<std::path::PathBuf, std::io::Error> = File_system::method97(v0.clone());
            let v7: Option<std::path::PathBuf> = v3.ok();
            let v43_1: File_system::US15 =
                defaultValue(File_system::US15::US15_1, map(File_system::method112(), v7));
            let v89: string = match &v43_1 {
                File_system::US15::US15_0(v43_1_0_0) => toString(
                    match &v43_1 {
                        File_system::US15::US15_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone()
                    .display(),
                ),
                _ => v0.clone(),
            };
            let v94: string = File_system::method113(
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
    pub fn closure51(unitVar: (), v0: string) -> string {
        File_system::method96(v0)
    }
    pub fn method117() -> string {
        let v6: Result<std::path::PathBuf, std::io::Error> = std::env::current_dir();
        let v10: std::path::PathBuf = v6.unwrap();
        let v28: std::path::Display = v10.display();
        let v64: std::string::String = format!("{}", v28);
        fable_library_rust::String_::fromString(v64)
    }
    pub fn method118(v0: i32, v1: LrcPtr<File_system::Mut5>) -> bool {
        (v1.l0.get().clone()) < (v0)
    }
    pub fn method119(v0: i32, v1: LrcPtr<File_system::Mut6>) -> bool {
        (v1.l0.get().clone()) < (v0)
    }
    pub fn method120() -> char {
        std::path::MAIN_SEPARATOR
    }
    pub fn method121(v0: string) -> string {
        v0
    }
    pub fn method116(v0: string) -> string {
        let v12: &str = &*v0.clone();
        let v48_1: std::string::String = String::from(v12);
        let v84: std::path::PathBuf = std::path::PathBuf::from(v48_1);
        if (v84.exists()) == false {
            let v117: string = File_system::method117();
            let v128: Array<string> = split(
                File_system::method96(File_system::method79(v117.clone(), v0.clone())),
                string("/"),
                -1_i32,
                0_i32,
            );
            let v132: i32 = get_Count(v128.clone());
            let v133: LrcPtr<File_system::Mut5> = LrcPtr::new(File_system::Mut5 {
                l0: MutCell::new(0_i32),
                l1: MutCell::new(0_i32),
                l2: MutCell::new(new_empty::<string>()),
            });
            while File_system::method118(v132, v133.clone()) {
                let v135: i32 = v133.l0.get().clone();
                let v138: i32 = ((v135.wrapping_neg()) + (v132)) - 1_i32;
                let matchValue: i32 = v133.l1.get().clone();
                let v140: Array<string> = v133.l2.get().clone();
                let v139: i32 = matchValue;
                let v141: string = v128[v138].clone();
                let patternInput_1: (i32, Array<string>) = if string("..") == (v141.clone()) {
                    ((v139) + 1_i32, v140.clone())
                } else {
                    if string(".") == (v141.clone()) {
                        (v139, v140.clone())
                    } else {
                        if 0_i32 == (v139) {
                            if endsWith3(v141.clone(), string(":"), false) {
                                let v153: Array<string> =
                                    new_array(&[sprintf!("{}:", getCharAt(v117.clone(), 0_i32))]);
                                let v154: i32 = get_Count(v153.clone());
                                let v156: i32 = (v154) + (get_Count(v140.clone()));
                                let v157: Array<string> = new_init(&string(""), v156);
                                let v158: LrcPtr<File_system::Mut6> =
                                    LrcPtr::new(File_system::Mut6 {
                                        l0: MutCell::new(0_i32),
                                    });
                                while File_system::method119(v156, v158.clone()) {
                                    let v160: i32 = v158.l0.get().clone();
                                    let v165: string = if (v160) < (v154) {
                                        v153[v160].clone()
                                    } else {
                                        let v163: i32 = (v160) - (v154);
                                        v140[v163].clone()
                                    };
                                    v157.get_mut()[v160 as usize] = v165;
                                    {
                                        let v166: i32 = (v160) + 1_i32;
                                        v158.l0.set(v166);
                                        ()
                                    }
                                }
                                (0_i32, v157.clone())
                            } else {
                                let v167: Array<string> = new_array(&[v141]);
                                let v168: i32 = get_Count(v167.clone());
                                let v170: i32 = (v168) + (get_Count(v140.clone()));
                                let v171: Array<string> = new_init(&string(""), v170);
                                let v172: LrcPtr<File_system::Mut6> =
                                    LrcPtr::new(File_system::Mut6 {
                                        l0: MutCell::new(0_i32),
                                    });
                                while File_system::method119(v170, v172.clone()) {
                                    let v174: i32 = v172.l0.get().clone();
                                    let v179: string = if (v174) < (v168) {
                                        v167[v174].clone()
                                    } else {
                                        let v177: i32 = (v174) - (v168);
                                        v140[v177].clone()
                                    };
                                    v171.get_mut()[v174 as usize] = v179;
                                    {
                                        let v180: i32 = (v174) + 1_i32;
                                        v172.l0.set(v180);
                                        ()
                                    }
                                }
                                (0_i32, v171.clone())
                            }
                        } else {
                            ((v139) - 1_i32, v140.clone())
                        }
                    }
                };
                let v190: i32 = (v135) + 1_i32;
                v133.l0.set(v190);
                v133.l1.set(patternInput_1.0.clone());
                v133.l2.set(patternInput_1.1.clone());
                ()
            }
            {
                let matchValue_2: i32 = v133.l1.get().clone();
                let v192: Array<string> = v133.l2.get().clone();
                let _let__v197: LrcPtr<dyn IEnumerable_1<string>> = delay(Func0::new({
                    let v192 = v192.clone();
                    move || {
                        map_1(
                            Func1::new({
                                let v192 = v192.clone();
                                move |i: i32| v192[i].clone()
                            }),
                            rangeNumeric(0_i32, 1_i32, (get_Count(v192.clone())) - 1_i32),
                        )
                    }
                }));
                let v209: string = ofChar(File_system::method120());
                join(
                    if (v209.clone()) == string("\n") {
                        File_system::method121(v209.clone())
                    } else {
                        v209
                    },
                    toArray_1(_let__v197),
                )
            }
        } else {
            let v222: Result<std::path::PathBuf, std::io::Error> = std::fs::canonicalize(&*v0);
            let v226: std::path::PathBuf = v222.unwrap();
            let v244: std::path::Display = v226.display();
            let v280: std::string::String = format!("{}", v244);
            fable_library_rust::String_::fromString(v280)
        }
    }
    pub fn closure59(unitVar: (), v0: string) -> string {
        File_system::method116(v0)
    }
    pub fn method122(v0: string) -> string {
        File_system::method96(File_system::method116(v0))
    }
    pub fn closure60(unitVar: (), v0: string) -> string {
        File_system::method122(v0)
    }
    pub fn closure61(unitVar: (), v0: string) -> string {
        concat(new_array(&[
            string("file:///"),
            trimStartChars(v0, toArray(singleton('/'))),
        ]))
    }
    pub fn closure63(unitVar: (), v0: string) -> bool {
        File_system::method34(v0)
    }
    pub fn closure64(unitVar: (), v0: string) -> bool {
        File_system::method10(v0)
    }
    pub fn method126(
        v0: string,
        v1: string,
        v2: bool,
        v3: Func1<string, bool>,
        v4: string,
    ) -> File_system::US17 {
        let v0: MutCell<string> = MutCell::new(v0.clone());
        let v1: MutCell<string> = MutCell::new(v1.clone());
        let v2: MutCell<bool> = MutCell::new(v2);
        let v3 = MutCell::new(v3.clone());
        let v4: MutCell<string> = MutCell::new(v4.clone());
        '_method126: loop {
            break '_method126 (if v3(File_system::method79(v4.get().clone(), v0.get().clone())) {
                File_system::US17::US17_0(v4.get().clone())
            } else {
                let v8: Option<string> = File_system::method103(v4.get().clone());
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
                        continue '_method126;
                    }
                    _ => File_system::US17::US17_1(append(
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
    pub fn method125(
        v0: string,
        v1: string,
        v2: bool,
        v3: Func1<string, bool>,
    ) -> File_system::US17 {
        if v3(File_system::method79(v1.clone(), v0.clone())) {
            File_system::US17::US17_0(v1.clone())
        } else {
            let v7: Option<string> = File_system::method103(v1.clone());
            let v32_1: File_system::US5 =
                defaultValue(File_system::US5::US5_1, map(File_system::method5(), v7));
            match &v32_1 {
                File_system::US5::US5_0(v32_1_0_0) => File_system::method126(
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
                _ => File_system::US17::US17_1(append(
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
    pub fn method124(v0: File_system::US16, v1: string, v2: string) -> File_system::US17 {
        let v3: bool = if let File_system::US16::US16_0 = &v0 {
            true
        } else {
            false
        };
        File_system::method125(
            v1,
            v2,
            v3,
            if v3 {
                Func1::new(move |v: string| File_system::closure63((), v))
            } else {
                Func1::new(move |v_1: string| File_system::closure64((), v_1))
            },
        )
    }
    pub fn method127(
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
        let v11: LrcPtr<File_system::Mut3> = LrcPtr::new(File_system::Mut3 {
            l0: MutCell::new(File_system::method17()),
        });
        let v25: () = {
            File_system::closure6(v11.clone(), string("{ "), ());
            ()
        };
        let v44_1: () = {
            File_system::closure6(v11.clone(), string("dir"), ());
            ()
        };
        let v63: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v80: () = {
            File_system::closure6(v11.clone(), v8, ());
            ()
        };
        let v99: () = {
            File_system::closure6(v11.clone(), string("; "), ());
            ()
        };
        let v118: () = {
            File_system::closure6(v11.clone(), string("error"), ());
            ()
        };
        let v135: () = {
            File_system::closure6(v11.clone(), string(" = "), ());
            ()
        };
        let v152: () = {
            File_system::closure6(v11.clone(), v9, ());
            ()
        };
        let v171: () = {
            File_system::closure6(v11.clone(), string(" }"), ());
            ()
        };
        let v177: string = v11.l0.get().clone();
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
            (v177),
        ))
    }
    pub fn closure65(v0: string, v1: string, unitVar: ()) {
        if File_system::method11(File_system::US0::US0_3) {
            let v20: () = {
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
            let v46_1: Option<i64> = patternInput.5.clone();
            let v45_1: LrcPtr<File_system::Mut4> = patternInput.4.clone();
            let v44_1: LrcPtr<File_system::Mut3> = patternInput.3.clone();
            let v43_1: LrcPtr<File_system::Mut2> = patternInput.2.clone();
            let v42_1: LrcPtr<File_system::Mut1> = patternInput.1.clone();
            let v41_1: LrcPtr<File_system::Mut0> = patternInput.0.clone();
            File_system::method22(File_system::method127(
                v41_1.clone(),
                v42_1.clone(),
                v43_1.clone(),
                v44_1.clone(),
                v45_1.clone(),
                v46_1.clone(),
                File_system::method12(v41_1, v42_1, v43_1, v44_1, v45_1, v46_1),
                File_system::method49(),
                v0,
                v1,
            ))
        };
    }
    pub fn method123(v0: string) -> File_system::US5 {
        let v5: File_system::US17 = File_system::method124(
            File_system::US16::US16_1,
            File_system::method79(string("spiral"), string("workspace")),
            v0.clone(),
        );
        match &v5 {
            File_system::US17::US17_0(v5_0_0) => {
                File_system::US5::US5_0(File_system::method96(v5_0_0.clone()))
            }
            File_system::US17::US17_1(v5_1_0) => {
                let v72: () = {
                    File_system::closure65(v0.clone(), v5_1_0.clone(), ());
                    ()
                };
                File_system::US5::US5_1
            }
        }
    }
    pub fn closure62(unitVar: (), unitVar_1: ()) -> string {
        let v1: File_system::US5 = File_system::method123(File_system::method117());
        let v7: File_system::US5 = match &v1 {
            File_system::US5::US5_0(v1_0_0) => File_system::US5::US5_0(
                match &v1 {
                    File_system::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
            ),
            _ => File_system::method123(string(
                "/home/runner/work/spiral/polyglot/deps/spiral/lib/spiral",
            )),
        };
        let v13: File_system::US5 = match &v7 {
            File_system::US5::US5_0(v7_0_0) => File_system::US5::US5_0(
                match &v7 {
                    File_system::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
            ),
            _ => File_system::method123(string("/workspaces")),
        };
        let v17: string = match &v13 {
            File_system::US5::US5_0(v13_0_0) => match &v13 {
                File_system::US5::US5_0(x) => x.clone(),
                _ => unreachable!(),
            }
            .clone(),
            _ => panic!("{}", string("Option does not have a value."),),
        };
        File_system::method79(
            if string("deps") == (File_system::method19(v17.clone())) {
                let v25: File_system::US5 =
                    File_system::method123(File_system::method103(v17.clone()).clone().unwrap());
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
    pub fn closure67(v0: LrcPtr<Exception>, unitVar: ()) -> LrcPtr<Exception> {
        v0
    }
    pub fn method128(v0: string) {
        ();
    }
    pub fn closure66(unitVar: (), v0: string) {
        File_system::method128(v0);
    }
    pub fn closure68(unitVar: (), v0: bool) {
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
        let v58 = if v0 {
            Func1::new(move |v: string| File_system::closure66((), v))
        } else {
            Func1::new(move |v_1: string| File_system::closure2((), v_1))
        };
        (patternInput.1.clone()).l0.set(v58);
        ()
    }
    pub fn method129(v0: string, v1: string) {
        if (File_system::method10(v0.clone())) == false {
            let v4: LrcPtr<dyn IDisposable> = File_system::method82(v0.clone());
            ()
        }
        {
            let v9: string = defaultValue(string(""), File_system::method103(v1.clone()));
            if (File_system::method10(v9.clone())) == false {
                let v14_1: LrcPtr<dyn IDisposable> = File_system::method82(v9);
                ()
            }
            if if File_system::method10(v1.clone()) {
                let v16_1: Result<std::path::PathBuf, std::io::Error> =
                    File_system::method97(v1.clone());
                v16_1.is_err()
            } else {
                false
            } {
                File_system::method9(true, v1.clone());
            }
            if (File_system::method10(v1.clone())) == false {
                let v31_1: bool = true;
                #[cfg(windows)]
                std::os::windows::fs::symlink_dir(&*v0.clone(), &*v1.clone()).unwrap();
                let v33_1: bool = true;
                #[cfg(unix)]
                std::os::unix::fs::symlink(&*v0, &*v1).unwrap();
                ()
            }
        }
    }
    pub fn closure70(v0: string, v1: string) {
        File_system::method129(v0, v1);
    }
    pub fn closure69(unitVar: (), v0: string) -> Func1<string, ()> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure70(v0.clone(), v)
        })
    }
    pub fn closure72(v0: string, v1: string) -> string {
        File_system::method79(v0, v1)
    }
    pub fn closure71(unitVar: (), v0: string) -> Func1<string, string> {
        Func1::new({
            let v0 = v0.clone();
            move |v: string| File_system::closure72(v0.clone(), v)
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
    pub fn v32() -> Func1<File_system::US6, Func1<string, Arc<Async<i64>>>> {
        static v32: OnceInit<Func1<File_system::US6, Func1<string, Arc<Async<i64>>>>> =
            OnceInit::new();
        v32.get_or_init(|| Func1::new(move |v: File_system::US6| File_system::closure10((), v)))
            .clone()
    }
    pub fn wait_for_file_access(x: File_system::US6) -> Func1<string, Arc<Async<i64>>> {
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
        v41.get_or_init(|| Func0::new(move || File_system::closure37((), ())))
            .clone()
    }
    pub fn create_temp_path() -> string {
        (File_system::v41())()
    }
    pub fn v42() -> Func0<(string, LrcPtr<dyn IDisposable>)> {
        static v42: OnceInit<Func0<(string, LrcPtr<dyn IDisposable>)>> = OnceInit::new();
        v42.get_or_init(|| Func0::new(move || File_system::closure39((), ())))
            .clone()
    }
    pub fn create_temp_dir() -> (string, LrcPtr<dyn IDisposable>) {
        (File_system::v42())()
    }
    pub fn v43() -> Func1<string, (string, LrcPtr<dyn IDisposable>)> {
        static v43: OnceInit<Func1<string, (string, LrcPtr<dyn IDisposable>)>> = OnceInit::new();
        v43.get_or_init(|| Func1::new(move |v: string| File_system::closure48((), v)))
            .clone()
    }
    pub fn create_temp_dir_(x: string) -> (string, LrcPtr<dyn IDisposable>) {
        (File_system::v43())(x)
    }
    pub fn v44() -> Func0<string> {
        static v44: OnceInit<Func0<string>> = OnceInit::new();
        v44.get_or_init(|| Func0::new(move || File_system::closure50((), ())))
            .clone()
    }
    pub fn get_source_directory() -> string {
        (File_system::v44())()
    }
    pub fn v45() -> Func1<string, string> {
        static v45: OnceInit<Func1<string, string>> = OnceInit::new();
        v45.get_or_init(|| Func1::new(move |v: string| File_system::closure51((), v)))
            .clone()
    }
    pub fn normalize_path(x: string) -> string {
        (File_system::v45())(x)
    }
    pub fn v46() -> Func1<string, string> {
        static v46: OnceInit<Func1<string, string>> = OnceInit::new();
        v46.get_or_init(|| Func1::new(move |v: string| File_system::closure59((), v)))
            .clone()
    }
    pub fn get_full_path(x: string) -> string {
        (File_system::v46())(x)
    }
    pub fn v47() -> Func1<string, string> {
        static v47: OnceInit<Func1<string, string>> = OnceInit::new();
        v47.get_or_init(|| Func1::new(move |v: string| File_system::closure60((), v)))
            .clone()
    }
    pub fn standardize_path(x: string) -> string {
        (File_system::v47())(x)
    }
    pub fn v48() -> Func1<string, string> {
        static v48: OnceInit<Func1<string, string>> = OnceInit::new();
        v48.get_or_init(|| Func1::new(move |v: string| File_system::closure61((), v)))
            .clone()
    }
    pub fn new_file_uri(x: string) -> string {
        (File_system::v48())(x)
    }
    pub fn v49() -> Func0<string> {
        static v49: OnceInit<Func0<string>> = OnceInit::new();
        v49.get_or_init(|| Func0::new(move || File_system::closure62((), ())))
            .clone()
    }
    pub fn get_workspace_root() -> string {
        (File_system::v49())()
    }
    pub fn v50() -> Func1<string, ()> {
        static v50: OnceInit<Func1<string, ()>> = OnceInit::new();
        v50.get_or_init(|| Func1::new(move |v: string| File_system::closure66((), v)))
            .clone()
    }
    pub fn trace_file(x: string) {
        (File_system::v50())(x);
    }
    pub fn v51() -> Func1<bool, ()> {
        static v51: OnceInit<Func1<bool, ()>> = OnceInit::new();
        v51.get_or_init(|| Func1::new(move |v: bool| File_system::closure68((), v)))
            .clone()
    }
    pub fn init_trace_file(x: bool) {
        (File_system::v51())(x);
    }
    pub fn v52() -> Func1<string, Func1<string, ()>> {
        static v52: OnceInit<Func1<string, Func1<string, ()>>> = OnceInit::new();
        v52.get_or_init(|| Func1::new(move |v: string| File_system::closure69((), v)))
            .clone()
    }
    pub fn link_directory(x: string) -> Func1<string, ()> {
        (File_system::v52())(x)
    }
    pub fn v53() -> Func1<string, Func1<string, string>> {
        static v53: OnceInit<Func1<string, Func1<string, string>>> = OnceInit::new();
        v53.get_or_init(|| Func1::new(move |v: string| File_system::closure71((), v)))
            .clone()
    }
    pub fn op_LessDivideGreater(x: string) -> Func1<string, string> {
        (File_system::v53())(x)
    }
    on_startup!(());
}
