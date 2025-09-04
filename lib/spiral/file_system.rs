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
    use fable_library_rust::String_::contains;
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
        US13_0(chrono::DateTime<chrono::Utc>),
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
        let v241: File_system::US2 =
            defaultValue(File_system::US2::US2_1, map(File_system::method12(), v5));
        let v395: DateTime = match &v241 {
            File_system::US2::US2_0(v241_0_0) => {
                let v324: TimeSpan = TimeSpan::new_ticks(
                    ({
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    }) - (match &v241 {
                        File_system::US2::US2_0(x) => x.clone(),
                        _ => unreachable!(),
                    }),
                );
                DateTime::new_ymdhms_milli(
                    1_i32,
                    1_i32,
                    1_i32,
                    v324.hours(),
                    v324.minutes(),
                    v324.seconds(),
                    v324.milliseconds(),
                )
            }
            _ => DateTime::now(),
        };
        let v396: string = File_system::method13();
        let provider: string = if (v396.clone()) == string("") {
            string("M-d-y hh:mm:ss tt")
        } else {
            v396
        };
        v395.toString(provider)
    }
    pub fn method17() -> string {
        string("")
    }
    pub fn closure6(v0: LrcPtr<File_system::Mut3>, v1: string, unitVar: ()) {
        let v4: string = append(v0.l0.get().clone(), v1);
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
        let v3: &str = inline_colorization::color_bright_blue;
        let v10: std::string::String = String::from(v3);
        let v139: string = append(
            fable_library_rust::String_::fromString(v10),
            File_system::method16(getCharAt(toLower(string("Debug")), 0_i32)),
        );
        let v145: &str = inline_colorization::color_reset;
        let v152: std::string::String = String::from(v145);
        append(v139, fable_library_rust::String_::fromString(v152))
    }
    pub fn method18(v0: string) -> string {
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
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("file_system.delete_directory_async"),
                ),
                string(" / "),
            ),
            v10,
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
            let v205: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v204: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v226: () = {
                File_system::closure7(v204.clone(), ());
                ()
            };
            println!("{}", v165.clone());
            (v205.l0.get().clone())(v165);
            File_system::US6::US6_0(
                v204,
                v205,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
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
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("file_system.wait_for_file_access"),
                ),
                string(" / "),
            ),
            v11,
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
            let v206: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v205: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v227: () = {
                File_system::closure7(v205.clone(), ());
                ()
            };
            println!("{}", v166.clone());
            (v206.l0.get().clone())(v166);
            File_system::US6::US6_0(
                v205,
                v206,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
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
        let v3: &str = inline_colorization::color_bright_black;
        let v10: std::string::String = String::from(v3);
        let v139: string = append(
            fable_library_rust::String_::fromString(v10),
            File_system::method16(getCharAt(toLower(string("Verbose")), 0_i32)),
        );
        let v145: &str = inline_colorization::color_reset;
        let v152: std::string::String = String::from(v145);
        append(v139, fable_library_rust::String_::fromString(v152))
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
        let v213: std::string::String = format!("{:#?}", v2);
        let v260: () = {
            File_system::closure6(
                v4.clone(),
                fable_library_rust::String_::fromString(v213),
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
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("file_system.read_all_text_async"),
                ),
                string(" / "),
            ),
            v11,
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
            let v166: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v165: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v187: () = {
                File_system::closure7(v165.clone(), ());
                ()
            };
            println!("{}", v126.clone());
            (v166.l0.get().clone())(v126);
            File_system::US6::US6_0(
                v165,
                v166,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
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
        let v12: &str = &*v0;
        let v48_1: std::string::String = String::from(v12);
        let v105: std::path::PathBuf = std::path::PathBuf::from(v48_1);
        if v105.clone().exists() {
            v105.is_file()
        } else {
            false
        }
    }
    pub fn method36(v0: Vec<u8>) -> Vec<u8> {
        v0
    }
    pub fn method34(v0: string, v1: string) -> bool {
        if (File_system::method35(v0.clone())) == false {
            false
        } else {
            let v20: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v0);
            let v68: Vec<u8> = File_system::method36(v20.unwrap());
            let v70: Result<std::string::String, std::string::FromUtf8Error> =
                std::string::String::from_utf8(v68);
            let v74: std::string::String = v70.unwrap();
            (v1) == (fable_library_rust::String_::fromString(v74))
        }
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
        let v9: std::string::String = format!("{:#?}", v0);
        let v56: () = {
            File_system::closure6(v2.clone(), fable_library_rust::String_::fromString(v9), ());
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
        let v3: &str = inline_colorization::color_bright_red;
        let v10: std::string::String = String::from(v3);
        let v139: string = append(
            fable_library_rust::String_::fromString(v10),
            File_system::method16(getCharAt(toLower(string("Critical")), 0_i32)),
        );
        let v145: &str = inline_colorization::color_reset;
        let v152: std::string::String = String::from(v145);
        append(v139, fable_library_rust::String_::fromString(v152))
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
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("file_system.file_delete"),
                ),
                string(" / "),
            ),
            v9,
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
            let v164: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v163: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v185: () = {
                File_system::closure7(v163.clone(), ());
                ()
            };
            println!("{}", v124.clone());
            (v164.l0.get().clone())(v124);
            File_system::US6::US6_0(
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
    pub fn method52() -> string {
        let v3: &str = inline_colorization::color_yellow;
        let v10: std::string::String = String::from(v3);
        let v139: string = append(
            fable_library_rust::String_::fromString(v10),
            File_system::method16(getCharAt(toLower(string("Warning")), 0_i32)),
        );
        let v145: &str = inline_colorization::color_reset;
        let v152: std::string::String = String::from(v145);
        append(v139, fable_library_rust::String_::fromString(v152))
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
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("delete_file_async"),
                ),
                string(" / "),
            ),
            v10,
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
            let v205: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v204: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v226: () = {
                File_system::closure7(v204.clone(), ());
                ()
            };
            println!("{}", v165.clone());
            (v205.l0.get().clone())(v165);
            File_system::US6::US6_0(
                v204,
                v205,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
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
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("move_file_async"),
                ),
                string(" / "),
            ),
            v11,
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
            let v207: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v206: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v228: () = {
                File_system::closure7(v206.clone(), ());
                ()
            };
            println!("{}", v167.clone());
            (v207.l0.get().clone())(v167);
            File_system::US6::US6_0(
                v206,
                v207,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
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
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("async.run_with_timeout_async"),
                ),
                string(" / "),
            ),
            v9,
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
            let v164: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v163: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v185: () = {
                File_system::closure7(v163.clone(), ());
                ()
            };
            println!("{}", v124.clone());
            (v164.l0.get().clone())(v124);
            File_system::US6::US6_0(
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
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("async.run_with_timeout_async**"),
                ),
                string(" / "),
            ),
            v10,
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
            let v204: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v203: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v225: () = {
                File_system::closure7(v203.clone(), ());
                ()
            };
            println!("{}", v164.clone());
            (v204.l0.get().clone())(v164);
            File_system::US6::US6_0(
                v203,
                v204,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
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
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("file_system.read_all_text_retry_async"),
                ),
                string(" / "),
            ),
            v10,
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
            let v204: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v203: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v225: () = {
                File_system::closure7(v203.clone(), ());
                ()
            };
            println!("{}", v164.clone());
            (v204.l0.get().clone())(v164);
            File_system::US6::US6_0(
                v203,
                v204,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
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
    pub fn closure42(unitVar: (), v0: chrono::DateTime<chrono::Utc>) -> File_system::US13 {
        File_system::US13::US13_0(v0)
    }
    pub fn method84() -> Func1<chrono::DateTime<chrono::Utc>, File_system::US13> {
        Func1::new(move |v: chrono::DateTime<chrono::Utc>| File_system::closure42((), v))
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
        let v752: DateTime = {
            let _arg: DateTime = DateTime::unixEpoch();
            _arg.toUniversalTime()
        };
        let v762: DateTime = {
            let _arg_1: DateTime = DateTime::specifyKind(v1, 2_i32);
            _arg_1.toUniversalTime()
        };
        let v862: i64 = ((v762.ticks()) - (v752.ticks())) / 10_i64;
        let v864: Option<chrono::DateTime<chrono::Utc>> =
            chrono::DateTime::from_timestamp_micros(v862);
        let v889: File_system::US13 = defaultValue(
            File_system::US13::US13_1,
            map(File_system::method84(), v864),
        );
        let v909: File_system::US5 = match &v889 {
            File_system::US13::US13_0(v889_0_0) => {
                let v895: chrono::NaiveDateTime = match &v889 {
                    File_system::US13::US13_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone()
                .naive_utc();
                let v897: chrono::DateTime<chrono::Local> =
                    chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &v895);
                let v899: string = string("r#\"%Y%m%d-%H%M-%S%f\"#");
                let v900: &str = r#"%Y%m%d-%H%M-%S%f"#;
                let v902: std::string::String = v897.format(v900).to_string();
                let v904: string = fable_library_rust::String_::fromString(v902);
                File_system::US5::US5_0(sprintf!(
                    "{}-{}-{}",
                    getSlice(v904.clone(), Some(0_i32), Some(17_i32)),
                    getSlice(v904.clone(), Some(18_i32), Some(21_i32)),
                    getCharAt(v904, 22_i32)
                ))
            }
            _ => File_system::US5::US5_1,
        };
        let v913: string = match &v909 {
            File_system::US5::US5_0(v909_0_0) => match &v909 {
                File_system::US5::US5_0(x) => x.clone(),
                _ => unreachable!(),
            }
            .clone(),
            _ => string(""),
        };
        let v920: LrcPtr<TimeZoneInfo> = std::sync::Arc::new(chrono::FixedOffset::local_minus_utc(
            chrono::Local::now().offset(),
        ) as i64);
        let v964: i64 = v762.ticks();
        let v1000: string = string(
            "chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))",
        );
        let v1151: TimeSpan = TimeSpan::new_ticks(chrono::FixedOffset::local_minus_utc(
            &chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(
                &chrono::DateTime::from_timestamp_nanos(v964),
            )),
        ) as i64);
        let v1172: u8 = if (v1151.hours()) > 0_i32 { 1_u8 } else { 0_u8 };
        let v1173: string = File_system::method85();
        let v1393: string = v1151.toString(v1173);
        let v1534: string = sprintf!(
            "{}{}{}",
            v1172,
            getSlice(v1393.clone(), Some(0_i32), Some(1_i32)),
            getSlice(v1393, Some(3_i32), Some(4_i32))
        );
        let v1537: string = toString(v0);
        parse(concat(new_array(&[
            v913.clone(),
            v1534.clone(),
            getSlice(
                v1537.clone(),
                Some((length(v913)) + (length(v1534))),
                Some((length(v1537)) - 1_i32),
            ),
        ])))
    }
    pub fn method89() -> string {
        let v6: std::path::PathBuf = std::env::temp_dir();
        let v13: std::path::Display = v6.display();
        let v49_1: std::string::String = format!("{}", v13);
        fable_library_rust::String_::fromString(v49_1)
    }
    pub fn method90() -> string {
        string("!create_temp_path_")
    }
    pub fn method91(v0: string, v1: string) -> string {
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
    pub fn method93() -> string {
        string("CARGO_PKG_NAME")
    }
    pub fn method92() -> string {
        File_system::method2(File_system::method93())
    }
    pub fn method88(v0: Guid) -> string {
        File_system::method91(
            File_system::method91(
                File_system::method91(File_system::method89(), File_system::method90()),
                File_system::method92(),
            ),
            toString(v0),
        )
    }
    pub fn method82() -> string {
        let v37_1: DateTime = DateTime::now();
        File_system::method88(File_system::method83(new_guid(), v37_1))
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
        let v139: std::string::String = format!("{:#?}", v1);
        let v186: () = {
            File_system::closure6(
                v3.clone(),
                fable_library_rust::String_::fromString(v139),
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
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("file_system.create_dir"),
                ),
                string(" / "),
            ),
            v10,
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
            let v165: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v164: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v186: () = {
                File_system::closure7(v164.clone(), ());
                ()
            };
            println!("{}", v125.clone());
            (v165.l0.get().clone())(v125);
            File_system::US6::US6_0(
                v164,
                v165,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
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
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("file_system.create_dir"),
                ),
                string(" / "),
            ),
            v9,
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
            let v164: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v163: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v185: () = {
                File_system::closure7(v163.clone(), ());
                ()
            };
            println!("{}", v124.clone());
            (v164.l0.get().clone())(v124);
            File_system::US6::US6_0(
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
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("file_system.create_dir"),
                ),
                string(" / "),
            ),
            v10,
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
            let v165: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v164: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v186: () = {
                File_system::closure7(v164.clone(), ());
                ()
            };
            println!("{}", v125.clone());
            (v165.l0.get().clone())(v125);
            File_system::US6::US6_0(
                v164,
                v165,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
                patternInput_2.4.clone(),
                patternInput_2.5.clone(),
            )
        };
        ()
    }
    pub fn closure51(v0: string, unitVar: ()) {
        let v1: Arc<Async<i64>> = File_system::method6(v0);
        let v8: Arc<Async<()>> = fable_library_rust::Native_::getZero();
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
        let v738: Result<(), std::io::Error> = std::fs::create_dir_all(&*v0.clone());
        let v739 = File_system::method95();
        let v752: Result<(), std::string::String> = v738.map_err(|x| v739(x));
        let v755 = File_system::method96();
        let v756 = File_system::method97();
        let v758: File_system::US14 = match &v752 {
            Err(v752_1_0) => v756(v752_1_0.clone()),
            _ => v755(),
        };
        match &v758 {
            File_system::US14::US14_0 => {
                let v1074: () = {
                    File_system::closure48(v0.clone(), ());
                    ()
                };
                ()
            }
            File_system::US14::US14_1(v758_1_0) => {
                let v1703: () = {
                    File_system::closure47(
                        v0.clone(),
                        match &v758 {
                            File_system::US14::US14_1(x) => x.clone(),
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
            let v2023 = File_system::method102(v0.clone());
            interface_cast!(
                File_system::Disposable::_ctor__3A5B6456(Func0::new({
                    let v2023 = v2023.clone();
                    move || v2023.clone()()
                })),
                Lrc<dyn IDisposable>,
            )
        }
    }
    pub fn closure43(unitVar: (), unitVar_1: ()) -> (string, LrcPtr<dyn IDisposable>) {
        let v0: string = File_system::method82();
        (v0.clone(), File_system::method94(v0))
    }
    pub fn closure53(v0: i32, v1: string, v2: i32, v3: string) -> string {
        if (v2) >= (v0) {
            v3.clone()
        } else {
            (File_system::method110(v0, v1.clone(), (v2) + 1_i32))(append(v3, v1))
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
            (File_system::method110(32_i32 - (length(v0.clone())), v3, 0_i32))(string("")),
            v0,
        );
        parse(append(
            append(
                append(
                    append(
                        append(
                            append(
                                append(
                                    append(
                                        getSlice(v13.clone(), Some(0_i32), Some((8_i32) - 1_i32)),
                                        string("-"),
                                    ),
                                    getSlice(v13.clone(), Some(8_i32), Some((12_i32) - 1_i32)),
                                ),
                                string("-"),
                            ),
                            getSlice(v13.clone(), Some(12_i32), Some((16_i32) - 1_i32)),
                        ),
                        string("-"),
                    ),
                    getSlice(v13.clone(), Some(16_i32), Some((20_i32) - 1_i32)),
                ),
                string("-"),
            ),
            getSlice(v13, Some(20_i32), Some((32_i32) - 1_i32)),
        ))
    }
    pub fn closure52(unitVar: (), v0: string) -> (string, LrcPtr<dyn IDisposable>) {
        let v2: string = File_system::method88(File_system::method109(v0));
        (v2.clone(), File_system::method94(v2))
    }
    pub fn closure54(unitVar: (), unitVar_1: ()) -> string {
        string("/home/runner/work/spiral/polyglot/deps/spiral/lib/spiral")
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
            let v46_1: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v39_1);
            Err(v46_1)
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
                            let v171: &str = &*v164;
                            let v207: std::string::String = String::from(v171);
                            let v243: std::path::PathBuf = std::path::PathBuf::from(v207);
                            Ok(v243)
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
                            let v298: std::io::Error =
                                std::io::Error::new(std::io::ErrorKind::Other, &*v291);
                            Err(v298)
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
                    let v354: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v347);
                    Err(v354)
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
                let v409: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v402);
                Err(v409)
            }
        }
    }
    pub fn method116(v0: string, v1: u8, v2: string) -> Result<std::path::PathBuf, std::io::Error> {
        let v9: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v2.clone());
        let v10 = File_system::method45();
        let v23: Result<std::path::PathBuf, string> = v9.map_err(|x| v10(x));
        let v26 = File_system::method114();
        let v27 = File_system::method115();
        let v29: File_system::US15 = match &v23 {
            Err(v23_1_0) => v27(v23_1_0.clone()),
            Ok(v23_0_0) => v26(v23_0_0.clone()),
        };
        match &v29 {
            File_system::US15::US15_0(v29_0_0) => Ok(v29_0_0.clone()),
            File_system::US15::US15_1(v29_1_0) => File_system::method117(
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
                v29_1_0.clone(),
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
            let v45_1: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v38_1);
            Err(v45_1)
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
                            let v170: &str = &*v163;
                            let v206: std::string::String = String::from(v170);
                            let v242: std::path::PathBuf = std::path::PathBuf::from(v206);
                            Ok(v242)
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
                            let v297: std::io::Error =
                                std::io::Error::new(std::io::ErrorKind::Other, &*v290);
                            Err(v297)
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
                    let v353: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v346);
                    Err(v353)
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
                let v408: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v401);
                Err(v408)
            }
        }
    }
    pub fn method113(v0: string, v1: u8) -> Result<std::path::PathBuf, std::io::Error> {
        let v8: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v0.clone());
        let v9 = File_system::method45();
        let v22: Result<std::path::PathBuf, string> = v8.map_err(|x| v9(x));
        let v25 = File_system::method114();
        let v26 = File_system::method115();
        let v28: File_system::US15 = match &v22 {
            Err(v22_1_0) => v26(v22_1_0.clone()),
            Ok(v22_0_0) => v25(v22_0_0.clone()),
        };
        match &v28 {
            File_system::US15::US15_0(v28_0_0) => Ok(v28_0_0.clone()),
            File_system::US15::US15_1(v28_1_0) => File_system::method120(
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
                v28_1_0.clone(),
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
            let v46_1: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v39_1);
            Err(v46_1)
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
                            let v171: &str = &*v164;
                            let v207: std::string::String = String::from(v171);
                            let v243: std::path::PathBuf = std::path::PathBuf::from(v207);
                            Ok(v243)
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
                            let v298: std::io::Error =
                                std::io::Error::new(std::io::ErrorKind::Other, &*v291);
                            Err(v298)
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
                    let v354: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v347);
                    Err(v354)
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
                let v409: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v402);
                Err(v409)
            }
        }
    }
    pub fn method125(v0: string, v1: u8, v2: string) -> Result<std::path::PathBuf, std::io::Error> {
        let v45_1: i32 =
            File_system::method122(unbox::<bool>(fable_library_rust::Native_::getZero()));
        let v47_1: bool = File_system::method124(File_system::method123(), v45_1);
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
            let v45_1: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v38_1);
            Err(v45_1)
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
                            let v170: &str = &*v163;
                            let v206: std::string::String = String::from(v170);
                            let v242: std::path::PathBuf = std::path::PathBuf::from(v206);
                            Ok(v242)
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
                            let v297: std::io::Error =
                                std::io::Error::new(std::io::ErrorKind::Other, &*v290);
                            Err(v297)
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
                    let v353: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v346);
                    Err(v353)
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
                let v408: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v401);
                Err(v408)
            }
        }
    }
    pub fn method121(v0: string, v1: u8) -> Result<std::path::PathBuf, std::io::Error> {
        let v44_1: i32 =
            File_system::method122(unbox::<bool>(fable_library_rust::Native_::getZero()));
        let v46_1: bool = File_system::method124(File_system::method123(), v44_1);
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
        let v6: Result<regex::Regex, regex::Error> = regex::Regex::new(&v0);
        let v10: regex::Regex = v6.unwrap();
        let v22: string = File_system::method130(v2);
        let v24: std::borrow::Cow<str> = v10.replace_all(&*v22, &*v1);
        let v26: std::string::String = String::from(v24);
        fable_library_rust::String_::fromString(v26)
    }
    pub fn method111(v0: string) -> string {
        if (v0.clone()) == string("") {
            string("")
        } else {
            let v3: Result<std::path::PathBuf, std::io::Error> = File_system::method112(v0.clone());
            let v7: Option<std::path::PathBuf> = v3.ok();
            let v43_1: File_system::US16 =
                defaultValue(File_system::US16::US16_1, map(File_system::method128(), v7));
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
        let v6: Result<std::path::PathBuf, std::io::Error> = std::env::current_dir();
        let v10: std::path::PathBuf = v6.unwrap();
        let v28: std::path::Display = v10.display();
        let v64: std::string::String = format!("{}", v28);
        fable_library_rust::String_::fromString(v64)
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
        let v12: &str = &*v0.clone();
        let v48_1: std::string::String = String::from(v12);
        let v84: std::path::PathBuf = std::path::PathBuf::from(v48_1);
        if (v84.exists()) == false {
            let v117: string = File_system::method133();
            let v131: Array<string> = split(
                File_system::method111(File_system::method91(v117.clone(), v0.clone())),
                string("/"),
                -1_i32,
                0_i32,
            );
            let v135: i32 = get_Count(v131.clone());
            let v136: LrcPtr<File_system::Mut5> = LrcPtr::new(File_system::Mut5 {
                l0: MutCell::new(0_i32),
                l1: MutCell::new(0_i32),
                l2: MutCell::new(new_empty::<string>()),
            });
            while File_system::method134(v135, v136.clone()) {
                let v138: i32 = v136.l0.get().clone();
                let v141: i32 = ((v138.wrapping_neg()) + (v135)) - 1_i32;
                let matchValue: i32 = v136.l1.get().clone();
                let v143: Array<string> = v136.l2.get().clone();
                let v142: i32 = matchValue;
                let v144: string = v131[v141].clone();
                let patternInput_1: (i32, Array<string>) = if string("..") == (v144.clone()) {
                    ((v142) + 1_i32, v143.clone())
                } else {
                    if string(".") == (v144.clone()) {
                        (v142, v143.clone())
                    } else {
                        if 0_i32 == (v142) {
                            if endsWith3(v144.clone(), string(":"), false) {
                                let v156: Array<string> =
                                    new_array(&[sprintf!("{}:", getCharAt(v117.clone(), 0_i32))]);
                                let v157: i32 = get_Count(v156.clone());
                                let v159: i32 = (v157) + (get_Count(v143.clone()));
                                let v160: Array<string> = new_init(&string(""), v159);
                                let v161: LrcPtr<File_system::Mut6> =
                                    LrcPtr::new(File_system::Mut6 {
                                        l0: MutCell::new(0_i32),
                                    });
                                while File_system::method135(v159, v161.clone()) {
                                    let v163: i32 = v161.l0.get().clone();
                                    let v168: string = if (v163) < (v157) {
                                        v156[v163].clone()
                                    } else {
                                        let v166: i32 = (v163) - (v157);
                                        v143[v166].clone()
                                    };
                                    v160.get_mut()[v163 as usize] = v168;
                                    {
                                        let v169: i32 = (v163) + 1_i32;
                                        v161.l0.set(v169);
                                        ()
                                    }
                                }
                                (0_i32, v160.clone())
                            } else {
                                let v170: Array<string> = new_array(&[v144]);
                                let v171: i32 = get_Count(v170.clone());
                                let v173: i32 = (v171) + (get_Count(v143.clone()));
                                let v174: Array<string> = new_init(&string(""), v173);
                                let v175: LrcPtr<File_system::Mut6> =
                                    LrcPtr::new(File_system::Mut6 {
                                        l0: MutCell::new(0_i32),
                                    });
                                while File_system::method135(v173, v175.clone()) {
                                    let v177: i32 = v175.l0.get().clone();
                                    let v182: string = if (v177) < (v171) {
                                        v170[v177].clone()
                                    } else {
                                        let v180: i32 = (v177) - (v171);
                                        v143[v180].clone()
                                    };
                                    v174.get_mut()[v177 as usize] = v182;
                                    {
                                        let v183: i32 = (v177) + 1_i32;
                                        v175.l0.set(v183);
                                        ()
                                    }
                                }
                                (0_i32, v174.clone())
                            }
                        } else {
                            ((v142) - 1_i32, v143.clone())
                        }
                    }
                };
                let v193: i32 = (v138) + 1_i32;
                v136.l0.set(v193);
                v136.l1.set(patternInput_1.0.clone());
                v136.l2.set(patternInput_1.1.clone());
                ()
            }
            {
                let matchValue_2: i32 = v136.l1.get().clone();
                let v195: Array<string> = v136.l2.get().clone();
                let _let__v200: LrcPtr<dyn IEnumerable_1<string>> = delay(Func0::new({
                    let v195 = v195.clone();
                    move || {
                        map_1(
                            Func1::new({
                                let v195 = v195.clone();
                                move |i: i32| v195[i].clone()
                            }),
                            rangeNumeric(0_i32, 1_i32, (get_Count(v195.clone())) - 1_i32),
                        )
                    }
                }));
                let v212: string = ofChar(File_system::method136());
                join(
                    if (v212.clone()) == string("\n") {
                        File_system::method137(v212.clone())
                    } else {
                        v212
                    },
                    toArray_1(_let__v200),
                )
            }
        } else {
            let v225: Result<std::path::PathBuf, std::io::Error> = std::fs::canonicalize(&*v0);
            let v229: std::path::PathBuf = v225.unwrap();
            let v247: std::path::Display = v229.display();
            let v283: std::string::String = format!("{}", v247);
            fable_library_rust::String_::fromString(v283)
        }
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
            break '_method142 if v3(File_system::method91(v4.get().clone(), v0.get().clone())) {
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
                        concat(new_array(&[
                            string("file_system.find_parent / No parent for "),
                            if v2.get().clone() {
                                string("file")
                            } else {
                                string("dir")
                            },
                        ])),
                        sprintf!(
                            " \'{}\' at \'{}\' (until \'{}\')",
                            v0.get().clone(),
                            v1.get().clone(),
                            v4.get().clone()
                        ),
                    )),
                }
            };
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
                    concat(new_array(&[
                        string("file_system.find_parent / No parent for "),
                        if v2 { string("file") } else { string("dir") },
                    ])),
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
            append(
                append(
                    append(
                        append(
                            append(append(append(v6, string(" ")), v7), string(" #")),
                            toString(v0.l0.get().clone()),
                        ),
                        string(" "),
                    ),
                    string("file_system.get_workspace_root"),
                ),
                string(" / "),
            ),
            v10,
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
            let v165: LrcPtr<File_system::Mut1> = patternInput_2.1.clone();
            let v164: LrcPtr<File_system::Mut0> = patternInput_2.0.clone();
            let v186: () = {
                File_system::closure7(v164.clone(), ());
                ()
            };
            println!("{}", v125.clone());
            (v165.l0.get().clone())(v125);
            File_system::US6::US6_0(
                v164,
                v165,
                patternInput_2.2.clone(),
                patternInput_2.3.clone(),
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
            _ => File_system::method139(string(
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
            let v4: LrcPtr<dyn IDisposable> = File_system::method94(v0.clone());
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
