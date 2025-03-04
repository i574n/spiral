#![allow(dead_code)]
#![allow(non_camel_case_types)]
#![allow(non_snake_case)]
#![allow(non_upper_case_globals)]
#![allow(unreachable_code)]
#![allow(unused_attributes)]
#![allow(unused_imports)]
#![allow(unused_macros)]
#![allow(unused_parens)]
#![allow(unused_variables)]
#![allow(unused_assignments)]
use fable_library_rust::NativeArray_::array_from;
use fable_library_rust::String_::fromString;
mod module_1216f6c3 {
    pub mod Spiral {
        use super::*;
        use fable_library_rust::Array_::skip;
        use fable_library_rust::Array_::skipWhile;
        use fable_library_rust::Array_::tryItem;
        use fable_library_rust::Async_::Async;
        use fable_library_rust::DateTime_::DateTime;
        use fable_library_rust::Encoding_::get_UTF8;
        use fable_library_rust::Encoding_::Encoding;
        use fable_library_rust::Exception_::try_catch;
        use fable_library_rust::Guid_::new_guid;
        use fable_library_rust::Guid_::parse;
        use fable_library_rust::Guid_::Guid;
        use fable_library_rust::List_::cons;
        use fable_library_rust::List_::empty;
        use fable_library_rust::List_::foldBack;
        use fable_library_rust::List_::ofArray;
        use fable_library_rust::List_::toArray;
        use fable_library_rust::List_::List;
        use fable_library_rust::Map_::find;
        use fable_library_rust::Map_::ofSeq;
        use fable_library_rust::NativeArray_::get_Count;
        use fable_library_rust::NativeArray_::new_array;
        use fable_library_rust::NativeArray_::new_empty;
        use fable_library_rust::NativeArray_::new_init;
        use fable_library_rust::NativeArray_::Array;
        use fable_library_rust::Native_::getNull;
        use fable_library_rust::Native_::interface_cast;
        use fable_library_rust::Native_::refCell;
        use fable_library_rust::Native_::unbox;
        use fable_library_rust::Native_::Any;
        use fable_library_rust::Native_::Arc;
        use fable_library_rust::Native_::Func0;
        use fable_library_rust::Native_::Func1;
        use fable_library_rust::Native_::Func2;
        use fable_library_rust::Native_::Lrc;
        use fable_library_rust::Native_::LrcPtr;
        use fable_library_rust::Native_::MutCell;
        use fable_library_rust::Native_::OnceInit;
        use fable_library_rust::Option_::defaultValue;
        use fable_library_rust::Option_::map;
        use fable_library_rust::Range_::rangeNumeric;
        use fable_library_rust::Seq_::delay;
        use fable_library_rust::Seq_::map as map_1;
        use fable_library_rust::Seq_::ofArray as ofArray_1;
        use fable_library_rust::Seq_::ofList;
        use fable_library_rust::Seq_::toArray as toArray_1;
        use fable_library_rust::String_::append;
        use fable_library_rust::String_::concat;
        use fable_library_rust::String_::contains;
        use fable_library_rust::String_::endsWith3;
        use fable_library_rust::String_::getCharAt;
        use fable_library_rust::String_::getSlice;
        use fable_library_rust::String_::indexOf;
        use fable_library_rust::String_::join;
        use fable_library_rust::String_::length;
        use fable_library_rust::String_::ofChar;
        use fable_library_rust::String_::printfn;
        use fable_library_rust::String_::replace;
        use fable_library_rust::String_::split;
        use fable_library_rust::String_::sprintf;
        use fable_library_rust::String_::startsWith3;
        use fable_library_rust::String_::string;
        use fable_library_rust::String_::toLower;
        use fable_library_rust::String_::toString;
        use fable_library_rust::String_::toUpper;
        use fable_library_rust::String_::trimEndChars;
        use fable_library_rust::String_::trimStartChars;
        use fable_library_rust::TimeSpan_::TimeSpan;
        type ConcurrentStack_1<T> = T;
        use fable_library_rust::System::Collections::Generic::IEnumerable_1;
        use fable_library_rust::System::Exception;
        use fable_library_rust::System::IDisposable;
        use fable_library_rust::System::Text::StringBuilder;
        use fable_library_rust::System::Threading::CancellationToken;
        type TaskCanceledException = ();
        type TimeZoneInfo = i64;
        pub mod TraceState {
            use super::*;
            pub fn trace_state() -> LrcPtr<
                MutCell<
                    Option<(
                        LrcPtr<Spiral::Mut0>,
                        LrcPtr<Spiral::Mut1>,
                        LrcPtr<Spiral::Mut2>,
                        LrcPtr<Spiral::Mut3>,
                        LrcPtr<Spiral::Mut4>,
                        Option<i64>,
                    )>,
                >,
            > {
                static trace_state: OnceInit<
                    LrcPtr<
                        MutCell<
                            Option<(
                                LrcPtr<Spiral::Mut0>,
                                LrcPtr<Spiral::Mut1>,
                                LrcPtr<Spiral::Mut2>,
                                LrcPtr<Spiral::Mut3>,
                                LrcPtr<Spiral::Mut4>,
                                Option<i64>,
                            )>,
                        >,
                    >,
                > = OnceInit::new();
                trace_state
                    .get_or_init(|| {
                        LrcPtr::new(MutCell::new(
                            None::<(
                                LrcPtr<Spiral::Mut0>,
                                LrcPtr<Spiral::Mut1>,
                                LrcPtr<Spiral::Mut2>,
                                LrcPtr<Spiral::Mut3>,
                                LrcPtr<Spiral::Mut4>,
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
        pub trait ICryptoCreateHash: core::fmt::Debug + core::fmt::Display {
            fn createHash(&self, x: string) -> LrcPtr<dyn Any>;
        }
        impl<V: ICryptoCreateHash + core::fmt::Debug + core::fmt::Display> ICryptoCreateHash for LrcPtr<V> {
            #[inline]
            fn createHash(&self, x: string) -> LrcPtr<dyn Any> {
                (**self).createHash(x)
            }
        }
        pub trait IHashlibSha256: core::fmt::Debug + core::fmt::Display {
            fn sha256(&self) -> LrcPtr<dyn Any>;
        }
        impl<V: IHashlibSha256 + core::fmt::Debug + core::fmt::Display> IHashlibSha256 for LrcPtr<V> {
            #[inline]
            fn sha256(&self) -> LrcPtr<dyn Any> {
                (**self).sha256()
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
        pub trait IPathJoin: core::fmt::Debug + core::fmt::Display {
            fn join(&self, paths: Array<string>) -> string;
        }
        impl<V: IPathJoin + core::fmt::Debug + core::fmt::Display> IPathJoin for LrcPtr<V> {
            #[inline]
            fn join(&self, paths: Array<string>) -> string {
                (**self).join(paths)
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
        pub trait IPathDirname: core::fmt::Debug + core::fmt::Display {
            fn dirname(&self, path: string) -> string;
        }
        impl<V: IPathDirname + core::fmt::Debug + core::fmt::Display> IPathDirname for LrcPtr<V> {
            #[inline]
            fn dirname(&self, path: string) -> string {
                (**self).dirname(path)
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
        #[derive(Clone, Debug)]
        pub struct Disposable {
            f: Func0<()>,
        }
        impl Disposable {
            pub fn _ctor__3A5B6456(f: Func0<()>) -> LrcPtr<Spiral::Disposable> {
                let f_1;
                ();
                f_1 = f;
                ();
                LrcPtr::new(Spiral::Disposable { f: f_1 })
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
            pub l0: MutCell<Spiral::US0>,
        }
        impl core::fmt::Display for Mut4 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US1 {
            US1_0(Spiral::US0),
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
            US4_0(Spiral::US3),
            US4_1(Spiral::US3),
            US4_2(Spiral::US3),
            US4_3(Spiral::US3),
            US4_4(Spiral::US3),
            US4_5(Spiral::US3),
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
            US6_0(std::string::String, clap::ArgMatches),
            US6_1,
        }
        impl core::fmt::Display for US6 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US7 {
            US7_0(std::string::String),
            US7_1,
        }
        impl core::fmt::Display for US7 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US8 {
            US8_0(Vec<std::string::String>),
            US8_1,
        }
        impl core::fmt::Display for US8 {
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
        pub enum US9 {
            US9_0,
            US9_1,
        }
        impl core::fmt::Display for US9 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US10 {
            US10_0(string),
            US10_1(string),
        }
        impl core::fmt::Display for US10 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US11 {
            US11_0(std::path::PathBuf),
            US11_1(string),
        }
        impl core::fmt::Display for US11 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US12 {
            US12_0(std::path::PathBuf),
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
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US14 {
            US14_0(string, Spiral::US5),
            US14_1(string),
        }
        impl core::fmt::Display for US14 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US15 {
            US15_0(char, string, LrcPtr<StringBuilder>, i32, i32),
            US15_1(string),
        }
        impl core::fmt::Display for US15 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum UH0 {
            UH0_0,
            UH0_1(char, LrcPtr<Spiral::UH0>),
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
                Func1<(string, LrcPtr<StringBuilder>, i32, i32), Spiral::US15>,
                LrcPtr<Spiral::UH1>,
            ),
        }
        impl core::fmt::Display for UH1 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US16 {
            US16_0(string, string, LrcPtr<StringBuilder>, i32, i32),
            US16_1(string),
        }
        impl core::fmt::Display for US16 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US17 {
            US17_0(char),
            US17_1,
        }
        impl core::fmt::Display for US17 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US18 {
            US18_0(string, LrcPtr<StringBuilder>, i32, i32),
            US18_1(string),
        }
        impl core::fmt::Display for US18 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US19 {
            US19_0(string, Spiral::US5, string, LrcPtr<StringBuilder>, i32, i32),
            US19_1(string),
        }
        impl core::fmt::Display for US19 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US20 {
            US20_0(Spiral::US17, string, LrcPtr<StringBuilder>, i32, i32),
            US20_1(string),
        }
        impl core::fmt::Display for US20 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US21 {
            US21_0(Spiral::US5, string, LrcPtr<StringBuilder>, i32, i32),
            US21_1(string),
        }
        impl core::fmt::Display for US21 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US22 {
            US22_0(Array<string>),
            US22_1(string),
        }
        impl core::fmt::Display for US22 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum UH2 {
            UH2_0,
            UH2_1(string, LrcPtr<Spiral::UH2>),
        }
        impl core::fmt::Display for UH2 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US23 {
            US23_0(LrcPtr<Spiral::UH2>, string, LrcPtr<StringBuilder>, i32, i32),
            US23_1(string),
        }
        impl core::fmt::Display for US23 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum UH3 {
            UH3_0,
            UH3_1(
                Func1<(string, LrcPtr<StringBuilder>, i32, i32), Spiral::US16>,
                LrcPtr<Spiral::UH3>,
            ),
        }
        impl core::fmt::Display for UH3 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US24 {
            US24_0(std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>),
            US24_1(std::string::String),
        }
        impl core::fmt::Display for US24 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US25 {
            US25_0(
                std::sync::Arc<
                    std::sync::Mutex<
                        std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                    >,
                >,
            ),
            US25_1,
        }
        impl core::fmt::Display for US25 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US26 {
            US26_0(std::string::String),
            US26_1(std::string::String),
        }
        impl core::fmt::Display for US26 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US27 {
            US27_0(Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>),
            US27_1,
        }
        impl core::fmt::Display for US27 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US28 {
            US28_0(std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>),
            US28_1,
        }
        impl core::fmt::Display for US28 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US29 {
            US29_0(std::process::Output),
            US29_1(std::string::String),
        }
        impl core::fmt::Display for US29 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US30 {
            US30_0(i32),
            US30_1,
        }
        impl core::fmt::Display for US30 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US31 {
            US31_0(Func1<(i32, string, bool), Arc<Async<()>>>),
            US31_1,
        }
        impl core::fmt::Display for US31 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US32 {
            US32_0(CancellationToken),
            US32_1,
        }
        impl core::fmt::Display for US32 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US35 {
            US35_0,
            US35_1,
        }
        impl core::fmt::Display for US35 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US34 {
            US34_0(Spiral::US35),
            US34_1,
        }
        impl core::fmt::Display for US34 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US33 {
            US33_0(Spiral::US34),
            US33_1,
        }
        impl core::fmt::Display for US33 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub struct Mut6 {
            pub l0: MutCell<i32>,
            pub l1: MutCell<i32>,
            pub l2: MutCell<Array<string>>,
        }
        impl core::fmt::Display for Mut6 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US37 {
            US37_0(string),
            US37_1(string),
        }
        impl core::fmt::Display for US37 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US36 {
            US36_0(Spiral::US37),
            US36_1,
        }
        impl core::fmt::Display for US36 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US38 {
            US38_0,
            US38_1,
            US38_2,
        }
        impl core::fmt::Display for US38 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US39 {
            US39_0(Spiral::US38),
            US39_1,
        }
        impl core::fmt::Display for US39 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum UH4 {
            UH4_0,
            UH4_1(string, string, LrcPtr<Spiral::UH4>),
        }
        impl core::fmt::Display for UH4 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US40 {
            US40_0(chrono::DateTime<chrono::Utc>),
            US40_1,
        }
        impl core::fmt::Display for US40 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US41 {
            US41_0(i32, string),
            US41_1(i32, string),
        }
        impl core::fmt::Display for US41 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US42 {
            US42_0(std::collections::HashMap<string, string>),
            US42_1,
        }
        impl core::fmt::Display for US42 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US43 {
            US43_0(Spiral::US5),
            US43_1,
        }
        impl core::fmt::Display for US43 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum UH5 {
            UH5_0,
            UH5_1(string, bool, LrcPtr<Spiral::UH5>),
        }
        impl core::fmt::Display for UH5 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US44 {
            US44_0,
            US44_1(string),
        }
        impl core::fmt::Display for US44 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US45 {
            US45_0(std::fs::FileType),
            US45_1(std::string::String),
        }
        impl core::fmt::Display for US45 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US46 {
            US46_0,
            US46_1,
            US46_2,
        }
        impl core::fmt::Display for US46 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US47 {
            US47_0(async_walkdir::DirEntry),
            US47_1(std::string::String),
        }
        impl core::fmt::Display for US47 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US48 {
            US48_0(string, string),
            US48_1,
        }
        impl core::fmt::Display for US48 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        pub fn method0() -> clap::Command {
            let v1_1: string = string("r#\"command\"#");
            let v2: &'static str = r#"command"#;
            let v4: clap::Command = clap::Command::new(v2);
            let v6: clap::Command = clap::Command::subcommand_required(v4, true);
            let v8: string = string("r#\"fsharp\"#");
            let v9: &'static str = r#"fsharp"#;
            let v11: clap::Command = clap::Command::new(v9);
            let v13: string = string("r#\"spi-path\"#");
            let v14: &'static str = r#"spi-path"#;
            let v16: clap::Arg = clap::Arg::new(v14);
            let v18: clap::Arg = v16.short('s');
            let v19: string = string("r#\"spi-path\"#");
            let v20: &'static str = r#"spi-path"#;
            let v22: clap::Arg = v18.long(v20);
            let v24: clap::Arg = v22.required(true);
            let v26: clap::Command = clap::Command::arg(v11, v24);
            let v28: clap::Command = clap::Command::subcommand(v6, v26);
            let v30: string = string("r#\"gleam\"#");
            let v31: &'static str = r#"gleam"#;
            let v33: clap::Command = clap::Command::new(v31);
            let v35: string = string("r#\"gleam-path\"#");
            let v36: &'static str = r#"gleam-path"#;
            let v38: clap::Arg = clap::Arg::new(v36);
            let v40: clap::Arg = v38.short('g');
            let v41: string = string("r#\"gleam-path\"#");
            let v42: &'static str = r#"gleam-path"#;
            let v44: clap::Arg = v40.long(v42);
            let v46: clap::Arg = v44.required(true);
            let v48: clap::Command = clap::Command::arg(v33, v46);
            let v50: string = string("r#\"NAME\"#");
            let v53: string = string("r#\"VERSION\"#");
            let v55: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v57: usize = 1_i32 as usize;
            let v61: usize = 0_i32 as usize;
            let v77: clap::builder::ValueRange = if (v61) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v57..)
            } else {
                let v75: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v57..v61)
            };
            let v79: string = string("r#\"deps\"#");
            let v80: &'static str = r#"deps"#;
            let v82: clap::Arg = clap::Arg::new(v80);
            let v84: clap::Arg = v82.short('d');
            let v85: string = string("r#\"deps\"#");
            let v86: &'static str = r#"deps"#;
            let v88: clap::Arg = v84.long(v86);
            let v90: Vec<&'static str> = v55.to_vec();
            let v92: clap::Arg = v88.value_names(v90);
            let v94: clap::Arg = v92.num_args(v77);
            let v96: clap::ArgAction = clap::ArgAction::Append;
            let v98: clap::Arg = v94.action(v96);
            let v100: clap::Command = clap::Command::arg(v48, v98);
            let v102: clap::Command = clap::Command::subcommand(v28, v100);
            let v104: string = string("r#\"cuda\"#");
            let v105: &'static str = r#"cuda"#;
            let v107: clap::Command = clap::Command::new(v105);
            let v109: string = string("r#\"py-path\"#");
            let v110: &'static str = r#"py-path"#;
            let v112: clap::Arg = clap::Arg::new(v110);
            let v114: clap::Arg = v112.short('p');
            let v115: string = string("r#\"py-path\"#");
            let v116: &'static str = r#"py-path"#;
            let v118: clap::Arg = v114.long(v116);
            let v120: clap::Arg = v118.required(true);
            let v122: clap::Command = clap::Command::arg(v107, v120);
            let v124: string = string("r#\"env\"#");
            let v125: &'static str = r#"env"#;
            let v127: clap::Arg = clap::Arg::new(v125);
            let v129: clap::Arg = v127.short('e');
            let v130: string = string("r#\"env\"#");
            let v131: &'static str = r#"env"#;
            let v133: clap::Arg = v129.long(v131);
            let v147: Array<string> =
                toArray(ofArray(new_array(&[string("Pip"), string("Poetry")])));
            let v151: Vec<string> = v147.to_vec();
            let v153: bool = true;
            let _vec_map: Vec<_> = v151
                .into_iter()
                .map(|x| {
                    //;
                    let v155: string = x;
                    let v162: &str = &*v155;
                    let v195: std::string::String = String::from(v162);
                    let v223: Box<std::string::String> = Box::new(v195);
                    let v225: &'static mut std::string::String = Box::leak(v223);
                    let v227: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v225);
                    let v229: bool = true;
                    v227
                })
                .collect::<Vec<_>>();
            let v231: Vec<clap::builder::PossibleValue> = _vec_map;
            let v233: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v231),
            );
            let v235: clap::Arg = v133.value_parser(v233);
            let v237: clap::Command = clap::Command::arg(v122, v235);
            let v238: string = string("r#\"NAME\"#");
            let v240: string = string("r#\"VERSION\"#");
            let v242: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v244: usize = 1_i32 as usize;
            let v248: usize = 0_i32 as usize;
            let v264: clap::builder::ValueRange = if (v248) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v244..)
            } else {
                let v262: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v244..v248)
            };
            let v265: string = string("r#\"deps\"#");
            let v266: &'static str = r#"deps"#;
            let v268: clap::Arg = clap::Arg::new(v266);
            let v270: clap::Arg = v268.short('d');
            let v271: string = string("r#\"deps\"#");
            let v272: &'static str = r#"deps"#;
            let v274: clap::Arg = v270.long(v272);
            let v276: Vec<&'static str> = v242.to_vec();
            let v278: clap::Arg = v274.value_names(v276);
            let v280: clap::Arg = v278.num_args(v264);
            let v282: clap::ArgAction = clap::ArgAction::Append;
            let v284: clap::Arg = v280.action(v282);
            let v286: clap::Command = clap::Command::arg(v237, v284);
            let v288: clap::Command = clap::Command::subcommand(v102, v286);
            let v290: string = string("r#\"fable\"#");
            let v291: &'static str = r#"fable"#;
            let v293: clap::Command = clap::Command::new(v291);
            let v295: string = string("r#\"fs-path\"#");
            let v296: &'static str = r#"fs-path"#;
            let v298: clap::Arg = clap::Arg::new(v296);
            let v300: clap::Arg = v298.short('f');
            let v301: string = string("r#\"fs-path\"#");
            let v302: &'static str = r#"fs-path"#;
            let v304: clap::Arg = v300.long(v302);
            let v306: clap::Arg = v304.required(true);
            let v308: clap::Command = clap::Command::arg(v293, v306);
            let v309: string = string("r#\"command\"#");
            let v310: &'static str = r#"command"#;
            let v312: clap::Arg = clap::Arg::new(v310);
            let v314: clap::Arg = v312.short('c');
            let v315: string = string("r#\"command\"#");
            let v316: &'static str = r#"command"#;
            let v318: clap::Arg = v314.long(v316);
            let v320: clap::Command = clap::Command::arg(v308, v318);
            let v322: clap::Command = clap::Command::subcommand(v288, v320);
            let v324: string = string("r#\"rust\"#");
            let v325: &'static str = r#"rust"#;
            let v327: clap::Command = clap::Command::new(v325);
            let v328: string = string("r#\"fs-path\"#");
            let v329: &'static str = r#"fs-path"#;
            let v331: clap::Arg = clap::Arg::new(v329);
            let v333: clap::Arg = v331.short('f');
            let v334: string = string("r#\"fs-path\"#");
            let v335: &'static str = r#"fs-path"#;
            let v337: clap::Arg = v333.long(v335);
            let v339: clap::Arg = v337.required(true);
            let v341: clap::Command = clap::Command::arg(v327, v339);
            let v342: string = string("r#\"NAME\"#");
            let v344: string = string("r#\"VERSION\"#");
            let v346: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v348: usize = 1_i32 as usize;
            let v352: usize = 0_i32 as usize;
            let v368: clap::builder::ValueRange = if (v352) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v348..)
            } else {
                let v366: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v348..v352)
            };
            let v369: string = string("r#\"deps\"#");
            let v370: &'static str = r#"deps"#;
            let v372: clap::Arg = clap::Arg::new(v370);
            let v374: clap::Arg = v372.short('d');
            let v375: string = string("r#\"deps\"#");
            let v376: &'static str = r#"deps"#;
            let v378: clap::Arg = v374.long(v376);
            let v380: Vec<&'static str> = v346.to_vec();
            let v382: clap::Arg = v378.value_names(v380);
            let v384: clap::Arg = v382.num_args(v368);
            let v386: clap::ArgAction = clap::ArgAction::Append;
            let v388: clap::Arg = v384.action(v386);
            let v390: clap::Command = clap::Command::arg(v341, v388);
            let v392: usize = 0_i32 as usize;
            let v396: usize = 1_i32 as usize;
            let v412: clap::builder::ValueRange = if (v396) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v392..)
            } else {
                let v410: string = string("clap::builder::ValueRange::new($0..=$1)");
                clap::builder::ValueRange::new(v392..=v396)
            };
            let v414: string = string("r#\"wasm\"#");
            let v415: &'static str = r#"wasm"#;
            let v417: clap::Arg = clap::Arg::new(v415);
            let v419: clap::Arg = v417.short('w');
            let v420: string = string("r#\"wasm\"#");
            let v421: &'static str = r#"wasm"#;
            let v423: clap::Arg = v419.long(v421);
            let v425: clap::Arg = v423.num_args(v412);
            let v427: clap::Arg = v425.require_equals(true);
            let v429: string = string("r#\"\"#");
            let v430: &str = r#""#;
            let v432: clap::Arg = v427.default_missing_value(v430);
            let v434: clap::Command = clap::Command::arg(v390, v432);
            let v436: usize = 0_i32 as usize;
            let v440: usize = 1_i32 as usize;
            let v456: clap::builder::ValueRange = if (v440) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v436..)
            } else {
                let v454: string = string("clap::builder::ValueRange::new($0..=$1)");
                clap::builder::ValueRange::new(v436..=v440)
            };
            let v458: string = string("r#\"contract\"#");
            let v459: &'static str = r#"contract"#;
            let v461: clap::Arg = clap::Arg::new(v459);
            let v463: clap::Arg = v461.short('c');
            let v464: string = string("r#\"contract\"#");
            let v465: &'static str = r#"contract"#;
            let v467: clap::Arg = v463.long(v465);
            let v469: clap::Arg = v467.num_args(v456);
            let v471: clap::Arg = v469.require_equals(true);
            let v472: string = string("r#\"\"#");
            let v473: &str = r#""#;
            let v475: clap::Arg = v471.default_missing_value(v473);
            let v477: clap::Command = clap::Command::arg(v434, v475);
            let v479: string = string("r#\"cleanup\"#");
            let v480: &'static str = r#"cleanup"#;
            let v482: clap::Arg = clap::Arg::new(v480);
            let v484: clap::Arg = v482.short('l');
            let v485: string = string("r#\"cleanup\"#");
            let v486: &'static str = r#"cleanup"#;
            let v488: clap::Arg = v484.long(v486);
            let v490: string = string("r#\"true\"#");
            let v491: &str = r#"true"#;
            let v493: clap::Arg = v488.default_value(v491);
            let v495: clap::ArgAction = clap::ArgAction::SetFalse;
            let v497: clap::Arg = v493.action(v495);
            let v499: clap::Command = clap::Command::arg(v477, v497);
            let v501: clap::Command = clap::Command::subcommand(v322, v499);
            let v503: string = string("r#\"typescript\"#");
            let v504: &'static str = r#"typescript"#;
            let v506: clap::Command = clap::Command::new(v504);
            let v507: string = string("r#\"fs-path\"#");
            let v508: &'static str = r#"fs-path"#;
            let v510: clap::Arg = clap::Arg::new(v508);
            let v512: clap::Arg = v510.short('f');
            let v513: string = string("r#\"fs-path\"#");
            let v514: &'static str = r#"fs-path"#;
            let v516: clap::Arg = v512.long(v514);
            let v518: clap::Arg = v516.required(true);
            let v520: clap::Command = clap::Command::arg(v506, v518);
            let v521: string = string("r#\"NAME\"#");
            let v523: string = string("r#\"VERSION\"#");
            let v525: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v527: usize = 1_i32 as usize;
            let v531: usize = 0_i32 as usize;
            let v546: clap::builder::ValueRange = if (v531) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v527..)
            } else {
                let v544: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v527..v531)
            };
            let v547: string = string("r#\"deps\"#");
            let v548: &'static str = r#"deps"#;
            let v550: clap::Arg = clap::Arg::new(v548);
            let v552: clap::Arg = v550.short('d');
            let v553: string = string("r#\"deps\"#");
            let v554: &'static str = r#"deps"#;
            let v556: clap::Arg = v552.long(v554);
            let v558: Vec<&'static str> = v525.to_vec();
            let v560: clap::Arg = v556.value_names(v558);
            let v562: clap::Arg = v560.num_args(v546);
            let v564: clap::ArgAction = clap::ArgAction::Append;
            let v566: clap::Arg = v562.action(v564);
            let v568: clap::Command = clap::Command::arg(v520, v566);
            let v570: clap::Command = clap::Command::subcommand(v501, v568);
            let v572: string = string("r#\"python\"#");
            let v573: &'static str = r#"python"#;
            let v575: clap::Command = clap::Command::new(v573);
            let v576: string = string("r#\"fs-path\"#");
            let v577: &'static str = r#"fs-path"#;
            let v579: clap::Arg = clap::Arg::new(v577);
            let v581: clap::Arg = v579.short('f');
            let v582: string = string("r#\"fs-path\"#");
            let v583: &'static str = r#"fs-path"#;
            let v585: clap::Arg = v581.long(v583);
            let v587: clap::Arg = v585.required(true);
            let v589: clap::Command = clap::Command::arg(v575, v587);
            let v590: string = string("r#\"NAME\"#");
            let v592: string = string("r#\"VERSION\"#");
            let v594: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v596: usize = 1_i32 as usize;
            let v600: usize = 0_i32 as usize;
            let v615: clap::builder::ValueRange = if (v600) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v596..)
            } else {
                let v613: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v596..v600)
            };
            let v616: string = string("r#\"deps\"#");
            let v617: &'static str = r#"deps"#;
            let v619: clap::Arg = clap::Arg::new(v617);
            let v621: clap::Arg = v619.short('d');
            let v622: string = string("r#\"deps\"#");
            let v623: &'static str = r#"deps"#;
            let v625: clap::Arg = v621.long(v623);
            let v627: Vec<&'static str> = v594.to_vec();
            let v629: clap::Arg = v625.value_names(v627);
            let v631: clap::Arg = v629.num_args(v615);
            let v633: clap::ArgAction = clap::ArgAction::Append;
            let v635: clap::Arg = v631.action(v633);
            let v637: clap::Command = clap::Command::arg(v589, v635);
            let v639: clap::Command = clap::Command::subcommand(v570, v637);
            let v641: string = string("r#\"dib\"#");
            let v642: &'static str = r#"dib"#;
            let v644: clap::Command = clap::Command::new(v642);
            let v646: string = string("r#\"path\"#");
            let v647: &'static str = r#"path"#;
            let v649: clap::Arg = clap::Arg::new(v647);
            let v651: clap::Arg = v649.short('p');
            let v652: string = string("r#\"path\"#");
            let v653: &'static str = r#"path"#;
            let v655: clap::Arg = v651.long(v653);
            let v657: clap::Arg = v655.required(true);
            let v659: clap::Command = clap::Command::arg(v644, v657);
            let v661: string = string("clap::value_parser!(u8).into()");
            let v662: clap::builder::ValueParser = clap::value_parser!(u8).into();
            let v664: string = string("r#\"retries\"#");
            let v665: &'static str = r#"retries"#;
            let v667: clap::Arg = clap::Arg::new(v665);
            let v669: clap::Arg = v667.short('r');
            let v670: string = string("r#\"retries\"#");
            let v671: &'static str = r#"retries"#;
            let v673: clap::Arg = v669.long(v671);
            let v675: clap::Arg = v673.value_parser(v662);
            let v677: clap::Command = clap::Command::arg(v659, v675);
            let v679: string = string("r#\"working-directory\"#");
            let v680: &'static str = r#"working-directory"#;
            let v682: clap::Arg = clap::Arg::new(v680);
            let v684: clap::Arg = v682.short('w');
            let v685: string = string("r#\"working-directory\"#");
            let v686: &'static str = r#"working-directory"#;
            let v688: clap::Arg = v684.long(v686);
            let v690: clap::Command = clap::Command::arg(v677, v688);
            clap::Command::subcommand(v639, v690)
        }
        pub fn closure0(unitVar: (), unitVar_1: ()) {
            let v1_1: bool = true;
            () //;
        } /* /*;
          {
              let v4: string = string("*/ #[test] fn verify_app() { //");
              let v5: bool = */
        #[test]
        fn verify_app() {
            //;
            let v6: clap::Command = Spiral::method0();
            clap::Command::debug_assert(v6);
            {
                //;
                ()
            }
        }
        pub fn method4(v0_1: string) -> string {
            v0_1
        }
        pub fn method5() -> string {
            string("")
        }
        pub fn closure3(unitVar: (), v0_1: string) -> Spiral::US5 {
            Spiral::US5::US5_0(v0_1)
        }
        pub fn method6() -> Func1<string, Spiral::US5> {
            Func1::new(move |v: string| Spiral::closure3((), v))
        }
        pub fn method3(v0_1: string) -> string {
            let v6: string = Spiral::method4(v0_1);
            let v8: Result<std::string::String, std::env::VarError> = std::env::var(&*v6);
            let v10: bool = true;
            let _result_map_ = v8.map(|x| {
                //;
                let v12: std::string::String = x;
                let v14: string = fable_library_rust::String_::fromString(v12);
                let v16: bool = true;
                v14
            });
            let v18: Result<string, std::env::VarError> = _result_map_;
            let v19: string = Spiral::method5();
            v18.unwrap_or(v19)
        }
        pub fn method2() -> (Spiral::US1, Spiral::US2) {
            let v1_1: string = Spiral::method3(string("TRACE_LEVEL"));
            let v6: Spiral::US1 = if string("Verbose") == (v1_1.clone()) {
                Spiral::US1::US1_0(Spiral::US0::US0_0)
            } else {
                Spiral::US1::US1_1
            };
            (
                match &v6 {
                    Spiral::US1::US1_0(v6_0_0) => Spiral::US1::US1_0(
                        match &v6 {
                            Spiral::US1::US1_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    _ => {
                        let v13: Spiral::US1 = if string("Debug") == (v1_1.clone()) {
                            Spiral::US1::US1_0(Spiral::US0::US0_1)
                        } else {
                            Spiral::US1::US1_1
                        };
                        match &v13 {
                            Spiral::US1::US1_0(v13_0_0) => Spiral::US1::US1_0(
                                match &v13 {
                                    Spiral::US1::US1_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => {
                                let v20: Spiral::US1 = if string("Info") == (v1_1.clone()) {
                                    Spiral::US1::US1_0(Spiral::US0::US0_2)
                                } else {
                                    Spiral::US1::US1_1
                                };
                                match &v20 {
                                    Spiral::US1::US1_0(v20_0_0) => Spiral::US1::US1_0(
                                        match &v20 {
                                            Spiral::US1::US1_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => {
                                        let v27: Spiral::US1 =
                                            if string("Warning") == (v1_1.clone()) {
                                                Spiral::US1::US1_0(Spiral::US0::US0_3)
                                            } else {
                                                Spiral::US1::US1_1
                                            };
                                        match &v27 {
                                            Spiral::US1::US1_0(v27_0_0) => Spiral::US1::US1_0(
                                                match &v27 {
                                                    Spiral::US1::US1_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            ),
                                            _ => {
                                                let v34: Spiral::US1 =
                                                    if string("Critical") == (v1_1.clone()) {
                                                        Spiral::US1::US1_0(Spiral::US0::US0_4)
                                                    } else {
                                                        Spiral::US1::US1_1
                                                    };
                                                match &v34 {
                                                    Spiral::US1::US1_0(v34_0_0) => {
                                                        Spiral::US1::US1_0(
                                                            match &v34 {
                                                                Spiral::US1::US1_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => Spiral::US1::US1_1,
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                if (Spiral::method3(string("AUTOMATION"))) != string("True") {
                    Spiral::US2::US2_1
                } else {
                    Spiral::US2::US2_0({
                        let _arg: DateTime = DateTime::now();
                        _arg.ticks()
                    })
                },
            )
        }
        pub fn closure4(unitVar: (), v0_1: string) {
            ();
        }
        pub fn method1(
            v0_1: Spiral::US0,
        ) -> (
            LrcPtr<Spiral::Mut0>,
            LrcPtr<Spiral::Mut1>,
            LrcPtr<Spiral::Mut2>,
            LrcPtr<Spiral::Mut3>,
            LrcPtr<Spiral::Mut4>,
            Option<i64>,
        ) {
            let patternInput: (Spiral::US1, Spiral::US2) = Spiral::method2();
            let _run_target_args__v3: (Spiral::US1, Spiral::US2) =
                (patternInput.0.clone(), patternInput.1.clone());
            let v173: Spiral::US2 = _run_target_args__v3.1.clone();
            let v172: Spiral::US1 = _run_target_args__v3.0.clone();
            (
                LrcPtr::new(Spiral::Mut0 {
                    l0: MutCell::new(1_i64),
                }),
                LrcPtr::new(Spiral::Mut1 {
                    l0: MutCell::new(Func1::new(move |v: string| Spiral::closure4((), v))),
                }),
                LrcPtr::new(Spiral::Mut2 {
                    l0: MutCell::new(true),
                }),
                LrcPtr::new(Spiral::Mut3 {
                    l0: MutCell::new(string("")),
                }),
                LrcPtr::new(Spiral::Mut4 {
                    l0: MutCell::new(match &v172 {
                        Spiral::US1::US1_0(v172_0_0) => match &v172 {
                            Spiral::US1::US1_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => v0_1.clone(),
                    }),
                }),
                match &v173 {
                    Spiral::US2::US2_0(v173_0_0) => Some(match &v173 {
                        Spiral::US2::US2_0(x) => x.clone(),
                        _ => unreachable!(),
                    }),
                    _ => None::<i64>,
                },
            )
        }
        pub fn closure2(unitVar: (), unitVar_1: ()) {
            if Spiral::TraceState::trace_state().get().clone().is_none() {
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::method1(Spiral::US0::US0_0);
                Spiral::TraceState::trace_state().set(Some((
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
        pub fn method7(v0_1: Spiral::US0) -> bool {
            let v3: () = {
                Spiral::closure2((), ());
                ()
            };
            let patternInput: (
                LrcPtr<Spiral::Mut0>,
                LrcPtr<Spiral::Mut1>,
                LrcPtr<Spiral::Mut2>,
                LrcPtr<Spiral::Mut3>,
                LrcPtr<Spiral::Mut4>,
                Option<i64>,
            ) = Spiral::TraceState::trace_state().get().clone().unwrap();
            let v42: Spiral::US0 = (patternInput.4.clone()).l0.get().clone();
            if ((patternInput.2.clone()).l0.get().clone()) == false {
                false
            } else {
                (find(
                    v0_1,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Spiral::US0::US0_0, 0_i32)),
                        LrcPtr::new((Spiral::US0::US0_1, 1_i32)),
                        LrcPtr::new((Spiral::US0::US0_2, 2_i32)),
                        LrcPtr::new((Spiral::US0::US0_3, 3_i32)),
                        LrcPtr::new((Spiral::US0::US0_4, 4_i32)),
                    ])))),
                )) >= (find(
                    v42,
                    ofSeq(ofList(ofArray(new_array(&[
                        LrcPtr::new((Spiral::US0::US0_0, 0_i32)),
                        LrcPtr::new((Spiral::US0::US0_1, 1_i32)),
                        LrcPtr::new((Spiral::US0::US0_2, 2_i32)),
                        LrcPtr::new((Spiral::US0::US0_3, 3_i32)),
                        LrcPtr::new((Spiral::US0::US0_4, 4_i32)),
                    ])))),
                ))
            }
        }
        pub fn closure6(unitVar: (), v0_1: i64) -> Spiral::US2 {
            Spiral::US2::US2_0(v0_1)
        }
        pub fn method9() -> Func1<i64, Spiral::US2> {
            Func1::new(move |v: i64| Spiral::closure6((), v))
        }
        pub fn method10() -> string {
            string("hh:mm:ss")
        }
        pub fn method11() -> string {
            string("HH:mm:ss")
        }
        pub fn method8(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
        ) -> string {
            let v182: Spiral::US2 = defaultValue(Spiral::US2::US2_1, map(Spiral::method9(), v5));
            let v300: DateTime = match &v182 {
                Spiral::US2::US2_0(v182_0_0) => {
                    let v252: TimeSpan = TimeSpan::new_ticks(
                        ({
                            let _arg: DateTime = DateTime::now();
                            _arg.ticks()
                        }) - (match &v182 {
                            Spiral::US2::US2_0(x) => x.clone(),
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
            let v302: string = Spiral::method10();
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
        pub fn closure7(v0_1: LrcPtr<Spiral::Mut3>, v1_1: string, unitVar: ()) {
            let v3: string = append((v0_1.l0.get().clone()), (v1_1));
            v0_1.l0.set(v3);
            ()
        }
        pub fn method13(v0_1: char) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v9: () = {
                Spiral::closure7(v2.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method15() -> string {
            string("\u{001b}[0m")
        }
        pub fn method12() -> string {
            let v7: string = Spiral::method13(getCharAt(toLower(string("Debug")), 0_i32));
            let v14: &str = inline_colorization::color_bright_blue;
            let v21: &str = &*v7;
            let v49: &str = inline_colorization::color_reset;
            let v51: std::string::String = format!("{}{}{}", v14, v21, v49);
            fable_library_rust::String_::fromString(v51)
        }
        pub fn method17(v0_1: Array<string>) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral::closure7(v2.clone(), string("args"), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v53: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method18(v0_1: string) -> string {
            trimEndChars(
                trimStartChars(v0_1, toArray(empty::<char>())),
                toArray(ofArray(new_array(&[' ', '/']))),
            )
        }
        pub fn method16(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: Array<string>,
        ) -> string {
            let v9: string = Spiral::method17(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.main"),
                v9
            ))
        }
        pub fn closure8(v0_1: LrcPtr<Spiral::Mut0>, unitVar: ()) {
            let v2: i64 = (v0_1.l0.get().clone()) + 1_i64;
            v0_1.l0.set(v2);
            ()
        }
        pub fn closure10(v0_1: string, unitVar: ()) {
            printfn!("{0}", v0_1);
        }
        pub fn closure9(unitVar: (), v0_1: string) {
            let v3: () = {
                Spiral::closure10(v0_1, ());
                ()
            };
            ()
        }
        pub fn method19(v0_1: string) {
            let v3: () = {
                Spiral::closure2((), ());
                ()
            };
            let patternInput: (
                LrcPtr<Spiral::Mut0>,
                LrcPtr<Spiral::Mut1>,
                LrcPtr<Spiral::Mut2>,
                LrcPtr<Spiral::Mut3>,
                LrcPtr<Spiral::Mut4>,
                Option<i64>,
            ) = Spiral::TraceState::trace_state().get().clone().unwrap();
            let v44: () = {
                Spiral::closure8(patternInput.0.clone(), ());
                ()
            };
            println!("{}", v0_1.clone());
            ((patternInput.1.clone()).l0.get().clone())(v0_1)
        }
        pub fn closure5(v0_1: Array<string>, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v5: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method16(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method12(),
                    v0_1,
                ))
            };
        }
        pub fn closure11(unitVar: (), v0_1: &str) -> std::string::String {
            String::from(v0_1)
        }
        pub fn closure12(
            unitVar: (),
            _arg: (std::string::String, clap::ArgMatches),
        ) -> Spiral::US6 {
            Spiral::US6::US6_0(_arg.0.clone(), _arg.1.clone())
        }
        pub fn method21() -> Func1<(std::string::String, clap::ArgMatches), Spiral::US6> {
            Func1::new(move |arg10_0040: (std::string::String, clap::ArgMatches)| {
                Spiral::closure12((), arg10_0040)
            })
        }
        pub fn method22() -> string {
            string("gleam-path")
        }
        pub fn closure13(unitVar: (), v0_1: std::string::String) -> Spiral::US7 {
            Spiral::US7::US7_0(v0_1)
        }
        pub fn method23() -> Func1<std::string::String, Spiral::US7> {
            Func1::new(move |v: std::string::String| Spiral::closure13((), v))
        }
        pub fn method24() -> string {
            string("deps")
        }
        pub fn closure14(unitVar: (), v0_1: Vec<std::string::String>) -> Spiral::US8 {
            Spiral::US8::US8_0(v0_1)
        }
        pub fn method25() -> Func1<Vec<std::string::String>, Spiral::US8> {
            Func1::new(move |v: Vec<std::string::String>| Spiral::closure14((), v))
        }
        pub fn method26(v0_1: Vec<u8>) -> Vec<u8> {
            v0_1
        }
        pub fn method27(v0_1: string, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("extension"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral::closure7(v3.clone(), string("new_code"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v78: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method29() -> string {
            string("")
        }
        pub fn method30(v0_1: string) -> string {
            v0_1
        }
        pub fn method31(v0_1: i32, v1_1: LrcPtr<Spiral::Mut5>) -> bool {
            (v1_1.l0.get().clone()) < (v0_1)
        }
        pub fn method32() -> string {
            string("")
        }
        pub fn method28(v0_1: string) -> string {
            let v9: Array<u8> = {
                let _arg: LrcPtr<dyn Encoding> = get_UTF8();
                _arg.getBytes(v0_1)
            };
            let v11: Vec<u8> = v9.to_vec();
            let v13: std::io::Cursor<Vec<u8>> = std::io::Cursor::new(v11);
            let v15: std::io::BufReader<std::io::Cursor<Vec<u8>>> = std::io::BufReader::new(v13);
            let v17: bool = true;
            let mut v15 = v15;
            let result: sha2::Sha256 = sha2::Digest::new();
            {
                let v20: sha2::Sha256 = result;
                let v22: bool = true;
                let mut v20 = v20;
                let v24: usize = 0_i32 as usize;
                let v28: _ = [0_u8; 1024];
                let v30: bool = true;
                loop {
                    // rust.loop;
                    let v32: bool = true;
                    let mut v28 = v28;
                    let v34: Result<usize, std::io::Error> =
                        std::io::Read::read(&mut v15, &mut v28);
                    let v47: usize = v34.unwrap();
                    if (v47) == (v24) {
                        let v55: bool = true;
                        break;
                        ()
                    }
                    {
                        let v57: usize = v47;
                        let v74: &_ = if (v57) == (v28.len()) {
                            &v28[v24..]
                        } else {
                            &v28[v24..v57]
                        };
                        sha2::Digest::update(&mut v20, v74);
                        {
                            let v77: bool = true;
                        } // rust.loop;
                        let v79: bool = true;
                    } // rust.loop;
                    let v81: bool = true;
                } // rust.loop;
                let v83: bool = true;
                {
                    // rust.loop;
                    let v85: bool = true;
                    {
                        // rust.loop;
                        let v87: &[u8] = &sha2::Digest::finalize(v20);
                        let v89: Vec<u8> = v87.iter().map(|x| *x).collect::<Vec<_>>();
                        let v91: bool = true;
                        let _vec_map: Vec<_> = v89
                            .into_iter()
                            .map(|x| {
                                //;
                                let v93: u8 = x;
                                let v95: std::string::String = format!("{:02x}", v93);
                                let v97: string = fable_library_rust::String_::fromString(v95);
                                let v99: bool = true;
                                v97
                            })
                            .collect::<Vec<_>>();
                        let v101: Vec<string> = _vec_map;
                        let v103: Array<string> =
                            fable_library_rust::NativeArray_::array_from(v101.clone());
                        let _let__v107: LrcPtr<dyn IEnumerable_1<string>> = delay(Func0::new({
                            let v103 = v103.clone();
                            move || {
                                map_1(
                                    Func1::new({
                                        let v103 = v103.clone();
                                        move |i: i32| v103[i].clone()
                                    }),
                                    rangeNumeric(0_i32, 1_i32, (get_Count(v103.clone())) - 1_i32),
                                )
                            }
                        }));
                        let v116: string = Spiral::method29();
                        let v123: string = join(
                            if (v116.clone()) == string("\n") {
                                Spiral::method30(v116.clone())
                            } else {
                                v116
                            },
                            toArray_1(_let__v107),
                        );
                        Ok::<string, std::io::Error>(v123).unwrap()
                    }
                }
            }
        }
        pub fn method33() -> string {
            let v6: Result<std::path::PathBuf, std::io::Error> = std::env::current_dir();
            let v10: std::path::PathBuf = v6.unwrap();
            let v28: std::path::Display = v10.display();
            let v61: std::string::String = format!("{}", v28);
            fable_library_rust::String_::fromString(v61)
        }
        pub fn method35(v0_1: string, v1_1: string) -> string {
            let v13: &str = &*v0_1;
            let v46: std::string::String = String::from(v13);
            let v79: std::path::PathBuf = std::path::PathBuf::from(v46);
            let v112: &str = &*v1_1;
            let v145: std::string::String = String::from(v112);
            let v173: std::path::PathBuf = v79.join(v145);
            let v180: std::path::Display = v173.display();
            let v213: std::string::String = format!("{}", v180);
            fable_library_rust::String_::fromString(v213)
        }
        pub fn method37(v0_1: string) -> bool {
            let v12: &str = &*v0_1;
            let v45: std::string::String = String::from(v12);
            let v99: std::path::PathBuf = std::path::PathBuf::from(v45);
            if v99.clone().exists() {
                v99.is_file()
            } else {
                false
            }
        }
        pub fn closure15(unitVar: (), v0_1: string) -> bool {
            Spiral::method37(v0_1)
        }
        pub fn method38(v0_1: string) -> bool {
            let v12: &str = &*v0_1;
            let v45: std::string::String = String::from(v12);
            let v99: std::path::PathBuf = std::path::PathBuf::from(v45);
            if v99.clone().exists() {
                v99.is_dir()
            } else {
                false
            }
        }
        pub fn closure16(unitVar: (), v0_1: string) -> bool {
            Spiral::method38(v0_1)
        }
        pub fn method40(v0_1: string) -> Option<string> {
            let v9: &str = &*v0_1;
            let v42: std::string::String = String::from(v9);
            let v75: std::path::PathBuf = std::path::PathBuf::from(v42);
            let v103: Option<std::path::PathBuf> = v75.parent().map(std::path::PathBuf::from);
            let v105: bool = true;
            let _optionm_map_ = v103.map(|x| {
                //;
                let v107: std::path::PathBuf = x;
                let v114: std::path::Display = v107.display();
                let v147: std::string::String = format!("{}", v114);
                let v175: string = fable_library_rust::String_::fromString(v147);
                let v177: bool = true;
                v175
            });
            _optionm_map_
        }
        pub fn method41(
            v0_1: string,
            v1_1: string,
            v2: bool,
            v3: Func1<string, bool>,
            v4: string,
        ) -> Spiral::US10 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<bool> = MutCell::new(v2);
            let v3 = MutCell::new(v3.clone());
            let v4: MutCell<string> = MutCell::new(v4.clone());
            '_method41: loop {
                break '_method41 (if v3(Spiral::method35(v4.get().clone(), v0_1.get().clone())) {
                    Spiral::US10::US10_0(v4.get().clone())
                } else {
                    let v8: Option<string> = Spiral::method40(v4.get().clone());
                    let v25: Spiral::US5 =
                        defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v8));
                    match &v25 {
                        Spiral::US5::US5_0(v25_0_0) => {
                            let v0_1_temp: string = v0_1.get().clone();
                            let v1_1_temp: string = v1_1.get().clone();
                            let v2_temp: bool = v2.get().clone();
                            let v3_temp = v3.get().clone();
                            let v4_temp: string = match &v25 {
                                Spiral::US5::US5_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method41;
                        }
                        _ => Spiral::US10::US10_1(append(
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
                                v0_1.get().clone(),
                                v1_1.get().clone(),
                                v4.get().clone()
                            ),
                        )),
                    }
                });
            }
        }
        pub fn method39(
            v0_1: string,
            v1_1: string,
            v2: bool,
            v3: Func1<string, bool>,
        ) -> Spiral::US10 {
            if v3(Spiral::method35(v1_1.clone(), v0_1.clone())) {
                Spiral::US10::US10_0(v1_1.clone())
            } else {
                let v7: Option<string> = Spiral::method40(v1_1.clone());
                let v24: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v7));
                match &v24 {
                    Spiral::US5::US5_0(v24_0_0) => Spiral::method41(
                        v0_1.clone(),
                        v1_1.clone(),
                        v2,
                        v3.clone(),
                        match &v24 {
                            Spiral::US5::US5_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    _ => Spiral::US10::US10_1(append(
                        (concat(new_array(&[
                            string("file_system.find_parent / No parent for "),
                            if v2 { string("file") } else { string("dir") },
                        ]))),
                        sprintf!(
                            " \'{}\' at \'{}\' (until \'{}\')",
                            v0_1.clone(),
                            v1_1.clone(),
                            v1_1.clone()
                        ),
                    )),
                }
            }
        }
        pub fn method36(v0_1: Spiral::US9, v1_1: string, v2: string) -> Spiral::US10 {
            let v3: bool = if let Spiral::US9::US9_0 = &v0_1 {
                true
            } else {
                false
            };
            Spiral::method39(
                v1_1,
                v2,
                v3,
                if v3 {
                    Func1::new(move |v: string| Spiral::closure15((), v))
                } else {
                    Func1::new(move |v_1: string| Spiral::closure16((), v_1))
                },
            )
        }
        pub fn method42() -> string {
            let v7: string = Spiral::method13(getCharAt(toLower(string("Warning")), 0_i32));
            let v14: &str = inline_colorization::color_yellow;
            let v21: &str = &*v7;
            let v49: &str = inline_colorization::color_reset;
            let v51: std::string::String = format!("{}{}{}", v14, v21, v49);
            fable_library_rust::String_::fromString(v51)
        }
        pub fn method44(v0_1: string, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("dir"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral::closure7(v3.clone(), string("error"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v78: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method43(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: string,
            v9: string,
        ) -> string {
            let v10: string = Spiral::method44(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.get_workspace_root"),
                v10
            ))
        }
        pub fn closure17(v0_1: string, v1_1: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_3) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method43(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method42(),
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn method49(v0_1: std::io::Error) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v9: std::string::String = format!("{:#?}", v0_1);
            let v48: () = {
                Spiral::closure7(v2.clone(), fable_library_rust::String_::fromString(v9), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn closure18(unitVar: (), v0_1: std::io::Error) -> string {
            Spiral::method49(v0_1)
        }
        pub fn method48() -> Func1<std::io::Error, string> {
            Func1::new(move |v: std::io::Error| Spiral::closure18((), v))
        }
        pub fn closure19(unitVar: (), v0_1: std::path::PathBuf) -> Spiral::US11 {
            Spiral::US11::US11_0(v0_1)
        }
        pub fn method50() -> Func1<std::path::PathBuf, Spiral::US11> {
            Func1::new(move |v: std::path::PathBuf| Spiral::closure19((), v))
        }
        pub fn closure20(unitVar: (), v0_1: string) -> Spiral::US11 {
            Spiral::US11::US11_1(v0_1)
        }
        pub fn method51() -> Func1<string, Spiral::US11> {
            Func1::new(move |v: string| Spiral::closure20((), v))
        }
        pub fn method54(v0_1: string) -> string {
            let v12: &str = &*v0_1;
            let v45: std::string::String = String::from(v12);
            let v78: std::path::PathBuf = std::path::PathBuf::from(v45);
            let v106: Option<&std::ffi::OsStr> = v78.file_name();
            let v108: bool = true;
            let _optionm_map_ = v106.map(|x| {
                //;
                let v110: &std::ffi::OsStr = x;
                let v112: std::ffi::OsString = v110.to_os_string();
                let v114: Option<&str> = v112.to_str();
                let v116: &str = v114.unwrap();
                let v123: std::string::String = String::from(v116);
                let v151: string = fable_library_rust::String_::fromString(v123);
                let v153: bool = true;
                v151
            });
            let v155: Option<string> = _optionm_map_;
            let v172: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v155));
            match &v172 {
                Spiral::US5::US5_0(v172_0_0) => match &v172 {
                    Spiral::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                _ => string(""),
            }
        }
        pub fn method55(v0_1: string) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v9: () = {
                Spiral::closure7(v2.clone(), v0_1, ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method53(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: string,
            v4: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v5: string = Spiral::method54(v4.clone());
            let v6: Option<string> = Spiral::method40(v4.clone());
            let v23: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6));
            let v27: string = Spiral::method55(v3);
            if (v2) >= 11_u8 {
                let v31: string = append(
                    string("file_system.read_link / "),
                    sprintf!(
                        "path: {} / n: {} / path\': {} / name: {}",
                        v0_1.clone(),
                        v2,
                        v4.clone(),
                        v5.clone()
                    ),
                );
                let v38: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v31);
                Err(v38)
            } else {
                if let Spiral::US5::US5_0(v23_0_0) = &v23 {
                    if (v4.clone()) != string("") {
                        let v89: Result<std::path::PathBuf, std::io::Error> =
                            v1_1((v2) + 1_u8, v23_0_0.clone());
                        let v90 = Spiral::method48();
                        let v103: Result<std::path::PathBuf, string> = v89.map_err(|x| v90(x));
                        let v106 = Spiral::method50();
                        let v107 = Spiral::method51();
                        let v108: Spiral::US11 = match &v103 {
                            Err(v103_1_0) => v107(v103_1_0.clone()),
                            Ok(v103_0_0) => v106(v103_0_0.clone()),
                        };
                        match &v108 {
                            Spiral::US11::US11_0(v108_0_0) => {
                                let v147: string = Spiral::method35(
                                    toString(v108_0_0.clone().display()),
                                    v5.clone(),
                                );
                                let v154: &str = &*v147;
                                let v187: std::string::String = String::from(v154);
                                let v220: std::path::PathBuf = std::path::PathBuf::from(v187);
                                Ok(v220)
                            }
                            Spiral::US11::US11_1(v108_1_0) => {
                                let v265: string = append(
                                    string("file_system.read_link / "),
                                    sprintf!(
                                        "error\': {} / error: {} / name: {}",
                                        v108_1_0.clone(),
                                        v27.clone(),
                                        v5.clone()
                                    ),
                                );
                                let v272: std::io::Error =
                                    std::io::Error::new(std::io::ErrorKind::Other, &*v265);
                                Err(v272)
                            }
                        }
                    } else {
                        let v318: string =
                            append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                                   sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                            v0_1.clone(), v27.clone(),
                                            v4.clone(), v5.clone()));
                        let v325: std::io::Error =
                            std::io::Error::new(std::io::ErrorKind::Other, &*v318);
                        Err(v325)
                    }
                } else {
                    let v370: string =
                        append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                               sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                        v0_1, v27.clone(), v4, v5.clone()));
                    let v377: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v370);
                    Err(v377)
                }
            }
        }
        pub fn method52(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v9: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v2.clone());
            let v10 = Spiral::method48();
            let v23: Result<std::path::PathBuf, string> = v9.map_err(|x| v10(x));
            let v26 = Spiral::method50();
            let v27 = Spiral::method51();
            let v28: Spiral::US11 = match &v23 {
                Err(v23_1_0) => v27(v23_1_0.clone()),
                Ok(v23_0_0) => v26(v23_0_0.clone()),
            };
            match &v28 {
                Spiral::US11::US11_0(v28_0_0) => Ok(v28_0_0.clone()),
                Spiral::US11::US11_1(v28_1_0) => Spiral::method53(
                    v0_1.clone(),
                    Func2::new({
                        let v0_1 = v0_1.clone();
                        move |b0: u8, b1: string| {
                            (Func1::new({
                                let v0_1 = v0_1.clone();
                                move |v: u8| Spiral::closure21(v0_1.clone(), v)
                            }))(b0)(b1)
                        }
                    }),
                    v1_1,
                    v28_1_0.clone(),
                    v2.clone(),
                ),
            }
        }
        pub fn closure22(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            Spiral::method52(v0_1, v1_1, v2)
        }
        pub fn closure21(
            v0_1: string,
            v1_1: u8,
        ) -> Func1<string, Result<std::path::PathBuf, std::io::Error>> {
            Func1::new({
                let v0_1 = v0_1.clone();
                let v1_1 = v1_1.clone();
                move |v: string| Spiral::closure22(v0_1.clone(), v1_1, v)
            })
        }
        pub fn method56(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v4: string = Spiral::method54(v0_1.clone());
            let v5: Option<string> = Spiral::method40(v0_1.clone());
            let v22: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v5));
            let v26: string = Spiral::method55(v3);
            if (v2) >= 11_u8 {
                let v30: string = append(
                    string("file_system.read_link / "),
                    sprintf!(
                        "path: {} / n: {} / path\': {} / name: {}",
                        v0_1.clone(),
                        v2,
                        v0_1.clone(),
                        v4.clone()
                    ),
                );
                let v37: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v30);
                Err(v37)
            } else {
                if let Spiral::US5::US5_0(v22_0_0) = &v22 {
                    if (v0_1.clone()) != string("") {
                        let v88: Result<std::path::PathBuf, std::io::Error> =
                            v1_1((v2) + 1_u8, v22_0_0.clone());
                        let v89 = Spiral::method48();
                        let v102: Result<std::path::PathBuf, string> = v88.map_err(|x| v89(x));
                        let v105 = Spiral::method50();
                        let v106 = Spiral::method51();
                        let v107: Spiral::US11 = match &v102 {
                            Err(v102_1_0) => v106(v102_1_0.clone()),
                            Ok(v102_0_0) => v105(v102_0_0.clone()),
                        };
                        match &v107 {
                            Spiral::US11::US11_0(v107_0_0) => {
                                let v146: string = Spiral::method35(
                                    toString(v107_0_0.clone().display()),
                                    v4.clone(),
                                );
                                let v153: &str = &*v146;
                                let v186: std::string::String = String::from(v153);
                                let v219: std::path::PathBuf = std::path::PathBuf::from(v186);
                                Ok(v219)
                            }
                            Spiral::US11::US11_1(v107_1_0) => {
                                let v264: string = append(
                                    string("file_system.read_link / "),
                                    sprintf!(
                                        "error\': {} / error: {} / name: {}",
                                        v107_1_0.clone(),
                                        v26.clone(),
                                        v4.clone()
                                    ),
                                );
                                let v271: std::io::Error =
                                    std::io::Error::new(std::io::ErrorKind::Other, &*v264);
                                Err(v271)
                            }
                        }
                    } else {
                        let v317: string =
                            append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                                   sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                            v0_1.clone(), v26.clone(),
                                            v0_1.clone(), v4.clone()));
                        let v324: std::io::Error =
                            std::io::Error::new(std::io::ErrorKind::Other, &*v317);
                        Err(v324)
                    }
                } else {
                    let v369: string =
                        append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                               sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                        v0_1.clone(), v26.clone(), v0_1,
                                        v4.clone()));
                    let v376: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v369);
                    Err(v376)
                }
            }
        }
        pub fn method47(v0_1: string, v1_1: u8) -> Result<std::path::PathBuf, std::io::Error> {
            let v8: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v0_1.clone());
            let v9 = Spiral::method48();
            let v22: Result<std::path::PathBuf, string> = v8.map_err(|x| v9(x));
            let v25 = Spiral::method50();
            let v26 = Spiral::method51();
            let v27: Spiral::US11 = match &v22 {
                Err(v22_1_0) => v26(v22_1_0.clone()),
                Ok(v22_0_0) => v25(v22_0_0.clone()),
            };
            match &v27 {
                Spiral::US11::US11_0(v27_0_0) => Ok(v27_0_0.clone()),
                Spiral::US11::US11_1(v27_1_0) => Spiral::method56(
                    v0_1.clone(),
                    Func2::new({
                        let v0_1 = v0_1.clone();
                        move |b0: u8, b1: string| {
                            (Func1::new({
                                let v0_1 = v0_1.clone();
                                move |v: u8| Spiral::closure21(v0_1.clone(), v)
                            }))(b0)(b1)
                        }
                    }),
                    v1_1,
                    v27_1_0.clone(),
                ),
            }
        }
        pub fn method58(v0_1: bool) -> i32 {
            unbox::<i32>(fable_library_rust::Native_::getZero())
        }
        pub fn method59() -> i32 {
            unbox::<i32>(fable_library_rust::Native_::getZero())
        }
        pub fn method60(v0_1: i32, v1_1: i32) -> bool {
            unbox::<bool>(fable_library_rust::Native_::getZero())
        }
        pub fn method62(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: std::io::Error,
            v4: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v5: string = Spiral::method54(v4.clone());
            let v6: Option<string> = Spiral::method40(v4.clone());
            let v23: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6));
            let v27: string = Spiral::method49(v3);
            if (v2) >= 11_u8 {
                let v31: string = append(
                    string("file_system.read_link / "),
                    sprintf!(
                        "path: {} / n: {} / path\': {} / name: {}",
                        v0_1.clone(),
                        v2,
                        v4.clone(),
                        v5.clone()
                    ),
                );
                let v38: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v31);
                Err(v38)
            } else {
                if let Spiral::US5::US5_0(v23_0_0) = &v23 {
                    if (v4.clone()) != string("") {
                        let v89: Result<std::path::PathBuf, std::io::Error> =
                            v1_1((v2) + 1_u8, v23_0_0.clone());
                        let v90 = Spiral::method48();
                        let v103: Result<std::path::PathBuf, string> = v89.map_err(|x| v90(x));
                        let v106 = Spiral::method50();
                        let v107 = Spiral::method51();
                        let v108: Spiral::US11 = match &v103 {
                            Err(v103_1_0) => v107(v103_1_0.clone()),
                            Ok(v103_0_0) => v106(v103_0_0.clone()),
                        };
                        match &v108 {
                            Spiral::US11::US11_0(v108_0_0) => {
                                let v147: string = Spiral::method35(
                                    toString(v108_0_0.clone().display()),
                                    v5.clone(),
                                );
                                let v154: &str = &*v147;
                                let v187: std::string::String = String::from(v154);
                                let v220: std::path::PathBuf = std::path::PathBuf::from(v187);
                                Ok(v220)
                            }
                            Spiral::US11::US11_1(v108_1_0) => {
                                let v265: string = append(
                                    string("file_system.read_link / "),
                                    sprintf!(
                                        "error\': {} / error: {} / name: {}",
                                        v108_1_0.clone(),
                                        v27.clone(),
                                        v5.clone()
                                    ),
                                );
                                let v272: std::io::Error =
                                    std::io::Error::new(std::io::ErrorKind::Other, &*v265);
                                Err(v272)
                            }
                        }
                    } else {
                        let v318: string =
                            append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                                   sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                            v0_1.clone(), v27.clone(),
                                            v4.clone(), v5.clone()));
                        let v325: std::io::Error =
                            std::io::Error::new(std::io::ErrorKind::Other, &*v318);
                        Err(v325)
                    }
                } else {
                    let v370: string =
                        append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                               sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                        v0_1, v27.clone(), v4, v5.clone()));
                    let v377: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v370);
                    Err(v377)
                }
            }
        }
        pub fn method61(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v42: i32 = Spiral::method58(unbox::<bool>(fable_library_rust::Native_::getZero()));
            let v44: bool = Spiral::method60(Spiral::method59(), v42);
            if v44 {
                let v51: bool = unbox::<bool>(fable_library_rust::Native_::getZero());
                let v122: std::path::PathBuf = fable_library_rust::Native_::getZero();
                Ok(v122)
            } else {
                let v144: string =
                    append(string("file_system.read_link / Fsharp / The file or directory is not a reparse point. / "),
                           sprintf!("path: {} / result: {} / path\': {} / n: {}",
                                    v0_1.clone(), v44, v2.clone(), v1_1));
                Spiral::method62(
                    v0_1.clone(),
                    Func2::new({
                        let v0_1 = v0_1.clone();
                        move |b0: u8, b1: string| {
                            (Func1::new({
                                let v0_1 = v0_1.clone();
                                move |v: u8| Spiral::closure23(v0_1.clone(), v)
                            }))(b0)(b1)
                        }
                    }),
                    v1_1,
                    std::io::Error::new(std::io::ErrorKind::Other, &*v144),
                    v2,
                )
            }
        }
        pub fn closure24(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            Spiral::method61(v0_1, v1_1, v2)
        }
        pub fn closure23(
            v0_1: string,
            v1_1: u8,
        ) -> Func1<string, Result<std::path::PathBuf, std::io::Error>> {
            Func1::new({
                let v0_1 = v0_1.clone();
                let v1_1 = v1_1.clone();
                move |v: string| Spiral::closure24(v0_1.clone(), v1_1, v)
            })
        }
        pub fn method63(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: std::io::Error,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v4: string = Spiral::method54(v0_1.clone());
            let v5: Option<string> = Spiral::method40(v0_1.clone());
            let v22: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v5));
            let v26: string = Spiral::method49(v3);
            if (v2) >= 11_u8 {
                let v30: string = append(
                    string("file_system.read_link / "),
                    sprintf!(
                        "path: {} / n: {} / path\': {} / name: {}",
                        v0_1.clone(),
                        v2,
                        v0_1.clone(),
                        v4.clone()
                    ),
                );
                let v37: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v30);
                Err(v37)
            } else {
                if let Spiral::US5::US5_0(v22_0_0) = &v22 {
                    if (v0_1.clone()) != string("") {
                        let v88: Result<std::path::PathBuf, std::io::Error> =
                            v1_1((v2) + 1_u8, v22_0_0.clone());
                        let v89 = Spiral::method48();
                        let v102: Result<std::path::PathBuf, string> = v88.map_err(|x| v89(x));
                        let v105 = Spiral::method50();
                        let v106 = Spiral::method51();
                        let v107: Spiral::US11 = match &v102 {
                            Err(v102_1_0) => v106(v102_1_0.clone()),
                            Ok(v102_0_0) => v105(v102_0_0.clone()),
                        };
                        match &v107 {
                            Spiral::US11::US11_0(v107_0_0) => {
                                let v146: string = Spiral::method35(
                                    toString(v107_0_0.clone().display()),
                                    v4.clone(),
                                );
                                let v153: &str = &*v146;
                                let v186: std::string::String = String::from(v153);
                                let v219: std::path::PathBuf = std::path::PathBuf::from(v186);
                                Ok(v219)
                            }
                            Spiral::US11::US11_1(v107_1_0) => {
                                let v264: string = append(
                                    string("file_system.read_link / "),
                                    sprintf!(
                                        "error\': {} / error: {} / name: {}",
                                        v107_1_0.clone(),
                                        v26.clone(),
                                        v4.clone()
                                    ),
                                );
                                let v271: std::io::Error =
                                    std::io::Error::new(std::io::ErrorKind::Other, &*v264);
                                Err(v271)
                            }
                        }
                    } else {
                        let v317: string =
                            append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                                   sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                            v0_1.clone(), v26.clone(),
                                            v0_1.clone(), v4.clone()));
                        let v324: std::io::Error =
                            std::io::Error::new(std::io::ErrorKind::Other, &*v317);
                        Err(v324)
                    }
                } else {
                    let v369: string =
                        append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                               sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                        v0_1.clone(), v26.clone(), v0_1,
                                        v4.clone()));
                    let v376: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v369);
                    Err(v376)
                }
            }
        }
        pub fn method57(v0_1: string, v1_1: u8) -> Result<std::path::PathBuf, std::io::Error> {
            let v41: i32 = Spiral::method58(unbox::<bool>(fable_library_rust::Native_::getZero()));
            let v43: bool = Spiral::method60(Spiral::method59(), v41);
            if v43 {
                let v50: bool = unbox::<bool>(fable_library_rust::Native_::getZero());
                let v121: std::path::PathBuf = fable_library_rust::Native_::getZero();
                Ok(v121)
            } else {
                let v143: string =
                    append(string("file_system.read_link / Fsharp / The file or directory is not a reparse point. / "),
                           sprintf!("path: {} / result: {} / path\': {} / n: {}",
                                    v0_1.clone(), v43, v0_1.clone(), v1_1));
                Spiral::method63(
                    v0_1.clone(),
                    Func2::new({
                        let v0_1 = v0_1.clone();
                        move |b0: u8, b1: string| {
                            (Func1::new({
                                let v0_1 = v0_1.clone();
                                move |v: u8| Spiral::closure23(v0_1.clone(), v)
                            }))(b0)(b1)
                        }
                    }),
                    v1_1,
                    std::io::Error::new(std::io::ErrorKind::Other, &*v143),
                )
            }
        }
        pub fn method46(v0_1: string) -> Result<std::path::PathBuf, std::io::Error> {
            if Spiral::method38(v0_1.clone()) {
                std::fs::read_link(&*v0_1.clone())
            } else {
                Spiral::method47(v0_1, 0_u8)
            }
        }
        pub fn closure25(unitVar: (), v0_1: std::path::PathBuf) -> Spiral::US12 {
            Spiral::US12::US12_0(v0_1)
        }
        pub fn method64() -> Func1<std::path::PathBuf, Spiral::US12> {
            Func1::new(move |v: std::path::PathBuf| Spiral::closure25((), v))
        }
        pub fn method66(v0_1: string) -> string {
            v0_1
        }
        pub fn method67() -> string {
            string("")
        }
        pub fn method65(v0_1: string, v1_1: string, v2: string) -> string {
            let v6: Result<regex::Regex, regex::Error> = regex::Regex::new(&v0_1);
            let v10: regex::Regex = v6.unwrap();
            let v22: string = Spiral::method66(v2);
            let v24: std::borrow::Cow<str> = v10.replace_all(&*v22, &*v1_1);
            let v26: std::string::String = String::from(v24);
            fable_library_rust::String_::fromString(v26)
        }
        pub fn method45(v0_1: string) -> string {
            if (v0_1.clone()) == string("") {
                string("")
            } else {
                let v3: Result<std::path::PathBuf, std::io::Error> = Spiral::method46(v0_1.clone());
                let v7: Option<std::path::PathBuf> = v3.ok();
                let v35: Spiral::US12 =
                    defaultValue(Spiral::US12::US12_1, map(Spiral::method64(), v7));
                let v78: string = match &v35 {
                    Spiral::US12::US12_0(v35_0_0) => toString(
                        match &v35 {
                            Spiral::US12::US12_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone()
                        .display(),
                    ),
                    _ => v0_1.clone(),
                };
                let v83: string = Spiral::method65(
                    string("^\\\\\\\\\\?\\\\"),
                    string(""),
                    if (v78.clone()) == string("") {
                        v0_1.clone()
                    } else {
                        v78
                    },
                );
                if (length(v83.clone())) < 2_i32 {
                    v0_1.clone()
                } else {
                    replace(
                        concat(new_array(&[
                            toLower(ofChar(getCharAt(v83.clone(), 0_i32))),
                            getSlice(v83, Some(1_i32), None::<i32>),
                        ])),
                        string("\\"),
                        string("/"),
                    )
                }
            }
        }
        pub fn method34(v0_1: string) -> Spiral::US5 {
            let v5: Spiral::US10 = Spiral::method36(
                Spiral::US9::US9_1,
                Spiral::method35(string("spiral"), string("workspace")),
                v0_1.clone(),
            );
            match &v5 {
                Spiral::US10::US10_0(v5_0_0) => {
                    Spiral::US5::US5_0(Spiral::method45(v5_0_0.clone()))
                }
                Spiral::US10::US10_1(v5_1_0) => {
                    let v12: () = {
                        Spiral::closure17(v0_1.clone(), v5_1_0.clone(), ());
                        ()
                    };
                    Spiral::US5::US5_1
                }
            }
        }
        pub fn method68(v0_1: Vec<std::string::String>) -> Vec<std::string::String> {
            v0_1
        }
        pub fn method69(v0_1: Vec<std::string::String>) -> Vec<std::string::String> {
            v0_1
        }
        pub fn method70() -> string {
            string("\n")
        }
        pub fn method72(v0_1: string, v1_1: string) -> bool {
            if (Spiral::method37(v0_1.clone())) == false {
                false
            } else {
                let v20: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v0_1);
                let v65: Vec<u8> = Spiral::method26(v20.unwrap());
                let v67: Result<std::string::String, std::string::FromUtf8Error> =
                    std::string::String::from_utf8(v65);
                let v71: std::string::String = v67.unwrap();
                (v1_1) == (fable_library_rust::String_::fromString(v71))
            }
        }
        pub fn closure26(unitVar: (), v0_1: std::io::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method74() -> Func1<std::io::Error, std::string::String> {
            Func1::new(move |v: std::io::Error| Spiral::closure26((), v))
        }
        pub fn closure27(unitVar: (), unitVar_1: ()) -> Spiral::US13 {
            Spiral::US13::US13_0
        }
        pub fn method75() -> Func0<Spiral::US13> {
            Func0::new(move || Spiral::closure27((), ()))
        }
        pub fn closure28(unitVar: (), v0_1: std::string::String) -> Spiral::US13 {
            Spiral::US13::US13_1(v0_1)
        }
        pub fn method76() -> Func1<std::string::String, Spiral::US13> {
            Func1::new(move |v: std::string::String| Spiral::closure28((), v))
        }
        pub fn method77() -> string {
            let v7: string = Spiral::method13(getCharAt(toLower(string("Critical")), 0_i32));
            let v14: &str = inline_colorization::color_bright_red;
            let v21: &str = &*v7;
            let v49: &str = inline_colorization::color_reset;
            let v51: std::string::String = format!("{}{}{}", v14, v21, v49);
            fable_library_rust::String_::fromString(v51)
        }
        pub fn method79(v0_1: string, v1_1: std::string::String) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("dir"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral::closure7(v3.clone(), string("error"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v78: std::string::String = format!("{:#?}", v1_1);
            let v117: () = {
                Spiral::closure7(v3.clone(), fable_library_rust::String_::fromString(v78), ());
                ()
            };
            let v127: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method78(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: string,
            v9: std::string::String,
        ) -> string {
            let v10: string = Spiral::method79(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.create_dir"),
                v10
            ))
        }
        pub fn closure29(v0_1: string, v1_1: std::string::String, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method78(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method77(),
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn method80() -> string {
            let v7: string = Spiral::method13(getCharAt(toLower(string("Verbose")), 0_i32));
            let v14: &str = inline_colorization::color_bright_black;
            let v21: &str = &*v7;
            let v49: &str = inline_colorization::color_reset;
            let v51: std::string::String = format!("{}{}{}", v14, v21, v49);
            fable_library_rust::String_::fromString(v51)
        }
        pub fn method82(v0_1: string) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral::closure7(v2.clone(), string("dir"), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v39: () = {
                Spiral::closure7(v2.clone(), v0_1, ());
                ()
            };
            let v49: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method81(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: string,
        ) -> string {
            let v9: string = Spiral::method82(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.create_dir"),
                v9
            ))
        }
        pub fn closure30(v0_1: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_0) {
                let v5: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method81(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method80(),
                    v0_1,
                ))
            };
        }
        pub fn method84(v0_1: bool, v1_1: string) {
            if Spiral::method38(v1_1.clone()) {
                if v0_1 {
                    std::fs::remove_dir_all(&*v1_1.clone()).unwrap();
                    ()
                } else {
                    std::fs::remove_dir(&*v1_1).unwrap();
                    ()
                };
            }
            ()
        }
        pub fn closure31(v0_1: string, unitVar: ()) {
            Spiral::method84(true, v0_1);
        }
        pub fn method83(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure31(v0_1.clone(), ())
            })
        }
        pub fn method85(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure31(v0_1.clone(), ())
            })
        }
        pub fn method86(v0_1: string) -> bool {
            unbox::<bool>(fable_library_rust::Native_::getZero())
        }
        pub fn method88(v0_1: string, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("dir"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral::closure7(v3.clone(), string("result"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v78: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method87(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: string,
            v9: string,
        ) -> string {
            let v10: string = Spiral::method88(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.create_dir"),
                v10
            ))
        }
        pub fn closure32(v0_1: string, v1_1: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method87(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method12(),
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn method94(v0_1: string, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("ex"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral::closure7(v3.clone(), string("path"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v78: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method93(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: string,
            v9: string,
        ) -> string {
            let v10: string = Spiral::method94(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.delete_directory_async"),
                v10
            ))
        }
        pub fn closure34(v0_1: string, v1_1: LrcPtr<Exception>, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method93(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method12(),
                    sprintf!("{:?}", v1_1),
                    Spiral::method54(v0_1),
                ))
            };
        }
        pub fn method92(v0_1: string, v1_1: i64) -> Arc<Async<i64>> {
            fable_library_rust::Native_::getZero()
        }
        pub fn method91(v0_1: string, v1_1: i64) -> Arc<Async<i64>> {
            fable_library_rust::Native_::getZero()
        }
        pub fn method90(v0_1: string) -> Arc<Async<i64>> {
            Spiral::method91(v0_1, 0_i64)
        }
        pub fn closure33(v0_1: string, unitVar: ()) {
            let v1_1: Arc<Async<i64>> = Spiral::method90(v0_1);
            let v8: Arc<Async<()>> = fable_library_rust::Native_::getZero();
            fable_library_rust::Native_::getZero::<()>();
            ()
        }
        pub fn method89(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure33(v0_1.clone(), ())
            })
        }
        pub fn method95(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure33(v0_1.clone(), ())
            })
        }
        pub fn method73(v0_1: string) -> LrcPtr<dyn IDisposable> {
            let v156: Result<(), std::io::Error> = std::fs::create_dir_all(&*v0_1.clone());
            let v157 = Spiral::method74();
            let v170: Result<(), std::string::String> = v156.map_err(|x| v157(x));
            let v173 = Spiral::method75();
            let v174 = Spiral::method76();
            let v175: Spiral::US13 = match &v170 {
                Err(v170_1_0) => v174(v170_1_0.clone()),
                _ => v173(),
            };
            match &v175 {
                Spiral::US13::US13_0 => {
                    let v178: () = {
                        Spiral::closure30(v0_1.clone(), ());
                        ()
                    };
                    ()
                }
                Spiral::US13::US13_1(v175_1_0) => {
                    let v228: () = {
                        Spiral::closure29(
                            v0_1.clone(),
                            match &v175 {
                                Spiral::US13::US13_1(x) => x.clone(),
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
                let v280 = Spiral::method83(v0_1.clone());
                interface_cast!(
                    Spiral::Disposable::_ctor__3A5B6456(Func0::new({
                        let v280 = v280.clone();
                        move || v280.clone()()
                    })),
                    Lrc<dyn IDisposable>,
                )
            }
        }
        pub fn method71(v0_1: string, v1_1: string) {
            if (Spiral::method72(v0_1.clone(), v1_1.clone())) == false {
                let v7: string = defaultValue(string(""), Spiral::method40(v0_1.clone()));
                if (Spiral::method38(v7.clone())) == false {
                    let v12: LrcPtr<dyn IDisposable> = Spiral::method73(v7);
                    ()
                }
                std::fs::write(&*v0_1, &*v1_1).unwrap();
                ()
            };
        }
        pub fn method97(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
        ) -> string {
            v0_1
        }
        pub fn method99() -> string {
            string("")
        }
        pub fn closure37(v0_1: char, v1_1: LrcPtr<Spiral::UH0>) -> LrcPtr<Spiral::UH0> {
            LrcPtr::new(Spiral::UH0::UH0_1(v0_1, v1_1))
        }
        pub fn closure36(
            unitVar: (),
            v0_1: char,
        ) -> Func1<LrcPtr<Spiral::UH0>, LrcPtr<Spiral::UH0>> {
            Func1::new({
                let v0_1 = v0_1.clone();
                move |v: LrcPtr<Spiral::UH0>| Spiral::closure37(v0_1, v)
            })
        }
        pub fn method100() -> Func1<char, Func1<LrcPtr<Spiral::UH0>, LrcPtr<Spiral::UH0>>> {
            Func1::new(move |v: char| Spiral::closure36((), v))
        }
        pub fn method101(
            v0_1: LrcPtr<Spiral::UH0>,
            v1_1: LrcPtr<StringBuilder>,
            v2: i32,
            v3: i32,
        ) -> (LrcPtr<StringBuilder>, i32, i32) {
            let v0_1: MutCell<LrcPtr<Spiral::UH0>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
            let v2: MutCell<i32> = MutCell::new(v2);
            let v3: MutCell<i32> = MutCell::new(v3);
            '_method101: loop {
                break '_method101 (match v0_1.get().clone().as_ref() {
                    Spiral::UH0::UH0_0 => (v1_1.get().clone(), v2.get().clone(), v3.get().clone()),
                    Spiral::UH0::UH0_1(v0_1_1_0, v0_1_1_1) => {
                        let v4: char = match v0_1.get().clone().as_ref() {
                            Spiral::UH0::UH0_1(x, _) => x.clone(),
                            _ => unreachable!(),
                        };
                        let v6: bool = '\n' == (v4);
                        let patternInput: (i32, i32) = if v6 {
                            ((v2.get().clone()) + 1_i32, 1_i32)
                        } else {
                            (v2.get().clone(), (v3.get().clone()) + 1_i32)
                        };
                        {
                            let v0_1_temp: LrcPtr<Spiral::UH0> =
                                match v0_1.get().clone().as_ref() {
                                    Spiral::UH0::UH0_1(_, x) => x.clone(),
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
                            let v2_temp: i32 = patternInput.0.clone();
                            let v3_temp: i32 = patternInput.1.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            continue '_method101;
                        }
                    }
                });
            }
        }
        pub fn closure38(v0_1: i32, v1_1: i32, v2: string) -> string {
            if (v1_1) >= (v0_1) {
                v2.clone()
            } else {
                (Spiral::method102(v0_1, (v1_1) + 1_i32))(append((v2), string(" ")))
            }
        }
        pub fn method102(v0_1: i32, v1_1: i32) -> Func1<string, string> {
            Func1::new({
                let v0_1 = v0_1.clone();
                let v1_1 = v1_1.clone();
                move |v: string| Spiral::closure38(v0_1, v1_1, v)
            })
        }
        pub fn closure35(
            unitVar: (),
            _arg: (string, LrcPtr<StringBuilder>, i32, i32),
        ) -> Spiral::US15 {
            let v3: i32 = _arg.3.clone();
            let v2: i32 = _arg.2.clone();
            let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
            let v0_1: string = _arg.0.clone();
            if string("") == (v0_1.clone()) {
                Spiral::US15::US15_1(sprintf!(
                    "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                    '\"',
                    (v1_1.clone(), v2, v3)
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
                    let v50: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Spiral::method31(v48, v50.clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method101(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method100())(b0)(b1)
                                }),
                                v56,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US15::US15_0(
                            v10,
                            v39,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v99: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
                    Spiral::US15::US15_1(concat(new_array(&[
                        sprintf!(
                            "parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                            '\"',
                            v2,
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
                            ((Spiral::method102((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            }
        }
        pub fn closure39(
            unitVar: (),
            _arg: (string, LrcPtr<StringBuilder>, i32, i32),
        ) -> Spiral::US15 {
            let v3: i32 = _arg.3.clone();
            let v2: i32 = _arg.2.clone();
            let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
            let v0_1: string = _arg.0.clone();
            if string("") == (v0_1.clone()) {
                Spiral::US15::US15_1(sprintf!(
                    "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                    '\'',
                    (v1_1.clone(), v2, v3)
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
                    let v50: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Spiral::method31(v48, v50.clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method101(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method100())(b0)(b1)
                                }),
                                v56,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US15::US15_0(
                            v10,
                            v39,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v99: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
                    Spiral::US15::US15_1(concat(new_array(&[
                        sprintf!(
                            "parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                            '\'',
                            v2,
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
                            ((Spiral::method102((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            }
        }
        pub fn method103(
            v0_1: string,
            v1_1: LrcPtr<StringBuilder>,
            v2: LrcPtr<Spiral::UH1>,
        ) -> Spiral::US15 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<Spiral::UH1>> = MutCell::new(v2.clone());
            '_method103: loop {
                break '_method103 (match v2.get().clone().as_ref() {
                    Spiral::UH1::UH1_0 => {
                        Spiral::US15::US15_1(string("parsing.choice / no parsers succeeded"))
                    }
                    Spiral::UH1::UH1_1(v2_1_0, v2_1_1) => {
                        let v7: Spiral::US15 = (match v2.get().clone().as_ref() {
                            Spiral::UH1::UH1_1(x, _) => x.clone(),
                            _ => unreachable!(),
                        })((
                            v0_1.get().clone(),
                            v1_1.get().clone(),
                            1_i32,
                            1_i32,
                        ));
                        match &v7 {
                            Spiral::US15::US15_0(v7_0_0, v7_0_1, v7_0_2, v7_0_3, v7_0_4) => {
                                v7.clone()
                            }
                            _ => {
                                let v0_1_temp: string = v0_1.get().clone();
                                let v1_1_temp: LrcPtr<StringBuilder> = v1_1.get().clone();
                                let v2_temp: LrcPtr<Spiral::UH1> =
                                    match v2.get().clone().as_ref() {
                                        Spiral::UH1::UH1_1(_, x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone();
                                v0_1.set(v0_1_temp);
                                v1_1.set(v1_1_temp);
                                v2.set(v2_temp);
                                continue '_method103;
                            }
                        }
                    }
                });
            }
        }
        pub fn method104(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method104: loop {
                break '_method104 (if (v1_1.get().clone()) >= 2_i64 {
                    false
                } else {
                    let v11: Spiral::US17 = if (v1_1.get().clone()) == 0_i64 {
                        Spiral::US17::US17_0('\"')
                    } else {
                        let v5: i64 = (v1_1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral::US17::US17_0('\'')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            Spiral::US17::US17_1
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v11 {
                            Spiral::US17::US17_0(v11_0_0) => match &v11 {
                                Spiral::US17::US17_0(x) => x.clone(),
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
                        continue '_method104;
                    }
                });
            }
        }
        pub fn method105(
            v0_1: string,
            v1_1: string,
            v2: LrcPtr<StringBuilder>,
            v3: i32,
            v4: i32,
        ) -> (string, string, LrcPtr<StringBuilder>, i32, i32) {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<i32> = MutCell::new(v4);
            '_method105: loop {
                break '_method105 ({
                    let v131: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v25: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method104(v25, 0_i64)) == false {
                            let v56: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v62: string = ofChar(v25);
                            let v65: i32 = length(v62.clone());
                            let v66: Array<char> = new_init(&'\u{0000}', v65);
                            let v67: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method31(v65, v67.clone()) {
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
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method101(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method100())(b0)(b1)
                                            }),
                                            v73,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v25,
                                    v56,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v25,
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v143: Spiral::US15 = match &v131 {
                        Spiral::US15::US15_0(v131_0_0, v131_0_1, v131_0_2, v131_0_3, v131_0_4) => {
                            let v132: char = v131_0_0.clone();
                            Spiral::US15::US15_0(
                                if '\\' == (v132) { '/' } else { v132 },
                                v131_0_1.clone(),
                                v131_0_2.clone(),
                                v131_0_3.clone(),
                                v131_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v131_1_0) => Spiral::US15::US15_1(v131_1_0.clone()),
                    };
                    match &v143 {
                        Spiral::US15::US15_0(v143_0_0, v143_0_1, v143_0_2, v143_0_3, v143_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v143_0_0.clone())));
                            let v1_1_temp: string = v143_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v143_0_2.clone();
                            let v3_temp: i32 = v143_0_3.clone();
                            let v4_temp: i32 = v143_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method105;
                        }
                        _ => (
                            v0_1.get().clone(),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method106(
            v0_1: string,
            v1_1: LrcPtr<StringBuilder>,
            v2: i32,
            v3: i32,
            v4: LrcPtr<Spiral::UH1>,
        ) -> Spiral::US15 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
            let v2: MutCell<i32> = MutCell::new(v2);
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<LrcPtr<Spiral::UH1>> = MutCell::new(v4.clone());
            '_method106: loop {
                break '_method106 (match v4.get().clone().as_ref() {
                    Spiral::UH1::UH1_0 => {
                        Spiral::US15::US15_1(string("parsing.choice / no parsers succeeded"))
                    }
                    Spiral::UH1::UH1_1(v4_1_0, v4_1_1) => {
                        let v9: Spiral::US15 = (match v4.get().clone().as_ref() {
                            Spiral::UH1::UH1_1(x, _) => x.clone(),
                            _ => unreachable!(),
                        })((
                            v0_1.get().clone(),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                        ));
                        match &v9 {
                            Spiral::US15::US15_0(v9_0_0, v9_0_1, v9_0_2, v9_0_3, v9_0_4) => {
                                v9.clone()
                            }
                            _ => {
                                let v0_1_temp: string = v0_1.get().clone();
                                let v1_1_temp: LrcPtr<StringBuilder> = v1_1.get().clone();
                                let v2_temp: i32 = v2.get().clone();
                                let v3_temp: i32 = v3.get().clone();
                                let v4_temp: LrcPtr<Spiral::UH1> =
                                    match v4.get().clone().as_ref() {
                                        Spiral::UH1::UH1_1(_, x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone();
                                v0_1.set(v0_1_temp);
                                v1_1.set(v1_1_temp);
                                v2.set(v2_temp);
                                v3.set(v3_temp);
                                v4.set(v4_temp);
                                continue '_method106;
                            }
                        }
                    }
                });
            }
        }
        pub fn method107(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method107: loop {
                break '_method107 (if (v1_1.get().clone()) >= 3_i64 {
                    false
                } else {
                    let v15: Spiral::US17 = if (v1_1.get().clone()) == 0_i64 {
                        Spiral::US17::US17_0('\"')
                    } else {
                        let v5: i64 = (v1_1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral::US17::US17_0('\'')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            if (v8) == 0_i64 {
                                Spiral::US17::US17_0(' ')
                            } else {
                                let v11: i64 = (v8) - 1_i64;
                                Spiral::US17::US17_1
                            }
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v15 {
                            Spiral::US17::US17_0(v15_0_0) => match &v15 {
                                Spiral::US17::US17_0(x) => x.clone(),
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
                        continue '_method107;
                    }
                });
            }
        }
        pub fn method108(
            v0_1: string,
            v1_1: string,
            v2: LrcPtr<StringBuilder>,
            v3: i32,
            v4: i32,
        ) -> (string, string, LrcPtr<StringBuilder>, i32, i32) {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<i32> = MutCell::new(v4);
            '_method108: loop {
                break '_method108 ({
                    let v139: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method107(v29, 0_i64)) == false {
                            let v60: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v66: string = ofChar(v29);
                            let v69: i32 = length(v66.clone());
                            let v70: Array<char> = new_init(&'\u{0000}', v69);
                            let v71: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method31(v69, v71.clone()) {
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
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method101(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method100())(b0)(b1)
                                            }),
                                            v77,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v29,
                                    v60,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v29,
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v151: Spiral::US15 = match &v139 {
                        Spiral::US15::US15_0(v139_0_0, v139_0_1, v139_0_2, v139_0_3, v139_0_4) => {
                            let v140: char = v139_0_0.clone();
                            Spiral::US15::US15_0(
                                if '\\' == (v140) { '/' } else { v140 },
                                v139_0_1.clone(),
                                v139_0_2.clone(),
                                v139_0_3.clone(),
                                v139_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v139_1_0) => Spiral::US15::US15_1(v139_1_0.clone()),
                    };
                    match &v151 {
                        Spiral::US15::US15_0(v151_0_0, v151_0_1, v151_0_2, v151_0_3, v151_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v151_0_0.clone())));
                            let v1_1_temp: string = v151_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v151_0_2.clone();
                            let v3_temp: i32 = v151_0_3.clone();
                            let v4_temp: i32 = v151_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method108;
                        }
                        _ => (
                            v0_1.get().clone(),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method109(v0_1: string, v1_1: i32) -> i32 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<i32> = MutCell::new(v1_1);
            '_method109: loop {
                break '_method109 (if (v1_1.get().clone()) >= (length(v0_1.get().clone())) {
                    v1_1.get().clone()
                } else {
                    if ' ' == (getCharAt(v0_1.get().clone(), v1_1.get().clone())) {
                        let v0_1_temp: string = v0_1.get().clone();
                        let v1_1_temp: i32 = (v1_1.get().clone()) + 1_i32;
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        continue '_method109;
                    } else {
                        v1_1.get().clone()
                    }
                });
            }
        }
        pub fn method110(
            v0_1: string,
            v1_1: string,
            v2: LrcPtr<StringBuilder>,
            v3: i32,
            v4: i32,
        ) -> (string, string, LrcPtr<StringBuilder>, i32, i32) {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<i32> = MutCell::new(v4);
            '_method110: loop {
                break '_method110 ({
                    let v94: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.any_char / unexpected end of input / s: {:?}",
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
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
                        let v50: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Spiral::method31(v48, v50.clone()) {
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
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method101(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                        (Spiral::method100())(b0)(b1)
                                    }),
                                    v56,
                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                ),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Spiral::US15::US15_0(
                                v11,
                                v39,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        }
                    };
                    match &v94 {
                        Spiral::US15::US15_0(v94_0_0, v94_0_1, v94_0_2, v94_0_3, v94_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v94_0_0.clone())));
                            let v1_1_temp: string = v94_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v94_0_2.clone();
                            let v3_temp: i32 = v94_0_3.clone();
                            let v4_temp: i32 = v94_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method110;
                        }
                        _ => (
                            v0_1.get().clone(),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method98(v0_1: string) -> Spiral::US14 {
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
                let v15: LrcPtr<StringBuilder> =
                    StringBuilder::_ctor__Z721C83C5(Spiral::method99());
                fn v18(arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)) -> Spiral::US15 {
                    Spiral::closure35((), arg10_0040)
                }
                fn v19(arg10_0040_1: (string, LrcPtr<StringBuilder>, i32, i32)) -> Spiral::US15 {
                    Spiral::closure39((), arg10_0040_1)
                }
                let v23: Spiral::US15 = Spiral::method103(
                    v9.clone(),
                    v15.clone(),
                    LrcPtr::new(Spiral::UH1::UH1_1(
                        Func1::from(v18),
                        LrcPtr::new(Spiral::UH1::UH1_1(
                            Func1::from(v19),
                            LrcPtr::new(Spiral::UH1::UH1_0),
                        )),
                    )),
                );
                let v229: Spiral::US16 = match &v23 {
                    Spiral::US15::US15_0(v23_0_0, v23_0_1, v23_0_2, v23_0_3, v23_0_4) => {
                        let v28: i32 = v23_0_4.clone();
                        let v27: i32 = v23_0_3.clone();
                        let v26: LrcPtr<StringBuilder> = v23_0_2.clone();
                        let v25: string = v23_0_1.clone();
                        let v155: Spiral::US15 = if string("") == (v25.clone()) {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                (v26.clone(), v27, v28)
                            ))
                        } else {
                            let v49: char = getCharAt(v25.clone(), 0_i32);
                            if (Spiral::method104(v49, 0_i64)) == false {
                                let v80: string = getSlice(
                                    v25.clone(),
                                    Some(1_i32),
                                    Some((length(v25.clone())) - 1_i32),
                                );
                                let v86: string = ofChar(v49);
                                let v89: i32 = length(v86.clone());
                                let v90: Array<char> = new_init(&'\u{0000}', v89);
                                let v91: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method31(v89, v91.clone()) {
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
                                        Spiral::method101(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method100())(b0)(b1)
                                                    },
                                                ),
                                                v97,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v26.clone(),
                                            v27,
                                            v28,
                                        );
                                    Spiral::US15::US15_0(
                                        v49,
                                        v80,
                                        patternInput.0.clone(),
                                        patternInput.1.clone(),
                                        patternInput.2.clone(),
                                    )
                                }
                            } else {
                                Spiral::US15::US15_1(sprintf!("parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                                                      v49,
                                                                      toArray(ofArray(new_array(&['\"',
                                                                                                  '\'']))),
                                                                      (v26.clone(),
                                                                       v27,
                                                                       v28)))
                            }
                        };
                        let v167: Spiral::US15 = match &v155 {
                            Spiral::US15::US15_0(
                                v155_0_0,
                                v155_0_1,
                                v155_0_2,
                                v155_0_3,
                                v155_0_4,
                            ) => {
                                let v156: char = v155_0_0.clone();
                                Spiral::US15::US15_0(
                                    if '\\' == (v156) { '/' } else { v156 },
                                    v155_0_1.clone(),
                                    v155_0_2.clone(),
                                    v155_0_3.clone(),
                                    v155_0_4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v155_1_0) => {
                                Spiral::US15::US15_1(v155_1_0.clone())
                            }
                        };
                        let v187: Spiral::US16 = match &v167 {
                            Spiral::US15::US15_0(
                                v167_0_0,
                                v167_0_1,
                                v167_0_2,
                                v167_0_3,
                                v167_0_4,
                            ) => {
                                let patternInput_1: (
                                    string,
                                    string,
                                    LrcPtr<StringBuilder>,
                                    i32,
                                    i32,
                                ) = Spiral::method105(
                                    ofChar(v167_0_0.clone()),
                                    v167_0_1.clone(),
                                    v167_0_2.clone(),
                                    v167_0_3.clone(),
                                    v167_0_4.clone(),
                                );
                                Spiral::US16::US16_0(
                                    patternInput_1.0.clone(),
                                    patternInput_1.1.clone(),
                                    patternInput_1.2.clone(),
                                    patternInput_1.3.clone(),
                                    patternInput_1.4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v167_1_0) => {
                                Spiral::US16::US16_1(v167_1_0.clone())
                            }
                        };
                        let v197: Spiral::US16 = match &v187 {
                            Spiral::US16::US16_0(
                                v187_0_0,
                                v187_0_1,
                                v187_0_2,
                                v187_0_3,
                                v187_0_4,
                            ) => Spiral::US16::US16_0(
                                v187_0_0.clone(),
                                v187_0_1.clone(),
                                v187_0_2.clone(),
                                v187_0_3.clone(),
                                v187_0_4.clone(),
                            ),
                            _ => {
                                Spiral::US16::US16_0(string(""), v25.clone(), v26.clone(), v27, v28)
                            }
                        };
                        match &v197 {
                            Spiral::US16::US16_0(
                                v197_0_0,
                                v197_0_1,
                                v197_0_2,
                                v197_0_3,
                                v197_0_4,
                            ) => {
                                let v202: i32 = v197_0_4.clone();
                                let v201: i32 = v197_0_3.clone();
                                let v200: LrcPtr<StringBuilder> = v197_0_2.clone();
                                let v199: string = v197_0_1.clone();
                                let v206: Spiral::US15 = Spiral::method106(
                                    v199.clone(),
                                    v200.clone(),
                                    v201,
                                    v202,
                                    LrcPtr::new(Spiral::UH1::UH1_1(
                                        Func1::from(v18),
                                        LrcPtr::new(Spiral::UH1::UH1_1(
                                            Func1::from(v19),
                                            LrcPtr::new(Spiral::UH1::UH1_0),
                                        )),
                                    )),
                                );
                                match &v206 {
                                        Spiral::US15::US15_0(v206_0_0,
                                                             v206_0_1,
                                                             v206_0_2,
                                                             v206_0_3,
                                                             v206_0_4) =>
                                        Spiral::US16::US16_0(v197_0_0.clone(),
                                                             v206_0_1.clone(),
                                                             v206_0_2.clone(),
                                                             v206_0_3.clone(),
                                                             v206_0_4.clone()),
                                        Spiral::US15::US15_1(v206_1_0) =>
                                        Spiral::US16::US16_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                      v206_1_0.clone(),
                                                                      (v9.clone(),
                                                                       v15.clone(),
                                                                       1_i32,
                                                                       1_i32),
                                                                      (v25.clone(),
                                                                       v26.clone(),
                                                                       v27,
                                                                       v28),
                                                                      (v199.clone(),
                                                                       v200.clone(),
                                                                       v201,
                                                                       v202))),
                                    }
                            }
                            _ => Spiral::US16::US16_1(string("parsing.between / expected content")),
                        }
                    }
                    Spiral::US15::US15_1(v23_1_0) => Spiral::US16::US16_1(v23_1_0.clone()),
                };
                let v475: Spiral::US16 = match &v229 {
                    Spiral::US16::US16_0(v229_0_0, v229_0_1, v229_0_2, v229_0_3, v229_0_4) => {
                        v229.clone()
                    }
                    _ => {
                        let v372: Spiral::US15 = if string("") == (v9.clone()) {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                (v15.clone(), 1_i32, 1_i32)
                            ))
                        } else {
                            let v260: char = getCharAt(v9.clone(), 0_i32);
                            if (Spiral::method107(v260, 0_i64)) == false {
                                let v291: string = getSlice(
                                    v9.clone(),
                                    Some(1_i32),
                                    Some((length(v9.clone())) - 1_i32),
                                );
                                let v297: string = ofChar(v260);
                                let v300: i32 = length(v297.clone());
                                let v301: Array<char> = new_init(&'\u{0000}', v300);
                                let v302: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method31(v300, v302.clone()) {
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
                                        Spiral::method101(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method100())(b0)(b1)
                                                    },
                                                ),
                                                v308,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v15.clone(),
                                            1_i32,
                                            1_i32,
                                        );
                                    Spiral::US15::US15_0(
                                        v260,
                                        v291,
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone(),
                                        patternInput_2.2.clone(),
                                    )
                                }
                            } else {
                                Spiral::US15::US15_1(sprintf!("parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                                                      v260,
                                                                      toArray(ofArray(new_array(&['\"',
                                                                                                  '\'',
                                                                                                  ' ']))),
                                                                      (v15.clone(),
                                                                       1_i32,
                                                                       1_i32)))
                            }
                        };
                        let v384: Spiral::US15 = match &v372 {
                            Spiral::US15::US15_0(
                                v372_0_0,
                                v372_0_1,
                                v372_0_2,
                                v372_0_3,
                                v372_0_4,
                            ) => {
                                let v373: char = v372_0_0.clone();
                                Spiral::US15::US15_0(
                                    if '\\' == (v373) { '/' } else { v373 },
                                    v372_0_1.clone(),
                                    v372_0_2.clone(),
                                    v372_0_3.clone(),
                                    v372_0_4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v372_1_0) => {
                                Spiral::US15::US15_1(v372_1_0.clone())
                            }
                        };
                        let v404: Spiral::US16 = match &v384 {
                            Spiral::US15::US15_0(
                                v384_0_0,
                                v384_0_1,
                                v384_0_2,
                                v384_0_3,
                                v384_0_4,
                            ) => {
                                let patternInput_3: (
                                    string,
                                    string,
                                    LrcPtr<StringBuilder>,
                                    i32,
                                    i32,
                                ) = Spiral::method108(
                                    ofChar(v384_0_0.clone()),
                                    v384_0_1.clone(),
                                    v384_0_2.clone(),
                                    v384_0_3.clone(),
                                    v384_0_4.clone(),
                                );
                                Spiral::US16::US16_0(
                                    patternInput_3.0.clone(),
                                    patternInput_3.1.clone(),
                                    patternInput_3.2.clone(),
                                    patternInput_3.3.clone(),
                                    patternInput_3.4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v384_1_0) => {
                                Spiral::US16::US16_1(v384_1_0.clone())
                            }
                        };
                        match &v404 {
                            Spiral::US16::US16_0(
                                v404_0_0,
                                v404_0_1,
                                v404_0_2,
                                v404_0_3,
                                v404_0_4,
                            ) => v404.clone(),
                            _ => {
                                let v419: Spiral::US18 = if (length(v9.clone())) == 0_i32 {
                                    Spiral::US18::US18_0(v9.clone(), v15.clone(), 1_i32, 1_i32)
                                } else {
                                    Spiral::US18::US18_1(sprintf!(
                                        "parsing.eof / expected end of input / input: {:?}",
                                        v9.clone()
                                    ))
                                };
                                let v428: Spiral::US16 = match &v419 {
                                    Spiral::US18::US18_0(
                                        v419_0_0,
                                        v419_0_1,
                                        v419_0_2,
                                        v419_0_3,
                                    ) => Spiral::US16::US16_0(
                                        string(""),
                                        v419_0_0.clone(),
                                        v419_0_1.clone(),
                                        v419_0_2.clone(),
                                        v419_0_3.clone(),
                                    ),
                                    Spiral::US18::US18_1(v419_1_0) => {
                                        Spiral::US16::US16_1(v419_1_0.clone())
                                    }
                                };
                                match &v428 {
                                    Spiral::US16::US16_0(
                                        v428_0_0,
                                        v428_0_1,
                                        v428_0_2,
                                        v428_0_3,
                                        v428_0_4,
                                    ) => {
                                        let v430: string = v428_0_1.clone();
                                        Spiral::US16::US16_0(
                                            v428_0_0.clone(),
                                            getSlice(
                                                v430.clone(),
                                                Some(Spiral::method109(v430.clone(), 0_i32)),
                                                Some((length(v430)) - 1_i32),
                                            ),
                                            v428_0_2.clone(),
                                            v428_0_3.clone(),
                                            v428_0_4.clone(),
                                        )
                                    }
                                    Spiral::US16::US16_1(v428_1_0) => {
                                        Spiral::US16::US16_1(v428_1_0.clone())
                                    }
                                }
                            }
                        }
                    }
                };
                let v785: Spiral::US19 = match &v475 {
                    Spiral::US16::US16_0(v475_0_0, v475_0_1, v475_0_2, v475_0_3, v475_0_4) => {
                        let v480: i32 = v475_0_4.clone();
                        let v479: i32 = v475_0_3.clone();
                        let v478: LrcPtr<StringBuilder> = v475_0_2.clone();
                        let v477: string = v475_0_1.clone();
                        let v628: Spiral::US15 = if string("") == (v477.clone()) {
                            Spiral::US15::US15_1(sprintf!(
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
                                let v527: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method31(v525, v527.clone()) {
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
                                        Spiral::method101(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method100())(b0)(b1)
                                                    },
                                                ),
                                                v533,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v478.clone(),
                                            v479,
                                            v480,
                                        );
                                    Spiral::US15::US15_0(
                                        v487,
                                        v516,
                                        patternInput_4.0.clone(),
                                        patternInput_4.1.clone(),
                                        patternInput_4.2.clone(),
                                    )
                                }
                            } else {
                                let v576: i32 = (indexOf(v477.clone(), string("\n"))) - 1_i32;
                                Spiral::US15::US15_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                         ' ',
                                                                                         v479,
                                                                                         v480,
                                                                                         v478.clone(),
                                                                                         getSlice(v477.clone(),
                                                                                                  Some(0_i32),
                                                                                                  Some((if -2_i32
                                                                                                               ==
                                                                                                               (v576)
                                                                                                           {
                                                                                                            (length(v477.clone()))
                                                                                                                +
                                                                                                                1_i32
                                                                                                        } else {
                                                                                                            (v576)
                                                                                                                +
                                                                                                                1_i32
                                                                                                        })
                                                                                                           -
                                                                                                           1_i32))),
                                                                                string("\n"),
                                                                                append(((Spiral::method102((v480)
                                                                                                               -
                                                                                                               1_i32,
                                                                                                           0_i32))(string(""))),
                                                                                       string("^")),
                                                                                string("\n")])))
                            }
                        };
                        let v640: Spiral::US20 = match &v628 {
                            Spiral::US15::US15_0(
                                v628_0_0,
                                v628_0_1,
                                v628_0_2,
                                v628_0_3,
                                v628_0_4,
                            ) => Spiral::US20::US20_0(
                                Spiral::US17::US17_0(v628_0_0.clone()),
                                v628_0_1.clone(),
                                v628_0_2.clone(),
                                v628_0_3.clone(),
                                v628_0_4.clone(),
                            ),
                            _ => Spiral::US20::US20_0(
                                Spiral::US17::US17_1,
                                v477.clone(),
                                v478.clone(),
                                v479,
                                v480,
                            ),
                        };
                        let v759: Spiral::US16 = match &v640 {
                            Spiral::US20::US20_0(
                                v640_0_0,
                                v640_0_1,
                                v640_0_2,
                                v640_0_3,
                                v640_0_4,
                            ) => {
                                let v645: i32 = v640_0_4.clone();
                                let v644: i32 = v640_0_3.clone();
                                let v643: LrcPtr<StringBuilder> = v640_0_2.clone();
                                let v642: string = v640_0_1.clone();
                                let v735: Spiral::US15 = if string("") == (v642.clone()) {
                                    Spiral::US15::US15_1(sprintf!(
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
                                    let v691: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method31(v689, v691.clone()) {
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
                                            Spiral::method101(
                                                foldBack(
                                                    Func2::new(
                                                        move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                            (Spiral::method100())(b0)(b1)
                                                        },
                                                    ),
                                                    v697,
                                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                                ),
                                                v643,
                                                v644,
                                                v645,
                                            );
                                        Spiral::US15::US15_0(
                                            v652,
                                            v680,
                                            patternInput_5.0.clone(),
                                            patternInput_5.1.clone(),
                                            patternInput_5.2.clone(),
                                        )
                                    }
                                };
                                match &v735 {
                                    Spiral::US15::US15_0(
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
                                        ) = Spiral::method110(
                                            ofChar(v735_0_0.clone()),
                                            v735_0_1.clone(),
                                            v735_0_2.clone(),
                                            v735_0_3.clone(),
                                            v735_0_4.clone(),
                                        );
                                        Spiral::US16::US16_0(
                                            patternInput_6.0.clone(),
                                            patternInput_6.1.clone(),
                                            patternInput_6.2.clone(),
                                            patternInput_6.3.clone(),
                                            patternInput_6.4.clone(),
                                        )
                                    }
                                    Spiral::US15::US15_1(v735_1_0) => {
                                        Spiral::US16::US16_1(v735_1_0.clone())
                                    }
                                }
                            }
                            Spiral::US20::US20_1(v640_1_0) => {
                                Spiral::US16::US16_1(v640_1_0.clone())
                            }
                        };
                        let v771: Spiral::US21 = match &v759 {
                            Spiral::US16::US16_0(
                                v759_0_0,
                                v759_0_1,
                                v759_0_2,
                                v759_0_3,
                                v759_0_4,
                            ) => Spiral::US21::US21_0(
                                Spiral::US5::US5_0(v759_0_0.clone()),
                                v759_0_1.clone(),
                                v759_0_2.clone(),
                                v759_0_3.clone(),
                                v759_0_4.clone(),
                            ),
                            _ => Spiral::US21::US21_0(
                                Spiral::US5::US5_1,
                                v477.clone(),
                                v478.clone(),
                                v479,
                                v480,
                            ),
                        };
                        match &v771 {
                            Spiral::US21::US21_0(
                                v771_0_0,
                                v771_0_1,
                                v771_0_2,
                                v771_0_3,
                                v771_0_4,
                            ) => Spiral::US19::US19_0(
                                v475_0_0.clone(),
                                v771_0_0.clone(),
                                v771_0_1.clone(),
                                v771_0_2.clone(),
                                v771_0_3.clone(),
                                v771_0_4.clone(),
                            ),
                            Spiral::US21::US21_1(v771_1_0) => {
                                Spiral::US19::US19_1(v771_1_0.clone())
                            }
                        }
                    }
                    Spiral::US16::US16_1(v475_1_0) => Spiral::US19::US19_1(v475_1_0.clone()),
                };
                match &v785 {
                    Spiral::US19::US19_0(
                        v785_0_0,
                        v785_0_1,
                        v785_0_2,
                        v785_0_3,
                        v785_0_4,
                        v785_0_5,
                    ) => Spiral::US14::US14_0(v785_0_0.clone(), v785_0_1.clone()),
                    Spiral::US19::US19_1(v785_1_0) => Spiral::US14::US14_1(v785_1_0.clone()),
                }
            }
        }
        pub fn method113(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method113: loop {
                break '_method113 (if (v1_1.get().clone()) >= 4_i64 {
                    false
                } else {
                    let v19: Spiral::US17 = if (v1_1.get().clone()) == 0_i64 {
                        Spiral::US17::US17_0('\\')
                    } else {
                        let v5: i64 = (v1_1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral::US17::US17_0('`')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            if (v8) == 0_i64 {
                                Spiral::US17::US17_0('\"')
                            } else {
                                let v11: i64 = (v8) - 1_i64;
                                if (v11) == 0_i64 {
                                    Spiral::US17::US17_0(' ')
                                } else {
                                    let v14: i64 = (v11) - 1_i64;
                                    Spiral::US17::US17_1
                                }
                            }
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v19 {
                            Spiral::US17::US17_0(v19_0_0) => match &v19 {
                                Spiral::US17::US17_0(x) => x.clone(),
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
                        continue '_method113;
                    }
                });
            }
        }
        pub fn method114(
            v0_1: string,
            v1_1: string,
            v2: LrcPtr<StringBuilder>,
            v3: i32,
            v4: i32,
        ) -> (string, string, LrcPtr<StringBuilder>, i32, i32) {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<i32> = MutCell::new(v4);
            '_method114: loop {
                break '_method114 ({
                    let v147: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v33: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method113(v33, 0_i64)) == false {
                            let v64: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v70: string = ofChar(v33);
                            let v73: i32 = length(v70.clone());
                            let v74: Array<char> = new_init(&'\u{0000}', v73);
                            let v75: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method31(v73, v75.clone()) {
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
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method101(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method100())(b0)(b1)
                                            }),
                                            v81,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v33,
                                    v64,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v33,
                                toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    match &v147 {
                        Spiral::US15::US15_0(v147_0_0, v147_0_1, v147_0_2, v147_0_3, v147_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v147_0_0.clone())));
                            let v1_1_temp: string = v147_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v147_0_2.clone();
                            let v3_temp: i32 = v147_0_3.clone();
                            let v4_temp: i32 = v147_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method114;
                        }
                        _ => (
                            v0_1.get().clone(),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method116(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method116: loop {
                break '_method116 (if (v1_1.get().clone()) >= 3_i64 {
                    false
                } else {
                    let v15: Spiral::US17 = if (v1_1.get().clone()) == 0_i64 {
                        Spiral::US17::US17_0('\\')
                    } else {
                        let v5: i64 = (v1_1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral::US17::US17_0('`')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            if (v8) == 0_i64 {
                                Spiral::US17::US17_0('\"')
                            } else {
                                let v11: i64 = (v8) - 1_i64;
                                Spiral::US17::US17_1
                            }
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v15 {
                            Spiral::US17::US17_0(v15_0_0) => match &v15 {
                                Spiral::US17::US17_0(x) => x.clone(),
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
                        continue '_method116;
                    }
                });
            }
        }
        pub fn closure40(
            unitVar: (),
            _arg: (string, LrcPtr<StringBuilder>, i32, i32),
        ) -> Spiral::US16 {
            let v3: i32 = _arg.3.clone();
            let v2: i32 = _arg.2.clone();
            let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
            let v0_1: string = _arg.0.clone();
            let v152: Spiral::US15 = if string("") == (v0_1.clone()) {
                Spiral::US15::US15_1(sprintf!(
                    "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                    '\\',
                    (v1_1.clone(), v2, v3)
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
                    let v50: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Spiral::method31(v48, v50.clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method101(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method100())(b0)(b1)
                                }),
                                v56,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US15::US15_0(
                            v10,
                            v39,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v99: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
                    Spiral::US15::US15_1(concat(new_array(&[
                        sprintf!(
                            "parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                            '\\',
                            v2,
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
                            ((Spiral::method102((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            };
            let v251: Spiral::US15 = match &v152 {
                Spiral::US15::US15_0(v152_0_0, v152_0_1, v152_0_2, v152_0_3, v152_0_4) => {
                    let v157: i32 = v152_0_4.clone();
                    let v156: i32 = v152_0_3.clone();
                    let v155: LrcPtr<StringBuilder> = v152_0_2.clone();
                    let v154: string = v152_0_1.clone();
                    if string("") == (v154.clone()) {
                        Spiral::US15::US15_1(sprintf!(
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
                        let v203: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Spiral::method31(v201, v203.clone()) {
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
                            let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method101(
                                    foldBack(
                                        Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                            (Spiral::method100())(b0)(b1)
                                        }),
                                        v209,
                                        LrcPtr::new(Spiral::UH0::UH0_0),
                                    ),
                                    v155,
                                    v156,
                                    v157,
                                );
                            Spiral::US15::US15_0(
                                v164,
                                v192,
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                            )
                        }
                    }
                }
                Spiral::US15::US15_1(v152_1_0) => Spiral::US15::US15_1(v152_1_0.clone()),
            };
            match &v251 {
                Spiral::US15::US15_0(v251_0_0, v251_0_1, v251_0_2, v251_0_3, v251_0_4) => {
                    Spiral::US16::US16_0(
                        append((ofChar('\\')), (ofChar(v251_0_0.clone()))),
                        v251_0_1.clone(),
                        v251_0_2.clone(),
                        v251_0_3.clone(),
                        v251_0_4.clone(),
                    )
                }
                Spiral::US15::US15_1(v251_1_0) => Spiral::US16::US16_1(v251_1_0.clone()),
            }
        }
        pub fn closure41(
            unitVar: (),
            _arg: (string, LrcPtr<StringBuilder>, i32, i32),
        ) -> Spiral::US16 {
            let v3: i32 = _arg.3.clone();
            let v2: i32 = _arg.2.clone();
            let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
            let v0_1: string = _arg.0.clone();
            let v152: Spiral::US15 = if string("") == (v0_1.clone()) {
                Spiral::US15::US15_1(sprintf!(
                    "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                    '`',
                    (v1_1.clone(), v2, v3)
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
                    let v50: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Spiral::method31(v48, v50.clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method101(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method100())(b0)(b1)
                                }),
                                v56,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US15::US15_0(
                            v10,
                            v39,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v99: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
                    Spiral::US15::US15_1(concat(new_array(&[
                        sprintf!(
                            "parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                            '`',
                            v2,
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
                            ((Spiral::method102((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            };
            let v251: Spiral::US15 = match &v152 {
                Spiral::US15::US15_0(v152_0_0, v152_0_1, v152_0_2, v152_0_3, v152_0_4) => {
                    let v157: i32 = v152_0_4.clone();
                    let v156: i32 = v152_0_3.clone();
                    let v155: LrcPtr<StringBuilder> = v152_0_2.clone();
                    let v154: string = v152_0_1.clone();
                    if string("") == (v154.clone()) {
                        Spiral::US15::US15_1(sprintf!(
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
                        let v203: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Spiral::method31(v201, v203.clone()) {
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
                            let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method101(
                                    foldBack(
                                        Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                            (Spiral::method100())(b0)(b1)
                                        }),
                                        v209,
                                        LrcPtr::new(Spiral::UH0::UH0_0),
                                    ),
                                    v155,
                                    v156,
                                    v157,
                                );
                            Spiral::US15::US15_0(
                                v164,
                                v192,
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                            )
                        }
                    }
                }
                Spiral::US15::US15_1(v152_1_0) => Spiral::US15::US15_1(v152_1_0.clone()),
            };
            match &v251 {
                Spiral::US15::US15_0(v251_0_0, v251_0_1, v251_0_2, v251_0_3, v251_0_4) => {
                    Spiral::US16::US16_0(
                        append((ofChar('`')), (ofChar(v251_0_0.clone()))),
                        v251_0_1.clone(),
                        v251_0_2.clone(),
                        v251_0_3.clone(),
                        v251_0_4.clone(),
                    )
                }
                Spiral::US15::US15_1(v251_1_0) => Spiral::US16::US16_1(v251_1_0.clone()),
            }
        }
        pub fn method117(
            v0_1: string,
            v1_1: LrcPtr<StringBuilder>,
            v2: i32,
            v3: i32,
            v4: LrcPtr<Spiral::UH3>,
        ) -> Spiral::US16 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
            let v2: MutCell<i32> = MutCell::new(v2);
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<LrcPtr<Spiral::UH3>> = MutCell::new(v4.clone());
            '_method117: loop {
                break '_method117 (match v4.get().clone().as_ref() {
                    Spiral::UH3::UH3_0 => {
                        Spiral::US16::US16_1(string("parsing.choice / no parsers succeeded"))
                    }
                    Spiral::UH3::UH3_1(v4_1_0, v4_1_1) => {
                        let v9: Spiral::US16 = (match v4.get().clone().as_ref() {
                            Spiral::UH3::UH3_1(x, _) => x.clone(),
                            _ => unreachable!(),
                        })((
                            v0_1.get().clone(),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                        ));
                        match &v9 {
                            Spiral::US16::US16_0(v9_0_0, v9_0_1, v9_0_2, v9_0_3, v9_0_4) => {
                                v9.clone()
                            }
                            _ => {
                                let v0_1_temp: string = v0_1.get().clone();
                                let v1_1_temp: LrcPtr<StringBuilder> = v1_1.get().clone();
                                let v2_temp: i32 = v2.get().clone();
                                let v3_temp: i32 = v3.get().clone();
                                let v4_temp: LrcPtr<Spiral::UH3> =
                                    match v4.get().clone().as_ref() {
                                        Spiral::UH3::UH3_1(_, x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone();
                                v0_1.set(v0_1_temp);
                                v1_1.set(v1_1_temp);
                                v2.set(v2_temp);
                                v3.set(v3_temp);
                                v4.set(v4_temp);
                                continue '_method117;
                            }
                        }
                    }
                });
            }
        }
        pub fn method118(
            v0_1: LrcPtr<Spiral::UH2>,
            v1_1: LrcPtr<Spiral::UH2>,
        ) -> LrcPtr<Spiral::UH2> {
            let v0_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v1_1.clone());
            '_method118: loop {
                break '_method118 (match v0_1.get().clone().as_ref() {
                    Spiral::UH2::UH2_0 => v1_1.get().clone(),
                    Spiral::UH2::UH2_1(v0_1_1_0, v0_1_1_1) => {
                        let v0_1_temp: LrcPtr<Spiral::UH2> = match v0_1.get().clone().as_ref() {
                            Spiral::UH2::UH2_1(_, x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone();
                        let v1_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(Spiral::UH2::UH2_1(
                            match v0_1.get().clone().as_ref() {
                                Spiral::UH2::UH2_1(x, _) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                            v1_1.get().clone(),
                        ));
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        continue '_method118;
                    }
                });
            }
        }
        pub fn method115(
            v0_1: LrcPtr<Spiral::UH2>,
            v1_1: string,
            v2: LrcPtr<StringBuilder>,
            v3: i32,
            v4: i32,
        ) -> Spiral::US23 {
            let v0_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<i32> = MutCell::new(v4);
            '_method115: loop {
                break '_method115 ({
                    let v139: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method116(v29, 0_i64)) == false {
                            let v60: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v66: string = ofChar(v29);
                            let v69: i32 = length(v66.clone());
                            let v70: Array<char> = new_init(&'\u{0000}', v69);
                            let v71: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method31(v69, v71.clone()) {
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
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method101(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method100())(b0)(b1)
                                            }),
                                            v77,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v29,
                                    v60,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v29,
                                toArray(ofArray(new_array(&['\\', '`', '\"']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v154: Spiral::US16 = match &v139 {
                        Spiral::US15::US15_0(v139_0_0, v139_0_1, v139_0_2, v139_0_3, v139_0_4) => {
                            Spiral::US16::US16_0(
                                ofChar(v139_0_0.clone()),
                                v139_0_1.clone(),
                                v139_0_2.clone(),
                                v139_0_3.clone(),
                                v139_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v139_1_0) => Spiral::US16::US16_1(v139_1_0.clone()),
                    };
                    let v168: Spiral::US16 = match &v154 {
                        Spiral::US16::US16_0(v154_0_0, v154_0_1, v154_0_2, v154_0_3, v154_0_4) => {
                            v154.clone()
                        }
                        _ => Spiral::method117(
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                            LrcPtr::new(Spiral::UH3::UH3_1(
                                Func1::new(
                                    move |arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)| {
                                        Spiral::closure40((), arg10_0040)
                                    },
                                ),
                                LrcPtr::new(Spiral::UH3::UH3_1(
                                    Func1::new(
                                        move |arg10_0040_1: (
                                            string,
                                            LrcPtr<StringBuilder>,
                                            i32,
                                            i32,
                                        )| {
                                            Spiral::closure41((), arg10_0040_1)
                                        },
                                    ),
                                    LrcPtr::new(Spiral::UH3::UH3_0),
                                )),
                            )),
                        ),
                    };
                    match &v168 {
                        Spiral::US16::US16_0(v168_0_0, v168_0_1, v168_0_2, v168_0_3, v168_0_4) => {
                            let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(Spiral::UH2::UH2_1(
                                v168_0_0.clone(),
                                v0_1.get().clone(),
                            ));
                            let v1_1_temp: string = v168_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v168_0_2.clone();
                            let v3_temp: i32 = v168_0_3.clone();
                            let v4_temp: i32 = v168_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method115;
                        }
                        _ => Spiral::US23::US23_0(
                            Spiral::method118(v0_1.get().clone(), LrcPtr::new(Spiral::UH2::UH2_0)),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method119(v0_1: LrcPtr<Spiral::UH2>, v1_1: List<string>) -> List<string> {
            match v0_1.as_ref() {
                Spiral::UH2::UH2_0 => v1_1.clone(),
                Spiral::UH2::UH2_1(v0_1_1_0, v0_1_1_1) => cons(
                    match v0_1.as_ref() {
                        Spiral::UH2::UH2_1(x, _) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    Spiral::method119(
                        match v0_1.as_ref() {
                            Spiral::UH2::UH2_1(_, x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        v1_1.clone(),
                    ),
                ),
            }
        }
        pub fn method120(
            v0_1: LrcPtr<Spiral::UH2>,
            v1_1: string,
            v2: LrcPtr<StringBuilder>,
            v3: i32,
            v4: i32,
        ) -> Spiral::US23 {
            let v0_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<i32> = MutCell::new(v4);
            '_method120: loop {
                break '_method120 ({
                    let v139: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method116(v29, 0_i64)) == false {
                            let v60: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v66: string = ofChar(v29);
                            let v69: i32 = length(v66.clone());
                            let v70: Array<char> = new_init(&'\u{0000}', v69);
                            let v71: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method31(v69, v71.clone()) {
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
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method101(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method100())(b0)(b1)
                                            }),
                                            v77,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v29,
                                    v60,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v29,
                                toArray(ofArray(new_array(&['\\', '`', '\"']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v154: Spiral::US16 = match &v139 {
                        Spiral::US15::US15_0(v139_0_0, v139_0_1, v139_0_2, v139_0_3, v139_0_4) => {
                            Spiral::US16::US16_0(
                                ofChar(v139_0_0.clone()),
                                v139_0_1.clone(),
                                v139_0_2.clone(),
                                v139_0_3.clone(),
                                v139_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v139_1_0) => Spiral::US16::US16_1(v139_1_0.clone()),
                    };
                    match &v154 {
                        Spiral::US16::US16_0(v154_0_0, v154_0_1, v154_0_2, v154_0_3, v154_0_4) => {
                            let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(Spiral::UH2::UH2_1(
                                v154_0_0.clone(),
                                v0_1.get().clone(),
                            ));
                            let v1_1_temp: string = v154_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v154_0_2.clone();
                            let v3_temp: i32 = v154_0_3.clone();
                            let v4_temp: i32 = v154_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method120;
                        }
                        _ => Spiral::US23::US23_0(
                            Spiral::method118(v0_1.get().clone(), LrcPtr::new(Spiral::UH2::UH2_0)),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method112(
            v0_1: LrcPtr<Spiral::UH2>,
            v1_1: string,
            v2: LrcPtr<StringBuilder>,
            v3: i32,
            v4: i32,
        ) -> Spiral::US23 {
            let v0_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<i32> = MutCell::new(v4);
            '_method112: loop {
                break '_method112 ({
                    let v5: bool = string("") == (v1_1.get().clone());
                    let v147: Spiral::US15 = if v5 {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v33: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method113(v33, 0_i64)) == false {
                            let v64: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v70: string = ofChar(v33);
                            let v73: i32 = length(v70.clone());
                            let v74: Array<char> = new_init(&'\u{0000}', v73);
                            let v75: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method31(v73, v75.clone()) {
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
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method101(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method100())(b0)(b1)
                                            }),
                                            v81,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v33,
                                    v64,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v33,
                                toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v167: Spiral::US16 = match &v147 {
                        Spiral::US15::US15_0(v147_0_0, v147_0_1, v147_0_2, v147_0_3, v147_0_4) => {
                            let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method114(
                                    ofChar(v147_0_0.clone()),
                                    v147_0_1.clone(),
                                    v147_0_2.clone(),
                                    v147_0_3.clone(),
                                    v147_0_4.clone(),
                                );
                            Spiral::US16::US16_0(
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                                patternInput_1.3.clone(),
                                patternInput_1.4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v147_1_0) => Spiral::US16::US16_1(v147_1_0.clone()),
                    };
                    let v605: Spiral::US16 = match &v167 {
                        Spiral::US16::US16_0(v167_0_0, v167_0_1, v167_0_2, v167_0_3, v167_0_4) => {
                            v167.clone()
                        }
                        _ => {
                            let v321: Spiral::US15 = if v5 {
                                Spiral::US15::US15_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                                                               '\"',
                                                                               (v2.get().clone(),
                                                                                v3.get().clone(),
                                                                                v4.get().clone())))
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
                                    let v219: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method31(v217, v219.clone()) {
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
                                            Spiral::method101(
                                                foldBack(
                                                    Func2::new(
                                                        move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                            (Spiral::method100())(b0)(b1)
                                                        },
                                                    ),
                                                    v225,
                                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                                ),
                                                v2.get().clone(),
                                                v3.get().clone(),
                                                v4.get().clone(),
                                            );
                                        Spiral::US15::US15_0(
                                            v179,
                                            v208,
                                            patternInput_2.0.clone(),
                                            patternInput_2.1.clone(),
                                            patternInput_2.2.clone(),
                                        )
                                    }
                                } else {
                                    let v268: i32 =
                                        (indexOf(v1_1.get().clone(), string("\n"))) - 1_i32;
                                    Spiral::US15::US15_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                                      '\"',
                                                                                                      v3.get().clone(),
                                                                                                      v4.get().clone(),
                                                                                                      v2.get().clone(),
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
                                                                                             append(((Spiral::method102((v4.get().clone())
                                                                                                                            -
                                                                                                                            1_i32,
                                                                                                                        0_i32))(string(""))),
                                                                                                    string("^")),
                                                                                             string("\n")])))
                                }
                            };
                            let v536: Spiral::US16 = match &v321 {
                                Spiral::US15::US15_0(
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
                                    let v328: Spiral::US23 = Spiral::method115(
                                        LrcPtr::new(Spiral::UH2::UH2_0),
                                        v323.clone(),
                                        v324.clone(),
                                        v325,
                                        v326,
                                    );
                                    let v359: Spiral::US16 = match &v328 {
                                        Spiral::US23::US23_0(
                                            v328_0_0,
                                            v328_0_1,
                                            v328_0_2,
                                            v328_0_3,
                                            v328_0_4,
                                        ) => {
                                            let v335: List<string> = Spiral::method119(
                                                v328_0_0.clone(),
                                                empty::<string>(),
                                            );
                                            Spiral::US16::US16_0(
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
                                        Spiral::US23::US23_1(v328_1_0) => {
                                            Spiral::US16::US16_1(v328_1_0.clone())
                                        }
                                    };
                                    match &v359 {
                                        Spiral::US16::US16_0(
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
                                            let v513: Spiral::US15 = if string("") == (v361.clone())
                                            {
                                                Spiral::US15::US15_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
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
                                                    let v410: Array<char> =
                                                        new_init(&'\u{0000}', v409);
                                                    let v411: LrcPtr<Spiral::Mut5> =
                                                        LrcPtr::new(Spiral::Mut5 {
                                                            l0: MutCell::new(0_i32),
                                                        });
                                                    while Spiral::method31(v409, v411.clone()) {
                                                        let v413: i32 = v411.l0.get().clone();
                                                        let v414: char =
                                                            getCharAt(v406.clone(), v413);
                                                        v410.get_mut()[v413 as usize] = v414;
                                                        {
                                                            let v415: i32 = (v413) + 1_i32;
                                                            v411.l0.set(v415);
                                                            ()
                                                        }
                                                    }
                                                    {
                                                        let v417: List<char> =
                                                            ofArray(v410.clone());
                                                        let patternInput_3:
                                                                                     (LrcPtr<StringBuilder>,
                                                                                      i32,
                                                                                      i32) =
                                                                                 Spiral::method101(foldBack(Func2::new(move
                                                                                                                           |b0:
                                                                                                                                char,
                                                                                                                            b1:
                                                                                                                                LrcPtr<Spiral::UH0>|
                                                                                                                           (Spiral::method100())(b0)(b1)),
                                                                                                            v417,
                                                                                                            LrcPtr::new(Spiral::UH0::UH0_0)),
                                                                                                   v362.clone(),
                                                                                                   v363,
                                                                                                   v364);
                                                        Spiral::US15::US15_0(
                                                            v371,
                                                            v400,
                                                            patternInput_3.0.clone(),
                                                            patternInput_3.1.clone(),
                                                            patternInput_3.2.clone(),
                                                        )
                                                    }
                                                } else {
                                                    let v460: i32 =
                                                        (indexOf(v361.clone(), string("\n")))
                                                            - 1_i32;
                                                    Spiral::US15::US15_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
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
                                                                                                                 append(((Spiral::method102((v364)
                                                                                                                                                -
                                                                                                                                                1_i32,
                                                                                                                                            0_i32))(string(""))),
                                                                                                                        string("^")),
                                                                                                                 string("\n")])))
                                                }
                                            };
                                            match &v513 {
                                                                 Spiral::US15::US15_0(v513_0_0,
                                                                                      v513_0_1,
                                                                                      v513_0_2,
                                                                                      v513_0_3,
                                                                                      v513_0_4)
                                                                 =>
                                                                 Spiral::US16::US16_0(v359_0_0.clone(),
                                                                                      v513_0_1.clone(),
                                                                                      v513_0_2.clone(),
                                                                                      v513_0_3.clone(),
                                                                                      v513_0_4.clone()),
                                                                 Spiral::US15::US15_1(v513_1_0)
                                                                 =>
                                                                 Spiral::US16::US16_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                                               v513_1_0.clone(),
                                                                                               (v1_1.get().clone(),
                                                                                                v2.get().clone(),
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
                                        _ => Spiral::US16::US16_1(string(
                                            "parsing.between / expected content",
                                        )),
                                    }
                                }
                                Spiral::US15::US15_1(v321_1_0) => {
                                    Spiral::US16::US16_1(v321_1_0.clone())
                                }
                            };
                            match &v536 {
                                Spiral::US16::US16_0(
                                    v536_0_0,
                                    v536_0_1,
                                    v536_0_2,
                                    v536_0_3,
                                    v536_0_4,
                                ) => v536.clone(),
                                _ => {
                                    let v548: Spiral::US16 =
                                                     Spiral::method117(v1_1.get().clone(),
                                                                       v2.get().clone(),
                                                                       v3.get().clone(),
                                                                       v4.get().clone(),
                                                                       LrcPtr::new(Spiral::UH3::UH3_1(Func1::new(move
                                                                                                                     |arg10_0040:
                                                                                                                          (string,
                                                                                                                           LrcPtr<StringBuilder>,
                                                                                                                           i32,
                                                                                                                           i32)|
                                                                                                                     Spiral::closure40((),
                                                                                                                                       arg10_0040)),
                                                                                                      LrcPtr::new(Spiral::UH3::UH3_1(Func1::new(move
                                                                                                                                                    |arg10_0040_1:
                                                                                                                                                         (string,
                                                                                                                                                          LrcPtr<StringBuilder>,
                                                                                                                                                          i32,
                                                                                                                                                          i32)|
                                                                                                                                                    Spiral::closure41((),
                                                                                                                                                                      arg10_0040_1)),
                                                                                                                                     LrcPtr::new(Spiral::UH3::UH3_0))))));
                                    let v559: Spiral::US16 = match &v548 {
                                        Spiral::US16::US16_0(
                                            v548_0_0,
                                            v548_0_1,
                                            v548_0_2,
                                            v548_0_3,
                                            v548_0_4,
                                        ) => Spiral::US16::US16_0(
                                            string(""),
                                            v548_0_1.clone(),
                                            v548_0_2.clone(),
                                            v548_0_3.clone(),
                                            v548_0_4.clone(),
                                        ),
                                        Spiral::US16::US16_1(v548_1_0) => {
                                            Spiral::US16::US16_1(v548_1_0.clone())
                                        }
                                    };
                                    let v570: Spiral::US23 = match &v559 {
                                        Spiral::US16::US16_0(
                                            v559_0_0,
                                            v559_0_1,
                                            v559_0_2,
                                            v559_0_3,
                                            v559_0_4,
                                        ) => Spiral::method120(
                                            LrcPtr::new(Spiral::UH2::UH2_0),
                                            v559_0_1.clone(),
                                            v559_0_2.clone(),
                                            v559_0_3.clone(),
                                            v559_0_4.clone(),
                                        ),
                                        Spiral::US16::US16_1(v559_1_0) => {
                                            Spiral::US23::US23_1(v559_1_0.clone())
                                        }
                                    };
                                    match &v570 {
                                        Spiral::US23::US23_0(
                                            v570_0_0,
                                            v570_0_1,
                                            v570_0_2,
                                            v570_0_3,
                                            v570_0_4,
                                        ) => {
                                            let v577: List<string> = Spiral::method119(
                                                v570_0_0.clone(),
                                                empty::<string>(),
                                            );
                                            Spiral::US16::US16_0(
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
                                        Spiral::US23::US23_1(v570_1_0) => {
                                            Spiral::US16::US16_1(v570_1_0.clone())
                                        }
                                    }
                                }
                            }
                        }
                    };
                    match &v605 {
                        Spiral::US16::US16_0(v605_0_0, v605_0_1, v605_0_2, v605_0_3, v605_0_4) => {
                            let v610: i32 = v605_0_4.clone();
                            let v609: i32 = v605_0_3.clone();
                            let v608: LrcPtr<StringBuilder> = v605_0_2.clone();
                            let v607: string = v605_0_1.clone();
                            let v606: string = v605_0_0.clone();
                            let v612: i32 = Spiral::method109(v607.clone(), 0_i32);
                            let v648: Spiral::US18 = if 0_i32 == (v612) {
                                Spiral::US18::US18_1(string(
                                    "parsing.spaces1 / expected at least one space",
                                ))
                            } else {
                                Spiral::US18::US18_0(
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
                                Spiral::US18::US18_0(v648_0_0, v648_0_1, v648_0_2, v648_0_3) => {
                                    let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(
                                        Spiral::UH2::UH2_1(v606.clone(), v0_1.get().clone()),
                                    );
                                    let v1_1_temp: string = v648_0_0.clone();
                                    let v2_temp: LrcPtr<StringBuilder> = v648_0_1.clone();
                                    let v3_temp: i32 = v648_0_2.clone();
                                    let v4_temp: i32 = v648_0_3.clone();
                                    v0_1.set(v0_1_temp);
                                    v1_1.set(v1_1_temp);
                                    v2.set(v2_temp);
                                    v3.set(v3_temp);
                                    v4.set(v4_temp);
                                    continue '_method112;
                                }
                                _ => Spiral::US23::US23_0(
                                    Spiral::method118(
                                        v0_1.get().clone(),
                                        LrcPtr::new(Spiral::UH2::UH2_1(
                                            v606.clone(),
                                            LrcPtr::new(Spiral::UH2::UH2_0),
                                        )),
                                    ),
                                    v607.clone(),
                                    v608.clone(),
                                    v609,
                                    v610,
                                ),
                            }
                        }
                        _ => Spiral::US23::US23_0(
                            Spiral::method118(v0_1.get().clone(), LrcPtr::new(Spiral::UH2::UH2_0)),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method111(v0_1: string) -> Spiral::US22 {
            let _v0: MutCell<Option<Option<string>>> = MutCell::new(None::<Option<string>>);
            _v0.set(Some(Some(v0_1)));
            {
                let v21: Spiral::US23 = Spiral::method112(
                    LrcPtr::new(Spiral::UH2::UH2_0),
                    defaultValue(
                        string(""),
                        match &_v0.get().clone() {
                            None => panic!("{}", string("optionm\'.of_obj / _v0=None"),),
                            Some(_v0_0_0) => _v0_0_0.clone(),
                        },
                    ),
                    StringBuilder::_ctor__Z721C83C5(Spiral::method99()),
                    1_i32,
                    1_i32,
                );
                match &v21 {
                    Spiral::US23::US23_0(v21_0_0, v21_0_1, v21_0_2, v21_0_3, v21_0_4) => {
                        Spiral::US22::US22_0(toArray(Spiral::method119(
                            v21_0_0.clone(),
                            empty::<string>(),
                        )))
                    }
                    Spiral::US23::US23_1(v21_1_0) => Spiral::US22::US22_1(v21_1_0.clone()),
                }
            }
        }
        pub fn method122(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: Option<CancellationToken>,
            v4: Array<(string, string)>,
            v5: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v6: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v7: bool,
            v8: Option<string>,
        ) -> string {
            let v10: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v18: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v10.clone(), string("file_name"), ());
                ()
            };
            let v38: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v47: () = {
                Spiral::closure7(v10.clone(), v0_1, ());
                ()
            };
            let v57: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v67: () = {
                Spiral::closure7(v10.clone(), string("arguments"), ());
                ()
            };
            let v76: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v85: () = {
                Spiral::closure7(v10.clone(), v1_1, ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v104: () = {
                Spiral::closure7(v10.clone(), string("options"), ());
                ()
            };
            let v113: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v122: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v132: () = {
                Spiral::closure7(v10.clone(), string("command"), ());
                ()
            };
            let v141: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v150: () = {
                Spiral::closure7(v10.clone(), v2, ());
                ()
            };
            let v159: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v169: () = {
                Spiral::closure7(v10.clone(), string("cancellation_token"), ());
                ()
            };
            let v178: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v187: std::string::String = format!("{:#?}", v3);
            let v226: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v187),
                    (),
                );
                ()
            };
            let v235: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v245: () = {
                Spiral::closure7(v10.clone(), string("environment_variables"), ());
                ()
            };
            let v254: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v267: () = {
                Spiral::closure7(v10.clone(), sprintf!("{:?}", v4), ());
                ()
            };
            let v276: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v286: () = {
                Spiral::closure7(v10.clone(), string("on_line"), ());
                ()
            };
            let v295: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v304: std::string::String = format!("{:#?}", v5);
            let v343: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v304),
                    (),
                );
                ()
            };
            let v352: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v362: () = {
                Spiral::closure7(v10.clone(), string("stdin"), ());
                ()
            };
            let v371: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v380: std::string::String = format!("{:#?}", v6);
            let v419: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v380),
                    (),
                );
                ()
            };
            let v428: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v438: () = {
                Spiral::closure7(v10.clone(), string("trace"), ());
                ()
            };
            let v447: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v459: () = {
                Spiral::closure7(
                    v10.clone(),
                    if v7 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v468: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v478: () = {
                Spiral::closure7(v10.clone(), string("working_directory"), ());
                ()
            };
            let v487: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v496: std::string::String = format!("{:#?}", v8);
            let v535: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v496),
                    (),
                );
                ()
            };
            let v545: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            let v554: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            v10.l0.get().clone()
        }
        pub fn method121(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: string,
            v9: string,
            v10: string,
            v11: Option<CancellationToken>,
            v12: Array<(string, string)>,
            v13: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v14: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v15: bool,
            v16: Option<string>,
        ) -> string {
            let v17: string = Spiral::method122(v8, v9, v10, v11, v12, v13, v14, v15, v16);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options"),
                v17
            ))
        }
        pub fn closure42(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
            v7: string,
            v8: Vec<std::string::String>,
            unitVar: (),
        ) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v13: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v39: Option<i64> = patternInput.5.clone();
                let v38: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v37: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v36: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v35: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v34: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method121(
                    v34.clone(),
                    v35.clone(),
                    v36.clone(),
                    v37.clone(),
                    v38.clone(),
                    v39.clone(),
                    Spiral::method8(v34, v35, v36, v37, v38, v39),
                    Spiral::method12(),
                    v7,
                    sprintf!("{:?}", v8),
                    v0_1,
                    v1_1,
                    v2,
                    v3,
                    v4,
                    v5,
                    v6,
                ))
            };
        }
        pub fn closure43(
            unitVar: (),
            v0_1: Option<std::process::Child>,
        ) -> Option<std::process::Child> {
            v0_1
        }
        pub fn method123() -> Func1<Option<std::process::Child>, Option<std::process::Child>> {
            Func1::new(move |v: Option<std::process::Child>| Spiral::closure43((), v))
        }
        pub fn closure44(
            unitVar: (),
            v0_1: std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>,
        ) -> Spiral::US24 {
            Spiral::US24::US24_0(v0_1)
        }
        pub fn method124(
        ) -> Func1<std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>, Spiral::US24>
        {
            Func1::new(
                move |v: std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>| {
                    Spiral::closure44((), v)
                },
            )
        }
        pub fn closure45(unitVar: (), v0_1: std::string::String) -> Spiral::US24 {
            Spiral::US24::US24_1(v0_1)
        }
        pub fn method125() -> Func1<std::string::String, Spiral::US24> {
            Func1::new(move |v: std::string::String| Spiral::closure45((), v))
        }
        pub fn method127(v0_1: std::string::String) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral::closure7(v2.clone(), string("error"), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v39: std::string::String = format!("{:#?}", v0_1);
            let v78: () = {
                Spiral::closure7(v2.clone(), fable_library_rust::String_::fromString(v39), ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method126(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: std::string::String,
        ) -> string {
            let v9: string = Spiral::method127(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options / child error"),
                v9
            ))
        }
        pub fn closure46(v0_1: std::string::String, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v5: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method126(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method77(),
                    v0_1,
                ))
            };
        }
        pub fn method128(
            v0_1: std::sync::MutexGuard<Option<std::process::Child>>,
        ) -> std::sync::MutexGuard<Option<std::process::Child>> {
            v0_1
        }
        pub fn closure47(
            unitVar: (),
            v0_1: Option<std::process::ChildStdin>,
        ) -> Option<std::process::ChildStdin> {
            v0_1
        }
        pub fn method129(
        ) -> Func1<Option<std::process::ChildStdin>, Option<std::process::ChildStdin>> {
            Func1::new(move |v: Option<std::process::ChildStdin>| Spiral::closure47((), v))
        }
        pub fn closure48(
            unitVar: (),
            v0_1: std::sync::mpsc::Sender<std::string::String>,
        ) -> std::sync::mpsc::Sender<std::string::String> {
            v0_1
        }
        pub fn method130() -> Func1<
            std::sync::mpsc::Sender<std::string::String>,
            std::sync::mpsc::Sender<std::string::String>,
        > {
            Func1::new(move |v: std::sync::mpsc::Sender<std::string::String>| {
                Spiral::closure48((), v)
            })
        }
        pub fn method131() -> Func1<
            std::sync::mpsc::Sender<std::string::String>,
            std::sync::mpsc::Sender<std::string::String>,
        > {
            Func1::new(move |v: std::sync::mpsc::Sender<std::string::String>| {
                Spiral::closure48((), v)
            })
        }
        pub fn closure49(
            unitVar: (),
            v0_1: std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
        ) -> std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>> {
            v0_1
        }
        pub fn method132() -> Func1<
            std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
            std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
        > {
            Func1::new(
                move |v: std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>| {
                    Spiral::closure49((), v)
                },
            )
        }
        pub fn closure50(unitVar: (), v0_1: std::string::String) -> Spiral::US26 {
            Spiral::US26::US26_0(v0_1)
        }
        pub fn method133() -> Func1<std::string::String, Spiral::US26> {
            Func1::new(move |v: std::string::String| Spiral::closure50((), v))
        }
        pub fn closure51(unitVar: (), v0_1: std::string::String) -> Spiral::US26 {
            Spiral::US26::US26_1(v0_1)
        }
        pub fn method134() -> Func1<std::string::String, Spiral::US26> {
            Func1::new(move |v: std::string::String| Spiral::closure51((), v))
        }
        pub fn method136(v0_1: bool, v1_1: std::string::String) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("trace\'"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(
                    v3.clone(),
                    if v0_1 {
                        string("true")
                    } else {
                        string("false")
                    },
                    (),
                );
                ()
            };
            let v53: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v63: () = {
                Spiral::closure7(v3.clone(), string("e"), ());
                ()
            };
            let v72: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v81: std::string::String = format!("{:#?}", v1_1);
            let v120: () = {
                Spiral::closure7(v3.clone(), fable_library_rust::String_::fromString(v81), ());
                ()
            };
            let v130: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method135(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: bool,
            v9: std::string::String,
        ) -> string {
            let v10: string = Spiral::method136(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.stdio_line"),
                v10
            ))
        }
        pub fn closure52(v0_1: bool, v1_1: std::string::String, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method135(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method77(),
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn method138() -> string {
            let v1_1: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            v1_1.l0.get().clone()
        }
        pub fn method137(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: string,
        ) -> string {
            let v9: string = Spiral::method138();
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                v8,
                v9
            ))
        }
        pub fn closure53(v0_1: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_0) {
                let v5: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(if (v0_1.clone()) == string("") {
                    string("")
                } else {
                    Spiral::method137(
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        v30.clone(),
                        v31.clone(),
                        Spiral::method8(v26, v27, v28, v29, v30, v31),
                        Spiral::method80(),
                        v0_1,
                    )
                })
            };
        }
        pub fn closure54(
            unitVar: (),
            v0_1: std::sync::mpsc::SendError<std::string::String>,
        ) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method139(
        ) -> Func1<std::sync::mpsc::SendError<std::string::String>, std::string::String> {
            Func1::new(move |v: std::sync::mpsc::SendError<std::string::String>| {
                Spiral::closure54((), v)
            })
        }
        pub fn method140(v0_1: Result<(), string>) -> Result<(), string> {
            v0_1
        }
        pub fn closure55(
            unitVar: (),
            v0_1: Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>,
        ) -> Spiral::US27 {
            Spiral::US27::US27_0(v0_1)
        }
        pub fn method141() -> Func1<
            Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>,
            Spiral::US27,
        > {
            Func1::new(
                move |v: Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>| {
                    Spiral::closure55((), v)
                },
            )
        }
        pub fn method142(
            v0_1: std::sync::MutexGuard<Option<std::process::ChildStdin>>,
        ) -> std::sync::MutexGuard<Option<std::process::ChildStdin>> {
            v0_1
        }
        pub fn closure56(
            unitVar: (),
            v0_1: std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
        ) -> Spiral::US28 {
            Spiral::US28::US28_0(v0_1)
        }
        pub fn method143(
        ) -> Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, Spiral::US28>
        {
            Func1::new(
                move |v: std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>| {
                    Spiral::closure56((), v)
                },
            )
        }
        pub fn method144(
            v0_1: std::sync::MutexGuard<std::process::ChildStdin>,
        ) -> std::sync::MutexGuard<std::process::ChildStdin> {
            v0_1
        }
        pub fn closure57(unitVar: (), v0_1: std::process::Output) -> Spiral::US29 {
            Spiral::US29::US29_0(v0_1)
        }
        pub fn method145() -> Func1<std::process::Output, Spiral::US29> {
            Func1::new(move |v: std::process::Output| Spiral::closure57((), v))
        }
        pub fn closure58(unitVar: (), v0_1: std::string::String) -> Spiral::US29 {
            Spiral::US29::US29_1(v0_1)
        }
        pub fn method146() -> Func1<std::string::String, Spiral::US29> {
            Func1::new(move |v: std::string::String| Spiral::closure58((), v))
        }
        pub fn method147(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: std::string::String,
        ) -> string {
            let v9: string = Spiral::method127(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options / output error"),
                v9
            ))
        }
        pub fn closure59(v0_1: std::string::String, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v5: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method147(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method77(),
                    v0_1,
                ))
            };
        }
        pub fn closure60(unitVar: (), v0_1: i32) -> Spiral::US30 {
            Spiral::US30::US30_0(v0_1)
        }
        pub fn method148() -> Func1<i32, Spiral::US30> {
            Func1::new(move |v: i32| Spiral::closure60((), v))
        }
        pub fn method150(v0_1: i32, v1_1: i32) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral::closure7(v3.clone(), string("std_trace_length"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v78: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method149(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: i32,
        ) -> string {
            let v10: string = Spiral::method150(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options / result"),
                v10
            ))
        }
        pub fn closure61(v0_1: i32, v1_1: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_0) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method149(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method80(),
                    v0_1,
                    length(v1_1),
                ))
            };
        }
        pub fn method154(
            v0_1: string,
            v1_1: Spiral::US5,
            v2: string,
            v3: Option<CancellationToken>,
            v4: Array<(string, string)>,
            v5: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v6: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v7: bool,
            v8: Option<string>,
        ) -> string {
            let v10: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v18: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v10.clone(), string("file_name"), ());
                ()
            };
            let v38: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v47: () = {
                Spiral::closure7(v10.clone(), v0_1, ());
                ()
            };
            let v57: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v67: () = {
                Spiral::closure7(v10.clone(), string("arguments"), ());
                ()
            };
            let v76: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v89: () = {
                Spiral::closure7(v10.clone(), sprintf!("{:?}", v1_1), ());
                ()
            };
            let v98: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v108: () = {
                Spiral::closure7(v10.clone(), string("options"), ());
                ()
            };
            let v117: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v126: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v136: () = {
                Spiral::closure7(v10.clone(), string("command"), ());
                ()
            };
            let v145: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v154: () = {
                Spiral::closure7(v10.clone(), v2, ());
                ()
            };
            let v163: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v173: () = {
                Spiral::closure7(v10.clone(), string("cancellation_token"), ());
                ()
            };
            let v182: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v191: std::string::String = format!("{:#?}", v3);
            let v230: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v191),
                    (),
                );
                ()
            };
            let v239: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v249: () = {
                Spiral::closure7(v10.clone(), string("environment_variables"), ());
                ()
            };
            let v258: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v271: () = {
                Spiral::closure7(v10.clone(), sprintf!("{:?}", v4), ());
                ()
            };
            let v280: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v290: () = {
                Spiral::closure7(v10.clone(), string("on_line"), ());
                ()
            };
            let v299: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v308: std::string::String = format!("{:#?}", v5);
            let v347: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v308),
                    (),
                );
                ()
            };
            let v356: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v366: () = {
                Spiral::closure7(v10.clone(), string("stdin"), ());
                ()
            };
            let v375: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v384: std::string::String = format!("{:#?}", v6);
            let v423: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v384),
                    (),
                );
                ()
            };
            let v432: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v442: () = {
                Spiral::closure7(v10.clone(), string("trace"), ());
                ()
            };
            let v451: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v463: () = {
                Spiral::closure7(
                    v10.clone(),
                    if v7 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v472: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v482: () = {
                Spiral::closure7(v10.clone(), string("working_directory"), ());
                ()
            };
            let v491: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v500: std::string::String = format!("{:#?}", v8);
            let v539: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v500),
                    (),
                );
                ()
            };
            let v549: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            let v558: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            v10.l0.get().clone()
        }
        pub fn method153(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: string,
            v9: Spiral::US5,
            v10: string,
            v11: Option<CancellationToken>,
            v12: Array<(string, string)>,
            v13: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v14: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v15: bool,
            v16: Option<string>,
        ) -> string {
            let v17: string = Spiral::method154(v8, v9, v10, v11, v12, v13, v14, v15, v16);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options_async"),
                v17
            ))
        }
        pub fn closure62(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
            v7: Spiral::US5,
            v8: string,
            unitVar: (),
        ) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v13: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v39: Option<i64> = patternInput.5.clone();
                let v38: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v37: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v36: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v35: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v34: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method153(
                    v34.clone(),
                    v35.clone(),
                    v36.clone(),
                    v37.clone(),
                    v38.clone(),
                    v39.clone(),
                    Spiral::method8(v34, v35, v36, v37, v38, v39),
                    Spiral::method12(),
                    v8,
                    v7,
                    v0_1,
                    v1_1,
                    v2,
                    v3,
                    v4,
                    v5,
                    v6,
                ))
            };
        }
        pub fn method155(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
        ) -> Array<(string, string)> {
            v2
        }
        pub fn method158(v0_1: bool) -> string {
            unbox::<string>(fable_library_rust::Native_::getZero())
        }
        pub fn closure64(
            unitVar: (),
            v0_1: Func1<(i32, string, bool), Arc<Async<()>>>,
        ) -> Spiral::US31 {
            Spiral::US31::US31_0(v0_1)
        }
        pub fn method159() -> Func1<Func1<(i32, string, bool), Arc<Async<()>>>, Spiral::US31> {
            Func1::new(move |v: Func1<(i32, string, bool), Arc<Async<()>>>| {
                Spiral::closure64((), v)
            })
        }
        pub fn method160(v0_1: bool) -> i32 {
            unbox::<i32>(fable_library_rust::Native_::getZero())
        }
        pub fn closure65(v0_1: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_0) {
                let v5: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(if (v0_1.clone()) == string("") {
                    string("")
                } else {
                    Spiral::method137(
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        v30.clone(),
                        v31.clone(),
                        Spiral::method8(v26, v27, v28, v29, v30, v31),
                        Spiral::method80(),
                        v0_1,
                    )
                })
            };
        }
        pub fn method157(
            v0_1: string,
            v1_1: Option<CancellationToken>,
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
        pub fn method156(
            v0_1: string,
            v1_1: Option<CancellationToken>,
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
            Spiral::method157(v0_1, v1_1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
        }
        pub fn closure63(
            v0_1: string,
            v1_1: Option<CancellationToken>,
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
            let v11: Arc<Async<()>> =
                Spiral::method156(v0_1, v1_1, v2, v3, v4, v5, v6, v7, v8, v9, v10);
            fable_library_rust::Native_::getZero::<()>();
            ()
        }
        pub fn closure66(unitVar: (), v0_1: CancellationToken) -> Spiral::US32 {
            Spiral::US32::US32_0(v0_1)
        }
        pub fn method161() -> Func1<CancellationToken, Spiral::US32> {
            Func1::new(move |v: CancellationToken| Spiral::closure66((), v))
        }
        pub fn method162(v0_1: CancellationToken) -> Arc<Async<CancellationToken>> {
            fable_library_rust::Native_::getZero()
        }
        pub fn method163(v0_1: bool) -> bool {
            unbox::<bool>(fable_library_rust::Native_::getZero())
        }
        pub fn method164(v0_1: bool) {
            ();
        }
        pub fn closure67(v0_1: bool, unitVar: ()) {
            if (Spiral::method163(v0_1)) == false {
                Spiral::method164(v0_1);
            };
        }
        pub fn method167(v0_1: LrcPtr<TaskCanceledException>) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral::closure7(v2.clone(), string("ex"), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v39: std::string::String = format!("{:#?}", v0_1);
            let v78: () = {
                Spiral::closure7(v2.clone(), fable_library_rust::String_::fromString(v39), ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method166(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: LrcPtr<TaskCanceledException>,
        ) -> string {
            let v9: string = Spiral::method167(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options_async / WaitForExitAsync"),
                v9
            ))
        }
        pub fn closure68(v0_1: LrcPtr<TaskCanceledException>, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_3) {
                let v5: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method166(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method42(),
                    v0_1,
                ))
            };
        }
        pub fn method165(
            v0_1: bool,
            v1_1: LrcPtr<ConcurrentStack_1<string>>,
            v2: CancellationToken,
        ) -> Arc<Async<i32>> {
            fable_library_rust::Native_::getZero()
        }
        pub fn method169(
            v0_1: i32,
            v1_1: i32,
            v2: string,
            v3: Option<CancellationToken>,
            v4: Array<(string, string)>,
            v5: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v6: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v7: bool,
            v8: Option<string>,
        ) -> string {
            let v10: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v18: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v10.clone(), string("exit_code"), ());
                ()
            };
            let v38: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v47: () = {
                Spiral::closure7(v10.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v57: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v67: () = {
                Spiral::closure7(v10.clone(), string("output_length"), ());
                ()
            };
            let v76: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v85: () = {
                Spiral::closure7(v10.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v104: () = {
                Spiral::closure7(v10.clone(), string("options"), ());
                ()
            };
            let v113: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v122: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v132: () = {
                Spiral::closure7(v10.clone(), string("command"), ());
                ()
            };
            let v141: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v150: () = {
                Spiral::closure7(v10.clone(), v2, ());
                ()
            };
            let v159: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v169: () = {
                Spiral::closure7(v10.clone(), string("cancellation_token"), ());
                ()
            };
            let v178: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v187: std::string::String = format!("{:#?}", v3);
            let v226: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v187),
                    (),
                );
                ()
            };
            let v235: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v245: () = {
                Spiral::closure7(v10.clone(), string("environment_variables"), ());
                ()
            };
            let v254: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v267: () = {
                Spiral::closure7(v10.clone(), sprintf!("{:?}", v4), ());
                ()
            };
            let v276: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v286: () = {
                Spiral::closure7(v10.clone(), string("on_line"), ());
                ()
            };
            let v295: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v304: std::string::String = format!("{:#?}", v5);
            let v343: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v304),
                    (),
                );
                ()
            };
            let v352: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v362: () = {
                Spiral::closure7(v10.clone(), string("stdin"), ());
                ()
            };
            let v371: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v380: std::string::String = format!("{:#?}", v6);
            let v419: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v380),
                    (),
                );
                ()
            };
            let v428: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v438: () = {
                Spiral::closure7(v10.clone(), string("trace"), ());
                ()
            };
            let v447: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v459: () = {
                Spiral::closure7(
                    v10.clone(),
                    if v7 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v468: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v478: () = {
                Spiral::closure7(v10.clone(), string("working_directory"), ());
                ()
            };
            let v487: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v496: std::string::String = format!("{:#?}", v8);
            let v535: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v496),
                    (),
                );
                ()
            };
            let v545: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            let v554: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            v10.l0.get().clone()
        }
        pub fn method168(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
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
            let v17: string = Spiral::method169(v8, v9, v10, v11, v12, v13, v14, v15, v16);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options_async"),
                v17
            ))
        }
        pub fn closure69(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
            v7: i32,
            v8: string,
            unitVar: (),
        ) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v13: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v39: Option<i64> = patternInput.5.clone();
                let v38: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v37: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v36: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v35: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v34: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method168(
                    v34.clone(),
                    v35.clone(),
                    v36.clone(),
                    v37.clone(),
                    v38.clone(),
                    v39.clone(),
                    Spiral::method8(v34, v35, v36, v37, v38, v39),
                    Spiral::method12(),
                    v7,
                    length(v8),
                    v0_1,
                    v1_1,
                    v2,
                    v3,
                    v4,
                    v5,
                    v6,
                ))
            };
        }
        pub fn method152(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
        ) -> Arc<Async<(i32, string)>> {
            fable_library_rust::Native_::getZero()
        }
        pub fn method151(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
        ) -> Arc<Async<(i32, string)>> {
            Spiral::method152(v0_1, v1_1, v2, v3, v4, v5, v6)
        }
        pub fn method96(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
        ) -> (i32, string) {
            let v17: Spiral::US14 = Spiral::method98(Spiral::method97(
                v0_1.clone(),
                v1_1.clone(),
                v2.clone(),
                v3.clone(),
                v4.clone(),
                v5,
                v6.clone(),
            ));
            let patternInput: (string, Spiral::US5) = match &v17 {
                Spiral::US14::US14_0(v17_0_0, v17_0_1) => (v17_0_0.clone(), v17_0_1.clone()),
                Spiral::US14::US14_1(v17_1_0) => panic!(
                    "{}",
                    concat(new_array(&[
                        string("resultm.get / Result value was Error: "),
                        v17_1_0.clone()
                    ])),
                ),
            };
            let v30: Spiral::US5 = patternInput.1.clone();
            let v29: string = patternInput.0.clone();
            let v35: Spiral::US22 = Spiral::method111(match &v30 {
                Spiral::US5::US5_0(v30_0_0) => match &v30 {
                    Spiral::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                _ => string(""),
            });
            let v44: Array<string> = match &v35 {
                Spiral::US22::US22_0(v35_0_0) => v35_0_0.clone(),
                Spiral::US22::US22_1(v35_1_0) => panic!(
                    "{}",
                    concat(new_array(&[
                        string("resultm.get / Result value was Error: "),
                        v35_1_0.clone()
                    ])),
                ),
            };
            let v46: Vec<string> = v44.to_vec();
            let v48: bool = true;
            let _vec_map: Vec<_> = v46
                .into_iter()
                .map(|x| {
                    //;
                    let v50: string = x;
                    let v57: &str = &*v50;
                    let v90: std::string::String = String::from(v57);
                    let v118: bool = true;
                    v90
                })
                .collect::<Vec<_>>();
            let v120: Vec<std::string::String> = _vec_map;
            let v123: () = {
                Spiral::closure42(
                    v0_1,
                    v1_1,
                    v2.clone(),
                    v3,
                    v4.clone(),
                    v5,
                    v6.clone(),
                    v29.clone(),
                    v120.clone(),
                    (),
                );
                ()
            };
            let _capture_v175: MutCell<Option<LrcPtr<(i32, string)>>> =
                MutCell::new(None::<LrcPtr<(i32, string)>>);
            {
                let x_5: LrcPtr<(i32, string)> = (Func0::new({
                    let v120 = v120.clone();
                    let v2 = v2.clone();
                    let v29 = v29.clone();
                    let v4 = v4.clone();
                    let v5 = v5.clone();
                    let v6 = v6.clone();
                    move || {
                        let v177: std::process::Command = std::process::Command::new(&*v29.clone());
                        let v179: bool = true;
                        let mut v177 = v177;
                        let v181: bool = true;
                        std::process::Command::args(&mut v177, &*v120.clone());
                        let v183: std::process::Command = v177;
                        let v185: std::process::Stdio = std::process::Stdio::piped();
                        let v187: bool = true;
                        let mut v183 = v183;
                        let v189: bool = true;
                        std::process::Command::stdout(&mut v183, std::process::Stdio::piped());
                        let v191: std::process::Command = v183;
                        let v193: std::process::Stdio = std::process::Stdio::piped();
                        let v195: bool = true;
                        let mut v191 = v191;
                        let v197: bool = true;
                        std::process::Command::stderr(&mut v191, std::process::Stdio::piped());
                        let v199: std::process::Command = v191;
                        let v201: std::process::Stdio = std::process::Stdio::piped();
                        let v203: bool = true;
                        let mut v199 = v199;
                        let v205: bool = true;
                        std::process::Command::stdin(&mut v199, std::process::Stdio::piped());
                        let v207: std::process::Command = v199;
                        let v224: Spiral::US5 =
                            defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6.clone()));
                        let v238: std::process::Command = match &v224 {
                            Spiral::US5::US5_0(v224_0_0) => {
                                let v230: bool = true;
                                let mut v207 = v207;
                                let v232: bool = true;
                                std::process::Command::current_dir(
                                    &mut v207,
                                    &*match &v224 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                );
                                v207
                            }
                            _ => v207,
                        };
                        let v260: std::process::Command = if (get_Count(v2.clone()) as u64) == 0_u64
                        {
                            v238
                        } else {
                            let v242: Vec<(string, string)> = v2.clone().to_vec();
                            let v244: bool = true;
                            let _vec_fold_ = v242.into_iter().fold(v238, |acc, x| {
                                //;
                                let v246: std::process::Command = acc;
                                let patternInput_1: (string, string) = x;
                                let v251: bool = true;
                                let mut v246 = v246;
                                let v253: bool = true;
                                std::process::Command::env(
                                    &mut v246,
                                    &*patternInput_1.0.clone(),
                                    &*patternInput_1.1.clone(),
                                );
                                let v255: std::process::Command = v246;
                                let v257: bool = true;
                                v255
                            });
                            _vec_fold_
                        };
                        let v262: bool = true;
                        let mut v260 = v260;
                        let v264: Result<std::process::Child, std::io::Error> =
                            std::process::Command::spawn(&mut v260);
                        let v265 = Spiral::method74();
                        let v269: Result<std::process::Child, std::string::String> =
                            v264.map_err(|x| v265(x));
                        let v281 = Spiral::method123();
                        let v283: bool = true;
                        let _result_map_ = v269.map(|x| {
                            //;
                            let v290: Option<std::process::Child> = v281(Some(x));
                            let v292: std::sync::Mutex<Option<std::process::Child>> =
                                std::sync::Mutex::new(v290);
                            let v294: std::sync::Arc<
                                std::sync::Mutex<Option<std::process::Child>>,
                            > = std::sync::Arc::new(v292);
                            let v296: bool = true;
                            v294
                        });
                        let v298: Result<
                            std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>,
                            std::string::String,
                        > = _result_map_;
                        let v299 = Spiral::method124();
                        let v300 = Spiral::method125();
                        let v302: Spiral::US24 = match v298 {
                            Ok(x) => v299(x),
                            Err(e) => v300(e),
                        };
                        let patternInput_3: (i32, Spiral::US7, Spiral::US25) = match &v302 {
                            Spiral::US24::US24_0(v302_0_0) => {
                                let v303: std::sync::Arc<
                                    std::sync::Mutex<Option<std::process::Child>>,
                                > = v302_0_0.clone();
                                let v305: bool = true;
                                let _capture = (|| {
                                    //;
                                    let v307: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::Child>>,
                                    > = v303.clone();
                                    let v309: Result<
                                        std::sync::MutexGuard<Option<std::process::Child>>,
                                        std::sync::PoisonError<
                                            std::sync::MutexGuard<Option<std::process::Child>>,
                                        >,
                                    > = v307.lock();
                                    let v325: std::sync::MutexGuard<Option<std::process::Child>> =
                                        Spiral::method128(v309.unwrap());
                                    let v327: bool = true;
                                    let mut v325 = v325;
                                    let v329: &mut Option<std::process::Child> = &mut v325;
                                    let v331: Option<&mut std::process::Child> = v329.as_mut();
                                    let v333: &mut std::process::Child = v331.unwrap();
                                    let v335: &mut Option<std::process::ChildStdout> =
                                        &mut v333.stdout;
                                    let v337: Option<std::process::ChildStdout> =
                                        Option::take(v335);
                                    let v339: std::process::ChildStdout = v337.unwrap();
                                    let v341: bool = true;
                                    v339
                                })();
                                let v343: std::process::ChildStdout = _capture;
                                let v345: bool = true;
                                let _capture = (|| {
                                    //;
                                    let v347: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::Child>>,
                                    > = v303.clone();
                                    let v349: Result<
                                        std::sync::MutexGuard<Option<std::process::Child>>,
                                        std::sync::PoisonError<
                                            std::sync::MutexGuard<Option<std::process::Child>>,
                                        >,
                                    > = v347.lock();
                                    let v365: std::sync::MutexGuard<Option<std::process::Child>> =
                                        Spiral::method128(v349.unwrap());
                                    let v367: bool = true;
                                    let mut v365 = v365;
                                    let v369: &mut Option<std::process::Child> = &mut v365;
                                    let v371: Option<&mut std::process::Child> = v369.as_mut();
                                    let v373: &mut std::process::Child = v371.unwrap();
                                    let v375: &mut Option<std::process::ChildStderr> =
                                        &mut v373.stderr;
                                    let v377: Option<std::process::ChildStderr> =
                                        Option::take(v375);
                                    let v379: std::process::ChildStderr = v377.unwrap();
                                    let v381: bool = true;
                                    v379
                                })();
                                let v383: std::process::ChildStderr = _capture;
                                let v385: bool = true;
                                let _capture = (|| {
                                    //;
                                    let v387: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::Child>>,
                                    > = v303.clone();
                                    let v389: Result<
                                        std::sync::MutexGuard<Option<std::process::Child>>,
                                        std::sync::PoisonError<
                                            std::sync::MutexGuard<Option<std::process::Child>>,
                                        >,
                                    > = v387.lock();
                                    let v405: std::sync::MutexGuard<Option<std::process::Child>> =
                                        Spiral::method128(v389.unwrap());
                                    let v407: bool = true;
                                    let mut v405 = v405;
                                    let v409: &mut Option<std::process::Child> = &mut v405;
                                    let v411: Option<&mut std::process::Child> = v409.as_mut();
                                    let v413: &mut std::process::Child = v411.unwrap();
                                    let v415: &mut Option<std::process::ChildStdin> =
                                        &mut v413.stdin;
                                    let v417: Option<std::process::ChildStdin> = Option::take(v415);
                                    let v419: std::process::ChildStdin = v417.unwrap();
                                    let v425: Option<std::process::ChildStdin> =
                                        (Spiral::method129())(Some(v419));
                                    let v427: std::sync::Mutex<Option<std::process::ChildStdin>> =
                                        std::sync::Mutex::new(v425);
                                    let v429: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::ChildStdin>>,
                                    > = std::sync::Arc::new(v427);
                                    let v431: bool = true;
                                    v429
                                })();
                                let v433: std::sync::Arc<
                                    std::sync::Mutex<Option<std::process::ChildStdin>>,
                                > = _capture;
                                let patternInput_2: (
                                    std::sync::mpsc::Sender<std::string::String>,
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                ) = {
                                    let (sender, receiver) = std::sync::mpsc::channel();
                                    (sender, std::sync::Arc::new(receiver))
                                };
                                let v435: std::sync::mpsc::Sender<std::string::String> =
                                    patternInput_2.0.clone();
                                let v438: std::sync::mpsc::Sender<std::string::String> =
                                    (Spiral::method130())(v435.clone());
                                let v440: std::sync::Mutex<
                                    std::sync::mpsc::Sender<std::string::String>,
                                > = std::sync::Mutex::new(v438);
                                let v442: std::sync::Arc<
                                    std::sync::Mutex<std::sync::mpsc::Sender<std::string::String>>,
                                > = std::sync::Arc::new(v440);
                                let v444: std::sync::mpsc::Sender<std::string::String> =
                                    (Spiral::method131())(v435);
                                let v446: std::sync::Mutex<
                                    std::sync::mpsc::Sender<std::string::String>,
                                > = std::sync::Mutex::new(v444);
                                let v448: std::sync::Arc<
                                    std::sync::Mutex<std::sync::mpsc::Sender<std::string::String>>,
                                > = std::sync::Arc::new(v446);
                                let v450: std::sync::Arc<
                                    std::sync::mpsc::Receiver<std::string::String>,
                                > = (Spiral::method132())(patternInput_2.1.clone());
                                let v452: std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                > = std::sync::Mutex::new(v450);
                                let v454: std::sync::Arc<
                                    std::sync::Mutex<
                                        std::sync::Arc<
                                            std::sync::mpsc::Receiver<std::string::String>,
                                        >,
                                    >,
                                > = std::sync::Arc::new(v452);
                                let v456: bool = true;
                                let __spawn = std::thread::spawn(move || {
                                    //;
                                    let v458: encoding_rs_io::DecodeReaderBytes<
                                        std::process::ChildStdout,
                                        Vec<u8>,
                                    > = encoding_rs_io::DecodeReaderBytesBuilder::new()
                                        .utf8_passthru(true)
                                        .build(v343);
                                    let v460: std::io::BufReader<
                                        encoding_rs_io::DecodeReaderBytes<
                                            std::process::ChildStdout,
                                            Vec<u8>,
                                        >,
                                    > = std::io::BufReader::new(v458);
                                    let v462: std::io::Lines<
                                        std::io::BufReader<
                                            encoding_rs_io::DecodeReaderBytes<
                                                std::process::ChildStdout,
                                                Vec<u8>,
                                            >,
                                        >,
                                    > = std::io::BufRead::lines(v460);
                                    let v464: bool = true;
                                    let mut v462 = v462;
                                    let _iter_try_for_each = v462.try_for_each(|x| {
                                        //;
                                        let v466: Result<std::string::String, std::io::Error> = x;
                                        let v468: std::sync::Arc<
                                            std::sync::Mutex<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                        > = v442.clone();
                                        let v469 = Spiral::method74();
                                        let v473: Result<std::string::String, std::string::String> =
                                            v466.map_err(|x| v469(x));
                                        let v485 = Spiral::method133();
                                        let v486 = Spiral::method134();
                                        let v488: Spiral::US26 = match v473 {
                                            Ok(x) => v485(x),
                                            Err(e) => v486(e),
                                        };
                                        let v725: std::string::String = match &v488 {
                                            Spiral::US26::US26_0(v488_0_0) => {
                                                let v491: string =
                                                    fable_library_rust::String_::fromString(
                                                        v488_0_0.clone(),
                                                    );
                                                let v493: &encoding_rs::Encoding =
                                                    encoding_rs::UTF_8;
                                                let v495: std::borrow::Cow<[u8]> =
                                                    v493.encode(&*v491).0;
                                                let v497: &[u8] = v495.as_ref();
                                                let v499: Result<&str, std::str::Utf8Error> =
                                                    std::str::from_utf8(v497);
                                                let v503: &str = v499.unwrap();
                                                let v542: std::string::String = String::from(v503);
                                                let v550: string = concat(new_array(&[
                                                    string("> "),
                                                    fable_library_rust::String_::fromString(
                                                        v542.clone(),
                                                    ),
                                                ]));
                                                if v5 {
                                                    let v553: () = {
                                                        Spiral::closure53(v550.clone(), ());
                                                        ()
                                                    };
                                                    ()
                                                } else {
                                                    let v605: () = {
                                                        Spiral::closure10(v550, ());
                                                        ()
                                                    };
                                                    ()
                                                }
                                                v542
                                            }
                                            Spiral::US26::US26_1(v488_1_0) => {
                                                let v607: std::string::String = v488_1_0.clone();
                                                let v610: () = {
                                                    Spiral::closure52(v5, v607.clone(), ());
                                                    ()
                                                };
                                                let v657: string =
                                                    sprintf!("\u{001b}[4;7m{}\u{001b}[0m", v607);
                                                let v664: &str = &*v657;
                                                String::from(v664)
                                            }
                                        };
                                        let v727: std::sync::Arc<
                                            std::sync::Mutex<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                        > = v468;
                                        let v729: Result<
                                            std::sync::MutexGuard<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                            std::sync::PoisonError<
                                                std::sync::MutexGuard<
                                                    std::sync::mpsc::Sender<std::string::String>,
                                                >,
                                            >,
                                        > = v727.lock();
                                        let v733: std::sync::MutexGuard<
                                            std::sync::mpsc::Sender<std::string::String>,
                                        > = v729.unwrap();
                                        let v746: &std::sync::mpsc::Sender<std::string::String> =
                                            &v733;
                                        let v748: Result<
                                            (),
                                            std::sync::mpsc::SendError<std::string::String>,
                                        > = v746.send(v725);
                                        let v749 = Spiral::method139();
                                        let v753: Result<(), std::string::String> =
                                            v748.map_err(|x| v749(x));
                                        let v766: _ = v753;
                                        let v768: bool = true;
                                        v766
                                    }); //;
                                    let v771: Result<(), string> =
                                        Spiral::method140(_iter_try_for_each.map_err(|x| x.into()));
                                    let v774: string = string("}");
                                    let v779: bool = true;
                                    let _fix_closure_v776 = v771;
                                    let v786: string = append(
                                        (append(
                                            (append(
                                                (append(
                                                    string("true; _fix_closure_v776 "),
                                                    (v774),
                                                )),
                                                string("); "),
                                            )),
                                            string(""),
                                        )),
                                        string(" // rust.fix_closure\'"),
                                    );
                                    let v787: bool = true;
                                    _fix_closure_v776
                                }); // rust.fix_closure';
                                let v789: std::thread::JoinHandle<Result<(), string>> = __spawn;
                                let v791: bool = true;
                                let __spawn = std::thread::spawn(move || {
                                    //;
                                    let v793: encoding_rs_io::DecodeReaderBytes<
                                        std::process::ChildStderr,
                                        Vec<u8>,
                                    > = encoding_rs_io::DecodeReaderBytesBuilder::new()
                                        .utf8_passthru(true)
                                        .build(v383);
                                    let v795: std::io::BufReader<
                                        encoding_rs_io::DecodeReaderBytes<
                                            std::process::ChildStderr,
                                            Vec<u8>,
                                        >,
                                    > = std::io::BufReader::new(v793);
                                    let v797: std::io::Lines<
                                        std::io::BufReader<
                                            encoding_rs_io::DecodeReaderBytes<
                                                std::process::ChildStderr,
                                                Vec<u8>,
                                            >,
                                        >,
                                    > = std::io::BufRead::lines(v795);
                                    let v799: bool = true;
                                    let mut v797 = v797;
                                    let _iter_try_for_each = v797.try_for_each(|x| {
                                        //;
                                        let v801: Result<std::string::String, std::io::Error> = x;
                                        let v803: std::sync::Arc<
                                            std::sync::Mutex<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                        > = v448.clone();
                                        let v804 = Spiral::method74();
                                        let v808: Result<std::string::String, std::string::String> =
                                            v801.map_err(|x| v804(x));
                                        let v820 = Spiral::method133();
                                        let v821 = Spiral::method134();
                                        let v823: Spiral::US26 = match v808 {
                                            Ok(x) => v820(x),
                                            Err(e) => v821(e),
                                        };
                                        let v1126: std::string::String = match &v823 {
                                            Spiral::US26::US26_0(v823_0_0) => {
                                                let v826: string =
                                                    fable_library_rust::String_::fromString(
                                                        v823_0_0.clone(),
                                                    );
                                                let v828: &encoding_rs::Encoding =
                                                    encoding_rs::UTF_8;
                                                let v830: std::borrow::Cow<[u8]> =
                                                    v828.encode(&*v826).0;
                                                let v832: &[u8] = v830.as_ref();
                                                let v834: Result<&str, std::str::Utf8Error> =
                                                    std::str::from_utf8(v832);
                                                let v838: &str = v834.unwrap();
                                                let v877: std::string::String = String::from(v838);
                                                let v885: string = concat(new_array(&[
                                                    string("! "),
                                                    fable_library_rust::String_::fromString(
                                                        v877.clone(),
                                                    ),
                                                ]));
                                                if v5 {
                                                    let v888: () = {
                                                        Spiral::closure53(v885.clone(), ());
                                                        ()
                                                    };
                                                    ()
                                                } else {
                                                    let v939: () = {
                                                        Spiral::closure10(v885, ());
                                                        ()
                                                    };
                                                    ()
                                                }
                                                {
                                                    let v941: string = sprintf!(
                                                        "\u{001b}[4;7m{}\u{001b}[0m",
                                                        v877
                                                    );
                                                    let v948: &str = &*v941;
                                                    String::from(v948)
                                                }
                                            }
                                            Spiral::US26::US26_1(v823_1_0) => {
                                                let v1008: std::string::String = v823_1_0.clone();
                                                let v1011: () = {
                                                    Spiral::closure52(v5, v1008.clone(), ());
                                                    ()
                                                };
                                                let v1058: string =
                                                    sprintf!("\u{001b}[4;7m{}\u{001b}[0m", v1008);
                                                let v1065: &str = &*v1058;
                                                String::from(v1065)
                                            }
                                        };
                                        let v1128: std::sync::Arc<
                                            std::sync::Mutex<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                        > = v803;
                                        let v1130: Result<
                                            std::sync::MutexGuard<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                            std::sync::PoisonError<
                                                std::sync::MutexGuard<
                                                    std::sync::mpsc::Sender<std::string::String>,
                                                >,
                                            >,
                                        > = v1128.lock();
                                        let v1134: std::sync::MutexGuard<
                                            std::sync::mpsc::Sender<std::string::String>,
                                        > = v1130.unwrap();
                                        let v1147: &std::sync::mpsc::Sender<std::string::String> =
                                            &v1134;
                                        let v1149: Result<
                                            (),
                                            std::sync::mpsc::SendError<std::string::String>,
                                        > = v1147.send(v1126);
                                        let v1150 = Spiral::method139();
                                        let v1154: Result<(), std::string::String> =
                                            v1149.map_err(|x| v1150(x));
                                        let v1167: _ = v1154;
                                        let v1169: bool = true;
                                        v1167
                                    }); //;
                                    let v1172: Result<(), string> =
                                        Spiral::method140(_iter_try_for_each.map_err(|x| x.into()));
                                    let v1173: string = string("}");
                                    let v1178: bool = true;
                                    let _fix_closure_v1175 = v1172;
                                    let v1185: string = append(
                                        (append(
                                            (append(
                                                (append(
                                                    string("true; _fix_closure_v1175 "),
                                                    (v1173),
                                                )),
                                                string("); "),
                                            )),
                                            string(""),
                                        )),
                                        string(" // rust.fix_closure\'"),
                                    );
                                    let v1186: bool = true;
                                    _fix_closure_v1175
                                }); // rust.fix_closure';
                                let v1188: std::thread::JoinHandle<Result<(), string>> = __spawn;
                                let v1205: Spiral::US27 = defaultValue(
                                    Spiral::US27::US27_1,
                                    map(Spiral::method141(), v4.clone()),
                                );
                                match &v1205 {
                                    Spiral::US27::US27_0(v1205_0_0) => {
                                        let v1211: std::sync::Arc<
                                            std::sync::Mutex<Option<std::process::ChildStdin>>,
                                        > = v433.clone();
                                        let v1213: Result<
                                            std::sync::MutexGuard<Option<std::process::ChildStdin>>,
                                            std::sync::PoisonError<
                                                std::sync::MutexGuard<
                                                    Option<std::process::ChildStdin>,
                                                >,
                                            >,
                                        > = v1211.lock();
                                        let v1229: std::sync::MutexGuard<
                                            Option<std::process::ChildStdin>,
                                        > = Spiral::method142(v1213.unwrap());
                                        let v1231: bool = true;
                                        let mut v1229 = v1229;
                                        let v1233: &mut Option<std::process::ChildStdin> =
                                            &mut v1229;
                                        let v1235: Option<std::process::ChildStdin> =
                                            Option::take(v1233);
                                        let v1237: bool = true;
                                        let _optionm_map_ = v1235.map(|x| {
                                            //;
                                            let v1239: std::process::ChildStdin = x;
                                            let v1241: std::sync::Mutex<std::process::ChildStdin> =
                                                std::sync::Mutex::new(v1239);
                                            let v1243: std::sync::Arc<
                                                std::sync::Mutex<std::process::ChildStdin>,
                                            > = std::sync::Arc::new(v1241);
                                            let v1245: bool = true;
                                            v1243
                                        });
                                        let v1247: Option<
                                            std::sync::Arc<
                                                std::sync::Mutex<std::process::ChildStdin>,
                                            >,
                                        > = _optionm_map_;
                                        let v1264: Spiral::US28 = defaultValue(
                                            Spiral::US28::US28_1,
                                            map(Spiral::method143(), v1247),
                                        );
                                        match &v1264 {
                                            Spiral::US28::US28_0(v1264_0_0) => {
                                                let v1268: std::sync::Arc<
                                                    std::sync::Mutex<std::process::ChildStdin>,
                                                > = match &v1264 {
                                                    Spiral::US28::US28_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone();
                                                (match &v1205 {
                                                    Spiral::US27::US27_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                })(
                                                    v1268.clone()
                                                );
                                                {
                                                    let v1270: std::sync::Arc<
                                                        std::sync::Mutex<std::process::ChildStdin>,
                                                    > = v1268;
                                                    let v1272: Result<
                                                        std::sync::MutexGuard<
                                                            std::process::ChildStdin,
                                                        >,
                                                        std::sync::PoisonError<
                                                            std::sync::MutexGuard<
                                                                std::process::ChildStdin,
                                                            >,
                                                        >,
                                                    > = v1270.lock();
                                                    let v1288: std::sync::MutexGuard<
                                                        std::process::ChildStdin,
                                                    > = Spiral::method144(v1272.unwrap());
                                                    let v1290: bool = true;
                                                    let mut v1288 = v1288;
                                                    let v1292: bool = true;
                                                    std::io::Write::flush(&mut *v1288).unwrap();
                                                    ()
                                                }
                                            }
                                            _ => (),
                                        }
                                    }
                                    _ => (),
                                }
                                {
                                    let v1294: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::Child>>,
                                    > = v303;
                                    let v1296: Result<
                                        std::sync::MutexGuard<Option<std::process::Child>>,
                                        std::sync::PoisonError<
                                            std::sync::MutexGuard<Option<std::process::Child>>,
                                        >,
                                    > = v1294.lock();
                                    let v1312: std::sync::MutexGuard<Option<std::process::Child>> =
                                        Spiral::method128(v1296.unwrap());
                                    let v1314: bool = true;
                                    let mut v1312 = v1312;
                                    let v1316: &mut Option<std::process::Child> = &mut v1312;
                                    let v1318: Option<std::process::Child> = Option::take(v1316);
                                    let v1320: std::process::Child = v1318.unwrap();
                                    let v1322: Result<std::process::Output, std::io::Error> =
                                        v1320.wait_with_output();
                                    let v1323 = Spiral::method74();
                                    let v1336: Result<std::process::Output, std::string::String> =
                                        v1322.map_err(|x| v1323(x));
                                    let v1346: string = string("vec![v789, v1188]");
                                    let v1347: Vec<std::thread::JoinHandle<Result<(), string>>> =
                                        vec![v789, v1188];
                                    let v1349: bool = true;
                                    v1347.into_iter().for_each(|x| {
                                        //;
                                        let v1351: std::thread::JoinHandle<Result<(), string>> = x;
                                        let v1353: Result<
                                            Result<(), string>,
                                            Box<dyn core::any::Any + 'static + Send>,
                                        > = std::thread::JoinHandle::join(v1351);
                                        let v1357: Result<(), string> = v1353.unwrap();
                                        v1357.unwrap();
                                        {
                                            let v1374: bool = true;
                                            let v1376: bool = true;
                                        }
                                    });
                                    {
                                        //;
                                        let v1377 = Spiral::method145();
                                        let v1378 = Spiral::method146();
                                        let v1379: Spiral::US29 = match &v1336 {
                                            Err(v1336_1_0) => v1378(v1336_1_0.clone()),
                                            Ok(v1336_0_0) => v1377(v1336_0_0.clone()),
                                        };
                                        match &v1379 {
                                            Spiral::US29::US29_0(v1379_0_0) => {
                                                let v1382: std::process::ExitStatus =
                                                    v1379_0_0.clone().status;
                                                let v1384: Option<i32> = v1382.code();
                                                let v1401: Spiral::US30 = defaultValue(
                                                    Spiral::US30::US30_1,
                                                    map(Spiral::method148(), v1384),
                                                );
                                                match &v1401 {
                                                    Spiral::US30::US30_0(v1401_0_0) => (
                                                        match &v1401 {
                                                            Spiral::US30::US30_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        },
                                                        Spiral::US7::US7_1,
                                                        Spiral::US25::US25_0(v454.clone()),
                                                    ),
                                                    _ => {
                                                        let v1415:
                                                                                        &str =
                                                                                    &*string("runtime.execute_with_options / exit_code=None");
                                                        (
                                                            -1_i32,
                                                            Spiral::US7::US7_0(String::from(v1415)),
                                                            Spiral::US25::US25_0(v454.clone()),
                                                        )
                                                    }
                                                }
                                            }
                                            Spiral::US29::US29_1(v1379_1_0) => {
                                                let v1483: std::string::String = v1379_1_0.clone();
                                                let v1486: () = {
                                                    Spiral::closure59(v1483.clone(), ());
                                                    ()
                                                };
                                                (
                                                    -2_i32,
                                                    Spiral::US7::US7_0(v1483),
                                                    Spiral::US25::US25_1,
                                                )
                                            }
                                        }
                                    }
                                }
                            }
                            Spiral::US24::US24_1(v302_1_0) => {
                                let v1541: std::string::String = v302_1_0.clone();
                                let v1544: () = {
                                    Spiral::closure46(v1541.clone(), ());
                                    ()
                                };
                                (-1_i32, Spiral::US7::US7_0(v1541), Spiral::US25::US25_1)
                            }
                        };
                        let v1598: Spiral::US25 = patternInput_3.2.clone();
                        let v1597: Spiral::US7 = patternInput_3.1.clone();
                        let v1596: i32 = patternInput_3.0.clone();
                        let v1606: Option<
                            std::sync::Arc<
                                std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                >,
                            >,
                        > = match &v1598 {
                            Spiral::US25::US25_0(v1598_0_0) => Some(
                                match &v1598 {
                                    Spiral::US25::US25_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => {
                                None::<
                                    std::sync::Arc<
                                        std::sync::Mutex<
                                            std::sync::Arc<
                                                std::sync::mpsc::Receiver<std::string::String>,
                                            >,
                                        >,
                                    >,
                                >
                            }
                        };
                        let v1608: bool = true;
                        let _optionm_map_ = v1606.map(|x| {
                            //;
                            let v1610: std::sync::Arc<
                                std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                >,
                            > = x;
                            let v1612: std::sync::Arc<
                                std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                >,
                            > = v1610;
                            let v1614: Result<
                                std::sync::MutexGuard<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                >,
                                std::sync::PoisonError<
                                    std::sync::MutexGuard<
                                        std::sync::Arc<
                                            std::sync::mpsc::Receiver<std::string::String>,
                                        >,
                                    >,
                                >,
                            > = v1612.lock();
                            let v1618: std::sync::MutexGuard<
                                std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                            > = v1614.unwrap();
                            let v1631 = v1618.iter();
                            let v1633: Vec<std::string::String> = v1631.collect::<Vec<_>>();
                            let v1635: bool = true;
                            let _vec_map: Vec<_> = v1633
                                .into_iter()
                                .map(|x| {
                                    //;
                                    let v1637: std::string::String = x;
                                    let v1639: string =
                                        fable_library_rust::String_::fromString(v1637);
                                    let v1641: bool = true;
                                    v1639
                                })
                                .collect::<Vec<_>>();
                            let v1643: Vec<string> = _vec_map;
                            let v1647: LrcPtr<dyn IEnumerable_1<string>> = ofArray_1(
                                fable_library_rust::NativeArray_::array_from(v1643.clone()),
                            );
                            let v1654: string = join(Spiral::method70(), toArray_1(v1647));
                            let v1659: bool = true;
                            v1654
                        });
                        let v1661: Option<string> = _optionm_map_;
                        let v1668: Spiral::US5 = match &v1597 {
                            Spiral::US7::US7_0(v1597_0_0) => {
                                Spiral::US5::US5_0(fable_library_rust::String_::fromString(
                                    match &v1597 {
                                        Spiral::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ))
                            }
                            _ => Spiral::US5::US5_1,
                        };
                        let v1674: string = defaultValue(
                            match &v1668 {
                                Spiral::US5::US5_0(v1668_0_0) => match &v1668 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => string(""),
                            },
                            v1661,
                        );
                        let v1679: () = {
                            Spiral::closure61(v1596, v1674.clone(), ());
                            ()
                        };
                        LrcPtr::new((v1596, v1674))
                    }
                }))();
                _capture_v175.set(Some(x_5))
            }
            {
                let v1728: LrcPtr<(i32, string)> = match &_capture_v175.get().clone() {
                    None => panic!("{}", string("base.capture / _capture_v175=None"),),
                    Some(_capture_v175_0_0) => _capture_v175_0_0.clone(),
                };
                let _run_target_args__v15: (i32, string) = (v1728.0.clone(), v1728.1.clone());
                (
                    _run_target_args__v15.0.clone(),
                    _run_target_args__v15.1.clone(),
                )
            }
        }
        pub fn method171(v0_1: i32, v1_1: string, v2: string) -> string {
            let v4: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v4.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral::closure7(v4.clone(), string("exit_code"), ());
                ()
            };
            let v32: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v41: () = {
                Spiral::closure7(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v51: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v61: () = {
                Spiral::closure7(v4.clone(), string("run_result"), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v4.clone(), v1_1, ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v98: () = {
                Spiral::closure7(v4.clone(), string("new_code_path"), ());
                ()
            };
            let v107: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v116: () = {
                Spiral::closure7(v4.clone(), v2, ());
                ()
            };
            let v126: () = {
                Spiral::closure7(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
        }
        pub fn method170(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: string,
            v10: string,
        ) -> string {
            let v11: string = Spiral::method171(v8, v9, v10);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_gleam / format error"),
                v11
            ))
        }
        pub fn closure70(v0_1: string, v1_1: string, v2: i32, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v7: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v33: Option<i64> = patternInput.5.clone();
                let v32: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v31: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v30: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v29: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v28: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method170(
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    Spiral::method8(v28, v29, v30, v31, v32, v33),
                    Spiral::method77(),
                    v2,
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn closure71(unitVar: (), v0_1: string) -> Spiral::US5 {
            Spiral::US5::US5_0(v0_1)
        }
        pub fn closure72(v0_1: string, unitVar: ()) -> string {
            let v7: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method70(), toArray_1(v7))
        }
        pub fn method173(v0_1: LrcPtr<Exception>, v1_1: string, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v13: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v5.clone(), string("ex"), ());
                ()
            };
            let v33: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v42: std::string::String = format!("{:#?}", v0_1);
            let v81: () = {
                Spiral::closure7(v5.clone(), fable_library_rust::String_::fromString(v42), ());
                ()
            };
            let v91: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v101: () = {
                Spiral::closure7(v5.clone(), string("run_result"), ());
                ()
            };
            let v110: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v119: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v128: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v138: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v147: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v156: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v165: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v175: () = {
                Spiral::closure7(v5.clone(), string("external_command"), ());
                ()
            };
            let v184: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v193: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v203: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
        }
        pub fn method172(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: LrcPtr<Exception>,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method173(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_gleam / Exception"),
                v12
            ))
        }
        pub fn closure74(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
            unitVar: (),
        ) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v8: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v34: Option<i64> = patternInput.5.clone();
                let v33: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v32: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v31: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v30: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v29: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method172(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method77(),
                    v3,
                    v1_1,
                    v0_1,
                    v2,
                ))
            };
        }
        pub fn closure73(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure74(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
        }
        pub fn method175(v0_1: i32, v1_1: string, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v13: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v5.clone(), string("exit_code"), ());
                ()
            };
            let v33: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v42: () = {
                Spiral::closure7(v5.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v52: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v62: () = {
                Spiral::closure7(v5.clone(), string("run_result"), ());
                ()
            };
            let v71: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v80: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v89: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v99: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v108: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v117: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v126: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v136: () = {
                Spiral::closure7(v5.clone(), string("external_command"), ());
                ()
            };
            let v145: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v154: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v164: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
        }
        pub fn method174(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method175(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_gleam / error"),
                v12
            ))
        }
        pub fn closure75(v0_1: string, v1_1: string, v2: i32, v3: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v8: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v34: Option<i64> = patternInput.5.clone();
                let v33: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v32: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v31: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v30: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v29: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method174(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method77(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
        }
        pub fn method176(
            v0_1: Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>>,
        ) -> Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>> {
            v0_1
        }
        pub fn closure76(
            v0_1: Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>>,
            _arg: (string, string),
        ) -> LrcPtr<(std::string::String, std::string::String)> {
            let v3: Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>> =
                Spiral::method176(v0_1);
            (move |x| v3(x))((_arg.0.clone(), _arg.1.clone()))
        }
        pub fn method177() -> string {
            string("py-path")
        }
        pub fn method178() -> string {
            string("env")
        }
        pub fn method180(v0_1: Spiral::US35, v1_1: i32, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v13: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v5.clone(), string("env"), ());
                ()
            };
            let v33: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v46: () = {
                Spiral::closure7(v5.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v56: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v66: () = {
                Spiral::closure7(v5.clone(), string("exit_code"), ());
                ()
            };
            let v75: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v84: () = {
                Spiral::closure7(v5.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v93: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v103: () = {
                Spiral::closure7(v5.clone(), string("run_result"), ());
                ()
            };
            let v112: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v121: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v130: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v140: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v149: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v158: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v168: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
        }
        pub fn method179(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: Spiral::US35,
            v9: i32,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method180(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_cuda / env install error"),
                v12
            ))
        }
        pub fn closure77(v0_1: Spiral::US35, v1_1: string, v2: string, v3: i32, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v8: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v34: Option<i64> = patternInput.5.clone();
                let v33: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v32: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v31: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v30: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v29: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method179(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method77(),
                    v0_1,
                    v3,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure78(v0_1: string, unitVar: ()) -> string {
            let v7: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method70(), toArray_1(v7))
        }
        pub fn method181(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: LrcPtr<Exception>,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method173(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_cuda / Exception"),
                v12
            ))
        }
        pub fn closure80(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
            unitVar: (),
        ) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v8: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v34: Option<i64> = patternInput.5.clone();
                let v33: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v32: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v31: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v30: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v29: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method181(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method77(),
                    v3,
                    v1_1,
                    v0_1,
                    v2,
                ))
            };
        }
        pub fn closure79(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure80(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
        }
        pub fn method182(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method175(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_cuda / error"),
                v12
            ))
        }
        pub fn closure81(v0_1: string, v1_1: string, v2: i32, v3: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v8: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v34: Option<i64> = patternInput.5.clone();
                let v33: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v32: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v31: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v30: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v29: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method182(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method77(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
        }
        pub fn method183() -> string {
            string("fs-path")
        }
        pub fn method184() -> string {
            string("command")
        }
        pub fn method185() -> string {
            string("path")
        }
        pub fn method190(v0_1: i32, v1_1: LrcPtr<Spiral::Mut6>) -> bool {
            (v1_1.l0.get().clone()) < (v0_1)
        }
        pub fn method191() -> char {
            std::path::MAIN_SEPARATOR
        }
        pub fn method189(v0_1: string) -> string {
            let v12: &str = &*v0_1.clone();
            let v45: std::string::String = String::from(v12);
            let v78: std::path::PathBuf = std::path::PathBuf::from(v45);
            if (v78.exists()) == false {
                let v108: string = Spiral::method33();
                let v113: Array<string> = split(
                    Spiral::method45(Spiral::method35(v108.clone(), v0_1.clone())),
                    string("/"),
                    -1_i32,
                    0_i32,
                );
                let v117: i32 = get_Count(v113.clone());
                let v118: LrcPtr<Spiral::Mut6> = LrcPtr::new(Spiral::Mut6 {
                    l0: MutCell::new(0_i32),
                    l1: MutCell::new(0_i32),
                    l2: MutCell::new(new_empty::<string>()),
                });
                while Spiral::method190(v117, v118.clone()) {
                    let v120: i32 = v118.l0.get().clone();
                    let v123: i32 = ((v120.wrapping_neg()) + (v117)) - 1_i32;
                    let matchValue: i32 = v118.l1.get().clone();
                    let v125: Array<string> = v118.l2.get().clone();
                    let v124: i32 = matchValue;
                    let v126: string = v113[v123].clone();
                    let patternInput_1: (i32, Array<string>) = if string("..") == (v126.clone()) {
                        ((v124) + 1_i32, v125.clone())
                    } else {
                        if string(".") == (v126.clone()) {
                            (v124, v125.clone())
                        } else {
                            if 0_i32 == (v124) {
                                if endsWith3(v126.clone(), string(":"), false) {
                                    let v137: Array<string> = new_array(&[sprintf!(
                                        "{}:",
                                        getCharAt(v108.clone(), 0_i32)
                                    )]);
                                    let v138: i32 = get_Count(v137.clone());
                                    let v140: i32 = (v138) + (get_Count(v125.clone()));
                                    let v141: Array<string> = new_init(&string(""), v140);
                                    let v142: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method31(v140, v142.clone()) {
                                        let v144: i32 = v142.l0.get().clone();
                                        let v149: string = if (v144) < (v138) {
                                            v137[v144].clone()
                                        } else {
                                            let v147: i32 = (v144) - (v138);
                                            v125[v147].clone()
                                        };
                                        v141.get_mut()[v144 as usize] = v149;
                                        {
                                            let v150: i32 = (v144) + 1_i32;
                                            v142.l0.set(v150);
                                            ()
                                        }
                                    }
                                    (0_i32, v141.clone())
                                } else {
                                    let v151: Array<string> = new_array(&[v126]);
                                    let v152: i32 = get_Count(v151.clone());
                                    let v154: i32 = (v152) + (get_Count(v125.clone()));
                                    let v155: Array<string> = new_init(&string(""), v154);
                                    let v156: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method31(v154, v156.clone()) {
                                        let v158: i32 = v156.l0.get().clone();
                                        let v163: string = if (v158) < (v152) {
                                            v151[v158].clone()
                                        } else {
                                            let v161: i32 = (v158) - (v152);
                                            v125[v161].clone()
                                        };
                                        v155.get_mut()[v158 as usize] = v163;
                                        {
                                            let v164: i32 = (v158) + 1_i32;
                                            v156.l0.set(v164);
                                            ()
                                        }
                                    }
                                    (0_i32, v155.clone())
                                }
                            } else {
                                ((v124) - 1_i32, v125.clone())
                            }
                        }
                    };
                    let v174: i32 = (v120) + 1_i32;
                    v118.l0.set(v174);
                    v118.l1.set(patternInput_1.0.clone());
                    v118.l2.set(patternInput_1.1.clone());
                    ()
                }
                {
                    let matchValue_2: i32 = v118.l1.get().clone();
                    let v176: Array<string> = v118.l2.get().clone();
                    let _let__v180: LrcPtr<dyn IEnumerable_1<string>> = delay(Func0::new({
                        let v176 = v176.clone();
                        move || {
                            map_1(
                                Func1::new({
                                    let v176 = v176.clone();
                                    move |i: i32| v176[i].clone()
                                }),
                                rangeNumeric(0_i32, 1_i32, (get_Count(v176.clone())) - 1_i32),
                            )
                        }
                    }));
                    let v192: string = ofChar(Spiral::method191());
                    join(
                        if (v192.clone()) == string("\n") {
                            Spiral::method30(v192.clone())
                        } else {
                            v192
                        },
                        toArray_1(_let__v180),
                    )
                }
            } else {
                let v205: Result<std::path::PathBuf, std::io::Error> =
                    std::fs::canonicalize(&*v0_1);
                let v209: std::path::PathBuf = v205.unwrap();
                let v227: std::path::Display = v209.display();
                let v260: std::string::String = format!("{}", v227);
                fable_library_rust::String_::fromString(v260)
            }
        }
        pub fn method188(v0_1: string) -> string {
            Spiral::method45(Spiral::method189(v0_1))
        }
        pub fn method187(v0_1: string) -> string {
            Spiral::method188(Spiral::method35(Spiral::method33(), v0_1))
        }
        pub fn closure82(unitVar: (), v0_1: std::string::String) -> string {
            Spiral::method187(fable_library_rust::String_::fromString(v0_1))
        }
        pub fn method186() -> Func1<std::string::String, string> {
            Func1::new(move |v: std::string::String| Spiral::closure82((), v))
        }
        pub fn method192() -> string {
            string("retries")
        }
        pub fn method193() -> string {
            string("working-directory")
        }
        pub fn method196(v0_1: i32, v1_1: string, v2: string) -> string {
            let v4: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v4.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral::closure7(v4.clone(), string("exit_code"), ());
                ()
            };
            let v32: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v41: () = {
                Spiral::closure7(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v51: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v61: () = {
                Spiral::closure7(v4.clone(), string("repl_result"), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v4.clone(), v1_1, ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v98: () = {
                Spiral::closure7(v4.clone(), string("retry"), ());
                ()
            };
            let v107: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v116: () = {
                Spiral::closure7(v4.clone(), v2, ());
                ()
            };
            let v126: () = {
                Spiral::closure7(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
        }
        pub fn method195(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: string,
            v10: string,
        ) -> string {
            let v11: string = Spiral::method196(v8, v9, v10);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / repl error"),
                v11
            ))
        }
        pub fn closure83(v0_1: u8, v1_1: u8, v2: string, v3: i32, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v8: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v34: Option<i64> = patternInput.5.clone();
                let v33: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v32: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v31: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v30: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v29: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method195(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method12(),
                    v3,
                    v2,
                    sprintf!("{}/{}", v1_1, v0_1),
                ))
            };
        }
        pub fn method194(v0_1: Spiral::US5, v1_1: u8, v2: string, v3: u8) -> (i32, string) {
            let v0_1: MutCell<Spiral::US5> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<u8> = MutCell::new(v1_1);
            let v2: MutCell<string> = MutCell::new(v2.clone());
            let v3: MutCell<u8> = MutCell::new(v3);
            '_method194: loop {
                break '_method194 ({
                    let patternInput: (i32, string) = Spiral::method96(
                        sprintf!(
                            "dotnet repl --exit-after-run --run \"{}\" --output-path \"{}.ipynb\"",
                            v2.get().clone(),
                            v2.get().clone()
                        ),
                        None::<CancellationToken>,
                        new_array(&[
                            (string("TRACE_LEVEL"), string("Verbose")),
                            (string("AUTOMATION"), string("True")),
                        ]),
                        None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
                        None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
                        false,
                        match &v0_1.get().clone() {
                            Spiral::US5::US5_0(v0_1_0_0) => Some(
                                match &v0_1.get().clone() {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => None::<string>,
                        },
                    );
                    let v25: string = patternInput.1.clone();
                    let v24: i32 = patternInput.0.clone();
                    if if (v24) == 0_i32 {
                        true
                    } else {
                        (v3.get().clone()) >= (v1_1.get().clone())
                    } {
                        (v24, v25.clone())
                    } else {
                        let v31: () = {
                            Spiral::closure83(v1_1.get().clone(), v3.get().clone(), v25, v24, ());
                            ()
                        };
                        {
                            let v0_1_temp: Spiral::US5 = v0_1.get().clone();
                            let v1_1_temp: u8 = v1_1.get().clone();
                            let v2_temp: string = v2.get().clone();
                            let v3_temp: u8 = (v3.get().clone()) + 1_u8;
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            continue '_method194;
                        }
                    }
                });
            }
        }
        pub fn method198(v0_1: i32, v1_1: i32) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral::closure7(v3.clone(), string("jupyter_result_length"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v78: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method197(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: i32,
        ) -> string {
            let v10: string = Spiral::method198(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / dib / jupyter nbconvert"),
                v10
            ))
        }
        pub fn closure84(v0_1: string, v1_1: i32, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method197(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method12(),
                    v1_1,
                    length(v0_1),
                ))
            };
        }
        pub fn method200(v0_1: i32, v1_1: i32) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral::closure7(v3.clone(), string("pwsh_replace_html_result_length"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v78: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method199(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: i32,
        ) -> string {
            let v10: string = Spiral::method200(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / dib / html cell ids"),
                v10
            ))
        }
        pub fn closure85(v0_1: string, v1_1: i32, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method199(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method12(),
                    v1_1,
                    length(v0_1),
                ))
            };
        }
        pub fn method202(v0_1: i32, v1_1: i32) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral::closure7(v3.clone(), string("result_length"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v78: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method201(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: i32,
        ) -> string {
            let v10: string = Spiral::method202(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / dib"),
                v10
            ))
        }
        pub fn closure86(v0_1: string, v1_1: i32, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method201(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method12(),
                    v1_1,
                    length(v0_1),
                ))
            };
        }
        pub fn method203() -> string {
            string("cleanup")
        }
        pub fn method204() -> string {
            string("wasm")
        }
        pub fn method205() -> string {
            string("contract")
        }
        pub fn method206(v0_1: string, v1_1: string, v2: Spiral::US36) -> string {
            let v4: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v4.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral::closure7(v4.clone(), string("extension"), ());
                ()
            };
            let v32: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v41: () = {
                Spiral::closure7(v4.clone(), v0_1, ());
                ()
            };
            let v51: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v61: () = {
                Spiral::closure7(v4.clone(), string("code"), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v4.clone(), v1_1, ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v98: () = {
                Spiral::closure7(v4.clone(), string("runtime"), ());
                ()
            };
            let v107: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v120: () = {
                Spiral::closure7(v4.clone(), sprintf!("{:?}", v2), ());
                ()
            };
            let v130: () = {
                Spiral::closure7(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
        }
        pub fn method207(v0_1: Spiral::US5, v1_1: string, v2: Spiral::US39, v3: string) -> string {
            let v6: string = Spiral::method35(Spiral::method35(v3, string("target/spiral")), v1_1);
            if let Spiral::US5::US5_0(v0_1_0_0) = &v0_1 {
                if let Spiral::US39::US39_0(v2_0_0) = &v2 {
                    let v8: Spiral::US38 = v2_0_0.clone();
                    let v10: string = Spiral::method35(v6.clone(), string("packages"));
                    let v15: Spiral::US5 = if if let Spiral::US38::US38_0 = &v8 {
                        true
                    } else {
                        false
                    } {
                        Spiral::US5::US5_0(string("Rust"))
                    } else {
                        Spiral::US5::US5_1
                    };
                    let v38: Spiral::US5 = match &v15 {
                        Spiral::US5::US5_0(v15_0_0) => Spiral::US5::US5_0(
                            match &v15 {
                                Spiral::US5::US5_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => {
                            let v22: Spiral::US5 = if if let Spiral::US38::US38_1 = &v8 {
                                true
                            } else {
                                false
                            } {
                                Spiral::US5::US5_0(string("TypeScript"))
                            } else {
                                Spiral::US5::US5_1
                            };
                            match &v22 {
                                Spiral::US5::US5_0(v22_0_0) => Spiral::US5::US5_0(
                                    match &v22 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v29: Spiral::US5 = if if let Spiral::US38::US38_2 = &v8 {
                                        true
                                    } else {
                                        false
                                    } {
                                        Spiral::US5::US5_0(string("Python"))
                                    } else {
                                        Spiral::US5::US5_1
                                    };
                                    match &v29 {
                                        Spiral::US5::US5_0(v29_0_0) => Spiral::US5::US5_0(
                                            match &v29 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        ),
                                        _ => Spiral::US5::US5_1,
                                    }
                                }
                            }
                        }
                    };
                    Spiral::method35(
                        Spiral::method35(
                            v10,
                            match &v38 {
                                Spiral::US5::US5_0(v38_0_0) => match &v38 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => panic!("{}", string("Option does not have a value."),),
                            },
                        ),
                        v0_1_0_0.clone(),
                    )
                } else {
                    v6.clone()
                }
            } else {
                v6
            }
        }
        pub fn method209(
            v0_1: string,
            v1_1: LrcPtr<Spiral::UH2>,
            v2: LrcPtr<Spiral::UH2>,
        ) -> LrcPtr<Spiral::UH2> {
            match v1_1.as_ref() {
                Spiral::UH2::UH2_0 => v2.clone(),
                Spiral::UH2::UH2_1(v1_1_1_0, v1_1_1_1) => {
                    let v5: LrcPtr<Spiral::UH2> = Spiral::method209(
                        v0_1.clone(),
                        match v1_1.as_ref() {
                            Spiral::UH2::UH2_1(_, x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        v2.clone(),
                    );
                    LrcPtr::new(Spiral::UH2::UH2_1(
                        concat(new_array(&[
                            string("<Compile Include=\""),
                            Spiral::method35(
                                v0_1.clone(),
                                match v1_1.as_ref() {
                                    Spiral::UH2::UH2_1(x, _) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            string("\" />"),
                        ])),
                        v5,
                    ))
                }
            }
        }
        pub fn method210(
            v0_1: LrcPtr<Spiral::UH4>,
            v1_1: LrcPtr<Spiral::UH2>,
        ) -> LrcPtr<Spiral::UH2> {
            match v0_1.as_ref() {
                Spiral::UH4::UH4_0 => v1_1.clone(),
                Spiral::UH4::UH4_1(v0_1_1_0, v0_1_1_1, v0_1_1_2) => {
                    LrcPtr::new(Spiral::UH2::UH2_1(
                        sprintf!(
                            "<PackageReference Include=\"{}\" Version=\"{}\" />",
                            match v0_1.as_ref() {
                                Spiral::UH4::UH4_1(x, _, _) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                            match v0_1.as_ref() {
                                Spiral::UH4::UH4_1(_, x, _) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone()
                        ),
                        Spiral::method210(
                            match v0_1.as_ref() {
                                Spiral::UH4::UH4_1(_, _, x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                            v1_1.clone(),
                        ),
                    ))
                }
            }
        }
        pub fn method208(
            v0_1: string,
            v1_1: string,
            v2: LrcPtr<Spiral::UH2>,
            v3: LrcPtr<Spiral::UH4>,
            v4: string,
            v5: string,
        ) -> string {
            let v6: LrcPtr<dyn IDisposable> = Spiral::method73(v4.clone());
            let v9: string = Spiral::method45(Spiral::method35(
                v4.clone(),
                concat(new_array(&[v1_1.clone(), string(".fs")])),
            ));
            Spiral::method71(v9.clone(), v0_1);
            {
                let v13: List<string> = Spiral::method119(
                    Spiral::method209(v5, v2, LrcPtr::new(Spiral::UH2::UH2_0)),
                    empty::<string>(),
                );
                let v30: string = join(
                    string("\\n        "),
                    toArray_1(delay(Func0::new({
                        let v13 = v13.clone();
                        move || ofList(v13.clone()).clone()
                    }))),
                );
                let v36: List<string> = Spiral::method119(
                    Spiral::method210(v3, LrcPtr::new(Spiral::UH2::UH2_0)),
                    empty::<string>(),
                );
                let v52: string = join(
                    string("\\n        "),
                    toArray_1(delay(Func0::new({
                        let v36 = v36.clone();
                        move || ofList(v36.clone()).clone()
                    }))),
                );
                let v57: string = Spiral::method45(Spiral::method35(
                    v4,
                    concat(new_array(&[v1_1, string(".fsproj")])),
                ));
                Spiral::method71(v57.clone(),
                                 append((append((append((append((append((append((append((append((append((append((append((append((append(string("<Project Sdk=\"Microsoft.NET.Sdk\">\n<PropertyGroup>\n    <TargetFramework>net9.0</TargetFramework>\n    <LangVersion>preview</LangVersion>\n    <RollForward>Major</RollForward>\n    <TargetLatestRuntimePatch>true</TargetLatestRuntimePatch>\n    <PublishAot>false</PublishAot>\n    <PublishTrimmed>false</PublishTrimmed>\n    <PublishSingleFile>true</PublishSingleFile>\n    <SelfContained>true</SelfContained>\n    <Version>0.0.1-alpha.1</Version>\n    <OutputType>Exe</OutputType>\n    <ServerGarbageCollection>true</ServerGarbageCollection>\n    <ConcurrentGarbageCollection>true</ConcurrentGarbageCollection>\n</PropertyGroup>\n<PropertyGroup Condition=\"$([MSBuild]::IsOSPlatform(\'FreeBSD\'))\">\n    <DefineConstants>_FREEBSD</DefineConstants>\n</PropertyGroup>\n<PropertyGroup Condition=\"$([MSBuild]::IsOSPlatform(\'Linux\'))\">\n    <DefineConstants>_LINUX</DefineConstants>\n</PropertyGroup>\n<PropertyGroup Condition=\"$([MSBuild]::IsOSPlatform(\'OSX\'))\">\n    <DefineConstants>_OSX</DefineConstants>\n</PropertyGroup>\n<PropertyGroup Condition=\"$([MSBuild]::IsOSPlatform(\'Windows\'))\">\n    <DefineConstants>_WINDOWS</DefineConstants>\n</PropertyGroup>\n<ItemGroup>\n"),
                                                                                                                                        (concat(new_array(&[string("    "),
                                                                                                                                                            v30]))))),
                                                                                                                                string("\n"))),
                                                                                                                        (concat(new_array(&[string("    <Compile Include=\""),
                                                                                                                                            v9,
                                                                                                                                            string("\" />")]))))),
                                                                                                                string("\n"))),
                                                                                                        string("</ItemGroup>"))),
                                                                                                string("\n"))),
                                                                                        string("<ItemGroup>"))),
                                                                                string("\n"))),
                                                                        (concat(new_array(&[string("    "),
                                                                                            v52]))))),
                                                                string("\n"))),
                                                        string("</ItemGroup>"))),
                                                string("\n"))),
                                        string("</Project>")));
                v57
            }
        }
        pub fn closure87(unitVar: (), v0_1: chrono::DateTime<chrono::Utc>) -> Spiral::US40 {
            Spiral::US40::US40_0(v0_1)
        }
        pub fn method212() -> Func1<chrono::DateTime<chrono::Utc>, Spiral::US40> {
            Func1::new(move |v: chrono::DateTime<chrono::Utc>| Spiral::closure87((), v))
        }
        pub fn method213() -> string {
            string("hh:mm")
        }
        pub fn method214() -> string {
            string("yyyyMMdd-HHmm-ssff-ffff-f")
        }
        pub fn method215() -> string {
            string("hhmm")
        }
        pub fn method211(v0_1: Guid, v1_1: DateTime) -> Guid {
            let v570: DateTime = {
                let _arg: DateTime = DateTime::unixEpoch();
                _arg.toUniversalTime()
            };
            let v580: DateTime = {
                let _arg_1: DateTime = DateTime::specifyKind(v1_1, 2_i32);
                _arg_1.toUniversalTime()
            };
            let v672: i64 = ((v580.ticks()) - (v570.ticks())) / 10_i64;
            let v674: Option<chrono::DateTime<chrono::Utc>> =
                chrono::DateTime::from_timestamp_micros(v672);
            let v691: Spiral::US40 =
                defaultValue(Spiral::US40::US40_1, map(Spiral::method212(), v674));
            let v711: Spiral::US5 = match &v691 {
                Spiral::US40::US40_0(v691_0_0) => {
                    let v697: chrono::NaiveDateTime = match &v691 {
                        Spiral::US40::US40_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone()
                    .naive_utc();
                    let v699: chrono::DateTime<chrono::Local> =
                        chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &v697);
                    let v701: string = string("r#\"%Y%m%d-%H%M-%S%f\"#");
                    let v702: &str = r#"%Y%m%d-%H%M-%S%f"#;
                    let v704: std::string::String = v699.format(v702).to_string();
                    let v706: string = fable_library_rust::String_::fromString(v704);
                    Spiral::US5::US5_0(sprintf!(
                        "{}-{}-{}",
                        getSlice(v706.clone(), Some(0_i32), Some(17_i32)),
                        getSlice(v706.clone(), Some(18_i32), Some(21_i32)),
                        getCharAt(v706, 22_i32)
                    ))
                }
                _ => Spiral::US5::US5_1,
            };
            let v715: string = match &v711 {
                Spiral::US5::US5_0(v711_0_0) => match &v711 {
                    Spiral::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                _ => string(""),
            };
            let v722: LrcPtr<TimeZoneInfo> = std::sync::Arc::new(
                chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64,
            );
            let v760: i64 = v580.ticks();
            let v795: string =
                string("chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))");
            let v936: TimeSpan = TimeSpan::new_ticks(chrono::FixedOffset::local_minus_utc(
                &chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(
                    &chrono::DateTime::from_timestamp_nanos(v760),
                )),
            ) as i64);
            let v951: u8 = if (v936.hours()) > 0_i32 { 1_u8 } else { 0_u8 };
            let v952: string = Spiral::method213();
            let v1121: string = v936.toString(v952);
            let v1176: string = sprintf!(
                "{}{}{}",
                v951,
                getSlice(v1121.clone(), Some(0_i32), Some(1_i32)),
                getSlice(v1121, Some(3_i32), Some(4_i32))
            );
            let v1179: string = toString(v0_1);
            parse(concat(new_array(&[
                v715.clone(),
                v1176.clone(),
                getSlice(
                    v1179.clone(),
                    Some((length(v715)) + (length(v1176))),
                    Some((length(v1179)) - 1_i32),
                ),
            ])))
        }
        pub fn method216(v0_1: string, v1_1: string) {
            if (Spiral::method38(v0_1.clone())) == false {
                let v4: LrcPtr<dyn IDisposable> = Spiral::method73(v0_1.clone());
                ()
            }
            {
                let v8: string = defaultValue(string(""), Spiral::method40(v1_1.clone()));
                if (Spiral::method38(v8.clone())) == false {
                    let v13: LrcPtr<dyn IDisposable> = Spiral::method73(v8);
                    ()
                }
                if if Spiral::method38(v1_1.clone()) {
                    let v15: Result<std::path::PathBuf, std::io::Error> =
                        Spiral::method46(v1_1.clone());
                    v15.is_err()
                } else {
                    false
                } {
                    Spiral::method84(true, v1_1.clone());
                }
                if (Spiral::method38(v1_1.clone())) == false {
                    let v31: bool = true;
                    #[cfg(windows)]
                    std::os::windows::fs::symlink_dir(&*v0_1.clone(), &*v1_1.clone()).unwrap();
                    let v33: bool = true;
                    #[cfg(unix)]
                    std::os::unix::fs::symlink(&*v0_1, &*v1_1).unwrap();
                    ()
                }
            }
        }
        pub fn method218() -> string {
            string("(")
        }
        pub fn method219() -> string {
            string(" ")
        }
        pub fn method220(v0_1: Spiral::US37) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v13: () = {
                Spiral::closure7(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method224(v0_1: bool, v1_1: string, v2: i32, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v13: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v5.clone(), string("is_error"), ());
                ()
            };
            let v33: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v45: () = {
                Spiral::closure7(
                    v5.clone(),
                    if v0_1 {
                        string("true")
                    } else {
                        string("false")
                    },
                    (),
                );
                ()
            };
            let v55: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v5.clone(), string("retry"), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v92: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v102: () = {
                Spiral::closure7(v5.clone(), string("result"), ());
                ()
            };
            let v111: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v120: () = {
                Spiral::closure7(v5.clone(), sprintf!("{}", v2), ());
                ()
            };
            let v130: () = {
                Spiral::closure7(v5.clone(), string(", "), ());
                ()
            };
            let v139: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v149: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
        }
        pub fn method223(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: bool,
            v9: string,
            v10: i32,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method224(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("common.retry_fn\' / loop"),
                v12
            ))
        }
        pub fn closure88(v0_1: u8, v1_1: u8, v2: i32, v3: string, v4: bool, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v9: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v35: Option<i64> = patternInput.5.clone();
                let v34: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v33: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v32: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v31: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v30: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method223(
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    v35.clone(),
                    Spiral::method8(v30, v31, v32, v33, v34, v35),
                    Spiral::method12(),
                    v4,
                    sprintf!("{}/{}", v1_1, v0_1),
                    v2,
                    v3,
                ))
            };
        }
        pub fn method222(
            v0_1: u8,
            v1_1: string,
            v2: Option<CancellationToken>,
            v3: Array<(string, string)>,
            v4: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v5: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v6: bool,
            v7: Option<string>,
            v8: u8,
        ) -> (i32, string) {
            let v0_1: MutCell<u8> = MutCell::new(v0_1);
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<Option<CancellationToken>> = MutCell::new(v2.clone());
            let v3: MutCell<Array<(string, string)>> = MutCell::new(v3.clone());
            let v4 = MutCell::new(v4.clone());
            let v5 = MutCell::new(v5.clone());
            let v6: MutCell<bool> = MutCell::new(v6);
            let v7: MutCell<Option<string>> = MutCell::new(v7.clone());
            let v8: MutCell<u8> = MutCell::new(v8);
            '_method222: loop {
                break '_method222 ({
                    let patternInput: (i32, string) = Spiral::method96(
                        v1_1.get().clone(),
                        v2.get().clone(),
                        v3.get().clone(),
                        v4.get().clone(),
                        v5.get().clone(),
                        v6.get().clone(),
                        v7.get().clone(),
                    );
                    let v9: i32 = patternInput.0.clone();
                    let v10: string = patternInput.1.clone();
                    let v14: Spiral::US41 = if (v9) == 0_i32 {
                        Spiral::US41::US41_0(v9, v10.clone())
                    } else {
                        Spiral::US41::US41_1(v9, v10)
                    };
                    let patternInput_1: (bool, i32, string) = match &v14 {
                        Spiral::US41::US41_0(v14_0_0, v14_0_1) => {
                            (false, v14_0_0.clone(), v14_0_1.clone())
                        }
                        Spiral::US41::US41_1(v14_1_0, v14_1_1) => {
                            (true, v14_1_0.clone(), v14_1_1.clone())
                        }
                    };
                    let v24: string = patternInput_1.2.clone();
                    let v23: i32 = patternInput_1.1.clone();
                    let v22: bool = patternInput_1.0.clone();
                    if if (v22) == false {
                        true
                    } else {
                        (v8.get().clone()) >= (v0_1.get().clone())
                    } {
                        (v23, v24.clone())
                    } else {
                        let v30: () = {
                            Spiral::closure88(
                                v0_1.get().clone(),
                                v8.get().clone(),
                                v23,
                                v24,
                                v22,
                                (),
                            );
                            ()
                        };
                        {
                            let v0_1_temp: u8 = v0_1.get().clone();
                            let v1_1_temp: string = v1_1.get().clone();
                            let v2_temp: Option<CancellationToken> = v2.get().clone();
                            let v3_temp: Array<(string, string)> = v3.get().clone();
                            let v4_temp = v4.get().clone();
                            let v5_temp = v5.get().clone();
                            let v6_temp: bool = v6.get().clone();
                            let v7_temp: Option<string> = v7.get().clone();
                            let v8_temp: u8 = (v8.get().clone()) + 1_u8;
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            v5.set(v5_temp);
                            v6.set(v6_temp);
                            v7.set(v7_temp);
                            v8.set(v8_temp);
                            continue '_method222;
                        }
                    }
                });
            }
        }
        pub fn method221(
            v0_1: u8,
            v1_1: string,
            v2: Option<CancellationToken>,
            v3: Array<(string, string)>,
            v4: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v5: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v6: bool,
            v7: Option<string>,
        ) -> (i32, string) {
            Spiral::method222(v0_1, v1_1, v2, v3, v4, v5, v6, v7, 1_u8)
        }
        pub fn method217(
            v0_1: Spiral::US36,
            v1_1: string,
            v2: string,
            v3: string,
            v4: Spiral::US10,
        ) -> (i32, string) {
            let v153: string = sprintf!(
                "dotnet fable \"{}\" --optimize --lang {} --extension .{} --outDir \"{}\"{}{}",
                v3,
                v2.clone(),
                v2,
                v1_1,
                concat(new_array(&[
                    string(" --define "),
                    if cfg!(windows) {
                        string("_WINDOWS")
                    } else {
                        string("_LINUX")
                    }
                ])),
                match &v0_1 {
                    Spiral::US36::US36_0(v0_1_0_0) => {
                        let v45: Spiral::US37 = match &v0_1 {
                            Spiral::US36::US36_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone();
                        let v93: Spiral::US5 = if if let Spiral::US37::US37_0(v45_0_0) = &v45 {
                            string("") == (v45_0_0.clone())
                        } else {
                            false
                        } {
                            Spiral::US5::US5_0(string("Wasm"))
                        } else {
                            let v62: string = Spiral::method218();
                            let v77: Array<string> = split(
                                Spiral::method220(Spiral::US37::US37_0(string(""))),
                                v62,
                                -1_i32,
                                0_i32,
                            );
                            let v81: string = v77[0_i32].clone();
                            if startsWith3(Spiral::method220(v45.clone()), v81, false) {
                                Spiral::US5::US5_0(string("Wasm"))
                            } else {
                                Spiral::US5::US5_1
                            }
                        };
                        let v142: Spiral::US5 = match &v93 {
                            Spiral::US5::US5_0(v93_0_0) => Spiral::US5::US5_0(
                                match &v93 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => {
                                let v135: Spiral::US5 = if if let Spiral::US37::US37_1(v45_1_0) =
                                    &v45
                                {
                                    string("") == (v45_1_0.clone())
                                } else {
                                    false
                                } {
                                    Spiral::US5::US5_0(string("Contract"))
                                } else {
                                    let v104: string = Spiral::method218();
                                    let v119: Array<string> = split(
                                        Spiral::method220(Spiral::US37::US37_1(string(""))),
                                        v104,
                                        -1_i32,
                                        0_i32,
                                    );
                                    let v123: string = v119[0_i32].clone();
                                    if startsWith3(Spiral::method220(v45.clone()), v123, false) {
                                        Spiral::US5::US5_0(string("Contract"))
                                    } else {
                                        Spiral::US5::US5_1
                                    }
                                };
                                match &v135 {
                                    Spiral::US5::US5_0(v135_0_0) => Spiral::US5::US5_0(
                                        match &v135 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => Spiral::US5::US5_1,
                                }
                            }
                        };
                        concat(new_array(&[
                            string(" --define "),
                            toUpper(match &v142 {
                                Spiral::US5::US5_0(v142_0_0) => match &v142 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => panic!("{}", string("Option does not have a value."),),
                            }),
                        ]))
                    }
                    _ => string(""),
                }
            );
            let v159: Result<string, string> = match &v4 {
                Spiral::US10::US10_0(v4_0_0) => Ok::<string, string>(v4_0_0.clone()),
                Spiral::US10::US10_1(v4_1_0) => Err::<string, string>(v4_1_0.clone()),
            };
            Spiral::method221(
                3_u8,
                v153,
                None::<CancellationToken>,
                new_empty::<(string, string)>(),
                None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
                None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
                true,
                v159.ok(),
            )
        }
        pub fn method226(v0_1: i32, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral::closure7(v3.clone(), string("dotnet_fable_result"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v78: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method225(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: string,
        ) -> string {
            let v10: string = Spiral::method226(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / dotnet fable error"),
                v10
            ))
        }
        pub fn closure89(v0_1: string, v1_1: i32, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method225(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method77(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn closure90(unitVar: (), v0_1: std::string::String) -> bool {
            contains(
                fable_library_rust::String_::fromString(v0_1),
                string("near-sdk"),
            )
        }
        pub fn method227() -> Func1<std::string::String, bool> {
            Func1::new(move |v: std::string::String| Spiral::closure90((), v))
        }
        pub fn method228(v0_1: Vec<std::string::String>) -> Vec<std::string::String> {
            v0_1
        }
        pub fn method229() -> string {
            string("(")
        }
        pub fn method230() -> string {
            string("(")
        }
        pub fn method232(
            v0_1: string,
            v1_1: regex::Regex,
        ) -> Vec<std::collections::HashMap<string, string>> {
            let v8: &str = &*v0_1;
            let v41: std::string::String = String::from(v8);
            let v69: bool = true;
            let _capture_move = (move || {
                //;
                let v71: Box<std::string::String> = Box::new(v41);
                let v73: &'static mut std::string::String = Box::leak(v71);
                let v75: regex::Regex = v1_1.clone();
                let v77: regex::CaptureMatches = v75.captures_iter(v73);
                let v79: bool = true;
                let _regex_captures: Vec<_> = v77
                    .map(|x| {
                        //;
                        let v81: regex::Captures<'static> = x;
                        let v83: Box<regex::Captures<'static>> = Box::new(v81);
                        let v85: &'static mut regex::Captures<'static> = Box::leak(v83);
                        let v87: regex::CaptureNames = v1_1.capture_names();
                        let v89: bool = true;
                        let _regex_captures: std::collections::HashMap<_, _> = v87
                            .map(|x| {
                                //;
                                let v91: string = x.unwrap_or("").to_string().into();
                                let v93: string = v91.clone().clone();
                                let v95: string = v85
                                    .name(&v91)
                                    .map(|x| x.as_str())
                                    .unwrap_or("")
                                    .to_string()
                                    .into();
                                let v98: bool = true;
                                LrcPtr::new((v93, v95))
                            })
                            .map(|x| std::sync::Arc::try_unwrap(x).unwrap_or_else(|x| (*x).clone()))
                            .collect();
                        let v100: std::collections::HashMap<string, string> = _regex_captures;
                        let v102: bool = true;
                        v100
                    })
                    .collect::<Vec<_>>();
                let v104: Vec<std::collections::HashMap<string, string>> = _regex_captures;
                let v106: bool = true;
                v104
            })();
            _capture_move
        }
        pub fn closure91(
            unitVar: (),
            v0_1: std::collections::HashMap<string, string>,
        ) -> Spiral::US42 {
            Spiral::US42::US42_0(v0_1)
        }
        pub fn method233() -> Func1<std::collections::HashMap<string, string>, Spiral::US42> {
            Func1::new(move |v: std::collections::HashMap<string, string>| Spiral::closure91((), v))
        }
        pub fn method234() -> string {
            string("a")
        }
        pub fn closure92(v0_1: u8, v1_1: i32, v2: string, v3: bool, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v8: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v34: Option<i64> = patternInput.5.clone();
                let v33: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v32: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v31: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v30: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v29: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method223(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method12(),
                    v3,
                    sprintf!("{}/{}", v0_1, 3_u8),
                    v1_1,
                    v2,
                ))
            };
        }
        pub fn method231(v0_1: Spiral::US10, v1_1: string, v2: u8) -> (i32, string) {
            let v0_1: MutCell<Spiral::US10> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<u8> = MutCell::new(v2);
            '_method231: loop {
                break '_method231 ({
                    let v8: string = concat(new_array(&[
                        string("cargo fmt --manifest-path \""),
                        v1_1.get().clone(),
                        string("\" --"),
                    ]));
                    let v14: Result<string, string> = match &v0_1.get().clone() {
                        Spiral::US10::US10_0(v0_1_0_0) => Ok::<string, string>(v0_1_0_0.clone()),
                        Spiral::US10::US10_1(v0_1_1_0) => Err::<string, string>(v0_1_1_0.clone()),
                    };
                    let patternInput: (i32, string) = Spiral::method96(
                        v8,
                        None::<CancellationToken>,
                        new_empty::<(string, string)>(),
                        None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
                        None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
                        true,
                        v14.ok(),
                    );
                    let v32: string = patternInput.1.clone();
                    let v31: i32 = patternInput.0.clone();
                    let v191: Spiral::US41 = if (contains(
                        v32.clone(),
                        string("failed to load manifest for workspace member"),
                    )) == false
                    {
                        if (v31) == 0_i32 {
                            Spiral::US41::US41_0(v31, v32.clone())
                        } else {
                            Spiral::US41::US41_1(v31, v32.clone())
                        }
                    } else {
                        let v45: Result<regex::Regex, regex::Error> =
                            regex::Regex::new(&string("failed to read `(?<a>.*?Cargo.toml)`"));
                        let v61: Vec<std::collections::HashMap<string, string>> =
                            Spiral::method232(v32.clone(), v45.unwrap());
                        let v64: Option<std::collections::HashMap<string, string>> = tryItem(
                            0_i32,
                            fable_library_rust::NativeArray_::array_from(v61.clone()),
                        );
                        let v81: Spiral::US42 =
                            defaultValue(Spiral::US42::US42_1, map(Spiral::method233(), v64));
                        let v112: Spiral::US43 = match &v81 {
                            Spiral::US42::US42_0(v81_0_0) => {
                                let v86: string = Spiral::method234();
                                let v88: Option<string> = std::collections::HashMap::get(
                                    &match &v81 {
                                        Spiral::US42::US42_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    &v86,
                                )
                                .map(|x| x)
                                .cloned();
                                Spiral::US43::US43_0(defaultValue(
                                    Spiral::US5::US5_1,
                                    map(Spiral::method6(), v88),
                                ))
                            }
                            _ => Spiral::US43::US43_1,
                        };
                        let v119: Spiral::US5 = if let Spiral::US43::US43_0(v112_0_0) = &v112 {
                            let v113: Spiral::US5 = v112_0_0.clone();
                            if let Spiral::US5::US5_0(v113_0_0) = &v113 {
                                Spiral::US5::US5_0(v113_0_0.clone())
                            } else {
                                Spiral::US5::US5_1
                            }
                        } else {
                            Spiral::US5::US5_1
                        };
                        match &v119 {
                            Spiral::US5::US5_0(v119_0_0) => {
                                let v121: string = match &v119 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone();
                                if (Spiral::method37(v121.clone())) == false {
                                    let v130: LrcPtr<dyn IDisposable> = Spiral::method73(
                                        defaultValue(string(""), Spiral::method40(v121.clone())),
                                    );
                                    let v134: DateTime = DateTime::now();
                                    let v157: string =
                                        toString(Spiral::method211(new_guid(), v134));
                                    let v182: string =
                                                     append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                            (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                v157.clone(),
                                                                                                                                                                                string("\"")]))))),
                                                                                                                                                    string("\n"))),
                                                                                                                                            string("version = \"0.0.1\""))),
                                                                                                                                    string("\n"))),
                                                                                                                            string("edition = \"2021\""))),
                                                                                                                    string("\n"))),
                                                                                                            string(""))),
                                                                                                    string("\n"))),
                                                                                            string("[[bin]]"))),
                                                                                    string("\n"))),
                                                                            (concat(new_array(&[string("name = \"spiral_"),
                                                                                                v157,
                                                                                                string("\"")]))))),
                                                                    string("\n"))),
                                                            string("path = \"spiral.rs\""));
                                    std::fs::write(&*v121, &*v182).unwrap();
                                    ()
                                }
                                if (v31) == 0_i32 {
                                    Spiral::US41::US41_0(v31, v32.clone())
                                } else {
                                    Spiral::US41::US41_1(v31, v32.clone())
                                }
                            }
                            _ => Spiral::US41::US41_1(v31, v32.clone()),
                        }
                    };
                    let patternInput_1: (bool, i32, string) = match &v191 {
                        Spiral::US41::US41_0(v191_0_0, v191_0_1) => {
                            (false, v191_0_0.clone(), v191_0_1.clone())
                        }
                        Spiral::US41::US41_1(v191_1_0, v191_1_1) => {
                            (true, v191_1_0.clone(), v191_1_1.clone())
                        }
                    };
                    let v201: string = patternInput_1.2.clone();
                    let v200: i32 = patternInput_1.1.clone();
                    let v199: bool = patternInput_1.0.clone();
                    if if (v199) == false {
                        true
                    } else {
                        (v2.get().clone()) >= 3_u8
                    } {
                        (v200, v201.clone())
                    } else {
                        let v207: () = {
                            Spiral::closure92(v2.get().clone(), v200, v201, v199, ());
                            ()
                        };
                        {
                            let v0_1_temp: Spiral::US10 = v0_1.get().clone();
                            let v1_1_temp: string = v1_1.get().clone();
                            let v2_temp: u8 = (v2.get().clone()) + 1_u8;
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            continue '_method231;
                        }
                    }
                });
            }
        }
        pub fn method236(v0_1: i32, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral::closure7(v3.clone(), string("cargo_fmt_result"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v78: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method235(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: string,
        ) -> string {
            let v10: string = Spiral::method236(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / cargo fmt error"),
                v10
            ))
        }
        pub fn closure93(v0_1: string, v1_1: i32, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method235(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method77(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn method237() -> string {
            string("{")
        }
        pub fn closure94(unitVar: (), v0_1: string) -> string {
            v0_1
        }
        pub fn closure95(v0_1: string, v1_1: string, v2: string) -> string {
            replace(v2, v0_1, v1_1)
        }
        pub fn closure96(v0_1: string, v1_1: string) -> string {
            replace(v1_1, v0_1, string("type DateTime = ();"))
        }
        pub fn method239(v0_1: i32, v1_1: string, v2: string, v3: bool, v4: string) -> string {
            let v6: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v14: () = {
                Spiral::closure7(v6.clone(), string("{ "), ());
                ()
            };
            let v24: () = {
                Spiral::closure7(v6.clone(), string("exit_code"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v6.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v53: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v63: () = {
                Spiral::closure7(v6.clone(), string("new_code_path"), ());
                ()
            };
            let v72: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v81: () = {
                Spiral::closure7(v6.clone(), v1_1, ());
                ()
            };
            let v90: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v100: () = {
                Spiral::closure7(v6.clone(), string("external_command"), ());
                ()
            };
            let v109: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v118: () = {
                Spiral::closure7(v6.clone(), v2, ());
                ()
            };
            let v127: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v137: () = {
                Spiral::closure7(v6.clone(), string("cleanup"), ());
                ()
            };
            let v146: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v158: () = {
                Spiral::closure7(
                    v6.clone(),
                    if v3 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v167: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v177: () = {
                Spiral::closure7(v6.clone(), string("cargo_result"), ());
                ()
            };
            let v186: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v195: () = {
                Spiral::closure7(v6.clone(), v4, ());
                ()
            };
            let v205: () = {
                Spiral::closure7(v6.clone(), string(" }"), ());
                ()
            };
            v6.l0.get().clone()
        }
        pub fn method238(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: string,
            v10: string,
            v11: bool,
            v12: string,
        ) -> string {
            let v13: string = Spiral::method239(v8, v9, v10, v11, v12);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / error"),
                v13
            ))
        }
        pub fn closure97(v0_1: bool, v1_1: string, v2: string, v3: i32, v4: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v9: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v35: Option<i64> = patternInput.5.clone();
                let v34: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v33: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v32: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v31: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v30: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method238(
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    v35.clone(),
                    Spiral::method8(v30, v31, v32, v33, v34, v35),
                    Spiral::method77(),
                    v3,
                    v1_1,
                    v4,
                    v0_1,
                    v2,
                ))
            };
        }
        pub fn closure99(unitVar: (), v0_1: string) -> bool {
            if (contains(v0_1.clone(), string("profile [optimized] target"))) == false {
                if (contains(v0_1.clone(), string("profile [unoptimized] target"))) == false {
                    (contains(v0_1, string("profile [unoptimized + debuginfo] target"))) == false
                } else {
                    false
                }
            } else {
                false
            }
        }
        pub fn closure98(v0_1: string, unitVar: ()) -> string {
            let v10: LrcPtr<dyn IEnumerable_1<string>> = ofArray_1(skip(
                2_i32,
                skipWhile(
                    Func1::new(move |v: string| Spiral::closure99((), v)),
                    split(v0_1, string("\n"), -1_i32, 0_i32),
                ),
            ));
            join(Spiral::method70(), toArray_1(v10))
        }
        pub fn method241(v0_1: LrcPtr<Exception>, v1_1: string, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v13: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v5.clone(), string("ex"), ());
                ()
            };
            let v33: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v42: std::string::String = format!("{:#?}", v0_1);
            let v81: () = {
                Spiral::closure7(v5.clone(), fable_library_rust::String_::fromString(v42), ());
                ()
            };
            let v91: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v101: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v110: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v119: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v128: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v138: () = {
                Spiral::closure7(v5.clone(), string("external_command"), ());
                ()
            };
            let v147: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v156: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v165: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v175: () = {
                Spiral::closure7(v5.clone(), string("cargo_result"), ());
                ()
            };
            let v184: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v193: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v203: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
        }
        pub fn method240(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: LrcPtr<Exception>,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method241(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / Exception"),
                v12
            ))
        }
        pub fn closure101(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
            unitVar: (),
        ) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v8: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v34: Option<i64> = patternInput.5.clone();
                let v33: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v32: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v31: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v30: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v29: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method240(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method77(),
                    v3,
                    v0_1,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure100(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure101(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
        }
        pub fn method243(v0_1: i32, v1_1: string, v2: string, v3: bool, v4: string) -> string {
            let v6: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v14: () = {
                Spiral::closure7(v6.clone(), string("{ "), ());
                ()
            };
            let v24: () = {
                Spiral::closure7(v6.clone(), string("exit_code"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v6.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v53: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v63: () = {
                Spiral::closure7(v6.clone(), string("new_code_path"), ());
                ()
            };
            let v72: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v81: () = {
                Spiral::closure7(v6.clone(), v1_1, ());
                ()
            };
            let v90: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v100: () = {
                Spiral::closure7(v6.clone(), string("cargo_result"), ());
                ()
            };
            let v109: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v118: () = {
                Spiral::closure7(v6.clone(), v2, ());
                ()
            };
            let v127: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v137: () = {
                Spiral::closure7(v6.clone(), string("cleanup"), ());
                ()
            };
            let v146: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v158: () = {
                Spiral::closure7(
                    v6.clone(),
                    if v3 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v167: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v177: () = {
                Spiral::closure7(v6.clone(), string("spiral_wasm_result"), ());
                ()
            };
            let v186: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v195: () = {
                Spiral::closure7(v6.clone(), v4, ());
                ()
            };
            let v205: () = {
                Spiral::closure7(v6.clone(), string(" }"), ());
                ()
            };
            v6.l0.get().clone()
        }
        pub fn method242(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: string,
            v10: string,
            v11: bool,
            v12: string,
        ) -> string {
            let v13: string = Spiral::method243(v8, v9, v10, v11, v12);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / wasm error"),
                v13
            ))
        }
        pub fn closure102(v0_1: bool, v1_1: string, v2: string, v3: string, v4: i32, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v9: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v35: Option<i64> = patternInput.5.clone();
                let v34: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v33: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v32: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v31: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v30: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method242(
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    v35.clone(),
                    Spiral::method8(v30, v31, v32, v33, v34, v35),
                    Spiral::method77(),
                    v4,
                    v1_1,
                    v2,
                    v0_1,
                    concat(new_array(&[string("\n"), v3])),
                ))
            };
        }
        pub fn method245(
            v0_1: i32,
            v1_1: string,
            v2: string,
            v3: string,
            v4: bool,
            v5: string,
        ) -> string {
            let v7: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v15: () = {
                Spiral::closure7(v7.clone(), string("{ "), ());
                ()
            };
            let v25: () = {
                Spiral::closure7(v7.clone(), string("exit_code"), ());
                ()
            };
            let v35: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v44: () = {
                Spiral::closure7(v7.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v64: () = {
                Spiral::closure7(v7.clone(), string("new_code_path"), ());
                ()
            };
            let v73: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v82: () = {
                Spiral::closure7(v7.clone(), v1_1, ());
                ()
            };
            let v91: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v101: () = {
                Spiral::closure7(v7.clone(), string("wasm_path"), ());
                ()
            };
            let v110: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v119: () = {
                Spiral::closure7(v7.clone(), v2, ());
                ()
            };
            let v128: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v138: () = {
                Spiral::closure7(v7.clone(), string("command"), ());
                ()
            };
            let v147: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v156: () = {
                Spiral::closure7(v7.clone(), v3, ());
                ()
            };
            let v165: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v175: () = {
                Spiral::closure7(v7.clone(), string("cleanup"), ());
                ()
            };
            let v184: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v196: () = {
                Spiral::closure7(
                    v7.clone(),
                    if v4 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v205: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v215: () = {
                Spiral::closure7(v7.clone(), string("cargo_result"), ());
                ()
            };
            let v224: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v233: () = {
                Spiral::closure7(v7.clone(), v5, ());
                ()
            };
            let v243: () = {
                Spiral::closure7(v7.clone(), string(" }"), ());
                ()
            };
            v7.l0.get().clone()
        }
        pub fn method244(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: string,
            v10: string,
            v11: string,
            v12: bool,
            v13: string,
        ) -> string {
            let v14: string = Spiral::method245(v8, v9, v10, v11, v12, v13);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / cargo error"),
                v14
            ))
        }
        pub fn closure103(
            v0_1: bool,
            v1_1: string,
            v2: string,
            v3: i32,
            v4: string,
            v5: string,
            unitVar: (),
        ) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v10: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v36: Option<i64> = patternInput.5.clone();
                let v35: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v34: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v33: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v32: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v31: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method244(
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    v35.clone(),
                    v36.clone(),
                    Spiral::method8(v31, v32, v33, v34, v35, v36),
                    Spiral::method77(),
                    v3,
                    v1_1,
                    v4,
                    v5,
                    v0_1,
                    concat(new_array(&[string("\n"), v2])),
                ))
            };
        }
        pub fn method247(v0_1: string, v1_1: LrcPtr<Spiral::UH5>) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("new_code_path"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v60: () = {
                Spiral::closure7(v3.clone(), string("cleanup"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v82: () = {
                Spiral::closure7(v3.clone(), sprintf!("{:?}", v1_1), ());
                ()
            };
            let v92: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method246(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: string,
            v9: string,
            v10: bool,
            v11: string,
            v12: bool,
            v13: string,
            v14: bool,
            v15: string,
            v16: bool,
            v17: string,
            v18: bool,
        ) -> string {
            let v25: string = Spiral::method247(
                v8,
                LrcPtr::new(Spiral::UH5::UH5_1(
                    v9,
                    v10,
                    LrcPtr::new(Spiral::UH5::UH5_1(
                        v11,
                        v12,
                        LrcPtr::new(Spiral::UH5::UH5_1(
                            v13,
                            v14,
                            LrcPtr::new(Spiral::UH5::UH5_1(
                                v15,
                                v16,
                                LrcPtr::new(Spiral::UH5::UH5_1(
                                    v17,
                                    v18,
                                    LrcPtr::new(Spiral::UH5::UH5_0),
                                )),
                            )),
                        )),
                    )),
                )),
            );
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / cleanup"),
                v25
            ))
        }
        pub fn closure104(
            v0_1: string,
            v1_1: string,
            v2: bool,
            v3: string,
            v4: bool,
            v5: string,
            v6: bool,
            v7: string,
            v8: bool,
            v9: string,
            v10: bool,
            unitVar: (),
        ) {
            if Spiral::method7(Spiral::US0::US0_0) {
                let v15: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v41: Option<i64> = patternInput.5.clone();
                let v40: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v39: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v38: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v37: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v36: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method246(
                    v36.clone(),
                    v37.clone(),
                    v38.clone(),
                    v39.clone(),
                    v40.clone(),
                    v41.clone(),
                    Spiral::method8(v36, v37, v38, v39, v40, v41),
                    Spiral::method80(),
                    v0_1,
                    v1_1,
                    v2,
                    v3,
                    v4,
                    v5,
                    v6,
                    v7,
                    v8,
                    v9,
                    v10,
                ))
            };
        }
        pub fn closure105(unitVar: (), unitVar_1: ()) -> Spiral::US44 {
            Spiral::US44::US44_0
        }
        pub fn method249() -> Func0<Spiral::US44> {
            Func0::new(move || Spiral::closure105((), ()))
        }
        pub fn closure106(unitVar: (), v0_1: string) -> Spiral::US44 {
            Spiral::US44::US44_1(v0_1)
        }
        pub fn method250() -> Func1<string, Spiral::US44> {
            Func1::new(move |v: string| Spiral::closure106((), v))
        }
        pub fn method252(v0_1: string) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral::closure7(v2.clone(), string("error\'"), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v39: () = {
                Spiral::closure7(v2.clone(), v0_1, ());
                ()
            };
            let v49: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method251(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: string,
        ) -> string {
            let v9: string = Spiral::method252(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.file_delete"),
                v9
            ))
        }
        pub fn closure107(v0_1: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v5: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method251(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method77(),
                    v0_1,
                ))
            };
        }
        pub fn method248(v0_1: LrcPtr<Spiral::UH5>) {
            let v0_1: MutCell<LrcPtr<Spiral::UH5>> = MutCell::new(v0_1.clone());
            '_method248: loop {
                break '_method248 (match v0_1.get().clone().as_ref() {
                    Spiral::UH5::UH5_0 => (),
                    Spiral::UH5::UH5_1(v0_1_1_0, v0_1_1_1, v0_1_1_2) => {
                        let v6: Result<(), std::io::Error> = std::fs::remove_file(
                            &*match v0_1.get().clone().as_ref() {
                                Spiral::UH5::UH5_1(x, _, _) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        );
                        let v7 = Spiral::method48();
                        let v20: Result<(), string> = v6.map_err(|x| v7(x));
                        let v23 = Spiral::method249();
                        let v24 = Spiral::method250();
                        let v25: Spiral::US44 = match &v20 {
                            Err(v20_1_0) => v24(v20_1_0.clone()),
                            _ => v23(),
                        };
                        match &v25 {
                            Spiral::US44::US44_0 => (),
                            Spiral::US44::US44_1(v25_1_0) => {
                                let v29: () = {
                                    Spiral::closure107(
                                        match &v25 {
                                            Spiral::US44::US44_1(x) => x.clone(),
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
                            let v0_1_temp: LrcPtr<Spiral::UH5> =
                                match v0_1.get().clone().as_ref() {
                                    Spiral::UH5::UH5_1(_, _, x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone();
                            v0_1.set(v0_1_temp);
                            continue '_method248;
                        }
                    }
                });
            }
        }
        pub fn method253(v0_1: string) -> string {
            v0_1
        }
        pub fn closure109(unitVar: (), v0_1: std::fs::FileType) -> Spiral::US45 {
            Spiral::US45::US45_0(v0_1)
        }
        pub fn method254() -> Func1<std::fs::FileType, Spiral::US45> {
            Func1::new(move |v: std::fs::FileType| Spiral::closure109((), v))
        }
        pub fn closure110(unitVar: (), v0_1: std::string::String) -> Spiral::US45 {
            Spiral::US45::US45_1(v0_1)
        }
        pub fn method255() -> Func1<std::string::String, Spiral::US45> {
            Func1::new(move |v: std::string::String| Spiral::closure110((), v))
        }
        pub fn method256(v0_1: string) -> string {
            let v12: &str = &*v0_1;
            let v45: std::string::String = String::from(v12);
            let v78: std::path::PathBuf = std::path::PathBuf::from(v45);
            let v106: Option<&std::ffi::OsStr> = v78.file_name();
            let v108: bool = true;
            let _optionm_map_ = v106.map(|x| {
                //;
                let v110: &std::ffi::OsStr = x;
                let v112: std::ffi::OsString = v110.to_os_string();
                let v114: Option<&str> = v112.to_str();
                let v116: &str = v114.unwrap();
                let v123: std::string::String = String::from(v116);
                let v151: string = fable_library_rust::String_::fromString(v123);
                let v153: bool = true;
                v151
            });
            let v155: Option<string> = _optionm_map_;
            let v172: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v155));
            match &v172 {
                Spiral::US5::US5_0(v172_0_0) => match &v172 {
                    Spiral::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                _ => string(""),
            }
        }
        pub fn closure108(
            v0_1: string,
            v1_1: async_walkdir::DirEntry,
        ) -> std::pin::Pin<Box<dyn std::future::Future<Output = async_walkdir::Filtering> + Send>>
        {
            let v3: bool = true;
            let __future_init = Box::pin(
                /*;
                let v5: bool = */
                async {
                    /*;
                    let v7: bool = */
                    ();
                    let v9: bool = true;
                    let __future_init = Box::pin(
                        /*;
                        let v11: bool = */
                        async move {
                            /*;
                            let v13: bool = */
                            ();
                            let v15: async_walkdir::DirEntry = v1_1.clone();
                            let v17: std::pin::Pin<
                                Box<
                                    dyn std::future::Future<
                                            Output = Result<std::fs::FileType, std::io::Error>,
                                        > + Send,
                                >,
                            > = Box::pin(async_walkdir::DirEntry::file_type(&v15));
                            let v19: Result<std::fs::FileType, std::io::Error> = v17.await;
                            let v20 = Spiral::method74();
                            let v33: Result<std::fs::FileType, std::string::String> =
                                v19.map_err(|x| v20(x));
                            let v36 = Spiral::method254();
                            let v37 = Spiral::method255();
                            let v38: Spiral::US45 = match &v33 {
                                Err(v33_1_0) => v37(v33_1_0.clone()),
                                Ok(v33_0_0) => v36(v33_0_0.clone()),
                            };
                            let v265: Spiral::US46 = if let Spiral::US45::US45_0(v38_0_0) = &v38 {
                                if (std::fs::FileType::is_dir(&v38_0_0.clone())) == false {
                                    Spiral::US46::US46_0
                                } else {
                                    let v45: std::path::PathBuf =
                                        async_walkdir::DirEntry::path(&v1_1.clone());
                                    let v52: std::path::Display = v45.display();
                                    let v85: std::string::String = format!("{}", v52);
                                    let v113: string = fable_library_rust::String_::fromString(v85);
                                    if (startsWith3(
                                        Spiral::method256(v113.clone()),
                                        v0_1.clone(),
                                        false,
                                    )) == false
                                    {
                                        Spiral::US46::US46_1
                                    } else {
                                        let v121: Option<string> = Spiral::method40(v113);
                                        let v138: Spiral::US5 = defaultValue(
                                            Spiral::US5::US5_1,
                                            map(Spiral::method6(), v121),
                                        );
                                        if let Spiral::US5::US5_0(v138_0_0) = &v138 {
                                            if (contains(v138_0_0.clone(), v0_1.clone())) == false {
                                                Spiral::US46::US46_2
                                            } else {
                                                Spiral::US46::US46_1
                                            }
                                        } else {
                                            Spiral::US46::US46_1
                                        }
                                    }
                                }
                            } else {
                                let v156: std::path::PathBuf = async_walkdir::DirEntry::path(&v1_1);
                                let v163: std::path::Display = v156.display();
                                let v196: std::string::String = format!("{}", v163);
                                let v224: string = fable_library_rust::String_::fromString(v196);
                                if (startsWith3(
                                    Spiral::method256(v224.clone()),
                                    v0_1.clone(),
                                    false,
                                )) == false
                                {
                                    Spiral::US46::US46_1
                                } else {
                                    let v232: Option<string> = Spiral::method40(v224);
                                    let v249: Spiral::US5 = defaultValue(
                                        Spiral::US5::US5_1,
                                        map(Spiral::method6(), v232),
                                    );
                                    if let Spiral::US5::US5_0(v249_0_0) = &v249 {
                                        if (contains(v249_0_0.clone(), v0_1)) == false {
                                            Spiral::US46::US46_2
                                        } else {
                                            Spiral::US46::US46_1
                                        }
                                    } else {
                                        Spiral::US46::US46_1
                                    }
                                }
                            };
                            let v268: string = string("}");
                            let v273: bool = true;
                            let _fix_closure_v270 = v265;
                            let v280: string = append(
                                (append(
                                    (append(
                                        (append(string("true; _fix_closure_v270 "), (v268))),
                                        string("); "),
                                    )),
                                    string(""),
                                )),
                                string(" // rust.fix_closure\'"),
                            );
                            let v281: bool = true;
                            _fix_closure_v270
                        },
                    ); // rust.fix_closure';
                    let v283 = __future_init;
                    let v285: std::pin::Pin<
                        Box<dyn std::future::Future<Output = Spiral::US46> + Send>,
                    > = v283;
                    let v287: Spiral::US46 = v285.await;
                    let v296: async_walkdir::Filtering = match &v287 {
                        Spiral::US46::US46_0 => async_walkdir::Filtering::Ignore,
                        Spiral::US46::US46_1 => async_walkdir::Filtering::IgnoreDir,
                        _ => async_walkdir::Filtering::Continue,
                    };
                    let v297: string = string("}");
                    let v302: bool = true;
                    let _fix_closure_v299 = v296;
                    let v309: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v299 "), (v297))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v310: bool = true;
                    _fix_closure_v299
                },
            ); // rust.fix_closure';
            let v312 = __future_init;
            v312
        }
        pub fn closure112(unitVar: (), v0_1: async_walkdir::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method258() -> Func1<async_walkdir::Error, std::string::String> {
            Func1::new(move |v: async_walkdir::Error| Spiral::closure112((), v))
        }
        pub fn closure113(unitVar: (), v0_1: async_walkdir::DirEntry) -> Spiral::US47 {
            Spiral::US47::US47_0(v0_1)
        }
        pub fn method259() -> Func1<async_walkdir::DirEntry, Spiral::US47> {
            Func1::new(move |v: async_walkdir::DirEntry| Spiral::closure113((), v))
        }
        pub fn closure114(unitVar: (), v0_1: std::string::String) -> Spiral::US47 {
            Spiral::US47::US47_1(v0_1)
        }
        pub fn method260() -> Func1<std::string::String, Spiral::US47> {
            Func1::new(move |v: std::string::String| Spiral::closure114((), v))
        }
        pub fn method261(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: std::string::String,
        ) -> string {
            let v9: string = Spiral::method127(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript / stream_filter_map"),
                v9
            ))
        }
        pub fn closure115(v0_1: std::string::String, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v5: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method261(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method77(),
                    v0_1,
                ))
            };
        }
        pub fn closure111(
            v0_1: string,
            v1_1: Result<async_walkdir::DirEntry, async_walkdir::Error>,
        ) -> Option<(string, string)> {
            let v2 = Spiral::method258();
            let v15: Result<async_walkdir::DirEntry, std::string::String> = v1_1.map_err(|x| v2(x));
            let v18 = Spiral::method259();
            let v19 = Spiral::method260();
            let v20: Spiral::US47 = match &v15 {
                Err(v15_1_0) => v19(v15_1_0.clone()),
                Ok(v15_0_0) => v18(v15_0_0.clone()),
            };
            let v226: Spiral::US48 = match &v20 {
                Spiral::US47::US47_0(v20_0_0) => {
                    let v23: std::path::PathBuf = async_walkdir::DirEntry::path(&v20_0_0.clone());
                    let v30: std::path::Display = v23.display();
                    let v63: std::string::String = format!("{}", v30);
                    let v91: string = fable_library_rust::String_::fromString(v63);
                    let v92: string =
                        concat(new_array(&[v0_1.clone(), string("\\.(?<a>[-\\d\\w.]+)$")]));
                    let v94: Result<regex::Regex, regex::Error> = regex::Regex::new(&v92);
                    let v110: Vec<std::collections::HashMap<string, string>> =
                        Spiral::method232(v91.clone(), v94.unwrap());
                    let v113: Option<std::collections::HashMap<string, string>> = tryItem(
                        0_i32,
                        fable_library_rust::NativeArray_::array_from(v110.clone()),
                    );
                    let v130: Spiral::US42 =
                        defaultValue(Spiral::US42::US42_1, map(Spiral::method233(), v113));
                    let v161: Spiral::US43 = match &v130 {
                        Spiral::US42::US42_0(v130_0_0) => {
                            let v135: string = Spiral::method234();
                            let v137: Option<string> = std::collections::HashMap::get(
                                &match &v130 {
                                    Spiral::US42::US42_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                &v135,
                            )
                            .map(|x| x)
                            .cloned();
                            Spiral::US43::US43_0(defaultValue(
                                Spiral::US5::US5_1,
                                map(Spiral::method6(), v137),
                            ))
                        }
                        _ => Spiral::US43::US43_1,
                    };
                    let v168: Spiral::US5 = if let Spiral::US43::US43_0(v161_0_0) = &v161 {
                        let v162: Spiral::US5 = v161_0_0.clone();
                        if let Spiral::US5::US5_0(v162_0_0) = &v162 {
                            Spiral::US5::US5_0(v162_0_0.clone())
                        } else {
                            Spiral::US5::US5_1
                        }
                    } else {
                        Spiral::US5::US5_1
                    };
                    match &v168 {
                        Spiral::US5::US5_0(v168_0_0) => Spiral::US48::US48_0(
                            v91.clone(),
                            match &v168 {
                                Spiral::US5::US5_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => Spiral::US48::US48_1,
                    }
                }
                Spiral::US47::US47_1(v20_1_0) => {
                    let v177: () = {
                        Spiral::closure115(v20_1_0.clone(), ());
                        ()
                    };
                    Spiral::US48::US48_1
                }
            };
            match &v226 {
                Spiral::US48::US48_0(v226_0_0, v226_0_1) => Some((
                    match &v226 {
                        Spiral::US48::US48_0(x, _) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    match &v226 {
                        Spiral::US48::US48_0(_, x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                )),
                _ => None::<(string, string)>,
            }
        }
        pub fn method257(
            v0_1: string,
        ) -> Func1<Result<async_walkdir::DirEntry, async_walkdir::Error>, Option<(string, string)>>
        {
            Func1::new({
                let v0_1 = v0_1.clone();
                move |v: Result<async_walkdir::DirEntry, async_walkdir::Error>| {
                    Spiral::closure111(v0_1.clone(), v)
                }
            })
        }
        pub fn closure116(unitVar: (), _arg: (string, string)) -> (string, string) {
            (_arg.0.clone(), _arg.1.clone())
        }
        pub fn closure117(unitVar: (), _arg: (string, string)) -> Spiral::US48 {
            Spiral::US48::US48_0(_arg.0.clone(), _arg.1.clone())
        }
        pub fn method262() -> Func1<(string, string), Spiral::US48> {
            Func1::new(move |arg10_0040: (string, string)| Spiral::closure117((), arg10_0040))
        }
        pub fn method264(v0_1: Spiral::US48) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral::closure7(v2.clone(), string("version"), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v53: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method263(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: Spiral::US48,
        ) -> string {
            let v9: string = Spiral::method264(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript"),
                v9
            ))
        }
        pub fn closure118(v0_1: Spiral::US48, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v5: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method263(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method12(),
                    v0_1,
                ))
            };
        }
        pub fn method265(v0_1: string, v1_1: string, v2: Spiral::US48) {
            match &v2 {
                Spiral::US48::US48_0(v2_0_0, v2_0_1) => {
                    let v4: string = match &v2 {
                        Spiral::US48::US48_0(_, x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone();
                    Spiral::method216(
                        Spiral::method35(
                            v1_1.clone(),
                            concat(new_array(&[
                                string("fable-library-"),
                                string("ts"),
                                string("."),
                                v4.clone(),
                            ])),
                        ),
                        Spiral::method35(
                            v0_1.clone(),
                            concat(new_array(&[
                                string("fable_modules/fable-library-"),
                                string("ts"),
                                string("."),
                                v4,
                            ])),
                        ),
                    )
                }
                _ => panic!(
                    "{}",
                    concat(new_array(&[
                        string("spiral.process_typescript / fable library not found / lib_path: "),
                        v1_1.clone()
                    ])),
                ),
            };
        }
        pub fn method266(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: string,
        ) -> string {
            let v10: string = Spiral::method226(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript"),
                v10
            ))
        }
        pub fn closure119(v0_1: string, v1_1: i32, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method266(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method77(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn method268(v0_1: string) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral::closure7(v2.clone(), string("new_code_path"), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v39: () = {
                Spiral::closure7(v2.clone(), v0_1, ());
                ()
            };
            let v49: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method267(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: string,
        ) -> string {
            let v9: string = Spiral::method268(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript"),
                v9
            ))
        }
        pub fn closure120(v0_1: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v5: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method267(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method12(),
                    v0_1,
                ))
            };
        }
        pub fn method269(
            v0_1: LrcPtr<Spiral::UH4>,
            v1_1: LrcPtr<Spiral::UH4>,
        ) -> LrcPtr<Spiral::UH4> {
            match v0_1.as_ref() {
                Spiral::UH4::UH4_0 => v1_1.clone(),
                Spiral::UH4::UH4_1(v0_1_1_0, v0_1_1_1, v0_1_1_2) => {
                    LrcPtr::new(Spiral::UH4::UH4_1(
                        match v0_1.as_ref() {
                            Spiral::UH4::UH4_1(x, _, _) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        match v0_1.as_ref() {
                            Spiral::UH4::UH4_1(_, x, _) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        Spiral::method269(
                            match v0_1.as_ref() {
                                Spiral::UH4::UH4_1(_, _, x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                            v1_1.clone(),
                        ),
                    ))
                }
            }
        }
        pub fn method270(
            v0_1: LrcPtr<Spiral::UH4>,
            v1_1: List<(string, string)>,
        ) -> List<(string, string)> {
            match v0_1.as_ref() {
                Spiral::UH4::UH4_0 => v1_1.clone(),
                Spiral::UH4::UH4_1(v0_1_1_0, v0_1_1_1, v0_1_1_2) => cons(
                    (
                        match v0_1.as_ref() {
                            Spiral::UH4::UH4_1(x, _, _) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        match v0_1.as_ref() {
                            Spiral::UH4::UH4_1(_, x, _) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    Spiral::method270(
                        match v0_1.as_ref() {
                            Spiral::UH4::UH4_1(_, _, x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        v1_1.clone(),
                    ),
                ),
            }
        }
        pub fn closure121(v0_1: string, unitVar: ()) -> string {
            let v7: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method70(), toArray_1(v7))
        }
        pub fn method272(v0_1: LrcPtr<Exception>, v1_1: string, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v13: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v5.clone(), string("ex"), ());
                ()
            };
            let v33: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v42: std::string::String = format!("{:#?}", v0_1);
            let v81: () = {
                Spiral::closure7(v5.clone(), fable_library_rust::String_::fromString(v42), ());
                ()
            };
            let v91: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v101: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v110: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v119: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v128: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v138: () = {
                Spiral::closure7(v5.clone(), string("external_command"), ());
                ()
            };
            let v147: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v156: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v165: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v175: () = {
                Spiral::closure7(v5.clone(), string("run_result"), ());
                ()
            };
            let v184: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v193: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v203: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
        }
        pub fn method271(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: LrcPtr<Exception>,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method272(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript / Exception"),
                v12
            ))
        }
        pub fn closure123(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
            unitVar: (),
        ) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v8: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v34: Option<i64> = patternInput.5.clone();
                let v33: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v32: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v31: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v30: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v29: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method271(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method77(),
                    v3,
                    v0_1,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure122(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure123(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
        }
        pub fn method273(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method175(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript / error"),
                v12
            ))
        }
        pub fn closure124(v0_1: string, v1_1: string, v2: i32, v3: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v8: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v34: Option<i64> = patternInput.5.clone();
                let v33: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v32: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v31: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v30: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v29: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method273(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method77(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
        }
        pub fn method274(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: string,
        ) -> string {
            let v10: string = Spiral::method226(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python"),
                v10
            ))
        }
        pub fn closure125(v0_1: string, v1_1: i32, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method274(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method77(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn method275(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: string,
        ) -> string {
            let v9: string = Spiral::method268(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python"),
                v9
            ))
        }
        pub fn closure126(v0_1: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v5: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v31: Option<i64> = patternInput.5.clone();
                let v30: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v29: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v28: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v27: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v26: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method275(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method12(),
                    v0_1,
                ))
            };
        }
        pub fn closure127(v0_1: string, unitVar: ()) -> string {
            let v7: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method70(), toArray_1(v7))
        }
        pub fn method276(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: LrcPtr<Exception>,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method272(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python / Exception"),
                v12
            ))
        }
        pub fn closure129(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
            unitVar: (),
        ) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v8: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v34: Option<i64> = patternInput.5.clone();
                let v33: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v32: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v31: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v30: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v29: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method276(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method77(),
                    v3,
                    v0_1,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure128(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure129(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
        }
        pub fn method277(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: i32,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method175(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python / error"),
                v12
            ))
        }
        pub fn closure130(v0_1: string, v1_1: string, v2: i32, v3: string, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_4) {
                let v8: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v34: Option<i64> = patternInput.5.clone();
                let v33: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v32: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v31: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v30: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v29: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method277(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method77(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
        }
        pub fn method279(v0_1: std::string::String, v1_1: clap::ArgMatches) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v3.clone(), string("subcommand"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v40: std::string::String = format!("{:#?}", v0_1);
            let v79: () = {
                Spiral::closure7(v3.clone(), fable_library_rust::String_::fromString(v40), ());
                ()
            };
            let v89: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v99: () = {
                Spiral::closure7(v3.clone(), string("arg_matches"), ());
                ()
            };
            let v108: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v117: std::string::String = format!("{:#?}", v1_1);
            let v156: () = {
                Spiral::closure7(
                    v3.clone(),
                    fable_library_rust::String_::fromString(v117),
                    (),
                );
                ()
            };
            let v166: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method278(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: std::string::String,
            v9: clap::ArgMatches,
        ) -> string {
            let v10: string = Spiral::method279(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / invalid subcommand"),
                v10
            ))
        }
        pub fn closure131(v0_1: clap::ArgMatches, v1_1: std::string::String, unitVar: ()) {
            if Spiral::method7(Spiral::US0::US0_1) {
                let v6: () = {
                    Spiral::closure2((), ());
                    ()
                };
                let patternInput: (
                    LrcPtr<Spiral::Mut0>,
                    LrcPtr<Spiral::Mut1>,
                    LrcPtr<Spiral::Mut2>,
                    LrcPtr<Spiral::Mut3>,
                    LrcPtr<Spiral::Mut4>,
                    Option<i64>,
                ) = Spiral::TraceState::trace_state().get().clone().unwrap();
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method278(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method12(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn closure132(unitVar: (), v0_1: serde_json::Error) -> string {
            let v7: std::string::String = format!("{}", v0_1);
            fable_library_rust::String_::fromString(v7)
        }
        pub fn method280() -> Func1<serde_json::Error, string> {
            Func1::new(move |v: serde_json::Error| Spiral::closure132((), v))
        }
        pub fn method20(
            v0_1: Spiral::US0,
            v1_1: clap::ArgMatches,
        ) -> std::pin::Pin<Box<dyn std::future::Future<Output = Result<string, string>>>> {
            let v3: bool = true;
            let __future_init = Box::pin(
                /*;
                let v5: bool = */
                async move {
                    /*;
                    let v7: bool = */
                    ();
                    let v10: Option<(std::string::String, clap::ArgMatches)> =
                        clap::ArgMatches::subcommand(Box::leak(Box::new(v1_1))).map(|(a, b)| {
                            (
                                Func1::new(move |v: &str| Spiral::closure11((), v))(a),
                                b.clone(),
                            )
                        });
                    let v28: Spiral::US6 =
                        defaultValue(Spiral::US6::US6_1, map(Spiral::method21(), v10));
                    let v6198: Array<(string, string)> = if let Spiral::US6::US6_0(
                        v28_0_0,
                        v28_0_1,
                    ) = &v28
                    {
                        let v33: clap::ArgMatches = v28_0_1.clone();
                        let v32: std::string::String = v28_0_0.clone();
                        if (fable_library_rust::String_::fromString(v32.clone())) == string("gleam")
                        {
                            let v37: string = Spiral::method22();
                            let v44: &str = &*v37;
                            let v72: Option<std::string::String> =
                                clap::ArgMatches::get_one(&v33.clone(), v44).cloned();
                            let v89: Spiral::US7 =
                                defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v72));
                            let v96: std::string::String = match &v89 {
                                Spiral::US7::US7_0(v89_0_0) => match &v89 {
                                    Spiral::US7::US7_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => panic!("{}", string("Option does not have a value."),),
                            };
                            let v98: string = fable_library_rust::String_::fromString(v96);
                            let v99: string = Spiral::method24();
                            let v106: &str = &*v99;
                            let v134: Option<Vec<std::string::String>> =
                                clap::ArgMatches::get_many(&v33.clone(), v106)
                                    .map(|x| x.cloned().into_iter().collect());
                            let v151: Spiral::US8 =
                                defaultValue(Spiral::US8::US8_1, map(Spiral::method25(), v134));
                            let v157: Vec<std::string::String> =
                                new_empty::<std::string::String>().to_vec();
                            let v160: Vec<std::string::String> = match &v151 {
                                Spiral::US8::US8_0(v151_0_0) => match &v151 {
                                    Spiral::US8::US8_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => v157.clone(),
                            };
                            let v172: Result<Vec<u8>, std::io::Error> =
                                std::fs::read(&*v98.clone());
                            let v217: Vec<u8> = Spiral::method26(v172.unwrap());
                            let v219: Result<std::string::String, std::string::FromUtf8Error> =
                                std::string::String::from_utf8(v217);
                            let v223: std::string::String = v219.unwrap();
                            let v258: string = fable_library_rust::String_::fromString(v223);
                            let v266: string =
                                Spiral::method28(Spiral::method27(string("gleam"), v258.clone()));
                            let v268: Spiral::US5 = Spiral::method34(Spiral::method33());
                            let v274: Spiral::US5 = match &v268 {
                                Spiral::US5::US5_0(v268_0_0) => Spiral::US5::US5_0(
                                    match &v268 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => Spiral::method34(string(
                                    "c:\\home\\git\\polyglot\\target\\Builder\\spiral",
                                )),
                            };
                            let v280: Spiral::US5 = match &v274 {
                                Spiral::US5::US5_0(v274_0_0) => Spiral::US5::US5_0(
                                    match &v274 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => Spiral::method34(string("/workspaces")),
                            };
                            let v284: string = match &v280 {
                                Spiral::US5::US5_0(v280_0_0) => match &v280 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => panic!("{}", string("Option does not have a value."),),
                            };
                            let v299: string = Spiral::method35(
                                if string("deps") == (Spiral::method54(v284.clone())) {
                                    let v292: Spiral::US5 = Spiral::method34(
                                        Spiral::method40(v284.clone()).clone().unwrap(),
                                    );
                                    match &v292 {
                                        Spiral::US5::US5_0(v292_0_0) => match &v292 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => panic!("{}", string("Option does not have a value."),),
                                    }
                                } else {
                                    v284
                                },
                                string("polyglot"),
                            );
                            let v303: string = toLower(Spiral::method33());
                            let v308: string = toLower(v299);
                            let v317: Spiral::US10 = if startsWith3(v303, v308.clone(), false) {
                                Spiral::US10::US10_1(v308.clone())
                            } else {
                                Spiral::US10::US10_0(v308)
                            };
                            let v323: Result<string, string> = match &v317 {
                                Spiral::US10::US10_0(v317_0_0) => {
                                    Ok::<string, string>(v317_0_0.clone())
                                }
                                Spiral::US10::US10_1(v317_1_0) => {
                                    Err::<string, string>(v317_1_0.clone())
                                }
                            };
                            let v325: bool = true;
                            let _result_unwrap_or_else = v323.unwrap_or_else(|x| {
                                //;
                                let v327: string = x;
                                let v329: bool = true;
                                v327
                            });
                            let v331: string = _result_unwrap_or_else;
                            let v339: string = Spiral::method35(
                                defaultValue(string(""), Spiral::method40(v98.clone())),
                                string(".."),
                            );
                            let v341: string = Spiral::method35(v339.clone(), string("gleam.toml"));
                            let v344: Array<string> = new_array(&[
                                string("gleam_stdlib=\">=0.55.0 and <1.0.0\""),
                                string("gary=\">=1.1.0 and <2.0.0\""),
                            ]);
                            let v346: Vec<string> = v344.to_vec();
                            let v348: bool = true;
                            let _vec_map: Vec<_> = v346
                                .into_iter()
                                .map(|x| {
                                    //;
                                    let v350: string = x;
                                    let v357: &str = &*v350;
                                    let v390: std::string::String = String::from(v357);
                                    let v418: bool = true;
                                    v390
                                })
                                .collect::<Vec<_>>();
                            let v420: Vec<std::string::String> = _vec_map;
                            let v421: Vec<std::string::String> = Spiral::method68(v160);
                            let v422: Vec<std::string::String> = Spiral::method69(v420);
                            let v424: bool = true;
                            let mut v422 = v422;
                            let v426: bool = true;
                            v422.extend(v421);
                            let v428: Vec<std::string::String> = v422;
                            let v430: bool = true;
                            let _vec_map: Vec<_> = v428
                                .into_iter()
                                .map(|x| {
                                    //;
                                    let v432: std::string::String = x;
                                    let v434: string =
                                        fable_library_rust::String_::fromString(v432);
                                    let v451: string = if contains(v434.clone(), string("=")) {
                                        v434.clone()
                                    } else {
                                        if endsWith3(v434.clone(), string("]"), false) {
                                            concat(new_array(&[
                                                replace(
                                                    v434.clone(),
                                                    string("["),
                                                    string("={version=\'*\',features=["),
                                                ),
                                                string("}"),
                                            ]))
                                        } else {
                                            concat(new_array(&[v434, string("=\'*\'")]))
                                        }
                                    };
                                    let v453: bool = true;
                                    v451
                                })
                                .collect::<Vec<_>>();
                            let v455: Vec<string> = _vec_map;
                            let v457: Array<string> =
                                fable_library_rust::NativeArray_::array_from(v455.clone());
                            let _let__v461: LrcPtr<dyn IEnumerable_1<string>> =
                                delay(Func0::new({
                                    let v457 = v457.clone();
                                    move || {
                                        map_1(
                                            Func1::new({
                                                let v457 = v457.clone();
                                                move |i: i32| v457[i].clone()
                                            }),
                                            rangeNumeric(
                                                0_i32,
                                                1_i32,
                                                (get_Count(v457.clone())) - 1_i32,
                                            ),
                                        )
                                    }
                                }));
                            Spiral::method71(
                                v341,
                                append(
                                    string(
                                        "name = \"main\"\ntarget = \"erlang\"\n\n[dependencies]\n",
                                    ),
                                    (join(Spiral::method70(), toArray_1(_let__v461))),
                                ),
                            );
                            {
                                let patternInput: (i32, string) = Spiral::method96(
                                    string("gleam check"),
                                    None::<CancellationToken>,
                                    new_empty::<(string, string)>(),
                                    None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
                                    None::<
                                        Func1<
                                            std::sync::Arc<
                                                std::sync::Mutex<std::process::ChildStdin>,
                                            >,
                                            (),
                                        >,
                                    >,
                                    true,
                                    Some(v339.clone()),
                                );
                                let v503: i32 = patternInput.0.clone();
                                let patternInput_4: (
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                ) = if (v503) != 0_i32 {
                                    let v511: () = {
                                        Spiral::closure70(
                                            v98.clone(),
                                            patternInput.1.clone(),
                                            v503,
                                            (),
                                        );
                                        ()
                                    };
                                    (
                                        Spiral::US5::US5_0(string("gleam")),
                                        Spiral::US5::US5_1,
                                        Spiral::US5::US5_1,
                                        Spiral::US5::US5_1,
                                    )
                                } else {
                                    let v562: string = concat(new_array(&[
                                        string("gleam run --no-print-progress \""),
                                        v98.clone(),
                                        string("\""),
                                    ]));
                                    let v566: Array<(string, string)> = new_array(&[
                                        (string("TRACE_LEVEL"), string("")),
                                        (string("GLEAM_LOG"), string("")),
                                        (string("GLEAM_LOG_NOCOLOUR"), string("")),
                                    ]);
                                    let patternInput_1: (i32, string) = Spiral::method96(
                                        v562.clone(),
                                        None::<CancellationToken>,
                                        v566.clone(),
                                        None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
                                        None::<
                                            Func1<
                                                std::sync::Arc<
                                                    std::sync::Mutex<std::process::ChildStdin>,
                                                >,
                                                (),
                                            >,
                                        >,
                                        true,
                                        Some(v339),
                                    );
                                    let v578: string = patternInput_1.1.clone();
                                    let v577: i32 = patternInput_1.0.clone();
                                    let v579: i32 = get_Count(v566.clone());
                                    let v580: Array<string> = new_init(&string(""), v579);
                                    let v581: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method31(v579, v581.clone()) {
                                        let v583: i32 = v581.l0.get().clone();
                                        let patternInput_2: (string, string) = v566[v583].clone();
                                        let v586: string = sprintf!(
                                            "$env:{}=\'\'{}\'\'",
                                            patternInput_2.0.clone(),
                                            patternInput_2.1.clone()
                                        );
                                        v580.get_mut()[v583 as usize] = v586;
                                        {
                                            let v587: i32 = (v583) + 1_i32;
                                            v581.l0.set(v587);
                                            ()
                                        }
                                    }
                                    {
                                        let v599: string = sprintf!(
                                            "pwsh -c \'{}; {}\'",
                                            join(string(";"), toArray_1(ofArray_1(v580.clone()))),
                                            v562
                                        );
                                        let patternInput_3: (
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                        ) = if (v577) == 0_i32 {
                                            let result: LrcPtr<MutCell<Spiral::US5>> =
                                                refCell(Spiral::US5::US5_1);
                                            try_catch(
                                                || {
                                                    result.set(Spiral::closure71(
                                                        (),
                                                        Spiral::closure72(v578.clone(), ()),
                                                    ))
                                                },
                                                |ex: LrcPtr<Exception>| {
                                                    result.set(Spiral::closure73(
                                                        v98.clone(),
                                                        v578.clone(),
                                                        v599.clone(),
                                                        ex.clone(),
                                                    ))
                                                },
                                            );
                                            {
                                                let v606: Spiral::US5 = result.get().clone();
                                                let v617: Option<string> = match &v606 {
                                                    Spiral::US5::US5_0(v606_0_0) => Some(
                                                        match &v606 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    ),
                                                    _ => None::<string>,
                                                };
                                                (
                                                    Spiral::US5::US5_0(string("gleam")),
                                                    Spiral::US5::US5_0(v258),
                                                    Spiral::US5::US5_0(v98.clone()),
                                                    Spiral::US5::US5_0(v617.unwrap()),
                                                )
                                            }
                                        } else {
                                            let v626: () = {
                                                Spiral::closure75(v98, v578, v577, v599, ());
                                                ()
                                            };
                                            (
                                                Spiral::US5::US5_0(string("gleam")),
                                                Spiral::US5::US5_1,
                                                Spiral::US5::US5_1,
                                                Spiral::US5::US5_1,
                                            )
                                        };
                                        (
                                            patternInput_3.0.clone(),
                                            patternInput_3.1.clone(),
                                            patternInput_3.2.clone(),
                                            patternInput_3.3.clone(),
                                        )
                                    }
                                };
                                let v684: Spiral::US5 = patternInput_4.3.clone();
                                let v682: Spiral::US5 = patternInput_4.1.clone();
                                let v681: Spiral::US5 = patternInput_4.0.clone();
                                let v697: Array<(string, string)> = new_array(&[
                                    (
                                        string("extension"),
                                        match &v681 {
                                            Spiral::US5::US5_0(v681_0_0) => match &v681 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("code"),
                                        match &v682 {
                                            Spiral::US5::US5_0(v682_0_0) => match &v682 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("output"),
                                        match &v684 {
                                            Spiral::US5::US5_0(v684_0_0) => match &v684 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                ]);
                                let v699: Vec<(string, string)> = v697.to_vec();
                                let v702: bool = true;
                                let _func1_from_v700 = Func1::from(move |value| {
                                    //;
                                    let patternInput_5: (string, string) = value;
                                    let v712: &str = &*patternInput_5.0.clone();
                                    let v745: std::string::String = String::from(v712);
                                    let v778: &str = &*patternInput_5.1.clone();
                                    let v811: std::string::String = String::from(v778);
                                    let v841: bool = true;
                                    LrcPtr::new((v745, v811)) /*;
                                                              let v843: bool = */
                                }); //;
                                let v845: Func1<
                                    (string, string),
                                    LrcPtr<(std::string::String, std::string::String)>,
                                > = _func1_from_v700;
                                let v848: Vec<LrcPtr<(std::string::String, std::string::String)>> =
                                    v699.into_iter()
                                        .map(|x| {
                                            Func1::new({
                                                let v845 = v845.clone();
                                                move |arg10_0040_3: (string, string)| {
                                                    Spiral::closure76(v845.clone(), arg10_0040_3)
                                                }
                                            })(x.clone())
                                        })
                                        .collect::<Vec<_>>();
                                let v849: string =
                                string("std::collections::BTreeMap::from_iter(v848.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                                let v850: std::collections::BTreeMap<
                                    std::string::String,
                                    std::string::String,
                                > = std::collections::BTreeMap::from_iter(
                                    v848.iter()
                                        .map(|x| x.as_ref())
                                        .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                                );
                                let v852: Result<std::string::String, serde_json::Error> =
                                    serde_json::to_string(&v850);
                                let v856: std::string::String = v852.unwrap();
                                new_array(&[(
                                    string("command_result"),
                                    fable_library_rust::String_::fromString(v856),
                                )])
                            }
                        } else {
                            if (fable_library_rust::String_::fromString(v32.clone()))
                                == string("cuda")
                            {
                                let v875: string = Spiral::method177();
                                let v882: &str = &*v875;
                                let v910: Option<std::string::String> =
                                    clap::ArgMatches::get_one(&v33.clone(), v882).cloned();
                                let v927: Spiral::US7 =
                                    defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v910));
                                let v934: std::string::String = match &v927 {
                                    Spiral::US7::US7_0(v927_0_0) => match &v927 {
                                        Spiral::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => panic!("{}", string("Option does not have a value."),),
                                };
                                let v936: string = fable_library_rust::String_::fromString(v934);
                                let v937: string = Spiral::method178();
                                let v944: &str = &*v937;
                                let v972: Option<std::string::String> =
                                    clap::ArgMatches::get_one(&v33.clone(), v944).cloned();
                                let v989: Spiral::US7 =
                                    defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v972));
                                let v1018: Spiral::US33 = match &v989 {
                                    Spiral::US7::US7_0(v989_0_0) => {
                                        let v995: string = fable_library_rust::String_::fromString(
                                            match &v989 {
                                                Spiral::US7::US7_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        );
                                        let v1000: Spiral::US34 = if string("Pip") == (v995.clone())
                                        {
                                            Spiral::US34::US34_0(Spiral::US35::US35_0)
                                        } else {
                                            Spiral::US34::US34_1
                                        };
                                        Spiral::US33::US33_0(match &v1000 {
                                            Spiral::US34::US34_0(v1000_0_0) => {
                                                Spiral::US34::US34_0(
                                                    match &v1000 {
                                                        Spiral::US34::US34_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                )
                                            }
                                            _ => {
                                                let v1007: Spiral::US34 =
                                                    if string("Poetry") == (v995.clone()) {
                                                        Spiral::US34::US34_0(Spiral::US35::US35_1)
                                                    } else {
                                                        Spiral::US34::US34_1
                                                    };
                                                match &v1007 {
                                                    Spiral::US34::US34_0(v1007_0_0) => {
                                                        Spiral::US34::US34_0(
                                                            match &v1007 {
                                                                Spiral::US34::US34_0(x) => {
                                                                    x.clone()
                                                                }
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => Spiral::US34::US34_1,
                                                }
                                            }
                                        })
                                    }
                                    _ => Spiral::US33::US33_1,
                                };
                                let v1025: Spiral::US34 =
                                    if let Spiral::US33::US33_0(v1018_0_0) = &v1018 {
                                        let v1019: Spiral::US34 = v1018_0_0.clone();
                                        if let Spiral::US34::US34_0(v1019_0_0) = &v1019 {
                                            Spiral::US34::US34_0(v1019_0_0.clone())
                                        } else {
                                            Spiral::US34::US34_1
                                        }
                                    } else {
                                        Spiral::US34::US34_1
                                    };
                                let v1029: Spiral::US35 = match &v1025 {
                                    Spiral::US34::US34_0(v1025_0_0) => match &v1025 {
                                        Spiral::US34::US34_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => Spiral::US35::US35_0,
                                };
                                let v1030: string = Spiral::method24();
                                let v1037: &str = &*v1030;
                                let v1065: Option<Vec<std::string::String>> =
                                    clap::ArgMatches::get_many(&v33.clone(), v1037)
                                        .map(|x| x.cloned().into_iter().collect());
                                let v1082: Spiral::US8 = defaultValue(
                                    Spiral::US8::US8_1,
                                    map(Spiral::method25(), v1065),
                                );
                                let v1088: Vec<std::string::String> =
                                    new_empty::<std::string::String>().to_vec();
                                let v1091: Vec<std::string::String> = match &v1082 {
                                    Spiral::US8::US8_0(v1082_0_0) => match &v1082 {
                                        Spiral::US8::US8_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => v1088.clone(),
                                };
                                let v1103: Result<Vec<u8>, std::io::Error> =
                                    std::fs::read(&*v936.clone());
                                let v1148: Vec<u8> = Spiral::method26(v1103.unwrap());
                                let v1150: Result<std::string::String, std::string::FromUtf8Error> =
                                    std::string::String::from_utf8(v1148);
                                let v1154: std::string::String = v1150.unwrap();
                                let v1167: string = fable_library_rust::String_::fromString(v1154);
                                let v1196: Spiral::US5 = Spiral::method34(Spiral::method33());
                                let v1202: Spiral::US5 = match &v1196 {
                                    Spiral::US5::US5_0(v1196_0_0) => Spiral::US5::US5_0(
                                        match &v1196 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => Spiral::method34(string(
                                        "c:\\home\\git\\polyglot\\target\\Builder\\spiral",
                                    )),
                                };
                                let v1208: Spiral::US5 = match &v1202 {
                                    Spiral::US5::US5_0(v1202_0_0) => Spiral::US5::US5_0(
                                        match &v1202 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => Spiral::method34(string("/workspaces")),
                                };
                                let v1212: string = match &v1208 {
                                    Spiral::US5::US5_0(v1208_0_0) => match &v1208 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => panic!("{}", string("Option does not have a value."),),
                                };
                                let v1227: string = Spiral::method35(
                                    if string("deps") == (Spiral::method54(v1212.clone())) {
                                        let v1220: Spiral::US5 = Spiral::method34(
                                            Spiral::method40(v1212.clone()).clone().unwrap(),
                                        );
                                        match &v1220 {
                                            Spiral::US5::US5_0(v1220_0_0) => match &v1220 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => panic!(
                                                "{}",
                                                string("Option does not have a value."),
                                            ),
                                        }
                                    } else {
                                        v1212
                                    },
                                    string("polyglot"),
                                );
                                let v1231: string = toLower(Spiral::method33());
                                let v1236: string = toLower(v1227);
                                let v1245: Spiral::US10 =
                                    if startsWith3(v1231, v1236.clone(), false) {
                                        Spiral::US10::US10_1(v1236.clone())
                                    } else {
                                        Spiral::US10::US10_0(v1236)
                                    };
                                let v1251: Result<string, string> = match &v1245 {
                                    Spiral::US10::US10_0(v1245_0_0) => {
                                        Ok::<string, string>(v1245_0_0.clone())
                                    }
                                    Spiral::US10::US10_1(v1245_1_0) => {
                                        Err::<string, string>(v1245_1_0.clone())
                                    }
                                };
                                let v1253: bool = true;
                                let _result_unwrap_or_else = v1251.unwrap_or_else(|x| {
                                    //;
                                    let v1255: string = x;
                                    let v1257: bool = true;
                                    v1255
                                });
                                let v1259: string = _result_unwrap_or_else;
                                let v1263: string =
                                    defaultValue(string(""), Spiral::method40(v936.clone()));
                                let v1271: string = match &v1029 {
                                    Spiral::US35::US35_1 => {
                                        Spiral::method35(v1263.clone(), string("pyproject.toml"))
                                    }
                                    _ => {
                                        Spiral::method35(v1263.clone(), string("requirements.txt"))
                                    }
                                };
                                let v1273: bool = true;
                                let _vec_map: Vec<_> = v1091
                                    .into_iter()
                                    .map(|x| {
                                        //;
                                        let v1275: std::string::String = x;
                                        let v1277: string =
                                            fable_library_rust::String_::fromString(v1275);
                                        let v1294: string = if contains(v1277.clone(), string("="))
                                        {
                                            v1277.clone()
                                        } else {
                                            if endsWith3(v1277.clone(), string("]"), false) {
                                                concat(new_array(&[
                                                    replace(
                                                        v1277.clone(),
                                                        string("["),
                                                        string("={version=\'*\',features=["),
                                                    ),
                                                    string("}"),
                                                ]))
                                            } else {
                                                concat(new_array(&[v1277, string("=\'*\'")]))
                                            }
                                        };
                                        let v1296: bool = true;
                                        v1294
                                    })
                                    .collect::<Vec<_>>();
                                let v1298: Vec<string> = _vec_map;
                                let v1300: Array<string> =
                                    fable_library_rust::NativeArray_::array_from(v1298.clone());
                                let _let__v1304: LrcPtr<dyn IEnumerable_1<string>> =
                                    delay(Func0::new({
                                        let v1300 = v1300.clone();
                                        move || {
                                            map_1(
                                                Func1::new({
                                                    let v1300 = v1300.clone();
                                                    move |i_1: i32| v1300[i_1].clone()
                                                }),
                                                rangeNumeric(
                                                    0_i32,
                                                    1_i32,
                                                    (get_Count(v1300.clone())) - 1_i32,
                                                ),
                                            )
                                        }
                                    }));
                                let v1317: string =
                                    join(Spiral::method70(), toArray_1(_let__v1304));
                                let patternInput_6: (i32, string) = if (v1317.clone()) == string("")
                                {
                                    (0_i32, string(""))
                                } else {
                                    Spiral::method71(v1271,
                                                     match &v1029 {
                                                         Spiral::US35::US35_1
                                                         =>
                                                         append((append((append((append((append((append((append((append((append(string("[tool.poetry]\nname = \"test\"\nversion = \"0.0.1\"\ndescription = \"\"\nauthors = []\n\n[tool.poetry.dependencies]\npython=\"~3.12\"\n"),
                                                                                                                                (v1317.clone()))),
                                                                                                                        string("\n"))),
                                                                                                                string(""))),
                                                                                                        string("\n"))),
                                                                                                string("[build-system]"))),
                                                                                        string("\n"))),
                                                                                string("requires = [\"poetry-core\"]"))),
                                                                        string("\n"))),
                                                                string("build-backend = \"poetry.core.masonry.api\"")),
                                                         _ => v1317.clone(),
                                                     });
                                    Spiral::method96(
                                        match &v1029 {
                                            Spiral::US35::US35_1 => string("poetry install"),
                                            _ => string("pip install -r requirements.txt"),
                                        },
                                        None::<CancellationToken>,
                                        new_empty::<(string, string)>(),
                                        None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
                                        None::<
                                            Func1<
                                                std::sync::Arc<
                                                    std::sync::Mutex<std::process::ChildStdin>,
                                                >,
                                                (),
                                            >,
                                        >,
                                        true,
                                        Some(v1263.clone()),
                                    )
                                };
                                let v1378: i32 = patternInput_6.0.clone();
                                let patternInput_10: (
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                ) = if (v1378) != 0_i32 {
                                    let v1386: () = {
                                        Spiral::closure77(
                                            v1029.clone(),
                                            v936.clone(),
                                            patternInput_6.1.clone(),
                                            v1378,
                                            (),
                                        );
                                        ()
                                    };
                                    (
                                        Spiral::US5::US5_0(string("py")),
                                        Spiral::US5::US5_1,
                                        Spiral::US5::US5_1,
                                        Spiral::US5::US5_1,
                                    )
                                } else {
                                    let v1441: string = match &v1029 {
                                        Spiral::US35::US35_1 => concat(new_array(&[
                                            string("poetry run python \""),
                                            v936.clone(),
                                            string("\""),
                                        ])),
                                        _ => concat(new_array(&[
                                            string("python \""),
                                            v936.clone(),
                                            string("\""),
                                        ])),
                                    };
                                    let v1444: Array<(string, string)> =
                                        new_array(&[(string("TRACE_LEVEL"), string("Verbose"))]);
                                    let patternInput_7: (i32, string) = Spiral::method96(
                                        v1441.clone(),
                                        None::<CancellationToken>,
                                        v1444.clone(),
                                        None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
                                        None::<
                                            Func1<
                                                std::sync::Arc<
                                                    std::sync::Mutex<std::process::ChildStdin>,
                                                >,
                                                (),
                                            >,
                                        >,
                                        true,
                                        Some(v1263.clone()),
                                    );
                                    let v1456: string = patternInput_7.1.clone();
                                    let v1455: i32 = patternInput_7.0.clone();
                                    let v1457: i32 = get_Count(v1444.clone());
                                    let v1458: Array<string> = new_init(&string(""), v1457);
                                    let v1459: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method31(v1457, v1459.clone()) {
                                        let v1461: i32 = v1459.l0.get().clone();
                                        let patternInput_8: (string, string) = v1444[v1461].clone();
                                        let v1464: string = sprintf!(
                                            "$env:{}=\'\'{}\'\'",
                                            patternInput_8.0.clone(),
                                            patternInput_8.1.clone()
                                        );
                                        v1458.get_mut()[v1461 as usize] = v1464;
                                        {
                                            let v1465: i32 = (v1461) + 1_i32;
                                            v1459.l0.set(v1465);
                                            ()
                                        }
                                    }
                                    {
                                        let v1477: string = sprintf!(
                                            "pwsh -c \'{}; {}\'",
                                            join(string(";"), toArray_1(ofArray_1(v1458.clone()))),
                                            v1441
                                        );
                                        let patternInput_9: (
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                        ) = if if (v1455) == 0_i32 {
                                            true
                                        } else {
                                            contains(v1456.clone(),
                                                            string("cupy_backends.cuda.api.runtime.CUDARuntimeError: cudaErrorInsufficientDriver"))
                                        } {
                                            let result_1: LrcPtr<MutCell<Spiral::US5>> =
                                                refCell(Spiral::US5::US5_1);
                                            try_catch(
                                                || {
                                                    result_1.set(Spiral::closure71(
                                                        (),
                                                        Spiral::closure78(v1456.clone(), ()),
                                                    ))
                                                },
                                                |ex_1: LrcPtr<Exception>| {
                                                    result_1.set(Spiral::closure79(
                                                        v936.clone(),
                                                        v1456.clone(),
                                                        v1477.clone(),
                                                        ex_1.clone(),
                                                    ))
                                                },
                                            );
                                            {
                                                let v1490: Spiral::US5 = result_1.get().clone();
                                                let v1501: Option<string> = match &v1490 {
                                                    Spiral::US5::US5_0(v1490_0_0) => Some(
                                                        match &v1490 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    ),
                                                    _ => None::<string>,
                                                };
                                                (
                                                    Spiral::US5::US5_0(string("py")),
                                                    Spiral::US5::US5_0(v1167),
                                                    Spiral::US5::US5_0(v936.clone()),
                                                    Spiral::US5::US5_0(v1501.unwrap()),
                                                )
                                            }
                                        } else {
                                            let v1511: () = {
                                                Spiral::closure81(
                                                    v936.clone(),
                                                    v1456,
                                                    v1455,
                                                    v1477,
                                                    (),
                                                );
                                                ()
                                            };
                                            (
                                                Spiral::US5::US5_0(string("py")),
                                                Spiral::US5::US5_1,
                                                Spiral::US5::US5_1,
                                                Spiral::US5::US5_1,
                                            )
                                        };
                                        (
                                            patternInput_9.0.clone(),
                                            patternInput_9.1.clone(),
                                            patternInput_9.2.clone(),
                                            patternInput_9.3.clone(),
                                        )
                                    }
                                };
                                let v1570: Spiral::US5 = patternInput_10.3.clone();
                                let v1568: Spiral::US5 = patternInput_10.1.clone();
                                let v1567: Spiral::US5 = patternInput_10.0.clone();
                                let v1583: Array<(string, string)> = new_array(&[
                                    (
                                        string("extension"),
                                        match &v1567 {
                                            Spiral::US5::US5_0(v1567_0_0) => match &v1567 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("code"),
                                        match &v1568 {
                                            Spiral::US5::US5_0(v1568_0_0) => match &v1568 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("output"),
                                        match &v1570 {
                                            Spiral::US5::US5_0(v1570_0_0) => match &v1570 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                ]);
                                let v1585: Vec<(string, string)> = v1583.to_vec();
                                let v1588: bool = true;
                                let _func1_from_v1586 = Func1::from(move |value| {
                                    //;
                                    let patternInput_11: (string, string) = value;
                                    let v1598: &str = &*patternInput_11.0.clone();
                                    let v1631: std::string::String = String::from(v1598);
                                    let v1664: &str = &*patternInput_11.1.clone();
                                    let v1697: std::string::String = String::from(v1664);
                                    let v1727: bool = true;
                                    LrcPtr::new((v1631, v1697)) /*;
                                                                let v1729: bool = */
                                }); //;
                                let v1731: Func1<
                                    (string, string),
                                    LrcPtr<(std::string::String, std::string::String)>,
                                > = _func1_from_v1586;
                                let v1734: Vec<LrcPtr<(std::string::String, std::string::String)>> =
                                    v1585
                                        .into_iter()
                                        .map(|x| {
                                            Func1::new({
                                                let v1731 = v1731.clone();
                                                move |arg10_0040_7: (string, string)| {
                                                    Spiral::closure76(v1731.clone(), arg10_0040_7)
                                                }
                                            })(x.clone())
                                        })
                                        .collect::<Vec<_>>();
                                let v1735: string =
                                string("std::collections::BTreeMap::from_iter(v1734.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                                let v1736: std::collections::BTreeMap<
                                    std::string::String,
                                    std::string::String,
                                > = std::collections::BTreeMap::from_iter(
                                    v1734
                                        .iter()
                                        .map(|x| x.as_ref())
                                        .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                                );
                                let v1738: Result<std::string::String, serde_json::Error> =
                                    serde_json::to_string(&v1736);
                                let v1742: std::string::String = v1738.unwrap();
                                new_array(&[(
                                    string("command_result"),
                                    fable_library_rust::String_::fromString(v1742),
                                )])
                            } else {
                                if (fable_library_rust::String_::fromString(v32.clone()))
                                    == string("fable")
                                {
                                    let v1761: string = Spiral::method183();
                                    let v1768: &str = &*v1761;
                                    let v1796: Option<std::string::String> =
                                        clap::ArgMatches::get_one(&v33.clone(), v1768).cloned();
                                    let v1813: Spiral::US7 = defaultValue(
                                        Spiral::US7::US7_1,
                                        map(Spiral::method23(), v1796),
                                    );
                                    let v1820: std::string::String = match &v1813 {
                                        Spiral::US7::US7_0(v1813_0_0) => match &v1813 {
                                            Spiral::US7::US7_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => panic!("{}", string("Option does not have a value."),),
                                    };
                                    let v1822: string =
                                        fable_library_rust::String_::fromString(v1820);
                                    let v1823: string = Spiral::method184();
                                    let v1830: &str = &*v1823;
                                    let v1858: Option<std::string::String> =
                                        clap::ArgMatches::get_one(&v33.clone(), v1830).cloned();
                                    let v1875: Spiral::US7 = defaultValue(
                                        Spiral::US7::US7_1,
                                        map(Spiral::method23(), v1858),
                                    );
                                    let v1885: Spiral::US5 = match &v1875 {
                                        Spiral::US7::US7_0(v1875_0_0) => Spiral::US5::US5_0(
                                            fable_library_rust::String_::fromString(
                                                match &v1875 {
                                                    Spiral::US7::US7_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            ),
                                        ),
                                        _ => Spiral::US5::US5_1,
                                    };
                                    new_array(&[(
                                        string("command_result"),
                                        match &v1885 {
                                            Spiral::US5::US5_0(v1885_0_0) => {
                                                let v1887: clap::Command = Spiral::method0();
                                                let v1889: Spiral::US22 =
                                                    Spiral::method111(sprintf!(
                                                        "_ {} --fs-path \"{}\"",
                                                        match &v1885 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                        v1822.clone()
                                                    ));
                                                let v1898:
                                                             Array<string> =
                                                         match &v1889 {
                                                             Spiral::US22::US22_0(v1889_0_0)
                                                             =>
                                                             v1889_0_0.clone(),
                                                             Spiral::US22::US22_1(v1889_1_0)
                                                             =>
                                                             panic!("{}",
                                                                    concat(new_array(&[string("resultm.get / Result value was Error: "),
                   v1889_1_0.clone()])),),
                                                         };
                                                let v1900: Vec<string> = v1898.to_vec();
                                                let v1902: bool = true;
                                                let _vec_map: Vec<_> = v1900
                                                    .into_iter()
                                                    .map(|x| {
                                                        //;
                                                        let v1904: string = x;
                                                        let v1911: &str = &*v1904;
                                                        let v1944: std::string::String =
                                                            String::from(v1911);
                                                        let v1972: bool = true;
                                                        v1944
                                                    })
                                                    .collect::<Vec<_>>();
                                                let v1974: Vec<std::string::String> = _vec_map;
                                                let v1977: std::pin::Pin<
                                                    Box<
                                                        dyn std::future::Future<
                                                            Output = Result<string, string>,
                                                        >,
                                                    >,
                                                > = Spiral::method20(
                                                    v0_1.clone(),
                                                    clap::Command::get_matches_from(v1887, v1974),
                                                );
                                                let v1979: Result<string, string> = v1977.await;
                                                v1979.unwrap()
                                            }
                                            _ => string("{}"),
                                        },
                                    )])
                                } else {
                                    if (fable_library_rust::String_::fromString(v32.clone()))
                                        == string("dib")
                                    {
                                        let v2003: string = Spiral::method185();
                                        let v2010: &str = &*v2003;
                                        let v2038: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v33.clone(), v2010).cloned();
                                        let v2041: Option<string> = map(Spiral::method186(), v2038);
                                        let v2056: string = v2041.unwrap();
                                        let v2057: string = Spiral::method192();
                                        let v2064: &str = &*v2057;
                                        let v2094: u8 = defaultValue(
                                            1_u8,
                                            clap::ArgMatches::get_one(&v33.clone(), v2064).cloned(),
                                        );
                                        let v2097: string = Spiral::method193();
                                        let v2104: &str = &*v2097;
                                        let v2132: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v33.clone(), v2104).cloned();
                                        let v2149: Spiral::US7 = defaultValue(
                                            Spiral::US7::US7_1,
                                            map(Spiral::method23(), v2132),
                                        );
                                        let patternInput_12: (i32, string) = Spiral::method194(
                                            match &v2149 {
                                                Spiral::US7::US7_0(v2149_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        fable_library_rust::String_::fromString(
                                                            match &v2149 {
                                                                Spiral::US7::US7_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        ),
                                                    )
                                                }
                                                _ => Spiral::US5::US5_1,
                                            },
                                            v2094,
                                            v2056.clone(),
                                            1_u8,
                                        );
                                        let v2162: string = patternInput_12.1.clone();
                                        let v2161: i32 = patternInput_12.0.clone();
                                        let patternInput_15: (i32, string) = if (v2161) != 0_i32 {
                                            (v2161, v2162.clone())
                                        } else {
                                            let patternInput_13:
                                                    (i32, string) =
                                                Spiral::method96(concat(new_array(&[string("jupyter nbconvert \""),
                                                                                    v2056.clone(),
                                                                                    string(".ipynb\" --to html --HTMLExporter.theme=dark")])),
                                                                 None::<CancellationToken>,
                                                                 new_empty::<(string,
                                                                              string)>(),
                                                                 None::<Func1<(i32,
                                                                               string,
                                                                               bool),
                                                                              Arc<Async<()>>>>,
                                                                 None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                              ()>>,
                                                                 true,
                                                                 None::<string>);
                                            let v2175: string = patternInput_13.1.clone();
                                            let v2174: i32 = patternInput_13.0.clone();
                                            let v2178: () = {
                                                Spiral::closure84(v2175.clone(), v2174, ());
                                                ()
                                            };
                                            if (v2174) != 0_i32 {
                                                (
                                                    v2174,
                                                    concat(new_array(&[
                                                        string("repl_result: "),
                                                        v2162.clone(),
                                                        string("\n\njupyter_result: "),
                                                        v2175.clone(),
                                                    ])),
                                                )
                                            } else {
                                                let patternInput_14:
                                                        (i32, string) =
                                                    Spiral::method96(concat(new_array(&[string("pwsh -c \"$counter = 1; $path = \'"),
                                                                                        replace(v2056.clone(),
                                                                                                string("\'"),
                                                                                                string("\'\'")),
                                                                                        string(".html\'; (Get-Content $path -Raw) -replace \'(id=\\\"cell-id=)[a-fA-F0-9]{8}\', { $_.Groups[1].Value + $counter++ } | Set-Content $path\"")])),
                                                                     None::<CancellationToken>,
                                                                     new_empty::<(string,
                                                                                  string)>(),
                                                                     None::<Func1<(i32,
                                                                                   string,
                                                                                   bool),
                                                                                  Arc<Async<()>>>>,
                                                                     None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                  ()>>,
                                                                     true,
                                                                     None::<string>);
                                                let v2242: string = patternInput_14.1.clone();
                                                let v2241: i32 = patternInput_14.0.clone();
                                                let v2245: () = {
                                                    Spiral::closure85(v2242.clone(), v2241, ());
                                                    ()
                                                };
                                                let v2293: string = concat(new_array(&[
                                                    v2056.clone(),
                                                    string(".html"),
                                                ]));
                                                let v2305: Result<Vec<u8>, std::io::Error> =
                                                    std::fs::read(&*v2293);
                                                let v2350: Vec<u8> =
                                                    Spiral::method26(v2305.unwrap());
                                                let v2352: Result<
                                                    std::string::String,
                                                    std::string::FromUtf8Error,
                                                > = std::string::String::from_utf8(v2350);
                                                let v2356: std::string::String = v2352.unwrap();
                                                let v2399: string = replace(
                                                    fable_library_rust::String_::fromString(v2356),
                                                    string("\r\n"),
                                                    string("\n"),
                                                );
                                                let v2400: string = concat(new_array(&[
                                                    v2056.clone(),
                                                    string(".html"),
                                                ]));
                                                std::fs::write(&*v2400, &*v2399).unwrap();
                                                {
                                                    let v2403: string = concat(new_array(&[
                                                        v2056.clone(),
                                                        string(".ipynb"),
                                                    ]));
                                                    let v2415: Result<Vec<u8>, std::io::Error> =
                                                        std::fs::read(&*v2403);
                                                    let v2460: Vec<u8> =
                                                        Spiral::method26(v2415.unwrap());
                                                    let v2462: Result<
                                                        std::string::String,
                                                        std::string::FromUtf8Error,
                                                    > = std::string::String::from_utf8(v2460);
                                                    let v2466: std::string::String = v2462.unwrap();
                                                    let v2510: string = replace(
                                                        replace(
                                                            fable_library_rust::String_::fromString(
                                                                v2466,
                                                            ),
                                                            string("\r\n"),
                                                            string("\n"),
                                                        ),
                                                        string("\\r\\n"),
                                                        string("\\n"),
                                                    );
                                                    let v2511: string = concat(new_array(&[
                                                        v2056,
                                                        string(".ipynb"),
                                                    ]));
                                                    std::fs::write(&*v2511, &*v2510).unwrap();
                                                    (v2241,
                                                     sprintf!("repl_result: {}\n\njupyter_result: {}\n\npwsh_replace_html_result: {}",
                                                              v2162, v2175,
                                                              v2242))
                                                }
                                            }
                                        };
                                        let v2518: string = patternInput_15.1.clone();
                                        let v2517: i32 = patternInput_15.0.clone();
                                        let v2521: () = {
                                            Spiral::closure86(v2518.clone(), v2517, ());
                                            ()
                                        };
                                        if (v2517) != 0_i32 {
                                            panic!(
                                                "{}",
                                                sprintf!(
                                                    "spiral.run / dib / exit_code: {} / result: {}",
                                                    v2517,
                                                    v2518.clone()
                                                )
                                            );
                                        }
                                        new_array(&[(string("stdio"), v2518)])
                                    } else {
                                        let patternInput_38: (
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                        ) = if (fable_library_rust::String_::fromString(
                                            v32.clone(),
                                        )) == string("rust")
                                        {
                                            let v2579: string = Spiral::method183();
                                            let v2586: &str = &*v2579;
                                            let v2614: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v33.clone(), v2586)
                                                    .cloned();
                                            let v2631: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v2614),
                                            );
                                            let v2638: std::string::String = match &v2631 {
                                                Spiral::US7::US7_0(v2631_0_0) => match &v2631 {
                                                    Spiral::US7::US7_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => panic!(
                                                    "{}",
                                                    string("Option does not have a value."),
                                                ),
                                            };
                                            let v2640: string =
                                                fable_library_rust::String_::fromString(v2638);
                                            let v2641: string = Spiral::method24();
                                            let v2648: &str = &*v2641;
                                            let v2676: Option<Vec<std::string::String>> =
                                                clap::ArgMatches::get_many(&v33.clone(), v2648)
                                                    .map(|x| x.cloned().into_iter().collect());
                                            let v2693: Spiral::US8 = defaultValue(
                                                Spiral::US8::US8_1,
                                                map(Spiral::method25(), v2676),
                                            );
                                            let v2699: Vec<std::string::String> =
                                                new_empty::<std::string::String>().to_vec();
                                            let v2702: Vec<std::string::String> = match &v2693 {
                                                Spiral::US8::US8_0(v2693_0_0) => match &v2693 {
                                                    Spiral::US8::US8_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => v2699.clone(),
                                            };
                                            let v2703: string = Spiral::method203();
                                            let v2710: &str = &*v2703;
                                            let v2738: bool =
                                                clap::ArgMatches::get_flag(&v33.clone(), v2710);
                                            let v2739: string = Spiral::method204();
                                            let v2746: &str = &*v2739;
                                            let v2774: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v33.clone(), v2746)
                                                    .cloned();
                                            let v2791: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v2774),
                                            );
                                            let v2801: Spiral::US5 = match &v2791 {
                                                Spiral::US7::US7_0(v2791_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        fable_library_rust::String_::fromString(
                                                            match &v2791 {
                                                                Spiral::US7::US7_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        ),
                                                    )
                                                }
                                                _ => Spiral::US5::US5_1,
                                            };
                                            let v2802: string = Spiral::method205();
                                            let v2809: &str = &*v2802;
                                            let v2837: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v33.clone(), v2809)
                                                    .cloned();
                                            let v2854: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v2837),
                                            );
                                            let v2864: Spiral::US5 = match &v2854 {
                                                Spiral::US7::US7_0(v2854_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        fable_library_rust::String_::fromString(
                                                            match &v2854 {
                                                                Spiral::US7::US7_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        ),
                                                    )
                                                }
                                                _ => Spiral::US5::US5_1,
                                            };
                                            let v2873: Spiral::US36 =
                                                if let Spiral::US5::US5_0(v2801_0_0) = &v2801 {
                                                    Spiral::US36::US36_0(Spiral::US37::US37_0(
                                                        v2801_0_0.clone(),
                                                    ))
                                                } else {
                                                    if let Spiral::US5::US5_0(v2864_0_0) = &v2864 {
                                                        Spiral::US36::US36_0(Spiral::US37::US37_1(
                                                            v2864_0_0.clone(),
                                                        ))
                                                    } else {
                                                        Spiral::US36::US36_1
                                                    }
                                                };
                                            let v2885: Result<Vec<u8>, std::io::Error> =
                                                std::fs::read(&*v2640);
                                            let v2930: Vec<u8> = Spiral::method26(v2885.unwrap());
                                            let v2932: Result<
                                                std::string::String,
                                                std::string::FromUtf8Error,
                                            > = std::string::String::from_utf8(v2930);
                                            let v2936: std::string::String = v2932.unwrap();
                                            let v2971: string =
                                                fable_library_rust::String_::fromString(v2936);
                                            let v2979: string =
                                                Spiral::method28(Spiral::method206(
                                                    string("rs"),
                                                    v2971.clone(),
                                                    v2873.clone(),
                                                ));
                                            let v2981: Spiral::US5 =
                                                Spiral::method34(Spiral::method33());
                                            let v2987: Spiral::US5 =
                                                match &v2981 {
                                                    Spiral::US5::US5_0(v2981_0_0)
                                                    =>
                                                    Spiral::US5::US5_0(match &v2981
                                                                           {
                                                                           Spiral::US5::US5_0(x)
                                                                           =>
                                                                           x.clone(),
                                                                           _
                                                                           =>
                                                                           unreachable!(),
                                                                       }.clone()),
                                                    _ =>
                                                    Spiral::method34(string("c:\\home\\git\\polyglot\\target\\Builder\\spiral")),
                                                };
                                            let v2993: Spiral::US5 = match &v2987 {
                                                Spiral::US5::US5_0(v2987_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        match &v2987 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => Spiral::method34(string("/workspaces")),
                                            };
                                            let v2997: string = match &v2993 {
                                                Spiral::US5::US5_0(v2993_0_0) => match &v2993 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => panic!(
                                                    "{}",
                                                    string("Option does not have a value."),
                                                ),
                                            };
                                            let v3012: string = Spiral::method35(
                                                if string("deps")
                                                    == (Spiral::method54(v2997.clone()))
                                                {
                                                    let v3005: Spiral::US5 = Spiral::method34(
                                                        Spiral::method40(v2997.clone())
                                                            .clone()
                                                            .unwrap(),
                                                    );
                                                    match &v3005 {
                                                        Spiral::US5::US5_0(v3005_0_0) => {
                                                            match &v3005 {
                                                                Spiral::US5::US5_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone()
                                                        }
                                                        _ => panic!(
                                                            "{}",
                                                            string("Option does not have a value."),
                                                        ),
                                                    }
                                                } else {
                                                    v2997
                                                },
                                                string("polyglot"),
                                            );
                                            let v3016: string = toLower(Spiral::method33());
                                            let v3021: string = toLower(v3012);
                                            let v3030: Spiral::US10 =
                                                if startsWith3(v3016, v3021.clone(), false) {
                                                    Spiral::US10::US10_1(v3021.clone())
                                                } else {
                                                    Spiral::US10::US10_0(v3021)
                                                };
                                            let v3036: Result<string, string> = match &v3030 {
                                                Spiral::US10::US10_0(v3030_0_0) => {
                                                    Ok::<string, string>(v3030_0_0.clone())
                                                }
                                                Spiral::US10::US10_1(v3030_1_0) => {
                                                    Err::<string, string>(v3030_1_0.clone())
                                                }
                                            };
                                            let v3038: bool = true;
                                            let _result_unwrap_or_else =
                                                v3036.unwrap_or_else(|x| {
                                                    //;
                                                    let v3040: string = x;
                                                    let v3042: bool = true;
                                                    v3040
                                                });
                                            let v3044: string = _result_unwrap_or_else;
                                            let v3049: string = Spiral::method207(
                                                Spiral::US5::US5_0(v2979.clone()),
                                                string("spiral"),
                                                Spiral::US39::US39_0(Spiral::US38::US38_0),
                                                v3044.clone(),
                                            );
                                            let v3055: string = Spiral::method208(
                                                v2971,
                                                string("spiral"),
                                                LrcPtr::new(Spiral::UH2::UH2_0),
                                                LrcPtr::new(Spiral::UH4::UH4_1(
                                                    string("Fable.Core"),
                                                    string("4.3.0"),
                                                    LrcPtr::new(Spiral::UH4::UH4_0),
                                                )),
                                                v3049.clone(),
                                                v3044.clone(),
                                            );
                                            let v3057: string =
                                                Spiral::method35(v3049.clone(), string("../../.."));
                                            let v3059: string = Spiral::method35(
                                                v3057.clone(),
                                                string("Cargo.toml"),
                                            );
                                            if (Spiral::method37(v3059.clone())) == false {
                                                let v3065: DateTime = DateTime::now();
                                                let v3088: string =
                                                    toString(Spiral::method211(new_guid(), v3065));
                                                let v3113: string =
                                                    append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                           (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                               v3088.clone(),
                                                                                                                                                                               string("\"")]))))),
                                                                                                                                                   string("\n"))),
                                                                                                                                           string("version = \"0.0.1\""))),
                                                                                                                                   string("\n"))),
                                                                                                                           string("edition = \"2021\""))),
                                                                                                                   string("\n"))),
                                                                                                           string(""))),
                                                                                                   string("\n"))),
                                                                                           string("[[bin]]"))),
                                                                                   string("\n"))),
                                                                           (concat(new_array(&[string("name = \"spiral_"),
                                                                                               v3088,
                                                                                               string("\"")]))))),
                                                                   string("\n"))),
                                                           string("path = \"spiral.rs\""));
                                                std::fs::write(&*v3059.clone(), &*v3113).unwrap();
                                                ()
                                            }
                                            {
                                                let v3116: string = Spiral::method35(
                                                    v3049.clone(),
                                                    string("Cargo.toml"),
                                                );
                                                if (Spiral::method37(v3116.clone())) == false {
                                                    let v3122: DateTime = DateTime::now();
                                                    let v3145: string = toString(
                                                        Spiral::method211(new_guid(), v3122),
                                                    );
                                                    let v3170: string =
                                                        append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                               (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                   v3145.clone(),
                                                                                                                                                                                   string("\"")]))))),
                                                                                                                                                       string("\n"))),
                                                                                                                                               string("version = \"0.0.1\""))),
                                                                                                                                       string("\n"))),
                                                                                                                               string("edition = \"2021\""))),
                                                                                                                       string("\n"))),
                                                                                                               string(""))),
                                                                                                       string("\n"))),
                                                                                               string("[[bin]]"))),
                                                                                       string("\n"))),
                                                                               (concat(new_array(&[string("name = \"spiral_"),
                                                                                                   v3145,
                                                                                                   string("\"")]))))),
                                                                       string("\n"))),
                                                               string("path = \"spiral.rs\""));
                                                    std::fs::write(&*v3116.clone(), &*v3170)
                                                        .unwrap();
                                                    ()
                                                }
                                                {
                                                    let v3174: string =
                                                        Spiral::method35(v3044.clone(),
                                                                         string("lib/rust/fable/fable_modules/fable-library-rust"));
                                                    let v3176: string = Spiral::method35(
                                                        v3049.clone(),
                                                        string("fable_modules/fable-library-rust"),
                                                    );
                                                    Spiral::method216(v3174, v3176.clone());
                                                    {
                                                        let patternInput_16: (i32, string) =
                                                            Spiral::method217(
                                                                v2873.clone(),
                                                                v3049.clone(),
                                                                string("rs"),
                                                                v3055,
                                                                v3030.clone(),
                                                            );
                                                        let v3178: string =
                                                            patternInput_16.1.clone();
                                                        let v3177: i32 = patternInput_16.0.clone();
                                                        let patternInput_25: (
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                        ) = if (v3177) != 0_i32 {
                                                            let v3185: () = {
                                                                Spiral::closure89(
                                                                    v3178.clone(),
                                                                    v3177,
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            (
                                                                Spiral::US5::US5_0(string("rs")),
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_0(v3178),
                                                            )
                                                        } else {
                                                            let v3333: Vec<std::string::String> =
                                                                if if let Spiral::US36::US36_1 =
                                                                    &v2873
                                                                {
                                                                    true
                                                                } else {
                                                                    false
                                                                } {
                                                                    v2702.clone()
                                                                } else {
                                                                    let v3237 = Spiral::method227();
                                                                    let v3238: Vec<
                                                                        std::string::String,
                                                                    > = Spiral::method228(
                                                                        v2702.clone(),
                                                                    );
                                                                    let v3240: Vec<
                                                                        std::string::String,
                                                                    > = v3238
                                                                        .into_iter()
                                                                        .filter(|x| {
                                                                            v3237(x.clone().clone())
                                                                        })
                                                                        .collect::<Vec<_>>();
                                                                    if (v3240.len() as i32) > 0_i32
                                                                    {
                                                                        v2702.clone()
                                                                    } else {
                                                                        let v3261: &str =
                                                                            &*string("near-sdk");
                                                                        let v3321: Array<
                                                                            std::string::String,
                                                                        > = new_array(&[
                                                                            String::from(v3261),
                                                                        ]);
                                                                        let v3324: Vec<
                                                                            std::string::String,
                                                                        > = Spiral::method68(
                                                                            v3321.to_vec(),
                                                                        );
                                                                        let v3325: Vec<
                                                                            std::string::String,
                                                                        > = Spiral::method69(v2702);
                                                                        let v3327: bool = true;
                                                                        let mut v3325 = v3325;
                                                                        let v3329: bool = true;
                                                                        v3325.extend(v3324);
                                                                        v3325
                                                                    }
                                                                };
                                                            let v3335: bool = true;
                                                            let _vec_map : Vec<_> = v3333.into_iter().map(|x| { //;
                                                                let v3337:
                                                                        std::string::String =
                                                                    x;
                                                                let v3339:
                                                                        string =
                                                                    fable_library_rust::String_::fromString(v3337);
                                                                let v3356:
                                                                        string =
                                                                    if contains(v3339.clone(),
                                                                                string("="))
                                                                       {
                                                                        v3339.clone()
                                                                    } else {
                                                                        if endsWith3(v3339.clone(),
                                                                                     string("]"),
                                                                                     false)
                                                                           {
                                                                            concat(new_array(&[replace(v3339.clone(),
                                                                                                       string("["),
                                                                                                       string("={version=\'*\',features=[")),
                                                                                               string("}")]))
                                                                        } else {
                                                                            concat(new_array(&[v3339,
                                                                                               string("=\'*\'")]))
                                                                        }
                                                                    };
                                                                let v3358:
                                                                        bool =
                                                                    true; v3356 }).collect::<Vec<_>>();
                                                            let v3360: Vec<string> = _vec_map;
                                                            let v3362:
                                                                        Array<string> =
                                                                    fable_library_rust::NativeArray_::array_from(v3360.clone());
                                                            let _let__v3366: LrcPtr<
                                                                dyn IEnumerable_1<string>,
                                                            > = delay(Func0::new({
                                                                let v3362 = v3362.clone();
                                                                move || {
                                                                    map_1(
                                                                        Func1::new({
                                                                            let v3362 =
                                                                                v3362.clone();
                                                                            move |i_2: i32| {
                                                                                v3362[i_2].clone()
                                                                            }
                                                                        }),
                                                                        rangeNumeric(
                                                                            0_i32,
                                                                            1_i32,
                                                                            (get_Count(
                                                                                v3362.clone(),
                                                                            )) - 1_i32,
                                                                        ),
                                                                    )
                                                                }
                                                            }));
                                                            let v3379: string = join(
                                                                Spiral::method70(),
                                                                toArray_1(_let__v3366),
                                                            );
                                                            let v3384: string = Spiral::method35(
                                                                v3049,
                                                                concat(new_array(&[
                                                                    string("spiral"),
                                                                    string("."),
                                                                    string("rs"),
                                                                ])),
                                                            );
                                                            let v3396: Result<
                                                                Vec<u8>,
                                                                std::io::Error,
                                                            > = std::fs::read(&*v3384.clone());
                                                            let v3441: Vec<u8> =
                                                                Spiral::method26(v3396.unwrap());
                                                            let v3443: Result<
                                                                std::string::String,
                                                                std::string::FromUtf8Error,
                                                            > = std::string::String::from_utf8(
                                                                v3441,
                                                            );
                                                            let v3447: std::string::String =
                                                                v3443.unwrap();
                                                            let v3482:
                                                                        string =
                                                                    fable_library_rust::String_::fromString(v3447);
                                                            let v3490: string = append(
                                                                string("on_startup!"),
                                                                (Spiral::method229()),
                                                            );
                                                            let v3493: string = append(
                                                                string(" method0"),
                                                                (Spiral::method230()),
                                                            );
                                                            let v3503: bool = if contains(
                                                                v3482.clone(),
                                                                v3490.clone(),
                                                            ) {
                                                                (contains(v3482, v3493)) == false
                                                            } else {
                                                                false
                                                            };
                                                            let v3568:
                                                                        string =
                                                                    append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                                                                                                           (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                                                                                               v2979.clone(),
                                                                                                                                                                                                                                                               string("\"")]))))),
                                                                                                                                                                                                                                   string("\n"))),
                                                                                                                                                                                                                           string("version = \"0.0.1\""))),
                                                                                                                                                                                                                   string("\n"))),
                                                                                                                                                                                                           string("edition = \"2021\""))),
                                                                                                                                                                                                   string("\n"))),
                                                                                                                                                                                           string(""))),
                                                                                                                                                                                   string("\n"))),
                                                                                                                                                                           string("[dependencies]"))),
                                                                                                                                                                   string("\n"))),
                                                                                                                                                           (if !((v2873.clone())
                                                                                                                                                                     ==
                                                                                                                                                                     Spiral::US36::US36_1)
                                                                                                                                                               {
                                                                                                                                                                string("fable_library_rust = { workspace = true }")
                                                                                                                                                            } else {
                                                                                                                                                                append((append((append(string("fable_library_rust = { workspace = true, features = ["),
                                                                                                                                                                                       (if v3503
                                                                                                                                                                                           {
                                                                                                                                                                                            string("\"static_do_bindings\", \"datetime\", \"guid\", \"threaded\"")
                                                                                                                                                                                        } else {
                                                                                                                                                                                            string("\"datetime\", \"guid\", \"threaded\"")
                                                                                                                                                                                        }))),
                                                                                                                                                                               string("]"))),
                                                                                                                                                                       string("}"))
                                                                                                                                                            }))),
                                                                                                                                                   string("\n"))),
                                                                                                                                           string("inline_colorization = { workspace = true }"))),
                                                                                                                                   string("\n"))),
                                                                                                                           (v3379))),
                                                                                                                   string("\n"))),
                                                                                                           string(""))),
                                                                                                   string("\n"))),
                                                                                           (if if let Spiral::US36::US36_1
                                                                                                      =
                                                                                                      &v2873
                                                                                                  {
                                                                                                   true
                                                                                               } else {
                                                                                                   false
                                                                                               }
                                                                                               {
                                                                                                append(string("[[bin]]\n"),
                                                                                                       (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                           v2979.clone(),
                                                                                                                           string("\"")]))))
                                                                                            } else {
                                                                                                string("[lib]\ncrate-type = [\"cdylib\"]")
                                                                                            }))),
                                                                                   string("\n"))),
                                                                           string("path = \"spiral.rs\""));
                                                            let v3633:
                                                                        string =
                                                                    append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append(string("cargo-features = [\"profile-rustflags\"]\n\n[workspace]\nresolver = \"2\"\nmembers = [\"packages/Rust/*\"]\n\n[workspace.dependencies.fable_library_rust]\n"),
                                                                                                                                                                                                                                                                                                           (concat(new_array(&[string("path = \""),
                                                                                                                                                                                                                                                                                                                               Spiral::method45(v3044.clone()),
                                                                                                                                                                                                                                                                                                                               string("/lib/rust/fable/fable_modules/fable-library-rust\"")]))))),
                                                                                                                                                                                                                                                                                                   string("\n"))),
                                                                                                                                                                                                                                                                                           string("default-features = false"))),
                                                                                                                                                                                                                                                                                   string("\n"))),
                                                                                                                                                                                                                                                                           string("features = []"))),
                                                                                                                                                                                                                                                                   string("\n"))),
                                                                                                                                                                                                                                                           string(""))),
                                                                                                                                                                                                                                                   string("\n"))),
                                                                                                                                                                                                                                           string("[workspace.dependencies]"))),
                                                                                                                                                                                                                                   string("\n"))),
                                                                                                                                                                                                                           string("inline_colorization = \"~0.1\""))),
                                                                                                                                                                                                                   string("\n"))),
                                                                                                                                                                                                           string(""))),
                                                                                                                                                                                                   string("\n"))),
                                                                                                                                                                                           string("[profile.release]"))),
                                                                                                                                                                                   string("\n"))),
                                                                                                                                                                           string("codegen-units = 1"))),
                                                                                                                                                                   string("\n"))),
                                                                                                                                                           string("opt-level = \"z\""))),
                                                                                                                                                   string("\n"))),
                                                                                                                                           string("lto = true"))),
                                                                                                                                   string("\n"))),
                                                                                                                           string("debug = false"))),
                                                                                                                   string("\n"))),
                                                                                                           string("panic = \"abort\""))),
                                                                                                   string("\n"))),
                                                                                           string("overflow-checks = true"))),
                                                                                   string("\n"))),
                                                                           string("rustflags = [\"-C\", \"link-arg=-s\"]"));
                                                            Spiral::method71(v3116.clone(), v3568);
                                                            Spiral::method71(v3059, v3633);
                                                            {
                                                                let v3635: string =
                                                                    Spiral::method35(
                                                                        v3176,
                                                                        string("src/Range.rs"),
                                                                    );
                                                                if Spiral::method37(v3635.clone()) {
                                                                    let v3648: Result<
                                                                        Vec<u8>,
                                                                        std::io::Error,
                                                                    > = std::fs::read(
                                                                        &*v3635.clone(),
                                                                    );
                                                                    let v3693: Vec<u8> =
                                                                        Spiral::method26(
                                                                            v3648.unwrap(),
                                                                        );
                                                                    let v3695:
                                                                                Result<std::string::String,
                                                                                       std::string::FromUtf8Error> =
                                                                            std::string::String::from_utf8(v3693);
                                                                    let v3699: std::string::String =
                                                                        v3695.unwrap();
                                                                    Spiral::method71(v3635,
                                                                                         replace(replace(fable_library_rust::String_::fromString(v3699),
                                                                                                         string("use crate::String_::fromCharCode;"),
                                                                                                         string("use crate::String_::fromChar;")),
                                                                                                 string("fromCharCode(c)"),
                                                                                                 string("std::char::from_u32(c).unwrap()")))
                                                                }
                                                                {
                                                                    let patternInput_17: (
                                                                        i32,
                                                                        string,
                                                                    ) = Spiral::method231(
                                                                        v3030.clone(),
                                                                        v3116.clone(),
                                                                        1_u8,
                                                                    );
                                                                    let v3747: i32 =
                                                                        patternInput_17.0.clone();
                                                                    if (v3747) != 0_i32 {
                                                                        let v3755: () = {
                                                                            Spiral::closure93(
                                                                                patternInput_17
                                                                                    .1
                                                                                    .clone(),
                                                                                v3747,
                                                                                (),
                                                                            );
                                                                            ()
                                                                        };
                                                                        ()
                                                                    }
                                                                    {
                                                                        let v3813: Result<
                                                                            Vec<u8>,
                                                                            std::io::Error,
                                                                        > = std::fs::read(
                                                                            &*v3384.clone(),
                                                                        );
                                                                        let v3858: Vec<u8> =
                                                                            Spiral::method26(
                                                                                v3813.unwrap(),
                                                                            );
                                                                        let v3860:
                                                                                    Result<std::string::String,
                                                                                           std::string::FromUtf8Error> =
                                                                                std::string::String::from_utf8(v3858);
                                                                        let v3864:
                                                                                    std::string::String =
                                                                                v3860.unwrap();
                                                                        let v3899:
                                                                                    string =
                                                                                fable_library_rust::String_::fromString(v3864);
                                                                        let v3907:
                                                                                    string =
                                                                                append(string("pub fn main() -> Result<(), String> "),
                                                                                       (Spiral::method237()));
                                                                        let v3954:
                                                                                    string =
                                                                                append((append((if if let Spiral::US36::US36_1
                                                                                                          =
                                                                                                          &v2873
                                                                                                      {
                                                                                                       true
                                                                                                   } else {
                                                                                                       false
                                                                                                   }
                                                                                                   {
                                                                                                    string("")
                                                                                                } else {
                                                                                                    string("#[near_sdk::near_bindgen]\n#[derive(near_sdk::PanicOnDefault)]\npub struct MainState {\n}\n\n#[near_sdk::near_bindgen]\nimpl MainState {\n    pub fn state_main() {\n        Spiral::method0();\n    }\n}")
                                                                                                }),
                                                                                               string("\n"))),
                                                                                       (if if if let Spiral::US36::US36_1
                                                                                                     =
                                                                                                     &v2873
                                                                                                 {
                                                                                                  true
                                                                                              } else {
                                                                                                  false
                                                                                              }
                                                                                              {
                                                                                               contains(v3899.clone(),
                                                                                                        append((v3490.clone()),
                                                                                                               string("Spiral::method0()")))
                                                                                           } else {
                                                                                               false
                                                                                           }
                                                                                           {
                                                                                            concat(new_array(&[v3907.clone(),
                                                                                                               string(" Ok(Spiral::method0()) }")]))
                                                                                        } else {
                                                                                            concat(new_array(&[v3907.clone(),
                                                                                                               string(" Ok(()) }")]))
                                                                                        }));
                                                                        let v3956: bool = contains(
                                                                            v3899.clone(),
                                                                            v3907,
                                                                        );
                                                                        let v4058: string = if v3956
                                                                        {
                                                                            v3899.clone()
                                                                        } else {
                                                                            (if (if let Spiral::US36::US36_0(v2873_0_0)
                                                                                                =
                                                                                                &v2873
                                                                                            {
                                                                                             if let Spiral::US37::US37_1(v2873_1_0)
                                                                                                    =
                                                                                                    &v2873_0_0
                                                                                                {
                                                                                                 true
                                                                                             } else {
                                                                                                 false
                                                                                             }
                                                                                         } else {
                                                                                             false
                                                                                         })
                                                                                            ==
                                                                                            false
                                                                                        {
                                                                                         Func1::new(move
                                                                                                        |v_7:
                                                                                                             string|
                                                                                                        Spiral::closure94((),
                                                                                                                          v_7))
                                                                                     } else {
                                                                                         let v4054:
                                                                                                 string =
                                                                                             string("use fable_library_rust::DateTime_::DateTime;");
                                                                                         Func1::new({
                                                                                                        let v4054
                                                                                                            =
                                                                                                            v4054.clone();
                                                                                                        move
                                                                                                            |v_8:
                                                                                                                 string|
                                                                                                            Spiral::closure96(v4054.clone(),
                                                                                                                              v_8)
                                                                                                    })
                                                                                     })((if v3503
                                                                                            {
                                                                                             Func1::new(move
                                                                                                            |v_5:
                                                                                                                 string|
                                                                                                            Spiral::closure94((),
                                                                                                                              v_5))
                                                                                         } else {
                                                                                             let v4046:
                                                                                                     string =
                                                                                                 append(string("// "),
                                                                                                        (v3490.clone()));
                                                                                             Func1::new({
                                                                                                            let v3490
                                                                                                                =
                                                                                                                v3490.clone();
                                                                                                            let v4046
                                                                                                                =
                                                                                                                v4046.clone();
                                                                                                            move
                                                                                                                |v_6:
                                                                                                                     string|
                                                                                                                Spiral::closure95(v3490.clone(),
                                                                                                                                  v4046.clone(),
                                                                                                                                  v_6)
                                                                                                        })
                                                                                         })(replace(replace(replace(replace(replace(replace(replace(replace(replace(Spiral::method65(string("\\s\\sfable_library_rust::Native_::getZero\\(\\);"),
                                                                                                                                                                                     string(" fable_library_rust::Native_::getZero::<()>();"),
                                                                                                                                                                                     replace(replace(Spiral::method65(string("\\s\\sgetZero\\(\\);"),
                                                                                                                                                                                                                      string(" getZero::<()>();"),
                                                                                                                                                                                                                      Spiral::method65(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                                                                                                                                                       string(" defaultOf::<()>();"),
                                                                                                                                                                                                                                       replace(replace(concat(new_array(&[v3899,
                                                                                                                                                                                                                                                                          string("\n\n"),
                                                                                                                                                                                                                                                                          v3954,
                                                                                                                                                                                                                                                                          string("\n")])),
                                                                                                                                                                                                                                                       append(string("),)"),
                                                                                                                                                                                                                                                              (";".into())),
                                                                                                                                                                                                                                                       string("));")),
                                                                                                                                                                                                                                               append(string("},)"),
                                                                                                                                                                                                                                                      (";".into())),
                                                                                                                                                                                                                                               string("});")))),
                                                                                                                                                                                                     append(string("(&e.get_Curren"),
                                                                                                                                                                                                            ("t".into())),
                                                                                                                                                                                                     string("(e.get_Current")),
                                                                                                                                                                                             append(string("getNull"),
                                                                                                                                                                                                    ("::<()>()".into())),
                                                                                                                                                                                             string("fable_library_rust::Native_::getZero()"))),
                                                                                                                                                                    string("::Slice\'_"),
                                                                                                                                                                    string("::Slice__")),
                                                                                                                                                            string(" Slice\'_"),
                                                                                                                                                            string(" Slice__")),
                                                                                                                                                    append(string("defaultOf()"),
                                                                                                                                                           (",".into())),
                                                                                                                                                    string("defaultOf::<std::sync::Arc<dyn IDisposable>>(),")),
                                                                                                                                            append(string("__self"),
                                                                                                                                                   ("__.".into())),
                                                                                                                                            string("self.")),
                                                                                                                                    append(string("_self"),
                                                                                                                                           ("_.".into())),
                                                                                                                                    string("self.")),
                                                                                                                            append(string("get_or_insert_wit"),
                                                                                                                                   ("h".into())),
                                                                                                                            string("get_or_init")),
                                                                                                                    append(string("use fable_library_rust::System::Collections::Concurrent::ConcurrentStack_1"),
                                                                                                                           (";".into())),
                                                                                                                    string("type ConcurrentStack_1<T> = T;")),
                                                                                                            append(string("use fable_library_rust::System::TimeZoneInfo"),
                                                                                                                   (";".into())),
                                                                                                            string("type TimeZoneInfo = i64;")),
                                                                                                    append(string("use fable_library_rust::System::Threading::Tasks::TaskCanceledException"),
                                                                                                           (";".into())),
                                                                                                    string("type TaskCanceledException = ();"))))
                                                                        };
                                                                        if (v3956) == false {
                                                                            Spiral::method71(
                                                                                v3384.clone(),
                                                                                v4058.clone(),
                                                                            );
                                                                        }
                                                                        {
                                                                            let v4064:
                                                                                        string =
                                                                                    if (if let Spiral::US36::US36_1
                                                                                               =
                                                                                               &v2873
                                                                                           {
                                                                                            true
                                                                                        } else {
                                                                                            false
                                                                                        })
                                                                                           !=
                                                                                           true
                                                                                       {
                                                                                        concat(new_array(&[string("cargo +nightly-2024-07-14 build --release --target wasm32-unknown-unknown --manifest-path \""),
                                                                                                           v3116.clone(),
                                                                                                           string("\"")]))
                                                                                    } else {
                                                                                        concat(new_array(&[string("cargo run --manifest-path \""),
                                                                                                           v3116,
                                                                                                           string("\"")]))
                                                                                    };
                                                                            let v4077:
                                                                                        Array<(string,
                                                                                               string)> =
                                                                                    if (if let Spiral::US36::US36_1
                                                                                               =
                                                                                               &v2873
                                                                                           {
                                                                                            true
                                                                                        } else {
                                                                                            false
                                                                                        })
                                                                                           !=
                                                                                           true
                                                                                       {
                                                                                        new_empty::<(string,
                                                                                                     string)>()
                                                                                    } else {
                                                                                        new_array(&[(string("TRACE_LEVEL"),
                                                                                                     string("Verbose")),
                                                                                                    (string("RUSTC_WRAPPER"),
                                                                                                     string("sccache")),
                                                                                                    (string("RUST_BACKTRACE"),
                                                                                                     string("full")),
                                                                                                    (string("RUSTFLAGS"),
                                                                                                     string("-C prefer-dynamic"))])
                                                                                    };
                                                                            let v4088:
                                                                                        Result<string,
                                                                                               string> =
                                                                                    match &v3030
                                                                                        {
                                                                                        Spiral::US10::US10_0(v3030_0_0)
                                                                                        =>
                                                                                        Ok::<string,
                                                                                             string>(v3030_0_0.clone()),
                                                                                        Spiral::US10::US10_1(v3030_1_0)
                                                                                        =>
                                                                                        Err::<string,
                                                                                              string>(v3030_1_0.clone()),
                                                                                    };
                                                                            let patternInput_18:
                                                                                        (i32,
                                                                                         string) =
                                                                                    Spiral::method96(v4064.clone(),
                                                                                                     None::<CancellationToken>,
                                                                                                     v4077.clone(),
                                                                                                     None::<Func1<(i32,
                                                                                                                   string,
                                                                                                                   bool),
                                                                                                                  Arc<Async<()>>>>,
                                                                                                     None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                                  ()>>,
                                                                                                     true,
                                                                                                     v4088.ok());
                                                                            let v4106: string =
                                                                                patternInput_18
                                                                                    .1
                                                                                    .clone();
                                                                            let v4105: i32 =
                                                                                patternInput_18
                                                                                    .0
                                                                                    .clone();
                                                                            let patternInput_24:
                                                                                        (Spiral::US5,
                                                                                         Spiral::US5,
                                                                                         Spiral::US5,
                                                                                         Spiral::US5) =
                                                                                    if if let Spiral::US36::US36_1
                                                                                              =
                                                                                              &v2873
                                                                                          {
                                                                                           true
                                                                                       } else {
                                                                                           false
                                                                                       }
                                                                                       {
                                                                                        let v4108:
                                                                                                i32 =
                                                                                            get_Count(v4077.clone());
                                                                                        let v4109:
                                                                                                Array<string> =
                                                                                            new_init(&string(""),
                                                                                                     v4108);
                                                                                        let v4110:
                                                                                                LrcPtr<Spiral::Mut5> =
                                                                                            LrcPtr::new(Spiral::Mut5{l0:
                                                                                                                         MutCell::new(0_i32),});
                                                                                        while Spiral::method31(v4108,
                                                                                                               v4110.clone())
                                                                                              {
                                                                                            let v4112:
                                                                                                    i32 =
                                                                                                v4110.l0.get().clone();
                                                                                            let patternInput_19:
                                                                                                    (string,
                                                                                                     string) =
                                                                                                v4077[v4112].clone();
                                                                                            let v4115:
                                                                                                    string =
                                                                                                sprintf!("$env:{}=\'\'{}\'\'",
                                                                                                         patternInput_19.0.clone(),
                                                                                                         patternInput_19.1.clone());
                                                                                            v4109.get_mut()[v4112
                                                                                                                as
                                                                                                                usize]
                                                                                                =
                                                                                                v4115;
                                                                                            {
                                                                                                let v4116:
                                                                                                        i32 =
                                                                                                    (v4112)
                                                                                                        +
                                                                                                        1_i32;
                                                                                                v4110.l0.set(v4116);
                                                                                                ()
                                                                                            }
                                                                                        }
                                                                                        {
                                                                                            let v4139:
                                                                                                    string =
                                                                                                concat(new_array(&[string("pwsh -c \'"),
                                                                                                                   join(string(";"),
                                                                                                                        toArray_1(ofArray_1(new_array(&[join(string(";"),
                                                                                                                                                             toArray_1(ofArray_1(v4109.clone()))),
                                                                                                                                                        v4064])))),
                                                                                                                   string("\'")]));
                                                                                            let patternInput_20:
                                                                                                    (Spiral::US5,
                                                                                                     Spiral::US5,
                                                                                                     Spiral::US5,
                                                                                                     Spiral::US5) =
                                                                                                if (v4105)
                                                                                                       !=
                                                                                                       0_i32
                                                                                                   {
                                                                                                    let v4146:
                                                                                                            () =
                                                                                                        {
                                                                                                            Spiral::closure97(v2738,
                                                                                                                              v3384.clone(),
                                                                                                                              v4106.clone(),
                                                                                                                              v4105,
                                                                                                                              v4139.clone(),
                                                                                                                              ());
                                                                                                            ()
                                                                                                        };
                                                                                                    (Spiral::US5::US5_0(string("rs")),
                                                                                                     Spiral::US5::US5_1,
                                                                                                     Spiral::US5::US5_1,
                                                                                                     Spiral::US5::US5_1)
                                                                                                } else {
                                                                                                    let result_2:
                                                                                                            LrcPtr<MutCell<Spiral::US5>> =
                                                                                                        refCell(Spiral::US5::US5_1);
                                                                                                    try_catch(||
                                                                                                                  result_2.set(Spiral::closure71((),
                                                                                                                                                 Spiral::closure98(v4106.clone(),
                                                                                                                                                                   ()))),
                                                                                                              |ex_2:
                                                                                                                   LrcPtr<Exception>|
                                                                                                                  result_2.set(Spiral::closure100(v3384.clone(),
                                                                                                                                                  v4106.clone(),
                                                                                                                                                  v4139,
                                                                                                                                                  ex_2.clone())));
                                                                                                    {
                                                                                                        let v4202:
                                                                                                                Spiral::US5 =
                                                                                                            result_2.get().clone();
                                                                                                        let v4213:
                                                                                                                Option<string> =
                                                                                                            match &v4202
                                                                                                                {
                                                                                                                Spiral::US5::US5_0(v4202_0_0)
                                                                                                                =>
                                                                                                                Some(match &v4202
                                                                                                                         {
                                                                                                                         Spiral::US5::US5_0(x)
                                                                                                                         =>
                                                                                                                         x.clone(),
                                                                                                                         _
                                                                                                                         =>
                                                                                                                         unreachable!(),
                                                                                                                     }.clone()),
                                                                                                                _
                                                                                                                =>
                                                                                                                None::<string>,
                                                                                                            };
                                                                                                        (Spiral::US5::US5_0(string("rs")),
                                                                                                         Spiral::US5::US5_0(v4058.clone()),
                                                                                                         Spiral::US5::US5_0(v3384.clone()),
                                                                                                         Spiral::US5::US5_0(v4213.unwrap()))
                                                                                                    }
                                                                                                };
                                                                                            (patternInput_20.0.clone(),
                                                                                             patternInput_20.1.clone(),
                                                                                             patternInput_20.2.clone(),
                                                                                             patternInput_20.3.clone())
                                                                                        }
                                                                                    } else {
                                                                                        let v4224:
                                                                                                string =
                                                                                            sprintf!("target/spiral/{}/target/wasm32-unknown-unknown/release/spiral_{}.wasm",
                                                                                                     string("spiral"),
                                                                                                     v2979.clone());
                                                                                        let v4236:
                                                                                                string =
                                                                                            sprintf!("pwsh -c \"pwsh {} {} -Linux -EnvironmentVariables AUTOMATION={}`nNEAR_RPC_TIMEOUT_SECS=100\"",
                                                                                                     string("scripts/invoke-block.ps1"),
                                                                                                     sprintf!("\'deps/spiral/workspace/target/release/spiral_wasm -w {} -t Debug {}\'",
                                                                                                              v4224.clone(),
                                                                                                              if let Spiral::US36::US36_0(v2873_0_0)
                                                                                                                     =
                                                                                                                     &v2873
                                                                                                                 {
                                                                                                                  let v4225:
                                                                                                                          Spiral::US37 =
                                                                                                                      v2873_0_0.clone();
                                                                                                                  match &v4225
                                                                                                                      {
                                                                                                                      Spiral::US37::US37_0(v4225_0_0)
                                                                                                                      =>
                                                                                                                      v4225_0_0.clone(),
                                                                                                                      Spiral::US37::US37_1(v4225_1_0)
                                                                                                                      =>
                                                                                                                      v4225_1_0.clone(),
                                                                                                                  }
                                                                                                              } else {
                                                                                                                  string("")
                                                                                                              }),
                                                                                                     Spiral::method3(string("AUTOMATION")));
                                                                                        let patternInput_23:
                                                                                                (Spiral::US5,
                                                                                                 Spiral::US5,
                                                                                                 Spiral::US5,
                                                                                                 Spiral::US5) =
                                                                                            if (v4105)
                                                                                                   ==
                                                                                                   0_i32
                                                                                               {
                                                                                                let patternInput_21:
                                                                                                        (i32,
                                                                                                         string) =
                                                                                                    Spiral::method96(v4236.clone(),
                                                                                                                     None::<CancellationToken>,
                                                                                                                     new_empty::<(string,
                                                                                                                                  string)>(),
                                                                                                                     None::<Func1<(i32,
                                                                                                                                   string,
                                                                                                                                   bool),
                                                                                                                                  Arc<Async<()>>>>,
                                                                                                                     None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                                                  ()>>,
                                                                                                                     true,
                                                                                                                     Some(v3044));
                                                                                                let v4249:
                                                                                                        string =
                                                                                                    patternInput_21.1.clone();
                                                                                                let v4248:
                                                                                                        i32 =
                                                                                                    patternInput_21.0.clone();
                                                                                                let patternInput_22:
                                                                                                        (Spiral::US5,
                                                                                                         Spiral::US5,
                                                                                                         Spiral::US5,
                                                                                                         Spiral::US5) =
                                                                                                    if (v4248)
                                                                                                           ==
                                                                                                           0_i32
                                                                                                       {
                                                                                                        (Spiral::US5::US5_0(string("rs")),
                                                                                                         Spiral::US5::US5_0(v4058),
                                                                                                         Spiral::US5::US5_0(v3384.clone()),
                                                                                                         Spiral::US5::US5_0(v4249.clone()))
                                                                                                    } else {
                                                                                                        let v4257:
                                                                                                                () =
                                                                                                            {
                                                                                                                Spiral::closure102(v2738,
                                                                                                                                   v3384.clone(),
                                                                                                                                   v4106.clone(),
                                                                                                                                   v4249,
                                                                                                                                   v4248,
                                                                                                                                   ());
                                                                                                                ()
                                                                                                            };
                                                                                                        (Spiral::US5::US5_0(string("rs")),
                                                                                                         Spiral::US5::US5_1,
                                                                                                         Spiral::US5::US5_1,
                                                                                                         Spiral::US5::US5_1)
                                                                                                    };
                                                                                                (patternInput_22.0.clone(),
                                                                                                 patternInput_22.1.clone(),
                                                                                                 patternInput_22.2.clone(),
                                                                                                 patternInput_22.3.clone())
                                                                                            } else {
                                                                                                let v4315:
                                                                                                        () =
                                                                                                    {
                                                                                                        Spiral::closure103(v2738,
                                                                                                                           v3384.clone(),
                                                                                                                           v4106,
                                                                                                                           v4105,
                                                                                                                           v4224,
                                                                                                                           v4236,
                                                                                                                           ());
                                                                                                        ()
                                                                                                    };
                                                                                                (Spiral::US5::US5_0(string("rs")),
                                                                                                 Spiral::US5::US5_1,
                                                                                                 Spiral::US5::US5_1,
                                                                                                 Spiral::US5::US5_1)
                                                                                            };
                                                                                        (patternInput_23.0.clone(),
                                                                                         patternInput_23.1.clone(),
                                                                                         patternInput_23.2.clone(),
                                                                                         patternInput_23.3.clone())
                                                                                    };
                                                                            if v2738 {
                                                                                let v4379:
                                                                                            string =
                                                                                        if (if let Spiral::US36::US36_1
                                                                                                   =
                                                                                                   &v2873
                                                                                               {
                                                                                                true
                                                                                            } else {
                                                                                                false
                                                                                            })
                                                                                               !=
                                                                                               true
                                                                                           {
                                                                                            string("wasm32-unknown-unknown/release")
                                                                                        } else {
                                                                                            string("debug")
                                                                                        };
                                                                                let v4382:
                                                                                            string =
                                                                                        Spiral::method35(v3057.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4379.clone(),
                                                                                                                  v2979.clone(),
                                                                                                                  string("")));
                                                                                let v4385:
                                                                                            string =
                                                                                        Spiral::method35(v3057.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4379.clone(),
                                                                                                                  v2979.clone(),
                                                                                                                  string(".wasm")));
                                                                                let v4388:
                                                                                            string =
                                                                                        Spiral::method35(v3057.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4379.clone(),
                                                                                                                  v2979.clone(),
                                                                                                                  string(".pdb")));
                                                                                let v4391:
                                                                                            string =
                                                                                        Spiral::method35(v3057.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4379.clone(),
                                                                                                                  v2979.clone(),
                                                                                                                  string(".exe")));
                                                                                let v4394:
                                                                                            string =
                                                                                        Spiral::method35(v3057,
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4379,
                                                                                                                  v2979,
                                                                                                                  string(".d")));
                                                                                let v4395:
                                                                                            bool =
                                                                                        Spiral::method37(v4382.clone());
                                                                                let v4396:
                                                                                            bool =
                                                                                        Spiral::method37(v4385.clone());
                                                                                let v4397:
                                                                                            bool =
                                                                                        Spiral::method37(v4388.clone());
                                                                                let v4398:
                                                                                            bool =
                                                                                        Spiral::method37(v4391.clone());
                                                                                let v4399:
                                                                                            bool =
                                                                                        Spiral::method37(v4394.clone());
                                                                                let v4402: () = {
                                                                                    Spiral::closure104(v3384,
                                                                                                               v4394.clone(),
                                                                                                               v4399,
                                                                                                               v4391.clone(),
                                                                                                               v4398,
                                                                                                               v4388.clone(),
                                                                                                               v4397,
                                                                                                               v4385.clone(),
                                                                                                               v4396,
                                                                                                               v4382.clone(),
                                                                                                               v4395,
                                                                                                               ());
                                                                                    ()
                                                                                };
                                                                                let v4452: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4395 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4382,
                                                                                                                           v4395,
                                                                                                                           LrcPtr::new(Spiral::UH5::UH5_0)))
                                                                                } else {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_0)
                                                                                };
                                                                                let v4454: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4396 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4385,
                                                                                                                           v4396,
                                                                                                                           v4452.clone()))
                                                                                } else {
                                                                                    v4452
                                                                                };
                                                                                let v4456: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4397 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4388,
                                                                                                                           v4397,
                                                                                                                           v4454.clone()))
                                                                                } else {
                                                                                    v4454
                                                                                };
                                                                                let v4458: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4398 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4391,
                                                                                                                           v4398,
                                                                                                                           v4456.clone()))
                                                                                } else {
                                                                                    v4456
                                                                                };
                                                                                Spiral::method248(
                                                                                    if v4399 {
                                                                                        LrcPtr::new(Spiral::UH5::UH5_1(v4394,
                                                                                                                                         v4399,
                                                                                                                                         v4458.clone()))
                                                                                    } else {
                                                                                        v4458
                                                                                    },
                                                                                )
                                                                            }
                                                                            (
                                                                                patternInput_24
                                                                                    .0
                                                                                    .clone(),
                                                                                patternInput_24
                                                                                    .1
                                                                                    .clone(),
                                                                                patternInput_24
                                                                                    .2
                                                                                    .clone(),
                                                                                patternInput_24
                                                                                    .3
                                                                                    .clone(),
                                                                            )
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        };
                                                        (
                                                            patternInput_25.0.clone(),
                                                            patternInput_25.1.clone(),
                                                            patternInput_25.2.clone(),
                                                            patternInput_25.3.clone(),
                                                        )
                                                    }
                                                }
                                            }
                                        } else {
                                            let patternInput_37: (
                                                Spiral::US5,
                                                Spiral::US5,
                                                Spiral::US5,
                                                Spiral::US5,
                                            ) = if (fable_library_rust::String_::fromString(
                                                v32.clone(),
                                            )) == string("typescript")
                                            {
                                                let v4468: string = Spiral::method183();
                                                let v4475: &str = &*v4468;
                                                let v4503: Option<std::string::String> =
                                                    clap::ArgMatches::get_one(&v33.clone(), v4475)
                                                        .cloned();
                                                let v4520: Spiral::US7 = defaultValue(
                                                    Spiral::US7::US7_1,
                                                    map(Spiral::method23(), v4503),
                                                );
                                                let v4527: std::string::String = match &v4520 {
                                                    Spiral::US7::US7_0(v4520_0_0) => match &v4520 {
                                                        Spiral::US7::US7_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => panic!(
                                                        "{}",
                                                        string("Option does not have a value."),
                                                    ),
                                                };
                                                let v4529: string =
                                                    fable_library_rust::String_::fromString(v4527);
                                                let v4530: string = Spiral::method24();
                                                let v4537: &str = &*v4530;
                                                let v4565: Option<Vec<std::string::String>> =
                                                    clap::ArgMatches::get_many(&v33.clone(), v4537)
                                                        .map(|x| x.cloned().into_iter().collect());
                                                let v4582: Spiral::US8 = defaultValue(
                                                    Spiral::US8::US8_1,
                                                    map(Spiral::method25(), v4565),
                                                );
                                                let v4588: Vec<std::string::String> =
                                                    new_empty::<std::string::String>().to_vec();
                                                let v4591: Vec<std::string::String> = match &v4582 {
                                                    Spiral::US8::US8_0(v4582_0_0) => match &v4582 {
                                                        Spiral::US8::US8_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => v4588.clone(),
                                                };
                                                let v4603: Result<Vec<u8>, std::io::Error> =
                                                    std::fs::read(&*v4529);
                                                let v4648: Vec<u8> =
                                                    Spiral::method26(v4603.unwrap());
                                                let v4650: Result<
                                                    std::string::String,
                                                    std::string::FromUtf8Error,
                                                > = std::string::String::from_utf8(v4648);
                                                let v4654: std::string::String = v4650.unwrap();
                                                let v4689: string =
                                                    fable_library_rust::String_::fromString(v4654);
                                                let v4700: string = Spiral::method28(sprintf!(
                                                    "{:?}",
                                                    (string("ts"), v4689.clone())
                                                ));
                                                let v4702: Spiral::US5 =
                                                    Spiral::method34(Spiral::method33());
                                                let v4708: Spiral::US5 =
                                                        match &v4702 {
                                                            Spiral::US5::US5_0(v4702_0_0)
                                                            =>
                                                            Spiral::US5::US5_0(match &v4702
                                                                                   {
                                                                                   Spiral::US5::US5_0(x)
                                                                                   =>
                                                                                   x.clone(),
                                                                                   _
                                                                                   =>
                                                                                   unreachable!(),
                                                                               }.clone()),
                                                            _ =>
                                                            Spiral::method34(string("c:\\home\\git\\polyglot\\target\\Builder\\spiral")),
                                                        };
                                                let v4714: Spiral::US5 = match &v4708 {
                                                    Spiral::US5::US5_0(v4708_0_0) => {
                                                        Spiral::US5::US5_0(
                                                            match &v4708 {
                                                                Spiral::US5::US5_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => Spiral::method34(string("/workspaces")),
                                                };
                                                let v4718: string = match &v4714 {
                                                    Spiral::US5::US5_0(v4714_0_0) => match &v4714 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => panic!(
                                                        "{}",
                                                        string("Option does not have a value."),
                                                    ),
                                                };
                                                let v4733: string = Spiral::method35(
                                                    if string("deps")
                                                        == (Spiral::method54(v4718.clone()))
                                                    {
                                                        let v4726: Spiral::US5 = Spiral::method34(
                                                            Spiral::method40(v4718.clone())
                                                                .clone()
                                                                .unwrap(),
                                                        );
                                                        match &v4726 {
                                                            Spiral::US5::US5_0(v4726_0_0) => {
                                                                match &v4726 {
                                                                    Spiral::US5::US5_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone()
                                                            }
                                                            _ => panic!(
                                                                "{}",
                                                                string(
                                                                    "Option does not have a value."
                                                                ),
                                                            ),
                                                        }
                                                    } else {
                                                        v4718
                                                    },
                                                    string("polyglot"),
                                                );
                                                let v4737: string = toLower(Spiral::method33());
                                                let v4742: string = toLower(v4733);
                                                let v4751: Spiral::US10 =
                                                    if startsWith3(v4737, v4742.clone(), false) {
                                                        Spiral::US10::US10_1(v4742.clone())
                                                    } else {
                                                        Spiral::US10::US10_0(v4742)
                                                    };
                                                let v4757: Result<string, string> = match &v4751 {
                                                    Spiral::US10::US10_0(v4751_0_0) => {
                                                        Ok::<string, string>(v4751_0_0.clone())
                                                    }
                                                    Spiral::US10::US10_1(v4751_1_0) => {
                                                        Err::<string, string>(v4751_1_0.clone())
                                                    }
                                                };
                                                let v4759: bool = true;
                                                let _result_unwrap_or_else =
                                                    v4757.unwrap_or_else(|x| {
                                                        //;
                                                        let v4761: string = x;
                                                        let v4763: bool = true;
                                                        v4761
                                                    });
                                                let v4765: string = _result_unwrap_or_else;
                                                let v4770: string = Spiral::method207(
                                                    Spiral::US5::US5_0(v4700.clone()),
                                                    string("spiral"),
                                                    Spiral::US39::US39_0(Spiral::US38::US38_1),
                                                    v4765.clone(),
                                                );
                                                let v4776: string = Spiral::method208(
                                                    v4689,
                                                    string("spiral"),
                                                    LrcPtr::new(Spiral::UH2::UH2_0),
                                                    LrcPtr::new(Spiral::UH4::UH4_1(
                                                        string("Fable.Core"),
                                                        string("4.3.0"),
                                                        LrcPtr::new(Spiral::UH4::UH4_0),
                                                    )),
                                                    v4770.clone(),
                                                    v4765.clone(),
                                                );
                                                let v4778: string = Spiral::method35(
                                                    v4765.clone(),
                                                    string("lib/typescript/fable/fable_modules"),
                                                );
                                                let v4779: string = concat(new_array(&[
                                                    string("fable-library-"),
                                                    string("ts"),
                                                ]));
                                                let v4780: string =
                                                    Spiral::method253(v4779.clone());
                                                let v4782: async_walkdir::WalkDir =
                                                    async_walkdir::WalkDir::new(&*v4778.clone());
                                                let v4785: async_walkdir::WalkDir =
                                                    async_walkdir::WalkDir::filter(
                                                        v4782,
                                                        move |x| {
                                                            Func1::new({
                                                                let v4779 = v4779.clone();
                                                                move
                                                                                                                          |v_11:
                                                                                                                               async_walkdir::DirEntry|
                                                                                                                          Spiral::closure108(v4779.clone(),
                                                                                                                                             v_11)
                                                            })(
                                                                x
                                                            )
                                                        },
                                                    );
                                                let v4786 = Spiral::method257(v4780);
                                                let v4788 = futures::stream::StreamExt::filter_map(
                                                    v4785,
                                                    |x| async { v4786(x) },
                                                );
                                                let v4790: std::pin::Pin<
                                                    Box<
                                                        dyn std::future::Future<
                                                            Output = Vec<(string, string)>,
                                                        >,
                                                    >,
                                                > = Box::pin(futures::stream::StreamExt::collect(
                                                    v4788,
                                                ));
                                                let v4792: Vec<(string, string)> = v4790.await;
                                                let v4794: rayon::vec::IntoIter<(string, string)> =
                                                    rayon::iter::IntoParallelIterator::into_par_iter(
                                                        v4792,
                                                    );
                                                let v4797: rayon::iter::Map<
                                                    rayon::vec::IntoIter<(string, string)>,
                                                    _,
                                                > = rayon::iter::ParallelIterator::map(
                                                    v4794,
                                                    |x| {
                                                        Func1::new(move
                                                                                                                     |arg10_0040_18:
                                                                                                                          (string,
                                                                                                                           string)|
                                                                                                                     Spiral::closure116((),
                                                                                                                                        arg10_0040_18))(x)
                                                    },
                                                );
                                                let v4799: Vec<(string, string)> =
                                                    rayon::iter::ParallelIterator::collect(v4797);
                                                let v4802: Option<(string, string)> = tryItem(
                                                    0_i32,
                                                    fable_library_rust::NativeArray_::array_from(
                                                        v4799.clone(),
                                                    ),
                                                );
                                                let v4820: Spiral::US48 = defaultValue(
                                                    Spiral::US48::US48_1,
                                                    map(Spiral::method262(), v4802),
                                                );
                                                let v4826: () = {
                                                    Spiral::closure118(v4820.clone(), ());
                                                    ()
                                                };
                                                Spiral::method265(
                                                    v4770.clone(),
                                                    v4778.clone(),
                                                    v4820.clone(),
                                                );
                                                {
                                                    let patternInput_26: (i32, string) =
                                                        Spiral::method217(
                                                            Spiral::US36::US36_1,
                                                            v4770.clone(),
                                                            string("ts"),
                                                            v4776,
                                                            v4751.clone(),
                                                        );
                                                    let v4875: string = patternInput_26.1.clone();
                                                    let v4874: i32 = patternInput_26.0.clone();
                                                    Spiral::method265(
                                                        v4770.clone(),
                                                        v4778,
                                                        v4820.clone(),
                                                    );
                                                    {
                                                        let patternInput_30: (
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                        ) = if (v4874) != 0_i32 {
                                                            let v4882: () = {
                                                                Spiral::closure119(
                                                                    v4875.clone(),
                                                                    v4874,
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            (
                                                                Spiral::US5::US5_0(string("ts")),
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_0(v4875),
                                                            )
                                                        } else {
                                                            let v4934: bool = true;
                                                            let _vec_map : Vec<_> = v4591.into_iter().map(|x| { //;
                                                                    let v4936:
                                                                            std::string::String =
                                                                        x;
                                                                    let v4938:
                                                                            string =
                                                                        fable_library_rust::String_::fromString(v4936);
                                                                    let v4945:
                                                                            string =
                                                                        if contains(v4938.clone(),
                                                                                    string("="))
                                                                           {
                                                                            v4938.clone()
                                                                        } else {
                                                                            concat(new_array(&[string("\""),
                                                                                               v4938,
                                                                                               string("\":\"*\"")]))
                                                                        };
                                                                    let v4947:
                                                                            bool =
                                                                        true; v4945 }).collect::<Vec<_>>();
                                                            let v4949: Vec<string> = _vec_map;
                                                            let v4951:
                                                                            Array<string> =
                                                                        fable_library_rust::NativeArray_::array_from(v4949.clone());
                                                            let v4968: string = join(
                                                                string(",\n"),
                                                                toArray_1(delay(Func0::new({
                                                                    let v4951 = v4951.clone();
                                                                    move || {
                                                                        map_1(
                                                                            Func1::new({
                                                                                let v4951 =
                                                                                    v4951.clone();
                                                                                move |i_3: i32| {
                                                                                    v4951[i_3]
                                                                                        .clone()
                                                                                }
                                                                            }),
                                                                            rangeNumeric(
                                                                                0_i32,
                                                                                1_i32,
                                                                                (get_Count(
                                                                                    v4951.clone(),
                                                                                )) - 1_i32,
                                                                            ),
                                                                        )
                                                                    }
                                                                }))),
                                                            );
                                                            let v4984:
                                                                            string =
                                                                        append((append((append((append((append((append((append(string("{"),
                                                                                                                               (concat(new_array(&[string("  \"name\": \"spiral_"),
                                                                                                                                                   v4700,
                                                                                                                                                   string("\",")]))))),
                                                                                                                       string("  \"dependencies\": {"))),
                                                                                                               (v4968))),
                                                                                                       string("  },"))),
                                                                                               string("    \"devDependencies\": {"))),
                                                                                       string("  },"))),
                                                                               string("}"));
                                                            let v4986: string = Spiral::method35(
                                                                v4770.clone(),
                                                                string("package.json"),
                                                            );
                                                            let v4989: string = Spiral::method35(
                                                                Spiral::method35(
                                                                    v4770.clone(),
                                                                    string("../.."),
                                                                ),
                                                                string("package.json"),
                                                            );
                                                            Spiral::method71(v4986, v4984);
                                                            Spiral::method71(v4989, string(""));
                                                            {
                                                                let v4992: string =
                                                                    Spiral::method35(
                                                                        v4770,
                                                                        concat(new_array(&[
                                                                            string("spiral"),
                                                                            string("."),
                                                                            string("ts"),
                                                                        ])),
                                                                    );
                                                                let v4995: () = {
                                                                    Spiral::closure120(
                                                                        v4992.clone(),
                                                                        (),
                                                                    );
                                                                    ()
                                                                };
                                                                let v5053: Result<
                                                                    Vec<u8>,
                                                                    std::io::Error,
                                                                > = std::fs::read(&*v4992.clone());
                                                                let v5098: Vec<u8> =
                                                                    Spiral::method26(
                                                                        v5053.unwrap(),
                                                                    );
                                                                let v5100: Result<
                                                                    std::string::String,
                                                                    std::string::FromUtf8Error,
                                                                > = std::string::String::from_utf8(
                                                                    v5098,
                                                                );
                                                                let v5104: std::string::String =
                                                                    v5100.unwrap();
                                                                let v5139:
                                                                                string =
                                                                            fable_library_rust::String_::fromString(v5104);
                                                                let v5147:
                                                                                bool =
                                                                            contains(v5139.clone(),
                                                                                     string("// spiral.process_typescript"));
                                                                let v5156: string = if v5147 {
                                                                    v5139.clone()
                                                                } else {
                                                                    Spiral::method65(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                 string(" defaultOf::<()>();"),
                                                                                                 replace(v5139,
                                                                                                         sprintf!("\"./fable_modules/fable-library-ts.{}/",
                                                                                                                  v4820.clone()),
                                                                                                         sprintf!("\"{}/lib/typescript/fable/fable_modules/fable-library-ts.{}/",
                                                                                                                  v4765,
                                                                                                                  v4820)))
                                                                };
                                                                if (v5147) == false {
                                                                    Spiral::method71(v4992.clone(),
                                                                                             concat(new_array(&[v5156.clone(),
                                                                                                                string("\n\n"),
                                                                                                                string("// spiral.process_typescript"),
                                                                                                                string("\n")])));
                                                                }
                                                                {
                                                                    let v5159: string =
                                                                        concat(new_array(&[
                                                                            string("bun run \""),
                                                                            v4992.clone(),
                                                                            string("\""),
                                                                        ]));
                                                                    let v5161: string =
                                                                        Spiral::method3(string(
                                                                            "PATH",
                                                                        ));
                                                                    let v5201: Spiral::US5 =
                                                                        if (v5161.clone())
                                                                            == string("")
                                                                        {
                                                                            Spiral::US5::US5_1
                                                                        } else {
                                                                            Spiral::US5::US5_0(concat(new_array(&[string("~/.bun/bin"),
                                                                                                                          if cfg!(windows)
                                                                                                                             {
                                                                                                                              string(";")
                                                                                                                          } else {
                                                                                                                              string(":")
                                                                                                                          },
                                                                                                                          v5161])))
                                                                        };
                                                                    let v5217:
                                                                                    Array<(string,
                                                                                           string)> =
                                                                                toArray(Spiral::method270(Spiral::method269(match &v5201
                                                                                                                                {
                                                                                                                                Spiral::US5::US5_0(v5201_0_0)
                                                                                                                                =>
                                                                                                                                LrcPtr::new(Spiral::UH4::UH4_1(string("PATH"),
                                                                                                                                                               match &v5201
                                                                                                                                                                   {
                                                                                                                                                                   Spiral::US5::US5_0(x)
                                                                                                                                                                   =>
                                                                                                                                                                   x.clone(),
                                                                                                                                                                   _
                                                                                                                                                                   =>
                                                                                                                                                                   unreachable!(),
                                                                                                                                                               }.clone(),
                                                                                                                                                               LrcPtr::new(Spiral::UH4::UH4_0))),
                                                                                                                                _
                                                                                                                                =>
                                                                                                                                LrcPtr::new(Spiral::UH4::UH4_0),
                                                                                                                            },
                                                                                                                            LrcPtr::new(Spiral::UH4::UH4_1(string("TRACE_LEVEL"),
                                                                                                                                                           string("Verbose"),
                                                                                                                                                           LrcPtr::new(Spiral::UH4::UH4_0)))),
                                                                                                          empty::<(string,
                                                                                                                   string)>()));
                                                                    let v5230: Result<
                                                                        string,
                                                                        string,
                                                                    > = match &v4751 {
                                                                        Spiral::US10::US10_0(
                                                                            v4751_0_0,
                                                                        ) => Ok::<string, string>(
                                                                            v4751_0_0.clone(),
                                                                        ),
                                                                        Spiral::US10::US10_1(
                                                                            v4751_1_0,
                                                                        ) => Err::<string, string>(
                                                                            v4751_1_0.clone(),
                                                                        ),
                                                                    };
                                                                    let patternInput_27:
                                                                                    (i32,
                                                                                     string) =
                                                                                Spiral::method96(v5159.clone(),
                                                                                                 None::<CancellationToken>,
                                                                                                 v5217.clone(),
                                                                                                 None::<Func1<(i32,
                                                                                                               string,
                                                                                                               bool),
                                                                                                              Arc<Async<()>>>>,
                                                                                                 None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                              ()>>,
                                                                                                 true,
                                                                                                 v5230.ok());
                                                                    let v5248: string =
                                                                        patternInput_27.1.clone();
                                                                    let v5247: i32 =
                                                                        patternInput_27.0.clone();
                                                                    let v5249: i32 =
                                                                        get_Count(v5217.clone());
                                                                    let v5250: Array<string> =
                                                                        new_init(
                                                                            &string(""),
                                                                            v5249,
                                                                        );
                                                                    let v5251: LrcPtr<
                                                                        Spiral::Mut5,
                                                                    > = LrcPtr::new(Spiral::Mut5 {
                                                                        l0: MutCell::new(0_i32),
                                                                    });
                                                                    while Spiral::method31(
                                                                        v5249,
                                                                        v5251.clone(),
                                                                    ) {
                                                                        let v5253: i32 =
                                                                            v5251.l0.get().clone();
                                                                        let patternInput_28: (
                                                                            string,
                                                                            string,
                                                                        ) = v5217[v5253].clone();
                                                                        let v5256: string = sprintf!(
                                                                            "$env:{}=\'\'{}\'\'",
                                                                            patternInput_28
                                                                                .0
                                                                                .clone(),
                                                                            patternInput_28
                                                                                .1
                                                                                .clone()
                                                                        );
                                                                        v5250.get_mut()
                                                                            [v5253 as usize] =
                                                                            v5256;
                                                                        {
                                                                            let v5257: i32 =
                                                                                (v5253) + 1_i32;
                                                                            v5251.l0.set(v5257);
                                                                            ()
                                                                        }
                                                                    }
                                                                    {
                                                                        let v5269: string = sprintf!(
                                                                            "pwsh -c \'{}; {}\'",
                                                                            join(
                                                                                string(";"),
                                                                                toArray_1(
                                                                                    ofArray_1(
                                                                                        v5250
                                                                                            .clone(
                                                                                            )
                                                                                    )
                                                                                )
                                                                            ),
                                                                            v5159
                                                                        );
                                                                        let patternInput_29: (
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                        ) = if (v5247) == 0_i32 {
                                                                            let result_3: LrcPtr<
                                                                                MutCell<
                                                                                    Spiral::US5,
                                                                                >,
                                                                            > = refCell(
                                                                                Spiral::US5::US5_1,
                                                                            );
                                                                            try_catch(||
                                                                                                      result_3.set(Spiral::closure71((),
                                                                                                                                     Spiral::closure121(v5248.clone(),
                                                                                                                                                        ()))),
                                                                                                  |ex_3:
                                                                                                       LrcPtr<Exception>|
                                                                                                      result_3.set(Spiral::closure122(v4992.clone(),
                                                                                                                                      v5248.clone(),
                                                                                                                                      v5269.clone(),
                                                                                                                                      ex_3.clone())));
                                                                            {
                                                                                let v5276:
                                                                                                    Spiral::US5 =
                                                                                                result_3.get().clone();
                                                                                let v5287:
                                                                                                    Option<string> =
                                                                                                match &v5276
                                                                                                    {
                                                                                                    Spiral::US5::US5_0(v5276_0_0)
                                                                                                    =>
                                                                                                    Some(match &v5276
                                                                                                             {
                                                                                                             Spiral::US5::US5_0(x)
                                                                                                             =>
                                                                                                             x.clone(),
                                                                                                             _
                                                                                                             =>
                                                                                                             unreachable!(),
                                                                                                         }.clone()),
                                                                                                    _
                                                                                                    =>
                                                                                                    None::<string>,
                                                                                                };
                                                                                (Spiral::US5::US5_0(string("ts")),
                                                                                             Spiral::US5::US5_0(v5156),
                                                                                             Spiral::US5::US5_0(v4992.clone()),
                                                                                             Spiral::US5::US5_0(v5287.unwrap()))
                                                                            }
                                                                        } else {
                                                                            let v5296: () = {
                                                                                Spiral::closure124(
                                                                                    v4992,
                                                                                    v5248,
                                                                                    v5247,
                                                                                    v5269,
                                                                                    (),
                                                                                );
                                                                                ()
                                                                            };
                                                                            (
                                                                                Spiral::US5::US5_0(
                                                                                    string("ts"),
                                                                                ),
                                                                                Spiral::US5::US5_1,
                                                                                Spiral::US5::US5_1,
                                                                                Spiral::US5::US5_1,
                                                                            )
                                                                        };
                                                                        (
                                                                            patternInput_29
                                                                                .0
                                                                                .clone(),
                                                                            patternInput_29
                                                                                .1
                                                                                .clone(),
                                                                            patternInput_29
                                                                                .2
                                                                                .clone(),
                                                                            patternInput_29
                                                                                .3
                                                                                .clone(),
                                                                        )
                                                                    }
                                                                }
                                                            }
                                                        };
                                                        (
                                                            patternInput_30.0.clone(),
                                                            patternInput_30.1.clone(),
                                                            patternInput_30.2.clone(),
                                                            patternInput_30.3.clone(),
                                                        )
                                                    }
                                                }
                                            } else {
                                                let patternInput_36: (
                                                    Spiral::US5,
                                                    Spiral::US5,
                                                    Spiral::US5,
                                                    Spiral::US5,
                                                ) = if (fable_library_rust::String_::fromString(
                                                    v32.clone(),
                                                )) == string("python")
                                                {
                                                    let v5358: string = Spiral::method183();
                                                    let v5365: &str = &*v5358;
                                                    let v5393: Option<std::string::String> =
                                                        clap::ArgMatches::get_one(
                                                            &v33.clone(),
                                                            v5365,
                                                        )
                                                        .cloned();
                                                    let v5410: Spiral::US7 = defaultValue(
                                                        Spiral::US7::US7_1,
                                                        map(Spiral::method23(), v5393),
                                                    );
                                                    let v5417: std::string::String = match &v5410 {
                                                        Spiral::US7::US7_0(v5410_0_0) => {
                                                            match &v5410 {
                                                                Spiral::US7::US7_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone()
                                                        }
                                                        _ => panic!(
                                                            "{}",
                                                            string("Option does not have a value."),
                                                        ),
                                                    };
                                                    let v5419: string =
                                                        fable_library_rust::String_::fromString(
                                                            v5417,
                                                        );
                                                    let v5420: string = Spiral::method24();
                                                    let v5427: &str = &*v5420;
                                                    let v5455: Option<Vec<std::string::String>> =
                                                        clap::ArgMatches::get_many(
                                                            &v33.clone(),
                                                            v5427,
                                                        )
                                                        .map(|x| x.cloned().into_iter().collect());
                                                    let v5472: Spiral::US8 = defaultValue(
                                                        Spiral::US8::US8_1,
                                                        map(Spiral::method25(), v5455),
                                                    );
                                                    let v5478: Vec<std::string::String> =
                                                        new_empty::<std::string::String>().to_vec();
                                                    let v5481: Vec<std::string::String> =
                                                        match &v5472 {
                                                            Spiral::US8::US8_0(v5472_0_0) => {
                                                                match &v5472 {
                                                                    Spiral::US8::US8_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone()
                                                            }
                                                            _ => v5478.clone(),
                                                        };
                                                    let v5482: bool =
                                                        if let Spiral::US0::US0_0 = &v0_1 {
                                                            true
                                                        } else {
                                                            false
                                                        };
                                                    let v5494: Result<Vec<u8>, std::io::Error> =
                                                        std::fs::read(&*v5419);
                                                    let v5539: Vec<u8> =
                                                        Spiral::method26(v5494.unwrap());
                                                    let v5541: Result<
                                                        std::string::String,
                                                        std::string::FromUtf8Error,
                                                    > = std::string::String::from_utf8(v5539);
                                                    let v5545: std::string::String = v5541.unwrap();
                                                    let v5580: string =
                                                        fable_library_rust::String_::fromString(
                                                            v5545,
                                                        );
                                                    let v5591: string = Spiral::method28(sprintf!(
                                                        "{:?}",
                                                        (string("py"), v5580.clone())
                                                    ));
                                                    let v5593: Spiral::US5 =
                                                        Spiral::method34(Spiral::method33());
                                                    let v5599:
                                                                    Spiral::US5 =
                                                                match &v5593 {
                                                                    Spiral::US5::US5_0(v5593_0_0)
                                                                    =>
                                                                    Spiral::US5::US5_0(match &v5593
                                                                                           {
                                                                                           Spiral::US5::US5_0(x)
                                                                                           =>
                                                                                           x.clone(),
                                                                                           _
                                                                                           =>
                                                                                           unreachable!(),
                                                                                       }.clone()),
                                                                    _ =>
                                                                    Spiral::method34(string("c:\\home\\git\\polyglot\\target\\Builder\\spiral")),
                                                                };
                                                    let v5605: Spiral::US5 = match &v5599 {
                                                        Spiral::US5::US5_0(v5599_0_0) => {
                                                            Spiral::US5::US5_0(
                                                                match &v5599 {
                                                                    Spiral::US5::US5_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            Spiral::method34(string("/workspaces"))
                                                        }
                                                    };
                                                    let v5609: string = match &v5605 {
                                                        Spiral::US5::US5_0(v5605_0_0) => {
                                                            match &v5605 {
                                                                Spiral::US5::US5_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone()
                                                        }
                                                        _ => panic!(
                                                            "{}",
                                                            string("Option does not have a value."),
                                                        ),
                                                    };
                                                    let v5624: string = Spiral::method35(
                                                        if string("deps")
                                                            == (Spiral::method54(v5609.clone()))
                                                        {
                                                            let v5617: Spiral::US5 =
                                                                Spiral::method34(
                                                                    Spiral::method40(v5609.clone())
                                                                        .clone()
                                                                        .unwrap(),
                                                                );
                                                            match &v5617
                                                                                         {
                                                                                         Spiral::US5::US5_0(v5617_0_0)
                                                                                         =>
                                                                                         match &v5617
                                                                                             {
                                                                                             Spiral::US5::US5_0(x)
                                                                                             =>
                                                                                             x.clone(),
                                                                                             _
                                                                                             =>
                                                                                             unreachable!(),
                                                                                         }.clone(),
                                                                                         _
                                                                                         =>
                                                                                         panic!("{}",
                                                                                                string("Option does not have a value."),),
                                                                                     }
                                                        } else {
                                                            v5609
                                                        },
                                                        string("polyglot"),
                                                    );
                                                    let v5628: string = toLower(Spiral::method33());
                                                    let v5633: string = toLower(v5624);
                                                    let v5642: Spiral::US10 =
                                                        if startsWith3(v5628, v5633.clone(), false)
                                                        {
                                                            Spiral::US10::US10_1(v5633.clone())
                                                        } else {
                                                            Spiral::US10::US10_0(v5633)
                                                        };
                                                    let v5648: Result<string, string> = match &v5642
                                                    {
                                                        Spiral::US10::US10_0(v5642_0_0) => {
                                                            Ok::<string, string>(v5642_0_0.clone())
                                                        }
                                                        Spiral::US10::US10_1(v5642_1_0) => {
                                                            Err::<string, string>(v5642_1_0.clone())
                                                        }
                                                    };
                                                    let v5650: bool = true;
                                                    let _result_unwrap_or_else = v5648
                                                        .unwrap_or_else(|x| {
                                                            //;
                                                            let v5652: string = x;
                                                            let v5654: bool = true;
                                                            v5652
                                                        });
                                                    let v5656: string = _result_unwrap_or_else;
                                                    let v5661: string = Spiral::method207(
                                                        Spiral::US5::US5_0(v5591.clone()),
                                                        string("spiral"),
                                                        Spiral::US39::US39_0(Spiral::US38::US38_2),
                                                        v5656.clone(),
                                                    );
                                                    let v5667: string = Spiral::method208(
                                                        v5580,
                                                        string("spiral"),
                                                        LrcPtr::new(Spiral::UH2::UH2_0),
                                                        LrcPtr::new(Spiral::UH4::UH4_1(
                                                            string("Fable.Core"),
                                                            string("4.3.0"),
                                                            LrcPtr::new(Spiral::UH4::UH4_0),
                                                        )),
                                                        v5661.clone(),
                                                        v5656.clone(),
                                                    );
                                                    Spiral::method216(Spiral::method35(Spiral::method35(v5656,
                                                                                                                string("lib/python/fable/fable_modules")),
                                                                                               string("fable_library")),
                                                                              Spiral::method35(v5661.clone(),
                                                                                               string("fable_modules/fable_library")));
                                                    {
                                                        let patternInput_31: (i32, string) =
                                                            Spiral::method217(
                                                                Spiral::US36::US36_1,
                                                                v5661.clone(),
                                                                string("py"),
                                                                v5667,
                                                                v5642.clone(),
                                                            );
                                                        let v5676: string =
                                                            patternInput_31.1.clone();
                                                        let v5675: i32 = patternInput_31.0.clone();
                                                        let patternInput_35: (
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                        ) = if (v5675) != 0_i32 {
                                                            let v5683: () = {
                                                                Spiral::closure125(
                                                                    v5676.clone(),
                                                                    v5675,
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            (
                                                                Spiral::US5::US5_0(string("py")),
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_0(v5676),
                                                            )
                                                        } else {
                                                            let v5735: bool = true;
                                                            let _vec_map : Vec<_> = v5481.into_iter().map(|x| { //;
                                                                        let v5737:
                                                                                std::string::String =
                                                                            x;
                                                                        let v5739:
                                                                                string =
                                                                            fable_library_rust::String_::fromString(v5737);
                                                                        let v5746:
                                                                                string =
                                                                            if contains(v5739.clone(),
                                                                                        string("="))
                                                                               {
                                                                                v5739.clone()
                                                                            } else {
                                                                                concat(new_array(&[string("\""),
                                                                                                   v5739,
                                                                                                   string("\":\"*\"")]))
                                                                            };
                                                                        let v5748:
                                                                                bool =
                                                                            true; v5746 }).collect::<Vec<_>>();
                                                            let v5750: Vec<string> = _vec_map;
                                                            let v5752:
                                                                                Array<string> =
                                                                            fable_library_rust::NativeArray_::array_from(v5750.clone());
                                                            let v5769: string = join(
                                                                string(",\n"),
                                                                toArray_1(delay(Func0::new({
                                                                    let v5752 = v5752.clone();
                                                                    move || {
                                                                        map_1(
                                                                            Func1::new({
                                                                                let v5752 =
                                                                                    v5752.clone();
                                                                                move |i_4: i32| {
                                                                                    v5752[i_4]
                                                                                        .clone()
                                                                                }
                                                                            }),
                                                                            rangeNumeric(
                                                                                0_i32,
                                                                                1_i32,
                                                                                (get_Count(
                                                                                    v5752.clone(),
                                                                                )) - 1_i32,
                                                                            ),
                                                                        )
                                                                    }
                                                                }))),
                                                            );
                                                            let v5785:
                                                                                string =
                                                                            append((append((append((append((append((append((append(string("{"),
                                                                                                                                   (concat(new_array(&[string("  \"name\": \"spiral_"),
                                                                                                                                                       v5591,
                                                                                                                                                       string("\",")]))))),
                                                                                                                           string("  \"dependencies\": {"))),
                                                                                                                   (v5769))),
                                                                                                           string("  },"))),
                                                                                                   string("    \"devDependencies\": {"))),
                                                                                           string("  },"))),
                                                                                   string("}"));
                                                            let v5787: string = Spiral::method35(
                                                                v5661.clone(),
                                                                string("package.json"),
                                                            );
                                                            let v5790: string = Spiral::method35(
                                                                Spiral::method35(
                                                                    v5661.clone(),
                                                                    string("../.."),
                                                                ),
                                                                string("package.json"),
                                                            );
                                                            Spiral::method71(v5787, v5785);
                                                            Spiral::method71(v5790, string(""));
                                                            {
                                                                let v5793: string =
                                                                    Spiral::method35(
                                                                        v5661,
                                                                        concat(new_array(&[
                                                                            string("spiral"),
                                                                            string("."),
                                                                            string("py"),
                                                                        ])),
                                                                    );
                                                                let v5796: () = {
                                                                    Spiral::closure126(
                                                                        v5793.clone(),
                                                                        (),
                                                                    );
                                                                    ()
                                                                };
                                                                let v5854: Result<
                                                                    Vec<u8>,
                                                                    std::io::Error,
                                                                > = std::fs::read(&*v5793.clone());
                                                                let v5899: Vec<u8> =
                                                                    Spiral::method26(
                                                                        v5854.unwrap(),
                                                                    );
                                                                let v5901: Result<
                                                                    std::string::String,
                                                                    std::string::FromUtf8Error,
                                                                > = std::string::String::from_utf8(
                                                                    v5899,
                                                                );
                                                                let v5905: std::string::String =
                                                                    v5901.unwrap();
                                                                let v5940:
                                                                                    string =
                                                                                fable_library_rust::String_::fromString(v5905);
                                                                let v5948: bool = contains(
                                                                    v5940.clone(),
                                                                    string(
                                                                        "# spiral.process_python",
                                                                    ),
                                                                );
                                                                let v5960: string = if v5948 {
                                                                    v5940.clone()
                                                                } else {
                                                                    Spiral::method65(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                     string(" defaultOf::<()>();"),
                                                                                                     replace(v5940,
                                                                                                             append(string("),)"),
                                                                                                                    (";".into())),
                                                                                                             string("));")))
                                                                };
                                                                if (v5948) == false {
                                                                    Spiral::method71(v5793.clone(),
                                                                                                 concat(new_array(&[v5960.clone(),
                                                                                                                    string("\n\n"),
                                                                                                                    string("# spiral.process_python"),
                                                                                                                    string("\n")])));
                                                                }
                                                                {
                                                                    let v5963: string =
                                                                        concat(new_array(&[
                                                                            string("python \""),
                                                                            v5793.clone(),
                                                                            string("\""),
                                                                        ]));
                                                                    let v5966: Array<(
                                                                        string,
                                                                        string,
                                                                    )> = new_array(&[(
                                                                        string("TRACE_LEVEL"),
                                                                        string("Verbose"),
                                                                    )]);
                                                                    let v5977: Result<
                                                                        string,
                                                                        string,
                                                                    > = match &v5642 {
                                                                        Spiral::US10::US10_0(
                                                                            v5642_0_0,
                                                                        ) => Ok::<string, string>(
                                                                            v5642_0_0.clone(),
                                                                        ),
                                                                        Spiral::US10::US10_1(
                                                                            v5642_1_0,
                                                                        ) => Err::<string, string>(
                                                                            v5642_1_0.clone(),
                                                                        ),
                                                                    };
                                                                    let patternInput_32:
                                                                                        (i32,
                                                                                         string) =
                                                                                    Spiral::method96(v5963.clone(),
                                                                                                     None::<CancellationToken>,
                                                                                                     v5966.clone(),
                                                                                                     None::<Func1<(i32,
                                                                                                                   string,
                                                                                                                   bool),
                                                                                                                  Arc<Async<()>>>>,
                                                                                                     None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                                  ()>>,
                                                                                                     true,
                                                                                                     v5977.ok());
                                                                    let v5995: string =
                                                                        patternInput_32.1.clone();
                                                                    let v5994: i32 =
                                                                        patternInput_32.0.clone();
                                                                    let v5996: i32 =
                                                                        get_Count(v5966.clone());
                                                                    let v5997: Array<string> =
                                                                        new_init(
                                                                            &string(""),
                                                                            v5996,
                                                                        );
                                                                    let v5998: LrcPtr<
                                                                        Spiral::Mut5,
                                                                    > = LrcPtr::new(Spiral::Mut5 {
                                                                        l0: MutCell::new(0_i32),
                                                                    });
                                                                    while Spiral::method31(
                                                                        v5996,
                                                                        v5998.clone(),
                                                                    ) {
                                                                        let v6000: i32 =
                                                                            v5998.l0.get().clone();
                                                                        let patternInput_33: (
                                                                            string,
                                                                            string,
                                                                        ) = v5966[v6000].clone();
                                                                        let v6003: string = sprintf!(
                                                                            "$env:{}=\'\'{}\'\'",
                                                                            patternInput_33
                                                                                .0
                                                                                .clone(),
                                                                            patternInput_33
                                                                                .1
                                                                                .clone()
                                                                        );
                                                                        v5997.get_mut()
                                                                            [v6000 as usize] =
                                                                            v6003;
                                                                        {
                                                                            let v6004: i32 =
                                                                                (v6000) + 1_i32;
                                                                            v5998.l0.set(v6004);
                                                                            ()
                                                                        }
                                                                    }
                                                                    {
                                                                        let v6016: string = sprintf!(
                                                                            "pwsh -c \'{}; {}\'",
                                                                            join(
                                                                                string(";"),
                                                                                toArray_1(
                                                                                    ofArray_1(
                                                                                        v5997
                                                                                            .clone(
                                                                                            )
                                                                                    )
                                                                                )
                                                                            ),
                                                                            v5963
                                                                        );
                                                                        let patternInput_34: (
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                        ) = if (v5994) == 0_i32 {
                                                                            let result_4: LrcPtr<
                                                                                MutCell<
                                                                                    Spiral::US5,
                                                                                >,
                                                                            > = refCell(
                                                                                Spiral::US5::US5_1,
                                                                            );
                                                                            try_catch(||
                                                                                                          result_4.set(Spiral::closure71((),
                                                                                                                                         Spiral::closure127(v5995.clone(),
                                                                                                                                                            ()))),
                                                                                                      |ex_4:
                                                                                                           LrcPtr<Exception>|
                                                                                                          result_4.set(Spiral::closure128(v5793.clone(),
                                                                                                                                          v5995.clone(),
                                                                                                                                          v6016.clone(),
                                                                                                                                          ex_4.clone())));
                                                                            {
                                                                                let v6023:
                                                                                                        Spiral::US5 =
                                                                                                    result_4.get().clone();
                                                                                let v6034:
                                                                                                        Option<string> =
                                                                                                    match &v6023
                                                                                                        {
                                                                                                        Spiral::US5::US5_0(v6023_0_0)
                                                                                                        =>
                                                                                                        Some(match &v6023
                                                                                                                 {
                                                                                                                 Spiral::US5::US5_0(x)
                                                                                                                 =>
                                                                                                                 x.clone(),
                                                                                                                 _
                                                                                                                 =>
                                                                                                                 unreachable!(),
                                                                                                             }.clone()),
                                                                                                        _
                                                                                                        =>
                                                                                                        None::<string>,
                                                                                                    };
                                                                                (Spiral::US5::US5_0(string("py")),
                                                                                                 Spiral::US5::US5_0(v5960),
                                                                                                 Spiral::US5::US5_0(v5793.clone()),
                                                                                                 Spiral::US5::US5_0(v6034.unwrap()))
                                                                            }
                                                                        } else {
                                                                            let v6043: () = {
                                                                                Spiral::closure130(
                                                                                    v5793,
                                                                                    v5995,
                                                                                    v5994,
                                                                                    v6016,
                                                                                    (),
                                                                                );
                                                                                ()
                                                                            };
                                                                            (
                                                                                Spiral::US5::US5_0(
                                                                                    string("py"),
                                                                                ),
                                                                                Spiral::US5::US5_1,
                                                                                Spiral::US5::US5_1,
                                                                                Spiral::US5::US5_1,
                                                                            )
                                                                        };
                                                                        (
                                                                            patternInput_34
                                                                                .0
                                                                                .clone(),
                                                                            patternInput_34
                                                                                .1
                                                                                .clone(),
                                                                            patternInput_34
                                                                                .2
                                                                                .clone(),
                                                                            patternInput_34
                                                                                .3
                                                                                .clone(),
                                                                        )
                                                                    }
                                                                }
                                                            }
                                                        };
                                                        (
                                                            patternInput_35.0.clone(),
                                                            patternInput_35.1.clone(),
                                                            patternInput_35.2.clone(),
                                                            patternInput_35.3.clone(),
                                                        )
                                                    }
                                                } else {
                                                    let v6104: () = {
                                                        Spiral::closure131(v33, v32, ());
                                                        ()
                                                    };
                                                    (
                                                        Spiral::US5::US5_1,
                                                        Spiral::US5::US5_1,
                                                        Spiral::US5::US5_1,
                                                        Spiral::US5::US5_1,
                                                    )
                                                };
                                                (
                                                    patternInput_36.0.clone(),
                                                    patternInput_36.1.clone(),
                                                    patternInput_36.2.clone(),
                                                    patternInput_36.3.clone(),
                                                )
                                            };
                                            (
                                                patternInput_37.0.clone(),
                                                patternInput_37.1.clone(),
                                                patternInput_37.2.clone(),
                                                patternInput_37.3.clone(),
                                            )
                                        };
                                        let v6166: Spiral::US5 = patternInput_38.3.clone();
                                        let v6165: Spiral::US5 = patternInput_38.2.clone();
                                        let v6164: Spiral::US5 = patternInput_38.1.clone();
                                        let v6163: Spiral::US5 = patternInput_38.0.clone();
                                        new_array(&[
                                            (
                                                string("extension"),
                                                match &v6163 {
                                                    Spiral::US5::US5_0(v6163_0_0) => match &v6163 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => string(""),
                                                },
                                            ),
                                            (
                                                string("code"),
                                                match &v6164 {
                                                    Spiral::US5::US5_0(v6164_0_0) => match &v6164 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => string(""),
                                                },
                                            ),
                                            (
                                                string("code_path"),
                                                match &v6165 {
                                                    Spiral::US5::US5_0(v6165_0_0) => match &v6165 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => string(""),
                                                },
                                            ),
                                            (
                                                string("output"),
                                                match &v6166 {
                                                    Spiral::US5::US5_0(v6166_0_0) => match &v6166 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => string(""),
                                                },
                                            ),
                                        ])
                                    }
                                }
                            }
                        }
                    } else {
                        new_array(&[
                            (string("extension"), string("")),
                            (string("code"), string("")),
                            (string("code_path"), string("")),
                            (string("output"), string("")),
                        ])
                    };
                    let v6200: Vec<(string, string)> = v6198.to_vec();
                    let v6203: bool = true;
                    let _func1_from_v6201 = Func1::from(move |value| {
                        //;
                        let patternInput_39: (string, string) = value;
                        let v6213: &str = &*patternInput_39.0.clone();
                        let v6246: std::string::String = String::from(v6213);
                        let v6279: &str = &*patternInput_39.1.clone();
                        let v6312: std::string::String = String::from(v6279);
                        let v6342: bool = true;
                        LrcPtr::new((v6246, v6312)) /*;
                                                    let v6344: bool = */
                    }); //;
                    let v6346: Func1<
                        (string, string),
                        LrcPtr<(std::string::String, std::string::String)>,
                    > = _func1_from_v6201;
                    let v6349: Vec<LrcPtr<(std::string::String, std::string::String)>> = v6200
                        .into_iter()
                        .map(|x| {
                            Func1::new({
                                let v6346 = v6346.clone();
                                move |arg10_0040_29: (string, string)| {
                                    Spiral::closure76(v6346.clone(), arg10_0040_29)
                                }
                            })(x.clone())
                        })
                        .collect::<Vec<_>>();
                    let v6350: string =
                string("std::collections::BTreeMap::from_iter(v6349.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                    let v6351: std::collections::BTreeMap<
                        std::string::String,
                        std::string::String,
                    > = std::collections::BTreeMap::from_iter(
                        v6349
                            .iter()
                            .map(|x| x.as_ref())
                            .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                    );
                    let v6353: Result<std::string::String, serde_json::Error> =
                        serde_json::to_string(&v6351);
                    let v6354 = Spiral::method280();
                    let v6358: Result<std::string::String, string> = v6353.map_err(|x| v6354(x));
                    let v6371: bool = true;
                    let _result_map_ = v6358.map(|x| {
                        //;
                        let v6373: std::string::String = x;
                        let v6375: string = fable_library_rust::String_::fromString(v6373);
                        let v6377: bool = true;
                        v6375
                    });
                    let v6379: Result<string, string> = _result_map_;
                    let v6382: string = string("}");
                    let v6387: bool = true;
                    let _fix_closure_v6384 = v6379;
                    let v6394: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v6384 "), (v6382))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v6395: bool = true;
                    _fix_closure_v6384
                },
            ); // rust.fix_closure';
            let v6397 = __future_init;
            v6397
        }
        pub fn closure1(unitVar: (), v0_1: Array<string>) -> i32 {
            let v3: () = {
                Spiral::closure2((), ());
                ()
            };
            let v28: LrcPtr<Spiral::Mut4> =
                (Spiral::TraceState::trace_state().get().clone().unwrap())
                    .4
                    .clone();
            let v44: () = {
                Spiral::closure5(v0_1, ());
                ()
            };
            let v90: clap::Command = Spiral::method0();
            let v92: clap::ArgMatches = clap::Command::get_matches(v90);
            let v94: std::pin::Pin<Box<dyn std::future::Future<Output = Result<string, string>>>> =
                Spiral::method20(v28.l0.get().clone(), v92);
            let v96: Result<string, string> = futures::executor::block_on(v94);
            let v100: string = v96.unwrap();
            if if let Spiral::US0::US0_2 = &v28.l0.get().clone() {
                true
            } else {
                false
            } {
                let v116: () = {
                    Spiral::closure10(v100, ());
                    ()
                };
                ()
            }
            0_i32
        }
        pub fn v0() -> Func0<()> {
            static v0: OnceInit<Func0<()>> = OnceInit::new();
            v0.get_or_init(|| Func0::new(move || Spiral::closure0((), ())))
                .clone()
        }
        pub fn tests() {
            (Spiral::v0())();
        }
        pub fn v1() -> Func1<Array<string>, i32> {
            static v1: OnceInit<Func1<Array<string>, i32>> = OnceInit::new();
            v1.get_or_init(|| Func1::new(move |v: Array<string>| Spiral::closure1((), v)))
                .clone()
        }
        pub fn main(args: Array<string>) -> i32 {
            (Spiral::v1())(args)
        }
    }
}
pub use module_1216f6c3::*;
#[path = "../../lib/spiral/async_.rs"]
mod module_763b9e6c;
pub use module_763b9e6c::*;
#[path = "../../lib/spiral/common.rs"]
mod module_18f1c018;
pub use module_18f1c018::*;
#[path = "../../lib/spiral/crypto.rs"]
mod module_c0301e36;
pub use module_c0301e36::*;
#[path = "../../lib/spiral/date_time.rs"]
mod module_e5abed0b;
pub use module_e5abed0b::*;
#[path = "../../lib/spiral/file_system.rs"]
mod module_336d1dc9;
pub use module_336d1dc9::*;
#[path = "../../lib/spiral/lib.rs"]
mod module_12dde172;
pub use module_12dde172::*;
#[path = "../../lib/spiral/networking.rs"]
mod module_7e35832b;
pub use module_7e35832b::*;
#[path = "../../lib/spiral/platform.rs"]
mod module_afd02cca;
pub use module_afd02cca::*;
#[path = "../../lib/spiral/runtime.rs"]
mod module_a3c64389;
pub use module_a3c64389::*;
#[path = "../../lib/spiral/sm.rs"]
mod module_8f227ecb;
pub use module_8f227ecb::*;
#[path = "../../lib/spiral/threading.rs"]
mod module_e08c16fb;
pub use module_e08c16fb::*;
#[path = "../../lib/spiral/trace.rs"]
mod module_702ddcb4;
pub use module_702ddcb4::*;
#[path = "../../deps/polyglot/lib/fsharp/Common.rs"]
mod module_eb7e4788;
pub use module_eb7e4788::*;
pub mod Polyglot {
    pub use crate::module_eb7e4788::Polyglot::*;
}
pub fn main() {
    let args = std::env::args().skip(1).map(fromString).collect();
    Spiral::main(array_from(args));
}
