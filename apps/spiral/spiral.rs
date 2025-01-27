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
        use fable_library_rust::Native_::getZero;
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
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US10 {
            US10_0,
            US10_1,
        }
        impl core::fmt::Display for US10 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US9 {
            US9_0(Spiral::US10),
            US9_1,
        }
        impl core::fmt::Display for US9 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US8 {
            US8_0(Spiral::US9),
            US8_1,
        }
        impl core::fmt::Display for US8 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US11 {
            US11_0(Vec<std::string::String>),
            US11_1,
        }
        impl core::fmt::Display for US11 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US12 {
            US12_0,
            US12_1,
        }
        impl core::fmt::Display for US12 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US13 {
            US13_0(string),
            US13_1(string),
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
        #[derive(Clone, Debug)]
        pub enum US16 {
            US16_0,
            US16_1(std::string::String),
        }
        impl core::fmt::Display for US16 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US17 {
            US17_0(string, Spiral::US5),
            US17_1(string),
        }
        impl core::fmt::Display for US17 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US18 {
            US18_0(char, string, LrcPtr<StringBuilder>, i32, i32),
            US18_1(string),
        }
        impl core::fmt::Display for US18 {
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
                Func1<(string, LrcPtr<StringBuilder>, i32, i32), Spiral::US18>,
                LrcPtr<Spiral::UH1>,
            ),
        }
        impl core::fmt::Display for UH1 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US19 {
            US19_0(string, string, LrcPtr<StringBuilder>, i32, i32),
            US19_1(string),
        }
        impl core::fmt::Display for US19 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US20 {
            US20_0(char),
            US20_1,
        }
        impl core::fmt::Display for US20 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US21 {
            US21_0(string, LrcPtr<StringBuilder>, i32, i32),
            US21_1(string),
        }
        impl core::fmt::Display for US21 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US22 {
            US22_0(string, Spiral::US5, string, LrcPtr<StringBuilder>, i32, i32),
            US22_1(string),
        }
        impl core::fmt::Display for US22 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US23 {
            US23_0(Spiral::US20, string, LrcPtr<StringBuilder>, i32, i32),
            US23_1(string),
        }
        impl core::fmt::Display for US23 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US24 {
            US24_0(Spiral::US5, string, LrcPtr<StringBuilder>, i32, i32),
            US24_1(string),
        }
        impl core::fmt::Display for US24 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US25 {
            US25_0(Array<string>),
            US25_1(string),
        }
        impl core::fmt::Display for US25 {
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
        pub enum US26 {
            US26_0(LrcPtr<Spiral::UH2>, string, LrcPtr<StringBuilder>, i32, i32),
            US26_1(string),
        }
        impl core::fmt::Display for US26 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum UH3 {
            UH3_0,
            UH3_1(
                Func1<(string, LrcPtr<StringBuilder>, i32, i32), Spiral::US19>,
                LrcPtr<Spiral::UH3>,
            ),
        }
        impl core::fmt::Display for UH3 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US27 {
            US27_0(std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>),
            US27_1(std::string::String),
        }
        impl core::fmt::Display for US27 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US28 {
            US28_0(
                std::sync::Arc<
                    std::sync::Mutex<
                        std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                    >,
                >,
            ),
            US28_1,
        }
        impl core::fmt::Display for US28 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US29 {
            US29_0(std::string::String),
            US29_1(std::string::String),
        }
        impl core::fmt::Display for US29 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US30 {
            US30_0(Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>),
            US30_1,
        }
        impl core::fmt::Display for US30 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US31 {
            US31_0(std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>),
            US31_1,
        }
        impl core::fmt::Display for US31 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US32 {
            US32_0(std::process::Output),
            US32_1(std::string::String),
        }
        impl core::fmt::Display for US32 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US33 {
            US33_0(i32),
            US33_1,
        }
        impl core::fmt::Display for US33 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US34 {
            US34_0(Func1<(i32, string, bool), Arc<Async<()>>>),
            US34_1,
        }
        impl core::fmt::Display for US34 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US35 {
            US35_0(CancellationToken),
            US35_1,
        }
        impl core::fmt::Display for US35 {
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
        pub enum UH4 {
            UH4_0,
            UH4_1(string, bool, LrcPtr<Spiral::UH4>),
        }
        impl core::fmt::Display for UH4 {
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
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum UH5 {
            UH5_0,
            UH5_1(string, string, LrcPtr<Spiral::UH5>),
        }
        impl core::fmt::Display for UH5 {
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
            let v30: string = string("r#\"cuda\"#");
            let v31: &'static str = r#"cuda"#;
            let v33: clap::Command = clap::Command::new(v31);
            let v35: string = string("r#\"py-path\"#");
            let v36: &'static str = r#"py-path"#;
            let v38: clap::Arg = clap::Arg::new(v36);
            let v40: clap::Arg = v38.short('p');
            let v41: string = string("r#\"py-path\"#");
            let v42: &'static str = r#"py-path"#;
            let v44: clap::Arg = v40.long(v42);
            let v46: clap::Arg = v44.required(true);
            let v48: clap::Command = clap::Command::arg(v33, v46);
            let v50: string = string("r#\"env\"#");
            let v51: &'static str = r#"env"#;
            let v53: clap::Arg = clap::Arg::new(v51);
            let v55: clap::Arg = v53.short('e');
            let v56: string = string("r#\"env\"#");
            let v57: &'static str = r#"env"#;
            let v59: clap::Arg = v55.long(v57);
            let v70: Array<string> =
                toArray(ofArray(new_array(&[string("Pip"), string("Poetry")])));
            let v74: Vec<string> = v70.to_vec();
            let v76: bool = true;
            let _vec_map: Vec<_> = v74
                .into_iter()
                .map(|x| {
                    //;
                    let v78: string = x;
                    let v81: &str = &*v78;
                    let v105: std::string::String = String::from(v81);
                    let v128: Box<std::string::String> = Box::new(v105);
                    let v130: &'static mut std::string::String = Box::leak(v128);
                    let v132: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v130);
                    let v134: bool = true;
                    v132
                })
                .collect::<Vec<_>>();
            let v136: Vec<clap::builder::PossibleValue> = _vec_map;
            let v138: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v136),
            );
            let v140: clap::Arg = v59.value_parser(v138);
            let v142: clap::Command = clap::Command::arg(v48, v140);
            let v144: string = string("r#\"NAME\"#");
            let v147: string = string("r#\"VERSION\"#");
            let v149: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v150: usize = 1_i32 as usize;
            let v153: usize = 0_i32 as usize;
            let v167: clap::builder::ValueRange = if (v153) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v150..)
            } else {
                let v165: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v150..v153)
            };
            let v169: string = string("r#\"deps\"#");
            let v170: &'static str = r#"deps"#;
            let v172: clap::Arg = clap::Arg::new(v170);
            let v174: clap::Arg = v172.short('d');
            let v175: string = string("r#\"deps\"#");
            let v176: &'static str = r#"deps"#;
            let v178: clap::Arg = v174.long(v176);
            let v180: Vec<&'static str> = v149.to_vec();
            let v182: clap::Arg = v178.value_names(v180);
            let v184: clap::Arg = v182.num_args(v167);
            let v186: clap::ArgAction = clap::ArgAction::Append;
            let v188: clap::Arg = v184.action(v186);
            let v190: clap::Command = clap::Command::arg(v142, v188);
            let v192: clap::Command = clap::Command::subcommand(v28, v190);
            let v194: string = string("r#\"fable\"#");
            let v195: &'static str = r#"fable"#;
            let v197: clap::Command = clap::Command::new(v195);
            let v199: string = string("r#\"fs-path\"#");
            let v200: &'static str = r#"fs-path"#;
            let v202: clap::Arg = clap::Arg::new(v200);
            let v204: clap::Arg = v202.short('f');
            let v205: string = string("r#\"fs-path\"#");
            let v206: &'static str = r#"fs-path"#;
            let v208: clap::Arg = v204.long(v206);
            let v210: clap::Arg = v208.required(true);
            let v212: clap::Command = clap::Command::arg(v197, v210);
            let v213: string = string("r#\"command\"#");
            let v214: &'static str = r#"command"#;
            let v216: clap::Arg = clap::Arg::new(v214);
            let v218: clap::Arg = v216.short('c');
            let v219: string = string("r#\"command\"#");
            let v220: &'static str = r#"command"#;
            let v222: clap::Arg = v218.long(v220);
            let v224: clap::Command = clap::Command::arg(v212, v222);
            let v226: clap::Command = clap::Command::subcommand(v192, v224);
            let v228: string = string("r#\"rust\"#");
            let v229: &'static str = r#"rust"#;
            let v231: clap::Command = clap::Command::new(v229);
            let v232: string = string("r#\"fs-path\"#");
            let v233: &'static str = r#"fs-path"#;
            let v235: clap::Arg = clap::Arg::new(v233);
            let v237: clap::Arg = v235.short('f');
            let v238: string = string("r#\"fs-path\"#");
            let v239: &'static str = r#"fs-path"#;
            let v241: clap::Arg = v237.long(v239);
            let v243: clap::Arg = v241.required(true);
            let v245: clap::Command = clap::Command::arg(v231, v243);
            let v246: string = string("r#\"NAME\"#");
            let v248: string = string("r#\"VERSION\"#");
            let v250: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v251: usize = 1_i32 as usize;
            let v254: usize = 0_i32 as usize;
            let v268: clap::builder::ValueRange = if (v254) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v251..)
            } else {
                let v266: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v251..v254)
            };
            let v269: string = string("r#\"deps\"#");
            let v270: &'static str = r#"deps"#;
            let v272: clap::Arg = clap::Arg::new(v270);
            let v274: clap::Arg = v272.short('d');
            let v275: string = string("r#\"deps\"#");
            let v276: &'static str = r#"deps"#;
            let v278: clap::Arg = v274.long(v276);
            let v280: Vec<&'static str> = v250.to_vec();
            let v282: clap::Arg = v278.value_names(v280);
            let v284: clap::Arg = v282.num_args(v268);
            let v286: clap::ArgAction = clap::ArgAction::Append;
            let v288: clap::Arg = v284.action(v286);
            let v290: clap::Command = clap::Command::arg(v245, v288);
            let v291: usize = 0_i32 as usize;
            let v294: usize = 1_i32 as usize;
            let v308: clap::builder::ValueRange = if (v294) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v291..)
            } else {
                let v306: string = string("clap::builder::ValueRange::new($0..=$1)");
                clap::builder::ValueRange::new(v291..=v294)
            };
            let v310: string = string("r#\"wasm\"#");
            let v311: &'static str = r#"wasm"#;
            let v313: clap::Arg = clap::Arg::new(v311);
            let v315: clap::Arg = v313.short('w');
            let v316: string = string("r#\"wasm\"#");
            let v317: &'static str = r#"wasm"#;
            let v319: clap::Arg = v315.long(v317);
            let v321: clap::Arg = v319.num_args(v308);
            let v323: clap::Arg = v321.require_equals(true);
            let v325: string = string("r#\"\"#");
            let v326: &str = r#""#;
            let v328: clap::Arg = v323.default_missing_value(v326);
            let v330: clap::Command = clap::Command::arg(v290, v328);
            let v331: usize = 0_i32 as usize;
            let v334: usize = 1_i32 as usize;
            let v348: clap::builder::ValueRange = if (v334) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v331..)
            } else {
                let v346: string = string("clap::builder::ValueRange::new($0..=$1)");
                clap::builder::ValueRange::new(v331..=v334)
            };
            let v350: string = string("r#\"contract\"#");
            let v351: &'static str = r#"contract"#;
            let v353: clap::Arg = clap::Arg::new(v351);
            let v355: clap::Arg = v353.short('c');
            let v356: string = string("r#\"contract\"#");
            let v357: &'static str = r#"contract"#;
            let v359: clap::Arg = v355.long(v357);
            let v361: clap::Arg = v359.num_args(v348);
            let v363: clap::Arg = v361.require_equals(true);
            let v364: string = string("r#\"\"#");
            let v365: &str = r#""#;
            let v367: clap::Arg = v363.default_missing_value(v365);
            let v369: clap::Command = clap::Command::arg(v330, v367);
            let v371: string = string("r#\"cleanup\"#");
            let v372: &'static str = r#"cleanup"#;
            let v374: clap::Arg = clap::Arg::new(v372);
            let v376: clap::Arg = v374.short('l');
            let v377: string = string("r#\"cleanup\"#");
            let v378: &'static str = r#"cleanup"#;
            let v380: clap::Arg = v376.long(v378);
            let v382: string = string("r#\"true\"#");
            let v383: &str = r#"true"#;
            let v385: clap::Arg = v380.default_value(v383);
            let v387: clap::ArgAction = clap::ArgAction::SetFalse;
            let v389: clap::Arg = v385.action(v387);
            let v391: clap::Command = clap::Command::arg(v369, v389);
            let v393: clap::Command = clap::Command::subcommand(v226, v391);
            let v395: string = string("r#\"typescript\"#");
            let v396: &'static str = r#"typescript"#;
            let v398: clap::Command = clap::Command::new(v396);
            let v399: string = string("r#\"fs-path\"#");
            let v400: &'static str = r#"fs-path"#;
            let v402: clap::Arg = clap::Arg::new(v400);
            let v404: clap::Arg = v402.short('f');
            let v405: string = string("r#\"fs-path\"#");
            let v406: &'static str = r#"fs-path"#;
            let v408: clap::Arg = v404.long(v406);
            let v410: clap::Arg = v408.required(true);
            let v412: clap::Command = clap::Command::arg(v398, v410);
            let v413: string = string("r#\"NAME\"#");
            let v415: string = string("r#\"VERSION\"#");
            let v417: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v418: usize = 1_i32 as usize;
            let v421: usize = 0_i32 as usize;
            let v434: clap::builder::ValueRange = if (v421) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v418..)
            } else {
                let v432: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v418..v421)
            };
            let v435: string = string("r#\"deps\"#");
            let v436: &'static str = r#"deps"#;
            let v438: clap::Arg = clap::Arg::new(v436);
            let v440: clap::Arg = v438.short('d');
            let v441: string = string("r#\"deps\"#");
            let v442: &'static str = r#"deps"#;
            let v444: clap::Arg = v440.long(v442);
            let v446: Vec<&'static str> = v417.to_vec();
            let v448: clap::Arg = v444.value_names(v446);
            let v450: clap::Arg = v448.num_args(v434);
            let v452: clap::ArgAction = clap::ArgAction::Append;
            let v454: clap::Arg = v450.action(v452);
            let v456: clap::Command = clap::Command::arg(v412, v454);
            let v458: clap::Command = clap::Command::subcommand(v393, v456);
            let v460: string = string("r#\"python\"#");
            let v461: &'static str = r#"python"#;
            let v463: clap::Command = clap::Command::new(v461);
            let v464: string = string("r#\"fs-path\"#");
            let v465: &'static str = r#"fs-path"#;
            let v467: clap::Arg = clap::Arg::new(v465);
            let v469: clap::Arg = v467.short('f');
            let v470: string = string("r#\"fs-path\"#");
            let v471: &'static str = r#"fs-path"#;
            let v473: clap::Arg = v469.long(v471);
            let v475: clap::Arg = v473.required(true);
            let v477: clap::Command = clap::Command::arg(v463, v475);
            let v478: string = string("r#\"NAME\"#");
            let v480: string = string("r#\"VERSION\"#");
            let v482: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v483: usize = 1_i32 as usize;
            let v486: usize = 0_i32 as usize;
            let v499: clap::builder::ValueRange = if (v486) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v483..)
            } else {
                let v497: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v483..v486)
            };
            let v500: string = string("r#\"deps\"#");
            let v501: &'static str = r#"deps"#;
            let v503: clap::Arg = clap::Arg::new(v501);
            let v505: clap::Arg = v503.short('d');
            let v506: string = string("r#\"deps\"#");
            let v507: &'static str = r#"deps"#;
            let v509: clap::Arg = v505.long(v507);
            let v511: Vec<&'static str> = v482.to_vec();
            let v513: clap::Arg = v509.value_names(v511);
            let v515: clap::Arg = v513.num_args(v499);
            let v517: clap::ArgAction = clap::ArgAction::Append;
            let v519: clap::Arg = v515.action(v517);
            let v521: clap::Command = clap::Command::arg(v477, v519);
            let v523: clap::Command = clap::Command::subcommand(v458, v521);
            let v525: string = string("r#\"dib\"#");
            let v526: &'static str = r#"dib"#;
            let v528: clap::Command = clap::Command::new(v526);
            let v530: string = string("r#\"path\"#");
            let v531: &'static str = r#"path"#;
            let v533: clap::Arg = clap::Arg::new(v531);
            let v535: clap::Arg = v533.short('p');
            let v536: string = string("r#\"path\"#");
            let v537: &'static str = r#"path"#;
            let v539: clap::Arg = v535.long(v537);
            let v541: clap::Arg = v539.required(true);
            let v543: clap::Command = clap::Command::arg(v528, v541);
            let v545: string = string("clap::value_parser!(u8).into()");
            let v546: clap::builder::ValueParser = clap::value_parser!(u8).into();
            let v548: string = string("r#\"retries\"#");
            let v549: &'static str = r#"retries"#;
            let v551: clap::Arg = clap::Arg::new(v549);
            let v553: clap::Arg = v551.short('r');
            let v554: string = string("r#\"retries\"#");
            let v555: &'static str = r#"retries"#;
            let v557: clap::Arg = v553.long(v555);
            let v559: clap::Arg = v557.value_parser(v546);
            let v561: clap::Command = clap::Command::arg(v543, v559);
            let v563: string = string("r#\"working-directory\"#");
            let v564: &'static str = r#"working-directory"#;
            let v566: clap::Arg = clap::Arg::new(v564);
            let v568: clap::Arg = v566.short('w');
            let v569: string = string("r#\"working-directory\"#");
            let v570: &'static str = r#"working-directory"#;
            let v572: clap::Arg = v568.long(v570);
            let v574: clap::Command = clap::Command::arg(v561, v572);
            clap::Command::subcommand(v523, v574)
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
            let v2: string = Spiral::method4(v0_1);
            let v4: Result<std::string::String, std::env::VarError> = std::env::var(&*v2);
            let v6: bool = true;
            let _result_map_ = v4.map(|x| {
                //;
                let v8: std::string::String = x;
                let v10: string = fable_library_rust::String_::fromString(v8);
                let v12: bool = true;
                v10
            });
            let v14: Result<string, std::env::VarError> = _result_map_;
            let v15: string = Spiral::method5();
            v14.unwrap_or(v15)
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
            let _run_target_args__v1: (Spiral::US1, Spiral::US2) =
                (patternInput.0.clone(), patternInput.1.clone());
            let v132: Spiral::US2 = _run_target_args__v1.1.clone();
            let v131: Spiral::US1 = _run_target_args__v1.0.clone();
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
                    l0: MutCell::new(match &v131 {
                        Spiral::US1::US1_0(v131_0_0) => match &v131 {
                            Spiral::US1::US1_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        _ => v0_1.clone(),
                    }),
                }),
                match &v132 {
                    Spiral::US2::US2_0(v132_0_0) => Some(match &v132 {
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
            let v35: Spiral::US0 = (patternInput.4.clone()).l0.get().clone();
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
                    v35,
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
            let v20: Spiral::US2 = defaultValue(Spiral::US2::US2_1, map(Spiral::method9(), v5));
            let v117: DateTime = match &v20 {
                Spiral::US2::US2_0(v20_0_0) => {
                    let v77: TimeSpan = TimeSpan::new_ticks(
                        ({
                            let _arg: DateTime = DateTime::now();
                            _arg.ticks()
                        }) - (match &v20 {
                            Spiral::US2::US2_0(x) => x.clone(),
                            _ => unreachable!(),
                        }),
                    );
                    DateTime::new_ymdhms_milli(
                        1_i32,
                        1_i32,
                        1_i32,
                        v77.hours(),
                        v77.minutes(),
                        v77.seconds(),
                        v77.milliseconds(),
                    )
                }
                _ => DateTime::now(),
            };
            let v118: string = Spiral::method10();
            let provider: string = if (v118.clone()) == string("") {
                string("M-d-y hh:mm:ss tt")
            } else {
                v118
            };
            v117.toString(provider)
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
            let v8: () = {
                Spiral::closure7(v2.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method15() -> string {
            string("\u{001b}[0m")
        }
        pub fn method12() -> string {
            let v6: string = Spiral::method13(getCharAt(toLower(string("Debug")), 0_i32));
            let v9: &str = inline_colorization::color_bright_blue;
            let v12: &str = &*v6;
            let v35: &str = inline_colorization::color_reset;
            let v37: std::string::String = format!("{}{}{}", v9, v12, v35);
            fable_library_rust::String_::fromString(v37)
        }
        pub fn method17(v0_1: Array<string>) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v9: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v18: () = {
                Spiral::closure7(v2.clone(), string("args"), ());
                ()
            };
            let v27: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v38: () = {
                Spiral::closure7(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v47: () = {
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
            let v37: () = {
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
                let v24: Option<i64> = patternInput.5.clone();
                let v23: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v22: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v21: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v20: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v19: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method16(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
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
            string("py-path")
        }
        pub fn closure13(unitVar: (), v0_1: std::string::String) -> Spiral::US7 {
            Spiral::US7::US7_0(v0_1)
        }
        pub fn method23() -> Func1<std::string::String, Spiral::US7> {
            Func1::new(move |v: std::string::String| Spiral::closure13((), v))
        }
        pub fn method24() -> string {
            string("env")
        }
        pub fn method25() -> string {
            string("deps")
        }
        pub fn closure14(unitVar: (), v0_1: Vec<std::string::String>) -> Spiral::US11 {
            Spiral::US11::US11_0(v0_1)
        }
        pub fn method26() -> Func1<Vec<std::string::String>, Spiral::US11> {
            Func1::new(move |v: Vec<std::string::String>| Spiral::closure14((), v))
        }
        pub fn method27(v0_1: Vec<u8>) -> Vec<u8> {
            v0_1
        }
        pub fn method28() -> string {
            let v2: Result<std::path::PathBuf, std::io::Error> = std::env::current_dir();
            let v5: std::path::PathBuf = v2.unwrap();
            let v19: std::path::Display = v5.display();
            let v43: std::string::String = format!("{}", v19);
            fable_library_rust::String_::fromString(v43)
        }
        pub fn method30(v0_1: string, v1_1: string) -> string {
            let v5: &str = &*v0_1;
            let v29: std::string::String = String::from(v5);
            let v53: std::path::PathBuf = std::path::PathBuf::from(v29);
            let v77: &str = &*v1_1;
            let v101: std::string::String = String::from(v77);
            let v124: std::path::PathBuf = v53.join(v101);
            let v127: std::path::Display = v124.display();
            let v151: std::string::String = format!("{}", v127);
            fable_library_rust::String_::fromString(v151)
        }
        pub fn method32(v0_1: string) -> bool {
            let v4: &str = &*v0_1;
            let v28: std::string::String = String::from(v4);
            let v69: std::path::PathBuf = std::path::PathBuf::from(v28);
            if v69.clone().exists() {
                v69.is_file()
            } else {
                false
            }
        }
        pub fn closure15(unitVar: (), v0_1: string) -> bool {
            Spiral::method32(v0_1)
        }
        pub fn method33(v0_1: string) -> bool {
            let v4: &str = &*v0_1;
            let v28: std::string::String = String::from(v4);
            let v69: std::path::PathBuf = std::path::PathBuf::from(v28);
            if v69.clone().exists() {
                v69.is_dir()
            } else {
                false
            }
        }
        pub fn closure16(unitVar: (), v0_1: string) -> bool {
            Spiral::method33(v0_1)
        }
        pub fn method35(v0_1: string) -> Option<string> {
            let v4: &str = &*v0_1;
            let v28: std::string::String = String::from(v4);
            let v52: std::path::PathBuf = std::path::PathBuf::from(v28);
            let v75: Option<std::path::PathBuf> = v52.parent().map(std::path::PathBuf::from);
            let v77: bool = true;
            let _optionm_map_ = v75.map(|x| {
                //;
                let v79: std::path::PathBuf = x;
                let v82: std::path::Display = v79.display();
                let v106: std::string::String = format!("{}", v82);
                let v129: string = fable_library_rust::String_::fromString(v106);
                let v131: bool = true;
                v129
            });
            _optionm_map_
        }
        pub fn method36(
            v0_1: string,
            v1_1: string,
            v2: bool,
            v3: Func1<string, bool>,
            v4: string,
        ) -> Spiral::US13 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<bool> = MutCell::new(v2);
            let v3 = MutCell::new(v3.clone());
            let v4: MutCell<string> = MutCell::new(v4.clone());
            '_method36: loop {
                break '_method36 (if v3(Spiral::method30(v4.get().clone(), v0_1.get().clone())) {
                    Spiral::US13::US13_0(v4.get().clone())
                } else {
                    let v8: Option<string> = Spiral::method35(v4.get().clone());
                    let v22: Spiral::US5 =
                        defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v8));
                    match &v22 {
                        Spiral::US5::US5_0(v22_0_0) => {
                            let v0_1_temp: string = v0_1.get().clone();
                            let v1_1_temp: string = v1_1.get().clone();
                            let v2_temp: bool = v2.get().clone();
                            let v3_temp = v3.get().clone();
                            let v4_temp: string = match &v22 {
                                Spiral::US5::US5_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method36;
                        }
                        _ => Spiral::US13::US13_1(append(
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
        pub fn method34(
            v0_1: string,
            v1_1: string,
            v2: bool,
            v3: Func1<string, bool>,
        ) -> Spiral::US13 {
            if v3(Spiral::method30(v1_1.clone(), v0_1.clone())) {
                Spiral::US13::US13_0(v1_1.clone())
            } else {
                let v7: Option<string> = Spiral::method35(v1_1.clone());
                let v21: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v7));
                match &v21 {
                    Spiral::US5::US5_0(v21_0_0) => Spiral::method36(
                        v0_1.clone(),
                        v1_1.clone(),
                        v2,
                        v3.clone(),
                        match &v21 {
                            Spiral::US5::US5_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    _ => Spiral::US13::US13_1(append(
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
        pub fn method31(v0_1: Spiral::US12, v1_1: string, v2: string) -> Spiral::US13 {
            let v3: bool = if let Spiral::US12::US12_0 = &v0_1 {
                true
            } else {
                false
            };
            Spiral::method34(
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
        pub fn method37() -> string {
            let v6: string = Spiral::method13(getCharAt(toLower(string("Warning")), 0_i32));
            let v9: &str = inline_colorization::color_yellow;
            let v12: &str = &*v6;
            let v35: &str = inline_colorization::color_reset;
            let v37: std::string::String = format!("{}{}{}", v9, v12, v35);
            fable_library_rust::String_::fromString(v37)
        }
        pub fn method39(v0_1: string, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("dir"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v45: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("error"), ());
                ()
            };
            let v62: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method38(
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
            let v10: string = Spiral::method39(v8, v9);
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method38(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method37(),
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn method44(v0_1: std::io::Error) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v5: std::string::String = format!("{:#?}", v0_1);
            let v38: () = {
                Spiral::closure7(v2.clone(), fable_library_rust::String_::fromString(v5), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn closure18(unitVar: (), v0_1: std::io::Error) -> string {
            Spiral::method44(v0_1)
        }
        pub fn method43() -> Func1<std::io::Error, string> {
            Func1::new(move |v: std::io::Error| Spiral::closure18((), v))
        }
        pub fn closure19(unitVar: (), v0_1: std::path::PathBuf) -> Spiral::US14 {
            Spiral::US14::US14_0(v0_1)
        }
        pub fn method45() -> Func1<std::path::PathBuf, Spiral::US14> {
            Func1::new(move |v: std::path::PathBuf| Spiral::closure19((), v))
        }
        pub fn closure20(unitVar: (), v0_1: string) -> Spiral::US14 {
            Spiral::US14::US14_1(v0_1)
        }
        pub fn method46() -> Func1<string, Spiral::US14> {
            Func1::new(move |v: string| Spiral::closure20((), v))
        }
        pub fn method49(v0_1: string) -> string {
            let v4: &str = &*v0_1;
            let v28: std::string::String = String::from(v4);
            let v52: std::path::PathBuf = std::path::PathBuf::from(v28);
            let v75: Option<&std::ffi::OsStr> = v52.file_name();
            let v77: bool = true;
            let _optionm_map_ = v75.map(|x| {
                //;
                let v79: &std::ffi::OsStr = x;
                let v81: std::ffi::OsString = v79.to_os_string();
                let v83: Option<&str> = v81.to_str();
                let v85: &str = v83.unwrap();
                let v88: std::string::String = String::from(v85);
                let v111: string = fable_library_rust::String_::fromString(v88);
                let v113: bool = true;
                v111
            });
            let v115: Option<string> = _optionm_map_;
            let v129: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v115));
            match &v129 {
                Spiral::US5::US5_0(v129_0_0) => match &v129 {
                    Spiral::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                _ => string(""),
            }
        }
        pub fn method50(v0_1: string) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v8: () = {
                Spiral::closure7(v2.clone(), v0_1, ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method48(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: string,
            v4: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v5: string = Spiral::method49(v4.clone());
            let v6: Option<string> = Spiral::method35(v4.clone());
            let v20: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6));
            let v24: string = Spiral::method50(v3);
            if (v2) >= 11_u8 {
                let v28: string = append(
                    string("file_system.read_link / "),
                    sprintf!(
                        "path: {} / n: {} / path\': {} / name: {}",
                        v0_1.clone(),
                        v2,
                        v4.clone(),
                        v5.clone()
                    ),
                );
                let v31: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v28);
                Err(v31)
            } else {
                if let Spiral::US5::US5_0(v20_0_0) = &v20 {
                    if (v4.clone()) != string("") {
                        let v74: Result<std::path::PathBuf, std::io::Error> =
                            v1_1((v2) + 1_u8, v20_0_0.clone());
                        let v75 = Spiral::method43();
                        let v87: Result<std::path::PathBuf, string> = v74.map_err(|x| v75(x));
                        let v90 = Spiral::method45();
                        let v91 = Spiral::method46();
                        let v92: Spiral::US14 = match &v87 {
                            Err(v87_1_0) => v91(v87_1_0.clone()),
                            Ok(v87_0_0) => v90(v87_0_0.clone()),
                        };
                        match &v92 {
                            Spiral::US14::US14_0(v92_0_0) => {
                                let v121: string = Spiral::method30(
                                    toString(v92_0_0.clone().display()),
                                    v5.clone(),
                                );
                                let v124: &str = &*v121;
                                let v148: std::string::String = String::from(v124);
                                let v172: std::path::PathBuf = std::path::PathBuf::from(v148);
                                Ok(v172)
                            }
                            Spiral::US14::US14_1(v92_1_0) => {
                                let v211: string = append(
                                    string("file_system.read_link / "),
                                    sprintf!(
                                        "error\': {} / error: {} / name: {}",
                                        v92_1_0.clone(),
                                        v24.clone(),
                                        v5.clone()
                                    ),
                                );
                                let v214: std::io::Error =
                                    std::io::Error::new(std::io::ErrorKind::Other, &*v211);
                                Err(v214)
                            }
                        }
                    } else {
                        let v254: string =
                            append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                                   sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                            v0_1.clone(), v24.clone(),
                                            v4.clone(), v5.clone()));
                        let v257: std::io::Error =
                            std::io::Error::new(std::io::ErrorKind::Other, &*v254);
                        Err(v257)
                    }
                } else {
                    let v296: string =
                        append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                               sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                        v0_1, v24.clone(), v4, v5.clone()));
                    let v299: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v296);
                    Err(v299)
                }
            }
        }
        pub fn method47(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v5: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v2.clone());
            let v6 = Spiral::method43();
            let v18: Result<std::path::PathBuf, string> = v5.map_err(|x| v6(x));
            let v21 = Spiral::method45();
            let v22 = Spiral::method46();
            let v23: Spiral::US14 = match &v18 {
                Err(v18_1_0) => v22(v18_1_0.clone()),
                Ok(v18_0_0) => v21(v18_0_0.clone()),
            };
            match &v23 {
                Spiral::US14::US14_0(v23_0_0) => Ok(v23_0_0.clone()),
                Spiral::US14::US14_1(v23_1_0) => Spiral::method48(
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
                    v23_1_0.clone(),
                    v2.clone(),
                ),
            }
        }
        pub fn closure22(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            Spiral::method47(v0_1, v1_1, v2)
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
        pub fn method51(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v4: string = Spiral::method49(v0_1.clone());
            let v5: Option<string> = Spiral::method35(v0_1.clone());
            let v19: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v5));
            let v23: string = Spiral::method50(v3);
            if (v2) >= 11_u8 {
                let v27: string = append(
                    string("file_system.read_link / "),
                    sprintf!(
                        "path: {} / n: {} / path\': {} / name: {}",
                        v0_1.clone(),
                        v2,
                        v0_1.clone(),
                        v4.clone()
                    ),
                );
                let v30: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v27);
                Err(v30)
            } else {
                if let Spiral::US5::US5_0(v19_0_0) = &v19 {
                    if (v0_1.clone()) != string("") {
                        let v73: Result<std::path::PathBuf, std::io::Error> =
                            v1_1((v2) + 1_u8, v19_0_0.clone());
                        let v74 = Spiral::method43();
                        let v86: Result<std::path::PathBuf, string> = v73.map_err(|x| v74(x));
                        let v89 = Spiral::method45();
                        let v90 = Spiral::method46();
                        let v91: Spiral::US14 = match &v86 {
                            Err(v86_1_0) => v90(v86_1_0.clone()),
                            Ok(v86_0_0) => v89(v86_0_0.clone()),
                        };
                        match &v91 {
                            Spiral::US14::US14_0(v91_0_0) => {
                                let v120: string = Spiral::method30(
                                    toString(v91_0_0.clone().display()),
                                    v4.clone(),
                                );
                                let v123: &str = &*v120;
                                let v147: std::string::String = String::from(v123);
                                let v171: std::path::PathBuf = std::path::PathBuf::from(v147);
                                Ok(v171)
                            }
                            Spiral::US14::US14_1(v91_1_0) => {
                                let v210: string = append(
                                    string("file_system.read_link / "),
                                    sprintf!(
                                        "error\': {} / error: {} / name: {}",
                                        v91_1_0.clone(),
                                        v23.clone(),
                                        v4.clone()
                                    ),
                                );
                                let v213: std::io::Error =
                                    std::io::Error::new(std::io::ErrorKind::Other, &*v210);
                                Err(v213)
                            }
                        }
                    } else {
                        let v253: string =
                            append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                                   sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                            v0_1.clone(), v23.clone(),
                                            v0_1.clone(), v4.clone()));
                        let v256: std::io::Error =
                            std::io::Error::new(std::io::ErrorKind::Other, &*v253);
                        Err(v256)
                    }
                } else {
                    let v295: string =
                        append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                               sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                        v0_1.clone(), v23.clone(), v0_1,
                                        v4.clone()));
                    let v298: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v295);
                    Err(v298)
                }
            }
        }
        pub fn method42(v0_1: string, v1_1: u8) -> Result<std::path::PathBuf, std::io::Error> {
            let v4: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v0_1.clone());
            let v5 = Spiral::method43();
            let v17: Result<std::path::PathBuf, string> = v4.map_err(|x| v5(x));
            let v20 = Spiral::method45();
            let v21 = Spiral::method46();
            let v22: Spiral::US14 = match &v17 {
                Err(v17_1_0) => v21(v17_1_0.clone()),
                Ok(v17_0_0) => v20(v17_0_0.clone()),
            };
            match &v22 {
                Spiral::US14::US14_0(v22_0_0) => Ok(v22_0_0.clone()),
                Spiral::US14::US14_1(v22_1_0) => Spiral::method51(
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
                    v22_1_0.clone(),
                ),
            }
        }
        pub fn method53(v0_1: bool) -> i32 {
            unbox::<i32>(&getZero())
        }
        pub fn method54() -> i32 {
            unbox::<i32>(&getZero())
        }
        pub fn method55(v0_1: i32, v1_1: i32) -> bool {
            unbox::<bool>(&getZero())
        }
        pub fn method57(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: std::io::Error,
            v4: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v5: string = Spiral::method49(v4.clone());
            let v6: Option<string> = Spiral::method35(v4.clone());
            let v20: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6));
            let v24: string = Spiral::method44(v3);
            if (v2) >= 11_u8 {
                let v28: string = append(
                    string("file_system.read_link / "),
                    sprintf!(
                        "path: {} / n: {} / path\': {} / name: {}",
                        v0_1.clone(),
                        v2,
                        v4.clone(),
                        v5.clone()
                    ),
                );
                let v31: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v28);
                Err(v31)
            } else {
                if let Spiral::US5::US5_0(v20_0_0) = &v20 {
                    if (v4.clone()) != string("") {
                        let v74: Result<std::path::PathBuf, std::io::Error> =
                            v1_1((v2) + 1_u8, v20_0_0.clone());
                        let v75 = Spiral::method43();
                        let v87: Result<std::path::PathBuf, string> = v74.map_err(|x| v75(x));
                        let v90 = Spiral::method45();
                        let v91 = Spiral::method46();
                        let v92: Spiral::US14 = match &v87 {
                            Err(v87_1_0) => v91(v87_1_0.clone()),
                            Ok(v87_0_0) => v90(v87_0_0.clone()),
                        };
                        match &v92 {
                            Spiral::US14::US14_0(v92_0_0) => {
                                let v121: string = Spiral::method30(
                                    toString(v92_0_0.clone().display()),
                                    v5.clone(),
                                );
                                let v124: &str = &*v121;
                                let v148: std::string::String = String::from(v124);
                                let v172: std::path::PathBuf = std::path::PathBuf::from(v148);
                                Ok(v172)
                            }
                            Spiral::US14::US14_1(v92_1_0) => {
                                let v211: string = append(
                                    string("file_system.read_link / "),
                                    sprintf!(
                                        "error\': {} / error: {} / name: {}",
                                        v92_1_0.clone(),
                                        v24.clone(),
                                        v5.clone()
                                    ),
                                );
                                let v214: std::io::Error =
                                    std::io::Error::new(std::io::ErrorKind::Other, &*v211);
                                Err(v214)
                            }
                        }
                    } else {
                        let v254: string =
                            append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                                   sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                            v0_1.clone(), v24.clone(),
                                            v4.clone(), v5.clone()));
                        let v257: std::io::Error =
                            std::io::Error::new(std::io::ErrorKind::Other, &*v254);
                        Err(v257)
                    }
                } else {
                    let v296: string =
                        append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                               sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                        v0_1, v24.clone(), v4, v5.clone()));
                    let v299: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v296);
                    Err(v299)
                }
            }
        }
        pub fn method56(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v30: i32 = Spiral::method53(unbox::<bool>(&getZero()));
            let v32: bool = Spiral::method55(Spiral::method54(), v30);
            if v32 {
                let v34: bool = unbox::<bool>(&getZero());
                let v86: std::path::PathBuf = getZero();
                Ok(v86)
            } else {
                let v107: string =
                    append(string("file_system.read_link / Fsharp / The file or directory is not a reparse point. / "),
                           sprintf!("path: {} / result: {} / path\': {} / n: {}",
                                    v0_1.clone(), v32, v2.clone(), v1_1));
                Spiral::method57(
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
                    std::io::Error::new(std::io::ErrorKind::Other, &*v107),
                    v2,
                )
            }
        }
        pub fn closure24(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            Spiral::method56(v0_1, v1_1, v2)
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
        pub fn method58(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: std::io::Error,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v4: string = Spiral::method49(v0_1.clone());
            let v5: Option<string> = Spiral::method35(v0_1.clone());
            let v19: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v5));
            let v23: string = Spiral::method44(v3);
            if (v2) >= 11_u8 {
                let v27: string = append(
                    string("file_system.read_link / "),
                    sprintf!(
                        "path: {} / n: {} / path\': {} / name: {}",
                        v0_1.clone(),
                        v2,
                        v0_1.clone(),
                        v4.clone()
                    ),
                );
                let v30: std::io::Error = std::io::Error::new(std::io::ErrorKind::Other, &*v27);
                Err(v30)
            } else {
                if let Spiral::US5::US5_0(v19_0_0) = &v19 {
                    if (v0_1.clone()) != string("") {
                        let v73: Result<std::path::PathBuf, std::io::Error> =
                            v1_1((v2) + 1_u8, v19_0_0.clone());
                        let v74 = Spiral::method43();
                        let v86: Result<std::path::PathBuf, string> = v73.map_err(|x| v74(x));
                        let v89 = Spiral::method45();
                        let v90 = Spiral::method46();
                        let v91: Spiral::US14 = match &v86 {
                            Err(v86_1_0) => v90(v86_1_0.clone()),
                            Ok(v86_0_0) => v89(v86_0_0.clone()),
                        };
                        match &v91 {
                            Spiral::US14::US14_0(v91_0_0) => {
                                let v120: string = Spiral::method30(
                                    toString(v91_0_0.clone().display()),
                                    v4.clone(),
                                );
                                let v123: &str = &*v120;
                                let v147: std::string::String = String::from(v123);
                                let v171: std::path::PathBuf = std::path::PathBuf::from(v147);
                                Ok(v171)
                            }
                            Spiral::US14::US14_1(v91_1_0) => {
                                let v210: string = append(
                                    string("file_system.read_link / "),
                                    sprintf!(
                                        "error\': {} / error: {} / name: {}",
                                        v91_1_0.clone(),
                                        v23.clone(),
                                        v4.clone()
                                    ),
                                );
                                let v213: std::io::Error =
                                    std::io::Error::new(std::io::ErrorKind::Other, &*v210);
                                Err(v213)
                            }
                        }
                    } else {
                        let v253: string =
                            append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                                   sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                            v0_1.clone(), v23.clone(),
                                            v0_1.clone(), v4.clone()));
                        let v256: std::io::Error =
                            std::io::Error::new(std::io::ErrorKind::Other, &*v253);
                        Err(v256)
                    }
                } else {
                    let v295: string =
                        append(string("file_system.read_link / run / The file or directory is not a reparse point. / "),
                               sprintf!("path: {} / error: {} / path\': {} / name: {}",
                                        v0_1.clone(), v23.clone(), v0_1,
                                        v4.clone()));
                    let v298: std::io::Error =
                        std::io::Error::new(std::io::ErrorKind::Other, &*v295);
                    Err(v298)
                }
            }
        }
        pub fn method52(v0_1: string, v1_1: u8) -> Result<std::path::PathBuf, std::io::Error> {
            let v29: i32 = Spiral::method53(unbox::<bool>(&getZero()));
            let v31: bool = Spiral::method55(Spiral::method54(), v29);
            if v31 {
                let v33: bool = unbox::<bool>(&getZero());
                let v85: std::path::PathBuf = getZero();
                Ok(v85)
            } else {
                let v106: string =
                    append(string("file_system.read_link / Fsharp / The file or directory is not a reparse point. / "),
                           sprintf!("path: {} / result: {} / path\': {} / n: {}",
                                    v0_1.clone(), v31, v0_1.clone(), v1_1));
                Spiral::method58(
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
                    std::io::Error::new(std::io::ErrorKind::Other, &*v106),
                )
            }
        }
        pub fn method41(v0_1: string) -> Result<std::path::PathBuf, std::io::Error> {
            if Spiral::method33(v0_1.clone()) {
                std::fs::read_link(&*v0_1.clone())
            } else {
                Spiral::method42(v0_1, 0_u8)
            }
        }
        pub fn closure25(unitVar: (), v0_1: std::path::PathBuf) -> Spiral::US15 {
            Spiral::US15::US15_0(v0_1)
        }
        pub fn method59() -> Func1<std::path::PathBuf, Spiral::US15> {
            Func1::new(move |v: std::path::PathBuf| Spiral::closure25((), v))
        }
        pub fn method61(v0_1: string) -> string {
            v0_1
        }
        pub fn method62() -> string {
            string("")
        }
        pub fn method60(v0_1: string, v1_1: string, v2: string) -> string {
            let v5: Result<regex::Regex, regex::Error> = regex::Regex::new(&v0_1);
            let v8: regex::Regex = v5.unwrap();
            let v20: string = Spiral::method61(v2);
            let v22: std::borrow::Cow<str> = v8.replace_all(&*v20, &*v1_1);
            let v24: std::string::String = String::from(v22);
            fable_library_rust::String_::fromString(v24)
        }
        pub fn method40(v0_1: string) -> string {
            if (v0_1.clone()) == string("") {
                string("")
            } else {
                let v3: Result<std::path::PathBuf, std::io::Error> = Spiral::method41(v0_1.clone());
                let v6: Option<std::path::PathBuf> = v3.ok();
                let v31: Spiral::US15 =
                    defaultValue(Spiral::US15::US15_1, map(Spiral::method59(), v6));
                let v64: string = match &v31 {
                    Spiral::US15::US15_0(v31_0_0) => toString(
                        match &v31 {
                            Spiral::US15::US15_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone()
                        .display(),
                    ),
                    _ => v0_1.clone(),
                };
                let v69: string = Spiral::method60(
                    string("^\\\\\\\\\\?\\\\"),
                    string(""),
                    if (v64.clone()) == string("") {
                        v0_1.clone()
                    } else {
                        v64
                    },
                );
                if (length(v69.clone())) < 2_i32 {
                    v0_1.clone()
                } else {
                    replace(
                        concat(new_array(&[
                            toLower(ofChar(getCharAt(v69.clone(), 0_i32))),
                            getSlice(v69, Some(1_i32), None::<i32>),
                        ])),
                        string("\\"),
                        string("/"),
                    )
                }
            }
        }
        pub fn method29(v0_1: string) -> Spiral::US5 {
            let v5: Spiral::US13 = Spiral::method31(
                Spiral::US12::US12_1,
                Spiral::method30(string("spiral"), string("workspace")),
                v0_1.clone(),
            );
            match &v5 {
                Spiral::US13::US13_0(v5_0_0) => {
                    Spiral::US5::US5_0(Spiral::method40(v5_0_0.clone()))
                }
                Spiral::US13::US13_1(v5_1_0) => {
                    let v12: () = {
                        Spiral::closure17(v0_1.clone(), v5_1_0.clone(), ());
                        ()
                    };
                    Spiral::US5::US5_1
                }
            }
        }
        pub fn method63() -> string {
            string("\n")
        }
        pub fn method65(v0_1: string, v1_1: string) -> bool {
            if (Spiral::method32(v0_1.clone())) == false {
                false
            } else {
                let v8: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v0_1);
                let v46: Vec<u8> = Spiral::method27(v8.unwrap());
                let v48: Result<std::string::String, std::string::FromUtf8Error> =
                    std::string::String::from_utf8(v46);
                let v51: std::string::String = v48.unwrap();
                (v1_1) == (fable_library_rust::String_::fromString(v51))
            }
        }
        pub fn closure26(unitVar: (), v0_1: std::io::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method67() -> Func1<std::io::Error, std::string::String> {
            Func1::new(move |v: std::io::Error| Spiral::closure26((), v))
        }
        pub fn closure27(unitVar: (), unitVar_1: ()) -> Spiral::US16 {
            Spiral::US16::US16_0
        }
        pub fn method68() -> Func0<Spiral::US16> {
            Func0::new(move || Spiral::closure27((), ()))
        }
        pub fn closure28(unitVar: (), v0_1: std::string::String) -> Spiral::US16 {
            Spiral::US16::US16_1(v0_1)
        }
        pub fn method69() -> Func1<std::string::String, Spiral::US16> {
            Func1::new(move |v: std::string::String| Spiral::closure28((), v))
        }
        pub fn method70() -> string {
            let v6: string = Spiral::method13(getCharAt(toLower(string("Critical")), 0_i32));
            let v9: &str = inline_colorization::color_bright_red;
            let v12: &str = &*v6;
            let v35: &str = inline_colorization::color_reset;
            let v37: std::string::String = format!("{}{}{}", v9, v12, v35);
            fable_library_rust::String_::fromString(v37)
        }
        pub fn method72(v0_1: string, v1_1: std::string::String) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("dir"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v45: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("error"), ());
                ()
            };
            let v62: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v67: std::string::String = format!("{:#?}", v1_1);
            let v100: () = {
                Spiral::closure7(v3.clone(), fable_library_rust::String_::fromString(v67), ());
                ()
            };
            let v109: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method71(
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
            let v10: string = Spiral::method72(v8, v9);
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method71(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method70(),
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn method73() -> string {
            let v6: string = Spiral::method13(getCharAt(toLower(string("Verbose")), 0_i32));
            let v9: &str = inline_colorization::color_bright_black;
            let v12: &str = &*v6;
            let v35: &str = inline_colorization::color_reset;
            let v37: std::string::String = format!("{}{}{}", v9, v12, v35);
            fable_library_rust::String_::fromString(v37)
        }
        pub fn method75(v0_1: string) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v9: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v18: () = {
                Spiral::closure7(v2.clone(), string("dir"), ());
                ()
            };
            let v27: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v35: () = {
                Spiral::closure7(v2.clone(), v0_1, ());
                ()
            };
            let v44: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method74(
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
            let v9: string = Spiral::method75(v8);
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
                let v24: Option<i64> = patternInput.5.clone();
                let v23: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v22: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v21: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v20: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v19: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method74(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method73(),
                    v0_1,
                ))
            };
        }
        pub fn method77(v0_1: bool, v1_1: string) {
            if Spiral::method33(v1_1.clone()) {
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
            Spiral::method77(true, v0_1);
        }
        pub fn method76(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure31(v0_1.clone(), ())
            })
        }
        pub fn method78(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure31(v0_1.clone(), ())
            })
        }
        pub fn method79(v0_1: string) -> bool {
            unbox::<bool>(&getZero())
        }
        pub fn method81(v0_1: string, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("dir"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v45: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("result"), ());
                ()
            };
            let v62: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method80(
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
            let v10: string = Spiral::method81(v8, v9);
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method80(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method12(),
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn method87(v0_1: string, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("ex"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v45: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("path"), ());
                ()
            };
            let v62: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method86(
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
            let v10: string = Spiral::method87(v8, v9);
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method86(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method12(),
                    sprintf!("{:?}", v1_1),
                    Spiral::method49(v0_1),
                ))
            };
        }
        pub fn method85(v0_1: string, v1_1: i64) -> Arc<Async<i64>> {
            getZero()
        }
        pub fn method84(v0_1: string, v1_1: i64) -> Arc<Async<i64>> {
            getZero()
        }
        pub fn method83(v0_1: string) -> Arc<Async<i64>> {
            Spiral::method84(v0_1, 0_i64)
        }
        pub fn closure33(v0_1: string, unitVar: ()) {
            let v1_1: Arc<Async<i64>> = Spiral::method83(v0_1);
            let v3: Arc<Async<()>> = getZero();
            getZero::<()>();
            ()
        }
        pub fn method82(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure33(v0_1.clone(), ())
            })
        }
        pub fn method88(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure33(v0_1.clone(), ())
            })
        }
        pub fn method66(v0_1: string) -> LrcPtr<dyn IDisposable> {
            let v3: Result<(), std::io::Error> = std::fs::create_dir_all(&*v0_1.clone());
            let v4 = Spiral::method67();
            let v16: Result<(), std::string::String> = v3.map_err(|x| v4(x));
            let v19 = Spiral::method68();
            let v20 = Spiral::method69();
            let v21: Spiral::US16 = match &v16 {
                Err(v16_1_0) => v20(v16_1_0.clone()),
                _ => v19(),
            };
            match &v21 {
                Spiral::US16::US16_0 => {
                    let v24: () = {
                        Spiral::closure30(v0_1.clone(), ());
                        ()
                    };
                    ()
                }
                Spiral::US16::US16_1(v21_1_0) => {
                    let v67: () = {
                        Spiral::closure29(
                            v0_1.clone(),
                            match &v21 {
                                Spiral::US16::US16_1(x) => x.clone(),
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
                let v108 = Spiral::method76(v0_1.clone());
                interface_cast!(
                    Spiral::Disposable::_ctor__3A5B6456(Func0::new({
                        let v108 = v108.clone();
                        move || v108.clone()()
                    })),
                    Lrc<dyn IDisposable>,
                )
            }
        }
        pub fn method64(v0_1: string, v1_1: string) {
            if (Spiral::method65(v0_1.clone(), v1_1.clone())) == false {
                let v6: string = defaultValue(string(""), Spiral::method35(v0_1.clone()));
                if (Spiral::method33(v6.clone())) == false {
                    let v11: LrcPtr<dyn IDisposable> = Spiral::method66(v6);
                    ()
                }
                std::fs::write(&*v0_1, &*v1_1).unwrap();
                ()
            };
        }
        pub fn method90(
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
        pub fn method92() -> string {
            string("")
        }
        pub fn method93(v0_1: i32, v1_1: LrcPtr<Spiral::Mut5>) -> bool {
            (v1_1.l0.get().clone()) < (v0_1)
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
        pub fn method94() -> Func1<char, Func1<LrcPtr<Spiral::UH0>, LrcPtr<Spiral::UH0>>> {
            Func1::new(move |v: char| Spiral::closure36((), v))
        }
        pub fn method95(
            v0_1: LrcPtr<Spiral::UH0>,
            v1_1: LrcPtr<StringBuilder>,
            v2: i32,
            v3: i32,
        ) -> (LrcPtr<StringBuilder>, i32, i32) {
            let v0_1: MutCell<LrcPtr<Spiral::UH0>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
            let v2: MutCell<i32> = MutCell::new(v2);
            let v3: MutCell<i32> = MutCell::new(v3);
            '_method95: loop {
                break '_method95 (match v0_1.get().clone().as_ref() {
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
                                let v12: LrcPtr<StringBuilder> = v1_1.get().clone().Clear();
                                v1_1.get().clone()
                            } else {
                                let v21: LrcPtr<StringBuilder> = {
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
                            continue '_method95;
                        }
                    }
                });
            }
        }
        pub fn closure38(v0_1: i32, v1_1: i32, v2: string) -> string {
            if (v1_1) >= (v0_1) {
                v2.clone()
            } else {
                (Spiral::method96(v0_1, (v1_1) + 1_i32))(append((v2), string(" ")))
            }
        }
        pub fn method96(v0_1: i32, v1_1: i32) -> Func1<string, string> {
            Func1::new({
                let v0_1 = v0_1.clone();
                let v1_1 = v1_1.clone();
                move |v: string| Spiral::closure38(v0_1, v1_1, v)
            })
        }
        pub fn closure35(
            unitVar: (),
            _arg: (string, LrcPtr<StringBuilder>, i32, i32),
        ) -> Spiral::US18 {
            let v3: i32 = _arg.3.clone();
            let v2: i32 = _arg.2.clone();
            let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
            let v0_1: string = _arg.0.clone();
            if string("") == (v0_1.clone()) {
                Spiral::US18::US18_1(sprintf!(
                    "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                    '\"',
                    (v1_1.clone(), v2, v3)
                ))
            } else {
                let v9: char = getCharAt(v0_1.clone(), 0_i32);
                if (v9) == '\"' {
                    let v30: string = getSlice(
                        v0_1.clone(),
                        Some(1_i32),
                        Some((length(v0_1.clone())) - 1_i32),
                    );
                    let v35: string = ofChar(v9);
                    let v38: i32 = length(v35.clone());
                    let v39: Array<char> = new_init(&'\u{0000}', v38);
                    let v40: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Spiral::method93(v38, v40.clone()) {
                        let v42: i32 = v40.l0.get().clone();
                        let v43: char = getCharAt(v35.clone(), v42);
                        v39.get_mut()[v42 as usize] = v43;
                        {
                            let v44: i32 = (v42) + 1_i32;
                            v40.l0.set(v44);
                            ()
                        }
                    }
                    {
                        let v45: List<char> = ofArray(v39.clone());
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method95(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method94())(b0)(b1)
                                }),
                                v45,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US18::US18_0(
                            v9,
                            v30,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v83: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
                    Spiral::US18::US18_1(concat(new_array(&[
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
                                    (if -2_i32 == (v83) {
                                        (length(v0_1)) + 1_i32
                                    } else {
                                        (v83) + 1_i32
                                    }) - 1_i32
                                )
                            )
                        ),
                        string("\n"),
                        append(
                            ((Spiral::method96((v3) - 1_i32, 0_i32))(string(""))),
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
        ) -> Spiral::US18 {
            let v3: i32 = _arg.3.clone();
            let v2: i32 = _arg.2.clone();
            let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
            let v0_1: string = _arg.0.clone();
            if string("") == (v0_1.clone()) {
                Spiral::US18::US18_1(sprintf!(
                    "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                    '\'',
                    (v1_1.clone(), v2, v3)
                ))
            } else {
                let v9: char = getCharAt(v0_1.clone(), 0_i32);
                if (v9) == '\'' {
                    let v30: string = getSlice(
                        v0_1.clone(),
                        Some(1_i32),
                        Some((length(v0_1.clone())) - 1_i32),
                    );
                    let v35: string = ofChar(v9);
                    let v38: i32 = length(v35.clone());
                    let v39: Array<char> = new_init(&'\u{0000}', v38);
                    let v40: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Spiral::method93(v38, v40.clone()) {
                        let v42: i32 = v40.l0.get().clone();
                        let v43: char = getCharAt(v35.clone(), v42);
                        v39.get_mut()[v42 as usize] = v43;
                        {
                            let v44: i32 = (v42) + 1_i32;
                            v40.l0.set(v44);
                            ()
                        }
                    }
                    {
                        let v45: List<char> = ofArray(v39.clone());
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method95(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method94())(b0)(b1)
                                }),
                                v45,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US18::US18_0(
                            v9,
                            v30,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v83: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
                    Spiral::US18::US18_1(concat(new_array(&[
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
                                    (if -2_i32 == (v83) {
                                        (length(v0_1)) + 1_i32
                                    } else {
                                        (v83) + 1_i32
                                    }) - 1_i32
                                )
                            )
                        ),
                        string("\n"),
                        append(
                            ((Spiral::method96((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            }
        }
        pub fn method97(
            v0_1: string,
            v1_1: LrcPtr<StringBuilder>,
            v2: LrcPtr<Spiral::UH1>,
        ) -> Spiral::US18 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<Spiral::UH1>> = MutCell::new(v2.clone());
            '_method97: loop {
                break '_method97 (match v2.get().clone().as_ref() {
                    Spiral::UH1::UH1_0 => {
                        Spiral::US18::US18_1(string("parsing.choice / no parsers succeeded"))
                    }
                    Spiral::UH1::UH1_1(v2_1_0, v2_1_1) => {
                        let v7: Spiral::US18 = (match v2.get().clone().as_ref() {
                            Spiral::UH1::UH1_1(x, _) => x.clone(),
                            _ => unreachable!(),
                        })((
                            v0_1.get().clone(),
                            v1_1.get().clone(),
                            1_i32,
                            1_i32,
                        ));
                        match &v7 {
                            Spiral::US18::US18_0(v7_0_0, v7_0_1, v7_0_2, v7_0_3, v7_0_4) => {
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
                                continue '_method97;
                            }
                        }
                    }
                });
            }
        }
        pub fn method98(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method98: loop {
                break '_method98 (if (v1_1.get().clone()) >= 2_i64 {
                    false
                } else {
                    let v11: Spiral::US20 = if (v1_1.get().clone()) == 0_i64 {
                        Spiral::US20::US20_0('\"')
                    } else {
                        let v5: i64 = (v1_1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral::US20::US20_0('\'')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            Spiral::US20::US20_1
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v11 {
                            Spiral::US20::US20_0(v11_0_0) => match &v11 {
                                Spiral::US20::US20_0(x) => x.clone(),
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
                        continue '_method98;
                    }
                });
            }
        }
        pub fn method99(
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
            '_method99: loop {
                break '_method99 ({
                    let v109: Spiral::US18 = if string("") == (v1_1.get().clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v21: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method98(v21, 0_i64)) == false {
                            let v44: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v49: string = ofChar(v21);
                            let v52: i32 = length(v49.clone());
                            let v53: Array<char> = new_init(&'\u{0000}', v52);
                            let v54: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method93(v52, v54.clone()) {
                                let v56: i32 = v54.l0.get().clone();
                                let v57: char = getCharAt(v49.clone(), v56);
                                v53.get_mut()[v56 as usize] = v57;
                                {
                                    let v58: i32 = (v56) + 1_i32;
                                    v54.l0.set(v58);
                                    ()
                                }
                            }
                            {
                                let v59: List<char> = ofArray(v53.clone());
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method95(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method94())(b0)(b1)
                                            }),
                                            v59,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US18::US18_0(
                                    v21,
                                    v44,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v21,
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v121: Spiral::US18 = match &v109 {
                        Spiral::US18::US18_0(v109_0_0, v109_0_1, v109_0_2, v109_0_3, v109_0_4) => {
                            let v110: char = v109_0_0.clone();
                            Spiral::US18::US18_0(
                                if '\\' == (v110) { '/' } else { v110 },
                                v109_0_1.clone(),
                                v109_0_2.clone(),
                                v109_0_3.clone(),
                                v109_0_4.clone(),
                            )
                        }
                        Spiral::US18::US18_1(v109_1_0) => Spiral::US18::US18_1(v109_1_0.clone()),
                    };
                    match &v121 {
                        Spiral::US18::US18_0(v121_0_0, v121_0_1, v121_0_2, v121_0_3, v121_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v121_0_0.clone())));
                            let v1_1_temp: string = v121_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v121_0_2.clone();
                            let v3_temp: i32 = v121_0_3.clone();
                            let v4_temp: i32 = v121_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method99;
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
        pub fn method100(
            v0_1: string,
            v1_1: LrcPtr<StringBuilder>,
            v2: i32,
            v3: i32,
            v4: LrcPtr<Spiral::UH1>,
        ) -> Spiral::US18 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
            let v2: MutCell<i32> = MutCell::new(v2);
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<LrcPtr<Spiral::UH1>> = MutCell::new(v4.clone());
            '_method100: loop {
                break '_method100 (match v4.get().clone().as_ref() {
                    Spiral::UH1::UH1_0 => {
                        Spiral::US18::US18_1(string("parsing.choice / no parsers succeeded"))
                    }
                    Spiral::UH1::UH1_1(v4_1_0, v4_1_1) => {
                        let v9: Spiral::US18 = (match v4.get().clone().as_ref() {
                            Spiral::UH1::UH1_1(x, _) => x.clone(),
                            _ => unreachable!(),
                        })((
                            v0_1.get().clone(),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                        ));
                        match &v9 {
                            Spiral::US18::US18_0(v9_0_0, v9_0_1, v9_0_2, v9_0_3, v9_0_4) => {
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
                                continue '_method100;
                            }
                        }
                    }
                });
            }
        }
        pub fn method101(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method101: loop {
                break '_method101 (if (v1_1.get().clone()) >= 3_i64 {
                    false
                } else {
                    let v15: Spiral::US20 = if (v1_1.get().clone()) == 0_i64 {
                        Spiral::US20::US20_0('\"')
                    } else {
                        let v5: i64 = (v1_1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral::US20::US20_0('\'')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            if (v8) == 0_i64 {
                                Spiral::US20::US20_0(' ')
                            } else {
                                let v11: i64 = (v8) - 1_i64;
                                Spiral::US20::US20_1
                            }
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v15 {
                            Spiral::US20::US20_0(v15_0_0) => match &v15 {
                                Spiral::US20::US20_0(x) => x.clone(),
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
                        continue '_method101;
                    }
                });
            }
        }
        pub fn method102(
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
            '_method102: loop {
                break '_method102 ({
                    let v115: Spiral::US18 = if string("") == (v1_1.get().clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v24: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method101(v24, 0_i64)) == false {
                            let v47: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v52: string = ofChar(v24);
                            let v55: i32 = length(v52.clone());
                            let v56: Array<char> = new_init(&'\u{0000}', v55);
                            let v57: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method93(v55, v57.clone()) {
                                let v59: i32 = v57.l0.get().clone();
                                let v60: char = getCharAt(v52.clone(), v59);
                                v56.get_mut()[v59 as usize] = v60;
                                {
                                    let v61: i32 = (v59) + 1_i32;
                                    v57.l0.set(v61);
                                    ()
                                }
                            }
                            {
                                let v62: List<char> = ofArray(v56.clone());
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method95(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method94())(b0)(b1)
                                            }),
                                            v62,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US18::US18_0(
                                    v24,
                                    v47,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v24,
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v127: Spiral::US18 = match &v115 {
                        Spiral::US18::US18_0(v115_0_0, v115_0_1, v115_0_2, v115_0_3, v115_0_4) => {
                            let v116: char = v115_0_0.clone();
                            Spiral::US18::US18_0(
                                if '\\' == (v116) { '/' } else { v116 },
                                v115_0_1.clone(),
                                v115_0_2.clone(),
                                v115_0_3.clone(),
                                v115_0_4.clone(),
                            )
                        }
                        Spiral::US18::US18_1(v115_1_0) => Spiral::US18::US18_1(v115_1_0.clone()),
                    };
                    match &v127 {
                        Spiral::US18::US18_0(v127_0_0, v127_0_1, v127_0_2, v127_0_3, v127_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v127_0_0.clone())));
                            let v1_1_temp: string = v127_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v127_0_2.clone();
                            let v3_temp: i32 = v127_0_3.clone();
                            let v4_temp: i32 = v127_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method102;
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
        pub fn method103(v0_1: string, v1_1: i32) -> i32 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<i32> = MutCell::new(v1_1);
            '_method103: loop {
                break '_method103 (if (v1_1.get().clone()) >= (length(v0_1.get().clone())) {
                    v1_1.get().clone()
                } else {
                    if ' ' == (getCharAt(v0_1.get().clone(), v1_1.get().clone())) {
                        let v0_1_temp: string = v0_1.get().clone();
                        let v1_1_temp: i32 = (v1_1.get().clone()) + 1_i32;
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        continue '_method103;
                    } else {
                        v1_1.get().clone()
                    }
                });
            }
        }
        pub fn method104(
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
            '_method104: loop {
                break '_method104 ({
                    let v79: Spiral::US18 = if string("") == (v1_1.get().clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.any_char / unexpected end of input / s: {:?}",
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v10: char = getCharAt(v1_1.get().clone(), 0_i32);
                        let v30: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v35: string = ofChar(v10);
                        let v38: i32 = length(v35.clone());
                        let v39: Array<char> = new_init(&'\u{0000}', v38);
                        let v40: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Spiral::method93(v38, v40.clone()) {
                            let v42: i32 = v40.l0.get().clone();
                            let v43: char = getCharAt(v35.clone(), v42);
                            v39.get_mut()[v42 as usize] = v43;
                            {
                                let v44: i32 = (v42) + 1_i32;
                                v40.l0.set(v44);
                                ()
                            }
                        }
                        {
                            let v45: List<char> = ofArray(v39.clone());
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method95(
                                foldBack(
                                    Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                        (Spiral::method94())(b0)(b1)
                                    }),
                                    v45,
                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                ),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Spiral::US18::US18_0(
                                v10,
                                v30,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        }
                    };
                    match &v79 {
                        Spiral::US18::US18_0(v79_0_0, v79_0_1, v79_0_2, v79_0_3, v79_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v79_0_0.clone())));
                            let v1_1_temp: string = v79_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v79_0_2.clone();
                            let v3_temp: i32 = v79_0_3.clone();
                            let v4_temp: i32 = v79_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method104;
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
        pub fn method91(v0_1: string) -> Spiral::US17 {
            let _v0: MutCell<Option<Option<string>>> = MutCell::new(None::<Option<string>>);
            _v0.set(Some(Some(v0_1)));
            {
                let v7: string = defaultValue(
                    string(""),
                    match &_v0.get().clone() {
                        None => panic!("{}", string("optionm\'.of_obj / _v0=None"),),
                        Some(_v0_0_0) => _v0_0_0.clone(),
                    },
                );
                let v12: LrcPtr<StringBuilder> =
                    StringBuilder::_ctor__Z721C83C5(Spiral::method92());
                fn v15(arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)) -> Spiral::US18 {
                    Spiral::closure35((), arg10_0040)
                }
                fn v16(arg10_0040_1: (string, LrcPtr<StringBuilder>, i32, i32)) -> Spiral::US18 {
                    Spiral::closure39((), arg10_0040_1)
                }
                let v20: Spiral::US18 = Spiral::method97(
                    v7.clone(),
                    v12.clone(),
                    LrcPtr::new(Spiral::UH1::UH1_1(
                        Func1::from(v15),
                        LrcPtr::new(Spiral::UH1::UH1_1(
                            Func1::from(v16),
                            LrcPtr::new(Spiral::UH1::UH1_0),
                        )),
                    )),
                );
                let v202: Spiral::US19 = match &v20 {
                    Spiral::US18::US18_0(v20_0_0, v20_0_1, v20_0_2, v20_0_3, v20_0_4) => {
                        let v25: i32 = v20_0_4.clone();
                        let v24: i32 = v20_0_3.clone();
                        let v23: LrcPtr<StringBuilder> = v20_0_2.clone();
                        let v22: string = v20_0_1.clone();
                        let v130: Spiral::US18 = if string("") == (v22.clone()) {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                (v23.clone(), v24, v25)
                            ))
                        } else {
                            let v42: char = getCharAt(v22.clone(), 0_i32);
                            if (Spiral::method98(v42, 0_i64)) == false {
                                let v65: string = getSlice(
                                    v22.clone(),
                                    Some(1_i32),
                                    Some((length(v22.clone())) - 1_i32),
                                );
                                let v70: string = ofChar(v42);
                                let v73: i32 = length(v70.clone());
                                let v74: Array<char> = new_init(&'\u{0000}', v73);
                                let v75: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method93(v73, v75.clone()) {
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
                                    let v80: List<char> = ofArray(v74.clone());
                                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                        Spiral::method95(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method94())(b0)(b1)
                                                    },
                                                ),
                                                v80,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v23.clone(),
                                            v24,
                                            v25,
                                        );
                                    Spiral::US18::US18_0(
                                        v42,
                                        v65,
                                        patternInput.0.clone(),
                                        patternInput.1.clone(),
                                        patternInput.2.clone(),
                                    )
                                }
                            } else {
                                Spiral::US18::US18_1(sprintf!("parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                                                      v42,
                                                                      toArray(ofArray(new_array(&['\"',
                                                                                                  '\'']))),
                                                                      (v23.clone(),
                                                                       v24,
                                                                       v25)))
                            }
                        };
                        let v142: Spiral::US18 = match &v130 {
                            Spiral::US18::US18_0(
                                v130_0_0,
                                v130_0_1,
                                v130_0_2,
                                v130_0_3,
                                v130_0_4,
                            ) => {
                                let v131: char = v130_0_0.clone();
                                Spiral::US18::US18_0(
                                    if '\\' == (v131) { '/' } else { v131 },
                                    v130_0_1.clone(),
                                    v130_0_2.clone(),
                                    v130_0_3.clone(),
                                    v130_0_4.clone(),
                                )
                            }
                            Spiral::US18::US18_1(v130_1_0) => {
                                Spiral::US18::US18_1(v130_1_0.clone())
                            }
                        };
                        let v161: Spiral::US19 = match &v142 {
                            Spiral::US18::US18_0(
                                v142_0_0,
                                v142_0_1,
                                v142_0_2,
                                v142_0_3,
                                v142_0_4,
                            ) => {
                                let patternInput_1: (
                                    string,
                                    string,
                                    LrcPtr<StringBuilder>,
                                    i32,
                                    i32,
                                ) = Spiral::method99(
                                    ofChar(v142_0_0.clone()),
                                    v142_0_1.clone(),
                                    v142_0_2.clone(),
                                    v142_0_3.clone(),
                                    v142_0_4.clone(),
                                );
                                Spiral::US19::US19_0(
                                    patternInput_1.0.clone(),
                                    patternInput_1.1.clone(),
                                    patternInput_1.2.clone(),
                                    patternInput_1.3.clone(),
                                    patternInput_1.4.clone(),
                                )
                            }
                            Spiral::US18::US18_1(v142_1_0) => {
                                Spiral::US19::US19_1(v142_1_0.clone())
                            }
                        };
                        let v171: Spiral::US19 = match &v161 {
                            Spiral::US19::US19_0(
                                v161_0_0,
                                v161_0_1,
                                v161_0_2,
                                v161_0_3,
                                v161_0_4,
                            ) => Spiral::US19::US19_0(
                                v161_0_0.clone(),
                                v161_0_1.clone(),
                                v161_0_2.clone(),
                                v161_0_3.clone(),
                                v161_0_4.clone(),
                            ),
                            _ => {
                                Spiral::US19::US19_0(string(""), v22.clone(), v23.clone(), v24, v25)
                            }
                        };
                        match &v171 {
                            Spiral::US19::US19_0(
                                v171_0_0,
                                v171_0_1,
                                v171_0_2,
                                v171_0_3,
                                v171_0_4,
                            ) => {
                                let v176: i32 = v171_0_4.clone();
                                let v175: i32 = v171_0_3.clone();
                                let v174: LrcPtr<StringBuilder> = v171_0_2.clone();
                                let v173: string = v171_0_1.clone();
                                let v180: Spiral::US18 = Spiral::method100(
                                    v173.clone(),
                                    v174.clone(),
                                    v175,
                                    v176,
                                    LrcPtr::new(Spiral::UH1::UH1_1(
                                        Func1::from(v15),
                                        LrcPtr::new(Spiral::UH1::UH1_1(
                                            Func1::from(v16),
                                            LrcPtr::new(Spiral::UH1::UH1_0),
                                        )),
                                    )),
                                );
                                match &v180 {
                                        Spiral::US18::US18_0(v180_0_0,
                                                             v180_0_1,
                                                             v180_0_2,
                                                             v180_0_3,
                                                             v180_0_4) =>
                                        Spiral::US19::US19_0(v171_0_0.clone(),
                                                             v180_0_1.clone(),
                                                             v180_0_2.clone(),
                                                             v180_0_3.clone(),
                                                             v180_0_4.clone()),
                                        Spiral::US18::US18_1(v180_1_0) =>
                                        Spiral::US19::US19_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                      v180_1_0.clone(),
                                                                      (v7.clone(),
                                                                       v12.clone(),
                                                                       1_i32,
                                                                       1_i32),
                                                                      (v22.clone(),
                                                                       v23.clone(),
                                                                       v24,
                                                                       v25),
                                                                      (v173.clone(),
                                                                       v174.clone(),
                                                                       v175,
                                                                       v176))),
                                    }
                            }
                            _ => Spiral::US19::US19_1(string("parsing.between / expected content")),
                        }
                    }
                    Spiral::US18::US18_1(v20_1_0) => Spiral::US19::US19_1(v20_1_0.clone()),
                };
                let v414: Spiral::US19 = match &v202 {
                    Spiral::US19::US19_0(v202_0_0, v202_0_1, v202_0_2, v202_0_3, v202_0_4) => {
                        v202.clone()
                    }
                    _ => {
                        let v321: Spiral::US18 = if string("") == (v7.clone()) {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                (v12.clone(), 1_i32, 1_i32)
                            ))
                        } else {
                            let v228: char = getCharAt(v7.clone(), 0_i32);
                            if (Spiral::method101(v228, 0_i64)) == false {
                                let v251: string = getSlice(
                                    v7.clone(),
                                    Some(1_i32),
                                    Some((length(v7.clone())) - 1_i32),
                                );
                                let v256: string = ofChar(v228);
                                let v259: i32 = length(v256.clone());
                                let v260: Array<char> = new_init(&'\u{0000}', v259);
                                let v261: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method93(v259, v261.clone()) {
                                    let v263: i32 = v261.l0.get().clone();
                                    let v264: char = getCharAt(v256.clone(), v263);
                                    v260.get_mut()[v263 as usize] = v264;
                                    {
                                        let v265: i32 = (v263) + 1_i32;
                                        v261.l0.set(v265);
                                        ()
                                    }
                                }
                                {
                                    let v266: List<char> = ofArray(v260.clone());
                                    let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                        Spiral::method95(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method94())(b0)(b1)
                                                    },
                                                ),
                                                v266,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v12.clone(),
                                            1_i32,
                                            1_i32,
                                        );
                                    Spiral::US18::US18_0(
                                        v228,
                                        v251,
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone(),
                                        patternInput_2.2.clone(),
                                    )
                                }
                            } else {
                                Spiral::US18::US18_1(sprintf!("parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                                                      v228,
                                                                      toArray(ofArray(new_array(&['\"',
                                                                                                  '\'',
                                                                                                  ' ']))),
                                                                      (v12.clone(),
                                                                       1_i32,
                                                                       1_i32)))
                            }
                        };
                        let v333: Spiral::US18 = match &v321 {
                            Spiral::US18::US18_0(
                                v321_0_0,
                                v321_0_1,
                                v321_0_2,
                                v321_0_3,
                                v321_0_4,
                            ) => {
                                let v322: char = v321_0_0.clone();
                                Spiral::US18::US18_0(
                                    if '\\' == (v322) { '/' } else { v322 },
                                    v321_0_1.clone(),
                                    v321_0_2.clone(),
                                    v321_0_3.clone(),
                                    v321_0_4.clone(),
                                )
                            }
                            Spiral::US18::US18_1(v321_1_0) => {
                                Spiral::US18::US18_1(v321_1_0.clone())
                            }
                        };
                        let v352: Spiral::US19 = match &v333 {
                            Spiral::US18::US18_0(
                                v333_0_0,
                                v333_0_1,
                                v333_0_2,
                                v333_0_3,
                                v333_0_4,
                            ) => {
                                let patternInput_3: (
                                    string,
                                    string,
                                    LrcPtr<StringBuilder>,
                                    i32,
                                    i32,
                                ) = Spiral::method102(
                                    ofChar(v333_0_0.clone()),
                                    v333_0_1.clone(),
                                    v333_0_2.clone(),
                                    v333_0_3.clone(),
                                    v333_0_4.clone(),
                                );
                                Spiral::US19::US19_0(
                                    patternInput_3.0.clone(),
                                    patternInput_3.1.clone(),
                                    patternInput_3.2.clone(),
                                    patternInput_3.3.clone(),
                                    patternInput_3.4.clone(),
                                )
                            }
                            Spiral::US18::US18_1(v333_1_0) => {
                                Spiral::US19::US19_1(v333_1_0.clone())
                            }
                        };
                        match &v352 {
                            Spiral::US19::US19_0(
                                v352_0_0,
                                v352_0_1,
                                v352_0_2,
                                v352_0_3,
                                v352_0_4,
                            ) => v352.clone(),
                            _ => {
                                let v366: Spiral::US21 = if (length(v7.clone())) == 0_i32 {
                                    Spiral::US21::US21_0(v7.clone(), v12.clone(), 1_i32, 1_i32)
                                } else {
                                    Spiral::US21::US21_1(sprintf!(
                                        "parsing.eof / expected end of input / input: {:?}",
                                        v7.clone()
                                    ))
                                };
                                let v375: Spiral::US19 = match &v366 {
                                    Spiral::US21::US21_0(
                                        v366_0_0,
                                        v366_0_1,
                                        v366_0_2,
                                        v366_0_3,
                                    ) => Spiral::US19::US19_0(
                                        string(""),
                                        v366_0_0.clone(),
                                        v366_0_1.clone(),
                                        v366_0_2.clone(),
                                        v366_0_3.clone(),
                                    ),
                                    Spiral::US21::US21_1(v366_1_0) => {
                                        Spiral::US19::US19_1(v366_1_0.clone())
                                    }
                                };
                                match &v375 {
                                    Spiral::US19::US19_0(
                                        v375_0_0,
                                        v375_0_1,
                                        v375_0_2,
                                        v375_0_3,
                                        v375_0_4,
                                    ) => {
                                        let v377: string = v375_0_1.clone();
                                        Spiral::US19::US19_0(
                                            v375_0_0.clone(),
                                            getSlice(
                                                v377.clone(),
                                                Some(Spiral::method103(v377.clone(), 0_i32)),
                                                Some((length(v377)) - 1_i32),
                                            ),
                                            v375_0_2.clone(),
                                            v375_0_3.clone(),
                                            v375_0_4.clone(),
                                        )
                                    }
                                    Spiral::US19::US19_1(v375_1_0) => {
                                        Spiral::US19::US19_1(v375_1_0.clone())
                                    }
                                }
                            }
                        }
                    }
                };
                let v682: Spiral::US22 = match &v414 {
                    Spiral::US19::US19_0(v414_0_0, v414_0_1, v414_0_2, v414_0_3, v414_0_4) => {
                        let v419: i32 = v414_0_4.clone();
                        let v418: i32 = v414_0_3.clone();
                        let v417: LrcPtr<StringBuilder> = v414_0_2.clone();
                        let v416: string = v414_0_1.clone();
                        let v541: Spiral::US18 = if string("") == (v416.clone()) {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                ' ',
                                (v417.clone(), v418, v419)
                            ))
                        } else {
                            let v425: char = getCharAt(v416.clone(), 0_i32);
                            if (v425) == ' ' {
                                let v446: string = getSlice(
                                    v416.clone(),
                                    Some(1_i32),
                                    Some((length(v416.clone())) - 1_i32),
                                );
                                let v451: string = ofChar(v425);
                                let v454: i32 = length(v451.clone());
                                let v455: Array<char> = new_init(&'\u{0000}', v454);
                                let v456: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method93(v454, v456.clone()) {
                                    let v458: i32 = v456.l0.get().clone();
                                    let v459: char = getCharAt(v451.clone(), v458);
                                    v455.get_mut()[v458 as usize] = v459;
                                    {
                                        let v460: i32 = (v458) + 1_i32;
                                        v456.l0.set(v460);
                                        ()
                                    }
                                }
                                {
                                    let v461: List<char> = ofArray(v455.clone());
                                    let patternInput_4: (LrcPtr<StringBuilder>, i32, i32) =
                                        Spiral::method95(
                                            foldBack(
                                                Func2::new(
                                                    move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                        (Spiral::method94())(b0)(b1)
                                                    },
                                                ),
                                                v461,
                                                LrcPtr::new(Spiral::UH0::UH0_0),
                                            ),
                                            v417.clone(),
                                            v418,
                                            v419,
                                        );
                                    Spiral::US18::US18_0(
                                        v425,
                                        v446,
                                        patternInput_4.0.clone(),
                                        patternInput_4.1.clone(),
                                        patternInput_4.2.clone(),
                                    )
                                }
                            } else {
                                let v499: i32 = (indexOf(v416.clone(), string("\n"))) - 1_i32;
                                Spiral::US18::US18_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                         ' ',
                                                                                         v418,
                                                                                         v419,
                                                                                         v417.clone(),
                                                                                         getSlice(v416.clone(),
                                                                                                  Some(0_i32),
                                                                                                  Some((if -2_i32
                                                                                                               ==
                                                                                                               (v499)
                                                                                                           {
                                                                                                            (length(v416.clone()))
                                                                                                                +
                                                                                                                1_i32
                                                                                                        } else {
                                                                                                            (v499)
                                                                                                                +
                                                                                                                1_i32
                                                                                                        })
                                                                                                           -
                                                                                                           1_i32))),
                                                                                string("\n"),
                                                                                append(((Spiral::method96((v419)
                                                                                                              -
                                                                                                              1_i32,
                                                                                                          0_i32))(string(""))),
                                                                                       string("^")),
                                                                                string("\n")])))
                            }
                        };
                        let v553: Spiral::US23 = match &v541 {
                            Spiral::US18::US18_0(
                                v541_0_0,
                                v541_0_1,
                                v541_0_2,
                                v541_0_3,
                                v541_0_4,
                            ) => Spiral::US23::US23_0(
                                Spiral::US20::US20_0(v541_0_0.clone()),
                                v541_0_1.clone(),
                                v541_0_2.clone(),
                                v541_0_3.clone(),
                                v541_0_4.clone(),
                            ),
                            _ => Spiral::US23::US23_0(
                                Spiral::US20::US20_1,
                                v416.clone(),
                                v417.clone(),
                                v418,
                                v419,
                            ),
                        };
                        let v656: Spiral::US19 = match &v553 {
                            Spiral::US23::US23_0(
                                v553_0_0,
                                v553_0_1,
                                v553_0_2,
                                v553_0_3,
                                v553_0_4,
                            ) => {
                                let v558: i32 = v553_0_4.clone();
                                let v557: i32 = v553_0_3.clone();
                                let v556: LrcPtr<StringBuilder> = v553_0_2.clone();
                                let v555: string = v553_0_1.clone();
                                let v633: Spiral::US18 = if string("") == (v555.clone()) {
                                    Spiral::US18::US18_1(sprintf!(
                                        "parsing.any_char / unexpected end of input / s: {:?}",
                                        (v556.clone(), v557, v558)
                                    ))
                                } else {
                                    let v564: char = getCharAt(v555.clone(), 0_i32);
                                    let v584: string = getSlice(
                                        v555.clone(),
                                        Some(1_i32),
                                        Some((length(v555)) - 1_i32),
                                    );
                                    let v589: string = ofChar(v564);
                                    let v592: i32 = length(v589.clone());
                                    let v593: Array<char> = new_init(&'\u{0000}', v592);
                                    let v594: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method93(v592, v594.clone()) {
                                        let v596: i32 = v594.l0.get().clone();
                                        let v597: char = getCharAt(v589.clone(), v596);
                                        v593.get_mut()[v596 as usize] = v597;
                                        {
                                            let v598: i32 = (v596) + 1_i32;
                                            v594.l0.set(v598);
                                            ()
                                        }
                                    }
                                    {
                                        let v599: List<char> = ofArray(v593.clone());
                                        let patternInput_5: (LrcPtr<StringBuilder>, i32, i32) =
                                            Spiral::method95(
                                                foldBack(
                                                    Func2::new(
                                                        move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                            (Spiral::method94())(b0)(b1)
                                                        },
                                                    ),
                                                    v599,
                                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                                ),
                                                v556,
                                                v557,
                                                v558,
                                            );
                                        Spiral::US18::US18_0(
                                            v564,
                                            v584,
                                            patternInput_5.0.clone(),
                                            patternInput_5.1.clone(),
                                            patternInput_5.2.clone(),
                                        )
                                    }
                                };
                                match &v633 {
                                    Spiral::US18::US18_0(
                                        v633_0_0,
                                        v633_0_1,
                                        v633_0_2,
                                        v633_0_3,
                                        v633_0_4,
                                    ) => {
                                        let patternInput_6: (
                                            string,
                                            string,
                                            LrcPtr<StringBuilder>,
                                            i32,
                                            i32,
                                        ) = Spiral::method104(
                                            ofChar(v633_0_0.clone()),
                                            v633_0_1.clone(),
                                            v633_0_2.clone(),
                                            v633_0_3.clone(),
                                            v633_0_4.clone(),
                                        );
                                        Spiral::US19::US19_0(
                                            patternInput_6.0.clone(),
                                            patternInput_6.1.clone(),
                                            patternInput_6.2.clone(),
                                            patternInput_6.3.clone(),
                                            patternInput_6.4.clone(),
                                        )
                                    }
                                    Spiral::US18::US18_1(v633_1_0) => {
                                        Spiral::US19::US19_1(v633_1_0.clone())
                                    }
                                }
                            }
                            Spiral::US23::US23_1(v553_1_0) => {
                                Spiral::US19::US19_1(v553_1_0.clone())
                            }
                        };
                        let v668: Spiral::US24 = match &v656 {
                            Spiral::US19::US19_0(
                                v656_0_0,
                                v656_0_1,
                                v656_0_2,
                                v656_0_3,
                                v656_0_4,
                            ) => Spiral::US24::US24_0(
                                Spiral::US5::US5_0(v656_0_0.clone()),
                                v656_0_1.clone(),
                                v656_0_2.clone(),
                                v656_0_3.clone(),
                                v656_0_4.clone(),
                            ),
                            _ => Spiral::US24::US24_0(
                                Spiral::US5::US5_1,
                                v416.clone(),
                                v417.clone(),
                                v418,
                                v419,
                            ),
                        };
                        match &v668 {
                            Spiral::US24::US24_0(
                                v668_0_0,
                                v668_0_1,
                                v668_0_2,
                                v668_0_3,
                                v668_0_4,
                            ) => Spiral::US22::US22_0(
                                v414_0_0.clone(),
                                v668_0_0.clone(),
                                v668_0_1.clone(),
                                v668_0_2.clone(),
                                v668_0_3.clone(),
                                v668_0_4.clone(),
                            ),
                            Spiral::US24::US24_1(v668_1_0) => {
                                Spiral::US22::US22_1(v668_1_0.clone())
                            }
                        }
                    }
                    Spiral::US19::US19_1(v414_1_0) => Spiral::US22::US22_1(v414_1_0.clone()),
                };
                match &v682 {
                    Spiral::US22::US22_0(
                        v682_0_0,
                        v682_0_1,
                        v682_0_2,
                        v682_0_3,
                        v682_0_4,
                        v682_0_5,
                    ) => Spiral::US17::US17_0(v682_0_0.clone(), v682_0_1.clone()),
                    Spiral::US22::US22_1(v682_1_0) => Spiral::US17::US17_1(v682_1_0.clone()),
                }
            }
        }
        pub fn method107(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method107: loop {
                break '_method107 (if (v1_1.get().clone()) >= 4_i64 {
                    false
                } else {
                    let v19: Spiral::US20 = if (v1_1.get().clone()) == 0_i64 {
                        Spiral::US20::US20_0('\\')
                    } else {
                        let v5: i64 = (v1_1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral::US20::US20_0('`')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            if (v8) == 0_i64 {
                                Spiral::US20::US20_0('\"')
                            } else {
                                let v11: i64 = (v8) - 1_i64;
                                if (v11) == 0_i64 {
                                    Spiral::US20::US20_0(' ')
                                } else {
                                    let v14: i64 = (v11) - 1_i64;
                                    Spiral::US20::US20_1
                                }
                            }
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v19 {
                            Spiral::US20::US20_0(v19_0_0) => match &v19 {
                                Spiral::US20::US20_0(x) => x.clone(),
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
                    let v121: Spiral::US18 = if string("") == (v1_1.get().clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v27: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method107(v27, 0_i64)) == false {
                            let v50: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v55: string = ofChar(v27);
                            let v58: i32 = length(v55.clone());
                            let v59: Array<char> = new_init(&'\u{0000}', v58);
                            let v60: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method93(v58, v60.clone()) {
                                let v62: i32 = v60.l0.get().clone();
                                let v63: char = getCharAt(v55.clone(), v62);
                                v59.get_mut()[v62 as usize] = v63;
                                {
                                    let v64: i32 = (v62) + 1_i32;
                                    v60.l0.set(v64);
                                    ()
                                }
                            }
                            {
                                let v65: List<char> = ofArray(v59.clone());
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method95(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method94())(b0)(b1)
                                            }),
                                            v65,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US18::US18_0(
                                    v27,
                                    v50,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v27,
                                toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    match &v121 {
                        Spiral::US18::US18_0(v121_0_0, v121_0_1, v121_0_2, v121_0_3, v121_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v121_0_0.clone())));
                            let v1_1_temp: string = v121_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v121_0_2.clone();
                            let v3_temp: i32 = v121_0_3.clone();
                            let v4_temp: i32 = v121_0_4.clone();
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
        pub fn method110(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method110: loop {
                break '_method110 (if (v1_1.get().clone()) >= 3_i64 {
                    false
                } else {
                    let v15: Spiral::US20 = if (v1_1.get().clone()) == 0_i64 {
                        Spiral::US20::US20_0('\\')
                    } else {
                        let v5: i64 = (v1_1.get().clone()) - 1_i64;
                        if (v5) == 0_i64 {
                            Spiral::US20::US20_0('`')
                        } else {
                            let v8: i64 = (v5) - 1_i64;
                            if (v8) == 0_i64 {
                                Spiral::US20::US20_0('\"')
                            } else {
                                let v11: i64 = (v8) - 1_i64;
                                Spiral::US20::US20_1
                            }
                        }
                    };
                    if (v0_1.get().clone())
                        == (match &v15 {
                            Spiral::US20::US20_0(v15_0_0) => match &v15 {
                                Spiral::US20::US20_0(x) => x.clone(),
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
                        continue '_method110;
                    }
                });
            }
        }
        pub fn closure40(
            unitVar: (),
            _arg: (string, LrcPtr<StringBuilder>, i32, i32),
        ) -> Spiral::US19 {
            let v3: i32 = _arg.3.clone();
            let v2: i32 = _arg.2.clone();
            let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
            let v0_1: string = _arg.0.clone();
            let v126: Spiral::US18 = if string("") == (v0_1.clone()) {
                Spiral::US18::US18_1(sprintf!(
                    "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                    '\\',
                    (v1_1.clone(), v2, v3)
                ))
            } else {
                let v9: char = getCharAt(v0_1.clone(), 0_i32);
                if (v9) == '\\' {
                    let v30: string = getSlice(
                        v0_1.clone(),
                        Some(1_i32),
                        Some((length(v0_1.clone())) - 1_i32),
                    );
                    let v35: string = ofChar(v9);
                    let v38: i32 = length(v35.clone());
                    let v39: Array<char> = new_init(&'\u{0000}', v38);
                    let v40: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Spiral::method93(v38, v40.clone()) {
                        let v42: i32 = v40.l0.get().clone();
                        let v43: char = getCharAt(v35.clone(), v42);
                        v39.get_mut()[v42 as usize] = v43;
                        {
                            let v44: i32 = (v42) + 1_i32;
                            v40.l0.set(v44);
                            ()
                        }
                    }
                    {
                        let v45: List<char> = ofArray(v39.clone());
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method95(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method94())(b0)(b1)
                                }),
                                v45,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US18::US18_0(
                            v9,
                            v30,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v83: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
                    Spiral::US18::US18_1(concat(new_array(&[
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
                                    (if -2_i32 == (v83) {
                                        (length(v0_1)) + 1_i32
                                    } else {
                                        (v83) + 1_i32
                                    }) - 1_i32
                                )
                            )
                        ),
                        string("\n"),
                        append(
                            ((Spiral::method96((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            };
            let v210: Spiral::US18 = match &v126 {
                Spiral::US18::US18_0(v126_0_0, v126_0_1, v126_0_2, v126_0_3, v126_0_4) => {
                    let v131: i32 = v126_0_4.clone();
                    let v130: i32 = v126_0_3.clone();
                    let v129: LrcPtr<StringBuilder> = v126_0_2.clone();
                    let v128: string = v126_0_1.clone();
                    if string("") == (v128.clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.any_char / unexpected end of input / s: {:?}",
                            (v129.clone(), v130, v131)
                        ))
                    } else {
                        let v137: char = getCharAt(v128.clone(), 0_i32);
                        let v157: string =
                            getSlice(v128.clone(), Some(1_i32), Some((length(v128)) - 1_i32));
                        let v162: string = ofChar(v137);
                        let v165: i32 = length(v162.clone());
                        let v166: Array<char> = new_init(&'\u{0000}', v165);
                        let v167: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Spiral::method93(v165, v167.clone()) {
                            let v169: i32 = v167.l0.get().clone();
                            let v170: char = getCharAt(v162.clone(), v169);
                            v166.get_mut()[v169 as usize] = v170;
                            {
                                let v171: i32 = (v169) + 1_i32;
                                v167.l0.set(v171);
                                ()
                            }
                        }
                        {
                            let v172: List<char> = ofArray(v166.clone());
                            let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method95(
                                    foldBack(
                                        Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                            (Spiral::method94())(b0)(b1)
                                        }),
                                        v172,
                                        LrcPtr::new(Spiral::UH0::UH0_0),
                                    ),
                                    v129,
                                    v130,
                                    v131,
                                );
                            Spiral::US18::US18_0(
                                v137,
                                v157,
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                            )
                        }
                    }
                }
                Spiral::US18::US18_1(v126_1_0) => Spiral::US18::US18_1(v126_1_0.clone()),
            };
            match &v210 {
                Spiral::US18::US18_0(v210_0_0, v210_0_1, v210_0_2, v210_0_3, v210_0_4) => {
                    Spiral::US19::US19_0(
                        append((ofChar('\\')), (ofChar(v210_0_0.clone()))),
                        v210_0_1.clone(),
                        v210_0_2.clone(),
                        v210_0_3.clone(),
                        v210_0_4.clone(),
                    )
                }
                Spiral::US18::US18_1(v210_1_0) => Spiral::US19::US19_1(v210_1_0.clone()),
            }
        }
        pub fn closure41(
            unitVar: (),
            _arg: (string, LrcPtr<StringBuilder>, i32, i32),
        ) -> Spiral::US19 {
            let v3: i32 = _arg.3.clone();
            let v2: i32 = _arg.2.clone();
            let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
            let v0_1: string = _arg.0.clone();
            let v126: Spiral::US18 = if string("") == (v0_1.clone()) {
                Spiral::US18::US18_1(sprintf!(
                    "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                    '`',
                    (v1_1.clone(), v2, v3)
                ))
            } else {
                let v9: char = getCharAt(v0_1.clone(), 0_i32);
                if (v9) == '`' {
                    let v30: string = getSlice(
                        v0_1.clone(),
                        Some(1_i32),
                        Some((length(v0_1.clone())) - 1_i32),
                    );
                    let v35: string = ofChar(v9);
                    let v38: i32 = length(v35.clone());
                    let v39: Array<char> = new_init(&'\u{0000}', v38);
                    let v40: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                        l0: MutCell::new(0_i32),
                    });
                    while Spiral::method93(v38, v40.clone()) {
                        let v42: i32 = v40.l0.get().clone();
                        let v43: char = getCharAt(v35.clone(), v42);
                        v39.get_mut()[v42 as usize] = v43;
                        {
                            let v44: i32 = (v42) + 1_i32;
                            v40.l0.set(v44);
                            ()
                        }
                    }
                    {
                        let v45: List<char> = ofArray(v39.clone());
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method95(
                            foldBack(
                                Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                    (Spiral::method94())(b0)(b1)
                                }),
                                v45,
                                LrcPtr::new(Spiral::UH0::UH0_0),
                            ),
                            v1_1.clone(),
                            v2,
                            v3,
                        );
                        Spiral::US18::US18_0(
                            v9,
                            v30,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    }
                } else {
                    let v83: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
                    Spiral::US18::US18_1(concat(new_array(&[
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
                                    (if -2_i32 == (v83) {
                                        (length(v0_1)) + 1_i32
                                    } else {
                                        (v83) + 1_i32
                                    }) - 1_i32
                                )
                            )
                        ),
                        string("\n"),
                        append(
                            ((Spiral::method96((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            };
            let v210: Spiral::US18 = match &v126 {
                Spiral::US18::US18_0(v126_0_0, v126_0_1, v126_0_2, v126_0_3, v126_0_4) => {
                    let v131: i32 = v126_0_4.clone();
                    let v130: i32 = v126_0_3.clone();
                    let v129: LrcPtr<StringBuilder> = v126_0_2.clone();
                    let v128: string = v126_0_1.clone();
                    if string("") == (v128.clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.any_char / unexpected end of input / s: {:?}",
                            (v129.clone(), v130, v131)
                        ))
                    } else {
                        let v137: char = getCharAt(v128.clone(), 0_i32);
                        let v157: string =
                            getSlice(v128.clone(), Some(1_i32), Some((length(v128)) - 1_i32));
                        let v162: string = ofChar(v137);
                        let v165: i32 = length(v162.clone());
                        let v166: Array<char> = new_init(&'\u{0000}', v165);
                        let v167: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                            l0: MutCell::new(0_i32),
                        });
                        while Spiral::method93(v165, v167.clone()) {
                            let v169: i32 = v167.l0.get().clone();
                            let v170: char = getCharAt(v162.clone(), v169);
                            v166.get_mut()[v169 as usize] = v170;
                            {
                                let v171: i32 = (v169) + 1_i32;
                                v167.l0.set(v171);
                                ()
                            }
                        }
                        {
                            let v172: List<char> = ofArray(v166.clone());
                            let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method95(
                                    foldBack(
                                        Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                            (Spiral::method94())(b0)(b1)
                                        }),
                                        v172,
                                        LrcPtr::new(Spiral::UH0::UH0_0),
                                    ),
                                    v129,
                                    v130,
                                    v131,
                                );
                            Spiral::US18::US18_0(
                                v137,
                                v157,
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                            )
                        }
                    }
                }
                Spiral::US18::US18_1(v126_1_0) => Spiral::US18::US18_1(v126_1_0.clone()),
            };
            match &v210 {
                Spiral::US18::US18_0(v210_0_0, v210_0_1, v210_0_2, v210_0_3, v210_0_4) => {
                    Spiral::US19::US19_0(
                        append((ofChar('`')), (ofChar(v210_0_0.clone()))),
                        v210_0_1.clone(),
                        v210_0_2.clone(),
                        v210_0_3.clone(),
                        v210_0_4.clone(),
                    )
                }
                Spiral::US18::US18_1(v210_1_0) => Spiral::US19::US19_1(v210_1_0.clone()),
            }
        }
        pub fn method111(
            v0_1: string,
            v1_1: LrcPtr<StringBuilder>,
            v2: i32,
            v3: i32,
            v4: LrcPtr<Spiral::UH3>,
        ) -> Spiral::US19 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
            let v2: MutCell<i32> = MutCell::new(v2);
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<LrcPtr<Spiral::UH3>> = MutCell::new(v4.clone());
            '_method111: loop {
                break '_method111 (match v4.get().clone().as_ref() {
                    Spiral::UH3::UH3_0 => {
                        Spiral::US19::US19_1(string("parsing.choice / no parsers succeeded"))
                    }
                    Spiral::UH3::UH3_1(v4_1_0, v4_1_1) => {
                        let v9: Spiral::US19 = (match v4.get().clone().as_ref() {
                            Spiral::UH3::UH3_1(x, _) => x.clone(),
                            _ => unreachable!(),
                        })((
                            v0_1.get().clone(),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                        ));
                        match &v9 {
                            Spiral::US19::US19_0(v9_0_0, v9_0_1, v9_0_2, v9_0_3, v9_0_4) => {
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
                                continue '_method111;
                            }
                        }
                    }
                });
            }
        }
        pub fn method112(
            v0_1: LrcPtr<Spiral::UH2>,
            v1_1: LrcPtr<Spiral::UH2>,
        ) -> LrcPtr<Spiral::UH2> {
            let v0_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v1_1.clone());
            '_method112: loop {
                break '_method112 (match v0_1.get().clone().as_ref() {
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
                        continue '_method112;
                    }
                });
            }
        }
        pub fn method109(
            v0_1: LrcPtr<Spiral::UH2>,
            v1_1: string,
            v2: LrcPtr<StringBuilder>,
            v3: i32,
            v4: i32,
        ) -> Spiral::US26 {
            let v0_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<i32> = MutCell::new(v4);
            '_method109: loop {
                break '_method109 ({
                    let v115: Spiral::US18 = if string("") == (v1_1.get().clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v24: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method110(v24, 0_i64)) == false {
                            let v47: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v52: string = ofChar(v24);
                            let v55: i32 = length(v52.clone());
                            let v56: Array<char> = new_init(&'\u{0000}', v55);
                            let v57: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method93(v55, v57.clone()) {
                                let v59: i32 = v57.l0.get().clone();
                                let v60: char = getCharAt(v52.clone(), v59);
                                v56.get_mut()[v59 as usize] = v60;
                                {
                                    let v61: i32 = (v59) + 1_i32;
                                    v57.l0.set(v61);
                                    ()
                                }
                            }
                            {
                                let v62: List<char> = ofArray(v56.clone());
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method95(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method94())(b0)(b1)
                                            }),
                                            v62,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US18::US18_0(
                                    v24,
                                    v47,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v24,
                                toArray(ofArray(new_array(&['\\', '`', '\"']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v129: Spiral::US19 = match &v115 {
                        Spiral::US18::US18_0(v115_0_0, v115_0_1, v115_0_2, v115_0_3, v115_0_4) => {
                            Spiral::US19::US19_0(
                                ofChar(v115_0_0.clone()),
                                v115_0_1.clone(),
                                v115_0_2.clone(),
                                v115_0_3.clone(),
                                v115_0_4.clone(),
                            )
                        }
                        Spiral::US18::US18_1(v115_1_0) => Spiral::US19::US19_1(v115_1_0.clone()),
                    };
                    let v143: Spiral::US19 = match &v129 {
                        Spiral::US19::US19_0(v129_0_0, v129_0_1, v129_0_2, v129_0_3, v129_0_4) => {
                            v129.clone()
                        }
                        _ => Spiral::method111(
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
                    match &v143 {
                        Spiral::US19::US19_0(v143_0_0, v143_0_1, v143_0_2, v143_0_3, v143_0_4) => {
                            let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(Spiral::UH2::UH2_1(
                                v143_0_0.clone(),
                                v0_1.get().clone(),
                            ));
                            let v1_1_temp: string = v143_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v143_0_2.clone();
                            let v3_temp: i32 = v143_0_3.clone();
                            let v4_temp: i32 = v143_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method109;
                        }
                        _ => Spiral::US26::US26_0(
                            Spiral::method112(v0_1.get().clone(), LrcPtr::new(Spiral::UH2::UH2_0)),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method113(v0_1: LrcPtr<Spiral::UH2>, v1_1: List<string>) -> List<string> {
            match v0_1.as_ref() {
                Spiral::UH2::UH2_0 => v1_1.clone(),
                Spiral::UH2::UH2_1(v0_1_1_0, v0_1_1_1) => cons(
                    match v0_1.as_ref() {
                        Spiral::UH2::UH2_1(x, _) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    Spiral::method113(
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
        pub fn method114(
            v0_1: LrcPtr<Spiral::UH2>,
            v1_1: string,
            v2: LrcPtr<StringBuilder>,
            v3: i32,
            v4: i32,
        ) -> Spiral::US26 {
            let v0_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<i32> = MutCell::new(v4);
            '_method114: loop {
                break '_method114 ({
                    let v115: Spiral::US18 = if string("") == (v1_1.get().clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v24: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method110(v24, 0_i64)) == false {
                            let v47: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v52: string = ofChar(v24);
                            let v55: i32 = length(v52.clone());
                            let v56: Array<char> = new_init(&'\u{0000}', v55);
                            let v57: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method93(v55, v57.clone()) {
                                let v59: i32 = v57.l0.get().clone();
                                let v60: char = getCharAt(v52.clone(), v59);
                                v56.get_mut()[v59 as usize] = v60;
                                {
                                    let v61: i32 = (v59) + 1_i32;
                                    v57.l0.set(v61);
                                    ()
                                }
                            }
                            {
                                let v62: List<char> = ofArray(v56.clone());
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method95(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method94())(b0)(b1)
                                            }),
                                            v62,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US18::US18_0(
                                    v24,
                                    v47,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v24,
                                toArray(ofArray(new_array(&['\\', '`', '\"']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v129: Spiral::US19 = match &v115 {
                        Spiral::US18::US18_0(v115_0_0, v115_0_1, v115_0_2, v115_0_3, v115_0_4) => {
                            Spiral::US19::US19_0(
                                ofChar(v115_0_0.clone()),
                                v115_0_1.clone(),
                                v115_0_2.clone(),
                                v115_0_3.clone(),
                                v115_0_4.clone(),
                            )
                        }
                        Spiral::US18::US18_1(v115_1_0) => Spiral::US19::US19_1(v115_1_0.clone()),
                    };
                    match &v129 {
                        Spiral::US19::US19_0(v129_0_0, v129_0_1, v129_0_2, v129_0_3, v129_0_4) => {
                            let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(Spiral::UH2::UH2_1(
                                v129_0_0.clone(),
                                v0_1.get().clone(),
                            ));
                            let v1_1_temp: string = v129_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v129_0_2.clone();
                            let v3_temp: i32 = v129_0_3.clone();
                            let v4_temp: i32 = v129_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method114;
                        }
                        _ => Spiral::US26::US26_0(
                            Spiral::method112(v0_1.get().clone(), LrcPtr::new(Spiral::UH2::UH2_0)),
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
            v0_1: LrcPtr<Spiral::UH2>,
            v1_1: string,
            v2: LrcPtr<StringBuilder>,
            v3: i32,
            v4: i32,
        ) -> Spiral::US26 {
            let v0_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v2.clone());
            let v3: MutCell<i32> = MutCell::new(v3);
            let v4: MutCell<i32> = MutCell::new(v4);
            '_method106: loop {
                break '_method106 ({
                    let v5: bool = string("") == (v1_1.get().clone());
                    let v121: Spiral::US18 = if v5 {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v27: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method107(v27, 0_i64)) == false {
                            let v50: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v55: string = ofChar(v27);
                            let v58: i32 = length(v55.clone());
                            let v59: Array<char> = new_init(&'\u{0000}', v58);
                            let v60: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                l0: MutCell::new(0_i32),
                            });
                            while Spiral::method93(v58, v60.clone()) {
                                let v62: i32 = v60.l0.get().clone();
                                let v63: char = getCharAt(v55.clone(), v62);
                                v59.get_mut()[v62 as usize] = v63;
                                {
                                    let v64: i32 = (v62) + 1_i32;
                                    v60.l0.set(v64);
                                    ()
                                }
                            }
                            {
                                let v65: List<char> = ofArray(v59.clone());
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method95(
                                        foldBack(
                                            Func2::new(move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                (Spiral::method94())(b0)(b1)
                                            }),
                                            v65,
                                            LrcPtr::new(Spiral::UH0::UH0_0),
                                        ),
                                        v2.get().clone(),
                                        v3.get().clone(),
                                        v4.get().clone(),
                                    );
                                Spiral::US18::US18_0(
                                    v27,
                                    v50,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            }
                        } else {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v27,
                                toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v140: Spiral::US19 = match &v121 {
                        Spiral::US18::US18_0(v121_0_0, v121_0_1, v121_0_2, v121_0_3, v121_0_4) => {
                            let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method108(
                                    ofChar(v121_0_0.clone()),
                                    v121_0_1.clone(),
                                    v121_0_2.clone(),
                                    v121_0_3.clone(),
                                    v121_0_4.clone(),
                                );
                            Spiral::US19::US19_0(
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                                patternInput_1.3.clone(),
                                patternInput_1.4.clone(),
                            )
                        }
                        Spiral::US18::US18_1(v121_1_0) => Spiral::US19::US19_1(v121_1_0.clone()),
                    };
                    let v517: Spiral::US19 = match &v140 {
                        Spiral::US19::US19_0(v140_0_0, v140_0_1, v140_0_2, v140_0_3, v140_0_4) => {
                            v140.clone()
                        }
                        _ => {
                            let v268: Spiral::US18 = if v5 {
                                Spiral::US18::US18_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                                                               '\"',
                                                                               (v2.get().clone(),
                                                                                v3.get().clone(),
                                                                                v4.get().clone())))
                            } else {
                                let v151: char = getCharAt(v1_1.get().clone(), 0_i32);
                                if (v151) == '\"' {
                                    let v172: string = getSlice(
                                        v1_1.get().clone(),
                                        Some(1_i32),
                                        Some((length(v1_1.get().clone())) - 1_i32),
                                    );
                                    let v177: string = ofChar(v151);
                                    let v180: i32 = length(v177.clone());
                                    let v181: Array<char> = new_init(&'\u{0000}', v180);
                                    let v182: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method93(v180, v182.clone()) {
                                        let v184: i32 = v182.l0.get().clone();
                                        let v185: char = getCharAt(v177.clone(), v184);
                                        v181.get_mut()[v184 as usize] = v185;
                                        {
                                            let v186: i32 = (v184) + 1_i32;
                                            v182.l0.set(v186);
                                            ()
                                        }
                                    }
                                    {
                                        let v187: List<char> = ofArray(v181.clone());
                                        let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                            Spiral::method95(
                                                foldBack(
                                                    Func2::new(
                                                        move |b0: char, b1: LrcPtr<Spiral::UH0>| {
                                                            (Spiral::method94())(b0)(b1)
                                                        },
                                                    ),
                                                    v187,
                                                    LrcPtr::new(Spiral::UH0::UH0_0),
                                                ),
                                                v2.get().clone(),
                                                v3.get().clone(),
                                                v4.get().clone(),
                                            );
                                        Spiral::US18::US18_0(
                                            v151,
                                            v172,
                                            patternInput_2.0.clone(),
                                            patternInput_2.1.clone(),
                                            patternInput_2.2.clone(),
                                        )
                                    }
                                } else {
                                    let v225: i32 =
                                        (indexOf(v1_1.get().clone(), string("\n"))) - 1_i32;
                                    Spiral::US18::US18_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                                      '\"',
                                                                                                      v3.get().clone(),
                                                                                                      v4.get().clone(),
                                                                                                      v2.get().clone(),
                                                                                                      getSlice(v1_1.get().clone(),
                                                                                                               Some(0_i32),
                                                                                                               Some((if -2_i32
                                                                                                                            ==
                                                                                                                            (v225)
                                                                                                                        {
                                                                                                                         (length(v1_1.get().clone()))
                                                                                                                             +
                                                                                                                             1_i32
                                                                                                                     } else {
                                                                                                                         (v225)
                                                                                                                             +
                                                                                                                             1_i32
                                                                                                                     })
                                                                                                                        -
                                                                                                                        1_i32))),
                                                                                             string("\n"),
                                                                                             append(((Spiral::method96((v4.get().clone())
                                                                                                                           -
                                                                                                                           1_i32,
                                                                                                                       0_i32))(string(""))),
                                                                                                    string("^")),
                                                                                             string("\n")])))
                                }
                            };
                            let v452: Spiral::US19 = match &v268 {
                                Spiral::US18::US18_0(
                                    v268_0_0,
                                    v268_0_1,
                                    v268_0_2,
                                    v268_0_3,
                                    v268_0_4,
                                ) => {
                                    let v273: i32 = v268_0_4.clone();
                                    let v272: i32 = v268_0_3.clone();
                                    let v271: LrcPtr<StringBuilder> = v268_0_2.clone();
                                    let v270: string = v268_0_1.clone();
                                    let v275: Spiral::US26 = Spiral::method109(
                                        LrcPtr::new(Spiral::UH2::UH2_0),
                                        v270.clone(),
                                        v271.clone(),
                                        v272,
                                        v273,
                                    );
                                    let v302: Spiral::US19 = match &v275 {
                                        Spiral::US26::US26_0(
                                            v275_0_0,
                                            v275_0_1,
                                            v275_0_2,
                                            v275_0_3,
                                            v275_0_4,
                                        ) => {
                                            let v282: List<string> = Spiral::method113(
                                                v275_0_0.clone(),
                                                empty::<string>(),
                                            );
                                            Spiral::US19::US19_0(
                                                join(
                                                    string(""),
                                                    toArray_1(delay(Func0::new({
                                                        let v282 = v282.clone();
                                                        move || ofList(v282.clone()).clone()
                                                    }))),
                                                ),
                                                v275_0_1.clone(),
                                                v275_0_2.clone(),
                                                v275_0_3.clone(),
                                                v275_0_4.clone(),
                                            )
                                        }
                                        Spiral::US26::US26_1(v275_1_0) => {
                                            Spiral::US19::US19_1(v275_1_0.clone())
                                        }
                                    };
                                    match &v302 {
                                        Spiral::US19::US19_0(
                                            v302_0_0,
                                            v302_0_1,
                                            v302_0_2,
                                            v302_0_3,
                                            v302_0_4,
                                        ) => {
                                            let v307: i32 = v302_0_4.clone();
                                            let v306: i32 = v302_0_3.clone();
                                            let v305: LrcPtr<StringBuilder> = v302_0_2.clone();
                                            let v304: string = v302_0_1.clone();
                                            let v430: Spiral::US18 = if string("") == (v304.clone())
                                            {
                                                Spiral::US18::US18_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                                                                                   '\"',
                                                                                                   (v305.clone(),
                                                                                                    v306,
                                                                                                    v307)))
                                            } else {
                                                let v313: char = getCharAt(v304.clone(), 0_i32);
                                                if (v313) == '\"' {
                                                    let v334: string = getSlice(
                                                        v304.clone(),
                                                        Some(1_i32),
                                                        Some((length(v304.clone())) - 1_i32),
                                                    );
                                                    let v339: string = ofChar(v313);
                                                    let v342: i32 = length(v339.clone());
                                                    let v343: Array<char> =
                                                        new_init(&'\u{0000}', v342);
                                                    let v344: LrcPtr<Spiral::Mut5> =
                                                        LrcPtr::new(Spiral::Mut5 {
                                                            l0: MutCell::new(0_i32),
                                                        });
                                                    while Spiral::method93(v342, v344.clone()) {
                                                        let v346: i32 = v344.l0.get().clone();
                                                        let v347: char =
                                                            getCharAt(v339.clone(), v346);
                                                        v343.get_mut()[v346 as usize] = v347;
                                                        {
                                                            let v348: i32 = (v346) + 1_i32;
                                                            v344.l0.set(v348);
                                                            ()
                                                        }
                                                    }
                                                    {
                                                        let v349: List<char> =
                                                            ofArray(v343.clone());
                                                        let patternInput_3:
                                                                                     (LrcPtr<StringBuilder>,
                                                                                      i32,
                                                                                      i32) =
                                                                                 Spiral::method95(foldBack(Func2::new(move
                                                                                                                          |b0:
                                                                                                                               char,
                                                                                                                           b1:
                                                                                                                               LrcPtr<Spiral::UH0>|
                                                                                                                          (Spiral::method94())(b0)(b1)),
                                                                                                           v349,
                                                                                                           LrcPtr::new(Spiral::UH0::UH0_0)),
                                                                                                  v305.clone(),
                                                                                                  v306,
                                                                                                  v307);
                                                        Spiral::US18::US18_0(
                                                            v313,
                                                            v334,
                                                            patternInput_3.0.clone(),
                                                            patternInput_3.1.clone(),
                                                            patternInput_3.2.clone(),
                                                        )
                                                    }
                                                } else {
                                                    let v387: i32 =
                                                        (indexOf(v304.clone(), string("\n")))
                                                            - 1_i32;
                                                    Spiral::US18::US18_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                                                          '\"',
                                                                                                                          v306,
                                                                                                                          v307,
                                                                                                                          v305.clone(),
                                                                                                                          getSlice(v304.clone(),
                                                                                                                                   Some(0_i32),
                                                                                                                                   Some((if -2_i32
                                                                                                                                                ==
                                                                                                                                                (v387)
                                                                                                                                            {
                                                                                                                                             (length(v304.clone()))
                                                                                                                                                 +
                                                                                                                                                 1_i32
                                                                                                                                         } else {
                                                                                                                                             (v387)
                                                                                                                                                 +
                                                                                                                                                 1_i32
                                                                                                                                         })
                                                                                                                                            -
                                                                                                                                            1_i32))),
                                                                                                                 string("\n"),
                                                                                                                 append(((Spiral::method96((v307)
                                                                                                                                               -
                                                                                                                                               1_i32,
                                                                                                                                           0_i32))(string(""))),
                                                                                                                        string("^")),
                                                                                                                 string("\n")])))
                                                }
                                            };
                                            match &v430 {
                                                                 Spiral::US18::US18_0(v430_0_0,
                                                                                      v430_0_1,
                                                                                      v430_0_2,
                                                                                      v430_0_3,
                                                                                      v430_0_4)
                                                                 =>
                                                                 Spiral::US19::US19_0(v302_0_0.clone(),
                                                                                      v430_0_1.clone(),
                                                                                      v430_0_2.clone(),
                                                                                      v430_0_3.clone(),
                                                                                      v430_0_4.clone()),
                                                                 Spiral::US18::US18_1(v430_1_0)
                                                                 =>
                                                                 Spiral::US19::US19_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                                               v430_1_0.clone(),
                                                                                               (v1_1.get().clone(),
                                                                                                v2.get().clone(),
                                                                                                v3.get().clone(),
                                                                                                v4.get().clone()),
                                                                                               (v270.clone(),
                                                                                                v271.clone(),
                                                                                                v272,
                                                                                                v273),
                                                                                               (v304.clone(),
                                                                                                v305.clone(),
                                                                                                v306,
                                                                                                v307))),
                                                             }
                                        }
                                        _ => Spiral::US19::US19_1(string(
                                            "parsing.between / expected content",
                                        )),
                                    }
                                }
                                Spiral::US18::US18_1(v268_1_0) => {
                                    Spiral::US19::US19_1(v268_1_0.clone())
                                }
                            };
                            match &v452 {
                                Spiral::US19::US19_0(
                                    v452_0_0,
                                    v452_0_1,
                                    v452_0_2,
                                    v452_0_3,
                                    v452_0_4,
                                ) => v452.clone(),
                                _ => {
                                    let v464: Spiral::US19 =
                                                     Spiral::method111(v1_1.get().clone(),
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
                                    let v475: Spiral::US19 = match &v464 {
                                        Spiral::US19::US19_0(
                                            v464_0_0,
                                            v464_0_1,
                                            v464_0_2,
                                            v464_0_3,
                                            v464_0_4,
                                        ) => Spiral::US19::US19_0(
                                            string(""),
                                            v464_0_1.clone(),
                                            v464_0_2.clone(),
                                            v464_0_3.clone(),
                                            v464_0_4.clone(),
                                        ),
                                        Spiral::US19::US19_1(v464_1_0) => {
                                            Spiral::US19::US19_1(v464_1_0.clone())
                                        }
                                    };
                                    let v486: Spiral::US26 = match &v475 {
                                        Spiral::US19::US19_0(
                                            v475_0_0,
                                            v475_0_1,
                                            v475_0_2,
                                            v475_0_3,
                                            v475_0_4,
                                        ) => Spiral::method114(
                                            LrcPtr::new(Spiral::UH2::UH2_0),
                                            v475_0_1.clone(),
                                            v475_0_2.clone(),
                                            v475_0_3.clone(),
                                            v475_0_4.clone(),
                                        ),
                                        Spiral::US19::US19_1(v475_1_0) => {
                                            Spiral::US26::US26_1(v475_1_0.clone())
                                        }
                                    };
                                    match &v486 {
                                        Spiral::US26::US26_0(
                                            v486_0_0,
                                            v486_0_1,
                                            v486_0_2,
                                            v486_0_3,
                                            v486_0_4,
                                        ) => {
                                            let v493: List<string> = Spiral::method113(
                                                v486_0_0.clone(),
                                                empty::<string>(),
                                            );
                                            Spiral::US19::US19_0(
                                                join(
                                                    string(""),
                                                    toArray_1(delay(Func0::new({
                                                        let v493 = v493.clone();
                                                        move || ofList(v493.clone()).clone()
                                                    }))),
                                                ),
                                                v486_0_1.clone(),
                                                v486_0_2.clone(),
                                                v486_0_3.clone(),
                                                v486_0_4.clone(),
                                            )
                                        }
                                        Spiral::US26::US26_1(v486_1_0) => {
                                            Spiral::US19::US19_1(v486_1_0.clone())
                                        }
                                    }
                                }
                            }
                        }
                    };
                    match &v517 {
                        Spiral::US19::US19_0(v517_0_0, v517_0_1, v517_0_2, v517_0_3, v517_0_4) => {
                            let v522: i32 = v517_0_4.clone();
                            let v521: i32 = v517_0_3.clone();
                            let v520: LrcPtr<StringBuilder> = v517_0_2.clone();
                            let v519: string = v517_0_1.clone();
                            let v518: string = v517_0_0.clone();
                            let v524: i32 = Spiral::method103(v519.clone(), 0_i32);
                            let v552: Spiral::US21 = if 0_i32 == (v524) {
                                Spiral::US21::US21_1(string(
                                    "parsing.spaces1 / expected at least one space",
                                ))
                            } else {
                                Spiral::US21::US21_0(
                                    getSlice(
                                        v519.clone(),
                                        Some(v524),
                                        Some((length(v519.clone())) - 1_i32),
                                    ),
                                    v520.clone(),
                                    v521,
                                    v522,
                                )
                            };
                            match &v552 {
                                Spiral::US21::US21_0(v552_0_0, v552_0_1, v552_0_2, v552_0_3) => {
                                    let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(
                                        Spiral::UH2::UH2_1(v518.clone(), v0_1.get().clone()),
                                    );
                                    let v1_1_temp: string = v552_0_0.clone();
                                    let v2_temp: LrcPtr<StringBuilder> = v552_0_1.clone();
                                    let v3_temp: i32 = v552_0_2.clone();
                                    let v4_temp: i32 = v552_0_3.clone();
                                    v0_1.set(v0_1_temp);
                                    v1_1.set(v1_1_temp);
                                    v2.set(v2_temp);
                                    v3.set(v3_temp);
                                    v4.set(v4_temp);
                                    continue '_method106;
                                }
                                _ => Spiral::US26::US26_0(
                                    Spiral::method112(
                                        v0_1.get().clone(),
                                        LrcPtr::new(Spiral::UH2::UH2_1(
                                            v518.clone(),
                                            LrcPtr::new(Spiral::UH2::UH2_0),
                                        )),
                                    ),
                                    v519.clone(),
                                    v520.clone(),
                                    v521,
                                    v522,
                                ),
                            }
                        }
                        _ => Spiral::US26::US26_0(
                            Spiral::method112(v0_1.get().clone(), LrcPtr::new(Spiral::UH2::UH2_0)),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method105(v0_1: string) -> Spiral::US25 {
            let _v0: MutCell<Option<Option<string>>> = MutCell::new(None::<Option<string>>);
            _v0.set(Some(Some(v0_1)));
            {
                let v18: Spiral::US26 = Spiral::method106(
                    LrcPtr::new(Spiral::UH2::UH2_0),
                    defaultValue(
                        string(""),
                        match &_v0.get().clone() {
                            None => panic!("{}", string("optionm\'.of_obj / _v0=None"),),
                            Some(_v0_0_0) => _v0_0_0.clone(),
                        },
                    ),
                    StringBuilder::_ctor__Z721C83C5(Spiral::method92()),
                    1_i32,
                    1_i32,
                );
                match &v18 {
                    Spiral::US26::US26_0(v18_0_0, v18_0_1, v18_0_2, v18_0_3, v18_0_4) => {
                        Spiral::US25::US25_0(toArray(Spiral::method113(
                            v18_0_0.clone(),
                            empty::<string>(),
                        )))
                    }
                    Spiral::US26::US26_1(v18_1_0) => Spiral::US25::US25_1(v18_1_0.clone()),
                }
            }
        }
        pub fn method116(
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
            let v17: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v26: () = {
                Spiral::closure7(v10.clone(), string("file_name"), ());
                ()
            };
            let v35: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v10.clone(), v0_1, ());
                ()
            };
            let v52: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v61: () = {
                Spiral::closure7(v10.clone(), string("arguments"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v77: () = {
                Spiral::closure7(v10.clone(), v1_1, ());
                ()
            };
            let v85: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v10.clone(), string("options"), ());
                ()
            };
            let v102: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v110: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v119: () = {
                Spiral::closure7(v10.clone(), string("command"), ());
                ()
            };
            let v127: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v135: () = {
                Spiral::closure7(v10.clone(), v2, ());
                ()
            };
            let v143: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v152: () = {
                Spiral::closure7(v10.clone(), string("cancellation_token"), ());
                ()
            };
            let v160: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v165: std::string::String = format!("{:#?}", v3);
            let v198: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v165),
                    (),
                );
                ()
            };
            let v206: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v215: () = {
                Spiral::closure7(v10.clone(), string("environment_variables"), ());
                ()
            };
            let v223: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v234: () = {
                Spiral::closure7(v10.clone(), sprintf!("{:?}", v4), ());
                ()
            };
            let v242: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v251: () = {
                Spiral::closure7(v10.clone(), string("on_line"), ());
                ()
            };
            let v259: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v264: std::string::String = format!("{:#?}", v5);
            let v297: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v264),
                    (),
                );
                ()
            };
            let v305: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v314: () = {
                Spiral::closure7(v10.clone(), string("stdin"), ());
                ()
            };
            let v322: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v327: std::string::String = format!("{:#?}", v6);
            let v360: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v327),
                    (),
                );
                ()
            };
            let v368: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v377: () = {
                Spiral::closure7(v10.clone(), string("trace"), ());
                ()
            };
            let v385: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v396: () = {
                Spiral::closure7(
                    v10.clone(),
                    if v7 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v404: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v413: () = {
                Spiral::closure7(v10.clone(), string("working_directory"), ());
                ()
            };
            let v421: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v426: std::string::String = format!("{:#?}", v8);
            let v459: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v426),
                    (),
                );
                ()
            };
            let v468: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            let v476: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            v10.l0.get().clone()
        }
        pub fn method115(
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
            let v17: string = Spiral::method116(v8, v9, v10, v11, v12, v13, v14, v15, v16);
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
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method115(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
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
        pub fn method117() -> Func1<Option<std::process::Child>, Option<std::process::Child>> {
            Func1::new(move |v: Option<std::process::Child>| Spiral::closure43((), v))
        }
        pub fn closure44(
            unitVar: (),
            v0_1: std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>,
        ) -> Spiral::US27 {
            Spiral::US27::US27_0(v0_1)
        }
        pub fn method118(
        ) -> Func1<std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>, Spiral::US27>
        {
            Func1::new(
                move |v: std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>| {
                    Spiral::closure44((), v)
                },
            )
        }
        pub fn closure45(unitVar: (), v0_1: std::string::String) -> Spiral::US27 {
            Spiral::US27::US27_1(v0_1)
        }
        pub fn method119() -> Func1<std::string::String, Spiral::US27> {
            Func1::new(move |v: std::string::String| Spiral::closure45((), v))
        }
        pub fn method121(v0_1: std::string::String) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v9: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v18: () = {
                Spiral::closure7(v2.clone(), string("error"), ());
                ()
            };
            let v27: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v32: std::string::String = format!("{:#?}", v0_1);
            let v65: () = {
                Spiral::closure7(v2.clone(), fable_library_rust::String_::fromString(v32), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method120(
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
            let v9: string = Spiral::method121(v8);
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
                let v24: Option<i64> = patternInput.5.clone();
                let v23: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v22: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v21: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v20: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v19: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method120(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method70(),
                    v0_1,
                ))
            };
        }
        pub fn method122(
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
        pub fn method123(
        ) -> Func1<Option<std::process::ChildStdin>, Option<std::process::ChildStdin>> {
            Func1::new(move |v: Option<std::process::ChildStdin>| Spiral::closure47((), v))
        }
        pub fn closure48(
            unitVar: (),
            v0_1: std::sync::mpsc::Sender<std::string::String>,
        ) -> std::sync::mpsc::Sender<std::string::String> {
            v0_1
        }
        pub fn method124() -> Func1<
            std::sync::mpsc::Sender<std::string::String>,
            std::sync::mpsc::Sender<std::string::String>,
        > {
            Func1::new(move |v: std::sync::mpsc::Sender<std::string::String>| {
                Spiral::closure48((), v)
            })
        }
        pub fn method125() -> Func1<
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
        pub fn method126() -> Func1<
            std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
            std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
        > {
            Func1::new(
                move |v: std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>| {
                    Spiral::closure49((), v)
                },
            )
        }
        pub fn closure50(unitVar: (), v0_1: std::string::String) -> Spiral::US29 {
            Spiral::US29::US29_0(v0_1)
        }
        pub fn method127() -> Func1<std::string::String, Spiral::US29> {
            Func1::new(move |v: std::string::String| Spiral::closure50((), v))
        }
        pub fn closure51(unitVar: (), v0_1: std::string::String) -> Spiral::US29 {
            Spiral::US29::US29_1(v0_1)
        }
        pub fn method128() -> Func1<std::string::String, Spiral::US29> {
            Func1::new(move |v: std::string::String| Spiral::closure51((), v))
        }
        pub fn method130(v0_1: bool, v1_1: std::string::String) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("trace\'"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v39: () = {
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
            let v48: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v57: () = {
                Spiral::closure7(v3.clone(), string("e"), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v70: std::string::String = format!("{:#?}", v1_1);
            let v103: () = {
                Spiral::closure7(v3.clone(), fable_library_rust::String_::fromString(v70), ());
                ()
            };
            let v112: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method129(
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
            let v10: string = Spiral::method130(v8, v9);
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method129(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method70(),
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn method132() -> string {
            let v1_1: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            v1_1.l0.get().clone()
        }
        pub fn method131(
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
            let v9: string = Spiral::method132();
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
                let v24: Option<i64> = patternInput.5.clone();
                let v23: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v22: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v21: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v20: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v19: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(if (v0_1.clone()) == string("") {
                    string("")
                } else {
                    Spiral::method131(
                        v19.clone(),
                        v20.clone(),
                        v21.clone(),
                        v22.clone(),
                        v23.clone(),
                        v24.clone(),
                        Spiral::method8(v19, v20, v21, v22, v23, v24),
                        Spiral::method73(),
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
        pub fn method133(
        ) -> Func1<std::sync::mpsc::SendError<std::string::String>, std::string::String> {
            Func1::new(move |v: std::sync::mpsc::SendError<std::string::String>| {
                Spiral::closure54((), v)
            })
        }
        pub fn method134(v0_1: Result<(), string>) -> Result<(), string> {
            v0_1
        }
        pub fn closure55(
            unitVar: (),
            v0_1: Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>,
        ) -> Spiral::US30 {
            Spiral::US30::US30_0(v0_1)
        }
        pub fn method135() -> Func1<
            Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>,
            Spiral::US30,
        > {
            Func1::new(
                move |v: Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>| {
                    Spiral::closure55((), v)
                },
            )
        }
        pub fn method136(
            v0_1: std::sync::MutexGuard<Option<std::process::ChildStdin>>,
        ) -> std::sync::MutexGuard<Option<std::process::ChildStdin>> {
            v0_1
        }
        pub fn closure56(
            unitVar: (),
            v0_1: std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
        ) -> Spiral::US31 {
            Spiral::US31::US31_0(v0_1)
        }
        pub fn method137(
        ) -> Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, Spiral::US31>
        {
            Func1::new(
                move |v: std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>| {
                    Spiral::closure56((), v)
                },
            )
        }
        pub fn method138(
            v0_1: std::sync::MutexGuard<std::process::ChildStdin>,
        ) -> std::sync::MutexGuard<std::process::ChildStdin> {
            v0_1
        }
        pub fn closure57(unitVar: (), v0_1: std::process::Output) -> Spiral::US32 {
            Spiral::US32::US32_0(v0_1)
        }
        pub fn method139() -> Func1<std::process::Output, Spiral::US32> {
            Func1::new(move |v: std::process::Output| Spiral::closure57((), v))
        }
        pub fn closure58(unitVar: (), v0_1: std::string::String) -> Spiral::US32 {
            Spiral::US32::US32_1(v0_1)
        }
        pub fn method140() -> Func1<std::string::String, Spiral::US32> {
            Func1::new(move |v: std::string::String| Spiral::closure58((), v))
        }
        pub fn method141(
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
            let v9: string = Spiral::method121(v8);
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
                let v24: Option<i64> = patternInput.5.clone();
                let v23: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v22: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v21: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v20: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v19: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method141(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method70(),
                    v0_1,
                ))
            };
        }
        pub fn closure60(unitVar: (), v0_1: i32) -> Spiral::US33 {
            Spiral::US33::US33_0(v0_1)
        }
        pub fn method142() -> Func1<i32, Spiral::US33> {
            Func1::new(move |v: i32| Spiral::closure60((), v))
        }
        pub fn method144(v0_1: i32, v1_1: i32) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v45: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("std_trace_length"), ());
                ()
            };
            let v62: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method143(
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
            let v10: string = Spiral::method144(v8, v9);
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method143(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method73(),
                    v0_1,
                    length(v1_1),
                ))
            };
        }
        pub fn method148(
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
            let v17: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v26: () = {
                Spiral::closure7(v10.clone(), string("file_name"), ());
                ()
            };
            let v35: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v10.clone(), v0_1, ());
                ()
            };
            let v52: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v61: () = {
                Spiral::closure7(v10.clone(), string("arguments"), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v80: () = {
                Spiral::closure7(v10.clone(), sprintf!("{:?}", v1_1), ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v97: () = {
                Spiral::closure7(v10.clone(), string("options"), ());
                ()
            };
            let v105: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v113: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v122: () = {
                Spiral::closure7(v10.clone(), string("command"), ());
                ()
            };
            let v130: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v138: () = {
                Spiral::closure7(v10.clone(), v2, ());
                ()
            };
            let v146: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v155: () = {
                Spiral::closure7(v10.clone(), string("cancellation_token"), ());
                ()
            };
            let v163: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v168: std::string::String = format!("{:#?}", v3);
            let v201: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v168),
                    (),
                );
                ()
            };
            let v209: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v218: () = {
                Spiral::closure7(v10.clone(), string("environment_variables"), ());
                ()
            };
            let v226: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v237: () = {
                Spiral::closure7(v10.clone(), sprintf!("{:?}", v4), ());
                ()
            };
            let v245: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v254: () = {
                Spiral::closure7(v10.clone(), string("on_line"), ());
                ()
            };
            let v262: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v267: std::string::String = format!("{:#?}", v5);
            let v300: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v267),
                    (),
                );
                ()
            };
            let v308: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v317: () = {
                Spiral::closure7(v10.clone(), string("stdin"), ());
                ()
            };
            let v325: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v330: std::string::String = format!("{:#?}", v6);
            let v363: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v330),
                    (),
                );
                ()
            };
            let v371: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v380: () = {
                Spiral::closure7(v10.clone(), string("trace"), ());
                ()
            };
            let v388: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v399: () = {
                Spiral::closure7(
                    v10.clone(),
                    if v7 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v407: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v416: () = {
                Spiral::closure7(v10.clone(), string("working_directory"), ());
                ()
            };
            let v424: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v429: std::string::String = format!("{:#?}", v8);
            let v462: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v429),
                    (),
                );
                ()
            };
            let v471: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            let v479: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            v10.l0.get().clone()
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
            let v17: string = Spiral::method148(v8, v9, v10, v11, v12, v13, v14, v15, v16);
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
                let v32: Option<i64> = patternInput.5.clone();
                let v31: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v30: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v29: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v28: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v27: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method147(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
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
        pub fn method149(
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
        pub fn method152(v0_1: bool) -> string {
            unbox::<string>(&getZero())
        }
        pub fn closure64(
            unitVar: (),
            v0_1: Func1<(i32, string, bool), Arc<Async<()>>>,
        ) -> Spiral::US34 {
            Spiral::US34::US34_0(v0_1)
        }
        pub fn method153() -> Func1<Func1<(i32, string, bool), Arc<Async<()>>>, Spiral::US34> {
            Func1::new(move |v: Func1<(i32, string, bool), Arc<Async<()>>>| {
                Spiral::closure64((), v)
            })
        }
        pub fn method154(v0_1: bool) -> i32 {
            unbox::<i32>(&getZero())
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
                let v24: Option<i64> = patternInput.5.clone();
                let v23: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v22: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v21: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v20: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v19: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(if (v0_1.clone()) == string("") {
                    string("")
                } else {
                    Spiral::method131(
                        v19.clone(),
                        v20.clone(),
                        v21.clone(),
                        v22.clone(),
                        v23.clone(),
                        v24.clone(),
                        Spiral::method8(v19, v20, v21, v22, v23, v24),
                        Spiral::method73(),
                        v0_1,
                    )
                })
            };
        }
        pub fn method151(
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
            getZero()
        }
        pub fn method150(
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
            Spiral::method151(v0_1, v1_1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
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
                Spiral::method150(v0_1, v1_1, v2, v3, v4, v5, v6, v7, v8, v9, v10);
            getZero::<()>();
            ()
        }
        pub fn closure66(unitVar: (), v0_1: CancellationToken) -> Spiral::US35 {
            Spiral::US35::US35_0(v0_1)
        }
        pub fn method155() -> Func1<CancellationToken, Spiral::US35> {
            Func1::new(move |v: CancellationToken| Spiral::closure66((), v))
        }
        pub fn method156(v0_1: CancellationToken) -> Arc<Async<CancellationToken>> {
            getZero()
        }
        pub fn method157(v0_1: bool) -> bool {
            unbox::<bool>(&getZero())
        }
        pub fn method158(v0_1: bool) {
            ();
        }
        pub fn closure67(v0_1: bool, unitVar: ()) {
            if (Spiral::method157(v0_1)) == false {
                Spiral::method158(v0_1);
            };
        }
        pub fn method161(v0_1: LrcPtr<TaskCanceledException>) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v9: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v18: () = {
                Spiral::closure7(v2.clone(), string("ex"), ());
                ()
            };
            let v27: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v32: std::string::String = format!("{:#?}", v0_1);
            let v65: () = {
                Spiral::closure7(v2.clone(), fable_library_rust::String_::fromString(v32), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method160(
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
            let v9: string = Spiral::method161(v8);
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
                let v24: Option<i64> = patternInput.5.clone();
                let v23: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v22: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v21: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v20: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v19: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method160(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method37(),
                    v0_1,
                ))
            };
        }
        pub fn method159(
            v0_1: bool,
            v1_1: LrcPtr<ConcurrentStack_1<string>>,
            v2: CancellationToken,
        ) -> Arc<Async<i32>> {
            getZero()
        }
        pub fn method163(v0_1: i32, v1_1: i32) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v45: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("output_length"), ());
                ()
            };
            let v62: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method162(
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
            let v10: string = Spiral::method163(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options_async"),
                v10
            ))
        }
        pub fn closure69(v0_1: i32, v1_1: string, unitVar: ()) {
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method162(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method12(),
                    v0_1,
                    length(v1_1),
                ))
            };
        }
        pub fn method146(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
        ) -> Arc<Async<(i32, string)>> {
            getZero()
        }
        pub fn method145(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
        ) -> Arc<Async<(i32, string)>> {
            Spiral::method146(v0_1, v1_1, v2, v3, v4, v5, v6)
        }
        pub fn method89(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
        ) -> (i32, string) {
            let v9: Spiral::US17 = Spiral::method91(Spiral::method90(
                v0_1.clone(),
                v1_1.clone(),
                v2.clone(),
                v3.clone(),
                v4.clone(),
                v5,
                v6.clone(),
            ));
            let patternInput: (string, Spiral::US5) = match &v9 {
                Spiral::US17::US17_0(v9_0_0, v9_0_1) => (v9_0_0.clone(), v9_0_1.clone()),
                Spiral::US17::US17_1(v9_1_0) => panic!(
                    "{}",
                    concat(new_array(&[
                        string("resultm.get / Result value was Error: "),
                        v9_1_0.clone()
                    ])),
                ),
            };
            let v21: Spiral::US5 = patternInput.1.clone();
            let v20: string = patternInput.0.clone();
            let v26: Spiral::US25 = Spiral::method105(match &v21 {
                Spiral::US5::US5_0(v21_0_0) => match &v21 {
                    Spiral::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                _ => string(""),
            });
            let v34: Array<string> = match &v26 {
                Spiral::US25::US25_0(v26_0_0) => v26_0_0.clone(),
                Spiral::US25::US25_1(v26_1_0) => panic!(
                    "{}",
                    concat(new_array(&[
                        string("resultm.get / Result value was Error: "),
                        v26_1_0.clone()
                    ])),
                ),
            };
            let v36: Vec<string> = v34.to_vec();
            let v38: bool = true;
            let _vec_map: Vec<_> = v36
                .into_iter()
                .map(|x| {
                    //;
                    let v40: string = x;
                    let v43: &str = &*v40;
                    let v67: std::string::String = String::from(v43);
                    let v90: bool = true;
                    v67
                })
                .collect::<Vec<_>>();
            let v92: Vec<std::string::String> = _vec_map;
            let v95: () = {
                Spiral::closure42(
                    v0_1,
                    v1_1,
                    v2.clone(),
                    v3,
                    v4.clone(),
                    v5,
                    v6.clone(),
                    v20.clone(),
                    v92.clone(),
                    (),
                );
                ()
            };
            let _capture_v138: MutCell<Option<LrcPtr<(i32, string)>>> =
                MutCell::new(None::<LrcPtr<(i32, string)>>);
            {
                let x_5: LrcPtr<(i32, string)> = (Func0::new({
                    let v2 = v2.clone();
                    let v20 = v20.clone();
                    let v4 = v4.clone();
                    let v5 = v5.clone();
                    let v6 = v6.clone();
                    let v92 = v92.clone();
                    move || {
                        let v140: std::process::Command = std::process::Command::new(&*v20.clone());
                        let v142: bool = true;
                        let mut v140 = v140;
                        let v144: bool = true;
                        std::process::Command::args(&mut v140, &*v92.clone());
                        let v146: std::process::Command = v140;
                        let v148: std::process::Stdio = std::process::Stdio::piped();
                        let v150: bool = true;
                        let mut v146 = v146;
                        let v152: bool = true;
                        std::process::Command::stdout(&mut v146, std::process::Stdio::piped());
                        let v154: std::process::Command = v146;
                        let v156: std::process::Stdio = std::process::Stdio::piped();
                        let v158: bool = true;
                        let mut v154 = v154;
                        let v160: bool = true;
                        std::process::Command::stderr(&mut v154, std::process::Stdio::piped());
                        let v162: std::process::Command = v154;
                        let v164: std::process::Stdio = std::process::Stdio::piped();
                        let v166: bool = true;
                        let mut v162 = v162;
                        let v168: bool = true;
                        std::process::Command::stdin(&mut v162, std::process::Stdio::piped());
                        let v170: std::process::Command = v162;
                        let v184: Spiral::US5 =
                            defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6.clone()));
                        let v198: std::process::Command = match &v184 {
                            Spiral::US5::US5_0(v184_0_0) => {
                                let v190: bool = true;
                                let mut v170 = v170;
                                let v192: bool = true;
                                std::process::Command::current_dir(
                                    &mut v170,
                                    &*match &v184 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                );
                                v170
                            }
                            _ => v170,
                        };
                        let v220: std::process::Command = if (get_Count(v2.clone()) as u64) == 0_u64
                        {
                            v198
                        } else {
                            let v202: Vec<(string, string)> = v2.clone().to_vec();
                            let v204: bool = true;
                            let _vec_fold_ = v202.into_iter().fold(v198, |acc, x| {
                                //;
                                let v206: std::process::Command = acc;
                                let patternInput_1: (string, string) = x;
                                let v211: bool = true;
                                let mut v206 = v206;
                                let v213: bool = true;
                                std::process::Command::env(
                                    &mut v206,
                                    &*patternInput_1.0.clone(),
                                    &*patternInput_1.1.clone(),
                                );
                                let v215: std::process::Command = v206;
                                let v217: bool = true;
                                v215
                            });
                            _vec_fold_
                        };
                        let v222: bool = true;
                        let mut v220 = v220;
                        let v224: Result<std::process::Child, std::io::Error> =
                            std::process::Command::spawn(&mut v220);
                        let v225 = Spiral::method67();
                        let v228: Result<std::process::Child, std::string::String> =
                            v224.map_err(|x| v225(x));
                        let v240 = Spiral::method117();
                        let v242: bool = true;
                        let _result_map_ = v228.map(|x| {
                            //;
                            let v248: Option<std::process::Child> = v240(Some(x));
                            let v250: std::sync::Mutex<Option<std::process::Child>> =
                                std::sync::Mutex::new(v248);
                            let v252: std::sync::Arc<
                                std::sync::Mutex<Option<std::process::Child>>,
                            > = std::sync::Arc::new(v250);
                            let v254: bool = true;
                            v252
                        });
                        let v256: Result<
                            std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>,
                            std::string::String,
                        > = _result_map_;
                        let v257 = Spiral::method118();
                        let v258 = Spiral::method119();
                        let v260: Spiral::US27 = match v256 {
                            Ok(x) => v257(x),
                            Err(e) => v258(e),
                        };
                        let patternInput_3: (i32, Spiral::US7, Spiral::US28) = match &v260 {
                            Spiral::US27::US27_0(v260_0_0) => {
                                let v261: std::sync::Arc<
                                    std::sync::Mutex<Option<std::process::Child>>,
                                > = v260_0_0.clone();
                                let v263: bool = true;
                                let _capture = (|| {
                                    //;
                                    let v265: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::Child>>,
                                    > = v261.clone();
                                    let v267: Result<
                                        std::sync::MutexGuard<Option<std::process::Child>>,
                                        std::sync::PoisonError<
                                            std::sync::MutexGuard<Option<std::process::Child>>,
                                        >,
                                    > = v265.lock();
                                    let v282: std::sync::MutexGuard<Option<std::process::Child>> =
                                        Spiral::method122(v267.unwrap());
                                    let v284: bool = true;
                                    let mut v282 = v282;
                                    let v286: &mut Option<std::process::Child> = &mut v282;
                                    let v288: Option<&mut std::process::Child> = v286.as_mut();
                                    let v290: &mut std::process::Child = v288.unwrap();
                                    let v292: &mut Option<std::process::ChildStdout> =
                                        &mut v290.stdout;
                                    let v294: Option<std::process::ChildStdout> =
                                        Option::take(v292);
                                    let v296: std::process::ChildStdout = v294.unwrap();
                                    let v298: bool = true;
                                    v296
                                })();
                                let v300: std::process::ChildStdout = _capture;
                                let v302: bool = true;
                                let _capture = (|| {
                                    //;
                                    let v304: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::Child>>,
                                    > = v261.clone();
                                    let v306: Result<
                                        std::sync::MutexGuard<Option<std::process::Child>>,
                                        std::sync::PoisonError<
                                            std::sync::MutexGuard<Option<std::process::Child>>,
                                        >,
                                    > = v304.lock();
                                    let v321: std::sync::MutexGuard<Option<std::process::Child>> =
                                        Spiral::method122(v306.unwrap());
                                    let v323: bool = true;
                                    let mut v321 = v321;
                                    let v325: &mut Option<std::process::Child> = &mut v321;
                                    let v327: Option<&mut std::process::Child> = v325.as_mut();
                                    let v329: &mut std::process::Child = v327.unwrap();
                                    let v331: &mut Option<std::process::ChildStderr> =
                                        &mut v329.stderr;
                                    let v333: Option<std::process::ChildStderr> =
                                        Option::take(v331);
                                    let v335: std::process::ChildStderr = v333.unwrap();
                                    let v337: bool = true;
                                    v335
                                })();
                                let v339: std::process::ChildStderr = _capture;
                                let v341: bool = true;
                                let _capture = (|| {
                                    //;
                                    let v343: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::Child>>,
                                    > = v261.clone();
                                    let v345: Result<
                                        std::sync::MutexGuard<Option<std::process::Child>>,
                                        std::sync::PoisonError<
                                            std::sync::MutexGuard<Option<std::process::Child>>,
                                        >,
                                    > = v343.lock();
                                    let v360: std::sync::MutexGuard<Option<std::process::Child>> =
                                        Spiral::method122(v345.unwrap());
                                    let v362: bool = true;
                                    let mut v360 = v360;
                                    let v364: &mut Option<std::process::Child> = &mut v360;
                                    let v366: Option<&mut std::process::Child> = v364.as_mut();
                                    let v368: &mut std::process::Child = v366.unwrap();
                                    let v370: &mut Option<std::process::ChildStdin> =
                                        &mut v368.stdin;
                                    let v372: Option<std::process::ChildStdin> = Option::take(v370);
                                    let v374: std::process::ChildStdin = v372.unwrap();
                                    let v379: Option<std::process::ChildStdin> =
                                        (Spiral::method123())(Some(v374));
                                    let v381: std::sync::Mutex<Option<std::process::ChildStdin>> =
                                        std::sync::Mutex::new(v379);
                                    let v383: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::ChildStdin>>,
                                    > = std::sync::Arc::new(v381);
                                    let v385: bool = true;
                                    v383
                                })();
                                let v387: std::sync::Arc<
                                    std::sync::Mutex<Option<std::process::ChildStdin>>,
                                > = _capture;
                                let patternInput_2: (
                                    std::sync::mpsc::Sender<std::string::String>,
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                ) = {
                                    let (sender, receiver) = std::sync::mpsc::channel();
                                    (sender, std::sync::Arc::new(receiver))
                                };
                                let v389: std::sync::mpsc::Sender<std::string::String> =
                                    patternInput_2.0.clone();
                                let v392: std::sync::mpsc::Sender<std::string::String> =
                                    (Spiral::method124())(v389.clone());
                                let v394: std::sync::Mutex<
                                    std::sync::mpsc::Sender<std::string::String>,
                                > = std::sync::Mutex::new(v392);
                                let v396: std::sync::Arc<
                                    std::sync::Mutex<std::sync::mpsc::Sender<std::string::String>>,
                                > = std::sync::Arc::new(v394);
                                let v398: std::sync::mpsc::Sender<std::string::String> =
                                    (Spiral::method125())(v389);
                                let v400: std::sync::Mutex<
                                    std::sync::mpsc::Sender<std::string::String>,
                                > = std::sync::Mutex::new(v398);
                                let v402: std::sync::Arc<
                                    std::sync::Mutex<std::sync::mpsc::Sender<std::string::String>>,
                                > = std::sync::Arc::new(v400);
                                let v404: std::sync::Arc<
                                    std::sync::mpsc::Receiver<std::string::String>,
                                > = (Spiral::method126())(patternInput_2.1.clone());
                                let v406: std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                > = std::sync::Mutex::new(v404);
                                let v408: std::sync::Arc<
                                    std::sync::Mutex<
                                        std::sync::Arc<
                                            std::sync::mpsc::Receiver<std::string::String>,
                                        >,
                                    >,
                                > = std::sync::Arc::new(v406);
                                let v410: bool = true;
                                let __spawn = std::thread::spawn(move || {
                                    //;
                                    let v412: encoding_rs_io::DecodeReaderBytes<
                                        std::process::ChildStdout,
                                        Vec<u8>,
                                    > = encoding_rs_io::DecodeReaderBytesBuilder::new()
                                        .utf8_passthru(true)
                                        .build(v300);
                                    let v414: std::io::BufReader<
                                        encoding_rs_io::DecodeReaderBytes<
                                            std::process::ChildStdout,
                                            Vec<u8>,
                                        >,
                                    > = std::io::BufReader::new(v412);
                                    let v416: std::io::Lines<
                                        std::io::BufReader<
                                            encoding_rs_io::DecodeReaderBytes<
                                                std::process::ChildStdout,
                                                Vec<u8>,
                                            >,
                                        >,
                                    > = std::io::BufRead::lines(v414);
                                    let v418: bool = true;
                                    let mut v416 = v416;
                                    let _iter_try_for_each = v416.try_for_each(|x| {
                                        //;
                                        let v420: Result<std::string::String, std::io::Error> = x;
                                        let v422: std::sync::Arc<
                                            std::sync::Mutex<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                        > = v396.clone();
                                        let v423 = Spiral::method67();
                                        let v426: Result<std::string::String, std::string::String> =
                                            v420.map_err(|x| v423(x));
                                        let v438 = Spiral::method127();
                                        let v439 = Spiral::method128();
                                        let v441: Spiral::US29 = match v426 {
                                            Ok(x) => v438(x),
                                            Err(e) => v439(e),
                                        };
                                        let v636: std::string::String = match &v441 {
                                            Spiral::US29::US29_0(v441_0_0) => {
                                                let v444: string =
                                                    fable_library_rust::String_::fromString(
                                                        v441_0_0.clone(),
                                                    );
                                                let v446: &encoding_rs::Encoding =
                                                    encoding_rs::UTF_8;
                                                let v448: std::borrow::Cow<[u8]> =
                                                    v446.encode(&*v444).0;
                                                let v450: &[u8] = v448.as_ref();
                                                let v452: Result<&str, std::str::Utf8Error> =
                                                    std::str::from_utf8(v450);
                                                let v455: &str = v452.unwrap();
                                                let v486: std::string::String = String::from(v455);
                                                let v493: string = concat(new_array(&[
                                                    string("> "),
                                                    fable_library_rust::String_::fromString(
                                                        v486.clone(),
                                                    ),
                                                ]));
                                                if v5 {
                                                    let v496: () = {
                                                        Spiral::closure53(v493.clone(), ());
                                                        ()
                                                    };
                                                    ()
                                                } else {
                                                    let v541: () = {
                                                        Spiral::closure10(v493, ());
                                                        ()
                                                    };
                                                    ()
                                                }
                                                v486
                                            }
                                            Spiral::US29::US29_1(v441_1_0) => {
                                                let v543: std::string::String = v441_1_0.clone();
                                                let v546: () = {
                                                    Spiral::closure52(v5, v543.clone(), ());
                                                    ()
                                                };
                                                let v586: string =
                                                    sprintf!("\u{001b}[4;7m{}\u{001b}[0m", v543);
                                                let v589: &str = &*v586;
                                                String::from(v589)
                                            }
                                        };
                                        let v638: std::sync::Arc<
                                            std::sync::Mutex<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                        > = v422;
                                        let v640: Result<
                                            std::sync::MutexGuard<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                            std::sync::PoisonError<
                                                std::sync::MutexGuard<
                                                    std::sync::mpsc::Sender<std::string::String>,
                                                >,
                                            >,
                                        > = v638.lock();
                                        let v643: std::sync::MutexGuard<
                                            std::sync::mpsc::Sender<std::string::String>,
                                        > = v640.unwrap();
                                        let v656: &std::sync::mpsc::Sender<std::string::String> =
                                            &v643;
                                        let v658: Result<
                                            (),
                                            std::sync::mpsc::SendError<std::string::String>,
                                        > = v656.send(v636);
                                        let v659 = Spiral::method133();
                                        let v662: Result<(), std::string::String> =
                                            v658.map_err(|x| v659(x));
                                        let v675: _ = v662;
                                        let v677: bool = true;
                                        v675
                                    }); //;
                                    let v680: Result<(), string> =
                                        Spiral::method134(_iter_try_for_each.map_err(|x| x.into()));
                                    let v683: string = string("}");
                                    let v688: bool = true;
                                    let _fix_closure_v685 = v680;
                                    let v695: string = append(
                                        (append(
                                            (append(
                                                (append(
                                                    string("true; _fix_closure_v685 "),
                                                    (v683),
                                                )),
                                                string("); "),
                                            )),
                                            string(""),
                                        )),
                                        string(" // rust.fix_closure\'"),
                                    );
                                    let v696: bool = true;
                                    _fix_closure_v685
                                }); // rust.fix_closure';
                                let v698: std::thread::JoinHandle<Result<(), string>> = __spawn;
                                let v700: bool = true;
                                let __spawn = std::thread::spawn(move || {
                                    //;
                                    let v702: encoding_rs_io::DecodeReaderBytes<
                                        std::process::ChildStderr,
                                        Vec<u8>,
                                    > = encoding_rs_io::DecodeReaderBytesBuilder::new()
                                        .utf8_passthru(true)
                                        .build(v339);
                                    let v704: std::io::BufReader<
                                        encoding_rs_io::DecodeReaderBytes<
                                            std::process::ChildStderr,
                                            Vec<u8>,
                                        >,
                                    > = std::io::BufReader::new(v702);
                                    let v706: std::io::Lines<
                                        std::io::BufReader<
                                            encoding_rs_io::DecodeReaderBytes<
                                                std::process::ChildStderr,
                                                Vec<u8>,
                                            >,
                                        >,
                                    > = std::io::BufRead::lines(v704);
                                    let v708: bool = true;
                                    let mut v706 = v706;
                                    let _iter_try_for_each = v706.try_for_each(|x| {
                                        //;
                                        let v710: Result<std::string::String, std::io::Error> = x;
                                        let v712: std::sync::Arc<
                                            std::sync::Mutex<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                        > = v402.clone();
                                        let v713 = Spiral::method67();
                                        let v716: Result<std::string::String, std::string::String> =
                                            v710.map_err(|x| v713(x));
                                        let v728 = Spiral::method127();
                                        let v729 = Spiral::method128();
                                        let v731: Spiral::US29 = match v716 {
                                            Ok(x) => v728(x),
                                            Err(e) => v729(e),
                                        };
                                        let v974: std::string::String = match &v731 {
                                            Spiral::US29::US29_0(v731_0_0) => {
                                                let v734: string =
                                                    fable_library_rust::String_::fromString(
                                                        v731_0_0.clone(),
                                                    );
                                                let v736: &encoding_rs::Encoding =
                                                    encoding_rs::UTF_8;
                                                let v738: std::borrow::Cow<[u8]> =
                                                    v736.encode(&*v734).0;
                                                let v740: &[u8] = v738.as_ref();
                                                let v742: Result<&str, std::str::Utf8Error> =
                                                    std::str::from_utf8(v740);
                                                let v745: &str = v742.unwrap();
                                                let v776: std::string::String = String::from(v745);
                                                let v783: string = concat(new_array(&[
                                                    string("! "),
                                                    fable_library_rust::String_::fromString(
                                                        v776.clone(),
                                                    ),
                                                ]));
                                                if v5 {
                                                    let v786: () = {
                                                        Spiral::closure53(v783.clone(), ());
                                                        ()
                                                    };
                                                    ()
                                                } else {
                                                    let v830: () = {
                                                        Spiral::closure10(v783, ());
                                                        ()
                                                    };
                                                    ()
                                                }
                                                {
                                                    let v832: string = sprintf!(
                                                        "\u{001b}[4;7m{}\u{001b}[0m",
                                                        v776
                                                    );
                                                    let v835: &str = &*v832;
                                                    String::from(v835)
                                                }
                                            }
                                            Spiral::US29::US29_1(v731_1_0) => {
                                                let v881: std::string::String = v731_1_0.clone();
                                                let v884: () = {
                                                    Spiral::closure52(v5, v881.clone(), ());
                                                    ()
                                                };
                                                let v924: string =
                                                    sprintf!("\u{001b}[4;7m{}\u{001b}[0m", v881);
                                                let v927: &str = &*v924;
                                                String::from(v927)
                                            }
                                        };
                                        let v976: std::sync::Arc<
                                            std::sync::Mutex<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                        > = v712;
                                        let v978: Result<
                                            std::sync::MutexGuard<
                                                std::sync::mpsc::Sender<std::string::String>,
                                            >,
                                            std::sync::PoisonError<
                                                std::sync::MutexGuard<
                                                    std::sync::mpsc::Sender<std::string::String>,
                                                >,
                                            >,
                                        > = v976.lock();
                                        let v981: std::sync::MutexGuard<
                                            std::sync::mpsc::Sender<std::string::String>,
                                        > = v978.unwrap();
                                        let v994: &std::sync::mpsc::Sender<std::string::String> =
                                            &v981;
                                        let v996: Result<
                                            (),
                                            std::sync::mpsc::SendError<std::string::String>,
                                        > = v994.send(v974);
                                        let v997 = Spiral::method133();
                                        let v1000: Result<(), std::string::String> =
                                            v996.map_err(|x| v997(x));
                                        let v1013: _ = v1000;
                                        let v1015: bool = true;
                                        v1013
                                    }); //;
                                    let v1018: Result<(), string> =
                                        Spiral::method134(_iter_try_for_each.map_err(|x| x.into()));
                                    let v1019: string = string("}");
                                    let v1024: bool = true;
                                    let _fix_closure_v1021 = v1018;
                                    let v1031: string = append(
                                        (append(
                                            (append(
                                                (append(
                                                    string("true; _fix_closure_v1021 "),
                                                    (v1019),
                                                )),
                                                string("); "),
                                            )),
                                            string(""),
                                        )),
                                        string(" // rust.fix_closure\'"),
                                    );
                                    let v1032: bool = true;
                                    _fix_closure_v1021
                                }); // rust.fix_closure';
                                let v1034: std::thread::JoinHandle<Result<(), string>> = __spawn;
                                let v1048: Spiral::US30 = defaultValue(
                                    Spiral::US30::US30_1,
                                    map(Spiral::method135(), v4.clone()),
                                );
                                match &v1048 {
                                    Spiral::US30::US30_0(v1048_0_0) => {
                                        let v1054: std::sync::Arc<
                                            std::sync::Mutex<Option<std::process::ChildStdin>>,
                                        > = v387.clone();
                                        let v1056: Result<
                                            std::sync::MutexGuard<Option<std::process::ChildStdin>>,
                                            std::sync::PoisonError<
                                                std::sync::MutexGuard<
                                                    Option<std::process::ChildStdin>,
                                                >,
                                            >,
                                        > = v1054.lock();
                                        let v1071: std::sync::MutexGuard<
                                            Option<std::process::ChildStdin>,
                                        > = Spiral::method136(v1056.unwrap());
                                        let v1073: bool = true;
                                        let mut v1071 = v1071;
                                        let v1075: &mut Option<std::process::ChildStdin> =
                                            &mut v1071;
                                        let v1077: Option<std::process::ChildStdin> =
                                            Option::take(v1075);
                                        let v1079: bool = true;
                                        let _optionm_map_ = v1077.map(|x| {
                                            //;
                                            let v1081: std::process::ChildStdin = x;
                                            let v1083: std::sync::Mutex<std::process::ChildStdin> =
                                                std::sync::Mutex::new(v1081);
                                            let v1085: std::sync::Arc<
                                                std::sync::Mutex<std::process::ChildStdin>,
                                            > = std::sync::Arc::new(v1083);
                                            let v1087: bool = true;
                                            v1085
                                        });
                                        let v1089: Option<
                                            std::sync::Arc<
                                                std::sync::Mutex<std::process::ChildStdin>,
                                            >,
                                        > = _optionm_map_;
                                        let v1103: Spiral::US31 = defaultValue(
                                            Spiral::US31::US31_1,
                                            map(Spiral::method137(), v1089),
                                        );
                                        match &v1103 {
                                            Spiral::US31::US31_0(v1103_0_0) => {
                                                let v1107: std::sync::Arc<
                                                    std::sync::Mutex<std::process::ChildStdin>,
                                                > = match &v1103 {
                                                    Spiral::US31::US31_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone();
                                                (match &v1048 {
                                                    Spiral::US30::US30_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                })(
                                                    v1107.clone()
                                                );
                                                {
                                                    let v1109: std::sync::Arc<
                                                        std::sync::Mutex<std::process::ChildStdin>,
                                                    > = v1107;
                                                    let v1111: Result<
                                                        std::sync::MutexGuard<
                                                            std::process::ChildStdin,
                                                        >,
                                                        std::sync::PoisonError<
                                                            std::sync::MutexGuard<
                                                                std::process::ChildStdin,
                                                            >,
                                                        >,
                                                    > = v1109.lock();
                                                    let v1126: std::sync::MutexGuard<
                                                        std::process::ChildStdin,
                                                    > = Spiral::method138(v1111.unwrap());
                                                    let v1128: bool = true;
                                                    let mut v1126 = v1126;
                                                    let v1130: bool = true;
                                                    std::io::Write::flush(&mut *v1126).unwrap();
                                                    ()
                                                }
                                            }
                                            _ => (),
                                        }
                                    }
                                    _ => (),
                                }
                                {
                                    let v1132: std::sync::Arc<
                                        std::sync::Mutex<Option<std::process::Child>>,
                                    > = v261;
                                    let v1134: Result<
                                        std::sync::MutexGuard<Option<std::process::Child>>,
                                        std::sync::PoisonError<
                                            std::sync::MutexGuard<Option<std::process::Child>>,
                                        >,
                                    > = v1132.lock();
                                    let v1149: std::sync::MutexGuard<Option<std::process::Child>> =
                                        Spiral::method122(v1134.unwrap());
                                    let v1151: bool = true;
                                    let mut v1149 = v1149;
                                    let v1153: &mut Option<std::process::Child> = &mut v1149;
                                    let v1155: Option<std::process::Child> = Option::take(v1153);
                                    let v1157: std::process::Child = v1155.unwrap();
                                    let v1159: Result<std::process::Output, std::io::Error> =
                                        v1157.wait_with_output();
                                    let v1160 = Spiral::method67();
                                    let v1172: Result<std::process::Output, std::string::String> =
                                        v1159.map_err(|x| v1160(x));
                                    let v1182: string = string("vec![v698, v1034]");
                                    let v1183: Vec<std::thread::JoinHandle<Result<(), string>>> =
                                        vec![v698, v1034];
                                    let v1185: bool = true;
                                    v1183.into_iter().for_each(|x| {
                                        //;
                                        let v1187: std::thread::JoinHandle<Result<(), string>> = x;
                                        let v1189: Result<
                                            Result<(), string>,
                                            Box<dyn core::any::Any + 'static + Send>,
                                        > = std::thread::JoinHandle::join(v1187);
                                        let v1192: Result<(), string> = v1189.unwrap();
                                        v1192.unwrap();
                                        {
                                            let v1209: bool = true;
                                            let v1211: bool = true;
                                        }
                                    });
                                    {
                                        //;
                                        let v1212 = Spiral::method139();
                                        let v1213 = Spiral::method140();
                                        let v1214: Spiral::US32 = match &v1172 {
                                            Err(v1172_1_0) => v1213(v1172_1_0.clone()),
                                            Ok(v1172_0_0) => v1212(v1172_0_0.clone()),
                                        };
                                        match &v1214 {
                                            Spiral::US32::US32_0(v1214_0_0) => {
                                                let v1217: std::process::ExitStatus =
                                                    v1214_0_0.clone().status;
                                                let v1219: Option<i32> = v1217.code();
                                                let v1233: Spiral::US33 = defaultValue(
                                                    Spiral::US33::US33_1,
                                                    map(Spiral::method142(), v1219),
                                                );
                                                match &v1233 {
                                                    Spiral::US33::US33_0(v1233_0_0) => (
                                                        match &v1233 {
                                                            Spiral::US33::US33_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        },
                                                        Spiral::US7::US7_1,
                                                        Spiral::US28::US28_0(v408.clone()),
                                                    ),
                                                    _ => {
                                                        let v1243:
                                                                                        &str =
                                                                                    &*string("runtime.execute_with_options / exit_code=None");
                                                        (
                                                            -1_i32,
                                                            Spiral::US7::US7_0(String::from(v1243)),
                                                            Spiral::US28::US28_0(v408.clone()),
                                                        )
                                                    }
                                                }
                                            }
                                            Spiral::US32::US32_1(v1214_1_0) => {
                                                let v1297: std::string::String = v1214_1_0.clone();
                                                let v1300: () = {
                                                    Spiral::closure59(v1297.clone(), ());
                                                    ()
                                                };
                                                (
                                                    -2_i32,
                                                    Spiral::US7::US7_0(v1297),
                                                    Spiral::US28::US28_1,
                                                )
                                            }
                                        }
                                    }
                                }
                            }
                            Spiral::US27::US27_1(v260_1_0) => {
                                let v1348: std::string::String = v260_1_0.clone();
                                let v1351: () = {
                                    Spiral::closure46(v1348.clone(), ());
                                    ()
                                };
                                (-1_i32, Spiral::US7::US7_0(v1348), Spiral::US28::US28_1)
                            }
                        };
                        let v1398: Spiral::US28 = patternInput_3.2.clone();
                        let v1397: Spiral::US7 = patternInput_3.1.clone();
                        let v1396: i32 = patternInput_3.0.clone();
                        let v1405: Option<
                            std::sync::Arc<
                                std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                >,
                            >,
                        > = match &v1398 {
                            Spiral::US28::US28_0(v1398_0_0) => Some(
                                match &v1398 {
                                    Spiral::US28::US28_0(x) => x.clone(),
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
                        let v1407: bool = true;
                        let _optionm_map_ = v1405.map(|x| {
                            //;
                            let v1409: std::sync::Arc<
                                std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                >,
                            > = x;
                            let v1411: std::sync::Arc<
                                std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                >,
                            > = v1409;
                            let v1413: Result<
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
                            > = v1411.lock();
                            let v1416: std::sync::MutexGuard<
                                std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                            > = v1413.unwrap();
                            let v1429 = v1416.iter();
                            let v1431: Vec<std::string::String> = v1429.collect::<Vec<_>>();
                            let v1433: bool = true;
                            let _vec_map: Vec<_> = v1431
                                .into_iter()
                                .map(|x| {
                                    //;
                                    let v1435: std::string::String = x;
                                    let v1437: string =
                                        fable_library_rust::String_::fromString(v1435);
                                    let v1439: bool = true;
                                    v1437
                                })
                                .collect::<Vec<_>>();
                            let v1441: Vec<string> = _vec_map;
                            let v1444: LrcPtr<dyn IEnumerable_1<string>> = ofArray_1(
                                fable_library_rust::NativeArray_::array_from(v1441.clone()),
                            );
                            let v1450: string = join(Spiral::method63(), toArray_1(v1444));
                            let v1455: bool = true;
                            v1450
                        });
                        let v1457: Option<string> = _optionm_map_;
                        let v1464: Spiral::US5 = match &v1397 {
                            Spiral::US7::US7_0(v1397_0_0) => {
                                Spiral::US5::US5_0(fable_library_rust::String_::fromString(
                                    match &v1397 {
                                        Spiral::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ))
                            }
                            _ => Spiral::US5::US5_1,
                        };
                        let v1469: string = defaultValue(
                            match &v1464 {
                                Spiral::US5::US5_0(v1464_0_0) => match &v1464 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => string(""),
                            },
                            v1457,
                        );
                        let v1474: () = {
                            Spiral::closure61(v1396, v1469.clone(), ());
                            ()
                        };
                        LrcPtr::new((v1396, v1469))
                    }
                }))();
                _capture_v138.set(Some(x_5))
            }
            {
                let v1516: LrcPtr<(i32, string)> = match &_capture_v138.get().clone() {
                    None => panic!("{}", string("base.capture / _capture_v138=None"),),
                    Some(_capture_v138_0_0) => _capture_v138_0_0.clone(),
                };
                let _run_target_args__v7: (i32, string) = (v1516.0.clone(), v1516.1.clone());
                (
                    _run_target_args__v7.0.clone(),
                    _run_target_args__v7.1.clone(),
                )
            }
        }
        pub fn method165(v0_1: Spiral::US10, v1_1: i32, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v5.clone(), string("env"), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v41: () = {
                Spiral::closure7(v5.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v59: () = {
                Spiral::closure7(v5.clone(), string("exit_code"), ());
                ()
            };
            let v67: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v75: () = {
                Spiral::closure7(v5.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v83: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v92: () = {
                Spiral::closure7(v5.clone(), string("run_result"), ());
                ()
            };
            let v100: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v108: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v116: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v125: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v133: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v141: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v150: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
        }
        pub fn method164(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: Spiral::US10,
            v9: i32,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method165(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_cuda / env install error"),
                v12
            ))
        }
        pub fn closure70(v0_1: Spiral::US10, v1_1: string, v2: string, v3: i32, unitVar: ()) {
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
                let v27: Option<i64> = patternInput.5.clone();
                let v26: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v25: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v24: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v23: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v22: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method164(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method70(),
                    v0_1,
                    v3,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure71(unitVar: (), v0_1: string) -> Spiral::US5 {
            Spiral::US5::US5_0(v0_1)
        }
        pub fn closure72(v0_1: string, unitVar: ()) -> string {
            let v5: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method63(), toArray_1(v5))
        }
        pub fn method167(v0_1: LrcPtr<Exception>, v1_1: string, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v5.clone(), string("ex"), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v35: std::string::String = format!("{:#?}", v0_1);
            let v68: () = {
                Spiral::closure7(v5.clone(), fable_library_rust::String_::fromString(v35), ());
                ()
            };
            let v77: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v86: () = {
                Spiral::closure7(v5.clone(), string("run_result"), ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v102: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v110: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v119: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v127: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v135: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v143: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v152: () = {
                Spiral::closure7(v5.clone(), string("external_command"), ());
                ()
            };
            let v160: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v168: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v177: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
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
            v8: LrcPtr<Exception>,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method167(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_cuda / Exception"),
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
                let v27: Option<i64> = patternInput.5.clone();
                let v26: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v25: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v24: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v23: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v22: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method166(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method70(),
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
        pub fn method169(v0_1: i32, v1_1: string, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v5.clone(), string("exit_code"), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v38: () = {
                Spiral::closure7(v5.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v47: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v56: () = {
                Spiral::closure7(v5.clone(), string("run_result"), ());
                ()
            };
            let v64: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v72: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v80: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v89: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v97: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v105: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v113: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v122: () = {
                Spiral::closure7(v5.clone(), string("external_command"), ());
                ()
            };
            let v130: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v138: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v147: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
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
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method169(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_cuda / error"),
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
                let v27: Option<i64> = patternInput.5.clone();
                let v26: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v25: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v24: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v23: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v22: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method168(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method70(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
        }
        pub fn method170(
            v0_1: Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>>,
        ) -> Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>> {
            v0_1
        }
        pub fn closure76(
            v0_1: Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>>,
            _arg: (string, string),
        ) -> LrcPtr<(std::string::String, std::string::String)> {
            let v3: Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>> =
                Spiral::method170(v0_1);
            (move |x| v3(x))((_arg.0.clone(), _arg.1.clone()))
        }
        pub fn method171() -> string {
            string("fs-path")
        }
        pub fn method172() -> string {
            string("command")
        }
        pub fn method173() -> string {
            string("path")
        }
        pub fn method178(v0_1: i32, v1_1: LrcPtr<Spiral::Mut6>) -> bool {
            (v1_1.l0.get().clone()) < (v0_1)
        }
        pub fn method179() -> char {
            std::path::MAIN_SEPARATOR
        }
        pub fn method180(v0_1: string) -> string {
            v0_1
        }
        pub fn method177(v0_1: string) -> string {
            let v4: &str = &*v0_1.clone();
            let v28: std::string::String = String::from(v4);
            let v52: std::path::PathBuf = std::path::PathBuf::from(v28);
            if (v52.exists()) == false {
                let v77: string = Spiral::method28();
                let v81: Array<string> = split(
                    Spiral::method40(Spiral::method30(v77.clone(), v0_1.clone())),
                    string("/"),
                    -1_i32,
                    0_i32,
                );
                let v85: i32 = get_Count(v81.clone());
                let v86: LrcPtr<Spiral::Mut6> = LrcPtr::new(Spiral::Mut6 {
                    l0: MutCell::new(0_i32),
                    l1: MutCell::new(0_i32),
                    l2: MutCell::new(new_empty::<string>()),
                });
                while Spiral::method178(v85, v86.clone()) {
                    let v88: i32 = v86.l0.get().clone();
                    let v91: i32 = ((v88.wrapping_neg()) + (v85)) - 1_i32;
                    let matchValue: i32 = v86.l1.get().clone();
                    let v93: Array<string> = v86.l2.get().clone();
                    let v92: i32 = matchValue;
                    let v94: string = v81[v91].clone();
                    let patternInput_1: (i32, Array<string>) = if string("..") == (v94.clone()) {
                        ((v92) + 1_i32, v93.clone())
                    } else {
                        if string(".") == (v94.clone()) {
                            (v92, v93.clone())
                        } else {
                            if 0_i32 == (v92) {
                                if endsWith3(v94.clone(), string(":"), false) {
                                    let v104: Array<string> = new_array(&[sprintf!(
                                        "{}:",
                                        getCharAt(v77.clone(), 0_i32)
                                    )]);
                                    let v105: i32 = get_Count(v104.clone());
                                    let v107: i32 = (v105) + (get_Count(v93.clone()));
                                    let v108: Array<string> = new_init(&string(""), v107);
                                    let v109: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method93(v107, v109.clone()) {
                                        let v111: i32 = v109.l0.get().clone();
                                        let v116: string = if (v111) < (v105) {
                                            v104[v111].clone()
                                        } else {
                                            let v114: i32 = (v111) - (v105);
                                            v93[v114].clone()
                                        };
                                        v108.get_mut()[v111 as usize] = v116;
                                        {
                                            let v117: i32 = (v111) + 1_i32;
                                            v109.l0.set(v117);
                                            ()
                                        }
                                    }
                                    (0_i32, v108.clone())
                                } else {
                                    let v118: Array<string> = new_array(&[v94]);
                                    let v119: i32 = get_Count(v118.clone());
                                    let v121: i32 = (v119) + (get_Count(v93.clone()));
                                    let v122: Array<string> = new_init(&string(""), v121);
                                    let v123: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method93(v121, v123.clone()) {
                                        let v125: i32 = v123.l0.get().clone();
                                        let v130: string = if (v125) < (v119) {
                                            v118[v125].clone()
                                        } else {
                                            let v128: i32 = (v125) - (v119);
                                            v93[v128].clone()
                                        };
                                        v122.get_mut()[v125 as usize] = v130;
                                        {
                                            let v131: i32 = (v125) + 1_i32;
                                            v123.l0.set(v131);
                                            ()
                                        }
                                    }
                                    (0_i32, v122.clone())
                                }
                            } else {
                                ((v92) - 1_i32, v93.clone())
                            }
                        }
                    };
                    let v141: i32 = (v88) + 1_i32;
                    v86.l0.set(v141);
                    v86.l1.set(patternInput_1.0.clone());
                    v86.l2.set(patternInput_1.1.clone());
                    ()
                }
                {
                    let matchValue_2: i32 = v86.l1.get().clone();
                    let v143: Array<string> = v86.l2.get().clone();
                    let _let__v144: LrcPtr<dyn IEnumerable_1<string>> = delay(Func0::new({
                        let v143 = v143.clone();
                        move || {
                            map_1(
                                Func1::new({
                                    let v143 = v143.clone();
                                    move |i: i32| v143[i].clone()
                                }),
                                rangeNumeric(0_i32, 1_i32, (get_Count(v143.clone())) - 1_i32),
                            )
                        }
                    }));
                    let v155: string = ofChar(Spiral::method179());
                    join(
                        if (v155.clone()) == string("\n") {
                            Spiral::method180(v155.clone())
                        } else {
                            v155
                        },
                        toArray_1(_let__v144),
                    )
                }
            } else {
                let v167: Result<std::path::PathBuf, std::io::Error> =
                    std::fs::canonicalize(&*v0_1);
                let v170: std::path::PathBuf = v167.unwrap();
                let v184: std::path::Display = v170.display();
                let v208: std::string::String = format!("{}", v184);
                fable_library_rust::String_::fromString(v208)
            }
        }
        pub fn method176(v0_1: string) -> string {
            Spiral::method40(Spiral::method177(v0_1))
        }
        pub fn method175(v0_1: string) -> string {
            Spiral::method176(Spiral::method30(Spiral::method28(), v0_1))
        }
        pub fn closure77(unitVar: (), v0_1: std::string::String) -> string {
            Spiral::method175(fable_library_rust::String_::fromString(v0_1))
        }
        pub fn method174() -> Func1<std::string::String, string> {
            Func1::new(move |v: std::string::String| Spiral::closure77((), v))
        }
        pub fn method181() -> string {
            string("retries")
        }
        pub fn method182() -> string {
            string("working-directory")
        }
        pub fn method185(v0_1: i32, v1_1: string, v2: string) -> string {
            let v4: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v4.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral::closure7(v4.clone(), string("exit_code"), ());
                ()
            };
            let v29: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v37: () = {
                Spiral::closure7(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v46: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v55: () = {
                Spiral::closure7(v4.clone(), string("repl_result"), ());
                ()
            };
            let v63: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v71: () = {
                Spiral::closure7(v4.clone(), v1_1, ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v4.clone(), string("retry"), ());
                ()
            };
            let v96: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v104: () = {
                Spiral::closure7(v4.clone(), v2, ());
                ()
            };
            let v113: () = {
                Spiral::closure7(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
        }
        pub fn method184(
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
            let v11: string = Spiral::method185(v8, v9, v10);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / repl error"),
                v11
            ))
        }
        pub fn closure78(v0_1: u8, v1_1: u8, v2: string, v3: i32, unitVar: ()) {
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
                let v27: Option<i64> = patternInput.5.clone();
                let v26: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v25: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v24: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v23: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v22: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method184(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method12(),
                    v3,
                    v2,
                    sprintf!("{}/{}", v1_1, v0_1),
                ))
            };
        }
        pub fn method183(v0_1: Spiral::US5, v1_1: u8, v2: string, v3: u8) -> (i32, string) {
            let v0_1: MutCell<Spiral::US5> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<u8> = MutCell::new(v1_1);
            let v2: MutCell<string> = MutCell::new(v2.clone());
            let v3: MutCell<u8> = MutCell::new(v3);
            '_method183: loop {
                break '_method183 ({
                    let patternInput: (i32, string) = Spiral::method89(
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
                    let v24: string = patternInput.1.clone();
                    let v23: i32 = patternInput.0.clone();
                    if if (v23) == 0_i32 {
                        true
                    } else {
                        (v3.get().clone()) >= (v1_1.get().clone())
                    } {
                        (v23, v24.clone())
                    } else {
                        let v30: () = {
                            Spiral::closure78(v1_1.get().clone(), v3.get().clone(), v24, v23, ());
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
                            continue '_method183;
                        }
                    }
                });
            }
        }
        pub fn method187(v0_1: i32, v1_1: i32) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v45: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("jupyter_result_length"), ());
                ()
            };
            let v62: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method186(
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
            let v10: string = Spiral::method187(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / dib / jupyter nbconvert"),
                v10
            ))
        }
        pub fn closure79(v0_1: string, v1_1: i32, unitVar: ()) {
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method186(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method12(),
                    v1_1,
                    length(v0_1),
                ))
            };
        }
        pub fn method189(v0_1: i32, v1_1: i32) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v45: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("pwsh_replace_html_result_length"), ());
                ()
            };
            let v62: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method188(
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
            let v10: string = Spiral::method189(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / dib / html cell ids"),
                v10
            ))
        }
        pub fn closure80(v0_1: string, v1_1: i32, unitVar: ()) {
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method188(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method12(),
                    v1_1,
                    length(v0_1),
                ))
            };
        }
        pub fn method191(v0_1: i32, v1_1: i32) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v45: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("result_length"), ());
                ()
            };
            let v62: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method190(
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
            let v10: string = Spiral::method191(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / dib"),
                v10
            ))
        }
        pub fn closure81(v0_1: string, v1_1: i32, unitVar: ()) {
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method190(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method12(),
                    v1_1,
                    length(v0_1),
                ))
            };
        }
        pub fn method192() -> string {
            string("cleanup")
        }
        pub fn method193() -> string {
            string("wasm")
        }
        pub fn method194() -> string {
            string("contract")
        }
        pub fn method195(v0_1: string, v1_1: string, v2: Spiral::US36) -> string {
            let v4: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v4.clone(), string("{ "), ());
                ()
            };
            let v20: () = {
                Spiral::closure7(v4.clone(), string("extension"), ());
                ()
            };
            let v29: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v37: () = {
                Spiral::closure7(v4.clone(), v0_1, ());
                ()
            };
            let v46: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v55: () = {
                Spiral::closure7(v4.clone(), string("code"), ());
                ()
            };
            let v63: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v71: () = {
                Spiral::closure7(v4.clone(), v1_1, ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v4.clone(), string("runtime"), ());
                ()
            };
            let v96: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v107: () = {
                Spiral::closure7(v4.clone(), sprintf!("{:?}", v2), ());
                ()
            };
            let v116: () = {
                Spiral::closure7(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
        }
        pub fn method197() -> string {
            string("")
        }
        pub fn method198() -> string {
            string("")
        }
        pub fn method196(v0_1: string) -> string {
            let v5: Array<u8> = {
                let _arg: LrcPtr<dyn Encoding> = get_UTF8();
                _arg.getBytes(v0_1)
            };
            let v7: Vec<u8> = v5.to_vec();
            let v9: std::io::Cursor<Vec<u8>> = std::io::Cursor::new(v7);
            let v11: std::io::BufReader<std::io::Cursor<Vec<u8>>> = std::io::BufReader::new(v9);
            let v13: bool = true;
            let mut v11 = v11;
            let result: sha2::Sha256 = sha2::Digest::new();
            {
                let v16: sha2::Sha256 = result;
                let v18: bool = true;
                let mut v16 = v16;
                let v19: usize = 0_i32 as usize;
                let v23: _ = [0_u8; 1024];
                let v25: bool = true;
                loop {
                    // rust.loop;
                    let v27: bool = true;
                    let mut v23 = v23;
                    let v29: Result<usize, std::io::Error> =
                        std::io::Read::read(&mut v11, &mut v23);
                    let v41: usize = v29.unwrap();
                    if (v41) == (v19) {
                        let v48: bool = true;
                        break;
                        ()
                    }
                    {
                        let v49: usize = v41;
                        let v64: &_ = if (v49) == (v23.len()) {
                            &v23[v19..]
                        } else {
                            &v23[v19..v49]
                        };
                        sha2::Digest::update(&mut v16, v64);
                        {
                            let v67: bool = true;
                        } // rust.loop;
                        let v69: bool = true;
                    } // rust.loop;
                    let v71: bool = true;
                } // rust.loop;
                let v73: bool = true;
                {
                    // rust.loop;
                    let v75: bool = true;
                    {
                        // rust.loop;
                        let v77: &[u8] = &sha2::Digest::finalize(v16);
                        let v79: Vec<u8> = v77.iter().map(|x| *x).collect::<Vec<_>>();
                        let v81: bool = true;
                        let _vec_map: Vec<_> = v79
                            .into_iter()
                            .map(|x| {
                                //;
                                let v83: u8 = x;
                                let v85: std::string::String = format!("{:02x}", v83);
                                let v87: string = fable_library_rust::String_::fromString(v85);
                                let v89: bool = true;
                                v87
                            })
                            .collect::<Vec<_>>();
                        let v91: Vec<string> = _vec_map;
                        let v93: Array<string> =
                            fable_library_rust::NativeArray_::array_from(v91.clone());
                        let _let__v94: LrcPtr<dyn IEnumerable_1<string>> = delay(Func0::new({
                            let v93 = v93.clone();
                            move || {
                                map_1(
                                    Func1::new({
                                        let v93 = v93.clone();
                                        move |i: i32| v93[i].clone()
                                    }),
                                    rangeNumeric(0_i32, 1_i32, (get_Count(v93.clone())) - 1_i32),
                                )
                            }
                        }));
                        let v103: string = Spiral::method197();
                        let v109: string = join(
                            if (v103.clone()) == string("\n") {
                                Spiral::method180(v103.clone())
                            } else {
                                v103
                            },
                            toArray_1(_let__v94),
                        );
                        Ok::<string, std::io::Error>(v109).unwrap()
                    }
                }
            }
        }
        pub fn method199(v0_1: Spiral::US5, v1_1: string, v2: Spiral::US39, v3: string) -> string {
            let v6: string = Spiral::method30(Spiral::method30(v3, string("target/spiral")), v1_1);
            if let Spiral::US5::US5_0(v0_1_0_0) = &v0_1 {
                if let Spiral::US39::US39_0(v2_0_0) = &v2 {
                    let v8: Spiral::US38 = v2_0_0.clone();
                    let v10: string = Spiral::method30(v6.clone(), string("packages"));
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
                    Spiral::method30(
                        Spiral::method30(
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
        pub fn method201(
            v0_1: string,
            v1_1: LrcPtr<Spiral::UH2>,
            v2: LrcPtr<Spiral::UH2>,
        ) -> LrcPtr<Spiral::UH2> {
            match v1_1.as_ref() {
                Spiral::UH2::UH2_0 => v2.clone(),
                Spiral::UH2::UH2_1(v1_1_1_0, v1_1_1_1) => {
                    let v5: LrcPtr<Spiral::UH2> = Spiral::method201(
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
                            Spiral::method30(
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
        pub fn method202(
            v0_1: LrcPtr<Spiral::UH2>,
            v1_1: LrcPtr<Spiral::UH2>,
        ) -> LrcPtr<Spiral::UH2> {
            match v0_1.as_ref() {
                Spiral::UH2::UH2_0 => v1_1.clone(),
                Spiral::UH2::UH2_1(v0_1_1_0, v0_1_1_1) => {
                    let v4: LrcPtr<Spiral::UH2> = Spiral::method202(
                        match v0_1.as_ref() {
                            Spiral::UH2::UH2_1(_, x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        v1_1.clone(),
                    );
                    LrcPtr::new(Spiral::UH2::UH2_1(
                        concat(new_array(&[
                            string("<PackageReference Include=\""),
                            match v0_1.as_ref() {
                                Spiral::UH2::UH2_1(x, _) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                            string("\" Version=\"*\" />"),
                        ])),
                        v4,
                    ))
                }
            }
        }
        pub fn method200(
            v0_1: string,
            v1_1: string,
            v2: LrcPtr<Spiral::UH2>,
            v3: LrcPtr<Spiral::UH2>,
            v4: string,
            v5: string,
        ) -> string {
            let v6: LrcPtr<dyn IDisposable> = Spiral::method66(v4.clone());
            let v9: string = Spiral::method40(Spiral::method30(
                v4.clone(),
                concat(new_array(&[v1_1.clone(), string(".fs")])),
            ));
            Spiral::method64(v9.clone(), v0_1);
            {
                let v13: List<string> = Spiral::method113(
                    Spiral::method201(v5, v2, LrcPtr::new(Spiral::UH2::UH2_0)),
                    empty::<string>(),
                );
                let v26: string = join(
                    string("\\n        "),
                    toArray_1(delay(Func0::new({
                        let v13 = v13.clone();
                        move || ofList(v13.clone()).clone()
                    }))),
                );
                let v32: List<string> = Spiral::method113(
                    Spiral::method202(v3, LrcPtr::new(Spiral::UH2::UH2_0)),
                    empty::<string>(),
                );
                let v44: string = join(
                    string("\\n        "),
                    toArray_1(delay(Func0::new({
                        let v32 = v32.clone();
                        move || ofList(v32.clone()).clone()
                    }))),
                );
                let v49: string = Spiral::method40(Spiral::method30(
                    v4,
                    concat(new_array(&[v1_1, string(".fsproj")])),
                ));
                Spiral::method64(v49.clone(),
                                 append((append((append((append((append((append((append((append((append((append((append((append((append(string("<Project Sdk=\"Microsoft.NET.Sdk\">\n<PropertyGroup>\n    <TargetFramework>net9.0</TargetFramework>\n    <LangVersion>preview</LangVersion>\n    <RollForward>Major</RollForward>\n    <TargetLatestRuntimePatch>true</TargetLatestRuntimePatch>\n    <PublishAot>false</PublishAot>\n    <PublishTrimmed>false</PublishTrimmed>\n    <PublishSingleFile>true</PublishSingleFile>\n    <SelfContained>true</SelfContained>\n    <Version>0.0.1-alpha.1</Version>\n    <OutputType>Exe</OutputType>\n</PropertyGroup>\n<PropertyGroup Condition=\"$([MSBuild]::IsOSPlatform(\'FreeBSD\'))\">\n    <DefineConstants>_FREEBSD</DefineConstants>\n</PropertyGroup>\n<PropertyGroup Condition=\"$([MSBuild]::IsOSPlatform(\'Linux\'))\">\n    <DefineConstants>_LINUX</DefineConstants>\n</PropertyGroup>\n<PropertyGroup Condition=\"$([MSBuild]::IsOSPlatform(\'OSX\'))\">\n    <DefineConstants>_OSX</DefineConstants>\n</PropertyGroup>\n<PropertyGroup Condition=\"$([MSBuild]::IsOSPlatform(\'Windows\'))\">\n    <DefineConstants>_WINDOWS</DefineConstants>\n</PropertyGroup>\n<ItemGroup>\n"),
                                                                                                                                        (concat(new_array(&[string("    "),
                                                                                                                                                            v26]))))),
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
                                                                                            v44]))))),
                                                                string("\n"))),
                                                        string("</ItemGroup>"))),
                                                string("\n"))),
                                        string("</Project>")));
                v49
            }
        }
        pub fn closure82(unitVar: (), v0_1: chrono::DateTime<chrono::Utc>) -> Spiral::US40 {
            Spiral::US40::US40_0(v0_1)
        }
        pub fn method204() -> Func1<chrono::DateTime<chrono::Utc>, Spiral::US40> {
            Func1::new(move |v: chrono::DateTime<chrono::Utc>| Spiral::closure82((), v))
        }
        pub fn method205() -> string {
            string("hh:mm")
        }
        pub fn method206() -> string {
            string("yyyyMMdd-HHmm-ssff-ffff-f")
        }
        pub fn method207() -> string {
            string("hhmm")
        }
        pub fn method203(v0_1: Guid, v1_1: DateTime) -> Guid {
            let v7: DateTime = {
                let _arg: DateTime = DateTime::unixEpoch();
                _arg.toUniversalTime()
            };
            let v15: DateTime = {
                let _arg_1: DateTime = DateTime::specifyKind(v1_1, 2_i32);
                _arg_1.toUniversalTime()
            };
            let v91: i64 = ((v15.ticks()) - (v7.ticks())) / 10_i64;
            let v93: Option<chrono::DateTime<chrono::Utc>> =
                chrono::DateTime::from_timestamp_micros(v91);
            let v107: Spiral::US40 =
                defaultValue(Spiral::US40::US40_1, map(Spiral::method204(), v93));
            let v127: Spiral::US5 = match &v107 {
                Spiral::US40::US40_0(v107_0_0) => {
                    let v113: chrono::NaiveDateTime = match &v107 {
                        Spiral::US40::US40_0(x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone()
                    .naive_utc();
                    let v115: chrono::DateTime<chrono::Local> =
                        chrono::offset::TimeZone::from_utc_datetime(&chrono::Local, &v113);
                    let v117: string = string("r#\"%Y%m%d-%H%M-%S%f\"#");
                    let v118: &str = r#"%Y%m%d-%H%M-%S%f"#;
                    let v120: std::string::String = v115.format(v118).to_string();
                    let v122: string = fable_library_rust::String_::fromString(v120);
                    Spiral::US5::US5_0(sprintf!(
                        "{}-{}-{}",
                        getSlice(v122.clone(), Some(0_i32), Some(17_i32)),
                        getSlice(v122.clone(), Some(18_i32), Some(21_i32)),
                        getCharAt(v122, 22_i32)
                    ))
                }
                _ => Spiral::US5::US5_1,
            };
            let v131: string = match &v127 {
                Spiral::US5::US5_0(v127_0_0) => match &v127 {
                    Spiral::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                _ => string(""),
            };
            let v134: LrcPtr<TimeZoneInfo> = std::sync::Arc::new(
                chrono::FixedOffset::local_minus_utc(chrono::Local::now().offset()) as i64,
            );
            let v157: i64 = v15.ticks();
            let v188: string =
                string("chrono::FixedOffset::local_minus_utc(&chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(&chrono::DateTime::from_timestamp_nanos($1))))");
            let v299: TimeSpan = TimeSpan::new_ticks(chrono::FixedOffset::local_minus_utc(
                &chrono::DateTime::timezone(&chrono::DateTime::fixed_offset(
                    &chrono::DateTime::from_timestamp_nanos(v157),
                )),
            ) as i64);
            let v312: u8 = if (v299.hours()) > 0_i32 { 1_u8 } else { 0_u8 };
            let v313: string = Spiral::method205();
            let v415: string = v299.toString(v313);
            let v463: string = sprintf!(
                "{}{}{}",
                v312,
                getSlice(v415.clone(), Some(0_i32), Some(1_i32)),
                getSlice(v415, Some(3_i32), Some(4_i32))
            );
            let v465: string = toString(v0_1);
            parse(concat(new_array(&[
                v131.clone(),
                v463.clone(),
                getSlice(
                    v465.clone(),
                    Some((length(v131)) + (length(v463))),
                    Some((length(v465)) - 1_i32),
                ),
            ])))
        }
        pub fn method208(v0_1: string, v1_1: string) {
            if (Spiral::method33(v0_1.clone())) == false {
                let v4: LrcPtr<dyn IDisposable> = Spiral::method66(v0_1.clone());
                ()
            }
            {
                let v7: string = defaultValue(string(""), Spiral::method35(v1_1.clone()));
                if (Spiral::method33(v7.clone())) == false {
                    let v12: LrcPtr<dyn IDisposable> = Spiral::method66(v7);
                    ()
                }
                if if Spiral::method33(v1_1.clone()) {
                    let v14: Result<std::path::PathBuf, std::io::Error> =
                        Spiral::method41(v1_1.clone());
                    v14.is_err()
                } else {
                    false
                } {
                    Spiral::method77(true, v1_1.clone());
                }
                if (Spiral::method33(v1_1.clone())) == false {
                    let v30: bool = true;
                    #[cfg(windows)]
                    std::os::windows::fs::symlink_dir(&*v0_1.clone(), &*v1_1.clone()).unwrap();
                    let v32: bool = true;
                    #[cfg(unix)]
                    std::os::unix::fs::symlink(&*v0_1, &*v1_1).unwrap();
                    ()
                }
            }
        }
        pub fn method210() -> string {
            string("(")
        }
        pub fn method211() -> string {
            string(" ")
        }
        pub fn method212(v0_1: Spiral::US37) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method216(v0_1: bool, v1_1: string, v2: i32, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v5.clone(), string("is_error"), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v41: () = {
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
            let v50: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v59: () = {
                Spiral::closure7(v5.clone(), string("retry"), ());
                ()
            };
            let v67: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v75: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v83: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v92: () = {
                Spiral::closure7(v5.clone(), string("result"), ());
                ()
            };
            let v100: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v108: () = {
                Spiral::closure7(v5.clone(), sprintf!("{}", v2), ());
                ()
            };
            let v117: () = {
                Spiral::closure7(v5.clone(), string(", "), ());
                ()
            };
            let v125: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v134: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
        }
        pub fn method215(
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
            let v12: string = Spiral::method216(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("common.retry_fn\' / loop"),
                v12
            ))
        }
        pub fn closure83(v0_1: u8, v1_1: u8, v2: i32, v3: string, v4: bool, unitVar: ()) {
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
                let v28: Option<i64> = patternInput.5.clone();
                let v27: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v26: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v25: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v24: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v23: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method215(
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    Spiral::method8(v23, v24, v25, v26, v27, v28),
                    Spiral::method12(),
                    v4,
                    sprintf!("{}/{}", v1_1, v0_1),
                    v2,
                    v3,
                ))
            };
        }
        pub fn method214(
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
            '_method214: loop {
                break '_method214 ({
                    let patternInput: (i32, string) = Spiral::method89(
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
                            Spiral::closure83(
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
                            continue '_method214;
                        }
                    }
                });
            }
        }
        pub fn method213(
            v0_1: u8,
            v1_1: string,
            v2: Option<CancellationToken>,
            v3: Array<(string, string)>,
            v4: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v5: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v6: bool,
            v7: Option<string>,
        ) -> (i32, string) {
            Spiral::method214(v0_1, v1_1, v2, v3, v4, v5, v6, v7, 1_u8)
        }
        pub fn method209(
            v0_1: Spiral::US36,
            v1_1: string,
            v2: string,
            v3: string,
            v4: Spiral::US13,
        ) -> (i32, string) {
            let v137: string = sprintf!(
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
                        let v41: Spiral::US37 = match &v0_1 {
                            Spiral::US36::US36_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone();
                        let v82: Spiral::US5 = if if let Spiral::US37::US37_0(v41_0_0) = &v41 {
                            string("") == (v41_0_0.clone())
                        } else {
                            false
                        } {
                            Spiral::US5::US5_0(string("Wasm"))
                        } else {
                            let v54: string = Spiral::method210();
                            let v68: Array<string> = split(
                                Spiral::method212(Spiral::US37::US37_0(string(""))),
                                v54,
                                -1_i32,
                                0_i32,
                            );
                            let v71: string = v68[0_i32].clone();
                            if startsWith3(Spiral::method212(v41.clone()), v71, false) {
                                Spiral::US5::US5_0(string("Wasm"))
                            } else {
                                Spiral::US5::US5_1
                            }
                        };
                        let v126: Spiral::US5 = match &v82 {
                            Spiral::US5::US5_0(v82_0_0) => Spiral::US5::US5_0(
                                match &v82 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => {
                                let v119: Spiral::US5 = if if let Spiral::US37::US37_1(v41_1_0) =
                                    &v41
                                {
                                    string("") == (v41_1_0.clone())
                                } else {
                                    false
                                } {
                                    Spiral::US5::US5_0(string("Contract"))
                                } else {
                                    let v91: string = Spiral::method210();
                                    let v105: Array<string> = split(
                                        Spiral::method212(Spiral::US37::US37_1(string(""))),
                                        v91,
                                        -1_i32,
                                        0_i32,
                                    );
                                    let v108: string = v105[0_i32].clone();
                                    if startsWith3(Spiral::method212(v41.clone()), v108, false) {
                                        Spiral::US5::US5_0(string("Contract"))
                                    } else {
                                        Spiral::US5::US5_1
                                    }
                                };
                                match &v119 {
                                    Spiral::US5::US5_0(v119_0_0) => Spiral::US5::US5_0(
                                        match &v119 {
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
                            toUpper(match &v126 {
                                Spiral::US5::US5_0(v126_0_0) => match &v126 {
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
            let v143: Result<string, string> = match &v4 {
                Spiral::US13::US13_0(v4_0_0) => Ok::<string, string>(v4_0_0.clone()),
                Spiral::US13::US13_1(v4_1_0) => Err::<string, string>(v4_1_0.clone()),
            };
            Spiral::method213(
                3_u8,
                v137,
                None::<CancellationToken>,
                new_empty::<(string, string)>(),
                None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
                None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
                true,
                v143.ok(),
            )
        }
        pub fn method218(v0_1: i32, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v45: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("dotnet_fable_result"), ());
                ()
            };
            let v62: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method217(
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
            let v10: string = Spiral::method218(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / dotnet fable error"),
                v10
            ))
        }
        pub fn closure84(v0_1: string, v1_1: i32, unitVar: ()) {
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method217(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method70(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn closure85(unitVar: (), v0_1: std::string::String) -> bool {
            contains(
                fable_library_rust::String_::fromString(v0_1),
                string("near-sdk"),
            )
        }
        pub fn method219() -> Func1<std::string::String, bool> {
            Func1::new(move |v: std::string::String| Spiral::closure85((), v))
        }
        pub fn method220(v0_1: Vec<std::string::String>) -> Vec<std::string::String> {
            v0_1
        }
        pub fn method221(v0_1: Vec<std::string::String>) -> Vec<std::string::String> {
            v0_1
        }
        pub fn method222(v0_1: Vec<std::string::String>) -> Vec<std::string::String> {
            v0_1
        }
        pub fn method223() -> string {
            string("(")
        }
        pub fn method224() -> string {
            string("(")
        }
        pub fn method226(
            v0_1: string,
            v1_1: regex::Regex,
        ) -> Vec<std::collections::HashMap<string, string>> {
            let v4: &str = &*v0_1;
            let v28: std::string::String = String::from(v4);
            let v51: bool = true;
            let _capture_move = (move || {
                //;
                let v53: Box<std::string::String> = Box::new(v28);
                let v55: &'static mut std::string::String = Box::leak(v53);
                let v57: regex::Regex = v1_1.clone();
                let v59: regex::CaptureMatches = v57.captures_iter(v55);
                let v61: bool = true;
                let _regex_captures: Vec<_> = v59
                    .map(|x| {
                        //;
                        let v63: regex::Captures<'static> = x;
                        let v65: Box<regex::Captures<'static>> = Box::new(v63);
                        let v67: &'static mut regex::Captures<'static> = Box::leak(v65);
                        let v69: regex::CaptureNames = v1_1.capture_names();
                        let v71: bool = true;
                        let _regex_captures: std::collections::HashMap<_, _> = v69
                            .map(|x| {
                                //;
                                let v73: string = x.unwrap_or("").to_string().into();
                                let v75: string = v73.clone().clone();
                                let v77: string = v67
                                    .name(&v73)
                                    .map(|x| x.as_str())
                                    .unwrap_or("")
                                    .to_string()
                                    .into();
                                let v80: bool = true;
                                LrcPtr::new((v75, v77))
                            })
                            .map(|x| std::sync::Arc::try_unwrap(x).unwrap_or_else(|x| (*x).clone()))
                            .collect();
                        let v82: std::collections::HashMap<string, string> = _regex_captures;
                        let v84: bool = true;
                        v82
                    })
                    .collect::<Vec<_>>();
                let v86: Vec<std::collections::HashMap<string, string>> = _regex_captures;
                let v88: bool = true;
                v86
            })();
            _capture_move
        }
        pub fn closure86(
            unitVar: (),
            v0_1: std::collections::HashMap<string, string>,
        ) -> Spiral::US42 {
            Spiral::US42::US42_0(v0_1)
        }
        pub fn method227() -> Func1<std::collections::HashMap<string, string>, Spiral::US42> {
            Func1::new(move |v: std::collections::HashMap<string, string>| Spiral::closure86((), v))
        }
        pub fn method228() -> string {
            string("a")
        }
        pub fn closure87(v0_1: u8, v1_1: i32, v2: string, v3: bool, unitVar: ()) {
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
                let v27: Option<i64> = patternInput.5.clone();
                let v26: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v25: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v24: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v23: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v22: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method215(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method12(),
                    v3,
                    sprintf!("{}/{}", v0_1, 3_u8),
                    v1_1,
                    v2,
                ))
            };
        }
        pub fn method225(v0_1: Spiral::US13, v1_1: string, v2: u8) -> (i32, string) {
            let v0_1: MutCell<Spiral::US13> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<u8> = MutCell::new(v2);
            '_method225: loop {
                break '_method225 ({
                    let v8: string = concat(new_array(&[
                        string("cargo fmt --manifest-path \""),
                        v1_1.get().clone(),
                        string("\" --"),
                    ]));
                    let v14: Result<string, string> = match &v0_1.get().clone() {
                        Spiral::US13::US13_0(v0_1_0_0) => Ok::<string, string>(v0_1_0_0.clone()),
                        Spiral::US13::US13_1(v0_1_1_0) => Err::<string, string>(v0_1_1_0.clone()),
                    };
                    let patternInput: (i32, string) = Spiral::method89(
                        v8,
                        None::<CancellationToken>,
                        new_empty::<(string, string)>(),
                        None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
                        None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
                        true,
                        v14.ok(),
                    );
                    let v31: string = patternInput.1.clone();
                    let v30: i32 = patternInput.0.clone();
                    let v176: Spiral::US41 = if (contains(
                        v31.clone(),
                        string("failed to load manifest for workspace member"),
                    )) == false
                    {
                        if (v30) == 0_i32 {
                            Spiral::US41::US41_0(v30, v31.clone())
                        } else {
                            Spiral::US41::US41_1(v30, v31.clone())
                        }
                    } else {
                        let v43: Result<regex::Regex, regex::Error> =
                            regex::Regex::new(&string("failed to read `(?<a>.*?Cargo.toml)`"));
                        let v58: Vec<std::collections::HashMap<string, string>> =
                            Spiral::method226(v31.clone(), v43.unwrap());
                        let v61: Option<std::collections::HashMap<string, string>> = tryItem(
                            0_i32,
                            fable_library_rust::NativeArray_::array_from(v58.clone()),
                        );
                        let v75: Spiral::US42 =
                            defaultValue(Spiral::US42::US42_1, map(Spiral::method227(), v61));
                        let v103: Spiral::US43 = match &v75 {
                            Spiral::US42::US42_0(v75_0_0) => {
                                let v80: string = Spiral::method228();
                                let v82: Option<string> = std::collections::HashMap::get(
                                    &match &v75 {
                                        Spiral::US42::US42_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    &v80,
                                )
                                .map(|x| x)
                                .cloned();
                                Spiral::US43::US43_0(defaultValue(
                                    Spiral::US5::US5_1,
                                    map(Spiral::method6(), v82),
                                ))
                            }
                            _ => Spiral::US43::US43_1,
                        };
                        let v110: Spiral::US5 = if let Spiral::US43::US43_0(v103_0_0) = &v103 {
                            let v104: Spiral::US5 = v103_0_0.clone();
                            if let Spiral::US5::US5_0(v104_0_0) = &v104 {
                                Spiral::US5::US5_0(v104_0_0.clone())
                            } else {
                                Spiral::US5::US5_1
                            }
                        } else {
                            Spiral::US5::US5_1
                        };
                        match &v110 {
                            Spiral::US5::US5_0(v110_0_0) => {
                                let v112: string = match &v110 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone();
                                if (Spiral::method32(v112.clone())) == false {
                                    let v120: LrcPtr<dyn IDisposable> = Spiral::method66(
                                        defaultValue(string(""), Spiral::method35(v112.clone())),
                                    );
                                    let v122: DateTime = DateTime::now();
                                    let v142: string =
                                        toString(Spiral::method203(new_guid(), v122));
                                    let v167: string =
                                                     append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                            (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                v142.clone(),
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
                                                                                                v142,
                                                                                                string("\"")]))))),
                                                                    string("\n"))),
                                                            string("path = \"spiral.rs\""));
                                    std::fs::write(&*v112, &*v167).unwrap();
                                    ()
                                }
                                if (v30) == 0_i32 {
                                    Spiral::US41::US41_0(v30, v31.clone())
                                } else {
                                    Spiral::US41::US41_1(v30, v31.clone())
                                }
                            }
                            _ => Spiral::US41::US41_1(v30, v31.clone()),
                        }
                    };
                    let patternInput_1: (bool, i32, string) = match &v176 {
                        Spiral::US41::US41_0(v176_0_0, v176_0_1) => {
                            (false, v176_0_0.clone(), v176_0_1.clone())
                        }
                        Spiral::US41::US41_1(v176_1_0, v176_1_1) => {
                            (true, v176_1_0.clone(), v176_1_1.clone())
                        }
                    };
                    let v186: string = patternInput_1.2.clone();
                    let v185: i32 = patternInput_1.1.clone();
                    let v184: bool = patternInput_1.0.clone();
                    if if (v184) == false {
                        true
                    } else {
                        (v2.get().clone()) >= 3_u8
                    } {
                        (v185, v186.clone())
                    } else {
                        let v192: () = {
                            Spiral::closure87(v2.get().clone(), v185, v186, v184, ());
                            ()
                        };
                        {
                            let v0_1_temp: Spiral::US13 = v0_1.get().clone();
                            let v1_1_temp: string = v1_1.get().clone();
                            let v2_temp: u8 = (v2.get().clone()) + 1_u8;
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            continue '_method225;
                        }
                    }
                });
            }
        }
        pub fn method230(v0_1: i32, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v45: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("cargo_fmt_result"), ());
                ()
            };
            let v62: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method229(
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
            let v10: string = Spiral::method230(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / cargo fmt error"),
                v10
            ))
        }
        pub fn closure88(v0_1: string, v1_1: i32, unitVar: ()) {
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method229(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method70(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn method231() -> string {
            string("{")
        }
        pub fn closure89(unitVar: (), v0_1: string) -> string {
            v0_1
        }
        pub fn closure90(v0_1: string, v1_1: string, v2: string) -> string {
            replace(v2, v0_1, v1_1)
        }
        pub fn closure91(v0_1: string, v1_1: string) -> string {
            replace(v1_1, v0_1, string("type DateTime = ();"))
        }
        pub fn method233(v0_1: i32, v1_1: string, v2: string, v3: bool, v4: string) -> string {
            let v6: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v13: () = {
                Spiral::closure7(v6.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral::closure7(v6.clone(), string("exit_code"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v39: () = {
                Spiral::closure7(v6.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v48: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v57: () = {
                Spiral::closure7(v6.clone(), string("new_code_path"), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v73: () = {
                Spiral::closure7(v6.clone(), v1_1, ());
                ()
            };
            let v81: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v90: () = {
                Spiral::closure7(v6.clone(), string("external_command"), ());
                ()
            };
            let v98: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v106: () = {
                Spiral::closure7(v6.clone(), v2, ());
                ()
            };
            let v114: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v123: () = {
                Spiral::closure7(v6.clone(), string("cleanup"), ());
                ()
            };
            let v131: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v142: () = {
                Spiral::closure7(
                    v6.clone(),
                    if v3 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v150: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v159: () = {
                Spiral::closure7(v6.clone(), string("cargo_result"), ());
                ()
            };
            let v167: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v175: () = {
                Spiral::closure7(v6.clone(), v4, ());
                ()
            };
            let v184: () = {
                Spiral::closure7(v6.clone(), string(" }"), ());
                ()
            };
            v6.l0.get().clone()
        }
        pub fn method232(
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
            let v13: string = Spiral::method233(v8, v9, v10, v11, v12);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / error"),
                v13
            ))
        }
        pub fn closure92(v0_1: bool, v1_1: string, v2: string, v3: i32, v4: string, unitVar: ()) {
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
                let v28: Option<i64> = patternInput.5.clone();
                let v27: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v26: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v25: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v24: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v23: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method232(
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    Spiral::method8(v23, v24, v25, v26, v27, v28),
                    Spiral::method70(),
                    v3,
                    v1_1,
                    v4,
                    v0_1,
                    v2,
                ))
            };
        }
        pub fn closure94(unitVar: (), v0_1: string) -> bool {
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
        pub fn closure93(v0_1: string, unitVar: ()) -> string {
            let v8: LrcPtr<dyn IEnumerable_1<string>> = ofArray_1(skip(
                2_i32,
                skipWhile(
                    Func1::new(move |v: string| Spiral::closure94((), v)),
                    split(v0_1, string("\n"), -1_i32, 0_i32),
                ),
            ));
            join(Spiral::method63(), toArray_1(v8))
        }
        pub fn method235(v0_1: LrcPtr<Exception>, v1_1: string, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v5.clone(), string("ex"), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v35: std::string::String = format!("{:#?}", v0_1);
            let v68: () = {
                Spiral::closure7(v5.clone(), fable_library_rust::String_::fromString(v35), ());
                ()
            };
            let v77: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v86: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v102: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v110: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v119: () = {
                Spiral::closure7(v5.clone(), string("external_command"), ());
                ()
            };
            let v127: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v135: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v143: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v152: () = {
                Spiral::closure7(v5.clone(), string("cargo_result"), ());
                ()
            };
            let v160: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v168: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v177: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
        }
        pub fn method234(
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
            let v12: string = Spiral::method235(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / Exception"),
                v12
            ))
        }
        pub fn closure96(
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
                let v27: Option<i64> = patternInput.5.clone();
                let v26: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v25: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v24: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v23: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v22: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method234(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method70(),
                    v3,
                    v0_1,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure95(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure96(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
        }
        pub fn method237(v0_1: i32, v1_1: string, v2: string, v3: bool, v4: string) -> string {
            let v6: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v13: () = {
                Spiral::closure7(v6.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral::closure7(v6.clone(), string("exit_code"), ());
                ()
            };
            let v31: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v39: () = {
                Spiral::closure7(v6.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v48: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v57: () = {
                Spiral::closure7(v6.clone(), string("new_code_path"), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v73: () = {
                Spiral::closure7(v6.clone(), v1_1, ());
                ()
            };
            let v81: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v90: () = {
                Spiral::closure7(v6.clone(), string("cargo_result"), ());
                ()
            };
            let v98: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v106: () = {
                Spiral::closure7(v6.clone(), v2, ());
                ()
            };
            let v114: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v123: () = {
                Spiral::closure7(v6.clone(), string("cleanup"), ());
                ()
            };
            let v131: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v142: () = {
                Spiral::closure7(
                    v6.clone(),
                    if v3 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v150: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v159: () = {
                Spiral::closure7(v6.clone(), string("spiral_wasm_result"), ());
                ()
            };
            let v167: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v175: () = {
                Spiral::closure7(v6.clone(), v4, ());
                ()
            };
            let v184: () = {
                Spiral::closure7(v6.clone(), string(" }"), ());
                ()
            };
            v6.l0.get().clone()
        }
        pub fn method236(
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
            let v13: string = Spiral::method237(v8, v9, v10, v11, v12);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / wasm error"),
                v13
            ))
        }
        pub fn closure97(v0_1: bool, v1_1: string, v2: string, v3: string, v4: i32, unitVar: ()) {
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
                let v28: Option<i64> = patternInput.5.clone();
                let v27: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v26: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v25: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v24: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v23: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method236(
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    Spiral::method8(v23, v24, v25, v26, v27, v28),
                    Spiral::method70(),
                    v4,
                    v1_1,
                    v2,
                    v0_1,
                    concat(new_array(&[string("\n"), v3])),
                ))
            };
        }
        pub fn method239(
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
            let v14: () = {
                Spiral::closure7(v7.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v7.clone(), string("exit_code"), ());
                ()
            };
            let v32: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v40: () = {
                Spiral::closure7(v7.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v49: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v58: () = {
                Spiral::closure7(v7.clone(), string("new_code_path"), ());
                ()
            };
            let v66: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v7.clone(), v1_1, ());
                ()
            };
            let v82: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v91: () = {
                Spiral::closure7(v7.clone(), string("wasm_path"), ());
                ()
            };
            let v99: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v107: () = {
                Spiral::closure7(v7.clone(), v2, ());
                ()
            };
            let v115: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v124: () = {
                Spiral::closure7(v7.clone(), string("command"), ());
                ()
            };
            let v132: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v140: () = {
                Spiral::closure7(v7.clone(), v3, ());
                ()
            };
            let v148: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v157: () = {
                Spiral::closure7(v7.clone(), string("cleanup"), ());
                ()
            };
            let v165: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v176: () = {
                Spiral::closure7(
                    v7.clone(),
                    if v4 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v184: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v193: () = {
                Spiral::closure7(v7.clone(), string("cargo_result"), ());
                ()
            };
            let v201: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v209: () = {
                Spiral::closure7(v7.clone(), v5, ());
                ()
            };
            let v218: () = {
                Spiral::closure7(v7.clone(), string(" }"), ());
                ()
            };
            v7.l0.get().clone()
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
            v11: string,
            v12: bool,
            v13: string,
        ) -> string {
            let v14: string = Spiral::method239(v8, v9, v10, v11, v12, v13);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / cargo error"),
                v14
            ))
        }
        pub fn closure98(
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
                let v29: Option<i64> = patternInput.5.clone();
                let v28: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v27: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v26: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v25: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v24: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method238(
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    Spiral::method8(v24, v25, v26, v27, v28, v29),
                    Spiral::method70(),
                    v3,
                    v1_1,
                    v4,
                    v5,
                    v0_1,
                    concat(new_array(&[string("\n"), v2])),
                ))
            };
        }
        pub fn method241(v0_1: string, v1_1: LrcPtr<Spiral::UH4>) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("new_code_path"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v45: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("cleanup"), ());
                ()
            };
            let v62: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v73: () = {
                Spiral::closure7(v3.clone(), sprintf!("{:?}", v1_1), ());
                ()
            };
            let v82: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
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
            let v25: string = Spiral::method241(
                v8,
                LrcPtr::new(Spiral::UH4::UH4_1(
                    v9,
                    v10,
                    LrcPtr::new(Spiral::UH4::UH4_1(
                        v11,
                        v12,
                        LrcPtr::new(Spiral::UH4::UH4_1(
                            v13,
                            v14,
                            LrcPtr::new(Spiral::UH4::UH4_1(
                                v15,
                                v16,
                                LrcPtr::new(Spiral::UH4::UH4_1(
                                    v17,
                                    v18,
                                    LrcPtr::new(Spiral::UH4::UH4_0),
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
        pub fn closure99(
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
                    Spiral::method73(),
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
        pub fn closure100(unitVar: (), unitVar_1: ()) -> Spiral::US44 {
            Spiral::US44::US44_0
        }
        pub fn method243() -> Func0<Spiral::US44> {
            Func0::new(move || Spiral::closure100((), ()))
        }
        pub fn closure101(unitVar: (), v0_1: string) -> Spiral::US44 {
            Spiral::US44::US44_1(v0_1)
        }
        pub fn method244() -> Func1<string, Spiral::US44> {
            Func1::new(move |v: string| Spiral::closure101((), v))
        }
        pub fn method246(v0_1: string) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v9: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v18: () = {
                Spiral::closure7(v2.clone(), string("error\'"), ());
                ()
            };
            let v27: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v35: () = {
                Spiral::closure7(v2.clone(), v0_1, ());
                ()
            };
            let v44: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method245(
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
            let v9: string = Spiral::method246(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.file_delete"),
                v9
            ))
        }
        pub fn closure102(v0_1: string, unitVar: ()) {
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
                let v24: Option<i64> = patternInput.5.clone();
                let v23: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v22: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v21: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v20: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v19: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method245(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method70(),
                    v0_1,
                ))
            };
        }
        pub fn method242(v0_1: LrcPtr<Spiral::UH4>) {
            let v0_1: MutCell<LrcPtr<Spiral::UH4>> = MutCell::new(v0_1.clone());
            '_method242: loop {
                break '_method242 (match v0_1.get().clone().as_ref() {
                    Spiral::UH4::UH4_0 => (),
                    Spiral::UH4::UH4_1(v0_1_1_0, v0_1_1_1, v0_1_1_2) => {
                        let v6: Result<(), std::io::Error> = std::fs::remove_file(
                            &*match v0_1.get().clone().as_ref() {
                                Spiral::UH4::UH4_1(x, _, _) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        );
                        let v7 = Spiral::method43();
                        let v19: Result<(), string> = v6.map_err(|x| v7(x));
                        let v22 = Spiral::method243();
                        let v23 = Spiral::method244();
                        let v24: Spiral::US44 = match &v19 {
                            Err(v19_1_0) => v23(v19_1_0.clone()),
                            _ => v22(),
                        };
                        match &v24 {
                            Spiral::US44::US44_0 => (),
                            Spiral::US44::US44_1(v24_1_0) => {
                                let v28: () = {
                                    Spiral::closure102(
                                        match &v24 {
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
                            let v0_1_temp: LrcPtr<Spiral::UH4> =
                                match v0_1.get().clone().as_ref() {
                                    Spiral::UH4::UH4_1(_, _, x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone();
                            v0_1.set(v0_1_temp);
                            continue '_method242;
                        }
                    }
                });
            }
        }
        pub fn method247(v0_1: string) -> string {
            v0_1
        }
        pub fn closure104(unitVar: (), v0_1: std::fs::FileType) -> Spiral::US45 {
            Spiral::US45::US45_0(v0_1)
        }
        pub fn method248() -> Func1<std::fs::FileType, Spiral::US45> {
            Func1::new(move |v: std::fs::FileType| Spiral::closure104((), v))
        }
        pub fn closure105(unitVar: (), v0_1: std::string::String) -> Spiral::US45 {
            Spiral::US45::US45_1(v0_1)
        }
        pub fn method249() -> Func1<std::string::String, Spiral::US45> {
            Func1::new(move |v: std::string::String| Spiral::closure105((), v))
        }
        pub fn method250(v0_1: string) -> string {
            let v4: &str = &*v0_1;
            let v28: std::string::String = String::from(v4);
            let v52: std::path::PathBuf = std::path::PathBuf::from(v28);
            let v75: Option<&std::ffi::OsStr> = v52.file_name();
            let v77: bool = true;
            let _optionm_map_ = v75.map(|x| {
                //;
                let v79: &std::ffi::OsStr = x;
                let v81: std::ffi::OsString = v79.to_os_string();
                let v83: Option<&str> = v81.to_str();
                let v85: &str = v83.unwrap();
                let v88: std::string::String = String::from(v85);
                let v111: string = fable_library_rust::String_::fromString(v88);
                let v113: bool = true;
                v111
            });
            let v115: Option<string> = _optionm_map_;
            let v129: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v115));
            match &v129 {
                Spiral::US5::US5_0(v129_0_0) => match &v129 {
                    Spiral::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                _ => string(""),
            }
        }
        pub fn closure103(
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
                            let v20 = Spiral::method67();
                            let v32: Result<std::fs::FileType, std::string::String> =
                                v19.map_err(|x| v20(x));
                            let v35 = Spiral::method248();
                            let v36 = Spiral::method249();
                            let v37: Spiral::US45 = match &v32 {
                                Err(v32_1_0) => v36(v32_1_0.clone()),
                                Ok(v32_0_0) => v35(v32_0_0.clone()),
                            };
                            let v218: Spiral::US46 = if let Spiral::US45::US45_0(v37_0_0) = &v37 {
                                if (std::fs::FileType::is_dir(&v37_0_0.clone())) == false {
                                    Spiral::US46::US46_0
                                } else {
                                    let v44: std::path::PathBuf =
                                        async_walkdir::DirEntry::path(&v1_1.clone());
                                    let v47: std::path::Display = v44.display();
                                    let v71: std::string::String = format!("{}", v47);
                                    let v94: string = fable_library_rust::String_::fromString(v71);
                                    if (startsWith3(
                                        Spiral::method250(v94.clone()),
                                        v0_1.clone(),
                                        false,
                                    )) == false
                                    {
                                        Spiral::US46::US46_1
                                    } else {
                                        let v101: Option<string> = Spiral::method35(v94);
                                        let v115: Spiral::US5 = defaultValue(
                                            Spiral::US5::US5_1,
                                            map(Spiral::method6(), v101),
                                        );
                                        if let Spiral::US5::US5_0(v115_0_0) = &v115 {
                                            if (contains(v115_0_0.clone(), v0_1.clone())) == false {
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
                                let v132: std::path::PathBuf = async_walkdir::DirEntry::path(&v1_1);
                                let v135: std::path::Display = v132.display();
                                let v159: std::string::String = format!("{}", v135);
                                let v182: string = fable_library_rust::String_::fromString(v159);
                                if (startsWith3(
                                    Spiral::method250(v182.clone()),
                                    v0_1.clone(),
                                    false,
                                )) == false
                                {
                                    Spiral::US46::US46_1
                                } else {
                                    let v189: Option<string> = Spiral::method35(v182);
                                    let v203: Spiral::US5 = defaultValue(
                                        Spiral::US5::US5_1,
                                        map(Spiral::method6(), v189),
                                    );
                                    if let Spiral::US5::US5_0(v203_0_0) = &v203 {
                                        if (contains(v203_0_0.clone(), v0_1)) == false {
                                            Spiral::US46::US46_2
                                        } else {
                                            Spiral::US46::US46_1
                                        }
                                    } else {
                                        Spiral::US46::US46_1
                                    }
                                }
                            };
                            let v221: string = string("}");
                            let v226: bool = true;
                            let _fix_closure_v223 = v218;
                            let v233: string = append(
                                (append(
                                    (append(
                                        (append(string("true; _fix_closure_v223 "), (v221))),
                                        string("); "),
                                    )),
                                    string(""),
                                )),
                                string(" // rust.fix_closure\'"),
                            );
                            let v234: bool = true;
                            _fix_closure_v223
                        },
                    ); // rust.fix_closure';
                    let v236 = __future_init;
                    let v238: std::pin::Pin<
                        Box<dyn std::future::Future<Output = Spiral::US46> + Send>,
                    > = v236;
                    let v240: Spiral::US46 = v238.await;
                    let v249: async_walkdir::Filtering = match &v240 {
                        Spiral::US46::US46_0 => async_walkdir::Filtering::Ignore,
                        Spiral::US46::US46_1 => async_walkdir::Filtering::IgnoreDir,
                        _ => async_walkdir::Filtering::Continue,
                    };
                    let v250: string = string("}");
                    let v255: bool = true;
                    let _fix_closure_v252 = v249;
                    let v262: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v252 "), (v250))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v263: bool = true;
                    _fix_closure_v252
                },
            ); // rust.fix_closure';
            let v265 = __future_init;
            v265
        }
        pub fn closure107(unitVar: (), v0_1: async_walkdir::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method252() -> Func1<async_walkdir::Error, std::string::String> {
            Func1::new(move |v: async_walkdir::Error| Spiral::closure107((), v))
        }
        pub fn closure108(unitVar: (), v0_1: async_walkdir::DirEntry) -> Spiral::US47 {
            Spiral::US47::US47_0(v0_1)
        }
        pub fn method253() -> Func1<async_walkdir::DirEntry, Spiral::US47> {
            Func1::new(move |v: async_walkdir::DirEntry| Spiral::closure108((), v))
        }
        pub fn closure109(unitVar: (), v0_1: std::string::String) -> Spiral::US47 {
            Spiral::US47::US47_1(v0_1)
        }
        pub fn method254() -> Func1<std::string::String, Spiral::US47> {
            Func1::new(move |v: std::string::String| Spiral::closure109((), v))
        }
        pub fn method255(
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
            let v9: string = Spiral::method121(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript / stream_filter_map"),
                v9
            ))
        }
        pub fn closure110(v0_1: std::string::String, unitVar: ()) {
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
                let v24: Option<i64> = patternInput.5.clone();
                let v23: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v22: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v21: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v20: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v19: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method255(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method70(),
                    v0_1,
                ))
            };
        }
        pub fn closure106(
            v0_1: string,
            v1_1: Result<async_walkdir::DirEntry, async_walkdir::Error>,
        ) -> Option<(string, string)> {
            let v2 = Spiral::method252();
            let v14: Result<async_walkdir::DirEntry, std::string::String> = v1_1.map_err(|x| v2(x));
            let v17 = Spiral::method253();
            let v18 = Spiral::method254();
            let v19: Spiral::US47 = match &v14 {
                Err(v14_1_0) => v18(v14_1_0.clone()),
                Ok(v14_0_0) => v17(v14_0_0.clone()),
            };
            let v193: Spiral::US48 = match &v19 {
                Spiral::US47::US47_0(v19_0_0) => {
                    let v22: std::path::PathBuf = async_walkdir::DirEntry::path(&v19_0_0.clone());
                    let v25: std::path::Display = v22.display();
                    let v49: std::string::String = format!("{}", v25);
                    let v72: string = fable_library_rust::String_::fromString(v49);
                    let v73: string =
                        concat(new_array(&[v0_1.clone(), string("\\.(?<a>[-\\d\\w.]+)$")]));
                    let v75: Result<regex::Regex, regex::Error> = regex::Regex::new(&v73);
                    let v90: Vec<std::collections::HashMap<string, string>> =
                        Spiral::method226(v72.clone(), v75.unwrap());
                    let v93: Option<std::collections::HashMap<string, string>> = tryItem(
                        0_i32,
                        fable_library_rust::NativeArray_::array_from(v90.clone()),
                    );
                    let v107: Spiral::US42 =
                        defaultValue(Spiral::US42::US42_1, map(Spiral::method227(), v93));
                    let v135: Spiral::US43 = match &v107 {
                        Spiral::US42::US42_0(v107_0_0) => {
                            let v112: string = Spiral::method228();
                            let v114: Option<string> = std::collections::HashMap::get(
                                &match &v107 {
                                    Spiral::US42::US42_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                &v112,
                            )
                            .map(|x| x)
                            .cloned();
                            Spiral::US43::US43_0(defaultValue(
                                Spiral::US5::US5_1,
                                map(Spiral::method6(), v114),
                            ))
                        }
                        _ => Spiral::US43::US43_1,
                    };
                    let v142: Spiral::US5 = if let Spiral::US43::US43_0(v135_0_0) = &v135 {
                        let v136: Spiral::US5 = v135_0_0.clone();
                        if let Spiral::US5::US5_0(v136_0_0) = &v136 {
                            Spiral::US5::US5_0(v136_0_0.clone())
                        } else {
                            Spiral::US5::US5_1
                        }
                    } else {
                        Spiral::US5::US5_1
                    };
                    match &v142 {
                        Spiral::US5::US5_0(v142_0_0) => Spiral::US48::US48_0(
                            v72.clone(),
                            match &v142 {
                                Spiral::US5::US5_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => Spiral::US48::US48_1,
                    }
                }
                Spiral::US47::US47_1(v19_1_0) => {
                    let v151: () = {
                        Spiral::closure110(v19_1_0.clone(), ());
                        ()
                    };
                    Spiral::US48::US48_1
                }
            };
            match &v193 {
                Spiral::US48::US48_0(v193_0_0, v193_0_1) => Some((
                    match &v193 {
                        Spiral::US48::US48_0(x, _) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    match &v193 {
                        Spiral::US48::US48_0(_, x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                )),
                _ => None::<(string, string)>,
            }
        }
        pub fn method251(
            v0_1: string,
        ) -> Func1<Result<async_walkdir::DirEntry, async_walkdir::Error>, Option<(string, string)>>
        {
            Func1::new({
                let v0_1 = v0_1.clone();
                move |v: Result<async_walkdir::DirEntry, async_walkdir::Error>| {
                    Spiral::closure106(v0_1.clone(), v)
                }
            })
        }
        pub fn closure111(unitVar: (), _arg: (string, string)) -> (string, string) {
            (_arg.0.clone(), _arg.1.clone())
        }
        pub fn closure112(unitVar: (), _arg: (string, string)) -> Spiral::US48 {
            Spiral::US48::US48_0(_arg.0.clone(), _arg.1.clone())
        }
        pub fn method256() -> Func1<(string, string), Spiral::US48> {
            Func1::new(move |arg10_0040: (string, string)| Spiral::closure112((), arg10_0040))
        }
        pub fn method258(v0_1: Spiral::US48) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v9: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v18: () = {
                Spiral::closure7(v2.clone(), string("version"), ());
                ()
            };
            let v27: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v38: () = {
                Spiral::closure7(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v47: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method257(
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
            let v9: string = Spiral::method258(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript"),
                v9
            ))
        }
        pub fn closure113(v0_1: Spiral::US48, unitVar: ()) {
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
                let v24: Option<i64> = patternInput.5.clone();
                let v23: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v22: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v21: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v20: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v19: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method257(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method12(),
                    v0_1,
                ))
            };
        }
        pub fn method259(v0_1: string, v1_1: string, v2: Spiral::US48) {
            match &v2 {
                Spiral::US48::US48_0(v2_0_0, v2_0_1) => {
                    let v4: string = match &v2 {
                        Spiral::US48::US48_0(_, x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone();
                    Spiral::method208(
                        Spiral::method30(
                            v1_1.clone(),
                            concat(new_array(&[
                                string("fable-library-"),
                                string("ts"),
                                string("."),
                                v4.clone(),
                            ])),
                        ),
                        Spiral::method30(
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
        pub fn method260(
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
            let v10: string = Spiral::method218(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript"),
                v10
            ))
        }
        pub fn closure114(v0_1: string, v1_1: i32, unitVar: ()) {
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method260(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method70(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn method262(v0_1: string) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v9: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v18: () = {
                Spiral::closure7(v2.clone(), string("new_code_path"), ());
                ()
            };
            let v27: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v35: () = {
                Spiral::closure7(v2.clone(), v0_1, ());
                ()
            };
            let v44: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
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
            v8: string,
        ) -> string {
            let v9: string = Spiral::method262(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript"),
                v9
            ))
        }
        pub fn closure115(v0_1: string, unitVar: ()) {
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
                let v24: Option<i64> = patternInput.5.clone();
                let v23: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v22: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v21: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v20: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v19: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method261(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method12(),
                    v0_1,
                ))
            };
        }
        pub fn method263(
            v0_1: LrcPtr<Spiral::UH5>,
            v1_1: LrcPtr<Spiral::UH5>,
        ) -> LrcPtr<Spiral::UH5> {
            match v0_1.as_ref() {
                Spiral::UH5::UH5_0 => v1_1.clone(),
                Spiral::UH5::UH5_1(v0_1_1_0, v0_1_1_1, v0_1_1_2) => {
                    LrcPtr::new(Spiral::UH5::UH5_1(
                        match v0_1.as_ref() {
                            Spiral::UH5::UH5_1(x, _, _) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        match v0_1.as_ref() {
                            Spiral::UH5::UH5_1(_, x, _) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        Spiral::method263(
                            match v0_1.as_ref() {
                                Spiral::UH5::UH5_1(_, _, x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                            v1_1.clone(),
                        ),
                    ))
                }
            }
        }
        pub fn method264(
            v0_1: LrcPtr<Spiral::UH5>,
            v1_1: List<(string, string)>,
        ) -> List<(string, string)> {
            match v0_1.as_ref() {
                Spiral::UH5::UH5_0 => v1_1.clone(),
                Spiral::UH5::UH5_1(v0_1_1_0, v0_1_1_1, v0_1_1_2) => cons(
                    (
                        match v0_1.as_ref() {
                            Spiral::UH5::UH5_1(x, _, _) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        match v0_1.as_ref() {
                            Spiral::UH5::UH5_1(_, x, _) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    Spiral::method264(
                        match v0_1.as_ref() {
                            Spiral::UH5::UH5_1(_, _, x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                        v1_1.clone(),
                    ),
                ),
            }
        }
        pub fn closure116(v0_1: string, unitVar: ()) -> string {
            let v5: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method63(), toArray_1(v5))
        }
        pub fn method266(v0_1: LrcPtr<Exception>, v1_1: string, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v21: () = {
                Spiral::closure7(v5.clone(), string("ex"), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v35: std::string::String = format!("{:#?}", v0_1);
            let v68: () = {
                Spiral::closure7(v5.clone(), fable_library_rust::String_::fromString(v35), ());
                ()
            };
            let v77: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v86: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v102: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v110: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v119: () = {
                Spiral::closure7(v5.clone(), string("external_command"), ());
                ()
            };
            let v127: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v135: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v143: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v152: () = {
                Spiral::closure7(v5.clone(), string("run_result"), ());
                ()
            };
            let v160: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v168: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v177: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
        }
        pub fn method265(
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
            let v12: string = Spiral::method266(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript / Exception"),
                v12
            ))
        }
        pub fn closure118(
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
                let v27: Option<i64> = patternInput.5.clone();
                let v26: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v25: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v24: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v23: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v22: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method265(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method70(),
                    v3,
                    v0_1,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure117(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure118(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
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
            v8: i32,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method169(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript / error"),
                v12
            ))
        }
        pub fn closure119(v0_1: string, v1_1: string, v2: i32, v3: string, unitVar: ()) {
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
                let v27: Option<i64> = patternInput.5.clone();
                let v26: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v25: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v24: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v23: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v22: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method267(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method70(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
        }
        pub fn method268(
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
            let v10: string = Spiral::method218(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python"),
                v10
            ))
        }
        pub fn closure120(v0_1: string, v1_1: i32, unitVar: ()) {
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method268(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method70(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn method269(
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
            let v9: string = Spiral::method262(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python"),
                v9
            ))
        }
        pub fn closure121(v0_1: string, unitVar: ()) {
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
                let v24: Option<i64> = patternInput.5.clone();
                let v23: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v22: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v21: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v20: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v19: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method269(
                    v19.clone(),
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    Spiral::method8(v19, v20, v21, v22, v23, v24),
                    Spiral::method12(),
                    v0_1,
                ))
            };
        }
        pub fn closure122(v0_1: string, unitVar: ()) -> string {
            let v5: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method63(), toArray_1(v5))
        }
        pub fn method270(
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
            let v12: string = Spiral::method266(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python / Exception"),
                v12
            ))
        }
        pub fn closure124(
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
                let v27: Option<i64> = patternInput.5.clone();
                let v26: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v25: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v24: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v23: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v22: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method270(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method70(),
                    v3,
                    v0_1,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure123(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure124(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
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
            v8: i32,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method169(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python / error"),
                v12
            ))
        }
        pub fn closure125(v0_1: string, v1_1: string, v2: i32, v3: string, unitVar: ()) {
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
                let v27: Option<i64> = patternInput.5.clone();
                let v26: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v25: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v24: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v23: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v22: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method271(
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    v26.clone(),
                    v27.clone(),
                    Spiral::method8(v22, v23, v24, v25, v26, v27),
                    Spiral::method70(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
        }
        pub fn method273(v0_1: std::string::String, v1_1: clap::ArgMatches) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v10: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v19: () = {
                Spiral::closure7(v3.clone(), string("subcommand"), ());
                ()
            };
            let v28: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v33: std::string::String = format!("{:#?}", v0_1);
            let v66: () = {
                Spiral::closure7(v3.clone(), fable_library_rust::String_::fromString(v33), ());
                ()
            };
            let v75: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v84: () = {
                Spiral::closure7(v3.clone(), string("arg_matches"), ());
                ()
            };
            let v92: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v97: std::string::String = format!("{:#?}", v1_1);
            let v130: () = {
                Spiral::closure7(v3.clone(), fable_library_rust::String_::fromString(v97), ());
                ()
            };
            let v139: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method272(
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
            let v10: string = Spiral::method273(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / invalid subcommand"),
                v10
            ))
        }
        pub fn closure126(v0_1: clap::ArgMatches, v1_1: std::string::String, unitVar: ()) {
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
                let v25: Option<i64> = patternInput.5.clone();
                let v24: LrcPtr<Spiral::Mut4> = patternInput.4.clone();
                let v23: LrcPtr<Spiral::Mut3> = patternInput.3.clone();
                let v22: LrcPtr<Spiral::Mut2> = patternInput.2.clone();
                let v21: LrcPtr<Spiral::Mut1> = patternInput.1.clone();
                let v20: LrcPtr<Spiral::Mut0> = patternInput.0.clone();
                Spiral::method19(Spiral::method272(
                    v20.clone(),
                    v21.clone(),
                    v22.clone(),
                    v23.clone(),
                    v24.clone(),
                    v25.clone(),
                    Spiral::method8(v20, v21, v22, v23, v24, v25),
                    Spiral::method12(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn closure127(unitVar: (), v0_1: serde_json::Error) -> string {
            let v3: std::string::String = format!("{}", v0_1);
            fable_library_rust::String_::fromString(v3)
        }
        pub fn method274() -> Func1<serde_json::Error, string> {
            Func1::new(move |v: serde_json::Error| Spiral::closure127((), v))
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
                    let v25: Spiral::US6 =
                        defaultValue(Spiral::US6::US6_1, map(Spiral::method21(), v10));
                    let v4586: Array<(string, string)> = if let Spiral::US6::US6_0(
                        v25_0_0,
                        v25_0_1,
                    ) = &v25
                    {
                        let v30: clap::ArgMatches = v25_0_1.clone();
                        let v29: std::string::String = v25_0_0.clone();
                        if (fable_library_rust::String_::fromString(v29.clone())) == string("cuda")
                        {
                            let v34: string = Spiral::method22();
                            let v37: &str = &*v34;
                            let v60: Option<std::string::String> =
                                clap::ArgMatches::get_one(&v30.clone(), v37).cloned();
                            let v74: Spiral::US7 =
                                defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v60));
                            let v81: std::string::String = match &v74 {
                                Spiral::US7::US7_0(v74_0_0) => match &v74 {
                                    Spiral::US7::US7_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => panic!("{}", string("Option does not have a value."),),
                            };
                            let v83: string = fable_library_rust::String_::fromString(v81);
                            let v84: string = Spiral::method24();
                            let v87: &str = &*v84;
                            let v110: Option<std::string::String> =
                                clap::ArgMatches::get_one(&v30.clone(), v87).cloned();
                            let v124: Spiral::US7 =
                                defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v110));
                            let v153: Spiral::US8 = match &v124 {
                                Spiral::US7::US7_0(v124_0_0) => {
                                    let v130: string = fable_library_rust::String_::fromString(
                                        match &v124 {
                                            Spiral::US7::US7_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    );
                                    let v135: Spiral::US9 = if string("Pip") == (v130.clone()) {
                                        Spiral::US9::US9_0(Spiral::US10::US10_0)
                                    } else {
                                        Spiral::US9::US9_1
                                    };
                                    Spiral::US8::US8_0(match &v135 {
                                        Spiral::US9::US9_0(v135_0_0) => Spiral::US9::US9_0(
                                            match &v135 {
                                                Spiral::US9::US9_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        ),
                                        _ => {
                                            let v142: Spiral::US9 =
                                                if string("Poetry") == (v130.clone()) {
                                                    Spiral::US9::US9_0(Spiral::US10::US10_1)
                                                } else {
                                                    Spiral::US9::US9_1
                                                };
                                            match &v142 {
                                                Spiral::US9::US9_0(v142_0_0) => Spiral::US9::US9_0(
                                                    match &v142 {
                                                        Spiral::US9::US9_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                ),
                                                _ => Spiral::US9::US9_1,
                                            }
                                        }
                                    })
                                }
                                _ => Spiral::US8::US8_1,
                            };
                            let v160: Spiral::US9 = if let Spiral::US8::US8_0(v153_0_0) = &v153 {
                                let v154: Spiral::US9 = v153_0_0.clone();
                                if let Spiral::US9::US9_0(v154_0_0) = &v154 {
                                    Spiral::US9::US9_0(v154_0_0.clone())
                                } else {
                                    Spiral::US9::US9_1
                                }
                            } else {
                                Spiral::US9::US9_1
                            };
                            let v164: Spiral::US10 = match &v160 {
                                Spiral::US9::US9_0(v160_0_0) => match &v160 {
                                    Spiral::US9::US9_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => Spiral::US10::US10_0,
                            };
                            let v165: string = Spiral::method25();
                            let v168: &str = &*v165;
                            let v191: Option<Vec<std::string::String>> =
                                clap::ArgMatches::get_many(&v30.clone(), v168)
                                    .map(|x| x.cloned().into_iter().collect());
                            let v205: Spiral::US11 =
                                defaultValue(Spiral::US11::US11_1, map(Spiral::method26(), v191));
                            let v211: Vec<std::string::String> =
                                new_empty::<std::string::String>().to_vec();
                            let v214: Vec<std::string::String> = match &v205 {
                                Spiral::US11::US11_0(v205_0_0) => match &v205 {
                                    Spiral::US11::US11_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => v211.clone(),
                            };
                            let v218: Result<Vec<u8>, std::io::Error> =
                                std::fs::read(&*v83.clone());
                            let v256: Vec<u8> = Spiral::method27(v218.unwrap());
                            let v258: Result<std::string::String, std::string::FromUtf8Error> =
                                std::string::String::from_utf8(v256);
                            let v261: std::string::String = v258.unwrap();
                            let v274: string = fable_library_rust::String_::fromString(v261);
                            let v297: Spiral::US5 = Spiral::method29(Spiral::method28());
                            let v303: Spiral::US5 = match &v297 {
                                Spiral::US5::US5_0(v297_0_0) => Spiral::US5::US5_0(
                                    match &v297 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => Spiral::method29(string(
                                    "c:\\home\\git\\polyglot\\target\\Builder\\spiral",
                                )),
                            };
                            let v309: Spiral::US5 = match &v303 {
                                Spiral::US5::US5_0(v303_0_0) => Spiral::US5::US5_0(
                                    match &v303 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => Spiral::method29(string("/workspaces")),
                            };
                            let v313: string = match &v309 {
                                Spiral::US5::US5_0(v309_0_0) => match &v309 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => panic!("{}", string("Option does not have a value."),),
                            };
                            let v327: string = Spiral::method30(
                                if string("deps") == (Spiral::method49(v313.clone())) {
                                    let v320: Spiral::US5 = Spiral::method29(
                                        Spiral::method35(v313.clone()).clone().unwrap(),
                                    );
                                    match &v320 {
                                        Spiral::US5::US5_0(v320_0_0) => match &v320 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => panic!("{}", string("Option does not have a value."),),
                                    }
                                } else {
                                    v313
                                },
                                string("polyglot"),
                            );
                            let v330: string = toLower(Spiral::method28());
                            let v334: string = toLower(v327);
                            let v342: Spiral::US13 = if startsWith3(v330, v334.clone(), false) {
                                Spiral::US13::US13_1(v334.clone())
                            } else {
                                Spiral::US13::US13_0(v334)
                            };
                            let v348: Result<string, string> = match &v342 {
                                Spiral::US13::US13_0(v342_0_0) => {
                                    Ok::<string, string>(v342_0_0.clone())
                                }
                                Spiral::US13::US13_1(v342_1_0) => {
                                    Err::<string, string>(v342_1_0.clone())
                                }
                            };
                            let v350: bool = true;
                            let _result_unwrap_or_else = v348.unwrap_or_else(|x| {
                                //;
                                let v352: string = x;
                                let v354: bool = true;
                                v352
                            });
                            let v356: string = _result_unwrap_or_else;
                            let v359: string =
                                defaultValue(string(""), Spiral::method35(v83.clone()));
                            let v367: string = match &v164 {
                                Spiral::US10::US10_1 => {
                                    Spiral::method30(v359.clone(), string("pyproject.toml"))
                                }
                                _ => Spiral::method30(v359.clone(), string("requirements.txt")),
                            };
                            let v369: bool = true;
                            let _vec_map: Vec<_> = v214
                                .into_iter()
                                .map(|x| {
                                    //;
                                    let v371: std::string::String = x;
                                    let v373: string =
                                        fable_library_rust::String_::fromString(v371);
                                    let v388: string = if contains(v373.clone(), string("=")) {
                                        v373.clone()
                                    } else {
                                        if endsWith3(v373.clone(), string("]"), false) {
                                            concat(new_array(&[
                                                replace(
                                                    v373.clone(),
                                                    string("["),
                                                    string("={version=\'*\',features=["),
                                                ),
                                                string("}"),
                                            ]))
                                        } else {
                                            concat(new_array(&[v373, string("=\'*\'")]))
                                        }
                                    };
                                    let v390: bool = true;
                                    v388
                                })
                                .collect::<Vec<_>>();
                            let v392: Vec<string> = _vec_map;
                            let v394: Array<string> =
                                fable_library_rust::NativeArray_::array_from(v392.clone());
                            let _let__v395: LrcPtr<dyn IEnumerable_1<string>> =
                                delay(Func0::new({
                                    let v394 = v394.clone();
                                    move || {
                                        map_1(
                                            Func1::new({
                                                let v394 = v394.clone();
                                                move |i: i32| v394[i].clone()
                                            }),
                                            rangeNumeric(
                                                0_i32,
                                                1_i32,
                                                (get_Count(v394.clone())) - 1_i32,
                                            ),
                                        )
                                    }
                                }));
                            let v407: string = join(Spiral::method63(), toArray_1(_let__v395));
                            let patternInput: (i32, string) = if (v407.clone()) == string("") {
                                (0_i32, string(""))
                            } else {
                                Spiral::method64(v367,
                                                 match &v164 {
                                                     Spiral::US10::US10_1 =>
                                                     append((append((append((append((append((append((append((append((append(string("[tool.poetry]\nname = \"test\"\nversion = \"0.0.1\"\ndescription = \"\"\nauthors = []\n\n[tool.poetry.dependencies]\npython=\"~3.12\"\n"),
                                                                                                                            (v407.clone()))),
                                                                                                                    string("\n"))),
                                                                                                            string(""))),
                                                                                                    string("\n"))),
                                                                                            string("[build-system]"))),
                                                                                    string("\n"))),
                                                                            string("requires = [\"poetry-core\"]"))),
                                                                    string("\n"))),
                                                            string("build-backend = \"poetry.core.masonry.api\"")),
                                                     _ => v407.clone(),
                                                 });
                                Spiral::method89(
                                    match &v164 {
                                        Spiral::US10::US10_1 => string("poetry install"),
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
                                    Some(v359.clone()),
                                )
                            };
                            let v467: i32 = patternInput.0.clone();
                            let patternInput_4: (
                                Spiral::US5,
                                Spiral::US5,
                                Spiral::US5,
                                Spiral::US5,
                            ) = if (v467) != 0_i32 {
                                let v474: () = {
                                    Spiral::closure70(
                                        v164.clone(),
                                        v83.clone(),
                                        patternInput.1.clone(),
                                        v467,
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
                                let v522: string = match &v164 {
                                    Spiral::US10::US10_1 => concat(new_array(&[
                                        string("poetry run python \""),
                                        v83.clone(),
                                        string("\""),
                                    ])),
                                    _ => concat(new_array(&[
                                        string("python \""),
                                        v83.clone(),
                                        string("\""),
                                    ])),
                                };
                                let v525: Array<(string, string)> =
                                    new_array(&[(string("TRACE_LEVEL"), string("Verbose"))]);
                                let patternInput_1: (i32, string) = Spiral::method89(
                                    v522.clone(),
                                    None::<CancellationToken>,
                                    v525.clone(),
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
                                    Some(v359.clone()),
                                );
                                let v536: string = patternInput_1.1.clone();
                                let v535: i32 = patternInput_1.0.clone();
                                let v537: i32 = get_Count(v525.clone());
                                let v538: Array<string> = new_init(&string(""), v537);
                                let v539: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                    l0: MutCell::new(0_i32),
                                });
                                while Spiral::method93(v537, v539.clone()) {
                                    let v541: i32 = v539.l0.get().clone();
                                    let patternInput_2: (string, string) = v525[v541].clone();
                                    let v544: string = sprintf!(
                                        "$env:{}=\'\'{}\'\'",
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone()
                                    );
                                    v538.get_mut()[v541 as usize] = v544;
                                    {
                                        let v545: i32 = (v541) + 1_i32;
                                        v539.l0.set(v545);
                                        ()
                                    }
                                }
                                {
                                    let v555: string = sprintf!(
                                        "pwsh -c \'{}; {}\'",
                                        join(string(";"), toArray_1(ofArray_1(v538.clone()))),
                                        v522
                                    );
                                    let patternInput_3: (
                                        Spiral::US5,
                                        Spiral::US5,
                                        Spiral::US5,
                                        Spiral::US5,
                                    ) = if if (v535) == 0_i32 {
                                        true
                                    } else {
                                        contains(v536.clone(),
                                                        string("cupy_backends.cuda.api.runtime.CUDARuntimeError: cudaErrorInsufficientDriver"))
                                    } {
                                        let result: LrcPtr<MutCell<Spiral::US5>> =
                                            refCell(Spiral::US5::US5_1);
                                        try_catch(
                                            || {
                                                result.set(Spiral::closure71(
                                                    (),
                                                    Spiral::closure72(v536.clone(), ()),
                                                ))
                                            },
                                            |ex: LrcPtr<Exception>| {
                                                result.set(Spiral::closure73(
                                                    v83.clone(),
                                                    v536.clone(),
                                                    v555.clone(),
                                                    ex.clone(),
                                                ))
                                            },
                                        );
                                        {
                                            let v566: Spiral::US5 = result.get().clone();
                                            let v576: Option<string> = match &v566 {
                                                Spiral::US5::US5_0(v566_0_0) => Some(
                                                    match &v566 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                ),
                                                _ => None::<string>,
                                            };
                                            (
                                                Spiral::US5::US5_0(string("py")),
                                                Spiral::US5::US5_0(v274),
                                                Spiral::US5::US5_0(v83.clone()),
                                                Spiral::US5::US5_0(v576.unwrap()),
                                            )
                                        }
                                    } else {
                                        let v586: () = {
                                            Spiral::closure75(v83.clone(), v536, v535, v555, ());
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
                                        patternInput_3.0.clone(),
                                        patternInput_3.1.clone(),
                                        patternInput_3.2.clone(),
                                        patternInput_3.3.clone(),
                                    )
                                }
                            };
                            let v638: Spiral::US5 = patternInput_4.3.clone();
                            let v636: Spiral::US5 = patternInput_4.1.clone();
                            let v635: Spiral::US5 = patternInput_4.0.clone();
                            let v651: Array<(string, string)> = new_array(&[
                                (
                                    string("extension"),
                                    match &v635 {
                                        Spiral::US5::US5_0(v635_0_0) => match &v635 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => string(""),
                                    },
                                ),
                                (
                                    string("code"),
                                    match &v636 {
                                        Spiral::US5::US5_0(v636_0_0) => match &v636 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => string(""),
                                    },
                                ),
                                (
                                    string("output"),
                                    match &v638 {
                                        Spiral::US5::US5_0(v638_0_0) => match &v638 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => string(""),
                                    },
                                ),
                            ]);
                            let v653: Vec<(string, string)> = v651.to_vec();
                            let v656: bool = true;
                            let _func1_from_v654 = Func1::from(move |value| {
                                //;
                                let patternInput_5: (string, string) = value;
                                let v662: &str = &*patternInput_5.0.clone();
                                let v686: std::string::String = String::from(v662);
                                let v710: &str = &*patternInput_5.1.clone();
                                let v734: std::string::String = String::from(v710);
                                let v759: bool = true;
                                LrcPtr::new((v686, v734)) /*;
                                                          let v761: bool = */
                            }); //;
                            let v763: Func1<
                                (string, string),
                                LrcPtr<(std::string::String, std::string::String)>,
                            > = _func1_from_v654;
                            let v766: Vec<LrcPtr<(std::string::String, std::string::String)>> =
                                v653.into_iter()
                                    .map(|x| {
                                        Func1::new({
                                            let v763 = v763.clone();
                                            move |arg10_0040_3: (string, string)| {
                                                Spiral::closure76(v763.clone(), arg10_0040_3)
                                            }
                                        })(x.clone())
                                    })
                                    .collect::<Vec<_>>();
                            let v767: string =
                            string("std::collections::BTreeMap::from_iter(v766.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                            let v768: std::collections::BTreeMap<
                                std::string::String,
                                std::string::String,
                            > = std::collections::BTreeMap::from_iter(
                                v766.iter()
                                    .map(|x| x.as_ref())
                                    .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                            );
                            let v770: Result<std::string::String, serde_json::Error> =
                                serde_json::to_string(&v768);
                            let v773: std::string::String = v770.unwrap();
                            new_array(&[(
                                string("command_result"),
                                fable_library_rust::String_::fromString(v773),
                            )])
                        } else {
                            if (fable_library_rust::String_::fromString(v29.clone()))
                                == string("fable")
                            {
                                let v792: string = Spiral::method171();
                                let v795: &str = &*v792;
                                let v818: Option<std::string::String> =
                                    clap::ArgMatches::get_one(&v30.clone(), v795).cloned();
                                let v832: Spiral::US7 =
                                    defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v818));
                                let v839: std::string::String = match &v832 {
                                    Spiral::US7::US7_0(v832_0_0) => match &v832 {
                                        Spiral::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => panic!("{}", string("Option does not have a value."),),
                                };
                                let v841: string = fable_library_rust::String_::fromString(v839);
                                let v842: string = Spiral::method172();
                                let v845: &str = &*v842;
                                let v868: Option<std::string::String> =
                                    clap::ArgMatches::get_one(&v30.clone(), v845).cloned();
                                let v882: Spiral::US7 =
                                    defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v868));
                                let v892: Spiral::US5 = match &v882 {
                                    Spiral::US7::US7_0(v882_0_0) => {
                                        Spiral::US5::US5_0(fable_library_rust::String_::fromString(
                                            match &v882 {
                                                Spiral::US7::US7_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        ))
                                    }
                                    _ => Spiral::US5::US5_1,
                                };
                                new_array(&[(
                                    string("command_result"),
                                    match &v892 {
                                        Spiral::US5::US5_0(v892_0_0) => {
                                            let v894: clap::Command = Spiral::method0();
                                            let v896: Spiral::US25 = Spiral::method105(sprintf!(
                                                "_ {} --fs-path \"{}\"",
                                                match &v892 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                v841.clone()
                                            ));
                                            let v904: Array<string> =
                                                     match &v896 {
                                                         Spiral::US25::US25_0(v896_0_0)
                                                         => v896_0_0.clone(),
                                                         Spiral::US25::US25_1(v896_1_0)
                                                         =>
                                                         panic!("{}",
                                                                concat(new_array(&[string("resultm.get / Result value was Error: "),
                   v896_1_0.clone()])),),
                                                     };
                                            let v906: Vec<string> = v904.to_vec();
                                            let v908: bool = true;
                                            let _vec_map: Vec<_> = v906
                                                .into_iter()
                                                .map(|x| {
                                                    //;
                                                    let v910: string = x;
                                                    let v913: &str = &*v910;
                                                    let v937: std::string::String =
                                                        String::from(v913);
                                                    let v960: bool = true;
                                                    v937
                                                })
                                                .collect::<Vec<_>>();
                                            let v962: Vec<std::string::String> = _vec_map;
                                            let v965: std::pin::Pin<
                                                Box<
                                                    dyn std::future::Future<
                                                        Output = Result<string, string>,
                                                    >,
                                                >,
                                            > = Spiral::method20(
                                                v0_1.clone(),
                                                clap::Command::get_matches_from(v894, v962),
                                            );
                                            let v967: Result<string, string> = v965.await;
                                            v967.unwrap()
                                        }
                                        _ => string("{}"),
                                    },
                                )])
                            } else {
                                if (fable_library_rust::String_::fromString(v29.clone()))
                                    == string("dib")
                                {
                                    let v990: string = Spiral::method173();
                                    let v993: &str = &*v990;
                                    let v1016: Option<std::string::String> =
                                        clap::ArgMatches::get_one(&v30.clone(), v993).cloned();
                                    let v1018: Option<string> = map(Spiral::method174(), v1016);
                                    let v1032: string = v1018.unwrap();
                                    let v1033: string = Spiral::method181();
                                    let v1036: &str = &*v1033;
                                    let v1060: u8 = defaultValue(
                                        1_u8,
                                        clap::ArgMatches::get_one(&v30.clone(), v1036).cloned(),
                                    );
                                    let v1063: string = Spiral::method182();
                                    let v1066: &str = &*v1063;
                                    let v1089: Option<std::string::String> =
                                        clap::ArgMatches::get_one(&v30.clone(), v1066).cloned();
                                    let v1103: Spiral::US7 = defaultValue(
                                        Spiral::US7::US7_1,
                                        map(Spiral::method23(), v1089),
                                    );
                                    let patternInput_6: (i32, string) = Spiral::method183(
                                        match &v1103 {
                                            Spiral::US7::US7_0(v1103_0_0) => Spiral::US5::US5_0(
                                                fable_library_rust::String_::fromString(
                                                    match &v1103 {
                                                        Spiral::US7::US7_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                ),
                                            ),
                                            _ => Spiral::US5::US5_1,
                                        },
                                        v1060,
                                        v1032.clone(),
                                        1_u8,
                                    );
                                    let v1116: string = patternInput_6.1.clone();
                                    let v1115: i32 = patternInput_6.0.clone();
                                    let patternInput_9: (i32, string) = if (v1115) != 0_i32 {
                                        (v1115, v1116.clone())
                                    } else {
                                        let patternInput_7: (i32, string) = Spiral::method89(
                                            concat(new_array(&[
                                                string("jupyter nbconvert \""),
                                                v1032.clone(),
                                                string(
                                                    ".ipynb\" --to html --HTMLExporter.theme=dark",
                                                ),
                                            ])),
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
                                            None::<string>,
                                        );
                                        let v1128: string = patternInput_7.1.clone();
                                        let v1127: i32 = patternInput_7.0.clone();
                                        let v1131: () = {
                                            Spiral::closure79(v1128.clone(), v1127, ());
                                            ()
                                        };
                                        if (v1127) != 0_i32 {
                                            (
                                                v1127,
                                                concat(new_array(&[
                                                    string("repl_result: "),
                                                    v1116.clone(),
                                                    string("\n\njupyter_result: "),
                                                    v1128.clone(),
                                                ])),
                                            )
                                        } else {
                                            let patternInput_8:
                                                    (i32, string) =
                                                Spiral::method89(concat(new_array(&[string("pwsh -c \"$counter = 1; $path = \'"),
                                                                                    replace(v1032.clone(),
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
                                            let v1187: string = patternInput_8.1.clone();
                                            let v1186: i32 = patternInput_8.0.clone();
                                            let v1190: () = {
                                                Spiral::closure80(v1187.clone(), v1186, ());
                                                ()
                                            };
                                            let v1231: string = concat(new_array(&[
                                                v1032.clone(),
                                                string(".html"),
                                            ]));
                                            let v1235: Result<Vec<u8>, std::io::Error> =
                                                std::fs::read(&*v1231);
                                            let v1273: Vec<u8> = Spiral::method27(v1235.unwrap());
                                            let v1275: Result<
                                                std::string::String,
                                                std::string::FromUtf8Error,
                                            > = std::string::String::from_utf8(v1273);
                                            let v1278: std::string::String = v1275.unwrap();
                                            let v1315: string = replace(
                                                fable_library_rust::String_::fromString(v1278),
                                                string("\r\n"),
                                                string("\n"),
                                            );
                                            let v1316: string = concat(new_array(&[
                                                v1032.clone(),
                                                string(".html"),
                                            ]));
                                            std::fs::write(&*v1316, &*v1315).unwrap();
                                            {
                                                let v1319: string = concat(new_array(&[
                                                    v1032.clone(),
                                                    string(".ipynb"),
                                                ]));
                                                let v1323: Result<Vec<u8>, std::io::Error> =
                                                    std::fs::read(&*v1319);
                                                let v1361: Vec<u8> =
                                                    Spiral::method27(v1323.unwrap());
                                                let v1363: Result<
                                                    std::string::String,
                                                    std::string::FromUtf8Error,
                                                > = std::string::String::from_utf8(v1361);
                                                let v1366: std::string::String = v1363.unwrap();
                                                let v1404: string = replace(
                                                    replace(
                                                        fable_library_rust::String_::fromString(
                                                            v1366,
                                                        ),
                                                        string("\r\n"),
                                                        string("\n"),
                                                    ),
                                                    string("\\r\\n"),
                                                    string("\\n"),
                                                );
                                                let v1405: string =
                                                    concat(new_array(&[v1032, string(".ipynb")]));
                                                std::fs::write(&*v1405, &*v1404).unwrap();
                                                (v1186,
                                                 sprintf!("repl_result: {}\n\njupyter_result: {}\n\npwsh_replace_html_result: {}",
                                                          v1116, v1128,
                                                          v1187))
                                            }
                                        }
                                    };
                                    let v1412: string = patternInput_9.1.clone();
                                    let v1411: i32 = patternInput_9.0.clone();
                                    let v1415: () = {
                                        Spiral::closure81(v1412.clone(), v1411, ());
                                        ()
                                    };
                                    if (v1411) != 0_i32 {
                                        panic!(
                                            "{}",
                                            sprintf!(
                                                "spiral.run / dib / exit_code: {} / result: {}",
                                                v1411,
                                                v1412.clone()
                                            )
                                        );
                                    }
                                    new_array(&[(string("stdio"), v1412)])
                                } else {
                                    let patternInput_32: (
                                        Spiral::US5,
                                        Spiral::US5,
                                        Spiral::US5,
                                        Spiral::US5,
                                    ) = if (fable_library_rust::String_::fromString(v29.clone()))
                                        == string("rust")
                                    {
                                        let v1465: string = Spiral::method171();
                                        let v1468: &str = &*v1465;
                                        let v1491: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v30.clone(), v1468).cloned();
                                        let v1505: Spiral::US7 = defaultValue(
                                            Spiral::US7::US7_1,
                                            map(Spiral::method23(), v1491),
                                        );
                                        let v1512: std::string::String = match &v1505 {
                                            Spiral::US7::US7_0(v1505_0_0) => match &v1505 {
                                                Spiral::US7::US7_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => panic!(
                                                "{}",
                                                string("Option does not have a value."),
                                            ),
                                        };
                                        let v1514: string =
                                            fable_library_rust::String_::fromString(v1512);
                                        let v1515: string = Spiral::method25();
                                        let v1518: &str = &*v1515;
                                        let v1541: Option<Vec<std::string::String>> =
                                            clap::ArgMatches::get_many(&v30.clone(), v1518)
                                                .map(|x| x.cloned().into_iter().collect());
                                        let v1555: Spiral::US11 = defaultValue(
                                            Spiral::US11::US11_1,
                                            map(Spiral::method26(), v1541),
                                        );
                                        let v1561: Vec<std::string::String> =
                                            new_empty::<std::string::String>().to_vec();
                                        let v1564: Vec<std::string::String> = match &v1555 {
                                            Spiral::US11::US11_0(v1555_0_0) => match &v1555 {
                                                Spiral::US11::US11_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => v1561.clone(),
                                        };
                                        let v1565: string = Spiral::method192();
                                        let v1568: &str = &*v1565;
                                        let v1591: bool =
                                            clap::ArgMatches::get_flag(&v30.clone(), v1568);
                                        let v1592: string = Spiral::method193();
                                        let v1595: &str = &*v1592;
                                        let v1618: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v30.clone(), v1595).cloned();
                                        let v1632: Spiral::US7 = defaultValue(
                                            Spiral::US7::US7_1,
                                            map(Spiral::method23(), v1618),
                                        );
                                        let v1642: Spiral::US5 = match &v1632 {
                                            Spiral::US7::US7_0(v1632_0_0) => Spiral::US5::US5_0(
                                                fable_library_rust::String_::fromString(
                                                    match &v1632 {
                                                        Spiral::US7::US7_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                ),
                                            ),
                                            _ => Spiral::US5::US5_1,
                                        };
                                        let v1643: string = Spiral::method194();
                                        let v1646: &str = &*v1643;
                                        let v1669: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v30.clone(), v1646).cloned();
                                        let v1683: Spiral::US7 = defaultValue(
                                            Spiral::US7::US7_1,
                                            map(Spiral::method23(), v1669),
                                        );
                                        let v1693: Spiral::US5 = match &v1683 {
                                            Spiral::US7::US7_0(v1683_0_0) => Spiral::US5::US5_0(
                                                fable_library_rust::String_::fromString(
                                                    match &v1683 {
                                                        Spiral::US7::US7_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                ),
                                            ),
                                            _ => Spiral::US5::US5_1,
                                        };
                                        let v1702: Spiral::US36 =
                                            if let Spiral::US5::US5_0(v1642_0_0) = &v1642 {
                                                Spiral::US36::US36_0(Spiral::US37::US37_0(
                                                    v1642_0_0.clone(),
                                                ))
                                            } else {
                                                if let Spiral::US5::US5_0(v1693_0_0) = &v1693 {
                                                    Spiral::US36::US36_0(Spiral::US37::US37_1(
                                                        v1693_0_0.clone(),
                                                    ))
                                                } else {
                                                    Spiral::US36::US36_1
                                                }
                                            };
                                        let v1706: Result<Vec<u8>, std::io::Error> =
                                            std::fs::read(&*v1514);
                                        let v1744: Vec<u8> = Spiral::method27(v1706.unwrap());
                                        let v1746: Result<
                                            std::string::String,
                                            std::string::FromUtf8Error,
                                        > = std::string::String::from_utf8(v1744);
                                        let v1749: std::string::String = v1746.unwrap();
                                        let v1779: string =
                                            fable_library_rust::String_::fromString(v1749);
                                        let v1786: string = Spiral::method196(Spiral::method195(
                                            string("rs"),
                                            v1779.clone(),
                                            v1702.clone(),
                                        ));
                                        let v1788: Spiral::US5 =
                                            Spiral::method29(Spiral::method28());
                                        let v1794: Spiral::US5 = match &v1788 {
                                            Spiral::US5::US5_0(v1788_0_0) => Spiral::US5::US5_0(
                                                match &v1788 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            ),
                                            _ => Spiral::method29(string(
                                                "c:\\home\\git\\polyglot\\target\\Builder\\spiral",
                                            )),
                                        };
                                        let v1800: Spiral::US5 = match &v1794 {
                                            Spiral::US5::US5_0(v1794_0_0) => Spiral::US5::US5_0(
                                                match &v1794 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            ),
                                            _ => Spiral::method29(string("/workspaces")),
                                        };
                                        let v1804: string = match &v1800 {
                                            Spiral::US5::US5_0(v1800_0_0) => match &v1800 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => panic!(
                                                "{}",
                                                string("Option does not have a value."),
                                            ),
                                        };
                                        let v1818: string = Spiral::method30(
                                            if string("deps") == (Spiral::method49(v1804.clone())) {
                                                let v1811: Spiral::US5 = Spiral::method29(
                                                    Spiral::method35(v1804.clone())
                                                        .clone()
                                                        .unwrap(),
                                                );
                                                match &v1811 {
                                                    Spiral::US5::US5_0(v1811_0_0) => match &v1811 {
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
                                                v1804
                                            },
                                            string("polyglot"),
                                        );
                                        let v1821: string = toLower(Spiral::method28());
                                        let v1825: string = toLower(v1818);
                                        let v1833: Spiral::US13 =
                                            if startsWith3(v1821, v1825.clone(), false) {
                                                Spiral::US13::US13_1(v1825.clone())
                                            } else {
                                                Spiral::US13::US13_0(v1825)
                                            };
                                        let v1839: Result<string, string> = match &v1833 {
                                            Spiral::US13::US13_0(v1833_0_0) => {
                                                Ok::<string, string>(v1833_0_0.clone())
                                            }
                                            Spiral::US13::US13_1(v1833_1_0) => {
                                                Err::<string, string>(v1833_1_0.clone())
                                            }
                                        };
                                        let v1841: bool = true;
                                        let _result_unwrap_or_else = v1839.unwrap_or_else(|x| {
                                            //;
                                            let v1843: string = x;
                                            let v1845: bool = true;
                                            v1843
                                        });
                                        let v1847: string = _result_unwrap_or_else;
                                        let v1852: string = Spiral::method199(
                                            Spiral::US5::US5_0(v1786.clone()),
                                            string("spiral"),
                                            Spiral::US39::US39_0(Spiral::US38::US38_0),
                                            v1847.clone(),
                                        );
                                        let v1857: string = Spiral::method200(
                                            v1779,
                                            string("spiral"),
                                            LrcPtr::new(Spiral::UH2::UH2_0),
                                            LrcPtr::new(Spiral::UH2::UH2_1(
                                                string("Fable.Core"),
                                                LrcPtr::new(Spiral::UH2::UH2_0),
                                            )),
                                            v1852.clone(),
                                            v1847.clone(),
                                        );
                                        let v1859: string =
                                            Spiral::method30(v1852.clone(), string("../../.."));
                                        let v1861: string =
                                            Spiral::method30(v1859.clone(), string("Cargo.toml"));
                                        if (Spiral::method32(v1861.clone())) == false {
                                            let v1865: DateTime = DateTime::now();
                                            let v1885: string =
                                                toString(Spiral::method203(new_guid(), v1865));
                                            let v1910: string =
                                                append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                       (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                           v1885.clone(),
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
                                                                                           v1885,
                                                                                           string("\"")]))))),
                                                               string("\n"))),
                                                       string("path = \"spiral.rs\""));
                                            std::fs::write(&*v1861.clone(), &*v1910).unwrap();
                                            ()
                                        }
                                        {
                                            let v1913: string = Spiral::method30(
                                                v1852.clone(),
                                                string("Cargo.toml"),
                                            );
                                            if (Spiral::method32(v1913.clone())) == false {
                                                let v1917: DateTime = DateTime::now();
                                                let v1937: string =
                                                    toString(Spiral::method203(new_guid(), v1917));
                                                let v1962: string =
                                                    append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                           (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                               v1937.clone(),
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
                                                                                               v1937,
                                                                                               string("\"")]))))),
                                                                   string("\n"))),
                                                           string("path = \"spiral.rs\""));
                                                std::fs::write(&*v1913.clone(), &*v1962).unwrap();
                                                ()
                                            }
                                            {
                                                let v1966: string =
                                                    Spiral::method30(v1847.clone(),
                                                                     string("lib/rust/fable/fable_modules/fable-library-rust"));
                                                let v1968: string = Spiral::method30(
                                                    v1852.clone(),
                                                    string("fable_modules/fable-library-rust"),
                                                );
                                                Spiral::method208(v1966, v1968.clone());
                                                {
                                                    let patternInput_10: (i32, string) =
                                                        Spiral::method209(
                                                            v1702.clone(),
                                                            v1852.clone(),
                                                            string("rs"),
                                                            v1857,
                                                            v1833.clone(),
                                                        );
                                                    let v1970: string = patternInput_10.1.clone();
                                                    let v1969: i32 = patternInput_10.0.clone();
                                                    let patternInput_19: (
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                    ) = if (v1969) != 0_i32 {
                                                        let v1976: () = {
                                                            Spiral::closure84(
                                                                v1970.clone(),
                                                                v1969,
                                                                (),
                                                            );
                                                            ()
                                                        };
                                                        (
                                                            Spiral::US5::US5_0(string("rs")),
                                                            Spiral::US5::US5_1,
                                                            Spiral::US5::US5_1,
                                                            Spiral::US5::US5_0(v1970),
                                                        )
                                                    } else {
                                                        let v2096: Vec<std::string::String> =
                                                            if if let Spiral::US36::US36_1 = &v1702
                                                            {
                                                                true
                                                            } else {
                                                                false
                                                            } {
                                                                v1564.clone()
                                                            } else {
                                                                let v2021 = Spiral::method219();
                                                                let v2022: Vec<
                                                                    std::string::String,
                                                                > = Spiral::method220(
                                                                    v1564.clone(),
                                                                );
                                                                let v2024: Vec<
                                                                    std::string::String,
                                                                > = v2022
                                                                    .into_iter()
                                                                    .filter(|x| {
                                                                        v2021(x.clone().clone())
                                                                    })
                                                                    .collect::<Vec<_>>();
                                                                if (v2024.len() as i32) > 0_i32 {
                                                                    v1564.clone()
                                                                } else {
                                                                    let v2038: &str =
                                                                        &*string("near-sdk");
                                                                    let v2084: Array<
                                                                        std::string::String,
                                                                    > = new_array(&[String::from(
                                                                        v2038,
                                                                    )]);
                                                                    let v2087: Vec<
                                                                        std::string::String,
                                                                    > = Spiral::method221(
                                                                        v2084.to_vec(),
                                                                    );
                                                                    let v2088: Vec<
                                                                        std::string::String,
                                                                    > = Spiral::method222(v1564);
                                                                    let v2090: bool = true;
                                                                    let mut v2088 = v2088;
                                                                    let v2092: bool = true;
                                                                    v2088.extend(v2087);
                                                                    v2088
                                                                }
                                                            };
                                                        let v2098: bool = true;
                                                        let _vec_map : Vec<_> = v2096.into_iter().map(|x| { //;
                                                            let v2100:
                                                                    std::string::String =
                                                                x;
                                                            let v2102:
                                                                    string =
                                                                fable_library_rust::String_::fromString(v2100);
                                                            let v2117:
                                                                    string =
                                                                if contains(v2102.clone(),
                                                                            string("="))
                                                                   {
                                                                    v2102.clone()
                                                                } else {
                                                                    if endsWith3(v2102.clone(),
                                                                                 string("]"),
                                                                                 false)
                                                                       {
                                                                        concat(new_array(&[replace(v2102.clone(),
                                                                                                   string("["),
                                                                                                   string("={version=\'*\',features=[")),
                                                                                           string("}")]))
                                                                    } else {
                                                                        concat(new_array(&[v2102,
                                                                                           string("=\'*\'")]))
                                                                    }
                                                                };
                                                            let v2119: bool =
                                                                true; v2117 }).collect::<Vec<_>>();
                                                        let v2121: Vec<string> = _vec_map;
                                                        let v2123:
                                                                    Array<string> =
                                                                fable_library_rust::NativeArray_::array_from(v2121.clone());
                                                        let _let__v2124: LrcPtr<
                                                            dyn IEnumerable_1<string>,
                                                        > = delay(Func0::new({
                                                            let v2123 = v2123.clone();
                                                            move || {
                                                                map_1(
                                                                    Func1::new({
                                                                        let v2123 = v2123.clone();
                                                                        move |i_1: i32| {
                                                                            v2123[i_1].clone()
                                                                        }
                                                                    }),
                                                                    rangeNumeric(
                                                                        0_i32,
                                                                        1_i32,
                                                                        (get_Count(v2123.clone()))
                                                                            - 1_i32,
                                                                    ),
                                                                )
                                                            }
                                                        }));
                                                        let v2136: string = join(
                                                            Spiral::method63(),
                                                            toArray_1(_let__v2124),
                                                        );
                                                        let v2141: string = Spiral::method30(
                                                            v1852,
                                                            concat(new_array(&[
                                                                string("spiral"),
                                                                string("."),
                                                                string("rs"),
                                                            ])),
                                                        );
                                                        let v2145: Result<Vec<u8>, std::io::Error> =
                                                            std::fs::read(&*v2141.clone());
                                                        let v2183: Vec<u8> =
                                                            Spiral::method27(v2145.unwrap());
                                                        let v2185: Result<
                                                            std::string::String,
                                                            std::string::FromUtf8Error,
                                                        > = std::string::String::from_utf8(v2183);
                                                        let v2188: std::string::String =
                                                            v2185.unwrap();
                                                        let v2218: string =
                                                            fable_library_rust::String_::fromString(
                                                                v2188,
                                                            );
                                                        let v2225: string = append(
                                                            string("on_startup!"),
                                                            (Spiral::method223()),
                                                        );
                                                        let v2228: string = append(
                                                            string(" method0"),
                                                            (Spiral::method224()),
                                                        );
                                                        let v2236: bool = if contains(
                                                            v2218.clone(),
                                                            v2225.clone(),
                                                        ) {
                                                            (contains(v2218, v2228)) == false
                                                        } else {
                                                            false
                                                        };
                                                        let v2299:
                                                                    string =
                                                                append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                                                                                                       (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                                                                                           v1786.clone(),
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
                                                                                                                                                       (if !((v1702.clone())
                                                                                                                                                                 ==
                                                                                                                                                                 Spiral::US36::US36_1)
                                                                                                                                                           {
                                                                                                                                                            string("fable_library_rust = { workspace = true }")
                                                                                                                                                        } else {
                                                                                                                                                            append((append((append(string("fable_library_rust = { workspace = true, features = ["),
                                                                                                                                                                                   (if v2236
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
                                                                                                                       (v2136))),
                                                                                                               string("\n"))),
                                                                                                       string(""))),
                                                                                               string("\n"))),
                                                                                       (if if let Spiral::US36::US36_1
                                                                                                  =
                                                                                                  &v1702
                                                                                              {
                                                                                               true
                                                                                           } else {
                                                                                               false
                                                                                           }
                                                                                           {
                                                                                            append(string("[[bin]]\n"),
                                                                                                   (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                       v1786.clone(),
                                                                                                                       string("\"")]))))
                                                                                        } else {
                                                                                            string("[lib]\ncrate-type = [\"cdylib\"]")
                                                                                        }))),
                                                                               string("\n"))),
                                                                       string("path = \"spiral.rs\""));
                                                        let v2364:
                                                                    string =
                                                                append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append(string("cargo-features = [\"profile-rustflags\"]\n\n[workspace]\nresolver = \"2\"\nmembers = [\"packages/Rust/*\"]\n\n[workspace.dependencies.fable_library_rust]\n"),
                                                                                                                                                                                                                                                                                                       (concat(new_array(&[string("path = \""),
                                                                                                                                                                                                                                                                                                                           Spiral::method40(v1847.clone()),
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
                                                        Spiral::method64(v1913.clone(), v2299);
                                                        Spiral::method64(v1861, v2364);
                                                        {
                                                            let v2366: string = Spiral::method30(
                                                                v1968,
                                                                string("src/Range.rs"),
                                                            );
                                                            if Spiral::method32(v2366.clone()) {
                                                                let v2371: Result<
                                                                    Vec<u8>,
                                                                    std::io::Error,
                                                                > = std::fs::read(&*v2366.clone());
                                                                let v2409: Vec<u8> =
                                                                    Spiral::method27(
                                                                        v2371.unwrap(),
                                                                    );
                                                                let v2411: Result<
                                                                    std::string::String,
                                                                    std::string::FromUtf8Error,
                                                                > = std::string::String::from_utf8(
                                                                    v2409,
                                                                );
                                                                let v2414: std::string::String =
                                                                    v2411.unwrap();
                                                                Spiral::method64(v2366,
                                                                                     replace(replace(fable_library_rust::String_::fromString(v2414),
                                                                                                     string("use crate::String_::fromCharCode;"),
                                                                                                     string("use crate::String_::fromChar;")),
                                                                                             string("fromCharCode(c)"),
                                                                                             string("std::char::from_u32(c).unwrap()")))
                                                            }
                                                            {
                                                                let patternInput_11: (i32, string) =
                                                                    Spiral::method225(
                                                                        v1833.clone(),
                                                                        v1913.clone(),
                                                                        1_u8,
                                                                    );
                                                                let v2456: i32 =
                                                                    patternInput_11.0.clone();
                                                                if (v2456) != 0_i32 {
                                                                    let v2463: () = {
                                                                        Spiral::closure88(
                                                                            patternInput_11
                                                                                .1
                                                                                .clone(),
                                                                            v2456,
                                                                            (),
                                                                        );
                                                                        ()
                                                                    };
                                                                    ()
                                                                }
                                                                {
                                                                    let v2506: Result<
                                                                        Vec<u8>,
                                                                        std::io::Error,
                                                                    > = std::fs::read(
                                                                        &*v2141.clone(),
                                                                    );
                                                                    let v2544: Vec<u8> =
                                                                        Spiral::method27(
                                                                            v2506.unwrap(),
                                                                        );
                                                                    let v2546:
                                                                                Result<std::string::String,
                                                                                       std::string::FromUtf8Error> =
                                                                            std::string::String::from_utf8(v2544);
                                                                    let v2549: std::string::String =
                                                                        v2546.unwrap();
                                                                    let v2579:
                                                                                string =
                                                                            fable_library_rust::String_::fromString(v2549);
                                                                    let v2586:
                                                                                string =
                                                                            append(string("pub fn main() -> Result<(), String> "),
                                                                                   (Spiral::method231()));
                                                                    let v2632:
                                                                                string =
                                                                            append((append((if if let Spiral::US36::US36_1
                                                                                                      =
                                                                                                      &v1702
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
                                                                                                 &v1702
                                                                                             {
                                                                                              true
                                                                                          } else {
                                                                                              false
                                                                                          }
                                                                                          {
                                                                                           contains(v2579.clone(),
                                                                                                    append((v2225.clone()),
                                                                                                           string("Spiral::method0()")))
                                                                                       } else {
                                                                                           false
                                                                                       }
                                                                                       {
                                                                                        concat(new_array(&[v2586.clone(),
                                                                                                           string(" Ok(Spiral::method0()) }")]))
                                                                                    } else {
                                                                                        concat(new_array(&[v2586.clone(),
                                                                                                           string(" Ok(()) }")]))
                                                                                    }));
                                                                    let v2633: bool = contains(
                                                                        v2579.clone(),
                                                                        v2586,
                                                                    );
                                                                    let v2720: string = if v2633 {
                                                                        v2579.clone()
                                                                    } else {
                                                                        (if (if let Spiral::US36::US36_0(v1702_0_0)
                                                                                            =
                                                                                            &v1702
                                                                                        {
                                                                                         if let Spiral::US37::US37_1(v1702_1_0)
                                                                                                =
                                                                                                &v1702_0_0
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
                                                                                                    |v_5:
                                                                                                         string|
                                                                                                    Spiral::closure89((),
                                                                                                                      v_5))
                                                                                 } else {
                                                                                     let v2716:
                                                                                             string =
                                                                                         string("use fable_library_rust::DateTime_::DateTime;");
                                                                                     Func1::new({
                                                                                                    let v2716
                                                                                                        =
                                                                                                        v2716.clone();
                                                                                                    move
                                                                                                        |v_6:
                                                                                                             string|
                                                                                                        Spiral::closure91(v2716.clone(),
                                                                                                                          v_6)
                                                                                                })
                                                                                 })((if v2236
                                                                                        {
                                                                                         Func1::new(move
                                                                                                        |v_3:
                                                                                                             string|
                                                                                                        Spiral::closure89((),
                                                                                                                          v_3))
                                                                                     } else {
                                                                                         let v2708:
                                                                                                 string =
                                                                                             append(string("// "),
                                                                                                    (v2225.clone()));
                                                                                         Func1::new({
                                                                                                        let v2225
                                                                                                            =
                                                                                                            v2225.clone();
                                                                                                        let v2708
                                                                                                            =
                                                                                                            v2708.clone();
                                                                                                        move
                                                                                                            |v_4:
                                                                                                                 string|
                                                                                                            Spiral::closure90(v2225.clone(),
                                                                                                                              v2708.clone(),
                                                                                                                              v_4)
                                                                                                    })
                                                                                     })(replace(replace(replace(replace(replace(replace(replace(replace(replace(Spiral::method60(string("\\s\\sgetZero\\(\\);"),
                                                                                                                                                                                 string(" getZero::<()>();"),
                                                                                                                                                                                 Spiral::method60(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                                                                                                                  string(" defaultOf::<()>();"),
                                                                                                                                                                                                  replace(replace(concat(new_array(&[v2579,
                                                                                                                                                                                                                                     string("\n\n"),
                                                                                                                                                                                                                                     v2632,
                                                                                                                                                                                                                                     string("\n")])),
                                                                                                                                                                                                                  append(string("),)"),
                                                                                                                                                                                                                         (";".into())),
                                                                                                                                                                                                                  string("));")),
                                                                                                                                                                                                          append(string("},)"),
                                                                                                                                                                                                                 (";".into())),
                                                                                                                                                                                                          string("});")))),
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
                                                                    if (v2633) == false {
                                                                        Spiral::method64(
                                                                            v2141.clone(),
                                                                            v2720.clone(),
                                                                        );
                                                                    }
                                                                    {
                                                                        let v2726:
                                                                                    string =
                                                                                if (if let Spiral::US36::US36_1
                                                                                           =
                                                                                           &v1702
                                                                                       {
                                                                                        true
                                                                                    } else {
                                                                                        false
                                                                                    })
                                                                                       !=
                                                                                       true
                                                                                   {
                                                                                    concat(new_array(&[string("cargo +nightly-2024-07-14 build --release --target wasm32-unknown-unknown --manifest-path \""),
                                                                                                       v1913.clone(),
                                                                                                       string("\"")]))
                                                                                } else {
                                                                                    concat(new_array(&[string("cargo run --manifest-path \""),
                                                                                                       v1913,
                                                                                                       string("\"")]))
                                                                                };
                                                                        let v2739:
                                                                                    Array<(string,
                                                                                           string)> =
                                                                                if (if let Spiral::US36::US36_1
                                                                                           =
                                                                                           &v1702
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
                                                                        let v2750:
                                                                                    Result<string,
                                                                                           string> =
                                                                                match &v1833
                                                                                    {
                                                                                    Spiral::US13::US13_0(v1833_0_0)
                                                                                    =>
                                                                                    Ok::<string,
                                                                                         string>(v1833_0_0.clone()),
                                                                                    Spiral::US13::US13_1(v1833_1_0)
                                                                                    =>
                                                                                    Err::<string,
                                                                                          string>(v1833_1_0.clone()),
                                                                                };
                                                                        let patternInput_12:
                                                                                    (i32,
                                                                                     string) =
                                                                                Spiral::method89(v2726.clone(),
                                                                                                 None::<CancellationToken>,
                                                                                                 v2739.clone(),
                                                                                                 None::<Func1<(i32,
                                                                                                               string,
                                                                                                               bool),
                                                                                                              Arc<Async<()>>>>,
                                                                                                 None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                              ()>>,
                                                                                                 true,
                                                                                                 v2750.ok());
                                                                        let v2767: string =
                                                                            patternInput_12
                                                                                .1
                                                                                .clone();
                                                                        let v2766: i32 =
                                                                            patternInput_12
                                                                                .0
                                                                                .clone();
                                                                        let patternInput_18:
                                                                                    (Spiral::US5,
                                                                                     Spiral::US5,
                                                                                     Spiral::US5,
                                                                                     Spiral::US5) =
                                                                                if if let Spiral::US36::US36_1
                                                                                          =
                                                                                          &v1702
                                                                                      {
                                                                                       true
                                                                                   } else {
                                                                                       false
                                                                                   }
                                                                                   {
                                                                                    let v2769:
                                                                                            i32 =
                                                                                        get_Count(v2739.clone());
                                                                                    let v2770:
                                                                                            Array<string> =
                                                                                        new_init(&string(""),
                                                                                                 v2769);
                                                                                    let v2771:
                                                                                            LrcPtr<Spiral::Mut5> =
                                                                                        LrcPtr::new(Spiral::Mut5{l0:
                                                                                                                     MutCell::new(0_i32),});
                                                                                    while Spiral::method93(v2769,
                                                                                                           v2771.clone())
                                                                                          {
                                                                                        let v2773:
                                                                                                i32 =
                                                                                            v2771.l0.get().clone();
                                                                                        let patternInput_13:
                                                                                                (string,
                                                                                                 string) =
                                                                                            v2739[v2773].clone();
                                                                                        let v2776:
                                                                                                string =
                                                                                            sprintf!("$env:{}=\'\'{}\'\'",
                                                                                                     patternInput_13.0.clone(),
                                                                                                     patternInput_13.1.clone());
                                                                                        v2770.get_mut()[v2773
                                                                                                            as
                                                                                                            usize]
                                                                                            =
                                                                                            v2776;
                                                                                        {
                                                                                            let v2777:
                                                                                                    i32 =
                                                                                                (v2773)
                                                                                                    +
                                                                                                    1_i32;
                                                                                            v2771.l0.set(v2777);
                                                                                            ()
                                                                                        }
                                                                                    }
                                                                                    {
                                                                                        let v2796:
                                                                                                string =
                                                                                            concat(new_array(&[string("pwsh -c \'"),
                                                                                                               join(string(";"),
                                                                                                                    toArray_1(ofArray_1(new_array(&[join(string(";"),
                                                                                                                                                         toArray_1(ofArray_1(v2770.clone()))),
                                                                                                                                                    v2726])))),
                                                                                                               string("\'")]));
                                                                                        let patternInput_14:
                                                                                                (Spiral::US5,
                                                                                                 Spiral::US5,
                                                                                                 Spiral::US5,
                                                                                                 Spiral::US5) =
                                                                                            if (v2766)
                                                                                                   !=
                                                                                                   0_i32
                                                                                               {
                                                                                                let v2802:
                                                                                                        () =
                                                                                                    {
                                                                                                        Spiral::closure92(v1591,
                                                                                                                          v2141.clone(),
                                                                                                                          v2767.clone(),
                                                                                                                          v2766,
                                                                                                                          v2796.clone(),
                                                                                                                          ());
                                                                                                        ()
                                                                                                    };
                                                                                                (Spiral::US5::US5_0(string("rs")),
                                                                                                 Spiral::US5::US5_1,
                                                                                                 Spiral::US5::US5_1,
                                                                                                 Spiral::US5::US5_1)
                                                                                            } else {
                                                                                                let result_1:
                                                                                                        LrcPtr<MutCell<Spiral::US5>> =
                                                                                                    refCell(Spiral::US5::US5_1);
                                                                                                try_catch(||
                                                                                                              result_1.set(Spiral::closure71((),
                                                                                                                                             Spiral::closure93(v2767.clone(),
                                                                                                                                                               ()))),
                                                                                                          |ex_1:
                                                                                                               LrcPtr<Exception>|
                                                                                                              result_1.set(Spiral::closure95(v2141.clone(),
                                                                                                                                             v2767.clone(),
                                                                                                                                             v2796,
                                                                                                                                             ex_1.clone())));
                                                                                                {
                                                                                                    let v2850:
                                                                                                            Spiral::US5 =
                                                                                                        result_1.get().clone();
                                                                                                    let v2860:
                                                                                                            Option<string> =
                                                                                                        match &v2850
                                                                                                            {
                                                                                                            Spiral::US5::US5_0(v2850_0_0)
                                                                                                            =>
                                                                                                            Some(match &v2850
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
                                                                                                     Spiral::US5::US5_0(v2720.clone()),
                                                                                                     Spiral::US5::US5_0(v2141.clone()),
                                                                                                     Spiral::US5::US5_0(v2860.unwrap()))
                                                                                                }
                                                                                            };
                                                                                        (patternInput_14.0.clone(),
                                                                                         patternInput_14.1.clone(),
                                                                                         patternInput_14.2.clone(),
                                                                                         patternInput_14.3.clone())
                                                                                    }
                                                                                } else {
                                                                                    let v2871:
                                                                                            string =
                                                                                        sprintf!("target/spiral/{}/target/wasm32-unknown-unknown/release/spiral_{}.wasm",
                                                                                                 string("spiral"),
                                                                                                 v1786.clone());
                                                                                    let v2883:
                                                                                            string =
                                                                                        sprintf!("pwsh -c \"pwsh {} {} -Linux -EnvironmentVariables AUTOMATION={}`nNEAR_RPC_TIMEOUT_SECS=100\"",
                                                                                                 string("scripts/invoke-block.ps1"),
                                                                                                 sprintf!("\'deps/spiral/workspace/target/release/spiral_wasm -w {} -t Debug {}\'",
                                                                                                          v2871.clone(),
                                                                                                          if let Spiral::US36::US36_0(v1702_0_0)
                                                                                                                 =
                                                                                                                 &v1702
                                                                                                             {
                                                                                                              let v2872:
                                                                                                                      Spiral::US37 =
                                                                                                                  v1702_0_0.clone();
                                                                                                              match &v2872
                                                                                                                  {
                                                                                                                  Spiral::US37::US37_0(v2872_0_0)
                                                                                                                  =>
                                                                                                                  v2872_0_0.clone(),
                                                                                                                  Spiral::US37::US37_1(v2872_1_0)
                                                                                                                  =>
                                                                                                                  v2872_1_0.clone(),
                                                                                                              }
                                                                                                          } else {
                                                                                                              string("")
                                                                                                          }),
                                                                                                 Spiral::method3(string("AUTOMATION")));
                                                                                    let patternInput_17:
                                                                                            (Spiral::US5,
                                                                                             Spiral::US5,
                                                                                             Spiral::US5,
                                                                                             Spiral::US5) =
                                                                                        if (v2766)
                                                                                               ==
                                                                                               0_i32
                                                                                           {
                                                                                            let patternInput_15:
                                                                                                    (i32,
                                                                                                     string) =
                                                                                                Spiral::method89(v2883.clone(),
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
                                                                                                                 Some(v1847));
                                                                                            let v2895:
                                                                                                    string =
                                                                                                patternInput_15.1.clone();
                                                                                            let v2894:
                                                                                                    i32 =
                                                                                                patternInput_15.0.clone();
                                                                                            let patternInput_16:
                                                                                                    (Spiral::US5,
                                                                                                     Spiral::US5,
                                                                                                     Spiral::US5,
                                                                                                     Spiral::US5) =
                                                                                                if (v2894)
                                                                                                       ==
                                                                                                       0_i32
                                                                                                   {
                                                                                                    (Spiral::US5::US5_0(string("rs")),
                                                                                                     Spiral::US5::US5_0(v2720),
                                                                                                     Spiral::US5::US5_0(v2141.clone()),
                                                                                                     Spiral::US5::US5_0(v2895.clone()))
                                                                                                } else {
                                                                                                    let v2903:
                                                                                                            () =
                                                                                                        {
                                                                                                            Spiral::closure97(v1591,
                                                                                                                              v2141.clone(),
                                                                                                                              v2767.clone(),
                                                                                                                              v2895,
                                                                                                                              v2894,
                                                                                                                              ());
                                                                                                            ()
                                                                                                        };
                                                                                                    (Spiral::US5::US5_0(string("rs")),
                                                                                                     Spiral::US5::US5_1,
                                                                                                     Spiral::US5::US5_1,
                                                                                                     Spiral::US5::US5_1)
                                                                                                };
                                                                                            (patternInput_16.0.clone(),
                                                                                             patternInput_16.1.clone(),
                                                                                             patternInput_16.2.clone(),
                                                                                             patternInput_16.3.clone())
                                                                                        } else {
                                                                                            let v2954:
                                                                                                    () =
                                                                                                {
                                                                                                    Spiral::closure98(v1591,
                                                                                                                      v2141.clone(),
                                                                                                                      v2767,
                                                                                                                      v2766,
                                                                                                                      v2871,
                                                                                                                      v2883,
                                                                                                                      ());
                                                                                                    ()
                                                                                                };
                                                                                            (Spiral::US5::US5_0(string("rs")),
                                                                                             Spiral::US5::US5_1,
                                                                                             Spiral::US5::US5_1,
                                                                                             Spiral::US5::US5_1)
                                                                                        };
                                                                                    (patternInput_17.0.clone(),
                                                                                     patternInput_17.1.clone(),
                                                                                     patternInput_17.2.clone(),
                                                                                     patternInput_17.3.clone())
                                                                                };
                                                                        if v1591 {
                                                                            let v3011:
                                                                                        string =
                                                                                    if (if let Spiral::US36::US36_1
                                                                                               =
                                                                                               &v1702
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
                                                                            let v3014:
                                                                                        string =
                                                                                    Spiral::method30(v1859.clone(),
                                                                                                     sprintf!("target/{}/spiral_{}{}",
                                                                                                              v3011.clone(),
                                                                                                              v1786.clone(),
                                                                                                              string("")));
                                                                            let v3017:
                                                                                        string =
                                                                                    Spiral::method30(v1859.clone(),
                                                                                                     sprintf!("target/{}/spiral_{}{}",
                                                                                                              v3011.clone(),
                                                                                                              v1786.clone(),
                                                                                                              string(".wasm")));
                                                                            let v3020:
                                                                                        string =
                                                                                    Spiral::method30(v1859.clone(),
                                                                                                     sprintf!("target/{}/spiral_{}{}",
                                                                                                              v3011.clone(),
                                                                                                              v1786.clone(),
                                                                                                              string(".pdb")));
                                                                            let v3023:
                                                                                        string =
                                                                                    Spiral::method30(v1859.clone(),
                                                                                                     sprintf!("target/{}/spiral_{}{}",
                                                                                                              v3011.clone(),
                                                                                                              v1786.clone(),
                                                                                                              string(".exe")));
                                                                            let v3026:
                                                                                        string =
                                                                                    Spiral::method30(v1859,
                                                                                                     sprintf!("target/{}/spiral_{}{}",
                                                                                                              v3011,
                                                                                                              v1786,
                                                                                                              string(".d")));
                                                                            let v3027: bool =
                                                                                Spiral::method32(
                                                                                    v3014.clone(),
                                                                                );
                                                                            let v3028: bool =
                                                                                Spiral::method32(
                                                                                    v3017.clone(),
                                                                                );
                                                                            let v3029: bool =
                                                                                Spiral::method32(
                                                                                    v3020.clone(),
                                                                                );
                                                                            let v3030: bool =
                                                                                Spiral::method32(
                                                                                    v3023.clone(),
                                                                                );
                                                                            let v3031: bool =
                                                                                Spiral::method32(
                                                                                    v3026.clone(),
                                                                                );
                                                                            let v3034: () = {
                                                                                Spiral::closure99(
                                                                                    v2141,
                                                                                    v3026.clone(),
                                                                                    v3031,
                                                                                    v3023.clone(),
                                                                                    v3030,
                                                                                    v3020.clone(),
                                                                                    v3029,
                                                                                    v3017.clone(),
                                                                                    v3028,
                                                                                    v3014.clone(),
                                                                                    v3027,
                                                                                    (),
                                                                                );
                                                                                ()
                                                                            };
                                                                            let v3077: LrcPtr<
                                                                                Spiral::UH4,
                                                                            > = if v3027 {
                                                                                LrcPtr::new(Spiral::UH4::UH4_1(v3014,
                                                                                                                       v3027,
                                                                                                                       LrcPtr::new(Spiral::UH4::UH4_0)))
                                                                            } else {
                                                                                LrcPtr::new(Spiral::UH4::UH4_0)
                                                                            };
                                                                            let v3079: LrcPtr<
                                                                                Spiral::UH4,
                                                                            > = if v3028 {
                                                                                LrcPtr::new(Spiral::UH4::UH4_1(v3017,
                                                                                                                       v3028,
                                                                                                                       v3077.clone()))
                                                                            } else {
                                                                                v3077
                                                                            };
                                                                            let v3081: LrcPtr<
                                                                                Spiral::UH4,
                                                                            > = if v3029 {
                                                                                LrcPtr::new(Spiral::UH4::UH4_1(v3020,
                                                                                                                       v3029,
                                                                                                                       v3079.clone()))
                                                                            } else {
                                                                                v3079
                                                                            };
                                                                            let v3083: LrcPtr<
                                                                                Spiral::UH4,
                                                                            > = if v3030 {
                                                                                LrcPtr::new(Spiral::UH4::UH4_1(v3023,
                                                                                                                       v3030,
                                                                                                                       v3081.clone()))
                                                                            } else {
                                                                                v3081
                                                                            };
                                                                            Spiral::method242(
                                                                                if v3031 {
                                                                                    LrcPtr::new(Spiral::UH4::UH4_1(v3026,
                                                                                                                                     v3031,
                                                                                                                                     v3083.clone()))
                                                                                } else {
                                                                                    v3083
                                                                                },
                                                                            )
                                                                        }
                                                                        (
                                                                            patternInput_18
                                                                                .0
                                                                                .clone(),
                                                                            patternInput_18
                                                                                .1
                                                                                .clone(),
                                                                            patternInput_18
                                                                                .2
                                                                                .clone(),
                                                                            patternInput_18
                                                                                .3
                                                                                .clone(),
                                                                        )
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    };
                                                    (
                                                        patternInput_19.0.clone(),
                                                        patternInput_19.1.clone(),
                                                        patternInput_19.2.clone(),
                                                        patternInput_19.3.clone(),
                                                    )
                                                }
                                            }
                                        }
                                    } else {
                                        let patternInput_31: (
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                        ) = if (fable_library_rust::String_::fromString(
                                            v29.clone(),
                                        )) == string("typescript")
                                        {
                                            let v3093: string = Spiral::method171();
                                            let v3096: &str = &*v3093;
                                            let v3119: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v30.clone(), v3096)
                                                    .cloned();
                                            let v3133: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v3119),
                                            );
                                            let v3140: std::string::String = match &v3133 {
                                                Spiral::US7::US7_0(v3133_0_0) => match &v3133 {
                                                    Spiral::US7::US7_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => panic!(
                                                    "{}",
                                                    string("Option does not have a value."),
                                                ),
                                            };
                                            let v3142: string =
                                                fable_library_rust::String_::fromString(v3140);
                                            let v3143: string = Spiral::method25();
                                            let v3146: &str = &*v3143;
                                            let v3169: Option<Vec<std::string::String>> =
                                                clap::ArgMatches::get_many(&v30.clone(), v3146)
                                                    .map(|x| x.cloned().into_iter().collect());
                                            let v3183: Spiral::US11 = defaultValue(
                                                Spiral::US11::US11_1,
                                                map(Spiral::method26(), v3169),
                                            );
                                            let v3189: Vec<std::string::String> =
                                                new_empty::<std::string::String>().to_vec();
                                            let v3192: Vec<std::string::String> = match &v3183 {
                                                Spiral::US11::US11_0(v3183_0_0) => match &v3183 {
                                                    Spiral::US11::US11_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => v3189.clone(),
                                            };
                                            let v3196: Result<Vec<u8>, std::io::Error> =
                                                std::fs::read(&*v3142);
                                            let v3234: Vec<u8> = Spiral::method27(v3196.unwrap());
                                            let v3236: Result<
                                                std::string::String,
                                                std::string::FromUtf8Error,
                                            > = std::string::String::from_utf8(v3234);
                                            let v3239: std::string::String = v3236.unwrap();
                                            let v3269: string =
                                                fable_library_rust::String_::fromString(v3239);
                                            let v3278: string = Spiral::method196(sprintf!(
                                                "{:?}",
                                                (string("ts"), v3269.clone())
                                            ));
                                            let v3280: Spiral::US5 =
                                                Spiral::method29(Spiral::method28());
                                            let v3286: Spiral::US5 =
                                                    match &v3280 {
                                                        Spiral::US5::US5_0(v3280_0_0)
                                                        =>
                                                        Spiral::US5::US5_0(match &v3280
                                                                               {
                                                                               Spiral::US5::US5_0(x)
                                                                               =>
                                                                               x.clone(),
                                                                               _
                                                                               =>
                                                                               unreachable!(),
                                                                           }.clone()),
                                                        _ =>
                                                        Spiral::method29(string("c:\\home\\git\\polyglot\\target\\Builder\\spiral")),
                                                    };
                                            let v3292: Spiral::US5 = match &v3286 {
                                                Spiral::US5::US5_0(v3286_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        match &v3286 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => Spiral::method29(string("/workspaces")),
                                            };
                                            let v3296: string = match &v3292 {
                                                Spiral::US5::US5_0(v3292_0_0) => match &v3292 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => panic!(
                                                    "{}",
                                                    string("Option does not have a value."),
                                                ),
                                            };
                                            let v3310: string = Spiral::method30(
                                                if string("deps")
                                                    == (Spiral::method49(v3296.clone()))
                                                {
                                                    let v3303: Spiral::US5 = Spiral::method29(
                                                        Spiral::method35(v3296.clone())
                                                            .clone()
                                                            .unwrap(),
                                                    );
                                                    match &v3303 {
                                                        Spiral::US5::US5_0(v3303_0_0) => {
                                                            match &v3303 {
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
                                                    v3296
                                                },
                                                string("polyglot"),
                                            );
                                            let v3313: string = toLower(Spiral::method28());
                                            let v3317: string = toLower(v3310);
                                            let v3325: Spiral::US13 =
                                                if startsWith3(v3313, v3317.clone(), false) {
                                                    Spiral::US13::US13_1(v3317.clone())
                                                } else {
                                                    Spiral::US13::US13_0(v3317)
                                                };
                                            let v3331: Result<string, string> = match &v3325 {
                                                Spiral::US13::US13_0(v3325_0_0) => {
                                                    Ok::<string, string>(v3325_0_0.clone())
                                                }
                                                Spiral::US13::US13_1(v3325_1_0) => {
                                                    Err::<string, string>(v3325_1_0.clone())
                                                }
                                            };
                                            let v3333: bool = true;
                                            let _result_unwrap_or_else =
                                                v3331.unwrap_or_else(|x| {
                                                    //;
                                                    let v3335: string = x;
                                                    let v3337: bool = true;
                                                    v3335
                                                });
                                            let v3339: string = _result_unwrap_or_else;
                                            let v3344: string = Spiral::method199(
                                                Spiral::US5::US5_0(v3278.clone()),
                                                string("spiral"),
                                                Spiral::US39::US39_0(Spiral::US38::US38_1),
                                                v3339.clone(),
                                            );
                                            let v3349: string = Spiral::method200(
                                                v3269,
                                                string("spiral"),
                                                LrcPtr::new(Spiral::UH2::UH2_0),
                                                LrcPtr::new(Spiral::UH2::UH2_1(
                                                    string("Fable.Core"),
                                                    LrcPtr::new(Spiral::UH2::UH2_0),
                                                )),
                                                v3344.clone(),
                                                v3339.clone(),
                                            );
                                            let v3351: string = Spiral::method30(
                                                v3339.clone(),
                                                string("lib/typescript/fable/fable_modules"),
                                            );
                                            let v3352: string = concat(new_array(&[
                                                string("fable-library-"),
                                                string("ts"),
                                            ]));
                                            let v3353: string = Spiral::method247(v3352.clone());
                                            let v3355: async_walkdir::WalkDir =
                                                async_walkdir::WalkDir::new(&*v3351.clone());
                                            let v3358: async_walkdir::WalkDir =
                                                async_walkdir::WalkDir::filter(v3355, move |x| {
                                                    Func1::new({
                                                        let v3352 = v3352.clone();
                                                        move |v_9: async_walkdir::DirEntry| {
                                                            Spiral::closure103(v3352.clone(), v_9)
                                                        }
                                                    })(
                                                        x
                                                    )
                                                });
                                            let v3359 = Spiral::method251(v3353);
                                            let v3361 = futures::stream::StreamExt::filter_map(
                                                v3358,
                                                |x| async { v3359(x) },
                                            );
                                            let v3363: std::pin::Pin<
                                                Box<
                                                    dyn std::future::Future<
                                                        Output = Vec<(string, string)>,
                                                    >,
                                                >,
                                            > = Box::pin(futures::stream::StreamExt::collect(
                                                v3361,
                                            ));
                                            let v3365: Vec<(string, string)> = v3363.await;
                                            let v3367: rayon::vec::IntoIter<(string, string)> =
                                                rayon::iter::IntoParallelIterator::into_par_iter(
                                                    v3365,
                                                );
                                            let v3370: rayon::iter::Map<
                                                rayon::vec::IntoIter<(string, string)>,
                                                _,
                                            > = rayon::iter::ParallelIterator::map(v3367, |x| {
                                                Func1::new(
                                                    move |arg10_0040_14: (string, string)| {
                                                        Spiral::closure111((), arg10_0040_14)
                                                    },
                                                )(x)
                                            });
                                            let v3372: Vec<(string, string)> =
                                                rayon::iter::ParallelIterator::collect(v3370);
                                            let v3375: Option<(string, string)> = tryItem(
                                                0_i32,
                                                fable_library_rust::NativeArray_::array_from(
                                                    v3372.clone(),
                                                ),
                                            );
                                            let v3390: Spiral::US48 = defaultValue(
                                                Spiral::US48::US48_1,
                                                map(Spiral::method256(), v3375),
                                            );
                                            let v3396: () = {
                                                Spiral::closure113(v3390.clone(), ());
                                                ()
                                            };
                                            Spiral::method259(
                                                v3344.clone(),
                                                v3351.clone(),
                                                v3390.clone(),
                                            );
                                            {
                                                let patternInput_20: (i32, string) =
                                                    Spiral::method209(
                                                        Spiral::US36::US36_1,
                                                        v3344.clone(),
                                                        string("ts"),
                                                        v3349,
                                                        v3325.clone(),
                                                    );
                                                let v3438: string = patternInput_20.1.clone();
                                                let v3437: i32 = patternInput_20.0.clone();
                                                Spiral::method259(
                                                    v3344.clone(),
                                                    v3351,
                                                    v3390.clone(),
                                                );
                                                {
                                                    let patternInput_24: (
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                    ) = if (v3437) != 0_i32 {
                                                        let v3444: () = {
                                                            Spiral::closure114(
                                                                v3438.clone(),
                                                                v3437,
                                                                (),
                                                            );
                                                            ()
                                                        };
                                                        (
                                                            Spiral::US5::US5_0(string("ts")),
                                                            Spiral::US5::US5_1,
                                                            Spiral::US5::US5_1,
                                                            Spiral::US5::US5_0(v3438),
                                                        )
                                                    } else {
                                                        let v3489: bool = true;
                                                        let _vec_map : Vec<_> = v3192.into_iter().map(|x| { //;
                                                                let v3491:
                                                                        std::string::String =
                                                                    x;
                                                                let v3493:
                                                                        string =
                                                                    fable_library_rust::String_::fromString(v3491);
                                                                let v3499:
                                                                        string =
                                                                    if contains(v3493.clone(),
                                                                                string("="))
                                                                       {
                                                                        v3493.clone()
                                                                    } else {
                                                                        concat(new_array(&[string("\""),
                                                                                           v3493,
                                                                                           string("\":\"*\"")]))
                                                                    };
                                                                let v3501:
                                                                        bool =
                                                                    true; v3499 }).collect::<Vec<_>>();
                                                        let v3503: Vec<string> = _vec_map;
                                                        let v3505:
                                                                        Array<string> =
                                                                    fable_library_rust::NativeArray_::array_from(v3503.clone());
                                                        let v3518: string = join(
                                                            string(",\n"),
                                                            toArray_1(delay(Func0::new({
                                                                let v3505 = v3505.clone();
                                                                move || {
                                                                    map_1(
                                                                        Func1::new({
                                                                            let v3505 =
                                                                                v3505.clone();
                                                                            move |i_2: i32| {
                                                                                v3505[i_2].clone()
                                                                            }
                                                                        }),
                                                                        rangeNumeric(
                                                                            0_i32,
                                                                            1_i32,
                                                                            (get_Count(
                                                                                v3505.clone(),
                                                                            )) - 1_i32,
                                                                        ),
                                                                    )
                                                                }
                                                            }))),
                                                        );
                                                        let v3534:
                                                                        string =
                                                                    append((append((append((append((append((append((append(string("{"),
                                                                                                                           (concat(new_array(&[string("  \"name\": \"spiral_"),
                                                                                                                                               v3278,
                                                                                                                                               string("\",")]))))),
                                                                                                                   string("  \"dependencies\": {"))),
                                                                                                           (v3518))),
                                                                                                   string("  },"))),
                                                                                           string("    \"devDependencies\": {"))),
                                                                                   string("  },"))),
                                                                           string("}"));
                                                        let v3536: string = Spiral::method30(
                                                            v3344.clone(),
                                                            string("package.json"),
                                                        );
                                                        let v3539: string = Spiral::method30(
                                                            Spiral::method30(
                                                                v3344.clone(),
                                                                string("../.."),
                                                            ),
                                                            string("package.json"),
                                                        );
                                                        Spiral::method64(v3536, v3534);
                                                        Spiral::method64(v3539, string(""));
                                                        {
                                                            let v3542: string = Spiral::method30(
                                                                v3344,
                                                                concat(new_array(&[
                                                                    string("spiral"),
                                                                    string("."),
                                                                    string("ts"),
                                                                ])),
                                                            );
                                                            let v3545: () = {
                                                                Spiral::closure115(
                                                                    v3542.clone(),
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            let v3588: Result<
                                                                Vec<u8>,
                                                                std::io::Error,
                                                            > = std::fs::read(&*v3542.clone());
                                                            let v3626: Vec<u8> =
                                                                Spiral::method27(v3588.unwrap());
                                                            let v3628: Result<
                                                                std::string::String,
                                                                std::string::FromUtf8Error,
                                                            > = std::string::String::from_utf8(
                                                                v3626,
                                                            );
                                                            let v3631: std::string::String =
                                                                v3628.unwrap();
                                                            let v3661:
                                                                            string =
                                                                        fable_library_rust::String_::fromString(v3631);
                                                            let v3667: bool = contains(
                                                                v3661.clone(),
                                                                string(
                                                                    "// spiral.process_typescript",
                                                                ),
                                                            );
                                                            let v3676: string = if v3667 {
                                                                v3661.clone()
                                                            } else {
                                                                Spiral::method60(string("\\s\\sdefaultOf\\(\\);"),
                                                                                             string(" defaultOf::<()>();"),
                                                                                             replace(v3661,
                                                                                                     sprintf!("\"./fable_modules/fable-library-ts.{}/",
                                                                                                              v3390.clone()),
                                                                                                     sprintf!("\"{}/lib/typescript/fable/fable_modules/fable-library-ts.{}/",
                                                                                                              v3339,
                                                                                                              v3390)))
                                                            };
                                                            if (v3667) == false {
                                                                Spiral::method64(v3542.clone(),
                                                                                         concat(new_array(&[v3676.clone(),
                                                                                                            string("\n\n"),
                                                                                                            string("// spiral.process_typescript"),
                                                                                                            string("\n")])));
                                                            }
                                                            {
                                                                let v3679: string =
                                                                    concat(new_array(&[
                                                                        string("bun run \""),
                                                                        v3542.clone(),
                                                                        string("\""),
                                                                    ]));
                                                                let v3681: string =
                                                                    Spiral::method3(string("PATH"));
                                                                let v3717: Spiral::US5 = if (v3681
                                                                    .clone())
                                                                    == string("")
                                                                {
                                                                    Spiral::US5::US5_1
                                                                } else {
                                                                    Spiral::US5::US5_0(concat(
                                                                        new_array(&[
                                                                            string("~/.bun/bin"),
                                                                            if cfg!(windows) {
                                                                                string(";")
                                                                            } else {
                                                                                string(":")
                                                                            },
                                                                            v3681,
                                                                        ]),
                                                                    ))
                                                                };
                                                                let v3732:
                                                                                Array<(string,
                                                                                       string)> =
                                                                            toArray(Spiral::method264(Spiral::method263(match &v3717
                                                                                                                            {
                                                                                                                            Spiral::US5::US5_0(v3717_0_0)
                                                                                                                            =>
                                                                                                                            LrcPtr::new(Spiral::UH5::UH5_1(string("PATH"),
                                                                                                                                                           match &v3717
                                                                                                                                                               {
                                                                                                                                                               Spiral::US5::US5_0(x)
                                                                                                                                                               =>
                                                                                                                                                               x.clone(),
                                                                                                                                                               _
                                                                                                                                                               =>
                                                                                                                                                               unreachable!(),
                                                                                                                                                           }.clone(),
                                                                                                                                                           LrcPtr::new(Spiral::UH5::UH5_0))),
                                                                                                                            _
                                                                                                                            =>
                                                                                                                            LrcPtr::new(Spiral::UH5::UH5_0),
                                                                                                                        },
                                                                                                                        LrcPtr::new(Spiral::UH5::UH5_1(string("TRACE_LEVEL"),
                                                                                                                                                       string("Verbose"),
                                                                                                                                                       LrcPtr::new(Spiral::UH5::UH5_0)))),
                                                                                                      empty::<(string,
                                                                                                               string)>()));
                                                                let v3745: Result<string, string> =
                                                                    match &v3325 {
                                                                        Spiral::US13::US13_0(
                                                                            v3325_0_0,
                                                                        ) => Ok::<string, string>(
                                                                            v3325_0_0.clone(),
                                                                        ),
                                                                        Spiral::US13::US13_1(
                                                                            v3325_1_0,
                                                                        ) => Err::<string, string>(
                                                                            v3325_1_0.clone(),
                                                                        ),
                                                                    };
                                                                let patternInput_21:
                                                                                (i32,
                                                                                 string) =
                                                                            Spiral::method89(v3679.clone(),
                                                                                             None::<CancellationToken>,
                                                                                             v3732.clone(),
                                                                                             None::<Func1<(i32,
                                                                                                           string,
                                                                                                           bool),
                                                                                                          Arc<Async<()>>>>,
                                                                                             None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                          ()>>,
                                                                                             true,
                                                                                             v3745.ok());
                                                                let v3762: string =
                                                                    patternInput_21.1.clone();
                                                                let v3761: i32 =
                                                                    patternInput_21.0.clone();
                                                                let v3763: i32 =
                                                                    get_Count(v3732.clone());
                                                                let v3764: Array<string> =
                                                                    new_init(&string(""), v3763);
                                                                let v3765: LrcPtr<Spiral::Mut5> =
                                                                    LrcPtr::new(Spiral::Mut5 {
                                                                        l0: MutCell::new(0_i32),
                                                                    });
                                                                while Spiral::method93(
                                                                    v3763,
                                                                    v3765.clone(),
                                                                ) {
                                                                    let v3767: i32 =
                                                                        v3765.l0.get().clone();
                                                                    let patternInput_22: (
                                                                        string,
                                                                        string,
                                                                    ) = v3732[v3767].clone();
                                                                    let v3770: string = sprintf!(
                                                                        "$env:{}=\'\'{}\'\'",
                                                                        patternInput_22.0.clone(),
                                                                        patternInput_22.1.clone()
                                                                    );
                                                                    v3764.get_mut()
                                                                        [v3767 as usize] = v3770;
                                                                    {
                                                                        let v3771: i32 =
                                                                            (v3767) + 1_i32;
                                                                        v3765.l0.set(v3771);
                                                                        ()
                                                                    }
                                                                }
                                                                {
                                                                    let v3781: string = sprintf!(
                                                                        "pwsh -c \'{}; {}\'",
                                                                        join(
                                                                            string(";"),
                                                                            toArray_1(ofArray_1(
                                                                                v3764.clone()
                                                                            ))
                                                                        ),
                                                                        v3679
                                                                    );
                                                                    let patternInput_23: (
                                                                        Spiral::US5,
                                                                        Spiral::US5,
                                                                        Spiral::US5,
                                                                        Spiral::US5,
                                                                    ) = if (v3761) == 0_i32 {
                                                                        let result_2: LrcPtr<
                                                                            MutCell<Spiral::US5>,
                                                                        > = refCell(
                                                                            Spiral::US5::US5_1,
                                                                        );
                                                                        try_catch(||
                                                                                                  result_2.set(Spiral::closure71((),
                                                                                                                                 Spiral::closure116(v3762.clone(),
                                                                                                                                                    ()))),
                                                                                              |ex_2:
                                                                                                   LrcPtr<Exception>|
                                                                                                  result_2.set(Spiral::closure117(v3542.clone(),
                                                                                                                                  v3762.clone(),
                                                                                                                                  v3781.clone(),
                                                                                                                                  ex_2.clone())));
                                                                        {
                                                                            let v3787: Spiral::US5 =
                                                                                result_2
                                                                                    .get()
                                                                                    .clone();
                                                                            let v3797:
                                                                                                Option<string> =
                                                                                            match &v3787
                                                                                                {
                                                                                                Spiral::US5::US5_0(v3787_0_0)
                                                                                                =>
                                                                                                Some(match &v3787
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
                                                                            (
                                                                                Spiral::US5::US5_0(
                                                                                    string("ts"),
                                                                                ),
                                                                                Spiral::US5::US5_0(
                                                                                    v3676,
                                                                                ),
                                                                                Spiral::US5::US5_0(
                                                                                    v3542.clone(),
                                                                                ),
                                                                                Spiral::US5::US5_0(
                                                                                    v3797.unwrap(),
                                                                                ),
                                                                            )
                                                                        }
                                                                    } else {
                                                                        let v3806: () = {
                                                                            Spiral::closure119(
                                                                                v3542,
                                                                                v3762,
                                                                                v3761,
                                                                                v3781,
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
                                                                        patternInput_23.0.clone(),
                                                                        patternInput_23.1.clone(),
                                                                        patternInput_23.2.clone(),
                                                                        patternInput_23.3.clone(),
                                                                    )
                                                                }
                                                            }
                                                        }
                                                    };
                                                    (
                                                        patternInput_24.0.clone(),
                                                        patternInput_24.1.clone(),
                                                        patternInput_24.2.clone(),
                                                        patternInput_24.3.clone(),
                                                    )
                                                }
                                            }
                                        } else {
                                            let patternInput_30: (
                                                Spiral::US5,
                                                Spiral::US5,
                                                Spiral::US5,
                                                Spiral::US5,
                                            ) = if (fable_library_rust::String_::fromString(
                                                v29.clone(),
                                            )) == string("python")
                                            {
                                                let v3861: string = Spiral::method171();
                                                let v3864: &str = &*v3861;
                                                let v3887: Option<std::string::String> =
                                                    clap::ArgMatches::get_one(&v30.clone(), v3864)
                                                        .cloned();
                                                let v3901: Spiral::US7 = defaultValue(
                                                    Spiral::US7::US7_1,
                                                    map(Spiral::method23(), v3887),
                                                );
                                                let v3908: std::string::String = match &v3901 {
                                                    Spiral::US7::US7_0(v3901_0_0) => match &v3901 {
                                                        Spiral::US7::US7_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => panic!(
                                                        "{}",
                                                        string("Option does not have a value."),
                                                    ),
                                                };
                                                let v3910: string =
                                                    fable_library_rust::String_::fromString(v3908);
                                                let v3911: string = Spiral::method25();
                                                let v3914: &str = &*v3911;
                                                let v3937: Option<Vec<std::string::String>> =
                                                    clap::ArgMatches::get_many(&v30.clone(), v3914)
                                                        .map(|x| x.cloned().into_iter().collect());
                                                let v3951: Spiral::US11 = defaultValue(
                                                    Spiral::US11::US11_1,
                                                    map(Spiral::method26(), v3937),
                                                );
                                                let v3957: Vec<std::string::String> =
                                                    new_empty::<std::string::String>().to_vec();
                                                let v3960: Vec<std::string::String> = match &v3951 {
                                                    Spiral::US11::US11_0(v3951_0_0) => match &v3951
                                                    {
                                                        Spiral::US11::US11_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => v3957.clone(),
                                                };
                                                let v3961: bool = if let Spiral::US0::US0_0 = &v0_1
                                                {
                                                    true
                                                } else {
                                                    false
                                                };
                                                let v3965: Result<Vec<u8>, std::io::Error> =
                                                    std::fs::read(&*v3910);
                                                let v4003: Vec<u8> =
                                                    Spiral::method27(v3965.unwrap());
                                                let v4005: Result<
                                                    std::string::String,
                                                    std::string::FromUtf8Error,
                                                > = std::string::String::from_utf8(v4003);
                                                let v4008: std::string::String = v4005.unwrap();
                                                let v4038: string =
                                                    fable_library_rust::String_::fromString(v4008);
                                                let v4047: string = Spiral::method196(sprintf!(
                                                    "{:?}",
                                                    (string("py"), v4038.clone())
                                                ));
                                                let v4049: Spiral::US5 =
                                                    Spiral::method29(Spiral::method28());
                                                let v4055:
                                                                Spiral::US5 =
                                                            match &v4049 {
                                                                Spiral::US5::US5_0(v4049_0_0)
                                                                =>
                                                                Spiral::US5::US5_0(match &v4049
                                                                                       {
                                                                                       Spiral::US5::US5_0(x)
                                                                                       =>
                                                                                       x.clone(),
                                                                                       _
                                                                                       =>
                                                                                       unreachable!(),
                                                                                   }.clone()),
                                                                _ =>
                                                                Spiral::method29(string("c:\\home\\git\\polyglot\\target\\Builder\\spiral")),
                                                            };
                                                let v4061: Spiral::US5 = match &v4055 {
                                                    Spiral::US5::US5_0(v4055_0_0) => {
                                                        Spiral::US5::US5_0(
                                                            match &v4055 {
                                                                Spiral::US5::US5_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => Spiral::method29(string("/workspaces")),
                                                };
                                                let v4065: string = match &v4061 {
                                                    Spiral::US5::US5_0(v4061_0_0) => match &v4061 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => panic!(
                                                        "{}",
                                                        string("Option does not have a value."),
                                                    ),
                                                };
                                                let v4079: string = Spiral::method30(
                                                    if string("deps")
                                                        == (Spiral::method49(v4065.clone()))
                                                    {
                                                        let v4072: Spiral::US5 = Spiral::method29(
                                                            Spiral::method35(v4065.clone())
                                                                .clone()
                                                                .unwrap(),
                                                        );
                                                        match &v4072 {
                                                            Spiral::US5::US5_0(v4072_0_0) => {
                                                                match &v4072 {
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
                                                        v4065
                                                    },
                                                    string("polyglot"),
                                                );
                                                let v4082: string = toLower(Spiral::method28());
                                                let v4086: string = toLower(v4079);
                                                let v4094: Spiral::US13 =
                                                    if startsWith3(v4082, v4086.clone(), false) {
                                                        Spiral::US13::US13_1(v4086.clone())
                                                    } else {
                                                        Spiral::US13::US13_0(v4086)
                                                    };
                                                let v4100: Result<string, string> = match &v4094 {
                                                    Spiral::US13::US13_0(v4094_0_0) => {
                                                        Ok::<string, string>(v4094_0_0.clone())
                                                    }
                                                    Spiral::US13::US13_1(v4094_1_0) => {
                                                        Err::<string, string>(v4094_1_0.clone())
                                                    }
                                                };
                                                let v4102: bool = true;
                                                let _result_unwrap_or_else =
                                                    v4100.unwrap_or_else(|x| {
                                                        //;
                                                        let v4104: string = x;
                                                        let v4106: bool = true;
                                                        v4104
                                                    });
                                                let v4108: string = _result_unwrap_or_else;
                                                let v4113: string = Spiral::method199(
                                                    Spiral::US5::US5_0(v4047.clone()),
                                                    string("spiral"),
                                                    Spiral::US39::US39_0(Spiral::US38::US38_2),
                                                    v4108.clone(),
                                                );
                                                let v4118: string = Spiral::method200(
                                                    v4038,
                                                    string("spiral"),
                                                    LrcPtr::new(Spiral::UH2::UH2_0),
                                                    LrcPtr::new(Spiral::UH2::UH2_1(
                                                        string("Fable.Core"),
                                                        LrcPtr::new(Spiral::UH2::UH2_0),
                                                    )),
                                                    v4113.clone(),
                                                    v4108.clone(),
                                                );
                                                Spiral::method208(
                                                    Spiral::method30(
                                                        Spiral::method30(
                                                            v4108,
                                                            string(
                                                                "lib/python/fable/fable_modules",
                                                            ),
                                                        ),
                                                        string("fable_library"),
                                                    ),
                                                    Spiral::method30(
                                                        v4113.clone(),
                                                        string("fable_modules/fable_library"),
                                                    ),
                                                );
                                                {
                                                    let patternInput_25: (i32, string) =
                                                        Spiral::method209(
                                                            Spiral::US36::US36_1,
                                                            v4113.clone(),
                                                            string("py"),
                                                            v4118,
                                                            v4094.clone(),
                                                        );
                                                    let v4127: string = patternInput_25.1.clone();
                                                    let v4126: i32 = patternInput_25.0.clone();
                                                    let patternInput_29: (
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                        Spiral::US5,
                                                    ) = if (v4126) != 0_i32 {
                                                        let v4133: () = {
                                                            Spiral::closure120(
                                                                v4127.clone(),
                                                                v4126,
                                                                (),
                                                            );
                                                            ()
                                                        };
                                                        (
                                                            Spiral::US5::US5_0(string("py")),
                                                            Spiral::US5::US5_1,
                                                            Spiral::US5::US5_1,
                                                            Spiral::US5::US5_0(v4127),
                                                        )
                                                    } else {
                                                        let v4178: bool = true;
                                                        let _vec_map : Vec<_> = v3960.into_iter().map(|x| { //;
                                                                    let v4180:
                                                                            std::string::String =
                                                                        x;
                                                                    let v4182:
                                                                            string =
                                                                        fable_library_rust::String_::fromString(v4180);
                                                                    let v4188:
                                                                            string =
                                                                        if contains(v4182.clone(),
                                                                                    string("="))
                                                                           {
                                                                            v4182.clone()
                                                                        } else {
                                                                            concat(new_array(&[string("\""),
                                                                                               v4182,
                                                                                               string("\":\"*\"")]))
                                                                        };
                                                                    let v4190:
                                                                            bool =
                                                                        true; v4188 }).collect::<Vec<_>>();
                                                        let v4192: Vec<string> = _vec_map;
                                                        let v4194:
                                                                            Array<string> =
                                                                        fable_library_rust::NativeArray_::array_from(v4192.clone());
                                                        let v4207: string = join(
                                                            string(",\n"),
                                                            toArray_1(delay(Func0::new({
                                                                let v4194 = v4194.clone();
                                                                move || {
                                                                    map_1(
                                                                        Func1::new({
                                                                            let v4194 =
                                                                                v4194.clone();
                                                                            move |i_3: i32| {
                                                                                v4194[i_3].clone()
                                                                            }
                                                                        }),
                                                                        rangeNumeric(
                                                                            0_i32,
                                                                            1_i32,
                                                                            (get_Count(
                                                                                v4194.clone(),
                                                                            )) - 1_i32,
                                                                        ),
                                                                    )
                                                                }
                                                            }))),
                                                        );
                                                        let v4223:
                                                                            string =
                                                                        append((append((append((append((append((append((append(string("{"),
                                                                                                                               (concat(new_array(&[string("  \"name\": \"spiral_"),
                                                                                                                                                   v4047,
                                                                                                                                                   string("\",")]))))),
                                                                                                                       string("  \"dependencies\": {"))),
                                                                                                               (v4207))),
                                                                                                       string("  },"))),
                                                                                               string("    \"devDependencies\": {"))),
                                                                                       string("  },"))),
                                                                               string("}"));
                                                        let v4225: string = Spiral::method30(
                                                            v4113.clone(),
                                                            string("package.json"),
                                                        );
                                                        let v4228: string = Spiral::method30(
                                                            Spiral::method30(
                                                                v4113.clone(),
                                                                string("../.."),
                                                            ),
                                                            string("package.json"),
                                                        );
                                                        Spiral::method64(v4225, v4223);
                                                        Spiral::method64(v4228, string(""));
                                                        {
                                                            let v4231: string = Spiral::method30(
                                                                v4113,
                                                                concat(new_array(&[
                                                                    string("spiral"),
                                                                    string("."),
                                                                    string("py"),
                                                                ])),
                                                            );
                                                            let v4234: () = {
                                                                Spiral::closure121(
                                                                    v4231.clone(),
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            let v4277: Result<
                                                                Vec<u8>,
                                                                std::io::Error,
                                                            > = std::fs::read(&*v4231.clone());
                                                            let v4315: Vec<u8> =
                                                                Spiral::method27(v4277.unwrap());
                                                            let v4317: Result<
                                                                std::string::String,
                                                                std::string::FromUtf8Error,
                                                            > = std::string::String::from_utf8(
                                                                v4315,
                                                            );
                                                            let v4320: std::string::String =
                                                                v4317.unwrap();
                                                            let v4350:
                                                                                string =
                                                                            fable_library_rust::String_::fromString(v4320);
                                                            let v4356: bool = contains(
                                                                v4350.clone(),
                                                                string("# spiral.process_python"),
                                                            );
                                                            let v4368: string = if v4356 {
                                                                v4350.clone()
                                                            } else {
                                                                Spiral::method60(
                                                                    string(
                                                                        "\\s\\sdefaultOf\\(\\);",
                                                                    ),
                                                                    string(" defaultOf::<()>();"),
                                                                    replace(
                                                                        v4350,
                                                                        append(
                                                                            string("),)"),
                                                                            (";".into()),
                                                                        ),
                                                                        string("));"),
                                                                    ),
                                                                )
                                                            };
                                                            if (v4356) == false {
                                                                Spiral::method64(v4231.clone(),
                                                                                             concat(new_array(&[v4368.clone(),
                                                                                                                string("\n\n"),
                                                                                                                string("# spiral.process_python"),
                                                                                                                string("\n")])));
                                                            }
                                                            {
                                                                let v4371: string =
                                                                    concat(new_array(&[
                                                                        string("python \""),
                                                                        v4231.clone(),
                                                                        string("\""),
                                                                    ]));
                                                                let v4374: Array<(string, string)> =
                                                                    new_array(&[(
                                                                        string("TRACE_LEVEL"),
                                                                        string("Verbose"),
                                                                    )]);
                                                                let v4385: Result<string, string> =
                                                                    match &v4094 {
                                                                        Spiral::US13::US13_0(
                                                                            v4094_0_0,
                                                                        ) => Ok::<string, string>(
                                                                            v4094_0_0.clone(),
                                                                        ),
                                                                        Spiral::US13::US13_1(
                                                                            v4094_1_0,
                                                                        ) => Err::<string, string>(
                                                                            v4094_1_0.clone(),
                                                                        ),
                                                                    };
                                                                let patternInput_26:
                                                                                    (i32,
                                                                                     string) =
                                                                                Spiral::method89(v4371.clone(),
                                                                                                 None::<CancellationToken>,
                                                                                                 v4374.clone(),
                                                                                                 None::<Func1<(i32,
                                                                                                               string,
                                                                                                               bool),
                                                                                                              Arc<Async<()>>>>,
                                                                                                 None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                              ()>>,
                                                                                                 true,
                                                                                                 v4385.ok());
                                                                let v4402: string =
                                                                    patternInput_26.1.clone();
                                                                let v4401: i32 =
                                                                    patternInput_26.0.clone();
                                                                let v4403: i32 =
                                                                    get_Count(v4374.clone());
                                                                let v4404: Array<string> =
                                                                    new_init(&string(""), v4403);
                                                                let v4405: LrcPtr<Spiral::Mut5> =
                                                                    LrcPtr::new(Spiral::Mut5 {
                                                                        l0: MutCell::new(0_i32),
                                                                    });
                                                                while Spiral::method93(
                                                                    v4403,
                                                                    v4405.clone(),
                                                                ) {
                                                                    let v4407: i32 =
                                                                        v4405.l0.get().clone();
                                                                    let patternInput_27: (
                                                                        string,
                                                                        string,
                                                                    ) = v4374[v4407].clone();
                                                                    let v4410: string = sprintf!(
                                                                        "$env:{}=\'\'{}\'\'",
                                                                        patternInput_27.0.clone(),
                                                                        patternInput_27.1.clone()
                                                                    );
                                                                    v4404.get_mut()
                                                                        [v4407 as usize] = v4410;
                                                                    {
                                                                        let v4411: i32 =
                                                                            (v4407) + 1_i32;
                                                                        v4405.l0.set(v4411);
                                                                        ()
                                                                    }
                                                                }
                                                                {
                                                                    let v4421: string = sprintf!(
                                                                        "pwsh -c \'{}; {}\'",
                                                                        join(
                                                                            string(";"),
                                                                            toArray_1(ofArray_1(
                                                                                v4404.clone()
                                                                            ))
                                                                        ),
                                                                        v4371
                                                                    );
                                                                    let patternInput_28: (
                                                                        Spiral::US5,
                                                                        Spiral::US5,
                                                                        Spiral::US5,
                                                                        Spiral::US5,
                                                                    ) = if (v4401) == 0_i32 {
                                                                        let result_3: LrcPtr<
                                                                            MutCell<Spiral::US5>,
                                                                        > = refCell(
                                                                            Spiral::US5::US5_1,
                                                                        );
                                                                        try_catch(||
                                                                                                      result_3.set(Spiral::closure71((),
                                                                                                                                     Spiral::closure122(v4402.clone(),
                                                                                                                                                        ()))),
                                                                                                  |ex_3:
                                                                                                       LrcPtr<Exception>|
                                                                                                      result_3.set(Spiral::closure123(v4231.clone(),
                                                                                                                                      v4402.clone(),
                                                                                                                                      v4421.clone(),
                                                                                                                                      ex_3.clone())));
                                                                        {
                                                                            let v4427: Spiral::US5 =
                                                                                result_3
                                                                                    .get()
                                                                                    .clone();
                                                                            let v4437:
                                                                                                    Option<string> =
                                                                                                match &v4427
                                                                                                    {
                                                                                                    Spiral::US5::US5_0(v4427_0_0)
                                                                                                    =>
                                                                                                    Some(match &v4427
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
                                                                            (
                                                                                Spiral::US5::US5_0(
                                                                                    string("py"),
                                                                                ),
                                                                                Spiral::US5::US5_0(
                                                                                    v4368,
                                                                                ),
                                                                                Spiral::US5::US5_0(
                                                                                    v4231.clone(),
                                                                                ),
                                                                                Spiral::US5::US5_0(
                                                                                    v4437.unwrap(),
                                                                                ),
                                                                            )
                                                                        }
                                                                    } else {
                                                                        let v4446: () = {
                                                                            Spiral::closure125(
                                                                                v4231,
                                                                                v4402,
                                                                                v4401,
                                                                                v4421,
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
                                                                        patternInput_28.0.clone(),
                                                                        patternInput_28.1.clone(),
                                                                        patternInput_28.2.clone(),
                                                                        patternInput_28.3.clone(),
                                                                    )
                                                                }
                                                            }
                                                        }
                                                    };
                                                    (
                                                        patternInput_29.0.clone(),
                                                        patternInput_29.1.clone(),
                                                        patternInput_29.2.clone(),
                                                        patternInput_29.3.clone(),
                                                    )
                                                }
                                            } else {
                                                let v4500: () = {
                                                    Spiral::closure126(v30, v29, ());
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
                                                patternInput_30.0.clone(),
                                                patternInput_30.1.clone(),
                                                patternInput_30.2.clone(),
                                                patternInput_30.3.clone(),
                                            )
                                        };
                                        (
                                            patternInput_31.0.clone(),
                                            patternInput_31.1.clone(),
                                            patternInput_31.2.clone(),
                                            patternInput_31.3.clone(),
                                        )
                                    };
                                    let v4555: Spiral::US5 = patternInput_32.3.clone();
                                    let v4554: Spiral::US5 = patternInput_32.2.clone();
                                    let v4553: Spiral::US5 = patternInput_32.1.clone();
                                    let v4552: Spiral::US5 = patternInput_32.0.clone();
                                    new_array(&[
                                        (
                                            string("extension"),
                                            match &v4552 {
                                                Spiral::US5::US5_0(v4552_0_0) => match &v4552 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => string(""),
                                            },
                                        ),
                                        (
                                            string("code"),
                                            match &v4553 {
                                                Spiral::US5::US5_0(v4553_0_0) => match &v4553 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => string(""),
                                            },
                                        ),
                                        (
                                            string("code_path"),
                                            match &v4554 {
                                                Spiral::US5::US5_0(v4554_0_0) => match &v4554 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => string(""),
                                            },
                                        ),
                                        (
                                            string("output"),
                                            match &v4555 {
                                                Spiral::US5::US5_0(v4555_0_0) => match &v4555 {
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
                    } else {
                        new_array(&[
                            (string("extension"), string("")),
                            (string("code"), string("")),
                            (string("code_path"), string("")),
                            (string("output"), string("")),
                        ])
                    };
                    let v4588: Vec<(string, string)> = v4586.to_vec();
                    let v4591: bool = true;
                    let _func1_from_v4589 = Func1::from(move |value| {
                        //;
                        let patternInput_33: (string, string) = value;
                        let v4597: &str = &*patternInput_33.0.clone();
                        let v4621: std::string::String = String::from(v4597);
                        let v4645: &str = &*patternInput_33.1.clone();
                        let v4669: std::string::String = String::from(v4645);
                        let v4694: bool = true;
                        LrcPtr::new((v4621, v4669)) /*;
                                                    let v4696: bool = */
                    }); //;
                    let v4698: Func1<
                        (string, string),
                        LrcPtr<(std::string::String, std::string::String)>,
                    > = _func1_from_v4589;
                    let v4701: Vec<LrcPtr<(std::string::String, std::string::String)>> = v4588
                        .into_iter()
                        .map(|x| {
                            Func1::new({
                                let v4698 = v4698.clone();
                                move |arg10_0040_25: (string, string)| {
                                    Spiral::closure76(v4698.clone(), arg10_0040_25)
                                }
                            })(x.clone())
                        })
                        .collect::<Vec<_>>();
                    let v4702: string =
                string("std::collections::BTreeMap::from_iter(v4701.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                    let v4703: std::collections::BTreeMap<
                        std::string::String,
                        std::string::String,
                    > = std::collections::BTreeMap::from_iter(
                        v4701
                            .iter()
                            .map(|x| x.as_ref())
                            .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                    );
                    let v4705: Result<std::string::String, serde_json::Error> =
                        serde_json::to_string(&v4703);
                    let v4706 = Spiral::method274();
                    let v4709: Result<std::string::String, string> = v4705.map_err(|x| v4706(x));
                    let v4722: bool = true;
                    let _result_map_ = v4709.map(|x| {
                        //;
                        let v4724: std::string::String = x;
                        let v4726: string = fable_library_rust::String_::fromString(v4724);
                        let v4728: bool = true;
                        v4726
                    });
                    let v4730: Result<string, string> = _result_map_;
                    let v4733: string = string("}");
                    let v4738: bool = true;
                    let _fix_closure_v4735 = v4730;
                    let v4745: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v4735 "), (v4733))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v4746: bool = true;
                    _fix_closure_v4735
                },
            ); // rust.fix_closure';
            let v4748 = __future_init;
            v4748
        }
        pub fn closure1(unitVar: (), v0_1: Array<string>) -> i32 {
            let v3: () = {
                Spiral::closure2((), ());
                ()
            };
            let v21: LrcPtr<Spiral::Mut4> =
                (Spiral::TraceState::trace_state().get().clone().unwrap())
                    .4
                    .clone();
            let v37: () = {
                Spiral::closure5(v0_1, ());
                ()
            };
            let v76: clap::Command = Spiral::method0();
            let v78: clap::ArgMatches = clap::Command::get_matches(v76);
            let v80: std::pin::Pin<Box<dyn std::future::Future<Output = Result<string, string>>>> =
                Spiral::method20(v21.l0.get().clone(), v78);
            let v82: Result<string, string> = futures::executor::block_on(v80);
            let v85: string = v82.unwrap();
            if if let Spiral::US0::US0_2 = &v21.l0.get().clone() {
                true
            } else {
                false
            } {
                let v101: () = {
                    Spiral::closure10(v85, ());
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
