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
        pub struct Mut5 {
            pub l0: MutCell<i32>,
        }
        impl core::fmt::Display for Mut5 {
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
        pub enum US38 {
            US38_0,
            US38_1,
        }
        impl core::fmt::Display for US38 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US37 {
            US37_0(Spiral::US38),
            US37_1,
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
        pub enum US40 {
            US40_0(string),
            US40_1(string),
        }
        impl core::fmt::Display for US40 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US39 {
            US39_0(Spiral::US40),
            US39_1,
        }
        impl core::fmt::Display for US39 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US41 {
            US41_0,
            US41_1,
            US41_2,
        }
        impl core::fmt::Display for US41 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US42 {
            US42_0(Spiral::US41),
            US42_1,
        }
        impl core::fmt::Display for US42 {
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
        pub enum US43 {
            US43_0(chrono::DateTime<chrono::Utc>),
            US43_1,
        }
        impl core::fmt::Display for US43 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US44 {
            US44_0(i32, string),
            US44_1(i32, string),
        }
        impl core::fmt::Display for US44 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US45 {
            US45_0(std::collections::HashMap<string, string>),
            US45_1,
        }
        impl core::fmt::Display for US45 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US46 {
            US46_0(Spiral::US5),
            US46_1,
        }
        impl core::fmt::Display for US46 {
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
        pub enum US47 {
            US47_0,
            US47_1(string),
        }
        impl core::fmt::Display for US47 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US48 {
            US48_0(std::fs::FileType),
            US48_1(std::string::String),
        }
        impl core::fmt::Display for US48 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US49 {
            US49_0,
            US49_1,
            US49_2,
        }
        impl core::fmt::Display for US49 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug)]
        pub enum US50 {
            US50_0(async_walkdir::DirEntry),
            US50_1(std::string::String),
        }
        impl core::fmt::Display for US50 {
            fn fmt(&self, f: &mut core::fmt::Formatter) -> core::fmt::Result {
                write!(f, "{}", core::any::type_name::<Self>())
            }
        }
        #[derive(Clone, Debug, Hash, PartialEq, PartialOrd)]
        pub enum US51 {
            US51_0(string, string),
            US51_1,
        }
        impl core::fmt::Display for US51 {
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
            let v50: string = string("r#\"target\"#");
            let v51: &'static str = r#"target"#;
            let v53: clap::Arg = clap::Arg::new(v51);
            let v55: clap::Arg = v53.short('t');
            let v56: string = string("r#\"target\"#");
            let v57: &'static str = r#"target"#;
            let v59: clap::Arg = v55.long(v57);
            let v64: string = toLower(string("JavaScript"));
            let v85: Array<string> = toArray(ofArray(new_array(&[toLower(string("Erlang")), v64])));
            let v89: Vec<string> = v85.to_vec();
            let v91: bool = true;
            let _vec_map: Vec<_> = v89
                .into_iter()
                .map(|x| {
                    //;
                    let v93: string = x;
                    let v100: &str = &*v93;
                    let v133: std::string::String = String::from(v100);
                    let v161: Box<std::string::String> = Box::new(v133);
                    let v163: &'static mut std::string::String = Box::leak(v161);
                    let v165: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v163);
                    let v167: bool = true;
                    v165
                })
                .collect::<Vec<_>>();
            let v169: Vec<clap::builder::PossibleValue> = _vec_map;
            let v171: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v169),
            );
            let v173: clap::Arg = v59.value_parser(v171);
            let v175: clap::Command = clap::Command::arg(v48, v173);
            let v177: string = string("r#\"NAME\"#");
            let v180: string = string("r#\"VERSION\"#");
            let v182: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v184: usize = 1_i32 as usize;
            let v188: usize = 0_i32 as usize;
            let v204: clap::builder::ValueRange = if (v188) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v184..)
            } else {
                let v202: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v184..v188)
            };
            let v206: string = string("r#\"deps\"#");
            let v207: &'static str = r#"deps"#;
            let v209: clap::Arg = clap::Arg::new(v207);
            let v211: clap::Arg = v209.short('d');
            let v212: string = string("r#\"deps\"#");
            let v213: &'static str = r#"deps"#;
            let v215: clap::Arg = v211.long(v213);
            let v217: Vec<&'static str> = v182.to_vec();
            let v219: clap::Arg = v215.value_names(v217);
            let v221: clap::Arg = v219.num_args(v204);
            let v223: clap::ArgAction = clap::ArgAction::Append;
            let v225: clap::Arg = v221.action(v223);
            let v227: clap::Command = clap::Command::arg(v175, v225);
            let v229: clap::Command = clap::Command::subcommand(v28, v227);
            let v231: string = string("r#\"cuda\"#");
            let v232: &'static str = r#"cuda"#;
            let v234: clap::Command = clap::Command::new(v232);
            let v236: string = string("r#\"py-path\"#");
            let v237: &'static str = r#"py-path"#;
            let v239: clap::Arg = clap::Arg::new(v237);
            let v241: clap::Arg = v239.short('p');
            let v242: string = string("r#\"py-path\"#");
            let v243: &'static str = r#"py-path"#;
            let v245: clap::Arg = v241.long(v243);
            let v247: clap::Arg = v245.required(true);
            let v249: clap::Command = clap::Command::arg(v234, v247);
            let v251: string = string("r#\"env\"#");
            let v252: &'static str = r#"env"#;
            let v254: clap::Arg = clap::Arg::new(v252);
            let v256: clap::Arg = v254.short('e');
            let v257: string = string("r#\"env\"#");
            let v258: &'static str = r#"env"#;
            let v260: clap::Arg = v256.long(v258);
            let v265: string = toLower(string("Poetry"));
            let v286: Array<string> = toArray(ofArray(new_array(&[toLower(string("Pip")), v265])));
            let v290: Vec<string> = v286.to_vec();
            let v292: bool = true;
            let _vec_map: Vec<_> = v290
                .into_iter()
                .map(|x| {
                    //;
                    let v294: string = x;
                    let v301: &str = &*v294;
                    let v334: std::string::String = String::from(v301);
                    let v362: Box<std::string::String> = Box::new(v334);
                    let v364: &'static mut std::string::String = Box::leak(v362);
                    let v366: clap::builder::PossibleValue =
                        clap::builder::PossibleValue::new(&**v364);
                    let v368: bool = true;
                    v366
                })
                .collect::<Vec<_>>();
            let v370: Vec<clap::builder::PossibleValue> = _vec_map;
            let v372: clap::builder::ValueParser = Into::<clap::builder::ValueParser>::into(
                clap::builder::PossibleValuesParser::new(v370),
            );
            let v374: clap::Arg = v260.value_parser(v372);
            let v376: clap::Command = clap::Command::arg(v249, v374);
            let v377: string = string("r#\"NAME\"#");
            let v379: string = string("r#\"VERSION\"#");
            let v381: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v383: usize = 1_i32 as usize;
            let v387: usize = 0_i32 as usize;
            let v403: clap::builder::ValueRange = if (v387) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v383..)
            } else {
                let v401: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v383..v387)
            };
            let v404: string = string("r#\"deps\"#");
            let v405: &'static str = r#"deps"#;
            let v407: clap::Arg = clap::Arg::new(v405);
            let v409: clap::Arg = v407.short('d');
            let v410: string = string("r#\"deps\"#");
            let v411: &'static str = r#"deps"#;
            let v413: clap::Arg = v409.long(v411);
            let v415: Vec<&'static str> = v381.to_vec();
            let v417: clap::Arg = v413.value_names(v415);
            let v419: clap::Arg = v417.num_args(v403);
            let v421: clap::ArgAction = clap::ArgAction::Append;
            let v423: clap::Arg = v419.action(v421);
            let v425: clap::Command = clap::Command::arg(v376, v423);
            let v427: clap::Command = clap::Command::subcommand(v229, v425);
            let v429: string = string("r#\"fable\"#");
            let v430: &'static str = r#"fable"#;
            let v432: clap::Command = clap::Command::new(v430);
            let v434: string = string("r#\"fs-path\"#");
            let v435: &'static str = r#"fs-path"#;
            let v437: clap::Arg = clap::Arg::new(v435);
            let v439: clap::Arg = v437.short('f');
            let v440: string = string("r#\"fs-path\"#");
            let v441: &'static str = r#"fs-path"#;
            let v443: clap::Arg = v439.long(v441);
            let v445: clap::Arg = v443.required(true);
            let v447: clap::Command = clap::Command::arg(v432, v445);
            let v448: string = string("r#\"command\"#");
            let v449: &'static str = r#"command"#;
            let v451: clap::Arg = clap::Arg::new(v449);
            let v453: clap::Arg = v451.short('c');
            let v454: string = string("r#\"command\"#");
            let v455: &'static str = r#"command"#;
            let v457: clap::Arg = v453.long(v455);
            let v459: clap::Command = clap::Command::arg(v447, v457);
            let v461: clap::Command = clap::Command::subcommand(v427, v459);
            let v463: string = string("r#\"rust\"#");
            let v464: &'static str = r#"rust"#;
            let v466: clap::Command = clap::Command::new(v464);
            let v467: string = string("r#\"fs-path\"#");
            let v468: &'static str = r#"fs-path"#;
            let v470: clap::Arg = clap::Arg::new(v468);
            let v472: clap::Arg = v470.short('f');
            let v473: string = string("r#\"fs-path\"#");
            let v474: &'static str = r#"fs-path"#;
            let v476: clap::Arg = v472.long(v474);
            let v478: clap::Arg = v476.required(true);
            let v480: clap::Command = clap::Command::arg(v466, v478);
            let v481: string = string("r#\"NAME\"#");
            let v483: string = string("r#\"VERSION\"#");
            let v485: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v487: usize = 1_i32 as usize;
            let v491: usize = 0_i32 as usize;
            let v507: clap::builder::ValueRange = if (v491) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v487..)
            } else {
                let v505: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v487..v491)
            };
            let v508: string = string("r#\"deps\"#");
            let v509: &'static str = r#"deps"#;
            let v511: clap::Arg = clap::Arg::new(v509);
            let v513: clap::Arg = v511.short('d');
            let v514: string = string("r#\"deps\"#");
            let v515: &'static str = r#"deps"#;
            let v517: clap::Arg = v513.long(v515);
            let v519: Vec<&'static str> = v485.to_vec();
            let v521: clap::Arg = v517.value_names(v519);
            let v523: clap::Arg = v521.num_args(v507);
            let v525: clap::ArgAction = clap::ArgAction::Append;
            let v527: clap::Arg = v523.action(v525);
            let v529: clap::Command = clap::Command::arg(v480, v527);
            let v531: usize = 0_i32 as usize;
            let v535: usize = 1_i32 as usize;
            let v551: clap::builder::ValueRange = if (v535) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v531..)
            } else {
                let v549: string = string("clap::builder::ValueRange::new($0..=$1)");
                clap::builder::ValueRange::new(v531..=v535)
            };
            let v553: string = string("r#\"wasm\"#");
            let v554: &'static str = r#"wasm"#;
            let v556: clap::Arg = clap::Arg::new(v554);
            let v558: clap::Arg = v556.short('w');
            let v559: string = string("r#\"wasm\"#");
            let v560: &'static str = r#"wasm"#;
            let v562: clap::Arg = v558.long(v560);
            let v564: clap::Arg = v562.num_args(v551);
            let v566: clap::Arg = v564.require_equals(true);
            let v568: string = string("r#\"\"#");
            let v569: &str = r#""#;
            let v571: clap::Arg = v566.default_missing_value(v569);
            let v573: clap::Command = clap::Command::arg(v529, v571);
            let v575: usize = 0_i32 as usize;
            let v579: usize = 1_i32 as usize;
            let v595: clap::builder::ValueRange = if (v579) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v575..)
            } else {
                let v593: string = string("clap::builder::ValueRange::new($0..=$1)");
                clap::builder::ValueRange::new(v575..=v579)
            };
            let v597: string = string("r#\"contract\"#");
            let v598: &'static str = r#"contract"#;
            let v600: clap::Arg = clap::Arg::new(v598);
            let v602: clap::Arg = v600.short('c');
            let v603: string = string("r#\"contract\"#");
            let v604: &'static str = r#"contract"#;
            let v606: clap::Arg = v602.long(v604);
            let v608: clap::Arg = v606.num_args(v595);
            let v610: clap::Arg = v608.require_equals(true);
            let v611: string = string("r#\"\"#");
            let v612: &str = r#""#;
            let v614: clap::Arg = v610.default_missing_value(v612);
            let v616: clap::Command = clap::Command::arg(v573, v614);
            let v618: string = string("r#\"cleanup\"#");
            let v619: &'static str = r#"cleanup"#;
            let v621: clap::Arg = clap::Arg::new(v619);
            let v623: clap::Arg = v621.short('l');
            let v624: string = string("r#\"cleanup\"#");
            let v625: &'static str = r#"cleanup"#;
            let v627: clap::Arg = v623.long(v625);
            let v629: string = string("r#\"true\"#");
            let v630: &str = r#"true"#;
            let v632: clap::Arg = v627.default_value(v630);
            let v634: clap::ArgAction = clap::ArgAction::SetFalse;
            let v636: clap::Arg = v632.action(v634);
            let v638: clap::Command = clap::Command::arg(v616, v636);
            let v640: clap::Command = clap::Command::subcommand(v461, v638);
            let v642: string = string("r#\"typescript\"#");
            let v643: &'static str = r#"typescript"#;
            let v645: clap::Command = clap::Command::new(v643);
            let v646: string = string("r#\"fs-path\"#");
            let v647: &'static str = r#"fs-path"#;
            let v649: clap::Arg = clap::Arg::new(v647);
            let v651: clap::Arg = v649.short('f');
            let v652: string = string("r#\"fs-path\"#");
            let v653: &'static str = r#"fs-path"#;
            let v655: clap::Arg = v651.long(v653);
            let v657: clap::Arg = v655.required(true);
            let v659: clap::Command = clap::Command::arg(v645, v657);
            let v660: string = string("r#\"NAME\"#");
            let v662: string = string("r#\"VERSION\"#");
            let v664: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v666: usize = 1_i32 as usize;
            let v670: usize = 0_i32 as usize;
            let v685: clap::builder::ValueRange = if (v670) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v666..)
            } else {
                let v683: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v666..v670)
            };
            let v686: string = string("r#\"deps\"#");
            let v687: &'static str = r#"deps"#;
            let v689: clap::Arg = clap::Arg::new(v687);
            let v691: clap::Arg = v689.short('d');
            let v692: string = string("r#\"deps\"#");
            let v693: &'static str = r#"deps"#;
            let v695: clap::Arg = v691.long(v693);
            let v697: Vec<&'static str> = v664.to_vec();
            let v699: clap::Arg = v695.value_names(v697);
            let v701: clap::Arg = v699.num_args(v685);
            let v703: clap::ArgAction = clap::ArgAction::Append;
            let v705: clap::Arg = v701.action(v703);
            let v707: clap::Command = clap::Command::arg(v659, v705);
            let v709: clap::Command = clap::Command::subcommand(v640, v707);
            let v711: string = string("r#\"python\"#");
            let v712: &'static str = r#"python"#;
            let v714: clap::Command = clap::Command::new(v712);
            let v715: string = string("r#\"fs-path\"#");
            let v716: &'static str = r#"fs-path"#;
            let v718: clap::Arg = clap::Arg::new(v716);
            let v720: clap::Arg = v718.short('f');
            let v721: string = string("r#\"fs-path\"#");
            let v722: &'static str = r#"fs-path"#;
            let v724: clap::Arg = v720.long(v722);
            let v726: clap::Arg = v724.required(true);
            let v728: clap::Command = clap::Command::arg(v714, v726);
            let v729: string = string("r#\"NAME\"#");
            let v731: string = string("r#\"VERSION\"#");
            let v733: Array<&'static str> = new_array(&[r#"NAME"#, r#"VERSION"#]);
            let v735: usize = 1_i32 as usize;
            let v739: usize = 0_i32 as usize;
            let v754: clap::builder::ValueRange = if (v739) == (0_i32 as usize) {
                clap::builder::ValueRange::new(v735..)
            } else {
                let v752: string = string("clap::builder::ValueRange::new($0..$1)");
                clap::builder::ValueRange::new(v735..v739)
            };
            let v755: string = string("r#\"deps\"#");
            let v756: &'static str = r#"deps"#;
            let v758: clap::Arg = clap::Arg::new(v756);
            let v760: clap::Arg = v758.short('d');
            let v761: string = string("r#\"deps\"#");
            let v762: &'static str = r#"deps"#;
            let v764: clap::Arg = v760.long(v762);
            let v766: Vec<&'static str> = v733.to_vec();
            let v768: clap::Arg = v764.value_names(v766);
            let v770: clap::Arg = v768.num_args(v754);
            let v772: clap::ArgAction = clap::ArgAction::Append;
            let v774: clap::Arg = v770.action(v772);
            let v776: clap::Command = clap::Command::arg(v728, v774);
            let v778: clap::Command = clap::Command::subcommand(v709, v776);
            let v780: string = string("r#\"dib\"#");
            let v781: &'static str = r#"dib"#;
            let v783: clap::Command = clap::Command::new(v781);
            let v785: string = string("r#\"path\"#");
            let v786: &'static str = r#"path"#;
            let v788: clap::Arg = clap::Arg::new(v786);
            let v790: clap::Arg = v788.short('p');
            let v791: string = string("r#\"path\"#");
            let v792: &'static str = r#"path"#;
            let v794: clap::Arg = v790.long(v792);
            let v796: clap::Arg = v794.required(true);
            let v798: clap::Command = clap::Command::arg(v783, v796);
            let v800: string = string("clap::value_parser!(u8).into()");
            let v801: clap::builder::ValueParser = clap::value_parser!(u8).into();
            let v803: string = string("r#\"retries\"#");
            let v804: &'static str = r#"retries"#;
            let v806: clap::Arg = clap::Arg::new(v804);
            let v808: clap::Arg = v806.short('r');
            let v809: string = string("r#\"retries\"#");
            let v810: &'static str = r#"retries"#;
            let v812: clap::Arg = v808.long(v810);
            let v814: clap::Arg = v812.value_parser(v801);
            let v816: clap::Command = clap::Command::arg(v798, v814);
            let v818: string = string("r#\"working-directory\"#");
            let v819: &'static str = r#"working-directory"#;
            let v821: clap::Arg = clap::Arg::new(v819);
            let v823: clap::Arg = v821.short('w');
            let v824: string = string("r#\"working-directory\"#");
            let v825: &'static str = r#"working-directory"#;
            let v827: clap::Arg = v823.long(v825);
            let v829: clap::Command = clap::Command::arg(v816, v827);
            clap::Command::subcommand(v778, v829)
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
            let v6: string = toLower(string("Critical"));
            let v13: string = toLower(string("Warning"));
            let v20: string = toLower(string("Info"));
            let v27: string = toLower(string("Debug"));
            let v34: string = toLower(string("Verbose"));
            let v41: Spiral::US1 = if string("Verbose") == (v1_1.clone()) {
                Spiral::US1::US1_0(Spiral::US0::US0_0)
            } else {
                Spiral::US1::US1_1
            };
            (
                match &v41 {
                    Spiral::US1::US1_0(v41_0_0) => Spiral::US1::US1_0(
                        match &v41 {
                            Spiral::US1::US1_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone(),
                    ),
                    _ => {
                        let v48: Spiral::US1 = if string("Debug") == (v1_1.clone()) {
                            Spiral::US1::US1_0(Spiral::US0::US0_1)
                        } else {
                            Spiral::US1::US1_1
                        };
                        match &v48 {
                            Spiral::US1::US1_0(v48_0_0) => Spiral::US1::US1_0(
                                match &v48 {
                                    Spiral::US1::US1_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => {
                                let v55: Spiral::US1 = if string("Info") == (v1_1.clone()) {
                                    Spiral::US1::US1_0(Spiral::US0::US0_2)
                                } else {
                                    Spiral::US1::US1_1
                                };
                                match &v55 {
                                    Spiral::US1::US1_0(v55_0_0) => Spiral::US1::US1_0(
                                        match &v55 {
                                            Spiral::US1::US1_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => {
                                        let v62: Spiral::US1 =
                                            if string("Warning") == (v1_1.clone()) {
                                                Spiral::US1::US1_0(Spiral::US0::US0_3)
                                            } else {
                                                Spiral::US1::US1_1
                                            };
                                        match &v62 {
                                            Spiral::US1::US1_0(v62_0_0) => Spiral::US1::US1_0(
                                                match &v62 {
                                                    Spiral::US1::US1_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                            ),
                                            _ => {
                                                let v69: Spiral::US1 =
                                                    if string("Critical") == (v1_1.clone()) {
                                                        Spiral::US1::US1_0(Spiral::US0::US0_4)
                                                    } else {
                                                        Spiral::US1::US1_1
                                                    };
                                                match &v69 {
                                                    Spiral::US1::US1_0(v69_0_0) => {
                                                        Spiral::US1::US1_0(
                                                            match &v69 {
                                                                Spiral::US1::US1_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => {
                                                        let v76: Spiral::US1 = if (v34.clone())
                                                            == (v1_1.clone())
                                                        {
                                                            Spiral::US1::US1_0(Spiral::US0::US0_0)
                                                        } else {
                                                            Spiral::US1::US1_1
                                                        };
                                                        match &v76 {
                                                            Spiral::US1::US1_0(v76_0_0) => {
                                                                Spiral::US1::US1_0(
                                                                    match &v76 {
                                                                        Spiral::US1::US1_0(x) => {
                                                                            x.clone()
                                                                        }
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                )
                                                            }
                                                            _ => {
                                                                let v83: Spiral::US1 = if (v27
                                                                    .clone())
                                                                    == (v1_1.clone())
                                                                {
                                                                    Spiral::US1::US1_0(
                                                                        Spiral::US0::US0_1,
                                                                    )
                                                                } else {
                                                                    Spiral::US1::US1_1
                                                                };
                                                                match &v83 {
                                                                 Spiral::US1::US1_0(v83_0_0)
                                                                 =>
                                                                 Spiral::US1::US1_0(match &v83
                                                                                        {
                                                                                        Spiral::US1::US1_0(x)
                                                                                        =>
                                                                                        x.clone(),
                                                                                        _
                                                                                        =>
                                                                                        unreachable!(),
                                                                                    }.clone()),
                                                                 _ => {
                                                                     let v90:
                                                                             Spiral::US1 =
                                                                         if (v20.clone())
                                                                                ==
                                                                                (v1_1.clone())
                                                                            {
                                                                             Spiral::US1::US1_0(Spiral::US0::US0_2)
                                                                         } else {
                                                                             Spiral::US1::US1_1
                                                                         };
                                                                     match &v90
                                                                         {
                                                                         Spiral::US1::US1_0(v90_0_0)
                                                                         =>
                                                                         Spiral::US1::US1_0(match &v90
                                                                                                {
                                                                                                Spiral::US1::US1_0(x)
                                                                                                =>
                                                                                                x.clone(),
                                                                                                _
                                                                                                =>
                                                                                                unreachable!(),
                                                                                            }.clone()),
                                                                         _ =>
                                                                         {
                                                                             let v97:
                                                                                     Spiral::US1 =
                                                                                 if (v13.clone())
                                                                                        ==
                                                                                        (v1_1.clone())
                                                                                    {
                                                                                     Spiral::US1::US1_0(Spiral::US0::US0_3)
                                                                                 } else {
                                                                                     Spiral::US1::US1_1
                                                                                 };
                                                                             match &v97
                                                                                 {
                                                                                 Spiral::US1::US1_0(v97_0_0)
                                                                                 =>
                                                                                 Spiral::US1::US1_0(match &v97
                                                                                                        {
                                                                                                        Spiral::US1::US1_0(x)
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
                                                                                             Spiral::US1 =
                                                                                         if (v6.clone())
                                                                                                ==
                                                                                                (v1_1.clone())
                                                                                            {
                                                                                             Spiral::US1::US1_0(Spiral::US0::US0_4)
                                                                                         } else {
                                                                                             Spiral::US1::US1_1
                                                                                         };
                                                                                     match &v104
                                                                                         {
                                                                                         Spiral::US1::US1_0(v104_0_0)
                                                                                         =>
                                                                                         Spiral::US1::US1_0(match &v104
                                                                                                                {
                                                                                                                Spiral::US1::US1_0(x)
                                                                                                                =>
                                                                                                                x.clone(),
                                                                                                                _
                                                                                                                =>
                                                                                                                unreachable!(),
                                                                                                            }.clone()),
                                                                                         _
                                                                                         =>
                                                                                         Spiral::US1::US1_1,
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
            let v8: string = Spiral::method13(getCharAt(toLower(string("Debug")), 0_i32));
            let v15: &str = inline_colorization::color_bright_blue;
            let v22: &str = &*v8;
            let v50: &str = inline_colorization::color_reset;
            let v52: std::string::String = format!("{}{}{}", v15, v22, v50);
            fable_library_rust::String_::fromString(v52)
        }
        pub fn method17(v0_1: Array<string>) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral::closure7(v2.clone(), string("args"), ());
                ()
            };
            let v33: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v46: () = {
                Spiral::closure7(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v57: () = {
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
            string("target")
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
        pub fn method28(v0_1: string, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("extension"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v3.clone(), string("new_code"), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method30() -> string {
            string("")
        }
        pub fn method31(v0_1: string) -> string {
            v0_1
        }
        pub fn method32(v0_1: i32, v1_1: LrcPtr<Spiral::Mut5>) -> bool {
            (v1_1.l0.get().clone()) < (v0_1)
        }
        pub fn method33() -> string {
            string("")
        }
        pub fn method29(v0_1: string) -> string {
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
                        let _let__v108: LrcPtr<dyn IEnumerable_1<string>> = delay(Func0::new({
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
                        let v117: string = Spiral::method30();
                        let v124: string = join(
                            if (v117.clone()) == string("\n") {
                                Spiral::method31(v117.clone())
                            } else {
                                v117
                            },
                            toArray_1(_let__v108),
                        );
                        Ok::<string, std::io::Error>(v124).unwrap()
                    }
                }
            }
        }
        pub fn method34() -> string {
            let v6: Result<std::path::PathBuf, std::io::Error> = std::env::current_dir();
            let v10: std::path::PathBuf = v6.unwrap();
            let v28: std::path::Display = v10.display();
            let v61: std::string::String = format!("{}", v28);
            fable_library_rust::String_::fromString(v61)
        }
        pub fn method36(v0_1: string, v1_1: string) -> string {
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
        pub fn method38(v0_1: string) -> bool {
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
            Spiral::method38(v0_1)
        }
        pub fn method39(v0_1: string) -> bool {
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
            Spiral::method39(v0_1)
        }
        pub fn method41(v0_1: string) -> Option<string> {
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
        pub fn method42(
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
            '_method42: loop {
                break '_method42 (if v3(Spiral::method36(v4.get().clone(), v0_1.get().clone())) {
                    Spiral::US13::US13_0(v4.get().clone())
                } else {
                    let v8: Option<string> = Spiral::method41(v4.get().clone());
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
                            continue '_method42;
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
        pub fn method40(
            v0_1: string,
            v1_1: string,
            v2: bool,
            v3: Func1<string, bool>,
        ) -> Spiral::US13 {
            if v3(Spiral::method36(v1_1.clone(), v0_1.clone())) {
                Spiral::US13::US13_0(v1_1.clone())
            } else {
                let v7: Option<string> = Spiral::method41(v1_1.clone());
                let v26: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v7));
                match &v26 {
                    Spiral::US5::US5_0(v26_0_0) => Spiral::method42(
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
        pub fn method37(v0_1: Spiral::US12, v1_1: string, v2: string) -> Spiral::US13 {
            let v3: bool = if let Spiral::US12::US12_0 = &v0_1 {
                true
            } else {
                false
            };
            Spiral::method40(
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
        pub fn method43() -> string {
            let v8: string = Spiral::method13(getCharAt(toLower(string("Warning")), 0_i32));
            let v15: &str = inline_colorization::color_yellow;
            let v22: &str = &*v8;
            let v50: &str = inline_colorization::color_reset;
            let v52: std::string::String = format!("{}{}{}", v15, v22, v50);
            fable_library_rust::String_::fromString(v52)
        }
        pub fn method45(v0_1: string, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("dir"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v3.clone(), string("error"), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method44(
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
            let v10: string = Spiral::method45(v8, v9);
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
                Spiral::method19(Spiral::method44(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method43(),
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn method50(v0_1: std::io::Error) -> string {
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
            Spiral::method50(v0_1)
        }
        pub fn method49() -> Func1<std::io::Error, string> {
            Func1::new(move |v: std::io::Error| Spiral::closure18((), v))
        }
        pub fn closure19(unitVar: (), v0_1: std::path::PathBuf) -> Spiral::US14 {
            Spiral::US14::US14_0(v0_1)
        }
        pub fn method51() -> Func1<std::path::PathBuf, Spiral::US14> {
            Func1::new(move |v: std::path::PathBuf| Spiral::closure19((), v))
        }
        pub fn closure20(unitVar: (), v0_1: string) -> Spiral::US14 {
            Spiral::US14::US14_1(v0_1)
        }
        pub fn method52() -> Func1<string, Spiral::US14> {
            Func1::new(move |v: string| Spiral::closure20((), v))
        }
        pub fn method55(v0_1: string) -> string {
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
        pub fn method56(v0_1: string) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v9: () = {
                Spiral::closure7(v2.clone(), v0_1, ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method54(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: string,
            v4: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v5: string = Spiral::method55(v4.clone());
            let v6: Option<string> = Spiral::method41(v4.clone());
            let v25: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6));
            let v29: string = Spiral::method56(v3);
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
                        let v92 = Spiral::method49();
                        let v105: Result<std::path::PathBuf, string> = v91.map_err(|x| v92(x));
                        let v108 = Spiral::method51();
                        let v109 = Spiral::method52();
                        let v111: Spiral::US14 = match &v105 {
                            Err(v105_1_0) => v109(v105_1_0.clone()),
                            Ok(v105_0_0) => v108(v105_0_0.clone()),
                        };
                        match &v111 {
                            Spiral::US14::US14_0(v111_0_0) => {
                                let v152: string = Spiral::method36(
                                    toString(v111_0_0.clone().display()),
                                    v5.clone(),
                                );
                                let v159: &str = &*v152;
                                let v192: std::string::String = String::from(v159);
                                let v225: std::path::PathBuf = std::path::PathBuf::from(v192);
                                Ok(v225)
                            }
                            Spiral::US14::US14_1(v111_1_0) => {
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
        pub fn method53(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v9: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v2.clone());
            let v10 = Spiral::method49();
            let v23: Result<std::path::PathBuf, string> = v9.map_err(|x| v10(x));
            let v26 = Spiral::method51();
            let v27 = Spiral::method52();
            let v29: Spiral::US14 = match &v23 {
                Err(v23_1_0) => v27(v23_1_0.clone()),
                Ok(v23_0_0) => v26(v23_0_0.clone()),
            };
            match &v29 {
                Spiral::US14::US14_0(v29_0_0) => Ok(v29_0_0.clone()),
                Spiral::US14::US14_1(v29_1_0) => Spiral::method54(
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
            Spiral::method53(v0_1, v1_1, v2)
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
        pub fn method57(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v4: string = Spiral::method55(v0_1.clone());
            let v5: Option<string> = Spiral::method41(v0_1.clone());
            let v24: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v5));
            let v28: string = Spiral::method56(v3);
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
                        let v91 = Spiral::method49();
                        let v104: Result<std::path::PathBuf, string> = v90.map_err(|x| v91(x));
                        let v107 = Spiral::method51();
                        let v108 = Spiral::method52();
                        let v110: Spiral::US14 = match &v104 {
                            Err(v104_1_0) => v108(v104_1_0.clone()),
                            Ok(v104_0_0) => v107(v104_0_0.clone()),
                        };
                        match &v110 {
                            Spiral::US14::US14_0(v110_0_0) => {
                                let v151: string = Spiral::method36(
                                    toString(v110_0_0.clone().display()),
                                    v4.clone(),
                                );
                                let v158: &str = &*v151;
                                let v191: std::string::String = String::from(v158);
                                let v224: std::path::PathBuf = std::path::PathBuf::from(v191);
                                Ok(v224)
                            }
                            Spiral::US14::US14_1(v110_1_0) => {
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
        pub fn method48(v0_1: string, v1_1: u8) -> Result<std::path::PathBuf, std::io::Error> {
            let v8: Result<std::path::PathBuf, std::io::Error> = std::fs::read_link(&*v0_1.clone());
            let v9 = Spiral::method49();
            let v22: Result<std::path::PathBuf, string> = v8.map_err(|x| v9(x));
            let v25 = Spiral::method51();
            let v26 = Spiral::method52();
            let v28: Spiral::US14 = match &v22 {
                Err(v22_1_0) => v26(v22_1_0.clone()),
                Ok(v22_0_0) => v25(v22_0_0.clone()),
            };
            match &v28 {
                Spiral::US14::US14_0(v28_0_0) => Ok(v28_0_0.clone()),
                Spiral::US14::US14_1(v28_1_0) => Spiral::method57(
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
        pub fn method59(v0_1: bool) -> i32 {
            unbox::<i32>(fable_library_rust::Native_::getZero())
        }
        pub fn method60() -> i32 {
            unbox::<i32>(fable_library_rust::Native_::getZero())
        }
        pub fn method61(v0_1: i32, v1_1: i32) -> bool {
            unbox::<bool>(fable_library_rust::Native_::getZero())
        }
        pub fn method63(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: std::io::Error,
            v4: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v5: string = Spiral::method55(v4.clone());
            let v6: Option<string> = Spiral::method41(v4.clone());
            let v25: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v6));
            let v29: string = Spiral::method50(v3);
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
                        let v92 = Spiral::method49();
                        let v105: Result<std::path::PathBuf, string> = v91.map_err(|x| v92(x));
                        let v108 = Spiral::method51();
                        let v109 = Spiral::method52();
                        let v111: Spiral::US14 = match &v105 {
                            Err(v105_1_0) => v109(v105_1_0.clone()),
                            Ok(v105_0_0) => v108(v105_0_0.clone()),
                        };
                        match &v111 {
                            Spiral::US14::US14_0(v111_0_0) => {
                                let v152: string = Spiral::method36(
                                    toString(v111_0_0.clone().display()),
                                    v5.clone(),
                                );
                                let v159: &str = &*v152;
                                let v192: std::string::String = String::from(v159);
                                let v225: std::path::PathBuf = std::path::PathBuf::from(v192);
                                Ok(v225)
                            }
                            Spiral::US14::US14_1(v111_1_0) => {
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
        pub fn method62(
            v0_1: string,
            v1_1: u8,
            v2: string,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v42: i32 = Spiral::method59(unbox::<bool>(fable_library_rust::Native_::getZero()));
            let v44: bool = Spiral::method61(Spiral::method60(), v42);
            if v44 {
                let v51: bool = unbox::<bool>(fable_library_rust::Native_::getZero());
                let v122: std::path::PathBuf = fable_library_rust::Native_::getZero();
                Ok(v122)
            } else {
                let v144: string =
                    append(string("file_system.read_link / Fsharp / The file or directory is not a reparse point. / "),
                           sprintf!("path: {} / result: {} / path\': {} / n: {}",
                                    v0_1.clone(), v44, v2.clone(), v1_1));
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
            Spiral::method62(v0_1, v1_1, v2)
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
        pub fn method64(
            v0_1: string,
            v1_1: Func2<u8, string, Result<std::path::PathBuf, std::io::Error>>,
            v2: u8,
            v3: std::io::Error,
        ) -> Result<std::path::PathBuf, std::io::Error> {
            let v4: string = Spiral::method55(v0_1.clone());
            let v5: Option<string> = Spiral::method41(v0_1.clone());
            let v24: Spiral::US5 = defaultValue(Spiral::US5::US5_1, map(Spiral::method6(), v5));
            let v28: string = Spiral::method50(v3);
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
                        let v91 = Spiral::method49();
                        let v104: Result<std::path::PathBuf, string> = v90.map_err(|x| v91(x));
                        let v107 = Spiral::method51();
                        let v108 = Spiral::method52();
                        let v110: Spiral::US14 = match &v104 {
                            Err(v104_1_0) => v108(v104_1_0.clone()),
                            Ok(v104_0_0) => v107(v104_0_0.clone()),
                        };
                        match &v110 {
                            Spiral::US14::US14_0(v110_0_0) => {
                                let v151: string = Spiral::method36(
                                    toString(v110_0_0.clone().display()),
                                    v4.clone(),
                                );
                                let v158: &str = &*v151;
                                let v191: std::string::String = String::from(v158);
                                let v224: std::path::PathBuf = std::path::PathBuf::from(v191);
                                Ok(v224)
                            }
                            Spiral::US14::US14_1(v110_1_0) => {
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
        pub fn method58(v0_1: string, v1_1: u8) -> Result<std::path::PathBuf, std::io::Error> {
            let v41: i32 = Spiral::method59(unbox::<bool>(fable_library_rust::Native_::getZero()));
            let v43: bool = Spiral::method61(Spiral::method60(), v41);
            if v43 {
                let v50: bool = unbox::<bool>(fable_library_rust::Native_::getZero());
                let v121: std::path::PathBuf = fable_library_rust::Native_::getZero();
                Ok(v121)
            } else {
                let v143: string =
                    append(string("file_system.read_link / Fsharp / The file or directory is not a reparse point. / "),
                           sprintf!("path: {} / result: {} / path\': {} / n: {}",
                                    v0_1.clone(), v43, v0_1.clone(), v1_1));
                Spiral::method64(
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
        pub fn method47(v0_1: string) -> Result<std::path::PathBuf, std::io::Error> {
            if Spiral::method39(v0_1.clone()) {
                std::fs::read_link(&*v0_1.clone())
            } else {
                Spiral::method48(v0_1, 0_u8)
            }
        }
        pub fn closure25(unitVar: (), v0_1: std::path::PathBuf) -> Spiral::US15 {
            Spiral::US15::US15_0(v0_1)
        }
        pub fn method65() -> Func1<std::path::PathBuf, Spiral::US15> {
            Func1::new(move |v: std::path::PathBuf| Spiral::closure25((), v))
        }
        pub fn method67(v0_1: string) -> string {
            v0_1
        }
        pub fn method68() -> string {
            string("")
        }
        pub fn method66(v0_1: string, v1_1: string, v2: string) -> string {
            let v6: Result<regex::Regex, regex::Error> = regex::Regex::new(&v0_1);
            let v10: regex::Regex = v6.unwrap();
            let v22: string = Spiral::method67(v2);
            let v24: std::borrow::Cow<str> = v10.replace_all(&*v22, &*v1_1);
            let v26: std::string::String = String::from(v24);
            fable_library_rust::String_::fromString(v26)
        }
        pub fn method46(v0_1: string) -> string {
            if (v0_1.clone()) == string("") {
                string("")
            } else {
                let v3: Result<std::path::PathBuf, std::io::Error> = Spiral::method47(v0_1.clone());
                let v7: Option<std::path::PathBuf> = v3.ok();
                let v37: Spiral::US15 =
                    defaultValue(Spiral::US15::US15_1, map(Spiral::method65(), v7));
                let v80: string = match &v37 {
                    Spiral::US15::US15_0(v37_0_0) => toString(
                        match &v37 {
                            Spiral::US15::US15_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone()
                        .display(),
                    ),
                    _ => v0_1.clone(),
                };
                let v85: string = Spiral::method66(
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
        pub fn method35(v0_1: string) -> Spiral::US5 {
            let v5: Spiral::US13 = Spiral::method37(
                Spiral::US12::US12_1,
                Spiral::method36(string("spiral"), string("workspace")),
                v0_1.clone(),
            );
            match &v5 {
                Spiral::US13::US13_0(v5_0_0) => {
                    Spiral::US5::US5_0(Spiral::method46(v5_0_0.clone()))
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
        pub fn method71(v0_1: i32, v1_1: LrcPtr<Spiral::Mut6>) -> bool {
            (v1_1.l0.get().clone()) < (v0_1)
        }
        pub fn method72() -> char {
            std::path::MAIN_SEPARATOR
        }
        pub fn method70(v0_1: string) -> string {
            let v12: &str = &*v0_1.clone();
            let v45: std::string::String = String::from(v12);
            let v78: std::path::PathBuf = std::path::PathBuf::from(v45);
            if (v78.exists()) == false {
                let v108: string = Spiral::method34();
                let v119: Array<string> = split(
                    Spiral::method46(Spiral::method36(v108.clone(), v0_1.clone())),
                    string("/"),
                    -1_i32,
                    0_i32,
                );
                let v123: i32 = get_Count(v119.clone());
                let v124: LrcPtr<Spiral::Mut6> = LrcPtr::new(Spiral::Mut6 {
                    l0: MutCell::new(0_i32),
                    l1: MutCell::new(0_i32),
                    l2: MutCell::new(new_empty::<string>()),
                });
                while Spiral::method71(v123, v124.clone()) {
                    let v126: i32 = v124.l0.get().clone();
                    let v129: i32 = ((v126.wrapping_neg()) + (v123)) - 1_i32;
                    let matchValue: i32 = v124.l1.get().clone();
                    let v131: Array<string> = v124.l2.get().clone();
                    let v130: i32 = matchValue;
                    let v132: string = v119[v129].clone();
                    let patternInput_1: (i32, Array<string>) = if string("..") == (v132.clone()) {
                        ((v130) + 1_i32, v131.clone())
                    } else {
                        if string(".") == (v132.clone()) {
                            (v130, v131.clone())
                        } else {
                            if 0_i32 == (v130) {
                                if endsWith3(v132.clone(), string(":"), false) {
                                    let v144: Array<string> = new_array(&[sprintf!(
                                        "{}:",
                                        getCharAt(v108.clone(), 0_i32)
                                    )]);
                                    let v145: i32 = get_Count(v144.clone());
                                    let v147: i32 = (v145) + (get_Count(v131.clone()));
                                    let v148: Array<string> = new_init(&string(""), v147);
                                    let v149: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method32(v147, v149.clone()) {
                                        let v151: i32 = v149.l0.get().clone();
                                        let v156: string = if (v151) < (v145) {
                                            v144[v151].clone()
                                        } else {
                                            let v154: i32 = (v151) - (v145);
                                            v131[v154].clone()
                                        };
                                        v148.get_mut()[v151 as usize] = v156;
                                        {
                                            let v157: i32 = (v151) + 1_i32;
                                            v149.l0.set(v157);
                                            ()
                                        }
                                    }
                                    (0_i32, v148.clone())
                                } else {
                                    let v158: Array<string> = new_array(&[v132]);
                                    let v159: i32 = get_Count(v158.clone());
                                    let v161: i32 = (v159) + (get_Count(v131.clone()));
                                    let v162: Array<string> = new_init(&string(""), v161);
                                    let v163: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method32(v161, v163.clone()) {
                                        let v165: i32 = v163.l0.get().clone();
                                        let v170: string = if (v165) < (v159) {
                                            v158[v165].clone()
                                        } else {
                                            let v168: i32 = (v165) - (v159);
                                            v131[v168].clone()
                                        };
                                        v162.get_mut()[v165 as usize] = v170;
                                        {
                                            let v171: i32 = (v165) + 1_i32;
                                            v163.l0.set(v171);
                                            ()
                                        }
                                    }
                                    (0_i32, v162.clone())
                                }
                            } else {
                                ((v130) - 1_i32, v131.clone())
                            }
                        }
                    };
                    let v181: i32 = (v126) + 1_i32;
                    v124.l0.set(v181);
                    v124.l1.set(patternInput_1.0.clone());
                    v124.l2.set(patternInput_1.1.clone());
                    ()
                }
                {
                    let matchValue_2: i32 = v124.l1.get().clone();
                    let v183: Array<string> = v124.l2.get().clone();
                    let _let__v188: LrcPtr<dyn IEnumerable_1<string>> = delay(Func0::new({
                        let v183 = v183.clone();
                        move || {
                            map_1(
                                Func1::new({
                                    let v183 = v183.clone();
                                    move |i: i32| v183[i].clone()
                                }),
                                rangeNumeric(0_i32, 1_i32, (get_Count(v183.clone())) - 1_i32),
                            )
                        }
                    }));
                    let v200: string = ofChar(Spiral::method72());
                    join(
                        if (v200.clone()) == string("\n") {
                            Spiral::method31(v200.clone())
                        } else {
                            v200
                        },
                        toArray_1(_let__v188),
                    )
                }
            } else {
                let v213: Result<std::path::PathBuf, std::io::Error> =
                    std::fs::canonicalize(&*v0_1);
                let v217: std::path::PathBuf = v213.unwrap();
                let v235: std::path::Display = v217.display();
                let v268: std::string::String = format!("{}", v235);
                fable_library_rust::String_::fromString(v268)
            }
        }
        pub fn method69(v0_1: string) -> string {
            Spiral::method46(Spiral::method70(v0_1))
        }
        pub fn method73(v0_1: Vec<std::string::String>) -> Vec<std::string::String> {
            v0_1
        }
        pub fn method74(v0_1: Vec<std::string::String>) -> Vec<std::string::String> {
            v0_1
        }
        pub fn method75() -> string {
            string("\n")
        }
        pub fn method77(v0_1: string, v1_1: string) -> bool {
            if (Spiral::method38(v0_1.clone())) == false {
                false
            } else {
                let v20: Result<Vec<u8>, std::io::Error> = std::fs::read(&*v0_1);
                let v65: Vec<u8> = Spiral::method27(v20.unwrap());
                let v67: Result<std::string::String, std::string::FromUtf8Error> =
                    std::string::String::from_utf8(v65);
                let v71: std::string::String = v67.unwrap();
                (v1_1) == (fable_library_rust::String_::fromString(v71))
            }
        }
        pub fn closure26(unitVar: (), v0_1: std::io::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method79() -> Func1<std::io::Error, std::string::String> {
            Func1::new(move |v: std::io::Error| Spiral::closure26((), v))
        }
        pub fn closure27(unitVar: (), unitVar_1: ()) -> Spiral::US16 {
            Spiral::US16::US16_0
        }
        pub fn method80() -> Func0<Spiral::US16> {
            Func0::new(move || Spiral::closure27((), ()))
        }
        pub fn closure28(unitVar: (), v0_1: std::string::String) -> Spiral::US16 {
            Spiral::US16::US16_1(v0_1)
        }
        pub fn method81() -> Func1<std::string::String, Spiral::US16> {
            Func1::new(move |v: std::string::String| Spiral::closure28((), v))
        }
        pub fn method82() -> string {
            let v8: string = Spiral::method13(getCharAt(toLower(string("Critical")), 0_i32));
            let v15: &str = inline_colorization::color_bright_red;
            let v22: &str = &*v8;
            let v50: &str = inline_colorization::color_reset;
            let v52: std::string::String = format!("{}{}{}", v15, v22, v50);
            fable_library_rust::String_::fromString(v52)
        }
        pub fn method84(v0_1: string, v1_1: std::string::String) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("dir"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v3.clone(), string("error"), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v83: std::string::String = format!("{:#?}", v1_1);
            let v122: () = {
                Spiral::closure7(v3.clone(), fable_library_rust::String_::fromString(v83), ());
                ()
            };
            let v133: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method83(
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
            let v10: string = Spiral::method84(v8, v9);
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
                Spiral::method19(Spiral::method83(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method82(),
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn method85() -> string {
            let v8: string = Spiral::method13(getCharAt(toLower(string("Verbose")), 0_i32));
            let v15: &str = inline_colorization::color_bright_black;
            let v22: &str = &*v8;
            let v50: &str = inline_colorization::color_reset;
            let v52: std::string::String = format!("{}{}{}", v15, v22, v50);
            fable_library_rust::String_::fromString(v52)
        }
        pub fn method87(v0_1: string) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral::closure7(v2.clone(), string("dir"), ());
                ()
            };
            let v33: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v42: () = {
                Spiral::closure7(v2.clone(), v0_1, ());
                ()
            };
            let v53: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
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
        ) -> string {
            let v9: string = Spiral::method87(v8);
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
                Spiral::method19(Spiral::method86(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method85(),
                    v0_1,
                ))
            };
        }
        pub fn method89(v0_1: bool, v1_1: string) {
            if Spiral::method39(v1_1.clone()) {
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
            Spiral::method89(true, v0_1);
        }
        pub fn method88(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure31(v0_1.clone(), ())
            })
        }
        pub fn method90(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure31(v0_1.clone(), ())
            })
        }
        pub fn method91(v0_1: string) -> bool {
            unbox::<bool>(fable_library_rust::Native_::getZero())
        }
        pub fn method93(v0_1: string, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("dir"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v3.clone(), string("result"), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method92(
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
            let v10: string = Spiral::method93(v8, v9);
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
                Spiral::method19(Spiral::method92(
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
        pub fn method99(v0_1: string, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("ex"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v3.clone(), string("path"), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method98(
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
            let v10: string = Spiral::method99(v8, v9);
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
                Spiral::method19(Spiral::method98(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method12(),
                    sprintf!("{:?}", v1_1),
                    Spiral::method55(v0_1),
                ))
            };
        }
        pub fn method97(v0_1: string, v1_1: i64) -> Arc<Async<i64>> {
            fable_library_rust::Native_::getZero()
        }
        pub fn method96(v0_1: string, v1_1: i64) -> Arc<Async<i64>> {
            fable_library_rust::Native_::getZero()
        }
        pub fn method95(v0_1: string) -> Arc<Async<i64>> {
            Spiral::method96(v0_1, 0_i64)
        }
        pub fn closure33(v0_1: string, unitVar: ()) {
            let v1_1: Arc<Async<i64>> = Spiral::method95(v0_1);
            let v8: Arc<Async<()>> = fable_library_rust::Native_::getZero();
            fable_library_rust::Native_::getZero::<()>();
            ()
        }
        pub fn method94(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure33(v0_1.clone(), ())
            })
        }
        pub fn method100(v0_1: string) -> Func0<()> {
            Func0::new({
                let v0_1 = v0_1.clone();
                move || Spiral::closure33(v0_1.clone(), ())
            })
        }
        pub fn method78(v0_1: string) -> LrcPtr<dyn IDisposable> {
            let v156: Result<(), std::io::Error> = std::fs::create_dir_all(&*v0_1.clone());
            let v157 = Spiral::method79();
            let v170: Result<(), std::string::String> = v156.map_err(|x| v157(x));
            let v173 = Spiral::method80();
            let v174 = Spiral::method81();
            let v176: Spiral::US16 = match &v170 {
                Err(v170_1_0) => v174(v170_1_0.clone()),
                _ => v173(),
            };
            match &v176 {
                Spiral::US16::US16_0 => {
                    let v181: () = {
                        Spiral::closure30(v0_1.clone(), ());
                        ()
                    };
                    ()
                }
                Spiral::US16::US16_1(v176_1_0) => {
                    let v231: () = {
                        Spiral::closure29(
                            v0_1.clone(),
                            match &v176 {
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
                let v283 = Spiral::method88(v0_1.clone());
                interface_cast!(
                    Spiral::Disposable::_ctor__3A5B6456(Func0::new({
                        let v283 = v283.clone();
                        move || v283.clone()()
                    })),
                    Lrc<dyn IDisposable>,
                )
            }
        }
        pub fn method76(v0_1: string, v1_1: string) {
            if (Spiral::method77(v0_1.clone(), v1_1.clone())) == false {
                let v8: string = defaultValue(string(""), Spiral::method41(v0_1.clone()));
                if (Spiral::method39(v8.clone())) == false {
                    let v13: LrcPtr<dyn IDisposable> = Spiral::method78(v8);
                    ()
                }
                std::fs::write(&*v0_1, &*v1_1).unwrap();
                ()
            };
        }
        pub fn method102(
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
        pub fn method104() -> string {
            string("")
        }
        pub fn method105(v0_1: i64, v1_1: string, v2: i64) -> LrcPtr<Spiral::UH0> {
            if (v2) < (v0_1) {
                LrcPtr::new(Spiral::UH0::UH0_1(
                    getCharAt(v1_1.clone(), v2 as i32),
                    Spiral::method105(v0_1, v1_1, (v2) + 1_i64),
                ))
            } else {
                LrcPtr::new(Spiral::UH0::UH0_0)
            }
        }
        pub fn method106(
            v0_1: LrcPtr<Spiral::UH0>,
            v1_1: LrcPtr<StringBuilder>,
            v2: i32,
            v3: i32,
        ) -> (LrcPtr<StringBuilder>, i32, i32) {
            let v0_1: MutCell<LrcPtr<Spiral::UH0>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
            let v2: MutCell<i32> = MutCell::new(v2);
            let v3: MutCell<i32> = MutCell::new(v3);
            '_method106: loop {
                break '_method106 (match v0_1.get().clone().as_ref() {
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
                            continue '_method106;
                        }
                    }
                });
            }
        }
        pub fn closure36(v0_1: i32, v1_1: i32, v2: string) -> string {
            if (v1_1) >= (v0_1) {
                v2.clone()
            } else {
                (Spiral::method107(v0_1, (v1_1) + 1_i32))(append((v2), string(" ")))
            }
        }
        pub fn method107(v0_1: i32, v1_1: i32) -> Func1<string, string> {
            Func1::new({
                let v0_1 = v0_1.clone();
                let v1_1 = v1_1.clone();
                move |v: string| Spiral::closure36(v0_1, v1_1, v)
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
                let v10: char = getCharAt(v0_1.clone(), 0_i32);
                if (v10) == '\"' {
                    let v45: string = getSlice(
                        v0_1.clone(),
                        Some(1_i32),
                        Some((length(v0_1.clone())) - 1_i32),
                    );
                    let v51: string = ofChar(v10);
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method106(
                        Spiral::method105(length(v51.clone()) as i64, v51, 0_i64),
                        v1_1.clone(),
                        v2,
                        v3,
                    );
                    Spiral::US18::US18_0(
                        v10,
                        v45,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                } else {
                    let v66: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                    (if -2_i32 == (v66) {
                                        (length(v0_1)) + 1_i32
                                    } else {
                                        (v66) + 1_i32
                                    }) - 1_i32
                                )
                            )
                        ),
                        string("\n"),
                        append(
                            ((Spiral::method107((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            }
        }
        pub fn closure37(
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
                let v10: char = getCharAt(v0_1.clone(), 0_i32);
                if (v10) == '\'' {
                    let v45: string = getSlice(
                        v0_1.clone(),
                        Some(1_i32),
                        Some((length(v0_1.clone())) - 1_i32),
                    );
                    let v51: string = ofChar(v10);
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method106(
                        Spiral::method105(length(v51.clone()) as i64, v51, 0_i64),
                        v1_1.clone(),
                        v2,
                        v3,
                    );
                    Spiral::US18::US18_0(
                        v10,
                        v45,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                } else {
                    let v66: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                    (if -2_i32 == (v66) {
                                        (length(v0_1)) + 1_i32
                                    } else {
                                        (v66) + 1_i32
                                    }) - 1_i32
                                )
                            )
                        ),
                        string("\n"),
                        append(
                            ((Spiral::method107((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            }
        }
        pub fn method108(
            v0_1: string,
            v1_1: LrcPtr<StringBuilder>,
            v2: LrcPtr<Spiral::UH1>,
        ) -> Spiral::US18 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<StringBuilder>> = MutCell::new(v1_1.clone());
            let v2: MutCell<LrcPtr<Spiral::UH1>> = MutCell::new(v2.clone());
            '_method108: loop {
                break '_method108 (match v2.get().clone().as_ref() {
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
                                continue '_method108;
                            }
                        }
                    }
                });
            }
        }
        pub fn method109(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method109: loop {
                break '_method109 (if (v1_1.get().clone()) >= 2_i64 {
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
                        continue '_method109;
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
                    let v98: Spiral::US18 = if string("") == (v1_1.get().clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v25: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method109(v25, 0_i64)) == false {
                            let v62: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v68: string = ofChar(v25);
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method106(
                                Spiral::method105(length(v68.clone()) as i64, v68, 0_i64),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Spiral::US18::US18_0(
                                v25,
                                v62,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        } else {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v25,
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v110: Spiral::US18 = match &v98 {
                        Spiral::US18::US18_0(v98_0_0, v98_0_1, v98_0_2, v98_0_3, v98_0_4) => {
                            let v99: char = v98_0_0.clone();
                            Spiral::US18::US18_0(
                                if '\\' == (v99) { '/' } else { v99 },
                                v98_0_1.clone(),
                                v98_0_2.clone(),
                                v98_0_3.clone(),
                                v98_0_4.clone(),
                            )
                        }
                        Spiral::US18::US18_1(v98_1_0) => Spiral::US18::US18_1(v98_1_0.clone()),
                    };
                    match &v110 {
                        Spiral::US18::US18_0(v110_0_0, v110_0_1, v110_0_2, v110_0_3, v110_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v110_0_0.clone())));
                            let v1_1_temp: string = v110_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v110_0_2.clone();
                            let v3_temp: i32 = v110_0_3.clone();
                            let v4_temp: i32 = v110_0_4.clone();
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
        pub fn method111(
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
            '_method111: loop {
                break '_method111 (match v4.get().clone().as_ref() {
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
                                continue '_method111;
                            }
                        }
                    }
                });
            }
        }
        pub fn method112(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method112: loop {
                break '_method112 (if (v1_1.get().clone()) >= 3_i64 {
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
                        continue '_method112;
                    }
                });
            }
        }
        pub fn method113(
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
            '_method113: loop {
                break '_method113 ({
                    let v106: Spiral::US18 = if string("") == (v1_1.get().clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method112(v29, 0_i64)) == false {
                            let v66: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v72: string = ofChar(v29);
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method106(
                                Spiral::method105(length(v72.clone()) as i64, v72, 0_i64),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Spiral::US18::US18_0(
                                v29,
                                v66,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        } else {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v29,
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v118: Spiral::US18 = match &v106 {
                        Spiral::US18::US18_0(v106_0_0, v106_0_1, v106_0_2, v106_0_3, v106_0_4) => {
                            let v107: char = v106_0_0.clone();
                            Spiral::US18::US18_0(
                                if '\\' == (v107) { '/' } else { v107 },
                                v106_0_1.clone(),
                                v106_0_2.clone(),
                                v106_0_3.clone(),
                                v106_0_4.clone(),
                            )
                        }
                        Spiral::US18::US18_1(v106_1_0) => Spiral::US18::US18_1(v106_1_0.clone()),
                    };
                    match &v118 {
                        Spiral::US18::US18_0(v118_0_0, v118_0_1, v118_0_2, v118_0_3, v118_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v118_0_0.clone())));
                            let v1_1_temp: string = v118_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v118_0_2.clone();
                            let v3_temp: i32 = v118_0_3.clone();
                            let v4_temp: i32 = v118_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method113;
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
        pub fn method114(v0_1: string, v1_1: i32) -> i32 {
            let v0_1: MutCell<string> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<i32> = MutCell::new(v1_1);
            '_method114: loop {
                break '_method114 (if (v1_1.get().clone()) >= (length(v0_1.get().clone())) {
                    v1_1.get().clone()
                } else {
                    if ' ' == (getCharAt(v0_1.get().clone(), v1_1.get().clone())) {
                        let v0_1_temp: string = v0_1.get().clone();
                        let v1_1_temp: i32 = (v1_1.get().clone()) + 1_i32;
                        v0_1.set(v0_1_temp);
                        v1_1.set(v1_1_temp);
                        continue '_method114;
                    } else {
                        v1_1.get().clone()
                    }
                });
            }
        }
        pub fn method115(
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
            '_method115: loop {
                break '_method115 ({
                    let v66: Spiral::US18 = if string("") == (v1_1.get().clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.any_char / unexpected end of input / s: {:?}",
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v16: char = getCharAt(v1_1.get().clone(), 0_i32);
                        let v50: string = getSlice(
                            v1_1.get().clone(),
                            Some(1_i32),
                            Some((length(v1_1.get().clone())) - 1_i32),
                        );
                        let v56: string = ofChar(v16);
                        let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method106(
                            Spiral::method105(length(v56.clone()) as i64, v56, 0_i64),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        );
                        Spiral::US18::US18_0(
                            v16,
                            v50,
                            patternInput.0.clone(),
                            patternInput.1.clone(),
                            patternInput.2.clone(),
                        )
                    };
                    match &v66 {
                        Spiral::US18::US18_0(v66_0_0, v66_0_1, v66_0_2, v66_0_3, v66_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v66_0_0.clone())));
                            let v1_1_temp: string = v66_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v66_0_2.clone();
                            let v3_temp: i32 = v66_0_3.clone();
                            let v4_temp: i32 = v66_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method115;
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
        pub fn method103(v0_1: string) -> Spiral::US17 {
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
                    StringBuilder::_ctor__Z721C83C5(Spiral::method104());
                fn v19(arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)) -> Spiral::US18 {
                    Spiral::closure35((), arg10_0040)
                }
                fn v20(arg10_0040_1: (string, LrcPtr<StringBuilder>, i32, i32)) -> Spiral::US18 {
                    Spiral::closure37((), arg10_0040_1)
                }
                let v24: Spiral::US18 = Spiral::method108(
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
                let v197: Spiral::US19 = match &v24 {
                    Spiral::US18::US18_0(v24_0_0, v24_0_1, v24_0_2, v24_0_3, v24_0_4) => {
                        let v29: i32 = v24_0_4.clone();
                        let v28: i32 = v24_0_3.clone();
                        let v27: LrcPtr<StringBuilder> = v24_0_2.clone();
                        let v26: string = v24_0_1.clone();
                        let v123: Spiral::US18 = if string("") == (v26.clone()) {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                                toArray(ofArray(new_array(&['\"', '\'']))),
                                (v27.clone(), v28, v29)
                            ))
                        } else {
                            let v50: char = getCharAt(v26.clone(), 0_i32);
                            if (Spiral::method109(v50, 0_i64)) == false {
                                let v87: string = getSlice(
                                    v26.clone(),
                                    Some(1_i32),
                                    Some((length(v26.clone())) - 1_i32),
                                );
                                let v93: string = ofChar(v50);
                                let patternInput: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method106(
                                        Spiral::method105(length(v93.clone()) as i64, v93, 0_i64),
                                        v27.clone(),
                                        v28,
                                        v29,
                                    );
                                Spiral::US18::US18_0(
                                    v50,
                                    v87,
                                    patternInput.0.clone(),
                                    patternInput.1.clone(),
                                    patternInput.2.clone(),
                                )
                            } else {
                                Spiral::US18::US18_1(sprintf!("parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                                                      v50,
                                                                      toArray(ofArray(new_array(&['\"',
                                                                                                  '\'']))),
                                                                      (v27.clone(),
                                                                       v28,
                                                                       v29)))
                            }
                        };
                        let v135: Spiral::US18 = match &v123 {
                            Spiral::US18::US18_0(
                                v123_0_0,
                                v123_0_1,
                                v123_0_2,
                                v123_0_3,
                                v123_0_4,
                            ) => {
                                let v124: char = v123_0_0.clone();
                                Spiral::US18::US18_0(
                                    if '\\' == (v124) { '/' } else { v124 },
                                    v123_0_1.clone(),
                                    v123_0_2.clone(),
                                    v123_0_3.clone(),
                                    v123_0_4.clone(),
                                )
                            }
                            Spiral::US18::US18_1(v123_1_0) => {
                                Spiral::US18::US18_1(v123_1_0.clone())
                            }
                        };
                        let v155: Spiral::US19 = match &v135 {
                            Spiral::US18::US18_0(
                                v135_0_0,
                                v135_0_1,
                                v135_0_2,
                                v135_0_3,
                                v135_0_4,
                            ) => {
                                let patternInput_1: (
                                    string,
                                    string,
                                    LrcPtr<StringBuilder>,
                                    i32,
                                    i32,
                                ) = Spiral::method110(
                                    ofChar(v135_0_0.clone()),
                                    v135_0_1.clone(),
                                    v135_0_2.clone(),
                                    v135_0_3.clone(),
                                    v135_0_4.clone(),
                                );
                                Spiral::US19::US19_0(
                                    patternInput_1.0.clone(),
                                    patternInput_1.1.clone(),
                                    patternInput_1.2.clone(),
                                    patternInput_1.3.clone(),
                                    patternInput_1.4.clone(),
                                )
                            }
                            Spiral::US18::US18_1(v135_1_0) => {
                                Spiral::US19::US19_1(v135_1_0.clone())
                            }
                        };
                        let v165: Spiral::US19 = match &v155 {
                            Spiral::US19::US19_0(
                                v155_0_0,
                                v155_0_1,
                                v155_0_2,
                                v155_0_3,
                                v155_0_4,
                            ) => Spiral::US19::US19_0(
                                v155_0_0.clone(),
                                v155_0_1.clone(),
                                v155_0_2.clone(),
                                v155_0_3.clone(),
                                v155_0_4.clone(),
                            ),
                            _ => {
                                Spiral::US19::US19_0(string(""), v26.clone(), v27.clone(), v28, v29)
                            }
                        };
                        match &v165 {
                            Spiral::US19::US19_0(
                                v165_0_0,
                                v165_0_1,
                                v165_0_2,
                                v165_0_3,
                                v165_0_4,
                            ) => {
                                let v170: i32 = v165_0_4.clone();
                                let v169: i32 = v165_0_3.clone();
                                let v168: LrcPtr<StringBuilder> = v165_0_2.clone();
                                let v167: string = v165_0_1.clone();
                                let v174: Spiral::US18 = Spiral::method111(
                                    v167.clone(),
                                    v168.clone(),
                                    v169,
                                    v170,
                                    LrcPtr::new(Spiral::UH1::UH1_1(
                                        Func1::from(v19),
                                        LrcPtr::new(Spiral::UH1::UH1_1(
                                            Func1::from(v20),
                                            LrcPtr::new(Spiral::UH1::UH1_0),
                                        )),
                                    )),
                                );
                                match &v174 {
                                        Spiral::US18::US18_0(v174_0_0,
                                                             v174_0_1,
                                                             v174_0_2,
                                                             v174_0_3,
                                                             v174_0_4) =>
                                        Spiral::US19::US19_0(v165_0_0.clone(),
                                                             v174_0_1.clone(),
                                                             v174_0_2.clone(),
                                                             v174_0_3.clone(),
                                                             v174_0_4.clone()),
                                        Spiral::US18::US18_1(v174_1_0) =>
                                        Spiral::US19::US19_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                      v174_1_0.clone(),
                                                                      (v10.clone(),
                                                                       v16.clone(),
                                                                       1_i32,
                                                                       1_i32),
                                                                      (v26.clone(),
                                                                       v27.clone(),
                                                                       v28,
                                                                       v29),
                                                                      (v167.clone(),
                                                                       v168.clone(),
                                                                       v169,
                                                                       v170))),
                                    }
                            }
                            _ => Spiral::US19::US19_1(string("parsing.between / expected content")),
                        }
                    }
                    Spiral::US18::US18_1(v24_1_0) => Spiral::US19::US19_1(v24_1_0.clone()),
                };
                let v416: Spiral::US19 = match &v197 {
                    Spiral::US19::US19_0(v197_0_0, v197_0_1, v197_0_2, v197_0_3, v197_0_4) => {
                        v197.clone()
                    }
                    _ => {
                        let v307: Spiral::US18 = if string("") == (v10.clone()) {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                                toArray(ofArray(new_array(&['\"', '\'', ' ']))),
                                (v16.clone(), 1_i32, 1_i32)
                            ))
                        } else {
                            let v228: char = getCharAt(v10.clone(), 0_i32);
                            if (Spiral::method112(v228, 0_i64)) == false {
                                let v265: string = getSlice(
                                    v10.clone(),
                                    Some(1_i32),
                                    Some((length(v10.clone())) - 1_i32),
                                );
                                let v271: string = ofChar(v228);
                                let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method106(
                                        Spiral::method105(length(v271.clone()) as i64, v271, 0_i64),
                                        v16.clone(),
                                        1_i32,
                                        1_i32,
                                    );
                                Spiral::US18::US18_0(
                                    v228,
                                    v265,
                                    patternInput_2.0.clone(),
                                    patternInput_2.1.clone(),
                                    patternInput_2.2.clone(),
                                )
                            } else {
                                Spiral::US18::US18_1(sprintf!("parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                                                      v228,
                                                                      toArray(ofArray(new_array(&['\"',
                                                                                                  '\'',
                                                                                                  ' ']))),
                                                                      (v16.clone(),
                                                                       1_i32,
                                                                       1_i32)))
                            }
                        };
                        let v319: Spiral::US18 = match &v307 {
                            Spiral::US18::US18_0(
                                v307_0_0,
                                v307_0_1,
                                v307_0_2,
                                v307_0_3,
                                v307_0_4,
                            ) => {
                                let v308: char = v307_0_0.clone();
                                Spiral::US18::US18_0(
                                    if '\\' == (v308) { '/' } else { v308 },
                                    v307_0_1.clone(),
                                    v307_0_2.clone(),
                                    v307_0_3.clone(),
                                    v307_0_4.clone(),
                                )
                            }
                            Spiral::US18::US18_1(v307_1_0) => {
                                Spiral::US18::US18_1(v307_1_0.clone())
                            }
                        };
                        let v339: Spiral::US19 = match &v319 {
                            Spiral::US18::US18_0(
                                v319_0_0,
                                v319_0_1,
                                v319_0_2,
                                v319_0_3,
                                v319_0_4,
                            ) => {
                                let patternInput_3: (
                                    string,
                                    string,
                                    LrcPtr<StringBuilder>,
                                    i32,
                                    i32,
                                ) = Spiral::method113(
                                    ofChar(v319_0_0.clone()),
                                    v319_0_1.clone(),
                                    v319_0_2.clone(),
                                    v319_0_3.clone(),
                                    v319_0_4.clone(),
                                );
                                Spiral::US19::US19_0(
                                    patternInput_3.0.clone(),
                                    patternInput_3.1.clone(),
                                    patternInput_3.2.clone(),
                                    patternInput_3.3.clone(),
                                    patternInput_3.4.clone(),
                                )
                            }
                            Spiral::US18::US18_1(v319_1_0) => {
                                Spiral::US19::US19_1(v319_1_0.clone())
                            }
                        };
                        match &v339 {
                            Spiral::US19::US19_0(
                                v339_0_0,
                                v339_0_1,
                                v339_0_2,
                                v339_0_3,
                                v339_0_4,
                            ) => v339.clone(),
                            _ => {
                                let v354: Spiral::US21 = if (length(v10.clone())) == 0_i32 {
                                    Spiral::US21::US21_0(v10.clone(), v16.clone(), 1_i32, 1_i32)
                                } else {
                                    Spiral::US21::US21_1(sprintf!(
                                        "parsing.eof / expected end of input / input: {:?}",
                                        v10.clone()
                                    ))
                                };
                                let v363: Spiral::US19 = match &v354 {
                                    Spiral::US21::US21_0(
                                        v354_0_0,
                                        v354_0_1,
                                        v354_0_2,
                                        v354_0_3,
                                    ) => Spiral::US19::US19_0(
                                        string(""),
                                        v354_0_0.clone(),
                                        v354_0_1.clone(),
                                        v354_0_2.clone(),
                                        v354_0_3.clone(),
                                    ),
                                    Spiral::US21::US21_1(v354_1_0) => {
                                        Spiral::US19::US19_1(v354_1_0.clone())
                                    }
                                };
                                match &v363 {
                                    Spiral::US19::US19_0(
                                        v363_0_0,
                                        v363_0_1,
                                        v363_0_2,
                                        v363_0_3,
                                        v363_0_4,
                                    ) => {
                                        let v365: string = v363_0_1.clone();
                                        Spiral::US19::US19_0(
                                            v363_0_0.clone(),
                                            getSlice(
                                                v365.clone(),
                                                Some(Spiral::method114(v365.clone(), 0_i32)),
                                                Some((length(v365)) - 1_i32),
                                            ),
                                            v363_0_2.clone(),
                                            v363_0_3.clone(),
                                            v363_0_4.clone(),
                                        )
                                    }
                                    Spiral::US19::US19_1(v363_1_0) => {
                                        Spiral::US19::US19_1(v363_1_0.clone())
                                    }
                                }
                            }
                        }
                    }
                };
                let v671: Spiral::US22 = match &v416 {
                    Spiral::US19::US19_0(v416_0_0, v416_0_1, v416_0_2, v416_0_3, v416_0_4) => {
                        let v421: i32 = v416_0_4.clone();
                        let v420: i32 = v416_0_3.clone();
                        let v419: LrcPtr<StringBuilder> = v416_0_2.clone();
                        let v418: string = v416_0_1.clone();
                        let v542: Spiral::US18 = if string("") == (v418.clone()) {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                ' ',
                                (v419.clone(), v420, v421)
                            ))
                        } else {
                            let v428: char = getCharAt(v418.clone(), 0_i32);
                            if (v428) == ' ' {
                                let v463: string = getSlice(
                                    v418.clone(),
                                    Some(1_i32),
                                    Some((length(v418.clone())) - 1_i32),
                                );
                                let v469: string = ofChar(v428);
                                let patternInput_4: (LrcPtr<StringBuilder>, i32, i32) =
                                    Spiral::method106(
                                        Spiral::method105(length(v469.clone()) as i64, v469, 0_i64),
                                        v419.clone(),
                                        v420,
                                        v421,
                                    );
                                Spiral::US18::US18_0(
                                    v428,
                                    v463,
                                    patternInput_4.0.clone(),
                                    patternInput_4.1.clone(),
                                    patternInput_4.2.clone(),
                                )
                            } else {
                                let v484: i32 = (indexOf(v418.clone(), string("\n"))) - 1_i32;
                                Spiral::US18::US18_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                         ' ',
                                                                                         v420,
                                                                                         v421,
                                                                                         v419.clone(),
                                                                                         getSlice(v418.clone(),
                                                                                                  Some(0_i32),
                                                                                                  Some((if -2_i32
                                                                                                               ==
                                                                                                               (v484)
                                                                                                           {
                                                                                                            (length(v418.clone()))
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
                                                                                append(((Spiral::method107((v421)
                                                                                                               -
                                                                                                               1_i32,
                                                                                                           0_i32))(string(""))),
                                                                                       string("^")),
                                                                                string("\n")])))
                            }
                        };
                        let v554: Spiral::US23 = match &v542 {
                            Spiral::US18::US18_0(
                                v542_0_0,
                                v542_0_1,
                                v542_0_2,
                                v542_0_3,
                                v542_0_4,
                            ) => Spiral::US23::US23_0(
                                Spiral::US20::US20_0(v542_0_0.clone()),
                                v542_0_1.clone(),
                                v542_0_2.clone(),
                                v542_0_3.clone(),
                                v542_0_4.clone(),
                            ),
                            _ => Spiral::US23::US23_0(
                                Spiral::US20::US20_1,
                                v418.clone(),
                                v419.clone(),
                                v420,
                                v421,
                            ),
                        };
                        let v645: Spiral::US19 = match &v554 {
                            Spiral::US23::US23_0(
                                v554_0_0,
                                v554_0_1,
                                v554_0_2,
                                v554_0_3,
                                v554_0_4,
                            ) => {
                                let v559: i32 = v554_0_4.clone();
                                let v558: i32 = v554_0_3.clone();
                                let v557: LrcPtr<StringBuilder> = v554_0_2.clone();
                                let v556: string = v554_0_1.clone();
                                let v621: Spiral::US18 = if string("") == (v556.clone()) {
                                    Spiral::US18::US18_1(sprintf!(
                                        "parsing.any_char / unexpected end of input / s: {:?}",
                                        (v557.clone(), v558, v559)
                                    ))
                                } else {
                                    let v571: char = getCharAt(v556.clone(), 0_i32);
                                    let v605: string = getSlice(
                                        v556.clone(),
                                        Some(1_i32),
                                        Some((length(v556)) - 1_i32),
                                    );
                                    let v611: string = ofChar(v571);
                                    let patternInput_5: (LrcPtr<StringBuilder>, i32, i32) =
                                        Spiral::method106(
                                            Spiral::method105(
                                                length(v611.clone()) as i64,
                                                v611,
                                                0_i64,
                                            ),
                                            v557,
                                            v558,
                                            v559,
                                        );
                                    Spiral::US18::US18_0(
                                        v571,
                                        v605,
                                        patternInput_5.0.clone(),
                                        patternInput_5.1.clone(),
                                        patternInput_5.2.clone(),
                                    )
                                };
                                match &v621 {
                                    Spiral::US18::US18_0(
                                        v621_0_0,
                                        v621_0_1,
                                        v621_0_2,
                                        v621_0_3,
                                        v621_0_4,
                                    ) => {
                                        let patternInput_6: (
                                            string,
                                            string,
                                            LrcPtr<StringBuilder>,
                                            i32,
                                            i32,
                                        ) = Spiral::method115(
                                            ofChar(v621_0_0.clone()),
                                            v621_0_1.clone(),
                                            v621_0_2.clone(),
                                            v621_0_3.clone(),
                                            v621_0_4.clone(),
                                        );
                                        Spiral::US19::US19_0(
                                            patternInput_6.0.clone(),
                                            patternInput_6.1.clone(),
                                            patternInput_6.2.clone(),
                                            patternInput_6.3.clone(),
                                            patternInput_6.4.clone(),
                                        )
                                    }
                                    Spiral::US18::US18_1(v621_1_0) => {
                                        Spiral::US19::US19_1(v621_1_0.clone())
                                    }
                                }
                            }
                            Spiral::US23::US23_1(v554_1_0) => {
                                Spiral::US19::US19_1(v554_1_0.clone())
                            }
                        };
                        let v657: Spiral::US24 = match &v645 {
                            Spiral::US19::US19_0(
                                v645_0_0,
                                v645_0_1,
                                v645_0_2,
                                v645_0_3,
                                v645_0_4,
                            ) => Spiral::US24::US24_0(
                                Spiral::US5::US5_0(v645_0_0.clone()),
                                v645_0_1.clone(),
                                v645_0_2.clone(),
                                v645_0_3.clone(),
                                v645_0_4.clone(),
                            ),
                            _ => Spiral::US24::US24_0(
                                Spiral::US5::US5_1,
                                v418.clone(),
                                v419.clone(),
                                v420,
                                v421,
                            ),
                        };
                        match &v657 {
                            Spiral::US24::US24_0(
                                v657_0_0,
                                v657_0_1,
                                v657_0_2,
                                v657_0_3,
                                v657_0_4,
                            ) => Spiral::US22::US22_0(
                                v416_0_0.clone(),
                                v657_0_0.clone(),
                                v657_0_1.clone(),
                                v657_0_2.clone(),
                                v657_0_3.clone(),
                                v657_0_4.clone(),
                            ),
                            Spiral::US24::US24_1(v657_1_0) => {
                                Spiral::US22::US22_1(v657_1_0.clone())
                            }
                        }
                    }
                    Spiral::US19::US19_1(v416_1_0) => Spiral::US22::US22_1(v416_1_0.clone()),
                };
                match &v671 {
                    Spiral::US22::US22_0(
                        v671_0_0,
                        v671_0_1,
                        v671_0_2,
                        v671_0_3,
                        v671_0_4,
                        v671_0_5,
                    ) => Spiral::US17::US17_0(v671_0_0.clone(), v671_0_1.clone()),
                    Spiral::US22::US22_1(v671_1_0) => Spiral::US17::US17_1(v671_1_0.clone()),
                }
            }
        }
        pub fn method118(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method118: loop {
                break '_method118 (if (v1_1.get().clone()) >= 4_i64 {
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
                        continue '_method118;
                    }
                });
            }
        }
        pub fn method119(
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
            '_method119: loop {
                break '_method119 ({
                    let v114: Spiral::US18 = if string("") == (v1_1.get().clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v33: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method118(v33, 0_i64)) == false {
                            let v70: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v76: string = ofChar(v33);
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method106(
                                Spiral::method105(length(v76.clone()) as i64, v76, 0_i64),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Spiral::US18::US18_0(
                                v33,
                                v70,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        } else {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v33,
                                toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    match &v114 {
                        Spiral::US18::US18_0(v114_0_0, v114_0_1, v114_0_2, v114_0_3, v114_0_4) => {
                            let v0_1_temp: string =
                                append((v0_1.get().clone()), (ofChar(v114_0_0.clone())));
                            let v1_1_temp: string = v114_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v114_0_2.clone();
                            let v3_temp: i32 = v114_0_3.clone();
                            let v4_temp: i32 = v114_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method119;
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
        pub fn method121(v0_1: char, v1_1: i64) -> bool {
            let v0_1: MutCell<char> = MutCell::new(v0_1);
            let v1_1: MutCell<i64> = MutCell::new(v1_1);
            '_method121: loop {
                break '_method121 (if (v1_1.get().clone()) >= 3_i64 {
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
                        continue '_method121;
                    }
                });
            }
        }
        pub fn closure38(
            unitVar: (),
            _arg: (string, LrcPtr<StringBuilder>, i32, i32),
        ) -> Spiral::US19 {
            let v3: i32 = _arg.3.clone();
            let v2: i32 = _arg.2.clone();
            let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
            let v0_1: string = _arg.0.clone();
            let v125: Spiral::US18 = if string("") == (v0_1.clone()) {
                Spiral::US18::US18_1(sprintf!(
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
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method106(
                        Spiral::method105(length(v51.clone()) as i64, v51, 0_i64),
                        v1_1.clone(),
                        v2,
                        v3,
                    );
                    Spiral::US18::US18_0(
                        v10,
                        v45,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                } else {
                    let v66: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                    (if -2_i32 == (v66) {
                                        (length(v0_1)) + 1_i32
                                    } else {
                                        (v66) + 1_i32
                                    }) - 1_i32
                                )
                            )
                        ),
                        string("\n"),
                        append(
                            ((Spiral::method107((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            };
            let v196: Spiral::US18 = match &v125 {
                Spiral::US18::US18_0(v125_0_0, v125_0_1, v125_0_2, v125_0_3, v125_0_4) => {
                    let v130: i32 = v125_0_4.clone();
                    let v129: i32 = v125_0_3.clone();
                    let v128: LrcPtr<StringBuilder> = v125_0_2.clone();
                    let v127: string = v125_0_1.clone();
                    if string("") == (v127.clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.any_char / unexpected end of input / s: {:?}",
                            (v128.clone(), v129, v130)
                        ))
                    } else {
                        let v142: char = getCharAt(v127.clone(), 0_i32);
                        let v176: string =
                            getSlice(v127.clone(), Some(1_i32), Some((length(v127)) - 1_i32));
                        let v182: string = ofChar(v142);
                        let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method106(
                            Spiral::method105(length(v182.clone()) as i64, v182, 0_i64),
                            v128,
                            v129,
                            v130,
                        );
                        Spiral::US18::US18_0(
                            v142,
                            v176,
                            patternInput_1.0.clone(),
                            patternInput_1.1.clone(),
                            patternInput_1.2.clone(),
                        )
                    }
                }
                Spiral::US18::US18_1(v125_1_0) => Spiral::US18::US18_1(v125_1_0.clone()),
            };
            match &v196 {
                Spiral::US18::US18_0(v196_0_0, v196_0_1, v196_0_2, v196_0_3, v196_0_4) => {
                    Spiral::US19::US19_0(
                        append((ofChar('\\')), (ofChar(v196_0_0.clone()))),
                        v196_0_1.clone(),
                        v196_0_2.clone(),
                        v196_0_3.clone(),
                        v196_0_4.clone(),
                    )
                }
                Spiral::US18::US18_1(v196_1_0) => Spiral::US19::US19_1(v196_1_0.clone()),
            }
        }
        pub fn closure39(
            unitVar: (),
            _arg: (string, LrcPtr<StringBuilder>, i32, i32),
        ) -> Spiral::US19 {
            let v3: i32 = _arg.3.clone();
            let v2: i32 = _arg.2.clone();
            let v1_1: LrcPtr<StringBuilder> = _arg.1.clone();
            let v0_1: string = _arg.0.clone();
            let v125: Spiral::US18 = if string("") == (v0_1.clone()) {
                Spiral::US18::US18_1(sprintf!(
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
                    let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method106(
                        Spiral::method105(length(v51.clone()) as i64, v51, 0_i64),
                        v1_1.clone(),
                        v2,
                        v3,
                    );
                    Spiral::US18::US18_0(
                        v10,
                        v45,
                        patternInput.0.clone(),
                        patternInput.1.clone(),
                        patternInput.2.clone(),
                    )
                } else {
                    let v66: i32 = (indexOf(v0_1.clone(), string("\n"))) - 1_i32;
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
                                    (if -2_i32 == (v66) {
                                        (length(v0_1)) + 1_i32
                                    } else {
                                        (v66) + 1_i32
                                    }) - 1_i32
                                )
                            )
                        ),
                        string("\n"),
                        append(
                            ((Spiral::method107((v3) - 1_i32, 0_i32))(string(""))),
                            string("^"),
                        ),
                        string("\n"),
                    ])))
                }
            };
            let v196: Spiral::US18 = match &v125 {
                Spiral::US18::US18_0(v125_0_0, v125_0_1, v125_0_2, v125_0_3, v125_0_4) => {
                    let v130: i32 = v125_0_4.clone();
                    let v129: i32 = v125_0_3.clone();
                    let v128: LrcPtr<StringBuilder> = v125_0_2.clone();
                    let v127: string = v125_0_1.clone();
                    if string("") == (v127.clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.any_char / unexpected end of input / s: {:?}",
                            (v128.clone(), v129, v130)
                        ))
                    } else {
                        let v142: char = getCharAt(v127.clone(), 0_i32);
                        let v176: string =
                            getSlice(v127.clone(), Some(1_i32), Some((length(v127)) - 1_i32));
                        let v182: string = ofChar(v142);
                        let patternInput_1: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method106(
                            Spiral::method105(length(v182.clone()) as i64, v182, 0_i64),
                            v128,
                            v129,
                            v130,
                        );
                        Spiral::US18::US18_0(
                            v142,
                            v176,
                            patternInput_1.0.clone(),
                            patternInput_1.1.clone(),
                            patternInput_1.2.clone(),
                        )
                    }
                }
                Spiral::US18::US18_1(v125_1_0) => Spiral::US18::US18_1(v125_1_0.clone()),
            };
            match &v196 {
                Spiral::US18::US18_0(v196_0_0, v196_0_1, v196_0_2, v196_0_3, v196_0_4) => {
                    Spiral::US19::US19_0(
                        append((ofChar('`')), (ofChar(v196_0_0.clone()))),
                        v196_0_1.clone(),
                        v196_0_2.clone(),
                        v196_0_3.clone(),
                        v196_0_4.clone(),
                    )
                }
                Spiral::US18::US18_1(v196_1_0) => Spiral::US19::US19_1(v196_1_0.clone()),
            }
        }
        pub fn method122(
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
            '_method122: loop {
                break '_method122 (match v4.get().clone().as_ref() {
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
                                continue '_method122;
                            }
                        }
                    }
                });
            }
        }
        pub fn method123(
            v0_1: LrcPtr<Spiral::UH2>,
            v1_1: LrcPtr<Spiral::UH2>,
        ) -> LrcPtr<Spiral::UH2> {
            let v0_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<LrcPtr<Spiral::UH2>> = MutCell::new(v1_1.clone());
            '_method123: loop {
                break '_method123 (match v0_1.get().clone().as_ref() {
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
                        continue '_method123;
                    }
                });
            }
        }
        pub fn method120(
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
            '_method120: loop {
                break '_method120 ({
                    let v106: Spiral::US18 = if string("") == (v1_1.get().clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method121(v29, 0_i64)) == false {
                            let v66: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v72: string = ofChar(v29);
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method106(
                                Spiral::method105(length(v72.clone()) as i64, v72, 0_i64),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Spiral::US18::US18_0(
                                v29,
                                v66,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        } else {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v29,
                                toArray(ofArray(new_array(&['\\', '`', '\"']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v121: Spiral::US19 = match &v106 {
                        Spiral::US18::US18_0(v106_0_0, v106_0_1, v106_0_2, v106_0_3, v106_0_4) => {
                            Spiral::US19::US19_0(
                                ofChar(v106_0_0.clone()),
                                v106_0_1.clone(),
                                v106_0_2.clone(),
                                v106_0_3.clone(),
                                v106_0_4.clone(),
                            )
                        }
                        Spiral::US18::US18_1(v106_1_0) => Spiral::US19::US19_1(v106_1_0.clone()),
                    };
                    let v135: Spiral::US19 = match &v121 {
                        Spiral::US19::US19_0(v121_0_0, v121_0_1, v121_0_2, v121_0_3, v121_0_4) => {
                            v121.clone()
                        }
                        _ => Spiral::method122(
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                            LrcPtr::new(Spiral::UH3::UH3_1(
                                Func1::new(
                                    move |arg10_0040: (string, LrcPtr<StringBuilder>, i32, i32)| {
                                        Spiral::closure38((), arg10_0040)
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
                                            Spiral::closure39((), arg10_0040_1)
                                        },
                                    ),
                                    LrcPtr::new(Spiral::UH3::UH3_0),
                                )),
                            )),
                        ),
                    };
                    match &v135 {
                        Spiral::US19::US19_0(v135_0_0, v135_0_1, v135_0_2, v135_0_3, v135_0_4) => {
                            let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(Spiral::UH2::UH2_1(
                                v135_0_0.clone(),
                                v0_1.get().clone(),
                            ));
                            let v1_1_temp: string = v135_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v135_0_2.clone();
                            let v3_temp: i32 = v135_0_3.clone();
                            let v4_temp: i32 = v135_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method120;
                        }
                        _ => Spiral::US26::US26_0(
                            Spiral::method123(v0_1.get().clone(), LrcPtr::new(Spiral::UH2::UH2_0)),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method124(v0_1: LrcPtr<Spiral::UH2>, v1_1: List<string>) -> List<string> {
            match v0_1.as_ref() {
                Spiral::UH2::UH2_0 => v1_1.clone(),
                Spiral::UH2::UH2_1(v0_1_1_0, v0_1_1_1) => cons(
                    match v0_1.as_ref() {
                        Spiral::UH2::UH2_1(x, _) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    Spiral::method124(
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
        pub fn method125(
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
            '_method125: loop {
                break '_method125 ({
                    let v106: Spiral::US18 = if string("") == (v1_1.get().clone()) {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v29: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method121(v29, 0_i64)) == false {
                            let v66: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v72: string = ofChar(v29);
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method106(
                                Spiral::method105(length(v72.clone()) as i64, v72, 0_i64),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Spiral::US18::US18_0(
                                v29,
                                v66,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        } else {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v29,
                                toArray(ofArray(new_array(&['\\', '`', '\"']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v121: Spiral::US19 = match &v106 {
                        Spiral::US18::US18_0(v106_0_0, v106_0_1, v106_0_2, v106_0_3, v106_0_4) => {
                            Spiral::US19::US19_0(
                                ofChar(v106_0_0.clone()),
                                v106_0_1.clone(),
                                v106_0_2.clone(),
                                v106_0_3.clone(),
                                v106_0_4.clone(),
                            )
                        }
                        Spiral::US18::US18_1(v106_1_0) => Spiral::US19::US19_1(v106_1_0.clone()),
                    };
                    match &v121 {
                        Spiral::US19::US19_0(v121_0_0, v121_0_1, v121_0_2, v121_0_3, v121_0_4) => {
                            let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(Spiral::UH2::UH2_1(
                                v121_0_0.clone(),
                                v0_1.get().clone(),
                            ));
                            let v1_1_temp: string = v121_0_1.clone();
                            let v2_temp: LrcPtr<StringBuilder> = v121_0_2.clone();
                            let v3_temp: i32 = v121_0_3.clone();
                            let v4_temp: i32 = v121_0_4.clone();
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            v3.set(v3_temp);
                            v4.set(v4_temp);
                            continue '_method125;
                        }
                        _ => Spiral::US26::US26_0(
                            Spiral::method123(v0_1.get().clone(), LrcPtr::new(Spiral::UH2::UH2_0)),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method117(
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
            '_method117: loop {
                break '_method117 ({
                    let v5: bool = string("") == (v1_1.get().clone());
                    let v114: Spiral::US18 = if v5 {
                        Spiral::US18::US18_1(sprintf!(
                            "parsing.none_of / unexpected end of input / chars: {:?} / s: {:?}",
                            toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                            (v2.get().clone(), v3.get().clone(), v4.get().clone())
                        ))
                    } else {
                        let v33: char = getCharAt(v1_1.get().clone(), 0_i32);
                        if (Spiral::method118(v33, 0_i64)) == false {
                            let v70: string = getSlice(
                                v1_1.get().clone(),
                                Some(1_i32),
                                Some((length(v1_1.get().clone())) - 1_i32),
                            );
                            let v76: string = ofChar(v33);
                            let patternInput: (LrcPtr<StringBuilder>, i32, i32) = Spiral::method106(
                                Spiral::method105(length(v76.clone()) as i64, v76, 0_i64),
                                v2.get().clone(),
                                v3.get().clone(),
                                v4.get().clone(),
                            );
                            Spiral::US18::US18_0(
                                v33,
                                v70,
                                patternInput.0.clone(),
                                patternInput.1.clone(),
                                patternInput.2.clone(),
                            )
                        } else {
                            Spiral::US18::US18_1(sprintf!(
                                "parsing.none_of / unexpected char: \'{}\' / chars: {:?} / s: {:?}",
                                v33,
                                toArray(ofArray(new_array(&['\\', '`', '\"', ' ']))),
                                (v2.get().clone(), v3.get().clone(), v4.get().clone())
                            ))
                        }
                    };
                    let v134: Spiral::US19 = match &v114 {
                        Spiral::US18::US18_0(v114_0_0, v114_0_1, v114_0_2, v114_0_3, v114_0_4) => {
                            let patternInput_1: (string, string, LrcPtr<StringBuilder>, i32, i32) =
                                Spiral::method119(
                                    ofChar(v114_0_0.clone()),
                                    v114_0_1.clone(),
                                    v114_0_2.clone(),
                                    v114_0_3.clone(),
                                    v114_0_4.clone(),
                                );
                            Spiral::US19::US19_0(
                                patternInput_1.0.clone(),
                                patternInput_1.1.clone(),
                                patternInput_1.2.clone(),
                                patternInput_1.3.clone(),
                                patternInput_1.4.clone(),
                            )
                        }
                        Spiral::US18::US18_1(v114_1_0) => Spiral::US19::US19_1(v114_1_0.clone()),
                    };
                    let v522: Spiral::US19 = match &v134 {
                        Spiral::US19::US19_0(v134_0_0, v134_0_1, v134_0_2, v134_0_3, v134_0_4) => {
                            v134.clone()
                        }
                        _ => {
                            let v261: Spiral::US18 = if v5 {
                                Spiral::US18::US18_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                                                               '\"',
                                                                               (v2.get().clone(),
                                                                                v3.get().clone(),
                                                                                v4.get().clone())))
                            } else {
                                let v146: char = getCharAt(v1_1.get().clone(), 0_i32);
                                if (v146) == '\"' {
                                    let v181: string = getSlice(
                                        v1_1.get().clone(),
                                        Some(1_i32),
                                        Some((length(v1_1.get().clone())) - 1_i32),
                                    );
                                    let v187: string = ofChar(v146);
                                    let patternInput_2: (LrcPtr<StringBuilder>, i32, i32) =
                                        Spiral::method106(
                                            Spiral::method105(
                                                length(v187.clone()) as i64,
                                                v187,
                                                0_i64,
                                            ),
                                            v2.get().clone(),
                                            v3.get().clone(),
                                            v4.get().clone(),
                                        );
                                    Spiral::US18::US18_0(
                                        v146,
                                        v181,
                                        patternInput_2.0.clone(),
                                        patternInput_2.1.clone(),
                                        patternInput_2.2.clone(),
                                    )
                                } else {
                                    let v202: i32 =
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
                                                                                                                            (v202)
                                                                                                                        {
                                                                                                                         (length(v1_1.get().clone()))
                                                                                                                             +
                                                                                                                             1_i32
                                                                                                                     } else {
                                                                                                                         (v202)
                                                                                                                             +
                                                                                                                             1_i32
                                                                                                                     })
                                                                                                                        -
                                                                                                                        1_i32))),
                                                                                             string("\n"),
                                                                                             append(((Spiral::method107((v4.get().clone())
                                                                                                                            -
                                                                                                                            1_i32,
                                                                                                                        0_i32))(string(""))),
                                                                                                    string("^")),
                                                                                             string("\n")])))
                                }
                            };
                            let v451: Spiral::US19 = match &v261 {
                                Spiral::US18::US18_0(
                                    v261_0_0,
                                    v261_0_1,
                                    v261_0_2,
                                    v261_0_3,
                                    v261_0_4,
                                ) => {
                                    let v266: i32 = v261_0_4.clone();
                                    let v265: i32 = v261_0_3.clone();
                                    let v264: LrcPtr<StringBuilder> = v261_0_2.clone();
                                    let v263: string = v261_0_1.clone();
                                    let v268: Spiral::US26 = Spiral::method120(
                                        LrcPtr::new(Spiral::UH2::UH2_0),
                                        v263.clone(),
                                        v264.clone(),
                                        v265,
                                        v266,
                                    );
                                    let v301: Spiral::US19 = match &v268 {
                                        Spiral::US26::US26_0(
                                            v268_0_0,
                                            v268_0_1,
                                            v268_0_2,
                                            v268_0_3,
                                            v268_0_4,
                                        ) => {
                                            let v275: List<string> = Spiral::method124(
                                                v268_0_0.clone(),
                                                empty::<string>(),
                                            );
                                            Spiral::US19::US19_0(
                                                join(
                                                    string(""),
                                                    toArray_1(delay(Func0::new({
                                                        let v275 = v275.clone();
                                                        move || ofList(v275.clone()).clone()
                                                    }))),
                                                ),
                                                v268_0_1.clone(),
                                                v268_0_2.clone(),
                                                v268_0_3.clone(),
                                                v268_0_4.clone(),
                                            )
                                        }
                                        Spiral::US26::US26_1(v268_1_0) => {
                                            Spiral::US19::US19_1(v268_1_0.clone())
                                        }
                                    };
                                    match &v301 {
                                        Spiral::US19::US19_0(
                                            v301_0_0,
                                            v301_0_1,
                                            v301_0_2,
                                            v301_0_3,
                                            v301_0_4,
                                        ) => {
                                            let v306: i32 = v301_0_4.clone();
                                            let v305: i32 = v301_0_3.clone();
                                            let v304: LrcPtr<StringBuilder> = v301_0_2.clone();
                                            let v303: string = v301_0_1.clone();
                                            let v428: Spiral::US18 = if string("") == (v303.clone())
                                            {
                                                Spiral::US18::US18_1(sprintf!("parsing.p_char / unexpected end of input / c: \'{}\' / s: {:?}",
                                                                                                   '\"',
                                                                                                   (v304.clone(),
                                                                                                    v305,
                                                                                                    v306)))
                                            } else {
                                                let v313: char = getCharAt(v303.clone(), 0_i32);
                                                if (v313) == '\"' {
                                                    let v348: string = getSlice(
                                                        v303.clone(),
                                                        Some(1_i32),
                                                        Some((length(v303.clone())) - 1_i32),
                                                    );
                                                    let v354: string = ofChar(v313);
                                                    let patternInput_3: (
                                                        LrcPtr<StringBuilder>,
                                                        i32,
                                                        i32,
                                                    ) = Spiral::method106(
                                                        Spiral::method105(
                                                            length(v354.clone()) as i64,
                                                            v354,
                                                            0_i64,
                                                        ),
                                                        v304.clone(),
                                                        v305,
                                                        v306,
                                                    );
                                                    Spiral::US18::US18_0(
                                                        v313,
                                                        v348,
                                                        patternInput_3.0.clone(),
                                                        patternInput_3.1.clone(),
                                                        patternInput_3.2.clone(),
                                                    )
                                                } else {
                                                    let v369: i32 =
                                                        (indexOf(v303.clone(), string("\n")))
                                                            - 1_i32;
                                                    Spiral::US18::US18_1(concat(new_array(&[sprintf!("parsing.p_char / expected: \'{}\' / line: {} / col: {}\n{}{}",
                                                                                                                          '\"',
                                                                                                                          v305,
                                                                                                                          v306,
                                                                                                                          v304.clone(),
                                                                                                                          getSlice(v303.clone(),
                                                                                                                                   Some(0_i32),
                                                                                                                                   Some((if -2_i32
                                                                                                                                                ==
                                                                                                                                                (v369)
                                                                                                                                            {
                                                                                                                                             (length(v303.clone()))
                                                                                                                                                 +
                                                                                                                                                 1_i32
                                                                                                                                         } else {
                                                                                                                                             (v369)
                                                                                                                                                 +
                                                                                                                                                 1_i32
                                                                                                                                         })
                                                                                                                                            -
                                                                                                                                            1_i32))),
                                                                                                                 string("\n"),
                                                                                                                 append(((Spiral::method107((v306)
                                                                                                                                                -
                                                                                                                                                1_i32,
                                                                                                                                            0_i32))(string(""))),
                                                                                                                        string("^")),
                                                                                                                 string("\n")])))
                                                }
                                            };
                                            match &v428 {
                                                                 Spiral::US18::US18_0(v428_0_0,
                                                                                      v428_0_1,
                                                                                      v428_0_2,
                                                                                      v428_0_3,
                                                                                      v428_0_4)
                                                                 =>
                                                                 Spiral::US19::US19_0(v301_0_0.clone(),
                                                                                      v428_0_1.clone(),
                                                                                      v428_0_2.clone(),
                                                                                      v428_0_3.clone(),
                                                                                      v428_0_4.clone()),
                                                                 Spiral::US18::US18_1(v428_1_0)
                                                                 =>
                                                                 Spiral::US19::US19_1(sprintf!("parsing.between / expected closing delimiter / e: {:?} / input: {:?} / rest1: {:?} / rest2: {:?}",
                                                                                               v428_1_0.clone(),
                                                                                               (v1_1.get().clone(),
                                                                                                v2.get().clone(),
                                                                                                v3.get().clone(),
                                                                                                v4.get().clone()),
                                                                                               (v263.clone(),
                                                                                                v264.clone(),
                                                                                                v265,
                                                                                                v266),
                                                                                               (v303.clone(),
                                                                                                v304.clone(),
                                                                                                v305,
                                                                                                v306))),
                                                             }
                                        }
                                        _ => Spiral::US19::US19_1(string(
                                            "parsing.between / expected content",
                                        )),
                                    }
                                }
                                Spiral::US18::US18_1(v261_1_0) => {
                                    Spiral::US19::US19_1(v261_1_0.clone())
                                }
                            };
                            match &v451 {
                                Spiral::US19::US19_0(
                                    v451_0_0,
                                    v451_0_1,
                                    v451_0_2,
                                    v451_0_3,
                                    v451_0_4,
                                ) => v451.clone(),
                                _ => {
                                    let v463: Spiral::US19 =
                                                     Spiral::method122(v1_1.get().clone(),
                                                                       v2.get().clone(),
                                                                       v3.get().clone(),
                                                                       v4.get().clone(),
                                                                       LrcPtr::new(Spiral::UH3::UH3_1(Func1::new(move
                                                                                                                     |arg10_0040:
                                                                                                                          (string,
                                                                                                                           LrcPtr<StringBuilder>,
                                                                                                                           i32,
                                                                                                                           i32)|
                                                                                                                     Spiral::closure38((),
                                                                                                                                       arg10_0040)),
                                                                                                      LrcPtr::new(Spiral::UH3::UH3_1(Func1::new(move
                                                                                                                                                    |arg10_0040_1:
                                                                                                                                                         (string,
                                                                                                                                                          LrcPtr<StringBuilder>,
                                                                                                                                                          i32,
                                                                                                                                                          i32)|
                                                                                                                                                    Spiral::closure39((),
                                                                                                                                                                      arg10_0040_1)),
                                                                                                                                     LrcPtr::new(Spiral::UH3::UH3_0))))));
                                    let v474: Spiral::US19 = match &v463 {
                                        Spiral::US19::US19_0(
                                            v463_0_0,
                                            v463_0_1,
                                            v463_0_2,
                                            v463_0_3,
                                            v463_0_4,
                                        ) => Spiral::US19::US19_0(
                                            string(""),
                                            v463_0_1.clone(),
                                            v463_0_2.clone(),
                                            v463_0_3.clone(),
                                            v463_0_4.clone(),
                                        ),
                                        Spiral::US19::US19_1(v463_1_0) => {
                                            Spiral::US19::US19_1(v463_1_0.clone())
                                        }
                                    };
                                    let v485: Spiral::US26 = match &v474 {
                                        Spiral::US19::US19_0(
                                            v474_0_0,
                                            v474_0_1,
                                            v474_0_2,
                                            v474_0_3,
                                            v474_0_4,
                                        ) => Spiral::method125(
                                            LrcPtr::new(Spiral::UH2::UH2_0),
                                            v474_0_1.clone(),
                                            v474_0_2.clone(),
                                            v474_0_3.clone(),
                                            v474_0_4.clone(),
                                        ),
                                        Spiral::US19::US19_1(v474_1_0) => {
                                            Spiral::US26::US26_1(v474_1_0.clone())
                                        }
                                    };
                                    match &v485 {
                                        Spiral::US26::US26_0(
                                            v485_0_0,
                                            v485_0_1,
                                            v485_0_2,
                                            v485_0_3,
                                            v485_0_4,
                                        ) => {
                                            let v492: List<string> = Spiral::method124(
                                                v485_0_0.clone(),
                                                empty::<string>(),
                                            );
                                            Spiral::US19::US19_0(
                                                join(
                                                    string(""),
                                                    toArray_1(delay(Func0::new({
                                                        let v492 = v492.clone();
                                                        move || ofList(v492.clone()).clone()
                                                    }))),
                                                ),
                                                v485_0_1.clone(),
                                                v485_0_2.clone(),
                                                v485_0_3.clone(),
                                                v485_0_4.clone(),
                                            )
                                        }
                                        Spiral::US26::US26_1(v485_1_0) => {
                                            Spiral::US19::US19_1(v485_1_0.clone())
                                        }
                                    }
                                }
                            }
                        }
                    };
                    match &v522 {
                        Spiral::US19::US19_0(v522_0_0, v522_0_1, v522_0_2, v522_0_3, v522_0_4) => {
                            let v527: i32 = v522_0_4.clone();
                            let v526: i32 = v522_0_3.clone();
                            let v525: LrcPtr<StringBuilder> = v522_0_2.clone();
                            let v524: string = v522_0_1.clone();
                            let v523: string = v522_0_0.clone();
                            let v529: i32 = Spiral::method114(v524.clone(), 0_i32);
                            let v571: Spiral::US21 = if 0_i32 == (v529) {
                                Spiral::US21::US21_1(string(
                                    "parsing.spaces1 / expected at least one space",
                                ))
                            } else {
                                Spiral::US21::US21_0(
                                    getSlice(
                                        v524.clone(),
                                        Some(v529),
                                        Some((length(v524.clone())) - 1_i32),
                                    ),
                                    v525.clone(),
                                    v526,
                                    v527,
                                )
                            };
                            match &v571 {
                                Spiral::US21::US21_0(v571_0_0, v571_0_1, v571_0_2, v571_0_3) => {
                                    let v0_1_temp: LrcPtr<Spiral::UH2> = LrcPtr::new(
                                        Spiral::UH2::UH2_1(v523.clone(), v0_1.get().clone()),
                                    );
                                    let v1_1_temp: string = v571_0_0.clone();
                                    let v2_temp: LrcPtr<StringBuilder> = v571_0_1.clone();
                                    let v3_temp: i32 = v571_0_2.clone();
                                    let v4_temp: i32 = v571_0_3.clone();
                                    v0_1.set(v0_1_temp);
                                    v1_1.set(v1_1_temp);
                                    v2.set(v2_temp);
                                    v3.set(v3_temp);
                                    v4.set(v4_temp);
                                    continue '_method117;
                                }
                                _ => Spiral::US26::US26_0(
                                    Spiral::method123(
                                        v0_1.get().clone(),
                                        LrcPtr::new(Spiral::UH2::UH2_1(
                                            v523.clone(),
                                            LrcPtr::new(Spiral::UH2::UH2_0),
                                        )),
                                    ),
                                    v524.clone(),
                                    v525.clone(),
                                    v526,
                                    v527,
                                ),
                            }
                        }
                        _ => Spiral::US26::US26_0(
                            Spiral::method123(v0_1.get().clone(), LrcPtr::new(Spiral::UH2::UH2_0)),
                            v1_1.get().clone(),
                            v2.get().clone(),
                            v3.get().clone(),
                            v4.get().clone(),
                        ),
                    }
                });
            }
        }
        pub fn method116(v0_1: string) -> Spiral::US25 {
            let _v0: MutCell<Option<Option<string>>> = MutCell::new(None::<Option<string>>);
            _v0.set(Some(Some(v0_1)));
            {
                let v22: Spiral::US26 = Spiral::method117(
                    LrcPtr::new(Spiral::UH2::UH2_0),
                    defaultValue(
                        string(""),
                        match &_v0.get().clone() {
                            None => panic!("{}", string("optionm\'.of_obj / _v0=None"),),
                            Some(_v0_0_0) => _v0_0_0.clone(),
                        },
                    ),
                    StringBuilder::_ctor__Z721C83C5(Spiral::method104()),
                    1_i32,
                    1_i32,
                );
                match &v22 {
                    Spiral::US26::US26_0(v22_0_0, v22_0_1, v22_0_2, v22_0_3, v22_0_4) => {
                        Spiral::US25::US25_0(toArray(Spiral::method124(
                            v22_0_0.clone(),
                            empty::<string>(),
                        )))
                    }
                    Spiral::US26::US26_1(v22_1_0) => Spiral::US25::US25_1(v22_1_0.clone()),
                }
            }
        }
        pub fn method127(
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
            let v19: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v10.clone(), string("file_name"), ());
                ()
            };
            let v41: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v10.clone(), v0_1, ());
                ()
            };
            let v61: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v72: () = {
                Spiral::closure7(v10.clone(), string("arguments"), ());
                ()
            };
            let v81: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v90: () = {
                Spiral::closure7(v10.clone(), v1_1, ());
                ()
            };
            let v99: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v110: () = {
                Spiral::closure7(v10.clone(), string("options"), ());
                ()
            };
            let v119: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v128: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v139: () = {
                Spiral::closure7(v10.clone(), string("command"), ());
                ()
            };
            let v148: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v157: () = {
                Spiral::closure7(v10.clone(), v2, ());
                ()
            };
            let v166: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v177: () = {
                Spiral::closure7(v10.clone(), string("cancellation_token"), ());
                ()
            };
            let v186: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v195: std::string::String = format!("{:#?}", v3);
            let v234: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v195),
                    (),
                );
                ()
            };
            let v243: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v254: () = {
                Spiral::closure7(v10.clone(), string("environment_variables"), ());
                ()
            };
            let v263: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v276: () = {
                Spiral::closure7(v10.clone(), sprintf!("{:?}", v4), ());
                ()
            };
            let v285: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v296: () = {
                Spiral::closure7(v10.clone(), string("on_line"), ());
                ()
            };
            let v305: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v314: std::string::String = format!("{:#?}", v5);
            let v353: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v314),
                    (),
                );
                ()
            };
            let v362: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v373: () = {
                Spiral::closure7(v10.clone(), string("stdin"), ());
                ()
            };
            let v382: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v391: std::string::String = format!("{:#?}", v6);
            let v430: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v391),
                    (),
                );
                ()
            };
            let v439: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v450: () = {
                Spiral::closure7(v10.clone(), string("trace"), ());
                ()
            };
            let v459: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v471: () = {
                Spiral::closure7(
                    v10.clone(),
                    if v7 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v480: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v491: () = {
                Spiral::closure7(v10.clone(), string("working_directory"), ());
                ()
            };
            let v500: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v509: std::string::String = format!("{:#?}", v8);
            let v548: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v509),
                    (),
                );
                ()
            };
            let v559: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            let v568: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            v10.l0.get().clone()
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
            let v17: string = Spiral::method127(v8, v9, v10, v11, v12, v13, v14, v15, v16);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options"),
                v17
            ))
        }
        pub fn closure40(
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
                Spiral::method19(Spiral::method126(
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
        pub fn closure41(
            unitVar: (),
            v0_1: Option<std::process::Child>,
        ) -> Option<std::process::Child> {
            v0_1
        }
        pub fn method128() -> Func1<Option<std::process::Child>, Option<std::process::Child>> {
            Func1::new(move |v: Option<std::process::Child>| Spiral::closure41((), v))
        }
        pub fn closure42(
            unitVar: (),
            v0_1: std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>,
        ) -> Spiral::US27 {
            Spiral::US27::US27_0(v0_1)
        }
        pub fn method129(
        ) -> Func1<std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>, Spiral::US27>
        {
            Func1::new(
                move |v: std::sync::Arc<std::sync::Mutex<Option<std::process::Child>>>| {
                    Spiral::closure42((), v)
                },
            )
        }
        pub fn closure43(unitVar: (), v0_1: std::string::String) -> Spiral::US27 {
            Spiral::US27::US27_1(v0_1)
        }
        pub fn method130() -> Func1<std::string::String, Spiral::US27> {
            Func1::new(move |v: std::string::String| Spiral::closure43((), v))
        }
        pub fn method132(v0_1: std::string::String) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral::closure7(v2.clone(), string("error"), ());
                ()
            };
            let v33: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v42: std::string::String = format!("{:#?}", v0_1);
            let v81: () = {
                Spiral::closure7(v2.clone(), fable_library_rust::String_::fromString(v42), ());
                ()
            };
            let v92: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
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
            v8: std::string::String,
        ) -> string {
            let v9: string = Spiral::method132(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options / child error"),
                v9
            ))
        }
        pub fn closure44(v0_1: std::string::String, unitVar: ()) {
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
                Spiral::method19(Spiral::method131(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method82(),
                    v0_1,
                ))
            };
        }
        pub fn method133(
            v0_1: std::sync::MutexGuard<Option<std::process::Child>>,
        ) -> std::sync::MutexGuard<Option<std::process::Child>> {
            v0_1
        }
        pub fn closure45(
            unitVar: (),
            v0_1: Option<std::process::ChildStdin>,
        ) -> Option<std::process::ChildStdin> {
            v0_1
        }
        pub fn method134(
        ) -> Func1<Option<std::process::ChildStdin>, Option<std::process::ChildStdin>> {
            Func1::new(move |v: Option<std::process::ChildStdin>| Spiral::closure45((), v))
        }
        pub fn closure46(
            unitVar: (),
            v0_1: std::sync::mpsc::Sender<std::string::String>,
        ) -> std::sync::mpsc::Sender<std::string::String> {
            v0_1
        }
        pub fn method135() -> Func1<
            std::sync::mpsc::Sender<std::string::String>,
            std::sync::mpsc::Sender<std::string::String>,
        > {
            Func1::new(move |v: std::sync::mpsc::Sender<std::string::String>| {
                Spiral::closure46((), v)
            })
        }
        pub fn method136() -> Func1<
            std::sync::mpsc::Sender<std::string::String>,
            std::sync::mpsc::Sender<std::string::String>,
        > {
            Func1::new(move |v: std::sync::mpsc::Sender<std::string::String>| {
                Spiral::closure46((), v)
            })
        }
        pub fn closure47(
            unitVar: (),
            v0_1: std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
        ) -> std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>> {
            v0_1
        }
        pub fn method137() -> Func1<
            std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
            std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
        > {
            Func1::new(
                move |v: std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>| {
                    Spiral::closure47((), v)
                },
            )
        }
        pub fn closure48(unitVar: (), v0_1: std::string::String) -> Spiral::US29 {
            Spiral::US29::US29_0(v0_1)
        }
        pub fn method138() -> Func1<std::string::String, Spiral::US29> {
            Func1::new(move |v: std::string::String| Spiral::closure48((), v))
        }
        pub fn closure49(unitVar: (), v0_1: std::string::String) -> Spiral::US29 {
            Spiral::US29::US29_1(v0_1)
        }
        pub fn method139() -> Func1<std::string::String, Spiral::US29> {
            Func1::new(move |v: std::string::String| Spiral::closure49((), v))
        }
        pub fn method141(v0_1: bool, v1_1: std::string::String) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("trace\'"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v46: () = {
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
            let v57: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v68: () = {
                Spiral::closure7(v3.clone(), string("e"), ());
                ()
            };
            let v77: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v86: std::string::String = format!("{:#?}", v1_1);
            let v125: () = {
                Spiral::closure7(v3.clone(), fable_library_rust::String_::fromString(v86), ());
                ()
            };
            let v136: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method140(
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
            let v10: string = Spiral::method141(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.stdio_line"),
                v10
            ))
        }
        pub fn closure50(v0_1: bool, v1_1: std::string::String, unitVar: ()) {
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
                Spiral::method19(Spiral::method140(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method82(),
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn method143() -> string {
            let v1_1: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            v1_1.l0.get().clone()
        }
        pub fn method142(
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
            let v9: string = Spiral::method143();
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                v8,
                v9
            ))
        }
        pub fn closure51(v0_1: string, unitVar: ()) {
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
                    Spiral::method142(
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        v30.clone(),
                        v31.clone(),
                        Spiral::method8(v26, v27, v28, v29, v30, v31),
                        Spiral::method85(),
                        v0_1,
                    )
                })
            };
        }
        pub fn closure52(
            unitVar: (),
            v0_1: std::sync::mpsc::SendError<std::string::String>,
        ) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method144(
        ) -> Func1<std::sync::mpsc::SendError<std::string::String>, std::string::String> {
            Func1::new(move |v: std::sync::mpsc::SendError<std::string::String>| {
                Spiral::closure52((), v)
            })
        }
        pub fn method145(v0_1: Result<(), string>) -> Result<(), string> {
            v0_1
        }
        pub fn closure53(
            unitVar: (),
            v0_1: Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>,
        ) -> Spiral::US30 {
            Spiral::US30::US30_0(v0_1)
        }
        pub fn method146() -> Func1<
            Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>,
            Spiral::US30,
        > {
            Func1::new(
                move |v: Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>| {
                    Spiral::closure53((), v)
                },
            )
        }
        pub fn method147(
            v0_1: std::sync::MutexGuard<Option<std::process::ChildStdin>>,
        ) -> std::sync::MutexGuard<Option<std::process::ChildStdin>> {
            v0_1
        }
        pub fn closure54(
            unitVar: (),
            v0_1: std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
        ) -> Spiral::US31 {
            Spiral::US31::US31_0(v0_1)
        }
        pub fn method148(
        ) -> Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, Spiral::US31>
        {
            Func1::new(
                move |v: std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>| {
                    Spiral::closure54((), v)
                },
            )
        }
        pub fn method149(
            v0_1: std::sync::MutexGuard<std::process::ChildStdin>,
        ) -> std::sync::MutexGuard<std::process::ChildStdin> {
            v0_1
        }
        pub fn closure55(unitVar: (), v0_1: std::process::Output) -> Spiral::US32 {
            Spiral::US32::US32_0(v0_1)
        }
        pub fn method150() -> Func1<std::process::Output, Spiral::US32> {
            Func1::new(move |v: std::process::Output| Spiral::closure55((), v))
        }
        pub fn closure56(unitVar: (), v0_1: std::string::String) -> Spiral::US32 {
            Spiral::US32::US32_1(v0_1)
        }
        pub fn method151() -> Func1<std::string::String, Spiral::US32> {
            Func1::new(move |v: std::string::String| Spiral::closure56((), v))
        }
        pub fn method152(
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
            let v9: string = Spiral::method132(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options / output error"),
                v9
            ))
        }
        pub fn closure57(v0_1: std::string::String, unitVar: ()) {
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
                Spiral::method19(Spiral::method152(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method82(),
                    v0_1,
                ))
            };
        }
        pub fn closure58(unitVar: (), v0_1: i32) -> Spiral::US33 {
            Spiral::US33::US33_0(v0_1)
        }
        pub fn method153() -> Func1<i32, Spiral::US33> {
            Func1::new(move |v: i32| Spiral::closure58((), v))
        }
        pub fn method155(v0_1: i32, v1_1: i32) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v3.clone(), string("std_trace_length"), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method154(
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
            let v10: string = Spiral::method155(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options / result"),
                v10
            ))
        }
        pub fn closure59(v0_1: i32, v1_1: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method154(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method85(),
                    v0_1,
                    length(v1_1),
                ))
            };
        }
        pub fn method159(
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
            let v19: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v10.clone(), string("file_name"), ());
                ()
            };
            let v41: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v10.clone(), v0_1, ());
                ()
            };
            let v61: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v72: () = {
                Spiral::closure7(v10.clone(), string("arguments"), ());
                ()
            };
            let v81: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v10.clone(), sprintf!("{:?}", v1_1), ());
                ()
            };
            let v103: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v114: () = {
                Spiral::closure7(v10.clone(), string("options"), ());
                ()
            };
            let v123: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v132: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v143: () = {
                Spiral::closure7(v10.clone(), string("command"), ());
                ()
            };
            let v152: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v161: () = {
                Spiral::closure7(v10.clone(), v2, ());
                ()
            };
            let v170: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v181: () = {
                Spiral::closure7(v10.clone(), string("cancellation_token"), ());
                ()
            };
            let v190: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v199: std::string::String = format!("{:#?}", v3);
            let v238: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v199),
                    (),
                );
                ()
            };
            let v247: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v258: () = {
                Spiral::closure7(v10.clone(), string("environment_variables"), ());
                ()
            };
            let v267: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v280: () = {
                Spiral::closure7(v10.clone(), sprintf!("{:?}", v4), ());
                ()
            };
            let v289: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v300: () = {
                Spiral::closure7(v10.clone(), string("on_line"), ());
                ()
            };
            let v309: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v318: std::string::String = format!("{:#?}", v5);
            let v357: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v318),
                    (),
                );
                ()
            };
            let v366: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v377: () = {
                Spiral::closure7(v10.clone(), string("stdin"), ());
                ()
            };
            let v386: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v395: std::string::String = format!("{:#?}", v6);
            let v434: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v395),
                    (),
                );
                ()
            };
            let v443: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v454: () = {
                Spiral::closure7(v10.clone(), string("trace"), ());
                ()
            };
            let v463: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v475: () = {
                Spiral::closure7(
                    v10.clone(),
                    if v7 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v484: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v495: () = {
                Spiral::closure7(v10.clone(), string("working_directory"), ());
                ()
            };
            let v504: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v513: std::string::String = format!("{:#?}", v8);
            let v552: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v513),
                    (),
                );
                ()
            };
            let v563: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            let v572: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            v10.l0.get().clone()
        }
        pub fn method158(
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
            let v17: string = Spiral::method159(v8, v9, v10, v11, v12, v13, v14, v15, v16);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options_async"),
                v17
            ))
        }
        pub fn closure60(
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
                Spiral::method19(Spiral::method158(
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
        pub fn method160(
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
        pub fn method163(v0_1: bool) -> string {
            unbox::<string>(fable_library_rust::Native_::getZero())
        }
        pub fn closure62(
            unitVar: (),
            v0_1: Func1<(i32, string, bool), Arc<Async<()>>>,
        ) -> Spiral::US34 {
            Spiral::US34::US34_0(v0_1)
        }
        pub fn method164() -> Func1<Func1<(i32, string, bool), Arc<Async<()>>>, Spiral::US34> {
            Func1::new(move |v: Func1<(i32, string, bool), Arc<Async<()>>>| {
                Spiral::closure62((), v)
            })
        }
        pub fn method165(v0_1: bool) -> i32 {
            unbox::<i32>(fable_library_rust::Native_::getZero())
        }
        pub fn closure63(v0_1: string, unitVar: ()) {
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
                    Spiral::method142(
                        v26.clone(),
                        v27.clone(),
                        v28.clone(),
                        v29.clone(),
                        v30.clone(),
                        v31.clone(),
                        Spiral::method8(v26, v27, v28, v29, v30, v31),
                        Spiral::method85(),
                        v0_1,
                    )
                })
            };
        }
        pub fn method162(
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
        pub fn method161(
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
            Spiral::method162(v0_1, v1_1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
        }
        pub fn closure61(
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
                Spiral::method161(v0_1, v1_1, v2, v3, v4, v5, v6, v7, v8, v9, v10);
            fable_library_rust::Native_::getZero::<()>();
            ()
        }
        pub fn closure64(unitVar: (), v0_1: CancellationToken) -> Spiral::US35 {
            Spiral::US35::US35_0(v0_1)
        }
        pub fn method166() -> Func1<CancellationToken, Spiral::US35> {
            Func1::new(move |v: CancellationToken| Spiral::closure64((), v))
        }
        pub fn method167(v0_1: CancellationToken) -> Arc<Async<CancellationToken>> {
            fable_library_rust::Native_::getZero()
        }
        pub fn method168(v0_1: bool) -> bool {
            unbox::<bool>(fable_library_rust::Native_::getZero())
        }
        pub fn method169(v0_1: bool) {
            ();
        }
        pub fn closure65(v0_1: bool, unitVar: ()) {
            if (Spiral::method168(v0_1)) == false {
                Spiral::method169(v0_1);
            };
        }
        pub fn method172(v0_1: LrcPtr<TaskCanceledException>) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral::closure7(v2.clone(), string("ex"), ());
                ()
            };
            let v33: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v42: std::string::String = format!("{:#?}", v0_1);
            let v81: () = {
                Spiral::closure7(v2.clone(), fable_library_rust::String_::fromString(v42), ());
                ()
            };
            let v92: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method171(
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
            let v9: string = Spiral::method172(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options_async / WaitForExitAsync"),
                v9
            ))
        }
        pub fn closure66(v0_1: LrcPtr<TaskCanceledException>, unitVar: ()) {
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
                Spiral::method19(Spiral::method171(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method43(),
                    v0_1,
                ))
            };
        }
        pub fn method170(
            v0_1: bool,
            v1_1: LrcPtr<ConcurrentStack_1<string>>,
            v2: CancellationToken,
        ) -> Arc<Async<i32>> {
            fable_library_rust::Native_::getZero()
        }
        pub fn method174(
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
            let v19: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v30: () = {
                Spiral::closure7(v10.clone(), string("exit_code"), ());
                ()
            };
            let v41: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v50: () = {
                Spiral::closure7(v10.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v61: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v72: () = {
                Spiral::closure7(v10.clone(), string("output_length"), ());
                ()
            };
            let v81: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v90: () = {
                Spiral::closure7(v10.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v99: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v110: () = {
                Spiral::closure7(v10.clone(), string("options"), ());
                ()
            };
            let v119: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v128: () = {
                Spiral::closure7(v10.clone(), string("{ "), ());
                ()
            };
            let v139: () = {
                Spiral::closure7(v10.clone(), string("command"), ());
                ()
            };
            let v148: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v157: () = {
                Spiral::closure7(v10.clone(), v2, ());
                ()
            };
            let v166: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v177: () = {
                Spiral::closure7(v10.clone(), string("cancellation_token"), ());
                ()
            };
            let v186: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v195: std::string::String = format!("{:#?}", v3);
            let v234: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v195),
                    (),
                );
                ()
            };
            let v243: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v254: () = {
                Spiral::closure7(v10.clone(), string("environment_variables"), ());
                ()
            };
            let v263: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v276: () = {
                Spiral::closure7(v10.clone(), sprintf!("{:?}", v4), ());
                ()
            };
            let v285: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v296: () = {
                Spiral::closure7(v10.clone(), string("on_line"), ());
                ()
            };
            let v305: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v314: std::string::String = format!("{:#?}", v5);
            let v353: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v314),
                    (),
                );
                ()
            };
            let v362: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v373: () = {
                Spiral::closure7(v10.clone(), string("stdin"), ());
                ()
            };
            let v382: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v391: std::string::String = format!("{:#?}", v6);
            let v430: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v391),
                    (),
                );
                ()
            };
            let v439: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v450: () = {
                Spiral::closure7(v10.clone(), string("trace"), ());
                ()
            };
            let v459: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v471: () = {
                Spiral::closure7(
                    v10.clone(),
                    if v7 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v480: () = {
                Spiral::closure7(v10.clone(), string("; "), ());
                ()
            };
            let v491: () = {
                Spiral::closure7(v10.clone(), string("working_directory"), ());
                ()
            };
            let v500: () = {
                Spiral::closure7(v10.clone(), string(" = "), ());
                ()
            };
            let v509: std::string::String = format!("{:#?}", v8);
            let v548: () = {
                Spiral::closure7(
                    v10.clone(),
                    fable_library_rust::String_::fromString(v509),
                    (),
                );
                ()
            };
            let v559: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            let v568: () = {
                Spiral::closure7(v10.clone(), string(" }"), ());
                ()
            };
            v10.l0.get().clone()
        }
        pub fn method173(
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
            let v17: string = Spiral::method174(v8, v9, v10, v11, v12, v13, v14, v15, v16);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("runtime.execute_with_options_async"),
                v17
            ))
        }
        pub fn closure67(
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
                Spiral::method19(Spiral::method173(
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
        pub fn method157(
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
        pub fn method156(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
        ) -> Arc<Async<(i32, string)>> {
            Spiral::method157(v0_1, v1_1, v2, v3, v4, v5, v6)
        }
        pub fn method101(
            v0_1: string,
            v1_1: Option<CancellationToken>,
            v2: Array<(string, string)>,
            v3: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v4: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v5: bool,
            v6: Option<string>,
        ) -> (i32, string) {
            let v17: Spiral::US17 = Spiral::method103(Spiral::method102(
                v0_1.clone(),
                v1_1.clone(),
                v2.clone(),
                v3.clone(),
                v4.clone(),
                v5,
                v6.clone(),
            ));
            let patternInput: (string, Spiral::US5) = match &v17 {
                Spiral::US17::US17_0(v17_0_0, v17_0_1) => (v17_0_0.clone(), v17_0_1.clone()),
                Spiral::US17::US17_1(v17_1_0) => panic!(
                    "{}",
                    concat(new_array(&[
                        string("resultm.get / Result value was Error: "),
                        v17_1_0.clone()
                    ])),
                ),
            };
            let v30: Spiral::US5 = patternInput.1.clone();
            let v29: string = patternInput.0.clone();
            let v35: Spiral::US25 = Spiral::method116(match &v30 {
                Spiral::US5::US5_0(v30_0_0) => match &v30 {
                    Spiral::US5::US5_0(x) => x.clone(),
                    _ => unreachable!(),
                }
                .clone(),
                _ => string(""),
            });
            let v44: Array<string> = match &v35 {
                Spiral::US25::US25_0(v35_0_0) => v35_0_0.clone(),
                Spiral::US25::US25_1(v35_1_0) => panic!(
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
                Spiral::closure40(
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
                        let v267 = Spiral::method79();
                        let v271: Result<std::process::Child, std::string::String> =
                            v266.map_err(|x| v267(x));
                        let v283 = Spiral::method128();
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
                        let v301 = Spiral::method129();
                        let v302 = Spiral::method130();
                        let v304: Spiral::US27 = match v300 {
                            Ok(x) => v301(x),
                            Err(e) => v302(e),
                        };
                        let patternInput_3: (i32, Spiral::US7, Spiral::US28) = match &v304 {
                            Spiral::US27::US27_0(v304_0_0) => {
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
                                        Spiral::method133(v311.unwrap());
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
                                        Spiral::method133(v351.unwrap());
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
                                        Spiral::method133(v391.unwrap());
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
                                        (Spiral::method134())(Some(v421));
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
                                    (Spiral::method135())(v437.clone());
                                let v442: std::sync::Mutex<
                                    std::sync::mpsc::Sender<std::string::String>,
                                > = std::sync::Mutex::new(v440);
                                let v444: std::sync::Arc<
                                    std::sync::Mutex<std::sync::mpsc::Sender<std::string::String>>,
                                > = std::sync::Arc::new(v442);
                                let v446: std::sync::mpsc::Sender<std::string::String> =
                                    (Spiral::method136())(v437);
                                let v448: std::sync::Mutex<
                                    std::sync::mpsc::Sender<std::string::String>,
                                > = std::sync::Mutex::new(v446);
                                let v450: std::sync::Arc<
                                    std::sync::Mutex<std::sync::mpsc::Sender<std::string::String>>,
                                > = std::sync::Arc::new(v448);
                                let v452: std::sync::Arc<
                                    std::sync::mpsc::Receiver<std::string::String>,
                                > = (Spiral::method137())(patternInput_2.1.clone());
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
                                        let v471 = Spiral::method79();
                                        let v475: Result<std::string::String, std::string::String> =
                                            v468.map_err(|x| v471(x));
                                        let v487 = Spiral::method138();
                                        let v488 = Spiral::method139();
                                        let v490: Spiral::US29 = match v475 {
                                            Ok(x) => v487(x),
                                            Err(e) => v488(e),
                                        };
                                        let v727: std::string::String = match &v490 {
                                            Spiral::US29::US29_0(v490_0_0) => {
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
                                                        Spiral::closure51(v552.clone(), ());
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
                                            Spiral::US29::US29_1(v490_1_0) => {
                                                let v609: std::string::String = v490_1_0.clone();
                                                let v612: () = {
                                                    Spiral::closure50(v5, v609.clone(), ());
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
                                        let v751 = Spiral::method144();
                                        let v755: Result<(), std::string::String> =
                                            v750.map_err(|x| v751(x));
                                        let v768: _ = v755;
                                        let v770: bool = true;
                                        v768
                                    }); //;
                                    let v773: Result<(), string> =
                                        Spiral::method145(_iter_try_for_each.map_err(|x| x.into()));
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
                                        let v806 = Spiral::method79();
                                        let v810: Result<std::string::String, std::string::String> =
                                            v803.map_err(|x| v806(x));
                                        let v822 = Spiral::method138();
                                        let v823 = Spiral::method139();
                                        let v825: Spiral::US29 = match v810 {
                                            Ok(x) => v822(x),
                                            Err(e) => v823(e),
                                        };
                                        let v1128: std::string::String = match &v825 {
                                            Spiral::US29::US29_0(v825_0_0) => {
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
                                                        Spiral::closure51(v887.clone(), ());
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
                                            Spiral::US29::US29_1(v825_1_0) => {
                                                let v1010: std::string::String = v825_1_0.clone();
                                                let v1013: () = {
                                                    Spiral::closure50(v5, v1010.clone(), ());
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
                                        let v1152 = Spiral::method144();
                                        let v1156: Result<(), std::string::String> =
                                            v1151.map_err(|x| v1152(x));
                                        let v1169: _ = v1156;
                                        let v1171: bool = true;
                                        v1169
                                    }); //;
                                    let v1174: Result<(), string> =
                                        Spiral::method145(_iter_try_for_each.map_err(|x| x.into()));
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
                                let v1209: Spiral::US30 = defaultValue(
                                    Spiral::US30::US30_1,
                                    map(Spiral::method146(), v4.clone()),
                                );
                                match &v1209 {
                                    Spiral::US30::US30_0(v1209_0_0) => {
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
                                        > = Spiral::method147(v1217.unwrap());
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
                                        let v1270: Spiral::US31 = defaultValue(
                                            Spiral::US31::US31_1,
                                            map(Spiral::method148(), v1251),
                                        );
                                        match &v1270 {
                                            Spiral::US31::US31_0(v1270_0_0) => {
                                                let v1274: std::sync::Arc<
                                                    std::sync::Mutex<std::process::ChildStdin>,
                                                > = match &v1270 {
                                                    Spiral::US31::US31_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone();
                                                (match &v1209 {
                                                    Spiral::US30::US30_0(x) => x.clone(),
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
                                                    > = Spiral::method149(v1278.unwrap());
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
                                        Spiral::method133(v1302.unwrap());
                                    let v1320: bool = true;
                                    let mut v1318 = v1318;
                                    let v1322: &mut Option<std::process::Child> = &mut v1318;
                                    let v1324: Option<std::process::Child> = Option::take(v1322);
                                    let v1326: std::process::Child = v1324.unwrap();
                                    let v1328: Result<std::process::Output, std::io::Error> =
                                        v1326.wait_with_output();
                                    let v1329 = Spiral::method79();
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
                                        let v1383 = Spiral::method150();
                                        let v1384 = Spiral::method151();
                                        let v1386: Spiral::US32 = match &v1342 {
                                            Err(v1342_1_0) => v1384(v1342_1_0.clone()),
                                            Ok(v1342_0_0) => v1383(v1342_0_0.clone()),
                                        };
                                        match &v1386 {
                                            Spiral::US32::US32_0(v1386_0_0) => {
                                                let v1391: std::process::ExitStatus =
                                                    v1386_0_0.clone().status;
                                                let v1393: Option<i32> = v1391.code();
                                                let v1412: Spiral::US33 = defaultValue(
                                                    Spiral::US33::US33_1,
                                                    map(Spiral::method153(), v1393),
                                                );
                                                match &v1412 {
                                                    Spiral::US33::US33_0(v1412_0_0) => (
                                                        match &v1412 {
                                                            Spiral::US33::US33_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        },
                                                        Spiral::US7::US7_1,
                                                        Spiral::US28::US28_0(v456.clone()),
                                                    ),
                                                    _ => {
                                                        let v1426:
                                                                                        &str =
                                                                                    &*string("runtime.execute_with_options / exit_code=None");
                                                        (
                                                            -1_i32,
                                                            Spiral::US7::US7_0(String::from(v1426)),
                                                            Spiral::US28::US28_0(v456.clone()),
                                                        )
                                                    }
                                                }
                                            }
                                            Spiral::US32::US32_1(v1386_1_0) => {
                                                let v1494: std::string::String = v1386_1_0.clone();
                                                let v1497: () = {
                                                    Spiral::closure57(v1494.clone(), ());
                                                    ()
                                                };
                                                (
                                                    -2_i32,
                                                    Spiral::US7::US7_0(v1494),
                                                    Spiral::US28::US28_1,
                                                )
                                            }
                                        }
                                    }
                                }
                            }
                            Spiral::US27::US27_1(v304_1_0) => {
                                let v1552: std::string::String = v304_1_0.clone();
                                let v1555: () = {
                                    Spiral::closure44(v1552.clone(), ());
                                    ()
                                };
                                (-1_i32, Spiral::US7::US7_0(v1552), Spiral::US28::US28_1)
                            }
                        };
                        let v1609: Spiral::US28 = patternInput_3.2.clone();
                        let v1608: Spiral::US7 = patternInput_3.1.clone();
                        let v1607: i32 = patternInput_3.0.clone();
                        let v1617: Option<
                            std::sync::Arc<
                                std::sync::Mutex<
                                    std::sync::Arc<std::sync::mpsc::Receiver<std::string::String>>,
                                >,
                            >,
                        > = match &v1609 {
                            Spiral::US28::US28_0(v1609_0_0) => Some(
                                match &v1609 {
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
                            let v1666: string = join(Spiral::method75(), toArray_1(v1658));
                            let v1671: bool = true;
                            v1666
                        });
                        let v1673: Option<string> = _optionm_map_;
                        let v1680: Spiral::US5 = match &v1608 {
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
                        let v1686: string = defaultValue(
                            match &v1680 {
                                Spiral::US5::US5_0(v1680_0_0) => match &v1680 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => string(""),
                            },
                            v1673,
                        );
                        let v1691: () = {
                            Spiral::closure59(v1607, v1686.clone(), ());
                            ()
                        };
                        LrcPtr::new((v1607, v1686))
                    }
                }))();
                _capture_v175.set(Some(x_5))
            }
            {
                let v1743: LrcPtr<(i32, string)> = match &_capture_v175.get().clone() {
                    None => panic!("{}", string("base.capture / _capture_v175=None"),),
                    Some(_capture_v175_0_0) => _capture_v175_0_0.clone(),
                };
                let _run_target_args__v15: (i32, string) = (v1743.0.clone(), v1743.1.clone());
                (
                    _run_target_args__v15.0.clone(),
                    _run_target_args__v15.1.clone(),
                )
            }
        }
        pub fn method176(v0_1: i32, v1_1: string, v2: string) -> string {
            let v4: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v13: () = {
                Spiral::closure7(v4.clone(), string("{ "), ());
                ()
            };
            let v24: () = {
                Spiral::closure7(v4.clone(), string("exit_code"), ());
                ()
            };
            let v35: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v44: () = {
                Spiral::closure7(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v55: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v66: () = {
                Spiral::closure7(v4.clone(), string("run_result"), ());
                ()
            };
            let v75: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v84: () = {
                Spiral::closure7(v4.clone(), v1_1, ());
                ()
            };
            let v93: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v104: () = {
                Spiral::closure7(v4.clone(), string("new_code_path"), ());
                ()
            };
            let v113: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v122: () = {
                Spiral::closure7(v4.clone(), v2, ());
                ()
            };
            let v133: () = {
                Spiral::closure7(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
        }
        pub fn method175(
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
            let v11: string = Spiral::method176(v8, v9, v10);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_gleam / format error"),
                v11
            ))
        }
        pub fn closure68(v0_1: string, v1_1: string, v2: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method175(
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    Spiral::method8(v28, v29, v30, v31, v32, v33),
                    Spiral::method82(),
                    v2,
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn closure69(unitVar: (), v0_1: string) -> Spiral::US5 {
            Spiral::US5::US5_0(v0_1)
        }
        pub fn closure70(v0_1: string, unitVar: ()) -> string {
            let v13: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method75(), toArray_1(v13))
        }
        pub fn method178(
            v0_1: LrcPtr<Exception>,
            v1_1: std::string::String,
            v2: string,
            v3: string,
        ) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v14: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v25: () = {
                Spiral::closure7(v5.clone(), string("ex"), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v45: std::string::String = format!("{:#?}", v0_1);
            let v84: () = {
                Spiral::closure7(v5.clone(), fable_library_rust::String_::fromString(v45), ());
                ()
            };
            let v95: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v106: () = {
                Spiral::closure7(v5.clone(), string("run_result\'"), ());
                ()
            };
            let v115: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v124: std::string::String = format!("{:#?}", v1_1);
            let v163: () = {
                Spiral::closure7(
                    v5.clone(),
                    fable_library_rust::String_::fromString(v124),
                    (),
                );
                ()
            };
            let v172: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v183: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v192: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v201: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v210: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v221: () = {
                Spiral::closure7(v5.clone(), string("external_command"), ());
                ()
            };
            let v230: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v239: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v250: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
        }
        pub fn method177(
            v0_1: LrcPtr<Spiral::Mut0>,
            v1_1: LrcPtr<Spiral::Mut1>,
            v2: LrcPtr<Spiral::Mut2>,
            v3: LrcPtr<Spiral::Mut3>,
            v4: LrcPtr<Spiral::Mut4>,
            v5: Option<i64>,
            v6: string,
            v7: string,
            v8: LrcPtr<Exception>,
            v9: std::string::String,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method178(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_gleam / Exception"),
                v12
            ))
        }
        pub fn closure72(
            v0_1: string,
            v1_1: string,
            v2: std::string::String,
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
                Spiral::method19(Spiral::method177(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method82(),
                    v3,
                    v2,
                    v0_1,
                    v1_1,
                ))
            };
        }
        pub fn closure71(
            v0_1: string,
            v1_1: string,
            v2: std::string::String,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure72(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
        }
        pub fn method180(v0_1: i32, v1_1: string, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v14: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v25: () = {
                Spiral::closure7(v5.clone(), string("exit_code"), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v45: () = {
                Spiral::closure7(v5.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v56: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v67: () = {
                Spiral::closure7(v5.clone(), string("run_result"), ());
                ()
            };
            let v76: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v85: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v105: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v114: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v123: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v132: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v143: () = {
                Spiral::closure7(v5.clone(), string("external_command"), ());
                ()
            };
            let v152: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v161: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v172: () = {
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
            v8: i32,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method180(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_gleam / error"),
                v12
            ))
        }
        pub fn closure73(v0_1: string, v1_1: string, v2: i32, v3: string, unitVar: ()) {
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
                    Spiral::method82(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
        }
        pub fn method181(
            v0_1: Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>>,
        ) -> Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>> {
            v0_1
        }
        pub fn closure74(
            v0_1: Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>>,
            _arg: (string, string),
        ) -> LrcPtr<(std::string::String, std::string::String)> {
            let v3: Func1<(string, string), LrcPtr<(std::string::String, std::string::String)>> =
                Spiral::method181(v0_1);
            (move |x| v3(x))((_arg.0.clone(), _arg.1.clone()))
        }
        pub fn method182() -> string {
            string("py-path")
        }
        pub fn method183() -> string {
            string("env")
        }
        pub fn method185(v0_1: Spiral::US38, v1_1: i32, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v14: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v25: () = {
                Spiral::closure7(v5.clone(), string("env"), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v49: () = {
                Spiral::closure7(v5.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v60: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v71: () = {
                Spiral::closure7(v5.clone(), string("exit_code"), ());
                ()
            };
            let v80: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v89: () = {
                Spiral::closure7(v5.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v98: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v109: () = {
                Spiral::closure7(v5.clone(), string("run_result"), ());
                ()
            };
            let v118: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v127: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v136: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v147: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v156: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v165: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v176: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
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
            v8: Spiral::US38,
            v9: i32,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method185(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_cuda / env install error"),
                v12
            ))
        }
        pub fn closure75(v0_1: Spiral::US38, v1_1: string, v2: string, v3: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method184(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method82(),
                    v0_1,
                    v3,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure76(v0_1: string, unitVar: ()) -> string {
            let v13: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method75(), toArray_1(v13))
        }
        pub fn method187(v0_1: LrcPtr<Exception>, v1_1: string, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v14: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v25: () = {
                Spiral::closure7(v5.clone(), string("ex"), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v45: std::string::String = format!("{:#?}", v0_1);
            let v84: () = {
                Spiral::closure7(v5.clone(), fable_library_rust::String_::fromString(v45), ());
                ()
            };
            let v95: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v106: () = {
                Spiral::closure7(v5.clone(), string("run_result"), ());
                ()
            };
            let v115: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v124: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v133: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v144: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v153: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v162: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v171: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v182: () = {
                Spiral::closure7(v5.clone(), string("external_command"), ());
                ()
            };
            let v191: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v200: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v211: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
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
            v8: LrcPtr<Exception>,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method187(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_cuda / Exception"),
                v12
            ))
        }
        pub fn closure78(
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
                Spiral::method19(Spiral::method186(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method82(),
                    v3,
                    v1_1,
                    v0_1,
                    v2,
                ))
            };
        }
        pub fn closure77(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure78(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
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
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method180(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_cuda / error"),
                v12
            ))
        }
        pub fn closure79(v0_1: string, v1_1: string, v2: i32, v3: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method188(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method82(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
        }
        pub fn method189() -> string {
            string("fs-path")
        }
        pub fn method190() -> string {
            string("command")
        }
        pub fn method191() -> string {
            string("path")
        }
        pub fn method193(v0_1: string) -> string {
            Spiral::method69(Spiral::method36(Spiral::method34(), v0_1))
        }
        pub fn closure80(unitVar: (), v0_1: std::string::String) -> string {
            Spiral::method193(fable_library_rust::String_::fromString(v0_1))
        }
        pub fn method192() -> Func1<std::string::String, string> {
            Func1::new(move |v: std::string::String| Spiral::closure80((), v))
        }
        pub fn method194() -> string {
            string("retries")
        }
        pub fn method195() -> string {
            string("working-directory")
        }
        pub fn method198(v0_1: i32, v1_1: string, v2: string) -> string {
            let v4: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v13: () = {
                Spiral::closure7(v4.clone(), string("{ "), ());
                ()
            };
            let v24: () = {
                Spiral::closure7(v4.clone(), string("exit_code"), ());
                ()
            };
            let v35: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v44: () = {
                Spiral::closure7(v4.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v55: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v66: () = {
                Spiral::closure7(v4.clone(), string("repl_result"), ());
                ()
            };
            let v75: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v84: () = {
                Spiral::closure7(v4.clone(), v1_1, ());
                ()
            };
            let v93: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v104: () = {
                Spiral::closure7(v4.clone(), string("retry"), ());
                ()
            };
            let v113: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v122: () = {
                Spiral::closure7(v4.clone(), v2, ());
                ()
            };
            let v133: () = {
                Spiral::closure7(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
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
            v9: string,
            v10: string,
        ) -> string {
            let v11: string = Spiral::method198(v8, v9, v10);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / repl error"),
                v11
            ))
        }
        pub fn closure81(v0_1: u8, v1_1: u8, v2: string, v3: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method197(
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
        pub fn method196(v0_1: Spiral::US5, v1_1: u8, v2: string, v3: u8) -> (i32, string) {
            let v0_1: MutCell<Spiral::US5> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<u8> = MutCell::new(v1_1);
            let v2: MutCell<string> = MutCell::new(v2.clone());
            let v3: MutCell<u8> = MutCell::new(v3);
            '_method196: loop {
                break '_method196 ({
                    let patternInput: (i32, string) = Spiral::method101(
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
                            Spiral::closure81(v1_1.get().clone(), v3.get().clone(), v25, v24, ());
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
                            continue '_method196;
                        }
                    }
                });
            }
        }
        pub fn method200(v0_1: i32, v1_1: i32) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v3.clone(), string("jupyter_result_length"), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v94: () = {
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
                string("spiral.run / dib / jupyter nbconvert"),
                v10
            ))
        }
        pub fn closure82(v0_1: string, v1_1: i32, unitVar: ()) {
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
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v3.clone(), string("pwsh_replace_html_result_length"), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v94: () = {
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
                string("spiral.run / dib / html cell ids"),
                v10
            ))
        }
        pub fn closure83(v0_1: string, v1_1: i32, unitVar: ()) {
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
        pub fn method204(v0_1: i32, v1_1: i32) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v3.clone(), string("result_length"), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v1_1), ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method203(
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
            let v10: string = Spiral::method204(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / dib"),
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
                Spiral::method19(Spiral::method203(
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
        pub fn method205() -> string {
            string("cleanup")
        }
        pub fn method206() -> string {
            string("wasm")
        }
        pub fn method207() -> string {
            string("contract")
        }
        pub fn method208(v0_1: string, v1_1: string, v2: Spiral::US39) -> string {
            let v4: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v13: () = {
                Spiral::closure7(v4.clone(), string("{ "), ());
                ()
            };
            let v24: () = {
                Spiral::closure7(v4.clone(), string("extension"), ());
                ()
            };
            let v35: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v44: () = {
                Spiral::closure7(v4.clone(), v0_1, ());
                ()
            };
            let v55: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v66: () = {
                Spiral::closure7(v4.clone(), string("code"), ());
                ()
            };
            let v75: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v84: () = {
                Spiral::closure7(v4.clone(), v1_1, ());
                ()
            };
            let v93: () = {
                Spiral::closure7(v4.clone(), string("; "), ());
                ()
            };
            let v104: () = {
                Spiral::closure7(v4.clone(), string("runtime"), ());
                ()
            };
            let v113: () = {
                Spiral::closure7(v4.clone(), string(" = "), ());
                ()
            };
            let v126: () = {
                Spiral::closure7(v4.clone(), sprintf!("{:?}", v2), ());
                ()
            };
            let v137: () = {
                Spiral::closure7(v4.clone(), string(" }"), ());
                ()
            };
            v4.l0.get().clone()
        }
        pub fn method209(v0_1: Spiral::US5, v1_1: string, v2: Spiral::US42, v3: string) -> string {
            let v6: string = Spiral::method36(Spiral::method36(v3, string("target/spiral")), v1_1);
            if let Spiral::US5::US5_0(v0_1_0_0) = &v0_1 {
                if let Spiral::US42::US42_0(v2_0_0) = &v2 {
                    let v8: Spiral::US41 = v2_0_0.clone();
                    let v10: string = Spiral::method36(v6.clone(), string("packages"));
                    let v15: Spiral::US5 = if if let Spiral::US41::US41_0 = &v8 {
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
                            let v22: Spiral::US5 = if if let Spiral::US41::US41_1 = &v8 {
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
                                    let v29: Spiral::US5 = if if let Spiral::US41::US41_2 = &v8 {
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
                    Spiral::method36(
                        Spiral::method36(
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
        pub fn method211(
            v0_1: string,
            v1_1: LrcPtr<Spiral::UH2>,
            v2: LrcPtr<Spiral::UH2>,
        ) -> LrcPtr<Spiral::UH2> {
            match v1_1.as_ref() {
                Spiral::UH2::UH2_0 => v2.clone(),
                Spiral::UH2::UH2_1(v1_1_1_0, v1_1_1_1) => {
                    let v5: LrcPtr<Spiral::UH2> = Spiral::method211(
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
                            Spiral::method36(
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
        pub fn method212(
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
                        Spiral::method212(
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
        pub fn method210(
            v0_1: string,
            v1_1: string,
            v2: LrcPtr<Spiral::UH2>,
            v3: LrcPtr<Spiral::UH4>,
            v4: string,
            v5: string,
        ) -> string {
            let v6: LrcPtr<dyn IDisposable> = Spiral::method78(v4.clone());
            let v9: string = Spiral::method46(Spiral::method36(
                v4.clone(),
                concat(new_array(&[v1_1.clone(), string(".fs")])),
            ));
            Spiral::method76(v9.clone(), v0_1);
            {
                let v13: List<string> = Spiral::method124(
                    Spiral::method211(v5, v2, LrcPtr::new(Spiral::UH2::UH2_0)),
                    empty::<string>(),
                );
                let v32: string = join(
                    string("\\n        "),
                    toArray_1(delay(Func0::new({
                        let v13 = v13.clone();
                        move || ofList(v13.clone()).clone()
                    }))),
                );
                let v38: List<string> = Spiral::method124(
                    Spiral::method212(v3, LrcPtr::new(Spiral::UH2::UH2_0)),
                    empty::<string>(),
                );
                let v55: string = join(
                    string("\\n        "),
                    toArray_1(delay(Func0::new({
                        let v38 = v38.clone();
                        move || ofList(v38.clone()).clone()
                    }))),
                );
                let v60: string = Spiral::method46(Spiral::method36(
                    v4,
                    concat(new_array(&[v1_1, string(".fsproj")])),
                ));
                Spiral::method76(v60.clone(),
                                 append((append((append((append((append((append((append((append((append((append((append((append((append(string("<Project Sdk=\"Microsoft.NET.Sdk\">\n<PropertyGroup>\n    <TargetFramework>net9.0</TargetFramework>\n    <LangVersion>preview</LangVersion>\n    <RollForward>Major</RollForward>\n    <TargetLatestRuntimePatch>true</TargetLatestRuntimePatch>\n    <PublishAot>false</PublishAot>\n    <PublishTrimmed>false</PublishTrimmed>\n    <PublishSingleFile>true</PublishSingleFile>\n    <SelfContained>true</SelfContained>\n    <Version>0.0.1-alpha.1</Version>\n    <OutputType>Exe</OutputType>\n    <ServerGarbageCollection>true</ServerGarbageCollection>\n    <ConcurrentGarbageCollection>true</ConcurrentGarbageCollection>\n</PropertyGroup>\n<PropertyGroup Condition=\"$([MSBuild]::IsOSPlatform(\'FreeBSD\'))\">\n    <DefineConstants>_FREEBSD</DefineConstants>\n</PropertyGroup>\n<PropertyGroup Condition=\"$([MSBuild]::IsOSPlatform(\'Linux\'))\">\n    <DefineConstants>_LINUX</DefineConstants>\n</PropertyGroup>\n<PropertyGroup Condition=\"$([MSBuild]::IsOSPlatform(\'OSX\'))\">\n    <DefineConstants>_OSX</DefineConstants>\n</PropertyGroup>\n<PropertyGroup Condition=\"$([MSBuild]::IsOSPlatform(\'Windows\'))\">\n    <DefineConstants>_WINDOWS</DefineConstants>\n</PropertyGroup>\n<ItemGroup>\n"),
                                                                                                                                        (concat(new_array(&[string("    "),
                                                                                                                                                            v32]))))),
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
                                                                                            v55]))))),
                                                                string("\n"))),
                                                        string("</ItemGroup>"))),
                                                string("\n"))),
                                        string("</Project>")));
                v60
            }
        }
        pub fn closure85(unitVar: (), v0_1: chrono::DateTime<chrono::Utc>) -> Spiral::US43 {
            Spiral::US43::US43_0(v0_1)
        }
        pub fn method214() -> Func1<chrono::DateTime<chrono::Utc>, Spiral::US43> {
            Func1::new(move |v: chrono::DateTime<chrono::Utc>| Spiral::closure85((), v))
        }
        pub fn method215() -> string {
            string("hh:mm")
        }
        pub fn method216() -> string {
            string("yyyyMMdd-HHmm-ssff-ffff-f")
        }
        pub fn method217() -> string {
            string("hhmm")
        }
        pub fn method213(v0_1: Guid, v1_1: DateTime) -> Guid {
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
            let v699: Spiral::US43 =
                defaultValue(Spiral::US43::US43_1, map(Spiral::method214(), v680));
            let v719: Spiral::US5 = match &v699 {
                Spiral::US43::US43_0(v699_0_0) => {
                    let v705: chrono::NaiveDateTime = match &v699 {
                        Spiral::US43::US43_0(x) => x.clone(),
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
            let v960: string = Spiral::method215();
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
        pub fn method218(v0_1: string, v1_1: string) {
            if (Spiral::method39(v0_1.clone())) == false {
                let v4: LrcPtr<dyn IDisposable> = Spiral::method78(v0_1.clone());
                ()
            }
            {
                let v9: string = defaultValue(string(""), Spiral::method41(v1_1.clone()));
                if (Spiral::method39(v9.clone())) == false {
                    let v14: LrcPtr<dyn IDisposable> = Spiral::method78(v9);
                    ()
                }
                if if Spiral::method39(v1_1.clone()) {
                    let v16: Result<std::path::PathBuf, std::io::Error> =
                        Spiral::method47(v1_1.clone());
                    v16.is_err()
                } else {
                    false
                } {
                    Spiral::method89(true, v1_1.clone());
                }
                if (Spiral::method39(v1_1.clone())) == false {
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
        pub fn method220() -> string {
            string("(")
        }
        pub fn method221() -> string {
            string(" ")
        }
        pub fn method222(v0_1: Spiral::US40) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v13: () = {
                Spiral::closure7(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method226(v0_1: bool, v1_1: string, v2: i32, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v14: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v25: () = {
                Spiral::closure7(v5.clone(), string("is_error"), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v48: () = {
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
            let v59: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v70: () = {
                Spiral::closure7(v5.clone(), string("retry"), ());
                ()
            };
            let v79: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v88: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v97: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v108: () = {
                Spiral::closure7(v5.clone(), string("result"), ());
                ()
            };
            let v117: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v126: () = {
                Spiral::closure7(v5.clone(), sprintf!("{}", v2), ());
                ()
            };
            let v137: () = {
                Spiral::closure7(v5.clone(), string(", "), ());
                ()
            };
            let v146: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v157: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
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
            v8: bool,
            v9: string,
            v10: i32,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method226(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("common.retry_fn\' / loop"),
                v12
            ))
        }
        pub fn closure86(v0_1: u8, v1_1: u8, v2: i32, v3: string, v4: bool, unitVar: ()) {
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
                Spiral::method19(Spiral::method225(
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
        pub fn method224(
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
            '_method224: loop {
                break '_method224 ({
                    let patternInput: (i32, string) = Spiral::method101(
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
                    let v14: Spiral::US44 = if (v9) == 0_i32 {
                        Spiral::US44::US44_0(v9, v10.clone())
                    } else {
                        Spiral::US44::US44_1(v9, v10)
                    };
                    let patternInput_1: (bool, i32, string) = match &v14 {
                        Spiral::US44::US44_0(v14_0_0, v14_0_1) => {
                            (false, v14_0_0.clone(), v14_0_1.clone())
                        }
                        Spiral::US44::US44_1(v14_1_0, v14_1_1) => {
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
                            Spiral::closure86(
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
                            continue '_method224;
                        }
                    }
                });
            }
        }
        pub fn method223(
            v0_1: u8,
            v1_1: string,
            v2: Option<CancellationToken>,
            v3: Array<(string, string)>,
            v4: Option<Func1<(i32, string, bool), Arc<Async<()>>>>,
            v5: Option<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
            v6: bool,
            v7: Option<string>,
        ) -> (i32, string) {
            Spiral::method224(v0_1, v1_1, v2, v3, v4, v5, v6, v7, 1_u8)
        }
        pub fn method219(
            v0_1: Spiral::US39,
            v1_1: string,
            v2: string,
            v3: string,
            v4: Spiral::US13,
        ) -> (i32, string) {
            let v163: string = sprintf!(
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
                    Spiral::US39::US39_0(v0_1_0_0) => {
                        let v45: Spiral::US40 = match &v0_1 {
                            Spiral::US39::US39_0(x) => x.clone(),
                            _ => unreachable!(),
                        }
                        .clone();
                        let v98: Spiral::US5 = if if let Spiral::US40::US40_0(v45_0_0) = &v45 {
                            string("") == (v45_0_0.clone())
                        } else {
                            false
                        } {
                            Spiral::US5::US5_0(string("Wasm"))
                        } else {
                            let v62: string = Spiral::method220();
                            let v82: Array<string> = split(
                                Spiral::method222(Spiral::US40::US40_0(string(""))),
                                v62,
                                -1_i32,
                                0_i32,
                            );
                            let v86: string = v82[0_i32].clone();
                            if startsWith3(Spiral::method222(v45.clone()), v86, false) {
                                Spiral::US5::US5_0(string("Wasm"))
                            } else {
                                Spiral::US5::US5_1
                            }
                        };
                        let v152: Spiral::US5 = match &v98 {
                            Spiral::US5::US5_0(v98_0_0) => Spiral::US5::US5_0(
                                match &v98 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                            ),
                            _ => {
                                let v145: Spiral::US5 = if if let Spiral::US40::US40_1(v45_1_0) =
                                    &v45
                                {
                                    string("") == (v45_1_0.clone())
                                } else {
                                    false
                                } {
                                    Spiral::US5::US5_0(string("Contract"))
                                } else {
                                    let v109: string = Spiral::method220();
                                    let v129: Array<string> = split(
                                        Spiral::method222(Spiral::US40::US40_1(string(""))),
                                        v109,
                                        -1_i32,
                                        0_i32,
                                    );
                                    let v133: string = v129[0_i32].clone();
                                    if startsWith3(Spiral::method222(v45.clone()), v133, false) {
                                        Spiral::US5::US5_0(string("Contract"))
                                    } else {
                                        Spiral::US5::US5_1
                                    }
                                };
                                match &v145 {
                                    Spiral::US5::US5_0(v145_0_0) => Spiral::US5::US5_0(
                                        match &v145 {
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
                            toUpper(match &v152 {
                                Spiral::US5::US5_0(v152_0_0) => match &v152 {
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
            let v175: Result<string, string> = match &v4 {
                Spiral::US13::US13_0(v4_0_0) => Ok::<string, string>(v4_0_0.clone()),
                Spiral::US13::US13_1(v4_1_0) => Err::<string, string>(v4_1_0.clone()),
            };
            Spiral::method223(
                3_u8,
                v163,
                None::<CancellationToken>,
                new_empty::<(string, string)>(),
                None::<Func1<(i32, string, bool), Arc<Async<()>>>>,
                None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>, ()>>,
                true,
                v175.ok(),
            )
        }
        pub fn method228(v0_1: i32, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v3.clone(), string("dotnet_fable_result"), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method227(
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
            let v10: string = Spiral::method228(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / dotnet fable error"),
                v10
            ))
        }
        pub fn closure87(v0_1: string, v1_1: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method227(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method82(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn closure88(unitVar: (), v0_1: std::string::String) -> bool {
            contains(
                fable_library_rust::String_::fromString(v0_1),
                string("near-sdk"),
            )
        }
        pub fn method229() -> Func1<std::string::String, bool> {
            Func1::new(move |v: std::string::String| Spiral::closure88((), v))
        }
        pub fn method230(v0_1: Vec<std::string::String>) -> Vec<std::string::String> {
            v0_1
        }
        pub fn method231() -> string {
            string("(")
        }
        pub fn method232() -> string {
            string("(")
        }
        pub fn method234(
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
        pub fn closure89(
            unitVar: (),
            v0_1: std::collections::HashMap<string, string>,
        ) -> Spiral::US45 {
            Spiral::US45::US45_0(v0_1)
        }
        pub fn method235() -> Func1<std::collections::HashMap<string, string>, Spiral::US45> {
            Func1::new(move |v: std::collections::HashMap<string, string>| Spiral::closure89((), v))
        }
        pub fn method236() -> string {
            string("a")
        }
        pub fn closure90(v0_1: u8, v1_1: i32, v2: string, v3: bool, unitVar: ()) {
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
                Spiral::method19(Spiral::method225(
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
        pub fn method233(v0_1: Spiral::US13, v1_1: string, v2: u8) -> (i32, string) {
            let v0_1: MutCell<Spiral::US13> = MutCell::new(v0_1.clone());
            let v1_1: MutCell<string> = MutCell::new(v1_1.clone());
            let v2: MutCell<u8> = MutCell::new(v2);
            '_method233: loop {
                break '_method233 ({
                    let v8: string = concat(new_array(&[
                        string("cargo fmt --manifest-path \""),
                        v1_1.get().clone(),
                        string("\" --"),
                    ]));
                    let v20: Result<string, string> = match &v0_1.get().clone() {
                        Spiral::US13::US13_0(v0_1_0_0) => Ok::<string, string>(v0_1_0_0.clone()),
                        Spiral::US13::US13_1(v0_1_1_0) => Err::<string, string>(v0_1_1_0.clone()),
                    };
                    let patternInput: (i32, string) = Spiral::method101(
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
                    let v203: Spiral::US44 = if (contains(
                        v38.clone(),
                        string("failed to load manifest for workspace member"),
                    )) == false
                    {
                        if (v37) == 0_i32 {
                            Spiral::US44::US44_0(v37, v38.clone())
                        } else {
                            Spiral::US44::US44_1(v37, v38.clone())
                        }
                    } else {
                        let v52: Result<regex::Regex, regex::Error> =
                            regex::Regex::new(&string("failed to read `(?<a>.*?Cargo.toml)`"));
                        let v68: Vec<std::collections::HashMap<string, string>> =
                            Spiral::method234(v38.clone(), v52.unwrap());
                        let v71: Option<std::collections::HashMap<string, string>> = tryItem(
                            0_i32,
                            fable_library_rust::NativeArray_::array_from(v68.clone()),
                        );
                        let v90: Spiral::US45 =
                            defaultValue(Spiral::US45::US45_1, map(Spiral::method235(), v71));
                        let v123: Spiral::US46 = match &v90 {
                            Spiral::US45::US45_0(v90_0_0) => {
                                let v95: string = Spiral::method236();
                                let v97: Option<string> = std::collections::HashMap::get(
                                    &match &v90 {
                                        Spiral::US45::US45_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    &v95,
                                )
                                .map(|x| x)
                                .cloned();
                                Spiral::US46::US46_0(defaultValue(
                                    Spiral::US5::US5_1,
                                    map(Spiral::method6(), v97),
                                ))
                            }
                            _ => Spiral::US46::US46_1,
                        };
                        let v130: Spiral::US5 = if let Spiral::US46::US46_0(v123_0_0) = &v123 {
                            let v124: Spiral::US5 = v123_0_0.clone();
                            if let Spiral::US5::US5_0(v124_0_0) = &v124 {
                                Spiral::US5::US5_0(v124_0_0.clone())
                            } else {
                                Spiral::US5::US5_1
                            }
                        } else {
                            Spiral::US5::US5_1
                        };
                        match &v130 {
                            Spiral::US5::US5_0(v130_0_0) => {
                                let v132: string = match &v130 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone();
                                if (Spiral::method38(v132.clone())) == false {
                                    let v142: LrcPtr<dyn IDisposable> = Spiral::method78(
                                        defaultValue(string(""), Spiral::method41(v132.clone())),
                                    );
                                    let v146: DateTime = DateTime::now();
                                    let v169: string =
                                        toString(Spiral::method213(new_guid(), v146));
                                    let v194: string =
                                                     append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                            (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                v169.clone(),
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
                                                                                                v169,
                                                                                                string("\"")]))))),
                                                                    string("\n"))),
                                                            string("path = \"spiral.rs\""));
                                    std::fs::write(&*v132, &*v194).unwrap();
                                    ()
                                }
                                if (v37) == 0_i32 {
                                    Spiral::US44::US44_0(v37, v38.clone())
                                } else {
                                    Spiral::US44::US44_1(v37, v38.clone())
                                }
                            }
                            _ => Spiral::US44::US44_1(v37, v38.clone()),
                        }
                    };
                    let patternInput_1: (bool, i32, string) = match &v203 {
                        Spiral::US44::US44_0(v203_0_0, v203_0_1) => {
                            (false, v203_0_0.clone(), v203_0_1.clone())
                        }
                        Spiral::US44::US44_1(v203_1_0, v203_1_1) => {
                            (true, v203_1_0.clone(), v203_1_1.clone())
                        }
                    };
                    let v213: string = patternInput_1.2.clone();
                    let v212: i32 = patternInput_1.1.clone();
                    let v211: bool = patternInput_1.0.clone();
                    if if (v211) == false {
                        true
                    } else {
                        (v2.get().clone()) >= 3_u8
                    } {
                        (v212, v213.clone())
                    } else {
                        let v219: () = {
                            Spiral::closure90(v2.get().clone(), v212, v213, v211, ());
                            ()
                        };
                        {
                            let v0_1_temp: Spiral::US13 = v0_1.get().clone();
                            let v1_1_temp: string = v1_1.get().clone();
                            let v2_temp: u8 = (v2.get().clone()) + 1_u8;
                            v0_1.set(v0_1_temp);
                            v1_1.set(v1_1_temp);
                            v2.set(v2_temp);
                            continue '_method233;
                        }
                    }
                });
            }
        }
        pub fn method238(v0_1: i32, v1_1: string) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("exit_code"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v3.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v3.clone(), string("cargo_fmt_result"), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v83: () = {
                Spiral::closure7(v3.clone(), v1_1, ());
                ()
            };
            let v94: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method237(
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
            let v10: string = Spiral::method238(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / cargo fmt error"),
                v10
            ))
        }
        pub fn closure91(v0_1: string, v1_1: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method237(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method82(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn method239() -> string {
            string("{")
        }
        pub fn closure92(unitVar: (), v0_1: string) -> string {
            v0_1
        }
        pub fn closure93(v0_1: string, v1_1: string, v2: string) -> string {
            replace(v2, v0_1, v1_1)
        }
        pub fn closure94(v0_1: string, v1_1: string) -> string {
            replace(v1_1, v0_1, string("type DateTime = ();"))
        }
        pub fn method241(v0_1: i32, v1_1: string, v2: string, v3: bool, v4: string) -> string {
            let v6: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v15: () = {
                Spiral::closure7(v6.clone(), string("{ "), ());
                ()
            };
            let v26: () = {
                Spiral::closure7(v6.clone(), string("exit_code"), ());
                ()
            };
            let v37: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v46: () = {
                Spiral::closure7(v6.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v57: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v68: () = {
                Spiral::closure7(v6.clone(), string("new_code_path"), ());
                ()
            };
            let v77: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v86: () = {
                Spiral::closure7(v6.clone(), v1_1, ());
                ()
            };
            let v95: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v106: () = {
                Spiral::closure7(v6.clone(), string("external_command"), ());
                ()
            };
            let v115: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v124: () = {
                Spiral::closure7(v6.clone(), v2, ());
                ()
            };
            let v133: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v144: () = {
                Spiral::closure7(v6.clone(), string("cleanup"), ());
                ()
            };
            let v153: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v165: () = {
                Spiral::closure7(
                    v6.clone(),
                    if v3 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v174: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v185: () = {
                Spiral::closure7(v6.clone(), string("cargo_result"), ());
                ()
            };
            let v194: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v203: () = {
                Spiral::closure7(v6.clone(), v4, ());
                ()
            };
            let v214: () = {
                Spiral::closure7(v6.clone(), string(" }"), ());
                ()
            };
            v6.l0.get().clone()
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
            v8: i32,
            v9: string,
            v10: string,
            v11: bool,
            v12: string,
        ) -> string {
            let v13: string = Spiral::method241(v8, v9, v10, v11, v12);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / error"),
                v13
            ))
        }
        pub fn closure95(v0_1: bool, v1_1: string, v2: string, v3: i32, v4: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method240(
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    v35.clone(),
                    Spiral::method8(v30, v31, v32, v33, v34, v35),
                    Spiral::method82(),
                    v3,
                    v1_1,
                    v4,
                    v0_1,
                    v2,
                ))
            };
        }
        pub fn closure97(unitVar: (), v0_1: string) -> bool {
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
        pub fn closure96(v0_1: string, unitVar: ()) -> string {
            let v16: LrcPtr<dyn IEnumerable_1<string>> = ofArray_1(skip(
                2_i32,
                skipWhile(
                    Func1::new(move |v: string| Spiral::closure97((), v)),
                    split(v0_1, string("\n"), -1_i32, 0_i32),
                ),
            ));
            join(Spiral::method75(), toArray_1(v16))
        }
        pub fn method243(v0_1: LrcPtr<Exception>, v1_1: string, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v14: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v25: () = {
                Spiral::closure7(v5.clone(), string("ex"), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v45: std::string::String = format!("{:#?}", v0_1);
            let v84: () = {
                Spiral::closure7(v5.clone(), fable_library_rust::String_::fromString(v45), ());
                ()
            };
            let v95: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v106: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v115: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v124: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v133: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v144: () = {
                Spiral::closure7(v5.clone(), string("external_command"), ());
                ()
            };
            let v153: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v162: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v171: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v182: () = {
                Spiral::closure7(v5.clone(), string("cargo_result"), ());
                ()
            };
            let v191: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v200: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v211: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
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
            v8: LrcPtr<Exception>,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method243(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / Exception"),
                v12
            ))
        }
        pub fn closure99(
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
                Spiral::method19(Spiral::method242(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method82(),
                    v3,
                    v0_1,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure98(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure99(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
        }
        pub fn method245(v0_1: i32, v1_1: string, v2: string, v3: bool, v4: string) -> string {
            let v6: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v15: () = {
                Spiral::closure7(v6.clone(), string("{ "), ());
                ()
            };
            let v26: () = {
                Spiral::closure7(v6.clone(), string("exit_code"), ());
                ()
            };
            let v37: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v46: () = {
                Spiral::closure7(v6.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v57: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v68: () = {
                Spiral::closure7(v6.clone(), string("new_code_path"), ());
                ()
            };
            let v77: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v86: () = {
                Spiral::closure7(v6.clone(), v1_1, ());
                ()
            };
            let v95: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v106: () = {
                Spiral::closure7(v6.clone(), string("cargo_result"), ());
                ()
            };
            let v115: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v124: () = {
                Spiral::closure7(v6.clone(), v2, ());
                ()
            };
            let v133: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v144: () = {
                Spiral::closure7(v6.clone(), string("cleanup"), ());
                ()
            };
            let v153: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v165: () = {
                Spiral::closure7(
                    v6.clone(),
                    if v3 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v174: () = {
                Spiral::closure7(v6.clone(), string("; "), ());
                ()
            };
            let v185: () = {
                Spiral::closure7(v6.clone(), string("spiral_wasm_result"), ());
                ()
            };
            let v194: () = {
                Spiral::closure7(v6.clone(), string(" = "), ());
                ()
            };
            let v203: () = {
                Spiral::closure7(v6.clone(), v4, ());
                ()
            };
            let v214: () = {
                Spiral::closure7(v6.clone(), string(" }"), ());
                ()
            };
            v6.l0.get().clone()
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
            v11: bool,
            v12: string,
        ) -> string {
            let v13: string = Spiral::method245(v8, v9, v10, v11, v12);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / wasm error"),
                v13
            ))
        }
        pub fn closure100(v0_1: bool, v1_1: string, v2: string, v3: string, v4: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method244(
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    v35.clone(),
                    Spiral::method8(v30, v31, v32, v33, v34, v35),
                    Spiral::method82(),
                    v4,
                    v1_1,
                    v2,
                    v0_1,
                    concat(new_array(&[string("\n"), v3])),
                ))
            };
        }
        pub fn method247(
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
            let v16: () = {
                Spiral::closure7(v7.clone(), string("{ "), ());
                ()
            };
            let v27: () = {
                Spiral::closure7(v7.clone(), string("exit_code"), ());
                ()
            };
            let v38: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v47: () = {
                Spiral::closure7(v7.clone(), sprintf!("{}", v0_1), ());
                ()
            };
            let v58: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v69: () = {
                Spiral::closure7(v7.clone(), string("new_code_path"), ());
                ()
            };
            let v78: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v87: () = {
                Spiral::closure7(v7.clone(), v1_1, ());
                ()
            };
            let v96: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v107: () = {
                Spiral::closure7(v7.clone(), string("wasm_path"), ());
                ()
            };
            let v116: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v125: () = {
                Spiral::closure7(v7.clone(), v2, ());
                ()
            };
            let v134: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v145: () = {
                Spiral::closure7(v7.clone(), string("command"), ());
                ()
            };
            let v154: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v163: () = {
                Spiral::closure7(v7.clone(), v3, ());
                ()
            };
            let v172: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v183: () = {
                Spiral::closure7(v7.clone(), string("cleanup"), ());
                ()
            };
            let v192: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v204: () = {
                Spiral::closure7(
                    v7.clone(),
                    if v4 { string("true") } else { string("false") },
                    (),
                );
                ()
            };
            let v213: () = {
                Spiral::closure7(v7.clone(), string("; "), ());
                ()
            };
            let v224: () = {
                Spiral::closure7(v7.clone(), string("cargo_result"), ());
                ()
            };
            let v233: () = {
                Spiral::closure7(v7.clone(), string(" = "), ());
                ()
            };
            let v242: () = {
                Spiral::closure7(v7.clone(), v5, ());
                ()
            };
            let v253: () = {
                Spiral::closure7(v7.clone(), string(" }"), ());
                ()
            };
            v7.l0.get().clone()
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
            v8: i32,
            v9: string,
            v10: string,
            v11: string,
            v12: bool,
            v13: string,
        ) -> string {
            let v14: string = Spiral::method247(v8, v9, v10, v11, v12, v13);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_rust / cargo error"),
                v14
            ))
        }
        pub fn closure101(
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
                Spiral::method19(Spiral::method246(
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    v35.clone(),
                    v36.clone(),
                    Spiral::method8(v31, v32, v33, v34, v35, v36),
                    Spiral::method82(),
                    v3,
                    v1_1,
                    v4,
                    v5,
                    v0_1,
                    concat(new_array(&[string("\n"), v2])),
                ))
            };
        }
        pub fn method249(v0_1: string, v1_1: LrcPtr<Spiral::UH5>) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("new_code_path"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: () = {
                Spiral::closure7(v3.clone(), v0_1, ());
                ()
            };
            let v54: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v65: () = {
                Spiral::closure7(v3.clone(), string("cleanup"), ());
                ()
            };
            let v74: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v87: () = {
                Spiral::closure7(v3.clone(), sprintf!("{:?}", v1_1), ());
                ()
            };
            let v98: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method248(
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
            let v25: string = Spiral::method249(
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
        pub fn closure102(
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
                Spiral::method19(Spiral::method248(
                    v36.clone(),
                    v37.clone(),
                    v38.clone(),
                    v39.clone(),
                    v40.clone(),
                    v41.clone(),
                    Spiral::method8(v36, v37, v38, v39, v40, v41),
                    Spiral::method85(),
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
        pub fn closure103(unitVar: (), unitVar_1: ()) -> Spiral::US47 {
            Spiral::US47::US47_0
        }
        pub fn method251() -> Func0<Spiral::US47> {
            Func0::new(move || Spiral::closure103((), ()))
        }
        pub fn closure104(unitVar: (), v0_1: string) -> Spiral::US47 {
            Spiral::US47::US47_1(v0_1)
        }
        pub fn method252() -> Func1<string, Spiral::US47> {
            Func1::new(move |v: string| Spiral::closure104((), v))
        }
        pub fn method254(v0_1: string) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral::closure7(v2.clone(), string("error\'"), ());
                ()
            };
            let v33: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v42: () = {
                Spiral::closure7(v2.clone(), v0_1, ());
                ()
            };
            let v53: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
        }
        pub fn method253(
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
            let v9: string = Spiral::method254(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("file_system.file_delete"),
                v9
            ))
        }
        pub fn closure105(v0_1: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method253(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method82(),
                    v0_1,
                ))
            };
        }
        pub fn method250(v0_1: LrcPtr<Spiral::UH5>) {
            let v0_1: MutCell<LrcPtr<Spiral::UH5>> = MutCell::new(v0_1.clone());
            '_method250: loop {
                break '_method250 (match v0_1.get().clone().as_ref() {
                    Spiral::UH5::UH5_0 => (),
                    Spiral::UH5::UH5_1(v0_1_1_0, v0_1_1_1, v0_1_1_2) => {
                        let v6: Result<(), std::io::Error> = std::fs::remove_file(
                            &*match v0_1.get().clone().as_ref() {
                                Spiral::UH5::UH5_1(x, _, _) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        );
                        let v7 = Spiral::method49();
                        let v20: Result<(), string> = v6.map_err(|x| v7(x));
                        let v23 = Spiral::method251();
                        let v24 = Spiral::method252();
                        let v26: Spiral::US47 = match &v20 {
                            Err(v20_1_0) => v24(v20_1_0.clone()),
                            _ => v23(),
                        };
                        match &v26 {
                            Spiral::US47::US47_0 => (),
                            Spiral::US47::US47_1(v26_1_0) => {
                                let v32: () = {
                                    Spiral::closure105(
                                        match &v26 {
                                            Spiral::US47::US47_1(x) => x.clone(),
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
                            continue '_method250;
                        }
                    }
                });
            }
        }
        pub fn method255(v0_1: string) -> string {
            v0_1
        }
        pub fn closure107(unitVar: (), v0_1: std::fs::FileType) -> Spiral::US48 {
            Spiral::US48::US48_0(v0_1)
        }
        pub fn method256() -> Func1<std::fs::FileType, Spiral::US48> {
            Func1::new(move |v: std::fs::FileType| Spiral::closure107((), v))
        }
        pub fn closure108(unitVar: (), v0_1: std::string::String) -> Spiral::US48 {
            Spiral::US48::US48_1(v0_1)
        }
        pub fn method257() -> Func1<std::string::String, Spiral::US48> {
            Func1::new(move |v: std::string::String| Spiral::closure108((), v))
        }
        pub fn method258(v0_1: string) -> string {
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
        pub fn closure106(
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
                            let v20 = Spiral::method79();
                            let v33: Result<std::fs::FileType, std::string::String> =
                                v19.map_err(|x| v20(x));
                            let v36 = Spiral::method256();
                            let v37 = Spiral::method257();
                            let v39: Spiral::US48 = match &v33 {
                                Err(v33_1_0) => v37(v33_1_0.clone()),
                                Ok(v33_0_0) => v36(v33_0_0.clone()),
                            };
                            let v272: Spiral::US49 = if let Spiral::US48::US48_0(v39_0_0) = &v39 {
                                if (std::fs::FileType::is_dir(&v39_0_0.clone())) == false {
                                    Spiral::US49::US49_0
                                } else {
                                    let v48: std::path::PathBuf =
                                        async_walkdir::DirEntry::path(&v1_1.clone());
                                    let v55: std::path::Display = v48.display();
                                    let v88: std::string::String = format!("{}", v55);
                                    let v116: string = fable_library_rust::String_::fromString(v88);
                                    if (startsWith3(
                                        Spiral::method258(v116.clone()),
                                        v0_1.clone(),
                                        false,
                                    )) == false
                                    {
                                        Spiral::US49::US49_1
                                    } else {
                                        let v124: Option<string> = Spiral::method41(v116);
                                        let v143: Spiral::US5 = defaultValue(
                                            Spiral::US5::US5_1,
                                            map(Spiral::method6(), v124),
                                        );
                                        if let Spiral::US5::US5_0(v143_0_0) = &v143 {
                                            if (contains(v143_0_0.clone(), v0_1.clone())) == false {
                                                Spiral::US49::US49_2
                                            } else {
                                                Spiral::US49::US49_1
                                            }
                                        } else {
                                            Spiral::US49::US49_1
                                        }
                                    }
                                }
                            } else {
                                let v161: std::path::PathBuf = async_walkdir::DirEntry::path(&v1_1);
                                let v168: std::path::Display = v161.display();
                                let v201: std::string::String = format!("{}", v168);
                                let v229: string = fable_library_rust::String_::fromString(v201);
                                if (startsWith3(
                                    Spiral::method258(v229.clone()),
                                    v0_1.clone(),
                                    false,
                                )) == false
                                {
                                    Spiral::US49::US49_1
                                } else {
                                    let v237: Option<string> = Spiral::method41(v229);
                                    let v256: Spiral::US5 = defaultValue(
                                        Spiral::US5::US5_1,
                                        map(Spiral::method6(), v237),
                                    );
                                    if let Spiral::US5::US5_0(v256_0_0) = &v256 {
                                        if (contains(v256_0_0.clone(), v0_1)) == false {
                                            Spiral::US49::US49_2
                                        } else {
                                            Spiral::US49::US49_1
                                        }
                                    } else {
                                        Spiral::US49::US49_1
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
                        Box<dyn std::future::Future<Output = Spiral::US49> + Send>,
                    > = v290;
                    let v294: Spiral::US49 = v292.await;
                    let v303: async_walkdir::Filtering = match &v294 {
                        Spiral::US49::US49_0 => async_walkdir::Filtering::Ignore,
                        Spiral::US49::US49_1 => async_walkdir::Filtering::IgnoreDir,
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
        pub fn closure110(unitVar: (), v0_1: async_walkdir::Error) -> std::string::String {
            format!("{}", v0_1)
        }
        pub fn method260() -> Func1<async_walkdir::Error, std::string::String> {
            Func1::new(move |v: async_walkdir::Error| Spiral::closure110((), v))
        }
        pub fn closure111(unitVar: (), v0_1: async_walkdir::DirEntry) -> Spiral::US50 {
            Spiral::US50::US50_0(v0_1)
        }
        pub fn method261() -> Func1<async_walkdir::DirEntry, Spiral::US50> {
            Func1::new(move |v: async_walkdir::DirEntry| Spiral::closure111((), v))
        }
        pub fn closure112(unitVar: (), v0_1: std::string::String) -> Spiral::US50 {
            Spiral::US50::US50_1(v0_1)
        }
        pub fn method262() -> Func1<std::string::String, Spiral::US50> {
            Func1::new(move |v: std::string::String| Spiral::closure112((), v))
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
            v8: std::string::String,
        ) -> string {
            let v9: string = Spiral::method132(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript / stream_filter_map"),
                v9
            ))
        }
        pub fn closure113(v0_1: std::string::String, unitVar: ()) {
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
                Spiral::method19(Spiral::method263(
                    v26.clone(),
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    Spiral::method8(v26, v27, v28, v29, v30, v31),
                    Spiral::method82(),
                    v0_1,
                ))
            };
        }
        pub fn closure109(
            v0_1: string,
            v1_1: Result<async_walkdir::DirEntry, async_walkdir::Error>,
        ) -> Option<(string, string)> {
            let v2 = Spiral::method260();
            let v15: Result<async_walkdir::DirEntry, std::string::String> = v1_1.map_err(|x| v2(x));
            let v18 = Spiral::method261();
            let v19 = Spiral::method262();
            let v21: Spiral::US50 = match &v15 {
                Err(v15_1_0) => v19(v15_1_0.clone()),
                Ok(v15_0_0) => v18(v15_0_0.clone()),
            };
            let v233: Spiral::US51 = match &v21 {
                Spiral::US50::US50_0(v21_0_0) => {
                    let v26: std::path::PathBuf = async_walkdir::DirEntry::path(&v21_0_0.clone());
                    let v33: std::path::Display = v26.display();
                    let v66: std::string::String = format!("{}", v33);
                    let v94: string = fable_library_rust::String_::fromString(v66);
                    let v95: string =
                        concat(new_array(&[v0_1.clone(), string("\\.(?<a>[-\\d\\w.]+)$")]));
                    let v97: Result<regex::Regex, regex::Error> = regex::Regex::new(&v95);
                    let v113: Vec<std::collections::HashMap<string, string>> =
                        Spiral::method234(v94.clone(), v97.unwrap());
                    let v116: Option<std::collections::HashMap<string, string>> = tryItem(
                        0_i32,
                        fable_library_rust::NativeArray_::array_from(v113.clone()),
                    );
                    let v135: Spiral::US45 =
                        defaultValue(Spiral::US45::US45_1, map(Spiral::method235(), v116));
                    let v168: Spiral::US46 = match &v135 {
                        Spiral::US45::US45_0(v135_0_0) => {
                            let v140: string = Spiral::method236();
                            let v142: Option<string> = std::collections::HashMap::get(
                                &match &v135 {
                                    Spiral::US45::US45_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                &v140,
                            )
                            .map(|x| x)
                            .cloned();
                            Spiral::US46::US46_0(defaultValue(
                                Spiral::US5::US5_1,
                                map(Spiral::method6(), v142),
                            ))
                        }
                        _ => Spiral::US46::US46_1,
                    };
                    let v175: Spiral::US5 = if let Spiral::US46::US46_0(v168_0_0) = &v168 {
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
                        Spiral::US5::US5_0(v175_0_0) => Spiral::US51::US51_0(
                            v94.clone(),
                            match &v175 {
                                Spiral::US5::US5_0(x) => x.clone(),
                                _ => unreachable!(),
                            }
                            .clone(),
                        ),
                        _ => Spiral::US51::US51_1,
                    }
                }
                Spiral::US50::US50_1(v21_1_0) => {
                    let v184: () = {
                        Spiral::closure113(v21_1_0.clone(), ());
                        ()
                    };
                    Spiral::US51::US51_1
                }
            };
            match &v233 {
                Spiral::US51::US51_0(v233_0_0, v233_0_1) => Some((
                    match &v233 {
                        Spiral::US51::US51_0(x, _) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                    match &v233 {
                        Spiral::US51::US51_0(_, x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone(),
                )),
                _ => None::<(string, string)>,
            }
        }
        pub fn method259(
            v0_1: string,
        ) -> Func1<Result<async_walkdir::DirEntry, async_walkdir::Error>, Option<(string, string)>>
        {
            Func1::new({
                let v0_1 = v0_1.clone();
                move |v: Result<async_walkdir::DirEntry, async_walkdir::Error>| {
                    Spiral::closure109(v0_1.clone(), v)
                }
            })
        }
        pub fn closure114(unitVar: (), _arg: (string, string)) -> (string, string) {
            (_arg.0.clone(), _arg.1.clone())
        }
        pub fn closure115(unitVar: (), _arg: (string, string)) -> Spiral::US51 {
            Spiral::US51::US51_0(_arg.0.clone(), _arg.1.clone())
        }
        pub fn method264() -> Func1<(string, string), Spiral::US51> {
            Func1::new(move |arg10_0040: (string, string)| Spiral::closure115((), arg10_0040))
        }
        pub fn method266(v0_1: Spiral::US51) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral::closure7(v2.clone(), string("version"), ());
                ()
            };
            let v33: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v46: () = {
                Spiral::closure7(v2.clone(), sprintf!("{:?}", v0_1), ());
                ()
            };
            let v57: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
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
            v8: Spiral::US51,
        ) -> string {
            let v9: string = Spiral::method266(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript"),
                v9
            ))
        }
        pub fn closure116(v0_1: Spiral::US51, unitVar: ()) {
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
                Spiral::method19(Spiral::method265(
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
        pub fn method267(v0_1: string, v1_1: string, v2: Spiral::US51) {
            match &v2 {
                Spiral::US51::US51_0(v2_0_0, v2_0_1) => {
                    let v4: string = match &v2 {
                        Spiral::US51::US51_0(_, x) => x.clone(),
                        _ => unreachable!(),
                    }
                    .clone();
                    Spiral::method218(
                        Spiral::method36(
                            v1_1.clone(),
                            concat(new_array(&[
                                string("fable-library-"),
                                string("ts"),
                                string("."),
                                v4.clone(),
                            ])),
                        ),
                        Spiral::method36(
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
            let v10: string = Spiral::method228(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript"),
                v10
            ))
        }
        pub fn closure117(v0_1: string, v1_1: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method268(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method82(),
                    v1_1,
                    v0_1,
                ))
            };
        }
        pub fn method270(v0_1: string) -> string {
            let v2: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v11: () = {
                Spiral::closure7(v2.clone(), string("{ "), ());
                ()
            };
            let v22: () = {
                Spiral::closure7(v2.clone(), string("new_code_path"), ());
                ()
            };
            let v33: () = {
                Spiral::closure7(v2.clone(), string(" = "), ());
                ()
            };
            let v42: () = {
                Spiral::closure7(v2.clone(), v0_1, ());
                ()
            };
            let v53: () = {
                Spiral::closure7(v2.clone(), string(" }"), ());
                ()
            };
            v2.l0.get().clone()
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
            let v9: string = Spiral::method270(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript"),
                v9
            ))
        }
        pub fn closure118(v0_1: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method269(
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
        pub fn method271(
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
                        Spiral::method271(
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
        pub fn method272(
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
                    Spiral::method272(
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
        pub fn closure119(v0_1: string, unitVar: ()) -> string {
            let v13: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method75(), toArray_1(v13))
        }
        pub fn method274(v0_1: LrcPtr<Exception>, v1_1: string, v2: string, v3: string) -> string {
            let v5: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v14: () = {
                Spiral::closure7(v5.clone(), string("{ "), ());
                ()
            };
            let v25: () = {
                Spiral::closure7(v5.clone(), string("ex"), ());
                ()
            };
            let v36: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v45: std::string::String = format!("{:#?}", v0_1);
            let v84: () = {
                Spiral::closure7(v5.clone(), fable_library_rust::String_::fromString(v45), ());
                ()
            };
            let v95: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v106: () = {
                Spiral::closure7(v5.clone(), string("new_code_path"), ());
                ()
            };
            let v115: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v124: () = {
                Spiral::closure7(v5.clone(), v1_1, ());
                ()
            };
            let v133: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v144: () = {
                Spiral::closure7(v5.clone(), string("external_command"), ());
                ()
            };
            let v153: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v162: () = {
                Spiral::closure7(v5.clone(), v2, ());
                ()
            };
            let v171: () = {
                Spiral::closure7(v5.clone(), string("; "), ());
                ()
            };
            let v182: () = {
                Spiral::closure7(v5.clone(), string("run_result"), ());
                ()
            };
            let v191: () = {
                Spiral::closure7(v5.clone(), string(" = "), ());
                ()
            };
            let v200: () = {
                Spiral::closure7(v5.clone(), v3, ());
                ()
            };
            let v211: () = {
                Spiral::closure7(v5.clone(), string(" }"), ());
                ()
            };
            v5.l0.get().clone()
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
            v8: LrcPtr<Exception>,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method274(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript / Exception"),
                v12
            ))
        }
        pub fn closure121(
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
                Spiral::method19(Spiral::method273(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method82(),
                    v3,
                    v0_1,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure120(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure121(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
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
            v8: i32,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method180(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_typescript / error"),
                v12
            ))
        }
        pub fn closure122(v0_1: string, v1_1: string, v2: i32, v3: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method275(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method82(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
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
            v8: i32,
            v9: string,
        ) -> string {
            let v10: string = Spiral::method228(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python"),
                v10
            ))
        }
        pub fn closure123(v0_1: string, v1_1: i32, unitVar: ()) {
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
                Spiral::method19(Spiral::method276(
                    v27.clone(),
                    v28.clone(),
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    Spiral::method8(v27, v28, v29, v30, v31, v32),
                    Spiral::method82(),
                    v1_1,
                    v0_1,
                ))
            };
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
            v8: string,
        ) -> string {
            let v9: string = Spiral::method270(v8);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python"),
                v9
            ))
        }
        pub fn closure124(v0_1: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method277(
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
        pub fn closure125(v0_1: string, unitVar: ()) -> string {
            let v13: LrcPtr<dyn IEnumerable_1<string>> =
                ofArray_1(split(v0_1, string("\n"), -1_i32, 0_i32));
            join(Spiral::method75(), toArray_1(v13))
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
            v8: LrcPtr<Exception>,
            v9: string,
            v10: string,
            v11: string,
        ) -> string {
            let v12: string = Spiral::method274(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python / Exception"),
                v12
            ))
        }
        pub fn closure127(
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
                Spiral::method19(Spiral::method278(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method82(),
                    v3,
                    v0_1,
                    v2,
                    v1_1,
                ))
            };
        }
        pub fn closure126(
            v0_1: string,
            v1_1: string,
            v2: string,
            v3: LrcPtr<Exception>,
        ) -> Spiral::US5 {
            let v6: () = {
                Spiral::closure127(v0_1, v1_1, v2, v3, ());
                ()
            };
            Spiral::US5::US5_1
        }
        pub fn method279(
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
            let v12: string = Spiral::method180(v8, v9, v10, v11);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.process_python / error"),
                v12
            ))
        }
        pub fn closure128(v0_1: string, v1_1: string, v2: i32, v3: string, unitVar: ()) {
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
                Spiral::method19(Spiral::method279(
                    v29.clone(),
                    v30.clone(),
                    v31.clone(),
                    v32.clone(),
                    v33.clone(),
                    v34.clone(),
                    Spiral::method8(v29, v30, v31, v32, v33, v34),
                    Spiral::method82(),
                    v2,
                    v1_1,
                    v0_1,
                    v3,
                ))
            };
        }
        pub fn method281(v0_1: std::string::String, v1_1: clap::ArgMatches) -> string {
            let v3: LrcPtr<Spiral::Mut3> = LrcPtr::new(Spiral::Mut3 {
                l0: MutCell::new(Spiral::method14()),
            });
            let v12: () = {
                Spiral::closure7(v3.clone(), string("{ "), ());
                ()
            };
            let v23: () = {
                Spiral::closure7(v3.clone(), string("subcommand"), ());
                ()
            };
            let v34: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v43: std::string::String = format!("{:#?}", v0_1);
            let v82: () = {
                Spiral::closure7(v3.clone(), fable_library_rust::String_::fromString(v43), ());
                ()
            };
            let v93: () = {
                Spiral::closure7(v3.clone(), string("; "), ());
                ()
            };
            let v104: () = {
                Spiral::closure7(v3.clone(), string("arg_matches"), ());
                ()
            };
            let v113: () = {
                Spiral::closure7(v3.clone(), string(" = "), ());
                ()
            };
            let v122: std::string::String = format!("{:#?}", v1_1);
            let v161: () = {
                Spiral::closure7(
                    v3.clone(),
                    fable_library_rust::String_::fromString(v122),
                    (),
                );
                ()
            };
            let v172: () = {
                Spiral::closure7(v3.clone(), string(" }"), ());
                ()
            };
            v3.l0.get().clone()
        }
        pub fn method280(
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
            let v10: string = Spiral::method281(v8, v9);
            Spiral::method18(sprintf!(
                "{} {} #{} {} / {}",
                v6,
                v7,
                v0_1.l0.get().clone(),
                string("spiral.run / invalid subcommand"),
                v10
            ))
        }
        pub fn closure129(v0_1: clap::ArgMatches, v1_1: std::string::String, unitVar: ()) {
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
                Spiral::method19(Spiral::method280(
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
        pub fn closure130(unitVar: (), v0_1: serde_json::Error) -> string {
            let v7: std::string::String = format!("{}", v0_1);
            fable_library_rust::String_::fromString(v7)
        }
        pub fn method282() -> Func1<serde_json::Error, string> {
            Func1::new(move |v: serde_json::Error| Spiral::closure130((), v))
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
                    let v6618: Array<(string, string)> = if let Spiral::US6::US6_0(
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
                            let v138: Option<std::string::String> =
                                clap::ArgMatches::get_one(&v35.clone(), v110).cloned();
                            let v157: Spiral::US7 =
                                defaultValue(Spiral::US7::US7_1, map(Spiral::method23(), v138));
                            let v218: Spiral::US8 = match &v157 {
                                Spiral::US7::US7_0(v157_0_0) => {
                                    let v163: string = fable_library_rust::String_::fromString(
                                        match &v157 {
                                            Spiral::US7::US7_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    );
                                    let v168: string = toLower(string("JavaScript"));
                                    let v175: string = toLower(string("Erlang"));
                                    let v182: Spiral::US9 = if string("Erlang") == (v163.clone()) {
                                        Spiral::US9::US9_0(Spiral::US10::US10_0)
                                    } else {
                                        Spiral::US9::US9_1
                                    };
                                    Spiral::US8::US8_0(match &v182 {
                                        Spiral::US9::US9_0(v182_0_0) => Spiral::US9::US9_0(
                                            match &v182 {
                                                Spiral::US9::US9_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        ),
                                        _ => {
                                            let v189: Spiral::US9 =
                                                if string("JavaScript") == (v163.clone()) {
                                                    Spiral::US9::US9_0(Spiral::US10::US10_1)
                                                } else {
                                                    Spiral::US9::US9_1
                                                };
                                            match &v189 {
                                                Spiral::US9::US9_0(v189_0_0) => Spiral::US9::US9_0(
                                                    match &v189 {
                                                        Spiral::US9::US9_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                ),
                                                _ => {
                                                    let v196: Spiral::US9 =
                                                        if (v175.clone()) == (v163.clone()) {
                                                            Spiral::US9::US9_0(Spiral::US10::US10_0)
                                                        } else {
                                                            Spiral::US9::US9_1
                                                        };
                                                    match &v196 {
                                                        Spiral::US9::US9_0(v196_0_0) => {
                                                            Spiral::US9::US9_0(
                                                                match &v196 {
                                                                    Spiral::US9::US9_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            let v203: Spiral::US9 =
                                                                if (v168.clone()) == (v163.clone())
                                                                {
                                                                    Spiral::US9::US9_0(
                                                                        Spiral::US10::US10_1,
                                                                    )
                                                                } else {
                                                                    Spiral::US9::US9_1
                                                                };
                                                            match &v203 {
                                                                Spiral::US9::US9_0(v203_0_0) => {
                                                                    Spiral::US9::US9_0(
                                                                        match &v203 {
                                                                            Spiral::US9::US9_0(
                                                                                x,
                                                                            ) => x.clone(),
                                                                            _ => unreachable!(),
                                                                        }
                                                                        .clone(),
                                                                    )
                                                                }
                                                                _ => Spiral::US9::US9_1,
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    })
                                }
                                _ => Spiral::US8::US8_1,
                            };
                            let v225: Spiral::US9 = if let Spiral::US8::US8_0(v218_0_0) = &v218 {
                                let v219: Spiral::US9 = v218_0_0.clone();
                                if let Spiral::US9::US9_0(v219_0_0) = &v219 {
                                    Spiral::US9::US9_0(v219_0_0.clone())
                                } else {
                                    Spiral::US9::US9_1
                                }
                            } else {
                                Spiral::US9::US9_1
                            };
                            let v229: Spiral::US10 = match &v225 {
                                Spiral::US9::US9_0(v225_0_0) => match &v225 {
                                    Spiral::US9::US9_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => Spiral::US10::US10_0,
                            };
                            let v230: string = Spiral::method25();
                            let v237: &str = &*v230;
                            let v265: Option<Vec<std::string::String>> =
                                clap::ArgMatches::get_many(&v35.clone(), v237)
                                    .map(|x| x.cloned().into_iter().collect());
                            let v284: Spiral::US11 =
                                defaultValue(Spiral::US11::US11_1, map(Spiral::method26(), v265));
                            let v290: Vec<std::string::String> =
                                new_empty::<std::string::String>().to_vec();
                            let v293: Vec<std::string::String> = match &v284 {
                                Spiral::US11::US11_0(v284_0_0) => match &v284 {
                                    Spiral::US11::US11_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => v290.clone(),
                            };
                            let v305: Result<Vec<u8>, std::io::Error> =
                                std::fs::read(&*v102.clone());
                            let v350: Vec<u8> = Spiral::method27(v305.unwrap());
                            let v352: Result<std::string::String, std::string::FromUtf8Error> =
                                std::string::String::from_utf8(v350);
                            let v356: std::string::String = v352.unwrap();
                            let v391: string = fable_library_rust::String_::fromString(v356);
                            let v399: string =
                                Spiral::method29(Spiral::method28(string("gleam"), v391.clone()));
                            let v401: Spiral::US5 = Spiral::method35(Spiral::method34());
                            let v407: Spiral::US5 = match &v401 {
                                Spiral::US5::US5_0(v401_0_0) => Spiral::US5::US5_0(
                                    match &v401 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => Spiral::method35(string(
                                    "c:\\home\\git\\polyglot\\target\\Builder\\spiral",
                                )),
                            };
                            let v413: Spiral::US5 = match &v407 {
                                Spiral::US5::US5_0(v407_0_0) => Spiral::US5::US5_0(
                                    match &v407 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => Spiral::method35(string("/workspaces")),
                            };
                            let v417: string = match &v413 {
                                Spiral::US5::US5_0(v413_0_0) => match &v413 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => panic!("{}", string("Option does not have a value."),),
                            };
                            let v432: string = Spiral::method36(
                                if string("deps") == (Spiral::method55(v417.clone())) {
                                    let v425: Spiral::US5 = Spiral::method35(
                                        Spiral::method41(v417.clone()).clone().unwrap(),
                                    );
                                    match &v425 {
                                        Spiral::US5::US5_0(v425_0_0) => match &v425 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => panic!("{}", string("Option does not have a value."),),
                                    }
                                } else {
                                    v417
                                },
                                string("polyglot"),
                            );
                            let v436: string = toLower(Spiral::method34());
                            let v441: string = toLower(v432);
                            let v450: Spiral::US13 = if startsWith3(v436, v441.clone(), false) {
                                Spiral::US13::US13_1(v441.clone())
                            } else {
                                Spiral::US13::US13_0(v441)
                            };
                            let v462: Result<string, string> = match &v450 {
                                Spiral::US13::US13_0(v450_0_0) => {
                                    Ok::<string, string>(v450_0_0.clone())
                                }
                                Spiral::US13::US13_1(v450_1_0) => {
                                    Err::<string, string>(v450_1_0.clone())
                                }
                            };
                            let v464: bool = true;
                            let _result_unwrap_or_else = v462.unwrap_or_else(|x| {
                                //;
                                let v466: string = x;
                                let v468: bool = true;
                                v466
                            });
                            let v471: string = Spiral::method69(_result_unwrap_or_else);
                            let v481: string = Spiral::method69(Spiral::method36(
                                defaultValue(string(""), Spiral::method41(v102.clone())),
                                string(".."),
                            ));
                            let v483: string = Spiral::method36(v481.clone(), string("gleam.toml"));
                            let v486: Array<string> = new_array(&[
                                string("gleam_stdlib=\">=0.55.0 and <1.0.0\""),
                                string("gary=\">=1.1.0 and <2.0.0\""),
                            ]);
                            let v488: Vec<string> = v486.to_vec();
                            let v490: bool = true;
                            let _vec_map: Vec<_> = v488
                                .into_iter()
                                .map(|x| {
                                    //;
                                    let v492: string = x;
                                    let v499: &str = &*v492;
                                    let v532: std::string::String = String::from(v499);
                                    let v560: bool = true;
                                    v532
                                })
                                .collect::<Vec<_>>();
                            let v562: Vec<std::string::String> = _vec_map;
                            let v563: Vec<std::string::String> = Spiral::method73(v293);
                            let v564: Vec<std::string::String> = Spiral::method74(v562);
                            let v566: bool = true;
                            let mut v564 = v564;
                            let v568: bool = true;
                            v564.extend(v563);
                            let v570: Vec<std::string::String> = v564;
                            let v572: bool = true;
                            let _vec_map: Vec<_> = v570
                                .into_iter()
                                .map(|x| {
                                    //;
                                    let v574: std::string::String = x;
                                    let v576: string =
                                        fable_library_rust::String_::fromString(v574);
                                    let v595: string = if contains(v576.clone(), string("=")) {
                                        v576.clone()
                                    } else {
                                        if endsWith3(v576.clone(), string("]"), false) {
                                            concat(new_array(&[
                                                replace(
                                                    v576.clone(),
                                                    string("["),
                                                    string("={version=\'*\',features=["),
                                                ),
                                                string("}"),
                                            ]))
                                        } else {
                                            concat(new_array(&[v576, string("=\'*\'")]))
                                        }
                                    };
                                    let v597: bool = true;
                                    v595
                                })
                                .collect::<Vec<_>>();
                            let v599: Vec<string> = _vec_map;
                            let v601: Array<string> =
                                fable_library_rust::NativeArray_::array_from(v599.clone());
                            let _let__v606: LrcPtr<dyn IEnumerable_1<string>> =
                                delay(Func0::new({
                                    let v601 = v601.clone();
                                    move || {
                                        map_1(
                                            Func1::new({
                                                let v601 = v601.clone();
                                                move |i: i32| v601[i].clone()
                                            }),
                                            rangeNumeric(
                                                0_i32,
                                                1_i32,
                                                (get_Count(v601.clone())) - 1_i32,
                                            ),
                                        )
                                    }
                                }));
                            let v620: string = join(Spiral::method75(), toArray_1(_let__v606));
                            let v628: Spiral::US5 = if if let Spiral::US10::US10_0 = &v229 {
                                true
                            } else {
                                false
                            } {
                                Spiral::US5::US5_0(string("Erlang"))
                            } else {
                                Spiral::US5::US5_1
                            };
                            let v642: Spiral::US5 = match &v628 {
                                Spiral::US5::US5_0(v628_0_0) => Spiral::US5::US5_0(
                                    match &v628 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                ),
                                _ => {
                                    let v635: Spiral::US5 = if if let Spiral::US10::US10_1 = &v229 {
                                        true
                                    } else {
                                        false
                                    } {
                                        Spiral::US5::US5_0(string("JavaScript"))
                                    } else {
                                        Spiral::US5::US5_1
                                    };
                                    match &v635 {
                                        Spiral::US5::US5_0(v635_0_0) => Spiral::US5::US5_0(
                                            match &v635 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        ),
                                        _ => Spiral::US5::US5_1,
                                    }
                                }
                            };
                            let v649: string = toLower(match &v642 {
                                Spiral::US5::US5_0(v642_0_0) => match &v642 {
                                    Spiral::US5::US5_0(x) => x.clone(),
                                    _ => unreachable!(),
                                }
                                .clone(),
                                _ => panic!("{}", string("Option does not have a value."),),
                            });
                            Spiral::method76(
                                v483,
                                append(
                                    (append(
                                        (append(
                                            (append(
                                                (append(
                                                    (append(
                                                        (append(
                                                            (append(
                                                                (concat(new_array(&[
                                                                    string("name = \""),
                                                                    if contains(
                                                                        v102.clone(),
                                                                        string("_real"),
                                                                    ) {
                                                                        string("main_real")
                                                                    } else {
                                                                        string("main")
                                                                    },
                                                                    string("\""),
                                                                ]))),
                                                                string("\n"),
                                                            )),
                                                            (concat(new_array(&[
                                                                string("target = \""),
                                                                v649,
                                                                string("\""),
                                                            ]))),
                                                        )),
                                                        string("\n"),
                                                    )),
                                                    string(""),
                                                )),
                                                string("\n"),
                                            )),
                                            string("[dependencies]"),
                                        )),
                                        string("\n"),
                                    )),
                                    (v620),
                                ),
                            );
                            {
                                let patternInput: (i32, string) = Spiral::method101(
                                    string("gleam format"),
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
                                    Some(v481.clone()),
                                );
                                let v686: i32 = patternInput.0.clone();
                                let patternInput_4: (
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                ) = if (v686) != 0_i32 {
                                    let v694: () = {
                                        Spiral::closure68(
                                            v102.clone(),
                                            patternInput.1.clone(),
                                            v686,
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
                                    let v748: string = if if let Spiral::US10::US10_0 = &v229 {
                                        true
                                    } else {
                                        false
                                    } {
                                        concat(new_array(&[
                                            string("gleam run --no-print-progress \""),
                                            v102.clone(),
                                            string("\""),
                                        ]))
                                    } else {
                                        string("gleam build --no-print-progress")
                                    };
                                    let v752: Array<(string, string)> = new_array(&[
                                        (string("TRACE_LEVEL"), string("")),
                                        (string("GLEAM_LOG"), string("")),
                                        (string("GLEAM_LOG_NOCOLOUR"), string("")),
                                    ]);
                                    let patternInput_1: (i32, string) = Spiral::method101(
                                        v748.clone(),
                                        None::<CancellationToken>,
                                        v752.clone(),
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
                                        Some(v481.clone()),
                                    );
                                    let v764: string = patternInput_1.1.clone();
                                    let v763: i32 = patternInput_1.0.clone();
                                    let v765: i32 = get_Count(v752.clone());
                                    let v766: Array<string> = new_init(&string(""), v765);
                                    let v767: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method32(v765, v767.clone()) {
                                        let v769: i32 = v767.l0.get().clone();
                                        let patternInput_2: (string, string) = v752[v769].clone();
                                        let v772: string = sprintf!(
                                            "$env:{}=\'\'{}\'\'",
                                            patternInput_2.0.clone(),
                                            patternInput_2.1.clone()
                                        );
                                        v766.get_mut()[v769 as usize] = v772;
                                        {
                                            let v773: i32 = (v769) + 1_i32;
                                            v767.l0.set(v773);
                                            ()
                                        }
                                    }
                                    {
                                        let v786: string = sprintf!(
                                            "pwsh -c \'{}; {}\'",
                                            join(string(";"), toArray_1(ofArray_1(v766.clone()))),
                                            v748
                                        );
                                        let patternInput_3: (
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                        ) = if (v763) == 0_i32 {
                                            let v816: string = if if let Spiral::US10::US10_0 =
                                                &v229
                                            {
                                                true
                                            } else {
                                                false
                                            } {
                                                v764.clone()
                                            } else {
                                                let v790: string = replace(
                                                    v481,
                                                    v471,
                                                    string("http://localhost:3000"),
                                                );
                                                append((append((append((append((append((append((append((append((append((append((append((append((append(string("<link\n  rel=\"stylesheet\"\n"),
                                                                                                                                                               (concat(new_array(&[string("  href=\""),
                                                                                                                                                                                   v790.clone(),
                                                                                                                                                                                   string("/build/dev/javascript/lustre_ui/priv/styles.css\"")]))))),
                                                                                                                                                       string("\n"))),
                                                                                                                                               string("/>"))),
                                                                                                                                       string("\n"))),
                                                                                                                               string("<div id=\"app\"></div>"))),
                                                                                                                       string("\n"))),
                                                                                                               string("<script type=\"module\">"))),
                                                                                                       string("\n"))),
                                                                                               (concat(new_array(&[string("  import * as main from \""),
                                                                                                                   v790,
                                                                                                                   string("/build/dev/javascript/main/main.mjs\"")]))))),
                                                                                       string("\n"))),
                                                                               string("  main.main()"))),
                                                                       string("\n"))),
                                                               string("</script>"))
                                            };
                                            let v823: &str = &*v816.clone();
                                            let v856: std::string::String = String::from(v823);
                                            let result: LrcPtr<MutCell<Spiral::US5>> =
                                                refCell(Spiral::US5::US5_1);
                                            try_catch(
                                                || {
                                                    result.set(Spiral::closure69(
                                                        (),
                                                        Spiral::closure70(v816, ()),
                                                    ))
                                                },
                                                |ex: LrcPtr<Exception>| {
                                                    result.set(Spiral::closure71(
                                                        v102.clone(),
                                                        v786.clone(),
                                                        v856,
                                                        ex.clone(),
                                                    ))
                                                },
                                            );
                                            {
                                                let v888: Spiral::US5 = result.get().clone();
                                                let v899: Option<string> = match &v888 {
                                                    Spiral::US5::US5_0(v888_0_0) => Some(
                                                        match &v888 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    ),
                                                    _ => None::<string>,
                                                };
                                                (
                                                    Spiral::US5::US5_0(string("gleam")),
                                                    Spiral::US5::US5_0(v391),
                                                    Spiral::US5::US5_0(v102.clone()),
                                                    Spiral::US5::US5_0(v899.unwrap()),
                                                )
                                            }
                                        } else {
                                            let v908: () = {
                                                Spiral::closure73(v102, v764, v763, v786, ());
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
                                let v966: Spiral::US5 = patternInput_4.3.clone();
                                let v964: Spiral::US5 = patternInput_4.1.clone();
                                let v963: Spiral::US5 = patternInput_4.0.clone();
                                let v979: Array<(string, string)> = new_array(&[
                                    (
                                        string("extension"),
                                        match &v963 {
                                            Spiral::US5::US5_0(v963_0_0) => match &v963 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("code"),
                                        match &v964 {
                                            Spiral::US5::US5_0(v964_0_0) => match &v964 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("output"),
                                        match &v966 {
                                            Spiral::US5::US5_0(v966_0_0) => match &v966 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                ]);
                                let v981: Vec<(string, string)> = v979.to_vec();
                                let v984: bool = true;
                                let _func1_from_v982 = Func1::from(move |value| {
                                    //;
                                    let patternInput_5: (string, string) = value;
                                    let v994: &str = &*patternInput_5.0.clone();
                                    let v1027: std::string::String = String::from(v994);
                                    let v1060: &str = &*patternInput_5.1.clone();
                                    let v1093: std::string::String = String::from(v1060);
                                    let v1126: bool = true;
                                    LrcPtr::new((v1027, v1093)) /*;
                                                                let v1128: bool = */
                                }); //;
                                let v1130: Func1<
                                    (string, string),
                                    LrcPtr<(std::string::String, std::string::String)>,
                                > = _func1_from_v982;
                                let v1133: Vec<LrcPtr<(std::string::String, std::string::String)>> =
                                    v981.into_iter()
                                        .map(|x| {
                                            Func1::new({
                                                let v1130 = v1130.clone();
                                                move |arg10_0040_3: (string, string)| {
                                                    Spiral::closure74(v1130.clone(), arg10_0040_3)
                                                }
                                            })(x.clone())
                                        })
                                        .collect::<Vec<_>>();
                                let v1134: string =
                                string("std::collections::BTreeMap::from_iter(v1133.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                                let v1135: std::collections::BTreeMap<
                                    std::string::String,
                                    std::string::String,
                                > = std::collections::BTreeMap::from_iter(
                                    v1133
                                        .iter()
                                        .map(|x| x.as_ref())
                                        .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                                );
                                let v1137: Result<std::string::String, serde_json::Error> =
                                    serde_json::to_string(&v1135);
                                let v1141: std::string::String = v1137.unwrap();
                                new_array(&[(
                                    string("command_result"),
                                    fable_library_rust::String_::fromString(v1141),
                                )])
                            }
                        } else {
                            if (fable_library_rust::String_::fromString(v34.clone()))
                                == string("cuda")
                            {
                                let v1160: string = Spiral::method182();
                                let v1167: &str = &*v1160;
                                let v1195: Option<std::string::String> =
                                    clap::ArgMatches::get_one(&v35.clone(), v1167).cloned();
                                let v1214: Spiral::US7 = defaultValue(
                                    Spiral::US7::US7_1,
                                    map(Spiral::method23(), v1195),
                                );
                                let v1221: std::string::String = match &v1214 {
                                    Spiral::US7::US7_0(v1214_0_0) => match &v1214 {
                                        Spiral::US7::US7_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => panic!("{}", string("Option does not have a value."),),
                                };
                                let v1223: string = fable_library_rust::String_::fromString(v1221);
                                let v1224: string = Spiral::method183();
                                let v1231: &str = &*v1224;
                                let v1259: Option<std::string::String> =
                                    clap::ArgMatches::get_one(&v35.clone(), v1231).cloned();
                                let v1278: Spiral::US7 = defaultValue(
                                    Spiral::US7::US7_1,
                                    map(Spiral::method23(), v1259),
                                );
                                let v1339: Spiral::US36 = match &v1278 {
                                    Spiral::US7::US7_0(v1278_0_0) => {
                                        let v1284: string = fable_library_rust::String_::fromString(
                                            match &v1278 {
                                                Spiral::US7::US7_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                        );
                                        let v1289: string = toLower(string("Poetry"));
                                        let v1296: string = toLower(string("Pip"));
                                        let v1303: Spiral::US37 =
                                            if string("Pip") == (v1284.clone()) {
                                                Spiral::US37::US37_0(Spiral::US38::US38_0)
                                            } else {
                                                Spiral::US37::US37_1
                                            };
                                        Spiral::US36::US36_0(match &v1303 {
                                            Spiral::US37::US37_0(v1303_0_0) => {
                                                Spiral::US37::US37_0(
                                                    match &v1303 {
                                                        Spiral::US37::US37_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                )
                                            }
                                            _ => {
                                                let v1310: Spiral::US37 =
                                                    if string("Poetry") == (v1284.clone()) {
                                                        Spiral::US37::US37_0(Spiral::US38::US38_1)
                                                    } else {
                                                        Spiral::US37::US37_1
                                                    };
                                                match &v1310 {
                                                    Spiral::US37::US37_0(v1310_0_0) => {
                                                        Spiral::US37::US37_0(
                                                            match &v1310 {
                                                                Spiral::US37::US37_0(x) => {
                                                                    x.clone()
                                                                }
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => {
                                                        let v1317: Spiral::US37 =
                                                            if (v1296.clone()) == (v1284.clone()) {
                                                                Spiral::US37::US37_0(
                                                                    Spiral::US38::US38_0,
                                                                )
                                                            } else {
                                                                Spiral::US37::US37_1
                                                            };
                                                        match &v1317 {
                                                            Spiral::US37::US37_0(v1317_0_0) => {
                                                                Spiral::US37::US37_0(
                                                                    match &v1317 {
                                                                        Spiral::US37::US37_0(x) => {
                                                                            x.clone()
                                                                        }
                                                                        _ => unreachable!(),
                                                                    }
                                                                    .clone(),
                                                                )
                                                            }
                                                            _ => {
                                                                let v1324: Spiral::US37 = if (v1289
                                                                    .clone())
                                                                    == (v1284.clone())
                                                                {
                                                                    Spiral::US37::US37_0(
                                                                        Spiral::US38::US38_1,
                                                                    )
                                                                } else {
                                                                    Spiral::US37::US37_1
                                                                };
                                                                match &v1324
                                                                                         {
                                                                                         Spiral::US37::US37_0(v1324_0_0)
                                                                                         =>
                                                                                         Spiral::US37::US37_0(match &v1324
                                                                                                                  {
                                                                                                                  Spiral::US37::US37_0(x)
                                                                                                                  =>
                                                                                                                  x.clone(),
                                                                                                                  _
                                                                                                                  =>
                                                                                                                  unreachable!(),
                                                                                                              }.clone()),
                                                                                         _
                                                                                         =>
                                                                                         Spiral::US37::US37_1,
                                                                                     }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        })
                                    }
                                    _ => Spiral::US36::US36_1,
                                };
                                let v1346: Spiral::US37 =
                                    if let Spiral::US36::US36_0(v1339_0_0) = &v1339 {
                                        let v1340: Spiral::US37 = v1339_0_0.clone();
                                        if let Spiral::US37::US37_0(v1340_0_0) = &v1340 {
                                            Spiral::US37::US37_0(v1340_0_0.clone())
                                        } else {
                                            Spiral::US37::US37_1
                                        }
                                    } else {
                                        Spiral::US37::US37_1
                                    };
                                let v1350: Spiral::US38 = match &v1346 {
                                    Spiral::US37::US37_0(v1346_0_0) => match &v1346 {
                                        Spiral::US37::US37_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => Spiral::US38::US38_0,
                                };
                                let v1351: string = Spiral::method25();
                                let v1358: &str = &*v1351;
                                let v1386: Option<Vec<std::string::String>> =
                                    clap::ArgMatches::get_many(&v35.clone(), v1358)
                                        .map(|x| x.cloned().into_iter().collect());
                                let v1405: Spiral::US11 = defaultValue(
                                    Spiral::US11::US11_1,
                                    map(Spiral::method26(), v1386),
                                );
                                let v1411: Vec<std::string::String> =
                                    new_empty::<std::string::String>().to_vec();
                                let v1414: Vec<std::string::String> = match &v1405 {
                                    Spiral::US11::US11_0(v1405_0_0) => match &v1405 {
                                        Spiral::US11::US11_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => v1411.clone(),
                                };
                                let v1426: Result<Vec<u8>, std::io::Error> =
                                    std::fs::read(&*v1223.clone());
                                let v1471: Vec<u8> = Spiral::method27(v1426.unwrap());
                                let v1473: Result<std::string::String, std::string::FromUtf8Error> =
                                    std::string::String::from_utf8(v1471);
                                let v1477: std::string::String = v1473.unwrap();
                                let v1490: string = fable_library_rust::String_::fromString(v1477);
                                let v1519: Spiral::US5 = Spiral::method35(Spiral::method34());
                                let v1525: Spiral::US5 = match &v1519 {
                                    Spiral::US5::US5_0(v1519_0_0) => Spiral::US5::US5_0(
                                        match &v1519 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => Spiral::method35(string(
                                        "c:\\home\\git\\polyglot\\target\\Builder\\spiral",
                                    )),
                                };
                                let v1531: Spiral::US5 = match &v1525 {
                                    Spiral::US5::US5_0(v1525_0_0) => Spiral::US5::US5_0(
                                        match &v1525 {
                                            Spiral::US5::US5_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                    ),
                                    _ => Spiral::method35(string("/workspaces")),
                                };
                                let v1535: string = match &v1531 {
                                    Spiral::US5::US5_0(v1531_0_0) => match &v1531 {
                                        Spiral::US5::US5_0(x) => x.clone(),
                                        _ => unreachable!(),
                                    }
                                    .clone(),
                                    _ => panic!("{}", string("Option does not have a value."),),
                                };
                                let v1550: string = Spiral::method36(
                                    if string("deps") == (Spiral::method55(v1535.clone())) {
                                        let v1543: Spiral::US5 = Spiral::method35(
                                            Spiral::method41(v1535.clone()).clone().unwrap(),
                                        );
                                        match &v1543 {
                                            Spiral::US5::US5_0(v1543_0_0) => match &v1543 {
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
                                        v1535
                                    },
                                    string("polyglot"),
                                );
                                let v1554: string = toLower(Spiral::method34());
                                let v1559: string = toLower(v1550);
                                let v1568: Spiral::US13 =
                                    if startsWith3(v1554, v1559.clone(), false) {
                                        Spiral::US13::US13_1(v1559.clone())
                                    } else {
                                        Spiral::US13::US13_0(v1559)
                                    };
                                let v1580: Result<string, string> = match &v1568 {
                                    Spiral::US13::US13_0(v1568_0_0) => {
                                        Ok::<string, string>(v1568_0_0.clone())
                                    }
                                    Spiral::US13::US13_1(v1568_1_0) => {
                                        Err::<string, string>(v1568_1_0.clone())
                                    }
                                };
                                let v1582: bool = true;
                                let _result_unwrap_or_else = v1580.unwrap_or_else(|x| {
                                    //;
                                    let v1584: string = x;
                                    let v1586: bool = true;
                                    v1584
                                });
                                let v1588: string = _result_unwrap_or_else;
                                let v1593: string =
                                    defaultValue(string(""), Spiral::method41(v1223.clone()));
                                let v1601: string = match &v1350 {
                                    Spiral::US38::US38_1 => {
                                        Spiral::method36(v1593.clone(), string("pyproject.toml"))
                                    }
                                    _ => {
                                        Spiral::method36(v1593.clone(), string("requirements.txt"))
                                    }
                                };
                                let v1603: bool = true;
                                let _vec_map: Vec<_> = v1414
                                    .into_iter()
                                    .map(|x| {
                                        //;
                                        let v1605: std::string::String = x;
                                        let v1607: string =
                                            fable_library_rust::String_::fromString(v1605);
                                        let v1626: string = if contains(v1607.clone(), string("="))
                                        {
                                            v1607.clone()
                                        } else {
                                            if endsWith3(v1607.clone(), string("]"), false) {
                                                concat(new_array(&[
                                                    replace(
                                                        v1607.clone(),
                                                        string("["),
                                                        string("={version=\'*\',features=["),
                                                    ),
                                                    string("}"),
                                                ]))
                                            } else {
                                                concat(new_array(&[v1607, string("=\'*\'")]))
                                            }
                                        };
                                        let v1628: bool = true;
                                        v1626
                                    })
                                    .collect::<Vec<_>>();
                                let v1630: Vec<string> = _vec_map;
                                let v1632: Array<string> =
                                    fable_library_rust::NativeArray_::array_from(v1630.clone());
                                let _let__v1637: LrcPtr<dyn IEnumerable_1<string>> =
                                    delay(Func0::new({
                                        let v1632 = v1632.clone();
                                        move || {
                                            map_1(
                                                Func1::new({
                                                    let v1632 = v1632.clone();
                                                    move |i_1: i32| v1632[i_1].clone()
                                                }),
                                                rangeNumeric(
                                                    0_i32,
                                                    1_i32,
                                                    (get_Count(v1632.clone())) - 1_i32,
                                                ),
                                            )
                                        }
                                    }));
                                let v1651: string =
                                    join(Spiral::method75(), toArray_1(_let__v1637));
                                let patternInput_6: (i32, string) = if (v1651.clone()) == string("")
                                {
                                    (0_i32, string(""))
                                } else {
                                    Spiral::method76(v1601,
                                                     match &v1350 {
                                                         Spiral::US38::US38_1
                                                         =>
                                                         append((append((append((append((append((append((append((append((append(string("[tool.poetry]\nname = \"test\"\nversion = \"0.0.1\"\ndescription = \"\"\nauthors = []\n\n[tool.poetry.dependencies]\npython=\"~3.12\"\n"),
                                                                                                                                (v1651.clone()))),
                                                                                                                        string("\n"))),
                                                                                                                string(""))),
                                                                                                        string("\n"))),
                                                                                                string("[build-system]"))),
                                                                                        string("\n"))),
                                                                                string("requires = [\"poetry-core\"]"))),
                                                                        string("\n"))),
                                                                string("build-backend = \"poetry.core.masonry.api\"")),
                                                         _ => v1651.clone(),
                                                     });
                                    Spiral::method101(
                                        match &v1350 {
                                            Spiral::US38::US38_1 => string("poetry install"),
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
                                        Some(v1593.clone()),
                                    )
                                };
                                let v1712: i32 = patternInput_6.0.clone();
                                let patternInput_10: (
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                    Spiral::US5,
                                ) = if (v1712) != 0_i32 {
                                    let v1720: () = {
                                        Spiral::closure75(
                                            v1350.clone(),
                                            v1223.clone(),
                                            patternInput_6.1.clone(),
                                            v1712,
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
                                    let v1775: string = match &v1350 {
                                        Spiral::US38::US38_1 => concat(new_array(&[
                                            string("poetry run python \""),
                                            v1223.clone(),
                                            string("\""),
                                        ])),
                                        _ => concat(new_array(&[
                                            string("python \""),
                                            v1223.clone(),
                                            string("\""),
                                        ])),
                                    };
                                    let v1778: Array<(string, string)> =
                                        new_array(&[(string("TRACE_LEVEL"), string("Verbose"))]);
                                    let patternInput_7: (i32, string) = Spiral::method101(
                                        v1775.clone(),
                                        None::<CancellationToken>,
                                        v1778.clone(),
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
                                        Some(v1593.clone()),
                                    );
                                    let v1790: string = patternInput_7.1.clone();
                                    let v1789: i32 = patternInput_7.0.clone();
                                    let v1791: i32 = get_Count(v1778.clone());
                                    let v1792: Array<string> = new_init(&string(""), v1791);
                                    let v1793: LrcPtr<Spiral::Mut5> = LrcPtr::new(Spiral::Mut5 {
                                        l0: MutCell::new(0_i32),
                                    });
                                    while Spiral::method32(v1791, v1793.clone()) {
                                        let v1795: i32 = v1793.l0.get().clone();
                                        let patternInput_8: (string, string) = v1778[v1795].clone();
                                        let v1798: string = sprintf!(
                                            "$env:{}=\'\'{}\'\'",
                                            patternInput_8.0.clone(),
                                            patternInput_8.1.clone()
                                        );
                                        v1792.get_mut()[v1795 as usize] = v1798;
                                        {
                                            let v1799: i32 = (v1795) + 1_i32;
                                            v1793.l0.set(v1799);
                                            ()
                                        }
                                    }
                                    {
                                        let v1812: string = sprintf!(
                                            "pwsh -c \'{}; {}\'",
                                            join(string(";"), toArray_1(ofArray_1(v1792.clone()))),
                                            v1775
                                        );
                                        let patternInput_9: (
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                            Spiral::US5,
                                        ) = if if (v1789) == 0_i32 {
                                            true
                                        } else {
                                            contains(v1790.clone(),
                                                            string("cupy_backends.cuda.api.runtime.CUDARuntimeError: cudaErrorInsufficientDriver"))
                                        } {
                                            let result_1: LrcPtr<MutCell<Spiral::US5>> =
                                                refCell(Spiral::US5::US5_1);
                                            try_catch(
                                                || {
                                                    result_1.set(Spiral::closure69(
                                                        (),
                                                        Spiral::closure76(v1790.clone(), ()),
                                                    ))
                                                },
                                                |ex_1: LrcPtr<Exception>| {
                                                    result_1.set(Spiral::closure77(
                                                        v1223.clone(),
                                                        v1790.clone(),
                                                        v1812.clone(),
                                                        ex_1.clone(),
                                                    ))
                                                },
                                            );
                                            {
                                                let v1826: Spiral::US5 = result_1.get().clone();
                                                let v1837: Option<string> = match &v1826 {
                                                    Spiral::US5::US5_0(v1826_0_0) => Some(
                                                        match &v1826 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    ),
                                                    _ => None::<string>,
                                                };
                                                (
                                                    Spiral::US5::US5_0(string("py")),
                                                    Spiral::US5::US5_0(v1490),
                                                    Spiral::US5::US5_0(v1223.clone()),
                                                    Spiral::US5::US5_0(v1837.unwrap()),
                                                )
                                            }
                                        } else {
                                            let v1847: () = {
                                                Spiral::closure79(
                                                    v1223.clone(),
                                                    v1790,
                                                    v1789,
                                                    v1812,
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
                                let v1906: Spiral::US5 = patternInput_10.3.clone();
                                let v1904: Spiral::US5 = patternInput_10.1.clone();
                                let v1903: Spiral::US5 = patternInput_10.0.clone();
                                let v1919: Array<(string, string)> = new_array(&[
                                    (
                                        string("extension"),
                                        match &v1903 {
                                            Spiral::US5::US5_0(v1903_0_0) => match &v1903 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("code"),
                                        match &v1904 {
                                            Spiral::US5::US5_0(v1904_0_0) => match &v1904 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                    (
                                        string("output"),
                                        match &v1906 {
                                            Spiral::US5::US5_0(v1906_0_0) => match &v1906 {
                                                Spiral::US5::US5_0(x) => x.clone(),
                                                _ => unreachable!(),
                                            }
                                            .clone(),
                                            _ => string(""),
                                        },
                                    ),
                                ]);
                                let v1921: Vec<(string, string)> = v1919.to_vec();
                                let v1924: bool = true;
                                let _func1_from_v1922 = Func1::from(move |value| {
                                    //;
                                    let patternInput_11: (string, string) = value;
                                    let v1934: &str = &*patternInput_11.0.clone();
                                    let v1967: std::string::String = String::from(v1934);
                                    let v2000: &str = &*patternInput_11.1.clone();
                                    let v2033: std::string::String = String::from(v2000);
                                    let v2066: bool = true;
                                    LrcPtr::new((v1967, v2033)) /*;
                                                                let v2068: bool = */
                                }); //;
                                let v2070: Func1<
                                    (string, string),
                                    LrcPtr<(std::string::String, std::string::String)>,
                                > = _func1_from_v1922;
                                let v2073: Vec<LrcPtr<(std::string::String, std::string::String)>> =
                                    v1921
                                        .into_iter()
                                        .map(|x| {
                                            Func1::new({
                                                let v2070 = v2070.clone();
                                                move |arg10_0040_7: (string, string)| {
                                                    Spiral::closure74(v2070.clone(), arg10_0040_7)
                                                }
                                            })(x.clone())
                                        })
                                        .collect::<Vec<_>>();
                                let v2074: string =
                                string("std::collections::BTreeMap::from_iter(v2073.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                                let v2075: std::collections::BTreeMap<
                                    std::string::String,
                                    std::string::String,
                                > = std::collections::BTreeMap::from_iter(
                                    v2073
                                        .iter()
                                        .map(|x| x.as_ref())
                                        .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                                );
                                let v2077: Result<std::string::String, serde_json::Error> =
                                    serde_json::to_string(&v2075);
                                let v2081: std::string::String = v2077.unwrap();
                                new_array(&[(
                                    string("command_result"),
                                    fable_library_rust::String_::fromString(v2081),
                                )])
                            } else {
                                if (fable_library_rust::String_::fromString(v34.clone()))
                                    == string("fable")
                                {
                                    let v2100: string = Spiral::method189();
                                    let v2107: &str = &*v2100;
                                    let v2135: Option<std::string::String> =
                                        clap::ArgMatches::get_one(&v35.clone(), v2107).cloned();
                                    let v2154: Spiral::US7 = defaultValue(
                                        Spiral::US7::US7_1,
                                        map(Spiral::method23(), v2135),
                                    );
                                    let v2161: std::string::String = match &v2154 {
                                        Spiral::US7::US7_0(v2154_0_0) => match &v2154 {
                                            Spiral::US7::US7_0(x) => x.clone(),
                                            _ => unreachable!(),
                                        }
                                        .clone(),
                                        _ => panic!("{}", string("Option does not have a value."),),
                                    };
                                    let v2163: string =
                                        fable_library_rust::String_::fromString(v2161);
                                    let v2164: string = Spiral::method190();
                                    let v2171: &str = &*v2164;
                                    let v2199: Option<std::string::String> =
                                        clap::ArgMatches::get_one(&v35.clone(), v2171).cloned();
                                    let v2218: Spiral::US7 = defaultValue(
                                        Spiral::US7::US7_1,
                                        map(Spiral::method23(), v2199),
                                    );
                                    let v2228: Spiral::US5 = match &v2218 {
                                        Spiral::US7::US7_0(v2218_0_0) => Spiral::US5::US5_0(
                                            fable_library_rust::String_::fromString(
                                                match &v2218 {
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
                                        match &v2228 {
                                            Spiral::US5::US5_0(v2228_0_0) => {
                                                let v2230: clap::Command = Spiral::method0();
                                                let v2232: Spiral::US25 =
                                                    Spiral::method116(sprintf!(
                                                        "_ {} --fs-path \"{}\"",
                                                        match &v2228 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                        v2163.clone()
                                                    ));
                                                let v2241:
                                                             Array<string> =
                                                         match &v2232 {
                                                             Spiral::US25::US25_0(v2232_0_0)
                                                             =>
                                                             v2232_0_0.clone(),
                                                             Spiral::US25::US25_1(v2232_1_0)
                                                             =>
                                                             panic!("{}",
                                                                    concat(new_array(&[string("resultm.get / Result value was Error: "),
                   v2232_1_0.clone()])),),
                                                         };
                                                let v2243: Vec<string> = v2241.to_vec();
                                                let v2245: bool = true;
                                                let _vec_map: Vec<_> = v2243
                                                    .into_iter()
                                                    .map(|x| {
                                                        //;
                                                        let v2247: string = x;
                                                        let v2254: &str = &*v2247;
                                                        let v2287: std::string::String =
                                                            String::from(v2254);
                                                        let v2315: bool = true;
                                                        v2287
                                                    })
                                                    .collect::<Vec<_>>();
                                                let v2317: Vec<std::string::String> = _vec_map;
                                                let v2320: std::pin::Pin<
                                                    Box<
                                                        dyn std::future::Future<
                                                            Output = Result<string, string>,
                                                        >,
                                                    >,
                                                > = Spiral::method20(
                                                    v0_1.clone(),
                                                    clap::Command::get_matches_from(v2230, v2317),
                                                );
                                                let v2322: Result<string, string> = v2320.await;
                                                v2322.unwrap()
                                            }
                                            _ => string("{}"),
                                        },
                                    )])
                                } else {
                                    if (fable_library_rust::String_::fromString(v34.clone()))
                                        == string("dib")
                                    {
                                        let v2346: string = Spiral::method191();
                                        let v2353: &str = &*v2346;
                                        let v2381: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v35.clone(), v2353).cloned();
                                        let v2385: Option<string> = map(Spiral::method192(), v2381);
                                        let v2400: string = v2385.unwrap();
                                        let v2401: string = Spiral::method194();
                                        let v2408: &str = &*v2401;
                                        let v2438: u8 = defaultValue(
                                            1_u8,
                                            clap::ArgMatches::get_one(&v35.clone(), v2408).cloned(),
                                        );
                                        let v2441: string = Spiral::method195();
                                        let v2448: &str = &*v2441;
                                        let v2476: Option<std::string::String> =
                                            clap::ArgMatches::get_one(&v35.clone(), v2448).cloned();
                                        let v2495: Spiral::US7 = defaultValue(
                                            Spiral::US7::US7_1,
                                            map(Spiral::method23(), v2476),
                                        );
                                        let patternInput_12: (i32, string) = Spiral::method196(
                                            match &v2495 {
                                                Spiral::US7::US7_0(v2495_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        fable_library_rust::String_::fromString(
                                                            match &v2495 {
                                                                Spiral::US7::US7_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        ),
                                                    )
                                                }
                                                _ => Spiral::US5::US5_1,
                                            },
                                            v2438,
                                            v2400.clone(),
                                            1_u8,
                                        );
                                        let v2508: string = patternInput_12.1.clone();
                                        let v2507: i32 = patternInput_12.0.clone();
                                        let patternInput_15: (i32, string) = if (v2507) != 0_i32 {
                                            (v2507, v2508.clone())
                                        } else {
                                            let patternInput_13:
                                                    (i32, string) =
                                                Spiral::method101(concat(new_array(&[string("jupyter nbconvert \""),
                                                                                     v2400.clone(),
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
                                            let v2521: string = patternInput_13.1.clone();
                                            let v2520: i32 = patternInput_13.0.clone();
                                            let v2524: () = {
                                                Spiral::closure82(v2521.clone(), v2520, ());
                                                ()
                                            };
                                            if (v2520) != 0_i32 {
                                                (
                                                    v2520,
                                                    concat(new_array(&[
                                                        string("repl_result: "),
                                                        v2508.clone(),
                                                        string("\n\njupyter_result: "),
                                                        v2521.clone(),
                                                    ])),
                                                )
                                            } else {
                                                let patternInput_14:
                                                        (i32, string) =
                                                    Spiral::method101(concat(new_array(&[string("pwsh -c \"$counter = 1; $path = \'"),
                                                                                         replace(v2400.clone(),
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
                                                let v2588: string = patternInput_14.1.clone();
                                                let v2587: i32 = patternInput_14.0.clone();
                                                let v2591: () = {
                                                    Spiral::closure83(v2588.clone(), v2587, ());
                                                    ()
                                                };
                                                let v2639: string = concat(new_array(&[
                                                    v2400.clone(),
                                                    string(".html"),
                                                ]));
                                                let v2651: Result<Vec<u8>, std::io::Error> =
                                                    std::fs::read(&*v2639);
                                                let v2696: Vec<u8> =
                                                    Spiral::method27(v2651.unwrap());
                                                let v2698: Result<
                                                    std::string::String,
                                                    std::string::FromUtf8Error,
                                                > = std::string::String::from_utf8(v2696);
                                                let v2702: std::string::String = v2698.unwrap();
                                                let v2745: string = replace(
                                                    fable_library_rust::String_::fromString(v2702),
                                                    string("\r\n"),
                                                    string("\n"),
                                                );
                                                let v2746: string = concat(new_array(&[
                                                    v2400.clone(),
                                                    string(".html"),
                                                ]));
                                                std::fs::write(&*v2746, &*v2745).unwrap();
                                                {
                                                    let v2749: string = concat(new_array(&[
                                                        v2400.clone(),
                                                        string(".ipynb"),
                                                    ]));
                                                    let v2761: Result<Vec<u8>, std::io::Error> =
                                                        std::fs::read(&*v2749);
                                                    let v2806: Vec<u8> =
                                                        Spiral::method27(v2761.unwrap());
                                                    let v2808: Result<
                                                        std::string::String,
                                                        std::string::FromUtf8Error,
                                                    > = std::string::String::from_utf8(v2806);
                                                    let v2812: std::string::String = v2808.unwrap();
                                                    let v2856: string = replace(
                                                        replace(
                                                            fable_library_rust::String_::fromString(
                                                                v2812,
                                                            ),
                                                            string("\r\n"),
                                                            string("\n"),
                                                        ),
                                                        string("\\r\\n"),
                                                        string("\\n"),
                                                    );
                                                    let v2857: string = concat(new_array(&[
                                                        v2400,
                                                        string(".ipynb"),
                                                    ]));
                                                    std::fs::write(&*v2857, &*v2856).unwrap();
                                                    (v2587,
                                                     sprintf!("repl_result: {}\n\njupyter_result: {}\n\npwsh_replace_html_result: {}",
                                                              v2508, v2521,
                                                              v2588))
                                                }
                                            }
                                        };
                                        let v2864: string = patternInput_15.1.clone();
                                        let v2863: i32 = patternInput_15.0.clone();
                                        let v2867: () = {
                                            Spiral::closure84(v2864.clone(), v2863, ());
                                            ()
                                        };
                                        if (v2863) != 0_i32 {
                                            panic!(
                                                "{}",
                                                sprintf!(
                                                    "spiral.run / dib / exit_code: {} / result: {}",
                                                    v2863,
                                                    v2864.clone()
                                                )
                                            );
                                        }
                                        new_array(&[(string("stdio"), v2864)])
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
                                            let v2925: string = Spiral::method189();
                                            let v2932: &str = &*v2925;
                                            let v2960: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v35.clone(), v2932)
                                                    .cloned();
                                            let v2979: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v2960),
                                            );
                                            let v2986: std::string::String = match &v2979 {
                                                Spiral::US7::US7_0(v2979_0_0) => match &v2979 {
                                                    Spiral::US7::US7_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => panic!(
                                                    "{}",
                                                    string("Option does not have a value."),
                                                ),
                                            };
                                            let v2988: string =
                                                fable_library_rust::String_::fromString(v2986);
                                            let v2989: string = Spiral::method25();
                                            let v2996: &str = &*v2989;
                                            let v3024: Option<Vec<std::string::String>> =
                                                clap::ArgMatches::get_many(&v35.clone(), v2996)
                                                    .map(|x| x.cloned().into_iter().collect());
                                            let v3043: Spiral::US11 = defaultValue(
                                                Spiral::US11::US11_1,
                                                map(Spiral::method26(), v3024),
                                            );
                                            let v3049: Vec<std::string::String> =
                                                new_empty::<std::string::String>().to_vec();
                                            let v3052: Vec<std::string::String> = match &v3043 {
                                                Spiral::US11::US11_0(v3043_0_0) => match &v3043 {
                                                    Spiral::US11::US11_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => v3049.clone(),
                                            };
                                            let v3053: string = Spiral::method205();
                                            let v3060: &str = &*v3053;
                                            let v3088: bool =
                                                clap::ArgMatches::get_flag(&v35.clone(), v3060);
                                            let v3089: string = Spiral::method206();
                                            let v3096: &str = &*v3089;
                                            let v3124: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v35.clone(), v3096)
                                                    .cloned();
                                            let v3143: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v3124),
                                            );
                                            let v3153: Spiral::US5 = match &v3143 {
                                                Spiral::US7::US7_0(v3143_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        fable_library_rust::String_::fromString(
                                                            match &v3143 {
                                                                Spiral::US7::US7_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        ),
                                                    )
                                                }
                                                _ => Spiral::US5::US5_1,
                                            };
                                            let v3154: string = Spiral::method207();
                                            let v3161: &str = &*v3154;
                                            let v3189: Option<std::string::String> =
                                                clap::ArgMatches::get_one(&v35.clone(), v3161)
                                                    .cloned();
                                            let v3208: Spiral::US7 = defaultValue(
                                                Spiral::US7::US7_1,
                                                map(Spiral::method23(), v3189),
                                            );
                                            let v3218: Spiral::US5 = match &v3208 {
                                                Spiral::US7::US7_0(v3208_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        fable_library_rust::String_::fromString(
                                                            match &v3208 {
                                                                Spiral::US7::US7_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        ),
                                                    )
                                                }
                                                _ => Spiral::US5::US5_1,
                                            };
                                            let v3227: Spiral::US39 =
                                                if let Spiral::US5::US5_0(v3153_0_0) = &v3153 {
                                                    Spiral::US39::US39_0(Spiral::US40::US40_0(
                                                        v3153_0_0.clone(),
                                                    ))
                                                } else {
                                                    if let Spiral::US5::US5_0(v3218_0_0) = &v3218 {
                                                        Spiral::US39::US39_0(Spiral::US40::US40_1(
                                                            v3218_0_0.clone(),
                                                        ))
                                                    } else {
                                                        Spiral::US39::US39_1
                                                    }
                                                };
                                            let v3239: Result<Vec<u8>, std::io::Error> =
                                                std::fs::read(&*v2988);
                                            let v3284: Vec<u8> = Spiral::method27(v3239.unwrap());
                                            let v3286: Result<
                                                std::string::String,
                                                std::string::FromUtf8Error,
                                            > = std::string::String::from_utf8(v3284);
                                            let v3290: std::string::String = v3286.unwrap();
                                            let v3325: string =
                                                fable_library_rust::String_::fromString(v3290);
                                            let v3333: string =
                                                Spiral::method29(Spiral::method208(
                                                    string("rs"),
                                                    v3325.clone(),
                                                    v3227.clone(),
                                                ));
                                            let v3335: Spiral::US5 =
                                                Spiral::method35(Spiral::method34());
                                            let v3341: Spiral::US5 =
                                                match &v3335 {
                                                    Spiral::US5::US5_0(v3335_0_0)
                                                    =>
                                                    Spiral::US5::US5_0(match &v3335
                                                                           {
                                                                           Spiral::US5::US5_0(x)
                                                                           =>
                                                                           x.clone(),
                                                                           _
                                                                           =>
                                                                           unreachable!(),
                                                                       }.clone()),
                                                    _ =>
                                                    Spiral::method35(string("c:\\home\\git\\polyglot\\target\\Builder\\spiral")),
                                                };
                                            let v3347: Spiral::US5 = match &v3341 {
                                                Spiral::US5::US5_0(v3341_0_0) => {
                                                    Spiral::US5::US5_0(
                                                        match &v3341 {
                                                            Spiral::US5::US5_0(x) => x.clone(),
                                                            _ => unreachable!(),
                                                        }
                                                        .clone(),
                                                    )
                                                }
                                                _ => Spiral::method35(string("/workspaces")),
                                            };
                                            let v3351: string = match &v3347 {
                                                Spiral::US5::US5_0(v3347_0_0) => match &v3347 {
                                                    Spiral::US5::US5_0(x) => x.clone(),
                                                    _ => unreachable!(),
                                                }
                                                .clone(),
                                                _ => panic!(
                                                    "{}",
                                                    string("Option does not have a value."),
                                                ),
                                            };
                                            let v3366: string = Spiral::method36(
                                                if string("deps")
                                                    == (Spiral::method55(v3351.clone()))
                                                {
                                                    let v3359: Spiral::US5 = Spiral::method35(
                                                        Spiral::method41(v3351.clone())
                                                            .clone()
                                                            .unwrap(),
                                                    );
                                                    match &v3359 {
                                                        Spiral::US5::US5_0(v3359_0_0) => {
                                                            match &v3359 {
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
                                                    v3351
                                                },
                                                string("polyglot"),
                                            );
                                            let v3370: string = toLower(Spiral::method34());
                                            let v3375: string = toLower(v3366);
                                            let v3384: Spiral::US13 =
                                                if startsWith3(v3370, v3375.clone(), false) {
                                                    Spiral::US13::US13_1(v3375.clone())
                                                } else {
                                                    Spiral::US13::US13_0(v3375)
                                                };
                                            let v3396: Result<string, string> = match &v3384 {
                                                Spiral::US13::US13_0(v3384_0_0) => {
                                                    Ok::<string, string>(v3384_0_0.clone())
                                                }
                                                Spiral::US13::US13_1(v3384_1_0) => {
                                                    Err::<string, string>(v3384_1_0.clone())
                                                }
                                            };
                                            let v3398: bool = true;
                                            let _result_unwrap_or_else =
                                                v3396.unwrap_or_else(|x| {
                                                    //;
                                                    let v3400: string = x;
                                                    let v3402: bool = true;
                                                    v3400
                                                });
                                            let v3404: string = _result_unwrap_or_else;
                                            let v3409: string = Spiral::method209(
                                                Spiral::US5::US5_0(v3333.clone()),
                                                string("spiral"),
                                                Spiral::US42::US42_0(Spiral::US41::US41_0),
                                                v3404.clone(),
                                            );
                                            let v3415: string = Spiral::method210(
                                                v3325,
                                                string("spiral"),
                                                LrcPtr::new(Spiral::UH2::UH2_0),
                                                LrcPtr::new(Spiral::UH4::UH4_1(
                                                    string("Fable.Core"),
                                                    string("4.3.0"),
                                                    LrcPtr::new(Spiral::UH4::UH4_0),
                                                )),
                                                v3409.clone(),
                                                v3404.clone(),
                                            );
                                            let v3417: string =
                                                Spiral::method36(v3409.clone(), string("../../.."));
                                            let v3419: string = Spiral::method36(
                                                v3417.clone(),
                                                string("Cargo.toml"),
                                            );
                                            if (Spiral::method38(v3419.clone())) == false {
                                                let v3425: DateTime = DateTime::now();
                                                let v3448: string =
                                                    toString(Spiral::method213(new_guid(), v3425));
                                                let v3473: string =
                                                    append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                           (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                               v3448.clone(),
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
                                                                                               v3448,
                                                                                               string("\"")]))))),
                                                                   string("\n"))),
                                                           string("path = \"spiral.rs\""));
                                                std::fs::write(&*v3419.clone(), &*v3473).unwrap();
                                                ()
                                            }
                                            {
                                                let v3476: string = Spiral::method36(
                                                    v3409.clone(),
                                                    string("Cargo.toml"),
                                                );
                                                if (Spiral::method38(v3476.clone())) == false {
                                                    let v3482: DateTime = DateTime::now();
                                                    let v3505: string = toString(
                                                        Spiral::method213(new_guid(), v3482),
                                                    );
                                                    let v3530: string =
                                                        append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                               (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                   v3505.clone(),
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
                                                                                                   v3505,
                                                                                                   string("\"")]))))),
                                                                       string("\n"))),
                                                               string("path = \"spiral.rs\""));
                                                    std::fs::write(&*v3476.clone(), &*v3530)
                                                        .unwrap();
                                                    ()
                                                }
                                                {
                                                    let v3534: string =
                                                        Spiral::method36(v3404.clone(),
                                                                         string("lib/rust/fable/fable_modules/fable-library-rust"));
                                                    let v3536: string = Spiral::method36(
                                                        v3409.clone(),
                                                        string("fable_modules/fable-library-rust"),
                                                    );
                                                    Spiral::method218(v3534, v3536.clone());
                                                    {
                                                        let patternInput_16: (i32, string) =
                                                            Spiral::method219(
                                                                v3227.clone(),
                                                                v3409.clone(),
                                                                string("rs"),
                                                                v3415,
                                                                v3384.clone(),
                                                            );
                                                        let v3538: string =
                                                            patternInput_16.1.clone();
                                                        let v3537: i32 = patternInput_16.0.clone();
                                                        let patternInput_25: (
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                        ) = if (v3537) != 0_i32 {
                                                            let v3545: () = {
                                                                Spiral::closure87(
                                                                    v3538.clone(),
                                                                    v3537,
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            (
                                                                Spiral::US5::US5_0(string("rs")),
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_0(v3538),
                                                            )
                                                        } else {
                                                            let v3696: Vec<std::string::String> =
                                                                if if let Spiral::US39::US39_1 =
                                                                    &v3227
                                                                {
                                                                    true
                                                                } else {
                                                                    false
                                                                } {
                                                                    v3052.clone()
                                                                } else {
                                                                    let v3597 = Spiral::method229();
                                                                    let v3598: Vec<
                                                                        std::string::String,
                                                                    > = Spiral::method230(
                                                                        v3052.clone(),
                                                                    );
                                                                    let v3600: Vec<
                                                                        std::string::String,
                                                                    > = v3598
                                                                        .into_iter()
                                                                        .filter(|x| {
                                                                            v3597(x.clone().clone())
                                                                        })
                                                                        .collect::<Vec<_>>();
                                                                    if (v3600.len() as i32) > 0_i32
                                                                    {
                                                                        v3052.clone()
                                                                    } else {
                                                                        let v3624: &str =
                                                                            &*string("near-sdk");
                                                                        let v3684: Array<
                                                                            std::string::String,
                                                                        > = new_array(&[
                                                                            String::from(v3624),
                                                                        ]);
                                                                        let v3687: Vec<
                                                                            std::string::String,
                                                                        > = Spiral::method73(
                                                                            v3684.to_vec(),
                                                                        );
                                                                        let v3688: Vec<
                                                                            std::string::String,
                                                                        > = Spiral::method74(v3052);
                                                                        let v3690: bool = true;
                                                                        let mut v3688 = v3688;
                                                                        let v3692: bool = true;
                                                                        v3688.extend(v3687);
                                                                        v3688
                                                                    }
                                                                };
                                                            let v3698: bool = true;
                                                            let _vec_map : Vec<_> = v3696.into_iter().map(|x| { //;
                                                                let v3700:
                                                                        std::string::String =
                                                                    x;
                                                                let v3702:
                                                                        string =
                                                                    fable_library_rust::String_::fromString(v3700);
                                                                let v3721:
                                                                        string =
                                                                    if contains(v3702.clone(),
                                                                                string("="))
                                                                       {
                                                                        v3702.clone()
                                                                    } else {
                                                                        if endsWith3(v3702.clone(),
                                                                                     string("]"),
                                                                                     false)
                                                                           {
                                                                            concat(new_array(&[replace(v3702.clone(),
                                                                                                       string("["),
                                                                                                       string("={version=\'*\',features=[")),
                                                                                               string("}")]))
                                                                        } else {
                                                                            concat(new_array(&[v3702,
                                                                                               string("=\'*\'")]))
                                                                        }
                                                                    };
                                                                let v3723:
                                                                        bool =
                                                                    true; v3721 }).collect::<Vec<_>>();
                                                            let v3725: Vec<string> = _vec_map;
                                                            let v3727:
                                                                        Array<string> =
                                                                    fable_library_rust::NativeArray_::array_from(v3725.clone());
                                                            let _let__v3732: LrcPtr<
                                                                dyn IEnumerable_1<string>,
                                                            > = delay(Func0::new({
                                                                let v3727 = v3727.clone();
                                                                move || {
                                                                    map_1(
                                                                        Func1::new({
                                                                            let v3727 =
                                                                                v3727.clone();
                                                                            move |i_2: i32| {
                                                                                v3727[i_2].clone()
                                                                            }
                                                                        }),
                                                                        rangeNumeric(
                                                                            0_i32,
                                                                            1_i32,
                                                                            (get_Count(
                                                                                v3727.clone(),
                                                                            )) - 1_i32,
                                                                        ),
                                                                    )
                                                                }
                                                            }));
                                                            let v3746: string = join(
                                                                Spiral::method75(),
                                                                toArray_1(_let__v3732),
                                                            );
                                                            let v3751: string = Spiral::method36(
                                                                v3409,
                                                                concat(new_array(&[
                                                                    string("spiral"),
                                                                    string("."),
                                                                    string("rs"),
                                                                ])),
                                                            );
                                                            let v3763: Result<
                                                                Vec<u8>,
                                                                std::io::Error,
                                                            > = std::fs::read(&*v3751.clone());
                                                            let v3808: Vec<u8> =
                                                                Spiral::method27(v3763.unwrap());
                                                            let v3810: Result<
                                                                std::string::String,
                                                                std::string::FromUtf8Error,
                                                            > = std::string::String::from_utf8(
                                                                v3808,
                                                            );
                                                            let v3814: std::string::String =
                                                                v3810.unwrap();
                                                            let v3849:
                                                                        string =
                                                                    fable_library_rust::String_::fromString(v3814);
                                                            let v3857: string = append(
                                                                string("on_startup!"),
                                                                (Spiral::method231()),
                                                            );
                                                            let v3860: string = append(
                                                                string(" method0"),
                                                                (Spiral::method232()),
                                                            );
                                                            let v3870: bool = if contains(
                                                                v3849.clone(),
                                                                v3857.clone(),
                                                            ) {
                                                                (contains(v3849, v3860)) == false
                                                            } else {
                                                                false
                                                            };
                                                            let v3935:
                                                                        string =
                                                                    append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append(string("[package]\n"),
                                                                                                                                                                                                                                           (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                                                                                                                                                               v3333.clone(),
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
                                                                                                                                                           (if !((v3227.clone())
                                                                                                                                                                     ==
                                                                                                                                                                     Spiral::US39::US39_1)
                                                                                                                                                               {
                                                                                                                                                                string("fable_library_rust = { workspace = true }")
                                                                                                                                                            } else {
                                                                                                                                                                append((append((append(string("fable_library_rust = { workspace = true, features = ["),
                                                                                                                                                                                       (if v3870
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
                                                                                                                           (v3746))),
                                                                                                                   string("\n"))),
                                                                                                           string(""))),
                                                                                                   string("\n"))),
                                                                                           (if if let Spiral::US39::US39_1
                                                                                                      =
                                                                                                      &v3227
                                                                                                  {
                                                                                                   true
                                                                                               } else {
                                                                                                   false
                                                                                               }
                                                                                               {
                                                                                                append(string("[[bin]]\n"),
                                                                                                       (concat(new_array(&[string("name = \"spiral_"),
                                                                                                                           v3333.clone(),
                                                                                                                           string("\"")]))))
                                                                                            } else {
                                                                                                string("[lib]\ncrate-type = [\"cdylib\"]")
                                                                                            }))),
                                                                                   string("\n"))),
                                                                           string("path = \"spiral.rs\""));
                                                            let v4000:
                                                                        string =
                                                                    append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append((append(string("cargo-features = [\"profile-rustflags\"]\n\n[workspace]\nresolver = \"2\"\nmembers = [\"packages/Rust/*\"]\n\n[workspace.dependencies.fable_library_rust]\n"),
                                                                                                                                                                                                                                                                                                           (concat(new_array(&[string("path = \""),
                                                                                                                                                                                                                                                                                                                               Spiral::method46(v3404.clone()),
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
                                                            Spiral::method76(v3476.clone(), v3935);
                                                            Spiral::method76(v3419, v4000);
                                                            {
                                                                let v4002: string =
                                                                    Spiral::method36(
                                                                        v3536,
                                                                        string("src/Range.rs"),
                                                                    );
                                                                if Spiral::method38(v4002.clone()) {
                                                                    let v4015: Result<
                                                                        Vec<u8>,
                                                                        std::io::Error,
                                                                    > = std::fs::read(
                                                                        &*v4002.clone(),
                                                                    );
                                                                    let v4060: Vec<u8> =
                                                                        Spiral::method27(
                                                                            v4015.unwrap(),
                                                                        );
                                                                    let v4062:
                                                                                Result<std::string::String,
                                                                                       std::string::FromUtf8Error> =
                                                                            std::string::String::from_utf8(v4060);
                                                                    let v4066: std::string::String =
                                                                        v4062.unwrap();
                                                                    Spiral::method76(v4002,
                                                                                         replace(replace(fable_library_rust::String_::fromString(v4066),
                                                                                                         string("use crate::String_::fromCharCode;"),
                                                                                                         string("use crate::String_::fromChar;")),
                                                                                                 string("fromCharCode(c)"),
                                                                                                 string("std::char::from_u32(c).unwrap()")))
                                                                }
                                                                {
                                                                    let patternInput_17: (
                                                                        i32,
                                                                        string,
                                                                    ) = Spiral::method233(
                                                                        v3384.clone(),
                                                                        v3476.clone(),
                                                                        1_u8,
                                                                    );
                                                                    let v4114: i32 =
                                                                        patternInput_17.0.clone();
                                                                    if (v4114) != 0_i32 {
                                                                        let v4122: () = {
                                                                            Spiral::closure91(
                                                                                patternInput_17
                                                                                    .1
                                                                                    .clone(),
                                                                                v4114,
                                                                                (),
                                                                            );
                                                                            ()
                                                                        };
                                                                        ()
                                                                    }
                                                                    {
                                                                        let v4180: Result<
                                                                            Vec<u8>,
                                                                            std::io::Error,
                                                                        > = std::fs::read(
                                                                            &*v3751.clone(),
                                                                        );
                                                                        let v4225: Vec<u8> =
                                                                            Spiral::method27(
                                                                                v4180.unwrap(),
                                                                            );
                                                                        let v4227:
                                                                                    Result<std::string::String,
                                                                                           std::string::FromUtf8Error> =
                                                                                std::string::String::from_utf8(v4225);
                                                                        let v4231:
                                                                                    std::string::String =
                                                                                v4227.unwrap();
                                                                        let v4266:
                                                                                    string =
                                                                                fable_library_rust::String_::fromString(v4231);
                                                                        let v4274:
                                                                                    string =
                                                                                append(string("pub fn main() -> Result<(), String> "),
                                                                                       (Spiral::method239()));
                                                                        let v4321:
                                                                                    string =
                                                                                append((append((if if let Spiral::US39::US39_1
                                                                                                          =
                                                                                                          &v3227
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
                                                                                       (if if if let Spiral::US39::US39_1
                                                                                                     =
                                                                                                     &v3227
                                                                                                 {
                                                                                                  true
                                                                                              } else {
                                                                                                  false
                                                                                              }
                                                                                              {
                                                                                               contains(v4266.clone(),
                                                                                                        append((v3857.clone()),
                                                                                                               string("Spiral::method0()")))
                                                                                           } else {
                                                                                               false
                                                                                           }
                                                                                           {
                                                                                            concat(new_array(&[v4274.clone(),
                                                                                                               string(" Ok(Spiral::method0()) }")]))
                                                                                        } else {
                                                                                            concat(new_array(&[v4274.clone(),
                                                                                                               string(" Ok(()) }")]))
                                                                                        }));
                                                                        let v4323: bool = contains(
                                                                            v4266.clone(),
                                                                            v4274,
                                                                        );
                                                                        let v4425: string = if v4323
                                                                        {
                                                                            v4266.clone()
                                                                        } else {
                                                                            (if (if let Spiral::US39::US39_0(v3227_0_0)
                                                                                                =
                                                                                                &v3227
                                                                                            {
                                                                                             if let Spiral::US40::US40_1(v3227_1_0)
                                                                                                    =
                                                                                                    &v3227_0_0
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
                                                                                                        Spiral::closure92((),
                                                                                                                          v_7))
                                                                                     } else {
                                                                                         let v4421:
                                                                                                 string =
                                                                                             string("use fable_library_rust::DateTime_::DateTime;");
                                                                                         Func1::new({
                                                                                                        let v4421
                                                                                                            =
                                                                                                            v4421.clone();
                                                                                                        move
                                                                                                            |v_8:
                                                                                                                 string|
                                                                                                            Spiral::closure94(v4421.clone(),
                                                                                                                              v_8)
                                                                                                    })
                                                                                     })((if v3870
                                                                                            {
                                                                                             Func1::new(move
                                                                                                            |v_5:
                                                                                                                 string|
                                                                                                            Spiral::closure92((),
                                                                                                                              v_5))
                                                                                         } else {
                                                                                             let v4413:
                                                                                                     string =
                                                                                                 append(string("// "),
                                                                                                        (v3857.clone()));
                                                                                             Func1::new({
                                                                                                            let v3857
                                                                                                                =
                                                                                                                v3857.clone();
                                                                                                            let v4413
                                                                                                                =
                                                                                                                v4413.clone();
                                                                                                            move
                                                                                                                |v_6:
                                                                                                                     string|
                                                                                                                Spiral::closure93(v3857.clone(),
                                                                                                                                  v4413.clone(),
                                                                                                                                  v_6)
                                                                                                        })
                                                                                         })(replace(replace(replace(replace(replace(replace(replace(replace(replace(Spiral::method66(string("\\s\\sfable_library_rust::Native_::getZero\\(\\);"),
                                                                                                                                                                                     string(" fable_library_rust::Native_::getZero::<()>();"),
                                                                                                                                                                                     replace(replace(Spiral::method66(string("\\s\\sgetZero\\(\\);"),
                                                                                                                                                                                                                      string(" getZero::<()>();"),
                                                                                                                                                                                                                      Spiral::method66(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                                                                                                                                                       string(" defaultOf::<()>();"),
                                                                                                                                                                                                                                       replace(replace(concat(new_array(&[v4266,
                                                                                                                                                                                                                                                                          string("\n\n"),
                                                                                                                                                                                                                                                                          v4321,
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
                                                                        if (v4323) == false {
                                                                            Spiral::method76(
                                                                                v3751.clone(),
                                                                                v4425.clone(),
                                                                            );
                                                                        }
                                                                        {
                                                                            let v4431:
                                                                                        string =
                                                                                    if (if let Spiral::US39::US39_1
                                                                                               =
                                                                                               &v3227
                                                                                           {
                                                                                            true
                                                                                        } else {
                                                                                            false
                                                                                        })
                                                                                           !=
                                                                                           true
                                                                                       {
                                                                                        concat(new_array(&[string("cargo +nightly-2024-07-14 build --release --target wasm32-unknown-unknown --manifest-path \""),
                                                                                                           v3476.clone(),
                                                                                                           string("\"")]))
                                                                                    } else {
                                                                                        concat(new_array(&[string("cargo run --manifest-path \""),
                                                                                                           v3476,
                                                                                                           string("\"")]))
                                                                                    };
                                                                            let v4444:
                                                                                        Array<(string,
                                                                                               string)> =
                                                                                    if (if let Spiral::US39::US39_1
                                                                                               =
                                                                                               &v3227
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
                                                                            let v4461:
                                                                                        Result<string,
                                                                                               string> =
                                                                                    match &v3384
                                                                                        {
                                                                                        Spiral::US13::US13_0(v3384_0_0)
                                                                                        =>
                                                                                        Ok::<string,
                                                                                             string>(v3384_0_0.clone()),
                                                                                        Spiral::US13::US13_1(v3384_1_0)
                                                                                        =>
                                                                                        Err::<string,
                                                                                              string>(v3384_1_0.clone()),
                                                                                    };
                                                                            let patternInput_18:
                                                                                        (i32,
                                                                                         string) =
                                                                                    Spiral::method101(v4431.clone(),
                                                                                                      None::<CancellationToken>,
                                                                                                      v4444.clone(),
                                                                                                      None::<Func1<(i32,
                                                                                                                    string,
                                                                                                                    bool),
                                                                                                                   Arc<Async<()>>>>,
                                                                                                      None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                                   ()>>,
                                                                                                      true,
                                                                                                      v4461.ok());
                                                                            let v4479: string =
                                                                                patternInput_18
                                                                                    .1
                                                                                    .clone();
                                                                            let v4478: i32 =
                                                                                patternInput_18
                                                                                    .0
                                                                                    .clone();
                                                                            let patternInput_24:
                                                                                        (Spiral::US5,
                                                                                         Spiral::US5,
                                                                                         Spiral::US5,
                                                                                         Spiral::US5) =
                                                                                    if if let Spiral::US39::US39_1
                                                                                              =
                                                                                              &v3227
                                                                                          {
                                                                                           true
                                                                                       } else {
                                                                                           false
                                                                                       }
                                                                                       {
                                                                                        let v4481:
                                                                                                i32 =
                                                                                            get_Count(v4444.clone());
                                                                                        let v4482:
                                                                                                Array<string> =
                                                                                            new_init(&string(""),
                                                                                                     v4481);
                                                                                        let v4483:
                                                                                                LrcPtr<Spiral::Mut5> =
                                                                                            LrcPtr::new(Spiral::Mut5{l0:
                                                                                                                         MutCell::new(0_i32),});
                                                                                        while Spiral::method32(v4481,
                                                                                                               v4483.clone())
                                                                                              {
                                                                                            let v4485:
                                                                                                    i32 =
                                                                                                v4483.l0.get().clone();
                                                                                            let patternInput_19:
                                                                                                    (string,
                                                                                                     string) =
                                                                                                v4444[v4485].clone();
                                                                                            let v4488:
                                                                                                    string =
                                                                                                sprintf!("$env:{}=\'\'{}\'\'",
                                                                                                         patternInput_19.0.clone(),
                                                                                                         patternInput_19.1.clone());
                                                                                            v4482.get_mut()[v4485
                                                                                                                as
                                                                                                                usize]
                                                                                                =
                                                                                                v4488;
                                                                                            {
                                                                                                let v4489:
                                                                                                        i32 =
                                                                                                    (v4485)
                                                                                                        +
                                                                                                        1_i32;
                                                                                                v4483.l0.set(v4489);
                                                                                                ()
                                                                                            }
                                                                                        }
                                                                                        {
                                                                                            let v4513:
                                                                                                    string =
                                                                                                concat(new_array(&[string("pwsh -c \'"),
                                                                                                                   join(string(";"),
                                                                                                                        toArray_1(ofArray_1(new_array(&[join(string(";"),
                                                                                                                                                             toArray_1(ofArray_1(v4482.clone()))),
                                                                                                                                                        v4431])))),
                                                                                                                   string("\'")]));
                                                                                            let patternInput_20:
                                                                                                    (Spiral::US5,
                                                                                                     Spiral::US5,
                                                                                                     Spiral::US5,
                                                                                                     Spiral::US5) =
                                                                                                if (v4478)
                                                                                                       !=
                                                                                                       0_i32
                                                                                                   {
                                                                                                    let v4520:
                                                                                                            () =
                                                                                                        {
                                                                                                            Spiral::closure95(v3088,
                                                                                                                              v3751.clone(),
                                                                                                                              v4479.clone(),
                                                                                                                              v4478,
                                                                                                                              v4513.clone(),
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
                                                                                                                  result_2.set(Spiral::closure69((),
                                                                                                                                                 Spiral::closure96(v4479.clone(),
                                                                                                                                                                   ()))),
                                                                                                              |ex_2:
                                                                                                                   LrcPtr<Exception>|
                                                                                                                  result_2.set(Spiral::closure98(v3751.clone(),
                                                                                                                                                 v4479.clone(),
                                                                                                                                                 v4513,
                                                                                                                                                 ex_2.clone())));
                                                                                                    {
                                                                                                        let v4576:
                                                                                                                Spiral::US5 =
                                                                                                            result_2.get().clone();
                                                                                                        let v4587:
                                                                                                                Option<string> =
                                                                                                            match &v4576
                                                                                                                {
                                                                                                                Spiral::US5::US5_0(v4576_0_0)
                                                                                                                =>
                                                                                                                Some(match &v4576
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
                                                                                                         Spiral::US5::US5_0(v4425.clone()),
                                                                                                         Spiral::US5::US5_0(v3751.clone()),
                                                                                                         Spiral::US5::US5_0(v4587.unwrap()))
                                                                                                    }
                                                                                                };
                                                                                            (patternInput_20.0.clone(),
                                                                                             patternInput_20.1.clone(),
                                                                                             patternInput_20.2.clone(),
                                                                                             patternInput_20.3.clone())
                                                                                        }
                                                                                    } else {
                                                                                        let v4598:
                                                                                                string =
                                                                                            sprintf!("target/spiral/{}/target/wasm32-unknown-unknown/release/spiral_{}.wasm",
                                                                                                     string("spiral"),
                                                                                                     v3333.clone());
                                                                                        let v4610:
                                                                                                string =
                                                                                            sprintf!("pwsh -c \"pwsh {} {} -Linux -EnvironmentVariables AUTOMATION={}`nNEAR_RPC_TIMEOUT_SECS=100\"",
                                                                                                     string("scripts/invoke-block.ps1"),
                                                                                                     sprintf!("\'deps/spiral/workspace/target/release/spiral_wasm -w {} -t debug {}\'",
                                                                                                              v4598.clone(),
                                                                                                              if let Spiral::US39::US39_0(v3227_0_0)
                                                                                                                     =
                                                                                                                     &v3227
                                                                                                                 {
                                                                                                                  let v4599:
                                                                                                                          Spiral::US40 =
                                                                                                                      v3227_0_0.clone();
                                                                                                                  match &v4599
                                                                                                                      {
                                                                                                                      Spiral::US40::US40_0(v4599_0_0)
                                                                                                                      =>
                                                                                                                      v4599_0_0.clone(),
                                                                                                                      Spiral::US40::US40_1(v4599_1_0)
                                                                                                                      =>
                                                                                                                      v4599_1_0.clone(),
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
                                                                                            if (v4478)
                                                                                                   ==
                                                                                                   0_i32
                                                                                               {
                                                                                                let patternInput_21:
                                                                                                        (i32,
                                                                                                         string) =
                                                                                                    Spiral::method101(v4610.clone(),
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
                                                                                                                      Some(v3404));
                                                                                                let v4623:
                                                                                                        string =
                                                                                                    patternInput_21.1.clone();
                                                                                                let v4622:
                                                                                                        i32 =
                                                                                                    patternInput_21.0.clone();
                                                                                                let patternInput_22:
                                                                                                        (Spiral::US5,
                                                                                                         Spiral::US5,
                                                                                                         Spiral::US5,
                                                                                                         Spiral::US5) =
                                                                                                    if (v4622)
                                                                                                           ==
                                                                                                           0_i32
                                                                                                       {
                                                                                                        (Spiral::US5::US5_0(string("rs")),
                                                                                                         Spiral::US5::US5_0(v4425),
                                                                                                         Spiral::US5::US5_0(v3751.clone()),
                                                                                                         Spiral::US5::US5_0(v4623.clone()))
                                                                                                    } else {
                                                                                                        let v4631:
                                                                                                                () =
                                                                                                            {
                                                                                                                Spiral::closure100(v3088,
                                                                                                                                   v3751.clone(),
                                                                                                                                   v4479.clone(),
                                                                                                                                   v4623,
                                                                                                                                   v4622,
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
                                                                                                let v4689:
                                                                                                        () =
                                                                                                    {
                                                                                                        Spiral::closure101(v3088,
                                                                                                                           v3751.clone(),
                                                                                                                           v4479,
                                                                                                                           v4478,
                                                                                                                           v4598,
                                                                                                                           v4610,
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
                                                                            if v3088 {
                                                                                let v4753:
                                                                                            string =
                                                                                        if (if let Spiral::US39::US39_1
                                                                                                   =
                                                                                                   &v3227
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
                                                                                let v4756:
                                                                                            string =
                                                                                        Spiral::method36(v3417.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4753.clone(),
                                                                                                                  v3333.clone(),
                                                                                                                  string("")));
                                                                                let v4759:
                                                                                            string =
                                                                                        Spiral::method36(v3417.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4753.clone(),
                                                                                                                  v3333.clone(),
                                                                                                                  string(".wasm")));
                                                                                let v4762:
                                                                                            string =
                                                                                        Spiral::method36(v3417.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4753.clone(),
                                                                                                                  v3333.clone(),
                                                                                                                  string(".pdb")));
                                                                                let v4765:
                                                                                            string =
                                                                                        Spiral::method36(v3417.clone(),
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4753.clone(),
                                                                                                                  v3333.clone(),
                                                                                                                  string(".exe")));
                                                                                let v4768:
                                                                                            string =
                                                                                        Spiral::method36(v3417,
                                                                                                         sprintf!("target/{}/spiral_{}{}",
                                                                                                                  v4753,
                                                                                                                  v3333,
                                                                                                                  string(".d")));
                                                                                let v4769:
                                                                                            bool =
                                                                                        Spiral::method38(v4756.clone());
                                                                                let v4770:
                                                                                            bool =
                                                                                        Spiral::method38(v4759.clone());
                                                                                let v4771:
                                                                                            bool =
                                                                                        Spiral::method38(v4762.clone());
                                                                                let v4772:
                                                                                            bool =
                                                                                        Spiral::method38(v4765.clone());
                                                                                let v4773:
                                                                                            bool =
                                                                                        Spiral::method38(v4768.clone());
                                                                                let v4776: () = {
                                                                                    Spiral::closure102(v3751,
                                                                                                               v4768.clone(),
                                                                                                               v4773,
                                                                                                               v4765.clone(),
                                                                                                               v4772,
                                                                                                               v4762.clone(),
                                                                                                               v4771,
                                                                                                               v4759.clone(),
                                                                                                               v4770,
                                                                                                               v4756.clone(),
                                                                                                               v4769,
                                                                                                               ());
                                                                                    ()
                                                                                };
                                                                                let v4826: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4769 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4756,
                                                                                                                           v4769,
                                                                                                                           LrcPtr::new(Spiral::UH5::UH5_0)))
                                                                                } else {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_0)
                                                                                };
                                                                                let v4828: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4770 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4759,
                                                                                                                           v4770,
                                                                                                                           v4826.clone()))
                                                                                } else {
                                                                                    v4826
                                                                                };
                                                                                let v4830: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4771 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4762,
                                                                                                                           v4771,
                                                                                                                           v4828.clone()))
                                                                                } else {
                                                                                    v4828
                                                                                };
                                                                                let v4832: LrcPtr<
                                                                                    Spiral::UH5,
                                                                                > = if v4772 {
                                                                                    LrcPtr::new(Spiral::UH5::UH5_1(v4765,
                                                                                                                           v4772,
                                                                                                                           v4830.clone()))
                                                                                } else {
                                                                                    v4830
                                                                                };
                                                                                Spiral::method250(
                                                                                    if v4773 {
                                                                                        LrcPtr::new(Spiral::UH5::UH5_1(v4768,
                                                                                                                                         v4773,
                                                                                                                                         v4832.clone()))
                                                                                    } else {
                                                                                        v4832
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
                                                let v4842: string = Spiral::method189();
                                                let v4849: &str = &*v4842;
                                                let v4877: Option<std::string::String> =
                                                    clap::ArgMatches::get_one(&v35.clone(), v4849)
                                                        .cloned();
                                                let v4896: Spiral::US7 = defaultValue(
                                                    Spiral::US7::US7_1,
                                                    map(Spiral::method23(), v4877),
                                                );
                                                let v4903: std::string::String = match &v4896 {
                                                    Spiral::US7::US7_0(v4896_0_0) => match &v4896 {
                                                        Spiral::US7::US7_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => panic!(
                                                        "{}",
                                                        string("Option does not have a value."),
                                                    ),
                                                };
                                                let v4905: string =
                                                    fable_library_rust::String_::fromString(v4903);
                                                let v4906: string = Spiral::method25();
                                                let v4913: &str = &*v4906;
                                                let v4941: Option<Vec<std::string::String>> =
                                                    clap::ArgMatches::get_many(&v35.clone(), v4913)
                                                        .map(|x| x.cloned().into_iter().collect());
                                                let v4960: Spiral::US11 = defaultValue(
                                                    Spiral::US11::US11_1,
                                                    map(Spiral::method26(), v4941),
                                                );
                                                let v4966: Vec<std::string::String> =
                                                    new_empty::<std::string::String>().to_vec();
                                                let v4969: Vec<std::string::String> = match &v4960 {
                                                    Spiral::US11::US11_0(v4960_0_0) => match &v4960
                                                    {
                                                        Spiral::US11::US11_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => v4966.clone(),
                                                };
                                                let v4981: Result<Vec<u8>, std::io::Error> =
                                                    std::fs::read(&*v4905);
                                                let v5026: Vec<u8> =
                                                    Spiral::method27(v4981.unwrap());
                                                let v5028: Result<
                                                    std::string::String,
                                                    std::string::FromUtf8Error,
                                                > = std::string::String::from_utf8(v5026);
                                                let v5032: std::string::String = v5028.unwrap();
                                                let v5067: string =
                                                    fable_library_rust::String_::fromString(v5032);
                                                let v5079: string = Spiral::method29(sprintf!(
                                                    "{:?}",
                                                    (string("ts"), v5067.clone())
                                                ));
                                                let v5081: Spiral::US5 =
                                                    Spiral::method35(Spiral::method34());
                                                let v5087: Spiral::US5 =
                                                        match &v5081 {
                                                            Spiral::US5::US5_0(v5081_0_0)
                                                            =>
                                                            Spiral::US5::US5_0(match &v5081
                                                                                   {
                                                                                   Spiral::US5::US5_0(x)
                                                                                   =>
                                                                                   x.clone(),
                                                                                   _
                                                                                   =>
                                                                                   unreachable!(),
                                                                               }.clone()),
                                                            _ =>
                                                            Spiral::method35(string("c:\\home\\git\\polyglot\\target\\Builder\\spiral")),
                                                        };
                                                let v5093: Spiral::US5 = match &v5087 {
                                                    Spiral::US5::US5_0(v5087_0_0) => {
                                                        Spiral::US5::US5_0(
                                                            match &v5087 {
                                                                Spiral::US5::US5_0(x) => x.clone(),
                                                                _ => unreachable!(),
                                                            }
                                                            .clone(),
                                                        )
                                                    }
                                                    _ => Spiral::method35(string("/workspaces")),
                                                };
                                                let v5097: string = match &v5093 {
                                                    Spiral::US5::US5_0(v5093_0_0) => match &v5093 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => panic!(
                                                        "{}",
                                                        string("Option does not have a value."),
                                                    ),
                                                };
                                                let v5112: string = Spiral::method36(
                                                    if string("deps")
                                                        == (Spiral::method55(v5097.clone()))
                                                    {
                                                        let v5105: Spiral::US5 = Spiral::method35(
                                                            Spiral::method41(v5097.clone())
                                                                .clone()
                                                                .unwrap(),
                                                        );
                                                        match &v5105 {
                                                            Spiral::US5::US5_0(v5105_0_0) => {
                                                                match &v5105 {
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
                                                        v5097
                                                    },
                                                    string("polyglot"),
                                                );
                                                let v5116: string = toLower(Spiral::method34());
                                                let v5121: string = toLower(v5112);
                                                let v5130: Spiral::US13 =
                                                    if startsWith3(v5116, v5121.clone(), false) {
                                                        Spiral::US13::US13_1(v5121.clone())
                                                    } else {
                                                        Spiral::US13::US13_0(v5121)
                                                    };
                                                let v5142: Result<string, string> = match &v5130 {
                                                    Spiral::US13::US13_0(v5130_0_0) => {
                                                        Ok::<string, string>(v5130_0_0.clone())
                                                    }
                                                    Spiral::US13::US13_1(v5130_1_0) => {
                                                        Err::<string, string>(v5130_1_0.clone())
                                                    }
                                                };
                                                let v5144: bool = true;
                                                let _result_unwrap_or_else =
                                                    v5142.unwrap_or_else(|x| {
                                                        //;
                                                        let v5146: string = x;
                                                        let v5148: bool = true;
                                                        v5146
                                                    });
                                                let v5150: string = _result_unwrap_or_else;
                                                let v5155: string = Spiral::method209(
                                                    Spiral::US5::US5_0(v5079.clone()),
                                                    string("spiral"),
                                                    Spiral::US42::US42_0(Spiral::US41::US41_1),
                                                    v5150.clone(),
                                                );
                                                let v5161: string = Spiral::method210(
                                                    v5067,
                                                    string("spiral"),
                                                    LrcPtr::new(Spiral::UH2::UH2_0),
                                                    LrcPtr::new(Spiral::UH4::UH4_1(
                                                        string("Fable.Core"),
                                                        string("4.3.0"),
                                                        LrcPtr::new(Spiral::UH4::UH4_0),
                                                    )),
                                                    v5155.clone(),
                                                    v5150.clone(),
                                                );
                                                let v5163: string = Spiral::method36(
                                                    v5150.clone(),
                                                    string("lib/typescript/fable/fable_modules"),
                                                );
                                                let v5164: string = concat(new_array(&[
                                                    string("fable-library-"),
                                                    string("ts"),
                                                ]));
                                                let v5165: string =
                                                    Spiral::method255(v5164.clone());
                                                let v5167: async_walkdir::WalkDir =
                                                    async_walkdir::WalkDir::new(&*v5163.clone());
                                                let v5170: async_walkdir::WalkDir =
                                                    async_walkdir::WalkDir::filter(
                                                        v5167,
                                                        move |x| {
                                                            Func1::new({
                                                                let v5164 = v5164.clone();
                                                                move
                                                                                                                          |v_11:
                                                                                                                               async_walkdir::DirEntry|
                                                                                                                          Spiral::closure106(v5164.clone(),
                                                                                                                                             v_11)
                                                            })(
                                                                x
                                                            )
                                                        },
                                                    );
                                                let v5171 = Spiral::method259(v5165);
                                                let v5173 = futures::stream::StreamExt::filter_map(
                                                    v5170,
                                                    |x| async { v5171(x) },
                                                );
                                                let v5175: std::pin::Pin<
                                                    Box<
                                                        dyn std::future::Future<
                                                            Output = Vec<(string, string)>,
                                                        >,
                                                    >,
                                                > = Box::pin(futures::stream::StreamExt::collect(
                                                    v5173,
                                                ));
                                                let v5177: Vec<(string, string)> = v5175.await;
                                                let v5179: rayon::vec::IntoIter<(string, string)> =
                                                    rayon::iter::IntoParallelIterator::into_par_iter(
                                                        v5177,
                                                    );
                                                let v5182: rayon::iter::Map<
                                                    rayon::vec::IntoIter<(string, string)>,
                                                    _,
                                                > = rayon::iter::ParallelIterator::map(
                                                    v5179,
                                                    |x| {
                                                        Func1::new(move
                                                                                                                     |arg10_0040_18:
                                                                                                                          (string,
                                                                                                                           string)|
                                                                                                                     Spiral::closure114((),
                                                                                                                                        arg10_0040_18))(x)
                                                    },
                                                );
                                                let v5184: Vec<(string, string)> =
                                                    rayon::iter::ParallelIterator::collect(v5182);
                                                let v5187: Option<(string, string)> = tryItem(
                                                    0_i32,
                                                    fable_library_rust::NativeArray_::array_from(
                                                        v5184.clone(),
                                                    ),
                                                );
                                                let v5207: Spiral::US51 = defaultValue(
                                                    Spiral::US51::US51_1,
                                                    map(Spiral::method264(), v5187),
                                                );
                                                let v5213: () = {
                                                    Spiral::closure116(v5207.clone(), ());
                                                    ()
                                                };
                                                Spiral::method267(
                                                    v5155.clone(),
                                                    v5163.clone(),
                                                    v5207.clone(),
                                                );
                                                {
                                                    let patternInput_26: (i32, string) =
                                                        Spiral::method219(
                                                            Spiral::US39::US39_1,
                                                            v5155.clone(),
                                                            string("ts"),
                                                            v5161,
                                                            v5130.clone(),
                                                        );
                                                    let v5262: string = patternInput_26.1.clone();
                                                    let v5261: i32 = patternInput_26.0.clone();
                                                    Spiral::method267(
                                                        v5155.clone(),
                                                        v5163,
                                                        v5207.clone(),
                                                    );
                                                    {
                                                        let patternInput_30: (
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                        ) = if (v5261) != 0_i32 {
                                                            let v5269: () = {
                                                                Spiral::closure117(
                                                                    v5262.clone(),
                                                                    v5261,
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            (
                                                                Spiral::US5::US5_0(string("ts")),
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_0(v5262),
                                                            )
                                                        } else {
                                                            let v5321: bool = true;
                                                            let _vec_map : Vec<_> = v4969.into_iter().map(|x| { //;
                                                                    let v5323:
                                                                            std::string::String =
                                                                        x;
                                                                    let v5325:
                                                                            string =
                                                                        fable_library_rust::String_::fromString(v5323);
                                                                    let v5333:
                                                                            string =
                                                                        if contains(v5325.clone(),
                                                                                    string("="))
                                                                           {
                                                                            v5325.clone()
                                                                        } else {
                                                                            concat(new_array(&[string("\""),
                                                                                               v5325,
                                                                                               string("\":\"*\"")]))
                                                                        };
                                                                    let v5335:
                                                                            bool =
                                                                        true; v5333 }).collect::<Vec<_>>();
                                                            let v5337: Vec<string> = _vec_map;
                                                            let v5339:
                                                                            Array<string> =
                                                                        fable_library_rust::NativeArray_::array_from(v5337.clone());
                                                            let v5358: string = join(
                                                                string(",\n"),
                                                                toArray_1(delay(Func0::new({
                                                                    let v5339 = v5339.clone();
                                                                    move || {
                                                                        map_1(
                                                                            Func1::new({
                                                                                let v5339 =
                                                                                    v5339.clone();
                                                                                move |i_3: i32| {
                                                                                    v5339[i_3]
                                                                                        .clone()
                                                                                }
                                                                            }),
                                                                            rangeNumeric(
                                                                                0_i32,
                                                                                1_i32,
                                                                                (get_Count(
                                                                                    v5339.clone(),
                                                                                )) - 1_i32,
                                                                            ),
                                                                        )
                                                                    }
                                                                }))),
                                                            );
                                                            let v5374:
                                                                            string =
                                                                        append((append((append((append((append((append((append(string("{"),
                                                                                                                               (concat(new_array(&[string("  \"name\": \"spiral_"),
                                                                                                                                                   v5079,
                                                                                                                                                   string("\",")]))))),
                                                                                                                       string("  \"dependencies\": {"))),
                                                                                                               (v5358))),
                                                                                                       string("  },"))),
                                                                                               string("    \"devDependencies\": {"))),
                                                                                       string("  },"))),
                                                                               string("}"));
                                                            let v5376: string = Spiral::method36(
                                                                v5155.clone(),
                                                                string("package.json"),
                                                            );
                                                            let v5379: string = Spiral::method36(
                                                                Spiral::method36(
                                                                    v5155.clone(),
                                                                    string("../.."),
                                                                ),
                                                                string("package.json"),
                                                            );
                                                            Spiral::method76(v5376, v5374);
                                                            Spiral::method76(v5379, string(""));
                                                            {
                                                                let v5382: string =
                                                                    Spiral::method36(
                                                                        v5155,
                                                                        concat(new_array(&[
                                                                            string("spiral"),
                                                                            string("."),
                                                                            string("ts"),
                                                                        ])),
                                                                    );
                                                                let v5385: () = {
                                                                    Spiral::closure118(
                                                                        v5382.clone(),
                                                                        (),
                                                                    );
                                                                    ()
                                                                };
                                                                let v5443: Result<
                                                                    Vec<u8>,
                                                                    std::io::Error,
                                                                > = std::fs::read(&*v5382.clone());
                                                                let v5488: Vec<u8> =
                                                                    Spiral::method27(
                                                                        v5443.unwrap(),
                                                                    );
                                                                let v5490: Result<
                                                                    std::string::String,
                                                                    std::string::FromUtf8Error,
                                                                > = std::string::String::from_utf8(
                                                                    v5488,
                                                                );
                                                                let v5494: std::string::String =
                                                                    v5490.unwrap();
                                                                let v5529:
                                                                                string =
                                                                            fable_library_rust::String_::fromString(v5494);
                                                                let v5538:
                                                                                bool =
                                                                            contains(v5529.clone(),
                                                                                     string("// spiral.process_typescript"));
                                                                let v5547: string = if v5538 {
                                                                    v5529.clone()
                                                                } else {
                                                                    Spiral::method66(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                 string(" defaultOf::<()>();"),
                                                                                                 replace(v5529,
                                                                                                         sprintf!("\"./fable_modules/fable-library-ts.{}/",
                                                                                                                  v5207.clone()),
                                                                                                         sprintf!("\"{}/lib/typescript/fable/fable_modules/fable-library-ts.{}/",
                                                                                                                  v5150,
                                                                                                                  v5207)))
                                                                };
                                                                if (v5538) == false {
                                                                    Spiral::method76(v5382.clone(),
                                                                                             concat(new_array(&[v5547.clone(),
                                                                                                                string("\n\n"),
                                                                                                                string("// spiral.process_typescript"),
                                                                                                                string("\n")])));
                                                                }
                                                                {
                                                                    let v5550: string =
                                                                        concat(new_array(&[
                                                                            string("bun run \""),
                                                                            v5382.clone(),
                                                                            string("\""),
                                                                        ]));
                                                                    let v5552: string =
                                                                        Spiral::method3(string(
                                                                            "PATH",
                                                                        ));
                                                                    let v5592: Spiral::US5 =
                                                                        if (v5552.clone())
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
                                                                                                                          v5552])))
                                                                        };
                                                                    let v5608:
                                                                                    Array<(string,
                                                                                           string)> =
                                                                                toArray(Spiral::method272(Spiral::method271(match &v5592
                                                                                                                                {
                                                                                                                                Spiral::US5::US5_0(v5592_0_0)
                                                                                                                                =>
                                                                                                                                LrcPtr::new(Spiral::UH4::UH4_1(string("PATH"),
                                                                                                                                                               match &v5592
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
                                                                    let v5627: Result<
                                                                        string,
                                                                        string,
                                                                    > = match &v5130 {
                                                                        Spiral::US13::US13_0(
                                                                            v5130_0_0,
                                                                        ) => Ok::<string, string>(
                                                                            v5130_0_0.clone(),
                                                                        ),
                                                                        Spiral::US13::US13_1(
                                                                            v5130_1_0,
                                                                        ) => Err::<string, string>(
                                                                            v5130_1_0.clone(),
                                                                        ),
                                                                    };
                                                                    let patternInput_27:
                                                                                    (i32,
                                                                                     string) =
                                                                                Spiral::method101(v5550.clone(),
                                                                                                  None::<CancellationToken>,
                                                                                                  v5608.clone(),
                                                                                                  None::<Func1<(i32,
                                                                                                                string,
                                                                                                                bool),
                                                                                                               Arc<Async<()>>>>,
                                                                                                  None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                               ()>>,
                                                                                                  true,
                                                                                                  v5627.ok());
                                                                    let v5645: string =
                                                                        patternInput_27.1.clone();
                                                                    let v5644: i32 =
                                                                        patternInput_27.0.clone();
                                                                    let v5646: i32 =
                                                                        get_Count(v5608.clone());
                                                                    let v5647: Array<string> =
                                                                        new_init(
                                                                            &string(""),
                                                                            v5646,
                                                                        );
                                                                    let v5648: LrcPtr<
                                                                        Spiral::Mut5,
                                                                    > = LrcPtr::new(Spiral::Mut5 {
                                                                        l0: MutCell::new(0_i32),
                                                                    });
                                                                    while Spiral::method32(
                                                                        v5646,
                                                                        v5648.clone(),
                                                                    ) {
                                                                        let v5650: i32 =
                                                                            v5648.l0.get().clone();
                                                                        let patternInput_28: (
                                                                            string,
                                                                            string,
                                                                        ) = v5608[v5650].clone();
                                                                        let v5653: string = sprintf!(
                                                                            "$env:{}=\'\'{}\'\'",
                                                                            patternInput_28
                                                                                .0
                                                                                .clone(),
                                                                            patternInput_28
                                                                                .1
                                                                                .clone()
                                                                        );
                                                                        v5647.get_mut()
                                                                            [v5650 as usize] =
                                                                            v5653;
                                                                        {
                                                                            let v5654: i32 =
                                                                                (v5650) + 1_i32;
                                                                            v5648.l0.set(v5654);
                                                                            ()
                                                                        }
                                                                    }
                                                                    {
                                                                        let v5667: string = sprintf!(
                                                                            "pwsh -c \'{}; {}\'",
                                                                            join(
                                                                                string(";"),
                                                                                toArray_1(
                                                                                    ofArray_1(
                                                                                        v5647
                                                                                            .clone(
                                                                                            )
                                                                                    )
                                                                                )
                                                                            ),
                                                                            v5550
                                                                        );
                                                                        let patternInput_29: (
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                        ) = if (v5644) == 0_i32 {
                                                                            let result_3: LrcPtr<
                                                                                MutCell<
                                                                                    Spiral::US5,
                                                                                >,
                                                                            > = refCell(
                                                                                Spiral::US5::US5_1,
                                                                            );
                                                                            try_catch(||
                                                                                                      result_3.set(Spiral::closure69((),
                                                                                                                                     Spiral::closure119(v5645.clone(),
                                                                                                                                                        ()))),
                                                                                                  |ex_3:
                                                                                                       LrcPtr<Exception>|
                                                                                                      result_3.set(Spiral::closure120(v5382.clone(),
                                                                                                                                      v5645.clone(),
                                                                                                                                      v5667.clone(),
                                                                                                                                      ex_3.clone())));
                                                                            {
                                                                                let v5674:
                                                                                                    Spiral::US5 =
                                                                                                result_3.get().clone();
                                                                                let v5685:
                                                                                                    Option<string> =
                                                                                                match &v5674
                                                                                                    {
                                                                                                    Spiral::US5::US5_0(v5674_0_0)
                                                                                                    =>
                                                                                                    Some(match &v5674
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
                                                                                             Spiral::US5::US5_0(v5547),
                                                                                             Spiral::US5::US5_0(v5382.clone()),
                                                                                             Spiral::US5::US5_0(v5685.unwrap()))
                                                                            }
                                                                        } else {
                                                                            let v5694: () = {
                                                                                Spiral::closure122(
                                                                                    v5382,
                                                                                    v5645,
                                                                                    v5644,
                                                                                    v5667,
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
                                                    let v5756: string = Spiral::method189();
                                                    let v5763: &str = &*v5756;
                                                    let v5791: Option<std::string::String> =
                                                        clap::ArgMatches::get_one(
                                                            &v35.clone(),
                                                            v5763,
                                                        )
                                                        .cloned();
                                                    let v5810: Spiral::US7 = defaultValue(
                                                        Spiral::US7::US7_1,
                                                        map(Spiral::method23(), v5791),
                                                    );
                                                    let v5817: std::string::String = match &v5810 {
                                                        Spiral::US7::US7_0(v5810_0_0) => {
                                                            match &v5810 {
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
                                                    let v5819: string =
                                                        fable_library_rust::String_::fromString(
                                                            v5817,
                                                        );
                                                    let v5820: string = Spiral::method25();
                                                    let v5827: &str = &*v5820;
                                                    let v5855: Option<Vec<std::string::String>> =
                                                        clap::ArgMatches::get_many(
                                                            &v35.clone(),
                                                            v5827,
                                                        )
                                                        .map(|x| x.cloned().into_iter().collect());
                                                    let v5874: Spiral::US11 = defaultValue(
                                                        Spiral::US11::US11_1,
                                                        map(Spiral::method26(), v5855),
                                                    );
                                                    let v5880: Vec<std::string::String> =
                                                        new_empty::<std::string::String>().to_vec();
                                                    let v5883: Vec<std::string::String> =
                                                        match &v5874 {
                                                            Spiral::US11::US11_0(v5874_0_0) => {
                                                                match &v5874 {
                                                                    Spiral::US11::US11_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone()
                                                            }
                                                            _ => v5880.clone(),
                                                        };
                                                    let v5884: bool =
                                                        if let Spiral::US0::US0_0 = &v0_1 {
                                                            true
                                                        } else {
                                                            false
                                                        };
                                                    let v5896: Result<Vec<u8>, std::io::Error> =
                                                        std::fs::read(&*v5819);
                                                    let v5941: Vec<u8> =
                                                        Spiral::method27(v5896.unwrap());
                                                    let v5943: Result<
                                                        std::string::String,
                                                        std::string::FromUtf8Error,
                                                    > = std::string::String::from_utf8(v5941);
                                                    let v5947: std::string::String = v5943.unwrap();
                                                    let v5982: string =
                                                        fable_library_rust::String_::fromString(
                                                            v5947,
                                                        );
                                                    let v5994: string = Spiral::method29(sprintf!(
                                                        "{:?}",
                                                        (string("py"), v5982.clone())
                                                    ));
                                                    let v5996: Spiral::US5 =
                                                        Spiral::method35(Spiral::method34());
                                                    let v6002:
                                                                    Spiral::US5 =
                                                                match &v5996 {
                                                                    Spiral::US5::US5_0(v5996_0_0)
                                                                    =>
                                                                    Spiral::US5::US5_0(match &v5996
                                                                                           {
                                                                                           Spiral::US5::US5_0(x)
                                                                                           =>
                                                                                           x.clone(),
                                                                                           _
                                                                                           =>
                                                                                           unreachable!(),
                                                                                       }.clone()),
                                                                    _ =>
                                                                    Spiral::method35(string("c:\\home\\git\\polyglot\\target\\Builder\\spiral")),
                                                                };
                                                    let v6008: Spiral::US5 = match &v6002 {
                                                        Spiral::US5::US5_0(v6002_0_0) => {
                                                            Spiral::US5::US5_0(
                                                                match &v6002 {
                                                                    Spiral::US5::US5_0(x) => {
                                                                        x.clone()
                                                                    }
                                                                    _ => unreachable!(),
                                                                }
                                                                .clone(),
                                                            )
                                                        }
                                                        _ => {
                                                            Spiral::method35(string("/workspaces"))
                                                        }
                                                    };
                                                    let v6012: string = match &v6008 {
                                                        Spiral::US5::US5_0(v6008_0_0) => {
                                                            match &v6008 {
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
                                                    let v6027: string = Spiral::method36(
                                                        if string("deps")
                                                            == (Spiral::method55(v6012.clone()))
                                                        {
                                                            let v6020: Spiral::US5 =
                                                                Spiral::method35(
                                                                    Spiral::method41(v6012.clone())
                                                                        .clone()
                                                                        .unwrap(),
                                                                );
                                                            match &v6020
                                                                                         {
                                                                                         Spiral::US5::US5_0(v6020_0_0)
                                                                                         =>
                                                                                         match &v6020
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
                                                            v6012
                                                        },
                                                        string("polyglot"),
                                                    );
                                                    let v6031: string = toLower(Spiral::method34());
                                                    let v6036: string = toLower(v6027);
                                                    let v6045: Spiral::US13 =
                                                        if startsWith3(v6031, v6036.clone(), false)
                                                        {
                                                            Spiral::US13::US13_1(v6036.clone())
                                                        } else {
                                                            Spiral::US13::US13_0(v6036)
                                                        };
                                                    let v6057: Result<string, string> = match &v6045
                                                    {
                                                        Spiral::US13::US13_0(v6045_0_0) => {
                                                            Ok::<string, string>(v6045_0_0.clone())
                                                        }
                                                        Spiral::US13::US13_1(v6045_1_0) => {
                                                            Err::<string, string>(v6045_1_0.clone())
                                                        }
                                                    };
                                                    let v6059: bool = true;
                                                    let _result_unwrap_or_else = v6057
                                                        .unwrap_or_else(|x| {
                                                            //;
                                                            let v6061: string = x;
                                                            let v6063: bool = true;
                                                            v6061
                                                        });
                                                    let v6065: string = _result_unwrap_or_else;
                                                    let v6070: string = Spiral::method209(
                                                        Spiral::US5::US5_0(v5994.clone()),
                                                        string("spiral"),
                                                        Spiral::US42::US42_0(Spiral::US41::US41_2),
                                                        v6065.clone(),
                                                    );
                                                    let v6076: string = Spiral::method210(
                                                        v5982,
                                                        string("spiral"),
                                                        LrcPtr::new(Spiral::UH2::UH2_0),
                                                        LrcPtr::new(Spiral::UH4::UH4_1(
                                                            string("Fable.Core"),
                                                            string("4.3.0"),
                                                            LrcPtr::new(Spiral::UH4::UH4_0),
                                                        )),
                                                        v6070.clone(),
                                                        v6065.clone(),
                                                    );
                                                    Spiral::method218(Spiral::method36(Spiral::method36(v6065,
                                                                                                                string("lib/python/fable/fable_modules")),
                                                                                               string("fable_library")),
                                                                              Spiral::method36(v6070.clone(),
                                                                                               string("fable_modules/fable_library")));
                                                    {
                                                        let patternInput_31: (i32, string) =
                                                            Spiral::method219(
                                                                Spiral::US39::US39_1,
                                                                v6070.clone(),
                                                                string("py"),
                                                                v6076,
                                                                v6045.clone(),
                                                            );
                                                        let v6085: string =
                                                            patternInput_31.1.clone();
                                                        let v6084: i32 = patternInput_31.0.clone();
                                                        let patternInput_35: (
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                            Spiral::US5,
                                                        ) = if (v6084) != 0_i32 {
                                                            let v6092: () = {
                                                                Spiral::closure123(
                                                                    v6085.clone(),
                                                                    v6084,
                                                                    (),
                                                                );
                                                                ()
                                                            };
                                                            (
                                                                Spiral::US5::US5_0(string("py")),
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_1,
                                                                Spiral::US5::US5_0(v6085),
                                                            )
                                                        } else {
                                                            let v6144: bool = true;
                                                            let _vec_map : Vec<_> = v5883.into_iter().map(|x| { //;
                                                                        let v6146:
                                                                                std::string::String =
                                                                            x;
                                                                        let v6148:
                                                                                string =
                                                                            fable_library_rust::String_::fromString(v6146);
                                                                        let v6156:
                                                                                string =
                                                                            if contains(v6148.clone(),
                                                                                        string("="))
                                                                               {
                                                                                v6148.clone()
                                                                            } else {
                                                                                concat(new_array(&[string("\""),
                                                                                                   v6148,
                                                                                                   string("\":\"*\"")]))
                                                                            };
                                                                        let v6158:
                                                                                bool =
                                                                            true; v6156 }).collect::<Vec<_>>();
                                                            let v6160: Vec<string> = _vec_map;
                                                            let v6162:
                                                                                Array<string> =
                                                                            fable_library_rust::NativeArray_::array_from(v6160.clone());
                                                            let v6181: string = join(
                                                                string(",\n"),
                                                                toArray_1(delay(Func0::new({
                                                                    let v6162 = v6162.clone();
                                                                    move || {
                                                                        map_1(
                                                                            Func1::new({
                                                                                let v6162 =
                                                                                    v6162.clone();
                                                                                move |i_4: i32| {
                                                                                    v6162[i_4]
                                                                                        .clone()
                                                                                }
                                                                            }),
                                                                            rangeNumeric(
                                                                                0_i32,
                                                                                1_i32,
                                                                                (get_Count(
                                                                                    v6162.clone(),
                                                                                )) - 1_i32,
                                                                            ),
                                                                        )
                                                                    }
                                                                }))),
                                                            );
                                                            let v6197:
                                                                                string =
                                                                            append((append((append((append((append((append((append(string("{"),
                                                                                                                                   (concat(new_array(&[string("  \"name\": \"spiral_"),
                                                                                                                                                       v5994,
                                                                                                                                                       string("\",")]))))),
                                                                                                                           string("  \"dependencies\": {"))),
                                                                                                                   (v6181))),
                                                                                                           string("  },"))),
                                                                                                   string("    \"devDependencies\": {"))),
                                                                                           string("  },"))),
                                                                                   string("}"));
                                                            let v6199: string = Spiral::method36(
                                                                v6070.clone(),
                                                                string("package.json"),
                                                            );
                                                            let v6202: string = Spiral::method36(
                                                                Spiral::method36(
                                                                    v6070.clone(),
                                                                    string("../.."),
                                                                ),
                                                                string("package.json"),
                                                            );
                                                            Spiral::method76(v6199, v6197);
                                                            Spiral::method76(v6202, string(""));
                                                            {
                                                                let v6205: string =
                                                                    Spiral::method36(
                                                                        v6070,
                                                                        concat(new_array(&[
                                                                            string("spiral"),
                                                                            string("."),
                                                                            string("py"),
                                                                        ])),
                                                                    );
                                                                let v6208: () = {
                                                                    Spiral::closure124(
                                                                        v6205.clone(),
                                                                        (),
                                                                    );
                                                                    ()
                                                                };
                                                                let v6266: Result<
                                                                    Vec<u8>,
                                                                    std::io::Error,
                                                                > = std::fs::read(&*v6205.clone());
                                                                let v6311: Vec<u8> =
                                                                    Spiral::method27(
                                                                        v6266.unwrap(),
                                                                    );
                                                                let v6313: Result<
                                                                    std::string::String,
                                                                    std::string::FromUtf8Error,
                                                                > = std::string::String::from_utf8(
                                                                    v6311,
                                                                );
                                                                let v6317: std::string::String =
                                                                    v6313.unwrap();
                                                                let v6352:
                                                                                    string =
                                                                                fable_library_rust::String_::fromString(v6317);
                                                                let v6361: bool = contains(
                                                                    v6352.clone(),
                                                                    string(
                                                                        "# spiral.process_python",
                                                                    ),
                                                                );
                                                                let v6373: string = if v6361 {
                                                                    v6352.clone()
                                                                } else {
                                                                    Spiral::method66(string("\\s\\sdefaultOf\\(\\);"),
                                                                                                     string(" defaultOf::<()>();"),
                                                                                                     replace(v6352,
                                                                                                             append(string("),)"),
                                                                                                                    (";".into())),
                                                                                                             string("));")))
                                                                };
                                                                if (v6361) == false {
                                                                    Spiral::method76(v6205.clone(),
                                                                                                 concat(new_array(&[v6373.clone(),
                                                                                                                    string("\n\n"),
                                                                                                                    string("# spiral.process_python"),
                                                                                                                    string("\n")])));
                                                                }
                                                                {
                                                                    let v6376: string =
                                                                        concat(new_array(&[
                                                                            string("python \""),
                                                                            v6205.clone(),
                                                                            string("\""),
                                                                        ]));
                                                                    let v6379: Array<(
                                                                        string,
                                                                        string,
                                                                    )> = new_array(&[(
                                                                        string("TRACE_LEVEL"),
                                                                        string("Verbose"),
                                                                    )]);
                                                                    let v6396: Result<
                                                                        string,
                                                                        string,
                                                                    > = match &v6045 {
                                                                        Spiral::US13::US13_0(
                                                                            v6045_0_0,
                                                                        ) => Ok::<string, string>(
                                                                            v6045_0_0.clone(),
                                                                        ),
                                                                        Spiral::US13::US13_1(
                                                                            v6045_1_0,
                                                                        ) => Err::<string, string>(
                                                                            v6045_1_0.clone(),
                                                                        ),
                                                                    };
                                                                    let patternInput_32:
                                                                                        (i32,
                                                                                         string) =
                                                                                    Spiral::method101(v6376.clone(),
                                                                                                      None::<CancellationToken>,
                                                                                                      v6379.clone(),
                                                                                                      None::<Func1<(i32,
                                                                                                                    string,
                                                                                                                    bool),
                                                                                                                   Arc<Async<()>>>>,
                                                                                                      None::<Func1<std::sync::Arc<std::sync::Mutex<std::process::ChildStdin>>,
                                                                                                                   ()>>,
                                                                                                      true,
                                                                                                      v6396.ok());
                                                                    let v6414: string =
                                                                        patternInput_32.1.clone();
                                                                    let v6413: i32 =
                                                                        patternInput_32.0.clone();
                                                                    let v6415: i32 =
                                                                        get_Count(v6379.clone());
                                                                    let v6416: Array<string> =
                                                                        new_init(
                                                                            &string(""),
                                                                            v6415,
                                                                        );
                                                                    let v6417: LrcPtr<
                                                                        Spiral::Mut5,
                                                                    > = LrcPtr::new(Spiral::Mut5 {
                                                                        l0: MutCell::new(0_i32),
                                                                    });
                                                                    while Spiral::method32(
                                                                        v6415,
                                                                        v6417.clone(),
                                                                    ) {
                                                                        let v6419: i32 =
                                                                            v6417.l0.get().clone();
                                                                        let patternInput_33: (
                                                                            string,
                                                                            string,
                                                                        ) = v6379[v6419].clone();
                                                                        let v6422: string = sprintf!(
                                                                            "$env:{}=\'\'{}\'\'",
                                                                            patternInput_33
                                                                                .0
                                                                                .clone(),
                                                                            patternInput_33
                                                                                .1
                                                                                .clone()
                                                                        );
                                                                        v6416.get_mut()
                                                                            [v6419 as usize] =
                                                                            v6422;
                                                                        {
                                                                            let v6423: i32 =
                                                                                (v6419) + 1_i32;
                                                                            v6417.l0.set(v6423);
                                                                            ()
                                                                        }
                                                                    }
                                                                    {
                                                                        let v6436: string = sprintf!(
                                                                            "pwsh -c \'{}; {}\'",
                                                                            join(
                                                                                string(";"),
                                                                                toArray_1(
                                                                                    ofArray_1(
                                                                                        v6416
                                                                                            .clone(
                                                                                            )
                                                                                    )
                                                                                )
                                                                            ),
                                                                            v6376
                                                                        );
                                                                        let patternInput_34: (
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                            Spiral::US5,
                                                                        ) = if (v6413) == 0_i32 {
                                                                            let result_4: LrcPtr<
                                                                                MutCell<
                                                                                    Spiral::US5,
                                                                                >,
                                                                            > = refCell(
                                                                                Spiral::US5::US5_1,
                                                                            );
                                                                            try_catch(||
                                                                                                          result_4.set(Spiral::closure69((),
                                                                                                                                         Spiral::closure125(v6414.clone(),
                                                                                                                                                            ()))),
                                                                                                      |ex_4:
                                                                                                           LrcPtr<Exception>|
                                                                                                          result_4.set(Spiral::closure126(v6205.clone(),
                                                                                                                                          v6414.clone(),
                                                                                                                                          v6436.clone(),
                                                                                                                                          ex_4.clone())));
                                                                            {
                                                                                let v6443:
                                                                                                        Spiral::US5 =
                                                                                                    result_4.get().clone();
                                                                                let v6454:
                                                                                                        Option<string> =
                                                                                                    match &v6443
                                                                                                        {
                                                                                                        Spiral::US5::US5_0(v6443_0_0)
                                                                                                        =>
                                                                                                        Some(match &v6443
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
                                                                                                 Spiral::US5::US5_0(v6373),
                                                                                                 Spiral::US5::US5_0(v6205.clone()),
                                                                                                 Spiral::US5::US5_0(v6454.unwrap()))
                                                                            }
                                                                        } else {
                                                                            let v6463: () = {
                                                                                Spiral::closure128(
                                                                                    v6205,
                                                                                    v6414,
                                                                                    v6413,
                                                                                    v6436,
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
                                                    let v6524: () = {
                                                        Spiral::closure129(v35, v34, ());
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
                                        let v6586: Spiral::US5 = patternInput_38.3.clone();
                                        let v6585: Spiral::US5 = patternInput_38.2.clone();
                                        let v6584: Spiral::US5 = patternInput_38.1.clone();
                                        let v6583: Spiral::US5 = patternInput_38.0.clone();
                                        new_array(&[
                                            (
                                                string("extension"),
                                                match &v6583 {
                                                    Spiral::US5::US5_0(v6583_0_0) => match &v6583 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => string(""),
                                                },
                                            ),
                                            (
                                                string("code"),
                                                match &v6584 {
                                                    Spiral::US5::US5_0(v6584_0_0) => match &v6584 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => string(""),
                                                },
                                            ),
                                            (
                                                string("code_path"),
                                                match &v6585 {
                                                    Spiral::US5::US5_0(v6585_0_0) => match &v6585 {
                                                        Spiral::US5::US5_0(x) => x.clone(),
                                                        _ => unreachable!(),
                                                    }
                                                    .clone(),
                                                    _ => string(""),
                                                },
                                            ),
                                            (
                                                string("output"),
                                                match &v6586 {
                                                    Spiral::US5::US5_0(v6586_0_0) => match &v6586 {
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
                    let v6620: Vec<(string, string)> = v6618.to_vec();
                    let v6623: bool = true;
                    let _func1_from_v6621 = Func1::from(move |value| {
                        //;
                        let patternInput_39: (string, string) = value;
                        let v6633: &str = &*patternInput_39.0.clone();
                        let v6666: std::string::String = String::from(v6633);
                        let v6699: &str = &*patternInput_39.1.clone();
                        let v6732: std::string::String = String::from(v6699);
                        let v6765: bool = true;
                        LrcPtr::new((v6666, v6732)) /*;
                                                    let v6767: bool = */
                    }); //;
                    let v6769: Func1<
                        (string, string),
                        LrcPtr<(std::string::String, std::string::String)>,
                    > = _func1_from_v6621;
                    let v6772: Vec<LrcPtr<(std::string::String, std::string::String)>> = v6620
                        .into_iter()
                        .map(|x| {
                            Func1::new({
                                let v6769 = v6769.clone();
                                move |arg10_0040_29: (string, string)| {
                                    Spiral::closure74(v6769.clone(), arg10_0040_29)
                                }
                            })(x.clone())
                        })
                        .collect::<Vec<_>>();
                    let v6773: string =
                string("std::collections::BTreeMap::from_iter(v6772.iter().map(|x| x.as_ref()).map(|&(ref k, ref v)| (k.clone(), v.clone())))");
                    let v6774: std::collections::BTreeMap<
                        std::string::String,
                        std::string::String,
                    > = std::collections::BTreeMap::from_iter(
                        v6772
                            .iter()
                            .map(|x| x.as_ref())
                            .map(|&(ref k, ref v)| (k.clone(), v.clone())),
                    );
                    let v6776: Result<std::string::String, serde_json::Error> =
                        serde_json::to_string(&v6774);
                    let v6777 = Spiral::method282();
                    let v6781: Result<std::string::String, string> = v6776.map_err(|x| v6777(x));
                    let v6794: bool = true;
                    let _result_map_ = v6781.map(|x| {
                        //;
                        let v6796: std::string::String = x;
                        let v6798: string = fable_library_rust::String_::fromString(v6796);
                        let v6800: bool = true;
                        v6798
                    });
                    let v6802: Result<string, string> = _result_map_;
                    let v6805: string = string("}");
                    let v6810: bool = true;
                    let _fix_closure_v6807 = v6802;
                    let v6817: string = append(
                        (append(
                            (append(
                                (append(string("true; _fix_closure_v6807 "), (v6805))),
                                string("); "),
                            )),
                            string(""),
                        )),
                        string(" // rust.fix_closure\'"),
                    );
                    let v6818: bool = true;
                    _fix_closure_v6807
                },
            ); // rust.fix_closure';
            let v6820 = __future_init;
            v6820
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
