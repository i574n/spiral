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
            let v149: Array<string> =
                toArray(ofArray(new_array(&[string("Pip"), string("Poetry")])));
            let v153: Vec<string> = v149.to_vec();
            let v155: bool = true;
            let _vec_map: Vec<_> = v153
                .into_iter()
                .map(|x| {
                    //;
                    let v157: string = x;
                    let v164: &str = &*v157;
                    let v197: std::string::String = String::from(v164);
                    let v225: Box<std::string::String> = Box::new(v197);
                    let v227: &'static mut std::string::String = Box::leak(v225);
                    let v229: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v227);
                    let v231: bool = true;
                    v229
                })
                .collect::<Vec<_>>();
            let v233: Vec<clap::builder::PossibleValue> = _vec_map;
            let v235: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v233),
            );
            let v237: clap::Arg = v133.value_parser(v235);
            let v239: clap::Command = clap::Command::arg(v122, v237);
            let v240: string = string("r#\"NAME\"#");
            let v242: string = string("r#\"VERSION\"#");
            let v244: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v246: usize = 1_i32 as usize;
            let v250: usize = 0_i32 as usize;
            let v266: clap::builder::ValueRange = if (v250) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v246..)
            } else {
                let v264: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v246..v250)
            };
            let v267: string = string("r#\"deps\"#");
            let v268: &'static str = r#"deps"#;
            let v270: clap::Arg = clap::Arg::new(v268);
            let v272: clap::Arg = v270.short('d');
            let v273: string = string("r#\"deps\"#");
            let v274: &'static str = r#"deps"#;
            let v276: clap::Arg = v272.long(v274);
            let v278: Vec<&'static str> = v244.to_vec();
            let v280: clap::Arg = v276.value_names(v278);
            let v282: clap::Arg = v280.num_args(v266);
            let v284: clap::ArgAction = clap::ArgAction::Append;
            let v286: clap::Arg = v282.action(v284);
            let v288: clap::Command = clap::Command::arg(v239, v286);
            let v290: clap::Command = clap::Command::subcommand(v102, v288);
            let v292: string = string("r#\"fable\"#");
            let v293: &'static str = r#"fable"#;
            let v295: clap::Command = clap::Command::new(v293);
            let v297: string = string("r#\"fs-path\"#");
            let v298: &'static str = r#"fs-path"#;
            let v300: clap::Arg = clap::Arg::new(v298);
            let v302: clap::Arg = v300.short('f');
            let v303: string = string("r#\"fs-path\"#");
            let v304: &'static str = r#"fs-path"#;
            let v306: clap::Arg = v302.long(v304);
            let v308: clap::Arg = v306.required(true);
            let v310: clap::Command = clap::Command::arg(v295, v308);
            let v311: string = string("r#\"command\"#");
            let v312: &'static str = r#"command"#;
            let v314: clap::Arg = clap::Arg::new(v312);
            let v316: clap::Arg = v314.short('c');
            let v317: string = string("r#\"command\"#");
            let v318: &'static str = r#"command"#;
            let v320: clap::Arg = v316.long(v318);
            let v322: clap::Command = clap::Command::arg(v310, v320);
            let v324: clap::Command = clap::Command::subcommand(v290, v322);
            let v326: string = string("r#\"rust\"#");
            let v327: &'static str = r#"rust"#;
            let v329: clap::Command = clap::Command::new(v327);
            let v330: string = string("r#\"fs-path\"#");
            let v331: &'static str = r#"fs-path"#;
            let v333: clap::Arg = clap::Arg::new(v331);
            let v335: clap::Arg = v333.short('f');
            let v336: string = string("r#\"fs-path\"#");
            let v337: &'static str = r#"fs-path"#;
            let v339: clap::Arg = v335.long(v337);
            let v341: clap::Arg = v339.required(true);
            let v343: clap::Command = clap::Command::arg(v329, v341);
            let v344: string = string("r#\"NAME\"#");
            let v346: string = string("r#\"VERSION\"#");
            let v348: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v350: usize = 1_i32 as usize;
            let v354: usize = 0_i32 as usize;
            let v370: clap::builder::ValueRange = if (v354) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v350..)
            } else {
                let v368: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v350..v354)
            };
            let v371: string = string("r#\"deps\"#");
            let v372: &'static str = r#"deps"#;
            let v374: clap::Arg = clap::Arg::new(v372);
            let v376: clap::Arg = v374.short('d');
            let v377: string = string("r#\"deps\"#");
            let v378: &'static str = r#"deps"#;
            let v380: clap::Arg = v376.long(v378);
            let v382: Vec<&'static str> = v348.to_vec();
            let v384: clap::Arg = v380.value_names(v382);
            let v386: clap::Arg = v384.num_args(v370);
            let v388: clap::ArgAction = clap::ArgAction::Append;
            let v390: clap::Arg = v386.action(v388);
            let v392: clap::Command = clap::Command::arg(v343, v390);
            let v394: usize = 0_i32 as usize;
            let v398: usize = 1_i32 as usize;
            let v414: clap::builder::ValueRange = if (v398) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v394..)
            } else {
                let v412: string = string("clap::builder::ValueRange::new($0..=$1)");
                clap::builder::ValueRange::new(v394..=v398)
            };
            let v416: string = string("r#\"wasm\"#");
            let v417: &'static str = r#"wasm"#;
            let v419: clap::Arg = clap::Arg::new(v417);
            let v421: clap::Arg = v419.short('w');
            let v422: string = string("r#\"wasm\"#");
            let v423: &'static str = r#"wasm"#;
            let v425: clap::Arg = v421.long(v423);
            let v427: clap::Arg = v425.num_args(v414);
            let v429: clap::Arg = v427.require_equals(true);
            let v431: string = string("r#\"\"#");
            let v432: &str = r#""#;
            let v434: clap::Arg = v429.default_missing_value(v432);
            let v436: clap::Command = clap::Command::arg(v392, v434);
            let v438: usize = 0_i32 as usize;
            let v442: usize = 1_i32 as usize;
            let v458: clap::builder::ValueRange = if (v442) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v438..)
            } else {
                let v456: string = string("clap::builder::ValueRange::new($0..=$1)");
                clap::builder::ValueRange::new(v438..=v442)
            };
            let v460: string = string("r#\"contract\"#");
            let v461: &'static str = r#"contract"#;
            let v463: clap::Arg = clap::Arg::new(v461);
            let v465: clap::Arg = v463.short('c');
            let v466: string = string("r#\"contract\"#");
            let v467: &'static str = r#"contract"#;
            let v469: clap::Arg = v465.long(v467);
            let v471: clap::Arg = v469.num_args(v458);
            let v473: clap::Arg = v471.require_equals(true);
            let v474: string = string("r#\"\"#");
            let v475: &str = r#""#;
            let v477: clap::Arg = v473.default_missing_value(v475);
            let v479: clap::Command = clap::Command::arg(v436, v477);
            let v481: string = string("r#\"cleanup\"#");
            let v482: &'static str = r#"cleanup"#;
            let v484: clap::Arg = clap::Arg::new(v482);
            let v486: clap::Arg = v484.short('l');
            let v487: string = string("r#\"cleanup\"#");
            let v488: &'static str = r#"cleanup"#;
            let v490: clap::Arg = v486.long(v488);
            let v492: string = string("r#\"true\"#");
            let v493: &str = r#"true"#;
            let v495: clap::Arg = v490.default_value(v493);
            let v497: clap::ArgAction = clap::ArgAction::SetFalse;
            let v499: clap::Arg = v495.action(v497);
            let v501: clap::Command = clap::Command::arg(v479, v499);
            let v503: clap::Command = clap::Command::subcommand(v324, v501);
            let v505: string = string("r#\"typescript\"#");
            let v506: &'static str = r#"typescript"#;
            let v508: clap::Command = clap::Command::new(v506);
            let v509: string = string("r#\"fs-path\"#");
            let v510: &'static str = r#"fs-path"#;
            let v512: clap::Arg = clap::Arg::new(v510);
            let v514: clap::Arg = v512.short('f');
            let v515: string = string("r#\"fs-path\"#");
            let v516: &'static str = r#"fs-path"#;
            let v518: clap::Arg = v514.long(v516);
            let v520: clap::Arg = v518.required(true);
            let v522: clap::Command = clap::Command::arg(v508, v520);
            let v523: string = string("r#\"NAME\"#");
            let v525: string = string("r#\"VERSION\"#");
            let v527: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v529: usize = 1_i32 as usize;
            let v533: usize = 0_i32 as usize;
            let v548: clap::builder::ValueRange = if (v533) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v529..)
            } else {
                let v546: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v529..v533)
            };
            let v549: string = string("r#\"deps\"#");
            let v550: &'static str = r#"deps"#;
            let v552: clap::Arg = clap::Arg::new(v550);
            let v554: clap::Arg = v552.short('d');
            let v555: string = string("r#\"deps\"#");
            let v556: &'static str = r#"deps"#;
            let v558: clap::Arg = v554.long(v556);
            let v560: Vec<&'static str> = v527.to_vec();
            let v562: clap::Arg = v558.value_names(v560);
            let v564: clap::Arg = v562.num_args(v548);
            let v566: clap::ArgAction = clap::ArgAction::Append;
            let v568: clap::Arg = v564.action(v566);
            let v570: clap::Command = clap::Command::arg(v522, v568);
            let v572: clap::Command = clap::Command::subcommand(v503, v570);
            let v574: string = string("r#\"python\"#");
            let v575: &'static str = r#"python"#;
            let v577: clap::Command = clap::Command::new(v575);
            let v578: string = string("r#\"fs-path\"#");
            let v579: &'static str = r#"fs-path"#;
            let v581: clap::Arg = clap::Arg::new(v579);
            let v583: clap::Arg = v581.short('f');
            let v584: string = string("r#\"fs-path\"#");
            let v585: &'static str = r#"fs-path"#;
            let v587: clap::Arg = v583.long(v585);
            let v589: clap::Arg = v587.required(true);
            let v591: clap::Command = clap::Command::arg(v577, v589);
            let v592: string = string("r#\"NAME\"#");
            let v594: string = string("r#\"VERSION\"#");
            let v596: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v598: usize = 1_i32 as usize;
            let v602: usize = 0_i32 as usize;
            let v617: clap::builder::ValueRange = if (v602) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v598..)
            } else {
                let v615: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v598..v602)
            };
            let v618: string = string("r#\"deps\"#");
            let v619: &'static str = r#"deps"#;
            let v621: clap::Arg = clap::Arg::new(v619);
            let v623: clap::Arg = v621.short('d');
            let v624: string = string("r#\"deps\"#");
            let v625: &'static str = r#"deps"#;
            let v627: clap::Arg = v623.long(v625);
            let v629: Vec<&'static str> = v596.to_vec();
            let v631: clap::Arg = v627.value_names(v629);
            let v633: clap::Arg = v631.num_args(v617);
            let v635: clap::ArgAction = clap::ArgAction::Append;
            let v637: clap::Arg = v633.action(v635);
            let v639: clap::Command = clap::Command::arg(v591, v637);
            let v641: clap::Command = clap::Command::subcommand(v572, v639);
            let v643: string = string("r#\"dib\"#");
            let v644: &'static str = r#"dib"#;
            let v646: clap::Command = clap::Command::new(v644);
            let v648: string = string("r#\"path\"#");
            let v649: &'static str = r#"path"#;
            let v651: clap::Arg = clap::Arg::new(v649);
            let v653: clap::Arg = v651.short('p');
            let v654: string = string("r#\"path\"#");
            let v655: &'static str = r#"path"#;
            let v657: clap::Arg = v653.long(v655);
            let v659: clap::Arg = v657.required(true);
            let v661: clap::Command = clap::Command::arg(v646, v659);
            let v663: string = string("clap::value_parser!(u8).into()");
            let v664: clap::builder::ValueParser = clap::value_parser!(u8).into();
            let v666: string = string("r#\"retries\"#");
            let v667: &'static str = r#"retries"#;
            let v669: clap::Arg = clap::Arg::new(v667);
            let v671: clap::Arg = v669.short('r');
            let v672: string = string("r#\"retries\"#");
            let v673: &'static str = r#"retries"#;
            let v675: clap::Arg = v671.long(v673);
            let v677: clap::Arg = v675.value_parser(v664);
            let v679: clap::Command = clap::Command::arg(v661, v677);
            let v681: string = string("r#\"working-directory\"#");
            let v682: &'static str = r#"working-directory"#;
            let v684: clap::Arg = clap::Arg::new(v682);
            let v686: clap::Arg = v684.short('w');
            let v687: string = string("r#\"working-directory\"#");
            let v688: &'static str = r#"working-directory"#;
            let v690: clap::Arg = v686.long(v688);
            let v692: clap::Command = clap::Command::arg(v679, v690);
            clap::Command::subcommand(v641, v692)
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
            let v186: Spiral::US2 = defaultValue(Spiral::US2::US2_1, map(Spiral::method9(), v5));
            let v304: DateTime = match &v186 {
                Spiral::US2::US2_0(v186_0_0) => {
                    let v256: TimeSpan = TimeSpan::new_ticks(
                        ({
                            let _arg: DateTime = DateTime::now();
                            _arg.ticks()
                        }) - (match &v186 {
                            Spiral::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }),
                    );
                    DateTime::new_ymdhms_milli(
                        1_i32,
                        1_i32,
                        1_i32,
                        v256.hours(),
                        v256.minutes(),
                        v256.seconds(),
                        v256.milliseconds(),
                    )
                }
                _ => DateTime::now(),
            };
            let v306: string = Spiral::method10();
            let provider: string = if (v306.clone()) == string("") {
                string("M-d-y hh:mm:ss tt")
            } else {
                v306
            };
            v304.toString(provider)
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
                    let v27: Spiral::US5 =
                        defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v8));
                    match &v27 {
                        Spiral::US5::US5_0(v27_0_0) => {
                            let v0_1_temp: string = v0_1.get().clone();
                            let v1_1_temp: string = v1_1.get().clone();
                            let v2_temp: bool = v2.get().clone();
                            let v3_temp = v3.get().clone();
                            let v4_temp: string = match &v27 {
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
                let v26: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v7));
                match &v26 {
                    Spiral::US5::US5_0(v26_0_0) => Spiral::method41(
                        v0_1.clone(),
                        v1_1.clone(),
                        v2,
                        v3.clone(),
                        match &v26 {
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
            let v174: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v155));
            match &v174 {
                Spiral::US5::US5_0(v174_0_0) => match &v174 {
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
            let v25: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6));
            let v29: string = Spiral::method55(v3);
            if (v2) >= 11_u8 {
                let v33: string = append(
                    string("file_system.read_link / "),
                    sprintf!(
                        "path: {} / n: {} / path\': {} / name: {}",
                        v0_1.clone(),
                        v2,
                        v4.clone(),
                        v5.clone()
                    ),
                );
                let v40: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v33);
                Err(v40)
            } else {
                if let Spiral::US5::US5_0(v25_0_0) = &v25 {
                    if (v4.clone()) != string("") {
                        let v91: Result<std::path::PathBuf, std::io::Error> =
                            v1_1((v2) + 1_u8, v25_0_0.clone());
                        let v92 = Spiral::method48();
                        let v105: Result<std::path::PathBuf, string> = v91.map_err(|x| v92(x));
                        let v108 = Spiral::method50();
                        let v109 = Spiral::method51();
                        let v111: Spiral::US11 = match &v105 {
                            Err(v105_1_0) => v109(v105_1_0.clone()),
                            Ok(v105_0_0) => v108(v105_0_0.clone()),
                        };
                        match &v111 {
                            Spiral::US11::US11_0(v111_0_0) => {
                                let v152: string = Spiral::method35(
                                    toString(v111_0_0.clone().display()),
                                    v5.clone(),
                                );
                                let v159: &str = &*v152;
                                let v192: std::string::String = String::from(v159);
                                let v225: std::path::PathBuf = std::path::PathBuf::from(v192);
                                Ok(v225)
                            }
                            Spiral::US11::US11_1(v111_1_0) => {
                                let v270: string = append(
                                    string("file_system.read_link / "),
                                    sprintf!(
                                        "error\': {} / error: {} / name: {}",
                                        v111_1_0.clone(),
                                        v29.clone(),
                                        v5.clone()
                                    ),
                                );
                                let v277: std::io::Error =
                                    std::io::Error::new(std::io::ErrorKind::Other, &*v270);
                                Err(v277)
                            }
                        }
                    } else {
                        let v323: string =
                            append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                                   sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                            v0_1.clone(), v29.clone(),
                                            v4.clone(), v5.clone()));
                        let v330: std::io::Error =
                            std::io::Error::new(std::io::ErrorKind::Other, &*v323);
                        Err(v330)
                    }
                } else {
                    let v375: string =
                        append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                               sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                        v0_1, v29.clone(), v4, v5.clone()));
                    let v382: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v375);
                    Err(v382)
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
            let v29: Spiral::US11 = match &v23 {
                Err(v23_1_0) => v27(v23_1_0.clone()),
                Ok(v23_0_0) => v26(v23_0_0.clone()),
            };
            match &v29 {
                Spiral::US11::US11_0(v29_0_0) => Ok(v29_0_0.clone()),
                Spiral::US11::US11_1(v29_1_0) => Spiral::method53(
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
                    v29_1_0.clone(),
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
            let v24: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v5));
            let v28: string = Spiral::method55(v3);
            if (v2) >= 11_u8 {
                let v32: string = append(
                    string("file_system.read_link / "),
                    sprintf!(
                        "path: {} / n: {} / path\': {} / name: {}",
                        v0_1.clone(),
                        v2,
                        v0_1.clone(),
                        v4.clone()
                    ),
                );
                let v39: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v32);
                Err(v39)
            } else {
                if let Spiral::US5::US5_0(v24_0_0) = &v24 {
                    if (v0_1.clone()) != string("") {
                        let v90: Result<std::path::PathBuf, std::io::Error> =
                            v1_1((v2) + 1_u8, v24_0_0.clone());
                        let v91 = Spiral::method48();
                        let v104: Result<std::path::PathBuf, string> = v90.map_err(|x| v91(x));
                        let v107 = Spiral::method50();
                        let v108 = Spiral::method51();
                        let v110: Spiral::US11 = match &v104 {
                            Err(v104_1_0) => v108(v104_1_0.clone()),
                            Ok(v104_0_0) => v107(v104_0_0.clone()),
                        };
                        match &v110 {
                            Spiral::US11::US11_0(v110_0_0) => {
                                let v151: string = Spiral::method35(
                                    toString(v110_0_0.clone().display()),
                                    v4.clone(),
                                );
                                let v158: &str = &*v151;
                                let v191: std::string::String = String::from(v158);
                                let v224: std::path::PathBuf = std::path::PathBuf::from(v191);
                                Ok(v224)
                            }
                            Spiral::US11::US11_1(v110_1_0) => {
                                let v269: string = append(
                                    string("file_system.read_link / "),
                                    sprintf!(
                                        "error\': {} / error: {} / name: {}",
                                        v110_1_0.clone(),
                                        v28.clone(),
                                        v4.clone()
                                    ),
                                );
                                let v276: std::io::Error =
                                    std::io::Error::new(std::io::ErrorKind::Other, &*v269);
                                Err(v276)
                            }
                        }
                    } else {
                        let v322: string =
                            append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                                   sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                            v0_1.clone(), v28.clone(),
                                            v0_1.clone(), v4.clone()));
                        let v329: std::io::Error =
                            std::io::Error::new(std::io::ErrorKind::Other, &*v322);
                        Err(v329)
                    }
                } else {
                    let v374: string =
                        append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                               sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                        v0_1.clone(), v28.clone(), v0_1,
                                        v4.clone()));
                    let v381: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v374);
                    Err(v381)
                }
            }
        }
        pub fn method47(v0_1: string, v1_1: u8) -> Result<std::path::PathBuf, std::io::Error> {
            let v8: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v0_1.clone());
            let v9 = Spiral::method48();
            let v22: Result<std::path::PathBuf, string> = v8.map_err(|x| v9(x));
            let v25 = Spiral::method50();
            let v26 = Spiral::method51();
            let v28: Spiral::US11 = match &v22 {
                Err(v22_1_0) => v26(v22_1_0.clone()),
                Ok(v22_0_0) => v25(v22_0_0.clone()),
            };
            match &v28 {
                Spiral::US11::US11_0(v28_0_0) => Ok(v28_0_0.clone()),
                Spiral::US11::US11_1(v28_1_0) => Spiral::method56(
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
            let v25: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6));
            let v29: string = Spiral::method49(v3);
            if (v2) >= 11_u8 {
                let v33: string = append(
                    string("file_system.read_link / "),
                    sprintf!(
                        "path: {} / n: {} / path\': {} / name: {}",
                        v0_1.clone(),
                        v2,
                        v4.clone(),
                        v5.clone()
                    ),
                );
                let v40: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v33);
                Err(v40)
            } else {
                if let Spiral::US5::US5_0(v25_0_0) = &v25 {
                    if (v4.clone()) != string("") {
                        let v91: Result<std::path::PathBuf, std::io::Error> =
                            v1_1((v2) + 1_u8, v25_0_0.clone());
                        let v92 = Spiral::method48();
                        let v105: Result<std::path::PathBuf, string> = v91.map_err(|x| v92(x));
                        let v108 = Spiral::method50();
                        let v109 = Spiral::method51();
                        let v111: Spiral::US11 = match &v105 {
                            Err(v105_1_0) => v109(v105_1_0.clone()),
                            Ok(v105_0_0) => v108(v105_0_0.clone()),
                        };
                        match &v111 {
                            Spiral::US11::US11_0(v111_0_0) => {
                                let v152: string = Spiral::method35(
                                    toString(v111_0_0.clone().display()),
                                    v5.clone(),
                                );
                                let v159: &str = &*v152;
                                let v192: std::string::String = String::from(v159);
                                let v225: std::path::PathBuf = std::path::PathBuf::from(v192);
                                Ok(v225)
                            }
                            Spiral::US11::US11_1(v111_1_0) => {
                                let v270: string = append(
                                    string("file_system.read_link / "),
                                    sprintf!(
                                        "error\': {} / error: {} / name: {}",
                                        v111_1_0.clone(),
                                        v29.clone(),
                                        v5.clone()
                                    ),
                                );
                                let v277: std::io::Error =
                                    std::io::Error::new(std::io::ErrorKind::Other, &*v270);
                                Err(v277)
                            }
                        }
                    } else {
                        let v323: string =
                            append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                                   sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                            v0_1.clone(), v29.clone(),
                                            v4.clone(), v5.clone()));
                        let v330: std::io::Error =
                            std::io::Error::new(std::io::ErrorKind::Other, &*v323);
                        Err(v330)
                    }
                } else {
                    let v375: string =
                        append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                               sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                        v0_1, v29.clone(), v4, v5.clone()));
                    let v382: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v375);
                    Err(v382)
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
            let v24: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v5));
            let v28: string = Spiral::method49(v3);
            if (v2) >= 11_u8 {
                let v32: string = append(
                    string("file_system.read_link / "),
                    sprintf!(
                        "path: {} / n: {} / path\': {} / name: {}",
                        v0_1.clone(),
                        v2,
                        v0_1.clone(),
                        v4.clone()
                    ),
                );
                let v39: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v32);
                Err(v39)
            } else {
                if let Spiral::US5::US5_0(v24_0_0) = &v24 {
                    if (v0_1.clone()) != string("") {
                        let v90: Result<std::path::PathBuf, std::io::Error> =
                            v1_1((v2) + 1_u8, v24_0_0.clone());
                        let v91 = Spiral::method48();
                        let v104: Result<std::path::PathBuf, string> = v90.map_err(|x| v91(x));
                        let v107 = Spiral::method50();
                        let v108 = Spiral::method51();
                        let v110: Spiral::US11 = match &v104 {
                            Err(v104_1_0) => v108(v104_1_0.clone()),
                            Ok(v104_0_0) => v107(v104_0_0.clone()),
                        };
                        match &v110 {
                            Spiral::US11::US11_0(v110_0_0) => {
                                let v151: string = Spiral::method35(
                                    toString(v110_0_0.clone().display()),
                                    v4.clone(),
                                );
                                let v158: &str = &*v151;
                                let v191: std::string::String = String::from(v158);
                                let v224: std::path::PathBuf = std::path::PathBuf::from(v191);
                                Ok(v224)
                            }
                            Spiral::US11::US11_1(v110_1_0) => {
                                let v269: string = append(
                                    string("file_system.read_link / "),
                                    sprintf!(
                                        "error\': {} / error: {} / name: {}",
                                        v110_1_0.clone(),
                                        v28.clone(),
                                        v4.clone()
                                    ),
                                );
                                let v276: std::io::Error =
                                    std::io::Error::new(std::io::ErrorKind::Other, &*v269);
                                Err(v276)
                            }
                        }
                    } else {
                        let v322: string =
                            append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                                   sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                            v0_1.clone(), v28.clone(),
                                            v0_1.clone(), v4.clone()));
                        let v329: std::io::Error =
                            std::io::Error::new(std::io::ErrorKind::Other, &*v322);
                        Err(v329)
                    }
                } else {
                    let v374: string =
                        append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                               sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                        v0_1.clone(), v28.clone(), v0_1,
                                        v4.clone()));
                    let v381: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v374);
                    Err(v381)
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
                let v37: Spiral::US12 =
                    defaultValue(Spiral::US12::US12_1, map(Spiral::method64(), v7));
                let v80: string = match &v37 {
                    Spiral::US12::US12_0(v37_0_0) => toString(
                        match &v37 {
                            Spiral::US12::US12_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone()
                        .display(),
                    ),
                    _ => v0_1.clone(),
                };
                let v85: string = Spiral::method65(
                    string("^\\\\\\\\\\?\\\\"),
                    string(""),
                    if (v80.clone()) == string("") {
                        v0_1.clone()
                    } else {
                        v80
                    },
                );
                if (length(v85.clone())) < 2_i32 {
                    v0_1.clone()
                } else {
                    replace(
                        concat(new_array(&[
                            toLower(ofChar(getCharAt(v85.clone(), 0_i32))),
                            getSlice(v85, Some(1_i32), None::<i32>),
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
            let v176: Spiral::US13 = match &v170 {
                Err(v170_1_0) => v174(v170_1_0.clone()),
                _ => v173(),
            };
            match &v176 {
                Spiral::US13::US13_0 => {
                    let v181: () = {
                        Spiral::closure30(v0_1.clone(), ());
                        ()
                    };
                    ()
                }
                Spiral::US13::US13_1(v176_1_0) => {
                    let v231: () = {
                        Spiral::closure29(
                            v0_1.clone(),
                            match &v176 {
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
                let v283 = Spiral::method83(v0_1.clone());
                interface_cast!(
                    Spiral::Disposable::_ctor__3A5B6456(Func0::new({
                        let v283 = v283.clone();
                        move || v283.clone()()
                    })),
                    Lrc<dyn IDisposable>,
                )
            }
        }
        pub fn method71(v0_1: string, v1_1: string) {
            if (Spiral::method72(v0_1.clone(), v1_1.clone())) == false {
                let v8: string = defaultValue(string(""), Spiral::method40(v0_1.clone()));
                if (Spiral::method38(v8.clone())) == false {
                    let v13: LrcPtr<dyn IDisposable> = Spiral::method73(v8);
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
                    let v45: string = getSlice(
                        v0_1.clone(),
                        Some(1_i32),
                        Some((length(v0_1.clone())) - 1_i32),
                    );
                    let v51: string = ofChar(v10);
                    let v54: i32 = length(v51.clone());
                    let v55: Array<char> = new_init(&'\u{0000}', v54);
                    let v56: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Spiral::method31(v54, v56.clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method101(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method100())(b0)(b1)
                                }),
                                v62,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US15::US15_0(
                            v10,
                            v45,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v113: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                    (if -2_i32 == (v113) {
                                        (length(v0_1)) + 1_i32
                                    } else {
                                        (v113) + 1_i32
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
                    let v45: string = getSlice(
                        v0_1.clone(),
                        Some(1_i32),
                        Some((length(v0_1.clone())) - 1_i32),
                    );
                    let v51: string = ofChar(v10);
                    let v54: i32 = length(v51.clone());
                    let v55: Array<char> = new_init(&'\u{0000}', v54);
                    let v56: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Spiral::method31(v54, v56.clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method101(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method100())(b0)(b1)
                                }),
                                v62,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US15::US15_0(
                            v10,
                            v45,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v113: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                    (if -2_i32 == (v113) {
                                        (length(v0_1)) + 1_i32
                                    } else {
                                        (v113) + 1_i32
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
                    let v145: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v25: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method104(v25, 0_i64)) == false {
                            let v62: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v68: string = ofChar(v25);
                            let v71: i32 = length(v68.clone());
                            let v72: Array<char> = new_init(&'\u{0000}', v71);
                            let v73: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method31(v71, v73.clone()) {
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
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method101(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method100())(b0)(b1)
                                            }),
                                            v79,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v25,
                                    v62,
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
                    let v157: Spiral::US15 = match &v145 {
                        Spiral::US15::US15_0(v145_0_0, v145_0_1, v145_0_2, v145_0_3, v145_0_4) => {
                            let v146: char = v145_0_0.clone();
                            Spiral::US15::US15_0(
                                if '\\' == (v146) { '/' } else { v146 },
                                v145_0_1.clone(),
                                v145_0_2.clone(),
                                v145_0_3.clone(),
                                v145_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v145_1_0) => Spiral::US15::US15_1(v145_1_0.clone()),
                    };
                    match &v157 {
                        Spiral::US15::US15_0(v157_0_0, v157_0_1, v157_0_2, v157_0_3, v157_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v157_0_0.clone())));
                            let v1_1_temp: string = v157_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v157_0_2.clone();
                            let v3_temp: i32 = v157_0_3.clone();
                            let v4_temp: i32 = v157_0_4.clone();
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
                    let v153: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method107(v29, 0_i64)) == false {
                            let v66: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v72: string = ofChar(v29);
                            let v75: i32 = length(v72.clone());
                            let v76: Array<char> = new_init(&'\u{0000}', v75);
                            let v77: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method31(v75, v77.clone()) {
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
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method101(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method100())(b0)(b1)
                                            }),
                                            v83,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v29,
                                    v66,
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
                    let v165: Spiral::US15 = match &v153 {
                        Spiral::US15::US15_0(v153_0_0, v153_0_1, v153_0_2, v153_0_3, v153_0_4) => {
                            let v154: char = v153_0_0.clone();
                            Spiral::US15::US15_0(
                                if '\\' == (v154) { '/' } else { v154 },
                                v153_0_1.clone(),
                                v153_0_2.clone(),
                                v153_0_3.clone(),
                                v153_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v153_1_0) => Spiral::US15::US15_1(v153_1_0.clone()),
                    };
                    match &v165 {
                        Spiral::US15::US15_0(v165_0_0, v165_0_1, v165_0_2, v165_0_3, v165_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v165_0_0.clone())));
                            let v1_1_temp: string = v165_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v165_0_2.clone();
                            let v3_temp: i32 = v165_0_3.clone();
                            let v4_temp: i32 = v165_0_4.clone();
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
                    let v108: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.any_char / unexpected end of input / s: {:?}",
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
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
                        let v56: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Spiral::method31(v54, v56.clone()) {
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
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method101(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                        (Spiral::method100())(b0)(b1)
                                    }),
                                    v62,
                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                ),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Spiral::US15::US15_0(
                                v11,
                                v45,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        }
                    };
                    match &v108 {
                        Spiral::US15::US15_0(v108_0_0, v108_0_1, v108_0_2, v108_0_3, v108_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v108_0_0.clone())));
                            let v1_1_temp: string = v108_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v108_0_2.clone();
                            let v3_temp: i32 = v108_0_3.clone();
                            let v4_temp: i32 = v108_0_4.clone();
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
                let v10: string = defaultValue(
                    string(""),
                    match &_v0.get().clone() {
                        None => panic!("{}", string("optionm\'.of_obj / _v0=None"),),
                        Some(_v0_0_0) => _v0_0_0.clone(),
                    },
                );
                let v16: LrcPtr<StringBuilder> =
                    StringBuilder::_ctor__Z721C83C5(Spiral::method99());
                fn v19(arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)) -> Spiral::US15 {
                    Spiral::closure35((), arg10_0040)
                }
                fn v20(arg10_0040_1: (string, LrcPtr<StringBuilder>, i32, i32)) -> Spiral::US15 {
                    Spiral::closure39((), arg10_0040_1)
                }
                let v24: Spiral::US15 = Spiral::method103(
                    v10.clone(),
                    v16.clone(),
                    LrcPtr::new(Spiral::UH1::UH1_1(
                        Func1::from(v19),
                        LrcPtr::new(Spiral::UH1::UH1_1(
                            Func1::from(v20),
                            LrcPtr::new(Spiral::UH1::UH1_0),
                        )),
                    )),
                );
                let v244: Spiral::US16 = match &v24 {
                    Spiral::US15::US15_0(v24_0_0, v24_0_1, v24_0_2, v24_0_3, v24_0_4) => {
                        let v29: i32 = v24_0_4.clone();
                        let v28: i32 = v24_0_3.clone();
                        let v27: LrcPtr<StringBuilder> = v24_0_2.clone();
                        let v26: string = v24_0_1.clone();
                        let v170: Spiral::US15 = if string("") == (v26.clone()) {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                (v27.clone(), v28, v29)
                            ))
                        } else {
                            let v50: char = getCharAt(v26.clone(), 0_i32);
                            if (Spiral::method104(v50, 0_i64)) == false {
                                let v87: string = getSlice(
                                    v26.clone(),
                                    Some(1_i32),
                                    Some((length(v26.clone())) - 1_i32),
                                );
                                let v93: string = ofChar(v50);
                                let v96: i32 = length(v93.clone());
                                let v97: Array<char> = new_init(&'\u{0000}', v96);
                                let v98: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method31(v96, v98.clone()) {
                                    let v100: i32 = v98.l0.get().clone();
                                    let v101: char = getCharAt(v93.clone(), v100);
                                    v97.get_mut()[v100 as usize] = v101;
                                    {
                                        let v102: i32 = (v100) + 1_i32;
                                        v98.l0.set(v102);
                                        ()
                                    }
                                }
                                {
                                    let v104: List<char> = ofArray(v97.clone());
                                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                        Spiral::method101(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method100())(b0)(b1)
                                                    },
                                                ),
                                                v104,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v27.clone(),
                                            v28,
                                            v29,
                                        );
                                    Spiral::US15::US15_0(
                                        v50,
                                        v87,
                                        patternInput.0.clone(),
                                        patternInput.1.clone(),
                                        patternInput.2.clone(),
                                    )
                                }
                            } else {
                                Spiral::US15::US15_1(sprintf!("parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                                                      v50,
                                                                      toArray(ofArray(new_array(&['\"',
                                                                                                  '\'']))),
                                                                      (v27.clone(),
                                                                       v28,
                                                                       v29)))
                            }
                        };
                        let v182: Spiral::US15 = match &v170 {
                            Spiral::US15::US15_0(
                                v170_0_0,
                                v170_0_1,
                                v170_0_2,
                                v170_0_3,
                                v170_0_4,
                            ) => {
                                let v171: char = v170_0_0.clone();
                                Spiral::US15::US15_0(
                                    if '\\' == (v171) { '/' } else { v171 },
                                    v170_0_1.clone(),
                                    v170_0_2.clone(),
                                    v170_0_3.clone(),
                                    v170_0_4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v170_1_0) => {
                                Spiral::US15::US15_1(v170_1_0.clone())
                            }
                        };
                        let v202: Spiral::US16 = match &v182 {
                            Spiral::US15::US15_0(
                                v182_0_0,
                                v182_0_1,
                                v182_0_2,
                                v182_0_3,
                                v182_0_4,
                            ) => {
                                let patternInput_1: (
                                    string,
                                    string,
                                    LrcPtr<StringBuilder>,
                                    i32,
                                    i32,
                                ) = Spiral::method105(
                                    ofChar(v182_0_0.clone()),
                                    v182_0_1.clone(),
                                    v182_0_2.clone(),
                                    v182_0_3.clone(),
                                    v182_0_4.clone(),
                                );
                                Spiral::US16::US16_0(
                                    patternInput_1.0.clone(),
                                    patternInput_1.1.clone(),
                                    patternInput_1.2.clone(),
                                    patternInput_1.3.clone(),
                                    patternInput_1.4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v182_1_0) => {
                                Spiral::US16::US16_1(v182_1_0.clone())
                            }
                        };
                        let v212: Spiral::US16 = match &v202 {
                            Spiral::US16::US16_0(
                                v202_0_0,
                                v202_0_1,
                                v202_0_2,
                                v202_0_3,
                                v202_0_4,
                            ) => Spiral::US16::US16_0(
                                v202_0_0.clone(),
                                v202_0_1.clone(),
                                v202_0_2.clone(),
                                v202_0_3.clone(),
                                v202_0_4.clone(),
                            ),
                            _ => {
                                Spiral::US16::US16_0(string(""), v26.clone(), v27.clone(), v28, v29)
                            }
                        };
                        match &v212 {
                            Spiral::US16::US16_0(
                                v212_0_0,
                                v212_0_1,
                                v212_0_2,
                                v212_0_3,
                                v212_0_4,
                            ) => {
                                let v217: i32 = v212_0_4.clone();
                                let v216: i32 = v212_0_3.clone();
                                let v215: LrcPtr<StringBuilder> = v212_0_2.clone();
                                let v214: string = v212_0_1.clone();
                                let v221: Spiral::US15 = Spiral::method106(
                                    v214.clone(),
                                    v215.clone(),
                                    v216,
                                    v217,
                                    LrcPtr::new(Spiral::UH1::UH1_1(
                                        Func1::from(v19),
                                        LrcPtr::new(Spiral::UH1::UH1_1(
                                            Func1::from(v20),
                                            LrcPtr::new(Spiral::UH1::UH1_0),
                                        )),
                                    )),
                                );
                                match &v221 {
                                        Spiral::US15::US15_0(v221_0_0,
                                                             v221_0_1,
                                                             v221_0_2,
                                                             v221_0_3,
                                                             v221_0_4) =>
                                        Spiral::US16::US16_0(v212_0_0.clone(),
                                                             v221_0_1.clone(),
                                                             v221_0_2.clone(),
                                                             v221_0_3.clone(),
                                                             v221_0_4.clone()),
                                        Spiral::US15::US15_1(v221_1_0) =>
                                        Spiral::US16::US16_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                      v221_1_0.clone(),
                                                                      (v10.clone(),
                                                                       v16.clone(),
                                                                       1_i32,
                                                                       1_i32),
                                                                      (v26.clone(),
                                                                       v27.clone(),
                                                                       v28,
                                                                       v29),
                                                                      (v214.clone(),
                                                                       v215.clone(),
                                                                       v216,
                                                                       v217))),
                                    }
                            }
                            _ => Spiral::US16::US16_1(string("parsing.between / expected content")),
                        }
                    }
                    Spiral::US15::US15_1(v24_1_0) => Spiral::US16::US16_1(v24_1_0.clone()),
                };
                let v510: Spiral::US16 = match &v244 {
                    Spiral::US16::US16_0(v244_0_0, v244_0_1, v244_0_2, v244_0_3, v244_0_4) => {
                        v244.clone()
                    }
                    _ => {
                        let v401: Spiral::US15 = if string("") == (v10.clone()) {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                (v16.clone(), 1_i32, 1_i32)
                            ))
                        } else {
                            let v275: char = getCharAt(v10.clone(), 0_i32);
                            if (Spiral::method107(v275, 0_i64)) == false {
                                let v312: string = getSlice(
                                    v10.clone(),
                                    Some(1_i32),
                                    Some((length(v10.clone())) - 1_i32),
                                );
                                let v318: string = ofChar(v275);
                                let v321: i32 = length(v318.clone());
                                let v322: Array<char> = new_init(&'\u{0000}', v321);
                                let v323: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method31(v321, v323.clone()) {
                                    let v325: i32 = v323.l0.get().clone();
                                    let v326: char = getCharAt(v318.clone(), v325);
                                    v322.get_mut()[v325 as usize] = v326;
                                    {
                                        let v327: i32 = (v325) + 1_i32;
                                        v323.l0.set(v327);
                                        ()
                                    }
                                }
                                {
                                    let v329: List<char> = ofArray(v322.clone());
                                    let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                        Spiral::method101(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method100())(b0)(b1)
                                                    },
                                                ),
                                                v329,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v16.clone(),
                                            1_i32,
                                            1_i32,
                                        );
                                    Spiral::US15::US15_0(
                                        v275,
                                        v312,
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone(),
                                        patternInput_2.2.clone(),
                                    )
                                }
                            } else {
                                Spiral::US15::US15_1(sprintf!("parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                                                      v275,
                                                                      toArray(ofArray(new_array(&['\"',
                                                                                                  '\'',
                                                                                                  ' ']))),
                                                                      (v16.clone(),
                                                                       1_i32,
                                                                       1_i32)))
                            }
                        };
                        let v413: Spiral::US15 = match &v401 {
                            Spiral::US15::US15_0(
                                v401_0_0,
                                v401_0_1,
                                v401_0_2,
                                v401_0_3,
                                v401_0_4,
                            ) => {
                                let v402: char = v401_0_0.clone();
                                Spiral::US15::US15_0(
                                    if '\\' == (v402) { '/' } else { v402 },
                                    v401_0_1.clone(),
                                    v401_0_2.clone(),
                                    v401_0_3.clone(),
                                    v401_0_4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v401_1_0) => {
                                Spiral::US15::US15_1(v401_1_0.clone())
                            }
                        };
                        let v433: Spiral::US16 = match &v413 {
                            Spiral::US15::US15_0(
                                v413_0_0,
                                v413_0_1,
                                v413_0_2,
                                v413_0_3,
                                v413_0_4,
                            ) => {
                                let patternInput_3: (
                                    string,
                                    string,
                                    LrcPtr<StringBuilder>,
                                    i32,
                                    i32,
                                ) = Spiral::method108(
                                    ofChar(v413_0_0.clone()),
                                    v413_0_1.clone(),
                                    v413_0_2.clone(),
                                    v413_0_3.clone(),
                                    v413_0_4.clone(),
                                );
                                Spiral::US16::US16_0(
                                    patternInput_3.0.clone(),
                                    patternInput_3.1.clone(),
                                    patternInput_3.2.clone(),
                                    patternInput_3.3.clone(),
                                    patternInput_3.4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v413_1_0) => {
                                Spiral::US16::US16_1(v413_1_0.clone())
                            }
                        };
                        match &v433 {
                            Spiral::US16::US16_0(
                                v433_0_0,
                                v433_0_1,
                                v433_0_2,
                                v433_0_3,
                                v433_0_4,
                            ) => v433.clone(),
                            _ => {
                                let v448: Spiral::US18 = if (length(v10.clone())) == 0_i32 {
                                    Spiral::US18::US18_0(v10.clone(), v16.clone(), 1_i32, 1_i32)
                                } else {
                                    Spiral::US18::US18_1(sprintf!(
                                        "parsing.eof / expected end of input / input: {:?}",
                                        v10.clone()
                                    ))
                                };
                                let v457: Spiral::US16 = match &v448 {
                                    Spiral::US18::US18_0(
                                        v448_0_0,
                                        v448_0_1,
                                        v448_0_2,
                                        v448_0_3,
                                    ) => Spiral::US16::US16_0(
                                        string(""),
                                        v448_0_0.clone(),
                                        v448_0_1.clone(),
                                        v448_0_2.clone(),
                                        v448_0_3.clone(),
                                    ),
                                    Spiral::US18::US18_1(v448_1_0) => {
                                        Spiral::US16::US16_1(v448_1_0.clone())
                                    }
                                };
                                match &v457 {
                                    Spiral::US16::US16_0(
                                        v457_0_0,
                                        v457_0_1,
                                        v457_0_2,
                                        v457_0_3,
                                        v457_0_4,
                                    ) => {
                                        let v459: string = v457_0_1.clone();
                                        Spiral::US16::US16_0(
                                            v457_0_0.clone(),
                                            getSlice(
                                                v459.clone(),
                                                Some(Spiral::method109(v459.clone(), 0_i32)),
                                                Some((length(v459)) - 1_i32),
                                            ),
                                            v457_0_2.clone(),
                                            v457_0_3.clone(),
                                            v457_0_4.clone(),
                                        )
                                    }
                                    Spiral::US16::US16_1(v457_1_0) => {
                                        Spiral::US16::US16_1(v457_1_0.clone())
                                    }
                                }
                            }
                        }
                    }
                };
                let v854: Spiral::US19 = match &v510 {
                    Spiral::US16::US16_0(v510_0_0, v510_0_1, v510_0_2, v510_0_3, v510_0_4) => {
                        let v515: i32 = v510_0_4.clone();
                        let v514: i32 = v510_0_3.clone();
                        let v513: LrcPtr<StringBuilder> = v510_0_2.clone();
                        let v512: string = v510_0_1.clone();
                        let v683: Spiral::US15 = if string("") == (v512.clone()) {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                ' ',
                                (v513.clone(), v514, v515)
                            ))
                        } else {
                            let v522: char = getCharAt(v512.clone(), 0_i32);
                            if (v522) == ' ' {
                                let v557: string = getSlice(
                                    v512.clone(),
                                    Some(1_i32),
                                    Some((length(v512.clone())) - 1_i32),
                                );
                                let v563: string = ofChar(v522);
                                let v566: i32 = length(v563.clone());
                                let v567: Array<char> = new_init(&'\u{0000}', v566);
                                let v568: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method31(v566, v568.clone()) {
                                    let v570: i32 = v568.l0.get().clone();
                                    let v571: char = getCharAt(v563.clone(), v570);
                                    v567.get_mut()[v570 as usize] = v571;
                                    {
                                        let v572: i32 = (v570) + 1_i32;
                                        v568.l0.set(v572);
                                        ()
                                    }
                                }
                                {
                                    let v574: List<char> = ofArray(v567.clone());
                                    let patternInput_4: (LrcPtr<StringBuilder>, i32, i32) =
                                        Spiral::method101(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method100())(b0)(b1)
                                                    },
                                                ),
                                                v574,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v513.clone(),
                                            v514,
                                            v515,
                                        );
                                    Spiral::US15::US15_0(
                                        v522,
                                        v557,
                                        patternInput_4.0.clone(),
                                        patternInput_4.1.clone(),
                                        patternInput_4.2.clone(),
                                    )
                                }
                            } else {
                                let v625: i32 = (indexOf(v512.clone(), string("\n"))) - 1_i32;
                                Spiral::US15::US15_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                         ' ',
                                                                                         v514,
                                                                                         v515,
                                                                                         v513.clone(),
                                                                                         getSlice(v512.clone(),
                                                                                                  Some(0_i32),
                                                                                                  Some((if -2_i32
                                                                                                               ==
                                                                                                               (v625)
                                                                                                           {
                                                                                                            (length(v512.clone()))
                                                                                                                +
                                                                                                                1_i32
                                                                                                        } else {
                                                                                                            (v625)
                                                                                                                +
                                                                                                                1_i32
                                                                                                        })
                                                                                                           -
                                                                                                           1_i32))),
                                                                                string("\n"),
                                                                                append(((Spiral::method102((v515)
                                                                                                               -
                                                                                                               1_i32,
                                                                                                           0_i32))(string(""))),
                                                                                       string("^")),
                                                                                string("\n")])))
                            }
                        };
                        let v695: Spiral::US20 = match &v683 {
                            Spiral::US15::US15_0(
                                v683_0_0,
                                v683_0_1,
                                v683_0_2,
                                v683_0_3,
                                v683_0_4,
                            ) => Spiral::US20::US20_0(
                                Spiral::US17::US17_0(v683_0_0.clone()),
                                v683_0_1.clone(),
                                v683_0_2.clone(),
                                v683_0_3.clone(),
                                v683_0_4.clone(),
                            ),
                            _ => Spiral::US20::US20_0(
                                Spiral::US17::US17_1,
                                v512.clone(),
                                v513.clone(),
                                v514,
                                v515,
                            ),
                        };
                        let v828: Spiral::US16 = match &v695 {
                            Spiral::US20::US20_0(
                                v695_0_0,
                                v695_0_1,
                                v695_0_2,
                                v695_0_3,
                                v695_0_4,
                            ) => {
                                let v700: i32 = v695_0_4.clone();
                                let v699: i32 = v695_0_3.clone();
                                let v698: LrcPtr<StringBuilder> = v695_0_2.clone();
                                let v697: string = v695_0_1.clone();
                                let v804: Spiral::US15 = if string("") == (v697.clone()) {
                                    Spiral::US15::US15_1(sprintf!(
                                        "parsing.any_char / unexpected end of input / s: {:?}",
                                        (v698.clone(), v699, v700)
                                    ))
                                } else {
                                    let v707: char = getCharAt(v697.clone(), 0_i32);
                                    let v741: string = getSlice(
                                        v697.clone(),
                                        Some(1_i32),
                                        Some((length(v697)) - 1_i32),
                                    );
                                    let v747: string = ofChar(v707);
                                    let v750: i32 = length(v747.clone());
                                    let v751: Array<char> = new_init(&'\u{0000}', v750);
                                    let v752: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method31(v750, v752.clone()) {
                                        let v754: i32 = v752.l0.get().clone();
                                        let v755: char = getCharAt(v747.clone(), v754);
                                        v751.get_mut()[v754 as usize] = v755;
                                        {
                                            let v756: i32 = (v754) + 1_i32;
                                            v752.l0.set(v756);
                                            ()
                                        }
                                    }
                                    {
                                        let v758: List<char> = ofArray(v751.clone());
                                        let patternInput_5: (LrcPtr<StringBuilder>, i32, i32) =
                                            Spiral::method101(
                                                foldBack(
                                                    Func2::new(
                                                        move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                            (Spiral::method100())(b0)(b1)
                                                        },
                                                    ),
                                                    v758,
                                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                                ),
                                                v698,
                                                v699,
                                                v700,
                                            );
                                        Spiral::US15::US15_0(
                                            v707,
                                            v741,
                                            patternInput_5.0.clone(),
                                            patternInput_5.1.clone(),
                                            patternInput_5.2.clone(),
                                        )
                                    }
                                };
                                match &v804 {
                                    Spiral::US15::US15_0(
                                        v804_0_0,
                                        v804_0_1,
                                        v804_0_2,
                                        v804_0_3,
                                        v804_0_4,
                                    ) => {
                                        let patternInput_6: (
                                            string,
                                            string,
                                            LrcPtr<StringBuilder>,
                                            i32,
                                            i32,
                                        ) = Spiral::method110(
                                            ofChar(v804_0_0.clone()),
                                            v804_0_1.clone(),
                                            v804_0_2.clone(),
                                            v804_0_3.clone(),
                                            v804_0_4.clone(),
                                        );
                                        Spiral::US16::US16_0(
                                            patternInput_6.0.clone(),
                                            patternInput_6.1.clone(),
                                            patternInput_6.2.clone(),
                                            patternInput_6.3.clone(),
                                            patternInput_6.4.clone(),
                                        )
                                    }
                                    Spiral::US15::US15_1(v804_1_0) => {
                                        Spiral::US16::US16_1(v804_1_0.clone())
                                    }
                                }
                            }
                            Spiral::US20::US20_1(v695_1_0) => {
                                Spiral::US16::US16_1(v695_1_0.clone())
                            }
                        };
                        let v840: Spiral::US21 = match &v828 {
                            Spiral::US16::US16_0(
                                v828_0_0,
                                v828_0_1,
                                v828_0_2,
                                v828_0_3,
                                v828_0_4,
                            ) => Spiral::US21::US21_0(
                                Spiral::US5::US5_0(v828_0_0.clone()),
                                v828_0_1.clone(),
                                v828_0_2.clone(),
                                v828_0_3.clone(),
                                v828_0_4.clone(),
                            ),
                            _ => Spiral::US21::US21_0(
                                Spiral::US5::US5_1,
                                v512.clone(),
                                v513.clone(),
                                v514,
                                v515,
                            ),
                        };
                        match &v840 {
                            Spiral::US21::US21_0(
                                v840_0_0,
                                v840_0_1,
                                v840_0_2,
                                v840_0_3,
                                v840_0_4,
                            ) => Spiral::US19::US19_0(
                                v510_0_0.clone(),
                                v840_0_0.clone(),
                                v840_0_1.clone(),
                                v840_0_2.clone(),
                                v840_0_3.clone(),
                                v840_0_4.clone(),
                            ),
                            Spiral::US21::US21_1(v840_1_0) => {
                                Spiral::US19::US19_1(v840_1_0.clone())
                            }
                        }
                    }
                    Spiral::US16::US16_1(v510_1_0) => Spiral::US19::US19_1(v510_1_0.clone()),
                };
                match &v854 {
                    Spiral::US19::US19_0(
                        v854_0_0,
                        v854_0_1,
                        v854_0_2,
                        v854_0_3,
                        v854_0_4,
                        v854_0_5,
                    ) => Spiral::US14::US14_0(v854_0_0.clone(), v854_0_1.clone()),
                    Spiral::US19::US19_1(v854_1_0) => Spiral::US14::US14_1(v854_1_0.clone()),
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
                    let v161: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v33: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method113(v33, 0_i64)) == false {
                            let v70: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v76: string = ofChar(v33);
                            let v79: i32 = length(v76.clone());
                            let v80: Array<char> = new_init(&'\u{0000}', v79);
                            let v81: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method31(v79, v81.clone()) {
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
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method101(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method100())(b0)(b1)
                                            }),
                                            v87,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v33,
                                    v70,
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
                    match &v161 {
                        Spiral::US15::US15_0(v161_0_0, v161_0_1, v161_0_2, v161_0_3, v161_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v161_0_0.clone())));
                            let v1_1_temp: string = v161_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v161_0_2.clone();
                            let v3_temp: i32 = v161_0_3.clone();
                            let v4_temp: i32 = v161_0_4.clone();
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
            let v172: Spiral::US15 = if string("") == (v0_1.clone()) {
                Spiral::US15::US15_1(sprintf!(
                    "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                    '\\',
                    (v1_1.clone(), v2, v3)
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
                    let v56: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Spiral::method31(v54, v56.clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method101(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method100())(b0)(b1)
                                }),
                                v62,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US15::US15_0(
                            v10,
                            v45,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v113: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                    (if -2_i32 == (v113) {
                                        (length(v0_1)) + 1_i32
                                    } else {
                                        (v113) + 1_i32
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
            let v285: Spiral::US15 = match &v172 {
                Spiral::US15::US15_0(v172_0_0, v172_0_1, v172_0_2, v172_0_3, v172_0_4) => {
                    let v177: i32 = v172_0_4.clone();
                    let v176: i32 = v172_0_3.clone();
                    let v175: LrcPtr<StringBuilder> = v172_0_2.clone();
                    let v174: string = v172_0_1.clone();
                    if string("") == (v174.clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.any_char / unexpected end of input / s: {:?}",
                            (v175.clone(), v176, v177)
                        ))
                    } else {
                        let v184: char = getCharAt(v174.clone(), 0_i32);
                        let v218: string =
                            getSlice(v174.clone(), Some(1_i32), Some((length(v174)) - 1_i32));
                        let v224: string = ofChar(v184);
                        let v227: i32 = length(v224.clone());
                        let v228: Array<char> = new_init(&'\u{0000}', v227);
                        let v229: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Spiral::method31(v227, v229.clone()) {
                            let v231: i32 = v229.l0.get().clone();
                            let v232: char = getCharAt(v224.clone(), v231);
                            v228.get_mut()[v231 as usize] = v232;
                            {
                                let v233: i32 = (v231) + 1_i32;
                                v229.l0.set(v233);
                                ()
                            }
                        }
                        {
                            let v235: List<char> = ofArray(v228.clone());
                            let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method101(
                                    foldBack(
                                        Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                            (Spiral::method100())(b0)(b1)
                                        }),
                                        v235,
                                        LrcPtr::new(Spiral::UH0::UH0_0),
                                    ),
                                    v175,
                                    v176,
                                    v177,
                                );
                            Spiral::US15::US15_0(
                                v184,
                                v218,
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                            )
                        }
                    }
                }
                Spiral::US15::US15_1(v172_1_0) => Spiral::US15::US15_1(v172_1_0.clone()),
            };
            match &v285 {
                Spiral::US15::US15_0(v285_0_0, v285_0_1, v285_0_2, v285_0_3, v285_0_4) => {
                    Spiral::US16::US16_0(
                        append((ofChar('\\')), (ofChar(v285_0_0.clone()))),
                        v285_0_1.clone(),
                        v285_0_2.clone(),
                        v285_0_3.clone(),
                        v285_0_4.clone(),
                    )
                }
                Spiral::US15::US15_1(v285_1_0) => Spiral::US16::US16_1(v285_1_0.clone()),
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
            let v172: Spiral::US15 = if string("") == (v0_1.clone()) {
                Spiral::US15::US15_1(sprintf!(
                    "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                    '`',
                    (v1_1.clone(), v2, v3)
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
                    let v56: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Spiral::method31(v54, v56.clone()) {
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
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method101(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method100())(b0)(b1)
                                }),
                                v62,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US15::US15_0(
                            v10,
                            v45,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v113: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                    (if -2_i32 == (v113) {
                                        (length(v0_1)) + 1_i32
                                    } else {
                                        (v113) + 1_i32
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
            let v285: Spiral::US15 = match &v172 {
                Spiral::US15::US15_0(v172_0_0, v172_0_1, v172_0_2, v172_0_3, v172_0_4) => {
                    let v177: i32 = v172_0_4.clone();
                    let v176: i32 = v172_0_3.clone();
                    let v175: LrcPtr<StringBuilder> = v172_0_2.clone();
                    let v174: string = v172_0_1.clone();
                    if string("") == (v174.clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.any_char / unexpected end of input / s: {:?}",
                            (v175.clone(), v176, v177)
                        ))
                    } else {
                        let v184: char = getCharAt(v174.clone(), 0_i32);
                        let v218: string =
                            getSlice(v174.clone(), Some(1_i32), Some((length(v174)) - 1_i32));
                        let v224: string = ofChar(v184);
                        let v227: i32 = length(v224.clone());
                        let v228: Array<char> = new_init(&'\u{0000}', v227);
                        let v229: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Spiral::method31(v227, v229.clone()) {
                            let v231: i32 = v229.l0.get().clone();
                            let v232: char = getCharAt(v224.clone(), v231);
                            v228.get_mut()[v231 as usize] = v232;
                            {
                                let v233: i32 = (v231) + 1_i32;
                                v229.l0.set(v233);
                                ()
                            }
                        }
                        {
                            let v235: List<char> = ofArray(v228.clone());
                            let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method101(
                                    foldBack(
                                        Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                            (Spiral::method100())(b0)(b1)
                                        }),
                                        v235,
                                        LrcPtr::new(Spiral::UH0::UH0_0),
                                    ),
                                    v175,
                                    v176,
                                    v177,
                                );
                            Spiral::US15::US15_0(
                                v184,
                                v218,
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                            )
                        }
                    }
                }
                Spiral::US15::US15_1(v172_1_0) => Spiral::US15::US15_1(v172_1_0.clone()),
            };
            match &v285 {
                Spiral::US15::US15_0(v285_0_0, v285_0_1, v285_0_2, v285_0_3, v285_0_4) => {
                    Spiral::US16::US16_0(
                        append((ofChar('`')), (ofChar(v285_0_0.clone()))),
                        v285_0_1.clone(),
                        v285_0_2.clone(),
                        v285_0_3.clone(),
                        v285_0_4.clone(),
                    )
                }
                Spiral::US15::US15_1(v285_1_0) => Spiral::US16::US16_1(v285_1_0.clone()),
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
                    let v153: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method116(v29, 0_i64)) == false {
                            let v66: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v72: string = ofChar(v29);
                            let v75: i32 = length(v72.clone());
                            let v76: Array<char> = new_init(&'\u{0000}', v75);
                            let v77: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method31(v75, v77.clone()) {
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
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method101(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method100())(b0)(b1)
                                            }),
                                            v83,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v29,
                                    v66,
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
                    let v168: Spiral::US16 = match &v153 {
                        Spiral::US15::US15_0(v153_0_0, v153_0_1, v153_0_2, v153_0_3, v153_0_4) => {
                            Spiral::US16::US16_0(
                                ofChar(v153_0_0.clone()),
                                v153_0_1.clone(),
                                v153_0_2.clone(),
                                v153_0_3.clone(),
                                v153_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v153_1_0) => Spiral::US16::US16_1(v153_1_0.clone()),
                    };
                    let v182: Spiral::US16 = match &v168 {
                        Spiral::US16::US16_0(v168_0_0, v168_0_1, v168_0_2, v168_0_3, v168_0_4) => {
                            v168.clone()
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
                    match &v182 {
                        Spiral::US16::US16_0(v182_0_0, v182_0_1, v182_0_2, v182_0_3, v182_0_4) => {
                            let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(Spiral::UH2::UH2_1(
                                v182_0_0.clone(),
                                v0_1.get().clone(),
                            ));
                            let v1_1_temp: string = v182_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v182_0_2.clone();
                            let v3_temp: i32 = v182_0_3.clone();
                            let v4_temp: i32 = v182_0_4.clone();
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
                    let v153: Spiral::US15 = if string("") == (v1_1.get().clone()) {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method116(v29, 0_i64)) == false {
                            let v66: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v72: string = ofChar(v29);
                            let v75: i32 = length(v72.clone());
                            let v76: Array<char> = new_init(&'\u{0000}', v75);
                            let v77: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method31(v75, v77.clone()) {
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
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method101(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method100())(b0)(b1)
                                            }),
                                            v83,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v29,
                                    v66,
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
                    let v168: Spiral::US16 = match &v153 {
                        Spiral::US15::US15_0(v153_0_0, v153_0_1, v153_0_2, v153_0_3, v153_0_4) => {
                            Spiral::US16::US16_0(
                                ofChar(v153_0_0.clone()),
                                v153_0_1.clone(),
                                v153_0_2.clone(),
                                v153_0_3.clone(),
                                v153_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v153_1_0) => Spiral::US16::US16_1(v153_1_0.clone()),
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
                    let v161: Spiral::US15 = if v5 {
                        Spiral::US15::US15_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v33: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method113(v33, 0_i64)) == false {
                            let v70: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v76: string = ofChar(v33);
                            let v79: i32 = length(v76.clone());
                            let v80: Array<char> = new_init(&'\u{0000}', v79);
                            let v81: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method31(v79, v81.clone()) {
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
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method101(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method100())(b0)(b1)
                                            }),
                                            v87,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US15::US15_0(
                                    v33,
                                    v70,
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
                    let v181: Spiral::US16 = match &v161 {
                        Spiral::US15::US15_0(v161_0_0, v161_0_1, v161_0_2, v161_0_3, v161_0_4) => {
                            let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method114(
                                    ofChar(v161_0_0.clone()),
                                    v161_0_1.clone(),
                                    v161_0_2.clone(),
                                    v161_0_3.clone(),
                                    v161_0_4.clone(),
                                );
                            Spiral::US16::US16_0(
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                                patternInput_1.3.clone(),
                                patternInput_1.4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v161_1_0) => Spiral::US16::US16_1(v161_1_0.clone()),
                    };
                    let v659: Spiral::US16 = match &v181 {
                        Spiral::US16::US16_0(v181_0_0, v181_0_1, v181_0_2, v181_0_3, v181_0_4) => {
                            v181.clone()
                        }
                        _ => {
                            let v355: Spiral::US15 = if v5 {
                                Spiral::US15::US15_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                                                               '\"',
                                                                               (v2.get().clone(),
                                                                                v3.get().clone(),
                                                                                v4.get().clone())))
                            } else {
                                let v193: char = getCharAt(v1_1.get().clone(), 0_i32);
                                if (v193) == '\"' {
                                    let v228: string = getSlice(
                                        v1_1.get().clone(),
                                        Some(1_i32),
                                        Some((length(v1_1.get().clone())) - 1_i32),
                                    );
                                    let v234: string = ofChar(v193);
                                    let v237: i32 = length(v234.clone());
                                    let v238: Array<char> = new_init(&'\u{0000}', v237);
                                    let v239: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method31(v237, v239.clone()) {
                                        let v241: i32 = v239.l0.get().clone();
                                        let v242: char = getCharAt(v234.clone(), v241);
                                        v238.get_mut()[v241 as usize] = v242;
                                        {
                                            let v243: i32 = (v241) + 1_i32;
                                            v239.l0.set(v243);
                                            ()
                                        }
                                    }
                                    {
                                        let v245: List<char> = ofArray(v238.clone());
                                        let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                            Spiral::method101(
                                                foldBack(
                                                    Func2::new(
                                                        move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                            (Spiral::method100())(b0)(b1)
                                                        },
                                                    ),
                                                    v245,
                                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                                ),
                                                v2.get().clone(),
                                                v3.get().clone(),
                                                v4.get().clone(),
                                            );
                                        Spiral::US15::US15_0(
                                            v193,
                                            v228,
                                            patternInput_2.0.clone(),
                                            patternInput_2.1.clone(),
                                            patternInput_2.2.clone(),
                                        )
                                    }
                                } else {
                                    let v296: i32 =
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
                                                                                                                            (v296)
                                                                                                                        {
                                                                                                                         (length(v1_1.get().clone()))
                                                                                                                             +
                                                                                                                             1_i32
                                                                                                                     } else {
                                                                                                                         (v296)
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
                            let v590: Spiral::US16 = match &v355 {
                                Spiral::US15::US15_0(
                                    v355_0_0,
                                    v355_0_1,
                                    v355_0_2,
                                    v355_0_3,
                                    v355_0_4,
                                ) => {
                                    let v360: i32 = v355_0_4.clone();
                                    let v359: i32 = v355_0_3.clone();
                                    let v358: LrcPtr<StringBuilder> = v355_0_2.clone();
                                    let v357: string = v355_0_1.clone();
                                    let v362: Spiral::US23 = Spiral::method115(
                                        LrcPtr::new(Spiral::UH2::UH2_0),
                                        v357.clone(),
                                        v358.clone(),
                                        v359,
                                        v360,
                                    );
                                    let v393: Spiral::US16 = match &v362 {
                                        Spiral::US23::US23_0(
                                            v362_0_0,
                                            v362_0_1,
                                            v362_0_2,
                                            v362_0_3,
                                            v362_0_4,
                                        ) => {
                                            let v369: List<string> = Spiral::method119(
                                                v362_0_0.clone(),
                                                empty::<string>(),
                                            );
                                            Spiral::US16::US16_0(
                                                join(
                                                    string(""),
                                                    toArray_1(delay(Func0::new({
                                                        let v369 = v369.clone();
                                                        move || ofList(v369.clone()).clone()
                                                    }))),
                                                ),
                                                v362_0_1.clone(),
                                                v362_0_2.clone(),
                                                v362_0_3.clone(),
                                                v362_0_4.clone(),
                                            )
                                        }
                                        Spiral::US23::US23_1(v362_1_0) => {
                                            Spiral::US16::US16_1(v362_1_0.clone())
                                        }
                                    };
                                    match &v393 {
                                        Spiral::US16::US16_0(
                                            v393_0_0,
                                            v393_0_1,
                                            v393_0_2,
                                            v393_0_3,
                                            v393_0_4,
                                        ) => {
                                            let v398: i32 = v393_0_4.clone();
                                            let v397: i32 = v393_0_3.clone();
                                            let v396: LrcPtr<StringBuilder> = v393_0_2.clone();
                                            let v395: string = v393_0_1.clone();
                                            let v567: Spiral::US15 = if string("") == (v395.clone())
                                            {
                                                Spiral::US15::US15_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                                                                                   '\"',
                                                                                                   (v396.clone(),
                                                                                                    v397,
                                                                                                    v398)))
                                            } else {
                                                let v405: char = getCharAt(v395.clone(), 0_i32);
                                                if (v405) == '\"' {
                                                    let v440: string = getSlice(
                                                        v395.clone(),
                                                        Some(1_i32),
                                                        Some((length(v395.clone())) - 1_i32),
                                                    );
                                                    let v446: string = ofChar(v405);
                                                    let v449: i32 = length(v446.clone());
                                                    let v450: Array<char> =
                                                        new_init(&'\u{0000}', v449);
                                                    let v451: LrcPtr<Spiral::Mut5> =
                                                        LrcPtr::new(Spiral::Mut5 {
                                                            l0: MutCell::new(0_i32),
                                                        });
                                                    while Spiral::method31(v449, v451.clone()) {
                                                        let v453: i32 = v451.l0.get().clone();
                                                        let v454: char =
                                                            getCharAt(v446.clone(), v453);
                                                        v450.get_mut()[v453 as usize] = v454;
                                                        {
                                                            let v455: i32 = (v453) + 1_i32;
                                                            v451.l0.set(v455);
                                                            ()
                                                        }
                                                    }
                                                    {
                                                        let v457: List<char> =
                                                            ofArray(v450.clone());
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
                                                                                                            v457,
                                                                                                            LrcPtr::new(Spiral::UH0::UH0_0)),
                                                                                                   v396.clone(),
                                                                                                   v397,
                                                                                                   v398);
                                                        Spiral::US15::US15_0(
                                                            v405,
                                                            v440,
                                                            patternInput_3.0.clone(),
                                                            patternInput_3.1.clone(),
                                                            patternInput_3.2.clone(),
                                                        )
                                                    }
                                                } else {
                                                    let v508: i32 =
                                                        (indexOf(v395.clone(), string("\n")))
                                                            - 1_i32;
                                                    Spiral::US15::US15_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                                                          '\"',
                                                                                                                          v397,
                                                                                                                          v398,
                                                                                                                          v396.clone(),
                                                                                                                          getSlice(v395.clone(),
                                                                                                                                   Some(0_i32),
                                                                                                                                   Some((if -2_i32
                                                                                                                                                ==
                                                                                                                                                (v508)
                                                                                                                                            {
                                                                                                                                             (length(v395.clone()))
                                                                                                                                                 +
                                                                                                                                                 1_i32
                                                                                                                                         } else {
                                                                                                                                             (v508)
                                                                                                                                                 +
                                                                                                                                                 1_i32
                                                                                                                                         })
                                                                                                                                            -
                                                                                                                                            1_i32))),
                                                                                                                 string("\n"),
                                                                                                                 append(((Spiral::method102((v398)
                                                                                                                                                -
                                                                                                                                                1_i32,
                                                                                                                                            0_i32))(string(""))),
                                                                                                                        string("^")),
                                                                                                                 string("\n")])))
                                                }
                                            };
                                            match &v567 {
                                                                 Spiral::US15::US15_0(v567_0_0,
                                                                                      v567_0_1,
                                                                                      v567_0_2,
                                                                                      v567_0_3,
                                                                                      v567_0_4)
                                                                 =>
                                                                 Spiral::US16::US16_0(v393_0_0.clone(),
                                                                                      v567_0_1.clone(),
                                                                                      v567_0_2.clone(),
                                                                                      v567_0_3.clone(),
                                                                                      v567_0_4.clone()),
                                                                 Spiral::US15::US15_1(v567_1_0)
                                                                 =>
                                                                 Spiral::US16::US16_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                                               v567_1_0.clone(),
                                                                                               (v1_1.get().clone(),
                                                                                                v2.get().clone(),
                                                                                                v3.get().clone(),
                                                                                                v4.get().clone()),
                                                                                               (v357.clone(),
                                                                                                v358.clone(),
                                                                                                v359,
                                                                                                v360),
                                                                                               (v395.clone(),
                                                                                                v396.clone(),
                                                                                                v397,
                                                                                                v398))),
                                                             }
                                        }
                                        _ => Spiral::US16::US16_1(string(
                                            "parsing.between / expected content",
                                        )),
                                    }
                                }
                                Spiral::US15::US15_1(v355_1_0) => {
                                    Spiral::US16::US16_1(v355_1_0.clone())
                                }
                            };
                            match &v590 {
                                Spiral::US16::US16_0(
                                    v590_0_0,
                                    v590_0_1,
                                    v590_0_2,
                                    v590_0_3,
                                    v590_0_4,
                                ) => v590.clone(),
                                _ => {
                                    let v602: Spiral::US16 =
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
                                    let v613: Spiral::US16 = match &v602 {
                                        Spiral::US16::US16_0(
                                            v602_0_0,
                                            v602_0_1,
                                            v602_0_2,
                                            v602_0_3,
                                            v602_0_4,
                                        ) => Spiral::US16::US16_0(
                                            string(""),
                                            v602_0_1.clone(),
                                            v602_0_2.clone(),
                                            v602_0_3.clone(),
                                            v602_0_4.clone(),
                                        ),
                                        Spiral::US16::US16_1(v602_1_0) => {
                                            Spiral::US16::US16_1(v602_1_0.clone())
                                        }
                                    };
                                    let v624: Spiral::US23 = match &v613 {
                                        Spiral::US16::US16_0(
                                            v613_0_0,
                                            v613_0_1,
                                            v613_0_2,
                                            v613_0_3,
                                            v613_0_4,
                                        ) => Spiral::method120(
                                            LrcPtr::new(Spiral::UH2::UH2_0),
                                            v613_0_1.clone(),
                                            v613_0_2.clone(),
                                            v613_0_3.clone(),
                                            v613_0_4.clone(),
                                        ),
                                        Spiral::US16::US16_1(v613_1_0) => {
                                            Spiral::US23::US23_1(v613_1_0.clone())
                                        }
                                    };
                                    match &v624 {
                                        Spiral::US23::US23_0(
                                            v624_0_0,
                                            v624_0_1,
                                            v624_0_2,
                                            v624_0_3,
                                            v624_0_4,
                                        ) => {
                                            let v631: List<string> = Spiral::method119(
                                                v624_0_0.clone(),
                                                empty::<string>(),
                                            );
                                            Spiral::US16::US16_0(
                                                join(
                                                    string(""),
                                                    toArray_1(delay(Func0::new({
                                                        let v631 = v631.clone();
                                                        move || ofList(v631.clone()).clone()
                                                    }))),
                                                ),
                                                v624_0_1.clone(),
                                                v624_0_2.clone(),
                                                v624_0_3.clone(),
                                                v624_0_4.clone(),
                                            )
                                        }
                                        Spiral::US23::US23_1(v624_1_0) => {
                                            Spiral::US16::US16_1(v624_1_0.clone())
                                        }
                                    }
                                }
                            }
                        }
                    };
                    match &v659 {
                        Spiral::US16::US16_0(v659_0_0, v659_0_1, v659_0_2, v659_0_3, v659_0_4) => {
                            let v664: i32 = v659_0_4.clone();
                            let v663: i32 = v659_0_3.clone();
                            let v662: LrcPtr<StringBuilder> = v659_0_2.clone();
                            let v661: string = v659_0_1.clone();
                            let v660: string = v659_0_0.clone();
                            let v666: i32 = Spiral::method109(v661.clone(), 0_i32);
                            let v708: Spiral::US18 = if 0_i32 == (v666) {
                                Spiral::US18::US18_1(string(
                                    "parsing.spaces1 / expected at least one space",
                                ))
                            } else {
                                Spiral::US18::US18_0(
                                    getSlice(
                                        v661.clone(),
                                        Some(v666),
                                        Some((length(v661.clone())) - 1_i32),
                                    ),
                                    v662.clone(),
                                    v663,
                                    v664,
                                )
                            };
                            match &v708 {
                                Spiral::US18::US18_0(v708_0_0, v708_0_1, v708_0_2, v708_0_3) => {
                                    let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(
                                        Spiral::UH2::UH2_1(v660.clone(), v0_1.get().clone()),
                                    );
                                    let v1_1_temp: string = v708_0_0.clone();
                                    let v2_temp: LrcPtr<StringBuilder> = v708_0_1.clone();
                                    let v3_temp: i32 = v708_0_2.clone();
                                    let v4_temp: i32 = v708_0_3.clone();
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
                                            v660.clone(),
                                            LrcPtr::new(Spiral::UH2::UH2_0),
                                        )),
                                    ),
                                    v661.clone(),
                                    v662.clone(),
                                    v663,
                                    v664,
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
                let v22: Spiral::US23 = Spiral::method112(
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
                match &v22 {
                    Spiral::US23::US23_0(v22_0_0, v22_0_1, v22_0_2, v22_0_3, v22_0_4) => {
                        Spiral::US22::US22_0(toArray(Spiral::method119(
                            v22_0_0.clone(),
                            empty::<string>(),
                        )))
                    }
                    Spiral::US23::US23_1(v22_1_0) => Spiral::US22::US22_1(v22_1_0.clone()),
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
                        let v226: Spiral::US5 =
                            defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6.clone()));
                        let v240: std::process::Command = match &v226 {
                            Spiral::US5::US5_0(v226_0_0) => {
                                let v232: bool = true;
                                let mut v207 = v207;
                                let v234: bool = true;
                                std::process::Command::current_dir(
                                    &mut v207,
                                    &*match &v226 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                );
                                v207
                            }
                            _ => v207,
                        };
                        let v262: std::process::Command = if (get_Count(v2.clone()) as u64) == 0_u64
                        {
                            v240
                        } else {
                            let v244: Vec<(string, string)> = v2.clone().to_vec();
                            let v246: bool = true;
                            let _vec_fold_ = v244.into_iter().fold(v240, |acc, x| {
                                //;
                                let v248: std::process::Command = acc;
                                let patternInput_1: (string, string) = x;
                                let v253: bool = true;
                                let mut v248 = v248;
                                let v255: bool = true;
                                std::process::Command::env(
                                    &mut v248,
                                    &*patternInput_1.0.clone(),
                                    &*patternInput_1.1.clone(),
                                );
                                let v257: std::process::Command = v248;
                                let v259: bool = true;
                                v257
                            });
                            _vec_fold_
                        };
                        let v264: bool = true;
                        let mut v262 = v262;
                        let v266: Result<std::process::Child, std::io::Error> =
                            std::process::Command::spawn(&mut v262);
                        let v267 = Spiral::method74();
                        let v271: Result<std::process::Child, std::string::String> =
                            v266.map_err(|x| v267(x));
                        let v283 = Spiral::method123();
                        let v285: bool = true;
                        let _result_map_ = v271.map(|x| {
                            //;
                            let v292: Option<std::process::Child> = v283(Some(x));
                            let v294: std::sync::Mutex<Option<std::process::Child>> =
                                std::sync::Mutex::new(v292);
                            let v296: std::sync::Arc<
                                std::sync::Mutex<Option<std::process::Child>>,
                            > = std::sync::Arc::new(v294);
                            let v298: bool = true;
                            v296
                        });
                        let v300: Result<
                            std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>,
                            std::string::String,
                        > = _result_map_;
                        let v301 = Spiral::method124();
                        let v302 = Spiral::method125();
                        let v304: Spiral::US24 = match v300 {
                            Ok(x) => v301(x),
                            Err(e) => v302(e),
                        };
                        let patternInput_3: (i32, Spiral::US7, Spiral::US25) = match &v304 {
                            Spiral::US24::US24_0(v304_0_0) => {
                                let v305: std::sync::Arc<
                                    std::sync::Mutex<Option<std::process::Child>>,
                                > = v304_0_0.clone();
                                let v307: bool = true;
                                let _capture = (|| {
                                    //;
                                    let v309: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::Child>>,
                                    > = v305.clone();
                                    let v311: Result<
                                        std::sync::MutexGuard<Option<std::process::Child>>,
                                        std::sync::PoisonError<
                                            std::sync::MutexGuard<Option<std::process::Child>>,
                                        >,
                                    > = v309.lock();
                                    let v327: std::sync::MutexGuard<Option<std::process::Child>> =
                                        Spiral::method128(v311.unwrap());
                                    let v329: bool = true;
                                    let mut v327 = v327;
                                    let v331: &mut Option<std::process::Child> = &mut v327;
                                    let v333: Option<&mut std::process::Child> = v331.as_mut();
                                    let v335: &mut std::process::Child = v333.unwrap();
                                    let v337: &mut Option<std::process::ChildStdout> =
                                        &mut v335.stdout;
                                    let v339: Option<std::process::ChildStdout> =
                                        Option::take(v337);
                                    let v341: std::process::ChildStdout = v339.unwrap();
                                    let v343: bool = true;
                                    v341
                                })();
                                let v345: std::process::ChildStdout = _capture;
                                let v347: bool = true;
                                let _capture = (|| {
                                    //;
                                    let v349: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::Child>>,
                                    > = v305.clone();
                                    let v351: Result<
                                        std::sync::MutexGuard<Option<std::process::Child>>,
                                        std::sync::PoisonError<
                                            std::sync::MutexGuard<Option<std::process::Child>>,
                                        >,
                                    > = v349.lock();
                                    let v367: std::sync::MutexGuard<Option<std::process::Child>> =
                                        Spiral::method128(v351.unwrap());
                                    let v369: bool = true;
                                    let mut v367 = v367;
                                    let v371: &mut Option<std::process::Child> = &mut v367;
                                    let v373: Option<&mut std::process::Child> = v371.as_mut();
                                    let v375: &mut std::process::Child = v373.unwrap();
                                    let v377: &mut Option<std::process::ChildStderr> =
                                        &mut v375.stderr;
                                    let v379: Option<std::process::ChildStderr> =
                                        Option::take(v377);
                                    let v381: std::process::ChildStderr = v379.unwrap();
                                    let v383: bool = true;
                                    v381
                                })();
                                let v385: std::process::ChildStderr = _capture;
                                let v387: bool = true;
                                let _capture = (|| {
                                    //;
                                    let v389: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::Child>>,
                                    > = v305.clone();
                                    let v391: Result<
                                        std::sync::MutexGuard<Option<std::process::Child>>,
                                        std::sync::PoisonError<
                                            std::sync::MutexGuard<Option<std::process::Child>>,
                                        >,
                                    > = v389.lock();
                                    let v407: std::sync::MutexGuard<Option<std::process::Child>> =
                                        Spiral::method128(v391.unwrap());
                                    let v409: bool = true;
                                    let mut v407 = v407;
                                    let v411: &mut Option<std::process::Child> = &mut v407;
                                    let v413: Option<&mut std::process::Child> = v411.as_mut();
                                    let v415: &mut std::process::Child = v413.unwrap();
                                    let v417: &mut Option<std::process::ChildStdin> =
                                        &mut v415.stdin;
                                    let v419: Option<std::process::ChildStdin> = Option::take(v417);
                                    let v421: std::process::ChildStdin = v419.unwrap();
                                    let v427: Option<std::process::ChildStdin> =
                                        (Spiral::method129())(Some(v421));
                                    let v429: std::sync::Mutex<Option<std::process::ChildStdin>> =
                                        std::sync::Mutex::new(v427);
                                    let v431: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::ChildStdin>>,
                                    > = std::sync::Arc::new(v429);
                                    let v433: bool = true;
                                    v431
                                })();
                                let v435: std::sync::Arc<
                                    std::sync::Mutex<Option<std::process::ChildStdin>>,
                                > = _capture;
                                let patternInput_2: (
                                    std::sync::mpsc::Sender<std::string::String>,
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                ) = {
                                    let (sender, receiver) = std::sync::mpsc::channel();
                                    (sender, std::sync::Arc::new(receiver))
                                };
                                let v437: std::sync::mpsc::Sender<std::string::String> =
                                    patternInput_2.0.clone();
                                let v440: std::sync::mpsc::Sender<std::string::String> =
                                    (Spiral::method130())(v437.clone());
                                let v442: std::sync::Mutex<
                                    std::sync::mpsc::Sender<std::string::String>,
                                > = std::sync::Mutex::new(v440);
                                let v444: std::sync::Arc<
                                    std::sync::Mutex<std::sync::mpsc::Sender<std::string::String>>,
                                > = std::sync::Arc::new(v442);
                                let v446: std::sync::mpsc::Sender<std::string::String> =
                                    (Spiral::method131())(v437);
                                let v448: std::sync::Mutex<
                                    std::sync::mpsc::Sender<std::string::String>,
                                > = std::sync::Mutex::new(v446);
                                let v450: std::sync::Arc<
                                    std::sync::Mutex<std::sync::mpsc::Sender<std::string::String>>,
                                > = std::sync::Arc::new(v448);
                                let v452: std::sync::Arc<
                                    std::sync::mpsc::Receiver<std::string::String>,
                                > = (Spiral::method132())(patternInput_2.1.clone());
                                let v454: std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                > = std::sync::Mutex::new(v452);
                                let v456: std::sync::Arc<
                                    std::sync::Mutex<
                                        std::sync::Arc<
                                            std::sync::mpsc::Receiver<std::string::String>,
                                        >,
                                    >,
                                > = std::sync::Arc::new(v454);
                                let v458: bool = true;
                                let __spawn = std::thread::spawn(move || {
                                    //;
                                    let v460: encoding_rs_io::DecodeReaderBytes<
                                        std::process::ChildStdout,
                                        Vec<u8>,
                                    > = encoding_rs_io::DecodeReaderBytesBuilder::new()
                                        .utf8_passthru(true)
                                        .build(v345);
                                    let v462: std::io::BufReader<
                                        encoding_rs_io::DecodeReaderBytes<
                                            std::process::ChildStdout,
                                            Vec<u8>,
                                        >,
                                    > = std::io::BufReader::new(v460);
                                    let v464: std::io::Lines<
                                        std::io::BufReader<
                                            encoding_rs_io::DecodeReaderBytes<
                                                std::process::ChildStdout,
                                                Vec<u8>,
                                            >,
                                        >,
                                    > = std::io::BufRead::lines(v462);
                                    let v466: bool = true;
                                    let mut v464 = v464;
                                    let _iter_try_for_each = v464.try_for_each(|x| {
                                        //;
                                        let v468: Result<std::string::String, std::io::Error> = x;
                                        let v470: std::sync::Arc<
                                            std::sync::Mutex<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                        > = v444.clone();
                                        let v471 = Spiral::method74();
                                        let v475: Result<std::string::String, std::string::String> =
                                            v468.map_err(|x| v471(x));
                                        let v487 = Spiral::method133();
                                        let v488 = Spiral::method134();
                                        let v490: Spiral::US26 = match v475 {
                                            Ok(x) => v487(x),
                                            Err(e) => v488(e),
                                        };
                                        let v727: std::string::String = match &v490 {
                                            Spiral::US26::US26_0(v490_0_0) => {
                                                let v493: string =
                                                    fable_library_rust::String_::fromString(
                                                        v490_0_0.clone(),
                                                    );
                                                let v495: &encoding_rs::Encoding =
                                                    encoding_rs::UTF_8;
                                                let v497: std::borrow::Cow<[u8]> =
                                                    v495.encode(&*v493).0;
                                                let v499: &[u8] = v497.as_ref();
                                                let v501: Result<&str, std::str::Utf8Error> =
                                                    std::str::from_utf8(v499);
                                                let v505: &str = v501.unwrap();
                                                let v544: std::string::String = String::from(v505);
                                                let v552: string = concat(new_array(&[
                                                    string("> "),
                                                    fable_library_rust::String_::fromString(
                                                        v544.clone(),
                                                    ),
                                                ]));
                                                if v5 {
                                                    let v555: () = {
                                                        Spiral::closure53(v552.clone(), ());
                                                        ()
                                                    };
                                                    ()
                                                } else {
                                                    let v607: () = {
                                                        Spiral::closure10(v552, ());
                                                        ()
                                                    };
                                                    ()
                                                }
                                                v544
                                            }
                                            Spiral::US26::US26_1(v490_1_0) => {
                                                let v609: std::string::String = v490_1_0.clone();
                                                let v612: () = {
                                                    Spiral::closure52(v5, v609.clone(), ());
                                                    ()
                                                };
                                                let v659: string =
                                                    sprintf!("\u{001b}[4;7m{}\u{001b}[0m", v609);
                                                let v666: &str = &*v659;
                                                String::from(v666)
                                            }
                                        };
                                        let v729: std::sync::Arc<
                                            std::sync::Mutex<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                        > = v470;
                                        let v731: Result<
                                            std::sync::MutexGuard<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                            std::sync::PoisonError<
                                                std::sync::MutexGuard<
                                                    std::sync::mpsc::Sender<std::string::String>,
                                                >,
                                            >,
                                        > = v729.lock();
                                        let v735: std::sync::MutexGuard<
                                            std::sync::mpsc::Sender<std::string::String>,
                                        > = v731.unwrap();
                                        let v748: &std::sync::mpsc::Sender<std::string::String> =
                                            &v735;
                                        let v750: Result<
                                            (),
                                            std::sync::mpsc::SendError<std::string::String>,
                                        > = v748.send(v727);
                                        let v751 = Spiral::method139();
                                        let v755: Result<(), std::string::String> =
                                            v750.map_err(|x| v751(x));
                                        let v768: _ = v755;
                                        let v770: bool = true;
                                        v768
                                    }); //;
                                    let v773: Result<(), string> =
                                        Spiral::method140(_iter_try_for_each.map_err(|x| x.into()));
                                    let v776: string = string("}");
                                    let v781: bool = true;
                                    let _fix_closure_v778 = v773;
                                    let v788: string = append(
                                        (append(
                                            (append(
                                                (append(
                                                    string("true; _fix_closure_v778 "),
                                                    (v776),
                                                )),
                                                string("); "),
                                            )),
                                            string(""),
                                        )),
                                        string(" // rust.fix_closure\'"),
                                    );
                                    let v789: bool = true;
                                    _fix_closure_v778
                                }); // rust.fix_closure';
                                let v791: std::thread::JoinHandle<Result<(), string>> = __spawn;
                                let v793: bool = true;
                                let __spawn = std::thread::spawn(move || {
                                    //;
                                    let v795: encoding_rs_io::DecodeReaderBytes<
                                        std::process::ChildStderr,
                                        Vec<u8>,
                                    > = encoding_rs_io::DecodeReaderBytesBuilder::new()
                                        .utf8_passthru(true)
                                        .build(v385);
                                    let v797: std::io::BufReader<
                                        encoding_rs_io::DecodeReaderBytes<
                                            std::process::ChildStderr,
                                            Vec<u8>,
                                        >,
                                    > = std::io::BufReader::new(v795);
                                    let v799: std::io::Lines<
                                        std::io::BufReader<
                                            encoding_rs_io::DecodeReaderBytes<
                                                std::process::ChildStderr,
                                                Vec<u8>,
                                            >,
                                        >,
                                    > = std::io::BufRead::lines(v797);
                                    let v801: bool = true;
                                    let mut v799 = v799;
                                    let _iter_try_for_each = v799.try_for_each(|x| {
                                        //;
                                        let v803: Result<std::string::String, std::io::Error> = x;
                                        let v805: std::sync::Arc<
                                            std::sync::Mutex<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                        > = v450.clone();
                                        let v806 = Spiral::method74();
                                        let v810: Result<std::string::String, std::string::String> =
                                            v803.map_err(|x| v806(x));
                                        let v822 = Spiral::method133();
                                        let v823 = Spiral::method134();
                                        let v825: Spiral::US26 = match v810 {
                                            Ok(x) => v822(x),
                                            Err(e) => v823(e),
                                        };
                                        let v1128: std::string::String = match &v825 {
                                            Spiral::US26::US26_0(v825_0_0) => {
                                                let v828: string =
                                                    fable_library_rust::String_::fromString(
                                                        v825_0_0.clone(),
                                                    );
                                                let v830: &encoding_rs::Encoding =
                                                    encoding_rs::UTF_8;
                                                let v832: std::borrow::Cow<[u8]> =
                                                    v830.encode(&*v828).0;
                                                let v834: &[u8] = v832.as_ref();
                                                let v836: Result<&str, std::str::Utf8Error> =
                                                    std::str::from_utf8(v834);
                                                let v840: &str = v836.unwrap();
                                                let v879: std::string::String = String::from(v840);
                                                let v887: string = concat(new_array(&[
                                                    string("! "),
                                                    fable_library_rust::String_::fromString(
                                                        v879.clone(),
                                                    ),
                                                ]));
                                                if v5 {
                                                    let v890: () = {
                                                        Spiral::closure53(v887.clone(), ());
                                                        ()
                                                    };
                                                    ()
                                                } else {
                                                    let v941: () = {
                                                        Spiral::closure10(v887, ());
                                                        ()
                                                    };
                                                    ()
                                                }
                                                {
                                                    let v943: string = sprintf!(
                                                        "\u{001b}[4;7m{}\u{001b}[0m",
                                                        v879
                                                    );
                                                    let v950: &str = &*v943;
                                                    String::from(v950)
                                                }
                                            }
                                            Spiral::US26::US26_1(v825_1_0) => {
                                                let v1010: std::string::String = v825_1_0.clone();
                                                let v1013: () = {
                                                    Spiral::closure52(v5, v1010.clone(), ());
                                                    ()
                                                };
                                                let v1060: string =
                                                    sprintf!("\u{001b}[4;7m{}\u{001b}[0m", v1010);
                                                let v1067: &str = &*v1060;
                                                String::from(v1067)
                                            }
                                        };
                                        let v1130: std::sync::Arc<
                                            std::sync::Mutex<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                        > = v805;
                                        let v1132: Result<
                                            std::sync::MutexGuard<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                            std::sync::PoisonError<
                                                std::sync::MutexGuard<
                                                    std::sync::mpsc::Sender<std::string::String>,
                                                >,
                                            >,
                                        > = v1130.lock();
                                        let v1136: std::sync::MutexGuard<
                                            std::sync::mpsc::Sender<std::string::String>,
                                        > = v1132.unwrap();
                                        let v1149: &std::sync::mpsc::Sender<std::string::String> =
                                            &v1136;
                                        let v1151: Result<
                                            (),
                                            std::sync::mpsc::SendError<std::string::String>,
                                        > = v1149.send(v1128);
                                        let v1152 = Spiral::method139();
                                        let v1156: Result<(), std::string::String> =
                                            v1151.map_err(|x| v1152(x));
                                        let v1169: _ = v1156;
                                        let v1171: bool = true;
                                        v1169
                                    }); //;
                                    let v1174: Result<(), string> =
                                        Spiral::method140(_iter_try_for_each.map_err(|x| x.into()));
                                    let v1175: string = string("}");
                                    let v1180: bool = true;
                                    let _fix_closure_v1177 = v1174;
                                    let v1187: string = append(
                                        (append(
                                            (append(
                                                (append(
                                                    string("true; _fix_closure_v1177 "),
                                                    (v1175),
                                                )),
                                                string("); "),
                                            )),
                                            string(""),
                                        )),
                                        string(" // rust.fix_closure\'"),
                                    );
                                    let v1188: bool = true;
                                    _fix_closure_v1177
                                }); // rust.fix_closure';
                                let v1190: std::thread::JoinHandle<Result<(), string>> = __spawn;
                                let v1209: Spiral::US27 = defaultValue(
                                    Spiral::US27::US27_1,
                                    map(Spiral::method141(), v4.clone()),
                                );
                                match &v1209 {
                                    Spiral::US27::US27_0(v1209_0_0) => {
                                        let v1215: std::sync::Arc<
                                            std::sync::Mutex<Option<std::process::ChildStdin>>,
                                        > = v435.clone();
                                        let v1217: Result<
                                            std::sync::MutexGuard<Option<std::process::ChildStdin>>,
                                            std::sync::PoisonError<
                                                std::sync::MutexGuard<
                                                    Option<std::process::ChildStdin>,
                                                >,
                                            >,
                                        > = v1215.lock();
                                        let v1233: std::sync::MutexGuard<
                                            Option<std::process::ChildStdin>,
                                        > = Spiral::method142(v1217.unwrap());
                                        let v1235: bool = true;
                                        let mut v1233 = v1233;
                                        let v1237: &mut Option<std::process::ChildStdin> =
                                            &mut v1233;
                                        let v1239: Option<std::process::ChildStdin> =
                                            Option::take(v1237);
                                        let v1241: bool = true;
                                        let _optionm_map_ = v1239.map(|x| {
                                            //;
                                            let v1243: std::process::ChildStdin = x;
                                            let v1245: std::sync::Mutex<std::process::ChildStdin> =
                                                std::sync::Mutex::new(v1243);
                                            let v1247: std::sync::Arc<
                                                std::sync::Mutex<std::process::ChildStdin>,
                                            > = std::sync::Arc::new(v1245);
                                            let v1249: bool = true;
                                            v1247
                                        });
                                        let v1251: Option<
                                            std::sync::Arc<
                                                std::sync::Mutex<std::process::ChildStdin>,
                                            >,
                                        > = _optionm_map_;
                                        let v1270: Spiral::US28 = defaultValue(
                                            Spiral::US28::US28_1,
                                            map(Spiral::method143(), v1251),
                                        );
                                        match &v1270 {
                                            Spiral::US28::US28_0(v1270_0_0) => {
                                                let v1274: std::sync::Arc<
                                                    std::sync::Mutex<std::process::ChildStdin>,
                                                > = match &v1270 {
                                                    Spiral::US28::US28_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone();
                                                (match &v1209 {
                                                    Spiral::US27::US27_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                })(
                                                    v1274.clone()
                                                );
                                                {
                                                    let v1276: std::sync::Arc<
                                                        std::sync::Mutex<std::process::ChildStdin>,
                                                    > = v1274;
                                                    let v1278: Result<
                                                        std::sync::MutexGuard<
                                                            std::process::ChildStdin,
                                                        >,
                                                        std::sync::PoisonError<
                                                            std::sync::MutexGuard<
                                                                std::process::ChildStdin,
                                                            >,
                                                        >,
                                                    > = v1276.lock();
                                                    let v1294: std::sync::MutexGuard<
                                                        std::process::ChildStdin,
                                                    > = Spiral::method144(v1278.unwrap());
                                                    let v1296: bool = true;
                                                    let mut v1294 = v1294;
                                                    let v1298: bool = true;
                                                    std::io::Write::flush(&mut *v1294).unwrap();
                                                    ()
                                                }
                                            }
                                            _ => (),
                                        }
                                    }
                                    _ => (),
                                }
                                {
                                    let v1300: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::Child>>,
                                    > = v305;
                                    let v1302: Result<
                                        std::sync::MutexGuard<Option<std::process::Child>>,
                                        std::sync::PoisonError<
                                            std::sync::MutexGuard<Option<std::process::Child>>,
                                        >,
                                    > = v1300.lock();
                                    let v1318: std::sync::MutexGuard<Option<std::process::Child>> =
                                        Spiral::method128(v1302.unwrap());
                                    let v1320: bool = true;
                                    let mut v1318 = v1318;
                                    let v1322: &mut Option<std::process::Child> = &mut v1318;
                                    let v1324: Option<std::process::Child> = Option::take(v1322);
                                    let v1326: std::process::Child = v1324.unwrap();
                                    let v1328: Result<std::process::Output, std::io::Error> =
                                        v1326.wait_with_output();
                                    let v1329 = Spiral::method74();
                                    let v1342: Result<std::process::Output, std::string::String> =
                                        v1328.map_err(|x| v1329(x));
                                    let v1352: string = string("vec![v791, v1190]");
                                    let v1353: Vec<std::thread::JoinHandle<Result<(), string>>> =
                                        vec![v791, v1190];
                                    let v1355: bool = true;
                                    v1353.into_iter().for_each(|x| {
                                        //;
                                        let v1357: std::thread::JoinHandle<Result<(), string>> = x;
                                        let v1359: Result<
                                            Result<(), string>,
                                            Box<dyn core::any::Any + 'static + Send>,
                                        > = std::thread::JoinHandle::join(v1357);
                                        let v1363: Result<(), string> = v1359.unwrap();
                                        v1363.unwrap();
                                        {
                                            let v1380: bool = true;
                                            let v1382: bool = true;
                                        }
                                    });
                                    {
                                        //;
                                        let v1383 = Spiral::method145();
                                        let v1384 = Spiral::method146();
                                        let v1386: Spiral::US29 = match &v1342 {
                                            Err(v1342_1_0) => v1384(v1342_1_0.clone()),
                                            Ok(v1342_0_0) => v1383(v1342_0_0.clone()),
                                        };
                                        match &v1386 {
                                            Spiral::US29::US29_0(v1386_0_0) => {
                                                let v1391: std::process::ExitStatus =
                                                    v1386_0_0.clone().status;
                                                let v1393: Option<i32> = v1391.code();
                                                let v1412: Spiral::US30 = defaultValue(
                                                    Spiral::US30::US30_1,
                                                    map(Spiral::method148(), v1393),
                                                );
                                                match &v1412 {
                                                    Spiral::US30::US30_0(v1412_0_0) => (
                                                        match &v1412 {
                                                            Spiral::US30::US30_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        },
                                                        Spiral::US7::US7_1,
                                                        Spiral::US25::US25_0(v456.clone()),
                                                    ),
                                                    _ => {
                                                        let v1426:
                                                                                        &str =
                                                                                    &*string("runtime.execute_with_options / exit_code=None");
                                                        (
                                                            -1_i32,
                                                            Spiral::US7::US7_0(String::from(v1426)),
                                                            Spiral::US25::US25_0(v456.clone()),
                                                        )
                                                    }
                                                }
                                            }
                                            Spiral::US29::US29_1(v1386_1_0) => {
                                                let v1494: std::string::String = v1386_1_0.clone();
                                                let v1497: () = {
                                                    Spiral::closure59(v1494.clone(), ());
                                                    ()
                                                };
                                                (
                                                    -2_i32,
                                                    Spiral::US7::US7_0(v1494),
                                                    Spiral::US25::US25_1,
                                                )
                                            }
                                        }
                                    }
                                }
                            }
                            Spiral::US24::US24_1(v304_1_0) => {
                                let v1552: std::string::String = v304_1_0.clone();
                                let v1555: () = {
                                    Spiral::closure46(v1552.clone(), ());
                                    ()
                                };
                                (-1_i32, Spiral::US7::US7_0(v1552), Spiral::US25::US25_1)
                            }
                        };
                        let v1609: Spiral::US25 = patternInput_3.2.clone();
                        let v1608: Spiral::US7 = patternInput_3.1.clone();
                        let v1607: i32 = patternInput_3.0.clone();
                        let v1617: Option<
                            std::sync::Arc<
                                std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                >,
                            >,
                        > = match &v1609 {
                            Spiral::US25::US25_0(v1609_0_0) => Some(
                                match &v1609 {
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
                        let v1619: bool = true;
                        let _optionm_map_ = v1617.map(|x| {
                            //;
                            let v1621: std::sync::Arc<
                                std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                >,
                            > = x;
                            let v1623: std::sync::Arc<
                                std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                >,
                            > = v1621;
                            let v1625: Result<
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
                            > = v1623.lock();
                            let v1629: std::sync::MutexGuard<
                                std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                            > = v1625.unwrap();
                            let v1642 = v1629.iter();
                            let v1644: Vec<std::string::String> = v1642.collect::<Vec<_>>();
                            let v1646: bool = true;
                            let _vec_map: Vec<_> = v1644
                                .into_iter()
                                .map(|x| {
                                    //;
                                    let v1648: std::string::String = x;
                                    let v1650: string =
                                        fable_library_rust::String_::fromString(v1648);
                                    let v1652: bool = true;
                                    v1650
                                })
                                .collect::<Vec<_>>();
                            let v1654: Vec<string> = _vec_map;
                            let v1658: LrcPtr<dyn IEnumerable_1<string>> = ofArray_1(
                                fable_library_rust::NativeArray_::array_from(v1654.clone()),
                            );
                            let v1665: string = join(Spiral::method70(), toArray_1(v1658));
                            let v1670: bool = true;
                            v1665
                        });
                        let v1672: Option<string> = _optionm_map_;
                        let v1679: Spiral::US5 = match &v1608 {
                            Spiral::US7::US7_0(v1608_0_0) => {
                                Spiral::US5::US5_0(fable_library_rust::String_::fromString(
                                    match &v1608 {
                                        Spiral::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ))
                            }
                            _ => Spiral::US5::US5_1,
                        };
                        let v1685: string = defaultValue(
                            match &v1679 {
                                Spiral::US5::US5_0(v1679_0_0) => match &v1679 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => string(""),
                            },
                            v1672,
                        );
                        let v1690: () = {
                            Spiral::closure61(v1607, v1685.clone(), ());
                            ()
                        };
                        LrcPtr::new((v1607, v1685))
                    }
                }))();
                _capture_v175.set(Some(x_5))
            }
            {
                let v1742: LrcPtr<(i32, string)> = match &_capture_v175.get().clone() {
                    None => panic!("{}", string("base.capture / _capture_v175=None"),),
                    Some(_capture_v175_0_0) => _capture_v175_0_0.clone(),
                };
                let _run_target_args__v15: (i32, string) = (v1742.0.clone(), v1742.1.clone());
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
            let v576: DateTime = {
                let _arg: DateTime = DateTime::unixEpoch();
                _arg.toUniversalTime()
            };
            let v586: DateTime = {
                let _arg_1: DateTime = DateTime::specifyKind(v1_1, 2_i32);
                _arg_1.toUniversalTime()
            };
            let v678: i64 = ((v586.ticks()) - (v576.ticks())) / 10_i64;
            let v680: Option<chrono::DateTime<chrono::Utc>> =
                chrono::DateTime::from_timestamp_micros(v678);
            let v699: Spiral::US40 =
                defaultValue(Spiral::US40::US40_1, map(Spiral::method212(), v680));
            let v719: Spiral::US5 = match &v699 {
                Spiral::US40::US40_0(v699_0_0) => {
                    let v705: chrono::NaiveDateTime = match &v699 {
                        Spiral::US40::US40_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone()
                    .naive_utc();
                    let v707: chrono::DateTime<chrono::Local> =
                        chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &v705);
                    let v709: string = string("r#\"%Y%m%d-%H%M-%S%f\"#");
                    let v710: &str = r#"%Y%m%d-%H%M-%S%f"#;
                    let v712: std::string::String = v707.format(v710).to_string();
                    let v714: string = fable_library_rust::String_::fromString(v712);
                    Spiral::US5::US5_0(sprintf!(
                        "{}-{}-{}",
                        getSlice(v714.clone(), Some(0_i32), Some(17_i32)),
                        getSlice(v714.clone(), Some(18_i32), Some(21_i32)),
                        getCharAt(v714, 22_i32)
                    ))
                }
                _ => Spiral::US5::US5_1,
            };
            let v723: string = match &v719 {
                Spiral::US5::US5_0(v719_0_0) => match &v719 {
                    Spiral::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                _ => string(""),
            };
            let v730: LrcPtr<TimeZoneInfo> = std::sync::Arc::new(
                chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64,
            );
            let v768: i64 = v586.ticks();
            let v803: string =
                string("chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))");
            let v944: TimeSpan = TimeSpan::new_ticks(chrono::FixedOffset::local_minus_utc(
                &chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(
                    &chrono::DateTime::from_timestamp_nanos(v768),
                )),
            ) as i64);
            let v959: u8 = if (v944.hours()) > 0_i32 { 1_u8 } else { 0_u8 };
            let v960: string = Spiral::method213();
            let v1129: string = v944.toString(v960);
            let v1184: string = sprintf!(
                "{}{}{}",
                v959,
                getSlice(v1129.clone(), Some(0_i32), Some(1_i32)),
                getSlice(v1129, Some(3_i32), Some(4_i32))
            );
            let v1187: string = toString(v0_1);
            parse(concat(new_array(&[
                v723.clone(),
                v1184.clone(),
                getSlice(
                    v1187.clone(),
                    Some((length(v723)) + (length(v1184))),
                    Some((length(v1187)) - 1_i32),
                ),
            ])))
        }
        pub fn method216(v0_1: string, v1_1: string) {
            if (Spiral::method38(v0_1.clone())) == false {
                let v4: LrcPtr<dyn IDisposable> = Spiral::method73(v0_1.clone());
                ()
            }
            {
                let v9: string = defaultValue(string(""), Spiral::method40(v1_1.clone()));
                if (Spiral::method38(v9.clone())) == false {
                    let v14: LrcPtr<dyn IDisposable> = Spiral::method73(v9);
                    ()
                }
                if if Spiral::method38(v1_1.clone()) {
                    let v16: Result<std::path::PathBuf, std::io::Error> =
                        Spiral::method46(v1_1.clone());
                    v16.is_err()
                } else {
                    false
                } {
                    Spiral::method84(true, v1_1.clone());
                }
                if (Spiral::method38(v1_1.clone())) == false {
                    let v32: bool = true;
                    #[cfg(windows)]
                    std::os::windows::fs::symlink_dir(&*v0_1.clone(), &*v1_1.clone()).unwrap();
                    let v34: bool = true;
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
            let v165: Result<string, string> = match &v4 {
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
                v165.ok(),
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
                                let v101: bool = true;
                                LrcPtr::new((v93, v95))
                            })
                            .map(|x| std::sync::Arc::try_unwrap(x).unwrap_or_else(|x| (*x).clone()))
                            .collect();
                        let v103: std::collections::HashMap<string, string> = _regex_captures;
                        let v105: bool = true;
                        v103
                    })
                    .collect::<Vec<_>>();
                let v107: Vec<std::collections::HashMap<string, string>> = _regex_captures;
                let v109: bool = true;
                v107
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
                    let v20: Result<string, string> = match &v0_1.get().clone() {
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
                        v20.ok(),
                    );
                    let v38: string = patternInput.1.clone();
                    let v37: i32 = patternInput.0.clone();
                    let v202: Spiral::US41 = if (contains(
                        v38.clone(),
                        string("failed to load manifest for workspace member"),
                    )) == false
                    {
                        if (v37) == 0_i32 {
                            Spiral::US41::US41_0(v37, v38.clone())
                        } else {
                            Spiral::US41::US41_1(v37, v38.clone())
                        }
                    } else {
                        let v51: Result<regex::Regex, regex::Error> =
                            regex::Regex::new(&string("failed to read `(?<a>.*?Cargo.toml)`"));
                        let v67: Vec<std::collections::HashMap<string, string>> =
                            Spiral::method232(v38.clone(), v51.unwrap());
                        let v70: Option<std::collections::HashMap<string, string>> = tryItem(
                            0_i32,
                            fable_library_rust::NativeArray_::array_from(v67.clone()),
                        );
                        let v89: Spiral::US42 =
                            defaultValue(Spiral::US42::US42_1, map(Spiral::method233(), v70));
                        let v122: Spiral::US43 = match &v89 {
                            Spiral::US42::US42_0(v89_0_0) => {
                                let v94: string = Spiral::method234();
                                let v96: Option<string> = std::collections::HashMap::get(
                                    &match &v89 {
                                        Spiral::US42::US42_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    &v94,
                                )
                                .map(|x| x)
                                .cloned();
                                Spiral::US43::US43_0(defaultValue(
                                    Spiral::US5::US5_1,
                                    map(Spiral::method6(), v96),
                                ))
                            }
                            _ => Spiral::US43::US43_1,
                        };
                        let v129: Spiral::US5 = if let Spiral::US43::US43_0(v122_0_0) = &v122 {
                            let v123: Spiral::US5 = v122_0_0.clone();
                            if let Spiral::US5::US5_0(v123_0_0) = &v123 {
                                Spiral::US5::US5_0(v123_0_0.clone())
                            } else {
                                Spiral::US5::US5_1
                            }
                        } else {
                            Spiral::US5::US5_1
                        };
                        match &v129 {
                            Spiral::US5::US5_0(v129_0_0) => {
                                let v131: string = match &v129 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone();
                                if (Spiral::method37(v131.clone())) == false {
                                    let v141: LrcPtr<dyn IDisposable> = Spiral::method73(
                                        defaultValue(string(""), Spiral::method40(v131.clone())),
                                    );
                                    let v145: DateTime = DateTime::now();
                                    let v168: string =
                                        toString(Spiral::method211(new_guid(), v145));
                                    let v193: string =
                                                     append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                            (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                v168.clone(),
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
                                                                                                v168,
                                                                                                string("\"")]))))),
                                                                    string("\n"))),
                                                            string("path = \"spiral.rs\""));
                                    std::fs::write(&*v131, &*v193).unwrap();
                                    ()
                                }
                                if (v37) == 0_i32 {
                                    Spiral::US41::US41_0(v37, v38.clone())
                                } else {
                                    Spiral::US41::US41_1(v37, v38.clone())
                                }
                            }
                            _ => Spiral::US41::US41_1(v37, v38.clone()),
                        }
                    };
                    let patternInput_1: (bool, i32, string) = match &v202 {
                        Spiral::US41::US41_0(v202_0_0, v202_0_1) => {
                            (false, v202_0_0.clone(), v202_0_1.clone())
                        }
                        Spiral::US41::US41_1(v202_1_0, v202_1_1) => {
                            (true, v202_1_0.clone(), v202_1_1.clone())
                        }
                    };
                    let v212: string = patternInput_1.2.clone();
                    let v211: i32 = patternInput_1.1.clone();
                    let v210: bool = patternInput_1.0.clone();
                    if if (v210) == false {
                        true
                    } else {
                        (v2.get().clone()) >= 3_u8
                    } {
                        (v211, v212.clone())
                    } else {
                        let v218: () = {
                            Spiral::closure92(v2.get().clone(), v211, v212, v210, ());
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
                        let v26: Spiral::US44 = match &v20 {
                            Err(v20_1_0) => v24(v20_1_0.clone()),
                            _ => v23(),
                        };
                        match &v26 {
                            Spiral::US44::US44_0 => (),
                            Spiral::US44::US44_1(v26_1_0) => {
                                let v32: () = {
                                    Spiral::closure107(
                                        match &v26 {
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
            let v174: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v155));
            match &v174 {
                Spiral::US5::US5_0(v174_0_0) => match &v174 {
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
                            let v39: Spiral::US45 = match &v33 {
                                Err(v33_1_0) => v37(v33_1_0.clone()),
                                Ok(v33_0_0) => v36(v33_0_0.clone()),
                            };
                            let v272: Spiral::US46 = if let Spiral::US45::US45_0(v39_0_0) = &v39 {
                                if (std::fs::FileType::is_dir(&v39_0_0.clone())) == false {
                                    Spiral::US46::US46_0
                                } else {
                                    let v48: std::path::PathBuf =
                                        async_walkdir::DirEntry::path(&v1_1.clone());
                                    let v55: std::path::Display = v48.display();
                                    let v88: std::string::String = format!("{}", v55);
                                    let v116: string = fable_library_rust::String_::fromString(v88);
                                    if (startsWith3(
                                        Spiral::method256(v116.clone()),
                                        v0_1.clone(),
                                        false,
                                    )) == false
                                    {
                                        Spiral::US46::US46_1
                                    } else {
                                        let v124: Option<string> = Spiral::method40(v116);
                                        let v143: Spiral::US5 = defaultValue(
                                            Spiral::US5::US5_1,
                                            map(Spiral::method6(), v124),
                                        );
                                        if let Spiral::US5::US5_0(v143_0_0) = &v143 {
                                            if (contains(v143_0_0.clone(), v0_1.clone())) == false {
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
                                let v161: std::path::PathBuf = async_walkdir::DirEntry::path(&v1_1);
                                let v168: std::path::Display = v161.display();
                                let v201: std::string::String = format!("{}", v168);
                                let v229: string = fable_library_rust::String_::fromString(v201);
                                if (startsWith3(
                                    Spiral::method256(v229.clone()),
                                    v0_1.clone(),
                                    false,
                                )) == false
                                {
                                    Spiral::US46::US46_1
                                } else {
                                    let v237: Option<string> = Spiral::method40(v229);
                                    let v256: Spiral::US5 = defaultValue(
                                        Spiral::US5::US5_1,
                                        map(Spiral::method6(), v237),
                                    );
                                    if let Spiral::US5::US5_0(v256_0_0) = &v256 {
                                        if (contains(v256_0_0.clone(), v0_1)) == false {
                                            Spiral::US46::US46_2
                                        } else {
                                            Spiral::US46::US46_1
                                        }
                                    } else {
                                        Spiral::US46::US46_1
                                    }
                                }
                            };
                            let v275: string = string("}");
                            let v280: bool = true;
                            let _fix_closure_v277 = v272;
                            let v287: string = append(
                                (append(
                                    (append(
                                        (append(string("true; _fix_closure_v277 "), (v275))),
                                        string("); "),
                                    )),
                                    string(""),
                                )),
                                string(" // rust.fix_closure\'"),
                            );
                            let v288: bool = true;
                            _fix_closure_v277
                        },
                    ); // rust.fix_closure';
                    let v290 = __future_init;
                    let v292: std::pin::Pin<
                        Box<dyn std::future::Future<Output = Spiral::US46> + Send>,
                    > = v290;
                    let v294: Spiral::US46 = v292.await;
                    let v303: async_walkdir::Filtering = match &v294 {
                        Spiral::US46::US46_0 => async_walkdir::Filtering::Ignore,
                        Spiral::US46::US46_1 => async_walkdir::Filtering::IgnoreDir,
                        _ => async_walkdir::Filtering::Continue,
                    };
                    let v304: string = string("}");
                    let v309: bool = true;
                    let _fix_closure_v306 = v303;
                    let v316: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v306 "), (v304))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v317: bool = true;
                    _fix_closure_v306
                },
            ); // rust.fix_closure';
            let v319 = __future_init;
            v319
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
            let v21: Spiral::US47 = match &v15 {
                Err(v15_1_0) => v19(v15_1_0.clone()),
                Ok(v15_0_0) => v18(v15_0_0.clone()),
            };
            let v233: Spiral::US48 = match &v21 {
                Spiral::US47::US47_0(v21_0_0) => {
                    let v26: std::path::PathBuf = async_walkdir::DirEntry::path(&v21_0_0.clone());
                    let v33: std::path::Display = v26.display();
                    let v66: std::string::String = format!("{}", v33);
                    let v94: string = fable_library_rust::String_::fromString(v66);
                    let v95: string =
                        concat(new_array(&[v0_1.clone(), string("\\.(?<a>[-\\d\\w.]+)$")]));
                    let v97: Result<regex::Regex, regex::Error> = regex::Regex::new(&v95);
                    let v113: Vec<std::collections::HashMap<string, string>> =
                        Spiral::method232(v94.clone(), v97.unwrap());
                    let v116: Option<std::collections::HashMap<string, string>> = tryItem(
                        0_i32,
                        fable_library_rust::NativeArray_::array_from(v113.clone()),
                    );
                    let v135: Spiral::US42 =
                        defaultValue(Spiral::US42::US42_1, map(Spiral::method233(), v116));
                    let v168: Spiral::US43 = match &v135 {
                        Spiral::US42::US42_0(v135_0_0) => {
                            let v140: string = Spiral::method234();
                            let v142: Option<string> = std::collections::HashMap::get(
                                &match &v135 {
                                    Spiral::US42::US42_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                &v140,
                            )
                            .map(|x| x)
                            .cloned();
                            Spiral::US43::US43_0(defaultValue(
                                Spiral::US5::US5_1,
                                map(Spiral::method6(), v142),
                            ))
                        }
                        _ => Spiral::US43::US43_1,
                    };
                    let v175: Spiral::US5 = if let Spiral::US43::US43_0(v168_0_0) = &v168 {
                        let v169: Spiral::US5 = v168_0_0.clone();
                        if let Spiral::US5::US5_0(v169_0_0) = &v169 {
                            Spiral::US5::US5_0(v169_0_0.clone())
                        } else {
                            Spiral::US5::US5_1
                        }
                    } else {
                        Spiral::US5::US5_1
                    };
                    match &v175 {
                        Spiral::US5::US5_0(v175_0_0) => Spiral::US48::US48_0(
                            v94.clone(),
                            match &v175 {
                                Spiral::US5::US5_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => Spiral::US48::US48_1,
                    }
                }
                Spiral::US47::US47_1(v21_1_0) => {
                    let v184: () = {
                        Spiral::closure115(v21_1_0.clone(), ());
                        ()
                    };
                    Spiral::US48::US48_1
                }
            };
            match &v233 {
                Spiral::US48::US48_0(v233_0_0, v233_0_1) => Some((
                    match &v233 {
                        Spiral::US48::US48_0(x, _) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    match &v233 {
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
                    let v30: Spiral::US6 =
                        defaultValue(Spiral::US6::US6_1, map(Spiral::method21(), v10));
                    let v6294: Array<(string, string)> = if let Spiral::US6::US6_0(
                        v30_0_0,
                        v30_0_1,
                    ) = &v30
                    {
                        let v35: clap::ArgMatches = v30_0_1.clone();
                        let v34: std::string::String = v30_0_0.clone();
                        if (fable_library_rust::String_::fromString(v34.clone())) == string("gleam")
                        {
                            let v39: string = Spiral::method22();
                            let v46: &str = &*v39;
                            let v74: Option<std::string::String> =
                                clap::ArgMatches::get_one(&v35.clone(), v46).cloned();
                            let v93: Spiral::US7 =
                                defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v74));
                            let v100: std::string::String = match &v93 {
                                Spiral::US7::US7_0(v93_0_0) => match &v93 {
                                    Spiral::US7::US7_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => panic!("{}", string("Option does not have a value."),),
                            };
                            let v102: string = fable_library_rust::String_::fromString(v100);
                            let v103: string = Spiral::method24();
                            let v110: &str = &*v103;
                            let v138: Option<Vec<std::string::String>> =
                                clap::ArgMatches::get_many(&v35.clone(), v110)
                                    .map(|x| x.cloned().into_iter().collect());
                            let v157: Spiral::US8 =
                                defaultValue(Spiral::US8::US8_1, map(Spiral::method25(), v138));
                            let v163: Vec<std::string::String> =
                                new_empty::<std::string::String>().to_vec();
                            let v166: Vec<std::string::String> = match &v157 {
                                Spiral::US8::US8_0(v157_0_0) => match &v157 {
                                    Spiral::US8::US8_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => v163.clone(),
                            };
                            let v178: Result<Vec<u8>, std::io::Error> =
                                std::fs::read(&*v102.clone());
                            let v223: Vec<u8> = Spiral::method26(v178.unwrap());
                            let v225: Result<std::string::String, std::string::FromUtf8Error> =
                                std::string::String::from_utf8(v223);
                            let v229: std::string::String = v225.unwrap();
                            let v264: string = fable_library_rust::String_::fromString(v229);
                            let v272: string =
                                Spiral::method28(Spiral::method27(string("gleam"), v264.clone()));
                            let v274: Spiral::US5 = Spiral::method34(Spiral::method33());
                            let v280: Spiral::US5 = match &v274 {
                                Spiral::US5::US5_0(v274_0_0) => Spiral::US5::US5_0(
                                    match &v274 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => Spiral::method34(string(
                                    "c:\\home\\git\\polyglot\\target\\Builder\\spiral",
                                )),
                            };
                            let v286: Spiral::US5 = match &v280 {
                                Spiral::US5::US5_0(v280_0_0) => Spiral::US5::US5_0(
                                    match &v280 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => Spiral::method34(string("/workspaces")),
                            };
                            let v290: string = match &v286 {
                                Spiral::US5::US5_0(v286_0_0) => match &v286 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => panic!("{}", string("Option does not have a value."),),
                            };
                            let v305: string = Spiral::method35(
                                if string("deps") == (Spiral::method54(v290.clone())) {
                                    let v298: Spiral::US5 = Spiral::method34(
                                        Spiral::method40(v290.clone()).clone().unwrap(),
                                    );
                                    match &v298 {
                                        Spiral::US5::US5_0(v298_0_0) => match &v298 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => panic!("{}", string("Option does not have a value."),),
                                    }
                                } else {
                                    v290
                                },
                                string("polyglot"),
                            );
                            let v309: string = toLower(Spiral::method33());
                            let v314: string = toLower(v305);
                            let v323: Spiral::US10 = if startsWith3(v309, v314.clone(), false) {
                                Spiral::US10::US10_1(v314.clone())
                            } else {
                                Spiral::US10::US10_0(v314)
                            };
                            let v335: Result<string, string> = match &v323 {
                                Spiral::US10::US10_0(v323_0_0) => {
                                    Ok::<string, string>(v323_0_0.clone())
                                }
                                Spiral::US10::US10_1(v323_1_0) => {
                                    Err::<string, string>(v323_1_0.clone())
                                }
                            };
                            let v337: bool = true;
                            let _result_unwrap_or_else = v335.unwrap_or_else(|x| {
                                //;
                                let v339: string = x;
                                let v341: bool = true;
                                v339
                            });
                            let v343: string = _result_unwrap_or_else;
                            let v352: string = Spiral::method35(
                                defaultValue(string(""), Spiral::method40(v102.clone())),
                                string(".."),
                            );
                            let v354: string = Spiral::method35(v352.clone(), string("gleam.toml"));
                            let v357: Array<string> = new_array(&[
                                string("gleam_stdlib=\">=0.55.0 and <1.0.0\""),
                                string("gary=\">=1.1.0 and <2.0.0\""),
                            ]);
                            let v359: Vec<string> = v357.to_vec();
                            let v361: bool = true;
                            let _vec_map: Vec<_> = v359
                                .into_iter()
                                .map(|x| {
                                    //;
                                    let v363: string = x;
                                    let v370: &str = &*v363;
                                    let v403: std::string::String = String::from(v370);
                                    let v431: bool = true;
                                    v403
                                })
                                .collect::<Vec<_>>();
                            let v433: Vec<std::string::String> = _vec_map;
                            let v434: Vec<std::string::String> = Spiral::method68(v166);
                            let v435: Vec<std::string::String> = Spiral::method69(v433);
                            let v437: bool = true;
                            let mut v435 = v435;
                            let v439: bool = true;
                            v435.extend(v434);
                            let v441: Vec<std::string::String> = v435;
                            let v443: bool = true;
                            let _vec_map: Vec<_> = v441
                                .into_iter()
                                .map(|x| {
                                    //;
                                    let v445: std::string::String = x;
                                    let v447: string =
                                        fable_library_rust::String_::fromString(v445);
                                    let v464: string = if contains(v447.clone(), string("=")) {
                                        v447.clone()
                                    } else {
                                        if endsWith3(v447.clone(), string("]"), false) {
                                            concat(new_array(&[
                                                replace(
                                                    v447.clone(),
                                                    string("["),
                                                    string("={version=\'*\',features=["),
                                                ),
                                                string("}"),
                                            ]))
                                        } else {
                                            concat(new_array(&[v447, string("=\'*\'")]))
                                        }
                                    };
                                    let v466: bool = true;
                                    v464
                                })
                                .collect::<Vec<_>>();
                            let v468: Vec<string> = _vec_map;
                            let v470: Array<string> =
                                fable_library_rust::NativeArray_::array_from(v468.clone());
                            let _let__v474: LrcPtr<dyn IEnumerable_1<string>> =
                                delay(Func0::new({
                                    let v470 = v470.clone();
                                    move || {
                                        map_1(
                                            Func1::new({
                                                let v470 = v470.clone();
                                                move |i: i32| v470[i].clone()
                                            }),
                                            rangeNumeric(
                                                0_i32,
                                                1_i32,
                                                (get_Count(v470.clone())) - 1_i32,
                                            ),
                                        )
                                    }
                                }));
                            Spiral::method71(
                                v354,
                                append(
                                    string(
                                        "name = \"main\"\ntarget = \"erlang\"\n\n[dependencies]\n",
                                    ),
                                    (join(Spiral::method70(), toArray_1(_let__v474))),
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
                                    Some(v352.clone()),
                                );
                                let v516: i32 = patternInput.0.clone();
                                let patternInput_4: (
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                ) = if (v516) != 0_i32 {
                                    let v524: () = {
                                        Spiral::closure70(
                                            v102.clone(),
                                            patternInput.1.clone(),
                                            v516,
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
                                    let v575: string = concat(new_array(&[
                                        string("gleam run --no-print-progress \""),
                                        v102.clone(),
                                        string("\""),
                                    ]));
                                    let v579: Array<(string, string)> = new_array(&[
                                        (string("TRACE_LEVEL"), string("")),
                                        (string("GLEAM_LOG"), string("")),
                                        (string("GLEAM_LOG_NOCOLOUR"), string("")),
                                    ]);
                                    let patternInput_1: (i32, string) = Spiral::method96(
                                        v575.clone(),
                                        None::<CancellationToken>,
                                        v579.clone(),
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
                                        Some(v352),
                                    );
                                    let v591: string = patternInput_1.1.clone();
                                    let v590: i32 = patternInput_1.0.clone();
                                    let v592: i32 = get_Count(v579.clone());
                                    let v593: Array<string> = new_init(&string(""), v592);
                                    let v594: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method31(v592, v594.clone()) {
                                        let v596: i32 = v594.l0.get().clone();
                                        let patternInput_2: (string, string) = v579[v596].clone();
                                        let v599: string = sprintf!(
                                            "$env:{}=\'\'{}\'\'",
                                            patternInput_2.0.clone(),
                                            patternInput_2.1.clone()
                                        );
                                        v593.get_mut()[v596 as usize] = v599;
                                        {
                                            let v600: i32 = (v596) + 1_i32;
                                            v594.l0.set(v600);
                                            ()
                                        }
                                    }
                                    {
                                        let v612: string = sprintf!(
                                            "pwsh -c \'{}; {}\'",
                                            join(string(";"), toArray_1(ofArray_1(v593.clone()))),
                                            v575
                                        );
                                        let patternInput_3: (
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                        ) = if (v590) == 0_i32 {
                                            let result: LrcPtr<MutCell<Spiral::US5>> =
                                                refCell(Spiral::US5::US5_1);
                                            try_catch(
                                                || {
                                                    result.set(Spiral::closure71(
                                                        (),
                                                        Spiral::closure72(v591.clone(), ()),
                                                    ))
                                                },
                                                |ex: LrcPtr<Exception>| {
                                                    result.set(Spiral::closure73(
                                                        v102.clone(),
                                                        v591.clone(),
                                                        v612.clone(),
                                                        ex.clone(),
                                                    ))
                                                },
                                            );
                                            {
                                                let v619: Spiral::US5 = result.get().clone();
                                                let v630: Option<string> = match &v619 {
                                                    Spiral::US5::US5_0(v619_0_0) => Some(
                                                        match &v619 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    ),
                                                    _ => None::<string>,
                                                };
                                                (
                                                    Spiral::US5::US5_0(string("gleam")),
                                                    Spiral::US5::US5_0(v264),
                                                    Spiral::US5::US5_0(v102.clone()),
                                                    Spiral::US5::US5_0(v630.unwrap()),
                                                )
                                            }
                                        } else {
                                            let v639: () = {
                                                Spiral::closure75(v102, v591, v590, v612, ());
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
                                let v697: Spiral::US5 = patternInput_4.3.clone();
                                let v695: Spiral::US5 = patternInput_4.1.clone();
                                let v694: Spiral::US5 = patternInput_4.0.clone();
                                let v710: Array<(string, string)> = new_array(&[
                                    (
                                        string("extension"),
                                        match &v694 {
                                            Spiral::US5::US5_0(v694_0_0) => match &v694 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("code"),
                                        match &v695 {
                                            Spiral::US5::US5_0(v695_0_0) => match &v695 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("output"),
                                        match &v697 {
                                            Spiral::US5::US5_0(v697_0_0) => match &v697 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                ]);
                                let v712: Vec<(string, string)> = v710.to_vec();
                                let v715: bool = true;
                                let _func1_from_v713 = Func1::from(move |value| {
                                    //;
                                    let patternInput_5: (string, string) = value;
                                    let v725: &str = &*patternInput_5.0.clone();
                                    let v758: std::string::String = String::from(v725);
                                    let v791: &str = &*patternInput_5.1.clone();
                                    let v824: std::string::String = String::from(v791);
                                    let v857: bool = true;
                                    LrcPtr::new((v758, v824)) /*;
                                                              let v859: bool = */
                                }); //;
                                let v861: Func1<
                                    (string, string),
                                    LrcPtr<(std::string::String, std::string::String)>,
                                > = _func1_from_v713;
                                let v864: Vec<LrcPtr<(std::string::String, std::string::String)>> =
                                    v712.into_iter()
                                        .map(|x| {
                                            Func1::new({
                                                let v861 = v861.clone();
                                                move |arg10_0040_3: (string, string)| {
                                                    Spiral::closure76(v861.clone(), arg10_0040_3)
                                                }
                                            })(x.clone())
                                        })
                                        .collect::<Vec<_>>();
                                let v865: string =
                                string("std::collections::BTreeMap::from_iter(v864.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                                let v866: std::collections::BTreeMap<
                                    std::string::String,
                                    std::string::String,
                                > = std::collections::BTreeMap::from_iter(
                                    v864.iter()
                                        .map(|x| x.as_ref())
                                        .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                                );
                                let v868: Result<std::string::String, serde_json::Error> =
                                    serde_json::to_string(&v866);
                                let v872: std::string::String = v868.unwrap();
                                new_array(&[(
                                    string("command_result"),
                                    fable_library_rust::String_::fromString(v872),
                                )])
                            }
                        } else {
                            if (fable_library_rust::String_::fromString(v34.clone()))
                                == string("cuda")
                            {
                                let v891: string = Spiral::method177();
                                let v898: &str = &*v891;
                                let v926: Option<std::string::String> =
                                    clap::ArgMatches::get_one(&v35.clone(), v898).cloned();
                                let v945: Spiral::US7 =
                                    defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v926));
                                let v952: std::string::String = match &v945 {
                                    Spiral::US7::US7_0(v945_0_0) => match &v945 {
                                        Spiral::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => panic!("{}", string("Option does not have a value."),),
                                };
                                let v954: string = fable_library_rust::String_::fromString(v952);
                                let v955: string = Spiral::method178();
                                let v962: &str = &*v955;
                                let v990: Option<std::string::String> =
                                    clap::ArgMatches::get_one(&v35.clone(), v962).cloned();
                                let v1009: Spiral::US7 =
                                    defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v990));
                                let v1038: Spiral::US33 = match &v1009 {
                                    Spiral::US7::US7_0(v1009_0_0) => {
                                        let v1015: string = fable_library_rust::String_::fromString(
                                            match &v1009 {
                                                Spiral::US7::US7_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        );
                                        let v1020: Spiral::US34 =
                                            if string("Pip") == (v1015.clone()) {
                                                Spiral::US34::US34_0(Spiral::US35::US35_0)
                                            } else {
                                                Spiral::US34::US34_1
                                            };
                                        Spiral::US33::US33_0(match &v1020 {
                                            Spiral::US34::US34_0(v1020_0_0) => {
                                                Spiral::US34::US34_0(
                                                    match &v1020 {
                                                        Spiral::US34::US34_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                )
                                            }
                                            _ => {
                                                let v1027: Spiral::US34 =
                                                    if string("Poetry") == (v1015.clone()) {
                                                        Spiral::US34::US34_0(Spiral::US35::US35_1)
                                                    } else {
                                                        Spiral::US34::US34_1
                                                    };
                                                match &v1027 {
                                                    Spiral::US34::US34_0(v1027_0_0) => {
                                                        Spiral::US34::US34_0(
                                                            match &v1027 {
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
                                let v1045: Spiral::US34 =
                                    if let Spiral::US33::US33_0(v1038_0_0) = &v1038 {
                                        let v1039: Spiral::US34 = v1038_0_0.clone();
                                        if let Spiral::US34::US34_0(v1039_0_0) = &v1039 {
                                            Spiral::US34::US34_0(v1039_0_0.clone())
                                        } else {
                                            Spiral::US34::US34_1
                                        }
                                    } else {
                                        Spiral::US34::US34_1
                                    };
                                let v1049: Spiral::US35 = match &v1045 {
                                    Spiral::US34::US34_0(v1045_0_0) => match &v1045 {
                                        Spiral::US34::US34_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => Spiral::US35::US35_0,
                                };
                                let v1050: string = Spiral::method24();
                                let v1057: &str = &*v1050;
                                let v1085: Option<Vec<std::string::String>> =
                                    clap::ArgMatches::get_many(&v35.clone(), v1057)
                                        .map(|x| x.cloned().into_iter().collect());
                                let v1104: Spiral::US8 = defaultValue(
                                    Spiral::US8::US8_1,
                                    map(Spiral::method25(), v1085),
                                );
                                let v1110: Vec<std::string::String> =
                                    new_empty::<std::string::String>().to_vec();
                                let v1113: Vec<std::string::String> = match &v1104 {
                                    Spiral::US8::US8_0(v1104_0_0) => match &v1104 {
                                        Spiral::US8::US8_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => v1110.clone(),
                                };
                                let v1125: Result<Vec<u8>, std::io::Error> =
                                    std::fs::read(&*v954.clone());
                                let v1170: Vec<u8> = Spiral::method26(v1125.unwrap());
                                let v1172: Result<std::string::String, std::string::FromUtf8Error> =
                                    std::string::String::from_utf8(v1170);
                                let v1176: std::string::String = v1172.unwrap();
                                let v1189: string = fable_library_rust::String_::fromString(v1176);
                                let v1218: Spiral::US5 = Spiral::method34(Spiral::method33());
                                let v1224: Spiral::US5 = match &v1218 {
                                    Spiral::US5::US5_0(v1218_0_0) => Spiral::US5::US5_0(
                                        match &v1218 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => Spiral::method34(string(
                                        "c:\\home\\git\\polyglot\\target\\Builder\\spiral",
                                    )),
                                };
                                let v1230: Spiral::US5 = match &v1224 {
                                    Spiral::US5::US5_0(v1224_0_0) => Spiral::US5::US5_0(
                                        match &v1224 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => Spiral::method34(string("/workspaces")),
                                };
                                let v1234: string = match &v1230 {
                                    Spiral::US5::US5_0(v1230_0_0) => match &v1230 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => panic!("{}", string("Option does not have a value."),),
                                };
                                let v1249: string = Spiral::method35(
                                    if string("deps") == (Spiral::method54(v1234.clone())) {
                                        let v1242: Spiral::US5 = Spiral::method34(
                                            Spiral::method40(v1234.clone()).clone().unwrap(),
                                        );
                                        match &v1242 {
                                            Spiral::US5::US5_0(v1242_0_0) => match &v1242 {
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
                                        v1234
                                    },
                                    string("polyglot"),
                                );
                                let v1253: string = toLower(Spiral::method33());
                                let v1258: string = toLower(v1249);
                                let v1267: Spiral::US10 =
                                    if startsWith3(v1253, v1258.clone(), false) {
                                        Spiral::US10::US10_1(v1258.clone())
                                    } else {
                                        Spiral::US10::US10_0(v1258)
                                    };
                                let v1279: Result<string, string> = match &v1267 {
                                    Spiral::US10::US10_0(v1267_0_0) => {
                                        Ok::<string, string>(v1267_0_0.clone())
                                    }
                                    Spiral::US10::US10_1(v1267_1_0) => {
                                        Err::<string, string>(v1267_1_0.clone())
                                    }
                                };
                                let v1281: bool = true;
                                let _result_unwrap_or_else = v1279.unwrap_or_else(|x| {
                                    //;
                                    let v1283: string = x;
                                    let v1285: bool = true;
                                    v1283
                                });
                                let v1287: string = _result_unwrap_or_else;
                                let v1292: string =
                                    defaultValue(string(""), Spiral::method40(v954.clone()));
                                let v1300: string = match &v1049 {
                                    Spiral::US35::US35_1 => {
                                        Spiral::method35(v1292.clone(), string("pyproject.toml"))
                                    }
                                    _ => {
                                        Spiral::method35(v1292.clone(), string("requirements.txt"))
                                    }
                                };
                                let v1302: bool = true;
                                let _vec_map: Vec<_> = v1113
                                    .into_iter()
                                    .map(|x| {
                                        //;
                                        let v1304: std::string::String = x;
                                        let v1306: string =
                                            fable_library_rust::String_::fromString(v1304);
                                        let v1323: string = if contains(v1306.clone(), string("="))
                                        {
                                            v1306.clone()
                                        } else {
                                            if endsWith3(v1306.clone(), string("]"), false) {
                                                concat(new_array(&[
                                                    replace(
                                                        v1306.clone(),
                                                        string("["),
                                                        string("={version=\'*\',features=["),
                                                    ),
                                                    string("}"),
                                                ]))
                                            } else {
                                                concat(new_array(&[v1306, string("=\'*\'")]))
                                            }
                                        };
                                        let v1325: bool = true;
                                        v1323
                                    })
                                    .collect::<Vec<_>>();
                                let v1327: Vec<string> = _vec_map;
                                let v1329: Array<string> =
                                    fable_library_rust::NativeArray_::array_from(v1327.clone());
                                let _let__v1333: LrcPtr<dyn IEnumerable_1<string>> =
                                    delay(Func0::new({
                                        let v1329 = v1329.clone();
                                        move || {
                                            map_1(
                                                Func1::new({
                                                    let v1329 = v1329.clone();
                                                    move |i_1: i32| v1329[i_1].clone()
                                                }),
                                                rangeNumeric(
                                                    0_i32,
                                                    1_i32,
                                                    (get_Count(v1329.clone())) - 1_i32,
                                                ),
                                            )
                                        }
                                    }));
                                let v1346: string =
                                    join(Spiral::method70(), toArray_1(_let__v1333));
                                let patternInput_6: (i32, string) = if (v1346.clone()) == string("")
                                {
                                    (0_i32, string(""))
                                } else {
                                    Spiral::method71(v1300,
                                                     match &v1049 {
                                                         Spiral::US35::US35_1
                                                         =>
                                                         append((append((append((append((append((append((append((append((append(string("[tool.poetry]\nname = \"test\"\nversion = \"0.0.1\"\ndescription = \"\"\nauthors = []\n\n[tool.poetry.dependencies]\npython=\"~3.12\"\n"),
                                                                                                                                (v1346.clone()))),
                                                                                                                        string("\n"))),
                                                                                                                string(""))),
                                                                                                        string("\n"))),
                                                                                                string("[build-system]"))),
                                                                                        string("\n"))),
                                                                                string("requires = [\"poetry-core\"]"))),
                                                                        string("\n"))),
                                                                string("build-backend = \"poetry.core.masonry.api\"")),
                                                         _ => v1346.clone(),
                                                     });
                                    Spiral::method96(
                                        match &v1049 {
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
                                        Some(v1292.clone()),
                                    )
                                };
                                let v1407: i32 = patternInput_6.0.clone();
                                let patternInput_10: (
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                ) = if (v1407) != 0_i32 {
                                    let v1415: () = {
                                        Spiral::closure77(
                                            v1049.clone(),
                                            v954.clone(),
                                            patternInput_6.1.clone(),
                                            v1407,
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
                                    let v1470: string = match &v1049 {
                                        Spiral::US35::US35_1 => concat(new_array(&[
                                            string("poetry run python \""),
                                            v954.clone(),
                                            string("\""),
                                        ])),
                                        _ => concat(new_array(&[
                                            string("python \""),
                                            v954.clone(),
                                            string("\""),
                                        ])),
                                    };
                                    let v1473: Array<(string, string)> =
                                        new_array(&[(string("TRACE_LEVEL"), string("Verbose"))]);
                                    let patternInput_7: (i32, string) = Spiral::method96(
                                        v1470.clone(),
                                        None::<CancellationToken>,
                                        v1473.clone(),
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
                                        Some(v1292.clone()),
                                    );
                                    let v1485: string = patternInput_7.1.clone();
                                    let v1484: i32 = patternInput_7.0.clone();
                                    let v1486: i32 = get_Count(v1473.clone());
                                    let v1487: Array<string> = new_init(&string(""), v1486);
                                    let v1488: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method31(v1486, v1488.clone()) {
                                        let v1490: i32 = v1488.l0.get().clone();
                                        let patternInput_8: (string, string) = v1473[v1490].clone();
                                        let v1493: string = sprintf!(
                                            "$env:{}=\'\'{}\'\'",
                                            patternInput_8.0.clone(),
                                            patternInput_8.1.clone()
                                        );
                                        v1487.get_mut()[v1490 as usize] = v1493;
                                        {
                                            let v1494: i32 = (v1490) + 1_i32;
                                            v1488.l0.set(v1494);
                                            ()
                                        }
                                    }
                                    {
                                        let v1506: string = sprintf!(
                                            "pwsh -c \'{}; {}\'",
                                            join(string(";"), toArray_1(ofArray_1(v1487.clone()))),
                                            v1470
                                        );
                                        let patternInput_9: (
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                        ) = if if (v1484) == 0_i32 {
                                            true
                                        } else {
                                            contains(v1485.clone(),
                                                            string("cupy_backends.cuda.api.runtime.CUDARuntimeError: cudaErrorInsufficientDriver"))
                                        } {
                                            let result_1: LrcPtr<MutCell<Spiral::US5>> =
                                                refCell(Spiral::US5::US5_1);
                                            try_catch(
                                                || {
                                                    result_1.set(Spiral::closure71(
                                                        (),
                                                        Spiral::closure78(v1485.clone(), ()),
                                                    ))
                                                },
                                                |ex_1: LrcPtr<Exception>| {
                                                    result_1.set(Spiral::closure79(
                                                        v954.clone(),
                                                        v1485.clone(),
                                                        v1506.clone(),
                                                        ex_1.clone(),
                                                    ))
                                                },
                                            );
                                            {
                                                let v1519: Spiral::US5 = result_1.get().clone();
                                                let v1530: Option<string> = match &v1519 {
                                                    Spiral::US5::US5_0(v1519_0_0) => Some(
                                                        match &v1519 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    ),
                                                    _ => None::<string>,
                                                };
                                                (
                                                    Spiral::US5::US5_0(string("py")),
                                                    Spiral::US5::US5_0(v1189),
                                                    Spiral::US5::US5_0(v954.clone()),
                                                    Spiral::US5::US5_0(v1530.unwrap()),
                                                )
                                            }
                                        } else {
                                            let v1540: () = {
                                                Spiral::closure81(
                                                    v954.clone(),
                                                    v1485,
                                                    v1484,
                                                    v1506,
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
                                let v1599: Spiral::US5 = patternInput_10.3.clone();
                                let v1597: Spiral::US5 = patternInput_10.1.clone();
                                let v1596: Spiral::US5 = patternInput_10.0.clone();
                                let v1612: Array<(string, string)> = new_array(&[
                                    (
                                        string("extension"),
                                        match &v1596 {
                                            Spiral::US5::US5_0(v1596_0_0) => match &v1596 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("code"),
                                        match &v1597 {
                                            Spiral::US5::US5_0(v1597_0_0) => match &v1597 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("output"),
                                        match &v1599 {
                                            Spiral::US5::US5_0(v1599_0_0) => match &v1599 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                ]);
                                let v1614: Vec<(string, string)> = v1612.to_vec();
                                let v1617: bool = true;
                                let _func1_from_v1615 = Func1::from(move |value| {
                                    //;
                                    let patternInput_11: (string, string) = value;
                                    let v1627: &str = &*patternInput_11.0.clone();
                                    let v1660: std::string::String = String::from(v1627);
                                    let v1693: &str = &*patternInput_11.1.clone();
                                    let v1726: std::string::String = String::from(v1693);
                                    let v1759: bool = true;
                                    LrcPtr::new((v1660, v1726)) /*;
                                                                let v1761: bool = */
                                }); //;
                                let v1763: Func1<
                                    (string, string),
                                    LrcPtr<(std::string::String, std::string::String)>,
                                > = _func1_from_v1615;
                                let v1766: Vec<LrcPtr<(std::string::String, std::string::String)>> =
                                    v1614
                                        .into_iter()
                                        .map(|x| {
                                            Func1::new({
                                                let v1763 = v1763.clone();
                                                move |arg10_0040_7: (string, string)| {
                                                    Spiral::closure76(v1763.clone(), arg10_0040_7)
                                                }
                                            })(x.clone())
                                        })
                                        .collect::<Vec<_>>();
                                let v1767: string =
                                string("std::collections::BTreeMap::from_iter(v1766.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                                let v1768: std::collections::BTreeMap<
                                    std::string::String,
                                    std::string::String,
                                > = std::collections::BTreeMap::from_iter(
                                    v1766
                                        .iter()
                                        .map(|x| x.as_ref())
                                        .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                                );
                                let v1770: Result<std::string::String, serde_json::Error> =
                                    serde_json::to_string(&v1768);
                                let v1774: std::string::String = v1770.unwrap();
                                new_array(&[(
                                    string("command_result"),
                                    fable_library_rust::String_::fromString(v1774),
                                )])
                            } else {
                                if (fable_library_rust::String_::fromString(v34.clone()))
                                    == string("fable")
                                {
                                    let v1793: string = Spiral::method183();
                                    let v1800: &str = &*v1793;
                                    let v1828: Option<std::string::String> =
                                        clap::ArgMatches::get_one(&v35.clone(), v1800).cloned();
                                    let v1847: Spiral::US7 = defaultValue(
                                        Spiral::US7::US7_1,
                                        map(Spiral::method23(), v1828),
                                    );
                                    let v1854: std::string::String = match &v1847 {
                                        Spiral::US7::US7_0(v1847_0_0) => match &v1847 {
                                            Spiral::US7::US7_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => panic!("{}", string("Option does not have a value."),),
                                    };
                                    let v1856: string =
                                        fable_library_rust::String_::fromString(v1854);
                                    let v1857: string = Spiral::method184();
                                    let v1864: &str = &*v1857;
                                    let v1892: Option<std::string::String> =
                                        clap::ArgMatches::get_one(&v35.clone(), v1864).cloned();
                                    let v1911: Spiral::US7 = defaultValue(
                                        Spiral::US7::US7_1,
                                        map(Spiral::method23(), v1892),
                                    );
                                    let v1921: Spiral::US5 = match &v1911 {
                                        Spiral::US7::US7_0(v1911_0_0) => Spiral::US5::US5_0(
                                            fable_library_rust::String_::fromString(
                                                match &v1911 {
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
                                        match &v1921 {
                                            Spiral::US5::US5_0(v1921_0_0) => {
                                                let v1923: clap::Command = Spiral::method0();
                                                let v1925: Spiral::US22 =
                                                    Spiral::method111(sprintf!(
                                                        "_ {} --fs-path \"{}\"",
                                                        match &v1921 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                        v1856.clone()
                                                    ));
                                                let v1934:
                                                             Array<string> =
                                                         match &v1925 {
                                                             Spiral::US22::US22_0(v1925_0_0)
                                                             =>
                                                             v1925_0_0.clone(),
                                                             Spiral::US22::US22_1(v1925_1_0)
                                                             =>
                                                             panic!("{}",
                                                                    concat(new_array(&[string("resultm.get / Result value was Error: "),
                   v1925_1_0.clone()])),),
                                                         };
                                                let v1936: Vec<string> = v1934.to_vec();
                                                let v1938: bool = true;
                                                let _vec_map: Vec<_> = v1936
                                                    .into_iter()
                                                    .map(|x| {
                                                        //;
                                                        let v1940: string = x;
                                                        let v1947: &str = &*v1940;
                                                        let v1980: std::string::String =
                                                            String::from(v1947);
                                                        let v2008: bool = true;
                                                        v1980
                                                    })
                                                    .collect::<Vec<_>>();
                                                let v2010: Vec<std::string::String> = _vec_map;
                                                let v2013: std::pin::Pin<
                                                    Box<
                                                        dyn std::future::Future<
                                                            Output = Result<string, string>,
                                                        >,
                                                    >,
                                                > = Spiral::method20(
                                                    v0_1.clone(),
                                                    clap::Command::get_matches_from(v1923, v2010),
                                                );
                                                let v2015: Result<string, string> = v2013.await;
                                                v2015.unwrap()
                                            }
                                            _ => string("{}"),
                                        },
                                    )])
                                } else {
                                    if (fable_library_rust::String_::fromString(v34.clone()))
                                        == string("dib")
                                    {
                                        let v2039: string = Spiral::method185();
                                        let v2046: &str = &*v2039;
                                        let v2074: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v35.clone(), v2046).cloned();
                                        let v2078: Option<string> = map(Spiral::method186(), v2074);
                                        let v2093: string = v2078.unwrap();
                                        let v2094: string = Spiral::method192();
                                        let v2101: &str = &*v2094;
                                        let v2131: u8 = defaultValue(
                                            1_u8,
                                            clap::ArgMatches::get_one(&v35.clone(), v2101).cloned(),
                                        );
                                        let v2134: string = Spiral::method193();
                                        let v2141: &str = &*v2134;
                                        let v2169: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v35.clone(), v2141).cloned();
                                        let v2188: Spiral::US7 = defaultValue(
                                            Spiral::US7::US7_1,
                                            map(Spiral::method23(), v2169),
                                        );
                                        let patternInput_12: (i32, string) = Spiral::method194(
                                            match &v2188 {
                                                Spiral::US7::US7_0(v2188_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        fable_library_rust::String_::fromString(
                                                            match &v2188 {
                                                                Spiral::US7::US7_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        ),
                                                    )
                                                }
                                                _ => Spiral::US5::US5_1,
                                            },
                                            v2131,
                                            v2093.clone(),
                                            1_u8,
                                        );
                                        let v2201: string = patternInput_12.1.clone();
                                        let v2200: i32 = patternInput_12.0.clone();
                                        let patternInput_15: (i32, string) = if (v2200) != 0_i32 {
                                            (v2200, v2201.clone())
                                        } else {
                                            let patternInput_13:
                                                    (i32, string) =
                                                Spiral::method96(concat(new_array(&[string("jupyter nbconvert \""),
                                                                                    v2093.clone(),
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
                                            let v2214: string = patternInput_13.1.clone();
                                            let v2213: i32 = patternInput_13.0.clone();
                                            let v2217: () = {
                                                Spiral::closure84(v2214.clone(), v2213, ());
                                                ()
                                            };
                                            if (v2213) != 0_i32 {
                                                (
                                                    v2213,
                                                    concat(new_array(&[
                                                        string("repl_result: "),
                                                        v2201.clone(),
                                                        string("\n\njupyter_result: "),
                                                        v2214.clone(),
                                                    ])),
                                                )
                                            } else {
                                                let patternInput_14:
                                                        (i32, string) =
                                                    Spiral::method96(concat(new_array(&[string("pwsh -c \"$counter = 1; $path = \'"),
                                                                                        replace(v2093.clone(),
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
                                                let v2281: string = patternInput_14.1.clone();
                                                let v2280: i32 = patternInput_14.0.clone();
                                                let v2284: () = {
                                                    Spiral::closure85(v2281.clone(), v2280, ());
                                                    ()
                                                };
                                                let v2332: string = concat(new_array(&[
                                                    v2093.clone(),
                                                    string(".html"),
                                                ]));
                                                let v2344: Result<Vec<u8>, std::io::Error> =
                                                    std::fs::read(&*v2332);
                                                let v2389: Vec<u8> =
                                                    Spiral::method26(v2344.unwrap());
                                                let v2391: Result<
                                                    std::string::String,
                                                    std::string::FromUtf8Error,
                                                > = std::string::String::from_utf8(v2389);
                                                let v2395: std::string::String = v2391.unwrap();
                                                let v2438: string = replace(
                                                    fable_library_rust::String_::fromString(v2395),
                                                    string("\r\n"),
                                                    string("\n"),
                                                );
                                                let v2439: string = concat(new_array(&[
                                                    v2093.clone(),
                                                    string(".html"),
                                                ]));
                                                std::fs::write(&*v2439, &*v2438).unwrap();
                                                {
                                                    let v2442: string = concat(new_array(&[
                                                        v2093.clone(),
                                                        string(".ipynb"),
                                                    ]));
                                                    let v2454: Result<Vec<u8>, std::io::Error> =
                                                        std::fs::read(&*v2442);
                                                    let v2499: Vec<u8> =
                                                        Spiral::method26(v2454.unwrap());
                                                    let v2501: Result<
                                                        std::string::String,
                                                        std::string::FromUtf8Error,
                                                    > = std::string::String::from_utf8(v2499);
                                                    let v2505: std::string::String = v2501.unwrap();
                                                    let v2549: string = replace(
                                                        replace(
                                                            fable_library_rust::String_::fromString(
                                                                v2505,
                                                            ),
                                                            string("\r\n"),
                                                            string("\n"),
                                                        ),
                                                        string("\\r\\n"),
                                                        string("\\n"),
                                                    );
                                                    let v2550: string = concat(new_array(&[
                                                        v2093,
                                                        string(".ipynb"),
                                                    ]));
                                                    std::fs::write(&*v2550, &*v2549).unwrap();
                                                    (v2280,
                                                     sprintf!("repl_result: {}\n\njupyter_result: {}\n\npwsh_replace_html_result: {}",
                                                              v2201, v2214,
                                                              v2281))
                                                }
                                            }
                                        };
                                        let v2557: string = patternInput_15.1.clone();
                                        let v2556: i32 = patternInput_15.0.clone();
                                        let v2560: () = {
                                            Spiral::closure86(v2557.clone(), v2556, ());
                                            ()
                                        };
                                        if (v2556) != 0_i32 {
                                            panic!(
                                                "{}",
                                                sprintf!(
                                                    "spiral.run / dib / exit_code: {} / result: {}",
                                                    v2556,
                                                    v2557.clone()
                                                )
                                            );
                                        }
                                        new_array(&[(string("stdio"), v2557)])
                                    } else {
                                        let patternInput_38: (
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                        ) = if (fable_library_rust::String_::fromString(
                                            v34.clone(),
                                        )) == string("rust")
                                        {
                                            let v2618: string = Spiral::method183();
                                            let v2625: &str = &*v2618;
                                            let v2653: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v35.clone(), v2625)
                                                    .cloned();
                                            let v2672: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v2653),
                                            );
                                            let v2679: std::string::String = match &v2672 {
                                                Spiral::US7::US7_0(v2672_0_0) => match &v2672 {
                                                    Spiral::US7::US7_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => panic!(
                                                    "{}",
                                                    string("Option does not have a value."),
                                                ),
                                            };
                                            let v2681: string =
                                                fable_library_rust::String_::fromString(v2679);
                                            let v2682: string = Spiral::method24();
                                            let v2689: &str = &*v2682;
                                            let v2717: Option<Vec<std::string::String>> =
                                                clap::ArgMatches::get_many(&v35.clone(), v2689)
                                                    .map(|x| x.cloned().into_iter().collect());
                                            let v2736: Spiral::US8 = defaultValue(
                                                Spiral::US8::US8_1,
                                                map(Spiral::method25(), v2717),
                                            );
                                            let v2742: Vec<std::string::String> =
                                                new_empty::<std::string::String>().to_vec();
                                            let v2745: Vec<std::string::String> = match &v2736 {
                                                Spiral::US8::US8_0(v2736_0_0) => match &v2736 {
                                                    Spiral::US8::US8_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => v2742.clone(),
                                            };
                                            let v2746: string = Spiral::method203();
                                            let v2753: &str = &*v2746;
                                            let v2781: bool =
                                                clap::ArgMatches::get_flag(&v35.clone(), v2753);
                                            let v2782: string = Spiral::method204();
                                            let v2789: &str = &*v2782;
                                            let v2817: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v35.clone(), v2789)
                                                    .cloned();
                                            let v2836: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v2817),
                                            );
                                            let v2846: Spiral::US5 = match &v2836 {
                                                Spiral::US7::US7_0(v2836_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        fable_library_rust::String_::fromString(
                                                            match &v2836 {
                                                                Spiral::US7::US7_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        ),
                                                    )
                                                }
                                                _ => Spiral::US5::US5_1,
                                            };
                                            let v2847: string = Spiral::method205();
                                            let v2854: &str = &*v2847;
                                            let v2882: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v35.clone(), v2854)
                                                    .cloned();
                                            let v2901: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v2882),
                                            );
                                            let v2911: Spiral::US5 = match &v2901 {
                                                Spiral::US7::US7_0(v2901_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        fable_library_rust::String_::fromString(
                                                            match &v2901 {
                                                                Spiral::US7::US7_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        ),
                                                    )
                                                }
                                                _ => Spiral::US5::US5_1,
                                            };
                                            let v2920: Spiral::US36 =
                                                if let Spiral::US5::US5_0(v2846_0_0) = &v2846 {
                                                    Spiral::US36::US36_0(Spiral::US37::US37_0(
                                                        v2846_0_0.clone(),
                                                    ))
                                                } else {
                                                    if let Spiral::US5::US5_0(v2911_0_0) = &v2911 {
                                                        Spiral::US36::US36_0(Spiral::US37::US37_1(
                                                            v2911_0_0.clone(),
                                                        ))
                                                    } else {
                                                        Spiral::US36::US36_1
                                                    }
                                                };
                                            let v2932: Result<Vec<u8>, std::io::Error> =
                                                std::fs::read(&*v2681);
                                            let v2977: Vec<u8> = Spiral::method26(v2932.unwrap());
                                            let v2979: Result<
                                                std::string::String,
                                                std::string::FromUtf8Error,
                                            > = std::string::String::from_utf8(v2977);
                                            let v2983: std::string::String = v2979.unwrap();
                                            let v3018: string =
                                                fable_library_rust::String_::fromString(v2983);
                                            let v3026: string =
                                                Spiral::method28(Spiral::method206(
                                                    string("rs"),
                                                    v3018.clone(),
                                                    v2920.clone(),
                                                ));
                                            let v3028: Spiral::US5 =
                                                Spiral::method34(Spiral::method33());
                                            let v3034: Spiral::US5 =
                                                match &v3028 {
                                                    Spiral::US5::US5_0(v3028_0_0)
                                                    =>
                                                    Spiral::US5::US5_0(match &v3028
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
                                            let v3040: Spiral::US5 = match &v3034 {
                                                Spiral::US5::US5_0(v3034_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        match &v3034 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => Spiral::method34(string("/workspaces")),
                                            };
                                            let v3044: string = match &v3040 {
                                                Spiral::US5::US5_0(v3040_0_0) => match &v3040 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => panic!(
                                                    "{}",
                                                    string("Option does not have a value."),
                                                ),
                                            };
                                            let v3059: string = Spiral::method35(
                                                if string("deps")
                                                    == (Spiral::method54(v3044.clone()))
                                                {
                                                    let v3052: Spiral::US5 = Spiral::method34(
                                                        Spiral::method40(v3044.clone())
                                                            .clone()
                                                            .unwrap(),
                                                    );
                                                    match &v3052 {
                                                        Spiral::US5::US5_0(v3052_0_0) => {
                                                            match &v3052 {
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
                                                    v3044
                                                },
                                                string("polyglot"),
                                            );
                                            let v3063: string = toLower(Spiral::method33());
                                            let v3068: string = toLower(v3059);
                                            let v3077: Spiral::US10 =
                                                if startsWith3(v3063, v3068.clone(), false) {
                                                    Spiral::US10::US10_1(v3068.clone())
                                                } else {
                                                    Spiral::US10::US10_0(v3068)
                                                };
                                            let v3089: Result<string, string> = match &v3077 {
                                                Spiral::US10::US10_0(v3077_0_0) => {
                                                    Ok::<string, string>(v3077_0_0.clone())
                                                }
                                                Spiral::US10::US10_1(v3077_1_0) => {
                                                    Err::<string, string>(v3077_1_0.clone())
                                                }
                                            };
                                            let v3091: bool = true;
                                            let _result_unwrap_or_else =
                                                v3089.unwrap_or_else(|x| {
                                                    //;
                                                    let v3093: string = x;
                                                    let v3095: bool = true;
                                                    v3093
                                                });
                                            let v3097: string = _result_unwrap_or_else;
                                            let v3102: string = Spiral::method207(
                                                Spiral::US5::US5_0(v3026.clone()),
                                                string("spiral"),
                                                Spiral::US39::US39_0(Spiral::US38::US38_0),
                                                v3097.clone(),
                                            );
                                            let v3108: string = Spiral::method208(
                                                v3018,
                                                string("spiral"),
                                                LrcPtr::new(Spiral::UH2::UH2_0),
                                                LrcPtr::new(Spiral::UH4::UH4_1(
                                                    string("Fable.Core"),
                                                    string("4.3.0"),
                                                    LrcPtr::new(Spiral::UH4::UH4_0),
                                                )),
                                                v3102.clone(),
                                                v3097.clone(),
                                            );
                                            let v3110: string =
                                                Spiral::method35(v3102.clone(), string("../../.."));
                                            let v3112: string = Spiral::method35(
                                                v3110.clone(),
                                                string("Cargo.toml"),
                                            );
                                            if (Spiral::method37(v3112.clone())) == false {
                                                let v3118: DateTime = DateTime::now();
                                                let v3141: string =
                                                    toString(Spiral::method211(new_guid(), v3118));
                                                let v3166: string =
                                                    append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                           (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                               v3141.clone(),
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
                                                                                               v3141,
                                                                                               string("\"")]))))),
                                                                   string("\n"))),
                                                           string("path = \"spiral.rs\""));
                                                std::fs::write(&*v3112.clone(), &*v3166).unwrap();
                                                ()
                                            }
                                            {
                                                let v3169: string = Spiral::method35(
                                                    v3102.clone(),
                                                    string("Cargo.toml"),
                                                );
                                                if (Spiral::method37(v3169.clone())) == false {
                                                    let v3175: DateTime = DateTime::now();
                                                    let v3198: string = toString(
                                                        Spiral::method211(new_guid(), v3175),
                                                    );
                                                    let v3223: string =
                                                        append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                               (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                   v3198.clone(),
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
                                                                                                   v3198,
                                                                                                   string("\"")]))))),
                                                                       string("\n"))),
                                                               string("path = \"spiral.rs\""));
                                                    std::fs::write(&*v3169.clone(), &*v3223)
                                                        .unwrap();
                                                    ()
                                                }
                                                {
                                                    let v3227: string =
                                                        Spiral::method35(v3097.clone(),
                                                                         string("lib/rust/fable/fable_modules/fable-library-rust"));
                                                    let v3229: string = Spiral::method35(
                                                        v3102.clone(),
                                                        string("fable_modules/fable-library-rust"),
                                                    );
                                                    Spiral::method216(v3227, v3229.clone());
                                                    {
                                                        let patternInput_16: (i32, string) =
                                                            Spiral::method217(
                                                                v2920.clone(),
                                                                v3102.clone(),
                                                                string("rs"),
                                                                v3108,
                                                                v3077.clone(),
                                                            );
                                                        let v3231: string =
                                                            patternInput_16.1.clone();
                                                        let v3230: i32 = patternInput_16.0.clone();
                                                        let patternInput_25: (
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                        ) = if (v3230) != 0_i32 {
                                                            let v3238: () = {
                                                                Spiral::closure89(
                                                                    v3231.clone(),
                                                                    v3230,
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            (
                                                                Spiral::US5::US5_0(string("rs")),
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_0(v3231),
                                                            )
                                                        } else {
                                                            let v3389: Vec<std::string::String> =
                                                                if if let Spiral::US36::US36_1 =
                                                                    &v2920
                                                                {
                                                                    true
                                                                } else {
                                                                    false
                                                                } {
                                                                    v2745.clone()
                                                                } else {
                                                                    let v3290 = Spiral::method227();
                                                                    let v3291: Vec<
                                                                        std::string::String,
                                                                    > = Spiral::method228(
                                                                        v2745.clone(),
                                                                    );
                                                                    let v3293: Vec<
                                                                        std::string::String,
                                                                    > = v3291
                                                                        .into_iter()
                                                                        .filter(|x| {
                                                                            v3290(x.clone().clone())
                                                                        })
                                                                        .collect::<Vec<_>>();
                                                                    if (v3293.len() as i32) > 0_i32
                                                                    {
                                                                        v2745.clone()
                                                                    } else {
                                                                        let v3317: &str =
                                                                            &*string("near-sdk");
                                                                        let v3377: Array<
                                                                            std::string::String,
                                                                        > = new_array(&[
                                                                            String::from(v3317),
                                                                        ]);
                                                                        let v3380: Vec<
                                                                            std::string::String,
                                                                        > = Spiral::method68(
                                                                            v3377.to_vec(),
                                                                        );
                                                                        let v3381: Vec<
                                                                            std::string::String,
                                                                        > = Spiral::method69(v2745);
                                                                        let v3383: bool = true;
                                                                        let mut v3381 = v3381;
                                                                        let v3385: bool = true;
                                                                        v3381.extend(v3380);
                                                                        v3381
                                                                    }
                                                                };
                                                            let v3391: bool = true;
                                                            let _vec_map : Vec<_> = v3389.into_iter().map(|x| { //;
                                                                let v3393:
                                                                        std::string::String =
                                                                    x;
                                                                let v3395:
                                                                        string =
                                                                    fable_library_rust::String_::fromString(v3393);
                                                                let v3412:
                                                                        string =
                                                                    if contains(v3395.clone(),
                                                                                string("="))
                                                                       {
                                                                        v3395.clone()
                                                                    } else {
                                                                        if endsWith3(v3395.clone(),
                                                                                     string("]"),
                                                                                     false)
                                                                           {
                                                                            concat(new_array(&[replace(v3395.clone(),
                                                                                                       string("["),
                                                                                                       string("={version=\'*\',features=[")),
                                                                                               string("}")]))
                                                                        } else {
                                                                            concat(new_array(&[v3395,
                                                                                               string("=\'*\'")]))
                                                                        }
                                                                    };
                                                                let v3414:
                                                                        bool =
                                                                    true; v3412 }).collect::<Vec<_>>();
                                                            let v3416: Vec<string> = _vec_map;
                                                            let v3418:
                                                                        Array<string> =
                                                                    fable_library_rust::NativeArray_::array_from(v3416.clone());
                                                            let _let__v3422: LrcPtr<
                                                                dyn IEnumerable_1<string>,
                                                            > = delay(Func0::new({
                                                                let v3418 = v3418.clone();
                                                                move || {
                                                                    map_1(
                                                                        Func1::new({
                                                                            let v3418 =
                                                                                v3418.clone();
                                                                            move |i_2: i32| {
                                                                                v3418[i_2].clone()
                                                                            }
                                                                        }),
                                                                        rangeNumeric(
                                                                            0_i32,
                                                                            1_i32,
                                                                            (get_Count(
                                                                                v3418.clone(),
                                                                            )) - 1_i32,
                                                                        ),
                                                                    )
                                                                }
                                                            }));
                                                            let v3435: string = join(
                                                                Spiral::method70(),
                                                                toArray_1(_let__v3422),
                                                            );
                                                            let v3440: string = Spiral::method35(
                                                                v3102,
                                                                concat(new_array(&[
                                                                    string("spiral"),
                                                                    string("."),
                                                                    string("rs"),
                                                                ])),
                                                            );
                                                            let v3452: Result<
                                                                Vec<u8>,
                                                                std::io::Error,
                                                            > = std::fs::read(&*v3440.clone());
                                                            let v3497: Vec<u8> =
                                                                Spiral::method26(v3452.unwrap());
                                                            let v3499: Result<
                                                                std::string::String,
                                                                std::string::FromUtf8Error,
                                                            > = std::string::String::from_utf8(
                                                                v3497,
                                                            );
                                                            let v3503: std::string::String =
                                                                v3499.unwrap();
                                                            let v3538:
                                                                        string =
                                                                    fable_library_rust::String_::fromString(v3503);
                                                            let v3546: string = append(
                                                                string("on_startup!"),
                                                                (Spiral::method229()),
                                                            );
                                                            let v3549: string = append(
                                                                string(" method0"),
                                                                (Spiral::method230()),
                                                            );
                                                            let v3559: bool = if contains(
                                                                v3538.clone(),
                                                                v3546.clone(),
                                                            ) {
                                                                (contains(v3538, v3549)) == false
                                                            } else {
                                                                false
                                                            };
                                                            let v3624:
                                                                        string =
                                                                    append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                                                                                                           (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                                                                                               v3026.clone(),
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
                                                                                                                                                           (if !((v2920.clone())
                                                                                                                                                                     ==
                                                                                                                                                                     Spiral::US36::US36_1)
                                                                                                                                                               {
                                                                                                                                                                string("fable_library_rust = { workspace = true }")
                                                                                                                                                            } else {
                                                                                                                                                                append((append((append(string("fable_library_rust = { workspace = true, features = ["),
                                                                                                                                                                                       (if v3559
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
                                                                                                                           (v3435))),
                                                                                                                   string("\n"))),
                                                                                                           string(""))),
                                                                                                   string("\n"))),
                                                                                           (if if let Spiral::US36::US36_1
                                                                                                      =
                                                                                                      &v2920
                                                                                                  {
                                                                                                   true
                                                                                               } else {
                                                                                                   false
                                                                                               }
                                                                                               {
                                                                                                append(string("[[bin]]\n"),
                                                                                                       (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                           v3026.clone(),
                                                                                                                           string("\"")]))))
                                                                                            } else {
                                                                                                string("[lib]\ncrate-type = [\"cdylib\"]")
                                                                                            }))),
                                                                                   string("\n"))),
                                                                           string("path = \"spiral.rs\""));
                                                            let v3689:
                                                                        string =
                                                                    append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append(string("cargo-features = [\"profile-rustflags\"]\n\n[workspace]\nresolver = \"2\"\nmembers = [\"packages/Rust/*\"]\n\n[workspace.dependencies.fable_library_rust]\n"),
                                                                                                                                                                                                                                                                                                           (concat(new_array(&[string("path = \""),
                                                                                                                                                                                                                                                                                                                               Spiral::method45(v3097.clone()),
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
                                                            Spiral::method71(v3169.clone(), v3624);
                                                            Spiral::method71(v3112, v3689);
                                                            {
                                                                let v3691: string =
                                                                    Spiral::method35(
                                                                        v3229,
                                                                        string("src/Range.rs"),
                                                                    );
                                                                if Spiral::method37(v3691.clone()) {
                                                                    let v3704: Result<
                                                                        Vec<u8>,
                                                                        std::io::Error,
                                                                    > = std::fs::read(
                                                                        &*v3691.clone(),
                                                                    );
                                                                    let v3749: Vec<u8> =
                                                                        Spiral::method26(
                                                                            v3704.unwrap(),
                                                                        );
                                                                    let v3751:
                                                                                Result<std::string::String,
                                                                                       std::string::FromUtf8Error> =
                                                                            std::string::String::from_utf8(v3749);
                                                                    let v3755: std::string::String =
                                                                        v3751.unwrap();
                                                                    Spiral::method71(v3691,
                                                                                         replace(replace(fable_library_rust::String_::fromString(v3755),
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
                                                                        v3077.clone(),
                                                                        v3169.clone(),
                                                                        1_u8,
                                                                    );
                                                                    let v3803: i32 =
                                                                        patternInput_17.0.clone();
                                                                    if (v3803) != 0_i32 {
                                                                        let v3811: () = {
                                                                            Spiral::closure93(
                                                                                patternInput_17
                                                                                    .1
                                                                                    .clone(),
                                                                                v3803,
                                                                                (),
                                                                            );
                                                                            ()
                                                                        };
                                                                        ()
                                                                    }
                                                                    {
                                                                        let v3869: Result<
                                                                            Vec<u8>,
                                                                            std::io::Error,
                                                                        > = std::fs::read(
                                                                            &*v3440.clone(),
                                                                        );
                                                                        let v3914: Vec<u8> =
                                                                            Spiral::method26(
                                                                                v3869.unwrap(),
                                                                            );
                                                                        let v3916:
                                                                                    Result<std::string::String,
                                                                                           std::string::FromUtf8Error> =
                                                                                std::string::String::from_utf8(v3914);
                                                                        let v3920:
                                                                                    std::string::String =
                                                                                v3916.unwrap();
                                                                        let v3955:
                                                                                    string =
                                                                                fable_library_rust::String_::fromString(v3920);
                                                                        let v3963:
                                                                                    string =
                                                                                append(string("pub fn main() -> Result<(), String> "),
                                                                                       (Spiral::method237()));
                                                                        let v4010:
                                                                                    string =
                                                                                append((append((if if let Spiral::US36::US36_1
                                                                                                          =
                                                                                                          &v2920
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
                                                                                                     &v2920
                                                                                                 {
                                                                                                  true
                                                                                              } else {
                                                                                                  false
                                                                                              }
                                                                                              {
                                                                                               contains(v3955.clone(),
                                                                                                        append((v3546.clone()),
                                                                                                               string("Spiral::method0()")))
                                                                                           } else {
                                                                                               false
                                                                                           }
                                                                                           {
                                                                                            concat(new_array(&[v3963.clone(),
                                                                                                               string(" Ok(Spiral::method0()) }")]))
                                                                                        } else {
                                                                                            concat(new_array(&[v3963.clone(),
                                                                                                               string(" Ok(()) }")]))
                                                                                        }));
                                                                        let v4012: bool = contains(
                                                                            v3955.clone(),
                                                                            v3963,
                                                                        );
                                                                        let v4114: string = if v4012
                                                                        {
                                                                            v3955.clone()
                                                                        } else {
                                                                            (if (if let Spiral::US36::US36_0(v2920_0_0)
                                                                                                =
                                                                                                &v2920
                                                                                            {
                                                                                             if let Spiral::US37::US37_1(v2920_1_0)
                                                                                                    =
                                                                                                    &v2920_0_0
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
                                                                                         let v4110:
                                                                                                 string =
                                                                                             string("use fable_library_rust::DateTime_::DateTime;");
                                                                                         Func1::new({
                                                                                                        let v4110
                                                                                                            =
                                                                                                            v4110.clone();
                                                                                                        move
                                                                                                            |v_8:
                                                                                                                 string|
                                                                                                            Spiral::closure96(v4110.clone(),
                                                                                                                              v_8)
                                                                                                    })
                                                                                     })((if v3559
                                                                                            {
                                                                                             Func1::new(move
                                                                                                            |v_5:
                                                                                                                 string|
                                                                                                            Spiral::closure94((),
                                                                                                                              v_5))
                                                                                         } else {
                                                                                             let v4102:
                                                                                                     string =
                                                                                                 append(string("// "),
                                                                                                        (v3546.clone()));
                                                                                             Func1::new({
                                                                                                            let v3546
                                                                                                                =
                                                                                                                v3546.clone();
                                                                                                            let v4102
                                                                                                                =
                                                                                                                v4102.clone();
                                                                                                            move
                                                                                                                |v_6:
                                                                                                                     string|
                                                                                                                Spiral::closure95(v3546.clone(),
                                                                                                                                  v4102.clone(),
                                                                                                                                  v_6)
                                                                                                        })
                                                                                         })(replace(replace(replace(replace(replace(replace(replace(replace(replace(Spiral::method65(string("\\s\\sfable_library_rust::Native_::getZero\\(\\);"),
                                                                                                                                                                                     string(" fable_library_rust::Native_::getZero::<()>();"),
                                                                                                                                                                                     replace(replace(Spiral::method65(string("\\s\\sgetZero\\(\\);"),
                                                                                                                                                                                                                      string(" getZero::<()>();"),
                                                                                                                                                                                                                      Spiral::method65(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                                                                                                                                                       string(" defaultOf::<()>();"),
                                                                                                                                                                                                                                       replace(replace(concat(new_array(&[v3955,
                                                                                                                                                                                                                                                                          string("\n\n"),
                                                                                                                                                                                                                                                                          v4010,
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
                                                                        if (v4012) == false {
                                                                            Spiral::method71(
                                                                                v3440.clone(),
                                                                                v4114.clone(),
                                                                            );
                                                                        }
                                                                        {
                                                                            let v4120:
                                                                                        string =
                                                                                    if (if let Spiral::US36::US36_1
                                                                                               =
                                                                                               &v2920
                                                                                           {
                                                                                            true
                                                                                        } else {
                                                                                            false
                                                                                        })
                                                                                           !=
                                                                                           true
                                                                                       {
                                                                                        concat(new_array(&[string("cargo +nightly-2024-07-14 build --release --target wasm32-unknown-unknown --manifest-path \""),
                                                                                                           v3169.clone(),
                                                                                                           string("\"")]))
                                                                                    } else {
                                                                                        concat(new_array(&[string("cargo run --manifest-path \""),
                                                                                                           v3169,
                                                                                                           string("\"")]))
                                                                                    };
                                                                            let v4133:
                                                                                        Array<(string,
                                                                                               string)> =
                                                                                    if (if let Spiral::US36::US36_1
                                                                                               =
                                                                                               &v2920
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
                                                                            let v4150:
                                                                                        Result<string,
                                                                                               string> =
                                                                                    match &v3077
                                                                                        {
                                                                                        Spiral::US10::US10_0(v3077_0_0)
                                                                                        =>
                                                                                        Ok::<string,
                                                                                             string>(v3077_0_0.clone()),
                                                                                        Spiral::US10::US10_1(v3077_1_0)
                                                                                        =>
                                                                                        Err::<string,
                                                                                              string>(v3077_1_0.clone()),
                                                                                    };
                                                                            let patternInput_18:
                                                                                        (i32,
                                                                                         string) =
                                                                                    Spiral::method96(v4120.clone(),
                                                                                                     None::<CancellationToken>,
                                                                                                     v4133.clone(),
                                                                                                     None::<Func1<(i32,
                                                                                                                   string,
                                                                                                                   bool),
                                                                                                                  Arc<Async<()>>>>,
                                                                                                     None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                                  ()>>,
                                                                                                     true,
                                                                                                     v4150.ok());
                                                                            let v4168: string =
                                                                                patternInput_18
                                                                                    .1
                                                                                    .clone();
                                                                            let v4167: i32 =
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
                                                                                              &v2920
                                                                                          {
                                                                                           true
                                                                                       } else {
                                                                                           false
                                                                                       }
                                                                                       {
                                                                                        let v4170:
                                                                                                i32 =
                                                                                            get_Count(v4133.clone());
                                                                                        let v4171:
                                                                                                Array<string> =
                                                                                            new_init(&string(""),
                                                                                                     v4170);
                                                                                        let v4172:
                                                                                                LrcPtr<Spiral::Mut5> =
                                                                                            LrcPtr::new(Spiral::Mut5{l0:
                                                                                                                         MutCell::new(0_i32),});
                                                                                        while Spiral::method31(v4170,
                                                                                                               v4172.clone())
                                                                                              {
                                                                                            let v4174:
                                                                                                    i32 =
                                                                                                v4172.l0.get().clone();
                                                                                            let patternInput_19:
                                                                                                    (string,
                                                                                                     string) =
                                                                                                v4133[v4174].clone();
                                                                                            let v4177:
                                                                                                    string =
                                                                                                sprintf!("$env:{}=\'\'{}\'\'",
                                                                                                         patternInput_19.0.clone(),
                                                                                                         patternInput_19.1.clone());
                                                                                            v4171.get_mut()[v4174
                                                                                                                as
                                                                                                                usize]
                                                                                                =
                                                                                                v4177;
                                                                                            {
                                                                                                let v4178:
                                                                                                        i32 =
                                                                                                    (v4174)
                                                                                                        +
                                                                                                        1_i32;
                                                                                                v4172.l0.set(v4178);
                                                                                                ()
                                                                                            }
                                                                                        }
                                                                                        {
                                                                                            let v4201:
                                                                                                    string =
                                                                                                concat(new_array(&[string("pwsh -c \'"),
                                                                                                                   join(string(";"),
                                                                                                                        toArray_1(ofArray_1(new_array(&[join(string(";"),
                                                                                                                                                             toArray_1(ofArray_1(v4171.clone()))),
                                                                                                                                                        v4120])))),
                                                                                                                   string("\'")]));
                                                                                            let patternInput_20:
                                                                                                    (Spiral::US5,
                                                                                                     Spiral::US5,
                                                                                                     Spiral::US5,
                                                                                                     Spiral::US5) =
                                                                                                if (v4167)
                                                                                                       !=
                                                                                                       0_i32
                                                                                                   {
                                                                                                    let v4208:
                                                                                                            () =
                                                                                                        {
                                                                                                            Spiral::closure97(v2781,
                                                                                                                              v3440.clone(),
                                                                                                                              v4168.clone(),
                                                                                                                              v4167,
                                                                                                                              v4201.clone(),
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
                                                                                                                                                 Spiral::closure98(v4168.clone(),
                                                                                                                                                                   ()))),
                                                                                                              |ex_2:
                                                                                                                   LrcPtr<Exception>|
                                                                                                                  result_2.set(Spiral::closure100(v3440.clone(),
                                                                                                                                                  v4168.clone(),
                                                                                                                                                  v4201,
                                                                                                                                                  ex_2.clone())));
                                                                                                    {
                                                                                                        let v4264:
                                                                                                                Spiral::US5 =
                                                                                                            result_2.get().clone();
                                                                                                        let v4275:
                                                                                                                Option<string> =
                                                                                                            match &v4264
                                                                                                                {
                                                                                                                Spiral::US5::US5_0(v4264_0_0)
                                                                                                                =>
                                                                                                                Some(match &v4264
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
                                                                                                         Spiral::US5::US5_0(v4114.clone()),
                                                                                                         Spiral::US5::US5_0(v3440.clone()),
                                                                                                         Spiral::US5::US5_0(v4275.unwrap()))
                                                                                                    }
                                                                                                };
                                                                                            (patternInput_20.0.clone(),
                                                                                             patternInput_20.1.clone(),
                                                                                             patternInput_20.2.clone(),
                                                                                             patternInput_20.3.clone())
                                                                                        }
                                                                                    } else {
                                                                                        let v4286:
                                                                                                string =
                                                                                            sprintf!("target/spiral/{}/target/wasm32-unknown-unknown/release/spiral_{}.wasm",
                                                                                                     string("spiral"),
                                                                                                     v3026.clone());
                                                                                        let v4298:
                                                                                                string =
                                                                                            sprintf!("pwsh -c \"pwsh {} {} -Linux -EnvironmentVariables AUTOMATION={}`nNEAR_RPC_TIMEOUT_SECS=100\"",
                                                                                                     string("scripts/invoke-block.ps1"),
                                                                                                     sprintf!("\'deps/spiral/workspace/target/release/spiral_wasm -w {} -t Debug {}\'",
                                                                                                              v4286.clone(),
                                                                                                              if let Spiral::US36::US36_0(v2920_0_0)
                                                                                                                     =
                                                                                                                     &v2920
                                                                                                                 {
                                                                                                                  let v4287:
                                                                                                                          Spiral::US37 =
                                                                                                                      v2920_0_0.clone();
                                                                                                                  match &v4287
                                                                                                                      {
                                                                                                                      Spiral::US37::US37_0(v4287_0_0)
                                                                                                                      =>
                                                                                                                      v4287_0_0.clone(),
                                                                                                                      Spiral::US37::US37_1(v4287_1_0)
                                                                                                                      =>
                                                                                                                      v4287_1_0.clone(),
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
                                                                                            if (v4167)
                                                                                                   ==
                                                                                                   0_i32
                                                                                               {
                                                                                                let patternInput_21:
                                                                                                        (i32,
                                                                                                         string) =
                                                                                                    Spiral::method96(v4298.clone(),
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
                                                                                                                     Some(v3097));
                                                                                                let v4311:
                                                                                                        string =
                                                                                                    patternInput_21.1.clone();
                                                                                                let v4310:
                                                                                                        i32 =
                                                                                                    patternInput_21.0.clone();
                                                                                                let patternInput_22:
                                                                                                        (Spiral::US5,
                                                                                                         Spiral::US5,
                                                                                                         Spiral::US5,
                                                                                                         Spiral::US5) =
                                                                                                    if (v4310)
                                                                                                           ==
                                                                                                           0_i32
                                                                                                       {
                                                                                                        (Spiral::US5::US5_0(string("rs")),
                                                                                                         Spiral::US5::US5_0(v4114),
                                                                                                         Spiral::US5::US5_0(v3440.clone()),
                                                                                                         Spiral::US5::US5_0(v4311.clone()))
                                                                                                    } else {
                                                                                                        let v4319:
                                                                                                                () =
                                                                                                            {
                                                                                                                Spiral::closure102(v2781,
                                                                                                                                   v3440.clone(),
                                                                                                                                   v4168.clone(),
                                                                                                                                   v4311,
                                                                                                                                   v4310,
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
                                                                                                let v4377:
                                                                                                        () =
                                                                                                    {
                                                                                                        Spiral::closure103(v2781,
                                                                                                                           v3440.clone(),
                                                                                                                           v4168,
                                                                                                                           v4167,
                                                                                                                           v4286,
                                                                                                                           v4298,
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
                                                                            if v2781 {
                                                                                let v4441:
                                                                                            string =
                                                                                        if (if let Spiral::US36::US36_1
                                                                                                   =
                                                                                                   &v2920
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
                                                                                let v4444:
                                                                                            string =
                                                                                        Spiral::method35(v3110.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4441.clone(),
                                                                                                                  v3026.clone(),
                                                                                                                  string("")));
                                                                                let v4447:
                                                                                            string =
                                                                                        Spiral::method35(v3110.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4441.clone(),
                                                                                                                  v3026.clone(),
                                                                                                                  string(".wasm")));
                                                                                let v4450:
                                                                                            string =
                                                                                        Spiral::method35(v3110.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4441.clone(),
                                                                                                                  v3026.clone(),
                                                                                                                  string(".pdb")));
                                                                                let v4453:
                                                                                            string =
                                                                                        Spiral::method35(v3110.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4441.clone(),
                                                                                                                  v3026.clone(),
                                                                                                                  string(".exe")));
                                                                                let v4456:
                                                                                            string =
                                                                                        Spiral::method35(v3110,
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4441,
                                                                                                                  v3026,
                                                                                                                  string(".d")));
                                                                                let v4457:
                                                                                            bool =
                                                                                        Spiral::method37(v4444.clone());
                                                                                let v4458:
                                                                                            bool =
                                                                                        Spiral::method37(v4447.clone());
                                                                                let v4459:
                                                                                            bool =
                                                                                        Spiral::method37(v4450.clone());
                                                                                let v4460:
                                                                                            bool =
                                                                                        Spiral::method37(v4453.clone());
                                                                                let v4461:
                                                                                            bool =
                                                                                        Spiral::method37(v4456.clone());
                                                                                let v4464: () = {
                                                                                    Spiral::closure104(v3440,
                                                                                                               v4456.clone(),
                                                                                                               v4461,
                                                                                                               v4453.clone(),
                                                                                                               v4460,
                                                                                                               v4450.clone(),
                                                                                                               v4459,
                                                                                                               v4447.clone(),
                                                                                                               v4458,
                                                                                                               v4444.clone(),
                                                                                                               v4457,
                                                                                                               ());
                                                                                    ()
                                                                                };
                                                                                let v4514: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4457 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4444,
                                                                                                                           v4457,
                                                                                                                           LrcPtr::new(Spiral::UH5::UH5_0)))
                                                                                } else {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_0)
                                                                                };
                                                                                let v4516: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4458 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4447,
                                                                                                                           v4458,
                                                                                                                           v4514.clone()))
                                                                                } else {
                                                                                    v4514
                                                                                };
                                                                                let v4518: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4459 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4450,
                                                                                                                           v4459,
                                                                                                                           v4516.clone()))
                                                                                } else {
                                                                                    v4516
                                                                                };
                                                                                let v4520: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4460 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4453,
                                                                                                                           v4460,
                                                                                                                           v4518.clone()))
                                                                                } else {
                                                                                    v4518
                                                                                };
                                                                                Spiral::method248(
                                                                                    if v4461 {
                                                                                        LrcPtr::new(Spiral::UH5::UH5_1(v4456,
                                                                                                                                         v4461,
                                                                                                                                         v4520.clone()))
                                                                                    } else {
                                                                                        v4520
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
                                                v34.clone(),
                                            )) == string("typescript")
                                            {
                                                let v4530: string = Spiral::method183();
                                                let v4537: &str = &*v4530;
                                                let v4565: Option<std::string::String> =
                                                    clap::ArgMatches::get_one(&v35.clone(), v4537)
                                                        .cloned();
                                                let v4584: Spiral::US7 = defaultValue(
                                                    Spiral::US7::US7_1,
                                                    map(Spiral::method23(), v4565),
                                                );
                                                let v4591: std::string::String = match &v4584 {
                                                    Spiral::US7::US7_0(v4584_0_0) => match &v4584 {
                                                        Spiral::US7::US7_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => panic!(
                                                        "{}",
                                                        string("Option does not have a value."),
                                                    ),
                                                };
                                                let v4593: string =
                                                    fable_library_rust::String_::fromString(v4591);
                                                let v4594: string = Spiral::method24();
                                                let v4601: &str = &*v4594;
                                                let v4629: Option<Vec<std::string::String>> =
                                                    clap::ArgMatches::get_many(&v35.clone(), v4601)
                                                        .map(|x| x.cloned().into_iter().collect());
                                                let v4648: Spiral::US8 = defaultValue(
                                                    Spiral::US8::US8_1,
                                                    map(Spiral::method25(), v4629),
                                                );
                                                let v4654: Vec<std::string::String> =
                                                    new_empty::<std::string::String>().to_vec();
                                                let v4657: Vec<std::string::String> = match &v4648 {
                                                    Spiral::US8::US8_0(v4648_0_0) => match &v4648 {
                                                        Spiral::US8::US8_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => v4654.clone(),
                                                };
                                                let v4669: Result<Vec<u8>, std::io::Error> =
                                                    std::fs::read(&*v4593);
                                                let v4714: Vec<u8> =
                                                    Spiral::method26(v4669.unwrap());
                                                let v4716: Result<
                                                    std::string::String,
                                                    std::string::FromUtf8Error,
                                                > = std::string::String::from_utf8(v4714);
                                                let v4720: std::string::String = v4716.unwrap();
                                                let v4755: string =
                                                    fable_library_rust::String_::fromString(v4720);
                                                let v4766: string = Spiral::method28(sprintf!(
                                                    "{:?}",
                                                    (string("ts"), v4755.clone())
                                                ));
                                                let v4768: Spiral::US5 =
                                                    Spiral::method34(Spiral::method33());
                                                let v4774: Spiral::US5 =
                                                        match &v4768 {
                                                            Spiral::US5::US5_0(v4768_0_0)
                                                            =>
                                                            Spiral::US5::US5_0(match &v4768
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
                                                let v4780: Spiral::US5 = match &v4774 {
                                                    Spiral::US5::US5_0(v4774_0_0) => {
                                                        Spiral::US5::US5_0(
                                                            match &v4774 {
                                                                Spiral::US5::US5_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => Spiral::method34(string("/workspaces")),
                                                };
                                                let v4784: string = match &v4780 {
                                                    Spiral::US5::US5_0(v4780_0_0) => match &v4780 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => panic!(
                                                        "{}",
                                                        string("Option does not have a value."),
                                                    ),
                                                };
                                                let v4799: string = Spiral::method35(
                                                    if string("deps")
                                                        == (Spiral::method54(v4784.clone()))
                                                    {
                                                        let v4792: Spiral::US5 = Spiral::method34(
                                                            Spiral::method40(v4784.clone())
                                                                .clone()
                                                                .unwrap(),
                                                        );
                                                        match &v4792 {
                                                            Spiral::US5::US5_0(v4792_0_0) => {
                                                                match &v4792 {
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
                                                        v4784
                                                    },
                                                    string("polyglot"),
                                                );
                                                let v4803: string = toLower(Spiral::method33());
                                                let v4808: string = toLower(v4799);
                                                let v4817: Spiral::US10 =
                                                    if startsWith3(v4803, v4808.clone(), false) {
                                                        Spiral::US10::US10_1(v4808.clone())
                                                    } else {
                                                        Spiral::US10::US10_0(v4808)
                                                    };
                                                let v4829: Result<string, string> = match &v4817 {
                                                    Spiral::US10::US10_0(v4817_0_0) => {
                                                        Ok::<string, string>(v4817_0_0.clone())
                                                    }
                                                    Spiral::US10::US10_1(v4817_1_0) => {
                                                        Err::<string, string>(v4817_1_0.clone())
                                                    }
                                                };
                                                let v4831: bool = true;
                                                let _result_unwrap_or_else =
                                                    v4829.unwrap_or_else(|x| {
                                                        //;
                                                        let v4833: string = x;
                                                        let v4835: bool = true;
                                                        v4833
                                                    });
                                                let v4837: string = _result_unwrap_or_else;
                                                let v4842: string = Spiral::method207(
                                                    Spiral::US5::US5_0(v4766.clone()),
                                                    string("spiral"),
                                                    Spiral::US39::US39_0(Spiral::US38::US38_1),
                                                    v4837.clone(),
                                                );
                                                let v4848: string = Spiral::method208(
                                                    v4755,
                                                    string("spiral"),
                                                    LrcPtr::new(Spiral::UH2::UH2_0),
                                                    LrcPtr::new(Spiral::UH4::UH4_1(
                                                        string("Fable.Core"),
                                                        string("4.3.0"),
                                                        LrcPtr::new(Spiral::UH4::UH4_0),
                                                    )),
                                                    v4842.clone(),
                                                    v4837.clone(),
                                                );
                                                let v4850: string = Spiral::method35(
                                                    v4837.clone(),
                                                    string("lib/typescript/fable/fable_modules"),
                                                );
                                                let v4851: string = concat(new_array(&[
                                                    string("fable-library-"),
                                                    string("ts"),
                                                ]));
                                                let v4852: string =
                                                    Spiral::method253(v4851.clone());
                                                let v4854: async_walkdir::WalkDir =
                                                    async_walkdir::WalkDir::new(&*v4850.clone());
                                                let v4857: async_walkdir::WalkDir =
                                                    async_walkdir::WalkDir::filter(
                                                        v4854,
                                                        move |x| {
                                                            Func1::new({
                                                                let v4851 = v4851.clone();
                                                                move
                                                                                                                          |v_11:
                                                                                                                               async_walkdir::DirEntry|
                                                                                                                          Spiral::closure108(v4851.clone(),
                                                                                                                                             v_11)
                                                            })(
                                                                x
                                                            )
                                                        },
                                                    );
                                                let v4858 = Spiral::method257(v4852);
                                                let v4860 = futures::stream::StreamExt::filter_map(
                                                    v4857,
                                                    |x| async { v4858(x) },
                                                );
                                                let v4862: std::pin::Pin<
                                                    Box<
                                                        dyn std::future::Future<
                                                            Output = Vec<(string, string)>,
                                                        >,
                                                    >,
                                                > = Box::pin(futures::stream::StreamExt::collect(
                                                    v4860,
                                                ));
                                                let v4864: Vec<(string, string)> = v4862.await;
                                                let v4866: rayon::vec::IntoIter<(string, string)> =
                                                    rayon::iter::IntoParallelIterator::into_par_iter(
                                                        v4864,
                                                    );
                                                let v4869: rayon::iter::Map<
                                                    rayon::vec::IntoIter<(string, string)>,
                                                    _,
                                                > = rayon::iter::ParallelIterator::map(
                                                    v4866,
                                                    |x| {
                                                        Func1::new(move
                                                                                                                     |arg10_0040_18:
                                                                                                                          (string,
                                                                                                                           string)|
                                                                                                                     Spiral::closure116((),
                                                                                                                                        arg10_0040_18))(x)
                                                    },
                                                );
                                                let v4871: Vec<(string, string)> =
                                                    rayon::iter::ParallelIterator::collect(v4869);
                                                let v4874: Option<(string, string)> = tryItem(
                                                    0_i32,
                                                    fable_library_rust::NativeArray_::array_from(
                                                        v4871.clone(),
                                                    ),
                                                );
                                                let v4894: Spiral::US48 = defaultValue(
                                                    Spiral::US48::US48_1,
                                                    map(Spiral::method262(), v4874),
                                                );
                                                let v4900: () = {
                                                    Spiral::closure118(v4894.clone(), ());
                                                    ()
                                                };
                                                Spiral::method265(
                                                    v4842.clone(),
                                                    v4850.clone(),
                                                    v4894.clone(),
                                                );
                                                {
                                                    let patternInput_26: (i32, string) =
                                                        Spiral::method217(
                                                            Spiral::US36::US36_1,
                                                            v4842.clone(),
                                                            string("ts"),
                                                            v4848,
                                                            v4817.clone(),
                                                        );
                                                    let v4949: string = patternInput_26.1.clone();
                                                    let v4948: i32 = patternInput_26.0.clone();
                                                    Spiral::method265(
                                                        v4842.clone(),
                                                        v4850,
                                                        v4894.clone(),
                                                    );
                                                    {
                                                        let patternInput_30: (
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                        ) = if (v4948) != 0_i32 {
                                                            let v4956: () = {
                                                                Spiral::closure119(
                                                                    v4949.clone(),
                                                                    v4948,
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            (
                                                                Spiral::US5::US5_0(string("ts")),
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_0(v4949),
                                                            )
                                                        } else {
                                                            let v5008: bool = true;
                                                            let _vec_map : Vec<_> = v4657.into_iter().map(|x| { //;
                                                                    let v5010:
                                                                            std::string::String =
                                                                        x;
                                                                    let v5012:
                                                                            string =
                                                                        fable_library_rust::String_::fromString(v5010);
                                                                    let v5019:
                                                                            string =
                                                                        if contains(v5012.clone(),
                                                                                    string("="))
                                                                           {
                                                                            v5012.clone()
                                                                        } else {
                                                                            concat(new_array(&[string("\""),
                                                                                               v5012,
                                                                                               string("\":\"*\"")]))
                                                                        };
                                                                    let v5021:
                                                                            bool =
                                                                        true; v5019 }).collect::<Vec<_>>();
                                                            let v5023: Vec<string> = _vec_map;
                                                            let v5025:
                                                                            Array<string> =
                                                                        fable_library_rust::NativeArray_::array_from(v5023.clone());
                                                            let v5042: string = join(
                                                                string(",\n"),
                                                                toArray_1(delay(Func0::new({
                                                                    let v5025 = v5025.clone();
                                                                    move || {
                                                                        map_1(
                                                                            Func1::new({
                                                                                let v5025 =
                                                                                    v5025.clone();
                                                                                move |i_3: i32| {
                                                                                    v5025[i_3]
                                                                                        .clone()
                                                                                }
                                                                            }),
                                                                            rangeNumeric(
                                                                                0_i32,
                                                                                1_i32,
                                                                                (get_Count(
                                                                                    v5025.clone(),
                                                                                )) - 1_i32,
                                                                            ),
                                                                        )
                                                                    }
                                                                }))),
                                                            );
                                                            let v5058:
                                                                            string =
                                                                        append((append((append((append((append((append((append(string("{"),
                                                                                                                               (concat(new_array(&[string("  \"name\": \"spiral_"),
                                                                                                                                                   v4766,
                                                                                                                                                   string("\",")]))))),
                                                                                                                       string("  \"dependencies\": {"))),
                                                                                                               (v5042))),
                                                                                                       string("  },"))),
                                                                                               string("    \"devDependencies\": {"))),
                                                                                       string("  },"))),
                                                                               string("}"));
                                                            let v5060: string = Spiral::method35(
                                                                v4842.clone(),
                                                                string("package.json"),
                                                            );
                                                            let v5063: string = Spiral::method35(
                                                                Spiral::method35(
                                                                    v4842.clone(),
                                                                    string("../.."),
                                                                ),
                                                                string("package.json"),
                                                            );
                                                            Spiral::method71(v5060, v5058);
                                                            Spiral::method71(v5063, string(""));
                                                            {
                                                                let v5066: string =
                                                                    Spiral::method35(
                                                                        v4842,
                                                                        concat(new_array(&[
                                                                            string("spiral"),
                                                                            string("."),
                                                                            string("ts"),
                                                                        ])),
                                                                    );
                                                                let v5069: () = {
                                                                    Spiral::closure120(
                                                                        v5066.clone(),
                                                                        (),
                                                                    );
                                                                    ()
                                                                };
                                                                let v5127: Result<
                                                                    Vec<u8>,
                                                                    std::io::Error,
                                                                > = std::fs::read(&*v5066.clone());
                                                                let v5172: Vec<u8> =
                                                                    Spiral::method26(
                                                                        v5127.unwrap(),
                                                                    );
                                                                let v5174: Result<
                                                                    std::string::String,
                                                                    std::string::FromUtf8Error,
                                                                > = std::string::String::from_utf8(
                                                                    v5172,
                                                                );
                                                                let v5178: std::string::String =
                                                                    v5174.unwrap();
                                                                let v5213:
                                                                                string =
                                                                            fable_library_rust::String_::fromString(v5178);
                                                                let v5221:
                                                                                bool =
                                                                            contains(v5213.clone(),
                                                                                     string("// spiral.process_typescript"));
                                                                let v5230: string = if v5221 {
                                                                    v5213.clone()
                                                                } else {
                                                                    Spiral::method65(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                 string(" defaultOf::<()>();"),
                                                                                                 replace(v5213,
                                                                                                         sprintf!("\"./fable_modules/fable-library-ts.{}/",
                                                                                                                  v4894.clone()),
                                                                                                         sprintf!("\"{}/lib/typescript/fable/fable_modules/fable-library-ts.{}/",
                                                                                                                  v4837,
                                                                                                                  v4894)))
                                                                };
                                                                if (v5221) == false {
                                                                    Spiral::method71(v5066.clone(),
                                                                                             concat(new_array(&[v5230.clone(),
                                                                                                                string("\n\n"),
                                                                                                                string("// spiral.process_typescript"),
                                                                                                                string("\n")])));
                                                                }
                                                                {
                                                                    let v5233: string =
                                                                        concat(new_array(&[
                                                                            string("bun run \""),
                                                                            v5066.clone(),
                                                                            string("\""),
                                                                        ]));
                                                                    let v5235: string =
                                                                        Spiral::method3(string(
                                                                            "PATH",
                                                                        ));
                                                                    let v5275: Spiral::US5 =
                                                                        if (v5235.clone())
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
                                                                                                                          v5235])))
                                                                        };
                                                                    let v5291:
                                                                                    Array<(string,
                                                                                           string)> =
                                                                                toArray(Spiral::method270(Spiral::method269(match &v5275
                                                                                                                                {
                                                                                                                                Spiral::US5::US5_0(v5275_0_0)
                                                                                                                                =>
                                                                                                                                LrcPtr::new(Spiral::UH4::UH4_1(string("PATH"),
                                                                                                                                                               match &v5275
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
                                                                    let v5310: Result<
                                                                        string,
                                                                        string,
                                                                    > = match &v4817 {
                                                                        Spiral::US10::US10_0(
                                                                            v4817_0_0,
                                                                        ) => Ok::<string, string>(
                                                                            v4817_0_0.clone(),
                                                                        ),
                                                                        Spiral::US10::US10_1(
                                                                            v4817_1_0,
                                                                        ) => Err::<string, string>(
                                                                            v4817_1_0.clone(),
                                                                        ),
                                                                    };
                                                                    let patternInput_27:
                                                                                    (i32,
                                                                                     string) =
                                                                                Spiral::method96(v5233.clone(),
                                                                                                 None::<CancellationToken>,
                                                                                                 v5291.clone(),
                                                                                                 None::<Func1<(i32,
                                                                                                               string,
                                                                                                               bool),
                                                                                                              Arc<Async<()>>>>,
                                                                                                 None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                              ()>>,
                                                                                                 true,
                                                                                                 v5310.ok());
                                                                    let v5328: string =
                                                                        patternInput_27.1.clone();
                                                                    let v5327: i32 =
                                                                        patternInput_27.0.clone();
                                                                    let v5329: i32 =
                                                                        get_Count(v5291.clone());
                                                                    let v5330: Array<string> =
                                                                        new_init(
                                                                            &string(""),
                                                                            v5329,
                                                                        );
                                                                    let v5331: LrcPtr<
                                                                        Spiral::Mut5,
                                                                    > = LrcPtr::new(Spiral::Mut5 {
                                                                        l0: MutCell::new(0_i32),
                                                                    });
                                                                    while Spiral::method31(
                                                                        v5329,
                                                                        v5331.clone(),
                                                                    ) {
                                                                        let v5333: i32 =
                                                                            v5331.l0.get().clone();
                                                                        let patternInput_28: (
                                                                            string,
                                                                            string,
                                                                        ) = v5291[v5333].clone();
                                                                        let v5336: string = sprintf!(
                                                                            "$env:{}=\'\'{}\'\'",
                                                                            patternInput_28
                                                                                .0
                                                                                .clone(),
                                                                            patternInput_28
                                                                                .1
                                                                                .clone()
                                                                        );
                                                                        v5330.get_mut()
                                                                            [v5333 as usize] =
                                                                            v5336;
                                                                        {
                                                                            let v5337: i32 =
                                                                                (v5333) + 1_i32;
                                                                            v5331.l0.set(v5337);
                                                                            ()
                                                                        }
                                                                    }
                                                                    {
                                                                        let v5349: string = sprintf!(
                                                                            "pwsh -c \'{}; {}\'",
                                                                            join(
                                                                                string(";"),
                                                                                toArray_1(
                                                                                    ofArray_1(
                                                                                        v5330
                                                                                            .clone(
                                                                                            )
                                                                                    )
                                                                                )
                                                                            ),
                                                                            v5233
                                                                        );
                                                                        let patternInput_29: (
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                        ) = if (v5327) == 0_i32 {
                                                                            let result_3: LrcPtr<
                                                                                MutCell<
                                                                                    Spiral::US5,
                                                                                >,
                                                                            > = refCell(
                                                                                Spiral::US5::US5_1,
                                                                            );
                                                                            try_catch(||
                                                                                                      result_3.set(Spiral::closure71((),
                                                                                                                                     Spiral::closure121(v5328.clone(),
                                                                                                                                                        ()))),
                                                                                                  |ex_3:
                                                                                                       LrcPtr<Exception>|
                                                                                                      result_3.set(Spiral::closure122(v5066.clone(),
                                                                                                                                      v5328.clone(),
                                                                                                                                      v5349.clone(),
                                                                                                                                      ex_3.clone())));
                                                                            {
                                                                                let v5356:
                                                                                                    Spiral::US5 =
                                                                                                result_3.get().clone();
                                                                                let v5367:
                                                                                                    Option<string> =
                                                                                                match &v5356
                                                                                                    {
                                                                                                    Spiral::US5::US5_0(v5356_0_0)
                                                                                                    =>
                                                                                                    Some(match &v5356
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
                                                                                             Spiral::US5::US5_0(v5230),
                                                                                             Spiral::US5::US5_0(v5066.clone()),
                                                                                             Spiral::US5::US5_0(v5367.unwrap()))
                                                                            }
                                                                        } else {
                                                                            let v5376: () = {
                                                                                Spiral::closure124(
                                                                                    v5066,
                                                                                    v5328,
                                                                                    v5327,
                                                                                    v5349,
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
                                                    v34.clone(),
                                                )) == string("python")
                                                {
                                                    let v5438: string = Spiral::method183();
                                                    let v5445: &str = &*v5438;
                                                    let v5473: Option<std::string::String> =
                                                        clap::ArgMatches::get_one(
                                                            &v35.clone(),
                                                            v5445,
                                                        )
                                                        .cloned();
                                                    let v5492: Spiral::US7 = defaultValue(
                                                        Spiral::US7::US7_1,
                                                        map(Spiral::method23(), v5473),
                                                    );
                                                    let v5499: std::string::String = match &v5492 {
                                                        Spiral::US7::US7_0(v5492_0_0) => {
                                                            match &v5492 {
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
                                                    let v5501: string =
                                                        fable_library_rust::String_::fromString(
                                                            v5499,
                                                        );
                                                    let v5502: string = Spiral::method24();
                                                    let v5509: &str = &*v5502;
                                                    let v5537: Option<Vec<std::string::String>> =
                                                        clap::ArgMatches::get_many(
                                                            &v35.clone(),
                                                            v5509,
                                                        )
                                                        .map(|x| x.cloned().into_iter().collect());
                                                    let v5556: Spiral::US8 = defaultValue(
                                                        Spiral::US8::US8_1,
                                                        map(Spiral::method25(), v5537),
                                                    );
                                                    let v5562: Vec<std::string::String> =
                                                        new_empty::<std::string::String>().to_vec();
                                                    let v5565: Vec<std::string::String> =
                                                        match &v5556 {
                                                            Spiral::US8::US8_0(v5556_0_0) => {
                                                                match &v5556 {
                                                                    Spiral::US8::US8_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone()
                                                            }
                                                            _ => v5562.clone(),
                                                        };
                                                    let v5566: bool =
                                                        if let Spiral::US0::US0_0 = &v0_1 {
                                                            true
                                                        } else {
                                                            false
                                                        };
                                                    let v5578: Result<Vec<u8>, std::io::Error> =
                                                        std::fs::read(&*v5501);
                                                    let v5623: Vec<u8> =
                                                        Spiral::method26(v5578.unwrap());
                                                    let v5625: Result<
                                                        std::string::String,
                                                        std::string::FromUtf8Error,
                                                    > = std::string::String::from_utf8(v5623);
                                                    let v5629: std::string::String = v5625.unwrap();
                                                    let v5664: string =
                                                        fable_library_rust::String_::fromString(
                                                            v5629,
                                                        );
                                                    let v5675: string = Spiral::method28(sprintf!(
                                                        "{:?}",
                                                        (string("py"), v5664.clone())
                                                    ));
                                                    let v5677: Spiral::US5 =
                                                        Spiral::method34(Spiral::method33());
                                                    let v5683:
                                                                    Spiral::US5 =
                                                                match &v5677 {
                                                                    Spiral::US5::US5_0(v5677_0_0)
                                                                    =>
                                                                    Spiral::US5::US5_0(match &v5677
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
                                                    let v5689: Spiral::US5 = match &v5683 {
                                                        Spiral::US5::US5_0(v5683_0_0) => {
                                                            Spiral::US5::US5_0(
                                                                match &v5683 {
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
                                                    let v5693: string = match &v5689 {
                                                        Spiral::US5::US5_0(v5689_0_0) => {
                                                            match &v5689 {
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
                                                    let v5708: string = Spiral::method35(
                                                        if string("deps")
                                                            == (Spiral::method54(v5693.clone()))
                                                        {
                                                            let v5701: Spiral::US5 =
                                                                Spiral::method34(
                                                                    Spiral::method40(v5693.clone())
                                                                        .clone()
                                                                        .unwrap(),
                                                                );
                                                            match &v5701
                                                                                         {
                                                                                         Spiral::US5::US5_0(v5701_0_0)
                                                                                         =>
                                                                                         match &v5701
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
                                                            v5693
                                                        },
                                                        string("polyglot"),
                                                    );
                                                    let v5712: string = toLower(Spiral::method33());
                                                    let v5717: string = toLower(v5708);
                                                    let v5726: Spiral::US10 =
                                                        if startsWith3(v5712, v5717.clone(), false)
                                                        {
                                                            Spiral::US10::US10_1(v5717.clone())
                                                        } else {
                                                            Spiral::US10::US10_0(v5717)
                                                        };
                                                    let v5738: Result<string, string> = match &v5726
                                                    {
                                                        Spiral::US10::US10_0(v5726_0_0) => {
                                                            Ok::<string, string>(v5726_0_0.clone())
                                                        }
                                                        Spiral::US10::US10_1(v5726_1_0) => {
                                                            Err::<string, string>(v5726_1_0.clone())
                                                        }
                                                    };
                                                    let v5740: bool = true;
                                                    let _result_unwrap_or_else = v5738
                                                        .unwrap_or_else(|x| {
                                                            //;
                                                            let v5742: string = x;
                                                            let v5744: bool = true;
                                                            v5742
                                                        });
                                                    let v5746: string = _result_unwrap_or_else;
                                                    let v5751: string = Spiral::method207(
                                                        Spiral::US5::US5_0(v5675.clone()),
                                                        string("spiral"),
                                                        Spiral::US39::US39_0(Spiral::US38::US38_2),
                                                        v5746.clone(),
                                                    );
                                                    let v5757: string = Spiral::method208(
                                                        v5664,
                                                        string("spiral"),
                                                        LrcPtr::new(Spiral::UH2::UH2_0),
                                                        LrcPtr::new(Spiral::UH4::UH4_1(
                                                            string("Fable.Core"),
                                                            string("4.3.0"),
                                                            LrcPtr::new(Spiral::UH4::UH4_0),
                                                        )),
                                                        v5751.clone(),
                                                        v5746.clone(),
                                                    );
                                                    Spiral::method216(Spiral::method35(Spiral::method35(v5746,
                                                                                                                string("lib/python/fable/fable_modules")),
                                                                                               string("fable_library")),
                                                                              Spiral::method35(v5751.clone(),
                                                                                               string("fable_modules/fable_library")));
                                                    {
                                                        let patternInput_31: (i32, string) =
                                                            Spiral::method217(
                                                                Spiral::US36::US36_1,
                                                                v5751.clone(),
                                                                string("py"),
                                                                v5757,
                                                                v5726.clone(),
                                                            );
                                                        let v5766: string =
                                                            patternInput_31.1.clone();
                                                        let v5765: i32 = patternInput_31.0.clone();
                                                        let patternInput_35: (
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                        ) = if (v5765) != 0_i32 {
                                                            let v5773: () = {
                                                                Spiral::closure125(
                                                                    v5766.clone(),
                                                                    v5765,
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            (
                                                                Spiral::US5::US5_0(string("py")),
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_0(v5766),
                                                            )
                                                        } else {
                                                            let v5825: bool = true;
                                                            let _vec_map : Vec<_> = v5565.into_iter().map(|x| { //;
                                                                        let v5827:
                                                                                std::string::String =
                                                                            x;
                                                                        let v5829:
                                                                                string =
                                                                            fable_library_rust::String_::fromString(v5827);
                                                                        let v5836:
                                                                                string =
                                                                            if contains(v5829.clone(),
                                                                                        string("="))
                                                                               {
                                                                                v5829.clone()
                                                                            } else {
                                                                                concat(new_array(&[string("\""),
                                                                                                   v5829,
                                                                                                   string("\":\"*\"")]))
                                                                            };
                                                                        let v5838:
                                                                                bool =
                                                                            true; v5836 }).collect::<Vec<_>>();
                                                            let v5840: Vec<string> = _vec_map;
                                                            let v5842:
                                                                                Array<string> =
                                                                            fable_library_rust::NativeArray_::array_from(v5840.clone());
                                                            let v5859: string = join(
                                                                string(",\n"),
                                                                toArray_1(delay(Func0::new({
                                                                    let v5842 = v5842.clone();
                                                                    move || {
                                                                        map_1(
                                                                            Func1::new({
                                                                                let v5842 =
                                                                                    v5842.clone();
                                                                                move |i_4: i32| {
                                                                                    v5842[i_4]
                                                                                        .clone()
                                                                                }
                                                                            }),
                                                                            rangeNumeric(
                                                                                0_i32,
                                                                                1_i32,
                                                                                (get_Count(
                                                                                    v5842.clone(),
                                                                                )) - 1_i32,
                                                                            ),
                                                                        )
                                                                    }
                                                                }))),
                                                            );
                                                            let v5875:
                                                                                string =
                                                                            append((append((append((append((append((append((append(string("{"),
                                                                                                                                   (concat(new_array(&[string("  \"name\": \"spiral_"),
                                                                                                                                                       v5675,
                                                                                                                                                       string("\",")]))))),
                                                                                                                           string("  \"dependencies\": {"))),
                                                                                                                   (v5859))),
                                                                                                           string("  },"))),
                                                                                                   string("    \"devDependencies\": {"))),
                                                                                           string("  },"))),
                                                                                   string("}"));
                                                            let v5877: string = Spiral::method35(
                                                                v5751.clone(),
                                                                string("package.json"),
                                                            );
                                                            let v5880: string = Spiral::method35(
                                                                Spiral::method35(
                                                                    v5751.clone(),
                                                                    string("../.."),
                                                                ),
                                                                string("package.json"),
                                                            );
                                                            Spiral::method71(v5877, v5875);
                                                            Spiral::method71(v5880, string(""));
                                                            {
                                                                let v5883: string =
                                                                    Spiral::method35(
                                                                        v5751,
                                                                        concat(new_array(&[
                                                                            string("spiral"),
                                                                            string("."),
                                                                            string("py"),
                                                                        ])),
                                                                    );
                                                                let v5886: () = {
                                                                    Spiral::closure126(
                                                                        v5883.clone(),
                                                                        (),
                                                                    );
                                                                    ()
                                                                };
                                                                let v5944: Result<
                                                                    Vec<u8>,
                                                                    std::io::Error,
                                                                > = std::fs::read(&*v5883.clone());
                                                                let v5989: Vec<u8> =
                                                                    Spiral::method26(
                                                                        v5944.unwrap(),
                                                                    );
                                                                let v5991: Result<
                                                                    std::string::String,
                                                                    std::string::FromUtf8Error,
                                                                > = std::string::String::from_utf8(
                                                                    v5989,
                                                                );
                                                                let v5995: std::string::String =
                                                                    v5991.unwrap();
                                                                let v6030:
                                                                                    string =
                                                                                fable_library_rust::String_::fromString(v5995);
                                                                let v6038: bool = contains(
                                                                    v6030.clone(),
                                                                    string(
                                                                        "# spiral.process_python",
                                                                    ),
                                                                );
                                                                let v6050: string = if v6038 {
                                                                    v6030.clone()
                                                                } else {
                                                                    Spiral::method65(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                     string(" defaultOf::<()>();"),
                                                                                                     replace(v6030,
                                                                                                             append(string("),)"),
                                                                                                                    (";".into())),
                                                                                                             string("));")))
                                                                };
                                                                if (v6038) == false {
                                                                    Spiral::method71(v5883.clone(),
                                                                                                 concat(new_array(&[v6050.clone(),
                                                                                                                    string("\n\n"),
                                                                                                                    string("# spiral.process_python"),
                                                                                                                    string("\n")])));
                                                                }
                                                                {
                                                                    let v6053: string =
                                                                        concat(new_array(&[
                                                                            string("python \""),
                                                                            v5883.clone(),
                                                                            string("\""),
                                                                        ]));
                                                                    let v6056: Array<(
                                                                        string,
                                                                        string,
                                                                    )> = new_array(&[(
                                                                        string("TRACE_LEVEL"),
                                                                        string("Verbose"),
                                                                    )]);
                                                                    let v6073: Result<
                                                                        string,
                                                                        string,
                                                                    > = match &v5726 {
                                                                        Spiral::US10::US10_0(
                                                                            v5726_0_0,
                                                                        ) => Ok::<string, string>(
                                                                            v5726_0_0.clone(),
                                                                        ),
                                                                        Spiral::US10::US10_1(
                                                                            v5726_1_0,
                                                                        ) => Err::<string, string>(
                                                                            v5726_1_0.clone(),
                                                                        ),
                                                                    };
                                                                    let patternInput_32:
                                                                                        (i32,
                                                                                         string) =
                                                                                    Spiral::method96(v6053.clone(),
                                                                                                     None::<CancellationToken>,
                                                                                                     v6056.clone(),
                                                                                                     None::<Func1<(i32,
                                                                                                                   string,
                                                                                                                   bool),
                                                                                                                  Arc<Async<()>>>>,
                                                                                                     None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                                  ()>>,
                                                                                                     true,
                                                                                                     v6073.ok());
                                                                    let v6091: string =
                                                                        patternInput_32.1.clone();
                                                                    let v6090: i32 =
                                                                        patternInput_32.0.clone();
                                                                    let v6092: i32 =
                                                                        get_Count(v6056.clone());
                                                                    let v6093: Array<string> =
                                                                        new_init(
                                                                            &string(""),
                                                                            v6092,
                                                                        );
                                                                    let v6094: LrcPtr<
                                                                        Spiral::Mut5,
                                                                    > = LrcPtr::new(Spiral::Mut5 {
                                                                        l0: MutCell::new(0_i32),
                                                                    });
                                                                    while Spiral::method31(
                                                                        v6092,
                                                                        v6094.clone(),
                                                                    ) {
                                                                        let v6096: i32 =
                                                                            v6094.l0.get().clone();
                                                                        let patternInput_33: (
                                                                            string,
                                                                            string,
                                                                        ) = v6056[v6096].clone();
                                                                        let v6099: string = sprintf!(
                                                                            "$env:{}=\'\'{}\'\'",
                                                                            patternInput_33
                                                                                .0
                                                                                .clone(),
                                                                            patternInput_33
                                                                                .1
                                                                                .clone()
                                                                        );
                                                                        v6093.get_mut()
                                                                            [v6096 as usize] =
                                                                            v6099;
                                                                        {
                                                                            let v6100: i32 =
                                                                                (v6096) + 1_i32;
                                                                            v6094.l0.set(v6100);
                                                                            ()
                                                                        }
                                                                    }
                                                                    {
                                                                        let v6112: string = sprintf!(
                                                                            "pwsh -c \'{}; {}\'",
                                                                            join(
                                                                                string(";"),
                                                                                toArray_1(
                                                                                    ofArray_1(
                                                                                        v6093
                                                                                            .clone(
                                                                                            )
                                                                                    )
                                                                                )
                                                                            ),
                                                                            v6053
                                                                        );
                                                                        let patternInput_34: (
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                        ) = if (v6090) == 0_i32 {
                                                                            let result_4: LrcPtr<
                                                                                MutCell<
                                                                                    Spiral::US5,
                                                                                >,
                                                                            > = refCell(
                                                                                Spiral::US5::US5_1,
                                                                            );
                                                                            try_catch(||
                                                                                                          result_4.set(Spiral::closure71((),
                                                                                                                                         Spiral::closure127(v6091.clone(),
                                                                                                                                                            ()))),
                                                                                                      |ex_4:
                                                                                                           LrcPtr<Exception>|
                                                                                                          result_4.set(Spiral::closure128(v5883.clone(),
                                                                                                                                          v6091.clone(),
                                                                                                                                          v6112.clone(),
                                                                                                                                          ex_4.clone())));
                                                                            {
                                                                                let v6119:
                                                                                                        Spiral::US5 =
                                                                                                    result_4.get().clone();
                                                                                let v6130:
                                                                                                        Option<string> =
                                                                                                    match &v6119
                                                                                                        {
                                                                                                        Spiral::US5::US5_0(v6119_0_0)
                                                                                                        =>
                                                                                                        Some(match &v6119
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
                                                                                                 Spiral::US5::US5_0(v6050),
                                                                                                 Spiral::US5::US5_0(v5883.clone()),
                                                                                                 Spiral::US5::US5_0(v6130.unwrap()))
                                                                            }
                                                                        } else {
                                                                            let v6139: () = {
                                                                                Spiral::closure130(
                                                                                    v5883,
                                                                                    v6091,
                                                                                    v6090,
                                                                                    v6112,
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
                                                    let v6200: () = {
                                                        Spiral::closure131(v35, v34, ());
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
                                        let v6262: Spiral::US5 = patternInput_38.3.clone();
                                        let v6261: Spiral::US5 = patternInput_38.2.clone();
                                        let v6260: Spiral::US5 = patternInput_38.1.clone();
                                        let v6259: Spiral::US5 = patternInput_38.0.clone();
                                        new_array(&[
                                            (
                                                string("extension"),
                                                match &v6259 {
                                                    Spiral::US5::US5_0(v6259_0_0) => match &v6259 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => string(""),
                                                },
                                            ),
                                            (
                                                string("code"),
                                                match &v6260 {
                                                    Spiral::US5::US5_0(v6260_0_0) => match &v6260 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => string(""),
                                                },
                                            ),
                                            (
                                                string("code_path"),
                                                match &v6261 {
                                                    Spiral::US5::US5_0(v6261_0_0) => match &v6261 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => string(""),
                                                },
                                            ),
                                            (
                                                string("output"),
                                                match &v6262 {
                                                    Spiral::US5::US5_0(v6262_0_0) => match &v6262 {
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
                    let v6296: Vec<(string, string)> = v6294.to_vec();
                    let v6299: bool = true;
                    let _func1_from_v6297 = Func1::from(move |value| {
                        //;
                        let patternInput_39: (string, string) = value;
                        let v6309: &str = &*patternInput_39.0.clone();
                        let v6342: std::string::String = String::from(v6309);
                        let v6375: &str = &*patternInput_39.1.clone();
                        let v6408: std::string::String = String::from(v6375);
                        let v6441: bool = true;
                        LrcPtr::new((v6342, v6408)) /*;
                                                    let v6443: bool = */
                    }); //;
                    let v6445: Func1<
                        (string, string),
                        LrcPtr<(std::string::String, std::string::String)>,
                    > = _func1_from_v6297;
                    let v6448: Vec<LrcPtr<(std::string::String, std::string::String)>> = v6296
                        .into_iter()
                        .map(|x| {
                            Func1::new({
                                let v6445 = v6445.clone();
                                move |arg10_0040_29: (string, string)| {
                                    Spiral::closure76(v6445.clone(), arg10_0040_29)
                                }
                            })(x.clone())
                        })
                        .collect::<Vec<_>>();
                    let v6449: string =
                string("std::collections::BTreeMap::from_iter(v6448.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                    let v6450: std::collections::BTreeMap<
                        std::string::String,
                        std::string::String,
                    > = std::collections::BTreeMap::from_iter(
                        v6448
                            .iter()
                            .map(|x| x.as_ref())
                            .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                    );
                    let v6452: Result<std::string::String, serde_json::Error> =
                        serde_json::to_string(&v6450);
                    let v6453 = Spiral::method280();
                    let v6457: Result<std::string::String, string> = v6452.map_err(|x| v6453(x));
                    let v6470: bool = true;
                    let _result_map_ = v6457.map(|x| {
                        //;
                        let v6472: std::string::String = x;
                        let v6474: string = fable_library_rust::String_::fromString(v6472);
                        let v6476: bool = true;
                        v6474
                    });
                    let v6478: Result<string, string> = _result_map_;
                    let v6481: string = string("}");
                    let v6486: bool = true;
                    let _fix_closure_v6483 = v6478;
                    let v6493: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v6483 "), (v6481))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v6494: bool = true;
                    _fix_closure_v6483
                },
            ); // rust.fix_closure';
            let v6496 = __future_init;
            v6496
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
