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
mod module_6ff740fe {
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
                    let v105: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                    let v105: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                    let v137: Spiral::US15 = if string("") == (v1_1.get().clone()) {
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
                    let v149: Spiral::US15 = match &v137 {
                        Spiral::US15::US15_0(v137_0_0, v137_0_1, v137_0_2, v137_0_3, v137_0_4) => {
                            let v138: char = v137_0_0.clone();
                            Spiral::US15::US15_0(
                                if '\\' == (v138) { '/' } else { v138 },
                                v137_0_1.clone(),
                                v137_0_2.clone(),
                                v137_0_3.clone(),
                                v137_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v137_1_0) => Spiral::US15::US15_1(v137_1_0.clone()),
                    };
                    match &v149 {
                        Spiral::US15::US15_0(v149_0_0, v149_0_1, v149_0_2, v149_0_3, v149_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v149_0_0.clone())));
                            let v1_1_temp: string = v149_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v149_0_2.clone();
                            let v3_temp: i32 = v149_0_3.clone();
                            let v4_temp: i32 = v149_0_4.clone();
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
                    let v145: Spiral::US15 = if string("") == (v1_1.get().clone()) {
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
                    let v100: Spiral::US15 = if string("") == (v1_1.get().clone()) {
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
                    match &v100 {
                        Spiral::US15::US15_0(v100_0_0, v100_0_1, v100_0_2, v100_0_3, v100_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v100_0_0.clone())));
                            let v1_1_temp: string = v100_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v100_0_2.clone();
                            let v3_temp: i32 = v100_0_3.clone();
                            let v4_temp: i32 = v100_0_4.clone();
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
                let v235: Spiral::US16 = match &v23 {
                    Spiral::US15::US15_0(v23_0_0, v23_0_1, v23_0_2, v23_0_3, v23_0_4) => {
                        let v28: i32 = v23_0_4.clone();
                        let v27: i32 = v23_0_3.clone();
                        let v26: LrcPtr<StringBuilder> = v23_0_2.clone();
                        let v25: string = v23_0_1.clone();
                        let v161: Spiral::US15 = if string("") == (v25.clone()) {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                (v26.clone(), v27, v28)
                            ))
                        } else {
                            let v49: char = getCharAt(v25.clone(), 0_i32);
                            if (Spiral::method104(v49, 0_i64)) == false {
                                let v86: string = getSlice(
                                    v25.clone(),
                                    Some(1_i32),
                                    Some((length(v25.clone())) - 1_i32),
                                );
                                let v92: string = ofChar(v49);
                                let v95: i32 = length(v92.clone());
                                let v96: Array<char> = new_init(&'\u{0000}', v95);
                                let v97: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method31(v95, v97.clone()) {
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
                                        Spiral::method101(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method100())(b0)(b1)
                                                    },
                                                ),
                                                v103,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v26.clone(),
                                            v27,
                                            v28,
                                        );
                                    Spiral::US15::US15_0(
                                        v49,
                                        v86,
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
                        let v173: Spiral::US15 = match &v161 {
                            Spiral::US15::US15_0(
                                v161_0_0,
                                v161_0_1,
                                v161_0_2,
                                v161_0_3,
                                v161_0_4,
                            ) => {
                                let v162: char = v161_0_0.clone();
                                Spiral::US15::US15_0(
                                    if '\\' == (v162) { '/' } else { v162 },
                                    v161_0_1.clone(),
                                    v161_0_2.clone(),
                                    v161_0_3.clone(),
                                    v161_0_4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v161_1_0) => {
                                Spiral::US15::US15_1(v161_1_0.clone())
                            }
                        };
                        let v193: Spiral::US16 = match &v173 {
                            Spiral::US15::US15_0(
                                v173_0_0,
                                v173_0_1,
                                v173_0_2,
                                v173_0_3,
                                v173_0_4,
                            ) => {
                                let patternInput_1: (
                                    string,
                                    string,
                                    LrcPtr<StringBuilder>,
                                    i32,
                                    i32,
                                ) = Spiral::method105(
                                    ofChar(v173_0_0.clone()),
                                    v173_0_1.clone(),
                                    v173_0_2.clone(),
                                    v173_0_3.clone(),
                                    v173_0_4.clone(),
                                );
                                Spiral::US16::US16_0(
                                    patternInput_1.0.clone(),
                                    patternInput_1.1.clone(),
                                    patternInput_1.2.clone(),
                                    patternInput_1.3.clone(),
                                    patternInput_1.4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v173_1_0) => {
                                Spiral::US16::US16_1(v173_1_0.clone())
                            }
                        };
                        let v203: Spiral::US16 = match &v193 {
                            Spiral::US16::US16_0(
                                v193_0_0,
                                v193_0_1,
                                v193_0_2,
                                v193_0_3,
                                v193_0_4,
                            ) => Spiral::US16::US16_0(
                                v193_0_0.clone(),
                                v193_0_1.clone(),
                                v193_0_2.clone(),
                                v193_0_3.clone(),
                                v193_0_4.clone(),
                            ),
                            _ => {
                                Spiral::US16::US16_0(string(""), v25.clone(), v26.clone(), v27, v28)
                            }
                        };
                        match &v203 {
                            Spiral::US16::US16_0(
                                v203_0_0,
                                v203_0_1,
                                v203_0_2,
                                v203_0_3,
                                v203_0_4,
                            ) => {
                                let v208: i32 = v203_0_4.clone();
                                let v207: i32 = v203_0_3.clone();
                                let v206: LrcPtr<StringBuilder> = v203_0_2.clone();
                                let v205: string = v203_0_1.clone();
                                let v212: Spiral::US15 = Spiral::method106(
                                    v205.clone(),
                                    v206.clone(),
                                    v207,
                                    v208,
                                    LrcPtr::new(Spiral::UH1::UH1_1(
                                        Func1::from(v18),
                                        LrcPtr::new(Spiral::UH1::UH1_1(
                                            Func1::from(v19),
                                            LrcPtr::new(Spiral::UH1::UH1_0),
                                        )),
                                    )),
                                );
                                match &v212 {
                                        Spiral::US15::US15_0(v212_0_0,
                                                             v212_0_1,
                                                             v212_0_2,
                                                             v212_0_3,
                                                             v212_0_4) =>
                                        Spiral::US16::US16_0(v203_0_0.clone(),
                                                             v212_0_1.clone(),
                                                             v212_0_2.clone(),
                                                             v212_0_3.clone(),
                                                             v212_0_4.clone()),
                                        Spiral::US15::US15_1(v212_1_0) =>
                                        Spiral::US16::US16_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                      v212_1_0.clone(),
                                                                      (v9.clone(),
                                                                       v15.clone(),
                                                                       1_i32,
                                                                       1_i32),
                                                                      (v25.clone(),
                                                                       v26.clone(),
                                                                       v27,
                                                                       v28),
                                                                      (v205.clone(),
                                                                       v206.clone(),
                                                                       v207,
                                                                       v208))),
                                    }
                            }
                            _ => Spiral::US16::US16_1(string("parsing.between / expected content")),
                        }
                    }
                    Spiral::US15::US15_1(v23_1_0) => Spiral::US16::US16_1(v23_1_0.clone()),
                };
                let v493: Spiral::US16 = match &v235 {
                    Spiral::US16::US16_0(v235_0_0, v235_0_1, v235_0_2, v235_0_3, v235_0_4) => {
                        v235.clone()
                    }
                    _ => {
                        let v384: Spiral::US15 = if string("") == (v9.clone()) {
                            Spiral::US15::US15_1(sprintf!(
                                "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                (v15.clone(), 1_i32, 1_i32)
                            ))
                        } else {
                            let v266: char = getCharAt(v9.clone(), 0_i32);
                            if (Spiral::method107(v266, 0_i64)) == false {
                                let v303: string = getSlice(
                                    v9.clone(),
                                    Some(1_i32),
                                    Some((length(v9.clone())) - 1_i32),
                                );
                                let v309: string = ofChar(v266);
                                let v312: i32 = length(v309.clone());
                                let v313: Array<char> = new_init(&'\u{0000}', v312);
                                let v314: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method31(v312, v314.clone()) {
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
                                        Spiral::method101(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method100())(b0)(b1)
                                                    },
                                                ),
                                                v320,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v15.clone(),
                                            1_i32,
                                            1_i32,
                                        );
                                    Spiral::US15::US15_0(
                                        v266,
                                        v303,
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone(),
                                        patternInput_2.2.clone(),
                                    )
                                }
                            } else {
                                Spiral::US15::US15_1(sprintf!("parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                                                      v266,
                                                                      toArray(ofArray(new_array(&['\"',
                                                                                                  '\'',
                                                                                                  ' ']))),
                                                                      (v15.clone(),
                                                                       1_i32,
                                                                       1_i32)))
                            }
                        };
                        let v396: Spiral::US15 = match &v384 {
                            Spiral::US15::US15_0(
                                v384_0_0,
                                v384_0_1,
                                v384_0_2,
                                v384_0_3,
                                v384_0_4,
                            ) => {
                                let v385: char = v384_0_0.clone();
                                Spiral::US15::US15_0(
                                    if '\\' == (v385) { '/' } else { v385 },
                                    v384_0_1.clone(),
                                    v384_0_2.clone(),
                                    v384_0_3.clone(),
                                    v384_0_4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v384_1_0) => {
                                Spiral::US15::US15_1(v384_1_0.clone())
                            }
                        };
                        let v416: Spiral::US16 = match &v396 {
                            Spiral::US15::US15_0(
                                v396_0_0,
                                v396_0_1,
                                v396_0_2,
                                v396_0_3,
                                v396_0_4,
                            ) => {
                                let patternInput_3: (
                                    string,
                                    string,
                                    LrcPtr<StringBuilder>,
                                    i32,
                                    i32,
                                ) = Spiral::method108(
                                    ofChar(v396_0_0.clone()),
                                    v396_0_1.clone(),
                                    v396_0_2.clone(),
                                    v396_0_3.clone(),
                                    v396_0_4.clone(),
                                );
                                Spiral::US16::US16_0(
                                    patternInput_3.0.clone(),
                                    patternInput_3.1.clone(),
                                    patternInput_3.2.clone(),
                                    patternInput_3.3.clone(),
                                    patternInput_3.4.clone(),
                                )
                            }
                            Spiral::US15::US15_1(v396_1_0) => {
                                Spiral::US16::US16_1(v396_1_0.clone())
                            }
                        };
                        match &v416 {
                            Spiral::US16::US16_0(
                                v416_0_0,
                                v416_0_1,
                                v416_0_2,
                                v416_0_3,
                                v416_0_4,
                            ) => v416.clone(),
                            _ => {
                                let v431: Spiral::US18 = if (length(v9.clone())) == 0_i32 {
                                    Spiral::US18::US18_0(v9.clone(), v15.clone(), 1_i32, 1_i32)
                                } else {
                                    Spiral::US18::US18_1(sprintf!(
                                        "parsing.eof / expected end of input / input: {:?}",
                                        v9.clone()
                                    ))
                                };
                                let v440: Spiral::US16 = match &v431 {
                                    Spiral::US18::US18_0(
                                        v431_0_0,
                                        v431_0_1,
                                        v431_0_2,
                                        v431_0_3,
                                    ) => Spiral::US16::US16_0(
                                        string(""),
                                        v431_0_0.clone(),
                                        v431_0_1.clone(),
                                        v431_0_2.clone(),
                                        v431_0_3.clone(),
                                    ),
                                    Spiral::US18::US18_1(v431_1_0) => {
                                        Spiral::US16::US16_1(v431_1_0.clone())
                                    }
                                };
                                match &v440 {
                                    Spiral::US16::US16_0(
                                        v440_0_0,
                                        v440_0_1,
                                        v440_0_2,
                                        v440_0_3,
                                        v440_0_4,
                                    ) => {
                                        let v442: string = v440_0_1.clone();
                                        Spiral::US16::US16_0(
                                            v440_0_0.clone(),
                                            getSlice(
                                                v442.clone(),
                                                Some(Spiral::method109(v442.clone(), 0_i32)),
                                                Some((length(v442)) - 1_i32),
                                            ),
                                            v440_0_2.clone(),
                                            v440_0_3.clone(),
                                            v440_0_4.clone(),
                                        )
                                    }
                                    Spiral::US16::US16_1(v440_1_0) => {
                                        Spiral::US16::US16_1(v440_1_0.clone())
                                    }
                                }
                            }
                        }
                    }
                };
                let v821: Spiral::US19 = match &v493 {
                    Spiral::US16::US16_0(v493_0_0, v493_0_1, v493_0_2, v493_0_3, v493_0_4) => {
                        let v498: i32 = v493_0_4.clone();
                        let v497: i32 = v493_0_3.clone();
                        let v496: LrcPtr<StringBuilder> = v493_0_2.clone();
                        let v495: string = v493_0_1.clone();
                        let v658: Spiral::US15 = if string("") == (v495.clone()) {
                            Spiral::US15::US15_1(sprintf!(
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
                                let v551: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method31(v549, v551.clone()) {
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
                                        Spiral::method101(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method100())(b0)(b1)
                                                    },
                                                ),
                                                v557,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v496.clone(),
                                            v497,
                                            v498,
                                        );
                                    Spiral::US15::US15_0(
                                        v505,
                                        v540,
                                        patternInput_4.0.clone(),
                                        patternInput_4.1.clone(),
                                        patternInput_4.2.clone(),
                                    )
                                }
                            } else {
                                let v600: i32 = (indexOf(v495.clone(), string("\n"))) - 1_i32;
                                Spiral::US15::US15_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                         ' ',
                                                                                         v497,
                                                                                         v498,
                                                                                         v496.clone(),
                                                                                         getSlice(v495.clone(),
                                                                                                  Some(0_i32),
                                                                                                  Some((if -2_i32
                                                                                                               ==
                                                                                                               (v600)
                                                                                                           {
                                                                                                            (length(v495.clone()))
                                                                                                                +
                                                                                                                1_i32
                                                                                                        } else {
                                                                                                            (v600)
                                                                                                                +
                                                                                                                1_i32
                                                                                                        })
                                                                                                           -
                                                                                                           1_i32))),
                                                                                string("\n"),
                                                                                append(((Spiral::method102((v498)
                                                                                                               -
                                                                                                               1_i32,
                                                                                                           0_i32))(string(""))),
                                                                                       string("^")),
                                                                                string("\n")])))
                            }
                        };
                        let v670: Spiral::US20 = match &v658 {
                            Spiral::US15::US15_0(
                                v658_0_0,
                                v658_0_1,
                                v658_0_2,
                                v658_0_3,
                                v658_0_4,
                            ) => Spiral::US20::US20_0(
                                Spiral::US17::US17_0(v658_0_0.clone()),
                                v658_0_1.clone(),
                                v658_0_2.clone(),
                                v658_0_3.clone(),
                                v658_0_4.clone(),
                            ),
                            _ => Spiral::US20::US20_0(
                                Spiral::US17::US17_1,
                                v495.clone(),
                                v496.clone(),
                                v497,
                                v498,
                            ),
                        };
                        let v795: Spiral::US16 = match &v670 {
                            Spiral::US20::US20_0(
                                v670_0_0,
                                v670_0_1,
                                v670_0_2,
                                v670_0_3,
                                v670_0_4,
                            ) => {
                                let v675: i32 = v670_0_4.clone();
                                let v674: i32 = v670_0_3.clone();
                                let v673: LrcPtr<StringBuilder> = v670_0_2.clone();
                                let v672: string = v670_0_1.clone();
                                let v771: Spiral::US15 = if string("") == (v672.clone()) {
                                    Spiral::US15::US15_1(sprintf!(
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
                                    let v727: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method31(v725, v727.clone()) {
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
                                            Spiral::method101(
                                                foldBack(
                                                    Func2::new(
                                                        move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                            (Spiral::method100())(b0)(b1)
                                                        },
                                                    ),
                                                    v733,
                                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                                ),
                                                v673,
                                                v674,
                                                v675,
                                            );
                                        Spiral::US15::US15_0(
                                            v682,
                                            v716,
                                            patternInput_5.0.clone(),
                                            patternInput_5.1.clone(),
                                            patternInput_5.2.clone(),
                                        )
                                    }
                                };
                                match &v771 {
                                    Spiral::US15::US15_0(
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
                                        ) = Spiral::method110(
                                            ofChar(v771_0_0.clone()),
                                            v771_0_1.clone(),
                                            v771_0_2.clone(),
                                            v771_0_3.clone(),
                                            v771_0_4.clone(),
                                        );
                                        Spiral::US16::US16_0(
                                            patternInput_6.0.clone(),
                                            patternInput_6.1.clone(),
                                            patternInput_6.2.clone(),
                                            patternInput_6.3.clone(),
                                            patternInput_6.4.clone(),
                                        )
                                    }
                                    Spiral::US15::US15_1(v771_1_0) => {
                                        Spiral::US16::US16_1(v771_1_0.clone())
                                    }
                                }
                            }
                            Spiral::US20::US20_1(v670_1_0) => {
                                Spiral::US16::US16_1(v670_1_0.clone())
                            }
                        };
                        let v807: Spiral::US21 = match &v795 {
                            Spiral::US16::US16_0(
                                v795_0_0,
                                v795_0_1,
                                v795_0_2,
                                v795_0_3,
                                v795_0_4,
                            ) => Spiral::US21::US21_0(
                                Spiral::US5::US5_0(v795_0_0.clone()),
                                v795_0_1.clone(),
                                v795_0_2.clone(),
                                v795_0_3.clone(),
                                v795_0_4.clone(),
                            ),
                            _ => Spiral::US21::US21_0(
                                Spiral::US5::US5_1,
                                v495.clone(),
                                v496.clone(),
                                v497,
                                v498,
                            ),
                        };
                        match &v807 {
                            Spiral::US21::US21_0(
                                v807_0_0,
                                v807_0_1,
                                v807_0_2,
                                v807_0_3,
                                v807_0_4,
                            ) => Spiral::US19::US19_0(
                                v493_0_0.clone(),
                                v807_0_0.clone(),
                                v807_0_1.clone(),
                                v807_0_2.clone(),
                                v807_0_3.clone(),
                                v807_0_4.clone(),
                            ),
                            Spiral::US21::US21_1(v807_1_0) => {
                                Spiral::US19::US19_1(v807_1_0.clone())
                            }
                        }
                    }
                    Spiral::US16::US16_1(v493_1_0) => Spiral::US19::US19_1(v493_1_0.clone()),
                };
                match &v821 {
                    Spiral::US19::US19_0(
                        v821_0_0,
                        v821_0_1,
                        v821_0_2,
                        v821_0_3,
                        v821_0_4,
                        v821_0_5,
                    ) => Spiral::US14::US14_0(v821_0_0.clone(), v821_0_1.clone()),
                    Spiral::US19::US19_1(v821_1_0) => Spiral::US14::US14_1(v821_1_0.clone()),
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
                    let v153: Spiral::US15 = if string("") == (v1_1.get().clone()) {
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
                    match &v153 {
                        Spiral::US15::US15_0(v153_0_0, v153_0_1, v153_0_2, v153_0_3, v153_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v153_0_0.clone())));
                            let v1_1_temp: string = v153_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v153_0_2.clone();
                            let v3_temp: i32 = v153_0_3.clone();
                            let v4_temp: i32 = v153_0_4.clone();
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
            let v164: Spiral::US15 = if string("") == (v0_1.clone()) {
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
                    let v105: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                            ((Spiral::method102((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            };
            let v269: Spiral::US15 = match &v164 {
                Spiral::US15::US15_0(v164_0_0, v164_0_1, v164_0_2, v164_0_3, v164_0_4) => {
                    let v169: i32 = v164_0_4.clone();
                    let v168: i32 = v164_0_3.clone();
                    let v167: LrcPtr<StringBuilder> = v164_0_2.clone();
                    let v166: string = v164_0_1.clone();
                    if string("") == (v166.clone()) {
                        Spiral::US15::US15_1(sprintf!(
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
                        let v221: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Spiral::method31(v219, v221.clone()) {
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
                            let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method101(
                                    foldBack(
                                        Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                            (Spiral::method100())(b0)(b1)
                                        }),
                                        v227,
                                        LrcPtr::new(Spiral::UH0::UH0_0),
                                    ),
                                    v167,
                                    v168,
                                    v169,
                                );
                            Spiral::US15::US15_0(
                                v176,
                                v210,
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                            )
                        }
                    }
                }
                Spiral::US15::US15_1(v164_1_0) => Spiral::US15::US15_1(v164_1_0.clone()),
            };
            match &v269 {
                Spiral::US15::US15_0(v269_0_0, v269_0_1, v269_0_2, v269_0_3, v269_0_4) => {
                    Spiral::US16::US16_0(
                        append((ofChar('\\')), (ofChar(v269_0_0.clone()))),
                        v269_0_1.clone(),
                        v269_0_2.clone(),
                        v269_0_3.clone(),
                        v269_0_4.clone(),
                    )
                }
                Spiral::US15::US15_1(v269_1_0) => Spiral::US16::US16_1(v269_1_0.clone()),
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
            let v164: Spiral::US15 = if string("") == (v0_1.clone()) {
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
                    let v105: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                            ((Spiral::method102((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            };
            let v269: Spiral::US15 = match &v164 {
                Spiral::US15::US15_0(v164_0_0, v164_0_1, v164_0_2, v164_0_3, v164_0_4) => {
                    let v169: i32 = v164_0_4.clone();
                    let v168: i32 = v164_0_3.clone();
                    let v167: LrcPtr<StringBuilder> = v164_0_2.clone();
                    let v166: string = v164_0_1.clone();
                    if string("") == (v166.clone()) {
                        Spiral::US15::US15_1(sprintf!(
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
                        let v221: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Spiral::method31(v219, v221.clone()) {
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
                            let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method101(
                                    foldBack(
                                        Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                            (Spiral::method100())(b0)(b1)
                                        }),
                                        v227,
                                        LrcPtr::new(Spiral::UH0::UH0_0),
                                    ),
                                    v167,
                                    v168,
                                    v169,
                                );
                            Spiral::US15::US15_0(
                                v176,
                                v210,
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                            )
                        }
                    }
                }
                Spiral::US15::US15_1(v164_1_0) => Spiral::US15::US15_1(v164_1_0.clone()),
            };
            match &v269 {
                Spiral::US15::US15_0(v269_0_0, v269_0_1, v269_0_2, v269_0_3, v269_0_4) => {
                    Spiral::US16::US16_0(
                        append((ofChar('`')), (ofChar(v269_0_0.clone()))),
                        v269_0_1.clone(),
                        v269_0_2.clone(),
                        v269_0_3.clone(),
                        v269_0_4.clone(),
                    )
                }
                Spiral::US15::US15_1(v269_1_0) => Spiral::US16::US16_1(v269_1_0.clone()),
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
                    let v145: Spiral::US15 = if string("") == (v1_1.get().clone()) {
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
                    let v160: Spiral::US16 = match &v145 {
                        Spiral::US15::US15_0(v145_0_0, v145_0_1, v145_0_2, v145_0_3, v145_0_4) => {
                            Spiral::US16::US16_0(
                                ofChar(v145_0_0.clone()),
                                v145_0_1.clone(),
                                v145_0_2.clone(),
                                v145_0_3.clone(),
                                v145_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v145_1_0) => Spiral::US16::US16_1(v145_1_0.clone()),
                    };
                    let v174: Spiral::US16 = match &v160 {
                        Spiral::US16::US16_0(v160_0_0, v160_0_1, v160_0_2, v160_0_3, v160_0_4) => {
                            v160.clone()
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
                    match &v174 {
                        Spiral::US16::US16_0(v174_0_0, v174_0_1, v174_0_2, v174_0_3, v174_0_4) => {
                            let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(Spiral::UH2::UH2_1(
                                v174_0_0.clone(),
                                v0_1.get().clone(),
                            ));
                            let v1_1_temp: string = v174_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v174_0_2.clone();
                            let v3_temp: i32 = v174_0_3.clone();
                            let v4_temp: i32 = v174_0_4.clone();
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
                    let v145: Spiral::US15 = if string("") == (v1_1.get().clone()) {
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
                    let v160: Spiral::US16 = match &v145 {
                        Spiral::US15::US15_0(v145_0_0, v145_0_1, v145_0_2, v145_0_3, v145_0_4) => {
                            Spiral::US16::US16_0(
                                ofChar(v145_0_0.clone()),
                                v145_0_1.clone(),
                                v145_0_2.clone(),
                                v145_0_3.clone(),
                                v145_0_4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v145_1_0) => Spiral::US16::US16_1(v145_1_0.clone()),
                    };
                    match &v160 {
                        Spiral::US16::US16_0(v160_0_0, v160_0_1, v160_0_2, v160_0_3, v160_0_4) => {
                            let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(Spiral::UH2::UH2_1(
                                v160_0_0.clone(),
                                v0_1.get().clone(),
                            ));
                            let v1_1_temp: string = v160_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v160_0_2.clone();
                            let v3_temp: i32 = v160_0_3.clone();
                            let v4_temp: i32 = v160_0_4.clone();
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
                    let v153: Spiral::US15 = if v5 {
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
                    let v173: Spiral::US16 = match &v153 {
                        Spiral::US15::US15_0(v153_0_0, v153_0_1, v153_0_2, v153_0_3, v153_0_4) => {
                            let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method114(
                                    ofChar(v153_0_0.clone()),
                                    v153_0_1.clone(),
                                    v153_0_2.clone(),
                                    v153_0_3.clone(),
                                    v153_0_4.clone(),
                                );
                            Spiral::US16::US16_0(
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                                patternInput_1.3.clone(),
                                patternInput_1.4.clone(),
                            )
                        }
                        Spiral::US15::US15_1(v153_1_0) => Spiral::US16::US16_1(v153_1_0.clone()),
                    };
                    let v635: Spiral::US16 = match &v173 {
                        Spiral::US16::US16_0(v173_0_0, v173_0_1, v173_0_2, v173_0_3, v173_0_4) => {
                            v173.clone()
                        }
                        _ => {
                            let v339: Spiral::US15 = if v5 {
                                Spiral::US15::US15_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                                                               '\"',
                                                                               (v2.get().clone(),
                                                                                v3.get().clone(),
                                                                                v4.get().clone())))
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
                                    let v231: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method31(v229, v231.clone()) {
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
                                            Spiral::method101(
                                                foldBack(
                                                    Func2::new(
                                                        move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                            (Spiral::method100())(b0)(b1)
                                                        },
                                                    ),
                                                    v237,
                                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                                ),
                                                v2.get().clone(),
                                                v3.get().clone(),
                                                v4.get().clone(),
                                            );
                                        Spiral::US15::US15_0(
                                            v185,
                                            v220,
                                            patternInput_2.0.clone(),
                                            patternInput_2.1.clone(),
                                            patternInput_2.2.clone(),
                                        )
                                    }
                                } else {
                                    let v280: i32 =
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
                                                                                             append(((Spiral::method102((v4.get().clone())
                                                                                                                            -
                                                                                                                            1_i32,
                                                                                                                        0_i32))(string(""))),
                                                                                                    string("^")),
                                                                                             string("\n")])))
                                }
                            };
                            let v566: Spiral::US16 = match &v339 {
                                Spiral::US15::US15_0(
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
                                    let v346: Spiral::US23 = Spiral::method115(
                                        LrcPtr::new(Spiral::UH2::UH2_0),
                                        v341.clone(),
                                        v342.clone(),
                                        v343,
                                        v344,
                                    );
                                    let v377: Spiral::US16 = match &v346 {
                                        Spiral::US23::US23_0(
                                            v346_0_0,
                                            v346_0_1,
                                            v346_0_2,
                                            v346_0_3,
                                            v346_0_4,
                                        ) => {
                                            let v353: List<string> = Spiral::method119(
                                                v346_0_0.clone(),
                                                empty::<string>(),
                                            );
                                            Spiral::US16::US16_0(
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
                                        Spiral::US23::US23_1(v346_1_0) => {
                                            Spiral::US16::US16_1(v346_1_0.clone())
                                        }
                                    };
                                    match &v377 {
                                        Spiral::US16::US16_0(
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
                                            let v543: Spiral::US15 = if string("") == (v379.clone())
                                            {
                                                Spiral::US15::US15_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
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
                                                    let v434: Array<char> =
                                                        new_init(&'\u{0000}', v433);
                                                    let v435: LrcPtr<Spiral::Mut5> =
                                                        LrcPtr::new(Spiral::Mut5 {
                                                            l0: MutCell::new(0_i32),
                                                        });
                                                    while Spiral::method31(v433, v435.clone()) {
                                                        let v437: i32 = v435.l0.get().clone();
                                                        let v438: char =
                                                            getCharAt(v430.clone(), v437);
                                                        v434.get_mut()[v437 as usize] = v438;
                                                        {
                                                            let v439: i32 = (v437) + 1_i32;
                                                            v435.l0.set(v439);
                                                            ()
                                                        }
                                                    }
                                                    {
                                                        let v441: List<char> =
                                                            ofArray(v434.clone());
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
                                                                                                            v441,
                                                                                                            LrcPtr::new(Spiral::UH0::UH0_0)),
                                                                                                   v380.clone(),
                                                                                                   v381,
                                                                                                   v382);
                                                        Spiral::US15::US15_0(
                                                            v389,
                                                            v424,
                                                            patternInput_3.0.clone(),
                                                            patternInput_3.1.clone(),
                                                            patternInput_3.2.clone(),
                                                        )
                                                    }
                                                } else {
                                                    let v484: i32 =
                                                        (indexOf(v379.clone(), string("\n")))
                                                            - 1_i32;
                                                    Spiral::US15::US15_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
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
                                                                                                                 append(((Spiral::method102((v382)
                                                                                                                                                -
                                                                                                                                                1_i32,
                                                                                                                                            0_i32))(string(""))),
                                                                                                                        string("^")),
                                                                                                                 string("\n")])))
                                                }
                                            };
                                            match &v543 {
                                                                 Spiral::US15::US15_0(v543_0_0,
                                                                                      v543_0_1,
                                                                                      v543_0_2,
                                                                                      v543_0_3,
                                                                                      v543_0_4)
                                                                 =>
                                                                 Spiral::US16::US16_0(v377_0_0.clone(),
                                                                                      v543_0_1.clone(),
                                                                                      v543_0_2.clone(),
                                                                                      v543_0_3.clone(),
                                                                                      v543_0_4.clone()),
                                                                 Spiral::US15::US15_1(v543_1_0)
                                                                 =>
                                                                 Spiral::US16::US16_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                                               v543_1_0.clone(),
                                                                                               (v1_1.get().clone(),
                                                                                                v2.get().clone(),
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
                                        _ => Spiral::US16::US16_1(string(
                                            "parsing.between / expected content",
                                        )),
                                    }
                                }
                                Spiral::US15::US15_1(v339_1_0) => {
                                    Spiral::US16::US16_1(v339_1_0.clone())
                                }
                            };
                            match &v566 {
                                Spiral::US16::US16_0(
                                    v566_0_0,
                                    v566_0_1,
                                    v566_0_2,
                                    v566_0_3,
                                    v566_0_4,
                                ) => v566.clone(),
                                _ => {
                                    let v578: Spiral::US16 =
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
                                    let v589: Spiral::US16 = match &v578 {
                                        Spiral::US16::US16_0(
                                            v578_0_0,
                                            v578_0_1,
                                            v578_0_2,
                                            v578_0_3,
                                            v578_0_4,
                                        ) => Spiral::US16::US16_0(
                                            string(""),
                                            v578_0_1.clone(),
                                            v578_0_2.clone(),
                                            v578_0_3.clone(),
                                            v578_0_4.clone(),
                                        ),
                                        Spiral::US16::US16_1(v578_1_0) => {
                                            Spiral::US16::US16_1(v578_1_0.clone())
                                        }
                                    };
                                    let v600: Spiral::US23 = match &v589 {
                                        Spiral::US16::US16_0(
                                            v589_0_0,
                                            v589_0_1,
                                            v589_0_2,
                                            v589_0_3,
                                            v589_0_4,
                                        ) => Spiral::method120(
                                            LrcPtr::new(Spiral::UH2::UH2_0),
                                            v589_0_1.clone(),
                                            v589_0_2.clone(),
                                            v589_0_3.clone(),
                                            v589_0_4.clone(),
                                        ),
                                        Spiral::US16::US16_1(v589_1_0) => {
                                            Spiral::US23::US23_1(v589_1_0.clone())
                                        }
                                    };
                                    match &v600 {
                                        Spiral::US23::US23_0(
                                            v600_0_0,
                                            v600_0_1,
                                            v600_0_2,
                                            v600_0_3,
                                            v600_0_4,
                                        ) => {
                                            let v607: List<string> = Spiral::method119(
                                                v600_0_0.clone(),
                                                empty::<string>(),
                                            );
                                            Spiral::US16::US16_0(
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
                                        Spiral::US23::US23_1(v600_1_0) => {
                                            Spiral::US16::US16_1(v600_1_0.clone())
                                        }
                                    }
                                }
                            }
                        }
                    };
                    match &v635 {
                        Spiral::US16::US16_0(v635_0_0, v635_0_1, v635_0_2, v635_0_3, v635_0_4) => {
                            let v640: i32 = v635_0_4.clone();
                            let v639: i32 = v635_0_3.clone();
                            let v638: LrcPtr<StringBuilder> = v635_0_2.clone();
                            let v637: string = v635_0_1.clone();
                            let v636: string = v635_0_0.clone();
                            let v642: i32 = Spiral::method109(v637.clone(), 0_i32);
                            let v684: Spiral::US18 = if 0_i32 == (v642) {
                                Spiral::US18::US18_1(string(
                                    "parsing.spaces1 / expected at least one space",
                                ))
                            } else {
                                Spiral::US18::US18_0(
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
                                Spiral::US18::US18_0(v684_0_0, v684_0_1, v684_0_2, v684_0_3) => {
                                    let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(
                                        Spiral::UH2::UH2_1(v636.clone(), v0_1.get().clone()),
                                    );
                                    let v1_1_temp: string = v684_0_0.clone();
                                    let v2_temp: LrcPtr<StringBuilder> = v684_0_1.clone();
                                    let v3_temp: i32 = v684_0_2.clone();
                                    let v4_temp: i32 = v684_0_3.clone();
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
                                            v636.clone(),
                                            LrcPtr::new(Spiral::UH2::UH2_0),
                                        )),
                                    ),
                                    v637.clone(),
                                    v638.clone(),
                                    v639,
                                    v640,
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
                let v1731: LrcPtr<(i32, string)> = match &_capture_v175.get().clone() {
                    None => panic!("{}", string("base.capture / _capture_v175=None"),),
                    Some(_capture_v175_0_0) => _capture_v175_0_0.clone(),
                };
                let _run_target_args__v15: (i32, string) = (v1731.0.clone(), v1731.1.clone());
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
            let v697: Spiral::US40 =
                defaultValue(Spiral::US40::US40_1, map(Spiral::method212(), v680));
            let v717: Spiral::US5 = match &v697 {
                Spiral::US40::US40_0(v697_0_0) => {
                    let v703: chrono::NaiveDateTime = match &v697 {
                        Spiral::US40::US40_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone()
                    .naive_utc();
                    let v705: chrono::DateTime<chrono::Local> =
                        chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &v703);
                    let v707: string = string("r#\"%Y%m%d-%H%M-%S%f\"#");
                    let v708: &str = r#"%Y%m%d-%H%M-%S%f"#;
                    let v710: std::string::String = v705.format(v708).to_string();
                    let v712: string = fable_library_rust::String_::fromString(v710);
                    Spiral::US5::US5_0(sprintf!(
                        "{}-{}-{}",
                        getSlice(v712.clone(), Some(0_i32), Some(17_i32)),
                        getSlice(v712.clone(), Some(18_i32), Some(21_i32)),
                        getCharAt(v712, 22_i32)
                    ))
                }
                _ => Spiral::US5::US5_1,
            };
            let v721: string = match &v717 {
                Spiral::US5::US5_0(v717_0_0) => match &v717 {
                    Spiral::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                _ => string(""),
            };
            let v728: LrcPtr<TimeZoneInfo> = std::sync::Arc::new(
                chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64,
            );
            let v766: i64 = v586.ticks();
            let v801: string =
                string("chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))");
            let v942: TimeSpan = TimeSpan::new_ticks(chrono::FixedOffset::local_minus_utc(
                &chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(
                    &chrono::DateTime::from_timestamp_nanos(v766),
                )),
            ) as i64);
            let v957: u8 = if (v942.hours()) > 0_i32 { 1_u8 } else { 0_u8 };
            let v958: string = Spiral::method213();
            let v1127: string = v942.toString(v958);
            let v1182: string = sprintf!(
                "{}{}{}",
                v957,
                getSlice(v1127.clone(), Some(0_i32), Some(1_i32)),
                getSlice(v1127, Some(3_i32), Some(4_i32))
            );
            let v1185: string = toString(v0_1);
            parse(concat(new_array(&[
                v721.clone(),
                v1182.clone(),
                getSlice(
                    v1185.clone(),
                    Some((length(v721)) + (length(v1182))),
                    Some((length(v1185)) - 1_i32),
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
                    let v6207: Array<(string, string)> = if let Spiral::US6::US6_0(
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
                                    "/home/runner/work/spiral/polyglot/target/Builder/spiral",
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
                                    let v844: bool = true;
                                    LrcPtr::new((v745, v811)) /*;
                                                              let v846: bool = */
                                }); //;
                                let v848: Func1<
                                    (string, string),
                                    LrcPtr<(std::string::String, std::string::String)>,
                                > = _func1_from_v700;
                                let v851: Vec<LrcPtr<(std::string::String, std::string::String)>> =
                                    v699.into_iter()
                                        .map(|x| {
                                            Func1::new({
                                                let v848 = v848.clone();
                                                move |arg10_0040_3: (string, string)| {
                                                    Spiral::closure76(v848.clone(), arg10_0040_3)
                                                }
                                            })(x.clone())
                                        })
                                        .collect::<Vec<_>>();
                                let v852: string =
                                string("std::collections::BTreeMap::from_iter(v851.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                                let v853: std::collections::BTreeMap<
                                    std::string::String,
                                    std::string::String,
                                > = std::collections::BTreeMap::from_iter(
                                    v851.iter()
                                        .map(|x| x.as_ref())
                                        .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                                );
                                let v855: Result<std::string::String, serde_json::Error> =
                                    serde_json::to_string(&v853);
                                let v859: std::string::String = v855.unwrap();
                                new_array(&[(
                                    string("command_result"),
                                    fable_library_rust::String_::fromString(v859),
                                )])
                            }
                        } else {
                            if (fable_library_rust::String_::fromString(v32.clone()))
                                == string("cuda")
                            {
                                let v878: string = Spiral::method177();
                                let v885: &str = &*v878;
                                let v913: Option<std::string::String> =
                                    clap::ArgMatches::get_one(&v33.clone(), v885).cloned();
                                let v930: Spiral::US7 =
                                    defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v913));
                                let v937: std::string::String = match &v930 {
                                    Spiral::US7::US7_0(v930_0_0) => match &v930 {
                                        Spiral::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => panic!("{}", string("Option does not have a value."),),
                                };
                                let v939: string = fable_library_rust::String_::fromString(v937);
                                let v940: string = Spiral::method178();
                                let v947: &str = &*v940;
                                let v975: Option<std::string::String> =
                                    clap::ArgMatches::get_one(&v33.clone(), v947).cloned();
                                let v992: Spiral::US7 =
                                    defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v975));
                                let v1021: Spiral::US33 = match &v992 {
                                    Spiral::US7::US7_0(v992_0_0) => {
                                        let v998: string = fable_library_rust::String_::fromString(
                                            match &v992 {
                                                Spiral::US7::US7_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        );
                                        let v1003: Spiral::US34 = if string("Pip") == (v998.clone())
                                        {
                                            Spiral::US34::US34_0(Spiral::US35::US35_0)
                                        } else {
                                            Spiral::US34::US34_1
                                        };
                                        Spiral::US33::US33_0(match &v1003 {
                                            Spiral::US34::US34_0(v1003_0_0) => {
                                                Spiral::US34::US34_0(
                                                    match &v1003 {
                                                        Spiral::US34::US34_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                )
                                            }
                                            _ => {
                                                let v1010: Spiral::US34 =
                                                    if string("Poetry") == (v998.clone()) {
                                                        Spiral::US34::US34_0(Spiral::US35::US35_1)
                                                    } else {
                                                        Spiral::US34::US34_1
                                                    };
                                                match &v1010 {
                                                    Spiral::US34::US34_0(v1010_0_0) => {
                                                        Spiral::US34::US34_0(
                                                            match &v1010 {
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
                                let v1028: Spiral::US34 =
                                    if let Spiral::US33::US33_0(v1021_0_0) = &v1021 {
                                        let v1022: Spiral::US34 = v1021_0_0.clone();
                                        if let Spiral::US34::US34_0(v1022_0_0) = &v1022 {
                                            Spiral::US34::US34_0(v1022_0_0.clone())
                                        } else {
                                            Spiral::US34::US34_1
                                        }
                                    } else {
                                        Spiral::US34::US34_1
                                    };
                                let v1032: Spiral::US35 = match &v1028 {
                                    Spiral::US34::US34_0(v1028_0_0) => match &v1028 {
                                        Spiral::US34::US34_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => Spiral::US35::US35_0,
                                };
                                let v1033: string = Spiral::method24();
                                let v1040: &str = &*v1033;
                                let v1068: Option<Vec<std::string::String>> =
                                    clap::ArgMatches::get_many(&v33.clone(), v1040)
                                        .map(|x| x.cloned().into_iter().collect());
                                let v1085: Spiral::US8 = defaultValue(
                                    Spiral::US8::US8_1,
                                    map(Spiral::method25(), v1068),
                                );
                                let v1091: Vec<std::string::String> =
                                    new_empty::<std::string::String>().to_vec();
                                let v1094: Vec<std::string::String> = match &v1085 {
                                    Spiral::US8::US8_0(v1085_0_0) => match &v1085 {
                                        Spiral::US8::US8_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => v1091.clone(),
                                };
                                let v1106: Result<Vec<u8>, std::io::Error> =
                                    std::fs::read(&*v939.clone());
                                let v1151: Vec<u8> = Spiral::method26(v1106.unwrap());
                                let v1153: Result<std::string::String, std::string::FromUtf8Error> =
                                    std::string::String::from_utf8(v1151);
                                let v1157: std::string::String = v1153.unwrap();
                                let v1170: string = fable_library_rust::String_::fromString(v1157);
                                let v1199: Spiral::US5 = Spiral::method34(Spiral::method33());
                                let v1205: Spiral::US5 = match &v1199 {
                                    Spiral::US5::US5_0(v1199_0_0) => Spiral::US5::US5_0(
                                        match &v1199 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => Spiral::method34(string(
                                        "/home/runner/work/spiral/polyglot/target/Builder/spiral",
                                    )),
                                };
                                let v1211: Spiral::US5 = match &v1205 {
                                    Spiral::US5::US5_0(v1205_0_0) => Spiral::US5::US5_0(
                                        match &v1205 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => Spiral::method34(string("/workspaces")),
                                };
                                let v1215: string = match &v1211 {
                                    Spiral::US5::US5_0(v1211_0_0) => match &v1211 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => panic!("{}", string("Option does not have a value."),),
                                };
                                let v1230: string = Spiral::method35(
                                    if string("deps") == (Spiral::method54(v1215.clone())) {
                                        let v1223: Spiral::US5 = Spiral::method34(
                                            Spiral::method40(v1215.clone()).clone().unwrap(),
                                        );
                                        match &v1223 {
                                            Spiral::US5::US5_0(v1223_0_0) => match &v1223 {
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
                                        v1215
                                    },
                                    string("polyglot"),
                                );
                                let v1234: string = toLower(Spiral::method33());
                                let v1239: string = toLower(v1230);
                                let v1248: Spiral::US10 =
                                    if startsWith3(v1234, v1239.clone(), false) {
                                        Spiral::US10::US10_1(v1239.clone())
                                    } else {
                                        Spiral::US10::US10_0(v1239)
                                    };
                                let v1254: Result<string, string> = match &v1248 {
                                    Spiral::US10::US10_0(v1248_0_0) => {
                                        Ok::<string, string>(v1248_0_0.clone())
                                    }
                                    Spiral::US10::US10_1(v1248_1_0) => {
                                        Err::<string, string>(v1248_1_0.clone())
                                    }
                                };
                                let v1256: bool = true;
                                let _result_unwrap_or_else = v1254.unwrap_or_else(|x| {
                                    //;
                                    let v1258: string = x;
                                    let v1260: bool = true;
                                    v1258
                                });
                                let v1262: string = _result_unwrap_or_else;
                                let v1266: string =
                                    defaultValue(string(""), Spiral::method40(v939.clone()));
                                let v1274: string = match &v1032 {
                                    Spiral::US35::US35_1 => {
                                        Spiral::method35(v1266.clone(), string("pyproject.toml"))
                                    }
                                    _ => {
                                        Spiral::method35(v1266.clone(), string("requirements.txt"))
                                    }
                                };
                                let v1276: bool = true;
                                let _vec_map: Vec<_> = v1094
                                    .into_iter()
                                    .map(|x| {
                                        //;
                                        let v1278: std::string::String = x;
                                        let v1280: string =
                                            fable_library_rust::String_::fromString(v1278);
                                        let v1297: string = if contains(v1280.clone(), string("="))
                                        {
                                            v1280.clone()
                                        } else {
                                            if endsWith3(v1280.clone(), string("]"), false) {
                                                concat(new_array(&[
                                                    replace(
                                                        v1280.clone(),
                                                        string("["),
                                                        string("={version=\'*\',features=["),
                                                    ),
                                                    string("}"),
                                                ]))
                                            } else {
                                                concat(new_array(&[v1280, string("=\'*\'")]))
                                            }
                                        };
                                        let v1299: bool = true;
                                        v1297
                                    })
                                    .collect::<Vec<_>>();
                                let v1301: Vec<string> = _vec_map;
                                let v1303: Array<string> =
                                    fable_library_rust::NativeArray_::array_from(v1301.clone());
                                let _let__v1307: LrcPtr<dyn IEnumerable_1<string>> =
                                    delay(Func0::new({
                                        let v1303 = v1303.clone();
                                        move || {
                                            map_1(
                                                Func1::new({
                                                    let v1303 = v1303.clone();
                                                    move |i_1: i32| v1303[i_1].clone()
                                                }),
                                                rangeNumeric(
                                                    0_i32,
                                                    1_i32,
                                                    (get_Count(v1303.clone())) - 1_i32,
                                                ),
                                            )
                                        }
                                    }));
                                let v1320: string =
                                    join(Spiral::method70(), toArray_1(_let__v1307));
                                let patternInput_6: (i32, string) = if (v1320.clone()) == string("")
                                {
                                    (0_i32, string(""))
                                } else {
                                    Spiral::method71(v1274,
                                                     match &v1032 {
                                                         Spiral::US35::US35_1
                                                         =>
                                                         append((append((append((append((append((append((append((append((append(string("[tool.poetry]\nname = \"test\"\nversion = \"0.0.1\"\ndescription = \"\"\nauthors = []\n\n[tool.poetry.dependencies]\npython=\"~3.12\"\n"),
                                                                                                                                (v1320.clone()))),
                                                                                                                        string("\n"))),
                                                                                                                string(""))),
                                                                                                        string("\n"))),
                                                                                                string("[build-system]"))),
                                                                                        string("\n"))),
                                                                                string("requires = [\"poetry-core\"]"))),
                                                                        string("\n"))),
                                                                string("build-backend = \"poetry.core.masonry.api\"")),
                                                         _ => v1320.clone(),
                                                     });
                                    Spiral::method96(
                                        match &v1032 {
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
                                        Some(v1266.clone()),
                                    )
                                };
                                let v1381: i32 = patternInput_6.0.clone();
                                let patternInput_10: (
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                ) = if (v1381) != 0_i32 {
                                    let v1389: () = {
                                        Spiral::closure77(
                                            v1032.clone(),
                                            v939.clone(),
                                            patternInput_6.1.clone(),
                                            v1381,
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
                                    let v1444: string = match &v1032 {
                                        Spiral::US35::US35_1 => concat(new_array(&[
                                            string("poetry run python \""),
                                            v939.clone(),
                                            string("\""),
                                        ])),
                                        _ => concat(new_array(&[
                                            string("python \""),
                                            v939.clone(),
                                            string("\""),
                                        ])),
                                    };
                                    let v1447: Array<(string, string)> =
                                        new_array(&[(string("TRACE_LEVEL"), string("Verbose"))]);
                                    let patternInput_7: (i32, string) = Spiral::method96(
                                        v1444.clone(),
                                        None::<CancellationToken>,
                                        v1447.clone(),
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
                                        Some(v1266.clone()),
                                    );
                                    let v1459: string = patternInput_7.1.clone();
                                    let v1458: i32 = patternInput_7.0.clone();
                                    let v1460: i32 = get_Count(v1447.clone());
                                    let v1461: Array<string> = new_init(&string(""), v1460);
                                    let v1462: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method31(v1460, v1462.clone()) {
                                        let v1464: i32 = v1462.l0.get().clone();
                                        let patternInput_8: (string, string) = v1447[v1464].clone();
                                        let v1467: string = sprintf!(
                                            "$env:{}=\'\'{}\'\'",
                                            patternInput_8.0.clone(),
                                            patternInput_8.1.clone()
                                        );
                                        v1461.get_mut()[v1464 as usize] = v1467;
                                        {
                                            let v1468: i32 = (v1464) + 1_i32;
                                            v1462.l0.set(v1468);
                                            ()
                                        }
                                    }
                                    {
                                        let v1480: string = sprintf!(
                                            "pwsh -c \'{}; {}\'",
                                            join(string(";"), toArray_1(ofArray_1(v1461.clone()))),
                                            v1444
                                        );
                                        let patternInput_9: (
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                        ) = if if (v1458) == 0_i32 {
                                            true
                                        } else {
                                            contains(v1459.clone(),
                                                            string("cupy_backends.cuda.api.runtime.CUDARuntimeError: cudaErrorInsufficientDriver"))
                                        } {
                                            let result_1: LrcPtr<MutCell<Spiral::US5>> =
                                                refCell(Spiral::US5::US5_1);
                                            try_catch(
                                                || {
                                                    result_1.set(Spiral::closure71(
                                                        (),
                                                        Spiral::closure78(v1459.clone(), ()),
                                                    ))
                                                },
                                                |ex_1: LrcPtr<Exception>| {
                                                    result_1.set(Spiral::closure79(
                                                        v939.clone(),
                                                        v1459.clone(),
                                                        v1480.clone(),
                                                        ex_1.clone(),
                                                    ))
                                                },
                                            );
                                            {
                                                let v1493: Spiral::US5 = result_1.get().clone();
                                                let v1504: Option<string> = match &v1493 {
                                                    Spiral::US5::US5_0(v1493_0_0) => Some(
                                                        match &v1493 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    ),
                                                    _ => None::<string>,
                                                };
                                                (
                                                    Spiral::US5::US5_0(string("py")),
                                                    Spiral::US5::US5_0(v1170),
                                                    Spiral::US5::US5_0(v939.clone()),
                                                    Spiral::US5::US5_0(v1504.unwrap()),
                                                )
                                            }
                                        } else {
                                            let v1514: () = {
                                                Spiral::closure81(
                                                    v939.clone(),
                                                    v1459,
                                                    v1458,
                                                    v1480,
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
                                let v1573: Spiral::US5 = patternInput_10.3.clone();
                                let v1571: Spiral::US5 = patternInput_10.1.clone();
                                let v1570: Spiral::US5 = patternInput_10.0.clone();
                                let v1586: Array<(string, string)> = new_array(&[
                                    (
                                        string("extension"),
                                        match &v1570 {
                                            Spiral::US5::US5_0(v1570_0_0) => match &v1570 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("code"),
                                        match &v1571 {
                                            Spiral::US5::US5_0(v1571_0_0) => match &v1571 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("output"),
                                        match &v1573 {
                                            Spiral::US5::US5_0(v1573_0_0) => match &v1573 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                ]);
                                let v1588: Vec<(string, string)> = v1586.to_vec();
                                let v1591: bool = true;
                                let _func1_from_v1589 = Func1::from(move |value| {
                                    //;
                                    let patternInput_11: (string, string) = value;
                                    let v1601: &str = &*patternInput_11.0.clone();
                                    let v1634: std::string::String = String::from(v1601);
                                    let v1667: &str = &*patternInput_11.1.clone();
                                    let v1700: std::string::String = String::from(v1667);
                                    let v1733: bool = true;
                                    LrcPtr::new((v1634, v1700)) /*;
                                                                let v1735: bool = */
                                }); //;
                                let v1737: Func1<
                                    (string, string),
                                    LrcPtr<(std::string::String, std::string::String)>,
                                > = _func1_from_v1589;
                                let v1740: Vec<LrcPtr<(std::string::String, std::string::String)>> =
                                    v1588
                                        .into_iter()
                                        .map(|x| {
                                            Func1::new({
                                                let v1737 = v1737.clone();
                                                move |arg10_0040_7: (string, string)| {
                                                    Spiral::closure76(v1737.clone(), arg10_0040_7)
                                                }
                                            })(x.clone())
                                        })
                                        .collect::<Vec<_>>();
                                let v1741: string =
                                string("std::collections::BTreeMap::from_iter(v1740.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                                let v1742: std::collections::BTreeMap<
                                    std::string::String,
                                    std::string::String,
                                > = std::collections::BTreeMap::from_iter(
                                    v1740
                                        .iter()
                                        .map(|x| x.as_ref())
                                        .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                                );
                                let v1744: Result<std::string::String, serde_json::Error> =
                                    serde_json::to_string(&v1742);
                                let v1748: std::string::String = v1744.unwrap();
                                new_array(&[(
                                    string("command_result"),
                                    fable_library_rust::String_::fromString(v1748),
                                )])
                            } else {
                                if (fable_library_rust::String_::fromString(v32.clone()))
                                    == string("fable")
                                {
                                    let v1767: string = Spiral::method183();
                                    let v1774: &str = &*v1767;
                                    let v1802: Option<std::string::String> =
                                        clap::ArgMatches::get_one(&v33.clone(), v1774).cloned();
                                    let v1819: Spiral::US7 = defaultValue(
                                        Spiral::US7::US7_1,
                                        map(Spiral::method23(), v1802),
                                    );
                                    let v1826: std::string::String = match &v1819 {
                                        Spiral::US7::US7_0(v1819_0_0) => match &v1819 {
                                            Spiral::US7::US7_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => panic!("{}", string("Option does not have a value."),),
                                    };
                                    let v1828: string =
                                        fable_library_rust::String_::fromString(v1826);
                                    let v1829: string = Spiral::method184();
                                    let v1836: &str = &*v1829;
                                    let v1864: Option<std::string::String> =
                                        clap::ArgMatches::get_one(&v33.clone(), v1836).cloned();
                                    let v1881: Spiral::US7 = defaultValue(
                                        Spiral::US7::US7_1,
                                        map(Spiral::method23(), v1864),
                                    );
                                    let v1891: Spiral::US5 = match &v1881 {
                                        Spiral::US7::US7_0(v1881_0_0) => Spiral::US5::US5_0(
                                            fable_library_rust::String_::fromString(
                                                match &v1881 {
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
                                        match &v1891 {
                                            Spiral::US5::US5_0(v1891_0_0) => {
                                                let v1893: clap::Command = Spiral::method0();
                                                let v1895: Spiral::US22 =
                                                    Spiral::method111(sprintf!(
                                                        "_ {} --fs-path \"{}\"",
                                                        match &v1891 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                        v1828.clone()
                                                    ));
                                                let v1904:
                                                             Array<string> =
                                                         match &v1895 {
                                                             Spiral::US22::US22_0(v1895_0_0)
                                                             =>
                                                             v1895_0_0.clone(),
                                                             Spiral::US22::US22_1(v1895_1_0)
                                                             =>
                                                             panic!("{}",
                                                                    concat(new_array(&[string("resultm.get / Result value was Error: "),
                   v1895_1_0.clone()])),),
                                                         };
                                                let v1906: Vec<string> = v1904.to_vec();
                                                let v1908: bool = true;
                                                let _vec_map: Vec<_> = v1906
                                                    .into_iter()
                                                    .map(|x| {
                                                        //;
                                                        let v1910: string = x;
                                                        let v1917: &str = &*v1910;
                                                        let v1950: std::string::String =
                                                            String::from(v1917);
                                                        let v1978: bool = true;
                                                        v1950
                                                    })
                                                    .collect::<Vec<_>>();
                                                let v1980: Vec<std::string::String> = _vec_map;
                                                let v1983: std::pin::Pin<
                                                    Box<
                                                        dyn std::future::Future<
                                                            Output = Result<string, string>,
                                                        >,
                                                    >,
                                                > = Spiral::method20(
                                                    v0_1.clone(),
                                                    clap::Command::get_matches_from(v1893, v1980),
                                                );
                                                let v1985: Result<string, string> = v1983.await;
                                                v1985.unwrap()
                                            }
                                            _ => string("{}"),
                                        },
                                    )])
                                } else {
                                    if (fable_library_rust::String_::fromString(v32.clone()))
                                        == string("dib")
                                    {
                                        let v2009: string = Spiral::method185();
                                        let v2016: &str = &*v2009;
                                        let v2044: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v33.clone(), v2016).cloned();
                                        let v2047: Option<string> = map(Spiral::method186(), v2044);
                                        let v2062: string = v2047.unwrap();
                                        let v2063: string = Spiral::method192();
                                        let v2070: &str = &*v2063;
                                        let v2100: u8 = defaultValue(
                                            1_u8,
                                            clap::ArgMatches::get_one(&v33.clone(), v2070).cloned(),
                                        );
                                        let v2103: string = Spiral::method193();
                                        let v2110: &str = &*v2103;
                                        let v2138: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v33.clone(), v2110).cloned();
                                        let v2155: Spiral::US7 = defaultValue(
                                            Spiral::US7::US7_1,
                                            map(Spiral::method23(), v2138),
                                        );
                                        let patternInput_12: (i32, string) = Spiral::method194(
                                            match &v2155 {
                                                Spiral::US7::US7_0(v2155_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        fable_library_rust::String_::fromString(
                                                            match &v2155 {
                                                                Spiral::US7::US7_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        ),
                                                    )
                                                }
                                                _ => Spiral::US5::US5_1,
                                            },
                                            v2100,
                                            v2062.clone(),
                                            1_u8,
                                        );
                                        let v2168: string = patternInput_12.1.clone();
                                        let v2167: i32 = patternInput_12.0.clone();
                                        let patternInput_15: (i32, string) = if (v2167) != 0_i32 {
                                            (v2167, v2168.clone())
                                        } else {
                                            let patternInput_13:
                                                    (i32, string) =
                                                Spiral::method96(concat(new_array(&[string("jupyter nbconvert \""),
                                                                                    v2062.clone(),
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
                                            let v2181: string = patternInput_13.1.clone();
                                            let v2180: i32 = patternInput_13.0.clone();
                                            let v2184: () = {
                                                Spiral::closure84(v2181.clone(), v2180, ());
                                                ()
                                            };
                                            if (v2180) != 0_i32 {
                                                (
                                                    v2180,
                                                    concat(new_array(&[
                                                        string("repl_result: "),
                                                        v2168.clone(),
                                                        string("\n\njupyter_result: "),
                                                        v2181.clone(),
                                                    ])),
                                                )
                                            } else {
                                                let patternInput_14:
                                                        (i32, string) =
                                                    Spiral::method96(concat(new_array(&[string("pwsh -c \"$counter = 1; $path = \'"),
                                                                                        replace(v2062.clone(),
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
                                                let v2248: string = patternInput_14.1.clone();
                                                let v2247: i32 = patternInput_14.0.clone();
                                                let v2251: () = {
                                                    Spiral::closure85(v2248.clone(), v2247, ());
                                                    ()
                                                };
                                                let v2299: string = concat(new_array(&[
                                                    v2062.clone(),
                                                    string(".html"),
                                                ]));
                                                let v2311: Result<Vec<u8>, std::io::Error> =
                                                    std::fs::read(&*v2299);
                                                let v2356: Vec<u8> =
                                                    Spiral::method26(v2311.unwrap());
                                                let v2358: Result<
                                                    std::string::String,
                                                    std::string::FromUtf8Error,
                                                > = std::string::String::from_utf8(v2356);
                                                let v2362: std::string::String = v2358.unwrap();
                                                let v2405: string = replace(
                                                    fable_library_rust::String_::fromString(v2362),
                                                    string("\r\n"),
                                                    string("\n"),
                                                );
                                                let v2406: string = concat(new_array(&[
                                                    v2062.clone(),
                                                    string(".html"),
                                                ]));
                                                std::fs::write(&*v2406, &*v2405).unwrap();
                                                {
                                                    let v2409: string = concat(new_array(&[
                                                        v2062.clone(),
                                                        string(".ipynb"),
                                                    ]));
                                                    let v2421: Result<Vec<u8>, std::io::Error> =
                                                        std::fs::read(&*v2409);
                                                    let v2466: Vec<u8> =
                                                        Spiral::method26(v2421.unwrap());
                                                    let v2468: Result<
                                                        std::string::String,
                                                        std::string::FromUtf8Error,
                                                    > = std::string::String::from_utf8(v2466);
                                                    let v2472: std::string::String = v2468.unwrap();
                                                    let v2516: string = replace(
                                                        replace(
                                                            fable_library_rust::String_::fromString(
                                                                v2472,
                                                            ),
                                                            string("\r\n"),
                                                            string("\n"),
                                                        ),
                                                        string("\\r\\n"),
                                                        string("\\n"),
                                                    );
                                                    let v2517: string = concat(new_array(&[
                                                        v2062,
                                                        string(".ipynb"),
                                                    ]));
                                                    std::fs::write(&*v2517, &*v2516).unwrap();
                                                    (v2247,
                                                     sprintf!("repl_result: {}\n\njupyter_result: {}\n\npwsh_replace_html_result: {}",
                                                              v2168, v2181,
                                                              v2248))
                                                }
                                            }
                                        };
                                        let v2524: string = patternInput_15.1.clone();
                                        let v2523: i32 = patternInput_15.0.clone();
                                        let v2527: () = {
                                            Spiral::closure86(v2524.clone(), v2523, ());
                                            ()
                                        };
                                        if (v2523) != 0_i32 {
                                            panic!(
                                                "{}",
                                                sprintf!(
                                                    "spiral.run / dib / exit_code: {} / result: {}",
                                                    v2523,
                                                    v2524.clone()
                                                )
                                            );
                                        }
                                        new_array(&[(string("stdio"), v2524)])
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
                                            let v2585: string = Spiral::method183();
                                            let v2592: &str = &*v2585;
                                            let v2620: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v33.clone(), v2592)
                                                    .cloned();
                                            let v2637: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v2620),
                                            );
                                            let v2644: std::string::String = match &v2637 {
                                                Spiral::US7::US7_0(v2637_0_0) => match &v2637 {
                                                    Spiral::US7::US7_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => panic!(
                                                    "{}",
                                                    string("Option does not have a value."),
                                                ),
                                            };
                                            let v2646: string =
                                                fable_library_rust::String_::fromString(v2644);
                                            let v2647: string = Spiral::method24();
                                            let v2654: &str = &*v2647;
                                            let v2682: Option<Vec<std::string::String>> =
                                                clap::ArgMatches::get_many(&v33.clone(), v2654)
                                                    .map(|x| x.cloned().into_iter().collect());
                                            let v2699: Spiral::US8 = defaultValue(
                                                Spiral::US8::US8_1,
                                                map(Spiral::method25(), v2682),
                                            );
                                            let v2705: Vec<std::string::String> =
                                                new_empty::<std::string::String>().to_vec();
                                            let v2708: Vec<std::string::String> = match &v2699 {
                                                Spiral::US8::US8_0(v2699_0_0) => match &v2699 {
                                                    Spiral::US8::US8_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => v2705.clone(),
                                            };
                                            let v2709: string = Spiral::method203();
                                            let v2716: &str = &*v2709;
                                            let v2744: bool =
                                                clap::ArgMatches::get_flag(&v33.clone(), v2716);
                                            let v2745: string = Spiral::method204();
                                            let v2752: &str = &*v2745;
                                            let v2780: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v33.clone(), v2752)
                                                    .cloned();
                                            let v2797: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v2780),
                                            );
                                            let v2807: Spiral::US5 = match &v2797 {
                                                Spiral::US7::US7_0(v2797_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        fable_library_rust::String_::fromString(
                                                            match &v2797 {
                                                                Spiral::US7::US7_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        ),
                                                    )
                                                }
                                                _ => Spiral::US5::US5_1,
                                            };
                                            let v2808: string = Spiral::method205();
                                            let v2815: &str = &*v2808;
                                            let v2843: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v33.clone(), v2815)
                                                    .cloned();
                                            let v2860: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v2843),
                                            );
                                            let v2870: Spiral::US5 = match &v2860 {
                                                Spiral::US7::US7_0(v2860_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        fable_library_rust::String_::fromString(
                                                            match &v2860 {
                                                                Spiral::US7::US7_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        ),
                                                    )
                                                }
                                                _ => Spiral::US5::US5_1,
                                            };
                                            let v2879: Spiral::US36 =
                                                if let Spiral::US5::US5_0(v2807_0_0) = &v2807 {
                                                    Spiral::US36::US36_0(Spiral::US37::US37_0(
                                                        v2807_0_0.clone(),
                                                    ))
                                                } else {
                                                    if let Spiral::US5::US5_0(v2870_0_0) = &v2870 {
                                                        Spiral::US36::US36_0(Spiral::US37::US37_1(
                                                            v2870_0_0.clone(),
                                                        ))
                                                    } else {
                                                        Spiral::US36::US36_1
                                                    }
                                                };
                                            let v2891: Result<Vec<u8>, std::io::Error> =
                                                std::fs::read(&*v2646);
                                            let v2936: Vec<u8> = Spiral::method26(v2891.unwrap());
                                            let v2938: Result<
                                                std::string::String,
                                                std::string::FromUtf8Error,
                                            > = std::string::String::from_utf8(v2936);
                                            let v2942: std::string::String = v2938.unwrap();
                                            let v2977: string =
                                                fable_library_rust::String_::fromString(v2942);
                                            let v2985: string =
                                                Spiral::method28(Spiral::method206(
                                                    string("rs"),
                                                    v2977.clone(),
                                                    v2879.clone(),
                                                ));
                                            let v2987: Spiral::US5 =
                                                Spiral::method34(Spiral::method33());
                                            let v2993: Spiral::US5 =
                                                match &v2987 {
                                                    Spiral::US5::US5_0(v2987_0_0)
                                                    =>
                                                    Spiral::US5::US5_0(match &v2987
                                                                           {
                                                                           Spiral::US5::US5_0(x)
                                                                           =>
                                                                           x.clone(),
                                                                           _
                                                                           =>
                                                                           unreachable!(),
                                                                       }.clone()),
                                                    _ =>
                                                    Spiral::method34(string("/home/runner/work/spiral/polyglot/target/Builder/spiral")),
                                                };
                                            let v2999: Spiral::US5 = match &v2993 {
                                                Spiral::US5::US5_0(v2993_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        match &v2993 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => Spiral::method34(string("/workspaces")),
                                            };
                                            let v3003: string = match &v2999 {
                                                Spiral::US5::US5_0(v2999_0_0) => match &v2999 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => panic!(
                                                    "{}",
                                                    string("Option does not have a value."),
                                                ),
                                            };
                                            let v3018: string = Spiral::method35(
                                                if string("deps")
                                                    == (Spiral::method54(v3003.clone()))
                                                {
                                                    let v3011: Spiral::US5 = Spiral::method34(
                                                        Spiral::method40(v3003.clone())
                                                            .clone()
                                                            .unwrap(),
                                                    );
                                                    match &v3011 {
                                                        Spiral::US5::US5_0(v3011_0_0) => {
                                                            match &v3011 {
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
                                                    v3003
                                                },
                                                string("polyglot"),
                                            );
                                            let v3022: string = toLower(Spiral::method33());
                                            let v3027: string = toLower(v3018);
                                            let v3036: Spiral::US10 =
                                                if startsWith3(v3022, v3027.clone(), false) {
                                                    Spiral::US10::US10_1(v3027.clone())
                                                } else {
                                                    Spiral::US10::US10_0(v3027)
                                                };
                                            let v3042: Result<string, string> = match &v3036 {
                                                Spiral::US10::US10_0(v3036_0_0) => {
                                                    Ok::<string, string>(v3036_0_0.clone())
                                                }
                                                Spiral::US10::US10_1(v3036_1_0) => {
                                                    Err::<string, string>(v3036_1_0.clone())
                                                }
                                            };
                                            let v3044: bool = true;
                                            let _result_unwrap_or_else =
                                                v3042.unwrap_or_else(|x| {
                                                    //;
                                                    let v3046: string = x;
                                                    let v3048: bool = true;
                                                    v3046
                                                });
                                            let v3050: string = _result_unwrap_or_else;
                                            let v3055: string = Spiral::method207(
                                                Spiral::US5::US5_0(v2985.clone()),
                                                string("spiral"),
                                                Spiral::US39::US39_0(Spiral::US38::US38_0),
                                                v3050.clone(),
                                            );
                                            let v3061: string = Spiral::method208(
                                                v2977,
                                                string("spiral"),
                                                LrcPtr::new(Spiral::UH2::UH2_0),
                                                LrcPtr::new(Spiral::UH4::UH4_1(
                                                    string("Fable.Core"),
                                                    string("4.3.0"),
                                                    LrcPtr::new(Spiral::UH4::UH4_0),
                                                )),
                                                v3055.clone(),
                                                v3050.clone(),
                                            );
                                            let v3063: string =
                                                Spiral::method35(v3055.clone(), string("../../.."));
                                            let v3065: string = Spiral::method35(
                                                v3063.clone(),
                                                string("Cargo.toml"),
                                            );
                                            if (Spiral::method37(v3065.clone())) == false {
                                                let v3071: DateTime = DateTime::now();
                                                let v3094: string =
                                                    toString(Spiral::method211(new_guid(), v3071));
                                                let v3119: string =
                                                    append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                           (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                               v3094.clone(),
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
                                                                                               v3094,
                                                                                               string("\"")]))))),
                                                                   string("\n"))),
                                                           string("path = \"spiral.rs\""));
                                                std::fs::write(&*v3065.clone(), &*v3119).unwrap();
                                                ()
                                            }
                                            {
                                                let v3122: string = Spiral::method35(
                                                    v3055.clone(),
                                                    string("Cargo.toml"),
                                                );
                                                if (Spiral::method37(v3122.clone())) == false {
                                                    let v3128: DateTime = DateTime::now();
                                                    let v3151: string = toString(
                                                        Spiral::method211(new_guid(), v3128),
                                                    );
                                                    let v3176: string =
                                                        append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                               (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                   v3151.clone(),
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
                                                                                                   v3151,
                                                                                                   string("\"")]))))),
                                                                       string("\n"))),
                                                               string("path = \"spiral.rs\""));
                                                    std::fs::write(&*v3122.clone(), &*v3176)
                                                        .unwrap();
                                                    ()
                                                }
                                                {
                                                    let v3180: string =
                                                        Spiral::method35(v3050.clone(),
                                                                         string("lib/rust/fable/fable_modules/fable-library-rust"));
                                                    let v3182: string = Spiral::method35(
                                                        v3055.clone(),
                                                        string("fable_modules/fable-library-rust"),
                                                    );
                                                    Spiral::method216(v3180, v3182.clone());
                                                    {
                                                        let patternInput_16: (i32, string) =
                                                            Spiral::method217(
                                                                v2879.clone(),
                                                                v3055.clone(),
                                                                string("rs"),
                                                                v3061,
                                                                v3036.clone(),
                                                            );
                                                        let v3184: string =
                                                            patternInput_16.1.clone();
                                                        let v3183: i32 = patternInput_16.0.clone();
                                                        let patternInput_25: (
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                        ) = if (v3183) != 0_i32 {
                                                            let v3191: () = {
                                                                Spiral::closure89(
                                                                    v3184.clone(),
                                                                    v3183,
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            (
                                                                Spiral::US5::US5_0(string("rs")),
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_0(v3184),
                                                            )
                                                        } else {
                                                            let v3342: Vec<std::string::String> =
                                                                if if let Spiral::US36::US36_1 =
                                                                    &v2879
                                                                {
                                                                    true
                                                                } else {
                                                                    false
                                                                } {
                                                                    v2708.clone()
                                                                } else {
                                                                    let v3243 = Spiral::method227();
                                                                    let v3244: Vec<
                                                                        std::string::String,
                                                                    > = Spiral::method228(
                                                                        v2708.clone(),
                                                                    );
                                                                    let v3246: Vec<
                                                                        std::string::String,
                                                                    > = v3244
                                                                        .into_iter()
                                                                        .filter(|x| {
                                                                            v3243(x.clone().clone())
                                                                        })
                                                                        .collect::<Vec<_>>();
                                                                    if (v3246.len() as i32) > 0_i32
                                                                    {
                                                                        v2708.clone()
                                                                    } else {
                                                                        let v3270: &str =
                                                                            &*string("near-sdk");
                                                                        let v3330: Array<
                                                                            std::string::String,
                                                                        > = new_array(&[
                                                                            String::from(v3270),
                                                                        ]);
                                                                        let v3333: Vec<
                                                                            std::string::String,
                                                                        > = Spiral::method68(
                                                                            v3330.to_vec(),
                                                                        );
                                                                        let v3334: Vec<
                                                                            std::string::String,
                                                                        > = Spiral::method69(v2708);
                                                                        let v3336: bool = true;
                                                                        let mut v3334 = v3334;
                                                                        let v3338: bool = true;
                                                                        v3334.extend(v3333);
                                                                        v3334
                                                                    }
                                                                };
                                                            let v3344: bool = true;
                                                            let _vec_map : Vec<_> = v3342.into_iter().map(|x| { //;
                                                                let v3346:
                                                                        std::string::String =
                                                                    x;
                                                                let v3348:
                                                                        string =
                                                                    fable_library_rust::String_::fromString(v3346);
                                                                let v3365:
                                                                        string =
                                                                    if contains(v3348.clone(),
                                                                                string("="))
                                                                       {
                                                                        v3348.clone()
                                                                    } else {
                                                                        if endsWith3(v3348.clone(),
                                                                                     string("]"),
                                                                                     false)
                                                                           {
                                                                            concat(new_array(&[replace(v3348.clone(),
                                                                                                       string("["),
                                                                                                       string("={version=\'*\',features=[")),
                                                                                               string("}")]))
                                                                        } else {
                                                                            concat(new_array(&[v3348,
                                                                                               string("=\'*\'")]))
                                                                        }
                                                                    };
                                                                let v3367:
                                                                        bool =
                                                                    true; v3365 }).collect::<Vec<_>>();
                                                            let v3369: Vec<string> = _vec_map;
                                                            let v3371:
                                                                        Array<string> =
                                                                    fable_library_rust::NativeArray_::array_from(v3369.clone());
                                                            let _let__v3375: LrcPtr<
                                                                dyn IEnumerable_1<string>,
                                                            > = delay(Func0::new({
                                                                let v3371 = v3371.clone();
                                                                move || {
                                                                    map_1(
                                                                        Func1::new({
                                                                            let v3371 =
                                                                                v3371.clone();
                                                                            move |i_2: i32| {
                                                                                v3371[i_2].clone()
                                                                            }
                                                                        }),
                                                                        rangeNumeric(
                                                                            0_i32,
                                                                            1_i32,
                                                                            (get_Count(
                                                                                v3371.clone(),
                                                                            )) - 1_i32,
                                                                        ),
                                                                    )
                                                                }
                                                            }));
                                                            let v3388: string = join(
                                                                Spiral::method70(),
                                                                toArray_1(_let__v3375),
                                                            );
                                                            let v3393: string = Spiral::method35(
                                                                v3055,
                                                                concat(new_array(&[
                                                                    string("spiral"),
                                                                    string("."),
                                                                    string("rs"),
                                                                ])),
                                                            );
                                                            let v3405: Result<
                                                                Vec<u8>,
                                                                std::io::Error,
                                                            > = std::fs::read(&*v3393.clone());
                                                            let v3450: Vec<u8> =
                                                                Spiral::method26(v3405.unwrap());
                                                            let v3452: Result<
                                                                std::string::String,
                                                                std::string::FromUtf8Error,
                                                            > = std::string::String::from_utf8(
                                                                v3450,
                                                            );
                                                            let v3456: std::string::String =
                                                                v3452.unwrap();
                                                            let v3491:
                                                                        string =
                                                                    fable_library_rust::String_::fromString(v3456);
                                                            let v3499: string = append(
                                                                string("on_startup!"),
                                                                (Spiral::method229()),
                                                            );
                                                            let v3502: string = append(
                                                                string(" method0"),
                                                                (Spiral::method230()),
                                                            );
                                                            let v3512: bool = if contains(
                                                                v3491.clone(),
                                                                v3499.clone(),
                                                            ) {
                                                                (contains(v3491, v3502)) == false
                                                            } else {
                                                                false
                                                            };
                                                            let v3577:
                                                                        string =
                                                                    append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                                                                                                           (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                                                                                               v2985.clone(),
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
                                                                                                                                                           (if !((v2879.clone())
                                                                                                                                                                     ==
                                                                                                                                                                     Spiral::US36::US36_1)
                                                                                                                                                               {
                                                                                                                                                                string("fable_library_rust = { workspace = true }")
                                                                                                                                                            } else {
                                                                                                                                                                append((append((append(string("fable_library_rust = { workspace = true, features = ["),
                                                                                                                                                                                       (if v3512
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
                                                                                                                           (v3388))),
                                                                                                                   string("\n"))),
                                                                                                           string(""))),
                                                                                                   string("\n"))),
                                                                                           (if if let Spiral::US36::US36_1
                                                                                                      =
                                                                                                      &v2879
                                                                                                  {
                                                                                                   true
                                                                                               } else {
                                                                                                   false
                                                                                               }
                                                                                               {
                                                                                                append(string("[[bin]]\n"),
                                                                                                       (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                           v2985.clone(),
                                                                                                                           string("\"")]))))
                                                                                            } else {
                                                                                                string("[lib]\ncrate-type = [\"cdylib\"]")
                                                                                            }))),
                                                                                   string("\n"))),
                                                                           string("path = \"spiral.rs\""));
                                                            let v3642:
                                                                        string =
                                                                    append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append(string("cargo-features = [\"profile-rustflags\"]\n\n[workspace]\nresolver = \"2\"\nmembers = [\"packages/Rust/*\"]\n\n[workspace.dependencies.fable_library_rust]\n"),
                                                                                                                                                                                                                                                                                                           (concat(new_array(&[string("path = \""),
                                                                                                                                                                                                                                                                                                                               Spiral::method45(v3050.clone()),
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
                                                            Spiral::method71(v3122.clone(), v3577);
                                                            Spiral::method71(v3065, v3642);
                                                            {
                                                                let v3644: string =
                                                                    Spiral::method35(
                                                                        v3182,
                                                                        string("src/Range.rs"),
                                                                    );
                                                                if Spiral::method37(v3644.clone()) {
                                                                    let v3657: Result<
                                                                        Vec<u8>,
                                                                        std::io::Error,
                                                                    > = std::fs::read(
                                                                        &*v3644.clone(),
                                                                    );
                                                                    let v3702: Vec<u8> =
                                                                        Spiral::method26(
                                                                            v3657.unwrap(),
                                                                        );
                                                                    let v3704:
                                                                                Result<std::string::String,
                                                                                       std::string::FromUtf8Error> =
                                                                            std::string::String::from_utf8(v3702);
                                                                    let v3708: std::string::String =
                                                                        v3704.unwrap();
                                                                    Spiral::method71(v3644,
                                                                                         replace(replace(fable_library_rust::String_::fromString(v3708),
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
                                                                        v3036.clone(),
                                                                        v3122.clone(),
                                                                        1_u8,
                                                                    );
                                                                    let v3756: i32 =
                                                                        patternInput_17.0.clone();
                                                                    if (v3756) != 0_i32 {
                                                                        let v3764: () = {
                                                                            Spiral::closure93(
                                                                                patternInput_17
                                                                                    .1
                                                                                    .clone(),
                                                                                v3756,
                                                                                (),
                                                                            );
                                                                            ()
                                                                        };
                                                                        ()
                                                                    }
                                                                    {
                                                                        let v3822: Result<
                                                                            Vec<u8>,
                                                                            std::io::Error,
                                                                        > = std::fs::read(
                                                                            &*v3393.clone(),
                                                                        );
                                                                        let v3867: Vec<u8> =
                                                                            Spiral::method26(
                                                                                v3822.unwrap(),
                                                                            );
                                                                        let v3869:
                                                                                    Result<std::string::String,
                                                                                           std::string::FromUtf8Error> =
                                                                                std::string::String::from_utf8(v3867);
                                                                        let v3873:
                                                                                    std::string::String =
                                                                                v3869.unwrap();
                                                                        let v3908:
                                                                                    string =
                                                                                fable_library_rust::String_::fromString(v3873);
                                                                        let v3916:
                                                                                    string =
                                                                                append(string("pub fn main() -> Result<(), String> "),
                                                                                       (Spiral::method237()));
                                                                        let v3963:
                                                                                    string =
                                                                                append((append((if if let Spiral::US36::US36_1
                                                                                                          =
                                                                                                          &v2879
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
                                                                                                     &v2879
                                                                                                 {
                                                                                                  true
                                                                                              } else {
                                                                                                  false
                                                                                              }
                                                                                              {
                                                                                               contains(v3908.clone(),
                                                                                                        append((v3499.clone()),
                                                                                                               string("Spiral::method0()")))
                                                                                           } else {
                                                                                               false
                                                                                           }
                                                                                           {
                                                                                            concat(new_array(&[v3916.clone(),
                                                                                                               string(" Ok(Spiral::method0()) }")]))
                                                                                        } else {
                                                                                            concat(new_array(&[v3916.clone(),
                                                                                                               string(" Ok(()) }")]))
                                                                                        }));
                                                                        let v3965: bool = contains(
                                                                            v3908.clone(),
                                                                            v3916,
                                                                        );
                                                                        let v4067: string = if v3965
                                                                        {
                                                                            v3908.clone()
                                                                        } else {
                                                                            (if (if let Spiral::US36::US36_0(v2879_0_0)
                                                                                                =
                                                                                                &v2879
                                                                                            {
                                                                                             if let Spiral::US37::US37_1(v2879_1_0)
                                                                                                    =
                                                                                                    &v2879_0_0
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
                                                                                         let v4063:
                                                                                                 string =
                                                                                             string("use fable_library_rust::DateTime_::DateTime;");
                                                                                         Func1::new({
                                                                                                        let v4063
                                                                                                            =
                                                                                                            v4063.clone();
                                                                                                        move
                                                                                                            |v_8:
                                                                                                                 string|
                                                                                                            Spiral::closure96(v4063.clone(),
                                                                                                                              v_8)
                                                                                                    })
                                                                                     })((if v3512
                                                                                            {
                                                                                             Func1::new(move
                                                                                                            |v_5:
                                                                                                                 string|
                                                                                                            Spiral::closure94((),
                                                                                                                              v_5))
                                                                                         } else {
                                                                                             let v4055:
                                                                                                     string =
                                                                                                 append(string("// "),
                                                                                                        (v3499.clone()));
                                                                                             Func1::new({
                                                                                                            let v3499
                                                                                                                =
                                                                                                                v3499.clone();
                                                                                                            let v4055
                                                                                                                =
                                                                                                                v4055.clone();
                                                                                                            move
                                                                                                                |v_6:
                                                                                                                     string|
                                                                                                                Spiral::closure95(v3499.clone(),
                                                                                                                                  v4055.clone(),
                                                                                                                                  v_6)
                                                                                                        })
                                                                                         })(replace(replace(replace(replace(replace(replace(replace(replace(replace(Spiral::method65(string("\\s\\sfable_library_rust::Native_::getZero\\(\\);"),
                                                                                                                                                                                     string(" fable_library_rust::Native_::getZero::<()>();"),
                                                                                                                                                                                     replace(replace(Spiral::method65(string("\\s\\sgetZero\\(\\);"),
                                                                                                                                                                                                                      string(" getZero::<()>();"),
                                                                                                                                                                                                                      Spiral::method65(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                                                                                                                                                       string(" defaultOf::<()>();"),
                                                                                                                                                                                                                                       replace(replace(concat(new_array(&[v3908,
                                                                                                                                                                                                                                                                          string("\n\n"),
                                                                                                                                                                                                                                                                          v3963,
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
                                                                        if (v3965) == false {
                                                                            Spiral::method71(
                                                                                v3393.clone(),
                                                                                v4067.clone(),
                                                                            );
                                                                        }
                                                                        {
                                                                            let v4073:
                                                                                        string =
                                                                                    if (if let Spiral::US36::US36_1
                                                                                               =
                                                                                               &v2879
                                                                                           {
                                                                                            true
                                                                                        } else {
                                                                                            false
                                                                                        })
                                                                                           !=
                                                                                           true
                                                                                       {
                                                                                        concat(new_array(&[string("cargo +nightly-2024-07-14 build --release --target wasm32-unknown-unknown --manifest-path \""),
                                                                                                           v3122.clone(),
                                                                                                           string("\"")]))
                                                                                    } else {
                                                                                        concat(new_array(&[string("cargo run --manifest-path \""),
                                                                                                           v3122,
                                                                                                           string("\"")]))
                                                                                    };
                                                                            let v4086:
                                                                                        Array<(string,
                                                                                               string)> =
                                                                                    if (if let Spiral::US36::US36_1
                                                                                               =
                                                                                               &v2879
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
                                                                            let v4097:
                                                                                        Result<string,
                                                                                               string> =
                                                                                    match &v3036
                                                                                        {
                                                                                        Spiral::US10::US10_0(v3036_0_0)
                                                                                        =>
                                                                                        Ok::<string,
                                                                                             string>(v3036_0_0.clone()),
                                                                                        Spiral::US10::US10_1(v3036_1_0)
                                                                                        =>
                                                                                        Err::<string,
                                                                                              string>(v3036_1_0.clone()),
                                                                                    };
                                                                            let patternInput_18:
                                                                                        (i32,
                                                                                         string) =
                                                                                    Spiral::method96(v4073.clone(),
                                                                                                     None::<CancellationToken>,
                                                                                                     v4086.clone(),
                                                                                                     None::<Func1<(i32,
                                                                                                                   string,
                                                                                                                   bool),
                                                                                                                  Arc<Async<()>>>>,
                                                                                                     None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                                  ()>>,
                                                                                                     true,
                                                                                                     v4097.ok());
                                                                            let v4115: string =
                                                                                patternInput_18
                                                                                    .1
                                                                                    .clone();
                                                                            let v4114: i32 =
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
                                                                                              &v2879
                                                                                          {
                                                                                           true
                                                                                       } else {
                                                                                           false
                                                                                       }
                                                                                       {
                                                                                        let v4117:
                                                                                                i32 =
                                                                                            get_Count(v4086.clone());
                                                                                        let v4118:
                                                                                                Array<string> =
                                                                                            new_init(&string(""),
                                                                                                     v4117);
                                                                                        let v4119:
                                                                                                LrcPtr<Spiral::Mut5> =
                                                                                            LrcPtr::new(Spiral::Mut5{l0:
                                                                                                                         MutCell::new(0_i32),});
                                                                                        while Spiral::method31(v4117,
                                                                                                               v4119.clone())
                                                                                              {
                                                                                            let v4121:
                                                                                                    i32 =
                                                                                                v4119.l0.get().clone();
                                                                                            let patternInput_19:
                                                                                                    (string,
                                                                                                     string) =
                                                                                                v4086[v4121].clone();
                                                                                            let v4124:
                                                                                                    string =
                                                                                                sprintf!("$env:{}=\'\'{}\'\'",
                                                                                                         patternInput_19.0.clone(),
                                                                                                         patternInput_19.1.clone());
                                                                                            v4118.get_mut()[v4121
                                                                                                                as
                                                                                                                usize]
                                                                                                =
                                                                                                v4124;
                                                                                            {
                                                                                                let v4125:
                                                                                                        i32 =
                                                                                                    (v4121)
                                                                                                        +
                                                                                                        1_i32;
                                                                                                v4119.l0.set(v4125);
                                                                                                ()
                                                                                            }
                                                                                        }
                                                                                        {
                                                                                            let v4148:
                                                                                                    string =
                                                                                                concat(new_array(&[string("pwsh -c \'"),
                                                                                                                   join(string(";"),
                                                                                                                        toArray_1(ofArray_1(new_array(&[join(string(";"),
                                                                                                                                                             toArray_1(ofArray_1(v4118.clone()))),
                                                                                                                                                        v4073])))),
                                                                                                                   string("\'")]));
                                                                                            let patternInput_20:
                                                                                                    (Spiral::US5,
                                                                                                     Spiral::US5,
                                                                                                     Spiral::US5,
                                                                                                     Spiral::US5) =
                                                                                                if (v4114)
                                                                                                       !=
                                                                                                       0_i32
                                                                                                   {
                                                                                                    let v4155:
                                                                                                            () =
                                                                                                        {
                                                                                                            Spiral::closure97(v2744,
                                                                                                                              v3393.clone(),
                                                                                                                              v4115.clone(),
                                                                                                                              v4114,
                                                                                                                              v4148.clone(),
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
                                                                                                                                                 Spiral::closure98(v4115.clone(),
                                                                                                                                                                   ()))),
                                                                                                              |ex_2:
                                                                                                                   LrcPtr<Exception>|
                                                                                                                  result_2.set(Spiral::closure100(v3393.clone(),
                                                                                                                                                  v4115.clone(),
                                                                                                                                                  v4148,
                                                                                                                                                  ex_2.clone())));
                                                                                                    {
                                                                                                        let v4211:
                                                                                                                Spiral::US5 =
                                                                                                            result_2.get().clone();
                                                                                                        let v4222:
                                                                                                                Option<string> =
                                                                                                            match &v4211
                                                                                                                {
                                                                                                                Spiral::US5::US5_0(v4211_0_0)
                                                                                                                =>
                                                                                                                Some(match &v4211
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
                                                                                                         Spiral::US5::US5_0(v4067.clone()),
                                                                                                         Spiral::US5::US5_0(v3393.clone()),
                                                                                                         Spiral::US5::US5_0(v4222.unwrap()))
                                                                                                    }
                                                                                                };
                                                                                            (patternInput_20.0.clone(),
                                                                                             patternInput_20.1.clone(),
                                                                                             patternInput_20.2.clone(),
                                                                                             patternInput_20.3.clone())
                                                                                        }
                                                                                    } else {
                                                                                        let v4233:
                                                                                                string =
                                                                                            sprintf!("target/spiral/{}/target/wasm32-unknown-unknown/release/spiral_{}.wasm",
                                                                                                     string("spiral"),
                                                                                                     v2985.clone());
                                                                                        let v4245:
                                                                                                string =
                                                                                            sprintf!("pwsh -c \"pwsh {} {} -Linux -EnvironmentVariables AUTOMATION={}`nNEAR_RPC_TIMEOUT_SECS=100\"",
                                                                                                     string("scripts/invoke-block.ps1"),
                                                                                                     sprintf!("\'deps/spiral/workspace/target/release/spiral_wasm -w {} -t Debug {}\'",
                                                                                                              v4233.clone(),
                                                                                                              if let Spiral::US36::US36_0(v2879_0_0)
                                                                                                                     =
                                                                                                                     &v2879
                                                                                                                 {
                                                                                                                  let v4234:
                                                                                                                          Spiral::US37 =
                                                                                                                      v2879_0_0.clone();
                                                                                                                  match &v4234
                                                                                                                      {
                                                                                                                      Spiral::US37::US37_0(v4234_0_0)
                                                                                                                      =>
                                                                                                                      v4234_0_0.clone(),
                                                                                                                      Spiral::US37::US37_1(v4234_1_0)
                                                                                                                      =>
                                                                                                                      v4234_1_0.clone(),
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
                                                                                            if (v4114)
                                                                                                   ==
                                                                                                   0_i32
                                                                                               {
                                                                                                let patternInput_21:
                                                                                                        (i32,
                                                                                                         string) =
                                                                                                    Spiral::method96(v4245.clone(),
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
                                                                                                                     Some(v3050));
                                                                                                let v4258:
                                                                                                        string =
                                                                                                    patternInput_21.1.clone();
                                                                                                let v4257:
                                                                                                        i32 =
                                                                                                    patternInput_21.0.clone();
                                                                                                let patternInput_22:
                                                                                                        (Spiral::US5,
                                                                                                         Spiral::US5,
                                                                                                         Spiral::US5,
                                                                                                         Spiral::US5) =
                                                                                                    if (v4257)
                                                                                                           ==
                                                                                                           0_i32
                                                                                                       {
                                                                                                        (Spiral::US5::US5_0(string("rs")),
                                                                                                         Spiral::US5::US5_0(v4067),
                                                                                                         Spiral::US5::US5_0(v3393.clone()),
                                                                                                         Spiral::US5::US5_0(v4258.clone()))
                                                                                                    } else {
                                                                                                        let v4266:
                                                                                                                () =
                                                                                                            {
                                                                                                                Spiral::closure102(v2744,
                                                                                                                                   v3393.clone(),
                                                                                                                                   v4115.clone(),
                                                                                                                                   v4258,
                                                                                                                                   v4257,
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
                                                                                                let v4324:
                                                                                                        () =
                                                                                                    {
                                                                                                        Spiral::closure103(v2744,
                                                                                                                           v3393.clone(),
                                                                                                                           v4115,
                                                                                                                           v4114,
                                                                                                                           v4233,
                                                                                                                           v4245,
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
                                                                            if v2744 {
                                                                                let v4388:
                                                                                            string =
                                                                                        if (if let Spiral::US36::US36_1
                                                                                                   =
                                                                                                   &v2879
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
                                                                                let v4391:
                                                                                            string =
                                                                                        Spiral::method35(v3063.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4388.clone(),
                                                                                                                  v2985.clone(),
                                                                                                                  string("")));
                                                                                let v4394:
                                                                                            string =
                                                                                        Spiral::method35(v3063.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4388.clone(),
                                                                                                                  v2985.clone(),
                                                                                                                  string(".wasm")));
                                                                                let v4397:
                                                                                            string =
                                                                                        Spiral::method35(v3063.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4388.clone(),
                                                                                                                  v2985.clone(),
                                                                                                                  string(".pdb")));
                                                                                let v4400:
                                                                                            string =
                                                                                        Spiral::method35(v3063.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4388.clone(),
                                                                                                                  v2985.clone(),
                                                                                                                  string(".exe")));
                                                                                let v4403:
                                                                                            string =
                                                                                        Spiral::method35(v3063,
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4388,
                                                                                                                  v2985,
                                                                                                                  string(".d")));
                                                                                let v4404:
                                                                                            bool =
                                                                                        Spiral::method37(v4391.clone());
                                                                                let v4405:
                                                                                            bool =
                                                                                        Spiral::method37(v4394.clone());
                                                                                let v4406:
                                                                                            bool =
                                                                                        Spiral::method37(v4397.clone());
                                                                                let v4407:
                                                                                            bool =
                                                                                        Spiral::method37(v4400.clone());
                                                                                let v4408:
                                                                                            bool =
                                                                                        Spiral::method37(v4403.clone());
                                                                                let v4411: () = {
                                                                                    Spiral::closure104(v3393,
                                                                                                               v4403.clone(),
                                                                                                               v4408,
                                                                                                               v4400.clone(),
                                                                                                               v4407,
                                                                                                               v4397.clone(),
                                                                                                               v4406,
                                                                                                               v4394.clone(),
                                                                                                               v4405,
                                                                                                               v4391.clone(),
                                                                                                               v4404,
                                                                                                               ());
                                                                                    ()
                                                                                };
                                                                                let v4461: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4404 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4391,
                                                                                                                           v4404,
                                                                                                                           LrcPtr::new(Spiral::UH5::UH5_0)))
                                                                                } else {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_0)
                                                                                };
                                                                                let v4463: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4405 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4394,
                                                                                                                           v4405,
                                                                                                                           v4461.clone()))
                                                                                } else {
                                                                                    v4461
                                                                                };
                                                                                let v4465: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4406 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4397,
                                                                                                                           v4406,
                                                                                                                           v4463.clone()))
                                                                                } else {
                                                                                    v4463
                                                                                };
                                                                                let v4467: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4407 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4400,
                                                                                                                           v4407,
                                                                                                                           v4465.clone()))
                                                                                } else {
                                                                                    v4465
                                                                                };
                                                                                Spiral::method248(
                                                                                    if v4408 {
                                                                                        LrcPtr::new(Spiral::UH5::UH5_1(v4403,
                                                                                                                                         v4408,
                                                                                                                                         v4467.clone()))
                                                                                    } else {
                                                                                        v4467
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
                                                let v4477: string = Spiral::method183();
                                                let v4484: &str = &*v4477;
                                                let v4512: Option<std::string::String> =
                                                    clap::ArgMatches::get_one(&v33.clone(), v4484)
                                                        .cloned();
                                                let v4529: Spiral::US7 = defaultValue(
                                                    Spiral::US7::US7_1,
                                                    map(Spiral::method23(), v4512),
                                                );
                                                let v4536: std::string::String = match &v4529 {
                                                    Spiral::US7::US7_0(v4529_0_0) => match &v4529 {
                                                        Spiral::US7::US7_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => panic!(
                                                        "{}",
                                                        string("Option does not have a value."),
                                                    ),
                                                };
                                                let v4538: string =
                                                    fable_library_rust::String_::fromString(v4536);
                                                let v4539: string = Spiral::method24();
                                                let v4546: &str = &*v4539;
                                                let v4574: Option<Vec<std::string::String>> =
                                                    clap::ArgMatches::get_many(&v33.clone(), v4546)
                                                        .map(|x| x.cloned().into_iter().collect());
                                                let v4591: Spiral::US8 = defaultValue(
                                                    Spiral::US8::US8_1,
                                                    map(Spiral::method25(), v4574),
                                                );
                                                let v4597: Vec<std::string::String> =
                                                    new_empty::<std::string::String>().to_vec();
                                                let v4600: Vec<std::string::String> = match &v4591 {
                                                    Spiral::US8::US8_0(v4591_0_0) => match &v4591 {
                                                        Spiral::US8::US8_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => v4597.clone(),
                                                };
                                                let v4612: Result<Vec<u8>, std::io::Error> =
                                                    std::fs::read(&*v4538);
                                                let v4657: Vec<u8> =
                                                    Spiral::method26(v4612.unwrap());
                                                let v4659: Result<
                                                    std::string::String,
                                                    std::string::FromUtf8Error,
                                                > = std::string::String::from_utf8(v4657);
                                                let v4663: std::string::String = v4659.unwrap();
                                                let v4698: string =
                                                    fable_library_rust::String_::fromString(v4663);
                                                let v4709: string = Spiral::method28(sprintf!(
                                                    "{:?}",
                                                    (string("ts"), v4698.clone())
                                                ));
                                                let v4711: Spiral::US5 =
                                                    Spiral::method34(Spiral::method33());
                                                let v4717: Spiral::US5 =
                                                        match &v4711 {
                                                            Spiral::US5::US5_0(v4711_0_0)
                                                            =>
                                                            Spiral::US5::US5_0(match &v4711
                                                                                   {
                                                                                   Spiral::US5::US5_0(x)
                                                                                   =>
                                                                                   x.clone(),
                                                                                   _
                                                                                   =>
                                                                                   unreachable!(),
                                                                               }.clone()),
                                                            _ =>
                                                            Spiral::method34(string("/home/runner/work/spiral/polyglot/target/Builder/spiral")),
                                                        };
                                                let v4723: Spiral::US5 = match &v4717 {
                                                    Spiral::US5::US5_0(v4717_0_0) => {
                                                        Spiral::US5::US5_0(
                                                            match &v4717 {
                                                                Spiral::US5::US5_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => Spiral::method34(string("/workspaces")),
                                                };
                                                let v4727: string = match &v4723 {
                                                    Spiral::US5::US5_0(v4723_0_0) => match &v4723 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => panic!(
                                                        "{}",
                                                        string("Option does not have a value."),
                                                    ),
                                                };
                                                let v4742: string = Spiral::method35(
                                                    if string("deps")
                                                        == (Spiral::method54(v4727.clone()))
                                                    {
                                                        let v4735: Spiral::US5 = Spiral::method34(
                                                            Spiral::method40(v4727.clone())
                                                                .clone()
                                                                .unwrap(),
                                                        );
                                                        match &v4735 {
                                                            Spiral::US5::US5_0(v4735_0_0) => {
                                                                match &v4735 {
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
                                                        v4727
                                                    },
                                                    string("polyglot"),
                                                );
                                                let v4746: string = toLower(Spiral::method33());
                                                let v4751: string = toLower(v4742);
                                                let v4760: Spiral::US10 =
                                                    if startsWith3(v4746, v4751.clone(), false) {
                                                        Spiral::US10::US10_1(v4751.clone())
                                                    } else {
                                                        Spiral::US10::US10_0(v4751)
                                                    };
                                                let v4766: Result<string, string> = match &v4760 {
                                                    Spiral::US10::US10_0(v4760_0_0) => {
                                                        Ok::<string, string>(v4760_0_0.clone())
                                                    }
                                                    Spiral::US10::US10_1(v4760_1_0) => {
                                                        Err::<string, string>(v4760_1_0.clone())
                                                    }
                                                };
                                                let v4768: bool = true;
                                                let _result_unwrap_or_else =
                                                    v4766.unwrap_or_else(|x| {
                                                        //;
                                                        let v4770: string = x;
                                                        let v4772: bool = true;
                                                        v4770
                                                    });
                                                let v4774: string = _result_unwrap_or_else;
                                                let v4779: string = Spiral::method207(
                                                    Spiral::US5::US5_0(v4709.clone()),
                                                    string("spiral"),
                                                    Spiral::US39::US39_0(Spiral::US38::US38_1),
                                                    v4774.clone(),
                                                );
                                                let v4785: string = Spiral::method208(
                                                    v4698,
                                                    string("spiral"),
                                                    LrcPtr::new(Spiral::UH2::UH2_0),
                                                    LrcPtr::new(Spiral::UH4::UH4_1(
                                                        string("Fable.Core"),
                                                        string("4.3.0"),
                                                        LrcPtr::new(Spiral::UH4::UH4_0),
                                                    )),
                                                    v4779.clone(),
                                                    v4774.clone(),
                                                );
                                                let v4787: string = Spiral::method35(
                                                    v4774.clone(),
                                                    string("lib/typescript/fable/fable_modules"),
                                                );
                                                let v4788: string = concat(new_array(&[
                                                    string("fable-library-"),
                                                    string("ts"),
                                                ]));
                                                let v4789: string =
                                                    Spiral::method253(v4788.clone());
                                                let v4791: async_walkdir::WalkDir =
                                                    async_walkdir::WalkDir::new(&*v4787.clone());
                                                let v4794: async_walkdir::WalkDir =
                                                    async_walkdir::WalkDir::filter(
                                                        v4791,
                                                        move |x| {
                                                            Func1::new({
                                                                let v4788 = v4788.clone();
                                                                move
                                                                                                                          |v_11:
                                                                                                                               async_walkdir::DirEntry|
                                                                                                                          Spiral::closure108(v4788.clone(),
                                                                                                                                             v_11)
                                                            })(
                                                                x
                                                            )
                                                        },
                                                    );
                                                let v4795 = Spiral::method257(v4789);
                                                let v4797 = futures::stream::StreamExt::filter_map(
                                                    v4794,
                                                    |x| async { v4795(x) },
                                                );
                                                let v4799: std::pin::Pin<
                                                    Box<
                                                        dyn std::future::Future<
                                                            Output = Vec<(string, string)>,
                                                        >,
                                                    >,
                                                > = Box::pin(futures::stream::StreamExt::collect(
                                                    v4797,
                                                ));
                                                let v4801: Vec<(string, string)> = v4799.await;
                                                let v4803: rayon::vec::IntoIter<(string, string)> =
                                                    rayon::iter::IntoParallelIterator::into_par_iter(
                                                        v4801,
                                                    );
                                                let v4806: rayon::iter::Map<
                                                    rayon::vec::IntoIter<(string, string)>,
                                                    _,
                                                > = rayon::iter::ParallelIterator::map(
                                                    v4803,
                                                    |x| {
                                                        Func1::new(move
                                                                                                                     |arg10_0040_18:
                                                                                                                          (string,
                                                                                                                           string)|
                                                                                                                     Spiral::closure116((),
                                                                                                                                        arg10_0040_18))(x)
                                                    },
                                                );
                                                let v4808: Vec<(string, string)> =
                                                    rayon::iter::ParallelIterator::collect(v4806);
                                                let v4811: Option<(string, string)> = tryItem(
                                                    0_i32,
                                                    fable_library_rust::NativeArray_::array_from(
                                                        v4808.clone(),
                                                    ),
                                                );
                                                let v4829: Spiral::US48 = defaultValue(
                                                    Spiral::US48::US48_1,
                                                    map(Spiral::method262(), v4811),
                                                );
                                                let v4835: () = {
                                                    Spiral::closure118(v4829.clone(), ());
                                                    ()
                                                };
                                                Spiral::method265(
                                                    v4779.clone(),
                                                    v4787.clone(),
                                                    v4829.clone(),
                                                );
                                                {
                                                    let patternInput_26: (i32, string) =
                                                        Spiral::method217(
                                                            Spiral::US36::US36_1,
                                                            v4779.clone(),
                                                            string("ts"),
                                                            v4785,
                                                            v4760.clone(),
                                                        );
                                                    let v4884: string = patternInput_26.1.clone();
                                                    let v4883: i32 = patternInput_26.0.clone();
                                                    Spiral::method265(
                                                        v4779.clone(),
                                                        v4787,
                                                        v4829.clone(),
                                                    );
                                                    {
                                                        let patternInput_30: (
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                        ) = if (v4883) != 0_i32 {
                                                            let v4891: () = {
                                                                Spiral::closure119(
                                                                    v4884.clone(),
                                                                    v4883,
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            (
                                                                Spiral::US5::US5_0(string("ts")),
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_0(v4884),
                                                            )
                                                        } else {
                                                            let v4943: bool = true;
                                                            let _vec_map : Vec<_> = v4600.into_iter().map(|x| { //;
                                                                    let v4945:
                                                                            std::string::String =
                                                                        x;
                                                                    let v4947:
                                                                            string =
                                                                        fable_library_rust::String_::fromString(v4945);
                                                                    let v4954:
                                                                            string =
                                                                        if contains(v4947.clone(),
                                                                                    string("="))
                                                                           {
                                                                            v4947.clone()
                                                                        } else {
                                                                            concat(new_array(&[string("\""),
                                                                                               v4947,
                                                                                               string("\":\"*\"")]))
                                                                        };
                                                                    let v4956:
                                                                            bool =
                                                                        true; v4954 }).collect::<Vec<_>>();
                                                            let v4958: Vec<string> = _vec_map;
                                                            let v4960:
                                                                            Array<string> =
                                                                        fable_library_rust::NativeArray_::array_from(v4958.clone());
                                                            let v4977: string = join(
                                                                string(",\n"),
                                                                toArray_1(delay(Func0::new({
                                                                    let v4960 = v4960.clone();
                                                                    move || {
                                                                        map_1(
                                                                            Func1::new({
                                                                                let v4960 =
                                                                                    v4960.clone();
                                                                                move |i_3: i32| {
                                                                                    v4960[i_3]
                                                                                        .clone()
                                                                                }
                                                                            }),
                                                                            rangeNumeric(
                                                                                0_i32,
                                                                                1_i32,
                                                                                (get_Count(
                                                                                    v4960.clone(),
                                                                                )) - 1_i32,
                                                                            ),
                                                                        )
                                                                    }
                                                                }))),
                                                            );
                                                            let v4993:
                                                                            string =
                                                                        append((append((append((append((append((append((append(string("{"),
                                                                                                                               (concat(new_array(&[string("  \"name\": \"spiral_"),
                                                                                                                                                   v4709,
                                                                                                                                                   string("\",")]))))),
                                                                                                                       string("  \"dependencies\": {"))),
                                                                                                               (v4977))),
                                                                                                       string("  },"))),
                                                                                               string("    \"devDependencies\": {"))),
                                                                                       string("  },"))),
                                                                               string("}"));
                                                            let v4995: string = Spiral::method35(
                                                                v4779.clone(),
                                                                string("package.json"),
                                                            );
                                                            let v4998: string = Spiral::method35(
                                                                Spiral::method35(
                                                                    v4779.clone(),
                                                                    string("../.."),
                                                                ),
                                                                string("package.json"),
                                                            );
                                                            Spiral::method71(v4995, v4993);
                                                            Spiral::method71(v4998, string(""));
                                                            {
                                                                let v5001: string =
                                                                    Spiral::method35(
                                                                        v4779,
                                                                        concat(new_array(&[
                                                                            string("spiral"),
                                                                            string("."),
                                                                            string("ts"),
                                                                        ])),
                                                                    );
                                                                let v5004: () = {
                                                                    Spiral::closure120(
                                                                        v5001.clone(),
                                                                        (),
                                                                    );
                                                                    ()
                                                                };
                                                                let v5062: Result<
                                                                    Vec<u8>,
                                                                    std::io::Error,
                                                                > = std::fs::read(&*v5001.clone());
                                                                let v5107: Vec<u8> =
                                                                    Spiral::method26(
                                                                        v5062.unwrap(),
                                                                    );
                                                                let v5109: Result<
                                                                    std::string::String,
                                                                    std::string::FromUtf8Error,
                                                                > = std::string::String::from_utf8(
                                                                    v5107,
                                                                );
                                                                let v5113: std::string::String =
                                                                    v5109.unwrap();
                                                                let v5148:
                                                                                string =
                                                                            fable_library_rust::String_::fromString(v5113);
                                                                let v5156:
                                                                                bool =
                                                                            contains(v5148.clone(),
                                                                                     string("// spiral.process_typescript"));
                                                                let v5165: string = if v5156 {
                                                                    v5148.clone()
                                                                } else {
                                                                    Spiral::method65(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                 string(" defaultOf::<()>();"),
                                                                                                 replace(v5148,
                                                                                                         sprintf!("\"./fable_modules/fable-library-ts.{}/",
                                                                                                                  v4829.clone()),
                                                                                                         sprintf!("\"{}/lib/typescript/fable/fable_modules/fable-library-ts.{}/",
                                                                                                                  v4774,
                                                                                                                  v4829)))
                                                                };
                                                                if (v5156) == false {
                                                                    Spiral::method71(v5001.clone(),
                                                                                             concat(new_array(&[v5165.clone(),
                                                                                                                string("\n\n"),
                                                                                                                string("// spiral.process_typescript"),
                                                                                                                string("\n")])));
                                                                }
                                                                {
                                                                    let v5168: string =
                                                                        concat(new_array(&[
                                                                            string("bun run \""),
                                                                            v5001.clone(),
                                                                            string("\""),
                                                                        ]));
                                                                    let v5170: string =
                                                                        Spiral::method3(string(
                                                                            "PATH",
                                                                        ));
                                                                    let v5210: Spiral::US5 =
                                                                        if (v5170.clone())
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
                                                                                                                          v5170])))
                                                                        };
                                                                    let v5226:
                                                                                    Array<(string,
                                                                                           string)> =
                                                                                toArray(Spiral::method270(Spiral::method269(match &v5210
                                                                                                                                {
                                                                                                                                Spiral::US5::US5_0(v5210_0_0)
                                                                                                                                =>
                                                                                                                                LrcPtr::new(Spiral::UH4::UH4_1(string("PATH"),
                                                                                                                                                               match &v5210
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
                                                                    let v5239: Result<
                                                                        string,
                                                                        string,
                                                                    > = match &v4760 {
                                                                        Spiral::US10::US10_0(
                                                                            v4760_0_0,
                                                                        ) => Ok::<string, string>(
                                                                            v4760_0_0.clone(),
                                                                        ),
                                                                        Spiral::US10::US10_1(
                                                                            v4760_1_0,
                                                                        ) => Err::<string, string>(
                                                                            v4760_1_0.clone(),
                                                                        ),
                                                                    };
                                                                    let patternInput_27:
                                                                                    (i32,
                                                                                     string) =
                                                                                Spiral::method96(v5168.clone(),
                                                                                                 None::<CancellationToken>,
                                                                                                 v5226.clone(),
                                                                                                 None::<Func1<(i32,
                                                                                                               string,
                                                                                                               bool),
                                                                                                              Arc<Async<()>>>>,
                                                                                                 None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                              ()>>,
                                                                                                 true,
                                                                                                 v5239.ok());
                                                                    let v5257: string =
                                                                        patternInput_27.1.clone();
                                                                    let v5256: i32 =
                                                                        patternInput_27.0.clone();
                                                                    let v5258: i32 =
                                                                        get_Count(v5226.clone());
                                                                    let v5259: Array<string> =
                                                                        new_init(
                                                                            &string(""),
                                                                            v5258,
                                                                        );
                                                                    let v5260: LrcPtr<
                                                                        Spiral::Mut5,
                                                                    > = LrcPtr::new(Spiral::Mut5 {
                                                                        l0: MutCell::new(0_i32),
                                                                    });
                                                                    while Spiral::method31(
                                                                        v5258,
                                                                        v5260.clone(),
                                                                    ) {
                                                                        let v5262: i32 =
                                                                            v5260.l0.get().clone();
                                                                        let patternInput_28: (
                                                                            string,
                                                                            string,
                                                                        ) = v5226[v5262].clone();
                                                                        let v5265: string = sprintf!(
                                                                            "$env:{}=\'\'{}\'\'",
                                                                            patternInput_28
                                                                                .0
                                                                                .clone(),
                                                                            patternInput_28
                                                                                .1
                                                                                .clone()
                                                                        );
                                                                        v5259.get_mut()
                                                                            [v5262 as usize] =
                                                                            v5265;
                                                                        {
                                                                            let v5266: i32 =
                                                                                (v5262) + 1_i32;
                                                                            v5260.l0.set(v5266);
                                                                            ()
                                                                        }
                                                                    }
                                                                    {
                                                                        let v5278: string = sprintf!(
                                                                            "pwsh -c \'{}; {}\'",
                                                                            join(
                                                                                string(";"),
                                                                                toArray_1(
                                                                                    ofArray_1(
                                                                                        v5259
                                                                                            .clone(
                                                                                            )
                                                                                    )
                                                                                )
                                                                            ),
                                                                            v5168
                                                                        );
                                                                        let patternInput_29: (
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                        ) = if (v5256) == 0_i32 {
                                                                            let result_3: LrcPtr<
                                                                                MutCell<
                                                                                    Spiral::US5,
                                                                                >,
                                                                            > = refCell(
                                                                                Spiral::US5::US5_1,
                                                                            );
                                                                            try_catch(||
                                                                                                      result_3.set(Spiral::closure71((),
                                                                                                                                     Spiral::closure121(v5257.clone(),
                                                                                                                                                        ()))),
                                                                                                  |ex_3:
                                                                                                       LrcPtr<Exception>|
                                                                                                      result_3.set(Spiral::closure122(v5001.clone(),
                                                                                                                                      v5257.clone(),
                                                                                                                                      v5278.clone(),
                                                                                                                                      ex_3.clone())));
                                                                            {
                                                                                let v5285:
                                                                                                    Spiral::US5 =
                                                                                                result_3.get().clone();
                                                                                let v5296:
                                                                                                    Option<string> =
                                                                                                match &v5285
                                                                                                    {
                                                                                                    Spiral::US5::US5_0(v5285_0_0)
                                                                                                    =>
                                                                                                    Some(match &v5285
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
                                                                                             Spiral::US5::US5_0(v5165),
                                                                                             Spiral::US5::US5_0(v5001.clone()),
                                                                                             Spiral::US5::US5_0(v5296.unwrap()))
                                                                            }
                                                                        } else {
                                                                            let v5305: () = {
                                                                                Spiral::closure124(
                                                                                    v5001,
                                                                                    v5257,
                                                                                    v5256,
                                                                                    v5278,
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
                                                    let v5367: string = Spiral::method183();
                                                    let v5374: &str = &*v5367;
                                                    let v5402: Option<std::string::String> =
                                                        clap::ArgMatches::get_one(
                                                            &v33.clone(),
                                                            v5374,
                                                        )
                                                        .cloned();
                                                    let v5419: Spiral::US7 = defaultValue(
                                                        Spiral::US7::US7_1,
                                                        map(Spiral::method23(), v5402),
                                                    );
                                                    let v5426: std::string::String = match &v5419 {
                                                        Spiral::US7::US7_0(v5419_0_0) => {
                                                            match &v5419 {
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
                                                    let v5428: string =
                                                        fable_library_rust::String_::fromString(
                                                            v5426,
                                                        );
                                                    let v5429: string = Spiral::method24();
                                                    let v5436: &str = &*v5429;
                                                    let v5464: Option<Vec<std::string::String>> =
                                                        clap::ArgMatches::get_many(
                                                            &v33.clone(),
                                                            v5436,
                                                        )
                                                        .map(|x| x.cloned().into_iter().collect());
                                                    let v5481: Spiral::US8 = defaultValue(
                                                        Spiral::US8::US8_1,
                                                        map(Spiral::method25(), v5464),
                                                    );
                                                    let v5487: Vec<std::string::String> =
                                                        new_empty::<std::string::String>().to_vec();
                                                    let v5490: Vec<std::string::String> =
                                                        match &v5481 {
                                                            Spiral::US8::US8_0(v5481_0_0) => {
                                                                match &v5481 {
                                                                    Spiral::US8::US8_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone()
                                                            }
                                                            _ => v5487.clone(),
                                                        };
                                                    let v5491: bool =
                                                        if let Spiral::US0::US0_0 = &v0_1 {
                                                            true
                                                        } else {
                                                            false
                                                        };
                                                    let v5503: Result<Vec<u8>, std::io::Error> =
                                                        std::fs::read(&*v5428);
                                                    let v5548: Vec<u8> =
                                                        Spiral::method26(v5503.unwrap());
                                                    let v5550: Result<
                                                        std::string::String,
                                                        std::string::FromUtf8Error,
                                                    > = std::string::String::from_utf8(v5548);
                                                    let v5554: std::string::String = v5550.unwrap();
                                                    let v5589: string =
                                                        fable_library_rust::String_::fromString(
                                                            v5554,
                                                        );
                                                    let v5600: string = Spiral::method28(sprintf!(
                                                        "{:?}",
                                                        (string("py"), v5589.clone())
                                                    ));
                                                    let v5602: Spiral::US5 =
                                                        Spiral::method34(Spiral::method33());
                                                    let v5608:
                                                                    Spiral::US5 =
                                                                match &v5602 {
                                                                    Spiral::US5::US5_0(v5602_0_0)
                                                                    =>
                                                                    Spiral::US5::US5_0(match &v5602
                                                                                           {
                                                                                           Spiral::US5::US5_0(x)
                                                                                           =>
                                                                                           x.clone(),
                                                                                           _
                                                                                           =>
                                                                                           unreachable!(),
                                                                                       }.clone()),
                                                                    _ =>
                                                                    Spiral::method34(string("/home/runner/work/spiral/polyglot/target/Builder/spiral")),
                                                                };
                                                    let v5614: Spiral::US5 = match &v5608 {
                                                        Spiral::US5::US5_0(v5608_0_0) => {
                                                            Spiral::US5::US5_0(
                                                                match &v5608 {
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
                                                    let v5618: string = match &v5614 {
                                                        Spiral::US5::US5_0(v5614_0_0) => {
                                                            match &v5614 {
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
                                                    let v5633: string = Spiral::method35(
                                                        if string("deps")
                                                            == (Spiral::method54(v5618.clone()))
                                                        {
                                                            let v5626: Spiral::US5 =
                                                                Spiral::method34(
                                                                    Spiral::method40(v5618.clone())
                                                                        .clone()
                                                                        .unwrap(),
                                                                );
                                                            match &v5626
                                                                                         {
                                                                                         Spiral::US5::US5_0(v5626_0_0)
                                                                                         =>
                                                                                         match &v5626
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
                                                            v5618
                                                        },
                                                        string("polyglot"),
                                                    );
                                                    let v5637: string = toLower(Spiral::method33());
                                                    let v5642: string = toLower(v5633);
                                                    let v5651: Spiral::US10 =
                                                        if startsWith3(v5637, v5642.clone(), false)
                                                        {
                                                            Spiral::US10::US10_1(v5642.clone())
                                                        } else {
                                                            Spiral::US10::US10_0(v5642)
                                                        };
                                                    let v5657: Result<string, string> = match &v5651
                                                    {
                                                        Spiral::US10::US10_0(v5651_0_0) => {
                                                            Ok::<string, string>(v5651_0_0.clone())
                                                        }
                                                        Spiral::US10::US10_1(v5651_1_0) => {
                                                            Err::<string, string>(v5651_1_0.clone())
                                                        }
                                                    };
                                                    let v5659: bool = true;
                                                    let _result_unwrap_or_else = v5657
                                                        .unwrap_or_else(|x| {
                                                            //;
                                                            let v5661: string = x;
                                                            let v5663: bool = true;
                                                            v5661
                                                        });
                                                    let v5665: string = _result_unwrap_or_else;
                                                    let v5670: string = Spiral::method207(
                                                        Spiral::US5::US5_0(v5600.clone()),
                                                        string("spiral"),
                                                        Spiral::US39::US39_0(Spiral::US38::US38_2),
                                                        v5665.clone(),
                                                    );
                                                    let v5676: string = Spiral::method208(
                                                        v5589,
                                                        string("spiral"),
                                                        LrcPtr::new(Spiral::UH2::UH2_0),
                                                        LrcPtr::new(Spiral::UH4::UH4_1(
                                                            string("Fable.Core"),
                                                            string("4.3.0"),
                                                            LrcPtr::new(Spiral::UH4::UH4_0),
                                                        )),
                                                        v5670.clone(),
                                                        v5665.clone(),
                                                    );
                                                    Spiral::method216(Spiral::method35(Spiral::method35(v5665,
                                                                                                                string("lib/python/fable/fable_modules")),
                                                                                               string("fable_library")),
                                                                              Spiral::method35(v5670.clone(),
                                                                                               string("fable_modules/fable_library")));
                                                    {
                                                        let patternInput_31: (i32, string) =
                                                            Spiral::method217(
                                                                Spiral::US36::US36_1,
                                                                v5670.clone(),
                                                                string("py"),
                                                                v5676,
                                                                v5651.clone(),
                                                            );
                                                        let v5685: string =
                                                            patternInput_31.1.clone();
                                                        let v5684: i32 = patternInput_31.0.clone();
                                                        let patternInput_35: (
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                        ) = if (v5684) != 0_i32 {
                                                            let v5692: () = {
                                                                Spiral::closure125(
                                                                    v5685.clone(),
                                                                    v5684,
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            (
                                                                Spiral::US5::US5_0(string("py")),
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_0(v5685),
                                                            )
                                                        } else {
                                                            let v5744: bool = true;
                                                            let _vec_map : Vec<_> = v5490.into_iter().map(|x| { //;
                                                                        let v5746:
                                                                                std::string::String =
                                                                            x;
                                                                        let v5748:
                                                                                string =
                                                                            fable_library_rust::String_::fromString(v5746);
                                                                        let v5755:
                                                                                string =
                                                                            if contains(v5748.clone(),
                                                                                        string("="))
                                                                               {
                                                                                v5748.clone()
                                                                            } else {
                                                                                concat(new_array(&[string("\""),
                                                                                                   v5748,
                                                                                                   string("\":\"*\"")]))
                                                                            };
                                                                        let v5757:
                                                                                bool =
                                                                            true; v5755 }).collect::<Vec<_>>();
                                                            let v5759: Vec<string> = _vec_map;
                                                            let v5761:
                                                                                Array<string> =
                                                                            fable_library_rust::NativeArray_::array_from(v5759.clone());
                                                            let v5778: string = join(
                                                                string(",\n"),
                                                                toArray_1(delay(Func0::new({
                                                                    let v5761 = v5761.clone();
                                                                    move || {
                                                                        map_1(
                                                                            Func1::new({
                                                                                let v5761 =
                                                                                    v5761.clone();
                                                                                move |i_4: i32| {
                                                                                    v5761[i_4]
                                                                                        .clone()
                                                                                }
                                                                            }),
                                                                            rangeNumeric(
                                                                                0_i32,
                                                                                1_i32,
                                                                                (get_Count(
                                                                                    v5761.clone(),
                                                                                )) - 1_i32,
                                                                            ),
                                                                        )
                                                                    }
                                                                }))),
                                                            );
                                                            let v5794:
                                                                                string =
                                                                            append((append((append((append((append((append((append(string("{"),
                                                                                                                                   (concat(new_array(&[string("  \"name\": \"spiral_"),
                                                                                                                                                       v5600,
                                                                                                                                                       string("\",")]))))),
                                                                                                                           string("  \"dependencies\": {"))),
                                                                                                                   (v5778))),
                                                                                                           string("  },"))),
                                                                                                   string("    \"devDependencies\": {"))),
                                                                                           string("  },"))),
                                                                                   string("}"));
                                                            let v5796: string = Spiral::method35(
                                                                v5670.clone(),
                                                                string("package.json"),
                                                            );
                                                            let v5799: string = Spiral::method35(
                                                                Spiral::method35(
                                                                    v5670.clone(),
                                                                    string("../.."),
                                                                ),
                                                                string("package.json"),
                                                            );
                                                            Spiral::method71(v5796, v5794);
                                                            Spiral::method71(v5799, string(""));
                                                            {
                                                                let v5802: string =
                                                                    Spiral::method35(
                                                                        v5670,
                                                                        concat(new_array(&[
                                                                            string("spiral"),
                                                                            string("."),
                                                                            string("py"),
                                                                        ])),
                                                                    );
                                                                let v5805: () = {
                                                                    Spiral::closure126(
                                                                        v5802.clone(),
                                                                        (),
                                                                    );
                                                                    ()
                                                                };
                                                                let v5863: Result<
                                                                    Vec<u8>,
                                                                    std::io::Error,
                                                                > = std::fs::read(&*v5802.clone());
                                                                let v5908: Vec<u8> =
                                                                    Spiral::method26(
                                                                        v5863.unwrap(),
                                                                    );
                                                                let v5910: Result<
                                                                    std::string::String,
                                                                    std::string::FromUtf8Error,
                                                                > = std::string::String::from_utf8(
                                                                    v5908,
                                                                );
                                                                let v5914: std::string::String =
                                                                    v5910.unwrap();
                                                                let v5949:
                                                                                    string =
                                                                                fable_library_rust::String_::fromString(v5914);
                                                                let v5957: bool = contains(
                                                                    v5949.clone(),
                                                                    string(
                                                                        "# spiral.process_python",
                                                                    ),
                                                                );
                                                                let v5969: string = if v5957 {
                                                                    v5949.clone()
                                                                } else {
                                                                    Spiral::method65(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                     string(" defaultOf::<()>();"),
                                                                                                     replace(v5949,
                                                                                                             append(string("),)"),
                                                                                                                    (";".into())),
                                                                                                             string("));")))
                                                                };
                                                                if (v5957) == false {
                                                                    Spiral::method71(v5802.clone(),
                                                                                                 concat(new_array(&[v5969.clone(),
                                                                                                                    string("\n\n"),
                                                                                                                    string("# spiral.process_python"),
                                                                                                                    string("\n")])));
                                                                }
                                                                {
                                                                    let v5972: string =
                                                                        concat(new_array(&[
                                                                            string("python \""),
                                                                            v5802.clone(),
                                                                            string("\""),
                                                                        ]));
                                                                    let v5975: Array<(
                                                                        string,
                                                                        string,
                                                                    )> = new_array(&[(
                                                                        string("TRACE_LEVEL"),
                                                                        string("Verbose"),
                                                                    )]);
                                                                    let v5986: Result<
                                                                        string,
                                                                        string,
                                                                    > = match &v5651 {
                                                                        Spiral::US10::US10_0(
                                                                            v5651_0_0,
                                                                        ) => Ok::<string, string>(
                                                                            v5651_0_0.clone(),
                                                                        ),
                                                                        Spiral::US10::US10_1(
                                                                            v5651_1_0,
                                                                        ) => Err::<string, string>(
                                                                            v5651_1_0.clone(),
                                                                        ),
                                                                    };
                                                                    let patternInput_32:
                                                                                        (i32,
                                                                                         string) =
                                                                                    Spiral::method96(v5972.clone(),
                                                                                                     None::<CancellationToken>,
                                                                                                     v5975.clone(),
                                                                                                     None::<Func1<(i32,
                                                                                                                   string,
                                                                                                                   bool),
                                                                                                                  Arc<Async<()>>>>,
                                                                                                     None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                                  ()>>,
                                                                                                     true,
                                                                                                     v5986.ok());
                                                                    let v6004: string =
                                                                        patternInput_32.1.clone();
                                                                    let v6003: i32 =
                                                                        patternInput_32.0.clone();
                                                                    let v6005: i32 =
                                                                        get_Count(v5975.clone());
                                                                    let v6006: Array<string> =
                                                                        new_init(
                                                                            &string(""),
                                                                            v6005,
                                                                        );
                                                                    let v6007: LrcPtr<
                                                                        Spiral::Mut5,
                                                                    > = LrcPtr::new(Spiral::Mut5 {
                                                                        l0: MutCell::new(0_i32),
                                                                    });
                                                                    while Spiral::method31(
                                                                        v6005,
                                                                        v6007.clone(),
                                                                    ) {
                                                                        let v6009: i32 =
                                                                            v6007.l0.get().clone();
                                                                        let patternInput_33: (
                                                                            string,
                                                                            string,
                                                                        ) = v5975[v6009].clone();
                                                                        let v6012: string = sprintf!(
                                                                            "$env:{}=\'\'{}\'\'",
                                                                            patternInput_33
                                                                                .0
                                                                                .clone(),
                                                                            patternInput_33
                                                                                .1
                                                                                .clone()
                                                                        );
                                                                        v6006.get_mut()
                                                                            [v6009 as usize] =
                                                                            v6012;
                                                                        {
                                                                            let v6013: i32 =
                                                                                (v6009) + 1_i32;
                                                                            v6007.l0.set(v6013);
                                                                            ()
                                                                        }
                                                                    }
                                                                    {
                                                                        let v6025: string = sprintf!(
                                                                            "pwsh -c \'{}; {}\'",
                                                                            join(
                                                                                string(";"),
                                                                                toArray_1(
                                                                                    ofArray_1(
                                                                                        v6006
                                                                                            .clone(
                                                                                            )
                                                                                    )
                                                                                )
                                                                            ),
                                                                            v5972
                                                                        );
                                                                        let patternInput_34: (
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                        ) = if (v6003) == 0_i32 {
                                                                            let result_4: LrcPtr<
                                                                                MutCell<
                                                                                    Spiral::US5,
                                                                                >,
                                                                            > = refCell(
                                                                                Spiral::US5::US5_1,
                                                                            );
                                                                            try_catch(||
                                                                                                          result_4.set(Spiral::closure71((),
                                                                                                                                         Spiral::closure127(v6004.clone(),
                                                                                                                                                            ()))),
                                                                                                      |ex_4:
                                                                                                           LrcPtr<Exception>|
                                                                                                          result_4.set(Spiral::closure128(v5802.clone(),
                                                                                                                                          v6004.clone(),
                                                                                                                                          v6025.clone(),
                                                                                                                                          ex_4.clone())));
                                                                            {
                                                                                let v6032:
                                                                                                        Spiral::US5 =
                                                                                                    result_4.get().clone();
                                                                                let v6043:
                                                                                                        Option<string> =
                                                                                                    match &v6032
                                                                                                        {
                                                                                                        Spiral::US5::US5_0(v6032_0_0)
                                                                                                        =>
                                                                                                        Some(match &v6032
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
                                                                                                 Spiral::US5::US5_0(v5969),
                                                                                                 Spiral::US5::US5_0(v5802.clone()),
                                                                                                 Spiral::US5::US5_0(v6043.unwrap()))
                                                                            }
                                                                        } else {
                                                                            let v6052: () = {
                                                                                Spiral::closure130(
                                                                                    v5802,
                                                                                    v6004,
                                                                                    v6003,
                                                                                    v6025,
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
                                                    let v6113: () = {
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
                                        let v6175: Spiral::US5 = patternInput_38.3.clone();
                                        let v6174: Spiral::US5 = patternInput_38.2.clone();
                                        let v6173: Spiral::US5 = patternInput_38.1.clone();
                                        let v6172: Spiral::US5 = patternInput_38.0.clone();
                                        new_array(&[
                                            (
                                                string("extension"),
                                                match &v6172 {
                                                    Spiral::US5::US5_0(v6172_0_0) => match &v6172 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => string(""),
                                                },
                                            ),
                                            (
                                                string("code"),
                                                match &v6173 {
                                                    Spiral::US5::US5_0(v6173_0_0) => match &v6173 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => string(""),
                                                },
                                            ),
                                            (
                                                string("code_path"),
                                                match &v6174 {
                                                    Spiral::US5::US5_0(v6174_0_0) => match &v6174 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => string(""),
                                                },
                                            ),
                                            (
                                                string("output"),
                                                match &v6175 {
                                                    Spiral::US5::US5_0(v6175_0_0) => match &v6175 {
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
                    let v6209: Vec<(string, string)> = v6207.to_vec();
                    let v6212: bool = true;
                    let _func1_from_v6210 = Func1::from(move |value| {
                        //;
                        let patternInput_39: (string, string) = value;
                        let v6222: &str = &*patternInput_39.0.clone();
                        let v6255: std::string::String = String::from(v6222);
                        let v6288: &str = &*patternInput_39.1.clone();
                        let v6321: std::string::String = String::from(v6288);
                        let v6354: bool = true;
                        LrcPtr::new((v6255, v6321)) /*;
                                                    let v6356: bool = */
                    }); //;
                    let v6358: Func1<
                        (string, string),
                        LrcPtr<(std::string::String, std::string::String)>,
                    > = _func1_from_v6210;
                    let v6361: Vec<LrcPtr<(std::string::String, std::string::String)>> = v6209
                        .into_iter()
                        .map(|x| {
                            Func1::new({
                                let v6358 = v6358.clone();
                                move |arg10_0040_29: (string, string)| {
                                    Spiral::closure76(v6358.clone(), arg10_0040_29)
                                }
                            })(x.clone())
                        })
                        .collect::<Vec<_>>();
                    let v6362: string =
                string("std::collections::BTreeMap::from_iter(v6361.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                    let v6363: std::collections::BTreeMap<
                        std::string::String,
                        std::string::String,
                    > = std::collections::BTreeMap::from_iter(
                        v6361
                            .iter()
                            .map(|x| x.as_ref())
                            .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                    );
                    let v6365: Result<std::string::String, serde_json::Error> =
                        serde_json::to_string(&v6363);
                    let v6366 = Spiral::method280();
                    let v6370: Result<std::string::String, string> = v6365.map_err(|x| v6366(x));
                    let v6383: bool = true;
                    let _result_map_ = v6370.map(|x| {
                        //;
                        let v6385: std::string::String = x;
                        let v6387: string = fable_library_rust::String_::fromString(v6385);
                        let v6389: bool = true;
                        v6387
                    });
                    let v6391: Result<string, string> = _result_map_;
                    let v6394: string = string("}");
                    let v6399: bool = true;
                    let _fix_closure_v6396 = v6391;
                    let v6406: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v6396 "), (v6394))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v6407: bool = true;
                    _fix_closure_v6396
                },
            ); // rust.fix_closure';
            let v6409 = __future_init;
            v6409
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
pub use module_6ff740fe::*;
#[path = "../../lib/spiral/async_.rs"]
mod module_2335f2f5;
pub use module_2335f2f5::*;
#[path = "../../lib/spiral/common.rs"]
mod module_652e6d81;
pub use module_652e6d81::*;
#[path = "../../lib/spiral/crypto.rs"]
mod module_dd5f95ef;
pub use module_dd5f95ef::*;
#[path = "../../lib/spiral/date_time.rs"]
mod module_ca5e6cb2;
pub use module_ca5e6cb2::*;
#[path = "../../lib/spiral/file_system.rs"]
mod module_5ab1faf0;
pub use module_5ab1faf0::*;
#[path = "../../lib/spiral/lib.rs"]
mod module_b386774b;
pub use module_b386774b::*;
#[path = "../../lib/spiral/networking.rs"]
mod module_ce497f72;
pub use module_ce497f72::*;
#[path = "../../lib/spiral/platform.rs"]
mod module_9a61edd3;
pub use module_9a61edd3::*;
#[path = "../../lib/spiral/runtime.rs"]
mod module_502d7e30;
pub use module_502d7e30::*;
#[path = "../../lib/spiral/sm.rs"]
mod module_34f67952;
pub use module_34f67952::*;
#[path = "../../lib/spiral/threading.rs"]
mod module_11c0c5c2;
pub use module_11c0c5c2::*;
#[path = "../../lib/spiral/trace.rs"]
mod module_28ecba0d;
pub use module_28ecba0d::*;
#[path = "../../deps/polyglot/lib/fsharp/Common.rs"]
mod module_ad43931;
pub use module_ad43931::*;
pub mod Polyglot {
    pub use crate::module_ad43931::Polyglot::*;
}
pub fn main() {
    let args = std::env::args().skip(1).map(fromString).collect();
    Spiral::main(array_from(args));
}
